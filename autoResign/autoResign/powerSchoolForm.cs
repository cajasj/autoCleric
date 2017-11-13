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
        Thread retryThread;
        Thread credInput;
        public ChromiumWebBrowser chrome;
        public credentialInput retryInput;
        public delegate void delegateRetry();
        public delegate void delegateChecks(string script, string log1, string log2);
        private string user="";
        private string pass="";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        private int count = 0;
        private bool loginFail = true;
        private bool threadRetry = false;
        private string foundLogOut = "login success";
        private string foundLogIn = "login Fail";
        private string delegateMessage = "";
        const string checkLogout = @"(function(){ " +
                     "if( document.getElementById('btnLogout')){" +
                     "  return true" +
                     "}else {" +
                     "  return false" +
                     "} " +
                     "})();";

        const string checkLogin = @"(function(){ " +
                "if( document.getElementById('btnEnter')){" +
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
            delegateMessage = "\n\nwe're in auto login method now \n\n";
            loadJS(loginThread,delegateMessage);
            delegateMessage = "\n\nwe're checking login button \n\n";



            Console.WriteLine(delegateMessage);
           
                loadCheckJS(checkLoginButton, foundLogIn, foundLogOut, checkLogout);
           
            Console.WriteLine("after check methold loginfail is :" + loginFail);

        
                if (loginFail == false)
                {
                    Console.WriteLine("/n/nfound logout button /n/n");

                }
                else
                {
                    delegateMessage = "\n\nwe're in retry login now " + loginFail.ToString() + " thisfailholder \n\n";

                    loadJS(retryLog, delegateMessage);

                }
            
            //delegateRetry retryLogMethod = retryLog;




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
        public void loadJS(delegateRetry methodName, string message) {
            
            chrome.FrameLoadEnd += (sender, args) =>
            {
                
                if (args.Frame.IsMain)
                {
                    Console.WriteLine(message);
                    methodName();
                }
                // turn this into a method

            };
        }
        public void loadCheckJS(delegateChecks methodCheck,string log1, string log2, string checkScript)
        {
           
            chrome.FrameLoadEnd += (sender, args) =>
            {
                if (!args.Frame.IsMain)
                {
                    Console.WriteLine(this.delegateMessage);
                    methodCheck(checkScript,log1,log2); 
                }
                // turn this into a method

            };
        }
        public void loginThread()
        {

            retryThread = new Thread(() => jsLogin());
            retryThread.Start();

            count++;
            Console.WriteLine("count is " + count);
            while (retryThread.IsAlive) ;
            retryThread.Abort();
            Console.WriteLine("login thread done");
        }
        public void retryLog()
        {
            MessageBox.Show("wrong credential please enter again");
            retryInput = new credentialInput();
            credInput = new Thread(() => retryInput.ShowDialog());
            credInput.Start();
            while (credInput.IsAlive) ;
            Console.WriteLine("cred input thread done");

            this.user = retryInput.getName;
            this.pass = retryInput.getPass;
            Console.WriteLine(this.user + " using properties " + this.pass);
            credInput.Abort();
            chrome.Load(url);
            //this needs to be passed into load js
        }
    
        private void powerSchoolForm_FormClosing(object sender, FormClosingEventArgs e)
        { 
            Cef.Shutdown();  
            this.Dispose();
        }

        private void jsLogin()
        {
            var autoUser = string.Format("document.getElementById('fieldUsername').value ='{0}';", this.user);
            var autoPass = string.Format("document.getElementById('fieldPassword').value ='{0}';", this.pass);
            var autologin = string.Format("document.getElementById('btnEnter').click();");

            chrome.ExecuteScriptAsync(autoUser);
            chrome.ExecuteScriptAsync(autoPass);
            chrome.ExecuteScriptAsync(autologin);
            retryThread.Abort();
            
        }

        private void checkLoginButton(string checkArg,string logout, string login)
        {
            
            string log="in check log if response result is ";
            chrome.EvaluateScriptAsync(checkArg).ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    var response = t.Result;
                    if (response.Success && response.Result != null )
                    {
                        if ((bool)response.Result == true)
                        {
                            Console.WriteLine(log + (bool)response.Result + " failholder now " + loginFail);
                            loginFail = (bool)response.Result;
                        }
                        else if ((bool)response.Result == false)
                        {
                            Console.WriteLine(log + (bool)response.Result + " else failholder now " + loginFail);
                            loginFail = (bool)response.Result;
                        }

                         
                    }
                    
                }
            });
        }
    }
}
//if (this.logoutFail == true)
//                    {
//    checkLoginButton(checkLogout, foundLogoOut, foundLogIn);
//    this.logoutFail = this.failHolder;
//    Console.WriteLine("did it found logout button? " + logoutFail);
//}
//                    else
//                    {
//    checkLoginButton(checkButton, foundLogIn, foundLogoOut);
//    this.loginFail = this.failHolder;
//    Console.WriteLine("did it found login button? " + loginFail);
//}
//                    //branding-powerschool id 
//                    //input id is fieldUsername name username type text
//                    //input id is fieldPassword type apssword name password
//                    //button typ submit id btnEnter value "Enter"
//else
//                 {
//                     MessageBox.Show("wrong credential please enter again");
//                     retryInput = new credentialInput();
//credInput = new Thread(()=>retryInput.ShowDialog());
//credInput.Start();
//                     while (credInput.IsAlive) ;
//                     this.user = retryInput.getName;
//                     this.pass = retryInput.getPass;
//                     Console.WriteLine(this.user + " using properties " + this.pass);
//credInput.Abort();
//                     this.loginFail = true;
//                    this.logoutFail = true;
//chrome.Load(url);
//}