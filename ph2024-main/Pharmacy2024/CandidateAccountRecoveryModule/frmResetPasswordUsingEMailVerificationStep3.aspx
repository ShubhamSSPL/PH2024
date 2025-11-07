<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmResetPasswordUsingEMailVerificationStep3.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmResetPasswordUsingEMailVerificationStep3" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Reset password using a reset link sent via E-Mail">
        <table class = "AppFormTable">
            <tr>
                <th align = "left">CET Cell just sent a password reset link to your Registered E-Mail ID.</th>
            </tr>
            <tr>
                <td>
                    <br /><br />
                    <p align = "justify"><font color = "red"><b>A link to reset the Password has been sent to your registered E-Mail ID. Please check your Mail Box and follow the instructions.</b></font></p>
                    <br /><br /><br />
                    <p align = "justify"><b>Note : </b>Didn't receive the password reset email? Check your spam folder for an email from system@dte.org.in. If you still don't see the email, try again.</p>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
