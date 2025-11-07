<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmRegionWiseReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmRegionWiseReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Region Wise Report">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td style="width: 50%;" align="right">Select Date to Filter : </td>
                <td style="width: 50%;">
                    <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        </table>
        <asp:GridView ID="gvRegionWiseReport" ShowFooter="true" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Footer" />
                </asp:BoundField>
                <asp:HyperLinkField DataTextField="RegionName" DataNavigateUrlFields="RegionID" DataNavigateUrlFormatString="frmAFCWiseReport.aspx?RegionID={0}" HeaderText="Region Name">
                    <ItemStyle HorizontalAlign="Center" Width="50%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Right" CssClass="Footer" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="TotalApplicationFormsConfirmed" HeaderText="Total Application Forms Confirmed">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>
