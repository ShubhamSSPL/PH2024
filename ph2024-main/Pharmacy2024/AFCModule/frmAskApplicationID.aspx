<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAskApplicationID.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmAskApplicationID" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/epoch_classes.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
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
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("ctl00_rightContainer_ContentTable2_txtDOB").value;
            if (dateStr.length == 0) {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat);
            if (matchArray == null) {
                args.IsValid = false;
                return;
            }
            month = matchArray[3];
            day = matchArray[1];
            year = matchArray[5];
            if (year < 1900 || year >= 2080) {
                args.IsValid = false;
                return;
            }
            if (month < 1 || month > 12) {
                args.IsValid = false;
                return;
            }
            if (day < 1 || day > 31) {
                args.IsValid = false;
                return;
            }
            if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
                args.IsValid = false;
                return;
            }
            if (month == 2) {
                var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
                if (day > 29 || (day == 29 && !isleap)) {
                    args.IsValid = false;
                    return;
                }
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" DefaultButton="btnProceed">
        <table class="AppFormTable">
            <tr id="trNote" runat="server" visible="false">
                <td colspan="2">
                    <font color="red">
                        <ol class="list-text">
                            <b>Instructions :</b>
                            <li>
                                <p align="justify"><font color="red">If Candidate's Marks are increased, Then send message to Admin through Message-Box with Candidate's All Details. You can confirm the Seat Acceptance Status of these type of Candidates.</font></p>
                            </li>
                        </ol>
                    </font>
                </td>
            </tr>
            <tr id="trcvctvcNote" runat="server" visible="false">
                <td colspan="2">
                    <font color="red">
                        <ol class="list-text">
                            <b>Instructions :</b>
                            <li>
                                <p align="justify">
                                    The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category
                                                    
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                                </p>
                            </li>
                            <%--<li>
                                <p align="justify">Caste Validity Certificate shall not be required for SEBC Category Candidates till further instructions/ orders from Government. </p>
                            </li>--%>
                            <%--<li>
                                <p align="justify">The ARC officers shall verify the Caste Validity Certificate / Tribe Validity Certificate and upload the scanned copy same.</p>
                            </li>--%>

                        </ol>
                    </font>
                </td>
            </tr>
            <tr>
                <td style="width: 50%;" align="right">Application ID</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="10" Width="120px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ControlToValidate="txtApplicationID" Display="None" ErrorMessage="Please Enter Application ID."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="trVersionNo" runat="server" visible="false">
                <td align="right">Version No<br />
                    (Printed on Candidate's Application Form)</td>
                <td>
                    <asp:TextBox ID="txtVersionNo" runat="server" Columns="11" MaxLength="3" Width="100px" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvVersionNo" runat="server" ControlToValidate="txtVersionNo" Display="None" ErrorMessage="Please Enter Version No."></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvVersionNo" runat="server" ControlToValidate="txtVersionNo" Display="None" ErrorMessage="Version No should be Numeric." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr id="trDOB" runat="server" visible="false">
                <td align="right">Enter Date Of Birth</td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                    <font color="red"><sup>*</sup></font> (DD/MM/YYYY)
                    <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB" Display="none" ErrorMessage="Please Enter Date of Birth."></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper DOB."></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed >>>" CssClass="InputButtonRed" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <br />
    <script language="javascript" type="text/javascript">
        var dp_cal;
        if (document.getElementById('ctl00_rightContainer_ContentTable2_txtDOB') != null) {
            window.onload = function () {
                dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable2_txtDOB'));
            };
        }
    </script>
</asp:Content>
