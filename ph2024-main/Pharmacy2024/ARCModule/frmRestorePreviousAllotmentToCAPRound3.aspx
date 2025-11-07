<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmRestorePreviousAllotmentToCAPRound3.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmRestorePreviousAllotmentToCAPRound3" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Restore Previous Allotment to CAP Round - III">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Enter Application ID</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="11" Width="120px">PH19</asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ControlToValidate="txtApplicationID" Display="None" ErrorMessage="Please Enter Application ID."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Enter Choice Code to be Restored</td>
                <td>
                    <asp:TextBox ID="txtChoiceCode" runat="server" MaxLength="12" Width="120px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvChoiceCode" runat="server" ControlToValidate="txtChoiceCode" Display="None" ErrorMessage="Please Enter Choice Code."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Restore Allotment" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <br />
</asp:Content>
