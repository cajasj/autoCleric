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
//overlap is functional look at that
namespace autoResign
{
    class cleanHistorical : powerSchool
    {
        private string userNameLog = "";
        private string userPass = "";
        private string url = "https://bridgeportedu.powerschool.com/admin/home.html";
        public string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\idList.txt";
        public List<string> studentID = new List<string>();
        public string readTextLine = " ";
        private bool runOnce = false;
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
        private const string findHistoricalLink = @"(function(){
          

            console.log('after console in historical method normal')

                var frameMenu=window.frames['menu'];
                var listID='std_academics'
                var academicList = frameMenu.document.getElementById(listID)
                console.log(academicList.children.length)
                for(var i=0; i<academicList.children.length;i++){
	                if(academicList.children[i].textContent=='Historical Grades'){
		                academicList.children[i].querySelectorAll('a')[0].click()
                    }
                }
        })()";

        private const string searchGrade = @"(function(){
            
        var frameContent=window.frames['content'];
        var gradegrid = frameContent.document.querySelectorAll('table.grid>tbody>tr')
        var gradeColumn = gradegrid[0]
        var p1Location;
        var firstRowLength = gradeColumn.children.length

        }";
        public override void loginUser(string name, string logPass)
        {
            int k = 0;
            userNameLog = name;
            userPass = logPass;
           
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

            sIDText.Close();
            System.IO.File.WriteAllText(path, string.Empty);
            base.initChrome();
            base.loadJS(userNameLog, userPass);
            base.loadCheckJS(url);

            clickMultiSelect();
            historicalGrades();
            ShowDialog();
            Console.WriteLine("after showdialog");
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
        private void historicalGrades()
        {
            chrome.FrameLoadEnd += (sender, args) =>
            {
                if (args.Frame.IsMain)
                {
                    Console.WriteLine("in the historical method");
                    findLink(args);
                }
            };
        }
        private void findLink(FrameLoadEndEventArgs args)
        {
            Console.WriteLine("in find link method");
            args.Frame.EvaluateScriptAsync(findHistoricalLink);
            //var clickHistorical = string.Format("window.frames['menu'].document.getElementById('std_academics').children[6].querySelectorAll('a')[0].click()");
            //args.Frame.EvaluateScriptAsync(clickHistorical);
        }
        private void autoMulti(FrameLoadEndEventArgs args)
        {
            var multiSelect = string.Format("document.getElementsByClassName('dialogDivM')[0].click();");

            args.Frame.ExecuteJavaScriptAsync(multiInputClick);
        }
        private void inputMulti(FrameLoadEndEventArgs args)
        {
            Console.WriteLine("input multi for each ");
            foreach (var id in studentID)
            {



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
                    checkPlease.Abort();
                }
            });
        }
    }
}
