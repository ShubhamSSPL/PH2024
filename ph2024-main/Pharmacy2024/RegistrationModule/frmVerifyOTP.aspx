<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmVerifyOTP.aspx.cs" Inherits="Pharmacy2024.RegistrationModule.frmVerifyOTP" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
       /* @media only screen and (width: 320px) {
            #layoutSidenav {
                margin-top: 65.5% !important;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 88% !important;
            }
        }
        @media only screen and (max-width: 425px) {
            #layoutSidenav {
                margin-top: 48.5%;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 80%;
            }
        }
        @media only screen and (width: 768px) {
            #layoutSidenav {
                margin-top: 14% !important;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 46%;
            }
        }*/
    </style>
 
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        //window.onload = showRetryTiemout;
        window.onload = ResendOTP;
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        //function showRetryTiemout() 
        //{
        //    var rCounter = 45
        //    var timerInterval = setInterval(function () 
        //    {
        //        document.getElementById("rightContainer_ContentTable1_btnCall").style.backgroundColor = "#1abc9c";
        //        document.getElementById("rightContainer_ContentTable1_btnCall").disabled = true;
        //        document.getElementById("rightContainer_ContentTable1_btnCall").value = "Retry in " + rCounter + " Second";

        //        if (rCounter == 0) 
        //        {
        //            rCounter = 45;
        //        }
        //        rCounter--;
        //    }, 1000);
        //    setTimeout(function () 
        //    {
        //        document.getElementById("rightContainer_ContentTable1_btnCall").style.backgroundColor = "#2966C0";
        //        document.getElementById("rightContainer_ContentTable1_btnCall").disabled = false;
        //        document.getElementById("rightContainer_ContentTable1_btnCall").value = "Retry on Call";
        //        document.getElementById("rightContainer_ContentTable1_rfvOneTimePassword").enabled = false;
        //        document.getElementById("rightContainer_ContentTable1_revOneTimePassword").enabled = false;
        //        clearInterval(timerInterval);
        //    }, 45000);
        //}
        function ResendOTP() {
            var rCounterOTP = '<% = CounterOTP %>';
            var SlapCounterOTP = '<% = OTPSlap %>';
            var timerInterval = setInterval(function ()
            {
                document.getElementById("rightContainer_ContentTable1_btnResendOTP").style.backgroundColor = "#1abc9c";
                document.getElementById("rightContainer_ContentTable1_btnResendOTP").disabled = true;
                document.getElementById("rightContainer_ContentTable1_btnResendOTP").value = "Resend OTP-" + rCounterOTP + " Second";
                document.getElementById("rightContainer_ContentTable1_myHiddenInput").value = rCounterOTP;

                if (rCounterOTP == 0) {
                    rCounterOTP = '<% = CounterOTP %>';
                }
                rCounterOTP--;
            }, 1000);
            setTimeout(function () {
                document.getElementById("rightContainer_ContentTable1_btnResendOTP").style.backgroundColor = "#2966C0";
                document.getElementById("rightContainer_ContentTable1_btnResendOTP").disabled = false;
                document.getElementById("rightContainer_ContentTable1_btnResendOTP").value = "Resend OTP";
                document.getElementById("rightContainer_ContentTable1_rfvOneTimePassword").enabled = false;
                //document.getElementById("rightContainer_ContentTable1_revOneTimePassword").enabled = false;
                clearInterval(timerInterval);
            }, SlapCounterOTP);
        }
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Verify One Time Password">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color = "red">
                        <p align = "justify"><font color = "red"><b>Instructions :</b></font></p>
                        <ul class="list-text">
                            <li><p align = "justify"><font color = "red">State CET Cell will send you a One Time Password (OTP) on Your Registered Mobile Number to Verify Your Login</font></p></li>
                            <li><p align = "justify"><font color = "red">After receiving One Time Password (OTP), Please Enter it.</font></p></li>
                            <li><p align = "justify"><font color = "red">After Verification of One Time Password (OTP), You can Proceed to Complete Your Activities.</font></p></li>
                            <%--<li><p align = "justify"><font color = "red">If OTP not received, then Click on "Retry on Call" button and Enter OTP received on Call.</font></p></li>--%>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
        <br />
        <table class = "AppFormTable">
            <tr>
               <td style="width: 50%" align="right"> <asp:Label ID="lblMaskMobileno" runat="server"></asp:Label></td>
                <td style = "width:50%">
                    <asp:TextBox ID="txtOneTimePassword" runat="server" Width = "100px" MaxLength="6" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword" Display="None" ErrorMessage="Please Enter One Time Password."></asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="revOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword" Display="None" ErrorMessage="One Time Password Should be of 6 Digits." ValidationExpression="\d{6}\"></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
        </table>
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td style="width: 50%" align="right" id="tdverifyOTP" runat="server">
                    <br />
                    <asp:Button ID="btnVerifyOTP" runat="server" Text="Verify OTP" CssClass="InputButton" OnClick="btnVerifyOTP_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
                </td>
                <td style="width:50%" align = "Left" id="tdResendOTP" runat="server" >
                     <br />
                    <asp:Button ID="btnResendOTP" runat="server" Text="Resend OTP" CssClass="InputButton" OnClick="btnResendOTP_Click" />
                   <%-- <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>--%>
                    <asp:HiddenField id="myHiddenInput" runat="server" />
                </td>
                <%--<td style="width: 50%" align="left">
                    <br />
                    <asp:Button ID="btnCall" runat="server" CssClass="InputButton" OnClick="btnCall_Click" Text="Resend OTP" />
                </td>--%>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>

