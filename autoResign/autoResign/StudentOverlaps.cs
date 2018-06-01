using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

namespace autoResign
{
    class StudentOverlaps:powerSchool   
    {
        int test = 0;
        private string userNameLog = "";
        private string userPass = "";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        public string pathState = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\idList.txt";
        private bool runOnce = false;
        private bool checkTablePage = false;
        public List<string> studentID = new List<string>();
        public string readTextLine=" ";
        Thread checkPlease;
        private string checkTableLength = @"(function(){
                if(document.getElementsByTagName('tbody')[1].children.length==0){
                    return false
                }else{
                    return true
                }
            })();";

        private const string multiInputClick = @"(function(){
            document.getElementsByClassName('dialogDivM')[0].click();
            document.getElementById('fldName').options[0].value='statenumber';

           })() ";
        private const string clickResult = @"(function(){
                setTimeout(clickMe, 1000)
                function clickMe(){
                console.log('in the click after a second');

                var studentSelectionTable = document.getElementsByTagName('tbody');
                 var studentClick = studentSelectionTable[1].children;
                var clickStudent =studentClick[0].querySelectorAll('a');
                clickStudent[0].click();
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

            
            sIDText.Close();
            System.IO.File.WriteAllText(pathState, string.Empty);

            base.initChrome();
            base.loadJS(userNameLog, userPass);
            base.loadCheckJS(url);
            
            clickMultiSelect();
        }

        protected virtual void clickMultiSelect()
        {
           
            chrome.FrameLoadEnd += (sender, args) =>
            {
                if (args.Frame.IsMain)
                {
                   
                   
                    if (runOnce == false)
                    {

                        checkPlease = new Thread(() => checkTable());
                        checkPlease.Start();
                        while (checkPlease.IsAlive)
                        checkTablePage = runOnce;
                        autoMulti(args);
                        inputMulti(args);
                        clickSearch(args);
                        
                    }
                    else
                    {

                            args.Frame.EvaluateScriptAsync(clickResult);
                       
                            Console.WriteLine("run once is false");                  
                    }

                     
                }
            };
        }

        private void autoMulti(FrameLoadEndEventArgs args )
        { 
            var multiSelect = string.Format("document.getElementsByClassName('dialogDivM')[0].click();");
            
                args.Frame.ExecuteJavaScriptAsync(multiInputClick);
        }
        private void inputMulti(FrameLoadEndEventArgs args )
        {
            Console.WriteLine("input multi for each ");
            foreach (var id in studentID)
            {

                Console.WriteLine(id);
               
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
                    checkTablePage=runOnce;
                    Console.WriteLine("run once is now {0}", runOnce);
                    checkPlease.Abort();
                }
            });
        }

        
    }
}
