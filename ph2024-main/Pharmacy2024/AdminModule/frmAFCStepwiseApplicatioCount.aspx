<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmAFCStepwiseApplicatioCount.aspx.cs" Inherits="Pharmacy2024.AdminModule.frmAFCStepwiseApplicatioCount" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
   
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Step wise Application Count Report">
      
                <table class = "AppFormTable" id = "tblDashboard" runat = "server" visible = "false"> 
                    <tr>
                        <td colspan = "2" align="center">
                           <%-- <center><b>Daily Status Report</b></center>--%>
                            <asp:GridView ID="gvApplicationStatusReport" runat="server" AutoGenerateColumns="False" Width="70%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="Step" HeaderText="Step No">
                                        <ItemStyle Width="10%" HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StepName" HeaderText="Step Name">
                                        <ItemStyle Width="65%" HorizontalAlign="Right" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="25%" HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
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
