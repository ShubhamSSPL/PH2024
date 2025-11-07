<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmARCSeatAcceptanceReport.aspx.cs" Inherits="Pharmacy2024.AdminModule.frmARCSeatAcceptanceReport" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
   
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Seat Acceptance Status Report">
     
                <table  class="AppFormTable">
                    <tr>
                        <td style="text-align: right; width:50%;">Allotment CAP Round : </td>
                        <td>
                            <asp:DropDownList ID="ddlCAPRound" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCAPRound_SelectedIndexChanged" >
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="1">CAP Round - I</asp:ListItem>
                                <asp:ListItem Value="2">CAP Round - II</asp:ListItem>
                                <asp:ListItem Value="3">CAP Round - III</asp:ListItem> 
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvCAPRound" runat="server" ErrorMessage="Please Select CAP Round." Operator="NotEqual" ValueToCompare="0" ControlToValidate="ddlCAPRound" ValidationGroup="GenerateReport" Display = "none"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width:50%;">Seat Acceptance Status Type : </td>
                        <td>
                            <asp:DropDownList ID="ddlSeatAcceptanceStatusType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeatAcceptanceStatusType_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="All">All</asp:ListItem>
                                <asp:ListItem Value="SeatAcceptance">Candidates Given Seat Acceptance</asp:ListItem>
                                <asp:ListItem Value="PaidFees">Candidates Paid Seat Acceptance Fee</asp:ListItem>
                                <asp:ListItem Value="Confirmed">Candidates Confirmed Seat Acceptance</asp:ListItem> 
                                <asp:ListItem Value="NotSeatAcceptance">Candidates Not Given Seat Acceptance</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvSeatAcceptanceStatusType" runat="server" ErrorMessage="Please Select Seat Acceptance Status Type." Operator="NotEqual" ValueToCompare="0" ControlToValidate="ddlSeatAcceptanceStatusType" ValidationGroup="GenerateReport" Display = "none"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width:50%;">Seat Acceptance Type : </td>
                        <td>
                            <asp:DropDownList ID="ddlSeatAcceptanceType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeatAcceptanceType_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="All">All</asp:ListItem>
                                <asp:ListItem Value="AutoFreeze">Auto Freeze</asp:ListItem>
                                <asp:ListItem Value="Freeze">Freeze</asp:ListItem>
                                <asp:ListItem Value="Betterment">Betterment (Not Freeze)</asp:ListItem> 
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvSeatAcceptanceType" runat="server" ErrorMessage="Please Select Seat Acceptance Type." Operator="NotEqual" ValueToCompare="0" ControlToValidate="ddlSeatAcceptanceType" ValidationGroup="GenerateReport" Display = "none"></asp:CompareValidator>
                        </td>
                    </tr>  
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click" CssClass="InputButton" ValidationGroup="GenerateReport"/>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"  ShowSummary="False" ValidationGroup="GenerateReport" /> 
                        </td>
                    </tr>
                </table>
                <table class = "AppFormTable" id = "tblDashboard" runat = "server" visible = "false"> 
                    <tr>
                        <td colspan = "2" align="center">
                           <%-- <center><b>Daily Status Report</b></center>--%>
                            <asp:GridView ID="gvApplicationStatusReport" runat="server" AutoGenerateColumns="False" Width="80%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="Category" HeaderText="Category">
                                        <ItemStyle Width="80%" HorizontalAlign="Right" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="20%" HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Button ID="btnExporttoExcel" runat="server" CssClass = "InputButtonRed" Text="Export to Excel"  OnClick="btnExporttoExcel_Click" />
                        </td>

                    </tr>
               </table>
           
    </cc1:ContentBox>
</asp:Content>
