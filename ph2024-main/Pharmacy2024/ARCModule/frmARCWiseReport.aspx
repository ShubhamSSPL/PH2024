<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmARCWiseReport.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmARCWiseReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="ARC Wise Report" Width="100%" Height="400px" ScrollBars="Auto">
        <asp:GridView ID="gvARCWiseReport" ShowFooter="true" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Footer" />
                </asp:BoundField>
                <asp:HyperLinkField DataTextField="ARCName" DataNavigateUrlFields="RegionID,InstituteID" DataNavigateUrlFormatString="frmSubARCWiseReport.aspx?RegionID={0}&InstituteID={1}" HeaderText="ARC Name">
                    <ItemStyle HorizontalAlign="Left" Width="50%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Right" CssClass="Footer" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="TotalConfirmed" HeaderText="Total Confirmed">
                    <ItemStyle HorizontalAlign="Center" Width="20%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalCancelled" HeaderText="Total Cancelled" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="20%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>
