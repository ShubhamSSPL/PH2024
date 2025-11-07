<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmResetPasswordUsingOTPStep3.aspx.cs" Inherits="Pharmacy2024.OthersAccountRecoveryModule.frmResetPasswordUsingOTPStep3" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
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
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Reset password using verification code sent via text message (SMS)">
        <table class = "AppFormTable">
            <tr>
                <th colspan = "2" align = "left">DTE just sent a verification code via text message (SMS) to your Registered Mobile No.</th>
            </tr>
            <tr>
                <td style = "width:50%" align="right">Enter that verification code here</td>
                <td style = "width:50%">
                    <asp:TextBox ID="txtOTPCode" runat="server" Width = "100px" MaxLength="6" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Verification Code. It should be of 6 Digits.')" onmouseout="hideddrivetip()"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvOTPCode" runat="server" ControlToValidate="txtOTPCode" Display="None" ErrorMessage="Please Enter Verification Code."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revOTPCode" runat="server" ControlToValidate="txtOTPCode" Display="None" ErrorMessage="Verification Code Should be of 6 Digits." ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan = "2" align = "center">
                    <br />
                    <asp:Button ID="btnContinue" runat="server" Text="CONTINUE" CssClass="InputButton" OnClick="btnContinue_Click" />
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
    </cc1:ContentBox>
</asp:Content>