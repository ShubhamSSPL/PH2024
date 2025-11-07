<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmChangeEligibilityCAPRound2.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmChangeEligibilityCAPRound2" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function checkEligibility(sender, args) {
            if (document.getElementById("ctl00_rightContainer_ContentBox1_rbnEligible").checked || document.getElementById("ctl00_rightContainer_ContentBox1_rbnNotEligible").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Change Candidate's Eligibility CAP Round-II">
        <table class="AppFormTable">
            <tr>
                <td align="right"><b>Candidate Name</b></td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td align="right"><b>Candidate's Eligibility Status</b></td>
                <td>
                    <asp:RadioButton ID="rbnEligible" runat="server" Text="&nbsp;&nbsp;Eligible" GroupName="Eligibility" />
                    &nbsp;&nbsp;
                    <asp:RadioButton ID="rbnNotEligible" runat="server" Text="&nbsp;&nbsp;Not Eligible" GroupName="Eligibility" />
                    <asp:CustomValidator ID="cvEligibility" runat="server" ClientValidationFunction="checkEligibility" Display="None" ErrorMessage="Please Select Eligibility Option."></asp:CustomValidator>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Change Eligibility" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
