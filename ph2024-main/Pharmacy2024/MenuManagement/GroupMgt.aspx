<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" EnableEventValidation="False" ValidateRequest="false" CodeBehind="GroupMgt.aspx.cs" Inherits="MenuManagement_GroupMgt" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_CbAddGroup, #rightContainer_CBEditGroup, #rightContainer_CBDeleteGroup{
            top:20% !important;
            height:450px;
            overflow:auto;
            z-index:2000 !important;
        }

        @media only screen and (max-width: 768px){
            #rightContainer_CbAddGroup, #rightContainer_CBEditGroup, #rightContainer_CBDeleteGroup{
                height:400px;
                width:90% !important;
            }
        }
    </style>
    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/AjaxLoader.js"></script>

    <script type="text/javascript" language="javascript">
    var atk;
         function ShowAddPopUp()
         {
             document.getElementById('<%=TxtGroupName.ClientID%>').value='';
             document.getElementById("<%=TxtGroupDisplayName.ClientID %>").value='';
             document.getElementById("rightContainer_CbAddGroups_rbtIsActive_0").checked=true;
             document.getElementById("rightContainer_CbAddGroups_rbtIsStatic_1").checked=true;
             document.getElementById("rightContainer_CbAddGroups_chkMultilingual").checked=false;
             document.getElementById('trMultilingual').style.display='none'; 
             document.getElementById('btn_OpenLingualEditor').style.display='none';
             clearLanguageGrid();
             document.getElementById('<%=CbAddGroups.ClientID%>').Show('#000000',true);
             return false;
         }
         function DeleteGroup()
         {
          var GroupId= document.getElementById("<%=HdnGroupId.ClientID %>").value;
          atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbGroupDetails_DdlUserType','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
             atk.Start('MenuManagement_GroupMgt.DeleteGroup',document.getElementById("<%=DdlUserType.ClientID %>").value,parseInt(GroupId),DeleteGroup_Callback);
            
         }
         function DeleteGroup_Callback(response)
         {
            GetGroupsUserTypeWise_Callback(response);
            HidePopUp(document.getElementById("<%=CBDeleteGroup.ClientID %>"));
         }
         function ShowDeleteGroup(Value)
         {
          document.getElementById("<%=HdnGroupId.ClientID %>").value=Value;
          atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbGroupDetails_DdlUserType','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
          atk.Start('MenuManagement_GroupMgt.GetSpecificGroupDetails',parseInt(Value),DeleteGroupDetails_Callback);
            
         }
          function DeleteGroupDetails_Callback(response)
         {
            atk.Stop();
            var ds=response.value;
            if(ds.Tables[0].Rows.length>0)
            {
                if(parseInt(ds.Tables[0].Rows[0].AuthenticationMode)!=3)
                {
                    document.getElementById("<%=LblDeleteGroupName.ClientID %>").innerHTML =ds.Tables[0].Rows[0].GroupName;
                    document.getElementById('TrGroupName').style.display='';
                    document.getElementById('TrDeleteButtons').style.display='';
                    document.getElementById('TrPrivateGroup').style.display='none';
                    document.getElementById('TrOkButton').style.display='none'; 
                }
                else if(parseInt(ds.Tables[0].Rows[0].AuthenticationMode)==3)
                {
                  document.getElementById('TrPrivateGroup').style.display='';
                  document.getElementById('TrOkButton').style.display=''; 
                  document.getElementById('TrGroupName').style.display='none';
                  document.getElementById('TrDeleteButtons').style.display='none';
                }
                var popup = document.getElementById("<%=CBDeleteGroup.ClientID %>");
                popup.Show('#000000',true);
            }
         }
         function ShowEditGroup(Value)
         {
          document.getElementById("<%=HdnGroupId.ClientID %>").value=Value;
           var table=document.getElementById("rightContainer_CBEditGroup_GvEditLanguageList");
           var LanguageList='';
            for( var j=1;j<parseInt(table.rows.length);j++)
            {
               LanguageList=LanguageList+ table.rows[j].cells[2].innerHTML+'_';
            }
          atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbGroupDetails_DdlUserType','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
          atk.Start('MenuManagement_GroupMgt.GetSpecificGroupDetailsForUpdate',parseInt(Value),LanguageList,GetSpecificGroupDetailsForUpdate_Callback);
            
         }
         function GetSpecificGroupDetailsForUpdate_Callback(response)
         {
            atk.Stop();
            var ds=response.value;
            //for adding data to multilingual rows
            if(ds.Tables[1].Rows.length>0)
            {
                document.getElementById("rightContainer_CBEditGroup_chkEditMultilingual").checked=true;
                document.getElementById('trEditMultilingual').style.display=''; 
                document.getElementById('Btn_EditOpenLingualEditor').style.display='';
                
                //first clear all the multilingual rows
                var table=document.getElementById("rightContainer_CBEditGroup_GvEditLanguageList");
                for( var j=1;j<parseInt(table.rows.length);j++)
                {
                    document.getElementById("CheckboxEdit_"+table.rows[j].cells[1].innerHTML).checked=false;
                    document.getElementById("TextboxEdit_"+table.rows[j].cells[1].innerHTML).disabled="disabled";                    
                    document.getElementById("TextboxEdit_"+table.rows[j].cells[1].innerHTML).value="";                            
                }  
                for(var i=0;i<ds.Tables[1].Rows.length;i++)
                {
                   // var table=document.getElementById("rightContainer_CBEditGroup_GvEditLanguageList");
                    for( var j=1;j<parseInt(table.rows.length);j++)
                    {
                        if(table.rows[j].cells[2].innerHTML==ds.Tables[1].Rows[i].Language)
                        {
                            document.getElementById("CheckboxEdit_"+table.rows[j].cells[1].innerHTML).checked=true;
                            document.getElementById("TextboxEdit_"+table.rows[j].cells[1].innerHTML).disabled="";                    
                            document.getElementById("TextboxEdit_"+table.rows[j].cells[1].innerHTML).value=ds.Tables[1].Rows[i].LanguageText;
                            
                        }
                        
                    }
                }
            }else
            {
                document.getElementById("rightContainer_CBEditGroup_chkEditMultilingual").checked=false;
                document.getElementById('trEditMultilingual').style.display='none';
                document.getElementById('Btn_EditOpenLingualEditor').style.display='none';
                var table=document.getElementById("rightContainer_CBEditGroup_GvEditLanguageList");
                    for( var j=1;j<parseInt(table.rows.length);j++)
                    {
                        document.getElementById("CheckboxEdit_"+table.rows[j].cells[1].innerHTML).checked=false;
                        document.getElementById("TextboxEdit_"+table.rows[j].cells[1].innerHTML).disabled="disabled";                    
                        document.getElementById("TextboxEdit_"+table.rows[j].cells[1].innerHTML).value="";                            
                    }  
            }
            //for adding general data
            if(ds.Tables[0].Rows.length>0)
            {
                document.getElementById("<%=TxtEditGroupName.ClientID %>").value =ds.Tables[0].Rows[0].GroupName;
                document.getElementById("<%=TxtEditGroupDisplayName.ClientID %>").value=ds.Tables[0].Rows[0].GroupDisplayText;
                document.getElementById("<%=TxtEditGroupOrder.ClientID %>").value =ds.Tables[0].Rows[0].GroupOrder;
                    if (ds.Tables[0].Rows[0].IsActive==true)
                    {
                         document.getElementById("rightContainer_CBEditGroup_rbtEditIsActive_0").checked=true;
                    }
                    else
                    {
                        document.getElementById("rightContainer_CBEditGroup_rbtEditIsActive_1").checked=true;
                    }
                    if (ds.Tables[0].Rows[0].IsStaticGroup==true)
                    {
                         document.getElementById("rightContainer_CBEditGroup_rbtEditIsStatic_0").checked=true;
                    }
                    else
                    {
                        document.getElementById("rightContainer_CBEditGroup_rbtEditIsStatic_1").checked=true;
                    }
                    
                   
                var popup = document.getElementById("<%=CBEditGroup.ClientID %>");
                popup.Show('#000000',true);
            }
            
         }
         function UpdateGroup()
         {
            var isValid=true;
            if(document.getElementById("<%=TxtEditGroupOrder.ClientID %>").value=='')
            {
                alert('Please enter the group order less than the total groups');
                isValid=false;
            }
            else if(parseInt(document.getElementById("<%=TxtEditGroupOrder.ClientID %>").value) > parseInt(document.getElementById("<%=HdnMaxGroupOrder.ClientID %>").value)
            && parseInt(document.getElementById("<%=HdnMaxGroupOrder.ClientID %>").value)!=0)
            {
                alert('Please enter the group order less than the total groups');
                isValid=false;
            }
            if(document.getElementById("<%=TxtEditGroupName.ClientID %>").value=='')
            {
                alert('Please enter the name of group which you are editing');
                isValid=false;
            }
            if(document.getElementById("<%=TxtEditGroupDisplayName.ClientID %>").value==''||document.getElementById("<%=TxtEditGroupDisplayName.ClientID %>").value=='null')
            {
                alert('Please enter the dispaly name of group which you are editing');
                isValid=false;
            }
            
            if(document.getElementById("rightContainer_CBEditGroup_rbtEditIsActive_0").checked==false &&
                document.getElementById("rightContainer_CBEditGroup_rbtEditIsActive_1").checked==false)
            {
                 alert('Please select if the group is active or not');
                isValid= false;
            }
            if(document.getElementById("rightContainer_CBEditGroup_rbtEditIsStatic_0").checked==false &&
                document.getElementById("rightContainer_CBEditGroup_rbtEditIsStatic_1").checked==false)
            {
                 alert('Please select if the group is static or not');
                isValid= false;
            }
             //validate Lingual Text
           
            if(document.getElementById("rightContainer_CBEditGroup_chkEditMultilingual").checked==true)
            {
                var table=document.getElementById("rightContainer_CBEditGroup_GvEditLanguageList");
                for( var i=1;i<parseInt(table.rows.length);i++)
                {
                    if(document.getElementById("CheckboxEdit_"+table.rows[i].cells[1].innerHTML).checked==true)
                    {
                        if(document.getElementById("TextboxEdit_"+table.rows[i].cells[1].innerHTML).value=="")
                        {
                          alert('Please enter the display text for '+table.rows[i].cells[2].innerHTML +' language.');
                          properdata= false; 
                          break; 
                        }
                    }
                }
            }
            if(isValid)
            {
                /*var sel_Index = document.getElementById("<%=DdlUserType.ClientID %>").selectedIndex;
                var selected_UserTypeValue = document.getElementById("<%=DdlUserType.ClientID %>").options[sel_Index].value;
                var GroupName=document.getElementById("<%=TxtEditGroupName.ClientID %>").value;
                var IsActive=document.getElementById("rightContainer_CBEditGroup_rbtEditIsActive_0").checked==true?"1":"0";
                var GroupOrder=document.getElementById("<%=TxtEditGroupOrder.ClientID %>").value;
                var GroupId=document.getElementById("<%=HdnGroupId.ClientID %>").value;
                var UserId=document.getElementById("<%=HdnUserId.ClientID %>").value; 
                var IsStatic=document.getElementById("rightContainer_CBEditGroup_rbtEditIsStatic_0").checked==true?"1":"0";
                var GroupDisplayText=document.getElementById("<%=TxtEditGroupDisplayName.ClientID %>").value;
                
                atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbGroupDetails_DdlUserType','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
                atk.Start('MenuManagement_GroupMgt.UpdateGroup',selected_UserTypeValue,GroupName,IsActive,GroupOrder,GroupId,UserId,IsStatic,GroupDisplayText,UpdateGroup_Callback); 
             */
               createEditLanguageXML(); 
               return isValid;
            }else
            {
                return isValid;
            }
        }
        function createEditLanguageXML()
        {
             var xmlLanguages = '<Languages>';
             if(document.getElementById("rightContainer_CBEditGroup_chkEditMultilingual").checked==true)
             {
                var table=document.getElementById("rightContainer_CBEditGroup_GvEditLanguageList");
                for( var i=1;i<parseInt(table.rows.length);i++)
                {
                    if(document.getElementById("CheckboxEdit_"+table.rows[i].cells[1].innerHTML).checked==true)
                    {
                           xmlLanguages=xmlLanguages+'<Language LanguageId="'+table.rows[i].cells[1].innerHTML+'" LanguageName="'+table.rows[i].cells[2].innerHTML+'" Text="'+document.getElementById("TextboxEdit_"+table.rows[i].cells[1].innerHTML).value+'"></Language>';                        
                    }
                }
              }
              xmlLanguages = xmlLanguages+'</Languages>';                
              document.getElementById("<%=HdnEditXMLLanguage.ClientID %>").value=xmlLanguages;
        }
        function UpdateGroup_Callback(response)
         {                
            atk.Stop();
            GetGroupsUserTypeWise_Callback(response);
            HidePopUp(document.getElementById("<%=CBEditGroup.ClientID %>"));
         }
         function RefreshPage()
         {
            if(document.getElementById("<%=HdnRefreshPage.ClientID %>").value == "Y")
            {
                GetListOfGroups(document.getElementById("<%=DdlUserType.ClientID %>").value);
                document.getElementById("<%=HdnRefreshPage.ClientID %>").value="";
            }
         }
         function GetListOfGroups(Value)
         {
             if(Value!='-- Select --')
             {
                  atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbGroupDetails_DdlUserType','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
                  atk.Start('MenuManagement_GroupMgt.GetGroupsUserTypeWise',Value,GetGroupsUserTypeWise_Callback);  
             }
         }
         function GetGroupsUserTypeWise_Callback(response)
         {

                atk.Stop();
                var ds=response.value;
                var tbl=document.getElementById('GroupGrid');
                document.getElementById("<%=Btn_Add.ClientID %>").style.display='none';
                document.getElementById("<%=Btn_SaveGroups.ClientID %>").style.display='none';
              if(ds.Tables[0].Rows.length>0)
              {
                
                htmlContent="<table id=\"TblGroupList\"  class=\"AppFormTable\" Synthesysfilter=\"text-columns:1\" cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                for(var i=0;i<response.value.Tables[0].Rows.length;i++)
                {
                  if(i==0)
                  htmlContent+="<tr class=\"Header\" ><th scope=\"col\" >Sr.No</th><th scope=\"col\" >Group Name</th><th scope=\"col\" >Group Display Name</th><th scope=\"col\">Order</th><th>IsActive</th><th style=\"display:none\">IsStatic</th><th>Edit</th><th>Delete</th></tr>";
                  htmlContent+="<tr class=\"NormalRow\" valign=\"center\">";
                  htmlContent+="<td align=\"center\" >"+parseInt(i+1)+"</td>";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:100px;display:none\" >"+ds.Tables[0].Rows[i].GroupId+"</td>";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:100px\" >"+ds.Tables[0].Rows[i].GroupName+"</td>";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:100px\" >"+ds.Tables[0].Rows[i].GroupDisplayText+"</td>";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;\"><input id=chkOrder"+parseInt(i+1)+" type=\"checkbox\" onclick=\"Ordering(this,"+parseInt(i+1)+")\" checked/>&nbsp;&nbsp;<span id=\"lbl"+parseInt(i+1)+"\" ><b>"+ds.Tables[0].Rows[i].GroupOrder+"</b></span></td>";
                  var IsActive=ds.Tables[0].Rows[i].IsActive==1?"checked":"";
                  htmlContent+="<td align=\"center\" ><input id=chkIsActive"+parseInt(i+1)+" type=\"checkbox\""+IsActive+"/></td>";
                  var IsStatic=ds.Tables[0].Rows[i].IsStaticGroup==1?"checked":"";
                  htmlContent+="<td align=\"center\" style=\"display:none\"><input id=chkStaticGroup"+parseInt(i+1)+" type=\"checkbox\""+IsStatic+"/></td>";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"ShowEditGroup("+ds.Tables[0].Rows[i].GroupId+")\" /></a></td>";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/delete.gif\" onclick=\"ShowDeleteGroup("+ds.Tables[0].Rows[i].GroupId+")\"/></a></td>";
                                   
                  htmlContent+="</tr>";                  
                }
               document.getElementById("<%=Btn_Add.ClientID %>").style.display='';
               document.getElementById("<%=Btn_SaveGroups.ClientID %>").style.display='';
              }
              else 
              {
                
                htmlContent="<table id=\"TblGroupList\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                htmlContent+="<tr><td><font color=\"red\">No Groups Found !!!</font></td></tr>";
                document.getElementById("<%=Btn_Add.ClientID %>").style.display='';
              }
              tbl.rows[0].cells[0].innerHTML=htmlContent;
              
              if(ds.Tables[1].Rows.length>0)
              {
                document.getElementById("<%=HdnMaxGroupOrder.ClientID %>").value=ds.Tables[1].Rows[0].MaxGroupOrder;
              }
        }
        
       function Ordering(checkBox,index)
        {
          if(checkBox.checked==false)
          { 
                 var OrderHtml=document.getElementById('lbl'+index).innerHTML;
                 var order=OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1");
                 for(var i=1;i<parseInt(document.getElementById('TblGroupList').rows.length);i++)
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
             for(var i=1;i<parseInt(document.getElementById('TblGroupList').rows.length);i++)
             {
                     OrderHtml=document.getElementById('lbl'+i).innerHTML;
                     if(parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"))>maxOrder)
                              maxOrder=parseInt(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1"));
             }
             document.getElementById('lbl'+index).innerHTML="<b>"+(maxOrder+1)+"</b>";
          }
  
        }
        function HidePopUp(ContentBox)
        {
            var popup = ContentBox;
            popup.Hide();
            document.getElementById("<%=HdnRefreshPage.ClientID %>").value="Y";
        }
        function HideDeletePopUp()
        {
            var popup = document.getElementById("<%=CBDeleteGroup.ClientID %>");
            popup.Hide();
            document.getElementById("<%=HdnRefreshPage.ClientID %>").value="Y";
        }
        function CreateXML()
        { 
            var flag=0;
            for(var i=1;i<parseInt(document.getElementById('TblGroupList').rows.length);i++)
             {
                 OrderHtml=document.getElementById('lbl'+i).innerHTML;
                 if(OrderHtml.replace(/<b>(.*?)<\/b>/i,"$1")=='')
                 {
                    alert('Please select order of all the groups');
                    flag=1;
                    return false;
                 }
             }
             if(flag==0)
             {
                 var xmlGroups = '<Groups>';
                 var table =document.getElementById("TblGroupList");
                 for(var i=1;i<table.rows.length;i++)
                 {
                    var chk='chkIsActive'+i;                    
                    var IsActive=document.getElementById(chk).checked?"1":"0";
                    var stc='chkStaticGroup'+i;
                    var IsStatic=document.getElementById(stc).checked?"1":"0";
                    var orderText=document.getElementById('lbl'+i).innerHTML;
                    orderText=orderText.replace(/<b>(.*?)<\/b>/i,"$1");
                    xmlGroups=xmlGroups+'<Group GroupId="'+table.rows[i].cells[1].innerHTML+'" Order="'+orderText+'" IsActive="'+IsActive+'" IsStatic="'+IsStatic+'"></Group>';
                 }
                 xmlGroups =xmlGroups+ '</Groups>';
                 document.getElementById("<%=HdnXML.ClientID %>").value=xmlGroups;
             }
        }
        function SaveData()
        {
            var properdata=true;
            
            
            //validate group name
            if(document.getElementById("<%=TxtGroupName.ClientID %>").value=='')
            {
                alert('Please enter a group name');
                properdata= false;
            }
             if(document.getElementById("<%=TxtGroupDisplayName.ClientID %>").value=='')
            {
                alert('Please enter a group dispaly name');
                properdata= false;
            }
            //validate group active or inactive.
            if(document.getElementById("rightContainer_CbAddGroups_rbtIsActive_0").checked==false &&
                document.getElementById("rightContainer_CbAddGroups_rbtIsActive_1").checked==false)
            {
                 alert('Please select if the group is active or not');
                properdata= false;
            }
            //validate static group or not
            if(document.getElementById("rightContainer_CbAddGroups_rbtIsStatic_0").checked==false &&
                document.getElementById("rightContainer_CbAddGroups_rbtIsStatic_1").checked==false)
            {
                 alert('Please select if the group is static or not');
                properdata= false;
            }
            
            //validate Lingual Text
           
            if(document.getElementById("rightContainer_CbAddGroups_chkMultilingual").checked==true)
            {
                var table=document.getElementById("rightContainer_CbAddGroups_GvLanguageList");
                for( var i=1;i<parseInt(table.rows.length);i++)
                {
                    if(document.getElementById("Checkbox_"+table.rows[i].cells[1].innerHTML).checked==true)
                    {
                        if(document.getElementById("Textbox_"+table.rows[i].cells[1].innerHTML).value=="")
                        {
                          alert('Please enter the display text for '+table.rows[i].cells[2].innerHTML +' language.');
                          properdata= false; 
                          break; 
                        }
                    }
                }
            }
            
            if(properdata)
            {/*
                var sel_Index = document.getElementById("<%=DdlUserType.ClientID %>").selectedIndex;
                var selected_UserTypeValue = document.getElementById("<%=DdlUserType.ClientID %>").options[sel_Index].value;
                var GroupName=document.getElementById("<%=TxtGroupName.ClientID %>").value;
                var IsActive=document.getElementById("rightContainer_CbAddGroups_rbtIsActive_0").checked==true?"1":"0";
                var UserId=document.getElementById("<%=HdnUserId.ClientID %>").value; 
                var IsStatic=document.getElementById("rightContainer_CbAddGroups_rbtIsStatic_0").checked==true?"1":"0";
                var GroupDisplayText=document.getElementById("<%=TxtGroupDisplayName.ClientID %>").value;
                
                //atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbGroupDetails_DdlUserType','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
                //atk.Start('MenuManagement_GroupMgt.AddNewGroup',selected_UserTypeValue,GroupName,IsActive,UserId,IsStatic,GroupDisplayText,AddNewGroup_Callback); 
             */
             createLanguageXML();            
             return properdata;
               
            }else
            {
                return properdata;
            }
        }
        function createLanguageXML()
        {
             var xmlLanguages = '<Languages>';
             if(document.getElementById("rightContainer_CbAddGroups_chkMultilingual").checked==true)
             {
                var table=document.getElementById("rightContainer_CbAddGroups_GvLanguageList");
                for( var i=1;i<parseInt(table.rows.length);i++)
                {
                    if(document.getElementById("Checkbox_"+table.rows[i].cells[1].innerHTML).checked==true)
                    {
                           xmlLanguages=xmlLanguages+'<Language LanguageId="'+table.rows[i].cells[1].innerHTML+'" LanguageName="'+table.rows[i].cells[2].innerHTML+'" Text="'+document.getElementById("Textbox_"+table.rows[i].cells[1].innerHTML).value+'"></Language>';                        
                    }
                }
              }
              xmlLanguages = xmlLanguages+'</Languages>';                
              document.getElementById("<%=HdnXMLLanguage.ClientID %>").value=xmlLanguages;
        }
        function AddNewGroup_Callback(response)
         {                
            atk.Stop();
            GetGroupsUserTypeWise_Callback(response);
            HidePopUp(document.getElementById("<%=CbAddGroups.ClientID %>"));
         }
      
        function ShowMultilingualTable(checkbox)
        {
            if(checkbox.checked==true)
            {
               document.getElementById('trMultilingual').style.display=''; 
               document.getElementById('btn_OpenLingualEditor').style.display='';
            }
            else
            {
               document.getElementById('trMultilingual').style.display='none';
               document.getElementById('btn_OpenLingualEditor').style.display='none'; 
               clearLanguageGrid();
            }
        }
        function clearLanguageGrid()
        {
            var table=document.getElementById("rightContainer_CbAddGroups_GvLanguageList");
                for( var i=1;i<parseInt(table.rows.length);i++)
                {
                    document.getElementById("Checkbox_"+table.rows[i].cells[1].innerHTML).checked=false;
                    document.getElementById("Textbox_"+table.rows[i].cells[1].innerHTML).disabled="disabled";
                    document.getElementById("Textbox_"+table.rows[i].cells[1].innerHTML).value="";
                }
        }
        function ShowEditMultilingualTable(checkbox)
        {
            if(checkbox.checked==true)
            {
               document.getElementById('trEditMultilingual').style.display=''; 
               document.getElementById('Btn_EditOpenLingualEditor').style.display='';
            }
            else
            {
               document.getElementById('trEditMultilingual').style.display='none'; 
               document.getElementById('Btn_EditOpenLingualEditor').style.display='none';
            }
        }
        function EnableTextBox(checkBox)
        {
            var checkBoxId=checkBox.id;
            var SplitId=checkBoxId.split("_");
            if(checkBox.checked==true)
            {
                document.getElementById("Textbox_"+SplitId[1]).disabled="";
            }else
            {
                document.getElementById("Textbox_"+SplitId[1]).disabled="disabled";
                document.getElementById("Textbox_"+SplitId[1]).value="";
            }
        }
        function EnableEditTextBox(checkBox)
        {
            var checkBoxId=checkBox.id;
            var SplitId=checkBoxId.split("_");
            if(checkBox.checked==true)
            {
                document.getElementById("TextboxEdit_"+SplitId[1]).disabled="";
            }else
            {
                document.getElementById("TextboxEdit_"+SplitId[1]).disabled="disabled";
                document.getElementById("TextboxEdit_"+SplitId[1]).value="";
            }
        }
        function OpenLingualEditor()
        {
             window.open('../CMS/LingualEditor.aspx', 'myPopup','height=500,width=600,left=200,top=200,resizable=yes,scrollbars=yes,toolbar=no,status=no');

            return false;
        } 
        Synthesys.FuncLib.AddLoadEvent(RefreshPage);
    </script>

    <asp:HiddenField ID="HdnGroupId" runat="server" />
    <asp:HiddenField ID="HdnShowGroupDetail" runat="server" />
    <asp:HiddenField ID="HdnMaxGroupOrder" runat="server" />
    <asp:HiddenField ID="HdnRefreshPage" runat="server" />
    <asp:HiddenField ID="HdnXML" runat="server" />
    <asp:HiddenField ID="HdnXMLLanguage" runat="server" />
    <asp:HiddenField ID="HdnEditXMLLanguage" runat="server" />
    <asp:HiddenField ID="HdnUserId" runat="server" />
    <ccm:ContentBox runat="server" ID="CbGroupDetails" HeaderText="Add New Group">
        <table class="AppFormTable">
            <tr>
                <td>
                    User Type</td>
                <td>
                    <asp:DropDownList ID="DdlUserType" runat="server" onchange="GetListOfGroups(this.value)">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                       <input id="Btn_Add" type="button" value="Add New Group" class="InputButton" runat="server" onclick="return ShowAddPopUp()" style=" display: none" />
                       <asp:Button ID="Btn_SaveGroups" runat="server" Text="Save Groups" OnClientClick="return CreateXML()" OnClick="Btn_SaveGroups_Click" CssClass="InputButton" Style="display: none" />
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="AppFormTable" id="GroupGrid">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CbAddGroups" HeaderText="Group Details" BoxType="PopupBox"
        Width="75%">
        <table class="AppFormTable">
            <tr>
                <td>
                    Group Name</td>
                <td>
                    <asp:TextBox ID="TxtGroupName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Display Name</td>
                <td>
                    <asp:TextBox ID="TxtGroupDisplayName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Is Active</td>
                <td>
                    <asp:RadioButtonList ID="rbtIsActive" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Is Static Group</td>
                <td>
                    <asp:RadioButtonList ID="rbtIsStatic" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkMultilingual" runat="server" type="checkbox" onclick="ShowMultilingualTable(this)" />&nbsp;&nbsp;<b>Do
                        you want to add Multi-Lingual display text ?</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btn_OpenLingualEditor" value="Open Lingual Editor" onclick="OpenLingualEditor()"
                        class="InputButton" /></td>
            </tr>
            <tr id="trMultilingual" style="display: none">
                <td colspan="2" align="center">
                    <asp:GridView ID="GvLanguageList" runat="server" AutoGenerateColumns="false" OnRowDataBound="GvLanguageList_RowDataBound"
                        CssClass="AppFormTable" Width="95%">
                        <SelectedRowStyle CssClass="SelectedRow" />
                        <EditRowStyle CssClass="EditRow" />
                        <AlternatingRowStyle CssClass="AlternateRow" />
                        <FooterStyle CssClass="Footer" />
                        <HeaderStyle CssClass="Header" />
                        <RowStyle CssClass="NormalRow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSrNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="LanguageId" HeaderText="LanguageId" ItemStyle-Width="10%"
                                ItemStyle-HorizontalAlign="Right" HtmlEncode="false" />
                            <asp:BoundField DataField="LanguageName" HeaderText="Language Name" ItemStyle-Width="40%"
                                ItemStyle-HorizontalAlign="left" HtmlEncode="false" />
                            <asp:TemplateField HeaderText="Add Text">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                <ItemTemplate>
                                    <input id="Checkbox_<%# DataBinder.Eval(Container,"DataItem.LanguageId") %>" type="checkbox"
                                        onchange="EnableTextBox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30%" />
                                <ItemTemplate>
                                    <input id="Textbox_<%# DataBinder.Eval(Container,"DataItem.LanguageId") %>" type="text"
                                        disabled="disabled" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                      <asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click" CssClass="InputButton" OnClientClick="return SaveData()" />
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBEditGroup" HeaderText="Edit Group Details" BoxType="PopupBox"
        Width="75%">
        <table class="AppFormTable">
            <tr>
                <td>
                    Group Name</td>
                <td>
                    <asp:TextBox ID="TxtEditGroupName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Display Name</td>
                <td>
                    <asp:TextBox ID="TxtEditGroupDisplayName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Is Active</td>
                <td>
                    <asp:RadioButtonList ID="rbtEditIsActive" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    Is Static Group</td>
                <td>
                    <asp:RadioButtonList ID="rbtEditIsStatic" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    Group Order</td>
                <td>
                    <asp:TextBox ID="TxtEditGroupOrder" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkEditMultilingual" runat="server" type="checkbox" onclick="ShowEditMultilingualTable(this)" />&nbsp;&nbsp;<b>Do
                        you want to add Multi-Lingual display text ?</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="Btn_EditOpenLingualEditor" value="Open Lingual Editor" onclick="OpenLingualEditor()"
                        class="InputButton" style="display: none" />
                </td>
            </tr>
            <tr id="trEditMultilingual" style="display: none">
                <td colspan="2" align="center">
                    <asp:GridView ID="GvEditLanguageList" runat="server" AutoGenerateColumns="false"
                        OnRowDataBound="GvLanguageList_RowDataBound" CssClass="AppFormTable" Width="95%">
                        <SelectedRowStyle CssClass="SelectedRow" />
                        <EditRowStyle CssClass="EditRow" />
                        <AlternatingRowStyle CssClass="AlternateRow" />
                        <FooterStyle CssClass="Footer" />
                        <HeaderStyle CssClass="Header" />
                        <RowStyle CssClass="NormalRow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="right" Width="10%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSrNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="LanguageId" HeaderText="LanguageId" ItemStyle-Width="10%"
                                ItemStyle-HorizontalAlign="right" HtmlEncode="false" />
                            <asp:BoundField DataField="LanguageName" HeaderText="Language Name" ItemStyle-Width="40%"
                                ItemStyle-HorizontalAlign="Left" HtmlEncode="false" />
                            <asp:TemplateField HeaderText="Add Text">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                <ItemTemplate>
                                    <input id="CheckboxEdit_<%# DataBinder.Eval(Container,"DataItem.LanguageId") %>"
                                        type="checkbox" onchange="EnableEditTextBox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30%" />
                                <ItemTemplate>
                                    <input id="TextboxEdit_<%# DataBinder.Eval(Container,"DataItem.LanguageId") %>" type="text"
                                        disabled="disabled" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Btn_Update" runat="server" Text="Update" OnClick="Btn_Update_Click" CssClass="InputButton" OnClientClick="return UpdateGroup()" />
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBDeleteGroup" HeaderText="Delete Group" BoxType="PopupBox" Width="75%">
        <table class="AppFormTable">
            <tr id="TrGroupName" style="display: none">
                <td colspan="2">
                    Are you sure you want to delete the group:
                    <asp:Label ID="LblDeleteGroupName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                    <br />
                    <b>This will delete the list of links present in this group.Do you want to still continue
                        deleteing this group?</b>
                </td>
            </tr>
            <tr id="TrPrivateGroup" style="display: none">
                <td colspan="2">
                    You can not delete this group as it is a compulsory group.
                </td>
            </tr>
            <tr id="TrDeleteButtons" style="display: none">
                <td align="center" colspan="2">
                    <asp:Button ID="Btn_Delete" runat="server" Text="Delete" OnClick="Btn_Delete_Click" CssClass="InputButton" />
                    <input id="Btn_Cancel" type="button" value="Cancel" class="InputButton" onclick="HideDeletePopUp()" />
                </td>
            </tr>
            <tr id="TrOkButton" style="display: none">
                <td align="center" colspan="2">
                    <input id="ButtonOk" type="button" value="Ok" class="InputButton" onclick="HideDeletePopUp()" /></td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox ID="cbLingualEditor" runat="server" HeaderText="Langauge Editor "
        BoxType="PopupBox" Width="75%" Height="500px" HorizontalAlign="Center">
        <iframe id="iFrameLingualEditor" frameborder="0" src="../SynthesysModules_Files/Resources/Wait.html"
            style="width: 98%; height: 98%"></iframe>
    </ccm:ContentBox>
    <script type="text/javascript">
        $(function () {
            if (typeof AjaxPro != 'undefined' && AjaxPro && AjaxPro.Request && AjaxPro.Request.prototype) {
                AjaxPro.Request.prototype.doStateChange = function () {
                    this.onStateChanged(this.xmlHttp.readyState, this);
                    if (this.xmlHttp.readyState != 4 || !this.isRunning) {
                        return;
                    }
                    this.duration = new Date().getTime() - this.__start;
                    if (this.timeoutTimer != null) {
                        clearTimeout(this.timeoutTimer);
                    }
                    var res = this.getEmptyRes();
                    if (this.xmlHttp.status == 200 && (this.xmlHttp.statusText == "OK" || !this.xmlHttp.statusText)) {
                        res = this.createResponse(res);
                    } else {
                        res = this.createResponse(res, true);
                        res.error = { Message: this.xmlHttp.statusText, Type: "ConnectFailure", Status: this.xmlHttp.status };
                    }
                    this.endRequest(res);
                };
            }
        });
    </script>
</asp:Content>
