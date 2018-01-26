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
        private string userNameLog = "";
        private string userPass = "";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        public override void loginUser(string name, string logPass)
        {
            userNameLog = name;
            userPass = logPass;
            foreach (Control c in Controls)
            {
                c.Visible = false;
            }
            base.initChrome();
            base.loadJS(userNameLog, userPass);
            base.loadCheckJS();

            Console.WriteLine("id input {0} ",idCorrectFormat.Count);
            ShowDialog();
           Console.WriteLine("after showdialog");
        }

    }
}