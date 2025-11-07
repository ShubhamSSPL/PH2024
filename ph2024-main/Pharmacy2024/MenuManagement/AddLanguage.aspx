<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="AddLanguage.aspx.cs" Inherits="Synthesys.MenuManagement.MenuManagement.AddLanguage" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
     <style>
        #rightContainer_CBAddLanguage, #rightContainer_CBEditLanguage{
            top:20% !important;
            height:500px;
            overflow:auto;
            z-index:2000 !important;

        }
        @media only screen and (max-width: 768px){
            #rightContainer_CBAddLanguage, #rightContainer_CBEditLanguage{
                height:400px;
                width:90% !important;
            }
        }
    </style>
    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/AjaxLoader.js"></script>

    <script type="text/javascript">
     function CheckAddData()
     {
            var properdata=true;
            //validate langauge name
            if(document.getElementById("<%=TxtLanguageName.ClientID %>").value=='')
            {
                alert('Please enter a language name');
                properdata= false;
            }
             //validate langauge display name
            if(document.getElementById('<%=TxtLanguageDispText.ClientID%>').value=='')
            {
                alert('Please enter a language display text');
                properdata= false;
            }
             
            //validate langauge active or inactive.
            if(document.getElementById("rightContainer_CBAddLanguage_rbtIsActive_0").checked==false &&
                document.getElementById("rightContainer_CBAddLanguage_rbtIsActive_1").checked==false)
            {
                 alert('Please select if the langauge is active or not');
                properdata= false;
            }
            return properdata;
    }
    function CheckEditedData()
    {
        var properdata=true;
            //validate langauge name
            if(document.getElementById("<%=TxtEditLanguageName.ClientID %>").value=='')
            {
                alert('Please enter a langauge name');
                properdata= false;
            }
            //validate langauge display text
             if(document.getElementById("<%=TxtEditLanguageDispText.ClientID %>").value=='')
             {
                alert('Please enter a langauge display text');
                properdata= false;
             }
            //validate langauage active or inactive.
            if(document.getElementById("rightContainer_CBEditLanguage_rbtEditIsActive_0").checked==false &&
                document.getElementById("rightContainer_CBEditLanguage_rbtEditIsActive_1").checked==false)
            {
                 alert('Please select if the language is active or not');
                properdata= false;
            }
            return properdata;
    }
    function ShowAddPopUp()
    {
        document.getElementById('<%=TxtLanguageName.ClientID%>').value='';
         document.getElementById('<%=TxtLanguageDispText.ClientID%>').value='';
         //document.getElementById("ctl00_rightContainer_CBAddLanguage_rbtIsActive_0").checked=true;
         document.getElementById('<%=CBAddLanguage.ClientID%>').Show('#000000',true);
         return false;
     }
     function ShowEditLanguage()
     {
        if(document.getElementById("<%=HdnShowEditBox.ClientID %>").value == "Y")
        {
            alert("Edit Languge Details");
            document.getElementById('<%=CBEditLanguage.ClientID%>').Show('#000000',true);  
            document.getElementById("<%=HdnShowEditBox.ClientID %>").value = "";          
            return false;             
        }
     }
    
     Synthesys.FuncLib.AddLoadEvent(ShowEditLanguage);
     //SSPL.FuncLib.AddLoadEvent(ShowDeleteModule);
    </script>

    <asp:HiddenField ID="HdnLanguageId" runat="server" />
    <asp:HiddenField ID="HdnShowEditBox" runat="server" />
    <asp:HiddenField ID="HdnShowDeleteBox" runat="server" />
    <ccm:ContentBox runat="server" ID="CbLanguageDetails" HeaderText="Language Details">
        <table class="AppFormTable">
            <tr>
           <td align="center" colspan="2">
            <input id="Btn_Add" type="button" value="Add New Language" class="InputButton" runat="server" onclick="return ShowAddPopUp()" />
            <asp:Button ID="Btn_SaveLanguages" runat="server" Text="Save Language" OnClick="Btn_SaveLanguages_Click" CssClass="InputButton" Style="display: none" />
            </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="LblNoLanguage" runat="server" Text="No Language Exists!!!" Visible="false"></asp:Label>
                    <asp:GridView ID="GvLangaugeList" runat="server" AutoGenerateColumns="false" OnRowDataBound="GvLangaugeList_RowDataBound"
                        CssClass="AppFormTable" Width="95%">
                        <SelectedRowStyle CssClass="SelectedRow" />
                        <EditRowStyle CssClass="EditRow" />
                        <AlternatingRowStyle CssClass="AlternateRow" />
                        <FooterStyle CssClass="Footer" />
                        <HeaderStyle CssClass="Header" />
                        <RowStyle CssClass="NormalRow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSrNo" runat="server" Text="<%# (Container.DataItemIndex) + 1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="LanguageId" HeaderText="LanguageId" ItemStyle-Width="10%"
                                ItemStyle-HorizontalAlign="Right" HtmlEncode="false" />
                            <asp:BoundField DataField="LanguageName" HeaderText="Langauge Name" ItemStyle-Width="30%"
                                ItemStyle-HorizontalAlign="Left" HtmlEncode="false" />
                            <asp:BoundField DataField="LanguageDisplayText" HeaderText="Language Display Text" ItemStyle-Width="30%"
                                ItemStyle-HorizontalAlign="Left" HtmlEncode="false" />
                            <asp:TemplateField HeaderText="Is Active">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox" runat="server" value='<%# DataBinder.Eval(Container,"DataItem.LanguageId") %>'
                                        Checked='<%# DataBinder.Eval(Container,"DataItem.IsActive")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="EditButton" CommandName="EditButton" ImageUrl="~/SynthesysModules_Files/Images/edit.gif"
                                        CommandArgument='<%# DataBinder.Eval(Container,"DataItem.LanguageId") %>' OnCommand="EditButton_Command" />
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBAddLanguage" HeaderText="Add Language Details"
        BoxType="PopupBox" Width="75%">
        <table class="AppFormTable">
            <tr>
                <td align="right">
                    Language Name</td>
                <td>
                    <asp:TextBox ID="TxtLanguageName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    Language Display Text</td>
                <td>
                    <asp:TextBox ID="TxtLanguageDispText" runat="server"></asp:TextBox></td>
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
    <ccm:ContentBox runat="server" ID="CBEditLanguage" HeaderText="Edit Language Details"
        BoxType="PopupBox" Width="75%">
        <table class="AppFormTable">
            <tr>
                <td align="right">
                    Language Name</td>
                <td>
                    <asp:TextBox ID="TxtEditLanguageName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    Language Display Text</td>
                <td>
                    <asp:TextBox ID="TxtEditLanguageDispText" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    Is Active</td>
                <td>
                    <asp:RadioButtonList ID="rbtEditIsActive" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
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
        
    </ccm:ContentBox>
</asp:Content>
