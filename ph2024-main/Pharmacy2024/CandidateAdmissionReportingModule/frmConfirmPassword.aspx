<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmConfirmPassword.aspx.cs" Inherits="Pharmacy2024.CandidateAdmissionReportingModule.frmConfirmPassword" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Request for Cancellation of Admission">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <ol class="list-text">
                            <b>Instructions :</b>
                            <li>
                                <p align="justify"><font color="red">If you want to cancel your admission, then only 'Enter Your Password' and click on 'Proceed >>>' Button.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">After submitting your request for cancellation of admission, you are required to report to the institute and complete the cancellation procedure.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Once you submit request for cancellation of admission, you will not be eligible to claim your admission.</font></p>
                            </li>
                        </ol>
                    </font>
                    <br />
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Application ID</td>
                <td style="width: 50%;">
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate Name</td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Enter Password</td>
                <td>
                    <asp:TextBox ID="txtCandidatePassword" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCandidatePassword" runat="server" ErrorMessage="Please Enter Your Password." ControlToValidate="txtCandidatePassword" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
