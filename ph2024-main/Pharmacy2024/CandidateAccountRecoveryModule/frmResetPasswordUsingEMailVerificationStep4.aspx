<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmResetPasswordUsingEMailVerificationStep4.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmResetPasswordUsingEMailVerificationStep4" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Verification of Password Reset Link">
        <table class = "AppFormTable">
            <tr>
                <th align = "left">Message</th>
            </tr>
            <tr>
                <td>
                    <br /><br />
                    <p align = "justify"><font color = "red" size = "2"><b>This link is no longer valid. The link you received in your email is expired or already used.</b></font></p>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
