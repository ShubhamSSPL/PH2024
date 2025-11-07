<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="ListOfContents.aspx.cs" Inherits="CMS_ListOfContents" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
     <style>
        #rightContainer_cbAddNewContent, #rightContainer_cbManageFiles, #rightContainer_cbLingualEditor,#rightContainer_CBDeleteContent{
            top:20% !important;            
            height:500px;
            overflow:auto;
            z-index:2000 !important;
            width:70%;
        }
         @media only screen and (max-width: 768px){
            #rightContainer_cbAddNewContent, #rightContainer_cbManageFiles, #rightContainer_cbLingualEditor,#rightContainer_CBDeleteContent{
                width:90% !important;
             }
         }
    </style>
    <script language="Javascript" type="text/javascript">
        function ShowAddContentPopup() {
            document.getElementById("<%=TxtContentName.ClientID %>").value = "";
             document.getElementById('<%=cbAddNewContent.ClientID%>').Show('#000000', true);
            return false;
        }
        function HidePopUp() {
            var popup = document.getElementById("<%=cbAddNewContent.ClientID %>");
            popup.Hide();
        }
        function VerifyData() {
            if (document.getElementById("<%=TxtContentName.ClientID %>").value == "") {
                alert('Please Enter a Content Name');
                return false;
            }
            else {
                return true;
            }

        }
        function ShowPopUp() {
            if (document.getElementById('<%=HdnShowPopUp.ClientID%>').value == "Y") {
                 document.getElementById('<%=CBDeleteContent.ClientID%>').Show('#000000', true);
             }
             document.getElementById('<%=HdnShowPopUp.ClientID%>').value = "";
            return false;
        }
        function HideDeleteMenuPopUp() {
            var popup = document.getElementById("<%=CBDeleteContent.ClientID %>");
            popup.Hide();

        }
        Synthesys.FuncLib.AddLoadEvent(ShowPopUp);
    </script>

    <asp:HiddenField ID="HdnContentId" runat="server" />
    <asp:HiddenField ID="HdnShowPopUp" runat="server" />
    <ccm:ContentBox ID="cbContentList" runat="server" HeaderText="Content List">
        <table class="AppFormTable">
            <tr>
                <td align="center">
                    <input id="Btn_AddNewMenu" type="button" value="Add New Content" class="InputButton" runat="server" onclick="return ShowAddContentPopup()" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="LblNoContent" runat="server" Text="No Content Exists!!!" Visible="false"></asp:Label>
                    <asp:GridView ID="GvContentList" runat="server" AutoGenerateColumns="false" CssClass="AppFormTable"
                        Width="95%">
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
                            <asp:BoundField DataField="ContentName" HeaderText="Content Name" ItemStyle-Width="60%"
                                ItemStyle-HorizontalAlign="Left" HtmlEncode="false" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Content Modified Date" ItemStyle-Width="60%"
                                ItemStyle-HorizontalAlign="Center" HtmlEncode="false" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="EditButton" CommandName="EditButton" ImageUrl="~/SynthesysModules_Files/Images/edit.gif"
                                        CommandArgument='<%# DataBinder.Eval(Container,"DataItem.ContentId") %>' OnCommand="EditButton_Command" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="DeleteButton" CommandName="DeleteButton" ImageUrl="~/SynthesysModules_Files/Images/delete.gif"
                                        CommandArgument='<%# DataBinder.Eval(Container,"DataItem.ContentId") %>' OnCommand="DeleteButton_Command" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox ID="cbAddNewContent" runat="server" HeaderText="New Content" BoxType="PopupBox"
        Width="75%">
        <table class="AppFormTable">
            <tr>
                <td align="right">
                    <asp:Label ID="LblContentName" runat="server" Text="Content Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtContentName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Btn_Save" runat="server" Text="Save & Proceed to Editor>>" class="InputButton" OnClientClick="return VerifyData()" OnClick="Btn_Save_click" />
                    <input id="Btn_Cancel" type="button" value="Cancel" class="InputButton" onclick="HidePopUp()" />
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBDeleteContent" HeaderText="Delete Content" BoxType="PopupBox"
        Width="75%">
        <table class="AppFormTable">
            <tr>
                <td colspan="2">Are you sure you want to delete the Content?
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Btn_Delete" runat="server" Text="Delete" Class="InputButton" OnClick="Btn_Delete_Click" />
                    <input id="Btn_Can" type="button" value="Cancel" class="InputButton" onclick="HideDeleteMenuPopUp()" />
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
</asp:Content>
