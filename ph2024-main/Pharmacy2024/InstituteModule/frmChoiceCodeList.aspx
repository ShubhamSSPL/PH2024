<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmChoiceCodeList.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmChoiceCodeList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "Choice Code List" Width = "100%" Height = "400px" ScrollBars = "auto">
        <center><asp:Button ID="btnExporttoExcel" runat="server" CssClass = "InputButtonRed" Text="Export to Excel All Choice Code List for Seat Distribution from DTE Portal" OnClick="btnExporttoExcel_Click" /></center>
        <br />
        <center>
        <asp:GridView ID="gvSummary" runat="server" AutoGenerateColumns="False" Width="50%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
                <asp:BoundField DataField="Details" HeaderText="Details">
                    <ItemStyle HorizontalAlign="Right" Font-Size="12px" CssClass = "Item" Width="50%" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Total" HeaderText="Total">
                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" CssClass = "Item" Width="50%" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        </center>
        <br />
        <asp:GridView ID="gvInstituteList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
                <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="Left" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="RegionName" HeaderText="Region">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="DistrictName" HeaderText="District">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteStatus1" HeaderText="Status 1">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteStatus2" HeaderText="Status 2">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteStatus3" HeaderText="Status 3">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PublicRemark" HeaderText="Public Remark">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="UniversityName" HeaderText="University">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseStatus1" HeaderText="Course Status 1">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseStatus2" HeaderText="Course Status 2">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseStatus3" HeaderText="Course Status 3">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Shift" HeaderText="Shift">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AccreditationDetails" HeaderText="Accreditation">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="GenderDetails" HeaderText="Gender">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="IsGov" HeaderText="Is Gov">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="IsNRI" HeaderText="Is NRI">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="IsPIO" HeaderText="Is PIO">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalIntake" HeaderText="Total Intake">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPSeatsPercentage" HeaderText="CAP (Excluding Minority) Seats %">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPSeats" HeaderText="CAP (Excluding Minority) Seats">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MinoritySeatsPercentage" HeaderText="CAP (Minority) Seats %">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MinoritySeats" HeaderText="CAP (Minority) Seats">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ILSeatsPercentage" HeaderText="Institutional Seats %">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ILSeats" HeaderText="Institutional Seats">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="IntakeJK" HeaderText="JK Intake">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourtCaseRemark" HeaderText="Court Case Remark">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ParticipateInCAP" HeaderText="Participate In CAP">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>