<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="MapModuleUserType.aspx.cs" Inherits="Synthesys.MenuManagement.MenuManagement.MapModuleUserType" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_CBAddModule, #rightContainer_CBEditModule, #rightContainer_CBDeleteModule{
            top:20% !important;            
            height:500px;
            overflow:auto;
            z-index:2000 !important;
            width:70%;
        }
         @media only screen and (max-width: 768px){
             #rightContainer_CBAddModule, #rightContainer_CBEditModule, #rightContainer_CBDeleteModule{
                height:400px;
                width:90% !important;
             }
         }
    </style>
    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/AjaxLoader.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/FilterTable.js"></script>

    <script type="text/javascript">
     function CheckAddData()
     {
            var properdata=true;
            //validate group name
            if(document.getElementById("<%=TxtModuleName.ClientID %>").value=='')
            {
                alert('Please enter a module name');
                properdata= false;
            }
             
            //validate group active or inactive.
            if(document.getElementById("ctl00_rightContainer_CBAddModule_rbtIsActive_0").checked==false &&
                document.getElementById("ctl00_rightContainer_CBAddModule_rbtIsActive_1").checked==false)
            {
                 alert('Please select if the module is active or not');
                properdata= false;
            }

//             if(selected_value=='-- Select --')
//             {
//                alert('Please select the user type');
//                properdata= false;
//             }
            var checkBoxSelected= CheckUserTypeSelection();
            if(!checkBoxSelected)
            {
                alert('Please select at least one user type');
                properdata= false;
            }
            return properdata;
    }
    function CheckUserTypeSelection()
    {
         var isChecked=false;
         var parentTable = document.getElementById("<%=ChkAddUserType.ClientID%>"); 
         for(var i=0;i<parentTable.rows.length;i++)
         {
            var chk='ctl00_rightContainer_CBAddModule_ChkAddUserType_'+i;
            if(document.getElementById(chk).checked)
            {
                isChecked=true;
                break;
            }
         }
         return isChecked;
    }
    function CheckEditedData()
    {
        var properdata=true;
            //validate group name
            if(document.getElementById("<%=TxtEditModuleName.ClientID %>").value=='')
            {
                alert('Please enter a module name');
                properdata= false;
            }
             
            //validate group active or inactive.
            if(document.getElementById("ctl00_rightContainer_CBEditModule_rbtEditIsActive_0").checked==false &&
                document.getElementById("ctl00_rightContainer_CBEditModule_rbtEditIsActive_1").checked==false)
            {
                 alert('Please select if the module is active or not');
                properdata= false;
            }
        var sel_Index = document.getElementById("<%=ddlEditUserType.ClientID %>").selectedIndex;
        var selected_value = document.getElementById("<%=ddlEditUserType.ClientID %>").options[sel_Index].value;
         if(selected_value=='-- Select --')
         {
            alert('Please select the user type');
            properdata= false;
         }
            return properdata;
    }
    function ShowAddPopUp()
     {
         document.getElementById('<%=TxtModuleName.ClientID%>').value='';
         //document.getElementById("ctl00_rightContainer_CBAddModule_rbtIsActive_0").checked=true;
         
         document.getElementById('<%=CBAddModule.ClientID%>').Show('#000000',true);
         
         var parentTable = document.getElementById("<%=ChkAddUserType.ClientID%>"); 
         for(var i=0;i<parentTable.rows.length;i++)
         {
            var chk='ctl00_rightContainer_CBAddModule_ChkAddUserType_'+i;
            document.getElementById(chk).checked=false;            
         }
         return false;
     }
     function ShowEditModule()
     {
        if(document.getElementById("<%=HdnShowEditBox.ClientID %>").value == "Y")
        {
            document.getElementById('<%=CBEditModule.ClientID%>').Show('#000000',true);  
            document.getElementById("<%=HdnShowEditBox.ClientID %>").value = "";          
            return false;             
        }
     }
      function ShowDeleteModule()
     {
        if(document.getElementById("<%=HdnShowDeleteBox.ClientID %>").value == "Y")
        {
            document.getElementById('<%=CBDeleteModule.ClientID%>').Show('#000000',true);  
            document.getElementById("<%=HdnShowDeleteBox.ClientID %>").value = "";          
            return false;             
        }
     }
     function HideDeletePopUp()
     {
        var popup = document.getElementById("<%=CBDeleteModule.ClientID %>");
        popup.Hide();        
     }
     Synthesys.FuncLib.AddLoadEvent(ShowEditModule);
     Synthesys.FuncLib.AddLoadEvent(ShowDeleteModule);
     
     var color = 'White'; 

        function changeColor(obj) 
        { 
            var rowObject = getParentRow(obj); 
            var parentTable = 
              document.getElementById("<%=ChkAddUserType.ClientID%>"); 

            if(color == '') 
            {
                color = getRowColor(); 
            } 

            if(obj.checked) 
            {
                rowObject.style.backgroundColor = '#A3B1D8'; 
            }
            else 
            {
                rowObject.style.backgroundColor = color; 
                color = 'White'; 
            }

            // private method
            function getRowColor() 
            {
                if(rowObject.style.backgroundColor == 'White')
                    return parentTable.style.backgroundColor; 
                else return rowObject.style.backgroundColor; 
            }
        }
        function getParentRow(obj) 
        { 
            do 
            {
                obj = obj.parentElement; 
            }
            while(obj.tagName != "TR") 
            return obj; 
        }
        

    </script>

    <style type="text/css">
        .scroll_checkboxes
        {
            height: 120px;
            width: 200px;
            padding: 5px;
            overflow: auto;
            border: 1px solid #ccc;
        }

        .FormText
        {
            FONT-SIZE: 11px;
            FONT-FAMILY: tahoma,sans-serif
        }
    </style>
    <asp:HiddenField ID="HdnModuleId" runat="server" />
    <asp:HiddenField ID="HdnShowEditBox" runat="server" />
    <asp:HiddenField ID="HdnShowDeleteBox" runat="server" />
    <ccm:ContentBox runat="server" ID="CbModuleDetails" HeaderText="Module Details">
        <table class="AppFormTable ">
            <tr>
                <td align="center" colspan="2">
                    <input id="Btn_Add" type="button" value="Add New Module" class="InputButton" runat="server" onclick="return ShowAddPopUp()" />
                    <asp:Button ID="Btn_SaveModules" runat="server" Text="Save Modules" OnClick="Btn_SaveModules_Click" CssClass="InputButton" Style="display: none" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="LblNoModule" runat="server" Text="No Module Exists!!!" Visible="false"></asp:Label>
                    <asp:GridView ID="GvModuleList" runat="server" AutoGenerateColumns="false" OnRowDataBound="GvModuleList_RowDataBound"
                        CssClass="AppFormTable " Synthesysfilter="text-columns:3;combo-columns:4">
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
                            <asp:BoundField DataField="UserTypeId" HeaderText="UserTypeId" ItemStyle-Width="5%"
                                ItemStyle-HorizontalAlign="Right" HtmlEncode="false" />
                            <asp:BoundField DataField="ModuleUser" HeaderText="ModuleUser" ItemStyle-Width="5%"
                                ItemStyle-HorizontalAlign="Left" HtmlEncode="false" />
                            <asp:BoundField DataField="ModuleName" HeaderText="Module Name" ItemStyle-Width="60%"
                                ItemStyle-HorizontalAlign="Left" HtmlEncode="false" />
                            <asp:BoundField DataField="UserTypeName" HeaderText="User Type Name" ItemStyle-Width="60%"
                                ItemStyle-HorizontalAlign="Left" HtmlEncode="false" />
                            <asp:TemplateField HeaderText="Is Active">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox" runat="server" value='<%# DataBinder.Eval(Container,"DataItem.ModuleUser") %>'
                                        Checked='<%# DataBinder.Eval(Container,"DataItem.IsActive") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="EditButton" CommandName="EditButton" ImageUrl="~/SynthesysModules_Files/Images/edit.gif"
                                        CommandArgument='<%# DataBinder.Eval(Container,"DataItem.ModuleUser") %>' OnCommand="EditButton_Command" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="DeleteButton" CommandName="DeleteButton" ImageUrl="~/SynthesysModules_Files/Images/delete.gif"
                                        CommandArgument='<%# DataBinder.Eval(Container,"DataItem.ModuleUser") %>' OnCommand="DeleteButton_Command" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBAddModule" HeaderText="Add Module Details" BoxType="PopupBox">
        <table class="AppFormTable">
            <tr>
                <td align="right">
                    Module Name</td>
                <td>
                    <asp:TextBox ID="TxtModuleName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    User&nbsp; Type</td>
                <td>
                    <div class="scroll_checkboxes">
                        <asp:CheckBoxList ID="ChkAddUserType" runat="server" Height="40px" RepeatColumns="1"
                            RepeatDirection="Vertical" BorderWidth="1px" CssClass="FormText">
                        </asp:CheckBoxList>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Is Active</td>
                <td>
                    <asp:RadioButtonList ID="rbtIsActive" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click" CssClass="InputButton" OnClientClick="return CheckAddData()" />
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBEditModule" HeaderText="Edit Module Details"
        BoxType="PopupBox">
        <table class="AppFormTable">
            <tr>
                <td align="right">
                    Module Name</td>
                <td>
                    <asp:TextBox ID="TxtEditModuleName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    User&nbsp; Type</td>
                <td>
                    <asp:DropDownList ID="ddlEditUserType" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    Is Active</td>
                <td>
                    <asp:RadioButtonList ID="rbtEditIsActive" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Btn_Update" runat="server" Text="Save" OnClick="Btn_Update_Click" CssClass="InputButton" OnClientClick="return CheckEditedData()" />
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBDeleteModule" HeaderText="Delete Module" BoxType="PopupBox">
        <table class="AppFormTable">
            <tr id="TrModuleName">
                <td colspan="2">
                    Are you sure you want to delete the module:
                    <asp:Label ID="LblDeleteModuleName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="TrDeleteButtons">
                <td align="center" colspan="2">
                    <asp:Button ID="Btn_Delete" runat="server" Text="Delete" OnClick="Btn_Delete_Click" CssClass="InputButton" />
                    <input id="Btn_Cancel" type="button" value="Cancel" class="InputButton" onclick="HideDeletePopUp()" />
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
</asp:Content>