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
    public partial class powerSchoolForm : Form
    {
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        Thread retryThread;
        Thread credInput;
        Thread checkThread;
        public ChromiumWebBrowser chrome;
        public credentialInput retryInput;
        private string user = "";
        private string pass = "";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        private string staffURL = "https://bridgeportedu.powerschool.com/admin/faculty/search.html";
        private int count = 0;
        private bool loginSuccess = false;
        private bool foundLogOut = true;
        protected bool foundLogIn = true;

        const string checkLogOut = @"(function(){ " +
                     "if( document.getElementById('btnLogout')){" +
                     "  return true" +
                     "}else {" +
                     "  return false" +
                     "} " +
                     "})();";
        const string loopCustomScreens = @"(function(){" +
                   "var frameMenu=window.frames['menu'];" +
                   "var list = frameMenu.document.getElementById('tchr_custom_pages');" +
                   "var listItem = list.getElementsByTagName('a');" +
                   "var anchorText='Conversion Data';" +
                   "for(var i =0; i<listItem.length; i++){ " +
                        "if(listItem[i].text==anchorText){	" +
                            "listItem[i].click();" +
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
        public powerSchoolForm(string uName, string uPass)
        {

            user = uName;
            pass = uPass;
            InitializeComponent();
            initChrome();
            //chrome.LoadingStateChanged += OnLoadingStageChanged;]
            Console.WriteLine("line 56 found logout is anad login fail is " + foundLogOut + " " + foundLogIn);
            loadJS();
            loadCheckJS();
            searchTeacher();
            Console.WriteLine("line 60 foundlog out is false and foundin is " + foundLogIn);
           
        }

        private void powerSchoolForm_Load(object sender, EventArgs e)
        {
            Debug.WriteLine(user + " test load " + pass);
        }

        public void initChrome()
        {

            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            chrome = new ChromiumWebBrowser(url);
            this.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;

        }
        public void loadJS()
        {
            Console.WriteLine("line 80 found logout is anad login fail is " + foundLogOut + " " + foundLogIn);

            chrome.FrameLoadEnd += (sender, args) =>
            {

                Console.WriteLine("LINE 84foundlogin before frame load " + foundLogIn);
                if (args.Frame.IsMain && loginSuccess == false)
                {
                    if (foundLogOut == false)
                    {

                        Console.WriteLine("\n\n LINE 105 before the message box show \n\n");
                        MessageBox.Show("wrong credential please enter again");
                        retryInput = new credentialInput();
                        credInput = new Thread(() => retryInput.ShowDialog());
                        credInput.Start();
                        while (credInput.IsAlive) ;
                        this.user = retryInput.getName;
                        this.pass = retryInput.getPass;
                        Console.WriteLine(user + " using properties " + pass);
                        Console.WriteLine("count is " + count);

                    }
                    retryThread = new Thread(() => jsLogin(args));
                    retryThread.Start();
                    Console.WriteLine("count is " + count);
                    while (retryThread.IsAlive) ;
                }
            };
        }

        private void powerSchoolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
            this.Dispose();
        }

        private void jsLogin(FrameLoadEndEventArgs args)
        {
            var autoUser = string.Format("document.getElementById('fieldUsername').value ='{0}';", this.user);
            var autoPass = string.Format("document.getElementById('fieldPassword').value ='{0}';", this.pass);
            var autologin = string.Format("document.getElementById('btnEnter').click();");

            args.Frame.ExecuteJavaScriptAsync(autoUser);
            args.Frame.ExecuteJavaScriptAsync(autoPass);
            args.Frame.ExecuteJavaScriptAsync(autologin);

            retryThread.Abort();

        }
        //studentSearchInput id for student input
        //teacherSearchInput id for teacher input
        private void loadCheckJS()
        {
            chrome.FrameLoadEnd += (sender, args) =>
            {
                if (args.Frame.IsMain)
                {
                    checkThread = new Thread(() => checkLoginButton(checkLogOut));
                    checkThread.Start();
                  ///  autoResetEvent.WaitOne();
                }
            };
        }
        private void searchTeacher()
        {
            chrome.FrameLoadEnd += (sender, args) =>
            {
                if (args.Frame.IsMain && loginSuccess==true)
                {
                    Console.WriteLine("\n\n\nin the search teacher function \n\n\n");
                    autoSearch(args);
                }
            };
        }
        private void autoSearch(FrameLoadEndEventArgs args)
        {
            string fNameContains = "first_name contains ";
            string lNameContains = " ; last_name contains ";
            var fillTeacherField = string.Format("document.getElementById('teacherSearchInput').value ='{0}{1}{2}{3}';", fNameContains, " ",lNameContains," ");
            var clickSearch= string.Format("document.getElementById('btnSearch').click();");
            args.Frame.ExecuteJavaScriptAsync(fillTeacherField);
            args.Frame.ExecuteJavaScriptAsync(clickSearch);
            searchListItems(args);
        }
        private void searchListItems(FrameLoadEndEventArgs args)
        {
            args.Frame.ExecuteJavaScriptAsync(loopCustomScreens);


        }
        private void checkLoginButton(string checkArg)
        {

            bool localBool = false;
            chrome.EvaluateScriptAsync(checkArg).ContinueWith(t =>
            {
                if (!t.IsFaulted && loginSuccess==false)
                {
                    var response = t.Result;
                    if (response.Success && response.Result != null)
                    {
                        localBool = (bool)response.Result;
                        Console.WriteLine("\n\n LINE 162 local bool in if statement is " + localBool);


                        foundLogOut = localBool;
                        foundLogIn = !localBool;

                        if (foundLogIn == false && foundLogOut == true)
                        {
                            Console.WriteLine("where found in false found out true");
                            loginSuccess = true;
                            chrome.Load(staffURL);
                        }
                        //autoResetEvent.Set();
                    }
                    Console.WriteLine("response success and resut " + response.Success + " " + response.Result);
                }
            });
            Console.WriteLine("\n\n LINE 166 foundlogin is " + foundLogIn + " found logout is " + foundLogOut);
            checkThread.Abort();
        }
    }
}