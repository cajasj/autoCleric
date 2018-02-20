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
var multiSelect=document.getElementById(multiSelectID);
console.log(multiSelect);
var idArray=[]
multiSelect.value="";
multiSelect.value+=idArray[0];
for(var i=1;i<idArray.length;i++){
  multiSelect.value+=idArray[i];
}
document.getElementById("fldName").value="statenumber"

var multiSelectClass="dialogDivM"
var frameContent=window.frames["content"];
///script for search
var searchButtonClass = document.getElementsByClassName("button-row")[2];
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



go to each student in student transfer 
looking for same day or reverse 
x means 2 or more overlapping dates
scripts compare all the current dates to see if they overlap and hope to god they a date format in js
js date stufff
so plan is scrape 2 dates check if it's the same use js date built in function


foreach(tr in document getelement){

latestDate= new Date(getelementbyclass);
latestMonth =latestDate.getMonth()+1;
latestDay = latestDate.getDate();
latestShortDate = latestMonth+latestday

earlyDate = new Date(document.getelementbyClass)
earlyMotnh = earlyDate.getMotnh()+1
earlyDay=earlyDay.getDate();
earlyShortDate = earlymonth+earlyDay

checkReverse(earlydate)
if(early&&latestshortdate =aug31){
	function()
}else{
	function(lateshort early short)
}


////////////////////////////
checkReverse(earlydate){
exit = earlydate
entry = getelement
combined =entry -exit
if combined <0
	click entrydate change transfer info
}
function(lateshort early short)
	{

	if(latestshort == earlyshort){
		click entrydate
		click on transferinfo

	}else{
	latestshort=earlyshort

	}

}
changeBothdatesfunction(){

}
var boxRound="box-round";
 var frameMenu=window.frames["frameContent"];
var tableBody =frameMenu.getElementsByClassName(boxRound);
console.log(tableBody.getElementsByTagName("tr"));


var subStringPlacement=[0,10,14,25];
var frameContent=window.frames["content"];
var lateRow = frameContent.document.getElementsByTagName("tr");
var earlyRow = frameContent.document.querySelectorAll("tr.oddRow");
var rowIndex=0;
var numberOfRows= earlyRow.length-1;

var latestEntry =lateRow[2].innerText;
var latestExit = latestEntry;
latestEntry= latestEntry.substring(subStringPlacement[0],subStringPlacement[1]);

var earlierEntry = earlyRow[0].innerText;
var earlierExit = earlierEntry;
earlierEntry = earlierEntry.substring(subStringPlacement[0],subStringPlacement[1]);
latestEntry = latestEntry.substring(subStringPlacement[0],subStringPlacement[1]);

findBackSlash(latestExit);
latestExit=latestExit.substring(subStringPlacement[2],subStringPlacement[3]);
findBackSlash(earlierExit);
earlierExit=earlierExit.substring(subStringPlacement[2],subStringPlacement[3]);

checkEntryExit(latestEntry,earlierExit)

for(var x=1;x<numberOfRows;x++){
	latestEntry = earlierEntry;
	latestExit = earlierExit;
	earlierEntry = earlyRow[x].innerText;
	earlierExit = earlierEntry;
	earlierEntry = earlierEntry.substring(subStringPlacement[0],subStringPlacement[1]);
	findBackSlash(earlierExit);
	earlierExit=earlierExit.substring(subStringPlacement[2],subStringPlacement[3]);

console.log(latestEntry+" "+latestExit);
console.log(earlierEntry+" "+earlierExit);
		checkEntryExit(latestEntry,earlierExit)

}
function checkEntryExit(latestEntry,earlierExit){
	if(latestEntry == earlierExit){
		var clickEntry= frameContent.document.querySelectorAll("tr.oddRow>td>a")
		//clickEntry[rowIndex].click();
		rowIndex+=2;
		console.log("a match");
	}else{
		console.log("not a match");
	}
}
function findBackSlash(exitDate){
	for (var i =10; i<exitDate.length; i++){
		
		var backSlashChar=exitDate.charAt(i)
		if(backSlashChar=="/"){
			subStringPlacement[2]=i-2;
			subStringPlacement[3]=i+8;
			break;
		
	    }

	}
}


var multiSelectClass="dialogDivM"
var frameContent = window.frames["content"];
if(  frameContent.document.getElementsByClassName(multiSelectClass);){
 return true
}else {
 return false
} 