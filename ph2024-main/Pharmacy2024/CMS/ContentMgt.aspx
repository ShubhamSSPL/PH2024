<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="ContentMgt.aspx.cs" Inherits="ContentManagement_ContentMgt" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cbx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cbx:ContentBox ID="cbxContentManagement" runat="server" HeaderText="Content Management">
        <asp:TreeView ID="tvContentManagement" runat="server" ShowLines="true" ExpandDepth="0">
            <RootNodeStyle ImageUrl="~/SynthesysModules_Files/Images/User-icon.png" />
        </asp:TreeView>
    </cbx:ContentBox>
</asp:Content>
