<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmVerifyAndConfirmApplicationForm.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmVerifyAndConfirmApplicationForm" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" lang="javascript"></script>
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" lang="javascript"></script>

    <script lang="javascript" type="text/javascript">
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
 
    </script>
    <script lang="javascript" type="text/javascript">

        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        //function showRetryTiemout() {
        //    var rCounter = 45
        //    var timerInterval = setInterval(function () {
        //        document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#1abc9c";
        //        document.getElementById("rightContainer_cbPassword_btnCall").disabled = true;
        //        document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry in " + rCounter + " Second";

        //        if (rCounter == 0) {
        //            rCounter = 45;
        //        }
        //        rCounter--;
        //    }, 1000);
        //    setTimeout(function () {
        //        document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#2966C0";
        //        document.getElementById("rightContainer_cbPassword_btnCall").disabled = false;
        //        document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry on Call";
        //        document.getElementById("rightContainer_cbPassword_rfvOneTimePassword").enabled = false;
        //        document.getElementById("rightContainer_cbPassword_revOneTimePassword").enabled = false;

        //        clearInterval(timerInterval);
        //    }, 45000);
        //}
        //function showRetryTiemouts() {

        //    var rCounter = 45
        //    var timerInterval = setInterval(function () {
        //        document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#1abc9c";
        //        document.getElementById("rightContainer_cbPassword_btnCall").disabled = true;
        //        document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry in " + rCounter + " Second";

        //        if (rCounter == 0) {
        //            rCounter = 45;
        //        }
        //        rCounter--;
        //    }, 1000);
        //    setTimeout(function () {
        //        document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#2966C0";
        //        document.getElementById("rightContainer_cbPassword_btnCall").disabled = false;
        //        document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry on Call";
        //        document.getElementById("rightContainer_cbPassword_rfvOneTimePassword").enabled = false;
        //        document.getElementById("rightContainer_cbPassword_revOneTimePassword").enabled = false;
        //        clearInterval(timerInterval);
        //    }, 45000);
        //}
        function ResendOTP() {
            var rCounterOTP = '<% = CounterOTP %>';
             var SlapCounterOTP = '<% = OTPSlap %>';
            var timerInterval = setInterval(function () {
                document.getElementById("rightContainer_cbPassword_btnResendOTP").style.backgroundColor = "#1abc9c";
                document.getElementById("rightContainer_cbPassword_btnResendOTP").disabled = true;
                document.getElementById("rightContainer_cbPassword_btnResendOTP").value = "Resend OTP-" + rCounterOTP + " Second";
                document.getElementById("rightContainer_cbPassword_myHiddenInput").value = rCounterOTP;

                if (rCounterOTP == 0) {
                    rCounterOTP = '<% = CounterOTP %>';
                }
                rCounterOTP--;
            }, 1000);
             setTimeout(function () {
                 document.getElementById("rightContainer_cbPassword_btnResendOTP").style.backgroundColor = "#2966C0";
                 document.getElementById("rightContainer_cbPassword_btnResendOTP").disabled = false;
                 document.getElementById("rightContainer_cbPassword_btnResendOTP").value = "Resend OTP";
                 document.getElementById("rightContainer_cbPassword_rfvOneTimePassword").enabled = false;
                 //document.getElementById("rightContainer_ContentTable1_revOneTimePassword").enabled = false;
                 clearInterval(timerInterval);
             }, SlapCounterOTP);
         }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            ResendOTP();
            if (document.getElementById("rightContainer_cbPassword_tblOtp") != null) {
                
            }
        }
        window.onload = load;
    </script>



    <cc1:ContentBox ID="cbPassword" runat="server" HeaderText="Lock your Application Form">
        <div class="table-responsive">
            <table class="AppFormTableWithOutBorder">
       
            </table>
        </div>
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upQualification">
            <ContentTemplate>
                <asp:HiddenField ID="hdnPassword" runat="server" />
                <div class="table-responsive">
                    <table class="AppFormTable">
                        <tr id="trEligibilityRemark" runat="server" visible="false">
                            <td colspan="4">
                                <asp:Label ID="lblEligibilityRemark" runat="server" ForeColor="Red"><b>Remark : </b></asp:Label></td>
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
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                    ShowMessageBox="True" ValidationGroup="password" />
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
                                <%--<asp:Button ID="btnCall" runat="server" CssClass="InputButton" OnClick="btnCall_Click"
                                    Text="Retry on Call" Visible="false" ValidationGroup="call" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" id="tdverifyOTP" runat="server">
                                <br />
                                <br />
                                <asp:Button ID="btnVerifyOtp" runat="server" Text="Verify OTP for Submit Application Form"
                                    CssClass="InputButton" OnClick="btnVerifyOtp_Click" ValidationGroup="otp" Style="font-size: medium; height: 30px; font-weight: bold; background-color: red;" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False"
                                    ShowMessageBox="True" ValidationGroup="otp" />
                            </td>
                            <td style="width: 50%" align="Center" colspan="3" id="tdResendOTP" runat="server" visible="false">
                                <br />
                                <asp:Button ID="btnResendOTP" runat="server" Text="Resend OTP" CssClass="InputButton" OnClick="btnResendOTP_Click" />
                                <%-- <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>--%>
                                <asp:HiddenField ID="myHiddenInput" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
