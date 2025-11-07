<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAllotmentDetails.aspx.cs" Inherits="Pharmacy2024.CandidateAdmissionReportingModule.frmAllotmentDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Allotment Details">
        <div class="table-responsive">
        <table class="AppFormTable">
            <tr>
                <th align="left" colspan="4">Personal Details</th>
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
                <td>
                    <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Applied for TFWS</td>
                <td>
<asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold = "true"></asp:Label>
                </td>
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
            </div>
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
                <th style="border-top-width: 0px;" align="left" colspan="2">Seat Acceptance Details</th>
            </tr>
            <tr>
                <td style="width: 40%" align="right">Seat Acceptance Status</td>
                <td style="width: 60%">
                    <asp:Label ID="lblSeatAcceptanceStatus" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Seat Acceptance Confirmation</td>
                <td>
                    <asp:Label ID="lblSeatAcceptanceConfirmationDetails" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label></td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed to Seat Acceptance >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
