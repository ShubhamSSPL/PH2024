<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmCVCTVCNonSTList.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCVCTVCNonSTList" %>
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
    <cc1:ContentBox ID="ContentBox1" HeaderText="" runat="server" ScrollBars="Auto" Height="305px">
      <asp:Button ID="btnexport" runat="server" CssClass="InputButtonRed" Text="Export to Excel"
            OnClick="btnexport_Click" />
        <asp:GridView ID="GridView1" runat="server" ShowFooter="true" AutoGenerateColumns="false" ShowHeader="false"
            Width="100%" CssClass="DataGrid" EmptyDataText="No Records Found" OnRowCreated="GridView1_RowCreated">
            <Columns>
                <asp:BoundField DataField="SrNo" HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="categoryName" HeaderText="Category Name">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="BETotal" HeaderText="BETotal">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="BESubmit" HeaderText="BESubmit">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="BE" HeaderText="BE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="BPharmTotal" HeaderText="BPharmTotal">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="BPharmSubmit" HeaderText="BPharmSubmit">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="BPharm" HeaderText="BPharm">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="METotal" HeaderText="METotal">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="MESubmit" HeaderText="MESubmit">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ME" HeaderText="ME">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable1" HeaderText=""
        runat="server" ScrollBars="Auto" Height="605px">
        <asp:Button ID="btnExporttoExcel" runat="server" CssClass="InputButtonRed" Text="Export to Excel"
            OnClick="btnExporttoExcel_Click" />
        <br />
        <asp:GridView ID="gvCVCTVCNonSTList" runat="server" ShowFooter="true" AutoGenerateColumns="True"
            Width="100%" CssClass="DataGrid" EmptyDataText="No Records Found">
        </asp:GridView>
    </cc1:ContentBox>
    </form>
</body>
</html>
