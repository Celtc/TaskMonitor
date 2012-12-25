 
 
google_adnum = 0;
 

var isSmallScreen = false;
var adBottomBlock = '';
var winprint;
var visitorIsHuman = false;

function SetAdChannels() {

}

function BodyOnLoad()
{
    setTimeout('SetVisitorIsHuman()', 2000);
}

function SetVisitorIsHuman()
{
    visitorIsHuman = true;
}

function GoNewsGroupAsk()
{
    if (!visitorIsHuman) return;
    window.location = 'http://www.eggheadcafe.com/forumpostsubmitnew.aspx';
}

function LogPageView()
{
    //    setTimeout('SetVisitorIsHuman()', 1000);
}

function LoadEggHeadCafeTopBanner() {
    //<a href=\"http://www.eggheadcafe.com/chatchaos.aspx\"><img src=\"/images/template2/emptyad.gif\" border=\"0\"/></a>

}

function SetAdChannel(divName) {

    var div = document.getElementById(divName);
    if (div == null) { return false; }

    google_ad_channel = Trim(div.innerHTML);
    div.innerHTML = '';
    div.style.visibility = 'visible';

    return true;
}


 
function ProcessAdSensesAds(ads)
{
    var div;
    var count = ads.length;
    var nextAdIndex = 0;
    var adsToRender = 2;

    try {

       
        if (count == 0) { return; }
        if (ads[0].type == "image" || ads[0].type == "flash" || ads[0].type == "html") { return; }
 
        if (screen.width <= 1024) isSmallScreen = true;
 
        google_adnum += count + 2;

        if (count > adsToRender) {
            adsToRender = count;
        }

        var w = '860px';
 
         
        div = document.getElementById('DivAdNewsGroupSplitTop');
        if ((div != null) && (Trim(div.innerHTML) == '')) { SetRemoteAdsGroup(ads, nextAdIndex, count, adsToRender); return; }

        div = document.getElementById('DivAdForumSplitTop');
        if ((div != null) && (Trim(div.innerHTML) == '')) { SetRemoteAdsForumPost(ads, nextAdIndex, count, adsToRender); return; }

        div = document.getElementById('DivAdArticleClassic');
        if ((div != null) && (Trim(div.innerHTML) == '')) { div.style.width = '880px'; div.innerHTML = GetRemoteAdClassic(ads, nextAdIndex, count, adsToRender); return; }

        div = document.getElementById('DivAdSearch');
        if ((div != null) && (Trim(div.innerHTML) == '')) { div.innerHTML = GetRemoteAdSearch(ads, nextAdIndex, count, adsToRender); return; }

        div = document.getElementById('DivAdFreeIcons');
        if ((div != null) && (Trim(div.innerHTML) == '')) { div.style.width = '900px';  div.innerHTML = GetRemoteAdSearch(ads, nextAdIndex, count, adsToRender); return; }

        div = document.getElementById('DivAdArticle');
        if ((div != null) && (Trim(div.innerHTML) == '')) { div.style.width = '880px'; div.innerHTML = GetRemoteAdStandard(ads, nextAdIndex, count, adsToRender); return; }
 
        div = document.getElementById('DivAdFAQ');
        if ((div != null) && (Trim(div.innerHTML) == '')) { div.style.width = '870px'; div.innerHTML = GetRemoteAdStandard(ads, nextAdIndex, count, adsToRender); return; }
 
        div = document.getElementById('DivAdVendorPage');
        if ((div != null) && (Trim(div.innerHTML) == '')) { div.style.width = w; div.innerHTML = GetRemoteAdStandard(ads, nextAdIndex, count, adsToRender); return; }

        div = document.getElementById('DivAdVendorPageBottom');
        if ((div != null) && (Trim(div.innerHTML) == '')) { div.innerHTML = GetRemoteAdStandard(ads, nextAdIndex, count, adsToRender); return; }
 
    }
    catch (e) { }
    return;
}

function SetRemoteAdsForumPost(ads, nextAdIndex, count, adsToRender)
{

    var x = 0;
    var ad;

    try
    {
        var c = 0;
        var logo = GetRemoteAdLogo();
        s = new Array();

        s.push('<div class="row" style="width:800px; padding: 5px 5px 5px 5px;">');
        s.push('<table class="AdTableBackground" align="left" cellpadding="1" border="0" cellspacing="0" width="100%">');
        s.push('<tr><td align="left" valign="top" height="20">&nbsp;' + logo + '</td></tr>');

        for (y = 0; y < count; y++) {
            c++;
            ad = ads[y];
            s.push('<tr>');
         //   s.push('<td valign="middle" height="25" style="font-size: 15px;text-align:right" nowrap class="AdText2">' + c + '.&nbsp;&nbsp;</td>');
            s.push('<td valign="middle" height="25" nowrap class="AdText2" style="font-size: 15px" >&nbsp;<a class="AdTopUrlAlt" href="' + ad.url + '"' + GetStatusEvents(ad.visible_url) + '>' + ad.line1 + '</a>&nbsp;&nbsp;-');
            s.push(ad.line2 + ' ' + ad.line3 + '&nbsp;-&nbsp;');
            s.push('<a style="font-size: 10px" class="AdBottomUrlBright" href="' + ad.url + '"' + GetStatusEvents(ad.visible_url) + '>' + CleanUrlPath(ad.visible_url) + '</a></td>');
            s.push('</tr>');
        }

        s.push('</table>');
        s.push('</div>');
        adBottomBlock = s.join(' ');
 
    }
    catch (e) { }

    return;
}

function SetRemoteAdsGroup(ads, nextAdIndex, count, adsToRender)
{
    var s = new Array();
    var x = 0;
    var ad;

    try
    {

        var divTop = document.getElementById('DivAdNewsGroupSplitTop');
        var c = 0;
        var logo = GetRemoteAdLogo();

        s = new Array();
 
        s.push('<table border="0" cellpadding="0" cellspacing="0" width="800">');
        s.push('<tr>');
        s.push('<td align="left">');
        s.push('<div style="border:solid 0px #3681cc; padding: 30px 0px 0px 0px; overflow:hidden">');
        s.push('<table class="AdTableBackground" align="left" cellpadding="1" border="0" cellspacing="0" width="100%">');
        s.push('<tr><td></td><td align="left" valign="top" height="20">&nbsp;' + logo + '</td></tr>');

        for (y = 0; y < count; y++)
        {
            c++;
            ad = ads[y];
            s.push('<tr>');
             s.push('<td valign="middle" height="25" style="font-size: 15px;text-align:right" nowrap class="AdText2">' + c + '.&nbsp;&nbsp;</td>');
            s.push('<td valign="middle" height="25" nowrap class="AdText2" style="font-size: 15px" >&nbsp;<a class="AdTopUrlAlt" href="' + ad.url + '"' + GetStatusEvents(ad.visible_url) + '>' + ad.line1 + '</a>&nbsp;&nbsp;-');
            s.push(ad.line2 + ' ' + ad.line3 + '&nbsp;-&nbsp;');
            s.push('<a style="font-size: 12px" class="AdBottomUrlBright" href="' + ad.url + '"' + GetStatusEvents(ad.visible_url) + '>' + CleanUrlPath(ad.visible_url) + '</a></td>');
            s.push('</tr>');
        }

        s.push('</table>');
        s.push('</div><br/>');
        s.push('</td></tr></table>');
 

        adBottomBlock = s.join(' ');

    }
    catch (e) { alert(e); }

    return;
}

function SetRemoteAdsForumBlock()
{
    var divMiddle = document.getElementById('DivAdForumSplitBottom');
    if (divMiddle != null) { divMiddle.innerHTML = adBottomBlock; }
}

function SetRemoteAdsGroupBottomBlock()
{
    var divMiddle = document.getElementById('DivAdNewsGroupSplitBottom');
    if (divMiddle != null) { divMiddle.innerHTML = adBottomBlock; }
}

function CleanUrlPath(url) {
    var e = url.indexOf("/");
    if (e <= 0) {
        return url.replace('www.', '');
    }
    url = url.substring(0, e);
    url = url.replace('www.', '');
    url.replace('-', ' - ');
    return url;
}

function GetRemoteAdDivTagWithBorder() {
    return '<div style="border-top:solid 1px #CFDADD; padding: 10px 5px 10px 5px; height:100%">';
}

function GetRemoteAdDivTag() {
    return '<div style="border:solid 0px #CFDADD; padding: 1px 1px 1px 1px;">';
}

function GetRemoteAdLogo() {
    return '<a href=\"' + google_info.feedback_url + '\" class="AdLogoUrl">' + 'Ads by Google' + '</a>';
}

function GetStatusEvents(url) {
    return ' onmouseout="window.status=\'\'" onmouseover="window.status=\'go to ' + url + '\';return true"';
}
 
function GetRemoteAdClassic(ads, start, end, max)
{
    var s = new Array();
    var x = 0;

    s.push('<div style="padding: 5px 5px 5px 5px;">');
    s.push('<table class="AdTableBackground" cellpadding="1" border="0" cellspacing="0" width="100%">');

    s.push('<tr><td align="left" valign="top" colspan="1" height="30">' + GetRemoteAdLogo() + '</td></tr>');

    for (y = start; y < end; y++)
    {
        if (x < max)
        {
 
            var ad = ads[y];
            s.push('<tr>');
            s.push('<td valign="middle" height="22" style="font-size: 15px" nowrap class="AdText2">&nbsp;<a  class="AdTopUrlAlt" href="' + ad.url + '"' + GetStatusEvents(ad.visible_url) + '>' + ad.line1 + '</a>&nbsp;&nbsp;-');
            s.push(ad.line2 + ' ' + ad.line3 + '&nbsp;-&nbsp;');
            s.push('<a style="font-size: 12px" class="AdBottomUrlBright" href="' + ad.url + '"' + GetStatusEvents(ad.visible_url) + '>' + CleanUrlPath(ad.visible_url) + '</a></td>');
            s.push('</tr>');
 
            x++;
        }
    }

    s.push('</table><br/>');
    s.push('</div>');
    return s.join(' ');
}

function GetRemoteAdStandard(ads, start, end, max)
{
    var s = new Array();
    var x = 0;
	var c = 0;

    s.push('<div style="padding: 5px 5px 5px 5px;">');
    s.push('<table class="AdTableBackground" cellpadding="1" border="0" cellspacing="0" width="100%">');

    s.push('<tr><td></td><td align="left" valign="top" height="20">' + GetRemoteAdLogo() + '</td></tr>');

    for (y = start; y < end; y++) 
    {
        if (x < max)
        {
			c++;
            var ad = ads[y];
            s.push('<tr>');
            s.push('<td valign="middle" height="25" style="font-size: 15px; text-align:right" nowrap class="AdText2">' + c + '.&nbsp;&nbsp;</td>');
            s.push('<td valign="middle" height="25" style="font-size: 15px" nowrap class="AdText2"><a  class="AdTopUrlAlt" href="' + ad.url + '"' + GetStatusEvents(ad.visible_url) + '>' + ad.line1 + '</a>&nbsp;-&nbsp;');
            s.push(ad.line2 + ' ' + ad.line3 + '&nbsp;-&nbsp;');
            s.push('<a style="font-size: 12px" class="AdBottomUrlBright" href="' + ad.url + '"' + GetStatusEvents(ad.visible_url) + '>' + CleanUrlPath(ad.visible_url) + '</a></td>');
            s.push('</tr>');
            x++;
        }
    }

    s.push('</table><br/>');
    s.push('</div>');
    return s.join(' ');
}

function GetRemoteAdSearch(ads, start, end, max) 
{
    var s = new Array();
    var x = 0;
    var ad;
	var c = 0;
    var css = 'AdTopUrl';

    if (start >= end) {
        return '';
    }
    s.push('<div style="border: 0px solid #CFDADD;padding: 5px 5px 10px 5px;width:800px">');
    s.push('<table class="AdTableBackground" width="799" cellpadding="1" border="0" cellspacing="1"  align="center">');
    s.push('<tr><td align="left" height="20" colspan="4">' + GetRemoteAdLogo() + '</td></tr>');

    for (y = start; y < end; y++) {

        if (x < max) {
            ad = ads[y];
            c++;
            s.push('<tr>');
		    s.push('<td valign="middle" height="25" style="font-size: 15px;text-align:right" nowrap class="AdText">' + c + '.&nbsp;&nbsp;</td>');
            s.push('<td height="25" valign="middle" nowrap align="left"><a style="font-size: 15px;" class="' + css + '" href="' + ad.url + '"' + GetStatusEvents(ad.visible_url) + '>' + ad.line1 + '</a>&nbsp;&nbsp;</td>');
            s.push('<td height="25" valign="middle" nowrap align="left" style="font-size: 13px;color:black" class="AdText">' + ad.line2 + ' ' + ad.line3 + '&nbsp;&nbsp;</td>');
            s.push('<td height="25" valign="middle" nowrap align="left"><a style="font-size: 13px;" class="AdBottomUrl" href="' + ad.url + '"' + GetStatusEvents(ad.visible_url) + '>' + CleanUrlPath(ad.visible_url) + '</a></td>');
            s.push('</tr>');

            x++;
        }
    }

    s.push('</table>');
    s.push('</div>');
    return s.join(' ');
}
 
// JScript File

var baseURL = 'http://www.eggheadcafe.com';

 


function GetEggHeadCafeAdType(source)
{

    if (source.indexOf('eggheadcafe.com') > 1) return 'EGG';
    if (source.indexOf('localhost') > 1) return '';

    if (source.indexOf('lakequincy.com') > 0)
    {
        return 'LQ';
    }
    if (source.indexOf('loungenet') > 0)
    {
        return 'L';
    }
    if (source.indexOf('adzerk') > 0) {
        return 'L';
    }
    if (source.indexOf('neudesic') > 0)
    {
        return 'N';
    }

    return '';

}
 
 
function LogPageViewDelay()
{
    var url = 'http://ads.eggheadcafe.com/logger.ashx?';
    
    var found = false;
    var type = '';
    var adHeader =  'None';
    var adMiddle = 'None';
    var adFooter = 'None';
    var test = '';
    try
    {
        
   
        url = url + 'header=' + adHeader + '&middle=' + adMiddle + '&footer=' + adFooter;
 
        var ga = document.createElement('script');
        ga.type = 'text/javascript';
        ga.async = true;
        ga.src = url;
        (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(ga);
 
    }
    catch (e) {    }

}

function Trim(stringToTrim)
{
	return stringToTrim.replace(/^\s+|\s+$/g,"");
}

function IsReferrer(domain)
{
  if (document.referrer && document.referrer!="")
  {
    if (document.referrer.indexOf(domain) >0) { return true; } 
  }
  return false;
}

function GetGoogleTerms()
{
 
  if (document.referrer.search(/google\.*/i) != -1) 
  {
    var start = document.referrer.search(/q=/);
    var searchTerms = document.referrer.substring(start + 2); 
    var end = searchTerms.search(/&/); 
        end = (end == -1) ? searchTerms.length:end;
        searchTerms = searchTerms.substring(0, end); 
  
        if (searchTerms.length != 0) 
        {
          searchTerms = searchTerms.replace(/\+/g, " "); 
          searchTerms = unescape(searchTerms);
          return searchTerms;
        }
  }
 
}

function SetSearchBoxFromTag(textBox,value)
{
    var search = '';
    try 
    {
      document.getElementById(textBox).value = ' ' + value;
      doSearchMaster();
    }
    catch (e) {   }
}

function SetSearchBox(textBox)
{
    var search = '';
    try 
    {
      if (IsReferrer('google'))
      {
         search = GetGoogleTerms();
      }
      
      if (search == 'undefined') { return; }
      document.getElementById(textBox).value = ' ' + search;
    }
    catch (e) {   }
}

function ReRouteToSearchKeyUp(e)
{
  //if (!e) e = window.event; 
  if (e.keyCode == 13) 
  {	
     ReRouteToSearch();
     return false;
  }
  return true;
}

function ReRouteToSearch(elem) {
    srch = document.getElementById('ctl00_MasterTopMenu1_searchRelatedText').value;
    ToggleSearchNewWindow('Search', true, 'site:www.eggheadcafe.com ' + srch, srch);     
}

function URLDecode (encodedString)
{
  var output = encodedString;
  var binVal, thisString;
  var myregexp = /(%[^%]{2})/;
  
  try
  {
     while ((match = myregexp.exec(output)) != null
             && match.length > 1
             && match[1] != '')
    {
      binVal = parseInt(match[1].substr(1),16);
      thisString = String.fromCharCode(binVal);
      output = output.replace(match[1], thisString);
    }
  }
  catch (e) { }
  return output;
}


function OpenManageArticleParagraph(articleParagraphID,articleID,languageID,sortOrder)
{
       var q = '';
 
        q ="id=" + articleParagraphID;
        q+= "&languageid=" + languageID;
        q+= "&sortorder=" + sortOrder;
        q+= "&articleid=" + articleID;
 
        
	var sOption="toolbar=no,location=no,status=yes,directories=no,menubar=no,";
          sOption+="scrollbars=1,width=680,height=425,left=150,top=25";
                      					                 
     var win=window.open("ManageArticleParagraph.aspx?" + q,"Paragraphs",sOption);
 
     win.focus();
  
}

function OpenConversationReply(messageID)
{
    
	var sOption="toolbar=no,location=no,status=yes,directories=no,menubar=no,scrollbars=yes,";
          sOption+="width=625,height=450,left=375,top=125";
                      					          
     var win=window.open("/ConversationPoster.aspx?messageid=" + messageID,"Post",sOption);
 
     win.focus();
  
}

function OpenUpload()
{
    
	var sOption="toolbar=no,location=no,status=yes,directories=no,menubar=no,scrollbars=yes,";
          sOption+="width=770,height=295,left=450,top=475";
                      					          
     var win=window.open("/Upload.aspx","Upload",sOption);
 
     win.focus();
  
}

function OpenFormatSourceCode(type)
{
    
	var sOption="toolbar=no,location=no,status=yes,directories=no,menubar=no,scrollbars=yes,";
          sOption+="width=725,height=550,left=350,top=300";

     var win=window.open("/FormatSourceCode.aspx?type=" + type,"Formatter",sOption);
 
     win.focus();
  
}


       function PrintThisPage()
	   {
	          var sOption="toolbar=yes,location=no,directories=yes,menubar=yes,";
              sOption+="scrollbars=yes,width=850,height=650,left=100,top=25";
                      					                 
              var winprint=window.open("/print.aspx","Print",sOption);
                            
              winprint.focus();
 
	   }
	  
	  function searchRelated(e)
		{ 
		    
	     if (!e) var e = window.event; 
    	if (e.keyCode == 13) 
		 {	
 
		  doSearch();
		  
		  return false; 
		 }		
       }	   
       
	function doSearch()
    {
 
        srch = document.getElementById('ctl00_searchRelatedText').value;
        ToggleSearchNewWindow('Search', true, 'site:www.eggheadcafe.com ' + srch, srch);  
		} 
		
		function searchVendorProductEvent(e)
		{ 
		    
	     if (!e) var e = window.event; 
    	if (e.keyCode == 13) 
		 {	
 
		  doSearchVendorProduct();
		  
		  return false; 
		 }		
       }	   
		
		function searchRelatedMaster(e)
		{ 
		    
	     if (!e) var e = window.event; 
    	if (e.keyCode == 13) 
		 {	
 
		  doSearchMaster();
		  
		  return false; 
		 }		
       }	   
       
    function doSearchVendorProduct()
    {
	    srch=document.getElementById('searchRelatedText').value;	  	    
		ToggleSearch('Search',true,'site:www.eggheadcafe.com/vendorproduct.aspx ' + srch,srch);  
    } 
       
	function doSearchMaster()
    {
	    srch=document.getElementById('ctl00_searchRelatedText').value;
	    ToggleSearchNewWindow('Search', true, 'site:www.eggheadcafe.com ' + srch, srch);  
    } 
   
   	  function searchRelatedClassicMaster(e)
		{ 
		    
	     if (!e) var e = window.event; 
    	if (e.keyCode == 13) 
		 {	
 
		  doSearchClassicMaster();
		  
		  return false; 
		 }		
       }	   
       
	function doSearchClassicMaster()
    {
	    srch=document.getElementById('searchRelatedText').value;
	    ToggleSearchNewWindow('Search', true, 'site:www.eggheadcafe.com tutorials ' + srch, srch);  
    }  

 function WriteUpAdsenseTracker()
{ 
 
}

function ShowRemoteAds()
{
   try
   {  
   
       if (document.getElementById('iframeSearch').src.substring(0,4)=='http')
       {
           window.location.href = 'http://www.eggheadcafe.com/default.aspx';
       }
    }
    catch (exception) { }        
}

function ToggleSearchNewWindow(uniqueID, show, url, text)
{
    try
        {
            var sOption = 'status=1,toolbar=yes,location=yes,directories=yes,menubar=yes,resizable=yes,';
            sOption += 'scrollbars=yes,width=1100,height=760,left=100,top=25'; 
        var win = window.open('/answers.aspx?search=' + encodeURIComponent(text), "Search", sOption);

        win.focus();

    }
    catch (exception) { alert(exception.message); }   
}

function ToggleSearch(uniqueID,show,url,text)
{
 
   try {


       window.location.href = '/answers.aspx?search=' + encodeURIComponent(text);
    }
    catch (exception)  { alert(exception.message);  }   
}
 

function queryString(item, source)
{
 var itemLoc=source.indexOf(item);
 var newSrc=source.substring(itemLoc);
 var endLoc=newSrc.indexOf("&");
 var lstSrc=newSrc.substring(0,endLoc);
 var itm=lstSrc.substring(item.length+1);
 return itm;
}






var deletePostWindowHandle;

function CloseDeletePostWindow()
{
    try
    {

        deletePostWindowHandle.close();
    }
    catch (e) { }
}

function DeletePost(url)
{
    var sOption = 'toolbar=no,location=yes,resizable=1,directories=yes,menubar=no,';
    sOption += 'scrollbars=yes,width=100,height=100,left=100,top=25';

    CloseDeletePostWindow();

    deletePostWindowHandle = window.open(url, "Delete", sOption);
}

function GoSite(url)
{
    if (!visitorIsHuman) return;
    window.location.href = url;
}

function GoSite2(evt,url)
{
    var option = 'toolbar=yes,location=yes,resizable=1,directories=yes,menubar=yes,scrollbars=yes,width=1200,height=900,left=10,top=25';
    var ctrlPressed = 0;

    try
    {

        if (parseInt(navigator.appVersion) > 3)
        {
            if (document.layers && navigator.appName == "Netscape"  && parseInt(navigator.appVersion) >= 4)
            {
                var modifierString = (e.modifiers + 32).toString(2).substring(3, 6);
                ctrlPressed = (modifierString.charAt(1) == "1");
            }
            else
            {
                ctrlPressed = evt.ctrlKey;
            }
            if (ctrlPressed)
            {
                window.open(url, "EggHeadCafe", option);
                return;
            }
        }
 
    }
    catch (exception) { }

    window.location.href = url;
}

function GetRandomNumber(n)
{
    return (Math.floor(Math.random() * n + 1));
}

function DeleteNewsGroupPost(messageID,deleteAllFromUser)
{

    var url = '/Handlers/NewsGroupPostDelete.ashx?id=' + messageID + '&deleteall=' + deleteAllFromUser;
    var xmlhttp = new XMLHttpRequest();

    try
    {
        xmlhttp.open("GET", url, true);
        xmlhttp.send(null);
    }
    catch (exception) { alert(exception.message); }

}

function DeleteForumPost(forumPostID)
{

    var url = '/Handlers/ForumPostDelete.ashx?id=' + forumPostID;
    var xmlhttp = new XMLHttpRequest();

    try
    {
        xmlhttp.open("GET", url, false);
        xmlhttp.send(null);
        window.location.href = xmlhttp.responseText;
    }
    catch (exception) { alert(exception.message); }

}

function ExcludeForumPost(forumPostID,redirect)
{
 
    var url = '/Handlers/ForumPostHide.ashx?id=' + forumPostID;
    var xmlhttp = new XMLHttpRequest();

    try
    {
        if (!redirect)
        {
           var elem = document.getElementById('exclude' + forumPostID);
           elem.style.visibility = 'hidden';
           elem.innerHTML = ' ';
        }
        xmlhttp.open("GET", url, false);
        xmlhttp.send(null);
        var response = xmlhttp.responseText;
        
        if (redirect)
        {
           window.location.href = document.referrer;
        }

    }
    catch (exception) { alert(exception.message); }

}

function GetTopicListHtml(page)
{
     var url = '/Handlers/TopicList.ashx?page=' + page;
     var xmlhttp = new XMLHttpRequest();

     try
     {
 
         xmlhttp.open("GET", url, false);
         xmlhttp.send(null);
         return xmlhttp.responseText;
 
     }
     catch (exception) { alert(exception.message); }
}

function ToggleTopicList(forceOpen,page)
{
 
    var elem = document.getElementById('lstTopics');

    if (elem.style.visibility == 'hidden' || forceOpen)
    {
        elem.style.height = '100%';
        elem.style.visibility = 'visible';
        elem.innerHTML = GetTopicListHtml(page);
        return;
    }

    ToggleTopicListClose();
}

function ToggleTopicListClose()
 {
    var elem = document.getElementById('lstTopics');
    elem.style.visibility = 'hidden';
    elem.style.height = '0px';
    elem.innerHTML = '';
} 


 




      
  