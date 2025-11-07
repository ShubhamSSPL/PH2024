<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmConfirmedCandidateList.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmConfirmedCandidateList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <table class="AppFormTableWithOutBorder">
        <tr>
            <td style="width: 50%;" align="right">Select Date to Filter : </td>
            <td style="width: 50%;">
                <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
    </table>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Confirmed Candidate List" Width="100%" Height="400px" ScrollBars="Auto">
        <asp:GridView ID="gvConfirmedCandidateList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Left" Width="35%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ReportedDateTime" HeaderText="Confirmed Date Time">
                    <ItemStyle HorizontalAlign="Center" Width="25%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ReportedBy" HeaderText="Confirmed By">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ReportedByIPAddress" HeaderText="Confirmed By<br />IP Address" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="DDAmount" HeaderText="Amount">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="DDNumber" HeaderText="Reference Number">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="DDDate" HeaderText="Payment Date">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "BankName" HeaderText = "Bank Name">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "BranchName" HeaderText = "Branch Name">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>--%>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Cancelled Candidate List" Width="100%" Height="400px" ScrollBars="Auto">
        <asp:GridView ID="gvCancelledCandidateList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Left" Width="35%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CancelledDateTime" HeaderText="Cancelled Date Time">
                    <ItemStyle HorizontalAlign="Center" Width="25%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CancelledBy" HeaderText="Cancelled By">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CancelledByIPAddress" HeaderText="Cancelled By<br />IP Address" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="DDAmount" HeaderText="Amount">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="DDNumber" HeaderText="Reference Number">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="DDDate" HeaderText="Payment Date">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "BankName" HeaderText = "Bank Name">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "BranchName" HeaderText = "Branch Name">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>--%>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>
