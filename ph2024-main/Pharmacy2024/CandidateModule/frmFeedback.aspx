<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmFeedback.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmFeedback" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Feedback Form">
        <table class="AppFormTable">
            <tr>
                <td>If there is any Feedback, Please Enter</td>
            </tr>

            <tr>
                <td>
                    <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" Width="99%" Height="50" MaxLength = "1000"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFeedback" runat="server" ControlToValidate="txtFeedback" ErrorMessage="Please Enter Feedback Details." Display = "none"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Send Feedback" CssClass="InputButton" OnClick="btnProceed_Click"  />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
        <br />
	</cc1:ContentBox>
</asp:Content>


