<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCancelApplicationForm.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmCancelApplicationForm" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="CandidatureType" runat="server" HeaderText="Cancel Application Form">
        <table class="AppFormTable">
            <tr>
                <td align="right">Application ID</td>
                <td colspan="3">
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name</td>
                <td colspan="3">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 26%;" align="right">Father's Name</td>
                <td style="width: 24%;">
                    <asp:Label ID="lblFatherName" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%;" align="right">Mother's Name</td>
                <td style="width: 25%;">
                    <asp:Label ID="lblMotherName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Gender</td>
                <td>
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Date of Birth</td>
                <td>
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td colspan="3">
                    <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Home University</td>
                <td colspan="3">
                    <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category</td>
                <td colspan="3">
                    <asp:Label ID="lblOriginalCategory" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category for Admission</td>
                <td colspan="3">
                    <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Person with Disability</td>
                <td colspan="3">
                    <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Minority Candidature Type</td>
                <td colspan="3">
                    <asp:Label ID="lblAppliedForMinoritySeats" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Reason for Cancellation</td>
                <td colspan="3">
                    <asp:TextBox ID="txtReasonForCancellation" runat="server" Width="100%" MaxLength="250" TextMode="multiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="frMsg" runat="server" ControlToValidate="txtReasonForCancellation" ErrorMessage="Please Enter Reason for Cancellation Details" Display="None"></asp:RequiredFieldValidator>
                </td>
                    
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel Application Form" CssClass="InputButton" OnClick="btnCancel_Click"></asp:Button></td>
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
            </tr>
        </table>
    </cc1:ContentBox>
    <br />
</asp:Content>
