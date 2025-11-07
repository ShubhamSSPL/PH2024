<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAskApplicationID.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmAskApplicationID" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server">
        <table class="AppFormTable">
            <tr id="trNote" runat="server" visible="false">
                <td colspan="2">
                    <font color="red">
                        <ol class="list-text">
                            <b>Instructions :</b>
                            <li>
                                <p align="justify"><font color="red">If  you have Mistakenly Confirmed the Seat Acceptance Status, Some Change in Application Data or Candidate Wants to Cancel the Seat Acceptance Status Then only Cancel the Seat Acceptance Confirmation Status.</font></p>
                            </li>
                        </ol>
                    </font>
                </td>
            </tr>
            <tr>
                <td style="width: 50%;" align="right">Application ID</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="10" Width="110px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ControlToValidate="txtApplicationID" Display="None" ErrorMessage="Please Enter Application ID."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="trVersionNo" runat="server" visible="false">
                <td align="right">Version No<br />
                    (Printed on Candidate's Seat Acceptance Form)</td>
                <td>
                    <asp:TextBox ID="txtVersionNo" runat="server" Columns="11" MaxLength="3" Width="100px" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvVersionNo" runat="server" ControlToValidate="txtVersionNo" Display="None" ErrorMessage="Please Enter Version No."></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvVersionNo" runat="server" ControlToValidate="txtVersionNo" Display="None" ErrorMessage="Version No should be Numeric." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <br />
</asp:Content>
