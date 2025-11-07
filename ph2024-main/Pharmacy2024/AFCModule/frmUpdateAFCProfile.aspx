<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmUpdateAFCProfile.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmUpdateAFCProfile" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        @media screen and (max-width:425px){
            .AppFormTable .col-sm-6{
                padding:5px;
            }
            .p1{
                text-align:left;
            }
        }
    </style>
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
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Update SC Profile">
        <table class="AppFormTable">
            <tr>
                <th colspan="4" align="left">SC Details</th>
            </tr>
            <tr>
                <td align="right" colspan="4">
					<div class="row w-100 mx-auto">
						<div class="col-sm-4 col-lg-3 px-0 p1">
							 SC Name
						</div>
						<div class="col-sm-8 col-lg-9 text-left ">
							<asp:Label ID="lblAFCName" runat="server" Font-Bold="true"></asp:Label>
						</div>
					</div>
				</td>
            </tr>
            <tr>
                <td align="right" colspan="4">
					<div class="row w-100 mx-auto">
						<div class="col-sm-4 col-lg-3 px-0 p1">
							SC Address
						</div>
						<div class="col-sm-8 col-lg-9 text-left">
							<asp:TextBox ID="txtAFCAddress" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvAFCAddress" runat="server" ControlToValidate="txtAFCAddress" Display="None" ErrorMessage="Please Enter SC Address."></asp:RequiredFieldValidator>
						</div>
					</div>
				</td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0 ">
                                    SC Phone No.
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtAFCPhoneNo" runat="server" MaxLength="15" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvAFCPhoneNo" runat="server" ControlToValidate="txtAFCPhoneNo" Display="None" ErrorMessage="Please Enter SC Phone No."></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvAFCPhone" runat="server" ControlToValidate="txtAFCPhoneNo" Display="None" ErrorMessage="Please Enter Proper SC Phone No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 ">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    SC Fax No.
                                </div>
                                <div class="col-8 col-lg-6 text-left ">
                                    <asp:TextBox ID="txtAFCFaxNo" runat="server" MaxLength="15" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvAFCFaxNo" runat="server" ControlToValidate="txtAFCFaxNo" Display="None" ErrorMessage="Please Enter SC Fax No."></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvAFCFax" runat="server" ControlToValidate="txtAFCFaxNo" Display="None" ErrorMessage="Please Enter Proper SC Fax No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <th colspan="4" align="left">Co-Ordinator Details</th>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-4 col-lg-3 px-0 p1">
                            Name
                        </div>
                        <div class="col-sm-8 col-lg-9 text-left">
                            <asp:TextBox ID="txtCoordinatorName" runat="server" MaxLength="100" onKeyPress="return charonly(event)" Width="50%"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCoordinatorName" runat="server" ControlToValidate="txtCoordinatorName" Display="None" ErrorMessage="Please Enter Co-Ordinator Name."></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Designation
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtCoordinatorDesignation" runat="server" MaxLength="100" onKeyPress="return charonly(event)" Width="90%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvCoordinatorDesignation" runat="server" ControlToValidate="txtCoordinatorDesignation" Display="None" ErrorMessage="Please Enter Co-Ordinator Designation."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    DOB (DD/MM/YYYY)
                                </div>
                                <div class="col-8 col-lg-6 text-left ">
                                    <asp:TextBox ID="txtCoordinatorDOB" runat="server" MaxLength="10" Width="90%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvCoordinatorDOB" runat="server" ErrorMessage="Please Co-Ordinator Select DOB." ControlToValidate="txtCoordinatorDOB" Display="None"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvCoordinatorDOB" runat="server" ControlToValidate="txtCoordinatorDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper Co-Ordinator DOB."></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Mobile No. 1
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtCoordinatorMobileNo" runat="server" MaxLength="10" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvCoordinatorMobileNo" runat="server" ControlToValidate="txtCoordinatorMobileNo" Display="None" ErrorMessage="Please Enter Co-Ordinator Mobile No. 1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revCoordinatorMobileNo" runat="server" ControlToValidate="txtCoordinatorMobileNo" Display="None" ErrorMessage="Mobile No. 1 of Co-Ordinator Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Mobile No. 2
                                </div>
                                <div class="col-8 col-lg-6 text-left ">
                                    <asp:TextBox ID="txtCoordinatorAltMobileNo" MaxLength="10" runat="server" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revCoordinatorAltMobileNo" runat="server" ControlToValidate="txtCoordinatorAltMobileNo" Display="None" ErrorMessage="Mobile No. 2 of Co-Ordinator Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    E-mail ID
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtCoordinatorEmailID" runat="server" MaxLength="100" Width="90%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvCoordinatorEmailID" runat="server" ControlToValidate="txtCoordinatorEmailID" Display="None" ErrorMessage="Please Enter Co-Ordinator E-Mail ID."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revCoordinatorEmailID" runat="server" ControlToValidate="txtCoordinatorEmailID" Display="None" ErrorMessage="Please Enter Valid Co-Ordinator E-Mail ID." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Phone No.
                                </div>
                                <div class="col-8 col-lg-6 text-left ">
                                    <asp:TextBox ID="txtCoordinatorPhoneNo" runat="server" MaxLength="15" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvCoordinatorPhoneNo" runat="server" ControlToValidate="txtCoordinatorPhoneNo" Display="None" ErrorMessage="Please Enter Co-Ordinator Phone No."></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvCoordinatorPhoneNo" runat="server" ControlToValidate="txtCoordinatorPhoneNo" Display="None" ErrorMessage="Please Enter Proper Co-Ordinator Phone No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                    </div>
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
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtCoordinatorDOB'));
        };
    </script>
</asp:Content>
