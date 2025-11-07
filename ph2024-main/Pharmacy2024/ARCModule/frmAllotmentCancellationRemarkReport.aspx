<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAllotmentCancellationRemarkReport.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmAllotmentCancellationRemarkReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Allotment Cancellation Remark Report">
        <asp:GridView ID="gvAllotmentCancellationRemarkReport" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="AllotmentCancellationRemark" HeaderText="Cancellation Remark">
                    <ItemStyle HorizontalAlign="Left" Width="50%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="CreatedDateTime" HeaderText="Cancellation Date Time">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="CreatedBy" HeaderText="Cancelled By">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPRound" HeaderText="CAP Round">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
