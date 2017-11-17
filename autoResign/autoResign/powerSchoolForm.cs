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
        private string user="";
        private string pass="";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        private int count = 0;
        private bool loginFail = false;
        private bool foundLogOut = false;
        protected bool foundLogIn = false;

        const string checkLogOut = @"(function(){ " +
                     "if( document.getElementById('btnLogout')){" +
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
            
            Console.WriteLine("line 56 found logout is anad login fail is " + foundLogOut + " " + loginFail);
            if (foundLogOut == false)
            {

                loadJS();

                loadCheckJS();
                Console.WriteLine("line 60 foundlog out is false and foundin is " + foundLogIn);
                foundLogIn = loginFail;
                foundLogOut = loginFail;

            }
            else
            {
                foundLogIn = true;

            }
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
        public void loadJS() {
             
            chrome.FrameLoadEnd += (sender, args) =>
            {
                
                Console.WriteLine("LINE 84foundlogin before frame load " + foundLogIn);
                if (args.Frame.IsMain)
                {
                    if (foundLogIn == false)
                    {
                        retryThread = new Thread(() => jsLogin(args));
                        
                        retryThread.Start();
                      //  autoResetEvent.WaitOne();
                        //  autoResetEvent = new AutoResetEvent(false);

                        count++;
                        Console.WriteLine("count is " + count);
                        while (retryThread.IsAlive) ;

                        //branding-powerschool id 
                        //input id is fieldUsername name username type text
                        //input id is fieldPassword type apssword name password
                        //button typ submit id btnEnter value "Enter"
                    }
                    else if (foundLogOut == false)
                    {
                        Console.WriteLine("\n\n LINE 105 before the message box show \n\n");
                        MessageBox.Show("wrong credential please enter again");
                        retryInput = new credentialInput();
                        credInput = new Thread(() => retryInput.ShowDialog());
                        credInput.Start();
                        while (credInput.IsAlive) ;
                        user = retryInput.getName;
                        pass = retryInput.getPass;
                        Console.WriteLine(user + " using properties " + pass);
                        credInput.Abort();
                        chrome.Load(url);
                    }
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
            //autoResetEvent.Set();
            retryThread.Abort();
            
        }
        //private void OnLoadingStageChanged(object sender, LoadingStateChangedEventArgs args)
        //{
        //    if (args.IsLoading == false)
        //    {
        //        checkLoginButton(checkLogOut, ref loginFail);
        //    }
        //}
        private void loadCheckJS() {
            chrome.FrameLoadEnd += (sender, args) =>
                {
                    if (args.Frame.IsMain)
                    {
                       checkThread = new Thread(() => checkLoginButton(checkLogOut, ref loginFail));
                        checkThread.Start();
                    }
                    };
            }
        private void checkLoginButton(string checkArg,ref bool loginfail)
        {

            bool localBool=false;
            chrome.EvaluateScriptAsync(checkArg).ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    var response = t.Result;
                    if (response.Success && response.Result != null)
                    {
                        localBool = (bool)response.Result;
                        Console.WriteLine("\n\n LINE 162 local bool in if statement is "+localBool);

                        loginFail = localBool;
                        foundLogIn = localBool;
                        autoResetEvent.Set();
                    }
                }
            });
            autoResetEvent.WaitOne();
            Console.WriteLine("\n\n LINE 166 pass by reference loginfail is " + loginFail + " local bool is " +localBool);
            //foundLogIn = localBool;
            //loginFail = localBool;
        }
    }
}