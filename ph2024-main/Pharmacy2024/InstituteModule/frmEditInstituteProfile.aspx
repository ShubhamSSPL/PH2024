<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditInstituteProfile.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmEditInstituteProfile" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
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
        function isDateValid(sender, args) 
        {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtCoordinatorDOB").value;
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
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Update Institute Profile">
        <table class="AppFormTable">
            <tr>
                <th colspan = "4" align = "left">Institute Details</th>
            </tr>
            <tr>
                <td align="right">Institute Code</td>
                <td colspan="3"><asp:Label ID="lblInstituteCode" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Institute Name</td>
                <td colspan="3"><asp:Label ID="lblInstituteName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Institute Address</td>
                 <td colspan="3"><asp:Label ID="lblInstituteAddress" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%;" align="right">Institute Phone No</td>
                <td style="width: 25%;">
                    <asp:TextBox ID="txtInstitutePhoneNo" runat="server" MaxLength="15" onKeyPress="return numbersonly(event)" Width = "89%"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvInstitutePhoneNo" runat="server" ControlToValidate="txtInstitutePhoneNo" Display="None" ErrorMessage="Please Enter Institute Phone No."></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvInstitutePhoneNo" runat="server" ControlToValidate="txtInstitutePhoneNo" Display="None" ErrorMessage="Please Enter Proper Institute Phone No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 25%;" align="right">Institute Fax No</td>
                <td style="width: 25%;">
                    <asp:TextBox ID="txtInstituteFaxNo" runat="server" MaxLength="15" onKeyPress="return numbersonly(event)" Width = "89%"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvInstituteFaxNo" runat="server" ControlToValidate="txtInstituteFaxNo" Display="None" ErrorMessage="Please Enter Institute Fax No."></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvInstituteFaxNo" runat="server" ControlToValidate="txtInstituteFaxNo" Display="None" ErrorMessage="Please Enter Proper Institute Fax No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <th colspan = "4" align = "left">Co-Ordinator Details</th>
            </tr>
            <tr>
                <td align="right">Name</td>
                <td colspan = "3">
                     <asp:TextBox ID="txtCoordinatorName" runat="server" MaxLength = "100" onKeyPress="return charonly(event)" Width = "50%"></asp:TextBox>
                     <font color = "red"><sup>*</sup></font>
                     <asp:RequiredFieldValidator ID="rfvCoordinatorName" runat="server" ControlToValidate="txtCoordinatorName" Display="None" ErrorMessage="Please Enter Co-Ordinator Name."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Designation</td>
                <td>
                     <asp:TextBox ID="txtCoordinatorDesignation" runat="server" MaxLength = "100" onKeyPress="return charonly(event)" Width = "90%"></asp:TextBox>
                     <font color = "red"><sup>*</sup></font>
                     <asp:RequiredFieldValidator ID="rfvCoordinatorDesignation" runat="server" ControlToValidate="txtCoordinatorDesignation" Display="None" ErrorMessage="Please Enter Co-Ordinator Designation."></asp:RequiredFieldValidator>
                </td>
                <td align="right">DOB (DD/MM/YYYY)</td>
			    <td>
		            <asp:TextBox  ID="txtCoordinatorDOB" runat="server" MaxLength="10" Width = "70%"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCoordinatorDOB" Runat="server" ErrorMessage="Please Co-Ordinator Select DOB." ControlToValidate="txtCoordinatorDOB" Display="None"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvCoordinatorDOB" runat="server" ControlToValidate="txtCoordinatorDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper Co-Ordinator DOB."></asp:CustomValidator>
               </td>
            </tr>
            <tr>
                <td align="right">Mobile No. 1</td>
                <td>
                    <asp:TextBox ID="txtCoordinatorMobileNo" runat="server"  MaxLength="10" onKeyPress="return numbersonly(event)" Width = "90%"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCoordinatorMobileNo" runat="server" ControlToValidate="txtCoordinatorMobileNo" Display="None" ErrorMessage="Please Enter Co-Ordinator Mobile No. 1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCoordinatorMobileNo" runat="server" ControlToValidate="txtCoordinatorMobileNo" Display="None" ErrorMessage="Mobile No. 1 of Co-Ordinator Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                </td>
                <td align="right">Mobile No. 2</td>
                <td>
                    <asp:TextBox ID="txtCoordinatorAltMobileNo" MaxLength="10" runat="server" onKeyPress="return numbersonly(event)" Width = "90%"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revCoordinatorAltMobileNo" runat="server" ControlToValidate="txtCoordinatorAltMobileNo" Display="None" ErrorMessage="Mobile No. 2 of Co-Ordinator Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">E-mail ID</td>
                <td>
                    <asp:TextBox ID="txtCoordinatorEmailID" runat="server" MaxLength = "100" Width = "90%"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCoordinatorEmailID" runat="server" ControlToValidate="txtCoordinatorEmailID" Display="None" ErrorMessage="Please Enter Co-Ordinator E-Mail ID."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCoordinatorEmailID" runat="server" ControlToValidate="txtCoordinatorEmailID" Display="None" ErrorMessage="Please Enter Valid Co-Ordinator E-Mail ID." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
                <td align="right">Phone No.</td>
                <td>
                    <asp:TextBox ID="txtCoordinatorPhoneNo" runat="server"  MaxLength="15" onKeyPress="return numbersonly(event)" Width = "90%"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCoordinatorPhoneNo" runat="server" ControlToValidate="txtCoordinatorPhoneNo" Display="None" ErrorMessage="Please Enter Co-Ordinator Phone No."></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvCoordinatorPhoneNo" runat="server" ControlToValidate="txtCoordinatorPhoneNo" Display="None" ErrorMessage="Please Enter Proper Co-Ordinator Phone No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
        </table> 
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="   Save   " CssClass="InputButton" OnClick="btnProceed_Click"/>
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        var dp_cal;
        window.onload = function () 
        {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtCoordinatorDOB'));
        };  	
    </script>
</asp:Content>
