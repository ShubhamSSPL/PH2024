<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" CodeBehind="frmVerifyAndConfirmOptionForm.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound3.frmVerifyAndConfirmOptionForm" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_ContentBox1 {
            top: 20% !important;
            width: 1000px;
        }

        #layoutSidenav #layoutSidenav_content {
            margin-left: unset !important;
        }

        #rightContainer_ContentTable1_gvSelectedOptionsList input[type='checkbox'] {
            width: 20px;
            height: 20px;
        }

        #rightContainer_ContentBox1_ContentBoxOverlayTwo {
            position: fixed !important;
        }

        @media only screen and (max-width: 768px) {
            #rightContainer_ContentBox1 {
                top: 25% !important;
                width: 100%;
            }
        }
    </style>
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            var success = document.getElementById('<%= hdnStepID.ClientID%>').value;
            for (var i = 1; i <= success; i++) {
                $('#nav' + i).addClass('sf-success');
            }
        });
    </script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
        function checkConfirmation(Source, args) {
            var confirmationValue = confirm("I agree to Confirm my Option Form. \nI am aware that I will not be able to modify / change / alter my Choices once I confirm the Option Form.\n\nAre you sure you want to confirm your Option Form ?");
            if (confirmationValue == true) {
                var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                cvCheckConfirmation.errormessage = 'We are confirming your Option Form. Please wait...';
                args.IsValid = true;
            }
            else {
                var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                cvCheckConfirmation.errormessage = 'We are not confirming your Option Form...';
                args.IsValid = false;
            }
        }
    </script>
    <script language="javascript" type="text/javascript">

        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        function showRetryTiemout() {
            var rCounter = 45
            var timerInterval = setInterval(function () {
                document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#1abc9c";
                document.getElementById("rightContainer_cbPassword_btnCall").disabled = true;
                document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry in " + rCounter + " Second";

                if (rCounter == 0) {
                    rCounter = 45;
                }
                rCounter--;
            }, 1000);
            setTimeout(function () {
                document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#2966C0";
                document.getElementById("rightContainer_cbPassword_btnCall").disabled = false;
                document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry on Call";
                document.getElementById("rightContainer_cbPassword_rfvOneTimePassword").enabled = false;
                document.getElementById("rightContainer_cbPassword_revOneTimePassword").enabled = false;

                clearInterval(timerInterval);
            }, 45000);
        }
        function showRetryTiemouts() {

            var rCounter = 45
            var timerInterval = setInterval(function () {
                document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#1abc9c";
                document.getElementById("rightContainer_cbPassword_btnCall").disabled = true;
                document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry in " + rCounter + " Second";

                if (rCounter == 0) {
                    rCounter = 45;
                }
                rCounter--;
            }, 1000);
            setTimeout(function () {
                document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#2966C0";
                document.getElementById("rightContainer_cbPassword_btnCall").disabled = false;
                document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry on Call";
                document.getElementById("rightContainer_cbPassword_rfvOneTimePassword").enabled = false;
                document.getElementById("rightContainer_cbPassword_revOneTimePassword").enabled = false;
                clearInterval(timerInterval);
            }, 45000);
        }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            if (document.getElementById("rightContainer_cbPassword_tblOtp") != null) {
                showRetryTiemout();
            }
        }
        window.onload = load;
    </script>
    <cc1:ContentBox ID="cbMenu" runat="server" HeaderVisible="false">
        <center>
            <div class="stepsForm">
                <div class="sf-steps">
                    <div class="sf-steps-content">
                        <div id="nav1">
                            <span>1</span><a id="a_1" runat="server" class="formWizard" href="frmShortListOptions.aspx?tms=101">Shortlist
                                Your Options</a>
                        </div>
                        <div id="nav2">
                            <span>2</span><a id="a_2" runat="server" class="formWizard" href="frmSetPreferences.aspx?tms=101">Set
                                Your Preferences</a>
                        </div>
                        <div id="nav3">
                            <span>3</span><a id="a_3" runat="server" class="formWizard" href="frmOptionFormSummary.aspx?tms=101">Option
                                Form Summary</a>
                        </div>
                        <div id="nav4" class="sf-active">
                            <span>4</span><a id="a_4" runat="server" class="formWizard" href="frmConfirmOptionForm.aspx?tms=101">Confirm
                                Your Option Form</a>
                        </div>
                    </div>
                </div>
            </div>
        </center>
        <input type="hidden" id="hdnStepID" runat="server" />
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbPassword" runat="server" HeaderText="Confirm Option Form">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td colspan="4">
                    <p align="justify">
                        <font color="red">
                            <ol class="list-text">
                                <li>Filling up and confirmation of online option form having preferences of Courses and Institutions prior to respective CAP Rounds. Candidates may fill in preferences of Institutes and Courses in decreasing order of their preference as specified by Competent Authority. The option form once confirmed by the candidate through their login shall be considered for allotment in the respective CAP Rounds.</li>
                                <li>Candidates may fill in maximum 300 choices of Institutes and Courses in decreasing order of their preference.</li>
                                <li>In order to participate in the CAP (subject to fulfilment of the eligibility requirements of respective CAP round), it is MANDATORY to fill the Online Option Form for respective CAP Round.</li>
                                <li>It is mandatory for all eligible candidates to confirm the online option form.</li>
                                <li>After confirmation of Option form, the candidate will not be able to change the Options.</li>
                                <li>The serial number of blocks in the option form indicates preference of choice. Thus, the choice code of the institute filled by the candidate in block No. 1 will be considered as first preference (Highest Priority Choice).</li>
                                <li>Option form received through online submission only will be considered for further processing.</li>
                                <li>Candidate shall confirm the submitted on-line Option Form by re-entering Login Password. The candidate can take a printout of the confirmed Option form for his record and future reference.</li>
                                <li>Candidates should not disclose their Application ID & Password to others to avoid impersonation. Competent Authority shall not be responsible for submissions done by others on behalf of the candidate. For Security reasons, candidates are instructed to keep changing the password and keep note of it in secured place.</li>
                            </ol>
                        </font>
                    </p>
                </td>
            </tr>
        </table>
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upQualification">
            <ContentTemplate>
                <asp:HiddenField ID="hdnPassword" runat="server" />
                <table id="tblPasword" class="AppFormTable" runat="server">
                    <tr runat="server" id="trPassOTPNote">
                        <td align="center" style="width: 50%; color: red" colspan="2">
                            <b>To confirm, you have to enter your Login password, then OTP will be sent to your registered 
                                <asp:Label ID="lblMaskMobileno1" runat="server" Font-Bold="true"></asp:Label>
                                mobile number.</b>
                        </td>
                    </tr>
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
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                ShowMessageBox="True" ValidationGroup="password" />
                        </td>
                    </tr>
                </table>
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
                        <td style="width: 50%" align="right">Enter Captcha Given Below (case sensitive)                      
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtSecurityPin" runat="server" MaxLength="5" Width="100px" onmouseover="ddrivetip('Please Enter Captcha (case sensitive).')" onmouseout="hideddrivetip()" autocomplete="off"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvSecurityPin" runat="server" ControlToValidate="txtSecurityPin" ErrorMessage="Please Enter Captcha (case sensitive)." Display="None" ValidationGroup="otp"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Captcha
                        </td>
                        <td style="width: 15%">
                            <cc2:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5" CaptchaHeight="40" CaptchaWidth="190" CaptchaFont="Verdana" Font-Bold="false" Font-Italic="true" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ23456789" />
                        </td>
                        <td>
                            <asp:ImageButton runat="server" ID="btnUpdateSecurityPin" ImageUrl="../Images/refresh.png" ValidationGroup="UpdateSecurityPin" Height="40px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <br />
                            <br />
                            <asp:Button ID="btnVerifyOtp" runat="server" Text="Confirm Option Form" CssClass="InputButton"
                                OnClick="btnVerifyOtp_Click" ValidationGroup="otp" Style="font-size: medium; height: 40px; font-weight: bold; background-color: red;" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False"
                                ShowMessageBox="True" ValidationGroup="otp" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
