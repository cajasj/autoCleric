using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

namespace autoResign
{
    class StudentOverlaps:powerSchool   
    {

        private string userNameLog = "";
        private string userPass = "";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        public string pathState = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\idList.txt";
        private bool runOnce = false;
        public List<string> studentID = new List<string>();
        public string readTextLine=" ";

        private string checkTableLength = @"(function(){
                if(document.getElementsByTagName('tbody')[1].children.length==0){
                    return false
                }else{
                    return true
                }
            })();";
        public override void loginUser(string name, string logPass)
        {
            int k = 0;
            userNameLog = name;
            userPass = logPass;
            //            foreach (Control c in Controls)
            //            {
            //                c.Visible = false;
            //            }
            StreamReader sIDText = new StreamReader(pathState);



            while (readTextLine != null)
            {
                readTextLine = sIDText.ReadLine();
                Console.WriteLine("id {0} ", readTextLine);
                studentID.Add(readTextLine);
            }


            Console.WriteLine("before multiSelect {0}", studentID);
            foreach (string textID in studentID)
            {
                Console.WriteLine("#{0} index \nid number is: {1} ", k, textID);
                k++;
            }

            sIDText.Close();
            System.IO.File.WriteAllText(pathState, string.Empty);

            base.initChrome();
            base.loadJS(userNameLog, userPass);
            base.loadCheckJS(url);
            Console.WriteLine("before multiSelect {0}", studentID.Count);
            
            clickMultiSelect();
            Console.WriteLine("after showdialog");
        }

        protected virtual void clickMultiSelect()
        {
           
            chrome.FrameLoadEnd += (sender, args) =>
            {
                if (args.Frame.IsMain)
                {
                    checkTable();

                    Console.WriteLine("run once in clickMethod is now {0}", runOnce);
                 
                    if (runOnce == false)
                    {
                        autoMulti(args);
                        inputMulti(args);
                        clickSearch(args);
                    }

                     
                }
            };
        }

        private void autoMulti(FrameLoadEndEventArgs args )
        { 
            var multiSelect = string.Format("document.getElementsByClassName('dialogDivM')[0].click();");
            
                args.Frame.ExecuteJavaScriptAsync(multiSelect);
            string stateID = "statenumber";
            var stateIdSelect = string.Format("document.getElementById('fldName').options[0].value={0};", stateID);

            args.Frame.ExecuteJavaScriptAsync(stateIdSelect);
        }
        private void inputMulti(FrameLoadEndEventArgs args )
        {
            
            foreach (var id in studentID)
            {
                Console.WriteLine("input multi for each ");
               
               
                var inputID = string.Format("document.getElementById('multiSelVals').value+={0}+'\\n';", id);
             
                args.Frame.ExecuteJavaScriptAsync(inputID);

            }
   
            
        }

        private void clickSearch(FrameLoadEndEventArgs args)
        {
            var clickSearch =
                string.Format("document.getElementsByClassName('button-row')[2].children[0].click()");
            args.Frame.ExecuteJavaScriptAsync(clickSearch);
        }
        private void checkTable()
        {
            chrome.EvaluateScriptAsync(checkTableLength).ContinueWith(x =>
            {
                var response = x.Result;
                if (response.Success && response.Result != null)
                {
                    runOnce = (bool)response.Result;
                    Console.WriteLine("run once is now {0}", runOnce);
                    
                }
            });
        }
    }
}
