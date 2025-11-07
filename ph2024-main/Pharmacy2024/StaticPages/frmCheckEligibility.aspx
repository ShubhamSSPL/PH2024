<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCheckEligibility.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCheckEligibility" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownList_OptGroup" Namespace="DropDownList_OptGroup" TagPrefix="cc2" %>
<%@ Register TagPrefix="ddlb" Assembly="OptionDropDownList" Namespace="OptionDropDownList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>       
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function Left(str, n) {
            if (n <= 0) {
                return "";
            }
            else if (n > String(str).length) {
                return str;
            }
            else {
                return String(str).substring(0, n);
            }
        }

        function numfor(a) {
            // return Left(a, 5);
            return a.toFixed(2);
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
        function checkQualifyingExam(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnQualifyingExamHSC").checked || document.getElementById("rightContainer_ContentTable2_rbnQualifyingExamDiploma").checked || document.getElementById("rightContainer_ContentTable2_rbnQualifyingExamBSc").checked) {
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
        function hscMathMarksChanged() {
            if (document.getElementById("rightContainer_ContentTable2_txtHSCMathMarksObtained").value != "" && document.getElementById("rightContainer_ContentTable2_txtHSCMathMarksOutOf").value != "") {
                document.getElementById("rightContainer_ContentTable2_txtHSCMathPercentage").value = numfor(((parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCMathMarksObtained").value) / parseFloat(document.getElementById("rightContainer_ContentTable2_txtHSCMathMarksOutOf").value)) * 100));
            }
            else {
                document.getElementById("rightContainer_ContentTable2_txtHSCMathPercentage").value = "";
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
        function hscSubjectChanged() {
            var ddlHSCSubject = document.getElementById("rightContainer_ContentTable2_ddlHSCSubject");
            var rfvHSCSubjectMarksObtained = document.getElementById("rightContainer_ContentTable2_rfvHSCSubjectMarksObtained");
            var revHSCSubjectMarksObtained = document.getElementById("rightContainer_ContentTable2_revHSCSubjectMarksObtained");
            var cvHSCSubjectMarksObtained = document.getElementById("rightContainer_ContentTable2_cvHSCSubjectMarksObtained");
            var cvHSCSubjectMarksObtainedZero = document.getElementById("rightContainer_ContentTable2_cvHSCSubjectMarksObtainedZero");
            var rfvHSCSubjectMarksOutOf = document.getElementById("rightContainer_ContentTable2_rfvHSCSubjectMarksOutOf");
            var revHSCSubjectMarksOutOf = document.getElementById("rightContainer_ContentTable2_revHSCSubjectMarksOutOf");

            if (ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text == "Not Applicable") {
                rfvHSCSubjectMarksObtained.errormessage = 'Please Enter HSC Subject Marks Obtained.';
                revHSCSubjectMarksObtained.errormessage = 'HSC Subject Marks Obtained should be Numeric.';
                cvHSCSubjectMarksObtained.errormessage = 'HSC Subject Marks Obtained should be less then or equal to HSC Subject Marks OutOf.';
                cvHSCSubjectMarksObtainedZero.errormessage = 'HSC Subject Marks Obtained should be greater than Zero.';
                rfvHSCSubjectMarksOutOf.errormessage = 'Please Enter HSC Subject Marks OutOf.';
                revHSCSubjectMarksOutOf.errormessage = 'HSC Subject Marks OutOf should be Numeric.';

                rfvHSCSubjectMarksObtained.enabled = false;
                revHSCSubjectMarksObtained.enabled = false;
                cvHSCSubjectMarksObtained.enabled = false;
                cvHSCSubjectMarksObtainedZero.enabled = false;
                rfvHSCSubjectMarksOutOf.enabled = false;
                revHSCSubjectMarksOutOf.enabled = false;

                HSCSubjectMarksObtainedStar.style.display = 'none';
                HSCSubjectMarksOutOfStar.style.display = 'none';

                document.getElementById("rightContainer_ContentTable2_txtHSCSubjectMarksObtained").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCSubjectMarksOutOf").value = "";
                document.getElementById("rightContainer_ContentTable2_txtHSCSubjectPercentage").value = "";
            }
            else if (ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text == "Biology" || ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text == "Bio-Technology") {
                rfvHSCSubjectMarksObtained.errormessage = 'Please Enter HSC ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks Obtained.';
                revHSCSubjectMarksObtained.errormessage = 'HSC ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks Obtained should be Numeric.';
                cvHSCSubjectMarksObtained.errormessage = 'HSC ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks Obtained should be less then or equal to HSC ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks OutOf.';
                cvHSCSubjectMarksObtainedZero.errormessage = 'HSC ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks Obtained should be greater than Zero.';
                rfvHSCSubjectMarksOutOf.errormessage = 'Please Enter HSC ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks OutOf.';
                revHSCSubjectMarksOutOf.errormessage = 'HSC ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks OutOf should be Numeric.';

                rfvHSCSubjectMarksObtained.enabled = true;
                revHSCSubjectMarksObtained.enabled = true;
                cvHSCSubjectMarksObtained.enabled = true;
                cvHSCSubjectMarksObtainedZero.enabled = true;
                rfvHSCSubjectMarksOutOf.enabled = true;
                revHSCSubjectMarksOutOf.enabled = true;

                HSCSubjectMarksObtainedStar.style.display = '';
                HSCSubjectMarksOutOfStar.style.display = '';
            }
            else {
                rfvHSCSubjectMarksObtained.errormessage = 'Please Enter HSC Technical Vocational Subject ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks Obtained.';
                revHSCSubjectMarksObtained.errormessage = 'HSC Technical Vocational Subject ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks Obtained should be Numeric.';
                cvHSCSubjectMarksObtained.errormessage = 'HSC Technical Vocational Subject ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks Obtained should be less then or equal to HSC Technical Vocational Subject ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks OutOf.';
                cvHSCSubjectMarksObtainedZero.errormessage = 'HSC Technical Vocational Subject ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks Obtained should be greater than Zero.';
                rfvHSCSubjectMarksOutOf.errormessage = 'Please Enter HSC Technical Vocational Subject ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks OutOf.';
                revHSCSubjectMarksOutOf.errormessage = 'HSC Technical Vocational Subject ' + ddlHSCSubject.options[ddlHSCSubject.selectedIndex].text + ' Marks OutOf should be Numeric.';

                rfvHSCSubjectMarksObtained.enabled = true;
                revHSCSubjectMarksObtained.enabled = true;
                cvHSCSubjectMarksObtained.enabled = true;
                cvHSCSubjectMarksObtainedZero.enabled = true;
                rfvHSCSubjectMarksOutOf.enabled = true;
                revHSCSubjectMarksOutOf.enabled = true;

                HSCSubjectMarksObtainedStar.style.display = '';
                HSCSubjectMarksOutOfStar.style.display = '';
            }
        }
        function Printit() {
            document.getElementById("top1").style.display = 'none';
            document.getElementById("top2").style.display = 'none';
            document.getElementById("left1").style.display = 'none';
            document.getElementById("footer1").style.display = 'none';
            document.getElementById("rightContainer_ContentBox1_btnBack").style.display = 'none';
            document.getElementById("btnPrint").style.display = 'none';
            document.getElementById("rightContainer1").style.width = '900px';

            window.print();

            document.getElementById("top1").style.display = '';
            document.getElementById("top2").style.display = '';
            document.getElementById("left1").style.display = '';
            document.getElementById("footer1").style.display = '';
            document.getElementById("rightContainer_ContentBox1_btnBack").style.display = '';
            document.getElementById("btnPrint").style.display = '';
            document.getElementById("rightContainer1").style.width = '79.7%';
        }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            if (document.getElementById("rightContainer_ContentTable2_trHSCPhysicsMarks") != null) {
                hscPhysicsMarksChanged();
            }
            if (document.getElementById("rightContainer_ContentTable2_trHSCChemistryMarks") != null) {
                hscChemistryMarksChanged();
            }
            if (document.getElementById("rightContainer_ContentTable2_trHSCMathMarks") != null) {
                hscMathMarksChanged();
            }
            if (document.getElementById("rightContainer_ContentTable2_trHSCSubjectMarks") != null) {
                hscSubjectMarksChanged();
                hscSubjectChanged();
            }
            if (document.getElementById("rightContainer_ContentTable2_trHSCEnglishMarks") != null) {
                hscEnglishMarksChanged();
            }
            if (document.getElementById("rightContainer_ContentTable2_trHSCTotalMarks") != null) {
                hscTotalMarksChanged();
            }
        }
        window.onload = load;
    </script>
    <asp:UpdateProgress runat="server" id="PageUpdateProgress">
        <ProgressTemplate>
            <img src ="../Images/BigProgress.gif" alt = "" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upQualification">
        <ContentTemplate>
            <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Check Your Eligibility">
		        <table class="AppFormTable">
                    <tr>
		                <th align = "left" colspan = "2">Reservation Details</th>
		            </tr>
                    <tr>
                        <td style = "width:30%;" align = "right">Select Candidature Type</td>
                        <td style = "width:70%;">
                            <asp:DropDownList ID="ddlCandidatureType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCandidatureType_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Candidature Type.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color = "red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCandidatureType" runat="server" ControlToValidate="ddlCandidatureType" Display="None" ErrorMessage="Please Select Candidature Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>                                                        
                        </td>
                    </tr>
			        <tr runat = "server" id = "trCategory">
                        <td align = "right">Select Category</td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Category.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color = "red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCategory" runat="server" ControlToValidate="ddlCategory" Display="None" ErrorMessage="Please Select Category." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                            
                        </td>
                    </tr>
                      <tr id="trAppliedForEWS2" runat="server" visible="false">
                        <td align="right">Do you want to Apply for EWS (Economically Weaker Section) Seats ?
                      <%--      <br />
                            आपण ईडब्ल्यूएस (आर्थिक दृष्ट्या दुर्बल घटक ) जागांसाठी अर्ज करू इच्छिता?--%>

                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAppliedForEWS" runat="Server" AutoPostBack="true" onmouseover="ddrivetip('Please Select Apply for EWS Seats Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvews" runat="server" ControlToValidate="ddlAppliedForEWS" Display="None" ErrorMessage="Please Select Apply for EWS Seats Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                            <asp:Label ID="lblAppliedForEWS" runat="server" ForeColor="red" Font-Bold="true" Visible="false">You are Not Eligible for EWS Seats because Your Parents having Annual Income Above 8 Lacs.</asp:Label>
                        </td>
                    </tr>
                    <tr runat = "server" id = "trPH">
                        <td align="right">Person with Disability</td>
                        <td style = "width:70%;"><asp:DropDownList id="ddlPHType" Runat="Server" onmouseover="ddrivetip('Please Select Person with Disability.')" onmouseout="hideddrivetip()"></asp:DropDownList></td>
                    </tr>
                    <tr id="trCourse" runat = "server">
                        <td align="right">Select Course</td>
                        <td style = "width:70%;">
                            <asp:DropDownList id="ddlCourse" Runat="Server" onmouseover="ddrivetip('Please Select Course.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                             <font color = "red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCourse" runat="server" ControlToValidate="ddlCourse" Display="None" ErrorMessage="Please Select Course." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                                                                                
                    </tr>
                    <tr>
		                <th align = "left" colspan = "2">HSC Details</th>
		            </tr>
                    <tr>
                        <td align ="right">Qualifying Exam</td>
                        <td colspan = "3">
                            <asp:RadioButton ID="rbnQualifyingExamHSC" runat="server" GroupName="QualifyingExam" Text="&nbsp;&nbsp;HSC" AutoPostBack = "true" OnCheckedChanged="QualifyingExam_CheckedChanged" onmouseover="ddrivetip('Please Select Qualifying Exam.')" onmouseout="hideddrivetip()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnQualifyingExamDiploma" runat="server" GroupName="QualifyingExam" Text="&nbsp;&nbsp;Diploma" AutoPostBack = "true" OnCheckedChanged="QualifyingExam_CheckedChanged" onmouseover="ddrivetip('Please Select Qualifying Exam.')" onmouseout="hideddrivetip()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnQualifyingExamBSc" runat="server" GroupName="QualifyingExam" Text="&nbsp;&nbsp;B.Sc." AutoPostBack = "true" OnCheckedChanged="QualifyingExam_CheckedChanged" onmouseover="ddrivetip('Please Select Qualifying Exam.')" onmouseout="hideddrivetip()" Visible="false" />
                            <asp:CustomValidator ID="cvQualifyingExam" runat="server" ClientValidationFunction="checkQualifyingExam" Display="None" ErrorMessage="Please Select Qualifying Exam."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id="trHSCBoard" runat="server">
                        <td align="right">HSC Board</td>
                        <td colspan = "3">
                            <%--<cc2:DropDownList_OptGroup ID="ddlHSCBoard" runat="server" Width="95%" AutoPostBack="true" OnSelectedIndexChanged="ddlHSCBoard_SelectedIndexChanged" onmouseover="ddrivetip('Please Select HSC Board.')" onmouseout="hideddrivetip()"></cc2:DropDownList_OptGroup>--%>
                            <ddlb:optiongroupselect id="ddlHSCBoard" runat="server" Width = "95%" AutoPostBack="true" OnValueChanged="ddlHSCBoard_SelectedIndexChanged" onmouseover="ddrivetip('Please Select HSC Board.')" onmouseout="hideddrivetip()"></ddlb:optiongroupselect>
                            <font color = "red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvHSCBoard" runat="server" ControlToValidate="ddlHSCBoard" Display="None" ErrorMessage="Please Select HSC Board." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
			        </tr>
                </table>
                <table class="AppFormTable">
                    <tr id = "trHSCMarksHeader" runat = "server">
                        <td style="width:40%;border-top-width:0px;" align = "center"><b>Subject</b></td>
                        <td style="width:20%;border-top-width:0px;" align = "center"><b>Marks Obtained</b></td>
                        <td style="width:20%;border-top-width:0px;" align = "center"><b>Marks OutOf</b></td>
                        <td style="width:20%;border-top-width:0px;" align = "center"><b>Percentage</b></td>
			        </tr>
                    <tr id = "trHSCPhysicsMarks" runat = "server">
                        <td align="center">Physics</td>
				        <td align="center">
                            <asp:TextBox id="txtHSCPhysicsMarksObtained" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Physics Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvHSCPhysicsMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksObtained" ErrorMessage="Please Enter HSC Physics Marks Obtained."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCPhysicsMarksObtained" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCPhysicsMarksObtained" ErrorMessage="HSC Physics Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                            <asp:CompareValidator id="cvHSCPhysicsMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksOutOf" ErrorMessage="HSC Physics Marks Obtained should be less then or equal to HSC Physics Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCPhysicsMarksObtained"></asp:CompareValidator>
                            <asp:CompareValidator id="cvHSCPhysicsMarksObtainedZero" Runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksObtained" ErrorMessage="HSC Physics Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                        </td>
				        <td align="center">
                            <asp:TextBox id="txtHSCPhysicsMarksOutOf" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Physics Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvHSCPhysicsMarksOutOf" Runat="server" Display="None" ControlToValidate="txtHSCPhysicsMarksOutOf" ErrorMessage="Please Enter HSC Physics Marks OutOf."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCPhysicsMarksOutOf" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCPhysicsMarksOutOf" ErrorMessage="HSC Physics Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                        </td>
				        <td align="center">
                            <asp:TextBox id="txtHSCPhysicsPercentage" Width="70px" Runat="server" ReadOnly = "true"></asp:TextBox>
                        </td>
			        </tr>
                   <%-- <tr id = "trHSCMathMarks" runat = "server">
                        <td align="center">Mathematics</td>
				        <td align="center">
                            <asp:TextBox id="txtHSCMathMarksObtained" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Mathematics Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvHSCMathMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCMathMarksObtained" ErrorMessage="Please Enter HSC Mathematics Marks Obtained."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCMathMarksObtained" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCMathMarksObtained" ErrorMessage="HSC Mathematics Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                            <asp:CompareValidator id="cvHSCMathMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCMathMarksOutOf" ErrorMessage="HSC Mathematics Marks Obtained should be less then or equal to HSC Mathematics Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCMathMarksObtained"></asp:CompareValidator>
                            <asp:CompareValidator id="cvHSCMathMarksObtainedZero" Runat="server" Display="None" ControlToValidate="txtHSCMathMarksObtained" ErrorMessage="HSC Mathematics Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                        </td>
				        <td align="center">
                            <asp:TextBox id="txtHSCMathMarksOutOf" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Mathematics Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvHSCMathMarksOutOf" Runat="server" Display="None" ControlToValidate="txtHSCMathMarksOutOf" ErrorMessage="Please Enter HSC Mathematics Marks OutOf."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCMathMarksOutOf" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCMathMarksOutOf" ErrorMessage="HSC Mathematics Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                        </td>
				        <td align="center">
                            <asp:TextBox id="txtHSCMathPercentage" Width="70px" Runat="server" ReadOnly = "true"></asp:TextBox>
                        </td>
			        </tr>--%>
                    <tr id = "trHSCChemistryMarks" runat = "server">
                        <td align="center">Chemistry</td>
				        <td align="center">
                            <asp:TextBox id="txtHSCChemistryMarksObtained" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Chemistry Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvHSCChemistryMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksObtained" ErrorMessage="Please Enter HSC Chemistry Marks Obtained."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCChemistryMarksObtained" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCChemistryMarksObtained" ErrorMessage="HSC Chemistry Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                            <asp:CompareValidator id="cvHSCChemistryMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksOutOf" ErrorMessage="HSC Chemistry Marks Obtained should be less then or equal to HSC Chemistry Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCChemistryMarksObtained"></asp:CompareValidator>
                            <asp:CompareValidator id="cvHSCChemistryMarksObtainedZero" Runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksObtained" ErrorMessage="HSC Chemistry Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                        </td>
				        <td align="center">
                            <asp:TextBox id="txtHSCChemistryMarksOutOf" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Chemistry Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvHSCChemistryMarksOutOf" Runat="server" Display="None" ControlToValidate="txtHSCChemistryMarksOutOf" ErrorMessage="Please Enter HSC Chemistry Marks OutOf."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCChemistryMarksOutOf" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCChemistryMarksOutOf" ErrorMessage="HSC Chemistry Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                        </td>
				        <td align="center">
                            <asp:TextBox id="txtHSCChemistryPercentage" Width="70px" Runat="server" ReadOnly = "true"></asp:TextBox>
                        </td>
			        </tr>
                    <tr id = "trHSCSubjectMarks" runat = "server">
                        <td align="center">
                            <asp:DropDownList ID="ddlHSCSubject" runat="server" Width = "99%" onmouseover="ddrivetip('Please Select HSC Subject. Maximum of marks obtained in Biology / Bio-Technology / Technical Vocational Subject shall be considered for Eligibility.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <br />
                            <font color = "red">Please Select HSC Subject in which you got Maximum Percentage of Marks</font>
                        </td>
				        <td align="center" valign="top">
                            <asp:TextBox id="txtHSCSubjectMarksObtained" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Subject Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <span id = "HSCSubjectMarksObtainedStar"><font color = "red"><sup>*</sup></font></span>
                            <span id = "HSCSubjectMarksObtainedStarWhite"><font color = "white"><sup>*</sup></font></span>
                            <asp:RequiredFieldValidator id="rfvHSCSubjectMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCSubjectMarksObtained" ErrorMessage="Please Enter HSC Subject Marks Obtained."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCSubjectMarksObtained" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCSubjectMarksObtained" ErrorMessage="HSC Subject Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                            <asp:CompareValidator id="cvHSCSubjectMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCSubjectMarksOutOf" ErrorMessage="HSC Subject Marks Obtained should be less then or equal to HSC Subject Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCSubjectMarksObtained"></asp:CompareValidator>
                            <asp:CompareValidator id="cvHSCSubjectMarksObtainedZero" Runat="server" Display="None" ControlToValidate="txtHSCSubjectMarksObtained" ErrorMessage="HSC Subject Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                        </td>
				        <td align="center" valign="top">
                            <asp:TextBox id="txtHSCSubjectMarksOutOf" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Subject Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <span id = "HSCSubjectMarksOutOfStar"><font color = "red"><sup>*</sup></font></span>
                            <span id = "HSCSubjectMarksOutOfStarWhite"><font color = "white"><sup>*</sup></font></span>
                            <asp:RequiredFieldValidator id="rfvHSCSubjectMarksOutOf" Runat="server" Display="None" ControlToValidate="txtHSCSubjectMarksOutOf" ErrorMessage="Please Enter HSC Subject Marks OutOf."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCSubjectMarksOutOf" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCSubjectMarksOutOf" ErrorMessage="HSC Subject Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                        </td>
				        <td align="center" valign="top">
                            <asp:TextBox id="txtHSCSubjectPercentage" Width="70px" Runat="server" ReadOnly = "true"></asp:TextBox>
                        </td>
			        </tr>
			        <tr id = "trHSCEnglishMarks" runat = "server">
                        <td align="center">English</td>
				        <td align="center">
                            <asp:TextBox id="txtHSCEnglishMarksObtained" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC English Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvHSCEnglishMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksObtained" ErrorMessage="Please Enter HSC English Marks Obtained."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCEnglishMarksObtained" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCEnglishMarksObtained" ErrorMessage="HSC English Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                            <asp:CompareValidator id="cvHSCEnglishMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksOutOf" ErrorMessage="HSC English Marks Obtained should be less then or equal to HSC English Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCEnglishMarksObtained"></asp:CompareValidator>
                            <asp:CompareValidator id="cvHSCEnglishMarksObtainedZero" Runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksObtained" ErrorMessage="HSC English Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                        </td>
				        <td align="center">
                            <asp:TextBox id="txtHSCEnglishMarksOutOf" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC English Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvHSCEnglishMarksOutOf" Runat="server" Display="None" ControlToValidate="txtHSCEnglishMarksOutOf" ErrorMessage="Please Enter HSC English Marks OutOf."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCEnglishMarksOutOf" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCEnglishMarksOutOf" ErrorMessage="HSC English Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                        </td>
				        <td align="center">
                            <asp:TextBox id="txtHSCEnglishPercentage" Width="70px" Runat="server" ReadOnly = "true"></asp:TextBox>
                        </td>
			        </tr>
			        <tr id = "trHSCTotalMarks" runat = "server">
                        <td align="center">Aggregate</td>
				        <td align="center">
                            <asp:TextBox id="txtHSCTotalMarksObtained" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Aggregate Marks Obtained. It should be less than Marks OutOf and greater than Zero.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvHSCTotalMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCTotalMarksObtained" ErrorMessage="Please Enter HSC Aggregate Marks Obtained."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCTotalMarksObtained" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCTotalMarksObtained" ErrorMessage="HSC Aggregate Marks Obtained should be Numeric."></asp:RegularExpressionValidator>
                            <asp:CompareValidator id="cvHSCTotalMarksObtained" Runat="server" Display="None" ControlToValidate="txtHSCTotalMarksOutOf" ErrorMessage="HSC Aggregate Marks Obtained should be less then or equal to HSC Aggregate Marks OutOf." Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtHSCTotalMarksObtained"></asp:CompareValidator>
                            <asp:CompareValidator id="cvHSCTotalMarksObtainedZero" Runat="server" Display="None" ControlToValidate="txtHSCTotalMarksObtained" ErrorMessage="HSC Aggregate Marks Obtained should be greater than Zero." Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                        </td>
				        <td align="center">
                            <asp:TextBox id="txtHSCTotalMarksOutOf" MaxLength="5" Width="50px" Runat="server" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter HSC Aggregate Marks OutOf.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator id="rfvHSCTotalMarksOutOf" Runat="server" Display="None" ControlToValidate="txtHSCTotalMarksOutOf" ErrorMessage="Please Enter HSC Aggregate Marks OutOf."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revHSCTotalMarksOutOf" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtHSCTotalMarksOutOf" ErrorMessage="HSC Aggregate Marks OutOf should be Numeric."></asp:RegularExpressionValidator>
                        </td>
				        <td align="center">
                            <asp:TextBox id="txtHSCTotalPercentage" Width="70px" Runat="server" ReadOnly = "true"></asp:TextBox>
                        </td>
			        </tr>
		        </table>
                <br />
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnProceed" runat="server" Text="Check Eligibility" CssClass="InputButton" OnClick="btnProceed_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />                            
                        </td>
                    </tr>
                </table>
            </cc1:ContentBox>
            <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Your Eligibility Status">
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td><asp:Button ID="btnBack" runat="server" Text="<<< Back" CssClass="InputButton" OnClick="btnBack_Click" /></td>
                    </tr>
                </table>
                <br /><br />
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 40%" align="right">Candidature Type</td>
                        <td style="width: 60%"><asp:Label ID="lblCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Category</td>
                        <td><asp:Label ID="lblCategory" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                     <tr>
                        <td align="right">EWS (Economically Weaker Section)</td>
                        <td><asp:Label ID="lblEws" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Person with Disability</td>
                        <td><asp:Label ID="lblPHType" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Course</td>
                        <td><asp:Label ID="lblCourse" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Qualifying Exam</td>
                        <td><asp:Label ID="lblQualifyingExam" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr id="trHSCBoardDisplay" runat="server">
                        <td align="right">HSC Board</td>
                        <td><asp:Label ID="lblHSCBoard" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                </table>
                <table class="AppFormTable">
                    <tr>
                        <td style="width:40%;border-top-width:0px;" align = "center"><b>Subject</b></td>
                        <td style="width:20%;border-top-width:0px;" align = "center"><b>Marks Obtained</b></td>
                        <td style="width:20%;border-top-width:0px;" align = "center"><b>Marks OutOf</b></td>
                        <td style="width:20%;border-top-width:0px;" align = "center"><b>Percentage</b></td>
			        </tr>
                    <tr id="trHSCPhysicsMarksDisplay" runat="server">
                        <td align="center">Physics</td>
                        <td align="center"><asp:Label id="lblHSCPhysicsMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCPhysicsMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCPhysicsPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                   <%-- <tr id="trHSCMathMarksDisplay" runat="server">
                        <td align="center">Mathematics</td>
                        <td align="center"><asp:Label id="lblHSCMathMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCMathMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCMathPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>--%>
                    <tr id="trHSCChemistryMarksDisplay" runat="server">
                        <td align="center">Chemistry</td>
                        <td align="center"><asp:Label id="lblHSCChemistryMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCChemistryMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCChemistryPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr id="trHSCSubjectMarksDisplay" runat="server">
                        <td align="center"><asp:Label id="lblHSCSubject" runat="server"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCSubjectMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCSubjectMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCSubjectPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr id="trHSCEnglishMarksDisplay" runat="server">
                        <td align="center">English</td>
                        <td align="center"><asp:Label id="lblHSCEnglishMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCEnglishMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCEnglishPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center">Aggregate</td>
                        <td align="center"><asp:Label id="lblHSCTotalMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCTotalMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="center"><asp:Label id="lblHSCTotalPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center" colspan = "4"><font size = "2"><b>Eligibility Status</b></font></td>
                    </tr>
                    <tr>
                        <td align = "center" colspan = "4"><asp:Label ID="lblEligibilityStatus" runat="server" Font-Bold = "true" Font-Size = "Small"></asp:Label></td>
                    </tr>
                </table>
                <br />
               <%-- <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td align="center"><input id="btnPrint" type="button" value="  Print  " class="InputButton" onclick="Printit()" /></td>
                    </tr>
                </table>--%>
                <br />
            </cc1:ContentBox>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <script language="javascript" type = "text/javascript">
        if (document.getElementById("rightContainer_ContentTable2_trHSCPhysicsMarks") != null) {
            hscPhysicsMarksChanged();
        }
        if (document.getElementById("rightContainer_ContentTable2_trHSCChemistryMarks") != null) {
            hscChemistryMarksChanged();
        }
        if (document.getElementById("rightContainer_ContentTable2_trHSCMathMarks") != null) {
            hscMathMarksChanged();
        }
        if (document.getElementById("rightContainer_ContentTable2_trHSCSubjectMarks") != null) {
            hscSubjectMarksChanged();
            hscSubjectChanged();
        }
        if (document.getElementById("rightContainer_ContentTable2_trHSCEnglishMarks") != null) {
            hscEnglishMarksChanged();
        }
        if (document.getElementById("rightContainer_ContentTable2_trHSCTotalMarks") != null) {
            hscTotalMarksChanged();
        }
    </script>
</asp:Content>
