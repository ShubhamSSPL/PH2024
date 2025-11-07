<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="UserTypeMgt.aspx.cs" Inherits="MenuManagement_UserTypeMgt" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/AjaxLoader.js"></script>

    <script type="text/javascript">
    var atk;
    
    function RefreshPage()
    {
        atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbAddUserType_TxtUserTypeName','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
        atk.Start('MenuManagement_UserTypeMgt.GetUserType',GetUserType_Callback);        
    }
     function GetUserType_Callback(response)
     {

            atk.Stop();
            var ds=response.value;
            var tbl=document.getElementById('UserTypeGrid');
          if(ds.Tables[0].Rows.length>0)
          {
            
            htmlContent="<table id=\"TblUserTypeList\"  class=\"AppFormTable\" Synthesysfilter=\"text-columns:1\" cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
            for(var i=0;i<response.value.Tables[0].Rows.length;i++)
            {
              if(i==0)
              {
                htmlContent+="<tr class=\"Header\" ><th scope=\"col\">Sr.No</th><th scope=\"col\" >User Type Name</th><th>Edit</th><th>Delete</th></tr>";
                  htmlContent+="<tr class=\"NormalRow\" valign=\"center\">";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:50px\">"+parseInt(i+1)+"</td>";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:250px\" >"+ds.Tables[0].Rows[i].UserTypeName+"</td>";  
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:50px\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"ShowEditUserType('"+ds.Tables[0].Rows[i].UserTypeID+"')\" /></a></td>";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:50px\"><a ><img src=\"../SynthesysModules_Files/Images/delete.gif\" onclick=\"ShowDeleteUserType('"+ds.Tables[0].Rows[i].UserTypeID+"')\"/></a></td>";                                       
                  htmlContent+="</tr>";
              }
              else
              {
                  htmlContent+="<tr class=\"NormalRow\" valign=\"center\">";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:50px\">"+parseInt(i+1)+"</td>";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:250px\" >"+ds.Tables[0].Rows[i].UserTypeName+"</td>";  
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:50px\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"ShowEditUserType('"+ds.Tables[0].Rows[i].UserTypeID+"')\" /></a></td>";
                  htmlContent+="<td align=\"center\" style=\"background-color:transparent;width:50px\"><a ><img src=\"../SynthesysModules_Files/Images/delete.gif\" onclick=\"ShowDeleteUserType('"+ds.Tables[0].Rows[i].UserTypeID+"')\"/></a></td>";                                       
                  htmlContent+="</tr>";
              }
            }
          }
          else 
          {
            
            htmlContent="<table id=\"TblUserTypeList\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
            htmlContent+="<tr><td><font color=\"red\">No user type Found !!!</font></td></tr>";
          }
          tbl.rows[0].cells[0].innerHTML=htmlContent;
    }
    
    function ShowEditUserType(UserTypeId)
    {
        document.getElementById("<%=HdnUserTypeId.ClientID %>").value=UserTypeId;
        atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbAddUserType_TxtUserTypeName','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
        atk.Start('MenuManagement_UserTypeMgt.GetSpecificUserType',UserTypeId,GetSpecificUserType_Callback);  
    }
    
    function GetSpecificUserType_Callback(response)
    {
        atk.Stop();
        var ds=response.value;        
      if(ds.Tables[0].Rows.length>0)
      {
        document.getElementById("<%=txtEditUserTypeName.ClientID %>").value=ds.Tables[0].Rows[i].UserTypeName;
        var popup = document.getElementById("<%=CBEditUserType.ClientID %>");
        popup.Show('#000000',true);
      }
    }
    function CheckProperData()
    {
        if(document.getElementById("<%=TxtUserTypeName.ClientID %>").value=='')
        {
            alert('Please enter usertype name');
            return false;
        }else
        {
            return true;
        }
    }
    function UpdateUserData()
    {
        if(document.getElementById("<%=txtEditUserTypeName.ClientID %>").value=='')
        {
            alert('Please enter usertype name');
            return false;
        }else
        {
           var UserTypeId=document.getElementById("<%=HdnUserTypeId.ClientID %>").value;
           var UserTypeName=document.getElementById("<%=txtEditUserTypeName.ClientID %>").value;
           atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbAddUserType_TxtUserTypeName','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
           atk.Start('MenuManagement_UserTypeMgt.UpdateUserType',UserTypeId,UserTypeName,UpdateUserType_Callback);   
        }
    }
     function UpdateUserType_Callback(response)
     {
        GetUserType_Callback(response);
        HideUpdatePopUp();        
     }
     function HideUpdatePopUp()
     {
        var popup = document.getElementById("<%=CBEditUserType.ClientID %>");
        popup.Hide();
     }
    function ShowDeleteUserType(UserTypeId)
    {
        document.getElementById("<%=HdnUserTypeId.ClientID %>").value=UserTypeId;
        atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbAddUserType_TxtUserTypeName','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
        atk.Start('MenuManagement_UserTypeMgt.GetSpecificUserType',UserTypeId,GetSpecificUserTypeForDelete_Callback);  
    }
    
    function GetSpecificUserTypeForDelete_Callback(response)
    {
        atk.Stop();
        var ds=response.value;        
      if(ds.Tables[0].Rows.length>0)
      {
        document.getElementById("<%=LblDeleteUserTypeName.ClientID %>").innerHTML =ds.Tables[0].Rows[0].UserTypeName;
        var popup = document.getElementById("<%=CBDeleteUserType.ClientID %>");
        popup.Show('#000000',true);
      }
    }
     function HidePopUp()
     {
        var popup = document.getElementById("<%=CBDeleteUserType.ClientID %>");
        popup.Hide();
     }
     function DeleteUserType()
     {
        var UserTypeId=document.getElementById("<%=HdnUserTypeId.ClientID %>").value;
        atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'rightContainer_CbAddUserType_TxtUserTypeName','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
        atk.Start('MenuManagement_UserTypeMgt.DeleteUserType',UserTypeId,DeleteUserType_Callback);  
     }
     function DeleteUserType_Callback(response)
     {
        GetUserType_Callback(response);
        HidePopUp();        
     }
        Synthesys.FuncLib.AddLoadEvent(RefreshPage);
    
    </script>

    <asp:HiddenField ID="HdnUserTypeId" runat="server" />
    <ccm:ContentBox runat="server" ID="CbAddUserType" HeaderText="Add new User Type">
        <table class="AppFormTable">
            <tr>
                <td align="right">
                    User Type Name</td>
                <td>
                    <asp:TextBox ID="TxtUserTypeName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Btn_Add" runat="server" Text="Add" CssClass="InputButton" Height="20px"
                        Width="50px" OnClick="Btn_Add_Click" OnClientClick="return CheckProperData()" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="AppFormTable" id="UserTypeGrid">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBEditUserType" HeaderText="Edit User Type" BoxType="PopupBox"
    Width="75%">
        <table class="AppFormTable">
            <tr>
                <td align="right">
                    User Type Name</td>
                <td>
                    <asp:TextBox ID="txtEditUserTypeName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input id="Btn_Update" type="button" value="Update" class="InputButton" onclick="return UpdateUserData()"
                        style="height: 20px; width: 70px" />
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBDeleteUserType" HeaderText="Delete User Type"
        BoxType="PopupBox" Width="75%">
        <table class="AppFormTable">
            <tr>
                <td colspan="2">
                    Are you sure you want to delete the UserType:
                    <asp:Label ID="LblDeleteUserTypeName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <input id="Btn_Delete" type="button" value="Delete" class="InputButton" onclick="DeleteUserType()"
                        style="height: 20px; width: 50px" />
                    <input id="Btn_Cancel" type="button" value="Cancel" class="InputButton" onclick="HidePopUp()"
                        style="height: 20px; width: 50px" />
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
</asp:Content>