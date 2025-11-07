<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmQualificationDetails.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmQualificationDetails" %>

<%@ Register TagPrefix="ddlb" Assembly="OptionDropDownList" Namespace="OptionDropDownList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%--<%@ Register Assembly="DropDownList_OptGroup" Namespace="DropDownList_OptGroup" TagPrefix="cc2" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .txtAlign {
            text-align: center;
        }

        #rightContainer_ContentTable2_ddlSSCBoard, #rightContainer_ContentTable2_ddlHSCBoard {
            width: 97%;
        }

        @media only screen and (max-width: 768px) {
            #rightContainer_ContentTable2_ddlSSCBoard, #rightContainer_ContentTable2_ddlHSCBoard {
                width: 90%;
            }
        }
    </style>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function Left(str, n) {
            if (n <= 0)
                return "";
            else if (n > String(str).length)
                return str;
            else if (String(str).substring(0, n) == "57.99")
                return "58";
            else if (String(str).substring(0, n) == "56.99")
                return "57";
            else
                return String(str).substring(0, n);
        }
        function numfor(a) {
            return a.toFixed(2);
            //return Left(a, 5);
        }
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if ((unicode >= 48 && unicode <= 57) || unicode == 46) {
                    return true
                }
                else {
                    return false
                }
            }
        }
        function validateInput(input) {
            var regex = /^[a-zA-Z]*$/;
            if (!regex.test(input.value)) {
                input.value = input.value.replace(/[^a-zA-Z\s]/g, "");
            }
        }
        function HSCValueKeyPress() {
            var HSCBoard = document.getElementById("rightContainer_ContentTable2_ddlHSCBoard").value;
            var HSCPassingYear = document.getElementById("rightContainer_ContentTable2_ddlHSCPassingYear").value;

            if (HSCBoard == "1" && (HSCPassingYear == "2018_3" || HSCPassingYear == "2019" || HSCPassingYear == "2021" || HSCPassingYear == "2022" || HSCPassingYear == "2023" || HSCPassingYear == "2024")) {
                document.getElementById("rightContainer_ContentTable2_txtHSCPhysicsMarksObtained").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCPhysicsMarksOutOf").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCPhysicsPercentage").value = "";

                document.getElementById("rightContainer_ContentTable2_txtHSCChemistryMarksObtained").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCChemistryMarksOutOf").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCChemistryPercentage").value = "";

                document.getElementById("rightContainer_ContentTable2_txtHSCSubjectMarksObtained").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCSubjectMarksOutOf").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCSubjectPercentage").value = "";

                document.getElementById("rightContainer_ContentTable2_txtHSCEnglishMarksObtained").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCEnglishMarksOutOf").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCEnglishPercentage").value = "";

                document.getElementById("rightContainer_ContentTable2_txtHSCTotalMarksObtained").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCTotalMarksOutOf").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCTotalPercentage").value = "";

                document.getElementById("rightContainer_ContentTable2_rbnHSCPassed").checked = false;
                document.getElementById("rightContainer_ContentTable2_rbnHSCFailed").checked = false;

                document.getElementById("rightContainer_ContentTable2_ddlHSCSubject").value = "0";
            }
        }
        //        function sscMathMarksChanged() 
        //        {
        //            if (document.getElementById("rightContainer_ContentTable2_txtSSCMathMarksObtained").value != "" && document.getElementById("rightContainer_ContentTable2_txtSSCMathMarksOutOf").value != "") 
        //            {
        //                document.getElementById("rightContainer_ContentTable2_txtSSCMathPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_ContentTable2_txtSSCMathMarksObtained").value) / parseFloat(document.getElementById("rightContainer_ContentTable2_txtSSCMathMarksOutOf").value)) * 100));
        //            }
        //            else 
        //            {
        //                document.getElementById("rightContainer_ContentTable2_txtSSCMathPercentage").value = "";
        //            }
        //        }
        //        function sscTotalMarksChanged() 
        //        {
        //            if (document.getElementById("rightContainer_ContentTable2_txtSSCTotalMarksObtained").value != "" && document.getElementById("rightContainer_ContentTable2_txtSSCTotalMarksOutOf").value != "") 
        //            {
        //                document.getElementById("rightContainer_ContentTable2_txtSSCTotalPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_ContentTable2_txtSSCTotalMarksObtained").value) / parseFloat(document.getElementById("rightContainer_ContentTable2_txtSSCTotalMarksOutOf").value)) * 100));
        //            }
        //            else 
        //            {
        //                document.getElementById("rightContainer_ContentTable2_txtSSCTotalPercentage").value = "";
        //            }
        //        }
        function checkHSCPlace(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnHSCPlaceIndia").checked || document.getElementById("rightContainer_ContentTable2_rbnHSCPlaceAbroad").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtHSCDOB").value;
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
        function checkHSCPassingStatus(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnHSCPassed").checked || document.getElementById("rightContainer_ContentTable2_rbnHSCFailed").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
        function hscPhysicsMarksChanged() {
            if (document.getElementById("rightContainer_ContentTable2_txtHSCPhysicsMarksObtained").value != "" && document.getElementById("rightContainer_ContentTable2_txtHSCPhysicsMarksOutOf").value != "") {
                document.getElementById("rightContainer_ContentTable2_txtHSCPhysicsPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCPhysicsMarksObtained").value) / parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCPhysicsMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_ContentTable2_txtHSCPhysicsPercentage").value = "";
            }
        }
        function hscChemistryMarksChanged() {
            if (document.getElementById("rightContainer_ContentTable2_txtHSCChemistryMarksObtained").value != "" && document.getElementById("rightContainer_ContentTable2_txtHSCChemistryMarksOutOf").value != "") {
                document.getElementById("rightContainer_ContentTable2_txtHSCChemistryPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCChemistryMarksObtained").value) / parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCChemistryMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_ContentTable2_txtHSCChemistryPercentage").value = "";
            }
        }
        function hscSubjectMarksChanged() {
            if (document.getElementById("rightContainer_ContentTable2_txtHSCSubjectMarksObtained").value != "" && document.getElementById("rightContainer_ContentTable2_txtHSCSubjectMarksOutOf").value != "") {
                document.getElementById("rightContainer_ContentTable2_txtHSCSubjectPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCSubjectMarksObtained").value) / parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCSubjectMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_ContentTable2_txtHSCSubjectPercentage").value = "";
            }
        }
        function hscEnglishMarksChanged() {
            if (document.getElementById("rightContainer_ContentTable2_txtHSCEnglishMarksObtained").value != "" && document.getElementById("rightContainer_ContentTable2_txtHSCEnglishMarksOutOf").value != "") {
                document.getElementById("rightContainer_ContentTable2_txtHSCEnglishPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCEnglishMarksObtained").value) / parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCEnglishMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_ContentTable2_txtHSCEnglishPercentage").value = "";
            }
        }
        function hscTotalMarksChanged() {
            if (document.getElementById("rightContainer_ContentTable2_txtHSCTotalMarksObtained").value != "" && document.getElementById("rightContainer_ContentTable2_txtHSCTotalMarksOutOf").value != "") {
                document.getElementById("rightContainer_ContentTable2_txtHSCTotalPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCTotalMarksObtained").value) / parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCTotalMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_ContentTable2_txtHSCTotalPercentage").value = "";
            }
        }
        function checkAppearedForDiploma(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnAppearedForDiplomaYes").checked || document.getElementById("rightContainer_ContentTable2_rbnAppearedForDiplomaNo").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
        function diplomaTotalMarksChanged() {
            if (document.getElementById("rightContainer_ContentTable2_txtDiplomaTotalMarksObtained").value != "" && document.getElementById("rightContainer_ContentTable2_txtDiplomaTotalMarksOutOf").value != "") {
                document.getElementById("rightContainer_ContentTable2_txtDiplomaTotalPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_ContentTable2_txtDiplomaTotalMarksObtained").value) / parseFloat(document.getElementById("rightContainer_ContentTable2_txtDiplomaTotalMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_ContentTable2_txtDiplomaTotalPercentage").value = "";
            }
        }
        function checkDiplomaMarksType(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnPercentage").checked || document.getElementById("rightContainer_ContentTable2_rbnCGPA").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            //            sscMathMarksChanged();
            //            sscTotalMarksChanged();
            hscPhysicsMarksChanged();
            hscChemistryMarksChanged();
            hscSubjectMarksChanged();
            hscEnglishMarksChanged();
            hscTotalMarksChanged();
            if (document.getElementById("rightContainer_ContentTable2_tblDiplomaMarks") != null) {
                diplomaTotalMarksChanged();
            }
            if (document.getElementById("rightContainer_ContentTable2_txtHSCDOB") != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtHSCDOB'));
            }
        }
        window.onload = load;
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Qualification Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upQualification">
            <ContentTemplate>
                <table class="AppFormTable ">
                    <tr>
                        <th align="left" colspan="4">SSC / Equivalent Details</th>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <div class="row w-100  mx-auto">
                                <div class="col-4 col-lg-3 px-0">
                                    SSC Board<br />
                                    दहावी बोर्ड

                                </div>
                                <div class="col-8 col-lg-9 text-left input-wid">
                                    <ddlb:OptionGroupSelect ID="ddlSSCBoard" CssClass="text-width" Width="90%" runat="server" AutoPostBack="true" onmouseover="ddrivetip('Please Select SSC Board.')" onmouseout="hideddrivetip()"></ddlb:OptionGroupSelect>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvSSCBoard" runat="server" ControlToValidate="ddlSSCBoard" Display="None" ErrorMessage="Please Select SSC Board." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

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
                                            SSC Passing Year<br />
                                            दहावी उत्तीर्ण वर्ष

                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:DropDownList ID="ddlSSCPassingYear" Width="90%" runat="server">
                                            </asp:DropDownList>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:CompareValidator ID="cvSSCPassingYear" runat="server" ControlToValidate="ddlSSCPassingYear" Display="None" ErrorMessage="Please Select SSC Passing Year." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                            SSC Seat Number<br />
                                            दहावीचा आसन क्रमांक

                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtSSCSeatNo" MaxLength="15" runat="server" Width="90%" onmouseover="ddrivetip('Please Enter SSC Seat Number.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:RequiredFieldValidator ID="rfvSSCSeatNo" runat="server" Display="None" ControlToValidate="txtSSCSeatNo" ErrorMessage="Please Enter SSC Seat Number."></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                            </div>


                        </td>


                    </tr>
                    <%--<tr>
                        <td align = "center"><b>Subject</b></td>
                        <td align = "center"><b>Marks Obtained</b></td>
                        <td align = "center"><b>Marks OutOf</b></td>
                        <td align = "center"><b>Percentage</b></td>
			        </tr>
			       <tr>
                        <td align="center">SSC Mathematics Marks</td>
                        <td align="center">
                            <asp:TextBox id="txtSSCMathMarksObtained" MaxLength="5" Width="70px" Runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter SSC Mathematics Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvSSCMathMarksObtained" Runat="server" Display="None" ControlToValidate="txtSSCMathMarksObtained" ErrorMessage="Please Enter SSC Mathematics Marks Obtained."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revSSCMathMarksObtained" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtSSCMathMarksObtained" ErrorMessage="SSC Mathematics Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                            <asp:CompareValidator id="cvSSCMathMarksObtained" Runat="server" Display="None" ControlToValidate="txtSSCMathMarksOutOf" ErrorMessage="SSC Mathematics Marks Obtained should be less than or equal to SSC Mathematics Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtSSCMathMarksObtained"></asp:CompareValidator>
                            <asp:CompareValidator id="cvSSCMathMarksObtainedZero" Runat="server" Display="None" ControlToValidate="txtSSCMathMarksObtained" ErrorMessage="SSC Mathematics Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td align="center">
                            <asp:TextBox id="txtSSCMathMarksOutOf" MaxLength="5" Width="70px" Runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter SSC Mathematics Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvSSCMathMarksOutOf" Runat="server" Display="None" ControlToValidate="txtSSCMathMarksOutOf" ErrorMessage="Please Enter SSC Mathematics Marks OutOf."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revSSCMathMarksOutOf" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtSSCMathMarksOutOf" ErrorMessage="SSC Mathematics Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                        </td>
                        <td align="center">
                            <asp:TextBox id="txtSSCMathPercentage" Width="70px" Runat="server" CssClass="txtAlign" ReadOnly = "true" MaxLength = "5"></asp:TextBox>
                        </td>
			        </tr>
			        <tr>
                        <td align="center">SSC Aggregate Marks</td>
                        <td align="center">
                            <asp:TextBox id="txtSSCTotalMarksObtained" MaxLength="5" Width="70px" Runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter SSC Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvSSCTotalMarksObtained" Runat="server" Display="None" ControlToValidate="txtSSCTotalMarksObtained" ErrorMessage="Please Enter SSC Aggregate Marks Obtained."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revSSCTotalMarksObtained" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtSSCTotalMarksObtained" ErrorMessage="SSC Aggregate Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                            <asp:CompareValidator id="cvSSCTotalMarksObtained" Runat="server" Display="None" ControlToValidate="txtSSCTotalMarksOutOf" ErrorMessage="SSC Aggragate Marks Obtained should be less then or equal to SSC Aggragate Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtSSCTotalMarksObtained"></asp:CompareValidator>
                            <asp:CompareValidator id="cvSSCTotalMarksObtainedZero" Runat="server" Display="None" ControlToValidate="txtSSCTotalMarksObtained" ErrorMessage="SSC Aggragate Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td align="center">
                            <asp:TextBox id="txtSSCTotalMarksOutOf" MaxLength="5" Width="70px" Runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter SSC Aggragate Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvSSCTotalMarksOutOf" Runat="server" Display="None" ControlToValidate="txtSSCTotalMarksOutOf" ErrorMessage="Please Enter SSC Aggragate Marks OutOf."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revSSCTotalMarksOutOf" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtSSCTotalMarksOutOf" ErrorMessage="SSC Aggragate Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                        </td>
                        <td align="center">
                            <asp:TextBox id="txtSSCTotalPercentage" Width="70px" Runat="server" CssClass="txtAlign" ReadOnly = "true"></asp:TextBox>
                        </td>
			        </tr>--%>
                    <tr>
                        <th align="left" colspan="4">HSC / Equivalent Details</th>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <div class="row w-100  mx-auto">
                                <div class="col-4 col-lg-3 px-0">
                                    Place of HSC Board
                                    <br />
                                    बारावी परिक्षा मंडळाचे स्थान
                                </div>
                                <div class="col-8 col-lg-9 text-left">
                                    <asp:RadioButton ID="rbnHSCPlaceIndia" runat="server" GroupName="HSCPlace" Text="&nbsp;&nbsp;India" AutoPostBack="true" OnCheckedChanged="HSCPlace_CheckedChanged" onmouseover="ddrivetip('Please Select Place of HSC Board.')" onmouseout="hideddrivetip()" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnHSCPlaceAbroad" runat="server" GroupName="HSCPlace" Text="&nbsp;&nbsp;Abroad" AutoPostBack="true" OnCheckedChanged="HSCPlace_CheckedChanged" onmouseover="ddrivetip('Please Select Place of HSC Board.')" onmouseout="hideddrivetip()" />
                                    <asp:CustomValidator ID="cvHSCPlace" runat="server" ClientValidationFunction="checkHSCPlace" Display="None" ErrorMessage="Please Select Place of HSC Board."></asp:CustomValidator>

                                </div>
                            </div>
                        </td>


                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <div class="row w-100  mx-auto">
                                <div class="col-4 col-lg-3 px-0">
                                    HSC Board<br />
                                    बारावी बोर्ड

                                </div>
                                <div class="col-8 col-lg-9 text-left input-wid">
                                    <ddlb:OptionGroupSelect ID="ddlHSCBoard" runat="server" AutoPostBack="true" OnValueChanged="ddlHSCBoard_SelectedIndexChanged" onmouseover="ddrivetip('Please Select HSC Board.')" onmouseout="hideddrivetip()"></ddlb:OptionGroupSelect>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:CompareValidator ID="cvHSCBoard" runat="server" ControlToValidate="ddlHSCBoard" Display="None" ErrorMessage="Please Select HSC Board." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                </div>
                            </div>

                        </td>


                    </tr>
                    <tr id="trHSCMaharashatra" runat="server">
                        <td colspan="4">
                            <p align="justify">
                                <font color="red"><b>If the concerned Board of HSC has corrected the Marks in rechecking / Verification /  awarded marks for Sports and these marks are added in Total as well as percentage.</b></font>
                            </p>
                        </td>
                    </tr>
                    <tr id="trOtherHSCBoard" runat="server">
                        <td align="right">Other HSC Board</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtOtherHSCBoard" MaxLength="250" runat="server" Width="80%" onmouseover="ddrivetip('Please Enter Other HSC Board.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvOtherHSCBoard" runat="server" Display="None" ControlToValidate="txtOtherHSCBoard" ErrorMessage="Please Enter Other HSC Board."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <div class="row w-100 mx-auto">
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                            HSC Passing Year<br />
                                            बारावी उत्तीर्ण वर्ष

                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:DropDownList ID="ddlHSCPassingYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHSCPassingYear_SelectedIndexChanged">
                                            </asp:DropDownList>                                            
                                            <font color="red"><sup>*</sup></font>
                                            <asp:CompareValidator ID="cvHSCPassingYear" runat="server" ControlToValidate="ddlHSCPassingYear" Display="None" ErrorMessage="Please Select HSC Passing Year." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                            HSC Seat Number<br />
                                            बारावीचा आसन क्रमांक

                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtHSCSeatNo" MaxLength="15" runat="server" Width="90%" onmouseover="ddrivetip('Please Enter HSC Seat Number.')" onmouseout="hideddrivetip()" onKeyUp="HSCValueKeyPress()"></asp:TextBox>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:RequiredFieldValidator ID="rfvHSCSeatNo" runat="server" Display="None" ControlToValidate="txtHSCSeatNo" ErrorMessage="Please Enter HSC Seat Number."></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtHSCSeatNo" ErrorMessage="Please Enter HSC Seat Number." ValidationGroup="hsc"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>

                    </tr>
                    <tr id="trHSCName" runat="server">
                        <td align="right" colspan="4">
                            <div class="row w-100 mx-auto">
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                           Candidate's Mother Name as on HSC Marksheet 
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtMotherName" MaxLength="250" runat="server" Width="80%" onmouseover="ddrivetip('Please Enter Mother Name as on HSC Marksheet.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                            <font color="red"><sup>*</sup></font>
                                            <asp:RequiredFieldValidator ID="rfvHSCName" runat="server" Display="None" ControlToValidate="txtMotherName" ErrorMessage="Please Enter Mother Name as on HSC MarkSheet.." ValidationGroup="HSC"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <%--<div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                            Candidate DOB as on HSC Marksheet

                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:TextBox ID="txtHSCDOB" runat="server" MaxLength="10" Width="50%" onmouseover="ddrivetip('Please Select DOB. It should be in DD/MM/YYYY format.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                            <font color="red"><sup>*</sup></font>(DD/MM/YYYY)
                            <asp:RequiredFieldValidator ID="rfvHSCDOB" runat="server" ErrorMessage="Please Select DOB." ControlToValidate="txtHSCDOB" Display="None" ValidationGroup="HSC"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="cvHSCDOB" runat="server" ControlToValidate="txtHSCDOB" ClientValidationFunction="isDOBValid" Display="None" ErrorMessage="Please Select Proper DOB." ValidationGroup="HSC"></asp:CustomValidator>

                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </td>


                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <div class="row w-100  mx-auto">
                                <div class="col-4 col-lg-3 px-0">
                                    Candidate's Name as on HSC Marksheet
                                    <br />
                                    बारावीच्या गुणपत्रिके प्रमाणे उमेदवाराचे नाव
                                </div>
                                <div class="col-8 col-lg-9 text-left">
                                    <asp:TextBox ID="txtNameAsPerHSCResult" MaxLength="500" runat="server" Width="97%" onmouseover="ddrivetip('Please Enter As Per HSC MarkSheet Name.')" onmouseout="hideddrivetip()" oninput="validateInput(this)"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtNameAsPerHSCResult" ErrorMessage="Please Enter As Per HSC MarkSheet Name."></asp:RequiredFieldValidator>

                                    <asp:TextBox ID="txtIsResultFetched" MaxLength="2" runat="server" Style="display: none;" Text="N"></asp:TextBox>

                                </div>
                            </div>

                        </td>


                    </tr>
                    <tr id="trFetchHSCData" runat="server">
                        <td align="center" colspan="4">
                            <asp:Button ID="btnFetchHSCData" runat="server" Text="Get HSC Data" CssClass="InputButton" OnClick="btnFetchHSCData_Click" BackColor="Red" ValidationGroup="HSC" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="HSC" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4" class="pr-0">


                            <div class="row w-100  mx-auto pr-0">
                                <div class="col-4 col-lg-3 px-0">
                                    HSC Passing Status<br />
                                    बारावी उत्तीर्ण स्थिती
                                </div>
                                <div class="col-8 col-lg-9 pr-0  text-left">
                                    <asp:RadioButton ID="rbnHSCPassed" runat="server" GroupName="HSCPassingStatus" Text="&nbsp;&nbsp;Passed" onmouseover="ddrivetip('Please Select HSC Passing Status.')" onmouseout="hideddrivetip()" />

                                    <asp:RadioButton ID="rbnHSCFailed" runat="server" GroupName="HSCPassingStatus" Text="&nbsp;&nbsp;Failed / Compartment" onmouseover="ddrivetip('Please Select HSC Passing Status.')" onmouseout="hideddrivetip()" />
                                    <asp:CustomValidator ID="cvHSCPassingStatus" runat="server" ClientValidationFunction="checkHSCPassingStatus" Display="None" ErrorMessage="Please Select HSC Passing Status."></asp:CustomValidator>

                                </div>
                            </div>
                        </td>


                    </tr>
                </table>
                <div class="table-responsive">
                    <table class="AppFormTable ">


                        <tr>
                            <td align="center"><b>Subject</b></td>
                            <td align="center"><b>Marks Obtained</b></td>
                            <td align="center"><b>Marks OutOf</b></td>
                            <td align="center"><b>Percentage</b></td>
                        </tr>
                        <tr>
                            <td align="center">HSC Physics Marks
                                <br />
                                बारावी भौतिकशास्त्र गुण</td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCPhysicsMarksObtained" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Physics Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvHSCPhysicsMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksObtained" ErrorMessage="Please Enter HSC Physics Marks Obtained."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revHSCPhysicsMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCPhysicsMarksObtained" ErrorMessage="HSC Physics Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvHSCPhysicsMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksOutOf" ErrorMessage="HSC Physics Marks Obtained should be less then or equal to HSC Physics Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCPhysicsMarksObtained"></asp:CompareValidator>
                                <asp:CompareValidator ID="cvHSCPhysicsMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksObtained" ErrorMessage="HSC Physics Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCPhysicsMarksOutOf" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Physics Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvHSCPhysicsMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksOutOf" ErrorMessage="Please Enter HSC Physics Marks OutOf."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revHSCPhysicsMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCPhysicsMarksOutOf" ErrorMessage="HSC Physics Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCPhysicsPercentage" Width="70px" runat="server" CssClass="txtAlign" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">HSC Chemistry Marks
                                <br />
                                बारावी रसायनशास्त्र गुण</td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCChemistryMarksObtained" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Chemistry Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvHSCChemistryMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksObtained" ErrorMessage="Please Enter HSC Chemistry Marks Obtained."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revHSCChemistryMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCChemistryMarksObtained" ErrorMessage="HSC Chemistry Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvHSCChemistryMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksOutOf" ErrorMessage="HSC Chemistry Marks Obtained should be less then or equal to HSC Chemistry Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCChemistryMarksObtained"></asp:CompareValidator>
                                <asp:CompareValidator ID="cvHSCChemistryMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksObtained" ErrorMessage="HSC Chemistry Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCChemistryMarksOutOf" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Chemistry Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvHSCChemistryMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksOutOf" ErrorMessage="Please Enter HSC Chemistry Marks OutOf."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revHSCChemistryMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCChemistryMarksOutOf" ErrorMessage="HSC Chemistry Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCChemistryPercentage" Width="70px" runat="server" CssClass="txtAlign" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <font color="red">Select Subject Having Maximum Marks</font>
                                <br />
                                HSC
                            <asp:DropDownList ID="ddlHSCSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHSCSubject_SelectedIndexChanged" onmouseover="ddrivetip('Please Select HSC Subject. Maximum of marks obtained in Biology / Mathematics shall be considered for Eligibility.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                                Marks
                                <asp:CompareValidator ID="cvddlhscSubject" runat="server" Display="None" ControlToValidate="ddlHSCSubject" ErrorMessage="Please Select Subject Having Maximum Marks." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCSubjectMarksObtained" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Subject Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvHSCSubjectMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCSubjectMarksObtained" ErrorMessage="Please Enter HSC Subject Marks Obtained."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revHSCSubjectMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCSubjectMarksObtained" ErrorMessage="HSC Subject Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvHSCSubjectMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCSubjectMarksOutOf" ErrorMessage="HSC Subject Marks Obtained should be less then or equal to HSC Subject Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCSubjectMarksObtained"></asp:CompareValidator>
                                <asp:CompareValidator ID="cvHSCSubjectMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCSubjectMarksObtained" ErrorMessage="HSC Subject Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCSubjectMarksOutOf" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Subject Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvHSCSubjectMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCSubjectMarksOutOf" ErrorMessage="Please Enter HSC Subject Marks OutOf."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revHSCSubjectMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCSubjectMarksOutOf" ErrorMessage="HSC Subject Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCSubjectPercentage" Width="70px" runat="server" CssClass="txtAlign" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">HSC English Marks
                                <br />
                                बारावी इंग्रजी गुण</td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCEnglishMarksObtained" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC English Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvHSCEnglishMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksObtained" ErrorMessage="Please Enter HSC English Marks Obtained."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revHSCEnglishMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCEnglishMarksObtained" ErrorMessage="HSC English Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvHSCEnglishMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksOutOf" ErrorMessage="HSC English Marks Obtained should be less then or equal to HSC English Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCEnglishMarksObtained"></asp:CompareValidator>
                                <asp:CompareValidator ID="cvHSCEnglishMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksObtained" ErrorMessage="HSC English Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCEnglishMarksOutOf" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC English Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvHSCEnglishMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksOutOf" ErrorMessage="Please Enter HSC English Marks OutOf."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revHSCEnglishMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCEnglishMarksOutOf" ErrorMessage="HSC English Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCEnglishPercentage" Width="70px" runat="server" CssClass="txtAlign" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblHSCTotalMarks" runat="server">HSC Aggregate Marks <br />बारावी एकत्रित गुण</asp:Label></td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCTotalMarksObtained" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvHSCTotalMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCTotalMarksObtained" ErrorMessage="Please Enter HSC Aggregate Marks Obtained."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revHSCTotalMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCTotalMarksObtained" ErrorMessage="HSC Aggregate Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvHSCTotalMarksObtained" runat="server" Display="None" ControlToValidate="txtHSCTotalMarksOutOf" ErrorMessage="HSC Aggregate Marks Obtained should be less then or equal to HSC Aggregate Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCTotalMarksObtained"></asp:CompareValidator>
                                <asp:CompareValidator ID="cvHSCTotalMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtHSCTotalMarksObtained" ErrorMessage="HSC Aggregate Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCTotalMarksOutOf" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Aggregate Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvHSCTotalMarksOutOf" runat="server" Display="None" ControlToValidate="txtHSCTotalMarksOutOf" ErrorMessage="Please Enter HSC Aggregate Marks OutOf."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revHSCTotalMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCTotalMarksOutOf" ErrorMessage="HSC Aggregate Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtHSCTotalPercentage" Width="70px" runat="server" CssClass="txtAlign" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <table class="AppFormTable ">
                    <tr>
                        <th align="left" colspan="4">Diploma Details</th>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <div class="row w-100  mx-auto">
                                <div class="col-6 col-lg-4 px-0">
                                    Appeared for Diploma in Pharmacy
                                    <br />
                                    औषधनिर्माणशास्त्र पदविका परिक्षा उत्तीर्ण आहात का ?
                                </div>
                                <div class="col-6 col-lg-8 text-left">
                                    <asp:RadioButton ID="rbnAppearedForDiplomaYes" runat="server" GroupName="AppearedForDiploma" Text="&nbsp;&nbsp;Yes" AutoPostBack="true" OnCheckedChanged="AppearedForDiploma_CheckedChanged" onmouseover="ddrivetip('Please Select Appeared For Diploma Status.')" onmouseout="hideddrivetip()" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnAppearedForDiplomaNo" runat="server" GroupName="AppearedForDiploma" Text="&nbsp;&nbsp;No" AutoPostBack="true" OnCheckedChanged="AppearedForDiploma_CheckedChanged" onmouseover="ddrivetip('Please Select Appeared For Diploma Status.')" onmouseout="hideddrivetip()" />
                                    <asp:CustomValidator ID="cvAppearedForDiploma" runat="server" ClientValidationFunction="checkAppearedForDiploma" Display="None" ErrorMessage="Please Select Appeared For Diploma Status."></asp:CustomValidator>

                                </div>
                            </div>

                        </td>


                    </tr>
                    <tr runat="server" id="trDiplomaMarksType">
                        <td align="right">

                            <div class="row w-100  mx-auto">
                                <div class="col-6 col-lg-4 px-0">
                                    Diploma Marks Type<br />
                                    पदविका गुण प्रकार
                                </div>
                                <div class="col-6 col-lg-8 text-left">
                                    <asp:RadioButton ID="rbnPercentage" runat="server" GroupName="DiplomaMarksType" Text="&nbsp;&nbsp;Percentage" AutoPostBack="true" OnCheckedChanged="DiplomaMarksType_CheckedChanged" onmouseover="ddrivetip('Please Select Diploma Marks Type.')" onmouseout="hideddrivetip()" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnCGPA" runat="server" GroupName="DiplomaMarksType" Text="&nbsp;&nbsp;CGPA" AutoPostBack="true" OnCheckedChanged="DiplomaMarksType_CheckedChanged" onmouseover="ddrivetip('Please Select Diploma Marks Type.')" onmouseout="hideddrivetip()" />
                                    <asp:CustomValidator ID="cvDiplomaMarksType" runat="server" ClientValidationFunction="checkDiplomaMarksType" Display="None" ErrorMessage="Please Select Diploma Marks Type."></asp:CustomValidator>

                                </div>
                            </div>
                        </td>

                    </tr>
                </table>

                <table id="tblDiplomaMarks" runat="server" class="AppFormTable">
                    <tr>
                        <td style="width: 25%; border-top-width: 0px;" align="center"><b>Subject</b></td>
                        <td style="width: 25%; border-top-width: 0px;" align="center"><b>Marks Obtained</b></td>
                        <td style="width: 25%; border-top-width: 0px;" align="center"><b>Marks OutOf</b></td>
                        <td style="width: 25%; border-top-width: 0px;" align="center"><b>Percentage</b></td>
                    </tr>
                    <tr>
                        <td align="center">Diploma Aggregate Marks
                            <br />
                            पदविका एकत्रित गुण</td>
                        <td align="center">
                            <asp:TextBox ID="txtDiplomaTotalMarksObtained" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Diploma Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvDiplomaTotalMarksObtained" runat="server" Display="None" ControlToValidate="txtDiplomaTotalMarksObtained" ErrorMessage="Please Enter Diploma Aggregate Marks Obtained."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revDiplomaTotalMarksObtained" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtDiplomaTotalMarksObtained" ErrorMessage="Diploma Aggregate Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cvDiplomaTotalMarksObtained" runat="server" Display="None" ControlToValidate="txtDiplomaTotalMarksOutOf" ErrorMessage="Diploma Aggregate Marks Obtained should be less then or equal to Diploma Aggregate Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtDiplomaTotalMarksObtained"></asp:CompareValidator>
                            <asp:CompareValidator ID="cvDiplomaTotalMarksObtainedZero" runat="server" Display="None" ControlToValidate="txtDiplomaTotalMarksObtained" ErrorMessage="Diploma Aggregate Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtDiplomaTotalMarksOutOf" MaxLength="5" Width="70px" runat="server" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Diploma Aggregate Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvDiplomaTotalMarksOutOf" runat="server" Display="None" ControlToValidate="txtDiplomaTotalMarksOutOf" ErrorMessage="Please Enter Diploma Aggregate Marks OutOf."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revDiplomaTotalMarksOutOf" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtDiplomaTotalMarksOutOf" ErrorMessage="Diploma Aggregate Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtDiplomaTotalPercentage" Width="70px" runat="server" CssClass="txtAlign" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table id="tblDiplomaCGPA" runat="server" class="AppFormTable">
                    <tr runat="server" id="trDiplomaMarksTypeCGPAHead">
                        <td style="width: 25%; border-top-width: 0px;" align="center"><b>Subject</b></td>
                        <td style="width: 25%; border-top-width: 0px;" align="center"><b>CGPA Obtained</b></td>
                        <td style="width: 25%; border-top-width: 0px;" align="center"><b>CGPA OutOf</b></td>
                        <td style="width: 25%; border-top-width: 0px;" align="center"><b>Equivalent Percentage</b></td>
                    </tr>
                    <tr runat="server" id="trDiplomaMarksTypeCGPA">
                        <td align="center">Diploma CGPA</td>
                        <td align="center">
                            <asp:TextBox ID="txtDiplomaCGPAObtained" runat="server" Width="70px" MaxLength="5" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Diploma CGPA Obtained. It should be less than CGPA Outof and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvDiplomaCGPAObtained" runat="server" ErrorMessage="Please Enter Diploma CGPA Obtained." ControlToValidate="txtDiplomaCGPAObtained" Display="None"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvDiplomaCGPAObtained" runat="server" ErrorMessage="Diploma CGPA Obtained should be less than CGPA Outof." ControlToCompare="txtDiplomaCGPAObtained" ControlToValidate="txtDiplomaCGPAOutOf" Display="None" Operator="GreaterThanEqual" Type="Double"></asp:CompareValidator>
                            <asp:CompareValidator ID="cvDiplomaCGPAObtainedZero" runat="server" ErrorMessage="Diploma CGPA Obtained Should be Greater than Zero." ControlToValidate="txtDiplomaCGPAObtained" Display="None" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="revDiplomaCGPAObtained" runat="server" ErrorMessage="Diploma CGPA Obtained should be Numeric." ControlToValidate="txtDiplomaCGPAObtained" Display="None" ValidationExpression="[0-9.]+"></asp:RegularExpressionValidator>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtDiplomaCGPAOutOf" runat="server" Width="70px" MaxLength="5" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Diploma CGPA OutOf. It should be greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvDiplomaCGPAOutOf" runat="server" ErrorMessage="Please Enter Diploma CGPA OutOf." ControlToValidate="txtDiplomaCGPAOutOf" Display='none'></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvDiplomaCGPAOutOfZero" runat="server" ErrorMessage="Diploma CGPA OutOf Should be Greater than Zero." ControlToValidate="txtDiplomaCGPAOutOf" Display="None" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="revDiplomaCGPAOutOf" runat="server" ErrorMessage="Diploma CGPA OutOf should be Numeric." ControlToValidate="txtDiplomaCGPAOutOf" Display="None" ValidationExpression="[0-9.]+"></asp:RegularExpressionValidator>
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtDiplomaCGPAPercentage" runat="server" Width="70px" MaxLength="5" CssClass="txtAlign" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter Diploma CGPA Equivalent Percentage. It should be greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvDiplomaCGPAPercentage" runat="server" ErrorMessage="Please Enter Diploma CGPA Equivalent Percentage." ControlToValidate="txtDiplomaCGPAPercentage" Display="None"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvDiplomaCGPAPercentage" runat="server" ErrorMessage="Diploma CGPA Equivalent Percentage Should be Greater than Zero." ControlToValidate="txtDiplomaCGPAPercentage" Display="None" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="revDiplomaCGPAPercentage" runat="server" ErrorMessage="Diploma CGPA Equivalent Percentage should be Numeric." ControlToValidate="txtDiplomaCGPAPercentage" Display="None" ValidationExpression="[0-9.]+"></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvDiplomaCGPAPercentage" runat="server" ControlToValidate="txtDiplomaCGPAPercentage" ErrorMessage="Please Enter Diploma CGPA Equivalent Percentage Below 100." Display="None" MaximumValue="100" MinimumValue="0.01" Type="Double"></asp:RangeValidator>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        //        sscMathMarksChanged();
        //        sscTotalMarksChanged();
        hscPhysicsMarksChanged();
        hscChemistryMarksChanged();
        hscSubjectMarksChanged();
        hscEnglishMarksChanged();
        hscTotalMarksChanged();
        if (document.getElementById("rightContainer_ContentTable2_tblDiplomaMarks") != null) {
            diplomaTotalMarksChanged();
        }
        if (document.getElementById("rightContainer_ContentTable2_txtHSCDOB") != null) {
            var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtHSCDOB'));
        }
    </script>
</asp:Content>
