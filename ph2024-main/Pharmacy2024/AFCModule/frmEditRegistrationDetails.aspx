<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditRegistrationDetails.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEditRegistrationDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #ctl00_rightContainer_ContentTable2_chkConfirmAadhaarDeclaration {
            width: 20px;
            height: 20px;
        }
        
        @media screen and (max-width:425px){
            .AppFormTable .col-sm-6{
                padding:5px;
            }           
            
        }
    </style>
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
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
        function alphabetsOnly(evt) {
            var keyCode = (evt.which) ? evt.which : evt.keyCode;

            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode >= 123) && (keyCode != 32) && (keyCode != 39) && (keyCode != 8)) {
                return false;
            }
            else {
                return true;
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
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%" align="right">Application ID</td>
                <td style="width: 50%">
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate's Name</td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
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
                    <div class="row">
                        <div class="col-4 col-lg-3">
                            Candidate's Name
                        </div>
                        <div class="col-8 col-lg-9 text-left">
                           <asp:TextBox ID="txtCandidateName" runat="server" Width="250px" MaxLength="300" onmouseover="ddrivetip('Please Enter Candidate\'s Name as appeared on HSC Marksheet.')" onmouseout="hideddrivetip()" onkeypress="return alphabetsOnly(event)"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCandidateName" runat="server" ErrorMessage="Please Enter Candidate's Name." ControlToValidate="txtCandidateName" Display="None"></asp:RequiredFieldValidator>
                            <font color="red">(As appeared on HSC Marksheet)</font>
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
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtFatherName" runat="server" Width="90%" MaxLength="300" onmouseover="ddrivetip('Please Enter Father\'s Name.')" onmouseout="hideddrivetip()" onkeypress="return alphabetsOnly(event)"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvFatherName" runat="server" ErrorMessage="Please Enter Father's Name." ControlToValidate="txtFatherName" Display="None"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Mother's Name
                                </div>
                                <div class="col-8 col-lg-6 text-left ">
                                    <asp:TextBox ID="txtMotherName" runat="server" Width="90%" MaxLength="300" onmouseover="ddrivetip('Please Enter Mother\'s Name.')" onmouseout="hideddrivetip()" onkeypress="return alphabetsOnly(event)"></asp:TextBox>
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
                                    Gender
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:DropDownList ID="ddlGender" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Gender.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvGender" runat="server" ControlToValidate="ddlGender" Display="None" ErrorMessage="Please Select Gender." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    DOB (DD/MM/YYYY)
                                </div>
                                <div class="col-8 col-lg-6 text-left ">
                                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" Width="90%" onmouseover="ddrivetip('Please Select DOB. It should be in DD/MM/YYYY format.')" onmouseout="hideddrivetip()"></asp:TextBox>
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
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Religion
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:DropDownList ID="ddlReligion" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Religion.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvReligion" runat="server" ControlToValidate="ddlReligion" Display="None" ErrorMessage="Please Select Religion." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Region
                                </div>
                                <div class="col-8 col-lg-6 text-left ">
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
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Mother Tongue
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:DropDownList ID="ddlMotherTongue" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Mother Tongue.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvMotherTongue" runat="server" ControlToValidate="ddlMotherTongue" Display="None" ErrorMessage="Please Select Mother Tongue." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Annual Family Income
                                </div>
                                <div class="col-8 col-lg-6 text-left ">
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
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6 px-0">
                                    Nationality
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:DropDownList ID="ddlNationality" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Nationality.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvNationality" runat="server" ControlToValidate="ddlNationality" Display="None" ErrorMessage="Please Select Nationality." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>

                    </div>
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
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDOB'));
        };
    </script>
</asp:Content>
