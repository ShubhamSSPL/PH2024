<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAdmissionReportingCenters.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmAdmissionReportingCenters" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" HeaderText = "List of Admission Reporting Centers (ARC)" runat="server">
        <asp:GridView ID="gvARCList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid table-responsive">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Header" Width = "7%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteCode" HeaderText = "Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width = "8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteNameAndAddress" HeaderText = "Institute Name & Address">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Width = "55%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "ContactDetails" HeaderText = "Contact Details">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Width = "30%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
