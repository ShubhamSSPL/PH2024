<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmInstituteSummary.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmInstituteSummary" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Institute Summary">
        <table class="AppFormTable">
            <tr>
                <td align="right">Institute Code</td>
                <td colspan="3"><asp:Label ID="lblInstituteCode" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Institute Name</td>
                <td colspan="3"><asp:Label ID="lblInstituteName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Institute Address</td>
                <td colspan="3"><asp:Label ID="lblInstituteAddress" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Region</td>
                <td><asp:Label ID="lblRegion" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">District</td>
                <td><asp:Label ID="lblDistrict" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td style ="width:25%" align="right">Status</td>
                <td style ="width:25%"><asp:Label ID="lblStatus1" runat="server" Font-Bold = "true"></asp:Label></td>
                <td style ="width:25%" align="right">Autonomy Status</td>
                <td style ="width:25%"><asp:Label ID="lblStatus2" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Minority Status</td>
                <td colspan = "3"><asp:Label ID="lblStatus3" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Public Remark</td>
                <td colspan = "3"><asp:Label ID="lblPublicRemark" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox7" runat="server" HeaderText="Course Details" Width = "100%" ScrollBars = "Auto">
        <asp:GridView ID="gvChoiceCodeList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
                <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="UniversityName" HeaderText="University">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseStatus1" HeaderText="Status">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseStatus2" HeaderText="Autonomy Status">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseStatus3" HeaderText="Minority Status">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseShift" HeaderText="Shift">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Accreditation" HeaderText="Accreditation">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="Gender" HeaderText="Gender">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalIntake" HeaderText="Total Intake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
