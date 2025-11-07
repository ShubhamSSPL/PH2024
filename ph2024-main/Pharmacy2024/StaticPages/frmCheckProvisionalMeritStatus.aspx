<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCheckProvisionalMeritStatus.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCheckProvisionalMeritStatus" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .AppFormTableNew {
            width: 100%;
            padding: 0 1px;
            font-size: 10px;
            font-family: Verdana;
            letter-spacing: 0.04em;
            /*font-weight:bold;*/
            border: 0px solid #000000; /*Border Color*/
            background-color: #FFFFFF; /*Background Color*/
            color: #000000; /*Font Color*/
            border-collapse: collapse;
            border-width: 0 1px 1px 0;
        }

            .AppFormTableNew td {
                border: 0px solid #000000;
                border-width: 0.5px;
                padding: 1px;
                font-family: Verdana;
                font-size: 9px;
            }

            .AppFormTableNew th {
                font-family: Verdana;
                font-size: 10px;
                font-weight: bold;
                color: #000000;
                border: 0px solid #000000;
                border-width: 0.5px;
                padding: 1px;
                letter-spacing: 0.04em;
                background-color: #d8d8d8;
            }

        /*.left-area {
            width: 18% !important;
        }*/
    </style>
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
    <cc1:ContentBox ID="cbCheckResult" runat="server" HeaderText="Provisional Merit Status (Only for Maharashtra State and All India Candidates)">
        <table class="AppFormTable">
            <tr>
                <td colspan="4">
                    <b>Instructions for First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions  <%= AdmissionYear %></b>
                    <p align="justify">
                        <b>All the eligible Candidates who have submitted Application Form on or before 26/09/2024 Up to 05:00 PM are considered for Provisional Merit List and assigned a Merit Number. <%--The merit is prepared on the basis of marks obtained by the candidate at qualifying examination and in case of tie as specified in sub-section (3) of rule 8.--%>
                            <%--[ज्या उमेदवाराने केंद्रीभूत प्रवेश प्रक्रिये अंतर्गत प्रवेश मिळण्यासाठी दिनांक ३१-१२-२०२० किंवा त्या दिनांकापूर्वी आवेदनपत्र सादर केलेले आहेत अशा उमेदवारांची नावे तात्पुरती गुणवत्ता यादी तयार करण्यासाठी विचारात घेण्यात आलेली असून त्यांना अर्हता परीक्षेतील गुणांच्या आधारे किंवा पोटनियम (३) मध्ये विनिर्दिष्ट केलेल्या निकषानुसार गुणानुक्रम देण्यात आला आहे.] --%>
                        </b>
                    </p>
                    <br />
                    <%--        <p align="justify">
                        <b>Due to COVID-19 outbreak and present lockdown, and to curb its spread, the Competent Authority has prescribed the following methods for the activities to be carried out by the candidate after the display of provisional Merit List: [कोविड -१९ चा उद्रेक आणि सध्याच्या लॉकडाऊनमुळे आणि त्याचा प्रसार रोखण्यासाठी सक्षम प्राधिकाऱ्यामार्फत उमेदवारांसाठी तात्पुरती गुणवत्ता यादी प्रसिद्ध झाल्यानंतरची  उमेदवारांनी अवलंबवीण्याची कार्य पद्धती खालील प्रमाणे नमूद केल्या आहेत.]
                        </b>
                    </p>--%>
                    <br />
                    <label style="color: red; font-size: 16px; font-weight: 600">Important Instructions for the Candidate:-</label>
                    <br />
                    <ol class="list-text">
                        <li runat="server" id="li4" visible="true">
                            <p align="justify">
                                The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                                
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                            </p>
                        </li>
                        <%--<li runat="server" id="li5" visible="true">
                            <p align="justify">
                                # - Non Creamy Layer Certificate (NCL) should be uploaded online till the last date of “Self Verification & Seat Acceptance “ as per Allotment of CAP Round-I to claim Category benefit for admission, otherwise you will be treated as General Candidate.
                            </p>
                        </li>--%>
                        <%--<li runat="server" id="li6" visible="true">
                            <p align="justify">
                                @ - Economically Weaker Section (EWS) Certificate should be uploaded online till the last date of “Self Verification & Seat Acceptance “ as per Allotment of CAP Round-I to claim Category benefit for admission, otherwise you will be treated as General Candidate.
                            </p>
                        </li>--%>
                        <li>
                            <p align="justify">
                                In Case of Physical Scrutiny Mode, Candidate shall raise the Grievance about correction required in the data displayed in provisional merit list , Candidate can personally visit and submit the required documents (if any) for verification at SC
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                In Case of E-Scrutiny Mode, Candidate shall raise the Grievance about correction required in the data displayed in provisional merit list through his/her Login.
                                Check the Provisional Merit Status through candidate’s Login & Verify the correctness of the Provisional Merit Number .
                                [उमेदवारांनी स्वत: च्या लॉग-इन मधून तात्पुरती गुणवत्ता यादी प्रसिद्ध झाल्यानंतर त्यामध्ये स्वत: च्या नावाची खात्री करून घ्यावी.]
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                After Approved grievance, the Application of such candidates shall be unlock to the candidate in his/her Login for rectification.
                                 Candidate shall ensure that the information shown on the Provisional Merit details of his/her claims related with Name, Qualifying Marks, category, gender, reservation, special reservation made by himself/herself in the applications form are correct.
                               [उमेदवारांनी त्याच्या/ तिच्या लॉगिनमधून तात्पुरती गुणवत्ता यादी मध्ये दर्शविण्यात आलेले नाव , पात्रता गुण, प्रवर्ग, लिंग, आरक्षण, स्वत: हून केलेले स्वत: चे विशेष आरक्षण यासंबंधीचे त्याने/तिने केलेले दावे बरोबर आहेत याची खात्री करुन घेणे आवश्यक आहे.]
                            </p>
                        </li>
                        <%--  <li>
                            <p align="justify">
                                Candidate shall upload the requisite documents to substantiate the claim for any correction/concession.
                                If a candidate finds any error in the information printed in the Provisional Merit List related to any parameter given above then the candidate shall report the grievance by e-Scrutiny through his Login without fail.
                              [जर एखाद्या उमेदवाराला उपरोक्त दिलेल्या पॅरामीटर शी संबंधित तात्पुरती गुणवत्ता यादीमध्ये छापलेल्या माहितीत काही त्रुटी आढळली असेल तर उमेदवाराने अर्ज भरताना निवडलेल्या मोड ई-स्क्रूटनी तक्रार नोंदविणे आवश्यक आहे.]
                            </p>
                        </li>--%>
                       <%-- <li>
                            <p align="justify">
                                Candidate shall raise the Grievance about correction required in the data displayed in provisional merit list , Candidate can personally visit and submit the required documents (if any) for verification at SC.
                                In later stage, if it is found that the seat allotted to the candidate is based on the false claims made in the application by the candidate, then such allotment/admission in the allotted institute shall be cancelled automatically.
                               [नंतरच्या टप्प्यात, उमेदवाराने अर्जात केलेल्या खोट्या दाव्यांवरून उमेदवाराला जागावाटप झालेले आहे असे आढळल्यास, असे जागावाटप/जागावाटप केलेल्या संस्थेत घेतलेला प्रवेश आपोआप रद्द होईल.]
                            </p>
                        </li>--%>
                        <li>
                            <p align="justify">
                                Submission of grievance, if any, for all type of Candidates at SC from 29/09/2024 to 01/10/2024 up to 5.00 PM.
                                <%-- If the marks in the qualifying examination are modified due to verification and the same is duly verified by the concerned Appropriate Authority or Board, the same shall be reported to the competent Authority for admission through CAP or its designated representatives prior to 5 p.m. on the day of display of final merit list.
                               [गुणांची पडताळणी केल्यामुळे अर्हता परीक्षेमधील गुणांमध्ये फेरबदल झाले असतील आणि संबंधित समुचीत प्राधिकरणाने किंवा मंडळाने ते गुण यथोचित रित्या प्रमाणित केलेले असतील तर, ते गुण, सक्षम प्राधिकाऱ्याला किंवा त्याच्या पदनिर्देशित प्रतिनिधींना केंद्रीभूत प्रवेश प्रक्रियेमधून प्रवेशासाठी अंतिम गुणवत्ता यादी प्रसिद्ध होण्याच्या दिवशी ५.०० वाजे पर्यंत किंवा त्या अगोदर कळविण्यात यावेत.]--%>
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                Final Merit List will be displayed on 04/10/2024.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                For Any Admission related query Contact  +91-9175108612, 18002660160<%-- [कोणत्याही प्रवेश संबंधित माहितीसाठी +91-9021060928 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.--%>
                            </p>
                        </li>

                    </ol>
                </td>
            </tr>
            <tr>
                <th colspan="2">Enter Your Application ID and Date of Birth to View Your Provisional Merit Status
                    <br />
                    (Only for Maharashtra State and All India Candidates)
                </th>
            </tr>
            <tr>
                <td style="width: 50%" align="right">Enter Application ID
                </td>
                <td style="width: 50%">
                    <asp:TextBox ID="txtApplicationID" runat="server" Width="110px" MaxLength="10">PH19</asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ErrorMessage="Please Enter Your Application ID."
                        ControlToValidate="txtApplicationID" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Enter Date Of Birth
                </td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" Width="110px" MaxLength="10"></asp:TextBox>
                    <font color="red"><sup>*</sup></font> (DD/MM/YYYY)
                    <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB"
                        Display="None" ErrorMessage="Please Enter Your Date of Birth."></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid"
                        Display="None" ErrorMessage="Please Select Proper Date of Birth."></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <center>
                        <asp:Button ID="btnProceed" runat="server" Text="SUBMIT" CssClass="InputButton" OnClick="btnProceed_Click" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" />
                    </center>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbDisplayResult" runat="server" HeaderVisible="false">
        <table class="AppFormTableNew">
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
                        Provisional Merit Status for Admission to First Year of Four Year Degree Course
                        in Pharmacy & First Year of Six Year Post Graduate Degree Course in Pharm. D. for
                        the Academic Year <%= AdmissionYear %> </b>
                </td>
                <td style="width: 10%; border-left-width: 0px;" align="center">
                    <img src="../Images/ARAFINAL.png" alt="" style="width: 73px; height: auto" />
                </td>
            </tr>
            <%--     <tr>
                <td align="center" colspan="3">
                    <font size="2">Application ID :
                        <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True"></asp:Label></font>
                </td>
            </tr>--%>
        </table>
        <table class="AppFormTableNew">
            <tr>
                <th align="left" colspan="1">Personal Details
                </th>
                <th align="center" colspan="3"><font size="2">Application ID :
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True"></asp:Label></font></th>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name
                </td>
                <td colspan="3">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Gender
                </td>
                <td style="width: 25%">
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Medium"></asp:Label>
                </td>
                <td style="width: 25%" align="right">DOB (DD/MM/YYYY)
                </td>
                <td style="width: 25%">
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">Candidature Type
                </td>
                <td>
                    <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Home University
                </td>
                <td>
                    <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">Category
                </td>
                <td>
                    <asp:Label ID="lblOriginalCategory" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Category for Admission
                </td>
                <td>
                    <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="trCVCTVCRemark" visible="false">
                <%-- <td colspan="4">
                    <b>$ - As you have submitted Receipt of Caste/Tribe validity certificate, you should submit
                    Caste/Tribe validity certificate till the last date of reporting to Admission Reporting
                    Center (ARC) as per Allotment of CAP Round-I (Before 15 July 2019 upto 5 pm) to claim Category benefit for admission,
                    otherwise you will be treated as General Candidate. </b>
                </td>--%>
            </tr>
            <tr>
                <td align="right">Applied for EWS
                </td>
                <td>
                    <asp:Label ID="lblAppliedForEWS" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Orphan Candidate
                </td>
                <td>
                    <asp:Label ID="lblIsOrphan" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">Applied for TFWS
                </td>
                <td colspan="3">
                    <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label>
                </td>

            </tr>
            <tr>
                <td align="right">Person with Disability
                </td>
                <td>
                    <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Defence Type
                </td>
                <td>
                    <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">Linguistic Minority
                </td>
                <td>
                    <asp:Label ID="lblLinguisticMinority" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Religious Minority
                </td>
                <td>
                    <asp:Label ID="lblReligiousMinority" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trCETScore1" runat="server" visible="false">
                <th colspan="4" align="left">
                    <%= MHTCETPercentile %>  [Roll No -
                    <asp:Label ID="lblCETRollNo" runat="server"></asp:Label>]
                </th>
            </tr>
            <tr id="trCETScore2" runat="server" visible="false">
                <td align="right">Candidate Name (as per CET)
                </td>
                <td colspan="3">
                    <asp:Label ID="lblCandidateNameAsPerCET" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trCETScore3" runat="server" visible="false">
                <td align="right">Physics
                </td>
                <td>
                    <asp:Label ID="lblCETPhysicsScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Chemistry
                </td>
                <td>
                    <asp:Label ID="lblCETChemistryScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trCETScore4" runat="server" visible="false">
                <td align="right">Mathematics
                </td>
                <td>
                    <asp:Label ID="lblCETMathScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Biology
                </td>
                <td>
                    <asp:Label ID="lblCETBiologyScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trCETScore5" runat="server" visible="false">
                <td align="right">Total PCM
                </td>
                <td>
                    <asp:Label ID="lblCETPCMScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Total PCB
                </td>
                <td>
                    <asp:Label ID="lblCETPCBScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trNEETScore1" runat="server" visible="false">
                <th align="left" colspan="4">NEET <%= CurrentYear %> Details [Roll No-
                    <asp:Label ID="lblNEETRollNo" runat="server" Font-Bold="true"></asp:Label>
                    ]
                </th>
            </tr>
            <tr id="trNEETScore2" runat="server" visible="false">
                <td align="right">Candidate Name (as per NEET)
                </td>
                <td colspan="3">
                    <asp:Label ID="lblCandidateNameAsPerNEET" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <%-- <td align="right">Roll No</td>
                <td><asp:Label id="lblNEETRollNo" runat="server" Font-Bold = "true"></asp:Label></td> --%>
            </tr>
            <tr id="trNEETScore3" runat="server" visible="false">
                <td align="right">Physics
                </td>
                <td>
                    <asp:Label ID="lblNEETPhysicsScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Chemistry
                </td>
                <td>
                    <asp:Label ID="lblNEETChemistryScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trNEETScore4" runat="server" visible="false">
                <td align="right">Biology
                </td>
                <td>
                    <asp:Label ID="lblNEETBiologyScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Total
                </td>
                <td>
                    <asp:Label ID="lblNEETTotalScore" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <th align="left" colspan="4">Qualification Details
                </th>
            </tr>
            <tr>
                <td align="right">HSC Physics
                </td>
                <td>
                    <asp:Label ID="lblHSCPhysicsPercentage" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">HSC Chemistry
                </td>
                <td>
                    <asp:Label ID="lblHSCChemistryPercentage" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">HSC
                    <asp:Label ID="lblHSCSubject" runat="server"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="lblHSCSubjectPercentage" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">HSC Aggregate
                </td>
                <td>
                    <asp:Label ID="lblHSCTotalPercentage" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Diploma Aggregate
                </td>
                <td>
                    <asp:Label ID="lblDiplomaTotalPercentage" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">HSC Eligibility Marks
                </td>
                <td>
                    <asp:Label ID="lblHSCEligibilityPercentage" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Diploma Eligibility Marks
                </td>
                <td>
                    <asp:Label ID="lblDiplomaEligibilityPercentage" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <th align="left" colspan="4">Eligibility Details
                </th>
            </tr>
            <tr>
                <td align="right">Eligible for B.Pharmacy
                </td>
                <td>
                    <asp:Label ID="lblEligibleForMeritBPharmacy" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">Eligible for Pharm.D
                </td>
                <td>
                    <asp:Label ID="lblEligibleForMeritPharmD" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="AppFormTableNew">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">
                    <b>Your Provisional Merit Status is...</b>
                </th>
            </tr>
            <tr id="trStateGeneralMeritNo" runat="server" visible="false">
                <td style="width: 50%" align="right">State General Merit No
                </td>
                <td style="width: 50%">
                    <asp:Label ID="lblStateGeneralMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trUniversityGeneralMeritNo" runat="server" visible="false">
                <td align="right">University General Merit No
                </td>
                <td>
                    <asp:Label ID="lblUniversityGeneralMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trStateCategoryMeritNo" runat="server" visible="false">
                <td align="right">State Category Merit No
                </td>
                <td>
                    <asp:Label ID="lblStateCategoryMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trUniversityCategoryMeritNo" runat="server" visible="false">
                <td align="right">University Category Merit No
                </td>
                <td>
                    <asp:Label ID="lblUniversityCategoryMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trStateSBCMeritNo" runat="server" visible="false">
                <td align="right">State SBC Merit No
                </td>
                <td>
                    <asp:Label ID="lblStateSBCMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trUniversitySBCMeritNo" runat="server" visible="false">
                <td align="right">University SBC Merit No
                </td>
                <td>
                    <asp:Label ID="lblUniversitySBCMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trLadiesStateGeneralMeritNo" runat="server" visible="false">
                <td align="right">Ladies State General Merit No
                </td>
                <td>
                    <asp:Label ID="lblLadiesStateGeneralMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trLadiesUniversityGeneralMeritNo" runat="server" visible="false">
                <td align="right">Ladies University General Merit No
                </td>
                <td>
                    <asp:Label ID="lblLadiesUniversityGeneralMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trLadiesStateCategoryMeritNo" runat="server" visible="false">
                <td align="right">Ladies State Category Merit No
                </td>
                <td>
                    <asp:Label ID="lblLadiesStateCategoryMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trLadiesUniversityCategoryMeritNo" runat="server" visible="false">
                <td align="right">Ladies University Category Merit No
                </td>
                <td>
                    <asp:Label ID="lblLadiesUniversityCategoryMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trLadiesStateSBCMeritNo" runat="server" visible="false">
                <td align="right">Ladies State SBC Merit No
                </td>
                <td>
                    <asp:Label ID="lblLadiesStateSBCMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trLadiesUniversitySBCMeritNo" runat="server" visible="false">
                <td align="right">Ladies University SBC Merit No
                </td>
                <td>
                    <asp:Label ID="lblLadiesUniversitySBCMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trStatePHMeritNo" runat="server" visible="false">
                <td align="right">State PWD Merit No
                </td>
                <td>
                    <asp:Label ID="lblStatePHMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trUniversityPHMeritNo" runat="server" visible="false">
                <td align="right">University PWD Merit No
                </td>
                <td>
                    <asp:Label ID="lblUniversityPHMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trStateDefenceMeritNo" runat="server" visible="false">
                <td align="right">State Defence Merit No
                </td>
                <td>
                    <asp:Label ID="lblStateDefenceMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trEWSMeritNo" runat="server" visible="false">
                <td align="right">EWS Merit No
                </td>
                <td>
                    <asp:Label ID="lblEWSMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trTFWSMeritNo" runat="server" visible="false">
                <td align="right">TFWS Merit No
                </td>
                <td>
                    <asp:Label ID="lblTFWSMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trOrphanMeritNo" runat="server" visible="false">
                <td align="right">Orphan Merit No
                </td>
                <td>
                    <asp:Label ID="lblOrphanMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trAIMeritNo" runat="server" visible="false">
                <td style="width: 35%" align="right">All India Merit No
                </td>
                <td style="width: 65%">
                    <asp:Label ID="lblAIMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trFNPIOMeritNo" runat="server" visible="false">
                <td style="width: 35%" align="right">Foreign Students / PIO / OCI Merit No
                </td>
                <td style="width: 65%">
                    <asp:Label ID="lblFNPIOMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trCIWGCMeritNo" runat="server" visible="false">
                <td style="width: 35%" align="right">CIWGC Merit No
                </td>
                <td style="width: 65%">
                    <asp:Label ID="lblCIWGCMeritNo" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="trCVCMsg" visible="false">
                <td colspan="4" style="color: red"><b>Note:- The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                    
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                </b></td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Instructions for First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions  <%= AdmissionYear %></b>
                    <p align="justify">
                        <b>All the eligible Candidates who have submitted Application Form on or before 26/09/2024 Up to 05:00 PM are considered for Provisional Merit List and assigned a Merit Number. <%--The merit is prepared on the basis of marks obtained by the candidate at qualifying examination and in case of tie as specified in sub-section (3) of rule 8.--%>
                            <%--[ज्या उमेदवाराने केंद्रीभूत प्रवेश प्रक्रिये अंतर्गत प्रवेश मिळण्यासाठी दिनांक ३१-१२-२०२० किंवा त्या दिनांकापूर्वी आवेदनपत्र सादर केलेले आहेत अशा उमेदवारांची नावे तात्पुरती गुणवत्ता यादी तयार करण्यासाठी विचारात घेण्यात आलेली असून त्यांना अर्हता परीक्षेतील गुणांच्या आधारे किंवा पोटनियम (३) मध्ये विनिर्दिष्ट केलेल्या निकषानुसार गुणानुक्रम देण्यात आला आहे.] --%>
                        </b>
                    </p>
                    <br />
                    <%--        <p align="justify">
                        <b>Due to COVID-19 outbreak and present lockdown, and to curb its spread, the Competent Authority has prescribed the following methods for the activities to be carried out by the candidate after the display of provisional Merit List: [कोविड -१९ चा उद्रेक आणि सध्याच्या लॉकडाऊनमुळे आणि त्याचा प्रसार रोखण्यासाठी सक्षम प्राधिकाऱ्यामार्फत उमेदवारांसाठी तात्पुरती गुणवत्ता यादी प्रसिद्ध झाल्यानंतरची  उमेदवारांनी अवलंबवीण्याची कार्य पद्धती खालील प्रमाणे नमूद केल्या आहेत.]
                        </b>
                    </p>--%>
                    <br />
                    <label style="color: red; font-size: 16px; font-weight: 600">Important Instructions for the Candidate:-</label>

                    <br />
                    <ol class="list-text">
                        <%-- <li runat="server" id="li1" visible="true">
                            <p align="justify">
                                $ - Caste Validity Certificate / Tribe Validity Certificate should be uploaded online till the last date of “Self Verification & Seat Acceptance “ as per Allotment of CAP Round-I to claim Category benefit for admission, otherwise you will be treated as General Candidate.
                            </p>
                        </li>--%>
                        <%-- <li runat="server" id="li2" visible="true">
                           <p align="justify">
                                # - Non Creamy Layer Certificate (NCL) should be uploaded online till the last date of “Self Verification & Seat Acceptance “ as per Allotment of CAP Round-I to claim Category benefit for admission, otherwise you will be treated as General Candidate.
                            </p>
                        </li>--%>
                        <%-- <li runat="server" id="li3" visible="true">
                          <p align="justify">
                                @ - Economically Weaker Section (EWS) Certificate should be uploaded online till the last date of “Self Verification & Seat Acceptance “ as per Allotment of CAP Round-I to claim Category benefit for admission, otherwise you will be treated as General Candidate.
                            </p>
                        </li>--%>                                               
                        <%--<li>
                            <p align="justify">
                                Candidate shall upload the requisite documents to substantiate the claim for any correction/concession.
                                 If a candidate finds any error in the information printed in the Provisional Merit List related to any parameter given above then the candidate shall report the grievance by e-Scrutiny through his Login without fail.
                              [जर एखाद्या उमेदवाराला उपरोक्त दिलेल्या पॅरामीटर शी संबंधित तात्पुरती गुणवत्ता यादीमध्ये छापलेल्या माहितीत काही त्रुटी आढळली असेल तर उमेदवाराने अर्ज भरताना निवडलेल्या मोड ई-स्क्रूटनी तक्रार नोंदविणे आवश्यक आहे.]
                            </p>
                        </li>--%>
                        <%-- <li>
                            <p align="justify">
                                The status of acceptance/rejection of Grievance raised by candidate shall be available in candidates Login along with latest receipt cum Acknowledgment.
                                In later stage, if it is found that the seat allotted to the candidate is based on the false claims made in the application by the candidate, then such allotment/admission in the allotted institute shall be cancelled automatically.
                               [नंतरच्या टप्प्यात, उमेदवाराने अर्जात केलेल्या खोट्या दाव्यांवरून उमेदवाराला जागावाटप झालेले आहे असे आढळल्यास, असे जागावाटप/जागावाटप केलेल्या संस्थेत घेतलेला प्रवेश आपोआप रद्द होईल.]
                            </p>
                        </li>--%>
                        <li>
                            <p align="justify">
                                In Case of Physical Scrutiny Mode, Candidate shall raise the Grievance about correction required in the data displayed in provisional merit list , Candidate can personally visit and submit the required documents (if any) for verification at SC.
                               <%-- The status of acceptance/rejection of Grievance raised by candidate shall be available in candidates Login along with latest receipt cum Acknowledgment.
                                 In later stage, if it is found that the seat allotted to the candidate is based on the false claims made in the application by the candidate, then such allotment/admission in the allotted institute shall be cancelled automatically.
                               [नंतरच्या टप्प्यात, उमेदवाराने अर्जात केलेल्या खोट्या दाव्यांवरून उमेदवाराला जागावाटप झालेले आहे असे आढळल्यास, असे जागावाटप/जागावाटप केलेल्या संस्थेत घेतलेला प्रवेश आपोआप रद्द होईल.]--%>
                            </p>
                        </li>
                         <li>
                            <p align="justify">
                               In Case of E-Scrutiny Mode, Candidate shall raise the Grievance about correction required in the data displayed in provisional merit list through his/her Login. Check the Provisional Merit Status through candidate’s Login & Verify the correctness of the Provisional Merit Number . [उमेदवारांनी स्वत: च्या लॉग-इन मधून तात्पुरती गुणवत्ता यादी प्रसिद्ध झाल्यानंतर त्यामध्ये स्वत: च्या नावाची खात्री करून घ्यावी.]
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                               After Approved grievance, the Application of such candidates shall be unlock to the candidate in his/her Login for rectification.
                                 Candidate shall ensure that the information shown on the Provisional Merit details of his/her claims related with Name, Qualifying Marks, category, gender, reservation, special reservation made by himself/herself in the applications form are correct.
                               [उमेदवारांनी त्याच्या/ तिच्या लॉगिनमधून तात्पुरती गुणवत्ता यादी मध्ये दर्शविण्यात आलेले नाव , पात्रता गुण, प्रवर्ग, लिंग, आरक्षण, स्वत: हून केलेले स्वत: चे विशेष आरक्षण यासंबंधीचे त्याने/तिने केलेले दावे बरोबर आहेत याची खात्री करुन घेणे आवश्यक आहे.]
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                Submission of grievance, if any, for all type of Candidates at SC from 29/09/2024 to 01/10/2024 up to 05.00 PM.
                                <%-- If the marks in the qualifying examination are modified due to verification and the same is duly verified by the concerned Appropriate Authority or Board, the same shall be reported to the competent Authority for admission through CAP or its designated representatives prior to 5 p.m. on the day of display of final merit list.
                               [गुणांची पडताळणी केल्यामुळे अर्हता परीक्षेमधील गुणांमध्ये फेरबदल झाले असतील आणि संबंधित समुचीत प्राधिकरणाने किंवा मंडळाने ते गुण यथोचित रित्या प्रमाणित केलेले असतील तर, ते गुण, सक्षम प्राधिकाऱ्याला किंवा त्याच्या पदनिर्देशित प्रतिनिधींना केंद्रीभूत प्रवेश प्रक्रियेमधून प्रवेशासाठी अंतिम गुणवत्ता यादी प्रसिद्ध होण्याच्या दिवशी ५.०० वाजे पर्यंत किंवा त्या अगोदर कळविण्यात यावेत.]--%>
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                Final Merit List will be displayed on 04/10/2024.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                For Any Admission related query Contact +91-9175108612, 18002660160<%-- [कोणत्याही प्रवेश संबंधित माहितीसाठी +91-9021060928 वर या 10:00 AM to 06:00 PM कार्यालयीन वेळेत संपर्क साधा.--%>
                            </p>
                        </li>

                    </ol>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <font color="red"><b>Published On : 28/09/2024</b></font>
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

