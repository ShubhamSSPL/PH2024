<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="hondirectorReport.aspx.cs" Inherits="Pharmacy2024.StaticPages.hondirectorReport" %>


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
    <script>
        function showSecretKey() {
            document.getElementById('<%=contentSecretKey.ClientID %>').Show('', true);
        }

        function Printit() {
            //document.getElementById("top1").style.display = 'none';
            //document.getElementById("top2").style.display = 'none';
            //document.getElementById("left1").style.display = 'none';
            //document.getElementById("footer1").style.display = 'none';
            document.getElementById("btnPrint").style.display = 'none';
            document.getElementById("rightContainer1").style.width = '900px';

            document.getElementById("topdiv").style.display = 'none';

            var x = document.getElementById("header");
            if (x.style.display == "none") {
                x.style.display = "block";
            }
            document.getElementById("footer1").style.display = 'none';

            window.print();

            //document.getElementById("top1").style.display = '';
            //document.getElementById("top2").style.display = '';
            //document.getElementById("left1").style.display = '';
            //document.getElementById("footer1").style.display = '';
            document.getElementById("btnPrint").style.display = '';
            document.getElementById("rightContainer1").style.width = '79.7%';
            document.getElementById("topdiv").style.display = '';
            x.style.display = "none";
        }

    </script>

    <table class="AppFormTableWithoutBorder" id="header" style="display: none;">
        <tr>
            <td style="width: 10%; border-top-width: 0px; border-right-width: 0px;" align="center">
                <img src="../Images/dte-logo.gif" alt="" height="76px" />
            </td>
            <td style="width: 90%; border-top-width: 0px; border-left-width: 0px;" align="center">
                <b>
                    <font size="3">State Common Entrance Test Cell, Maharashtra State</font>
                </b>
                <br />
                <font size="2">First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions A.Y. <%=AdmissionYear%></font>
                <br />
            </td>
        </tr>
    </table>
    <table class="AppFormTable mt-3" id="tblPayDifferenceFee" runat="server">
        <tr style="background-color: #0cbaba;">
            <td align="center">
                <b>
                    <asp:Label ID="lblPrintedOn1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Font-Names="Verdana"></asp:Label></b>
            </td>
        </tr>
    </table>
    <br />
    <center>
        <cc1:ContentBox ID="ContentTable1" HeaderText="First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions" runat="server" Width="80%">
            <table class="AppFormTable" id="tblDashboard" runat="server" visible="true">
                <tr>
                    <td valign="top" style="background-color: #ffe4c4;">
                        <center><b>Registration Counts (A) = (B+C+D)</b></center>
                        <asp:GridView ID="gvRegistration" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                            <Columns>
                                <asp:BoundField DataField="FormStatus" HeaderText="Description">
                                    <ItemStyle Width="60%" HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" BackColor="#ffa500" CssClass="Item" />
                                    <%-- <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                <FooterStyle HorizontalAlign="Right" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />--%>
                                </asp:BoundField>
                                <asp:BoundField DataField="Total" HeaderText="Pharmacy">
                                    <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#ffa500" CssClass="Item" />
                                </asp:BoundField>
                                <%--  <asp:BoundField DataField="HMCT" HeaderText="D. HMCT">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#ffa500" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SCT" HeaderText="D. SCT">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#ffa500" CssClass="Item" />
                            </asp:BoundField>--%>
                                <%-- <asp:BoundField DataField="Total" HeaderText="Total">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#ffa500" CssClass="Item" />
                            </asp:BoundField>--%>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <center><b>Registration Device Counts (A) = (E+F)</b></center>
                        <asp:GridView ID="gvDevice" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid" ShowHeader="false">
                            <Columns>
                                <asp:BoundField DataField="FormStatus" HeaderText="Description">
                                    <ItemStyle Width="60%" HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" BackColor="#87ceeb" CssClass="Item" />
                                    <%-- <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                <FooterStyle HorizontalAlign="Right" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />--%>
                                </asp:BoundField>
                                <asp:BoundField DataField="Total" HeaderText="Count">
                                    <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#87ceeb" CssClass="Item" />
                                </asp:BoundField>
                                <%--   <asp:BoundField DataField="HMCT" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#87ceeb" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SCT" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#87ceeb" CssClass="Item" />
                            </asp:BoundField>--%>
                                <%--    <asp:BoundField DataField="Total" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#87ceeb" CssClass="Item" />
                            </asp:BoundField>--%>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <center><b>Scrutiny Mode Counts (A) = (G+H+I)</b></center>
                        <asp:GridView ID="gvScrutinyMode" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid" ShowHeader="false">
                            <Columns>
                                <asp:BoundField DataField="FormStatus" HeaderText="Description">
                                    <ItemStyle Width="60%" HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" BackColor="#9acd32" CssClass="Item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Total" HeaderText="Count">
                                    <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#9acd32" CssClass="Item" />
                                </asp:BoundField>
                                <%-- <asp:BoundField DataField="HMCT" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#9acd32" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SCT" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#9acd32" CssClass="Item" />
                            </asp:BoundField>--%>
                                <%-- <asp:BoundField DataField="Total" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#9acd32" CssClass="Item" />
                            </asp:BoundField>--%>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <center><b>e-Scrutiny Mode Selected Candidates Bifurcation (G) = (J+K+L+M)</b></center>
                        <asp:GridView ID="gvEVerificationStatus" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid" ShowHeader="false">
                            <Columns>
                                <asp:BoundField DataField="FormStatus" HeaderText="Description">
                                    <ItemStyle Width="60%" HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" BackColor="#d2691e" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Total" HeaderText="Count">
                                    <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#d2691e" />
                                </asp:BoundField>
                                <%-- <asp:BoundField DataField="HMCT" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#d2691e" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SCT" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#d2691e" />
                            </asp:BoundField>--%>
                                <%-- <asp:BoundField DataField="Total" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#d2691e" />
                            </asp:BoundField>--%>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <center><b>Physical-Scrutiny Mode Selected Candidates Bifurcation (H) = (O+P+Q)</b></center>
                        <asp:GridView ID="gvPVerificationStatus" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid" ShowHeader="false">
                            <Columns>
                                <asp:BoundField DataField="FormStatus" HeaderText="Description">
                                    <ItemStyle Width="60%" HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" BackColor="#fafad2" CssClass="Item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Total" HeaderText="Count">
                                    <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#fafad2" CssClass="Item" />
                                </asp:BoundField>
                                <%--  <asp:BoundField DataField="HMCT" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#fafad2" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SCT" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#fafad2" CssClass="Item" />
                            </asp:BoundField>--%>
                                <%--  <asp:BoundField DataField="Total" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#fafad2" CssClass="Item" />
                            </asp:BoundField>--%>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <center>
                            <b>e-Scrutiny Mode Selected but awaiting Confirmation by SC (L) -
                        <asp:Label ID="lbleFCAwating" runat="server" Text=""></asp:Label>[Break Up]</b></center>
                        <asp:GridView ID="gvEScrutinyBreakup" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid" ShowHeader="false">
                            <Columns>
                                <asp:BoundField DataField="FormStatus" HeaderText="Description">
                                    <ItemStyle Width="60%" HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" BackColor="#9370db" CssClass="Item" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Total" HeaderText="Count">
                                    <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#9370db" CssClass="Item" />
                                </asp:BoundField>
                                <%--   <asp:BoundField DataField="HMCT" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#9370db" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SCT" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#9370db" CssClass="Item" />
                            </asp:BoundField>--%>
                                <%-- <asp:BoundField DataField="Total" HeaderText="Count">
                                <ItemStyle Width="10%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" BackColor="#9370db" CssClass="Item" />
                            </asp:BoundField>--%>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </td>

                </tr>
                <tr>
                    <td align="right">
                        <b>
                            <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label></b>
                    </td>
                </tr>
            </table>
            <br />
            <table class="AppFormTableWithOutBorder">
                <tr>
                    <td align="center">
                        <input id="btnPrint" type="button" value="  Print  " class="InputButton" onclick="Printit()" />
                    </td>
                </tr>
            </table>
        </cc1:ContentBox>
    </center>

    <asp:Label ID="Label2" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
    <cc1:ContentBox ID="contentSecretKey" runat="server" HeaderText="Secret Key" BoxType="PopupBox"
        Width="50%" HeaderVisible="false">
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
    </cc1:ContentBox>

</asp:Content>
