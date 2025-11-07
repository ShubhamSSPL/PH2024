<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAFCList.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmAFCList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" HeaderText="SC List" runat="server" Width="100%" Height="400px" ScrollBars="Auto">
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteNameEnglish" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PrincipalNameEnglish" HeaderText="Principal Name">
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PrincipalMobileNo" HeaderText="Principal Mobile No">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PrincipalEMailID" HeaderText="Principal EMail ID">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CoordinatorName" HeaderText="Coordinator Name">
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CoordinatorDesignation" HeaderText="Coordinator Designation">
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CoordinatorMobileNo" HeaderText="Coordinator<br />Mobile No" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CoordinatorEmailID" HeaderText="Coordinator<br />E-Mail ID" HtmlEncode='false'>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CoordinatorPhoneNo" HeaderText="Coordinator Phone No">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>
