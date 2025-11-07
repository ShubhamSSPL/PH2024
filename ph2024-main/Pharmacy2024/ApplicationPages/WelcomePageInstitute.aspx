<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="WelcomePageInstitute.aspx.cs" Inherits="Pharmacy2024.ApplicationPages.WelcomePageInstitute" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownList_OptGroup" Namespace="DropDownList_OptGroup" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible="false">
        <br />
        <center>
            <asp:Label ID="lblHeader" runat="server" Font-Names="Bookman Old Style" Font-Size="Medium" Width="92%">
                Welcome for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>
            </asp:Label>
        </center>
        <br />
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
            <%--<tr>
                <td colspan = "4">
                    <b>Note : </b>
                    <br /><br />
                    <ol class="list-text">
                         <li><p align = "justify" ><font color="red" size="3"> ARA has extended last date for submission of Caste/Tribe Validity, NCL as applicable in case of admission to B.E/B.Tech, B.Pharm/Pharm.D, B.Architecture, B.HMCT,MBA/MMS,MCA,M.Arch & M.HMCT upto 25th August 2020.</font> </p></li>
                        </br>
                       <li><p align = "justify" ><font color="red" size="3"> ARA has extended the Cutoff date for admission to all Under Graduate & Post Graduate courses upto 31st August 2020 06:00 PM.</font> </p></li>
                       </br>
                    </ol>
                </td>
            </tr>--%>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbInstitute" runat="server" HeaderVisible="false" ScrollBars="Auto" Visible="false">
        <table class="AppFormTable">
            <tr>
                <th colspan="2" align="left">Course Information</th>
            </tr>
            <tr>
                <td colspan="2">
                    <ol class="list-text">
                        <b>Instructions : </b>
                        <li>
                            <p align="justify">Please Verify the Course Information given below.</p>
                        </li>
                        <li>
                            <p align="justify">If there is any discrepancy, Please contact to CET Cell as earliest.</p>
                        </li>
                    </ol>
                    <asp:Button ID="btnExporttoExcel" runat="server" CssClass="InputButton" Text="Export to Excel" OnClick="btnExporttoExcel_Click" />
                    <br />
                    <br />
                    <asp:GridView ID="gvChoiceCodeListFromDTEPortal" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                                <ItemStyle HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UniversityName" HeaderText="University Name">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseStatus1" HeaderText="Course Status">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseStatus2" HeaderText="Autonomy Status">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseStatus3" HeaderText="Minority Status">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GenderDetails" HeaderText="Gender Status">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AccreditationDetails" HeaderText="Accreditation<br />Details" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IsNRI" HeaderText="NRI<br />Quota" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IsPIO" HeaderText="PIO<br />Quota" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IsForeignCollaboration" HeaderText="Foreign<br />Collaboration" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ParticipateInCAP" HeaderText="Participate<br />in CAP" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AffilatedToUniversity" HeaderText="Affilated to<br />University" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApprovedByAICTEForCurrentYear" HeaderText="Approved<br />By AICTE" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourtCaseRemark" HeaderText="Court Case<br />Remark" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalIntake" HeaderText="Intake<br />2024" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CAPSeatsPercentage" HeaderText="CAP Seats (%)<br />(Excluding Minority)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CAPSeats" HeaderText="CAP Seats<br />(Excluding Minority)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MinoritySeatsPercentage" HeaderText="CAP Seats (%)<br />(Minority)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MinoritySeats" HeaderText="CAP Seats<br />(Minority)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ILSeatsPercentage" HeaderText="Institutional<br />Seats (%)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ILSeats" HeaderText="Institutional<br />Seats" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" Font-Size="9px" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" Font-Size="9px" Wrap="false" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbDashboard1" runat="server" HeaderVisible="false" ScrollBars="Auto" Visible="false">
        <table class="AppFormTable">
            <tr>
                <th colspan="2">Dashboard</th>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvDashboardInstitute" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField DataField="CourseStatus1" HeaderText="Course Status">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Item" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" Wrap="false" />
                                <FooterStyle HorizontalAlign="Right" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseStatus2" HeaderText="Autonomy Status">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Item" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" Wrap="false" />
                                <FooterStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseStatus3" HeaderText="Minority Status">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Item" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" Wrap="false" />
                                <FooterStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalInstitutes" HeaderText="Total<br />Institutes" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" Wrap="false" />
                                <FooterStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                        <asp:BoundField DataField="IntakeApexBody" HeaderText="Intake 2024<br />(As per ApexBody)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="IntakeCurrentYear_AsPerAICTEAfterLastDate" HeaderText="Intake 2020<br />(As per AICTE)<br />(After Last Date)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="IntakeCurrentYear_AsPerGR" HeaderText="Intake 2024<br />(As per GR)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" Wrap="false" />
                                <FooterStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IntakeCurrentYear_AsPerUniversity" HeaderText="Intake 2024<br />(University Affiliated)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" Wrap="false" />
                                <FooterStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IntakeCurrentYear_AsPerDTEForAdmission" HeaderText="Intake 2024<br />(As per Court Order)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" Wrap="false" />
                                <FooterStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IntakeCurrentYear_FinalForAdmission" HeaderText="Intake 2024<br />(Final for Admission)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" Wrap="false" />
                                <FooterStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="9px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbDashboard2" runat="server" HeaderVisible="false" Visible="false">
        <table class="AppFormTable">
            <tr>
                <td colspan="2">
                    <table class="AppFormTable">
                        <tr>
                            <td style="width: 80%;" align="right">CAP (Excluding Minority) Intake</td>
                            <td style="width: 20%;" align="center">
                                <asp:Label ID="lblCAPIntake" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">CAP (Excluding Minority) Admitted</td>
                            <td align="center">
                                <asp:Label ID="lblCAPAdmitted" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Against CAP (Excluding Minority) Admitted</td>
                            <td align="center">
                                <asp:Label ID="lblACAPAdmitted" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">CAP (Excluding Minority) Vacancy</td>
                            <td align="center">
                                <asp:Label ID="lblCAPVacancy" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">CAP (Minority) Intake</td>
                            <td align="center">
                                <asp:Label ID="lblMIIntake" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">CAP (Minority) Admitted</td>
                            <td align="center">
                                <asp:Label ID="lblMIAdmitted" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Against CAP (Minority) Admitted</td>
                            <td align="center">
                                <asp:Label ID="lblAMIAdmitted" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">CAP (Minority) Vacancy</td>
                            <td align="center">
                                <asp:Label ID="lblMIVacancy" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Institute Intake</td>
                            <td align="center">
                                <asp:Label ID="lblILIntake" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Institute Admitted</td>
                            <td align="center">
                                <asp:Label ID="lblILAdmitted" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Institute Vacancy</td>
                            <td align="center">
                                <asp:Label ID="lblILVacancy" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Total Intake</td>
                            <td align="center">
                                <asp:Label ID="lblTotalIntake" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Total Admitted</td>
                            <td align="center">
                                <asp:Label ID="lblTotalAdmitted" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Total Vacancy</td>
                            <td align="center">
                                <asp:Label ID="lblTotalVacancy" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">JK Admitted</td>
                            <td align="center">
                                <asp:Label ID="lblJKAdmitted" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Over and Above Admitted</td>
                            <td align="center">
                                <asp:Label ID="lblOAAAdmitted" runat="server"></asp:Label></td>
                        </tr>
                    </table>
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
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
