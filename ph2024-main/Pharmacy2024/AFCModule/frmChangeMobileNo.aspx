<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmChangeMobileNo.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmChangeMobileNo" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">
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
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Change Mobile Number">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upAddress">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr id="trOldMobileNo" runat="server">
                        <td style="width: 50%;" align="right">Old Mobile Number</td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblOldMobileNo" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trNewMobileNo" runat="server">
                        <td style="width: 50%;" align="right">New Mobile Number</td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblNewMobileNo" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trMobileNo" runat="server">
                        <td style="width: 50%;" align="right">Enter New Mobile Number</td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Please Enter New Mobile Number."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="New Mobile Number Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr id="trOTP" runat="server">
                        <td style="width: 50%" align="right">Enter One Time Password (OTP)</td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txtOneTimePassword" runat="server" Width="100px" MaxLength="6" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword" Display="None" ErrorMessage="Please Enter One Time Password (OTP)."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword" Display="None" ErrorMessage="One Time Password (OTP) Should be of 6 Digits." ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnProceed" runat="server" Text="Send OTP" CssClass="InputButton" OnClick="btnProceed_Click" />
                             <asp:Button ID="btnCall" runat="server" Text="Retry on Call" OnClientClick="showRetryTiemout();" onclick="btnCall_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                        </td>
                    </tr>
                </table>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
