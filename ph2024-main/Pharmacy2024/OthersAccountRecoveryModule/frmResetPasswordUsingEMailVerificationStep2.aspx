<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmResetPasswordUsingEMailVerificationStep2.aspx.cs" Inherits="Pharmacy2024.OthersAccountRecoveryModule.frmResetPasswordUsingEMailVerificationStep2" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Reset password using a reset link sent via E-Mail">
        <table class = "AppFormTable">
            <tr>
                <th align = "left">DTE will sent a password reset link via email to following E-Mail ID.</th>
            </tr>
            <tr>
                <td align="center"><br /><font size = "4" color = "red"><b>Registered E-Mail ID : <asp:Label ID="lblEMailID" runat="server"></asp:Label></b></font></td>
            </tr>
            <tr>
                <td align = "center">
                    <br />
                    <asp:Button ID="btnContinue" runat="server" Text="CONTINUE" CssClass="InputButton" OnClick="btnContinue_Click" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
