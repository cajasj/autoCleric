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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoResign
{
    public partial class powerSchoolForm : Form
    {
        public ChromiumWebBrowser chrome;
        
        private string user;
        private string pass;

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
            var url = "https://bridgeportedu.powerschool.com/admin/pw.html";
            chrome = new ChromiumWebBrowser(url);
            this.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            
        }
        public void loadJS() {
            chrome.FrameLoadEnd += (sender, args) =>
             {
                 if (args.Frame.IsMain)
                 {
                     args.Frame.ExecuteJavaScriptAsync("alert('mainfram is done');");
                 }
             };
        }
        private void powerSchoolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
         
            
            Cef.Shutdown();
            Debug.WriteLine(this.user + " test " + this.pass);
        }
  
            
            //input id is fieldUsername name username type text
            //input id is fieldPassword type apssword name password
            //button typ submit id btnEnter value "Enter"
        

    }
  
}