<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCheckCETDetails.aspx.cs" Inherits="Pharmacy2024.RegistrationModule.frmCheckCETDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        /* @media only screen and (width: 320px) {
            #layoutSidenav {
                margin-top: 75.5% !important;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 97% !important;
            }
        }

        @media only screen and (max-width: 425px) {
            #layoutSidenav {
                margin-top: 52.5%;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 89%;
            }
        }

        @media only screen and (width: 768px) {
            #layoutSidenav {
                margin-top: 17.5% !important;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 59%;
            }
        }

        @media only screen and (width:1024px) {
            #layoutSidenav {
                margin-top: 12.4%;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 57%;
            }
        }*/
         #rightContainer_ContentTable2_chkIAgree {
            width: 20px;
            height: 20px;
        }
    </style>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        function checkAppearedForCET(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnAppearedForCETYes").checked || document.getElementById("rightContainer_ContentTable2_rbnAppearedForCETNo").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
        function checkAppearedForJEE(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnAppearedForJEEYes").checked || document.getElementById("rightContainer_ContentTable2_rbnAppearedForJEENo").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
        function checkCandidateType(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnCandidateTypeYes").checked || document.getElementById("rightContainer_ContentTable2_rbnCandidateTypeNo").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
        function checkQualifyingExam(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnQualifyingExamHSC").checked || document.getElementById("rightContainer_ContentTable2_rbnQualifyingExamDiploma").checked || document.getElementById("rightContainer_ContentTable2_rbnQualifyingExamBSc").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtCETDOB").value;
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
        function isDateValidF(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtDOB").value;
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
        function ValidateDeclaration(sender, args) {
            if (document.getElementById('rightContainer_ContentTable2_chkIAgree').checked == false) {
                alert('Please Confirm your declaration.');
                args.IsValid = false;
                return;
            }
            else {
                args.IsValid = true;
                return;
            }

        }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {

            if (document.getElementById("rightContainer_ContentTable2_txtCETDOB") != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtCETDOB'));
            }
            if (document.getElementById("rightContainer_ContentTable2_txtDOB") != null) {
                var dp_calF = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDOB'));
            }
        }
        window.onload = load;
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upCET">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 50%" align="right">Have you Appeared for <%=MHTCETName %> ?</td>
                        <td style="width: 50%">
                            <asp:RadioButton ID="rbnAppearedForCETYes" runat="server" GroupName="AppearedForCET" Text="&nbsp;&nbsp;Yes" AutoPostBack="true" OnCheckedChanged="AppearedForCET_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnAppearedForCETNo" runat="server" GroupName="AppearedForCET" Text="&nbsp;&nbsp;No" AutoPostBack="true" OnCheckedChanged="AppearedForCET_CheckedChanged" />
                            <asp:CustomValidator ID="cvAppearedForCET" runat="server" ClientValidationFunction="checkAppearedForCET" Display="None"></asp:CustomValidator>
                        </td>
                    </tr>
                    <%--  <tr id = "trAppearedForJEE" runat = "server">
                        <td align ="right">Have you Appeared for <%=JEEName %> ?</td>
                        <td>
                            <asp:RadioButton ID="rbnAppearedForJEEYes" runat="server" GroupName="AppearedForJEE" Text="&nbsp;&nbsp;Yes" AutoPostBack = "true" OnCheckedChanged="AppearedForJEE_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnAppearedForJEENo" runat="server" GroupName="AppearedForJEE" Text="&nbsp;&nbsp;No" AutoPostBack = "true" OnCheckedChanged="AppearedForJEE_CheckedChanged" />
                            <asp:CustomValidator ID="cvAppearedForJEE" runat="server" ClientValidationFunction="checkAppearedForJEE" Display="None" ></asp:CustomValidator>
                        </td>
                    </tr>--%>
                    <tr id="trAppearedForNEET" runat="server">
                        <td align="right">Have you Appeared for NEET <%=CurrentYear %> ?
                        </td>
                        <td>
                            <asp:RadioButton ID="rbnAppearedForNEETYes" runat="server" GroupName="AppearedForNEET"
                                Text="&nbsp;&nbsp;Yes" AutoPostBack="true" OnCheckedChanged="AppearedForNEET_CheckedChanged"
                                onmouseover="ddrivetip('Please Select Appeared Status for NEET 2024.')" onmouseout="hideddrivetip()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnAppearedForNEETNo" runat="server" GroupName="AppearedForNEET"
                                Text="&nbsp;&nbsp;No" AutoPostBack="true" OnCheckedChanged="AppearedForNEET_CheckedChanged"
                                onmouseover="ddrivetip('Please Select Appeared Status for NEET 2024.')" onmouseout="hideddrivetip()" />
                            <asp:CustomValidator ID="cvAppearedForNEET" runat="server" ClientValidationFunction="checkAppearedForNEET"
                                Display="None" ErrorMessage="Please Select Appeared Status for NEET 2024."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id = "trCandidateType" runat = "server">
                        <td align ="right">Are You Foreign National / NRI / PIO / OCI / CIWGC ?</td>
                        <td>
                            <asp:RadioButton ID="rbnCandidateTypeYes" runat="server" GroupName="CandidateType" Text="&nbsp;&nbsp;Yes" AutoPostBack = "true" OnCheckedChanged="CandidateType_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnCandidateTypeNo" runat="server" GroupName="CandidateType" Text="&nbsp;&nbsp;No" AutoPostBack = "true" OnCheckedChanged="CandidateType_CheckedChanged" />
                            <asp:CustomValidator ID="cvCandidateType" runat="server" ClientValidationFunction="checkCandidateType" Display="None" ErrorMessage="Please Select Foreign National/NRI/PIO/OCI/CIWGC Candidate Type."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id="trCandidateType2" runat="server">
                        <td align="right">Are You NEUT / JKSSS / PMSSS Candidate ?</td>
                        <td>
                            <asp:RadioButton ID="rbnCandidateType2Yes" runat="server" GroupName="CandidateType2" Text="&nbsp;&nbsp;Yes" AutoPostBack="true" OnCheckedChanged="CandidateType2_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnCandidateType2No" runat="server" GroupName="CandidateType2" Text="&nbsp;&nbsp;No" AutoPostBack="true" OnCheckedChanged="CandidateType2_CheckedChanged" />
                            <asp:CustomValidator ID="cvcCandidateType2" runat="server" ClientValidationFunction="checkCandidateType2" Display="None" ErrorMessage="Please Select Foreign National/NEUT/JKSSS Candidate Type."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id="trQualifyingExam" runat="server">
                        <td align="right">Qualifying Exam</td>
                        <td>
                            <asp:RadioButton ID="rbnQualifyingExamHSC" runat="server" GroupName="QualifyingExam" Text="&nbsp;&nbsp;HSC" />
                            <br />

                            <asp:RadioButton ID="rbnQualifyingExamDiploma" runat="server" GroupName="QualifyingExam" Text="&nbsp;&nbsp;Diploma in Pharmacy" Visible="false" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnQualifyingExamBSc" runat="server" GroupName="QualifyingExam" Text="&nbsp;&nbsp;B.Sc." Visible="false" />
                            <asp:CustomValidator ID="cvQualifyingExam" runat="server" ClientValidationFunction="checkQualifyingExam" Display="None" ErrorMessage="Please Select Qualifying Exam."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id="trCETApplicationFormNo" runat="server">
                        <td align="right"><%=MHTCETName %> Application Number</td>
                        <td>
                            <asp:TextBox ID="txtCETApplicationFormNo" MaxLength="9" runat="server" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvCETApplicationFormNo" runat="server" Display="None" ControlToValidate="txtCETApplicationFormNo"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCETApplicationFormNo" runat="server" Display="None" ValidationExpression="\d{9}" ControlToValidate="txtCETApplicationFormNo"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr id="trCETRollNo" runat="server">
                        <td align="right"><%=MHTCETName %> Roll Number</td>
                        <td>
                            <asp:TextBox ID="txtCETRollNo" runat="server" MaxLength="10" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <br />
                            <font color="red"><b>Note :</b> Please enter your CET Roll No in which you have obtained highest score.(PCM or PCB) </font>

                            <asp:RequiredFieldValidator ID="rfvCETRollNo" runat="server" Display="None" ControlToValidate="txtCETRollNo"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCETRollNo" runat="server" Display="None" ValidationExpression="\d{10}" ControlToValidate="txtCETRollNo"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr id="trCETName" runat="server">
                        <td align="right"><%=MHTCETName %> DOB</td>
                        <td>
                            <asp:TextBox ID="txtCETDOB" runat="server" MaxLength="10"  onmouseover="ddrivetip('Please Select DOB. It should be in DD/MM/YYYY format.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>(DD/MM/YYYY)
                            <asp:RequiredFieldValidator ID="rfvCETDOB" runat="server" ControlToValidate="txtCETDOB" Display="None"  ></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvCETDOB" runat="server" ControlToValidate="txtCETDOB" ClientValidationFunction="isDateValid"  ErrorMessage="Please Select Proper DOB." ></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id="trCheckCETDetails" runat="server">
                        <td colspan="2" align="center">
                            <asp:Button ID="btnCheckCETDetails" runat="server" Text="Check CET Details" CssClass="InputButton" BackColor="Red" OnClick="btnCheckCETDetails_Click" />
                        </td>
                    </tr>
                    <tr id="trCheckFCRDetails" runat="server">
                        <td align="right">Enter Foreign Registration Application Number</td>
                        <td>
                            <asp:TextBox ID="txtFCRApplicationFormNo" MaxLength="11" runat="server"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvFCRApplicationFormNo" runat="server" Display="None" ControlToValidate="txtFCRApplicationFormNo"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator id="revNRIPIOOCICIWGC" Runat="server" Display="None" ValidationExpression="\d{9}" ControlToValidate="txtFCRApplicationFormNo" ></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                     <tr id="trCheckFCRDOB" runat="server">
                        <td align="right">Enter Date Of Birth</td>
                        <td>
                            <asp:TextBox ID="txtDOB" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                            <font color="red"><sup>*</sup></font> (DD/MM/YYYY)
                            <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB" Display="None" ErrorMessage="Please Enter Your Date of Birth."></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValidF" Display="None" ErrorMessage="Please Select Proper Date of Birth."></asp:CustomValidator>
                        </td>
                    </tr>
                     <tr id="trFCRGetData" runat="server">
                        <td colspan="2" align="center">
                            <asp:Button ID="btnFCRGetData" runat="server" Text="Check Foreign Registration Details" CssClass="InputButton" BackColor="Red" OnClick="btnCheckFCRGetData_Click" />
                            <br/>
                            <asp:Label ID="lblNote" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table id="tblCETDetails" runat="server" class="AppFormTable">
                    <tr>
                        <th colspan="4" style="border-top-width: 0px;" align="left"><%= MHTCETPercentile %></th>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 50%" align="right">Candidate Name</td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trCET1" runat="server">
                        <td style="width: 50%" colspan="2" align="right">Physics </td>
                        <td style="width: 50%" colspan="2">
                            <asp:Label ID="lblCETPhysicsMarks" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trCET2" runat="server">
                        <td align="right" colspan="2">Chemistry </td>
                        <td colspan="2">
                            <asp:Label ID="lblCETChemistryMarks" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trCET3" runat="server">
                        <td align="right" colspan="2">
                            <asp:Label ID="lblSubjectName" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblCETMathMarks" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trCET4" runat="server">
                        <td align="right" colspan="2">
                            <asp:Label ID="lblGroupName" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblCETPCMTotalMarks" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trCET5" runat="server">
                        <td style="width: 25%" align="right">Message</td>
                        <td style="width: 75%" colspan="3">
                            <asp:Label ID="lblNoCET" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                </table>
                <table id="tblFRNoDetails" runat="server" class="AppFormTable">
                    <tr id="trFCRApplicationNo" runat="server" visible="false">
                        <td colspan="4" style="width: 50%" align="right">FCR Candidate Application No </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRApplicationNo" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 50%" align="right">Candidate Name As Per FCR </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 50%" align="right">Candidature Type Name As Per FCR </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRCandidatureTypeName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 50%" align="right">Mother Name As Per FCR </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRMotherName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 50%" align="right">Gender As Per FCR </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRGender" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 50%" align="right">DOB As Per FCR </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRDOB" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                </table>
                <table>
                    <tr>
                <td align="left">
                    <p align = "justify" style="color:red"><b>Important Instructions for Candidates :</b></p>
                    <ol class="list-text">
                        <li><p align = "justify">Read the information brochure carefully before filling in the CAP application form.</p></li>
                        <li><p align = "justify">Make sure all supporting documents are properly scanned and uploaded for documents verification as per the Proforma mentioned in the information brochure.</p></li>
                        <li><p align = "justify">kindly check following details before sending for e-verification:- Verify Your Name, Category, Gender, Photo, Signature, Exam Marks and Name on Marksheet as well as any additional information, such as the status of the EWS, validity, required format, etc.</p></li>
                        <li><p align = "justify">Check daily SMS, WhatsApp messages on your registered mobile number; login to your account to read messages in your message box; and registered e-mail for important information from State CET Cell until the end of the CAP process.</p></li>
                        <li><p align = "justify">Check the official State CET website daily for the latest notification published by the State CET cell.</p></li>
                        <li><p align = "justify">Please check the important dates of the various activities and complete the activities according to schedule.</p></li>
                        <li><p align = "justify">Download & install mobile app from play store iOS/ android for latest updates.</p></li>
                    </ol>
                </td>
            </tr>
                    <tr>
                          <td>
                              <p align="justify" style="color:red">
                                <asp:CheckBox ID="chkIAgree" runat="server" AutoPostBack="true" /> 
                                  <font color="red"><b> I have read all Important Instructions.</b></font>
                                 </p>
                               <%--<asp:CustomValidator ID="CvIAgree" runat="server" ClientValidationFunction="ValidateDeclaration" Display="None"></asp:CustomValidator>--%>
                                </td>
                           </tr>
                </table>

                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" Visible="false" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                        </td>
                    </tr>
                </table>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
    <cc1:ContentBox ID="contentSecretKey" runat="server" HeaderText="Secret Key" BoxType="PopupBox"
        Width="50%" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Text="This Screate is only for Testing Purpose. Registration Window is not Opened till Now. "
                        ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblmsg" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;" align="right">Enter Secret Key
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtkey" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSecretKey" runat="server" OnClick="btnSecretKey_Click" Text="Submit"
                        ValidationGroup="secret" />
                </td>
            </tr>
        </table>
        <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        function showSecretKey() {
            document.getElementById('<%=contentSecretKey.ClientID %>').Show('', true);
        }
    </script>
</asp:Content>







