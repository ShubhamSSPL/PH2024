<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmFCNotLoggedInReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmFCNotLoggedInReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="SC Not Logged In Report" Width="100%" Height="400px" ScrollBars="Auto">

        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:Button ID="btnexporttoExcel" runat="server" Text="Export To Excel" OnClick="btnexporttoExcel_Click" Visible="false" />
                </td>
            </tr>
        </table>

        <br />
        <asp:GridView ID="gvFCNotLoggedInReportList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField DataField="SrNo" HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AFCCode" HeaderText="AFC Code">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AFCName" HeaderText="AFC Name">
                    <ItemStyle HorizontalAlign="Center" Width="20%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CoordinatorName" HeaderText="Coordinator Name">
                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>
