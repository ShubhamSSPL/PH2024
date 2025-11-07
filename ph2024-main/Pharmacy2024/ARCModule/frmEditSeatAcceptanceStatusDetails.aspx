<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditSeatAcceptanceStatusDetails.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmEditSeatAcceptanceStatusDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function checkSeatAcceptanceStatus(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnFreeze").checked || document.getElementById("rightContainer_ContentTable2_rbnFloat").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false" CornerStyle="SquareCut">
        <table class="AppFormTable">
            <tr>
                <td style="width: 30%" align="right">Application ID</td>
                <td style="width: 70%">
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name</td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Seat Acceptance Status Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upQualification">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <th align="left" colspan="2">Seat Acceptance Status Details</th>
                    </tr>
                    <tr id="trMessage" runat="server" visible="false">
                        <td colspan="2" align="justify">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 50%" align="right">Would You Like to Freeze the Offered Seat ?</td>
                        <td style="width: 50%">
                            <asp:RadioButton ID="rbnFreeze" runat="server" GroupName="SeatAcceptanceStatus" Text="&nbsp;&nbsp;Yes" Font-Size="Large" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnFloat" runat="server" GroupName="SeatAcceptanceStatus" Text="&nbsp;&nbsp;No" Font-Size="Large" />
                            <asp:CustomValidator ID="cvGraduationStatus" runat="server" ClientValidationFunction="checkSeatAcceptanceStatus" Display="None" ErrorMessage="Please Select Seat Acceptance Status."></asp:CustomValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
