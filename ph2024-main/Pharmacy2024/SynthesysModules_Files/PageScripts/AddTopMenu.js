var Groups=new Array();
var AddEditIndex;
var atk;
var OrderString='';

function Delete(index)
{
     if(confirm ("Are you sure you want to delete this link !!"))
     {
               document.getElementById('gvMenu').rows[index].style.display='None'
               document.getElementById('chk'+index).checked=false;
               Ordering(document.getElementById('chk'+index),index);
               atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_ccbMenu','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
         atk.Start('MenuManagement_AddTopMenu.DeleteLink',document.getElementById('gvMenu').rows[index].cells[6].innerHTML,DeleteLink_Callback);  
     }   
}
function DeleteLink_Callback(response)
{
    atk.Stop();
    
}
function GroupOrdering(checkBox,index)
{

      if(checkBox.checked==false)
      { 
             var OrderHtml=document.getElementById('lbl2'+index).innerHTML;
             var order=OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1");
             for(var i=1;i<parseInt(document.getElementById('lstGroup').rows.length);i++)
             {
                   OrderHtml=document.getElementById('lbl2'+i).innerHTML;
                   if(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))>parseInt(order))
                           document.getElementById('lbl2'+i).innerHTML="<b>"+parseInt(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))-1)+"</b>";
                   if(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))==parseInt(order))
                           document.getElementById('lbl2'+i).innerHTML='';
             }
             var reg;
             
             var len=OrderString.length;
             var gId=document.getElementById('lstGroup').rows[index].cells[2].innerHTML;
             reg=RegExp("(.*,)("+gId+",)(.*)");
             OrderString=OrderString.replace(reg,"$1$3");
             if(len==OrderString.length) 
             {
                reg=RegExp("(.*)("+gId+",)(.*)");
                OrderString=OrderString.replace(reg,"$1$3"); 
             }
      }
      else
      {
         var maxOrder=0;
         for(var i=1;i<parseInt(document.getElementById('lstGroup').rows.length);i++)
         {
                 OrderHtml=document.getElementById('lbl2'+i).innerHTML;
                 if(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))>maxOrder)
                          maxOrder=parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"));
         }
         document.getElementById('lbl2'+index).innerHTML="<b>"+(maxOrder+1)+"</b>";
         OrderString+=document.getElementById('lstGroup').rows[index].cells[2].innerHTML+',';
      }
  
}
function Ordering(checkBox,index)
{

      if(checkBox.checked==false)
      { 
             var OrderHtml=document.getElementById('lbl'+index).innerHTML;
             var order=OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1");
             for(var i=1;i<parseInt(document.getElementById('gvMenu').rows.length);i++)
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
         for(var i=1;i<parseInt(document.getElementById('gvMenu').rows.length);i++)
         {
                 OrderHtml=document.getElementById('lbl'+i).innerHTML;
                 if(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))>maxOrder)
                          maxOrder=parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"));
         }
         document.getElementById('lbl'+index).innerHTML="<b>"+(maxOrder+1)+"</b>";
      }
  
}
function showAddEdit(index)
{

   AddEditIndex=index; 
   document.getElementById('btn_OpenLingualEditorContent').style.display='none';
   if(index==0)
   {
      document.getElementById('rightContainer_ccbAddEdit_txtMenuName').value='';
      document.getElementById('rightContainer_ccbAddEdit_chkAddEditIsActive').checked=true;
      document.getElementById('rightContainer_ccbAddEdit_lblAddEditOrder').innerHTML='<b>'+GetMaxOrder()+'</b>';
      SelectTableValues(document.getElementById('lstGroup'),'');
      document.getElementById('rightContainer_ccbAddEdit_chkmultiLingualLink').checked=false;
      document.getElementById('trLanguage').style.display='none';
      var rowCount=document.getElementById('rightContainer_ccbAddEdit_gvLanguage').rows.length;
      for(var l=1;l<rowCount;l++)
      {
        document.getElementById('chkLang'+l).checked=false;
        document.getElementById('txtLang'+l).disabled=true;
        document.getElementById('txtLang'+l).value='';
      } 
   }
   else
   {
      
      
      
      var tbl=document.getElementById('gvMenu');
      document.getElementById('rightContainer_ccbAddEdit_txtMenuName').value=tbl.rows[index].cells[1].innerHTML;
      document.getElementById('rightContainer_ccbAddEdit_chkAddEditIsActive').checked=document.getElementById('chkIsActive'+index).checked;
      document.getElementById('rightContainer_ccbAddEdit_lblAddEditOrder').innerHTML=document.getElementById('lbl'+index).innerHTML.replace(/(<b>.*?<\/b>)/i,"$1");
      SelectTableValues(document.getElementById('lstGroup'),tbl.rows[index].cells[7].innerHTML);
      setMutilingualForSpecificIds();
   }
  rightContainer_ccbAddEdit.Show('#000000',true);
}
function GetMaxOrder()
{
     var maxOrder=0,OrderHtml;
     if(document.getElementById('gvMenu')!=null)
     {
         for(var i=1;i<parseInt(document.getElementById('gvMenu').rows.length);i++)
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
function SelectTableValues(control,ids)
{

  var id=ids.split(',');
  var optsLength = control.rows.length;
  var count=1;
  var index=new Array();
  for(var l=0;l<index.length;l++)
  {
     document.getElementById('grOrder'+l).checked=false;
     document.getElementById('lbl2'+l).innerHTML='';
  }
  
  for(var j=0;j<id.length;j++ )
  {
    var flag=0;
    for(var i=1;i<optsLength;i++)
    {
        if(control.rows[i].cells[2].innerHTML==id[j]) 
        { 
           flag=1; 
           document.getElementById('grOrder'+i).checked=true;
           document.getElementById('lbl2'+i).innerHTML='<b>'+count+'</b>';
           OrderString+=id[j]+',';
           index[count-1]=i;
           count++;
           
           break;
        }
         
        
        
    }
  }
       
    
  
}

function SelectedValue(control)
{
  var Ids='',text='';   
  var optsLength = control.options.length;
  var count=0;
  for(var i=0;i<optsLength;i++)
  {
    if(control.options[i].selected) 
    { 
       count++;
       if(count>1) 
       {
         Ids+=control.options[i].value+',';
         
       } 
       else
       {
         Ids+=control.options[i].value;
         
       }
    }  
  }
  return [Ids,text];
}
function ValidateAddEdit()
{

  var errorMsg='';
  document.getElementById('rightContainer_hddMultilingual').value='';
  if(AddEditIndex!=0)
  document.getElementById('rightContainer_hddAddEditIndex').value=document.getElementById('gvMenu').rows[AddEditIndex].cells[6].innerHTML;
     
  if(document.getElementById('rightContainer_ccbAddEdit_txtMenuName').value=='') errorMsg+='Menu name should not be blank !!\n';
  if(OrderString=="") errorMsg+='Select any group !!\n';
  if(document.getElementById('rightContainer_ccbAddEdit_chkmultiLingualLink').checked==true)
  {
     var rowCount=document.getElementById('rightContainer_ccbAddEdit_gvLanguage').rows.length;
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
  if(errorMsg=='') 
  { 
    document.getElementById('rightContainer_hddText').value= CreateText();
    return true;
  }  
  else 
  {
    alert(errorMsg);
    return false;
  }
    
  
}
function CreateText()
{
  var xml='';
  if(AddEditIndex==0)
  xml+='@MenuId=0@';
  else xml+='@MenuId='+document.getElementById('gvMenu').rows[AddEditIndex].cells[6].innerHTML+'@';
  xml+='@MenuOrder='+document.getElementById('rightContainer_ccbAddEdit_lblAddEditOrder').innerHTML.replace(/<b>(.*?)<\/b>/i,"$1")+'@';
  xml+='@GroupIds='+OrderString+'@';
  xml+='@UserTypeId='+UserTId+'@';
  return xml;
}
function ValidateAll()
{
  var flag=0;
  if(document.getElementById('gvMenu')!=null)
  {
      for(var i=1;i<parseInt(document.getElementById('gvMenu').rows.length);i++)
         {
             OrderHtml=document.getElementById('lbl'+i).innerHTML;
             if(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1")=='' && document.getElementById('gvMenu').rows[i].style.display!='none')
             {
                alert('Please select order of all the links !!');
                flag=1;
                return false;
             }
         }
         if(flag==0)
            CreateXML();
  }  
  else return false; 
}
function CreateXML()
{

      var XML='';
      var tbl=document.getElementById('gvMenu');
      XML='@Root#';
      for(var i=1;i<parseInt(document.getElementById('gvMenu').rows.length);i++)
      {
          if(tbl.rows[i].style.display!='none')
          {
            XML+="@Menu Id=\""+tbl.rows[i].cells[6].innerHTML+"\"";
            XML+=" Order=\""+document.getElementById('lbl'+i).innerHTML.replace(/<b>(.*?)<\/b>/i,"$1")+"\"";
            var IsAct=document.getElementById('chkIsActive'+i).checked==true?1:0
            XML+=" IsActive=\""+IsAct+"\"/#";
          }
      }
      XML+='@/Root#';
      document.getElementById('rightContainer_hddText').value=XML;
}
function setMutilingualForSpecificIds()
{
   att = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_ccbMenu','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
   att.Start('MenuManagement_AddTopMenu.Getkeys',document.getElementById('gvMenu').rows[AddEditIndex].cells[6].innerHTML,Getkeys_Callback); 
   
}
function Getkeys_Callback(response)
{
   att.Stop();
   var v=response.value;
   var lang=v.split(',');
   var rowCount=document.getElementById('rightContainer_ccbAddEdit_gvLanguage').rows.length;
   document.getElementById('rightContainer_ccbAddEdit_chkmultiLingualLink').checked=false;
   document.getElementById('trLanguage').style.display='none';
  
   for(var l=1;l<rowCount;l++)
   {
     document.getElementById('chkLang'+l).checked=false;
     document.getElementById('txtLang'+l).disabled=true;
     document.getElementById('txtLang'+l).value='';
   } 
   if(lang.length>1) 
   {
      
        document.getElementById('rightContainer_ccbAddEdit_chkmultiLingualLink').checked=true;
        ShowLanguageRow(document.getElementById('rightContainer_ccbAddEdit_chkmultiLingualLink'));  
       
   }    
   for(var i=0;i<lang.length;i++)
   {
     for(var j=1;j<rowCount;j++)
     {
       if(lang[i].split('#')[0]==document.getElementById('rightContainer_ccbAddEdit_gvLanguage').rows[j].cells[2].innerHTML)
       {
         document.getElementById('chkLang'+j).checked=true;
         document.getElementById('txtLang'+j).disabled=false;
         document.getElementById('txtLang'+j).value=lang[i].split('#')[1]
       }
     }
   }
   
}
function CreateMultiLingualXML()
{
  var rowCount=document.getElementById('rightContainer_ccbAddEdit_gvLanguage').rows.length;
  var xml='';
  for(var i=1;i<rowCount;i++)
  {
    if(document.getElementById('chkLang'+i).checked==true)
       if(document.getElementById('txtLang'+i).value!="")
       {
         xml+="@Language name=\""+document.getElementById('rightContainer_ccbAddEdit_gvLanguage').rows[i].cells[2].innerHTML+"\"#";
         xml+="@Page name=\"commonlanguagetexts\"#";
         var Edit='';
         if(AddEditIndex!=0)
         Edit='T'+document.getElementById('gvMenu').rows[AddEditIndex].cells[6].innerHTML;
         xml+="@data key=\""+Edit+"\" value=\""+document.getElementById('txtLang'+i).value+"\"#";
         xml+="@/Page#";
         xml+="@/Language#";
       }
  }
  document.getElementById('rightContainer_hddMultilingual').value=xml;
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
    if(checkbox.checked)
    {
       document.getElementById('trLanguage').style.display='';
       document.getElementById('btn_OpenLingualEditorContent').style.display='';
    }   
    else
    {
     document.getElementById('trLanguage').style.display='none';
     document.getElementById('btn_OpenLingualEditorContent').style.display='none';
    }
  
}