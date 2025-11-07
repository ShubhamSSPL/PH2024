<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSubAFCWiseReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmSubAFCWiseReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Sub-SC Wise Report">
        <asp:GridView ID="gvSubAFCWiseReport" ShowFooter="true" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid   table-responsive">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Footer" />
                </asp:BoundField>
                <asp:HyperLinkField DataTextField="AFCName" DataNavigateUrlFields="RegionID,InstituteID,AFCID" DataNavigateUrlFormatString="frmConfirmedCandidateList.aspx?RegionID={0}&InstituteID={1}&AFCID={2}" HeaderText="SC Name">
                    <ItemStyle HorizontalAlign="Left" Width="85%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Right" CssClass="Footer" />
                </asp:HyperLinkField>
                <asp:BoundField DataField = "EVerification" HeaderText = "E-Scrutiny<br />Confirmed" HtmlEncode = "false" Visible="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"  />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" />
                </asp:BoundField>
                <asp:BoundField DataField = "PVerification" HeaderText = "P-Scrutiny<br />Confirmed" HtmlEncode = "false" Visible="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"  />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalApplicationFormsConfirmed" HeaderText="Total Application<br />Forms Confirmed" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>
