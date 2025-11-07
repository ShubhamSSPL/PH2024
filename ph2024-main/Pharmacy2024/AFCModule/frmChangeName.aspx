<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmChangeName.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmChangeName" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        //        window.onload = showRetryTiemout;
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        function showRetryTiemout() {
            if (document.getElementById("ctl00_rightContainer_ContentTable2_btnProceed").value == "Send OTP") {
                var rCounter = 45
                var timerInterval = setInterval(function () {
                    document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").style.backgroundColor = "#1abc9c";
                    document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").disabled = true;
                    document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").value = "Retry in " + rCounter + " Second";

                    if (rCounter == 0) {
                        rCounter = 45;
                    }
                    rCounter--;
                }, 1000);
                setTimeout(function () {
                    document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").style.backgroundColor = "#2966C0";
                    document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").disabled = false;
                    document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").value = "Retry on Call";
                    document.getElementById("ctl00_rightContainer_ContentTable2_rfvOneTimePassword").enabled = false;
                    document.getElementById("ctl00_rightContainer_ContentTable2_revOneTimePassword").enabled = false;
                    clearInterval(timerInterval);
                }, 45000);
            }
        }
        function showRetryTiemouts() {

            var rCounter = 45
            var timerInterval = setInterval(function () {
                document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").style.backgroundColor = "#1abc9c";
                document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").disabled = true;
                document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").value = "Retry in " + rCounter + " Second";

                if (rCounter == 0) {
                    rCounter = 45;
                }
                rCounter--;
            }, 1000);
            setTimeout(function () {
                document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").style.backgroundColor = "#2966C0";
                document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").disabled = false;
                document.getElementById("ctl00_rightContainer_ContentTable2_btnCall").value = "Retry on Call";
                document.getElementById("ctl00_rightContainer_ContentTable2_rfvOneTimePassword").enabled = false;
                document.getElementById("ctl00_rightContainer_ContentTable2_revOneTimePassword").enabled = false;
                clearInterval(timerInterval);
            }, 45000);
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Change Candidate Name">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upAddress">
            <ContentTemplate>
                <asp:HiddenField ID="hdnMobileNo" runat="server" />
                <table class="AppFormTable">
                    <tr>
                        <td colspan="2">
                            <ol class="list-text">
                                <b>Important Instructions for Correction in Name :</b>
                                <li>The Scrutiny Center should verify & approve the request of change in name by
                                    verifying the original documents as mentioned in admit card, carried by the candidate.
                                </li>
                                <li>After approval of the request of change in name by Scrutiny Center, the correct
                                    name will be reflected in the Application Form. </li>
                            </ol>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr id="trOldMobileNo" runat="server">
                        <td style="width: 40%;" rowspan="2" align="right">
                            <asp:Image ID="imgPhotograph" Width="133" Height="171" runat="server" AlternateText="Candidate Photograph" />
                        </td>
                        <td style="width: 60%;">Old Name:
                            <asp:Label ID="lblOldMobileNo" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trNewMobileNo" runat="server">
                        <td>New Name:
                            <asp:Label ID="lblNewMobileNo" runat="server" Font-Bold="true"></asp:Label><br />
                            <font color="red">(As appeared on HSC Marksheet)</font></td>

                    </tr>
                    <tr id="trOTP" runat="server">
                        <td style="width: 50%" align="right">Enter One Time Password (OTP)
                        </td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txtOneTimePassword" runat="server" Width="100px" MaxLength="6" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword"
                                Display="None" ErrorMessage="Please Enter One Time Password (OTP)."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword"
                                Display="None" ErrorMessage="One Time Password (OTP) Should be of 6 Digits."
                                ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td align="Center">
                            <asp:Button ID="btnProceed" OnClientClick="javascript:showRetryTiemout();" runat="server" Text="Send OTP" CssClass="InputButton"
                                OnClick="btnProceed_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                ShowMessageBox="True" />
                            <asp:Button ID="btnCall" runat="server" CssClass="InputButton" OnClientClick="javascript:showRetryTiemouts();"
                                OnClick="btnCall_Click" Text="Retry on Call" Visible="false" />
                        </td>
                        <%--   <td align = "left" >
                    <asp:Button ID="btnCall" runat="server" CssClass="InputButton" OnClientClick="javascript:showRetryTiemouts();"
                        onclick="btnCall_Click" Text="Retry on Call"  Visible="false"/>
                </td>--%>
                    </tr>
                </table>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
