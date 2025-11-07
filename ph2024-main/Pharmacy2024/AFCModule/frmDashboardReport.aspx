<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmDashboardReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmDashboardReport" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownList_OptGroup" Namespace="DropDownList_OptGroup" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible="false">
        <asp:UpdatePanel runat="server" ID="upSpecialReservation">
            <ContentTemplate>
                <table class="AppFormTable" id="tblDashboard" runat="server" visible="false">
                    <tr>
                        <th colspan="2" style="border-top-width: 0px;">Dashboard</th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center><b>Application Status Wise Report</b></center>
                            <asp:GridView ID="gvApplicationStatusReport" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="FormStatus" HeaderText="Application Status">
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
                    <tr>
                        <td align="right">Select Date</td>
                        <td>
                            <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">Total Confirmed Under CAP at SCs</td>
                        <td>
                            <asp:Label ID="lblCAPConfirmed" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Total Confirmed Under Non-CAP at SCs</td>
                        <td>
                            <asp:Label ID="lblNonCAPConfirmed" runat="server"></asp:Label></td>
                    </tr>
                    <tr id="trDashboardType" runat="server">
                        <td style="text-align: right">Select Dashboard Type : </td>
                        <td>
                            <asp:DropDownList ID="ddlDashboard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDashboard_SelectedIndexChanged">
                                <asp:ListItem Value="1">Confirmed At SCs</asp:ListItem>
                               <asp:ListItem Value="2">Provisional Merit List</asp:ListItem>
                                 <asp:ListItem Value="3">Final Merit List</asp:ListItem>
                                <asp:ListItem Value="4">Fill completely But not Confirmed</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%;" valign="top">
                            <center><b>Candidature Type Wise Report</b></center>
                            <asp:GridView ID="gvCandidatureTypeWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="CandidatureTypeName" HeaderText="Candidature Type">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Home University Wise Report</b></center>
                            <asp:GridView ID="gvHomeUniversityWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="HomeUniversityName" HeaderText="Home University">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Category Wise Report</b></center>
                            <asp:GridView ID="gvCategoryWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="CategoryName" HeaderText="Category">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>PH Type Wise Report</b></center>
                            <asp:GridView ID="gvPHTypeWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="PHTypeDetails" HeaderText="PH Type">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Defence Type Wise Report</b></center>
                            <asp:GridView ID="gvDefenceTypeWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="DefenceTypeDetails" HeaderText="Defence Type">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Gender Wise Report</b></center>
                            <asp:GridView ID="gvGenderWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="GenderName" HeaderText="Gender">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>HSC Passing Year Wise Report</b></center>
                            <asp:GridView ID="gvHSCPassingYearWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="HSCPassingYear" HeaderText="HSC Passing Year">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Minority Status Wise Report</b></center>
                            <asp:GridView ID="gvMinorityReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="MinorityType" HeaderText="Minority Type" HtmlEncode="false">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 50%;" valign="top">
                            <center><b>Religion Wise Report</b></center>
                            <asp:GridView ID="gvReligionWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="ReligionName" HeaderText="Religion">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Region Wise Report</b></center>
                            <asp:GridView ID="gvRegionWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="RegionName" HeaderText="Region">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Mother Tongue Wise Report</b></center>
                            <asp:GridView ID="gvMotherTongueWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="MotherTongueName" HeaderText="Mother Tongue">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <center><b>Annual Family Income Wise Report</b></center>
                            <asp:GridView ID="gvAnnualFamilyIncomeWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="AnnualFamilyIncomeDetails" HeaderText="Annual Family Income">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>HSC Board Wise Report</b></center>
                            <asp:GridView ID="gvHSCBoardWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="BoardName" HeaderText="Board">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Orphan Status Wise Report</b></center>
                            <asp:GridView ID="gvOrphanStatusWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="Orphan" HeaderText="Orphan Status">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>EWS Status Wise Report</b></center>
                            <asp:GridView ID="gvEWSStatusWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="EWS" HeaderText="EWS Status">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
