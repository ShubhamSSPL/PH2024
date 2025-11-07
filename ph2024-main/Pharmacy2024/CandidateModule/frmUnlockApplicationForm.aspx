<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmUnlockApplicationForm.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmUnlockApplicationForm" %>

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
    <script lang="javascript" type="text/javascript">

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



    <cc1:ContentBox ID="cbPassword" runat="server" HeaderText="Unlock Application Form">
        <div class="table-responsive">
            <table class="AppFormTableWithOutBorder">
                <%-- <tr>
                <td colspan="3">
                    <p align="justify">
                        <font color="red" size="2">जर उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या  पसंतीक्रमांकावरील जागेचे वाटप झाल्यास असे वाटप प्रणालीतून आपोआप गोठविले जाईल व उमेदवार या जागेचा स्वीकार करेल. असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्यास पात्र नसतील. असे  उमेदवार प्रवेश उपस्थिती केंद्रावर जागास्वीकृती करिता कागदपत्राची पडताळणी व  जागा स्विकृती शुल्क भरण्यासाठी हजर होतील. तदनंतर असे उमेदवार वाटप करण्यात आलेल्या जागेवर प्रवेश घेण्यासाठी वाटप करण्यात आलेल्या  संस्थेमध्ये हजर होतील. असे उमेदवार जर प्रवेश उपस्थिती केंद्रावर जागास्वीकृती करिता हजर झाले नाहीत तर ते त्यांना वाटप करण्यात आलेल्या  जागेवरील हक्क  आपोआप गमावतील आणि ती  जागा पुढील वाटपासाठी उपलब्ध होईल.  अश्या  उमेदवारांकरिता करण्यात आलेले हे जागावाटप अंतिम असेल.
                            <br />
                            <br />
                            If a candidate is allotted the seat as per his first preference, such allotment shall be auto freezed and the candidate shall accept the allotment so made. Such candidate shall then be not eligible for participation in the subsequent CAP rounds. Such candidates shall then report to ARC for verification of documents and payment of seat acceptance fee. Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat. If such candidate does not report to ARC for confirmation of seat acceptance, their claim on the allotted seat shall stand forfeited automatically and the seat shall become available for fresh allotment. For such candidate, the allotment so made shall be the final allotment. </font>
                    </p>
                </td>
            </tr>--%>
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
                    <table id="tblPasword" class="AppFormTable" runat="server">

                        <tr id="tr1" runat="server">
                            <td align="right" style="width: 50%;">Enter Your Password
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
                                <asp:Button ID="btnCall" runat="server" CssClass="InputButton" OnClick="btnCall_Click"
                                    Text="Retry on Call" Visible="false" ValidationGroup="call" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <br />
                                <br />
                                <asp:Button ID="btnVerifyOtp" runat="server" Text="Verify OTP & Unlock Application Form"
                                    CssClass="InputButton" OnClick="btnVerifyOtp_Click" ValidationGroup="otp" Style="font-size: medium; height: 30px; font-weight: bold; background-color: red;" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False"
                                    ShowMessageBox="True" ValidationGroup="otp" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
