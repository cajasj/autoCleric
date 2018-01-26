using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using autoResign;
using CefSharp;
using CefSharp.WinForms;

namespace autoResign
{
    public class StudentRTC:powerSchool
    {

        ChromiumWebBrowser chrome;
        private string userName = "";
        private string userPass = "";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        public override void loginUser(string name, string logPass)
        {
            userName = name;
            userPass = logPass;

            initChrome();
            base.loadJS(userName, userPass,chrome);
            base.loadCheckJS(chrome);
            ShowDialog();
           
            
        }
        public void initChrome()
        {
            Console.WriteLine("inititalize chrome in class");
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            Console.WriteLine(chrome);
            Console.WriteLine(url);
            chrome = new ChromiumWebBrowser(url);
            
            Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;

        }
     

    }
}