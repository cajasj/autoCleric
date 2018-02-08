using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\idList.txt"; 
        public List<string> studentID=new List<string>();
        public string readTextLine;
        public override void loginUser(string name, string logPass)
        {
            int k = 0;
            userNameLog = name;
            userPass = logPass;
//            foreach (Control c in Controls)
//            {
//                c.Visible = false;
//            }
            StreamReader sIDText = new StreamReader(path);
             
              
                    
                while (readTextLine != null)
                {
                    readTextLine = sIDText.ReadLine();
                Console.WriteLine("id {0} ", readTextLine);
                    studentID.Add(readTextLine);
                }

            
            foreach (string textID in studentID)
            {
                Console.WriteLine("#{0} index \nid number is: {1} ", k, textID);
                k++;
            }
            System.IO.File.WriteAllText(path, string.Empty);
          
            base.initChrome();
            base.loadJS(userNameLog, userPass);
            base.loadCheckJS();
        
            ShowDialog();
           Console.WriteLine("after showdialog");
        }

    }
}