<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCVCTVCListEmailMobile.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCVCTVCListEmailMobile" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>
<body>
    <form id="VacancyReportForm" runat="server">
    <div class="header">
        <div class="header-left">
            <img alt="Logo" src="../Images/WebsiteLogo.png" />
        </div>
        <div class="header-right">
            <p class="logo-subtitle">
                State Common Entrance Test Cell, Government of Maharashtra
                <br />
            </p>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table>
        <td style="width: 25%;" align="right">
           Select Authority District &nbsp&nbsp&nbsp&nbsp
        </td>
        <td style="width: 25%;">
            <asp:DropDownList ID="ddlCDistrict" runat="server" Width="90%" AutoPostBack="true"
                OnSelectedIndexChanged="ddlCDistrict_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </table>
    <br />
    <br />
    <cc1:ContentBox ID="ContentBox1" HeaderText="" runat="server" ScrollBars="Auto" Height="205px">
      <asp:Button ID="btnexport" runat="server" CssClass="InputButtonRed" Text="Export to Excel"
            OnClick="btnexport_Click" />
        <asp:GridView ID="GridView1" runat="server" ShowFooter="false" AutoGenerateColumns="True"
            Width="100%" CssClass="DataGrid" EmptyDataText="No Records Found" onrowdatabound="GridView1_RowDataBound">
        </asp:GridView>
    </cc1:ContentBox>
  <cc1:ContentBox ID="ContentTable1" HeaderText=""
        runat="server" ScrollBars="Auto" Height="605px">
        <asp:Button ID="btnExporttoExcel" runat="server" CssClass="InputButtonRed" Text="Export to Excel"
            OnClick="btnExporttoExcel_Click" />
        <br />
        <asp:GridView ID="gvCVCTVCNonSTList" runat="server" ShowFooter="false" AutoGenerateColumns="True"
            Width="100%" CssClass="DataGrid" EmptyDataText="No Records Found" onrowdatabound="gvCVCTVCNonSTList_RowDataBound">
        </asp:GridView>
    </cc1:ContentBox> 
    </form>
</body>
</html>

