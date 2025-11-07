<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmWillingnessForAdmissionCancellation.aspx.cs" Inherits="Pharmacy2024.CandidateAdmissionReportingModule.frmWillingnessForAdmissionCancellation" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
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
        function checkWillingnessForAdmissionCancellation(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnYes").checked || document.getElementById("rightContainer_ContentTable2_rbnNo").checked) {
            }
            else {
                args.IsValid = false;
            }
        }

        function checkConfirmation(Source, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnYes").checked) {
                var confirmationValue = confirm("I am aware of that after cancellation of my admission through online system, the seat shall be released for admission to others, if any, and I shall not claim the seat.\n\nAre you sure you want to Cancel your Admission ?");
                if (confirmationValue == true) {
                    var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                    cvCheckConfirmation.errormessage = 'We are taking your request for Cancellation of Admission. Please wait...';
                    args.IsValid = true;
                }
                else {
                    var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                    cvCheckConfirmation.errormessage = 'We are not taking your request for Cancellation of Admission...';
                    args.IsValid = false;
                }
            }
            else {
                var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                cvCheckConfirmation.errormessage = 'We are not taking your request for Cancellation of Admission...';
                args.IsValid = false;
            }
        }
        function showRetryTiemout() {
            var rCounter = 45
            var timerInterval = setInterval(function () {
                document.getElementById("rightContainer_ContentTable2_btnCall").style.backgroundColor = "#1abc9c";
                document.getElementById("rightContainer_ContentTable2_btnCall").disabled = true;
                document.getElementById("rightContainer_ContentTable2_btnCall").value = "Retry in " + rCounter + " Second";

                if (rCounter == 0) {
                    rCounter = 45;
                }
                rCounter--;
            }, 1000);
            setTimeout(function () {
                document.getElementById("rightContainer_ContentTable2_btnCall").style.backgroundColor = "#2966C0";
                document.getElementById("rightContainer_ContentTable2_btnCall").disabled = false;
                document.getElementById("rightContainer_ContentTable2_btnCall").value = "Retry on Call";
                document.getElementById("rightContainer_ContentTable2_rfvOneTimePassword").enabled = false;
                document.getElementById("rightContainer_ContentTable2_revOneTimePassword").enabled = false;

                clearInterval(timerInterval);
            }, 45000);
        }
        function showRetryTiemouts() {

            var rCounter = 45
            var timerInterval = setInterval(function () {
                document.getElementById("rightContainer_ContentTable2_btnCall").style.backgroundColor = "#1abc9c";
                document.getElementById("rightContainer_ContentTable2_btnCall").disabled = true;
                document.getElementById("rightContainer_ContentTable2_btnCall").value = "Retry in " + rCounter + " Second";

                if (rCounter == 0) {
                    rCounter = 45;
                }
                rCounter--;
            }, 1000);
            setTimeout(function () {
                document.getElementById("rightContainer_ContentTable2_btnCall").style.backgroundColor = "#2966C0";
                document.getElementById("rightContainer_ContentTable2_btnCall").disabled = false;
                document.getElementById("rightContainer_ContentTable2_btnCall").value = "Retry on Call";
                document.getElementById("rightContainer_ContentTable2_rfvOneTimePassword").enabled = false;
                document.getElementById("rightContainer_ContentTable2_revOneTimePassword").enabled = false;
                clearInterval(timerInterval);
            }, 45000);
        }
        function EndRequestHandler() {
            if (document.getElementById("rightContainer_ContentTable2_tblOtp") != null) {
                showRetryTiemout();
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Request for Cancellation of Admission">
        <table class="AppFormTable">
            <tr>
                <th align="left" colspan="2">
                    Admission Details
                </th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">
                    Institute Admitted
                </td>
                <td style="width: 75%">
                    <asp:Label ID="lblInstituteAdmitted" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Course Admitted
                </td>
                <td>
                    <asp:Label ID="lblCourseAdmitted" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Seat Type Admitted
                </td>
                <td>
                    <asp:Label ID="lblSeatTypeAdmitted" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Admission Date
                </td>
                <td>
                    <asp:Label ID="lblAdmissionDate" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Admitted Through
                </td>
                <td>
                    <asp:Label ID="lblAdmittedThrough" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">
                    Request for Cancellation of Admission
                </th>
            </tr>
            <tr id="tryesno" runat="server">
                <td style="width: 40%;" align="right">
                    Willing to Cancel Admission to above Admitted Choice Code
                </td>
                <td style="width: 60%;">
                    <asp:RadioButton ID="rbnYes" runat="server" GroupName="WillingnessForAdmissionCancellation"
                        Text="&nbsp;&nbsp;Yes" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbnNo" runat="server" GroupName="WillingnessForAdmissionCancellation"
                        Text="&nbsp;&nbsp;No" />
                    <asp:CustomValidator ID="cvWillingnessForAdmissionCancellation" runat="server" ClientValidationFunction="checkWillingnessForAdmissionCancellation"
                        Display="None" ErrorMessage="Please Select Willingness for Admission Cancellation."></asp:CustomValidator>
                </td>
            </tr>

            <tr id="trPasword" runat="server">
                <td align="right">
                    Enter Your Password
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        Display="None" ErrorMessage="Please Enter Your Password."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <asp:HiddenField ID="hdnPassword" runat="server" />
                <asp:HiddenField ID="hdnchoiceCode" runat="server" />
                <table id="tblOtp" class="AppFormTable" runat="server" visible="false">
                <tr id="trMobileNo" runat="server">
                         <td align="right"> Mobile No Registered.(OTP will Sent to this Mobile No. Valid for 5 min.)</td>
                        <td ><asp:Label id="lblMaskMobileno" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%">
                            Enter One Time Password (OTP)
                        </td>
                        <td >
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
                </table>
            </tr>
            <tr>
                <td colspan="2">
                    <center>
                        <font size="4" color="red"><b><u>Undertaking</u></b></font></center>
                    <br />
                    <br />
                    <p align="justify">
                        <font size="2" color="red"><b>I am aware of that after cancellation of my admission
                            through online system, the seats shall be released for admission to others, if any,
                            and I shall not claim the seat.</b></font></p>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr runat="server" id="trpasswordbtn">
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text=" Save Request for Cancellation of Admission "
                        CssClass="InputButton" BackColor="#d9332c" OnClick="btnProceed_Click" />
                    <asp:CustomValidator ID="cvCheckConfirmation" runat="server" ClientValidationFunction="checkConfirmation"
                        Display="None" ErrorMessage=""></asp:CustomValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                        ShowMessageBox="True" />
                </td>
            </tr>
            <tr runat="server" id="trotpbtn" visible="false">
                <td align="center" colspan="3">
                    <br />
                    <br />
                    <asp:Button ID="btnVerifyOtp" runat="server" Text="Verify OTP & Confirm Admission Cancellation"
                        CssClass="InputButton" OnClick="btnVerifyOtp_Click" ValidationGroup="otp" Style="font-size: medium;
                        height: 30px; font-weight: bold; background-color: red;" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False"
                        ShowMessageBox="True" ValidationGroup="otp" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>