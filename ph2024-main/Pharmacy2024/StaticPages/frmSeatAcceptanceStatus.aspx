<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSeatAcceptanceStatus.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmSeatAcceptanceStatus" %>


<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        @media only screen and (max-width: 768px) {
            #rightContainer_contentSecretKey {
                position: fixed !important;
                width: 95% !important;
                top: 30% !important;
            }
        }
</style>
      <asp:Label ID="Label2" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
    <cc1:contentbox id="contentSecretKey" runat="server" headertext="Secret Key" boxtype="PopupBox"
        width="50%" headervisible="false" >
       <div class="table-responsive">
        <table class="AppFormTable">
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Text="This Screate key confidential purpose. "
                        ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblmsg" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;" align="right">Enter Secret Key
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtkey" runat="server"></asp:TextBox>
                    <br />
                     <asp:Button ID="btnSecretKey" runat="server" OnClick="btnSecretKey_Click" Text="Submit"
                        ValidationGroup="secret" />
                </td>
            </tr>
        </table>
           </div>
        <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
    </cc1:contentbox>
    <cc1:ContentBox ID="ContentTable1" HeaderText="Application Status Wise Report" runat="server">
        <div class="table-responsive">
          <%--  <asp:UpdatePanel runat="server" ID="upSpecialReservation">
                <ContentTemplate>--%>
                    <table class="AppFormTable" id="tblAll" runat="server">
                        <tr>
                            <td colspan="2">
                                <center><b>Self ARC and Institue Reporting Report</b></center>
                                <asp:GridView ID="gvAll" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                    <Columns>
                                        <asp:BoundField DataField="Title" HeaderText="Status">
                                            <ItemStyle Width="80%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Total" HeaderText="Total">
                                            <ItemStyle Width="20%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <br />
                   <%-- <table class="AppFormTable" id="tblDashboardPharmacy" runat="server">
                        <tr>
                            <td colspan="2">
                                <center><b>Pharmacy Self ARC and Institue Reporting Report</b></center>
                                <asp:GridView ID="gvApplicationStatusReportPH" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                    <Columns>
                                        <asp:BoundField DataField="Title" HeaderText="Option Form Status">
                                            <ItemStyle Width="80%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Total" HeaderText="Total">
                                            <ItemStyle Width="20%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table class="AppFormTable" id="tblDashboardHMCT" runat="server">
                        <tr>
                            <td colspan="2">
                                <center><b>Hotel Management and Catering Technology Self ARC and Institue Reporting Report</b></center>
                                <asp:GridView ID="gvApplicationStatusReportHMCT" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                    <Columns>
                                        <asp:BoundField DataField="Title" HeaderText="Status">
                                            <ItemStyle Width="80%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Total" HeaderText="Total">
                                            <ItemStyle Width="20%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table class="AppFormTable" id="tblDashboardSCT" runat="server">
                        <tr>
                            <td colspan="2">
                                <center><b>Surface Coating Technology Self ARC and Institue Reporting Wise Report</b></center>
                                <asp:GridView ID="gvApplicationStatusReportSCT" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                    <Columns>
                                        <asp:BoundField DataField="Title" HeaderText="Status">
                                            <ItemStyle Width="80%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Total" HeaderText="Total">
                                            <ItemStyle Width="20%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>--%>

                <%--</ContentTemplate>--%>
            <%--</asp:UpdatePanel>--%>
            <br />
            <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
        </div>
    </cc1:ContentBox>
    <script>
        function showSecretKey() {
            document.getElementById('<%=contentSecretKey.ClientID %>').Show('', true);
        }
    </script>
</asp:Content>
