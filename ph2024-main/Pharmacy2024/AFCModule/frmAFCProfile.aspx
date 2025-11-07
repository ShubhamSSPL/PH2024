<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAFCProfile.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmAFCProfile" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function numbersonly(e) {
            var unicode = e.chAFCode ? e.chAFCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        function charonly(e) {
            var unicode = e.chAFCode ? e.chAFCode : e.keyCode
            if ((unicode != 8) && (unicode != 32) && (unicode != 39)) {
                if ((unicode < 65 || unicode > 90) && (unicode < 96 || unicode > 122)) {
                    return false
                }
            }
        }
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtCoordinatorDOB").value;
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
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="SC Profile">
        <table class="AppFormTable">
            <tr>
                <th colspan="4" align="left">SC Details</th>
            </tr>
            <tr>
                <td align="right">SC Name</td>
                <td colspan="3">
                    <asp:Label ID="lblAFCName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">SC Address</td>
                <td colspan="3">
                    <asp:TextBox ID="txtAFCAddress" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvAFCAddress" runat="server" ControlToValidate="txtAFCAddress" Display="None" ErrorMessage="Please Enter SC Address."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;" align="right">SC Phone No.</td>
                <td style="width: 25%;">
                    <asp:TextBox ID="txtAFCPhoneNo" runat="server" MaxLength="15" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvAFCPhoneNo" runat="server" ControlToValidate="txtAFCPhoneNo" Display="None" ErrorMessage="Please Enter SC Phone No."></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvAFCPhone" runat="server" ControlToValidate="txtAFCPhoneNo" Display="None" ErrorMessage="Please Enter Proper SC Phone No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 25%;" align="right">SC Fax No.</td>
                <td style="width: 25%;">
                    <asp:TextBox ID="txtAFCFaxNo" runat="server" MaxLength="15" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvAFCFaxNo" runat="server" ControlToValidate="txtAFCFaxNo" Display="None" ErrorMessage="Please Enter SC Fax No."></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvAFCFax" runat="server" ControlToValidate="txtAFCFaxNo" Display="None" ErrorMessage="Please Enter Proper SC Fax No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <th colspan="4" align="left">Co-Ordinator Details</th>
            </tr>
            <tr>
                <td align="right">Name</td>
                <td colspan="3">
                    <asp:TextBox ID="txtCoordinatorName" runat="server" MaxLength="100" onKeyPress="return charonly(event)" Width="50%"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCoordinatorName" runat="server" ControlToValidate="txtCoordinatorName" Display="None" ErrorMessage="Please Enter Co-Ordinator Name."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Designation</td>
                <td>
                    <asp:TextBox ID="txtCoordinatorDesignation" runat="server" MaxLength="100" onKeyPress="return charonly(event)" Width="90%"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCoordinatorDesignation" runat="server" ControlToValidate="txtCoordinatorDesignation" Display="None" ErrorMessage="Please Enter Co-Ordinator Designation."></asp:RequiredFieldValidator>
                </td>
                <td align="right">DOB (DD/MM/YYYY)</td>
                <td>
                    <asp:TextBox ID="txtCoordinatorDOB" runat="server" MaxLength="10" Width="70%"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCoordinatorDOB" runat="server" ErrorMessage="Please Co-Ordinator Select DOB." ControlToValidate="txtCoordinatorDOB" Display="None"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvCoordinatorDOB" runat="server" ControlToValidate="txtCoordinatorDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper Co-Ordinator DOB."></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Mobile No. 1</td>
                <td>
                    <asp:TextBox ID="txtCoordinatorMobileNo" runat="server" MaxLength="10" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCoordinatorMobileNo" runat="server" ControlToValidate="txtCoordinatorMobileNo" Display="None" ErrorMessage="Please Enter Co-Ordinator Mobile No. 1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCoordinatorMobileNo" runat="server" ControlToValidate="txtCoordinatorMobileNo" Display="None" ErrorMessage="Mobile No. 1 of Co-Ordinator Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                </td>
                <td align="right">Mobile No. 2</td>
                <td>
                    <asp:TextBox ID="txtCoordinatorAltMobileNo" MaxLength="10" runat="server" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revCoordinatorAltMobileNo" runat="server" ControlToValidate="txtCoordinatorAltMobileNo" Display="None" ErrorMessage="Mobile No. 2 of Co-Ordinator Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">E-mail ID</td>
                <td>
                    <asp:TextBox ID="txtCoordinatorEmailID" runat="server" MaxLength="100" Width="90%"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCoordinatorEmailID" runat="server" ControlToValidate="txtCoordinatorEmailID" Display="None" ErrorMessage="Please Enter Co-Ordinator E-Mail ID."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCoordinatorEmailID" runat="server" ControlToValidate="txtCoordinatorEmailID" Display="None" ErrorMessage="Please Enter Valid Co-Ordinator E-Mail ID." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
                <td align="right">Phone No.</td>
                <td>
                    <asp:TextBox ID="txtCoordinatorPhoneNo" runat="server" MaxLength="15" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCoordinatorPhoneNo" runat="server" ControlToValidate="txtCoordinatorPhoneNo" Display="None" ErrorMessage="Please Enter Co-Ordinator Phone No."></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvCoordinatorPhoneNo" runat="server" ControlToValidate="txtCoordinatorPhoneNo" Display="None" ErrorMessage="Please Enter Proper Co-Ordinator Phone No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <%--<tr>
                <th colspan = "4" align = "left">Choose Security Question</th>
            </tr>
            <tr>
                <td colspan = "2" align="right">Security Question</td>
                <td colspan = "2">
                    <asp:DropDownList ID="ddlSecurityQuestion" runat="server"></asp:DropDownList>
                    <font color = "red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSecurityQuestion" runat="server" ControlToValidate="ddlSecurityQuestion" Display="None" ErrorMessage="Please Select Security Question." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan = "2" align="right">Security Answer</td>
                <td colspan = "2">
                    <asp:TextBox ID="txtSecurityAnswer" runat="server" MaxLength = "100"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSecurityAnswer" runat="server" ControlToValidate="txtSecurityAnswer"  ErrorMessage="Please Enter Security Answer." Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan = "2" align="right">Confirm Security Answer</td>
                <td colspan = "2">
                    <asp:TextBox ID="txtConfirmSecurityAnswer" runat="server" MaxLength = "100"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvConfirmSecurityAnswer" runat="server" ErrorMessage="Please Enter Confirm Security Answer." Display="None" ControlToValidate="txtConfirmSecurityAnswer"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmSecurityAnswer" runat="server" ControlToCompare="txtConfirmSecurityAnswer" ControlToValidate="txtSecurityAnswer" ErrorMessage="Security Answer and Confirm Security Answer should be Same." Display = "none"></asp:CompareValidator>
                </td>
            </tr>--%>
            <tr>
                <th colspan="4" align="left">Change Password</th>
            </tr>
            <tr>
                <td colspan="4">
                    <font color="red">
                        <p align="justify"><font color="red"><b>The Password must be as per the following Password policy :</b></font></p>
                        <ul class="list-text">
                            <li>
                                <p align="justify"><font color="red">Password must be 8 to 13 character long.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one Upper case alphabet.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one Lower case alphabet.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one numeric value.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one special characters eg.!@#$%^&*-</font></p>
                            </li>
                        </ul>
                    </font>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">New Password</td>
                <td colspan="2">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="13"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Choose Your New Password." Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="New Password must be 8 to 13 character long and must have at least one Upper case alphabet, one Lower case alphabet, one numeric value and one special character." ValidationExpression="^.*(?=^.{8,13}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">Confirm New Password</td>
                <td colspan="2">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" MaxLength="13"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please Enter Confirm New Password." Display="None"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" ErrorMessage="Password and Confirm New Password should be Same." Display="None"></asp:CompareValidator>
                </td>
            </tr>
        </table>
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
    <script language="javascript" type="text/javascript">
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable2_txtCoordinatorDOB'));
        };
    </script>
</asp:Content>
