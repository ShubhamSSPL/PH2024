<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSeatDistributionNotMatchingReport.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmSeatDistributionNotMatchingReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
     <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "Invalid Seat Distribution List" Width = "100%" ScrollBars = "Auto">
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
                <asp:BoundField DataField="CAPIntake" HeaderText="CAP (Excluding Minority) Intake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MIIntake" HeaderText="CAP (Minority) Intake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ILIntake" HeaderText="Institutional Intake">
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
