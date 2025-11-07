<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmForgotApplicationID.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmForgotApplicationID" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <style>
         /*@media only screen and (width: 320px) {
            #layoutSidenav {
                margin-top: 75.5% !important;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 97% !important;
            }
        }

        @media only screen and (max-width: 425px) {
            #layoutSidenav {
                margin-top: 52.5%;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 89%;
            }
        }

        @media only screen and (width: 768px) {
            #layoutSidenav {
                margin-top: 17.5% !important;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 59%;
            }
        }

        @media only screen and (width:1024px) {
            #layoutSidenav {
                margin-top: 12.4%;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 57%;
            }
        }*/
    </style>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function charonly(e) 
        {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if ((unicode != 8) && (unicode != 32) && (unicode != 39)) 
            {
                if ((unicode < 65 || unicode > 90) && (unicode < 96 || unicode > 122)) 
                {
                    return false
                }
            }
        }
        function makeUpper() 
        {
            document.getElementById("rightContainer_ContentTable2_txtCandidateName").value = document.getElementById("rightContainer_ContentTable2_txtCandidateName").value.toUpperCase();
            document.getElementById("rightContainer_ContentTable2_txtFatherName").value = document.getElementById("rightContainer_ContentTable2_txtFatherName").value.toUpperCase();
            document.getElementById("rightContainer_ContentTable2_txtMotherName").value = document.getElementById("rightContainer_ContentTable2_txtMotherName").value.toUpperCase();
        }
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
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Forgot Application ID ?">
        <table class="AppFormTable">
            <tr>
                <th colspan = "3" align = "left">Enter the following Information</th>
            </tr>
            <tr>
                <td style="width: 40%" align="right">Candidate's Name</td>
                <td colspan="2">
                    <asp:TextBox ID="txtCandidateName" runat="server" Width="200px" MaxLength="300" onKeyPress="return charonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCandidateName" runat="server" ErrorMessage="Please Enter Candidate's Name." ControlToValidate="txtCandidateName" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCandidateName" runat="server" ControlToValidate="txtCandidateName" Display="None" ErrorMessage="Candidate's Name must contain only alphabets,' and space." ValidationExpression="[a-zA-Z' ]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Father's Name</td>
                <td colspan="2">
                    <asp:TextBox ID="txtFatherName" runat="server" Width="200px" MaxLength="300" onKeyPress="return charonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvFatherName" runat="server" ErrorMessage="Please Enter Father's Name." ControlToValidate="txtFatherName" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revFatherName" runat="server" ControlToValidate="txtFatherName" Display="None" ErrorMessage="Father's Name must contain only alphabets,' and space." ValidationExpression="[a-zA-Z' ]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Mother's Name</td>
                <td colspan="2">
                    <asp:TextBox ID="txtMotherName" runat="server" Width="200px" MaxLength="300" onKeyPress="return charonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvMotherName" runat="server" ErrorMessage="Please Enter Mother's Name." ControlToValidate="txtMotherName" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revMotherName" runat="server" ControlToValidate="txtMotherName" Display="None" ErrorMessage="Mother's Name must contain only alphabets,' and space." ValidationExpression="[a-zA-Z' ]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
			    <td align="right">DOB (DD/MM/YYYY)</td>
			    <td colspan="2">
		            <asp:TextBox  ID="txtDOB" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
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


