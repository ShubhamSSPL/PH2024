<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmILSeatAcceptanceFeeNotPaidReport.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmILSeatAcceptanceFeeNotPaidReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="IL Seat Acceptance Candidate Fee Not Paid Institute List Report">
        <asp:GridView ID="gvILSeatAcceptanceFeeNotPaidInstituteList" EmptyDataText="No records Found"
            runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="ApplicationID">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FeeToBePay" HeaderText="Fee To Be Pay">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CategoryName" HeaderText="Category Name">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AdmittedStatus" HeaderText="Admitted Status">
                    <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="CandidateName">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteCodeAdmitted" HeaderText="Institute Code Admitted">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteNameAdmitted" HeaderText="Institute Name Admitted">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="50%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseNameAdmitted" HeaderText="Course Name Admitted">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ChoiceCodeAdmitted" HeaderText="Choice Code Admitted">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SeatTypeAdmitted" HeaderText="Seat Type Admitted">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPRoundAdmitted" HeaderText="CAP Round Admitted">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>