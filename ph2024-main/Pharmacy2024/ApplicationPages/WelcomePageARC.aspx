<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="WelcomePageARC.aspx.cs" Inherits="Pharmacy2024.ApplicationPages.WelcomePageARC" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register TagPrefix="ddlb" Assembly="OptionDropDownList" Namespace="OptionDropDownList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible="false">
        <br />
        <center>
            <asp:Label ID="lblHeader" runat="server" Font-Names="Bookman Old Style" Font-Bold="false" Font-Size="Medium" Width="92%">
                Welcome for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>
            </asp:Label>
        </center>
        <br />
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <table class="AppFormTable">
            <tr>
                <th colspan="4">Login Details</th>
            </tr>
            <tr>
                <td style="width: 20%" align="right">Login ID</td>
                <td style="width: 30%">
                    <asp:Label ID="lblLoginID" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 20%" align="right">User Name</td>
                <td style="width: 30%">
                    <asp:Label ID="lblUserName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">User Role</td>
                <td>
                    <asp:Label ID="lblUserType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">IP Address</td>
                <td>
                    <asp:Label ID="lblIPAddress" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Current Login Time</td>
                <td>
                    <asp:Label ID="lblCurrentLoginTime" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Previous Login Time</td>
                <td>
                    <asp:Label ID="lblPreviousLoginTime" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trWebSiteNavigation1" runat="server" visible="false">
                <th colspan="4">WebSite Navigation</th>
            </tr>
            <tr id="trWebSiteNavigation2" runat="server" visible="false">
                <td align="right">Select WebSite</td>
                <td colspan="3">
                    <%-- <cc2:DropDownList_OptGroup ID="ddlWebSite" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWebSite_SelectedIndexChanged"></cc2:DropDownList_OptGroup></td>--%>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <font size="3" color="red">
                        <b>Instructions for ARC  : </b>
                        <br />
                        <ol class="list-text">
                            <li>
                                <p align="justify"><font color="red" size="3">If Seat Acceptance is cancelled, Please collect / take back the copy of the Acknowledgement of Seat Acceptance Confirmation issued to the Candidate.</font></p>
                            </li>
                           <%-- <li>
                                <p align="justify">
                                    <font color="red" size="2">After allotment candidate shall report to ARC for seat acceptance. During verification, if ARC found any errors in the application form, in such cases — ARC shall do the following :
                                </p>
                            </li>--%>
                            <%--<li><p align = "justify" > <font color="red" size="3">  To Change the Seat Acceptance Status of Candidate from ‘Not Freeze’ to ‘Freeze’ , ARC can do this in their Respective Login by taking signed willingness letter from the candidate.</font></p></li>
                         <li><p align = "justify" > <font color="red" size="3"> In Case of Change in Marks ARC will Have to send message to ‘ADMIN’ by clearly mentioning exact change in marks details using Message-Box Facility. </font></p></li>--%>
                        </ol>
                    </font>
                    <%--<ol class="list-text">
                        <li>
                            <p align="justify">
                                <font color="red" size="2">First cancel the allotment of the candidate.(except errors in Name change, DoB, Increase in Marks of HSC)
                                </font>
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                <font color="red" size="2">Do the necessary corrections in the application form. Such candidates shall be eligible for next round if they satisfies the eligibility criteria.
                                </font>
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                <font color="red" size="2">If errors are relates with Name change, DoB, Increase in Marks of HSC then do the following:</font>
                            </p>
                            <ol class="list-text">
                                <li>
                                    <p align="justify"><font color="red" size="2">Confirm such applications without cancellation</font></p>
                                </li>
                                <li>
                                    <p align="justify"><font color="red" size="2">Put the exact remark of ARC in the Remark for Confirmation field.</font></p>
                                </li>
                                <li>
                                    <p align="justify"><font color="red" size="2">Send specific message along with required data to admin through message box for ARC in ARC Login. Such corrections shall be done by the Admin only.</font></p>
                                </li>
                            </ol>
                        </li>

                    </ol>--%>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel runat="server" ID="upSpecialReservation">
            <ContentTemplate>
                <table class="AppFormTable" id="tblDashboard" runat="server" visible="false">
                    <tr>
                        <th colspan="2" style="border-top-width: 0px;">Dashboard</th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center><b>Seat Acceptance Status Wise Report</b></center>
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
                        <td style="width: 50%;" align="right">Select Date</td>
                        <td style="width: 50%;">
                            <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">Total Confirmed</td>
                        <td>
                            <asp:Label ID="lblConfirmed" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <table class="AppFormTable" id="tblDashboardAdmin" runat="server" visible="false">
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
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
