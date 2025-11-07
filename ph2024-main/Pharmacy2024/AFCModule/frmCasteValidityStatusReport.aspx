<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCasteValidityStatusReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmCasteValidityStatusReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Caste Validity Status Report By Application Status" Width="100%" ScrollBars="auto">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <b>Select Application Status : </b>
                    <asp:DropDownList ID="ddlApplicationStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlApplicationStatus_SelectedIndexChanged">
                        <asp:ListItem Value="ALL">ALL</asp:ListItem>
                        <asp:ListItem Value="CompletelyFilled">Filled Completely But Not Confirmed</asp:ListItem>
                        <asp:ListItem Value="Confirmed">Confirmed</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvCasteValidityStatusReport" runat="server" AutoGenerateColumns="False" ShowFooter="true" Width="100%" CellPadding="5" CssClass="DataGrid">
            <Columns>
                <asp:BoundField DataField="CategoryName" HeaderText="Category">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Available" HeaderText="Available">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Appliedbutnotreceived" HeaderText="Applied But Not Received">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="notApplied" HeaderText="Not Applied">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Total" HeaderText="Total">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
