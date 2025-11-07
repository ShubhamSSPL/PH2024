<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmResetPasswordUsingSecurityQuestionStep1.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmResetPasswordUsingSecurityQuestionStep1" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Reset password using Security Question & its Answer">
        <table class="AppFormTable">
            <tr>
                <th colspan = "2" align = "left">Enter the following Information</th>
            </tr>
            <tr>
                <td style="width: 40%" align="right">Application ID</td>
                <td style="width: 60%">
                    <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="10"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ErrorMessage="Please Enter Application ID." ControlToValidate="txtApplicationID" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Security Question</td>
                <td>
                    <asp:DropDownList ID="ddlSecurityQuestion" runat="server"></asp:DropDownList>
                    <font color = "red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSecurityQuestion" runat="server" ControlToValidate="ddlSecurityQuestion" Display="None" ErrorMessage="Please Select Security Question." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Security Answer</td>
                <td>
                    <asp:TextBox ID="txtSecurityAnswer" runat="server" MaxLength = "100" TextMode = "Password"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSecurityAnswer" runat="server" ControlToValidate="txtSecurityAnswer"  ErrorMessage="Please Enter Security Answer." Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button id = "btnBack" runat = "server" Text = "<<< Back" CssClass="InputButton" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" CssClass="InputButton" OnClick="btnSubmit_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>


