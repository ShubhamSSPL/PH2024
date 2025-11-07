<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmRegistrationDetails.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmRegistrationDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">

    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
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
        function alphabetsOnly(evt) {
            var keyCode = (evt.which) ? evt.which : evt.keyCode;

            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode >= 123) && (keyCode != 32) && (keyCode != 39) && (keyCode != 8)) {
                return false;
            }
            else {
                return true;
            }
        }
        function validateInput(input) {
            var regex = /^[a-zA-Z]*$/;
            if (!regex.test(input.value)) {
                input.value = input.value.replace(/[^a-zA-Z\s]/g, "");
            }
        }
        function makeUpper() {
            document.getElementById("rightContainer_ContentTable2_txtCandidateName").value = document.getElementById("rightContainer_ContentTable2_txtCandidateName").value.toUpperCase();
            document.getElementById("rightContainer_ContentTable2_txtFatherName").value = document.getElementById("rightContainer_ContentTable2_txtFatherName").value.toUpperCase();
            document.getElementById("rightContainer_ContentTable2_txtMotherName").value = document.getElementById("rightContainer_ContentTable2_txtMotherName").value.toUpperCase();
        }
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtDOB").value;
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
        function isDOBDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtDOB").value;
            //Add Date current date validation
            var date = dateStr.substring(0, 2);
            var month = dateStr.substring(3, 5);
            var year = dateStr.substring(6, 10);
            var SleDate = new Date(year, month - 1, date);
            var CurDate = new Date();

            if (SleDate > CurDate) {
                //Do something..
                //alert("Date of Birth Should Not Be Greater Than Today!");
                args.IsValid = false;
                return;
            }
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

        function isDateValidC(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtDOBC").value;
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

        function checkDateofBirthAndConfirmDateofBirth(sender, args) {
            var DateValidateDateofBirthAndConfirmDateofBirth = document.getElementById("rightContainer_ContentTable2_DateValidateDateofBirthAndConfirmDateofBirth");

            var DateofBirth = document.getElementById("rightContainer_ContentTable2_txtDOB").value;
            var DateofBirthConfirm = document.getElementById("rightContainer_ContentTable2_txtDOBC").value;

            if (DateofBirth.length == 0) {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArrayF = DateofBirth.match(datePat);
            if (matchArrayF == null) {
                args.IsValid = false;
                return;
            }
            monthF = matchArrayF[3];
            dayF = matchArrayF[1];
            yearF = matchArrayF[5];

            if (DateofBirthConfirm.length == 0) {
                args.IsValid = false;
                return;
            }
            var datePatT = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArrayT = DateofBirthConfirm.match(datePatT);
            if (matchArrayT == null) {
                args.IsValid = false;
                return;
            }
            monthT = matchArrayT[3];
            dayT = matchArrayT[1];
            yearT = matchArrayT[5];

            //if (monthT - monthF + (12 * (yearT - yearF)) < 6) {

            //    DateValidateDateofBirthAndConfirmDateofBirth.errormessage = 'Date of passing must be at least six months before Internship completion date.';
            //    args.IsValid = false;
            //}

            if (monthF != monthT || dayF != dayT || yearF != yearT) {
                DateValidateDateofBirthAndConfirmDateofBirth.errormessage = 'Date of Birth and Confirm Date of Birth should be Same.';
                args.IsValid = false;
            }
        }
        function ValidateDOB(sender, args) {

            var dateString = document.getElementById("rightContainer_ContentTable2_txtDOB").value;
            var validatedate = '01/04/2024';
            var parts = dateString.split("/");
            var dtDOB = new Date(parts[1] + "/" + parts[0] + "/" + parts[2]);
            var partvalidatedate = validatedate.split("/");
            var dtCurrent = new Date(partvalidatedate[1] + "/" + partvalidatedate[0] + "/" + partvalidatedate[2]);
            if (dtCurrent.getFullYear() - dtDOB.getFullYear() < 15) {
                args.IsValid = false;
                return;
            }
            if (dtCurrent.getFullYear() - dtDOB.getFullYear() == 15) {
                if (dtCurrent.getMonth() < dtDOB.getMonth()) {
                    args.IsValid = false;
                    return;
                }
                if (dtCurrent.getMonth() == dtDOB.getMonth()) {
                    if (dtCurrent.getDate() < dtDOB.getDate()) {
                        args.IsValid = false;
                        return;
                    }
                }
            }
            return;
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Registration Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <table class="AppFormTable">
            <tr>
                <th colspan="4" align="left">Personal Details</th>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100  mx-auto">
                        <div class="col-4 col-lg-3 px-0">
                            Candidate's Full Name<br />
                            उमेदवाराचे पूर्ण नाव
                        </div>
                        <div class="col-8 col-lg-9 text-left">
                            <asp:TextBox ID="txtCandidateName" runat="server" Width="100%" MaxLength="300" onkeypress="return alphabetsOnly(event)" oninput="validateInput(this)"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCandidateName" runat="server" ErrorMessage="Please Enter Candidate's Full Name." ControlToValidate="txtCandidateName" Display="None"></asp:RequiredFieldValidator>
                            <font color="red">(As appeared on HSC Marksheet)(बारावी गुणपत्रिकेवर प्रकाशित केल्याप्रमाणे)</font>

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
                                    Father's Name
                                    <br />
                                    वडिलांचे नाव
                                </div>
                                <div class="col-8 col-lg-6 text-left pt-2">
                                    <asp:TextBox ID="txtFatherName" runat="server" Width="90%" MaxLength="300" onkeypress="return alphabetsOnly(event)" oninput="validateInput(this)"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvFatherName" runat="server" ErrorMessage="Please Enter Father's Name." ControlToValidate="txtFatherName" Display="None"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Mother's Name<br />
                                    आईचे नाव
                                </div>
                                <div class="col-8 col-lg-6 text-left pt-2">
                                    <asp:TextBox ID="txtMotherName" runat="server" Width="90%" MaxLength="300" onkeypress="return alphabetsOnly(event)" oninput="validateInput(this)"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvMotherName" runat="server" ErrorMessage="Please Enter Mother's Name." ControlToValidate="txtMotherName" Display="None"></asp:RequiredFieldValidator>

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
                                    Gender<br />
                                    लिंग

                                </div>
                                <div class="col-8 col-lg-6 text-left pt-2">
                                    <asp:DropDownList ID="ddlGender" runat="server" Width="90%"></asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvGender" runat="server" ControlToValidate="ddlGender" Display="None" ErrorMessage="Please Select Gender." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Confirm Gender<br />
                                    लिंग पुष्टी करा
                                </div>
                                <div class="col-8 col-lg-6 text-left pt-2">
                                    <asp:DropDownList ID="ddlGenderre" runat="server" Width="90%">
                                    </asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlGender"
                                        Display="None" ErrorMessage="Gender and Confirm Gender Should be Same." Operator="Equal" ControlToCompare="ddlGenderre" Type="String"></asp:CompareValidator>
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
                                    DOB (DD/MM/YYYY)<br />
                                    जन्म तारीख ( दिनांक/महिना/वर्ष )

                                </div>
                                <div class="col-8 col-lg-6 text-left pt-2">
                                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" Width="70%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ErrorMessage="Please Select DOB." ControlToValidate="txtDOB" Display="None"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper DOB."></asp:CustomValidator>
                                    <asp:CustomValidator ID="cvdobval" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="ValidateDOB"
                                        Display="None" ErrorMessage="Candidates who have not completed 15 Year as on Date (1 April 2024) are not eligible for CAP Process 2024."></asp:CustomValidator>
                                    <asp:CustomValidator ID="cvDOBDateValid" runat="server" ControlToValidate="txtDOB"
                                        ClientValidationFunction="isDOBDateValid" Display="None" ErrorMessage=" Date of Birth Should Not Be Greater Than Today!"></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                            Confirm Your DOB (DD/MM/YYYY)<br />
                                            जन्म तारीख ( दिनांक/महिना/वर्ष ) पुष्टी करा
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtDOBC" runat="server" MaxLength="10" Width="90%"></asp:TextBox>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:RequiredFieldValidator ID="rfvDOBC" runat="server" ErrorMessage="Please select confirm DOB."
                                                ControlToValidate="txtDOBC" Display="None"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="cvDOBC" runat="server" ControlToValidate="txtDOBC" ClientValidationFunction="isDateValidC"
                                                Display="None" ErrorMessage="Please Select Proper DOB."></asp:CustomValidator>

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
                                    Religion<br />
                                    धर्म
                                </div>
                                <div class="col-8 col-lg-6 text-left pt-2">
                                    <asp:DropDownList ID="ddlReligion" runat="server" Width="90%"></asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvReligion" runat="server" ControlToValidate="ddlReligion" Display="None" ErrorMessage="Please Select Religion." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Region<br />
                                    प्रदेश
                                </div>
                                <div class="col-8 col-lg-6 text-left pt-2">
                                    <asp:DropDownList ID="ddlRegion" runat="server" Width="90%"></asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvRegion" runat="server" ControlToValidate="ddlRegion" Display="None" ErrorMessage="Please Select Region." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                </div>

                            </div>
                        </div>
                    </div>
                </td>

            </tr>
            <tr>
                <%--<td align="right">Aadhaar Number</td>
                <td>
                    <asp:TextBox ID="txtAadhaarNumber" runat="server" Width="90%" MaxLength="12"  autocomplete="off" onKeyUp="checkAadhaarNumber()" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revAadhaarNumber" runat="server" ControlToValidate="txtAadhaarNumber" Display="None" ErrorMessage="Aadhaar Number No Should be Proper and of 12 Digits." ValidationExpression="\d{12}$"></asp:RegularExpressionValidator>
                </td>--%>
                <td align="right" colspan="4">

                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Mother Tongue<br />
                                    मातृभाषा


                                </div>
                                <div class="col-8 col-lg-6 text-left pt-2">
                                    <asp:DropDownList ID="ddlMotherTongue" runat="server" Width="90%"></asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvMotherTongue" runat="server" ControlToValidate="ddlMotherTongue" Display="None" ErrorMessage="Please Select Mother Tongue." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Annual Family Income<br />
                                    वार्षिक कौटुंबिक उत्पन्न

                                </div>
                                <div class="col-8 col-lg-6 text-left pt-2">
                                    <asp:DropDownList ID="ddlAnnualFamilyIncome" runat="server" Width="90%"></asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvAnnualFamilyIncome" runat="server" ControlToValidate="ddlAnnualFamilyIncome" Display="None" ErrorMessage="Please Select Annual Family Income." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

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
                                    Nationality<br />
                                    राष्ट्रीयत्व
                                </div>
                                <div class="col-8 col-lg-6 text-left pt-2">
                                    <asp:DropDownList ID="ddlNationality" runat="server" Width="90%"></asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvNationality" runat="server" ControlToValidate="ddlNationality" Display="None" ErrorMessage="Please Select Nationality." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <%--<tr id="trAadhaarDeclaration" runat="server">
                <td colspan="4">
                    <p align = "justify">
                        <asp:CheckBox ID="chkConfirmAadhaarDeclaration" runat="server" />
                        <font color="red"> I, the holder of Aadhaar Number given above, hereby give my consent to State CET Cell to obtain my Aadhaar number for authentication with UIDAI. State CET Cell has informed me that my identity information would only be used for admission purpose and will be submitted to CIDR only for the purpose of authentication.</font>
                        <asp:CustomValidator ID="cvValidateAadhaarDeclaration" runat="server" Display="None" ClientValidationFunction = "validateAadhaarDeclaration" ErrorMessage="Please Accept Declaration for Aadhaar."></asp:CustomValidator>
                    </p>
                </td>
            </tr>--%>
        </table>
        <asp:UpdatePanel runat="server" ID="upAddress">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <th colspan="4" align="left" style="border-top-width: 0px;">Communication Details</th>
                    </tr>
                    <tr>
                        <td align="right" style="width: 25%">Address Line 1<br />
                            पत्ता ओळ १
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtCAdressLine1" runat="server" Width="90%" MaxLength="50"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCAddressLine1" runat="server" ControlToValidate="txtCAdressLine1" Display="None" ErrorMessage="Please Enter Address Line 1."></asp:RequiredFieldValidator>
                        </td>
                        <td rowspan="3" style="width: 25%">
                            <font color="red"><b>Note : </b>Maximum allowed length for each row is 50 characters.</font>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Address Line 2<br />
                            पत्ता ओळ २

                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtCAdressLine2" runat="server" Width="90%" MaxLength="50"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCAddressLine2" runat="server" ControlToValidate="txtCAdressLine2" Display="None" ErrorMessage="Please Enter Address Line 2."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Address Line 3
                            <br />
                            पत्ता ओळ 3
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtCAdressLine3" runat="server" Width="90%" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <div class="row w-100 mx-auto">
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                            State<br />
                                            राज्य
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:DropDownList ID="ddlCState" runat="server" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlCState_SelectedIndexChanged"></asp:DropDownList>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:CompareValidator ID="cvCState" runat="server" ControlToValidate="ddlCState" Display="None" ErrorMessage="Please Select Communication Address State." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                            District<br />
                                            जिल्हा

                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:DropDownList ID="ddlCDistrict" runat="server" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlCDistrict_SelectedIndexChanged"></asp:DropDownList>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:CompareValidator ID="cvCDistrict" runat="server" ControlToValidate="ddlCDistrict" Display="None" ErrorMessage="Please Select Communication Address District." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

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
                                            Taluka<br />
                                            तालुका

                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:DropDownList ID="ddlCTaluka" runat="server" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlCTaluka_SelectedIndexChanged"></asp:DropDownList>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:CompareValidator ID="cvCTaluka" runat="server" ControlToValidate="ddlCTaluka" Display="None" ErrorMessage="Please Select Communication Address Taluka." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                            Village<br />
                                            गाव

                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:DropDownList ID="ddlCVillage" runat="server" Width="90%"></asp:DropDownList>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:CompareValidator ID="cvCVillage" runat="server" ControlToValidate="ddlCVillage" Display="None" ErrorMessage="Please Select Communication Address Village." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

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
                                            PIN Code<br />
                                            पिन कोड
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtCPincode" runat="server" MaxLength="6" onKeyPress="return numbersonly(event)" Width="90%"></asp:TextBox>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:RequiredFieldValidator ID="rfvCPincode" runat="server" ControlToValidate="txtCPincode" Display="None" ErrorMessage="Please Enter Communication Address Pincode."></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revCPincode" runat="server" ControlToValidate="txtCPincode" Display="None" ErrorMessage="Communication Address Pincode Should be of 6 Digits." ValidationExpression="\d{6}"></asp:RegularExpressionValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                            Telephone No<br />
                                            दूरध्वनी क्रमांक
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtSTDCode" runat="server" Width="67px" MaxLength="5" onKeyPress="return numbersonly(event)"></asp:TextBox>
                                            -
                            <asp:TextBox ID="txtPhoneNo" runat="server" Width="84px" MaxLength="8" onKeyPress="return numbersonly(event)"></asp:TextBox>
                                            <asp:CompareValidator ID="cvSTDCode" runat="server" ControlToValidate="txtSTDCode" Display="None" ErrorMessage="Please Enter Proper STD Code." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                            <asp:CompareValidator ID="cvPhoneNo" runat="server" ControlToValidate="txtPhoneNo" Display="None" ErrorMessage="Please Enter Proper Phone No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>

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
                                            Mobile No<br />
                                            भ्रमणध्वनी क्रमांक

                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" onKeyPress="return numbersonly(event)" Width="90%" Enabled="false"></asp:TextBox>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Please Enter Mobile No."></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Mobile No Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                            E-Mail ID<br />
                                            ई - मेल आयडी

                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtEMailID" runat="server" MaxLength="100" Width="90%"></asp:TextBox>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:RequiredFieldValidator ID="rfvEMailID" runat="server" ControlToValidate="txtEMailID" Display="None" ErrorMessage="Please Enter E-Mail ID."></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revEMailID" runat="server" ControlToValidate="txtEMailID" Display="None" ErrorMessage="Please Enter Valid E-Mail ID." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </td>


                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:CustomValidator ID="DateValidateDateofBirthAndConfirmDateofBirth" runat="server" ClientValidationFunction="checkDateofBirthAndConfirmDateofBirth"
                        Display="None" ErrorMessage=""></asp:CustomValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        var dp_cal;
        var dp_calC;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDOB'));
            dp_calC = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDOBC'));
        };


    </script>
</asp:Content>


