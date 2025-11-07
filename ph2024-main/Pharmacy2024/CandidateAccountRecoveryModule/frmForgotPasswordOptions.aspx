<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmForgotPasswordOptions.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmForgotPasswordOptions" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        function checkResetPassword(sender, args) 
        {
            if (document.getElementById("rightContainer_ContentTable1_rbnResetPasswordUsingSecurityQuestion").checked || document.getElementById("rightContainer_ContentTable1_rbnResetPasswordUsingOTP").checked || document.getElementById("rightContainer_ContentTable1_rbnResetPasswordUsingEMailVerification").checked) 
            {
            }
            else 
            {
                args.IsValid = false;
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText=" Options available for reset your Password">
        <br />
        <table class = "AppFormTable">
            <tr>
                <th align = "left">Reset Password option</th>
            </tr>
            <tr>
                <td style="width: 70%">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbnResetPasswordUsingSecurityQuestion" runat="server" Text="&nbsp;&nbsp;Using Security Question & its Answer you chosen during Form filling." GroupName="ResetPassword"  />
                    <br /><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbnResetPasswordUsingOTP" runat="server" Text="&nbsp;&nbsp;Using One Time Password (OTP) sent via SMS to your Registered Mobile Number." GroupName="ResetPassword" />
                    <%--<br /><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                    <asp:RadioButton ID="rbnResetPasswordUsingEMailVerification" runat="server" Text="&nbsp;&nbsp;Using a reset link sent via Email to your Registered Email address." GroupName="ResetPassword" Visible="false" />
                    <asp:CustomValidator ID="cvResetPassword" runat="server" ClientValidationFunction="checkResetPassword" Display="None" ErrorMessage="Please Select atleast one option."></asp:CustomValidator>
                    <br /><br /><br /><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnContinue" runat="server" Text="CONTINUE" CssClass="InputButton" Width = "100px" OnClick="btnContinue_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                    <br /><br />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>


