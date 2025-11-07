<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmChangeMobileNo.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmChangeMobileNo" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function numbersonly(e) 
        {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) 
            {
                if (unicode < 48 || unicode > 57) 
                {
                    return false
                }
            }
        }
        function showRetryTiemout() 
        {
            var rCounter = 45
            var timerInterval = setInterval(function () 
            {
                document.getElementById("rightContainer_ContentTable2_btnCall").style.backgroundColor = "#1abc9c";
                document.getElementById("rightContainer_ContentTable2_btnCall").disabled = true;
                document.getElementById("rightContainer_ContentTable2_btnCall").value = "Retry in " + rCounter + " Second";

                if (rCounter == 0) 
                {
                    rCounter = 45;
                }
                rCounter--;
            }, 1000);
            setTimeout(function () 
            {
                document.getElementById("rightContainer_ContentTable2_btnCall").style.backgroundColor = "#2966C0";
                document.getElementById("rightContainer_ContentTable2_btnCall").disabled = false;
                document.getElementById("rightContainer_ContentTable2_btnCall").value = "Retry on Call";
                document.getElementById("rightContainer_ContentTable2_rfvOneTimePassword").enabled = false;
                document.getElementById("rightContainer_ContentTable2_revOneTimePassword").enabled = false;
                clearInterval(timerInterval);
            }, 45000);
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Change Mobile Number">
        <asp:UpdateProgress runat="server" id="PageUpdateProgress">
            <ProgressTemplate>
                <img src ="../Images/BigProgress.gif" alt = "" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upAddress">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr id="trOldMobileNo" runat="server">
                        <td style="width:50%;" align="right">Old Mobile Number</td>
                        <td style="width:50%;"><asp:Label ID="lblOldMobileNo" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trNewMobileNo" runat="server">
                        <td style="width:50%;" align="right">New Mobile Number</td>
                        <td style="width:50%;"><asp:Label ID="lblNewMobileNo" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trMobileNo" runat="server">
                        <td style="width:50%;" align="right">Enter New Mobile Number</td>
                        <td style="width:50%;">
                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Please Enter New Mobile Number."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="New Mobile Number Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr> 
                    <tr id="trOTP" runat="server">
                        <td style="width:50%" align="right">Enter One Time Password Sent on Old Mobile Number (OTP)</td>
                        <td style="width:50%">
                            <asp:TextBox ID="txtOneTimePassword" runat="server" Width = "100px" MaxLength="6" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword" Display="None" ErrorMessage="Please Enter One Time Password of Old Mobile Number (OTP)."></asp:RequiredFieldValidator>
                           <%-- <asp:RegularExpressionValidator ID="revOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword" Display="None" ErrorMessage="One Time Password (OTP) Should be of 6 Digits." ValidationExpression="\d{6}"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                     <tr id="trOTPNew" runat="server">
                        <td style="width:50%" align="right">Enter One Time Password Sent on New Mobile Number (OTP)</td>
                        <td style="width:50%">
                            <asp:TextBox ID="txtOneTimePasswordNew" runat="server" Width = "100px" MaxLength="6" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOneTimePasswordNew" Display="None" ErrorMessage="Please Enter One Time Password New Mobile Number (OTP)."></asp:RequiredFieldValidator>
                           <%-- <asp:RegularExpressionValidator ID="revOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword" Display="None" ErrorMessage="One Time Password (OTP) Should be of 6 Digits." ValidationExpression="\d{6}"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                </table>
                <br />
                <table class = "AppFormTableWithOutBorder">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnProceed" runat="server" Text="Send OTP" OnClientClick="showRetryTiemout();" CssClass="InputButton" OnClick="btnProceed_Click" />
                            <asp:Button ID="btnCall" runat="server" Text="Retry on Call" OnClientClick="showRetryTiemout();" onclick="btnCall_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                        </td>
                    </tr>
                </table>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>



