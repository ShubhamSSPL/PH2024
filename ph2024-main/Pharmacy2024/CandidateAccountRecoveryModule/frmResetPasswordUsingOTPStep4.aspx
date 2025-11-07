<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmResetPasswordUsingOTPStep4.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmResetPasswordUsingOTPStep4" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
   
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function DisableCopyPaste(e) {

            var message = "Right Click/Ctrl+C/Ctrl+V Options are not allowed.";
            var kCode = event.keyCode || e.charCode;
            //FF and Safari use e.charCode, while IE use e.keyCode
            if (kCode == 17 || kCode == 2) {
                alert(message);
                return false;
            }
            if (e.button == 2) {
                alert(message);
                return false;
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Reset Your Password">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color = "red">
                        <p align = "justify"><font color = "red"><b>The Password must be as per the following Password policy :</b></font></p>
                        <ul class="list-text">
                            <li><p align = "justify"><font color = "red">Password must be 8 to 13 character long.</font></p></li>
                            <li><p align = "justify"><font color = "red">Password must have at least one Upper case alphabet.</font></p></li>
                            <li><p align = "justify"><font color = "red">Password must have at least one Lower case alphabet.</font></p></li>
                            <li><p align = "justify"><font color = "red">Password must have at least one numeric value.</font></p></li>
                            <li><p align = "justify"><font color = "red">Password must have at least one special characters eg.!@#$%^&*-</font></p></li>
                            <li><p align = "justify"> <font color="red">You can not Copy(Ctrl + C) & Paste(Ctrl + V) and Right Click Passwords into a Password Field</font></p></li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <th colspan = "2" align = "left">Ensure that your NEW PASSWORD cannot be identical to any of the previous 3 passwords</th>
            </tr>
            <tr>
                <td style="width: 40%;" align="right">New Password</td>
                <td style="width: 60%;">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength = "13" onKeyDown="return DisableCopyPaste(event)" onMouseDown="return DisableCopyPaste(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter New Password." Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="New Password must be 8 to 13 character long and must have at least one Upper case alphabet, one Lower case alphabet, one numeric value and one special character." ValidationExpression="^.*(?=^.{8,13}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Confirm New Password</td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" MaxLength = "13" onKeyDown="return DisableCopyPaste(event)" onMouseDown="return DisableCopyPaste(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please Enter Confirm New Password." Display="None"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" ErrorMessage="Password and Confirm New Password should be Same." Display = "None"></asp:CompareValidator>
                </td>
            </tr>
        </table>
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnResetPassword" runat="server" Text="RESET PASSWORD" CssClass="InputButton" OnClick="btnResetPassword_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>

