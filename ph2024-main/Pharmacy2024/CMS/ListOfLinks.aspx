<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="ListOfLinks.aspx.cs" Inherits="CMS_ListOfLinks" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <ccm:ContentBox runat="server" ID="CBLinks" Width="700px">
        <table id="tblLinks" runat="server" border="0" cellpadding="0" cellspacing="2">
        </table>
    </ccm:ContentBox>
</asp:Content>
