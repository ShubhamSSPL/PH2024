<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCheckAllotmentStatusCAPRound3.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCheckAllotmentStatusCAPRound3" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/epoch_classes.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_cbCheckResult_txtDOB").value;
            if (dateStr.length == 0) {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat);
            if (matchArray == null) {
                args.IsValid = false;
                return;
            }
            month = matchArray[3];
            day = matchArray[1];
            year = matchArray[5];
            if (year < 1900 || year >= 2080) {
                args.IsValid = false;
                return;
            }
            if (month < 1 || month > 12) {
                args.IsValid = false;
                return;
            }
            if (day < 1 || day > 31) {
                args.IsValid = false;
                return;
            }
            if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
                args.IsValid = false;
                return;
            }
            if (month == 2) {
                var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
                if (day > 29 || (day == 29 && !isleap)) {
                    args.IsValid = false;
                    return;
                }
            }
        }
        function Printit() {
            document.getElementById("topdiv").style.display = 'none';
            document.getElementById("left1").style.display = 'none';
            document.getElementById("footer1").style.display = 'none';
            document.getElementById("btnPrint").style.display = 'none';
            document.getElementById("rightContainer1").style.width = '900px';

            window.print();

            document.getElementById("topdiv").style.display = '';
            document.getElementById("left1").style.display = '';
            document.getElementById("footer1").style.display = '';
            document.getElementById("btnPrint").style.display = '';
            document.getElementById("rightContainer1").style.width = '79.7%';
        }
    </script>
    <cc1:ContentBox ID="cbCheckResult" runat="server" HeaderText="Provisional Allotment Status of CAP Round-III">
        <table class="AppFormTable" width="40%" align="center" id="tblResult" runat="server">
            <tr>
                <th colspan="2">Enter Your Application ID and Date of Birth to View Your Provisional Allotment Status of CAP Round-III</th>
            </tr>
            <tr>
                <td style="width: 50%" align="right">Enter Application ID</td>
                <td style="width: 50%">
                    <asp:TextBox ID="txtApplicationID" runat="server" Width="110px" MaxLength="10"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ErrorMessage="Please Enter Your Application ID." ControlToValidate="txtApplicationID" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Enter Date Of Birth</td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" Width="110px" MaxLength="10"></asp:TextBox>
                    <font color="red"><sup>*</sup></font> (DD/MM/YYYY)
                    <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB" Display="None" ErrorMessage="Please Enter Your Date of Birth."></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper Date of Birth."></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <center>
                        <asp:Button ID="btnProceed" runat="server" Text="SUBMIT" CssClass="InputButton" OnClick="btnProceed_Click" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    </center>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbDisplayResult" runat="server" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
                <td style="width: 10%; border-right-width: 0px;" align="center">
                    <img src="../Images/WebsiteLogo.png" alt="" style="width: 73px; height: auto" />
                </td>
                <td style="width: 80%; border-left-width: 0px; border-right-width: 0px;" align="center">
                    <b>
                        <img src="../Images/WebsiteLogoOld_Print.png" alt="" /><br />
                        <font size="4">G</font><font size="2">OVERNMENT</font> <font size="4">O</font><font
                            size="2">F</font> <font size="4">M</font><font size="2">AHARASHTRA</font><br />
                        <font size="4">S</font><font size="2">TATE</font> <font size="4">C</font><font size="2">OMMON</font>
                        <font size="4">E</font><font size="2">NTRANCE</font> <font size="4">T</font><font
                            size="2">EST</font> <font size="4">C</font><font size="2">ELL,</font> <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font>
                        <br />
                        <font size="1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001.
                        (M.S.)</font>
                        <br />
                        <br />
                        Provisional Allotment Letter for Admission to First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions <%= AdmissionYear %>
                </td>
                <td style="width: 10%; border-left-width: 0px;" align="center">
                    <img src="../Images/ARAFINAL.png" alt="" style="width: 73px; height: auto" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4"><font size="2">Application ID :
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True"></asp:Label></font></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="4">Personal Details</th>
            </tr>
            <tr>
                <td align="right">Candidate's Name</td>
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
                <td align="right">Orphan Candidate</td>
                <td>
                    <asp:Label ID="lblIsOrphan" runat="server" Font-Bold="true"></asp:Label></td>
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
                <td colspan="3">
                    <asp:Label ID="lblFinalAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">Linguistic Minority</td>
                <td>
                    <asp:Label ID="lblLinguisticMinority" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Religious Minority</td>
                <td>
                    <asp:Label ID="lblReligiousMinority" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <th align="left" colspan="4">Provisional Allotment Details</th>
            </tr>
            <tr id="trInstituteAllotted" runat="server">
                <td align="right">Institute Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteAllotted" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCourseAllotted" runat="server">
                <td align="right">Course Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseAllotted" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trChoiceCodeAllotted" runat="server">
                <td align="right">Choice Code Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblChoiceCodeAllotted" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trBenefitTaken" runat="server">
                <td align="right">Benefit Taken
                </td>
                <td colspan="3">
                    <asp:Label ID="lblBenefitTaken" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trSeatTypeAllotted" runat="server">
                <td align="right">Seat Type Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblSeatTypeAllotted" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trPreferenceNoAllotted" runat="server">
                <td align="right">Preference No. Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblPreferenceNoAllotted" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCAPRoundAllotted" runat="server">
                <td align="right">CAP Round Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblCAPRoundAllotted" runat="server" Font-Bold="true">III</asp:Label></td>
            </tr>
            <tr id="trMeritNo" runat="server">
                <td align="right">Merit No.</td>
                <td colspan="3">
                    <asp:Label ID="lblMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trMeritMarks" runat="server">
                <td align="right">Merit Percentile</td>
                <td colspan="3">
                    <asp:Label ID="lblMeritScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trChoiceCodeStatusDetails" runat="server">
                <td colspan="4">
                    <asp:Label ID="lblChoiceCodeStatusDetails" runat="server"></asp:Label></td>
            </tr>
            <tr id="trNotAllotted" runat="server">
                <td align="right">Allotment Status</td>
                <td colspan="3">
                    <p align="justify">
                        <asp:Label ID="lblNotAllotted" runat="server" Font-Bold="true"></asp:Label>
                    </p>
                </td>
            </tr>
            <tr id="trCVC" runat="server" visible="false">
                <%-- <td colspan = "4">
                    $ -- Candidates should submit Caste Validity Certificate/ Tribe Validity Certificate before 10 August 2019 at Application Receipt Centers to claim Category benefit for admission, otherwise your admission shall stand cancelled.
                </td>--%>
            </tr>
            <tr id="trNCL" runat="server" visible="false">
                <%-- <td colspan = "4">
                    # -- Candidates should submit Non Creamy Layer Certificate valid up to 31/03/2019, at Application Receipt Centers to claim Category benefit for admission, otherwise your admission shall stand cancelled.
                </td>--%>
            </tr>
            <tr runat="server" id="trCVCMsg" visible="false">
                <td class="AppFormTable" colspan="4" style="color: red; font-weight: bold">
                    <font size="2">Note : The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                        
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                    </font>
                </td>
            </tr>
            <tr id="trBeterment" runat="server" visible="False">
                <td colspan="4">
                    <center>
                        <font size="2"><b><u>Important Instructions to Candidates after Seat Allotment in respective CAP Rounds</u></b></font></center>
                    <br />
                    <ol class="list-text" style="list-style-type: none">
                        <li id="li1" runat="server">
                            <p align="justify"><b>Instructions for Candidate who have got Betterment in CAP Rounds III :-</b></p>
                            <ol type="a">
                                <li>
                                    <p align="justify">You have got betterment in CAP Round III. Your earlier allotment in CAP Round II is automatically cancelled. </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        If Candidate got Betterment or no change in CAP Round III in such case, if the Candidate wishes to take Admission in the allotted Institute, then the Candidate is required to change the Seat Acceptance status to ‘FREEZE’ using the provided button(Choose Seat Acceptance Option (Freeze/Betterment (Not Freeze)) for CAP-III) in their login.
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">There shall be no further betterment option available to the candidate after Round III. The allotment made in Round III for participating candidates in Round III shall be final;</p>
                                </li>
                                <li>
                                    <p align="justify">It is mandatory for the candidate to report to the Allotted Institute for confirmation of admission.</p>
                                </li>
                                <li>
                                    <p align="justify">If such Candidate does not report to the allotted Institute within scheduled time, then his allotted seat shall be cancelled and the seat shall be available for Institute level admissions.</p>
                                </li>
                                <li>
                                    <p align="justify">For Any Admission related query Contact +91-9175108612, 18002660160  [कोणत्याही प्रवेश संबंधित माहितीसाठी +91-9175108612, 18002660160 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.</p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Reporting dates for admission in the allotted Institution <b>13/12/2024 to 16/12/2024 Up to 05:00 P.M.</b>
                                </li>
                            </ol>
                        </li>
                    </ol>
                    <center>
                        <font size="2"><b>*******************</b></font></center>
                </td>
            </tr>

            <tr id="trNoBeterment" runat="server" visible="False">
                <td colspan="4">
                    <center><font size="2"><b><u>Important Instructions to Candidates after Seat Allotment in respective CAP Rounds</u></b></font></center>
                    <br />
                    <ol class="list-text" style="list-style-type: none">
                        <li id="li2" runat="server">
                            <p align="justify">
                                <b>Instructions for Candidate who have got No Change in CAP Rounds III: -</b>
                            </p>
                            <ol type="a">
                                <li>
                                    <p align="justify">You did not get Betterment in CAP Round III. Your earlier allotment in CAP Round II is retained.</p>
                                </li>
                                <li>
                                    <p align="justify">
                                        If Candidate got Betterment or no change in CAP Round III in such case, if the Candidate wishes to take Admission in the allotted Institute, then the Candidate is required to change the Seat Acceptance status to ‘FREEZE’ using the provided button(Choose Seat Acceptance Option (Freeze/Betterment (Not Freeze)) for CAP-III) in their login.
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">There shall be no further betterment option available to the candidate after Round III. The allotment retained in Round III for participating candidates in Round III shall be final.</p>
                                </li>
                                <li>
                                    <p align="justify">It is mandatory for the candidate to report to the Allotted Institute for confirmation of admission.</p>
                                </li>
                                <li>
                                    <p align="justify">If such Candidate does not report to the allotted Institute within scheduled time, then his allotted seat shall be cancelled and the seat shall be available for Institute level admissions.</p>
                                </li>
                                 <li>
                                    <p align="justify">For Any Admission related query Contact +91-9175108612, 18002660160  [कोणत्याही प्रवेश संबंधित माहितीसाठी +91-9175108612, 18002660160 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.</p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Reporting dates for admission in the allotted Institution <b>13/12/2024 to 16/12/2024 Up to 05:00 P.M.</b>
                                </li>
                            </ol>
                        </li>
                    </ol>
                    <center>
                        <font size="2"><b>*******************</b></font></center>
                </td>
            </tr>

            <tr id="trEligibleButNotFilledOptionForm" runat="server" visible="False">
                <td colspan="4">
                    <center>
                        <font size="2"><b><u>Important Instructions to Candidates in respective CAP Rounds</u></b></font></center>
                    <br />
                    <ol class="list-text" style="list-style-type: none">
                        <li id="li5" runat="server">
                            <p align="justify">
                                <b>Candidate did not Confirm Options Form in CAP Rounds III: -</b>
                            </p>
                            <ol type="a">
                                <li>
                                    <p align="justify">You have not Submited and Confirmed Option Form for CAP Round III for seat allotment.</p>
                                </li>                                
                                <li>
                                    <p align="justify">You are eligible for Institutional Round scheduled from 18/12/2024 to 23/12/2024</p>
                                </li>
                                 <li>
                                    <p align="justify">For Any Admission related query Contact +91-9175108612, 18002660160  [कोणत्याही प्रवेश संबंधित माहितीसाठी +91-9175108612, 18002660160 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.</p>
                                </li>
                            </ol>
                        </li>
                    </ol>
                    <center><font size="2"><b>*******************</b></font></center>
                </td>
            </tr>

            <tr id="trSubmitOptionNoAllotment" runat="server" visible="False">
                <td colspan="4">
                    <center><font size="2"><b><u>Important Instructions to Candidates after Seat Allotment in respective CAP Rounds</u></b></font></center>
                    <br />
                    <ol class="list-text" style="list-style-type: none">
                        <li id="li6" runat="server">
                            <p align="justify">
                                <b>Instructions for Candidates who have Submitted Option Form but not allotted any seat in CAP Rounds III: -</b>
                            </p>
                            <ol type="a">
                                <li>
                                    <p align="justify">No Seat Allotted to you in CAP Round III.</p>
                                </li>
                                <li>
                                    <p align="justify">Kindly check the cutoff list for CAP Round III.</p>
                                </li>                                
                                <li>
                                    <p align="justify">You are eligible for Institutional Round scheduled from 18/12/2024 to 23/12/2024</p>
                                </li>
                                 <li>
                                    <p align="justify">For Any Admission related query Contact +91-9175108612, 18002660160  [कोणत्याही प्रवेश संबंधित माहितीसाठी +91-9175108612, 18002660160 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.</p>
                                </li>
                            </ol>
                        </li>
                    </ol>
                    <center>
                        <font size="2"><b>*******************</b></font></center>
                </td>
            </tr>

            <tr id="trFirstTime" runat="server" visible="False">
                <td colspan="4">
                    <center><font size="2"><b><u>Important Instructions to Candidates after Seat Allotment in respective CAP Rounds</u></b></font></center>
                    <br />
                    <ol class="list-text" style="list-style-type: none">
                        <li id="li3" runat="server">
                            <p align="justify"><b>Candidate who have got allotment in CAP Rounds III (First Time):-</b></p>
                            <ol type="a">
                                <li>
                                    <p align="justify">There shall be no further betterment option available to the candidate after Round III. The allotment made and/or allotment retained in Round III for participating candidates in Round III shall be final.</p>
                                </li>
                                <li>
                                    <p align="justify">It is mandatory for the candidate complete self-verification and seat acceptance and then report to the Allotted Institute for confirmation of admission.</p>
                                </li>
                                <li>
                                    <p align="justify">You will have to pay seat acceptance fees of Rs.1000/- as a processing fee.</p>
                                </li>
                                <li>
                                    <p align="justify">If such Candidate do not complete self-verification and seat acceptance and/or Report to the allotted Institute within scheduled time, then his allotted seat shall be cancelled and the seat shall be available for Institute level admissions.</p>
                                </li>
                                 <li>
                                    <p align="justify">For Any Admission related query Contact +91-9175108612, 18002660160  [कोणत्याही प्रवेश संबंधित माहितीसाठी +91-9175108612, 18002660160 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.</p>
                                </li>
                                <li>
                                    <p align="justify">Reporting dates for admission in the allotted Institution <b>13/12/2024 to 16/12/2024 Up to 05:00 P.M.</b></p>
                                </li>
                            </ol>
                        </li>
                    </ol>
                    <center><font size="2"><b>*******************</b></font></center>
                </td>
            </tr>

            <tr>
                <td colspan="4"><font color="red"><b>Published On : 12/12/2024</b></font></td>
            </tr>
        </table>
        <br />
        <div id="divPrint" runat="server" width="100%">
            <center>
                <input id="btnPrint" type="button" value="  Print  " class="InputButton" onclick="Printit()" />
            </center>
        </div>
        <br />
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        var dp_cal;
        if (document.getElementById('rightContainer_cbCheckResult_txtDOB') != null) {
            window.onload = function () {
                dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_cbCheckResult_txtDOB'));
            };
        }
    </script>
</asp:Content>
