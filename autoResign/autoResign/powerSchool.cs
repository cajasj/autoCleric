using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoResign
{
    public partial class powerSchool : Form
    {
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        Thread retryThread;
        Thread credInput;
        Thread checkThread;
        protected ChromiumWebBrowser chrome;
        public credentialInput retryInput;
        private string user = "";
        private string pass = "";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        private int count = 0;
        protected bool loginSuccess = false;
        private bool foundLogOut = true;
        protected bool foundLogIn = true;
        private string menu = "menu";
        const string checkLogOut = @"(function(){ " +
                     "if( document.getElementById('btnLogout')){" +
                     "  return true" +
                     "}else {" +
                     "  return false" +
                     "} " +
                     "})();";
        private const string multiSelect = @"(function(){" +
                                           "var multiSelectClass='dialogDivM'" +
                                           "var frameContent = window.frames['content'];" +
                                           "var multiSelectLink = frameContent.getElementsByClassName(multiSelectClass);" +
                                           "console.log(multiSelectLink);" +
                                           "multiSelectLink[0].click();" +
                                           "})()";
        /*   const string loopCustomScreens = ("(function('menu'){" +
                     "var frameMenu=window.frames['{0}'];" +
                     "var list = frameMenu.document.getElementById('tchr_information');" +
                     "var listItem = list.getElementsByTagName('a');" +
                     "var anchorText='Security Settings';" +
                     "for(var i =0; i<listItem.length; i++){ " +
                          "if(listItem[i].text==anchorText){	" +
                              "listItem[i].click();" +
                              "break;" +
                          "}" +
                      "}" +
                      "})();");*/
        const string traverseTabs = @"(function(){" +
                 "var frameMenu=window.frames['content'];" +
                 "var tabItems = frameMenu.document.querySelectorAll('ul.tabs');" +
                 "var tabList =tabItems[0].getElementsByTagName('a');" +
                 "var tabText='Admin Access and Roles';" +
                 "for(var i =0; i<tabList.length; i++){ " +
                      "if(tabList[i].innerText==tabText){	" +
                          "tabList[i].click();" +
                          "break;" +
                      "}" +
                  "}" +
                  "})();";
        const string checkTagDebug = @"(function(){ " +
                    "if( document.getElementById('tchr_custom_pages')){" +
                    "  return true" +
                    "}else {" +
                    "  return false" +
                    "} " +
                    "})();";

        public virtual void loginUser(string uName, string uPass)
        {

            user = uName;
            var pass = uPass;
            string webSite=url;


            initChrome();
            loadJS(user, pass);
            
            loadCheckJS(webSite); 
         //   searchTeacher();

        }

        public powerSchool()
        {

            InitializeComponent(); 
         
        }
        private void powerSchool_Load(object sender, EventArgs e)
        {
            Debug.WriteLine(user + " test load " + pass);
        }

        public void initChrome()
        {
           
            Console.WriteLine("inititalize chrome");
            CefSettings settings = new CefSettings();
            settings.RemoteDebuggingPort = 8088;
            Cef.Initialize(settings);
            chrome = new ChromiumWebBrowser(url);
            Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;

        }

        public virtual void loadJS(string userText, string passText)
        {

            chrome.FrameLoadEnd += (sender, args) =>
            {
                
                if (args.Frame.IsMain && loginSuccess == false)
                {
                    if (foundLogOut == false)
                    {
                        
                        MessageBox.Show("wrong credential please enter again");
                        retryInput = new credentialInput();
                        credInput = new Thread(() => retryInput.ShowDialog());
                        credInput.Start();
                        while (credInput.IsAlive) ;
                        userText = retryInput.getName;
                        passText = retryInput.getPass;

                    }
                    retryThread = new Thread(() => jsLogin(args, userText, passText));
                    retryThread.Start();
                    while (retryThread.IsAlive);
                }
            };
        }
        protected virtual void loadCheckJS(string siteName)
        {
            chrome.FrameLoadEnd += (sender, args) =>
            {
                if (args.Frame.IsMain)
                {
                    checkThread = new Thread(() => checkLoginButton(checkLogOut,siteName));
                    checkThread.Start();
                    ///  autoResetEvent.WaitOne();
                }
            };
        }
        private void checkLoginButton(string checkArg,string urlSite)
        {

            bool localBool = false;
            chrome.EvaluateScriptAsync(checkArg).ContinueWith(t =>
            {
                if (!t.IsFaulted && loginSuccess == false)
                {
                    var response = t.Result;
                    if (response.Success && response.Result != null)
                    {
                        localBool = (bool)response.Result;


                        foundLogOut = localBool;
                        foundLogIn = !localBool;

                        if (foundLogIn == false && foundLogOut == true)
                        {
                            loginSuccess = true;
                            chrome.Load(urlSite);
                        }
                        //autoResetEvent.Set();
                    }
                }
            });
            checkThread.Abort();
        }
        protected virtual void jsLogin(FrameLoadEndEventArgs args, string logUser, string logPass)
        {
            var autoUser = string.Format("document.getElementById('fieldUsername').value ='{0}';", logUser);
            var autoPass = string.Format("document.getElementById('fieldPassword').value ='{0}';", logPass);
            var autologin = string.Format("document.getElementById('btnEnter').click();");

            args.Frame.ExecuteJavaScriptAsync(autoUser);
            args.Frame.ExecuteJavaScriptAsync(autoPass);
            args.Frame.ExecuteJavaScriptAsync(autologin);

            retryThread.Abort();

        }

        private void powerSchool_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
            this.Dispose();
        }


        private void searchTeacher()
        {
            chrome.FrameLoadEnd += (sender, args) =>
            {
                if (args.Frame.IsMain && loginSuccess == true)
                {
                    autoSearch(args);
                }
            };
        }
        private void autoSearch(FrameLoadEndEventArgs args)
        {
            string fNameContains = "first_name contains Jennifer";
            string lNameContains = "; last_name contains Hale";
            var fillTeacherField = string.Format("document.getElementById('teacherSearchInput').value ='{0}{1}';", fNameContains, lNameContains);
            var clickSearch = string.Format("document.getElementById('btnSearch').click();");
            args.Frame.ExecuteJavaScriptAsync(fillTeacherField);
            args.Frame.ExecuteJavaScriptAsync(clickSearch);
            searchListItems(args);
        }
        private void searchListItems(FrameLoadEndEventArgs args)
        {

            //args.Frame.ExecuteJavaScriptAsync(loopCustomScreens);


        }

        private void powerSchool_Load_1(object sender, EventArgs e)
        {

        }


  
        //studentSearchInput id for student input
        //teacherSearchInput id for teacher input

    }
}