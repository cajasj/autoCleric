  const string loopCustomScreens = @"(function(){" +
                   "var frameMenu=window.frames['menu'];" +
                   "var list = frameMenu.document.getElementById('tchr_information');" +
                   "var listItem = list.getElementsByTagName('a');" +
                   "var anchorText='Security Settings';" +
                   "for(var i =0; i<listItem.length; i++){ " +
                        "if(listItem[i].text==anchorText){  " +
                            "listItem[i].click();" +
                            "break;" +
                        "}" +
                    "}" +
                    "})();";
        const string traverseTabs = @"(function(){" +
                 "var frameMenu=window.frames['content'];" +
                 "var tabItems = frameMenu.document.querySelectorAll('ul.tabs');" +
                 "var tabList =tabItems[0].getElementsByTagName('a');" +
                 "var tabText='Admin Access and Roles';" +
                 "for(var i =0; i<tabList.length; i++){ " +
                      "if(tabList[i].innerText==tabText){ " +
                          "tabList[i].click();" +
                          "break;" +
                      "}" +
                  "}" +
                  "})();";
var runScript=true;
var frameString="menu";
var qSelectorString="ul.tab";
var frameMenu=window.frames["menu"];
var idName;
var tagName;
var tagContent
var list = document.getElementById("tchr_information");
var tabClass=document.getElementsbyClassName("selected");
  
	if(!tabclass){
		var tabItems = frameMenu.document.querySelectorAll("ul.tabs");
		var tabList =tabItems[0].getElementsByTagName("li");
		var list = document.getElementById("tchr_custom_pages");
		var listItem = list.getElementsByTagName("a");
		 for(var i =0; i<listItem.length; i++){ 
		if(listItem[i].text=="Conversion Data"){
			console.log('list item is ', listItem[i].text);	
			break;
		}else{
			console.log("not conversion data");
		}
	}

}
//<a href="home.html?ac=jumpstudent1&amp;rn=201025" target="_top" class="button next"><em>&nbsp;</em></a>
function(){" +"
                   "var frameMenu=window.frames['menu'];" +
                   "var list = frameMenu.document.getElementById('tchr_information');" +
                   "var listItem = list.getElementsByTagName('a');" +
                   "var anchorText='Security Settings';" +
                   "for(var i =0; i<listItem.length; i++){ " +
                        "if(listItem[i].text==anchorText){  " +
                            "listItem[i].click();" +
                            "break;" +
                        "}" +
                    "}" +
                    "})();";


//<button type="submit" id="btnSubmit" name="btnSubmit">Submit</button>                    
/////script also function it's to automatically change rtc to bridgeport under the special education menu
function automateRTC (){
  var frameMenu=window.frames["menu"];
  var frameContent=window.frames["content"];

  var navListClass="studentSearchList";
  var navID="nav-main-frame-secondary";
  var navRightButton="button next"

  var submit="btnSubmit";
  var rtcError="Resident_Town";
  var feedbackConfirm="feedback-confirm";
  var navFrameMenu=frameMenu.document.getElementsByClassName(navListClass); 
  var navNextButton = frameMenu.document.getElementsByClassName(navRightButton);

  var rtcTextBox = frameContent.document.getElementById(rtcError);
  var submitButton = frameContent.document.getElementById(submit);
  var feedback= frameContent.document.getElementsByClassName(feedbackConfirm);
  var numberString =navFrameMenu[0].text;
  var stringToNum = numberString.replace(/^\D+/g, '');

  stringToNum=parseInt(stringToNum);
  var i;


  for(var i=1; i<stringToNum;i++){
    rtcTextBox.value="015";
    submitButton.click()
    while(!feedback){

    }

    navNextButton[0].click();
  }
}
window.onload =  automateRTC();

/// first count the ammount of id numbers are they in main
/// then loop the script
/// you gotta create a radio button and something to parse the the ids.
/*
 

*/
//so far it works in one fell swoop just need to edit the array to take value from c#
var multiSelectClass="dialogDivM"
var frameContent=window.frames["content"];
var multiSelectLink=frameContent.document.getElementsByClassName(multiSelectClass);
console.log(multiSelectLink);
multiSelectLink[0].click();
var multiSelectID="multiSelVals"
var multiSelect=frameContent.document.getElementById(multiSelectID);
console.log(multiSelect);
var idArray=[]
multiSelect.value="";
multiSelect.value+=idArray[0];
for(var i=1;i<idArray.length;i++){
  multiSelect.value+=idArray[i];
}


var multiSelectClass="dialogDivM"
var frameContent=window.frames["content"];
///script for search
var searchButtonClass = frameContent.document.getElementsByClassName("button-row")[2];
var clickSearchButton =searchButtonClass.children[0];
clickSearchButton.click();
var searchButtonTag = searchButtonClass.document.getElementsByTagName("button");


//script to click on search result
var frameContent=window.frames["content"];
var studentSelectionTableID="studentSelectionTable";
var trClass="ng-scope";
var studentSelectionTable = frameContent.document.getElementsByTagName("tbody");
var studentClick = studentSelectionTable[1].children;
var clickStudent =studentClick[0].querySelectorAll("a");
console.log(clickStudent);
clickStudent[0].click()


var frameMenu=window.frames["menu"];
var stateReportingID="state_reporting";
var stateReporting=frameMenu.document.getElementById(stateReportingID);
//var reportingList=stateReporting.document.getElementsByTagName("a");
console.log(stateReporting.children.length);
var i=0;
var length=stateReporting.children.length;
for(i=0;i<length;i++){
  if(stateReporting.children[i].innerText=="Special Education"){
    console.log(stateReporting.children[i].innerHTML);
    stateReporting.children[i].querySelectorAll("a")[0].click();
    
  }
}
////ok add the new enum type or w.e for each time check box is true
///remove when false pass in to another constructor
///

