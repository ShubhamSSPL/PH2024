<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSendSMSToCandidates.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmSendSMSToCandidates" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function SMSChanged() {
            if (document.getElementById('ctl00_rightContainer_ContentTable2_txtSMSContent').value.length > 150) {
                document.getElementById('ctl00_rightContainer_ContentTable2_txtSMSContent').value = document.getElementById('ctl00_rightContainer_ContentTable2_txtSMSContent').value.substring(0, 150);
            }
            document.getElementById('countSMSCharacters').innerHTML = document.getElementById('ctl00_rightContainer_ContentTable2_txtSMSContent').value.length;
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Send SMS to Candidate">
        <table class="AppFormTable" id="tblMessage" runat="server">
            <tr>
                <td style="width: 25%;" align="right">Application ID</td>
                <td style="width: 75%;">
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name</td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">SMS Content</td>
                <td>
                    <asp:TextBox ID="txtSMSContent" runat="server" TextMode="MultiLine" MaxLength="150" Width="90%" Height="50" onkeyup="SMSChanged()"></asp:TextBox>
                    <br />
                    <b>(<span id="countSMSCharacters">0</span> / 150 characters filled)</b>
                    <asp:RequiredFieldValidator ID="rfvSMSContent" runat="server" ControlToValidate="txtSMSContent" ErrorMessage="Please Enter SMS Content." Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnSend" runat="server" Text="Send SMS" CssClass="InputButton" OnClick="btnSend_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
