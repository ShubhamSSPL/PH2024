<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="TestApplicationForm.aspx.cs" Inherits="Pharmacy2024.SBAdmin.TestApplicationForm" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_ContentTable2_chkConfirmAadhaarDeclaration {
            width: 20px;
            height: 20px;
        }
    </style>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" lang="javascript"></script>
    <script src="../Scripts/HintBox.js" type="text/javascript" lang="javascript"></script>
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
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
        function checkAadhaarNumber() {
            document.getElementById("<%=chkConfirmAadhaarDeclaration.ClientID %>").checked = false;

            if (document.getElementById("<%=txtAadhaarNumber.ClientID %>").value.length == 12) {
                document.getElementById("<%=trAadhaarDeclaration.ClientID %>").style.display = '';
                document.getElementById("<%=cvValidateAadhaarDeclaration.ClientID %>").enabled = true;
            }
            else {
                document.getElementById("<%=trAadhaarDeclaration.ClientID %>").style.display = 'none';
                document.getElementById("<%=cvValidateAadhaarDeclaration.ClientID %>").enabled = false;
            }
        }
        function validateAadhaarDeclaration(sender, args) {
            if (document.getElementById("<%=chkConfirmAadhaarDeclaration.ClientID %>").checked == true) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
        function blankSecurityAnswer() {
            document.getElementById("rightContainer_ContentTable2_txtSecurityAnswer").value = '';
            document.getElementById("rightContainer_ContentTable2_txtConfirmSecurityAnswer").value = '';
        }
    </script>


    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Registration Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="table-responsive">
            <table class=" AppFormTable">
                <tr>
                    <th colspan="4" align="left">Personal Details</th>
                </tr>
                <tr>

                    <td align="right" class="col-form-label" colspan="4">
                        <div class="row w-100 mx-auto  px-0 ">
                            <div class="col-4 col-lg-3 text-right px-0">
                                Candidate's Full Name
                        <br />
                                उमेदवाराचे पूर्ण नाव
                            </div>
                            <div class="col-8 col-lg-9 text-left ">

                                <div class="">
                                    <asp:TextBox ID="txtCandidateName" CssClass="col-form-control " runat="server" Width="90%" MaxLength="300" onmouseover="ddrivetip('Please Enter Candidate\'s Full Name as appeared on HSC Marksheet.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                    <br />
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvCandidateName" runat="server" ErrorMessage="Please Enter Candidate's Full Name." ControlToValidate="txtCandidateName" Display="None"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorCandidateName" runat="server" ControlToValidate="txtCandidateName" Display="None" ErrorMessage="Special characters Not Allowed in Candidate's Name." ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                                    <font color="red">(As appeared on HSC Marksheet) (बारावी गुणपत्रिकेवर प्रकाशित केल्याप्रमाणे)</font>
                                </div>
                            </div>
                        </div>
                    </td>


                </tr>
                <tr>
                    <td align="right" class="col-form-label" colspan="4">
                        <div class="row w-100 mx-auto   px-0  ">
                            <div class="col-sm-6 px-0  px-0">
                                <div class="row w-100 mx-auto    ">
                                    <div class="col-4 col-md-6 text-right px-0">
                                        Father's Name
                                <br />
                                        वडिलांचे नाव
                                    </div>
                                    <div class="col-8 col-md-6 text-left py-2">
                                        <asp:TextBox ID="txtFatherName" runat="server" Width="90%" MaxLength="300" onmouseover="ddrivetip('Please Enter Father\'s Name.')" onmouseout="hideddrivetip()" CssClass="col-form-control "></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvFatherName" runat="server" ErrorMessage="Please Enter Father's Name." ControlToValidate="txtFatherName" Display="None"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorFatherName" runat="server" ControlToValidate="txtFatherName" Display="None" ErrorMessage="Special characters Not Allowed in Father's Name." ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 px-0  px-0">
                                <div class="row w-100 mx-auto    px-0 ">
                                    <div class="col-4 col-md-6 text-right px-0">
                                        Mother's Name
                                <br />
                                        आईचे नाव
                                    </div>
                                    <div class="col-8 col-md-6 text-left py-2 ">
                                        <asp:TextBox ID="txtMotherName" runat="server" Width="90%" MaxLength="300" onmouseover="ddrivetip('Please Enter Mother\'s Name.')" onmouseout="hideddrivetip()" CssClass="col-form-control "></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvMotherName" runat="server" ErrorMessage="Please Enter Mother's Name." ControlToValidate="txtMotherName" Display="None"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorMotherName" runat="server" ControlToValidate="txtMotherName" Display="None" ErrorMessage="Special characters Not Allowed in Mother's Name." ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>

                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <div class="row w-100 mx-auto  ">
                            <div class="col-sm-6 px-0 px-0">
                                <div class="row w-100 mx-auto  ">
                                    <div class="col-4 col-lg-6 px-0">
                                        Gender
                                           <br />
                                        लिंग
                                    </div>
                                    <div class="col-8 col-lg-6 text-left py-2">
                                        <asp:DropDownList ID="ddlGender" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Gender.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:CompareValidator ID="cvGender" runat="server" ControlToValidate="ddlGender" Display="None" ErrorMessage="Please Select Gender." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 px-0 px-0">
                                <div class="row w-100 mx-auto  ">
                                    <div class="col-4 col-lg-6 px-0">
                                        DOB (DD/MM/YYYY)
                                       <br />
                                        जन्म तारीख ( दिनांक/महिना/वर्ष )
                                    </div>
                                    <div class="col-8 col-lg-6 text-left py-2">
                                        <asp:TextBox ID="txtDOB" runat="server" Width="90%" MaxLength="10" onmouseover="ddrivetip('Please Select DOB. It should be in DD/MM/YYYY format.')" onmouseout="hideddrivetip()" CssClass="col-form-control "></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ErrorMessage="Please Select DOB." ControlToValidate="txtDOB" Display="None"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper DOB."></asp:CustomValidator>

                                    </div>

                                </div>

                            </div>
                        </div>
                    </td>


                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <div class="row w-100 mx-auto  ">
                            <div class="col-sm-6 px-0 px-0">
                                <div class="row w-100 mx-auto  ">
                                    <div class="col-4 col-lg-6 px-0">
                                        Religion
                        <br />
                                        धर्म
                                    </div>
                                    <div class="col-8 col-lg-6 text-left py-2">
                                        <asp:DropDownList ID="ddlReligion" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Religion.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:CompareValidator ID="cvReligion" runat="server" ControlToValidate="ddlReligion" Display="None" ErrorMessage="Please Select Religion." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 px-0 px-0">
                                <div class="row w-100 mx-auto  ">
                                    <div class="col-4 col-lg-6 px-0">
                                        Region
                        <br />
                                        प्रदेश
                                    </div>
                                    <div class="col-8 col-lg-6 text-left py-2">
                                        <asp:DropDownList ID="ddlRegion" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Region.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:CompareValidator ID="cvRegion" runat="server" ControlToValidate="ddlRegion" Display="None" ErrorMessage="Please Select Region." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                    </div>
                                </div>
                            </div>

                        </div>

                    </td>

                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <div class="row w-100 mx-auto  ">
                            <div class="col-sm-6 px-0 px-0">
                                <div class="row w-100 mx-auto  ">
                                    <div class="col-4 col-lg-6 px-0">
                                        Mother Tongue
                        <br />
                                        मातृभाषा
                                    </div>
                                    <div class="col-8 col-lg-6 text-left py-2">
                                        <asp:DropDownList ID="ddlMotherTongue" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Mother Tongue.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:CompareValidator ID="cvMotherTongue" runat="server" ControlToValidate="ddlMotherTongue" Display="None" ErrorMessage="Please Select Mother Tongue." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 px-0 px-0">
                                <div class="row w-100 mx-auto  ">
                                    <div class="col-4 col-lg-6 px-0">
                                        Annual Family Income
                        <br />
                                        वार्षिक कौटुंबिक उत्पन्न
                                    </div>
                                    <div class="col-8 col-lg-6 text-left py-2">
                                        <asp:DropDownList ID="ddlAnnualFamilyIncome" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Annual Family Income.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:CompareValidator ID="cvAnnualFamilyIncome" runat="server" ControlToValidate="ddlAnnualFamilyIncome" Display="None" ErrorMessage="Please Select Annual Family Income." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <div class="row w-100 mx-auto  ">
                            <div class="col-sm-6 px-0">
                                <div class="row w-100 mx-auto  ">
                                    <div class="col-4 col-lg-6 px-0">
                                        Aadhaar Number
                        <br />
                                        आधार क्रमांक
                                    </div>
                                    <div class="col-8 col-lg-6 text-left pt-2">
                                        <asp:TextBox ID="txtAadhaarNumber" runat="server" Width="90%" MaxLength="12" autocomplete="off" onKeyUp="checkAadhaarNumber()" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Aadhaar Number. It should be proper and of 12 Digits.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="revAadhaarNumber" runat="server" ControlToValidate="txtAadhaarNumber" Display="None" ErrorMessage="Aadhaar Number No Should be Proper and of 12 Digits." ValidationExpression="\d{12}$"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 px-0 px-0">
                                <div class="row w-100 mx-auto  ">
                                    <div class="col-4 col-lg-6 px-0">
                                        Nationality
                        <br />
                                        राष्ट्रीयत्व
                                    </div>
                                    <div class="col-8 col-lg-6 text-left pt-2">
                                        <asp:DropDownList ID="ddlNationality" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Nationality.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:CompareValidator ID="cvNationality" runat="server" ControlToValidate="ddlNationality" Display="None" ErrorMessage="Please Select Nationality." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </td>


                </tr>
                <tr id="trAadhaarDeclaration" runat="server">
                    <td colspan="4">

                        <p align="justify">
                            <asp:CheckBox ID="chkConfirmAadhaarDeclaration" runat="server" />
                            <font color="red"> I, the holder of Aadhaar Number given above, hereby give my consent to DTE to obtain my Aadhaar number for authentication with UIDAI. DTE has informed me that my identity information would only be used for admission purpose and will be submitted to CIDR only for the purpose of authentication.</font>
                            <asp:CustomValidator ID="cvValidateAadhaarDeclaration" runat="server" Display="None" ClientValidationFunction="validateAadhaarDeclaration" ErrorMessage="Please Accept Declaration for Aadhaar."></asp:CustomValidator>
                        </p>
                    </td>
                </tr>
            </table>
        </div>
        <asp:UpdatePanel runat="server" ID="upAddress">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <th colspan="4" align="left" style="border-top-width: 0px;">Communication Details</th>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <div class="row w-100 mx-auto  ">
                                <div class="col-4 col-lg-3 text-right px-0">
                                    Address Line 1
                            <br />
                                    पत्ता ओळ १
                                </div>
                                <div class="col-8 col-lg-9 text-left pt-2">
                                    <asp:TextBox ID="txtCAdressLine1" runat="server" Width="90%" MaxLength="50" onmouseover="ddrivetip('Please Enter Address Line 1.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvCAddressLine1" runat="server" ControlToValidate="txtCAdressLine1" Display="None" ErrorMessage="Please Enter Address Line 1."></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <div class="row w-100 mx-auto  ">
                                <div class="col-4 col-lg-3 text-right px-0">
                                    Address Line 2
                            <br />
                                    पत्ता ओळ  २
                                </div>
                                <div class="col-8 col-lg-9 text-left pt-2">
                                    <asp:TextBox ID="txtCAdressLine2" runat="server" Width="90%" MaxLength="50" onmouseover="ddrivetip('Please Enter Address Line 2.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvCAddressLine2" runat="server" ControlToValidate="txtCAdressLine2" Display="None" ErrorMessage="Please Enter Address Line 2."></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </td>


                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <div class="row w-100 mx-auto  ">
                                <div class="col-4 col-lg-3 text-right px-0">
                                    Address Line 2
                            <br />
                                    पत्ता ओळ  २
                                </div>
                                <div class="col-8 col-lg-9 text-left pt-2">
                                    <asp:TextBox ID="txtCAdressLine3" runat="server" Width="90%" MaxLength="50" onmouseover="ddrivetip('Please Enter Address Line 3.')" onmouseout="hideddrivetip()"></asp:TextBox>

                                </div>
                            </div>
                        </td>


                    </tr>
                    <tr>


                        <td style="width: 25%;" align="right" colspan="4">
                            <div class="row w-100 mx-auto  ">
                                <div class="col-sm-6 px-0 px-0">
                                    <div class="row w-100 mx-auto  ">
                                        <div class="col-4 col-lg-6 px-0">
                                            State
                            <br />
                                            राज्य
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:DropDownList ID="ddlCState" runat="server" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlCState_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Communication Address State.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:CompareValidator ID="cvCState" runat="server" ControlToValidate="ddlCState" Display="None" ErrorMessage="Please Select Communication Address State." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 px-0 px-0">
                                    <div class="row w-100 mx-auto  ">
                                        <div class="col-4 col-lg-6 px-0">
                                            District
                            <br />
                                            जिल्हा
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:DropDownList ID="ddlCDistrict" runat="server" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlCDistrict_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Communication Address District.')" onmouseout="hideddrivetip()"></asp:DropDownList>
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
                            <div class="row w-100 mx-auto  ">
                                <div class="col-sm-6 px-0 px-0">
                                    <div class="row w-100 mx-auto  ">
                                        <div class="col-4 col-lg-6 px-0">
                                            Taluka
                            <br />
                                            तालुका
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:DropDownList ID="ddlCTaluka" runat="server" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlCTaluka_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Communication Address Taluka.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:CompareValidator ID="cvCTaluka" runat="server" ControlToValidate="ddlCTaluka" Display="None" ErrorMessage="Please Select Communication Address Taluka." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 px-0 px-0">
                                    <div class="row w-100 mx-auto  ">
                                        <div class="col-4 col-lg-6 px-0">
                                            Village
                            <br />
                                            गाव
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:DropDownList ID="ddlCVillage" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Communication Address Village.')" onmouseout="hideddrivetip()"></asp:DropDownList>
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
                            <div class="row w-100 mx-auto  ">
                                <div class="col-sm-6 px-0">
                                    <div class="row w-100 mx-auto  ">
                                        <div class="col-4 col-lg-6 px-0">
                                            PIN Code
                            <br />
                                            पिन कोड
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtCPincode" runat="server" MaxLength="6" onKeyPress="return numbersonly(event)" Width="90%" onmouseover="ddrivetip('Please Enter Communication Address PIN Code. It Should be of 6 Digits.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:RequiredFieldValidator ID="rfvCPincode" runat="server" ControlToValidate="txtCPincode" Display="None" ErrorMessage="Please Enter Communication Address Pincode."></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revCPincode" runat="server" ControlToValidate="txtCPincode" Display="None" ErrorMessage="Communication Address Pincode Should be of 6 Digits." ValidationExpression="\d{6}"></asp:RegularExpressionValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 px-0">
                                    <div class="row w-100 mx-auto  ">
                                        <div class="col-4 col-lg-6 px-0">
                                            Telephone No
                            <br />
                                            दूरध्वनी क्रमांक
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtSTDCode" runat="server" Width="40px" MaxLength="5" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Proper STD Code.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                            -
                            <asp:TextBox ID="txtPhoneNo" runat="server" Width="70px" MaxLength="8" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Proper Phone No.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                            <asp:CompareValidator ID="cvSTDCode" runat="server" ControlToValidate="txtSTDCode" Display="None" ErrorMessage="Please Enter Proper STD Code." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                            <asp:CompareValidator ID="cvPhoneNo" runat="server" ControlToValidate="txtPhoneNo" Display="None" ErrorMessage="Please Enter Proper Phone No." Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </td>



                    </tr>
                    <tr>
                        <td colspan="4" align="center"><font color="red">One Time Password (OTP) will be sent to the mobile number given below for activation of your login.<br />Kindly make sure that mobile number is correct. This mobile number will be used for all future communications.</font></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <div class="row w-100 mx-auto  ">
                                <div class="col-sm-6 px-0">
                                    <div class="row w-100 mx-auto  ">
                                        <div class="col-4 col-lg-6 px-0">
                                            Mobile No
                            <br />
                                            भ्रमणध्वनी क्रमांक
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" onKeyPress="return numbersonly(event)" Width="90%" onmouseover="ddrivetip('Please Enter Mobile Number. It Should be Proper and of 10 Digits like \'9999999999\'.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Please Enter Mobile No."></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Mobile No Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 px-0">
                                    <div class="row w-100 mx-auto  ">
                                        <div class="col-4 col-lg-6 px-0">
                                            E-Mail ID
                            <br />
                                            ई - मेल आयडी
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtEMailID" runat="server" MaxLength="100" Width="90%" onmouseover="ddrivetip('Please Enter Valid E-Mail ID.')" onmouseout="hideddrivetip()"></asp:TextBox>
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
        <table class="AppFormTable">
            <%-- <tr>
                <th colspan = "2" align = "left" style="border-top-width:0px;">Choose Security Question Details</th>
            </tr>
            <tr>
                <td style="width: 50%;" align="right">Security Question</td>
                <td style="width: 50%;">
                    <asp:DropDownList ID="ddlSecurityQuestion" runat="server" onmouseover="ddrivetip('Please Select Security Question.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                    <font color = "red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSecurityQuestion" runat="server" ControlToValidate="ddlSecurityQuestion" Display="None" ErrorMessage="Please Select Security Question." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Security Answer</td>
                <td>
                    <asp:TextBox ID="txtSecurityAnswer" runat="server" MaxLength = "100" TextMode = "Password" onmouseover="ddrivetip('Please Enter Security Answer.')" onmouseout="hideddrivetip()"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSecurityAnswer" runat="server" ControlToValidate="txtSecurityAnswer"  ErrorMessage="Please Enter Security Answer." Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Confirm Security Answer</td>
                <td>
                    <asp:TextBox ID="txtConfirmSecurityAnswer" runat="server" MaxLength = "100" TextMode = "Password" onmouseover="ddrivetip('Please Enter Confirm Security Answer.')" onmouseout="hideddrivetip()"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvConfirmSecurityAnswer" runat="server" ErrorMessage="Please Enter Confirm Security Answer." Display="None" ControlToValidate="txtConfirmSecurityAnswer"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmSecurityAnswer" runat="server" ControlToCompare="txtConfirmSecurityAnswer" ControlToValidate="txtSecurityAnswer" ErrorMessage="Security Answer and Confirm Security Answer should be Same." Display = "none"></asp:CompareValidator>
                </td>
            </tr>--%>
            <tr>
                <th colspan="2" align="left" style="border-top-width: 0px;">Choose Password </th>
            </tr>
            <tr>
                <td colspan="2">
                    <font color="red">
                        <p align = "justify"><font color = "red"><b>The Password must be as per the following Password policy :</b></font></p>
                        <ul class="list-text">
                            <li><p align = "justify"><font color = "red">Password must be 8 to 13 character long.</font></p></li>
                            <li><p align = "justify"><font color = "red">Password must have at least one Upper case alphabet.</font></p></li>
                            <li><p align = "justify"><font color = "red">Password must have at least one Lower case alphabet.</font></p></li>
                            <li><p align = "justify"><font color = "red">Password must have at least one numeric value.</font></p></li>
                            <li><p align = "justify"><font color = "red">Password must have at least one special characters eg.!@#$%^&*-</font></p></li>
                        </ul>
                    </font>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto  ">
                        <div class="col-4 col-lg-6 pr-0">
                            Choose Your Password
                    <br />
                            संकेतशब्द निवडा
                        </div>
                        <div class="col-8 col-lg-6 text-left py-2">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="13" onmouseover="ddrivetip('Please Choose Your Password. It must be 8 to 13 character long and must have at least one Upper case alphabet, one Lower case alphabet, one numeric value and one special character.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Choose Your Password." Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Password must be 8 to 13 character long and must have at least one Upper case alphabet, one Lower case alphabet, one numeric value and one special character." ValidationExpression="^.*(?=^.{8,13}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"></asp:RegularExpressionValidator>

                        </div>
                    </div>
                </td>

            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto  ">
                        <div class="col-4 col-lg-6 pr-0">
                            Confirm Password
                    <br />
                            संकेतशब्दाची  पुष्टी करा
                        </div>
                        <div class="col-8 col-lg-6 text-left py-2">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" MaxLength="13" onmouseover="ddrivetip('Please Enter Confirm Password.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please Enter Confirm Password." Display="None"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" ErrorMessage="Password and Confirm Password should be Same." Display="None"></asp:CompareValidator>


                        </div>
                    </div>


                </td>


            </tr>
        </table>
        <asp:UpdatePanel runat="server" ID="upSecurityPin">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>

                        <td align="right" colspan="4">
                            <div class="row w-100 mx-auto  ">
                                <div class="col-4 col-lg-6 pr-0">
                                    Enter Security Pin Given Below (case sensitive)
                                </div>
                                <div class="col-8 col-lg-6 text-left py-2">
                                    
                                        <asp:TextBox ID="txtSecurityPin" runat="server" MaxLength="5"  onmouseover="ddrivetip('Please Enter Security Pin (case sensitive).')" onmouseout="hideddrivetip()" autocomplete="off"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvSecurityPin" runat="server" ControlToValidate="txtSecurityPin" ErrorMessage="Please Enter Security Pin (case sensitive)." Display="None"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                        </td>

                    </tr>
                    <tr>

                        
                        <td align="right" colspan="3">
                            <div class="row w-100 mx-auto  ">
                                <div class="col-4 col-lg-6 pr-0 pt-2">
                                    Security Pin
                                </div>
                                <div class="col-8 col-lg-6 text-left ">
                                        <cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5" CaptchaHeight="40" CaptchaWidth="190" CaptchaFont="Verdana" Font-Bold="false" Font-Italic="true" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ23456789" />
                       
                                    </div>

                            </div>
                            </td>
                    
                        <td style="border-left-width: 0px;">
                            <asp:ImageButton runat="server" ID="btnUpdateSecurityPin" ImageUrl="~/Images/refresh.png" ValidationGroup="UpdateSecurityPin" /></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click"/>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <ccm:ContentBox ID="contentSecretKey" runat="server" HeaderText="Secret Key" BoxType="PopupBox"
        Width="50%" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Text="This Screate is only for Testing Purpose. Registration Window is not Opened till Now. "
                        ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblmsg" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;" align="right">Enter Secret Key
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtkey" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSecretKey" runat="server" OnClick="btnSecretKey_Click" Text="Submit"
                        ValidationGroup="secret" />
                </td>
            </tr>
        </table>
        <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
    </ccm:ContentBox>
    <script lang="javascript" type="text/javascript">
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDOB'));
        };
        checkAadhaarNumber();
        function showSecretKey() {
            document.getElementById('<%=contentSecretKey.ClientID %>').Show('', true);
        }
    </script>
</asp:Content>
