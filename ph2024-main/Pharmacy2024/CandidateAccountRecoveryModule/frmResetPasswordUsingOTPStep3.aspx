<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmResetPasswordUsingOTPStep3.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmResetPasswordUsingOTPStep3" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
  
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function numbersonly(e) 
        {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) 
            {
                if (unicode < 48 || unicode > 57) 
                {
                    return false
                }
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Reset password using One Time Password (OTP) sent via SMS">
        <table class = "AppFormTable">
            <tr>
                <th colspan = "3" align = "left">CET Cell just sent a One Time Password (OTP) via SMS to your Registered Mobile Number.</th>
            </tr>
            <tr>
                <td style = "width:50%" align="right">Enter One Time Password (OTP)</td>
                <td colspan="2">
                    <asp:TextBox ID="txtOTPCode" runat="server" Width = "100px" MaxLength="6" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvOTPCode" runat="server" ControlToValidate="txtOTPCode" Display="None" ErrorMessage="Please Enter One Time Password (OTP)."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revOTPCode" runat="server" ControlToValidate="txtOTPCode" Display="None" ErrorMessage="One Time Password (OTP) Should be of 6 Digits." ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 50%" align="right">Enter Captcha Given Below (case sensitive)                      
                </td>
                <td colspan="2">

                    <asp:TextBox ID="txtSecurityPin" runat="server" MaxLength="5" Width="100px" onmouseover="ddrivetip('Please Enter Security Pin (case sensitive).')" onmouseout="hideddrivetip()" autocomplete="off"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSecurityPin" runat="server" ControlToValidate="txtSecurityPin" ErrorMessage="Please Enter Captcha Pin (case sensitive)." Display="None"></asp:RequiredFieldValidator>
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
                <td colspan = "3" align = "center">
                    <br />
                    <asp:Button ID="btnContinue" runat="server" Text="CONTINUE" CssClass="InputButton" OnClick="btnContinue_Click" />
                     <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td>
                    <p align = "justify"><font color = "red"><b>Note : </b>Didn't get the text message? Sometimes it can take up to 15 minutes. If it's been longer than that, try using a different way to get into your account.</font></p>
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>

