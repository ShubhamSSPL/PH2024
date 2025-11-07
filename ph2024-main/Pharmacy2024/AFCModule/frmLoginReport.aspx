<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmLoginReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmLoginReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Login Report" Width="100%" Height="400px" ScrollBars="Auto">

        <table class="AppFormTable">
            <tr id="trLoginID" runat="server">
                <td align="right" style="width: 50%">Login ID</td>
                <td style="width: 50%">
                    <asp:TextBox ID="txtLoginID" MaxLength="100" runat="server" onmouseover="ddrivetip('Please Enter Login ID.')" onmouseout="hideddrivetip()"></asp:TextBox>
                    <font color="red">*</font>
                    <asp:RequiredFieldValidator ID="rfvLoginID" runat="server" Display="None" ControlToValidate="txtLoginID" ErrorMessage="Please Enter Login ID."></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>

        <table class="AppFormTable">
            <tr>
                <td align="center">
                    <asp:Button ID="btnGetDetails" runat="server" Text="Get Details" CssClass="InputButton" OnClick="btnGetDetails_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>

        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:Button ID="btnexporttoExcel" runat="server" Text="Export To Excel" OnClick="btnexporttoExcel_Click" Visible="false" />
                </td>
            </tr>
        </table>

        <br />
        <asp:GridView ID="gvLoginReportList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField DataField="SrNo" HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="LoginID" HeaderText="Login ID">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="LoginDateTime" HeaderText="Login Date Time">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="BrowserName" HeaderText="Browser Name">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="IPAddress" HeaderText="IP Address">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>
