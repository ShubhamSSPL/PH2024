<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmInstituteCoordinatorList.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmInstituteCoordinatorList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" HeaderText = "Institute Co-Ordinator List" runat="server" Width = "100%" Height = "400px" ScrollBars = "Auto">
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteCode" HeaderText = "Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteName" HeaderText = "Institute Name">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstitutePhoneNo" HeaderText = "Institute Phone No">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteFaxNo" HeaderText = "Institute Fax No">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CoordinatorName" HeaderText = "Coordinator Name">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CoordinatorDesignation" HeaderText = "Coordinator Designation">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CoordinatorMobileNo" HeaderText = "Coordinator Mobile No">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CoordinatorEmailID" HeaderText = "Coordinator Email ID">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CoordinatorPhoneNo" HeaderText = "Coordinator Phone No">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>