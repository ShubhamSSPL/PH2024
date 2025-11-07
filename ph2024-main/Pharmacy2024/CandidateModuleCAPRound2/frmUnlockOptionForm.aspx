<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" CodeBehind="frmUnlockOptionForm.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound2.frmUnlockOptionForm" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
                  <style>
   
        #rightContainer_ContentBox1{
            top:20% !important;
             width:1000px;
        }
      #layoutSidenav #layoutSidenav_content {
            margin-left: unset !important;
        }

        #rightContainer_ContentTable1_gvSelectedOptionsList input[type='checkbox'] {
            width: 20px;
            height: 20px;
        }
        #rightContainer_ContentBox1_ContentBoxOverlayTwo{
            position:fixed !important;
        }
       
        @media only screen and (max-width: 768px) {
 #rightContainer_ContentBox1{
     top:25% !important;
            width:100%;
        }
        }
    </style>
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" language="javascript"></script>
 
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
//                document.getElementById("rightContainer_cbPassword_revOneTimePassword").enabled = false;

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
//                document.getElementById("rightContainer_cbPassword_revOneTimePassword").enabled = false;
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
     
    <cc1:ContentBox ID="cbPassword" runat="server" HeaderText="Unlock option form">
        <table class="AppFormTableWithOutBorder">
            <tr>
                 <td colspan = "3">
                     
                     <ol class="list-text">
                        <li>
                            <p align="justify">
                             	The Candidate whose name appeared in Final Merit List (Maharashtra State / All India) is Eligible to Submit Option Form.
                            </p>
                        </li>
                            <li>
                            <p align="justify">
                             		The Scrutiny Center shall act only as facilitator for Candidate to Submit and Confirm Online Option Form. It will be the responsibility of the candidate to Un-Lock and Re-Submit and Confirm Online Option Form by himself/herself through their login. DO NOT SHARE PASSWORD and OTP, instead type the password by himself /herself.
                            </p>
                        </li>
                            <li>
                            <p align="justify">
                             The Candidate who has Submitted and Confirmed Online Option Form through Candidate Login by himself/herself and wish to UN-lock Option Form can click on “ Revised Option Form (UN-Confimation)”.
                            </p>
                        </li>
                            <li>
                            <p align="justify">
                             	After that, Candidate will have to select the Course & Other Search Criteria and then click on 'Search' button. All the Institutes under that Search Criteria will be displayed.
                            </p>
                        </li>
                            <li>
                            <p align="justify">
                                To shortlist an option candidate has to select the Institute by clicking on the Checkbox given in front of the Institute name.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                              She/he can go on selecting as many options as candidate wants by clicking on the Institutes.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                           	Once candidate finalizes all his options, only then candidate can click on Proceed button.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                            	All the options selected by her/his will be shown.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                              	If candidate wants to change the short listed options then candidate is also allowed to do so.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                              	You can go on clicking one by one on the check box given in front of the option to set preferences with highest priority first.
                            </p>
                        </li>    
                        <li>
                            <p align="justify">
                               	If you wish to reset the preferences then click on Reset preferences button or click on confirm button.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                              	Then all the options in order of preferences given by you are shown.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                      	Candidate can modify preferences, add choices, delete choices before confirmation of the online Option Form.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                            	You can repeat these steps as many times as you want till you Confirm your Option Form. Once you are sure then confirm your Option Form by entering the password once again. Candidate shall take print out of Receipt-cum-Acknowledgement of Option Form.
                            </p>
                        </li>
                          <li>
                            <p align="justify">
                            	The Option Form just submitted, but not confirmed by the candidate himself/herself will not be processed for allotment.
                            </p>
                        </li>
                          <li>
                            <p align="justify">
                            	Candidate should keep the printout of the online Option/Preference form after Re-confirmation for future reference. They can view the detailed option form having the details of the Choice Codes.
                            </p>
                        </li>
                    </ol>
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
                  
                    <tr id="tr1" runat="server">
                        <td align="right" style="width: 50%;">
                          Enter Your Login Password to receive OTP
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
                                OnClick="btnpassword_Click" ValidationGroup="password" Style="font-size: medium;
                                height: 30px; font-weight: bold; background-color: red;" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                ShowMessageBox="True" ValidationGroup="password" />
                        </td>
                    </tr>
                </table>
                <table id="tblOtp" class="AppFormTable" runat="server">
                    <tr id="trMobileNo" runat="server" Visible="False">
                        <td colspan="4" align="center">
                          OTP has been sent your Mobile No :   <asp:Label ID="lblMaskMobileno" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">
                            Enter One Time Password (OTP)
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
                            <asp:Button ID="btnVerifyOtp" runat="server" Text=" Unlock Option Form"
                                CssClass="InputButton" OnClick="btnVerifyOtp_Click" ValidationGroup="otp" Style="font-size: medium;
                                height: 40px; font-weight: bold; background-color: red;" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False"
                                ShowMessageBox="True" ValidationGroup="otp" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
