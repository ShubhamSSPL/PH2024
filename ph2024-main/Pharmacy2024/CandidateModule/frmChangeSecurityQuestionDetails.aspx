<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmChangeSecurityQuestionDetails.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmChangeSecurityQuestionDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function blankSecurityAnswer() 
        {
            document.getElementById("rightContainer_ContentTable2_txtSecurityAnswer").value = '';
            document.getElementById("rightContainer_ContentTable2_txtConfirmSecurityAnswer").value = '';
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Security Question Details">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Security Question</td>
                <td style="width: 50%;">
                    <asp:DropDownList ID="ddlSecurityQuestion" runat="server" onmouseover="ddrivetip('Please Select Security Question.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                    <font color = "red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSecurityQuestion" runat="server" ControlToValidate="ddlSecurityQuestion" Display="None" ErrorMessage="Please Select Security Question." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Security Answer</td>
                <td>
                    <asp:TextBox ID="txtSecurityAnswer" runat="server" MaxLength = "100" onmouseover="ddrivetip('Please Enter Security Answer.')" onmouseout="hideddrivetip()"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSecurityAnswer" runat="server" ControlToValidate="txtSecurityAnswer"  ErrorMessage="Please Enter Security Answer." Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Confirm Security Answer</td>
                <td>
                    <asp:TextBox ID="txtConfirmSecurityAnswer" runat="server" MaxLength = "100" onmouseover="ddrivetip('Please Enter Confirm Security Answer.')" onmouseout="hideddrivetip()"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvConfirmSecurityAnswer" runat="server" ErrorMessage="Please Enter Confirm Security Answer." Display="None" ControlToValidate="txtConfirmSecurityAnswer"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmSecurityAnswer" runat="server" ControlToCompare="txtConfirmSecurityAnswer" ControlToValidate="txtSecurityAnswer" ErrorMessage="Security Answer and Confirm Security Answer should be Same." Display = "none"></asp:CompareValidator>
                </td>
            </tr>
        </table>
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save Security Question" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>


