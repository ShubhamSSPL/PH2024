function FillGroup(value)
{
 
  if(value!='-- Select --')
  {
          userType= value;  
          var e=document.getElementById('ctl00_rightContainer_ccbMenu_ddlUserType');
          userType=e.options[e.selectedIndex].value;
          document.getElementById('ctl00_rightContainer_hddUserType').value=userType;
          document.getElementById("ctl00_rightContainer_ccbMenu_ddlGroup").selectedIndex=0;
          document.getElementById("ctl00_rightContainer_ccbMenu_ddlGroup").disabled=true;
          document.getElementById("MenuGrid").rows[0].cells[0].innerHTML='';
          if(value!=undefined)
          document.getElementById('ctl00_rightContainer_hddGroup').value=''
          atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'ctl00_rightContainer_ccbMenu','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
          atk.Start('MenuManagement_MenuMgt.FillGroup',userType,FillGroup_Callback);  
  }
}
function FillGroup_Callback(response)
{
      atk.Stop();
      var grouplist=document.getElementById("ctl00_rightContainer_ccbMenu_ddlGroup");
      while (grouplist.hasChildNodes())
                    grouplist.removeChild(grouplist.childNodes[0]);
      if(response.value.Tables[0].Rows.length>0)
      {
                grouplist.disabled=false;
                grouplist.options[0]=new Option('-- Select --',0);
                for(var i=0;i<response.value.Tables[0].Rows.length;i++)
                {
                      grouplist.options[i+1]=new Option(response.value.Tables[0].Rows[i].GroupName,response.value.Tables[0].Rows[i].GroupId);
                }
                if(document.getElementById('ctl00_rightContainer_hddGroup').value!='')
                {
                      setSelectedIndex(document.getElementById('ctl00_rightContainer_ccbMenu_ddlGroup'), document.getElementById('ctl00_rightContainer_hddGroup').value);
                      GetMenus(document.getElementById('ctl00_rightContainer_hddGroup').value);
                }
        
      }
      else alert('There are no groups associated with this user type !!');
}
function GetMenus(value)
{
      if(value!='-- Select --')
      {
              document.getElementById('ctl00_rightContainer_hddGroup').value=value;
              atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'ctl00_rightContainer_ccbMenu','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
              atk.Start('MenuManagement_MenuMgt.GetMenus',value,userType,GetMenus_Callback);  
      }
  
}
function GetMenus_Callback(response)
{

      atk.Stop();
      var MenuGrid=document.getElementById("MenuGrid");
      var htmlContent;
      var ds=response.value;
      if(ds.Tables[0].Rows.length>0)
      {
                document.getElementById('trButtons').style.display='';
                htmlContent="<table id=\"TblBranch\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                for(var i=0;i<response.value.Tables[0].Rows.length;i++)
                {
                   
                      if(i==0)
                          htmlContent+="<tr class=\"Header\" ><th scope=\"col\">Sr.No</th><th scope=\"col\" >MenuName</th><th scope=\"col\">Order</th><th>IsActive</th><th>Edit</th><th>Delete</th><th>Schedule</th><th>Edit User</th></tr>";
                      htmlContent+="<tr class=\"NormalRow\" valign=\"center\">";
                      htmlContent+="<td align=\"center\" >"+parseInt(i+1)+"</td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:100px\" ><a onclick=\"ShowUserPopup("+parseInt(i+1)+")\" href=\"javascript:void(0)\">"+ds.Tables[0].Rows[i].MenuName+"</a></td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\"><input id=chkOrder"+parseInt(i+1)+" type=\"checkbox\" onclick=\"Ordering(this,"+parseInt(i+1)+")\" checked/>&nbsp;&nbsp;<span id=\"lbl"+parseInt(i+1)+"\" ><b>"+ds.Tables[0].Rows[i].MenuOrder+"</b></span></td>";
                      var IsActive=ds.Tables[0].Rows[i].IsActive==1?"checked":"";
                      htmlContent+="<td align=\"center\" ><input id=chkIsActive"+parseInt(i+1)+" type=\"checkbox\" "+IsActive+"/></td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"showAddEdit('Edit',"+parseInt(i+1)+")\"/></a></td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/delete.gif\" onclick=\"Delete("+parseInt(i+1)+")\"/></a></td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\">"+ds.Tables[0].Rows[i].Date+"</td>";
                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].ModuleId+"</td>";
                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].MenuId+"</td>";
                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].IsNew+"</td>";
                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].DetailId+"</td>";
                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].TypeOfMenu+"</td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"showSelectedUsers("+parseInt(i+1)+")\"/></a></td>";
                     
                      htmlContent+="</tr>";
                      MenuArray[i+1]=ds.Tables[0].Rows[i].DetailId+'#'+ds.Tables[0].Rows[i].IsActive;
                }
                
      }
      else 
      {
                document.getElementById('trButtons').style.display='';
                htmlContent="<table id=\"TblBranch\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                htmlContent+="<tr><td><font color=\"red\">No Menus Found !!!</font></td></tr>";
      }
      MenuGrid.rows[0].cells[0].innerHTML=htmlContent;
}
function setMutilingualForSpecificIds()
{
   att = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'ctl00_rightContainer_ccbMenu','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
   att.Start('MenuManagement_MenuMgt.Getkeys',document.getElementById('TblBranch').rows[AddEditIndex].cells[10].innerHTML,Getkeys_Callback); 
   
}
function Getkeys_Callback(response)
{
   att.Stop();
   var v=response.value;
   var lang=v.split(',');
   var rowCount=document.getElementById('ctl00_rightContainer_ccbAddEdit_gvLanguage').rows.length;
   document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultiLingualLink').checked=false;
   document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultiLingualContent').checked=false;
   document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultilingualText').checked=false;
   document.getElementById('trMLink').style.display='none';
   document.getElementById('trMContent').style.display='none';
   document.getElementById('trMText').style.display='none';
   for(var l=1;l<rowCount;l++)
   {
     document.getElementById('chkLang'+l).checked=false;
     document.getElementById('txtLang'+l).disabled=true;
     document.getElementById('txtLang'+l).value='';
   } 
   if(lang.length>1) 
   {
      if(document.getElementById('TblBranch').rows[AddEditIndex].cells[11].innerHTML=='1')
      {
        document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultiLingualLink').checked=true;
        ShowLanguageRow(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultiLingualLink'),'Link');  
      }  
      if(document.getElementById('TblBranch').rows[AddEditIndex].cells[11].innerHTML=='2')
      {
        document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultiLingualContent').checked=true;
        ShowLanguageRow(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultiLingualContent'),'Content');  
      }  
      if(document.getElementById('TblBranch').rows[AddEditIndex].cells[11].innerHTML=='3')
      {
        document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultilingualText').checked=true;
        ShowLanguageRow(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultilingualText'),'Text');  
      }  
   }    
   for(var i=0;i<lang.length;i++)
   {
     for(var j=1;j<rowCount;j++)
     {
       if(lang[i].split('#')[0]==document.getElementById('ctl00_rightContainer_ccbAddEdit_gvLanguage').rows[j].cells[2].innerHTML)
       {
         document.getElementById('chkLang'+j).checked=true;
         document.getElementById('txtLang'+j).disabled=false;
         document.getElementById('txtLang'+j).value=lang[i].split('#')[1]
       }
     }
   }
   
}
function showSelectedUsers(index)
{

  // Synthesys.FuncLib.AddLoadEvent(GetSpecificMenuUser);
   MenuIndex=index;
   GetSpecificMenuUser(index);
   document.getElementById('ctl00_rightContainer_ccbSpecificUser').Show('#000000',true);
}
function Delete(index)
{
     if(confirm ("Are you sure you want to delete this link !!"))
     {
               atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'ctl00_rightContainer_ccbMenu','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
               atk.Start('MenuManagement_MenuMgt.DeleteLink',document.getElementById('TblBranch').rows[index].cells[10].innerHTML,DeleteLink_Callback);  
     }   
}
function DeleteLink_Callback(response)
{
    atk.Stop();
    var ddl=document.getElementById('ctl00_rightContainer_ccbMenu_ddlGroup');
    GetMenus(ddl.options[ddl.selectedIndex].value);
}
function Ordering(checkBox,index)
{
      if(checkBox.checked==false)
      { 
             var OrderHtml=document.getElementById('lbl'+index).innerHTML;
             var order=OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1");
             for(var i=1;i<parseInt(document.getElementById('TblBranch').rows.length);i++)
             {
                   OrderHtml=document.getElementById('lbl'+i).innerHTML;
                   if(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))>parseInt(order))
                           document.getElementById('lbl'+i).innerHTML="<b>"+parseInt(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))-1)+"</b>";
                   if(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))==parseInt(order))
                           document.getElementById('lbl'+i).innerHTML='';
             }
      }
      else
      {
         var maxOrder=0;
         for(var i=1;i<parseInt(document.getElementById('TblBranch').rows.length);i++)
         {
                 OrderHtml=document.getElementById('lbl'+i).innerHTML;
                 if(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))>maxOrder)
                          maxOrder=parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"));
         }
         document.getElementById('lbl'+index).innerHTML="<b>"+(maxOrder+1)+"</b>";
      }
  
}
function GetMaxOrder()
{
     var maxOrder=0,OrderHtml;
     if(document.getElementById('TblBranch')!=null)
     {
         for(var i=1;i<parseInt(document.getElementById('TblBranch').rows.length);i++)
         {
                 OrderHtml=document.getElementById('lbl'+i).innerHTML;
                 if(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))>maxOrder)
                          maxOrder=parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"));
         }
         MaximumOrder=maxOrder;
         return MaximumOrder+1;
     }
     else return 1; 
}
function setSelectedIndex(s, v) 
{    
     for( var i = 0; i < s.options.length; i++ )
     {     
           if ( s.options[i].value == v ) 
           {           
                s.options[i].selected = true;  
                return;    
           } 
     }
}
function showAddEdit(flag,index)
{

      
      AddEditFlag=flag;
      AddEditIndex=index;
      fillModules();
      document.getElementById('btn_OpenLingualEditorLink').style.display='none';
      document.getElementById('btn_OpenLingualEditorText').style.display='none';
      document.getElementById('btn_OpenLingualEditorContent').style.display='none';
      var tbl=document.getElementById('TblBranch');
      if(flag=='Edit')
      {
         document.getElementById('tblOptions').style.display='none';
         if(document.getElementById('TblBranch').rows[index].cells[11].innerHTML=='1')
         {
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkAddEditIsActive').checked=document.getElementById('chkIsActive'+index).checked;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkAddEditNewLink').checked=tbl.rows[index].cells[9].innerHTML=='true'?true:false;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtStartDt').value=tbl.rows[index].cells[6].innerHTML.replace(/(.*?)To(.*)/i,"$1");
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtEndDt').value=tbl.rows[index].cells[6].innerHTML.replace(/(.*?)To(.*)/i,"$2");
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_lblAddEditOrder').innerHTML=document.getElementById('lbl'+index).innerHTML.replace(/(<b>.*?<\/b>)/i,"$1");
                 
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtLinkName').value=document.getElementById('TblBranch').rows[index].cells[1].innerHTML.replace(/.*>(.*?)<.*/,"$1");
              
                 if(document.getElementById('ctl00_rightContainer_ccbAddEdit_txtStartDt').value!='--' && document.getElementById('ctl00_rightContainer_ccbAddEdit_txtEndDt').value!='--')
                      document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleLink').checked=true;
                 else  
                      document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleLink').checked=false;
                 ShowDateRow(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleLink'),'Link'); 
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_rbOptions_0').checked=true;
                 document.getElementById('tblLink').style.display='';
                 document.getElementById('tblContent').style.display='none';
                 document.getElementById('tblText').style.display='none';
         }
         if(document.getElementById('TblBranch').rows[index].cells[11].innerHTML=='2')
         {
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_ContentIsActive').checked=document.getElementById('chkIsActive'+index).checked;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_ContentIsNew').checked=tbl.rows[index].cells[9].innerHTML=='true'?true:false;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentStartDate').value=tbl.rows[index].cells[6].innerHTML.replace(/(.*?)To(.*)/i,"$1");
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentEndDate').value=tbl.rows[index].cells[6].innerHTML.replace(/(.*?)To(.*)/i,"$2");
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_lblContentOrder').innerHTML=document.getElementById('lbl'+index).innerHTML.replace(/(<b>.*?<\/b>)/i,"$1");
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentMenuName').value=document.getElementById('TblBranch').rows[index].cells[1].innerHTML.replace(/.*>(.*?)<.*/,"$1");
              
                 if(document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentStartDate').value!='--' && document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentEndDate').value!='--')
                      document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleContent').checked=true;
                 else  
                      document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleContent').checked=false;
                 ShowDateRow( document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleContent'),'Content'); 
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_rbOptions_1').checked=true;
                 document.getElementById('ContentMenuName').style.display='';
                 document.getElementById('tblLink').style.display='none';
                 document.getElementById('tblContent').style.display='';
                 document.getElementById('tblText').style.display='none';
         }
         if(document.getElementById('TblBranch').rows[index].cells[11].innerHTML=='3')
         {
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkTextIsActive').checked=document.getElementById('chkIsActive'+index).checked;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkTextIsNew').checked=tbl.rows[index].cells[9].innerHTML=='true'?true:false;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_TextStartDt').value=tbl.rows[index].cells[6].innerHTML.replace(/(.*?)To(.*)/i,"$1");
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_TextEndDt').value=tbl.rows[index].cells[6].innerHTML.replace(/(.*?)To(.*)/i,"$2");
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_lblTextOrder').innerHTML=document.getElementById('lbl'+index).innerHTML.replace(/(<b>.*?<\/b>)/i,"$1");
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtText').innerHTML=document.getElementById('TblBranch').rows[index].cells[1].innerHTML.replace(/.*>(.*?)<.*/,"$1");
                 if(document.getElementById('ctl00_rightContainer_ccbAddEdit_TextStartDt').value!='--' && document.getElementById('ctl00_rightContainer_ccbAddEdit_TextEndDt').value!='--')
                      document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleText').checked=true;
                 else  
                      document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleText').checked=false;
                 ShowDateRow( document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleText'),'Text'); 
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_rbOptions_2').checked=true;
                 document.getElementById('tblLink').style.display='none';
                 document.getElementById('tblContent').style.display='none';
                 document.getElementById('tblText').style.display='';
         }
         
         setMutilingualForSpecificIds();
         
      }
      else
      {
         
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkAddEditIsActive').checked=true;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkAddEditNewLink').checked=true;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtStartDt').value='';
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtEndDt').value='';
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleLink').checked=false;
                 ShowDateRow(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleLink'),'Link'); 
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtLinkName').value='';
         
        
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_ContentIsActive').checked=true;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_ContentIsNew').checked=true;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentStartDate').value='';
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentEndDate').value='';
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleContent').checked=false;
                 ShowDateRow( document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleContent'),'Content'); 
                 document.getElementById('ContentMenuName').style.display='';
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentMenuName').value='';
         
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkTextIsActive').checked=true;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkTextIsNew').checked=true;
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_TextStartDt').value='';
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_TextEndDt').value='';
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_txtText').innerHTML='';
                 document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleText').checked=false;
                 ShowDateRow( document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleText'),'Text'); 
                 
                document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultiLingualLink').checked=false;
                document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultiLingualContent').checked=false;
                document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultilingualText').checked=false;
                document.getElementById('trMLink').style.display='none';
                document.getElementById('trMContent').style.display='none';
                document.getElementById('trMText').style.display='none';
        
      }
      ctl00_rightContainer_ccbAddEdit.Show('#000000',true,AddEditClose);
}
function AddEditClose()
{
         document.getElementById('tblOptions').style.display='';
         document.getElementById('ctl00_rightContainer_ccbAddEdit_rbOptions_0').checked=true;
         document.getElementById('tblLink').style.display='none';
         document.getElementById('tblContent').style.display='none';
         document.getElementById('tblText').style.display='none';
}
function ShowAddEditTables()
{
      document.getElementById('tblOptions').style.display='none';
      if(document.getElementById('ctl00_rightContainer_ccbAddEdit_rbOptions_0').checked==true)
      {
             document.getElementById('tblLink').style.display='';
             document.getElementById('tblContent').style.display='none';
             document.getElementById('tblText').style.display='none';
             document.getElementById('ctl00_rightContainer_ccbAddEdit_lblAddEditOrder').innerHTML='<b>'+GetMaxOrder()+'</b>';
      }
      if(document.getElementById('ctl00_rightContainer_ccbAddEdit_rbOptions_1').checked==true)
      {
             document.getElementById('tblLink').style.display='none';
             document.getElementById('tblContent').style.display='';
             document.getElementById('tblText').style.display='none';
             document.getElementById('ctl00_rightContainer_ccbAddEdit_lblContentOrder').innerHTML='<b>'+GetMaxOrder()+'</b>';
      }
      if(document.getElementById('ctl00_rightContainer_ccbAddEdit_rbOptions_2').checked==true)
      {
             document.getElementById('tblLink').style.display='none';
             document.getElementById('tblContent').style.display='none';
             document.getElementById('tblText').style.display='';
             document.getElementById('ctl00_rightContainer_ccbAddEdit_lblTextOrder').innerHTML='<b>'+GetMaxOrder()+'</b>';
      }
 }
function fillModules()
{
          document.getElementById("ctl00_rightContainer_ccbAddEdit_ddlMenu").selectedIndex=0;
          document.getElementById("ctl00_rightContainer_ccbAddEdit_ddlMenu").disabled=true;
//          var response= MenuManagement_MenuMgt.FillModule(1);
//          var modulelist=document.getElementById("ctl00_rightContainer_ccbAddEdit_ddlModule");
//          if(response.value.Tables[0].Rows.length>0)
//          {
//            modulelist.options[0]=new Option('-- Select --',0);
//            for(var i=0;i<response.value.Tables[0].Rows.length;i++)
//            {
//               modulelist.options[i+1]=new Option(response.value.Tables[0].Rows[i].ModuleName,response.value.Tables[0].Rows[i].ModuleId);
//               if(AddEditFlag=='Edit')
//               {
//                      if(modulelist.options[i+1].value==document.getElementById('TblBranch').rows[AddEditIndex].cells[7].innerHTML)
//                      {
//                          modulelist.options[i+1].selected=true;
//                          getMenusModuleWise(modulelist.options[i+1].value);
//                      }    
//               }
//            }
//          }
          atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'ctl00_rightContainer_ccbMenu','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
          atk.Start('MenuManagement_MenuMgt.FillModule',1,FillModule_Callback); 
}
function FillModule_Callback(response)
{
     atk.Stop();
     var modulelist=document.getElementById("ctl00_rightContainer_ccbAddEdit_ddlModule");
     if(response.value.Tables[0].Rows.length>0)
     {
        modulelist.options[0]=new Option('-- Select --',0);
        for(var i=0;i<response.value.Tables[0].Rows.length;i++)
        {
           modulelist.options[i+1]=new Option(response.value.Tables[0].Rows[i].ModuleName,response.value.Tables[0].Rows[i].ModuleId);
           if(AddEditFlag=='Edit')
           {
                  if(modulelist.options[i+1].value==document.getElementById('TblBranch').rows[AddEditIndex].cells[7].innerHTML)
                  {
                      modulelist.options[i+1].selected=true;
                      getMenusModuleWise(modulelist.options[i+1].value);
                  }    
           }
        }
     }
}
function getMenusModuleWise(value)
{
      var menulist=document.getElementById("ctl00_rightContainer_ccbAddEdit_ddlMenu")
      menulist.disabled=true;
      menulist.selectedIndex=0;
      if(value!='-- Select --')
      {
         
         atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'ctl00_rightContainer_ccbMenu','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
         atk.Start('MenuManagement_MenuMgt.MenusModuleWise',value,FillMenusModuleWise_Callback); 
      }

}
function FillMenusModuleWise_Callback(response)
{
       atk.Stop();
       var menulist=document.getElementById("ctl00_rightContainer_ccbAddEdit_ddlMenu");
       while (menulist.hasChildNodes())
                    menulist.removeChild(menulist.childNodes[0]);
       if(response.value.Tables[0].Rows.length>0)
       {
            menulist.disabled=false;
            menulist.options[0]=new Option('-- Select --',0);
            for(var i=0;i<response.value.Tables[0].Rows.length;i++)
            {
               menulist.options[i+1]=new Option(response.value.Tables[0].Rows[i].MenuName,response.value.Tables[0].Rows[i].MenuId);
               if(AddEditFlag=='Edit')
               {
                  if(menulist.options[i+1].value==document.getElementById('TblBranch').rows[AddEditIndex].cells[8].innerHTML)
                        menulist.options[i+1].selected=true;
               }
            }
       }
}
function ValidateLink(flag)
{
      var errorMsg='';
      document.getElementById('ctl00_rightContainer_hddMultilingual').value='';
      if(AddEditIndex!=0)
      document.getElementById('ctl00_rightContainer_hddAddEditIndex').value=document.getElementById('TblBranch').rows[AddEditIndex].cells[10].innerHTML;
      if(flag=='Link')
      {
          if(document.getElementById('ctl00_rightContainer_ccbAddEdit_ddlModule').selectedIndex==0 || document.getElementById('ctl00_rightContainer_ccbAddEdit_ddlModule').selectedIndex==-1) errorMsg='Please select the module !!\n';
          if(document.getElementById('ctl00_rightContainer_ccbAddEdit_ddlMenu').selectedIndex==0 || document.getElementById('ctl00_rightContainer_ccbAddEdit_ddlMenu').selectedIndex==-1) errorMsg='Please select menu !!\n';
          if(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleLink').checked==true)
          {
              if(document.getElementById('ctl00_rightContainer_ccbAddEdit_txtStartDt').value=='' || document.getElementById('ctl00_rightContainer_ccbAddEdit_txtStartDt').value=='--') errorMsg='Please select menu\'s start date & time !!\n';
              if(document.getElementById('ctl00_rightContainer_ccbAddEdit_txtEndDt').value=='' || document.getElementById('ctl00_rightContainer_ccbAddEdit_txtEndDt').value=='--') errorMsg='Please select menu\'s end date & time !!\n';
          }
          if(document.getElementById('ctl00_rightContainer_ccbAddEdit_txtLinkName').value=='')
          {
            errorMsg='Display Text should not be blank  !!\n';
          }
          if(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultiLingualLink').checked==true)
          {
             var rowCount=document.getElementById('ctl00_rightContainer_ccbAddEdit_gvLanguage').rows.length;
             var jFlag=0;
             if(rowCount>1)
             {
               
               for(var i=1;i<rowCount;i++)
               {
                 
                 if(document.getElementById('chkLang'+i).checked==true)
                 {
                    if(document.getElementById('txtLang'+i).value!="")
                    {
                      jFlag=1
                    
                    }
                    else
                    {
                      jFlag=0;
                      break;
                    }  
                 }
               }
             }
             if(jFlag==0)
             errorMsg='Please give text for the selected language,or select any language';
             else CreateMultiLingualXML();
          }
          
           
         
      }
      if(flag=='Content')
      {
          if(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleContent').checked==true)
          {
              if(document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentStartDate').value=='' || document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentStartDate').value=='--') errorMsg='Please select content\'s start date & time !!\n';
              if(document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentEndDate').value=='' || document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentEndDate').value=='--') errorMsg='Please select content\'s end date & time !!\n';
          }
          //if(AddEditFlag!='Edit')
          //{
            if(document.getElementById('ctl00_rightContainer_ccbAddEdit_txtContentMenuName').value=='') 
                errorMsg='Menu name should not be blank  !!\n';
          //}
          if(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultiLingualContent').checked==true)
          {
             var rowCount=document.getElementById('ctl00_rightContainer_ccbAddEdit_gvLanguage').rows.length;
             var jFlag=0;
             if(rowCount>1)
             {
               
               for(var i=1;i<rowCount;i++)
               {
                 
                 if(document.getElementById('chkLang'+i).checked==true)
                 {
                    if(document.getElementById('txtLang'+i).value!="")
                    {
                      jFlag=1
                    
                    }
                    else
                    {
                      jFlag=0;
                      break;
                    }  
                 }
               }
             }
             if(jFlag==0)
             errorMsg='Please give text for the selected language,or select any language';
             else CreateMultiLingualXML();
          } 
      }
      if(flag=='Text')
      {
          if(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkScheduleText').checked==true)
          {  
              if(document.getElementById('ctl00_rightContainer_ccbAddEdit_TextStartDt').value=='' || document.getElementById('ctl00_rightContainer_ccbAddEdit_TextStartDt').value=='--') errorMsg='Please select text\'s start date & time !!\n';
              if(document.getElementById('ctl00_rightContainer_ccbAddEdit_TextEndDt').value=='' || document.getElementById('ctl00_rightContainer_ccbAddEdit_TextEndDt').value=='--') errorMsg='Please select text\'s end date & time !!\n';
          }
          if(document.getElementById('ctl00_rightContainer_ccbAddEdit_txtText').value=='') 
                errorMsg='Menu text should not be blank  !!\n';
          if(document.getElementById('ctl00_rightContainer_ccbAddEdit_chkmultilingualText').checked==true)
          {
             var rowCount=document.getElementById('ctl00_rightContainer_ccbAddEdit_gvLanguage').rows.length;
             var jFlag=0;
             if(rowCount>1)
             {
               
               for(var i=1;i<rowCount;i++)
               {
                 
                 if(document.getElementById('chkLang'+i).checked==true)
                 {
                    if(document.getElementById('txtLang'+i).value!="")
                    {
                      jFlag=1
                    
                    }
                    else
                    {
                      jFlag=0;
                      break;
                    }  
                 }
               }
             }
             if(jFlag==0)
             errorMsg='Please give text for the selected language,or select any language';
             else CreateMultiLingualXML();
          }       
      }
      if(errorMsg=='') 
      {
         CreateNewLinkText(flag);
         
         
         return true;
      }
      else 
      {
         alert(errorMsg);
         return false;
      }
 
}
function CreateMultiLingualXML()
{
  var rowCount=document.getElementById('ctl00_rightContainer_ccbAddEdit_gvLanguage').rows.length;
  var xml='';
  for(var i=1;i<rowCount;i++)
  {
    if(document.getElementById('chkLang'+i).checked==true)
       if(document.getElementById('txtLang'+i).value!="")
       {
         xml+="@Language name=\""+document.getElementById('ctl00_rightContainer_ccbAddEdit_gvLanguage').rows[i].cells[2].innerHTML+"\"#";
         xml+="@Page name=\"commonlanguagetexts\"#";
         var Edit='';
         if(AddEditFlag=='Edit')
         Edit='D'+document.getElementById('TblBranch').rows[AddEditIndex].cells[10].innerHTML;
         xml+="@data key=\""+Edit+"\" value=\""+document.getElementById('txtLang'+i).value+"\"#";
         xml+="@/Page#";
         xml+="@/Language#";
       }
  }
  document.getElementById('ctl00_rightContainer_hddMultilingual').value=xml;
}
function ValidateAll()
{
  var flag=0;
  for(var i=1;i<parseInt(document.getElementById('TblBranch').rows.length);i++)
     {
         OrderHtml=document.getElementById('lbl'+i).innerHTML;
         if(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1")=='')
         {
            alert('Please select order of all the links !!');
            flag=1;
            return false;
         }
     }
     if(flag==0)
        CreateXML();
     
}
function CreateXML()
{
      var XML='';
      var tbl=document.getElementById('TblBranch');
      XML='@Root#';
      for(var i=1;i<parseInt(document.getElementById('TblBranch').rows.length);i++)
      {
            XML+="@Menu Id=\""+tbl.rows[i].cells[8].innerHTML+"\"";
            XML+=" GroupId=\""+document.getElementById('ctl00_rightContainer_ccbMenu_ddlGroup').options[document.getElementById('ctl00_rightContainer_ccbMenu_ddlGroup').selectedIndex].value+"\"";
            XML+=" UserTypeId=\""+document.getElementById('ctl00_rightContainer_ccbMenu_ddlUserType').options[document.getElementById('ctl00_rightContainer_ccbMenu_ddlUserType').selectedIndex].value+"\"";
            XML+=" ModuleId=\""+tbl.rows[i].cells[7].innerHTML+"\"";
            XML+=" Order=\""+document.getElementById('lbl'+i).innerHTML.replace(/<b>(.*?)<\/b>/i,"$1")+"\"";
            var IsAct=document.getElementById('chkIsActive'+i).checked==true?1:0
            XML+=" IsActive=\""+IsAct+"\"";
            var date=tbl.rows[i].cells[6].innerHTML.replace(/(.*?)To(.*)/i,"$1");
            XML+=" StartDate=\""+date.replace(/(.*?)\/(.*?)\/.* /,"$2/$1/$3")+"\"";
            date=tbl.rows[i].cells[6].innerHTML.replace(/(.*?)To(.*)/i,"$2");
            XML+=" EndDate=\""+date.replace(/(.*?)\/(.*?)\/.* /,"$2/$1/$3")+"\"";
            XML+=" DetailId=\""+tbl.rows[i].cells[10].innerHTML+"\"/#";
        
      }
      XML+='@/Root#';
      document.getElementById('ctl00_rightContainer_hddText').value=XML;
}
function CreateNewLinkText(flag)
{

      var Content='';
      if(flag=='Link')
      {
          Content='@ModuleId='+document.getElementById('ctl00_rightContainer_ccbAddEdit_ddlModule').options[document.getElementById('ctl00_rightContainer_ccbAddEdit_ddlModule').selectedIndex].value+'@';
          Content+='@MenuId='+document.getElementById('ctl00_rightContainer_ccbAddEdit_ddlMenu').options[document.getElementById('ctl00_rightContainer_ccbAddEdit_ddlMenu').selectedIndex].value+'@';
          Content+='@UserTypeId='+document.getElementById('ctl00_rightContainer_ccbMenu_ddlUserType').options[document.getElementById('ctl00_rightContainer_ccbMenu_ddlUserType').selectedIndex].value+'@';
          Content+='@GroupId='+document.getElementById('ctl00_rightContainer_ccbMenu_ddlGroup').options[document.getElementById('ctl00_rightContainer_ccbMenu_ddlGroup').selectedIndex].value+'@';
          Content+='@Order='+document.getElementById('ctl00_rightContainer_ccbAddEdit_lblAddEditOrder').innerHTML.replace(/<b>(.*?)<\/b>/i,"$1")+'@';
          var Edit='';
          if(AddEditFlag=='Edit')
          Edit=document.getElementById('TblBranch').rows[AddEditIndex].cells[10].innerHTML;
          Content+='@DetailId='+Edit+'@';
      }
      if(flag=='Content')
      {
          Content+='@UserTypeId='+document.getElementById('ctl00_rightContainer_ccbMenu_ddlUserType').options[document.getElementById('ctl00_rightContainer_ccbMenu_ddlUserType').selectedIndex].value+'@';
          Content+='@GroupId='+document.getElementById('ctl00_rightContainer_ccbMenu_ddlGroup').options[document.getElementById('ctl00_rightContainer_ccbMenu_ddlGroup').selectedIndex].value+'@';
          Content+='@Order='+document.getElementById('ctl00_rightContainer_ccbAddEdit_lblContentOrder').innerHTML.replace(/<b>(.*?)<\/b>/i,"$1")+'@';
          var Edit='';
          if(AddEditFlag=='Edit')
          Edit=document.getElementById('TblBranch').rows[AddEditIndex].cells[10].innerHTML;
          Content+='@DetailId='+Edit+'@';
      }
      if(flag=='Text')
      {
          Content+='@UserTypeId='+document.getElementById('ctl00_rightContainer_ccbMenu_ddlUserType').options[document.getElementById('ctl00_rightContainer_ccbMenu_ddlUserType').selectedIndex].value+'@';
          Content+='@GroupId='+document.getElementById('ctl00_rightContainer_ccbMenu_ddlGroup').options[document.getElementById('ctl00_rightContainer_ccbMenu_ddlGroup').selectedIndex].value+'@';
          Content+='@Order='+document.getElementById('ctl00_rightContainer_ccbAddEdit_lblTextOrder').innerHTML.replace(/<b>(.*?)<\/b>/i,"$1")+'@';
          var Edit='';
          if(AddEditFlag=='Edit')
          Edit=document.getElementById('TblBranch').rows[AddEditIndex].cells[10].innerHTML;
          Content+='@DetailId='+Edit+'@';
      }
      document.getElementById('ctl00_rightContainer_hddText').value=Content;
 
}
function ShowUserPopup(index)
{
   MenuIndex=index;
   radioCheckbox='';
   document.getElementById('ctl00_rightContainer_ccbUser_txtSearchbox').value='';
   document.getElementById('UserGrid').rows[1].cells[0].innerHTML='';
   document.getElementById('ctl00_rightContainer_ccbUser_chkByLogin').checked=false;
   document.getElementById('ctl00_rightContainer_ccbUser_chkByName').checked=false;
   document.getElementById('trUser').style.display='none';
   if(CheckMenuActive(index)=='false')
   {
      ctl00_rightContainer_ccbUser.Show('#000000',true);
      //GetSpecificMenuUser(index);
   }   
   else alert('You can only associate users to specific menu,\nif that menu is not active !!');   
}
function GetSpecificMenuUser(index)
{
      atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'ctl00_rightContainer_ccbMenu','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
      atk.Start('MenuManagement_MenuMgt.GetSpecificMenuUser',MenuArray[index].replace(/(.*)#.*/,"$1"),GetSpecificMenuUser_CallBack); 
}
function GetSpecificMenuUser_CallBack(response)
{

      atk.Stop();
      var ds=response.value;
      var UserGrid=document.getElementById('tblMenuWiseUser');
      if(ds.Tables[0].Rows.length>0)
      {
                
                htmlContent="<table id=\"MenuWiseUserDt\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                for(var i=0;i<response.value.Tables[0].Rows.length;i++)
                {
                      if(i==0)
                          htmlContent+="<tr class=\"Header\" ><th scope=\"col\">Sr.No</th><th scope=\"col\" >UserName</th><th scope=\"col\">LoginId</th><th>Delete</th></tr>";
                      htmlContent+="<tr class=\"NormalRow\" valign=\"center\">";
                      htmlContent+="<td align=\"center\" >"+parseInt(i+1)+"</td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\" >"+ds.Tables[0].Rows[i].UserName+"</td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\">"+ds.Tables[0].Rows[i].LoginId+"</td>";
                      //htmlContent+="<td align=\"center\" style=\"background-color:transparent;\">"+ds.Tables[0].Rows[i].DATE+"</td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/delete.gif\" onclick=\"DeleteUser("+parseInt(i+1)+")\"/></a></td>";
                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].UserId+"</td>";
                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].DetailId+"</td>";
                      
                      htmlContent+="</tr>";
                }
                
      }
      else 
      {        
                document.getElementById('trUser').style.display='none';     
                htmlContent="<table id=\"TblUser\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                htmlContent+="<tr><td><font color=\"red\">No Users Found !!!</font></td></tr>";
      }
      UserGrid.rows[0].cells[0].innerHTML=htmlContent;
  
}
function DeleteUser(index)
{
      var tbl=document.getElementById('MenuWiseUserDt');
      atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'ctl00_rightContainer_ccbSpecificUser','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
      atk.Start('MenuManagement_MenuMgt.DeleteUser',tbl.rows[index].cells[4].innerHTML,tbl.rows[index].cells[5].innerHTML,DeleteUser_CallBack); 

}
function DeleteUser_CallBack(response)
{
   atk.Stop();
   GetSpecificMenuUser(MenuIndex);
 
} 
function CheckMenuActive(index)
{
    return MenuArray[index].replace(/.*#(.*)/,"$1");
}

function RadioEffect(checkBox)
{
   if(checkBox.checked==true)
   {
     if(checkBox.id=='ctl00_rightContainer_ccbUser_chkByName')
        document.getElementById('ctl00_rightContainer_ccbUser_chkByLogin').checked=false;
     else  document.getElementById('ctl00_rightContainer_ccbUser_chkByName').checked=false;
     radioCheckbox=checkBox;
   }
   else radioCheckbox='';
    
}
function SearchUsers()
{
   if(radioCheckbox!='' && radioCheckbox!=undefined)
   {
        if(document.getElementById('ctl00_rightContainer_ccbUser_txtSearchbox').value!='')
        {
            var columntype;
            if(radioCheckbox.id=='ctl00_rightContainer_ccbUser_chkByName')
                columntype='Name';
            else columntype='Id';
            var KeyWord=document.getElementById('ctl00_rightContainer_ccbUser_txtSearchbox').value;
            atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'ctl00_rightContainer_ccbUser','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
            atk.Start('MenuManagement_MenuMgt.GetUsers',KeyWord,columntype,userType,GetUsers_Callback); 
        } 
        else alert('Search box should not be blank !!');
    }
    else alert('Select any search criteria !!');
}
function GetUsers_Callback(response)
{
  atk.Stop();
  var ds=response.value;
  var UserGrid=document.getElementById('UserGrid');
  if(ds.Tables[0].Rows.length>0)
      {
                document.getElementById('trUser').style.display='';
                htmlContent="<table id=\"TblUser\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                for(var i=0;i<response.value.Tables[0].Rows.length;i++)
                {
                      if(i==0)
                          htmlContent+="<tr class=\"Header\" ><th scope=\"col\">Sr.No</th><th scope=\"col\" >UserName</th><th scope=\"col\">LoginId</th><th>Select</th><th>Start Date</th><th>End Date</th></tr>";
                      htmlContent+="<tr class=\"NormalRow\" valign=\"center\">";
                      htmlContent+="<td align=\"center\" style=\"width:10px\">"+parseInt(i+1)+"</td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\" >"+ds.Tables[0].Rows[i].UserName+"</td>";
                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\">"+ds.Tables[0].Rows[i].LoginId+"</td>";
                      htmlContent+="<td align=\"center\" ><input id=\"chkUser"+parseInt(i+1)+"\" type=\"checkbox\" onclick=\"enable_ClaenderInput("+parseInt(i+1)+")\"/></td>";
                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].UserID+"</td>";
                      htmlContent+="<td align=\"center\" ><input type=\"text\" id=\"txtSCal"+parseInt(i+1)+"\" onmousedown=\"register_Calander(this)\" size=\"\16\" disabled/></td>";
                      htmlContent+="<td align=\"center\" ><input type=\"text\" id=\"txtECal"+parseInt(i+1)+"\" onmousedown=\"register_Calander(this)\" size=\"\16\" disabled/></td>";
                      htmlContent+="</tr>";
                      
                }
      }
      else 
      {        
                document.getElementById('trUser').style.display='none';     
                htmlContent="<table id=\"TblUser\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                htmlContent+="<tr><td><font color=\"red\">No Users Found !!!</font></td></tr>";
      }
      UserGrid.rows[1].cells[0].innerHTML=htmlContent;
}
function enable_ClaenderInput(index)
{

   var tbl=document.getElementById('TblUser');
   if(document.getElementById('chkUser'+index).checked==true)
   {
      tbl.rows[index].cells[5].firstChild.disabled=false;
      tbl.rows[index].cells[6].firstChild.disabled=false;
      
   }
   else
   {
      tbl.rows[index].cells[5].firstChild.disabled=true;
      tbl.rows[index].cells[6].firstChild.disabled=true;
   }
   tbl.rows[index].cells[5].firstChild.value='';
   tbl.rows[index].cells[6].firstChild.value='';
}
function register_Calander(input)
{
      document.getElementById('calendar_div').style.zIndex=600;
      $("#"+input.id+", #"+input.id+"").calendar();
}
function Validate_UserCheckBox()
{

       var flag=0,tflag=0,XML='';
       var tbl=document.getElementById('TblUser');
       for(var i=1;i<tbl.rows.length;i++)
       {
           if(document.getElementById('chkUser'+i).checked==true)
           {
              if(Validate_UserDate(i))
                    XML+=createUserXML(i);
              else return false;
           }
       }
      
       if(XML!='')
       SaveUserSpecificMenus("<Root>"+XML+"</Root>");
       else 
       {  
            alert('Select any user !!');
            return false;
       }
       ctl00_rightContainer_ccbUser.Hide();   
       
}
function Validate_UserDate(index)
{
   var userTbl=document.getElementById('TblUser');
   if(userTbl.rows[index].cells[5].firstChild.value=='')
   {
      alert('Select Start Date !!');
      return false;
   } 
   else if(userTbl.rows[index].cells[6].firstChild.value=='')
   {
      alert('Select End Date !!');
      return false;    
   }
   return true;
}

function SaveUserSpecificMenus(XML)
{
     atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'ctl00_rightContainer_ccbUser','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
     atk.Start('MenuManagement_MenuMgt.SaveUserSpecificMenus',XML,SaveUserSpecificMenus_Callback);
}
function SaveUserSpecificMenus_Callback(response)
{
   atk.Stop();
   //GetSpecificMenuUser(MenuIndex);
}
function createUserXML(index)
{ 
   var XML='';
   var menuTbl=document.getElementById('TblBranch');
   var userTbl=document.getElementById('TblUser');
   XML+="<Menu DetailId=\""+menuTbl.rows[MenuIndex].cells[10].innerHTML+"\"";
   XML+=" UserId=\""+userTbl.rows[index].cells[4].innerHTML+"\"";
   var LoginID=UserLoginId;
   XML+=" LoginId=\""+LoginID+"\"";
   XML+=" SDate=\""+userTbl.rows[index].cells[5].firstChild.value.replace(/(.*?)\/(.*?)\//,"$2/$1/")+"\"";
   XML+=" EDate=\""+userTbl.rows[index].cells[6].firstChild.value.replace(/(.*?)\/(.*?)\//,"$2/$1/")+"\"/>";
   return XML;      
          
}
function EnableLanguageTextBox(checkbox,index)
{
  if(checkbox.checked==true)
     document.getElementById('txtLang'+index).disabled=false;
  else 
   {
      document.getElementById('txtLang'+index).value='';
      document.getElementById('txtLang'+index).disabled=true;
   }
}
function ShowLanguageRow(checkbox,flag)
{
  
  if(flag=='Link')
  {
    if(checkbox.checked)
    {
      document.getElementById('btn_OpenLingualEditorLink').style.display='';
      document.getElementById('trMLink').style.display='';
      document.getElementById('trMContent').cells[0].innerHTML='';
      document.getElementById('trMText').cells[0].innerHTML='';
      document.getElementById('trMLink').cells[0].innerHTML=document.getElementById('tblLanguage').rows[0].cells[0].innerHTML;
      
    }  
    else
    {
      document.getElementById('trMLink').style.display='none';
      document.getElementById('btn_OpenLingualEditorLink').style.display='none';
    } 
  }
  if(flag=='Content')
  {
    if(checkbox.checked)
    {
      document.getElementById('btn_OpenLingualEditorContent').style.display='';
      document.getElementById('trMContent').style.display='';
      document.getElementById('trMLink').cells[0].innerHTML='';
      document.getElementById('trMText').cells[0].innerHTML='';
      document.getElementById('trMContent').cells[0].innerHTML=document.getElementById('tblLanguage').rows[0].cells[0].innerHTML;
      
    }  
    else
    {
     document.getElementById('btn_OpenLingualEditorContent').style.display='none';
     document.getElementById('trMContent').style.display='none';
    } 
  } 
  if(flag=='Text')
  {
    if(checkbox.checked)
    {
      document.getElementById('btn_OpenLingualEditorText').style.display='';
      document.getElementById('trMText').style.display='';
      document.getElementById('trMLink').cells[0].innerHTML='';
      document.getElementById('trMContent').cells[0].innerHTML='';
      document.getElementById('trMText').cells[0].innerHTML=document.getElementById('tblLanguage').rows[0].cells[0].innerHTML;
      
    }  
    else
    {
      document.getElementById('trMText').style.display='none';
      document.getElementById('btn_OpenLingualEditorText').style.display='none';
    }  
  }  
}
function ShowDateRow(checkbox,flag)
{
  if(flag=='Link')
    if(checkbox.checked)
      document.getElementById('trDtLink').style.display='';
    else
     document.getElementById('trDtLink').style.display='none';
  if(flag=='Content')
    if(checkbox.checked)
      document.getElementById('trDtContent').style.display='';
    else
     document.getElementById('trDtContent').style.display='none';
  if(flag=='Text')
    if(checkbox.checked)
      document.getElementById('trDtText').style.display='';
    else
     document.getElementById('trDtText').style.display='none';   
}

