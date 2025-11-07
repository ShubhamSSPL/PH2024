<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmVerifyOTPCancelApplication.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmVerifyOTPCancelApplication" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        window.onload = showRetryTiemout;
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
                document.getElementById("rightContainer_ContentTable1_btnCall").style.backgroundColor = "#1abc9c";
                document.getElementById("rightContainer_ContentTable1_btnCall").disabled = true;
                document.getElementById("rightContainer_ContentTable1_btnCall").value = "Retry in " + rCounter + " Second";

                if (rCounter == 0) {
                    rCounter = 45;
                }
                rCounter--;
            }, 1000);
            setTimeout(function () {
                document.getElementById("rightContainer_ContentTable1_btnCall").style.backgroundColor = "#2966C0";
                document.getElementById("rightContainer_ContentTable1_btnCall").disabled = false;
                document.getElementById("rightContainer_ContentTable1_btnCall").value = "Retry on Call";
                document.getElementById("rightContainer_ContentTable1_rfvOneTimePassword").enabled = false;
                document.getElementById("rightContainer_ContentTable1_revOneTimePassword").enabled = false;
                clearInterval(timerInterval);
            }, 45000);
        }
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Verify One Time Password">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <p align="justify"><font color="red"><b>Instructions :</b></font></p>
                        <ul class="list-text">
                            <li>
                                <p align="justify"><font color="red">CET CELL will send you a One Time Password (OTP) on your mobile to verify the mobile number.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">After receiving OTP, Please Enter it.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">After Verification of your OTP, Your Application Form get Cancelled.</font></p>
                            </li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%" align="right">Enter One Time Password</td>
                <td style="width: 50%">
                    <asp:TextBox ID="txtOneTimePassword" runat="server" Width="100px" MaxLength="6" onKeyPress="return numbersonly(event)" ValidationGroup="OTP"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword" Display="None" ErrorMessage="Please Enter One Time Password." ValidationGroup="OTP"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword" Display="None" ErrorMessage="One Time Password Should be of 6 Digits." ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td style="width: 50%" align="right">
                    <asp:Button ID="btnVerifyOTP" runat="server" Text="Verify OTP" CssClass="InputButton" OnClick="btnVerifyOTP_Click" ValidationGroup="OTP" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="OTP"></asp:ValidationSummary>
                </td>
                <td style="width: 50%" align="left">
                    <asp:Button ID="btnCall" runat="server" CssClass="InputButton" OnClick="btnCall_Click" Text="Retry on Call" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
