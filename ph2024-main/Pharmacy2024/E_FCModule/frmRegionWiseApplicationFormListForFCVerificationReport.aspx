<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmRegionWiseApplicationFormListForFCVerificationReport.aspx.cs" Inherits="Pharmacy2024.E_FCModule.frmRegionWiseApplicationFormListForFCVerificationReport" %>


<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "Region Wise New Application Forms For E-Scrutiny">
        <asp:GridView ID="gvRegionWiseReport" ShowFooter = "true" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>
                <asp:HyperLinkField DataTextField = "RegionName" DataNavigateUrlFields="RegionID" DataNavigateUrlFormatString = "frmAFCWiseApplicationFormListForFCVerificationReport.aspx?RegionID={0}" HeaderText = "Region Name">
                    <ItemStyle HorizontalAlign="Center" Width="50%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Right" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:BoundField DataField = "TotalApplicationFormsConfirmed" HeaderText = "New Application Forms For E-Scrutiny">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"  />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>



