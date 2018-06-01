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
        private bool clickedHistorical = false;

        private int kount = 0;
        Thread checkPlease;
        Thread searchMenu;
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
          
 
                var frameContent=window.frames['content'];
                clickHistorical()
                function clickHistorical(){

                var frameMenu=window.frames['menu'];
                var listID='std_academics'
                var academicList = frameMenu.document.getElementById(listID)
                console.log(academicList.children.length)
                    for(var i=0; i<academicList.children.length;i++){
	                    if(academicList.children[i].textContent=='Historical Grades'){
		                    academicList.children[i].querySelectorAll('a')[0].click() 
                            
                            setTimeout(gridSearch,2000)
                        }
                    }
                }
                console.log('string in the historical')     
                function gridSearch(){

                var frameContent=window.frames['content'];
                    var gradegrid = frameContent.document.querySelectorAll('table.grid>tbody>tr')
                    var gradeColumn = gradegrid[0]
                    var p1Location;
                    console.log('table grade grd ') 
                    console.log(gradegrid) 
                    var length=1;
                    var firstRowLength = gradeColumn.children.length
                    var l
                    console.log('index 0 gradegrid ') 
                    console.log(gradegrid[0])
                    for( l=0;l<firstRowLength;l++){
	                    if(gradeColumn.children[l].innerHTML=='P1'){
		                    p1Location=l
		                    break
	                    }
                    }
                    gradeColumn = gradegrid
                    var gridBoxLength=gradeColumn.length; 
                    gradeColumn = gradegrid[1]
                    var currentGradeLevel = gradeColumn.children[0].innerText.substring(0,5)

                    var gradeLevel
                    var grades = gradeColumn.children[p1Location].getElementsByTagName('a')

                    for(l =1;l<gridBoxLength;l++){
	                    gradeColumn = gradegrid[l]
                        gradeLevel = gradeColumn.children[0].innerHTML.substring(0, 5)
	                    if(gradeLevel!=currentGradeLevel){

		                    break; 
	                    }

                    }
                    length=l-1;
                    console.log('length of grade grid ') 
                    console.log(gradegrid[length])
                    for(var i=1;i<length;i++){
	                        gradeColumn = gradegrid[i]
                            grades = gradeColumn.children[p1Location].getElementsByTagName('a')

                            gridBoxLength=grades.length
	                        if(gridBoxLength>1){

                                compareGrades(grades, gridBoxLength)
	                        }
 
                        }
                        function compareGrades(gridBoxGrades, boxLength)
                        {
                            var gradeArray =[];
                            var counter = 0;
                            var k = 0;

                            for (k = 0; k < boxLength; k++)
                            {
                                gradeArray[k] =[gridBoxGrades[k].innerHTML, gridBoxGrades[k]]


                            }

                            gradeArray.sort()

                            console.log('after sort ')
                            console.log(gradeArray)
                            console.log('index[1][1] ')
                            console.log(gradeArray[1][1])
                            gradeArray[1][1].click()
                            setTimeout(deleteMe,1000)
                            
                        }
                } 
                function deleteMe(){
                    var deleteButtonID='btnbtnConfirmProxy'
                    var deleteButton= frameContent.document.getElementById(deleteButtonID)
                       
                    console.log(deleteButton)
                    deleteButton.click()
                    var confirmID='btnDelete'
                    var confirmation= frameContent.document.getElementById(confirmID)
                    confirmation.click()

                            clickHistorical()
                }
   
        })()";
        private const string searching = @"(funtion(){
              
            var frameContent=window.frames['content'];
            var gradegrid = frameContent.document.querySelectorAll('table.grid>tbody>tr')
            var gradeColumn = gradegrid[0]
            var p1Location;
            var firstRowLength = gradeColumn.children.length

            if(gradegrid.length>1){
                console.log('true in the historical')
            } 
        })()";
        public override void loginUser(string name, string logPass)
        {
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
                Console.WriteLine("#{0} index \nid number is: {1} ", kount, textID);
                kount++;
            }

            sIDText.Close();
            System.IO.File.WriteAllText(path, string.Empty);
            base.initChrome();
            base.loadJS(userNameLog, userPass);
            base.loadCheckJS(url);

            clickMultiSelect();
            historicalGrades();
             searchGrades();
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

                    searchMenu = new Thread(() => findLink(args));
                    searchMenu.Start();
                    while (searchMenu.IsAlive) ;
                    clickedHistorical = true;
                }
            };
        }
        private void searchGrades()
        {
            //chrome.FrameLoadEnd += (sender, args) =>
            //{
            //    if (args.Frame.IsMain && clickedHistorical)
            //    {
            //        args.Frame.EvaluateScriptAsync(searching);
            //    }
            //};
         }
        private void findLink(FrameLoadEndEventArgs args)
        {
            Console.WriteLine("in find link method");
            Console.WriteLine("kount is {0}", kount);
            args.Frame.EvaluateScriptAsync(findHistoricalLink);
                
            searchMenu.Abort();
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
