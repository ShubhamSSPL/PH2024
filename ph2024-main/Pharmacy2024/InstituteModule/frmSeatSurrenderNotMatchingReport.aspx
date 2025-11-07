<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSeatSurrenderNotMatchingReport.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmSeatSurrenderNotMatchingReport" AsyncTimeout="600000" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
     <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "Invalid Seat Surrender List" Width = "100%" Height="400px" ScrollBars = "Auto">
        <asp:GridView ID="gvInstituteList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Width="38%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="17%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalIntake" HeaderText="Total Intake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPSeatsPercentage" HeaderText="CAP (Excluding Minority) Percentage">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MinoritySeatsPercentage" HeaderText="CAP (Minority) Percentage">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ILSeatsPercentage" HeaderText="Institutional Percentage">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPSeatsInPortal" HeaderText="CAP (Excluding Minority) Intake in Portal">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MinoritySeatsInPortal" HeaderText="CAP (Minority) Intake in Portal">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ILSeatsInPortal" HeaderText="Institutional Intake in Portal">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPSeatsInAdmission" HeaderText="CAP (Excluding Minority) Intake in Admission">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MISeatsInAdmission" HeaderText="CAP (Minority) Intake in Admission">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ILSeatsInAdmission" HeaderText="Institutional Intake in Admission">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Edit" HeaderText="Edit" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center"  CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
