<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmLoginPage.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmLoginPage" %>


<%@ Register Assembly="Synthesys.Controls.LoginBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_cbAlreadyRegisteredCandidatesSignIn_LoginBox1_btnUpdateSecurityPin {
            margin-left: 10px;
            margin-bottom: -7px;
        }
    </style>

    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" language="javascript"></script>
    <script>
        $(document).ready(function () {
            $("input").attr("autocomplete", "new-password");

            $('#rightContainer_cbAlreadyRegisteredCandidatesSignIn_LoginBox1_txtSecurityPin').keyup(function () {
                var inputValue = $(this).val();
                var upperCaseValue = inputValue.toUpperCase();
                $(this).val(upperCaseValue);
            });
        });
    </script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        $(function () {
            turnOffAutoComplete();
        });
        $(function () {
            turnOffAutoCompletes();
        });
        $(function () {
            turnOffAutoCompletes();
        });

        function turnOffAutoCompleteP() {
            $('input[type=text]').attr('autocomplete', 'off');
        }
        function turnOffAutoCompletes() {
            $('input[type=Password]').attr('autocomplete', 'off');
        }

        function turnOffAutoComplete() {
            $("rightContainer_cbAlreadyRegisteredCandidatesSignIn_LoginBox1_UserName").attr('autocomplete', 'off');
        }
        function turnOffAutoComplete() {
            $("rightContainer_cbAlreadyRegisteredCandidatesSignIn_LoginBox1_Password").attr('autocomplete', 'off');
        }
        function turnOffAutoCompletes() {
            document.getElementById("rightContainer_cbAlreadyRegisteredCandidatesSignIn_LoginBox1_UserName").setAttribute("autocomplete", "off");
        }
        function turnOffAutoCompleteP() {
            document.getElementById("rightContainer_cbAlreadyRegisteredCandidatesSignIn_LoginBox1_Password").setAttribute("autocomplete", "off");
        }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            var tblLogin = document.getElementsByTagName("table")[2];
            var tblCaptcha = document.getElementsByTagName("table")[3];

            if (tblLogin.rows.length == 3) {
                var rowUserName = tblLogin.rows[1];
                var rowPassword = tblLogin.rows[2];
                var rowSignBtn = tblLogin.rows[2];

                var rowCaptcha = tblCaptcha.rows[0];

                tblLogin.deleteRow(2);

                tblCaptcha.insertRow(1).innerHTML = rowSignBtn.innerHTML;
            }
            if (tblLogin.rows.length == 4) {
                var rowUserName = tblLogin.rows[0];
                var rowPassword = tblLogin.rows[1];
                var rowMessage = tblLogin.rows[2];
                var rowSignBtn = tblLogin.rows[3];

                var rowCaptcha = tblCaptcha.rows[0];

                tblLogin.deleteRow(3);

                tblCaptcha.insertRow(1).innerHTML = rowSignBtn.innerHTML;
            }
        }
        function EndRequestHandler() {
            turnOffAutoComplete();
            turnOffAutoCompletes();
            turnOffAutoCompleteP();
        }
        window.onload = load;
    </script>
    <cc1:ContentBox runat="server" ID="cbAlreadyRegisteredCandidatesSignIn" HeaderText="Registered Candidates Sign In">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td style="width: 30%;" valign="top">
                    <div class="row w-100  mx-auto">
                        <div class="col-sm-4  px-0">
                            <center>
                                <cc1:LoginBox ID="LoginBox1" runat="server" LoginButtonType="Button" UseFormsAuthentication="true" LoginButtonImageUrl="~/SynthesysModules_Files/Images/btn-login.png" PasswordLabelText="Password : " UserNameLabelText="Application ID : " LoginButtonText="Sign In" Font-Names="verdana" Font-Size="12px" ShowBorder="false" FailureText="Invalid Login ID or Password.">
                                    <loginbuttonstyle cssclass="InputButton" />
                                    <textboxstyle width="120" />
                                </cc1:LoginBox>
                            </center>
                            <br />
                            <br />
                            <a href="../CandidateAccountRecoveryModule/frmAccountRecovery.aspx">I can't access my account ?</a>
                        </div>
                        <div class="col-sm-8  text-left">
                            <font color="red">
                                <p align="justify"><font color="red"><b>Instructions :</b></font></p>
                                <ol class="list-text">
                                    <li>
                                        <p align="justify"><font color="red">The Candidate who is already registered should enter Application ID and Password.</font></p>
                                    </li>
                                    <li>
                                        <p align="justify"><font color="red">In case candidate forgets his / her Application ID / Password, he / she can retrieve it by using "I can't access my account ?".</font></p>
                                    </li>
                                    <li>
                                        <p align="justify"><font color="red">Candidate is advised not to disclose or share their password with anybody. CET Cell will not be responsible for violation or misuse of the password of a candidate.</font></p>
                                    </li>
                                    <li>
                                        <p align="justify"><font color="red">Only authorised users are allowed to proceed further.</font></p>
                                    </li>
                                    <li>
                                        <p align="justify"><font color="red">Your IP Address and other information will be captured for security reasons.</font></p>
                                    </li>
                                    <li>
                                        <p align="justify">
                                            <font color="red">The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                                                
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                                            </font>
                                        </p>
                                    </li>
                                </ol>
                            </font>
                        </div>
                    </div>


                </td>

            </tr>
        </table>
        <%--<font color="red" size = "2">
            <ol class="list-text"><b>पदव्युत्तर पदवी व्यवस्थापन प्रवेश प्रक्रियेत उमेदवाराने / अर्जदाराने ऑनलाईन पद्धतीने ऑप्शन फॉर्म भरतांना घ्यावयाची काळजी :</b>
                <li><p align = "justify"><font color = "red" size = "2">अर्जदाराने अप्लिकेशन आयडी व पासवर्ड द्वारे लॉगीन करावे.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">अर्जदाराने अप्लिकेशन आयडी अथवा पासवर्ड स्वतः टाकावा. सायबर कॅफे / एआरसी अधिकारी / मित्र यांना पासवर्ड सांगू नये. अन्यथा अर्जदाराच्या पासवर्ड द्वारे इतर व्यक्तीने अर्जदाराच्या अपरोक्ष ऑप्शन फॉर्म मध्ये बदल केल्यास अथवा ऑप्शन फॉर्म कन्फर्म केल्यास त्यास संचालनालय जबाबदार राहणार नाही.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">संचालनालयाच्या संकेतस्थळावर संस्थेबद्दल तसेच अभ्यासक्रमांबाबत अद्ययावत माहिती उपलब्ध आहे. त्याचे आवलोकन करावे.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">काही संस्थाना मा. उच्च न्यायालय / मा. सर्वोच्च न्यायालय यांच्या अदेशानुसार केंद्रीभूत प्रवेश प्रक्रियेत समाविष्ट केलेले आहेत याची नोंद घ्यावी.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">शासनाच्या धोरणानुसार संस्थेतील अभ्यासक्रमांना अथवा काही अभ्यासक्रमांना प्रवेश घेतल्यास शुल्क प्रतिपूर्ती योजनेचा लाभ घेता येणार नाही याबाबत नोंद घ्यावी.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">अर्जदाराने एकदा ऑप्शन फॉर्म कन्फर्म केल्यानंतर त्यामध्ये कोणताही बदल करता येणार नाही व त्यानुसार पुढील संगणकीय प्रणालीद्वारे अलॉटमेंट करण्यात येईल.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">ऑप्शन फॉर्म मध्ये बदल केल्यानंतर अथवा ऑप्शन फॉर्म कन्फर्म केल्यानंतर लॉगआउट न चुकता करावे जेणेकरून आपल्या लॉगीन द्वारे दुसरा व्यक्ती कोनतेही बदल आपल्या अपरोक्ष करणार नाही.</font></p></li>
            </ol>
        </font>--%>
        <%--<font color="red" size = "2">	
            <ol class="list-text"><b>प्रवेश निश्चिती केंद्रावर प्रवेश निश्चित करण्यासाठी मार्गदर्शक सूचना :</b>
                <li><p align = "justify"><font color = "red" size = "2">ज्या विद्यार्थ्यांना या फेरीमध्ये प्रथमच  जागेचे वाटप झालेले असेल त्यांनी प्रवेश निश्चिती केंद्रावर जाऊन प्रवेश निश्चिती करणे आवश्यक आहे. त्यासाठी त्यांना आवश्यक रकमेचा डी.डी. सादर करणे व सर्व मूळ कागदपत्रे तपासणीसाठी सादर करणे आवश्यक आहे. प्रवेश निश्चिती केंद्रावर कागदपत्रांची तपासणी केल्यानंतर व विद्यार्थी पात्रता निकष पूर्ण करत असल्याची खात्री करून घेऊन अधिकारी online प्रवेश निश्चिती करून त्याची पोच पावती देतील.हि पावती विद्यार्थ्याने सांभाळून ठेवावी.<br /><u>अशा प्रकारे प्रवेश निश्चिती केली नाही तर अशा विद्यार्थ्यांचा या फेरीतील प्रवेश रद्द होतो व ते पुढील फेरीसाठी  (कॅप ३ ) पात्र असणार नाही.</u></font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">ज्या विद्यार्थ्यांना कोणत्याही फेरीमध्ये पहिला विकल्प मिळालेला असेल त्यांचा विकल्प आपोआप Freeze होतो त्यांना Float/ Slide करता येणार नाही. परंतु त्यांना जर प्रवेश प्रक्रियेमध्ये पुन्हा भाग घ्यावयाचा असेल तर त्यांना चौथ्या फेरीमध्ये भाग घेता येईल.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">ज्या विद्यार्थ्यांना या पूर्वीच्या कॅप १ फेरीमध्ये जागावाटप झालेले होते व त्यांना कॅप-२ मध्ये वरील प्राधान्याच्या क्रमांकावर (Betterment ) जागावाटप झालेले आहे/ नाही व त्यांना पूर्वीच्या फेरीमध्ये दिलेला विकल्प बदलावयाचा नाही त्यांनी प्रवेश निश्चिती केंद्रावर जाण्याची आवश्यकता नाही.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">ज्यांना कॅप २ मध्ये वरील प्राधान्याच्या क्रमांकावर (Betterment) मिळालेले असेल अशा विद्यार्थ्यांना जर त्यांचा विकल्प Float/ Slide/Freeze बदलून घ्यावयाचा असेल त्यांना प्रवेश निश्चिती केंद्रावर जाने आवश्यक आहे. खालीलप्रमाणे बदल करता येतील.<br />Float To  Slide;  ​Float To Freeze; ​Slide To Freeze अशा प्रकारचा बदल फक्त एकवेळेसच करता येईल.<br />नोट :पहिल्या फेरीमध्ये  Freeze केलेल्या विद्यार्थ्यांना विकल्प बदलता येणार नाही.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">ज्या विद्यार्थ्यांना पहिल्या किंवा दुसऱ्या फेरीमध्ये जागेचे वाटप झालेले नाही, अशा विद्यार्थ्यांनी तिसऱ्या फेरीच्या जागावाटपाची वाट पहावी.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">प्रवेश निश्चितीसाठी डी डी रु. ५०००/- (एस सी / एस टी वगळून इतर सर्व प्रवर्गासाठी ) व रु. १०००/- (एस सी / एस टी साठी) जमा करणे आवश्यक आहे. डी डी “Commissioner, State CET Cell, Maharashtra State, Mumbai” यांचे नावाने Payable at “Mumbai” असा काढलेला असावा.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">ज्या विद्यार्थ्यांनी पहिल्या  फेरीमधील जागावाटपानंतर Float / Slide केलेले आहे व त्यांना दुसऱ्या फेरीमध्ये जागावाटप (Betterment) झालेले नाही त्यांचा पूर्वीचा कॅप फेरी १ मधील प्रवेश अबाधित राहतो.</font></p></li>
            </ol>
        </font>--%>
        <%--<font color="red" size = "2">	
            <center><b>Detailed Instructions for CAP Round IV :</b></center><br />
            All the candidates are hereby informed that if they do not fill and confirm the Option Form for CAP Round IV, shall retain their current seat, if any. <br />
            Candidates are advised to fill in Choice Codes, even if there are no vacancies displayed in the Seat matrix for CAP Round IV. The vacancies may be created due to betterment to the candidates and such seats shall be allotted in this round only as per merit.<br /><br />
            <ol class="list-text"><b>Seat is Allotted in earlier rounds and Candidate has Reported :</b><br />
                <li><p align = "justify"><font color = "red" size = "2">Candidate having Reporting Status as “Freeze” are not eligible for participating in CAP Round IV.  However to participate in CAP Round IV, candidate should report to the ARC in person and submit an application to change the seat acceptance status from Freeze to Float during scheduled dates for 'Option Form Submission and Confirmation for CAP Round IV'. The ARC Officer shall update your status in the Online System and then you will be able to participate in CAP Round IV.</u></font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">Candidate having Reporting Status as “Float” or “Slide” are eligible for participating in CAP Round IV.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">If Candidate submit and Confirm the Option Form during the scheduled dates for CAP Round IV, you will be considered for allotment as per merit. While filling the option form, Candidate can add new Choice Codes, delete Choice Codes, change the preference numbers, however do not add the current Choice Code which is allotted to you, this will be added at the end by the online system. Option Form submitted online for CAP Round IV must be confirmed otherwise it shall not be considered for allotment of CAP Round IV.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">If Candidate do not submit and confirm the Option Form for CAP Round IV, Candidate will not be considered for allotment and no new seat shall be allotted to you. However their current seat shall retain and are required to report to that institute.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">If seat is allotted in CAP Round IV, Candidate’s current seat allotted shall be automatically cancelled and he/she will be reporting to the new Institute / Course as per Allotment in CAP Round IV.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">If seat is not allotted in CAP Round IV, Candidate’s current seat shall be retained and he/she will be reporting to the current Institute / Course as per current allotment.</font></p></li>
            </ol>
            <br />
            <ol class="list-text"><b>Candidate Not holding any seat :</b><br />
                <li><p align = "justify"><font color = "red" size = "2">You are eligible for participating in CAP Round IV.</u></font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">If you submit and Confirm the Option Form during the scheduled dates for CAP Round IV, Candidate will be considered for allotment as per merit.  You can use (import) the Choice Codes of earlier CAP Round I. Candidate can add new Choice Codes, delete Choice Codes, change the preference numbers.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">If seat is allotted in CAP Round IV, Candidate must report to the ARC, pay the Seat Acceptance Fees and get the Documents verified and then only Candidate are required to report to the Institute / Course as per Allotment in CAP Round IV.</font></p></li>
                <li><p align = "justify"><font color = "red" size = "2">If seat is not allotted in CAP Round IV, contact to the institutes for admission under Institute Level Quota as well as CAP Vacancy seat, if any.</font></p></li>
            </ol> <br /><br />
       
        <b>NOTE:</b> WHILE FILLING THE OPTION FORM, PLEASE REFER THE SEATS FOR CAP IV, HON. COURT REMARKS AND NEW CHOICE CODES ADDED IN CAP IV.
        </font>
         <br /><br />--%>
    </cc1:ContentBox>
</asp:Content>
