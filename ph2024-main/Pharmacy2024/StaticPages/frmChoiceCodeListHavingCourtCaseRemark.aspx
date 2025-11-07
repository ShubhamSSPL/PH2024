<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmChoiceCodeListHavingCourtCaseRemark.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmChoiceCodeListHavingCourtCaseRemark" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" HeaderText = "Institute Wise Course List having Remark" runat="server">
        <asp:PlaceHolder ID="plcTable" runat="server"></asp:PlaceHolder>
    </cc1:ContentBox>
</asp:Content>
