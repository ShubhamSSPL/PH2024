<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmARCAllotmentReport.aspx.cs" Inherits="Pharmacy2024.AdminModule.frmARCAllotmentReport" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
   
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Allotment Report">
     
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
                        <td style="text-align: right; width:50%;">Entrance Exam Type : </td>
                        <td>
                            <asp:DropDownList ID="ddlEntranceExamType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEntranceExamType_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem> 
                                <asp:ListItem Value="All">All </asp:ListItem> 
                                <asp:ListItem Value="MHT-CET">MHT-CET </asp:ListItem>
                                <asp:ListItem Value="JEE">JEE</asp:ListItem> 
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvEntranceExamType" runat="server" ErrorMessage="Please Select Entrance Exam Type." Operator="NotEqual" ValueToCompare="0" ControlToValidate="ddlEntranceExamType" ValidationGroup="GenerateReport" Display = "none"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width:50%;">Qualifying Exam Type : </td>
                        <td>
                            <asp:DropDownList ID="ddlQualifyingExamType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlQualifyingExamType_SelectedIndexChanged" >
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="All">All </asp:ListItem>  
                                <asp:ListItem Value="MHT-CET">HSC </asp:ListItem>
                                <asp:ListItem Value="JEE">Diploma</asp:ListItem> 
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvQualifyingExamType" runat="server" ErrorMessage="Please Select Qualifying Exam Type." Operator="NotEqual" ValueToCompare="0" ControlToValidate="ddlQualifyingExamType" ValidationGroup="GenerateReport" Display = "none"></asp:CompareValidator>
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