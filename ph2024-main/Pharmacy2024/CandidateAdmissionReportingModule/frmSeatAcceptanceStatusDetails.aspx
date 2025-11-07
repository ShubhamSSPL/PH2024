<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSeatAcceptanceStatusDetails.aspx.cs" Inherits="Pharmacy2024.CandidateAdmissionReportingModule.frmSeatAcceptanceStatusDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Choose Your Seat Acceptance Status">
        <table class="AppFormTable" id="tblBettermentNotFreeze" runat="server" visible="false">
            <tr>
                <th align="left" style="background: #269226; color: White; border: 1px solid green">
                    <font size="3">Betterment (Not Freeze)</font>
                </th>
            </tr>
            <tr>
                <td style="background-color: #def3de; border: 1px solid green">
                    <p align="justify"><b>Candidate who wants to participate in the next Round :-</b></p>
                    <ol class="list-text" type="a">
                        <%--<li><p align = "justify">Candidate who have been allotted seat other than first preference and <b>accepted the seat by reporting to ARC</b> for confirmation of seat acceptance shall be eligible for participation in the subsequent rounds for betterment.</p></li>
                                <li><p align = "justify">Candidate who have been allotted seat other than first preference and <b>not accepted the seat by not reporting to ARC</b> for confirmation of seat acceptance shall be eligible for participation in the subsequent rounds.</p></li>
                                <li><p align = "justify">Candidates at 3(a) & 3(b) shall <u>submit & confirm fresh options</u> for the subsequent rounds.</p></li>--%>
                        <%--     <li><p align = "justify">Candidate who have been allotted seat other than first preference and accepted the seat by reporting to ARC for confirmation of seat acceptance shall be eligible for participation in the subsequent rounds for betterment;
                               <br /> ज्या उमेदवारांना त्याच्या विकल्प नमुन्यातील पहिल्या  पसंतीक्रमांकाखेरीज इतर  पसंतीक्रमांकावरील  जागेचे वाटप झाले  आणि उमेदवाराने  प्रवेश उपस्थिती केंद्रावर हजर  होवून जागास्वीकृती केली असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये वरच्या पसंतीक्रमावरील जागा मिळविण्याकरिता सहभागी होण्यास पात्र असतील.</p></li>      
                                <li><p align = "justify">Candidate who have been allotted seat other than first preference and not accepted the seat by not reporting to ARC for confirmation of seat acceptance shall be eligible for participation in the subsequent rounds;
                              <br />  ज्या उमेदवारांना त्याच्या विकल्प नमुन्यातील पहिल्या  पसंतीक्रमांकाखेरीज इतर  पसंतीक्रमांकावरील  जागेचे वाटप झाले  आणि उमेदवाराने  प्रवेश उपस्थिती केंद्रावर हजर न होवून जागास्वीकृती केली नाही,  असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्यास पात्र असतील.</p></li>
                              <li><p align = "justify">Reporting dates ARC for confirming the allotted seat at ARC<b> 14/08/2019 to 16/08/2019 </b></p></li>--%>
                        <li>
                            <p align="justify">
                                Candidate who have been allotted seat other than the first preference and if the candidate is not satisfied with such allotment and do wish to participate in further CAP rounds for betterment, by self-verifying the current allotment and ensuring the correctness of the details given in the application form as per the rule no 9 (i) of the information brochure.

ज्या उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या पसंतीक्रमांकाखेरीज इतर पसंतीक्रमांकावरील जागेचे वाटप झाल्यास आणि उमेदवार या वाटपाने संतुष्ट नसल्यास आणि केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्याची त्याची इच्छा असल्यास उमेदवार त्यांना झालेल्या जागा वाटपाची स्वतः पडताळणी करून माहिती पुस्तिकेतील नियम क्र. ९ नुसार अर्जामध्ये दिलेल्या तपशीलांची अचूकता सुनिश्चित करून त्यास देऊ केलेली जागेवर स्वतःचा हक्क ठेवु शकतो.
                        </li>
                        <li>
                            <p align="justify">
                                Candidate who have been allotted seat other than first preference and not accepted the seat by not doing Self Verification and Seat Acceptance, in such case candidate seat shall cancelled automatically and the seat shall become available for fresh allotment and candidate will eligible for participation in the subsequent rounds;

ज्या उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या पसंतीक्रमांकाखेरीज इतर पसंतीक्रमांकावरील जागेचे वाटप झाल्यास आणि उमेदवाराने स्वयःपडताळणी व जागा स्विकृती न केल्यास असे उमेदवार त्यांना वाटप करण्यात आलेल्या जागेवरील हक्क आपोआप गमावतील आणि ती जागा पुढील वाटपासाठी उपलब्ध होईल व उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये पात्र असेल.
                            </p>
                        </li>

                        <li>
                            <p align="justify">
                                Last date for Confirmation of allotted seat is <b>16/12/2024 Up to 3 P.M.</b>
                                वाटप केलेल्या जागेच्या पुष्टीकरणाची अंतिम तारीख  <b>16/12/2024 Up to 3 P.M.</b> आहे.
                            </p>
                        </li>

                        <li>
                            <p align="justify">
                                Last date for Confirmation of Admission in allotted Institute is <b>16/12/2024 Up to 5 P.M.</b>
                                वाटप झालेल्या संस्थेमध्ये प्रवेशासाठी अंतिम तारीख <b>16/12/2024 Up to 5 P.M. </b>आहे.
                            </p>
                        </li>

                    </ol>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="btnBettermentNotFreeze" runat="server" Text="Betterment (Not Freeze) & Proceed >>>" CssClass="InputButton" OnClick="btnBettermentNotFreeze_Click" /></center>
                    <br />
                </td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblFreeze" runat="server">
            <tr>
                <th align="left" style="background: #e8be42; color: White; border: 1px solid #c5b20b">
                    <font size="3">Freeze</font>
                </th>
            </tr>
            <tr>
                <td style="background-color: #fffbd6; border: 1px solid #c5b20b">

                    <p align="justify"><b>Other Than First Preference Allotted but Self Freezed by Candidate:-</b></p>
                    <ol class="list-text" type="a">
                        <%--  <li><p align = "justify">If the candidate is satisfied with such allotment and do not wish to participate in further CAP rounds, such candidate can freeze the offered seat through candidate’s login.</p></li>
                                <li><p align = "justify"><u>However, the candidate has to exercise this deliberate option of freezing cautiously with full understanding.</u></p></li>
                                <li><p align = "justify">Once the candidate willingly freezes the allotted seat, such candidate shall then report to ARC for verification of documents and payment of seat acceptance fee as per the notified schedule. Such candidate shall then be not eligible for participation in the subsequent CAP rounds. The allotment so made shall be the final allotment.</p></li>
                                <li><p align = "justify">Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat as per the notified schedule.</p></li>
                                <li><p align = "justify">If such candidate does not report to ARC for confirmation of seat acceptance, their claim on the allotted seat shall stand forfeited automatically.</p></li>--%>
                        <%--         <li><p align ="justify"> Candidate who have been allotted seat other than the first preference given by the candidate and if the candidate is satisfied with such allotment and do not wish to participate in further CAP rounds, such candidate can freeze the offered seat through candidate’s login. Once the candidate freezes the allotted seat, such candidate shall then report to ARC for verification of documents and payment of seat acceptance fee. Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat. If such candidate does not report to ARC for confirmation of seat acceptance, their claim on the allotted seat shall stand forfeited automatically and the seat shall become available for fresh allotment. For such candidate, the allotment so made shall be the final allotment. Such candidate shall then be not eligible for participation in the subsequent CAP rounds;
                              <br />  ज्या उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या  पसंतीक्रमांकाखेरीज इतर  पसंतीक्रमांकावरील  जागेचे वाटप झाल्यास आणि उमेदवार या वाटपाने संतुष्ट असल्यास आणि केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी  होण्याची त्याची इच्छा नसल्यास उमेदवार त्याच्या लॉग-इन मधून त्यास देऊ केलेली जागा स्वतः गोठवू शकतो. अशा प्रकारे जागा गोठविल्यावर असे  उमेदवार प्रवेश उपस्थिती केंद्रावर जागास्वीकृती करिता कागदपत्राची पडताळणी व  जागा स्विकृती शुल्क भरण्यासाठी हजर होतील. तदनंतर असे उमेदवार वाटप करण्यात आलेल्या जागेवर प्रवेश घेण्यासाठी वाटप करण्यात आलेल्या  संस्थेमध्ये हजर होतील.  असे उमेदवार जर प्रवेश उपस्थिती केंद्रावर जागास्वीकृती करिता हजर झाले नाहीत तर ते त्यांना वाटप करण्यात आलेल्या  जागेवरील हक्क  आपोआप गमावतील आणि ती जागा पुढील वाटपासाठी उपलब्ध होईल.   अश्या  उमेदवारांकरिता करण्यात आलेले हे जागावाटप अंतिम असेल व असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्यास पात्र नसतील;</p></li>
                              <li><p align = "justify">Reporting dates ARC for confirming the allotted seat at ARC<b> 14/08/2019 to 16/08/2019 </b></p></li>
                              <li><p align = "justify">Reporting dates for admission in the allotted Institute <b>14/08/2019 to 17/08/2019 </b></p></li>--%>
                        <li>
                            <p align="justify">
                                Candidate who have been allotted seat other than the first preference and if the candidate is satisfied with such allotment, such candidate can freeze the offered seat by self verifiying the current allotment and ensuring the correctness of the details given in the application form as per the rule no 9 (i) of the information brochure.
                                ज्या उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या पसंतीक्रमांकाखेरीज इतर पसंतीक्रमांकावरील जागेचे वाटप झाल्यास आणि उमेदवार या वाटपाने संतुष्ट असल्यास आणि केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्याची त्याची इच्छा नसल्यास उमेदवार त्यांना झालेल्या जागा वाटपाची स्वतः पडताळणी करून माहिती पुस्तिकेतील नियम क्र. ९ नुसार अर्जामध्ये दिलेल्या तपशीलांची अचूकता सुनिश्चित करून त्यास देऊ केलेली जागा स्वतः गोठवू शकतो.

                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                After freezing the allotted seat, such candidate shall report to the allotted institute and seek admission on the allotted seat. If such candidate does not report to the allotted insttiute his claim on the allotted seat shall stand forfeited automatically. 

                                ज्या उमेदवाराने त्यास देऊ केलेली जागा स्वतः गोठविली असे उमेदवार वाटप करण्यात आलेल्या जागेवर प्रवेश घेण्यासाठी वाटप करण्यात आलेल्या संस्थेमध्ये हजर होतील. असे उमेदवार वाटप झालेल्या संस्थेमध्ये विहित वेळेमध्ये प्रवेशासाठी हजर न झाल्यास असे उमेदवार त्यांना वाटप करण्यात आलेल्या जागेवरील हक्क आपोआप गमावतील .
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                For such candidate, the allotment so made shall be the final allotment.
                                अशा उमेदवारांकरिता करण्यात आलेले हे जागावाटप अंतिम असेल.
                            </p>
                        </li>

                        <li>
                            <p align="justify">
                                Last date for Confirmation of allotted seat is <b>16/12/2024 Up to 3 P.M.</b>
                                वाटप केलेल्या जागेच्या पुष्टीकरणाची अंतिम तारीख  <b>16/12/2024 Up to 3 P.M.</b> आहे.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                Last date for Confirmation of Admission in allotted Institute is <b>16/12/2024 Up to 5 P.M.</b>
                                वाटप झालेल्या संस्थेमध्ये प्रवेशासाठी अंतिम तारीख <b>16/12/2024 Up to 5 P.M.</b> आहे.
                            </p>
                        </li>


                    </ol>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="btnFreeze" runat="server" Text="Freeze & Proceed >>>" CssClass="InputButton" OnClick="btnFreeze_Click" /></center>
                    <br />
                </td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblAutoFreeze" runat="server">
            <tr>
                <th align="left" style="background: #7b63a5; color: White; border: 1px solid #7b63a5">
                    <font size="3">Auto Freeze</font>
                </th>
            </tr>
            <tr>
                <td style="background-color: #eae3f7; border: 1px solid #7b63a5">
                    <font size="4" color="red"><b>Congratulations!!! You have got the First Preference. So Your Offered Seat is Auto Freezed.</b></font>
                    <br />
                    <br />
                    <p align="justify"><b>If a candidate is allotted the seat as per his first preference:-</b></p>
                    <ol class="list-text" type="a">
                        <%--  <li><p align = "justify">Such allotment shall be <b>auto freezed</b> and the candidate shall accept the allotment so made.</p></li>
                                <li><p align = "justify">Such candidate shall not be eligible for participation in the subsequent CAP rounds.</p></li>
                                <li><p align = "justify">Such candidates shall then report to ARC for verification of documents and payment of seat acceptance fee as per the notified schedule.</p></li>
                                <li><p align = "justify">Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat as per the notified schedule.</p></li>
                                <li><p align = "justify">If such candidate does not report to ARC for confirmation of seat acceptance, their claim on the allotted seat shall stand forfeited automatically; the allotment so made shall be the final allotment.</p></li>--%>
                        <%--       <li><p align = "justify">If a candidate is allotted the seat as per his first preference, such allotment shall be auto freezed and the candidate shall accept the allotment so made. Such candidate shall then be not eligible for participation in the subsequent CAP rounds. Such candidates shall then report to ARC for verification of documents and payment of seat acceptance fee. Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat. If such candidate does not report to ARC for confirmation of seat acceptance, their claim on the allotted seat shall stand forfeited automatically and the seat shall become available for fresh allotment. For such candidate, the allotment so made shall be the final allotment;
                              <br />  जर उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या  पसंतीक्रमांकावरील जागेचे वाटप झाल्यास असे वाटप प्रणालीतून आपोआप गोठविले जाईल व उमेदवार या जागेचा स्वीकार करेल. असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्यास पात्र नसतील. असे  उमेदवार प्रवेश उपस्थिती केंद्रावर जागास्वीकृती करिता कागदपत्राची पडताळणी व  जागा स्विकृती शुल्क भरण्यासाठी हजर होतील. तदनंतर असे उमेदवार वाटप करण्यात आलेल्या जागेवर प्रवेश घेण्यासाठी वाटप करण्यात आलेल्या  संस्थेमध्ये हजर होतील. असे उमेदवार जर प्रवेश उपस्थिती केंद्रावर जागास्वीकृती करिता हजर झाले नाहीत तर ते त्यांना वाटप करण्यात आलेल्या  जागेवरील हक्क  आपोआप गमावतील आणि ती  जागा पुढील वाटपासाठी उपलब्ध होईल.  अश्या  उमेदवारांकरिता करण्यात आलेले हे जागावाटप अंतिम असेल;</p></li>
                                   <li><p align = "justify">Reporting dates ARC for confirming the allotted seat at ARC<b> 14/08/2019 to 16/08/2019 </b></p></li>
                                <li><p align = "justify">Reporting dates for admission in the allotted Institute <b>14/08/2019 to 17/08/2019</b></p></li>--%>

                        <li>
                            <p align="justify">
                                If a candidate is allotted the seat as per his first preference, such allotment shall be auto freezed and the candidate shall accept the allotment so made. Such candidates follow the instructions given at clause 9(1)(i) above. Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat. If such candidate does not follow the instructions given in clause 9(1)(i) , their claim on the allotted seat shall stand forfeited automatically. For such candidate, the allotment so made shall be the final allotment;
जर उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या पसंतीक्रमांकावरील जागेचे वाटप झाल्यास असे वाटप प्रणालीतुन आपोआप गोठिवले जाईल. असे उमेदवार जागा वाटपाची स्वःता पडताळणी करुन माहिती पुस्तीकेतील नियम क्र. ९ नुसार अर्जामध्ये दिलेल्या तपशीलांची अचूकता सुनिश्चित करतील व या जागेचा स्विकार करतील . तदनंतर असे उमेदवार वाटप करण्यात आलेल्या जागेवर प्रवेश घेण्यासाठी वाटप करण्यात आलेल्या संस्थेमध्ये हजर होतील. असे उमेदवार वाटप झालेल्या संस्थेमध्ये विहित वेळेमध्ये प्रवेशासाठी हजर न झाल्यास असे उमेदवार त्यांना वाटप करण्यात आलेल्या जागेवरील हक्क आपोआप गमावतील . अशा उमेदवारांकरीता करण्यात आलेले हे जागावाटप अंतिम असेल;
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                Candidate shall pay the seat acceptance fee through online mode for the purpose of accepting the allotted seat.
उमेदवाराने दिलेली जागा स्वीकारण्याच्या उद्देशाने जागा स्वीकृती शुल्क ऑनलाईन पध्दतीने भरले पाहिजे.

                            </p>
                        </li>

                        <li>
                            <p align="justify">
                                Last date for Confirmation of allotted seat is <b>16/12/2024 Up to 3 P.M.</b>
                                वाटप केलेल्या जागेच्या पुष्टीकरणाची अंतिम तारीख  <b>16/12/2024 Up to 3 P.M.</b> आहे.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                Last date for Confirmation of Admission in allotted Institute is <b>16/12/2024 Up to 5 P.M.</b>
                                वाटप झालेल्या संस्थेमध्ये प्रवेशासाठी अंतिम तारीख <b>16/12/2024 Up to 5 P.M.</b> आहे.
                            </p>
                        </li>

                    </ol>
                    <br />
                    <br />
                    <center>
                        <asp:Button ID="btnAutoFreeze" runat="server" Text="Auto Freeze & Proceed >>>" CssClass="InputButton" OnClick="btnAutoFreeze_Click" /></center>
                    <br />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="contentOTPVerify" runat="server" Visible="false" HeaderVisible="false">
        <asp:HiddenField ID="hdnPassword" runat="server" />
        <div class="table-responsive">
            <table class="AppFormTable">
                <tr id="trEligibilityRemark" runat="server" visible="false">
                    <td colspan="4">
                        <asp:Label ID="lblEligibilityRemark" runat="server" ForeColor="Red"> </asp:Label></td>
                </tr>
            </table>
            <table id="tblPasword" class="AppFormTable" runat="server">

                <tr id="tr1" runat="server">
                    <td align="right" style="width: 50%;">Enter Your Login Password
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20" autocomplete="off"></asp:TextBox>
                        <font color="red"><sup>*</sup></font>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                            Display="None" ErrorMessage="Enter Password" ValidationGroup="password"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <br />
                <tr>
                    <td align="center" colspan="3">
                        <br />
                        <br />
                        <asp:Button ID="btnpassword" runat="server" Text="Verify Password" CssClass="InputButton"
                            OnClick="btnpassword_Click" ValidationGroup="password" Style="font-size: medium; height: 30px; font-weight: bold; background-color: red;" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False"
                            ShowMessageBox="True" ValidationGroup="password" />
                        &nbsp;&nbsp;
                                  <asp:Button ID="btnReset1" runat="server" Text="Reset" CssClass="InputButton" OnClick="btnReset_Click" />
                    </td>

                </tr>
            </table>
        </div>
        <div class="table-responsive">
            <table id="tblOtp" class="AppFormTable" runat="server">
                <tr id="trMobileNo" runat="server" visible="False">
                    <td colspan="4" align="center">OTP has been sent your Mobile No :  
                                <asp:Label ID="lblMaskMobileno" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 50%">Enter One Time Password (OTP)
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtOneTimePassword" runat="server" MaxLength="6" onKeyPress="return numbersonly(event)"
                            autocomplete="off"> </asp:TextBox>
                        <font color="red"><sup>*</sup></font>
                        <asp:RequiredFieldValidator ID="rfvOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword"
                            Display="None" ErrorMessage="Please Enter One Time Password (OTP)." ValidationGroup="otp"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword"
                            Display="None" ErrorMessage="One Time Password (OTP) Should be of 6 Digits."
                            ValidationExpression="\d{6}" ValidationGroup="otp"></asp:RegularExpressionValidator>
                        <asp:Button ID="btnCall" runat="server" CssClass="InputButton" OnClick="btnCall_Click"
                            Text="Retry on Call" Visible="false" ValidationGroup="call" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <br />
                        <br />
                        <asp:Button ID="btnVerifyOtp" runat="server" Text="Verify OTP for Seat Acceptance Status"
                            CssClass="InputButton" OnClick="btnVerifyOtp_Click" ValidationGroup="otp" Style="font-size: medium; height: 30px; font-weight: bold; background-color: red;" />
                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowSummary="False"
                            ShowMessageBox="True" ValidationGroup="otp" />
                        &nbsp;&nbsp;
                                  <asp:Button ID="Button1" runat="server" Text="Reset" CssClass="InputButton" OnClick="btnReset_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </cc1:ContentBox>
</asp:Content>
