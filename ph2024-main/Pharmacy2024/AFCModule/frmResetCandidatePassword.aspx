<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmResetCandidatePassword.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmResetCandidatePassword" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Reset Candidate Password">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <p align="justify"><font color="red"><b>The Password must be as per the following Password policy :</b></font></p>
                        <br />
                        <ul class="list-text">
                            <li>
                                <p align="justify"><font color="red">Password must be 8 to 13 character long.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one Upper case alphabet.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one Lower case alphabet.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one numeric value.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one special characters eg.!@#$%^&*-</font></p>
                            </li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <td align="right"><b>Candidate Name</b></td>
                <td align="left">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 40%;" align="right">New Password</td>
                <td style="width: 60%;">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="13" ToolTip="Please Enter New Password. Password must be 8 to 13 character long. Password must have at least one Upper case alphabet. Password must have at least one Lower case alphabet. Password must have at least one numeric value. Password must have at least one special characters eg.!@#$%^&*-."></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter New Password." Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Password must be 8 to 13 character long. Password must have at least one Upper case alphabet. Password must have at least one Lower case alphabet. Password must have at least one numeric value. Password must have at least one special characters eg.!@#$%^&*-." ValidationExpression="^.*(?=^.{8,13}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Confirm New Password</td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" MaxLength="13" ToolTip="Please Enter Confirm New Password."></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please Enter Confirm New Password." Display="None"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" ErrorMessage="Password and Confirm New Password should be Same." Display="None"></asp:CompareValidator>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnResetPassword" runat="server" Text="RESET PASSWORD" CssClass="InputButton" OnClick="btnResetPassword_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
