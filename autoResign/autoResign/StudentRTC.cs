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

            base.initChrome();
            base.loadJS(userName, userPass);
            base.loadCheckJS();
            ShowDialog();
           Console.WriteLine("after showdialog");
            
        }

    }
}