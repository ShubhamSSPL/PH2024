<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSeatAcceptanceAcknowledgement.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmSeatAcceptanceAcknowledgement" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function OpenPopUpWindow() {
            window.open("frmPrintSeatAcceptanceAcknowledgement.aspx?PID=<% = PID %>", "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes");
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <input id="btnPrint1" type="button" runat="server" value="Print Seat Acceptance Acknowledgement" class="InputButton" onclick="javascript: OpenPopUpWindow()" />
                </td>
            </tr>
            <tr>
                <td>
                    <div id="Note">
                        <font color="red">
                            <ol class="list-text">
                                <b>Important Instructions for Printing :</b>
                                <li>Before printing acess the <b>"Page Setup"</b> Option from file menu and configure the following values :
	                                <ol type="a" class="list-text">
                                        <li>Left Margin = 0.25</li>
                                        <li>Right Margin = 0.25</li>
                                        <li>Top Margin = 0.25</li>
                                        <li>Bottom Margin = 0.25</li>
                                        <li>Header should be blank</li>
                                        <li>Footer should be blank</li>
                                    </ol>
                                </li>
                                <li>Make sure that the printer is ready with <b>A4</b> size papers in it.</li>
                                <li>The online system will print <b>Seat Acceptance Acknowledgement</b>.</li>
                                <li>Confirm whether you have received correct set of printout if not then please take the printouts again.</li>
                            </ol>
                        </font>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <td><font size="2"><b>First Year B. Pharm & Pharm. D Admissions <%=CurrentYear %></b></font></td>
                <td style="border-left-width: 0px;" align="right"><font size="2"><b>Seat Acceptance Acknowledgement</b></font></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="width: 10%; border-top-width: 0px; border-right-width: 0px;" align="center">
                    <img src="../Images/WebsiteLogo.png" alt="" style="width: 73px; height: auto" /></td>
                <td style="width: 80%; border-top-width: 0px; border-left-width: 0px;" align="center">
                    <b>
                        <img src="../Images/WebsiteLogoOld_Print.png" alt="" /><br />
                        <font size="4">G</font><font size="2">OVERNMENT</font> <font size="4">O</font><font size="2">F</font> <font size="4">M</font><font size="2">AHARASHTRA</font><br />
                        <font size="4">S</font><font size="2">TATE</font> <font size="4">C</font><font size="2">OMMON</font> <font size="4">E</font><font size="2">NTRANCE</font> <font size="4">T</font><font size="2">EST</font> <font size="4">C</font><font size="2">ELL,</font> <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font>
                        <br />
                        <font size="1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
                        <br />
                        <br />
                        Receipt-cum-Acknowledgement of Seat Acceptance Form for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>
                    </b>
                </td>
                <td style="width: 10%; border-top-width: 0px; border-left-width: 0px;" align="center">
                    <img src="../Images/ARAFINAL.png" alt="" style="width: 73px; height: auto" /></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="border-top-width: 0px;" align="center">
                    <font size="3">Application ID : 
                        <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;
                        Version No : 
                        <asp:Label ID="lblVersionNo" runat="server" Font-Bold="True"></asp:Label>
                    </font>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" colspan="4" align="left">Personal Details</th>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name</td>
                <td colspan="3">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Gender</td>
                <td style="width: 25%">
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">DOB (DD/MM/YYYY)</td>
                <td style="width: 25%">
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td>
                    <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Home University</td>
                <td>
                    <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category</td>
                <td>
                    <asp:Label ID="lblOriginalCategory" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Category for Admission</td>
                <td>
                    <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for EWS</td>
                <td>
                    <asp:Label ID="lblAppliedForEWS" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Applied for Orphan</td>
                <td>
                    <asp:Label ID="lblAppliedForOrphan" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Person with Disability</td>
                <td>
                    <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Defence Type</td>
                <td>
                    <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Minority Candidature Type</td>
                <td colspan="3">
                    <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC Physics</td>
                <td>
                    <asp:Label ID="lblHSCPhysicsPercentage" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">HSC Chemistry</td>
                <td>
                    <asp:Label ID="lblHSCChemistryPercentage" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC
                    <asp:Label ID="lblHSCSubject" runat="server"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lblHSCSubjectPercentage" runat="server" Font-Bold="true"></asp:Label></td>
                <%--<td align="right">HSC Bio-Technology</td>
                <td><asp:Label id="lblHSCBioTechnologyPercentage" runat="server" Font-Bold = "true"></asp:Label></td>--%>
            </tr>
            <tr>
                <td align="right">HSC Aggregate</td>
                <td>
                    <asp:Label ID="lblHSCTotalPercentage" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Diploma Aggregate</td>
                <td>
                    <asp:Label ID="lblDiplomaTotalPercentage" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">MH Merit No</td>
                <td>
                    <asp:Label ID="lblMHMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">MH Merit Percentile</td>
                <td>
                    <asp:Label ID="lblMHMeritScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">AI Merit No</td>
                <td>
                    <asp:Label ID="lblAIMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">AI Merit Percentile</td>
                <td>
                    <asp:Label ID="lblAIMeritScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblAllotmentDetailsCAPRound1" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="4">Provisional Allotment Details (CAP Round-I)</th>
            </tr>
            <tr>
                <td align="right">Institute Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteAllottedCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseAllottedCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCommentsCAPRound1">
                <td colspan="4">
                    <asp:Label ID="lblCommentsCAPRound1" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetailsCAPRound1" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">Provisional Allotment Details (CAP Round-I)</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Allotment Status</td>
                <td style="width: 75%">
                    <asp:Label ID="lblAllotmentStatusCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblAllotmentDetailsCAPRound2" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="4">Provisional Allotment Details (CAP Round-II)</th>
            </tr>
            <tr>
                <td align="right">Institute Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteAllottedCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseAllottedCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCommentsCAPRound2">
                <td colspan="4">
                    <asp:Label ID="lblCommentsCAPRound2" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetailsCAPRound2" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">Provisional Allotment Details (CAP Round-II)</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Allotment Status</td>
                <td style="width: 75%">
                    <asp:Label ID="lblAllotmentStatusCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblAllotmentDetailsCAPRound3" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="4">Provisional Allotment Details (CAP Round-III)</th>
            </tr>
            <tr>
                <td align="right">Institute Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteAllottedCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseAllottedCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCommentsCAPRound3">
                <td colspan="4">
                    <asp:Label ID="lblCommentsCAPRound3" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetailsCAPRound3" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">Provisional Allotment Details (CAP Round-III)</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Allotment Status</td>
                <td style="width: 75%">
                    <asp:Label ID="lblAllotmentStatusCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblAllotmentDetailsCAPRound4" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="4">Provisional Allotment Details (Separate Admission Round)</th>
            </tr>
            <tr>
                <td align="right">Institute Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteAllottedCAPRound4" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseAllottedCAPRound4" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound4" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound4" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCommentsCAPRound4">
                <td colspan="4">
                    <asp:Label ID="lblCommentsCAPRound4" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetailsCAPRound4" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">Provisional Allotment Details (Separate Admission Round)</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Allotment Status</td>
                <td style="width: 75%">
                    <asp:Label ID="lblAllotmentStatusCAPRound4" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblSeatAcceptanceStatusDetails" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="4">Seat Acceptance Details</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Status</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatAcceptanceStatus" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                <td style="width: 25%" align="right">Confirmation status</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatAcceptanceConfirmationDetails" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="left">Seat Acceptance Fee Details</th>
            </tr>
            <tr id="trFeeDetails1" runat="server">
                <td colspan="4">
                    <asp:GridView ID="gvFeeDetails" runat="server" AutoGenerateColumns="False" Width="100%" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="15%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDAmount" HeaderText="Amount">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDNumber" HeaderText="Reference Number" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="15%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDDate" HeaderText="Payment Date" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="12%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="BankName" HeaderText="Bank Name">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width = "30%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="FeeLockStatus" HeaderText="Payment Status">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="18%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="trFeeDetails2" runat="server">
                <td colspan="4">
                    <font color="red" size="3"><b>Seat Acceptance Fee Not Paid</b></font>
                </td>
            </tr>
            <tr id="trCVC" runat="server" visible="false">
                <%-- <td colspan = "4">
                      <b>$ - As you have submitted Receipt of Caste/Tribe validity certificate, you should submit
                          Caste/Tribe validity certificate till 16/07/2019 the last date of reporting to Admission Reporting
                          Center (ARC) as per Allotment of CAP Round-I to claim Category benefit for admission,
                          otherwise you will be treated as General Candidate.</b>
                  </td>--%>
                <%--  <td colspan = "4">
                        $ --Candidates should submit Caste Validity Certificate/ Tribe Validity Certificate before 10 August 2019 at Application Receipt Centers to claim Category benefit for admission, otherwise your admission shall stand cancelled.
                    </td>
                </tr>
                  <tr id = "trNCL" runat = "server" visible="false">
                    <td colspan = "4">
                        # -- Candidates should submit Non Creamy Layer Certificate valid up to 31/03/2019, at Application Receipt Centers to claim Category benefit for admission, otherwise your admission shall stand cancelled.
                    </td>--%>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="border-top-width: 0px;" colspan="2">
                    <center><b><font size="2">Declaration</font></b></center>
                    <br />
                    <p align="justify">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        I have read all the rules of admission and Information brochure for admission to UG courses <%=CurrentYear%> and on understanding these Rules, I have filled this Seat Acceptance Form for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>. The information given by me in this application is true to the best of my knowledge &amp; belief. If at later stage, it is found that I have furnished wrong information and/or submitted false certificate(s), I am aware that my admission stands cancelled and fees paid by me will be forfeited. Further I will be subject to legal and/or penal action as per the provisions of the law.
                    </p>
                </td>
            </tr>
            <tr>
                <td style="width: 60%">Place :
                </td>
                <td style="width: 40%" align="center" valign="bottom" rowspan="3">
                    <br />
                    <br />
                    <br />
                    Signature of Applicant
                    <br />
                    (<asp:Label ID="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
                </td>
            </tr>
            <tr>
                <td>Date :
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td>Printed On :
                    <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="2"><font size="2">For Office Use Only</font></th>
            </tr>
            <tr>
                <td>Confirmed On :
                    <asp:Label ID="lblConfirmedOn" runat="server" Font-Bold="True"></asp:Label></td>
                <td align="center" valign="bottom" rowspan="2">
                    <br />
                    <br />
                    <br />
                    Seal & Signature of the Issuing ARC Officer</td>
            </tr>
            <tr>
                <td>Confirmed By :
                    <asp:Label ID="lblConfirmedBy" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center" width="100%">
                    <input id="btnPrint2" type="button" runat="server" value="Print Seat Acceptance Acknowledgement" class="InputButton" onclick="javascript: OpenPopUpWindow()" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
