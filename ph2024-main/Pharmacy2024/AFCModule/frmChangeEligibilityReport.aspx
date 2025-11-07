<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmChangeEligibilityReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmChangeEligibilityReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server">
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="32%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="EligibilityStatus" HeaderText="Eligibility Status">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ModifiedDateTime" HeaderText="Modified Date Time">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ModifiedBy" HeaderText="Modified By">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ModifiedByIPAddress" HeaderText="Modified By IP Address">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>
