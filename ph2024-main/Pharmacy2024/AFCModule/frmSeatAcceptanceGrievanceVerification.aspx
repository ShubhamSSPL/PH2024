<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" CodeBehind="frmSeatAcceptanceGrievanceVerification.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmSeatAcceptanceGrievanceVerification" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/CandidateBasicInfoWithPhoto.ascx" TagName="BInfo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
        input[type="radio"] {
            /*margin: 10px 10px;*/
            margin-right: 8px;
        }

        .txtAlign {
            text-align: center;
        }

        #layoutSidenav #layoutSidenav_content {
            margin-left: 0px;
        }

        .pdfobject-container img {
            width: 100%;
        }
    </style>
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }

        function numfor(a) {
            return a.toFixed(2);
            //Left(a, 5);
        }

        function sscMathMarksChanged() {
            if (document.getElementById("rightContainer_txtSSCMathMarksObtained").value != "" && document.getElementById("rightContainer_txtSSCMathMarksOutOf").value != "") {
                document.getElementById("rightContainer_txtSSCMathPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_txtSSCMathMarksObtained").value) / parseFloat(document.getElementById("rightContainer_txtSSCMathMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_txtSSCMathPercentage").value = "";
            }
        }
        function sscTotalMarksChanged() {
            if (document.getElementById("rightContainer_txtSSCTotalMarksObtained").value != "" && document.getElementById("rightContainer_txtSSCTotalMarksOutOf").value != "") {
                document.getElementById("rightContainer_txtSSCTotalPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_txtSSCTotalMarksObtained").value) / parseFloat(document.getElementById("rightContainer_txtSSCTotalMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_txtSSCTotalPercentage").value = "";
            }
        }

        function hscPhysicsMarksChanged() {
            if (document.getElementById("rightContainer_txtHSCPhysicsMarksObtained").value != "" && document.getElementById("rightContainer_txtHSCPhysicsMarksOutOf").value != "") {
                document.getElementById("rightContainer_txtHSCPhysicsPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_txtHSCPhysicsMarksObtained").value) / parseFloat(document.getElementById("rightContainer_txtHSCPhysicsMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_txtHSCPhysicsPercentage").value = "";
            }
        }
        function hscChemistryMarksChanged() {
            if (document.getElementById("rightContainer_txtHSCChemistryMarksObtained").value != "" && document.getElementById("rightContainer_txtHSCChemistryMarksOutOf").value != "") {
                document.getElementById("rightContainer_txtHSCChemistryPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_txtHSCChemistryMarksObtained").value) / parseFloat(document.getElementById("rightContainer_txtHSCChemistryMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_txtHSCChemistryPercentage").value = "";
            }
        }
        function hscMathMarksChanged() {
            if (document.getElementById("rightContainer_txtHSCMathMarksObtained").value != "" && document.getElementById("rightContainer_txtHSCMathMarksOutOf").value != "") {
                document.getElementById("rightContainer_txtHSCMathPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_txtHSCMathMarksObtained").value) / parseFloat(document.getElementById("rightContainer_txtHSCMathMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_txtHSCMathPercentage").value = "";
            }
        }
        function hscBiologyMarksChanged() {
            if (document.getElementById("rightContainer_txtHSCBiologyMarksObtained").value != "" && document.getElementById("rightContainer_txtHSCBiologyMarksOutOf").value != "") {
                document.getElementById("rightContainer_txtHSCBiologyPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_txtHSCBiologyMarksObtained").value) / parseFloat(document.getElementById("rightContainer_txtHSCBiologyMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_txtHSCBiologyPercentage").value = "";
            }
        }

        function hscSubjectMarksChanged() {
            if (document.getElementById("rightContainer_txtHSCSubjectMarksObtained").value != "" && document.getElementById("rightContainer_txtHSCSubjectMarksOutOf").value != "") {
                document.getElementById("rightContainer_txtHSCSubjectPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_txtHSCSubjectMarksObtained").value) / parseFloat(document.getElementById("rightContainer_txtHSCSubjectMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_txtHSCSubjectPercentage").value = "";
            }
        }

        function hscEnglishMarksChanged() {
            if (document.getElementById("rightContainer_txtHSCEnglishMarksObtained").value != "" && document.getElementById("rightContainer_txtHSCEnglishMarksOutOf").value != "") {
                document.getElementById("rightContainer_txtHSCEnglishPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_txtHSCEnglishMarksObtained").value) / parseFloat(document.getElementById("rightContainer_txtHSCEnglishMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_txtHSCEnglishPercentage").value = "";
            }
        }
        function hscTotalMarksChanged() {
            if (document.getElementById("rightContainer_txtHSCTotalMarksObtained").value != "" && document.getElementById("rightContainer_txtHSCTotalMarksOutOf").value != "") {
                document.getElementById("rightContainer_txtHSCTotalPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_txtHSCTotalMarksObtained").value) / parseFloat(document.getElementById("rightContainer_txtHSCTotalMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_txtHSCTotalPercentage").value = "";
            }
        }

        function diplomaTotalMarksChanged() {
            if (document.getElementById("rightContainer_txtDiplomaTotalMarksObtained").value != "" && document.getElementById("rightContainer_txtDiplomaTotalMarksOutOf").value != "") {
                document.getElementById("rightContainer_txtDiplomaTotalPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_txtDiplomaTotalMarksObtained").value) / parseFloat(document.getElementById("rightContainer_txtDiplomaTotalMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_txtDiplomaTotalPercentage").value = "";
            }
        }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }

        function EndRequestHandler() {
            if (document.getElementById("rightContainer_trSSCMath") != null) {
                sscMathMarksChanged();
            }
            if (document.getElementById("rightContainer_trSSCTotal") != null) {
                sscTotalMarksChanged();
            }

            if (document.getElementById("rightContainer_trPhysics") != null) {
                hscPhysicsMarksChanged();
            }
            if (document.getElementById("rightContainer_trHSCChemistry") != null) {
                hscChemistryMarksChanged();
            }
            if (document.getElementById("rightContainer_trHSCMathematics") != null) {
                hscMathMarksChanged();
            }
            if (document.getElementById("rightContainer_trHSCBiology") != null) {
                hscBiologyMarksChanged();
            }
            if (document.getElementById("rightContainer_trHSCSubject") != null) {
                hscSubjectMarksChanged();
            }
            if (document.getElementById("rightContainer_trHSCEnglish") != null) {
                hscEnglishMarksChanged();
            }
            if (document.getElementById("rightContainer_trHSCTotal") != null) {
                hscTotalMarksChanged();
            }
            if (document.getElementById("rightContainer_trDiplomaMarks") != null) {
                diplomaTotalMarksChanged();
            }
        }

        window.onload = load;
    </script>
    <script src="../Scripts/HintBox.js" type="text/javascript" lang="javascript"></script>
    <script src="../Scripts/jquery.js"></script>

    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Candidate Details">
        <uc1:BInfo ID="CandidateBasicInformation" runat="server" />
    </cc1:ContentBox>
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <img src="../Images/BigProgress.gif" alt="" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Candidate and Allotment Details">
        <table class="AppFormTable ">
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
                    <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label>
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
                <td align="right">Seat Acceptance Confirmation at ARC</td>
                <td>
                    <asp:Label ID="lblSeatAcceptanceConfirmationDetails" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label></td>
            </tr>
        </table>

        <br />
    </cc1:ContentBox>
    <%--  <asp:UpdatePanel ID="UpdatePanel21" runat="server">
        <ContentTemplate>--%>
    <div class="">
        <table class="AppFormTable table-responsive">
            <tr>
                <td style="vertical-align: top;">
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6  ">
                            <table class="AppFormTable table-responsive">
                                <tr>
                                    <th align="left">Grievance Details to be Verified by SC</th>

                                </tr>
                                <tr>
                                    <td>
                                        <table class="AppFormTable" style="width: 100%;">
                                            <tr>
                                                <th>List of Parameters to be Verified by SC </th>
                                                <th>Current Status </th>
                                                <th>Need to Correct As </th>
                                            </tr>
                                            <tr id="trGender" runat="server">
                                                <td align="right"><b>Gender </b></td>
                                                <td>
                                                    <asp:Label ID="lblCurrentGender" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:Label ID="lblGenderStatus" runat="server">Not Selected </asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trCandidature" runat="server">
                                                <td align="right"><b>Candidature Type</b> </td>
                                                <td>
                                                    <asp:Label ID="lblCurrentCandidature" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCandidatureStatus" runat="server">Not Selected </asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trCategory" runat="server">
                                                <td align="right"><b>Category for Admission</b> </td>
                                                <td>
                                                    <asp:Label ID="lblCurrentCategory" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCategoryStatus" runat="server">Not Selected </asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trEWS" runat="server">
                                                <td align="right"><b>Applied for EWS</b> </td>
                                                <td>
                                                    <asp:Label ID="lblCurrentEWS" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEWSStatus" runat="server">Not Selected </asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trPH" runat="server">
                                                <td align="right"><b>Applied for PWD</b> </td>
                                                <td>
                                                    <asp:Label ID="lblCurrentPWD" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPWDStatus" runat="server">Not Selected </asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trDef" runat="server">
                                                <td align="right"><b>Applied for Defence</b> </td>
                                                <td>
                                                    <asp:Label ID="lblCurrentDEF" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDefStatus" runat="server">Not Selected </asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trorphan" runat="server">
                                                <td align="right"><b>ORPHAN</b> </td>
                                                <td>
                                                    <asp:Label ID="lblCurrentOrphan" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOrphanStatus" runat="server">Not Selected </asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trTFWS" runat="server">
                                                <td align="right"><b>Applied for TFWS</b> </td>
                                                <td>
                                                    <asp:Label ID="lblCurrentTFWS" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTFWSStatus" runat="server">Not Selected </asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trLinguisticMinority" runat="server">
                                                <td align="right"><b>Linguistic Minority</b> </td>
                                                <td>
                                                    <asp:Label ID="lblCurrentLinguistic" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblLinguisticMinorityStatus" runat="server">Not Selected </asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trReligiousMinority" runat="server">
                                                <td align="right"><b>Religious Minority </b></td>
                                                <td>
                                                    <asp:Label ID="lblCurrentReligious" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblReligiousMinorityStatus" runat="server">Not Selected </asp:Label>
                                                </td>
                                            </tr>
                                            <%-- <tr id="trIntermediateGradeDrawing" runat="server">
                                <td  align="right"><b>Intermediate Grade Drawing  </b> </td>
                                <td >
                                    <asp:Label ID="lblCurrentIntermediateGradeDrawing" runat="server"></asp:Label>
                                </td> 
                                <td>
                                    <asp:Label ID="lblIntermediateGradeDrawingStatus" runat="server">Not Selected </asp:Label>
                                </td>
                            </tr>--%>
                                        </table>
                                        <br />
                                        <table class="AppFormTable" style="width: 100%;">
                                            <tr id="trQualificationPH" runat="server">
                                                <th>List of Parameters to be Make Corrections </th>
                                                <th style="text-align: center;"><b>Current Status
                                                    <br />
                                                    (Marks Obtained / Marks Outof) </b></th>
                                                <th style="text-align: center;"><b>Correct Marks Obtained</b></th>
                                                <th style="text-align: center;"><b>Correct Marks Outof </b></th>
                                                <th style="text-align: center;"><b>Correct Percentage</b></th>
                                            </tr>
                                            <tr id="trSSCMath" runat="server">
                                                <td align="right">SSC Mathematics Marks
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="lblCurrentSSCMathematics" runat="server"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtSSCMathMarksObtained" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter SSC Mathematics Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvSSCMathMarksObtained" runat="server" Display="None" ControlToValidate="txtSSCMathMarksObtained" ErrorMessage="Please Enter SSC Mathematics Marks Obtained."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revSSCMathMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtSSCMathMarksObtained" ErrorMessage="SSC Mathematics Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                                    <asp:CompareValidator ID="cvSSCMathMarksObtained" runat="server" Display="None" ControlToValidate="txtSSCMathMarksOutOf" ErrorMessage="SSC Mathematics Marks Obtained should be less than or equal to SSC Mathematics Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtSSCMathMarksObtained"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cvSSCMathMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtSSCMathMarksObtained" ErrorMessage="SSC Mathematics Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtSSCMathMarksOutOf" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter SSC Mathematics Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvSSCMathMarksOutOf" runat="server" Display="None" ControlToValidate="txtSSCMathMarksOutOf" ErrorMessage="Please Enter SSC Mathematics Marks OutOf."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revSSCMathMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtSSCMathMarksOutOf" ErrorMessage="SSC Mathematics Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtSSCMathPercentage" runat="server" CssClass="txtAlign width-password" ReadOnly="true" MaxLength="5"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="trSSCTotal" runat="server">
                                                <td align="right">SSC Aggregate Marks
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="lblCurrentSSCTotal" runat="server"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtSSCTotalMarksObtained" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter SSC Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvSSCTotalMarksObtained" runat="server" Display="None" ControlToValidate="txtSSCTotalMarksObtained" ErrorMessage="Please Enter SSC Aggregate Marks Obtained."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revSSCTotalMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtSSCTotalMarksObtained" ErrorMessage="SSC Aggregate Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                                    <asp:CompareValidator ID="cvSSCTotalMarksObtained" runat="server" Display="None" ControlToValidate="txtSSCTotalMarksOutOf" ErrorMessage="SSC Aggragate Marks Obtained should be less then or equal to SSC Aggragate Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtSSCTotalMarksObtained"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cvSSCTotalMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtSSCTotalMarksObtained" ErrorMessage="SSC Aggragate Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtSSCTotalMarksOutOf" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter SSC Aggragate Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvSSCTotalMarksOutOf" runat="server" Display="None" ControlToValidate="txtSSCTotalMarksOutOf" ErrorMessage="Please Enter SSC Aggragate Marks OutOf."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revSSCTotalMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtSSCTotalMarksOutOf" ErrorMessage="SSC Aggragate Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtSSCTotalPercentage" runat="server" CssClass="txtAlign width-password" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>


                                            <tr id="trPhysics" runat="server">
                                                <td align="right">HSC Physics Marks
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="lblCurrentHSCPhysics" runat="server"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCPhysicsMarksObtained" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Physics Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvHSCPhysicsMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksObtained" ErrorMessage="Please Enter HSC Physics Marks Obtained."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCPhysicsMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCPhysicsMarksObtained" ErrorMessage="HSC Physics Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                                    <asp:CompareValidator ID="cvHSCPhysicsMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksOutOf" ErrorMessage="HSC Physics Marks Obtained should be less then or equal to HSC Physics Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCPhysicsMarksObtained"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cvHSCPhysicsMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksObtained" ErrorMessage="HSC Physics Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCPhysicsMarksOutOf" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Physics Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvHSCPhysicsMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksOutOf" ErrorMessage="Please Enter HSC Physics Marks OutOf."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCPhysicsMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCPhysicsMarksOutOf" ErrorMessage="HSC Physics Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCPhysicsPercentage" runat="server" CssClass="txtAlign width-password" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="trHSCChemistry" runat="server">
                                                <td align="right">HSC Chemistry Marks
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="lblCurrentHSCChemistry" runat="server"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCChemistryMarksObtained" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Chemistry Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvHSCChemistryMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksObtained" ErrorMessage="Please Enter HSC Chemistry Marks Obtained."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCChemistryMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCChemistryMarksObtained" ErrorMessage="HSC Chemistry Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                                    <asp:CompareValidator ID="cvHSCChemistryMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksOutOf" ErrorMessage="HSC Chemistry Marks Obtained should be less then or equal to HSC Chemistry Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCChemistryMarksObtained"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cvHSCChemistryMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksObtained" ErrorMessage="HSC Chemistry Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCChemistryMarksOutOf" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Chemistry Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvHSCChemistryMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksOutOf" ErrorMessage="Please Enter HSC Chemistry Marks OutOf."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCChemistryMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCChemistryMarksOutOf" ErrorMessage="HSC Chemistry Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCChemistryPercentage" runat="server" CssClass="txtAlign width-password" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="trHSCBiology" runat="server">
                                                <td align="right">HSC Biology Marks
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="lblCurrentHSCBiology" runat="server"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCBiologyMarksObtained" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Biology Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <asp:Label ID="lblHSCBiologyMarksObtainedStar" runat="server" ForeColor="Red"><sup>*</sup></asp:Label>
                                                    <asp:RequiredFieldValidator ID="rfvHSCBiologyMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCBiologyMarksObtained" ErrorMessage="Please Enter HSC Biology Marks Obtained."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCBiologyMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCBiologyMarksObtained" ErrorMessage="HSC Biology Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                                    <asp:CompareValidator ID="cvHSCBiologyMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCBiologyMarksOutOf" ErrorMessage="HSC Biology Marks Obtained should be less then or equal to HSC Biology Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCBiologyMarksObtained"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cvHSCBiologyMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCBiologyMarksObtained" ErrorMessage="HSC Biology Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                    <%--<asp:CustomValidator ID="cvMathBiology" runat="server" ClientValidationFunction="checkMathBiology" Display="None" ErrorMessage="Please Enter HSC Mathematics OR Biology Marks Obtained."></asp:CustomValidator>--%>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCBiologyMarksOutOf" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Biology Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <asp:Label ID="lblHSCBiologyMarksOutOfStar" runat="server" ForeColor="Red"><sup>*</sup></asp:Label>
                                                    <asp:RequiredFieldValidator ID="rfvHSCBiologyMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCBiologyMarksOutOf" ErrorMessage="Please Enter HSC Biology Marks OutOf."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCBiologyMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCBiologyMarksOutOf" ErrorMessage="HSC Biology Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCBiologyPercentage" runat="server" CssClass="txtAlign width-password" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="trHSCMathematics" runat="server">
                                                <td align="right">HSC Mathematics Marks</td>
                                                <td align="center">
                                                    <asp:Label ID="lblCurrentHSCMathematics" runat="server"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCMathMarksObtained" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Mathematics Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <asp:Label ID="lblHSCMathMarksObtainedStar" runat="server" ForeColor="Red"><sup>*</sup></asp:Label>
                                                    <asp:RequiredFieldValidator ID="rfvHSCMathMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCMathMarksObtained" ErrorMessage="Please Enter HSC Mathematics Marks Obtained."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCMathMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCMathMarksObtained" ErrorMessage="HSC Mathematics Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                                    <asp:CompareValidator ID="cvHSCMathMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCMathMarksOutOf" ErrorMessage="HSC Mathematics Marks Obtained should be less then or equal to HSC Mathematics Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCMathMarksObtained"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cvHSCMathMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCMathMarksObtained" ErrorMessage="HSC Mathematics Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCMathMarksOutOf" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Mathematics Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <asp:Label ID="lblHSCMathMarksOutOfStar" runat="server" ForeColor="Red"><sup>*</sup></asp:Label>
                                                    <asp:RequiredFieldValidator ID="rfvHSCMathMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCMathMarksOutOf" ErrorMessage="Please Enter HSC Mathematics Marks OutOf."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCMathMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCMathMarksOutOf" ErrorMessage="HSC Mathematics Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCMathPercentage" runat="server" CssClass="txtAlign width-password" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="trHSCEnglish" runat="server">
                                                <td align="right">HSC English Marks</td>
                                                <td align="center">
                                                    <asp:Label ID="lblCurrentHSCEnglish" runat="server"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCEnglishMarksObtained" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC English Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvHSCEnglishMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksObtained" ErrorMessage="Please Enter HSC English Marks Obtained."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCEnglishMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCEnglishMarksObtained" ErrorMessage="HSC English Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                                    <asp:CompareValidator ID="cvHSCEnglishMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksOutOf" ErrorMessage="HSC English Marks Obtained should be less then or equal to HSC English Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCEnglishMarksObtained"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cvHSCEnglishMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksObtained" ErrorMessage="HSC English Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCEnglishMarksOutOf" MaxLength="5" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC English Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvHSCEnglishMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksOutOf" ErrorMessage="Please Enter HSC English Marks OutOf."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCEnglishMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCEnglishMarksOutOf" ErrorMessage="HSC English Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCEnglishPercentage" runat="server" CssClass="txtAlign width-password" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="trHSCTotal" runat="server">
                                                <td align="right">HSC Aggregate Marks </td>
                                                <td align="center">
                                                    <asp:Label ID="lblCurrentHSCAggregate" runat="server"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCTotalMarksObtained" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvHSCTotalMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCTotalMarksObtained" ErrorMessage="Please Enter HSC Aggregate Marks Obtained."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCTotalMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCTotalMarksObtained" ErrorMessage="HSC Aggregate Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                                    <asp:CompareValidator ID="cvHSCTotalMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCTotalMarksOutOf" ErrorMessage="HSC Aggregate Marks Obtained should be less then or equal to HSC Aggregate Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCTotalMarksObtained"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cvHSCTotalMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCTotalMarksObtained" ErrorMessage="HSC Aggregate Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCTotalMarksOutOf" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Aggregate Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvHSCTotalMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCTotalMarksOutOf" ErrorMessage="Please Enter HSC Aggregate Marks OutOf."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revHSCTotalMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCTotalMarksOutOf" ErrorMessage="HSC Aggregate Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtHSCTotalPercentage" runat="server" CssClass="txtAlign width-password" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr id="trDiplomaMarks" runat="server">
                                                <td align="center">Diploma Aggregate Marks </td>
                                                <td align="center">
                                                    <asp:Label ID="lblCurrentDiplomaMarks" runat="server"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtDiplomaTotalMarksObtained" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Diploma Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvDiplomaTotalMarksObtained" runat="server" Display="None" ControlToValidate="txtDiplomaTotalMarksObtained" ErrorMessage="Please Enter Diploma Aggregate Marks Obtained."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revDiplomaTotalMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtDiplomaTotalMarksObtained" ErrorMessage="Diploma Aggregate Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                                    <asp:CompareValidator ID="cvDiplomaTotalMarksObtained" runat="server" Display="None" ControlToValidate="txtDiplomaTotalMarksOutOf" ErrorMessage="Diploma Aggregate Marks Obtained should be less then or equal to Diploma Aggregate Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtDiplomaTotalMarksObtained"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cvDiplomaTotalMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtDiplomaTotalMarksObtained" ErrorMessage="Diploma Aggregate Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtDiplomaTotalMarksOutOf" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Diploma Aggregate Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvDiplomaTotalMarksOutOf" runat="server" Display="None" ControlToValidate="txtDiplomaTotalMarksOutOf" ErrorMessage="Please Enter Diploma Aggregate Marks OutOf."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revDiplomaTotalMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtDiplomaTotalMarksOutOf" ErrorMessage="Diploma Aggregate Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtDiplomaTotalPercentage" runat="server" CssClass="txtAlign width-password" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trDiplomaMarksTypeCGPA">
                                                <td align="center">Diploma CGPA</td>
                                                <td align="center">
                                                    <asp:Label ID="lblCurrentDiplomaCGPA" runat="server"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtDiplomaCGPAObtained" runat="server" MaxLength="5" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Diploma CGPA Obtained. It should be less than CGPA Outof and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvDiplomaCGPAObtained" runat="server" ErrorMessage="Please Enter Diploma CGPA Obtained." ControlToValidate="txtDiplomaCGPAObtained" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="cvDiplomaCGPAObtained" runat="server" ErrorMessage="Diploma CGPA Obtained should be less than CGPA Outof." ControlToCompare="txtDiplomaCGPAObtained" ControlToValidate="txtDiplomaCGPAOutOf" Display="None" Operator="GreaterThanEqual" Type="Double"></asp:CompareValidator>
                                                    <asp:CompareValidator ID="cvDiplomaCGPAObtainedZero" runat="server" ErrorMessage="Diploma CGPA Obtained Should be Greater than Zero." ControlToValidate="txtDiplomaCGPAObtained" Display="None" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                    <asp:RegularExpressionValidator ID="revDiplomaCGPAObtained" runat="server" ErrorMessage="Diploma CGPA Obtained should be Numeric." ControlToValidate="txtDiplomaCGPAObtained" Display="None" ValidationExpression="[0-9.]+"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtDiplomaCGPAOutOf" runat="server" MaxLength="5" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Diploma CGPA OutOf. It should be greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvDiplomaCGPAOutOf" runat="server" ErrorMessage="Please Enter Diploma CGPA OutOf." ControlToValidate="txtDiplomaCGPAOutOf" Display='none'></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="cvDiplomaCGPAOutOfZero" runat="server" ErrorMessage="Diploma CGPA OutOf Should be Greater than Zero." ControlToValidate="txtDiplomaCGPAOutOf" Display="None" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                    <asp:RegularExpressionValidator ID="revDiplomaCGPAOutOf" runat="server" ErrorMessage="Diploma CGPA OutOf should be Numeric." ControlToValidate="txtDiplomaCGPAOutOf" Display="None" ValidationExpression="[0-9.]+"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtDiplomaCGPAPercentage" runat="server" MaxLength="5" CssClass="txtAlign width-password" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Diploma CGPA Equivalent Percentage. It should be greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                                    <font color="red"><sup>*</sup></font>
                                                    <asp:RequiredFieldValidator ID="rfvDiplomaCGPAPercentage" runat="server" ErrorMessage="Please Enter Diploma CGPA Equivalent Percentage." ControlToValidate="txtDiplomaCGPAPercentage" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="cvDiplomaCGPAPercentage" runat="server" ErrorMessage="Diploma CGPA Equivalent Percentage Should be Greater than Zero." ControlToValidate="txtDiplomaCGPAPercentage" Display="None" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                                    <asp:RegularExpressionValidator ID="revDiplomaCGPAPercentage" runat="server" ErrorMessage="Diploma CGPA Equivalent Percentage should be Numeric." ControlToValidate="txtDiplomaCGPAPercentage" Display="None" ValidationExpression="[0-9.]+"></asp:RegularExpressionValidator>
                                                    <asp:RangeValidator ID="rvDiplomaCGPAPercentage" runat="server" ControlToValidate="txtDiplomaCGPAPercentage" ErrorMessage="Please Enter Diploma CGPA Equivalent Percentage Below 100." Display="None" MaximumValue="100" MinimumValue="0.01" Type="Double"></asp:RangeValidator>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>

                                </tr>
                            </table>
                        </div>
                        <div class="col-sm-6" id="tdDocuments">
                            <h2 class="font-weight-bold text-primary">Document for Data Verification</h2>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table class="AppFormTableWithOutBorder table-responsive">
                                        <tr id="trdocument" runat="server" visible="false">
                                            <td>
                                                <asp:Label ID="lbldoclistname" runat="server" Width="250px" Font-Bold="true">Document List : </asp:Label>
                                                <asp:RadioButtonList ID="ReadoDocumentList" runat="server" OnSelectedIndexChanged="ReadoDocumentList_CheckedChanged" AutoPostBack="true" CssClass="radioButtonListDocVerification"></asp:RadioButtonList>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblLoadDocumentName"></asp:Label>
                                                <div runat="server" id="divBotton">
                                                    <button type="button" onclick="zoomin()">
                                                        <img src="../Images/zoom-in.png" width="15px" height="15px"></button>
                                                    <button type="button" onclick="zoomout()">
                                                        <img src="../Images/zoom-out.png" width="15px" height="15px">
                                                    </button>
                                                </div>
                                                <div runat="server" id="divLoadDocument" class="pdfobject-container"></div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>



    <br />
    <center>
        <table class="AppFormTable" style="width: 80%;">
            <tr>
                <th align="left">List of Verified Documents</th>
            </tr>
            <tr>
                <td>
                    <font color="red">Documents shown in red color are not uploaded. </font>
                    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid" OnRowDataBound="gvDocuments_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="8%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="57%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                            <%-- <asp:TemplateField HeaderText="Verified">
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rbnYes" runat="server" Text="&nbsp;Verified" GroupName="YesNo" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Not Accepted">
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rbnNo" runat="server" Text="&nbsp;Not Accepted" GroupName="YesNo" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="15%" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                    <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" onclick="javascript:OpenViewDocumentPopUp(this)" runat="server" />
                                    <asp:HiddenField ID="hidFURL" runat="server" Value='<%# Bind("FilePath") %>' />
                                    <asp:HiddenField ID="hidDID" runat="server" Value='<%# Bind("DocumentTransID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsSubmitted" runat="server" Text='<%# Eval("IsSubmittedAtAFC") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocumentID" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnImgUrl" runat="server" Value='<%# Bind("FilePath") %>' />
                                    <asp:HiddenField ID="hdnImgByteArray" runat="server" Value='<%# Bind("FilePath") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" Width="1%"/>
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </center>
    <br />
    <center>
        <table class="AppFormTable" style="width: 80%;">
            <%-- <tr>
            <td>
                <asp:RadioButton ID="rbnYes" runat="server" Text="&nbsp;Yes, Candidate's Request is Valid. Edit Candidate Details, Cancel Allotment and Make Eligible for Next Round." GroupName="YesNo" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="rbnNo" runat="server" Text="&nbsp;No, Candidates Request is Invalid, Candidate need to Accept Alloted Seat." GroupName="YesNo" />
            </td>
        </tr>--%>
            <tr>
                <td align="right">Select Request Status</td>
                <td>
                    <font color="red"><sup>*</sup></font>
                    <asp:RadioButtonList ID="rbLstRequest" runat="server" Width="100%">
                        <asp:ListItem Value="Yes" Text=""> </asp:ListItem>
                        <asp:ListItem Value="No" Text="No, Candidate's request is rejected. Candidate need not to edit the details. Candidate shall proceed for Seat Acceptance."></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="rfvrbLstRequest" runat="server" ForeColor="Red" Font-Bold="true" ControlToValidate="rbLstRequest" ErrorMessage="Please choose One option for Request eighter Valid or Invalid!!!"> </asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td align="right">Comments/Remark for Candidate</td>
                <td>
                    <font color="red"><sup>*</sup></font>
                    <asp:TextBox ID="txtComments" runat="server" Width="95%" Height="50px" MaxLength="250" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtComments" ControlToValidate="txtComments" runat="server" ErrorMessage="Please Enter Comments/Remark for Candidate." ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                    <%--<asp:Label ID ="lblStar" runat="server" Text="*" ForeColor="Red"></asp:Label>--%> 
                </td>
            </tr>
        </table>
    </center>
    <br />
    <table class="AppFormTableWithOutBorder">
        <tr>
            <td align="center">
                <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" OnClick="btnProceed_Click" CssClass="InputButton"></asp:Button></td>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="false" />
        </tr>
    </table>

    <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>

    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr>
                <td>
                    <div class="modal-body">
                        <div runat="server" id="divButtonPopup">
                            <button type="button" onclick="zoominPopUp()">
                                <img src="../Images/zoom-in.png" width="15px" height="15px"></button>
                            <button type="button" onclick="zoomoutPopUp()">
                                <img src="../Images/zoom-out.png" width="15px" height="15px">
                            </button>
                        </div>
                        <div id="divDocument" class="doc-container"></div>
                    </div>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <script>
        if (document.getElementById("rightContainer_trSSCMath") != null) {
            sscMathMarksChanged();
        }
        if (document.getElementById("rightContainer_trSSCTotal") != null) {
            sscTotalMarksChanged();
        }

        if (document.getElementById("rightContainer_trPhysics") != null) {
            hscPhysicsMarksChanged();
        }
        if (document.getElementById("rightContainer_trHSCChemistry") != null) {
            hscChemistryMarksChanged();
        }
        if (document.getElementById("rightContainer_trHSCMathematics") != null) {
            hscMathMarksChanged();
        }
        if (document.getElementById("rightContainer_trHSCBiology") != null) {
            hscBiologyMarksChanged();
        }
        if (document.getElementById("rightContainer_trHSCSubject") != null) {
            hscSubjectMarksChanged();
        }
        if (document.getElementById("rightContainer_trHSCEnglish") != null) {
            hscEnglishMarksChanged();
        }
        if (document.getElementById("rightContainer_trHSCTotal") != null) {
            hscTotalMarksChanged();
        }
        if (document.getElementById("rightContainer_trDiplomaMarks") != null) {
            diplomaTotalMarksChanged();
        }

        function zoominPopUp() {
            var GFG = document.getElementById('<%=imgPopUpDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth + 100) + "px";
        }

        function zoomoutPopUp() {
            var GFG = document.getElementById('<%=imgPopUpDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth - 100) + "px";
        }

        function OpenViewDocumentPopUp(cntrl) {

            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            var corrRow = cntrl.parentNode.parentNode;
            var filePath = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            //corrRow.cells[corrRow.cells.length - 5].innerText
            var byteStream = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[1].value;
            document.getElementById('lblDocumentName').innerHTML = corrRow.cells[1].innerText;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + byteStream + '">';
                    document.getElementById('divDocument').style.overflow = "auto";
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('divDocument').innerHTML = '<iframe src="' + byteStream + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                    document.getElementById('divDocument').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }

        function zoomin() {
            var GFG = document.getElementById('<%=imgDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth + 100) + "px";
        }

        function zoomout() {
            var GFG = document.getElementById('<%=imgDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth - 100) + "px";
        }

        function LoadDocument(filePath, DocumentName) {
            document.getElementById('<%=lblLoadDocumentName.ClientID %>').innerHTML = "";
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            var dsResponse = Pharmacy2024.ViewMyDocument.GetCandidateDocumentAsBase64(filePath);
            var byteStream = dsResponse.value;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divBotton.ClientID %>').style.display = 'inline';
                    document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<img id="imgDoc" runat="server" src="' + byteStream + '">';
                    document.getElementById('<%=divLoadDocument.ClientID %>').style.overflow = "auto";
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<iframe src="' + byteStream + '" autostart="true" style="width:100%;height:450px;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divBotton.ClientID %>').style.display = 'none';
                    document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:450px;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }

        function CheckBoxRequired_ClientValidate(sender, e) {
            e.IsValid = jQuery(".AcceptedAgreement input:checkbox").is(':checked');

        }
    </script>
</asp:Content>
