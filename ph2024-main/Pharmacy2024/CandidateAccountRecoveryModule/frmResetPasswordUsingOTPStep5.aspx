<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmResetPasswordUsingOTPStep5.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmResetPasswordUsingOTPStep5" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
   
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Message">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="left">
                    <br />
                    Your password has been Reset Successfully. Your PASSWORD is required to be kept confidential & all care must be taken to protect its security.
                </td>
            </tr>
            <tr>
                <td align = "center">
                    <br />
                    <asp:Button ID="btnProceed" runat="server" Text="Click Here to Login" CssClass="InputButton" OnClick="btnProceed_Click" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
