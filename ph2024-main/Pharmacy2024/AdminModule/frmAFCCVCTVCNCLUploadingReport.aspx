<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmAFCCVCTVCNCLUploadingReport.aspx.cs" Inherits="Pharmacy2024.AdminModule.frmAFCCVCTVCNCLUploadingReport" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
   
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="CVC/TVC NCL Uploading Status Report">
     
                <table  class="AppFormTable">
                    <tr>
                        <td style="text-align: right; width:50%;">Document Type : </td>
                        <td>
                            <asp:DropDownList ID="ddlDocumentType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDocumentType_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>  
                                <asp:ListItem Value="CVC">CVC/TVC</asp:ListItem>
                                <asp:ListItem Value="NCL">NCL</asp:ListItem>
                                <asp:ListItem Value="RCVC">Receipt of CVC/TVC</asp:ListItem>  
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvDocumentType" runat="server" ErrorMessage="Please Select Document Type." Operator="NotEqual" ValueToCompare="0" ControlToValidate="ddlDocumentType" ValidationGroup="GenerateReport" Display = "none"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width:50%;">Uploading Status : </td>
                        <td>
                            <asp:DropDownList ID="ddlUploadingStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUploadingStatus_SelectedIndexChanged" >
                                <asp:ListItem Value="0">-- Select --</asp:ListItem> 
                                <asp:ListItem Value="Yes">Yes </asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem> 
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvUploadingStatus" runat="server" ErrorMessage="Please Select Uploading Status." Operator="NotEqual" ValueToCompare="0" ControlToValidate="ddlUploadingStatus" ValidationGroup="GenerateReport" Display = "none"></asp:CompareValidator>
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
