<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmInstituteWiseAllotmentList.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmInstituteWiseAllotmentList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Institute-Wise Allotment List">
        <asp:GridView ID="gvInstituteList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" Width="58%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="DownloadRound1" HeaderText="CAP-I" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
               <asp:BoundField DataField="DownloadRound2" HeaderText="CAP-II" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="DownloadRound3" HeaderText="CAP-III" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <%--   <asp:BoundField DataField="DownloadRound4" HeaderText="Aditional Round" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField> --%>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
