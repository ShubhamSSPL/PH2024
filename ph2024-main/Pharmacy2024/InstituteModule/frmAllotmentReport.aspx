<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAllotmentReport.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmAllotmentReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Candidate List">
        <center><asp:Label ID="lblInstituteName" Font-Bold="true" ForeColor="red" runat="server" Font-Size = "small" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="6%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID">
                    <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Width="30%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "MobileNo" HeaderText = "Mobile No">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "MeritNo" HeaderText = "Merit No">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="6%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "MeritMarks" HeaderText = "Merit Marks">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="6%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "SeatTypeAllotted" HeaderText = "Seat Type">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="6%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "ReportingStatus" HeaderText = "Admission Status">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
