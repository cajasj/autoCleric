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

        private string user="";
        private string pass="";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        private int count = 0;
        private bool failHolder = false;
        private bool loginFail = false;
        private bool headerFail = false;
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
                const string checkButton = @"(function(){ " +
                        "if( document.getElementById('btnEnter')){" +
                        "  return true" +
                        "}else {" +
                        "  return false" +
                        "} " +
                        "})();";
                    const string checkHeader = @"(function(){ " +
                                 "if( document.getElementById('branding-powerschool')){" +
                                 "  return true" +
                                 "}else {" +
                                 "  return false" +
                                 "} " +
                                 "})();";
                 if (args.Frame.IsMain && this.loginFail==false)
                 {
                    
                    retryThread = new Thread(() => jsLogin(args));
                     retryThread.Start();
                     
                     count++;
                     Console.WriteLine("count is " + count);
                     while (retryThread.IsAlive);
                    if (this.headerFail == true)
                    {
                        checkLoginButton(checkHeader);
                        this.headerFail = this.failHolder;
                    }
                    else
                    {
                        checkLoginButton(checkButton);
                        this.loginFail = this.failHolder;
                    }
                    //branding-powerschool id 
                    //input id is fieldUsername name username type text
                    //input id is fieldPassword type apssword name password
                    //button typ submit id btnEnter value "Enter"
                }
                 else
                 {
                     MessageBox.Show("wrong credential please enter again");
                     retryInput = new credentialInput();
                     credInput = new Thread(()=>retryInput.ShowDialog());
                     credInput.Start();
                     while (credInput.IsAlive) ;
                     this.user = retryInput.getName;
                     this.pass = retryInput.getPass;
                     Console.WriteLine(this.user + " using properties " + this.pass);
                     credInput.Abort();
                     this.loginFail = false;
                    this.headerFail = true;
                     chrome.Load(url);
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

        private void checkLoginButton(string checkArg)
        {
            

            chrome.EvaluateScriptAsync(checkArg).ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    var response = t.Result;
                    if (response.Success && response.Result != null)
                    {
                        this.failHolder = true;
                    Console.WriteLine("login fail is trye " + response.Result);
                    }
                    else
                    {
                        this.failHolder = false;
                    }
                }
            });
        }
    }
}