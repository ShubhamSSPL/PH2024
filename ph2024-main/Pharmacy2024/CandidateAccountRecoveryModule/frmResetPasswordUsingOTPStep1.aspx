<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmResetPasswordUsingOTPStep1.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmResetPasswordUsingOTPStep1" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
   
    <script src="../Scripts/epoch_classes.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function isDateValid(sender, args) 
        {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtDOB").value;
            if (dateStr.length == 0) 
            {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat);
            if (matchArray == null) 
            {
                args.IsValid = false;
                return;
            }
            month = matchArray[3];
            day = matchArray[1];
            year = matchArray[5];
            if (year < 1900 || year >= 2080) 
            {
                args.IsValid = false;
                return;
            }
            if (month < 1 || month > 12) 
            {
                args.IsValid = false;
                return;
            }
            if (day < 1 || day > 31) 
            {
                args.IsValid = false;
                return;
            }
            if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) 
            {
                args.IsValid = false;
                return;
            }
            if (month == 2) 
            {
                var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
                if (day > 29 || (day == 29 && !isleap)) 
                {
                    args.IsValid = false;
                    return;
                }
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Reset password using verification code sent via text message (SMS)">
        <table class="AppFormTable">
            <tr>
                <th colspan = "3" align = "left">Enter the following Information</th>
            </tr>
            <tr>
                <td style="width: 50%" align="right">Application ID</td>
                <td style="width: 50%" colspan="2">
                    <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="10" Width="120px"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ErrorMessage="Please Enter Application ID." ControlToValidate="txtApplicationID" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
			    <td align="right">DOB (DD/MM/YYYY)</td>
			    <td colspan="2">
		            <asp:TextBox  ID="txtDOB" runat="server" MaxLength="10" Width="110px"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvDOB" Runat="server" ErrorMessage="Please Select DOB." ControlToValidate="txtDOB" Display="None"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper DOB."></asp:CustomValidator>
               </td>
		    </tr>
             <tr>
                <td style="width: 50%" align="right">Enter Captcha Given Below (case sensitive)                      
                </td>
                <td colspan="2">

                    <asp:TextBox ID="txtSecurityPin" runat="server" MaxLength="5" Width="100px" onmouseover="ddrivetip('Please Enter Security Pin (case sensitive).')" onmouseout="hideddrivetip()" autocomplete="off"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSecurityPin" runat="server" ControlToValidate="txtSecurityPin" ErrorMessage="Please Enter Security Pin (case sensitive)." Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Captcha
                </td>
                <td style="width: 15%">
                    <cc2:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5" CaptchaHeight="40" CaptchaWidth="190" CaptchaFont="Verdana" Font-Bold="false" Font-Italic="true" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ23456789" />
                </td>
                <td>
                    <asp:ImageButton runat="server" ID="btnUpdateSecurityPin" ImageUrl="../Images/refresh.png" ValidationGroup="UpdateSecurityPin" Height="40px" />
                </td>
            </tr>
        </table>
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button id = "btnBack" runat = "server" Text = "<<< Back" CssClass="InputButton" OnClick="btnBack_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" CssClass="InputButton" OnClick="btnSubmit_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        var dp_cal;
        window.onload = function () 
        {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDOB'));
        };  	
    </script>
</asp:Content>




