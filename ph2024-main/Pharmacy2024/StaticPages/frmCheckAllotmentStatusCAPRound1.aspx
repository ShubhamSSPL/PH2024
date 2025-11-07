<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCheckAllotmentStatusCAPRound1.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCheckAllotmentStatusCAPRound1" %>

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
    <cc1:ContentBox ID="cbCheckResult" runat="server" HeaderText="Provisional Allotment Status of CAP Round-I">
        <table class="AppFormTable" width="40%" align="center" id="tblResult" runat="server">

            <tr>
                <th colspan="2">Enter Your Application ID and Date of Birth to View Your Provisional Allotment Status of CAP Round-I</th>
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
                        Provisional Allotment Status for Admission to First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions <%= AdmissionYear %> </b>
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
                    <asp:Label ID="lblFinalAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label></td>
                <%--<td align="right">Konkan Candidate</td>
                <td><asp:Label id="lblKonkanCandidate" runat="server" Font-Bold = "true"></asp:Label></td>--%>
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
                    <asp:Label ID="lblCAPRoundAllotted" runat="server" Font-Bold="true">I</asp:Label></td>
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
                <td colspan="4">
                    <%--<b>$ - As you have submitted Receipt of Caste/Tribe validity certificate, you should submit
                        Caste/Tribe validity certificate till the last date of reporting to Admission Reporting
                        Center (ARC) as per Allotment of CAP Round-I to claim Category benefit for admission,
                        otherwise you will be treated as General Candidate.</b>--%>
                </td>
            </tr>
            <%-- <tr id = "trNCL" runat = "server" visible="false">
                <td colspan = "4">
                    # -- Candidates should submit Non Creamy Layer Certificate valid up to 31/03/2019, at Application Receipt Centers to claim Category benefit for admission, otherwise your admission shall stand cancelled.
                </td>
            </tr>--%>
            <tr id="trInstructions" runat="server">
                <td colspan="4">
                    <center>
                        <font size="2"><b><u>Important Instructions to Candidates after Seat Allotment in respective CAP Rounds</u></b></font></center>
                    <br />
                    <p align="justify">
                        <b>The Competent Authority has prescribed the following methods for the activities post allotment: [ सक्षम प्राधिकाऱ्यामार्फत उमेदवारांसाठी जागा वाटप झाल्यानंतरची  उमेदवारांनी अवलंबवीण्याची कार्य पद्धती खालील प्रमाणे नमूद केल्या आहेत.]</b>
                    </p>
                    <br />
                    <ol class="list-text" style="list-style-type: none">
                        <li id="lifirstprefcap1" runat="server" visible="False">
                            <p align="justify">
                                <b>If a candidate is allotted the seat as per his first preference:-</b>
                            </p>
                            <ol type="a">
                                <%--  <li><p align = "justify">Such allotment shall be <b>auto freezed</b> and the candidate shall accept the allotment so made.</p></li>
                                <li><p align = "justify">Such candidate shall not be eligible for participation in the subsequent CAP rounds.</p></li>
                                <li><p align = "justify">Such candidates shall then report to ARC for verification of documents and payment of seat acceptance fee as per the notified schedule.</p></li>
                                <li><p align = "justify">Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat as per the notified schedule.</p></li>
                                <li><p align = "justify">If such candidate does not report to ARC for confirmation of seat acceptance, their claim on the allotted seat shall stand forfeited automatically; the allotment so made shall be the final allotment.</p></li>--%>
                                <li>
                                    <p align="justify">
                                        Check the allotment made in the CAP Round I through candidate’s Login & Verify the correctness of the seat allotment made to him/her in CAP round I is as per the Rules & Regulations.[जागावाटप झाल्यानंतर, उमेदवारांनी त्याला/तिला कॅपफेरीदरम्यान दिलेले जागा वाटप हे नियमांनुसार आहे किंवा नाही याची पडताळणी स्वत: च्या लॉग-इन मधून करावी.]
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Candidate shall ensure through login that his/her claims related with Qualifying Marks, category, gender, reservation, special reservation made by himself/herself in the applications form are correct and the relevant documents uploaded to substantiate his/her claims are authentic and correct. [उमेदवारांनी त्याच्या/ तिच्या लॉगिनमधून पात्रता गुण, प्रवर्ग, लिंग, आरक्षण, स्वत: हून केलेले स्वत: चे विशेष आरक्षण यासंबंधीचे त्याने/तिने केलेले दावे बरोबर आहेत याची खात्री करुन घ्यावी. तसेच त्याने/तिने दाखल केलेले दावे योग्य व बरोबर असल्याबाबतचे सुसंगत कागदपत्रे अपलोड केलेले आहेत याची खात्री करावी.]

                                    </p>
                                </li>
                                <%--<li>
                                    <p align="justify">
                                        Candidates who submitted ($)Caste/ Tribe Validity Certificate receipt,  (#)Non Creamy Layer Certificate (NCL) receipt and (@)Economically Weaker Section (EWS) Certificate receipt during the document verification and confirmation period should Upload ($)Caste/ Tribe Validity Certificate, (#)Non Creamy Layer Certificate and (@)Economically Weaker Section (EWS) Certificate between 09/12/2021 and 11/12/2021 Up to 3 P.M. through "Upload CVC/TVC,NCL,EWS Document" link from their individual login, otherwise these candidates shall be considered as Open category candidates and their allotment, if any, shall be cancelled. [ज्या उमेदवारांनी अर्ज भरतेवेळी ($)जात / जमात वैधता पावती, (#)नॉन क्रिमीलेयर पावती व (@) ई.डब्ल्यु.एस. पावती अपलोड केलेल्या आहेत, अशा सर्व उमेदवारांनी स्वताःच्या लॉगीन मधुन "Upload CVC/TVC,NCL,EWS Document" या लिंक द्वारे दिनांक 09/12/2021 ते दिनांक 11/12/2021 Up to 3 P.M. या कालावधीत मुळ प्रमाणपत्र अपलोड करावे. जर उमेदवारांनी मुळ प्रमाणपत्र अपलोड केले नाही तर अशा उमेदवारांचे प्रथम फेरीतील जागा वाटप रद्द करुन अशा उमेदवारांना पुढील प्रवेश फेरीत खुला ( Open) या प्रवर्गातुन पात्र केले जाईल.]

                                    </p>
                                </li>--%>
                                <%-- <li>
                                    <p align="justify">
                                       Candidates who uploaded Certificates (CVC/TVC,NCL & EWS) between 09/12/2021 and 11/12/2021 Up to 3 P.M. will be Verified through online by the Scrutiny Center. Until then, candidates will not be able to do self-Verification. Candidates will have the facility to do self-Verification & Seat Acceptance after e-Scrutiny of this certificate (CVC/TVC,NCL & EWS). Candidate who do Not Available their CVC/TVC, NCL and EWS certificate between 09/12/2021 and 11/12/2021 Up to 3 P.M. will have the facility to do Convert from Category to Open & Self-Verification only. Such Candidates and their allotment, if any, shall be cancelled.[ज्या उमेदवारांनी  मुळ प्रमाणपत्र (जात / जमात वैधता प्रमाणपत्र ,नॉन क्रिमीलेयर प्रमाणपत्र व ई.डब्ल्यु.एस. प्रमाणपत्र) दिनांक 09/12/2021 ते दिनांक 11/12/2021 Up to 3 P.M. या कालावधीत  अपलोड केले असतील असे प्रमाणपत्र ई-छाणनी केंद्राद्वारे ऑनलाईन तपासले जातील. तसेच जो पर्यंत सदर प्रमाणपत्रांची ई-छाणनी पुर्ण होत नाही तोपर्यंत उमेदवारांस स्वयः छाणनी व जागा स्विकृती करता येणार नाही. जर उमेदवाराकडे दिनांक 09/12/2021 ते दिनांक 11/12/2021 Up to 3 P.M. या कालावधीत मुळ प्रमाणपत्र उपलबध नसेल तर उमेदवारांस सामाजिक प्रवर्गातुन खुल्या प्रवर्गात रुपांतर करण्याची सुविधा उपलब्ध असेल व त्यानंतर उमेदवारांस स्वयः छाणनी करता येईल. अशा वेळी उमेदवाराचे प्रथम फेरीतील जागा वाटप रद्द करुन उमेदवारास पुढील प्रवेश फेरीत खुला प्रवर्गातुन पात्र केले जाईल.] 

                                    </p>
                                </li>--%>
                                <li>
                                    <p align="justify">
                                        The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                                        
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        After ensuring the correctness of the allotment, candidates shall pay the seat acceptance fee through online mode for the purpose of accepting the allotted seat.[जागावाटपाची अचूकता सुनिश्चित केल्यावर, उमेदवाराने दिलेली जागा स्वीकारण्याच्या उद्देशाने जागा स्वीकृती शुल्क ऑनलाईन पद्धतीने भरले पाहिजे.]
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        If allotment made to the candidate based on the claims made in the applications form, during self verification of the allotment, if candidate found that the claim made by him is not correct and he wants to correct the error, (errors as per the clause (e) of sub rule(4) of rule) the candidate shall report the grievance by e-Scrutiny Mode without fail.[जागावाटपाच्या स्वयं पडताळणी दरम्यान जर उमेदवारांला, उमेदवारी अर्जाच्या नमुन्यात केलेल्या दाव्याच्या आधारे केलेले जागावाटप व त्याने केलेला दावा योग्य नाही असे आढळून आले आणि त्याला त्याची चूक दुरुस्त करायची असल्यास (या नियमांच्या पोट-नियम (४) च्या खंड (ङ) नुसार, चुका दुरुस्त करण्याचे प्रयोजन), उमेदवाराने ई-स्क्रूटनी पध्दत यांद्वारे तक्रार/हरकत नोंदवावी.]

                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        In later stage, if it is found that the seat allotted to the candidate on the false claims made in the application by the candidate, then such allotment/admission taken in the allotted institute shall be cancelled automatically.[नंतरच्या टप्प्यात, उमेदवाराने अर्जात केलेल्या खोट्या दाव्यांवरून उमेदवाराला जागावाटप झालेले आहे असे आढळल्यास, असे जागावाटप/जागावाटप केलेल्या संस्थेत घेतलेला प्रवेश आपोआप रद्द होईल.]

                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        If a candidate is allotted the seat as per his first preference, such allotment shall be auto freezed and the candidate shall accept the allotment so made. Such candidates shall then be not eligible for participation in the subsequent CAP rounds. Such candidates follow the instructions given at clause 9(3)(a) above. Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat. If such candidate does not follow the instructions given in clause 9(3)(a) , their claim on the allotted seat shall stand forfeited automatically and the seat shall become available for fresh allotment. For such candidate, the allotment so made shall be the final allotment; [जर उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या पसंतीक्रमांकावरील जागेचे वाटप झाल्यास असे वाटप प्रणालीतून आपोआप गोठविले जाईल व उमेदवार या जागेचा स्वीकार करेल. असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्यास पात्र नसतील. असे उमेदवार वरील कलम 9(3)(a) मध्ये दिलेल्या सूचनांचे अनुसरण करतील. तदनंतर असे उमेदवार वाटप करण्यात आलेल्या जागेवर प्रवेश घेण्यासाठी वाटप करण्यात आलेल्या संस्थेमध्ये हजर होतील. अशा उमेदवाराने कलम 9(3)(a) मध्ये दिलेल्या सूचनांचे अनुसरण केले नाही तर ते त्यांना वाटप करण्यात आलेल्या  जागेवरील हक्क  आपोआप गमावतील आणि ती  जागा पुढील वाटपासाठी उपलब्ध होईल.  अशा उमेदवारांकरिता करण्यात आलेले हे जागावाटप अंतिम असेल]

                                    </p>
                                </li>
                                <%-- <li>
                                    <p align="justify">
                                        Reporting dates for Seat Acceptance in Candidate Login. <b>17/12/202020 to 18/12/2020</b>
                                    </p>
                                </li>--%>
                                <li>
                                    <p align="justify">
                                        Accepting to the offered seat by candidate through his/her login as per Allotment of CAP Round I on/before <b>14/10/2024 Up to 03.00 P.M.</b>
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Reporting dates for admission in the allotted Institute <b>11/10/2024 to 14/10/2024 Up to 5 P.M. </b>
                                        [वाटप केलेल्या संस्थेत प्रवेश घेण्याच्या तारखां: <b>11/10/2024 to 14/10/2024 Up to 5 P.M. </b>
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">For Any Admission related query Contact 9175108612, 18002660160 [कोणत्याही प्रवेश संबंधित माहितीसाठी 9175108612, 18002660160 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.</p>
                                </li>
                            </ol>
                        </li>
                        <li id="lisecondprefcap1" runat="server" visible="False">
                            <p align="justify">
                                <b>If a candidate is allotted seat other than his first preference:-</b>
                            </p>
                            <%-- <br />
                            <p align="justify">
                                Due to COVID-19 outbreak and present lockdown, and to curb its spread, the Competent Authority has prescribed the following methods for the activities post allotment: [कोविड -१९ चा उद्रेक आणि सध्याच्या लॉकडाऊनमुळे आणि त्याचा प्रसार रोखण्यासाठी सक्षम प्राधिकाऱ्यामार्फत उमेदवारांसाठी जागा वाटप झाल्यानंतरची  कार्य पद्धती खालील प्रमाणे नमूद केल्या आहेत.]
                            </p>--%>
                            <ol type="a">
                                <%--  <li><p align = "justify">If the candidate is satisfied with such allotment and do not wish to participate in further CAP rounds, such candidate can freeze the offered seat through candidate’s login.</p></li>
                                <li><p align = "justify"><u>However, the candidate has to exercise this deliberate option of freezing cautiously with full understanding.</u></p></li>
                                <li><p align = "justify">Once the candidate willingly freezes the allotted seat, such candidate shall then report to ARC for verification of documents and payment of seat acceptance fee as per the notified schedule. Such candidate shall then be not eligible for participation in the subsequent CAP rounds. The allotment so made shall be the final allotment.</p></li>
                                <li><p align = "justify">Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat as per the notified schedule.</p></li>
                                <li><p align = "justify">If such candidate does not report to ARC for confirmation of seat acceptance, their claim on the allotted seat shall stand forfeited automatically.</p></li>--%>
                                <li>
                                    <p align="justify">
                                        Check the allotment made in the CAP Round I through candidate’s Login & Verify the correctness of the seat allotment made to him/her in CAP round I is as per the Rules & Regulations.[जागावाटप झाल्यानंतर, उमेदवारांनी त्याला/तिला कॅपफेरीदरम्यान दिलेले जागा वाटप हे नियमांनुसार आहे किंवा नाही याची पडताळणी स्वत: च्या लॉग-इन मधून करावी.]

                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Candidate shall ensure through login that his/her claims related with Qualifying Marks, category, gender, reservation, special reservation made by himself/herself in the applications form are correct and the relevant documents uploaded to substantiate his/her claims are authentic and correct. [उमेदवारांनी त्याच्या/ तिच्या लॉगिनमधून पात्रता गुण, प्रवर्ग, लिंग, आरक्षण, स्वत: हून केलेले स्वत: चे विशेष आरक्षण यासंबंधीचे त्याने/तिने केलेले दावे बरोबर आहेत याची खात्री करुन घ्यावी. तसेच त्याने/तिने दाखल केलेले दावे योग्य व बरोबर असल्याबाबतचे सुसंगत कागदपत्रे अपलोड केलेले आहेत याची खात्री करावी.]

                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Candidates who have been allotted a seat other than the first preference given by the candidate and if the candidate is satisfied with such allotment and does not wish to participate in further CAP rounds, such candidate can freeze the offered seat through candidate’s login. [ज्या उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या पसंतीक्रमांकाखेरीज इतर पसंतीक्रमांकावरील जागेचे वाटप झाल्यास आणि उमेदवार या वाटपाने संतुष्ट असल्यास आणि केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्याची त्याची इच्छा नसल्यास उमेदवार त्याच्या लॉग-इन मधून त्यास देऊ केलेली जागा स्वतः गोठवू शकतो.अशा उमेदवारांकरिता करण्यात आलेले हे जागावाटप अंतिम असेल व असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्यास पात्र नसतील]

                                    </p>
                                </li>
                                <%-- <li>
                                    <p align="justify">
                                Candidates who submitted ($)Caste/ Tribe Validity Certificate receipt,  (#)Non Creamy Layer Certificate (NCL) receipt and (@)Economically Weaker Section (EWS) Certificate receipt during the document verification and confirmation period should Upload ($)Caste/ Tribe Validity Certificate, (#)Non Creamy Layer Certificate and (@)Economically Weaker Section (EWS) Certificate between 09/12/2021 and 11/12/2021 Up to 3 P.M. through "Upload CVC/TVC,NCL,EWS Document" link from their individual login, otherwise these candidates shall be considered as Open category candidates and their allotment, if any, shall be cancelled. [ज्या उमेदवारांनी अर्ज भरतेवेळी ($)जात / जमात वैधता पावती, (#)नॉन क्रिमीलेयर पावती व (@) ई.डब्ल्यु.एस. पावती अपलोड केलेल्या आहेत, अशा सर्व उमेदवारांनी स्वताःच्या लॉगीन मधुन "Upload CVC/TVC,NCL,EWS Document" या लिंक द्वारे दिनांक 09/12/2021 ते दिनांक 11/12/2021 Up to 3 P.M. या कालावधीत मुळ प्रमाणपत्र अपलोड करावे. जर उमेदवारांनी मुळ प्रमाणपत्र अपलोड केले नाही तर अशा उमेदवारांचे प्रथम फेरीतील जागा वाटप रद्द करुन अशा उमेदवारांना पुढील प्रवेश फेरीत खुला ( Open) या प्रवर्गातुन पात्र केले जाईल.]
                                    </p>
                                </li>--%>
                                <%--<li>
                                    <p align="justify">
                                    Candidates who uploaded Certificates (CVC/TVC,NCL & EWS) between 09/12/2021 and 11/12/2021 Up to 3 P.M. will be Verified through online by the Scrutiny Center. Until then, candidates will not be able to do self-Verification. Candidates will have the facility to do self-Verification & Seat Acceptance after e-Scrutiny of this certificate (CVC/TVC,NCL & EWS). Candidate who do Not Available their CVC/TVC, NCL and EWS certificate between 09/12/2021 and 11/12/2021 Up to 3 P.M. will have the facility to do Convert from Category to Open & Self-Verification only. Such Candidates and their allotment, if any, shall be cancelled.[ज्या उमेदवारांनी  मुळ प्रमाणपत्र (जात / जमात वैधता प्रमाणपत्र ,नॉन क्रिमीलेयर प्रमाणपत्र व ई.डब्ल्यु.एस. प्रमाणपत्र) दिनांक 09/12/2021 ते दिनांक 11/12/2021 Up to 3 P.M. या कालावधीत  अपलोड केले असतील असे प्रमाणपत्र ई-छाणनी केंद्राद्वारे ऑनलाईन तपासले जातील. तसेच जो पर्यंत सदर प्रमाणपत्रांची ई-छाणनी पुर्ण होत नाही तोपर्यंत उमेदवारांस स्वयः छाणनी व जागा स्विकृती करता येणार नाही. जर उमेदवाराकडे दिनांक 09/12/2021 ते दिनांक 11/12/2021 Up to 3 P.M. या कालावधीत मुळ प्रमाणपत्र उपलबध नसेल तर उमेदवारांस सामाजिक प्रवर्गातुन खुल्या प्रवर्गात रुपांतर करण्याची सुविधा उपलब्ध असेल व त्यानंतर उमेदवारांस स्वयः छाणनी करता येईल. अशा वेळी उमेदवाराचे प्रथम फेरीतील जागा वाटप रद्द करुन उमेदवारास पुढील प्रवेश फेरीत खुला प्रवर्गातुन पात्र केले जाईल.]
                                     </p>
                                </li>--%>
                                <li>
                                    <p align="justify">
                                        The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                                        
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Candidate who have been allotted seat other than first preference and accepted the seat as per the instructions given in clause 9(3)(c) then such candidates shall be eligible for participation in the subsequent rounds for betterment; [ज्या उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या पसंतीक्रमांकाखेरीज इतर पसंतीक्रमांकावरील जागेचे वाटप झाल्यास आणि उमेदवारास वाटप झालेली जागा कायम ठेऊन  पुढील फेरींमध्ये वरच्या पसंतीक्रमावरील जागा मिळविण्याकरिता सहभागी होण्यास पात्र असतील.या करिता उमेदवाराने वाटप झालेली जागा स्वीकारण्याच्या उद्देशाने जागा स्वीकृती शुल्क ऑनलाईन पद्धतीने भरले पाहिजे अन्यथा त्यांना वाटप झालेली जागा कायम ठेवता येणार नाही ]

                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        If allotment made to the candidate based on the claims made in the applications form, during self verification of the allotment, if candidate found that the claim made by him is not correct and he wants to correct the error, (errors as per the clause (e) of sub rule(4) of rule) the candidate shall report the grievance by e-Scrutiny Mode without fail.[जागावाटपाच्या स्वयं पडताळणी दरम्यान जर उमेदवारांला, उमेदवारी अर्जाच्या नमुन्यात केलेल्या दाव्याच्या आधारे केलेले जागावाटप व त्याने केलेला दावा योग्य नाही असे आढळून आले आणि त्याला त्याची चूक दुरुस्त करायची असल्यास (या नियमांच्या पोट-नियम (४) च्या खंड (ङ) नुसार, चुका दुरुस्त करण्याचे प्रयोजन), उमेदवाराने ई-स्क्रूटनी पध्दत यांद्वारे तक्रार/हरकत नोंदवावी.]
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        In later stage, if it is found that the seat allotted to the candidate on the false claims made in the application by the candidate, then such allotment/admission taken in the allotted institute shall be cancelled automatically.[नंतरच्या टप्प्यात, उमेदवाराने अर्जात केलेल्या खोट्या दाव्यांवरून उमेदवाराला जागावाटप झालेले आहे असे आढळल्यास, असे जागावाटप/जागावाटप केलेल्या संस्थेत घेतलेला प्रवेश आपोआप रद्द होईल.]

                                    </p>
                                </li>
                                <li>
                                    <p align="justify">Seat Acceptance Fees of Rs.1000/- (Rupees One Thousand only) shall be paid by online mode through candidate’s Login. It is treated as non-refundable processing fees.</p>
                                </li>
                                 <li>
                                    <p align="justify">
                                        Accepting to the offered seat by candidate through his/her login as per Allotment of CAP Round I on/before <b>14/10/2024 Up to 03.00 P.M.</b>
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Reporting dates for admission in the allotted Institute <b>11/10/2024 to 14/10/2024 Up to 5 P.M. </b>
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">For Any Admission related query Contact 9175108612, 18002660160 [कोणत्याही प्रवेश संबंधित माहितीसाठी 9175108612, 18002660160 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.</p>
                                </li>
                                <li id="lithirdprefcap1" runat="server" visible="False"></li>
                                <%-- <li>
                            <p align="justify">Reporting dates ARC for confirming the allotted seat at ARC<b> 18/07/2019 to 20/07/2019</b></p>
                        </li>
                        <li>
                            <p align="justify">At the time of reporting to ARC for confirming the allotted seat, the candidate shall produce all the original documents in support of the claims made in the application. In the event the candidate fails to produce the documents in support of the claim, so made in the application, the allotment shall stand cancelled automatically and the seat shall become available for allotment in further rounds.</p>
                        </li>
                        <li>
                            <p align="justify">Candidate shall produce the set of copies certified by SC for verification to ARC. The ARC shall verify set of copies certified by SC from Original and put ARC stamp with date & Signature and return original and verified documents along with Receipt–cum-Acknowledgement of Seat Acceptance. (Candidate shall submit SC and ARC stamped &verified set of documents to the Institute at the time of reporting)</p>
                        </li>--%>
                                <%--   <li>
                            <p align="justify">Seat Acceptance Fees of Rs.1000/- (Rupees One Thousand only) shall be paid by online mode through candidate’s Login. It is treated as non-refundable processing fees.</p>
                        </li>--%>
                                <%--<li>
                            <p align="justify">Candidate has to report to ARC only once for Seat acceptance, after the first time Allotment.</p>
                        </li>--%>
                            </ol>
                        </li>
                    </ol>
                    <center><font size="2"><b>*******************</b></font></center>
                </td>

            </tr>
            <tr id="trInstructionforNotAllotment" runat="server" visible="false">
                <td colspan="4">
                    <center>
                        <font size="2"><b><u>Important Instructions to Candidates in respective CAP Rounds</u></b></font></center>
                    <br />
                    <ol class="list-text" style="list-style-type: none">
                        <li id="linotAllotted" runat="server" visible="False">
                            <p align="justify">
                                <b>General Instructions for all Candidate who have not allotted any seat in Subsequent Rounds:-</b>
                            </p>
                            <ol type="a">
                                <li>
                                    <p align="justify">
                                        You have not allotted any Seat in CAP Round I. You are eligible for the next CAP Round. [तुम्हाला कॅप राउंड १ मध्ये जागेचे वाटप झालेले नाही. तुम्ही पुढील कॅप राउंड मध्ये भाग घेण्यास पात्र आहात.]
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        For detail read Rule No 9 from the Information Brochure. [तपशीलवार माहितीसाठी माहितीपुस्तिकेतील नियम क्रमांक 9 वाचा.]
                                    </p>
                                </li>
                                <%--<li>
                                    <p align="justify">                                        
                                    Candidates who submitted ($)Caste/ Tribe Validity Certificate receipt,  (#)Non Creamy Layer Certificate (NCL) receipt and (@)Economically Weaker Section (EWS) Certificate receipt during the document verification and confirmation period should Upload ($)Caste/ Tribe Validity Certificate, (#)Non Creamy Layer Certificate and (@)Economically Weaker Section (EWS) Certificate between 09/12/2021 and 11/12/2021 Up to 3 P.M. through "Upload CVC/TVC,NCL,EWS Document" link from their individual login, otherwise these candidates shall be considered as Open category candidates and their allotment, if any, shall be cancelled. [ज्या उमेदवारांनी अर्ज भरतेवेळी ($)जात / जमात वैधता पावती, (#)नॉन क्रिमीलेयर पावती व (@) ई.डब्ल्यु.एस. पावती अपलोड केलेल्या आहेत, अशा सर्व उमेदवारांनी स्वताःच्या लॉगीन मधुन "Upload CVC/TVC,NCL,EWS Document" या लिंक द्वारे दिनांक 09/12/2021 ते दिनांक 11/12/2021 Up to 3 P.M. या कालावधीत मुळ प्रमाणपत्र अपलोड करावे. जर उमेदवारांनी मुळ प्रमाणपत्र अपलोड केले नाही तर अशा उमेदवारांचे प्रथम फेरीतील जागा वाटप रद्द करुन अशा उमेदवारांना पुढील प्रवेश फेरीत खुला ( Open) या प्रवर्गातुन पात्र केले जाईल.]
                                    </p>
                                </li>--%>
                                <%-- <li>
                                    <p align="justify">
                                    Candidates who uploaded Certificates (CVC/TVC,NCL & EWS) between 09/12/2021 and 11/12/2021 Up to 3 P.M. will be Verified through online by the Scrutiny Center. Until then, candidates will not be able to do self-Verification. Candidates will have the facility to do self-Verification & Seat Acceptance after e-Scrutiny of this certificate (CVC/TVC,NCL & EWS). Candidate who do Not Available their CVC/TVC, NCL and EWS certificate between 09/12/2021 and 11/12/2021 Up to 3 P.M. will have the facility to do Convert from Category to Open & Self-Verification only. Such Candidates and their allotment, if any, shall be cancelled.[ज्या उमेदवारांनी  मुळ प्रमाणपत्र (जात / जमात वैधता प्रमाणपत्र ,नॉन क्रिमीलेयर प्रमाणपत्र व ई.डब्ल्यु.एस. प्रमाणपत्र) दिनांक 09/12/2021 ते दिनांक 11/12/2021 Up to 3 P.M. या कालावधीत  अपलोड केले असतील असे प्रमाणपत्र ई-छाणनी केंद्राद्वारे ऑनलाईन तपासले जातील. तसेच जो पर्यंत सदर प्रमाणपत्रांची ई-छाणनी पुर्ण होत नाही तोपर्यंत उमेदवारांस स्वयः छाणनी व जागा स्विकृती करता येणार नाही. जर उमेदवाराकडे दिनांक 09/12/2021 ते दिनांक 11/12/2021 Up to 3 P.M. या कालावधीत मुळ प्रमाणपत्र उपलबध नसेल तर उमेदवारांस सामाजिक प्रवर्गातुन खुल्या प्रवर्गात रुपांतर करण्याची सुविधा उपलब्ध असेल व त्यानंतर उमेदवारांस स्वयः छाणनी करता येईल. अशा वेळी उमेदवाराचे प्रथम फेरीतील जागा वाटप रद्द करुन उमेदवारास पुढील प्रवेश फेरीत खुला प्रवर्गातुन पात्र केले जाईल.]
                                    </p>
                                </li>--%>
                                <li>
                                    <p align="justify">
                                        The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                                       
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                                    </p>
                                </li>
                                <li>
                                    <p align="justify">For Any Admission related query Contact 9175108612, 18002660160 [कोणत्याही प्रवेश संबंधित माहितीसाठी 9175108612, 18002660160 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.</p>
                                </li>
                            </ol>
                        </li>
                        <li id="trNosubmittedOptions" runat="server" visible="False">
                            <p align="justify">
                                <b>General Instructions for all Candidate who have not Submitted options for CAP Rounds
                                    :-</b>
                            </p>
                            <ol type="a">
                                <li>
                                    <p align="justify">
                                        You have not submitted options for CAP Round I for seat allotment, hence No Seat is Allotted. You are eligible for next CAP Round. [तुम्ही कॅप राउंड १ मध्ये पर्याय सबमिट केले नसल्यामुळे तुम्हाला जागेचे वाटप झालेले नाही. तुम्ही पुढील कॅप राउंड मध्ये भाग घेण्यास पात्र आहात.]
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">For detail read Rule No 9 from the Information Brochure. [तपशीलवार माहितीसाठी माहितीपुस्तिकेतील नियम क्रमांक 9 वाचा.]</p>
                                </li>
                                <li>
                                    <p align="justify">For Any Admission related query Contact 9175108612, 18002660160  [कोणत्याही प्रवेश संबंधित माहितीसाठी  9175108612, 18002660160 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.</p>
                                </li>
                            </ol>
                        </li>
                    </ol>
                    <center>
                        <font size="2"><b>*******************</b></font></center>
                </td>

            </tr>
            <tr>
                <td colspan="4"><font color="red"><b>Published On : 10/10/2024</b></font></td>
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
