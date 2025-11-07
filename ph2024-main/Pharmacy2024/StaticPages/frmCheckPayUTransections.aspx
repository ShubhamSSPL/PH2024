<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmCheckPayUTransections.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCheckPayUTransections" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">  
</br>
</br>
<asp:Button ID="btnRefreshGrid" runat="server" onclick="btnRefreshGrid_Click" />
</br>
</br>
 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>
       <asp:GridView ID="gvCounts" runat="server" ShowFooter="true" AutoGenerateColumns="True" Width="100%" CssClass = "DataGrid">
 </asp:GridView>
          </ContentTemplate>
      </asp:UpdatePanel> 
</asp:Content>
