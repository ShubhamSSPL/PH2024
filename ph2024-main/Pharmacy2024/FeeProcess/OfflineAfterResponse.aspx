<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="OfflineAfterResponse.aspx.cs" Inherits="Pharmacy2024.FeeProcess.OfflineAfterResponse" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
<ccm:ContentBox ID="cntExpired" runat="server" HeaderText="::Challan Generation Details::">
<br />
<br /><br />
<br />

<div align="center">
    <asp:Label runat="server" ID="lblPaymentStatus" Font-Bold="True"></asp:Label>
</div>
<br />



<br /><br />
</ccm:ContentBox>
</asp:Content>
