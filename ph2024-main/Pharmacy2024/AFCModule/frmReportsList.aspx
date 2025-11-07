<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmReportsList.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmReportsList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="frmReportsListContent" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="frmReportsListContentTable" runat="server" HeaderText="Search Report">
        <table class="AppFormTable">
            <tr>
                <td style="width: 25%" align="right">Report Name</td>
                <td style="width: 75%">
                    <asp:TextBox ID="txtReportName" runat="server" Width="70%" MaxLength="500"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="InputButton" OnClick="btnSearch_Click" /></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="frmReportsListContentBox" runat="server" HeaderText="Reports List">
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" CssClass="DataGrid" OnRowCommand="gvList_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="9%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ReportName" HeaderText="Report Name">
                    <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="75%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:ButtonField CommandName="Excel" HeaderText="Excel" Text="Excel">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <ControlStyle ForeColor="Blue" />
                </asp:ButtonField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblReportID" runat="server" Text='<%# Eval("ReportID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
