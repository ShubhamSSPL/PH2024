<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="ImportCandidateSentSMS.aspx.cs" Inherits="Pharmacy2024.StaticPages.ImportCandidateSentSMS" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
<div style="padding-top:50px; padding-left:20px; font-size:20px">

    <asp:FileUpload ID="FileUpload1" runat="server" />  
        <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click"/>  
        <br />  
        <asp:Label ID="Label1" runat="server" ForeColor="Blue" />  
        <br />  
        <asp:Label ID="Label2" runat="server" ForeColor="Green" />  
        <br />  
        <asp:Label ID="lblError" runat="server" ForeColor="Red" /> 
</div>
</asp:Content>
