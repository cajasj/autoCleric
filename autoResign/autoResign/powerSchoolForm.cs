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
        public ChromiumWebBrowser chrome;
        public credentialInput retryInput;
        private string currenturl = "";
        private string user="";
        private string pass="";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        private int count = 0;
        private bool loginFail = false;
        public powerSchoolForm(string uName, string uPass)
        {
            user = uName;
            pass = uPass;
            InitializeComponent();
            initChrome();
            loadJS();
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
                 if (args.Frame.IsMain && ! this.loginFail)
                 {
                     
                     retryThread = new Thread(() => jsLogin(args));
                     retryThread.Start();
                     
                     count++;
                     Console.WriteLine("count is " + count);
                     while (retryThread.IsAlive);
                     
                     checkLoginButton();
                                  
                     //input id is fieldUsername name username type text
                     //input id is fieldPassword type apssword name password
                     //button typ submit id btnEnter value "Enter"
                 }else{
                     
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

        private void checkLoginButton()
        {
            const string checkLoginButton = @"(function(){ " +
                         "return document.getElementById('btnEnter').value; " +
                         "})();";
            chrome.EvaluateScriptAsync(checkLoginButton).ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    var response = t.Result;
                    if (response.Success && response.Result != null)
                    {
                        this.loginFail = true;
                       
                    }
                }
            });
        }
    }
}