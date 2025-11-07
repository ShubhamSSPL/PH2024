<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCheckAllotmentStatusCAPRound4.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCheckAllotmentStatusCAPRound4" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script src="../Scripts/epoch_classes.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type = "text/javascript">
        function isDateValid(sender, args) 
        {
            var dateStr = document.getElementById("rightContainer_cbCheckResult_txtDOB").value;
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
        function Printit() {
            document.getElementById("topdiv").style.display = 'none';
            document.getElementById("left1").style.display = 'none';
            document.getElementById("footer1").style.display = 'none';
            document.getElementById("btnPrint").style.display = 'none';
            document.getElementById("rightContainer1").style.width = '900px';

            window.print();

            document.getElementById("topdiv").style.display = '';
            document.getElementById("left1").style.display = '';
            document.getElementById("footer1").style.display = '';
            document.getElementById("btnPrint").style.display = '';
            document.getElementById("rightContainer1").style.width = '79.7%';
        }
    </script>
    <cc1:ContentBox ID="cbCheckResult" runat="server" HeaderText="Provisional Allotment Status of Additional Round for Government/Govt. Aided Institutes">
        <table class="AppFormTable" width = "40%" align="center" id = "tblResult" runat = "server">
            <tr>
                <th colspan="2">Enter Your Application ID and Date of Birth to View Your Provisional Allotment Status of Additional Round for Government/Govt. Aided Institutes</th>
            </tr>
            <tr>
                <td style="width:50%" align="right">Enter Application ID</td>
                <td style="width:50%">
                    <asp:TextBox ID="txtApplicationID" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ErrorMessage="Please Enter Your Application ID." ControlToValidate="txtApplicationID" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Enter Date Of Birth</td>
                <td>
                    <asp:TextBox  ID="txtDOB" runat="server" Width="100px" MaxLength = "10"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font> (DD/MM/YYYY)
                    <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB" Display="None" ErrorMessage="Please Enter Your Date of Birth."></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper Date of Birth."></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <center>
                        <asp:Button ID="btnProceed" runat="server" Text="SUBMIT" CssClass="InputButton" OnClick="btnProceed_Click"  />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    </center>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbDisplayResult" runat="server" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
                <td style="width:10%;border-right-width:0px;" align="center"><img src="../Images/dtelogo.jpg" alt = "" /></td>
                <td style="width:90%;border-left-width:0px;" align="center">
                    <b>
                        <font size="4">S</font><font size="2">TATE</font> <font size="4">C</font><font size="2">OMMON</font> <font size="4">E</font><font size="2">NTRANCE</font> <font size="4">T</font><font size="2">EST</font> <font size="4">C</font><font size="2">ELL, <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font></font>
                        <br />
                        <font size = "1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
                        <br /><br />
                        Provisional Allotment Letter for Admission to First Year of Under Graduate Technical Courses in Engineering and Technology for the Academic Year <%= AdmissionYear %>
                    </b>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2"><font size = "2">Application ID : <asp:Label id="lblApplicationID" runat="server" Font-Bold="True"></asp:Label></font></td>
            </tr>
        </table>   
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width:0px;" align="left" colspan="4">Personal Details</th>
            </tr>
            <tr>
                <td align="right">Candidate's Name</td>
                <td colspan = "3"><asp:Label id="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td> 
            </tr>
            <tr>
                <td style="width: 25%" align="right">Gender</td>
                <td style="width: 25%"><asp:Label id="lblGender" runat="server" Font-Bold = "true"></asp:Label></td> 
                <td style="width: 25%" align="right">DOB (DD/MM/YYYY)</td>
                <td style="width: 25%"><asp:Label id="lblDOB" runat="server" Font-Bold = "true"></asp:Label></td> 
            </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td><asp:Label id="lblCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td> 
                <td align="right">Home University</td>
                <td><asp:Label id="lblHomeUniversity" runat="server" Font-Bold = "true"></asp:Label></td> 
            </tr>
            <tr>
                <td align="right">Category</td>
                <td><asp:Label id="lblOriginalCategory" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Category for Admission</td>
                <td><asp:Label id="lblCategoryForAdmission" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Person with Disability</td>
                <td><asp:Label id="lblPHType" runat="server" Font-Bold = "true"></asp:Label></td> 
                <td align="right">Defence Type</td>
                <td><asp:Label id="lblDefenceType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Linguistic Minority</td>
                <td><asp:Label ID="lblLinguisticMinority" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Religious Minority</td>
                <td><asp:Label ID="lblReligiousMinority" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <th align="left" colspan="4">Provisional Allotment Details</th>
            </tr>
            <tr id = "trInstituteAllotted" runat = "server">
                <td align="right">Institute Allotted</td>
                <td colspan = "3"><asp:Label id="lblInstituteAllotted" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trCourseAllotted" runat = "server">
                <td align="right">Course Allotted</td>
                <td colspan = "3"><asp:Label id="lblCourseAllotted" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trChoiceCodeAllotted" runat = "server">
                <td align="right">Choice Code Allotted</td>
                <td colspan = "3"><asp:Label id="lblChoiceCodeAllotted" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trSeatTypeAllotted" runat = "server">
                <td align="right">Seat Type Allotted</td>
                <td colspan = "3"><asp:Label id="lblSeatTypeAllotted" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trPreferenceNoAllotted" runat = "server">
                <td align="right">Preference No. Allotted</td>
                <td colspan = "3"><asp:Label id="lblPreferenceNoAllotted" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trCAPRoundAllotted" runat = "server">
                <td align="right">CAP Round Allotted</td>
                <td colspan = "3"><asp:Label id="lblCAPRoundAllotted" runat="server" Font-Bold = "true">Additional Round for Government/Govt. Aided Institutes</asp:Label></td>
            </tr>
            <tr id = "trMeritNo" runat = "server">
                <td align="right">Merit No.</td>
                <td colspan = "3"><asp:Label id="lblMeritNo" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trMeritMarks" runat = "server">
                <td align="right">Merit Percentile</td>
                <td colspan = "3"><asp:Label id="lblMeritScore" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trChoiceCodeStatusDetails" runat = "server">
                <td colspan = "4"><asp:Label id="lblChoiceCodeStatusDetails" runat="server"></asp:Label></td>
            </tr>
            <tr id = "trNotAllotted" runat = "server">
                <td align="right">Allotment Status</td>
                <td colspan = "3"><p align = "justify"><asp:Label id="lblNotAllotted" runat="server" Font-Bold = "true"></asp:Label></p></td>
            </tr>
            <tr id = "trCVC" runat = "server" visible="false">
                <td colspan = "4">
                    $ -- Candidates should submit Caste Validity Certificate/ Tribe Validity Certificate before 10 August 2019 at Application Receipt Centers to claim Category benefit for admission, otherwise your admission shall stand cancelled.
                </td>
            </tr>
            <tr id = "trNCL" runat = "server" visible="false">
                <td colspan = "4">
                    # -- Candidates should submit Non Creamy Layer Certificate valid up to 31/03/2019, at Application Receipt Centers to claim Category benefit for admission, otherwise your admission shall stand cancelled.
                </td>
            </tr>
            <tr id = "trInstructions" runat = "server">
                <td colspan = "4">
                    <b>Instructions :</b>
                    <ol class="list-text">
                        <li><p align = "justify">If seat is allotted in this round, the candidate shall report to allotted institute along with original documents and fees for confirmation of admission.</p></li>
                        <li><p align = "justify">I am aware that if I get allotment/betterment in this round then my earlier admission in Govt, Aided or University Department (if any) shall be cancelled automatically and it will be mandatory for me to report to the allotted institute in this round.</p></li>
                        <li><p align = "justify">I also know that vacancy created due to cancellation of admission (if any) shall be offered to other eligible candidate as per the inter se merit, therefore I shall not request for restoration of the earlier cancelled admission.</p></li>
                        <li><p align = "justify">The rules of refund of fees due to cancellation shall be applicable, if candidate get allotment in this round.</p></li>
                        <li><p align = "justify">If candidate fails to report for the allotted Institution in scheduled time, it will be treated as he/she has rejected the allotted seat.</p></li>
                    </ol>
                </td>
            </tr>
            <tr>
                <td colspan="4"><font color = "red"><b>Published On : 07/08/2019</b></font></td>
            </tr>
        </table>
        <br />
        <div id = "divPrint" runat = "server" width = "100%">
            <center>
                <input id="btnPrint" type="button" value="  Print  " class="InputButton" onclick="Printit()" />
            </center>
        </div>
        <br />
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        var dp_cal;
        if (document.getElementById('rightContainer_cbCheckResult_txtDOB') != null) 
        {
            window.onload = function () 
            {
                dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_cbCheckResult_txtDOB'));
            };
        }
    </script>
</asp:Content>
