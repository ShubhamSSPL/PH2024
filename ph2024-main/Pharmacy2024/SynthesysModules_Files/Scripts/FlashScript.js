/************************************************************************************************
Name		- Flash Script
Description	- Flashing elements using script.
Version		- 3.7.0
Author		- Anoop Nair.
Company		- Synthesys (part of MKCL).

# COPYRIGHT NOTICE
# Copyright (c) 2005-2009 MKCL, All rights reserved.
# This script may be used and modified free of charge for Non-profit purposes by anyone as long
# as this copyright notice and the comments above are kept in their original form.
************************************************************************************************/
 
 var Flash_span=new Array();function Flash_Init(){var spans=document.getElementsByTagName("SPAN");var numFlash=0;for(i=0;i< spans.length;i++){if(String(spans.item(i).className).substring(0,7).toLowerCase()!="flashit")continue;Flash_span[numFlash]=spans.item(i);if(String(spans.item(i).className).substring(0,12).toLowerCase()!="flashitnodec"){if(Flash_span[numFlash].innerHTML.toLowerCase()=="new"){Flash_span[numFlash].innerHTML="";var image=document.createElement("IMG");image.src="../SynthesysModules_Files/Images/new.gif";image.alt="New";Flash_span[numFlash].appendChild(image);numFlash++;continue;}else{Flash_SetStyles(Flash_span[numFlash]);}}if(navigator.userAgent.indexOf("IE")!=-1){Flash_span[numFlash].style.display="inline-block";if(Flash_span[numFlash].style.filter !='undefined'){Flash_span[numFlash].style.filter="alpha(opacity=0)";setInterval("Flash_FilterWork("+numFlash+")",1000);}}else{if(Flash_span[numFlash].style.opacity !='undefined'){Flash_span[numFlash].style.opacity=0;Flash_Work(numFlash);}}numFlash++;}}function Flash_SetStyles(elem){elem.innerHTML="&bull;"+elem.innerHTML+"&bull;";elem.style.backgroundColor="#60C0EC";elem.style.background="#60C0EC";elem.style.border="1px solid red";elem.style.fontWeight="normal";elem.style.fontStyle="italic";elem.style.fontSize="90%";elem.style.color="red";}function Flash_FilterWork(index){Flash_span[index].style.filter="alpha(opacity="+(parseInt(Flash_span[index].style.filter.substring(14))+100)%200+")";}function Flash_Work(index){Flash_span[index].style.opacity=(parseInt(Flash_span[index].style.opacity)+1)%2;setTimeout('Flash_Work('+index+')',1000);}Synthesys.FuncLib.AddLoadEvent(Flash_Init);