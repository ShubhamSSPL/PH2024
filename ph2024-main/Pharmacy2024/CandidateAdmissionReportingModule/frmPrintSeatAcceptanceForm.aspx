<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrintSeatAcceptanceForm.aspx.cs" Inherits="Pharmacy2024.CandidateAdmissionReportingModule.frmPrintSeatAcceptanceForm" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/InstructionCAPRound1.ascx" TagName="CAP1" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/InstructionCAPRound2.ascx" TagName="CAP2" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/InstructionCAPRound3.ascx" TagName="CAP3" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
    <link rel="stylesheet" href="../Styles/Style.css" type="text/css" />
    <style>
        .AppFormTable {
            padding: 0 3px;
            font-size: 10px;
        }

            .AppFormTable th {
                padding: 3px;
                font-size: 10px;
            }

            .AppFormTable td {
                padding: 3px;
                font-size: 10px;
            }

        .AppFormTableWithOutBorder {
            padding: 0 3px;
            font-size: 11px;
        }

            .AppFormTableWithOutBorder th {
                padding: 0 3px;
                font-size: 11px;
            }

            .AppFormTableWithOutBorder td {
                padding: 0 3px;
                font-size: 11px;
            }

        p {
            line-height: 13px;
            padding: 2px 2px 10px;
            margin: 0;
            font-size: 11px;
            font-family: Verdana;
            color: #000000;
        }
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <cc1:ShowMessage ID="shInfo" runat="server"></cc1:ShowMessage>
        <table class="AppFormTable">
            <tr>
                <td><font size="2"><b>First Year B. Pharm & Pharm. D Admissions <%=CurrentYear %></b></font></td>
                <td style="border-left-width: 0px;" align="right"><font size="2"><b>Seat Acceptance Form</b></font></td>
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
                <td align="right">Applied for TFWS</td>
                <td>
                    <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Minority Candidature Type</td>
                <td>
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
            <tr id="trBenefitTaken" runat="server">
                <td align="right">Benefit Taken
                </td>
                <td colspan="3">
                    <asp:Label ID="lblBenefitTaken" runat="server" Font-Bold="true"></asp:Label>
                </td>

            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Institute Coordinator Name</td>
                <td style="width: 25%">
                    <asp:Label ID="lblCoordinatorName1" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Coordinator Mobile No</td>
                <td style="width: 25%">
                    <asp:Label ID="lblCoordinatorMobile1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
             <tr id="trEligibilityRemark" runat="server" visible="false">
                <td colspan="4">
                    <asp:Label ID="lblEligibilityRemark" runat="server" ForeColor="Red"><b>Remark : </b></asp:Label></td>
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
            <tr id="trBenefitTaken2" runat="server">
                <td align="right">Benefit Taken
                </td>
                <td colspan="3">
                    <asp:Label ID="lblBenefitTaken2" runat="server" Font-Bold="true"></asp:Label>
                </td>

            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
                  <tr>
                <td style="width: 25%" align="right">Institute Coordinator Name</td>
                <td style="width: 25%">
                    <asp:Label ID="lblCoordinatorName2" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Coordinator Mobile No</td>
                <td style="width: 25%">
                    <asp:Label ID="lblCoordinatorMobile2" runat="server" Font-Bold="true"></asp:Label></td>
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
            <tr id="trBenefitTaken3" runat="server">
                <td align="right">Benefit Taken
                </td>
                <td colspan="3">
                    <asp:Label ID="lblBenefitTaken3" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
             <tr>
                <td style="width: 25%" align="right">Institute Coordinator Name</td>
                <td style="width: 25%">
                    <asp:Label ID="lblCoordinatorName3" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Coordinator Mobile No</td>
                <td style="width: 25%">
                    <asp:Label ID="lblCoordinatorMobile3" runat="server" Font-Bold="true"></asp:Label></td>
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
                <td style="width: 25%" align="right">Seat Acceptance Confirmation</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatAcceptanceConfirmationDetails" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
            </tr>
            <%--<tr>
                <td colspan="4" align="justify">
                    <font color="red" size="2">
                        <b>Note : </b>
                        At the time of reporting to ARC for confirming the allotted seat, the candidate shall produce all the original documents in support of the claims made in the application. In the event the candidate fails to produce the documents in support of the claim, so made in the application, the allotment shall stand cancelled automatically and the seat shall become available for allotment in further rounds.
                            <br />
                        <br />
                        Candidate shall produce the set of copies certified by SC for verification to ARC. The ARC shall verify set of copies certified by SC from Original and put ARC stamp with date & Signature and return original and verified documents along with Receipt–cum-Acknowledgement of Seat Acceptance. (Candidate shall submit SC and ARC stamped &verified set of documents to the Institute at the time of reporting)
                    </font>
                </td>
            </tr>--%>
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
                <%--  <td colspan = "4">
                        <b>$ - As you have submitted Receipt of Caste/Tribe validity certificate, you should submit
                            Caste/Tribe validity certificate till 16/07/2019 the last date of reporting to Admission Reporting
                            Center (ARC) as per Allotment of CAP Round-I to claim Category benefit for admission,
                            otherwise you will be treated as General Candidate.</b>
                    </td>--%>
            </tr>
                <tr runat="server" id="trCVCMsg" visible="false">
                <td colspan="4" style="color:red"> <b>The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category. 
                               
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

</b> </td>
            </tr>
            <%-- <tr id = "trNCL" runat = "server" visible="false">
                        <td colspan = "4">
                            # -- Candidates should submit Non Creamy Layer Certificate valid up to 31/03/2019, at Application Receipt Centers to claim Category benefit for admission, otherwise your admission shall stand cancelled.
                        </td>
                    </tr>--%>
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
                <td style="width: 40%" align="center" valign="bottom" rowspan="5">
                   <%-- <br />
                     <asp:Image ID="imgSignature1" width="133" Height="57" runat="server" AlternateText="Candidate Signature" />--%>
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
                <td>Confirmed On :
                    <asp:Label ID="lblConfirmedOn" runat="server" Font-Bold="True"></asp:Label></td>
                <%-- <td align = "center" valign = "bottom" rowspan = "2"><br /><br /><br />Seal & Signature of the Issuing ARC Officer</td>--%>
            </tr>
            <tr>
                <td>Confirmed By :
                    <asp:Label ID="lblConfirmedBy" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
        </table>
        <div style="page-break-after: always"></div>
        <table class="AppFormTableWithOutBorder">
            <tr>
                  <uc1:CAP1 ID="CAP1" runat="server" Visible="false" />
                        <uc2:CAP2 ID="CAP2" runat="server" Visible="false" />
                        <uc3:CAP3 ID="CAP3" runat="server" Visible="false" />
            </tr>
        </table>
    </form>
</body>
</html>


