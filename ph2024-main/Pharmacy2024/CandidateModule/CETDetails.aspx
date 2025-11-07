<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="CETDetails.aspx.cs" Inherits="Pharmacy2024.CandidateModule.CETDetails" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
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
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtCETDOB").value;
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
    <cc1:ContentBox ID="ContentTable2" runat="server">
        <table id="tblCETDetailsold" runat="server" class="AppFormTable">
            <tr>
                <th colspan="4" style="border-top-width: 0px;" align="left"><%= MHTCETName %></th>
            </tr>
            <tr>
                <td colspan="2" style="width: 50%" align="right">Candidate Name As Per CETaa</td>
                <td colspan="2" style="width: 50%">
                    <asp:Label ID="lblCandidateNameold" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="width: 50%" align="right">CET Application Form No</td>
                <td colspan="2" style="width: 50%">
                    <asp:Label ID="lblCETApplicationFormNoold" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" style="width: 50%" align="right">CET Roll No</td>
                <td colspan="2" style="width: 50%">
                    <asp:Label ID="lblCETRollNoold" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCET1old" runat="server">
                <td style="width: 50%" colspan="2" align="right">Physics </td>
                <td style="width: 50%" colspan="2">
                    <asp:Label ID="lblCETPhysicsMarksold" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCET2old" runat="server">
                <td align="right" colspan="2">Chemistry </td>
                <td colspan="2">
                    <asp:Label ID="lblCETChemistryMarksold" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCET3old" runat="server">
                <td align="right" colspan="2">Mathematics </td>
                <td colspan="2">
                    <asp:Label ID="lblCETMathMarksold" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCET4old" runat="server">
                <td align="right" colspan="2">Total PCM </td>
                <td colspan="2">
                    <asp:Label ID="lblCETPCMTotalMarksold" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCET5old" runat="server">
                <td style="width: 25%" align="right">Message</td>
                <td style="width: 75%" colspan="3">
                    <asp:Label ID="lblNoCETold" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblCETDetails" runat="server" class="AppFormTable">
            <tr>
                <th colspan="4" style="border-top-width: 0px;" align="left"><%= MHTCETName %> Details</th>
            </tr>
            <tr>
                <td colspan="2" style="width: 50%" align="right">Candidate Name As Per CET</td>
                <td colspan="2" style="width: 50%">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCET1" runat="server">
                <td style="width: 50%" colspan="2" align="right">Physics </td>
                <td style="width: 50%" colspan="2">
                    <asp:Label ID="lblCETPhysicsMarks" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCET2" runat="server">
                <td align="right" colspan="2">Chemistry </td>
                <td colspan="2">
                    <asp:Label ID="lblCETChemistryMarks" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCET3" runat="server">
                <td align="right" colspan="2">Mathematics </td>
                <td colspan="2">
                    <asp:Label ID="lblCETMathMarks" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCET4" runat="server">
                <td align="right" colspan="2">Total PCM </td>
                <td colspan="2">
                    <asp:Label ID="lblCETPCMTotalMarks" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCET5" runat="server">
                <td style="width: 25%" align="right">Message</td>
                <td style="width: 75%" colspan="3">
                    <asp:Label ID="lblNoCET" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblNewCETDetails" runat="server">
            <tr id="trCETApplicationFormNo" runat="server">
                <td align="right"><%=MHTCETName %> Application Number</td>
                <td>
                    <asp:TextBox ID="txtCETApplicationFormNo" MaxLength="9" runat="server" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color="red">*</font>
                    <asp:RequiredFieldValidator ID="rfvCETApplicationFormNo" runat="server" Display="None" ControlToValidate="txtCETApplicationFormNo"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCETApplicationFormNo" runat="server" Display="None" ValidationExpression="\d{9}" ControlToValidate="txtCETApplicationFormNo"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr id="trCETRollNo" runat="server">
                <td align="right"><%=MHTCETName %> Roll Number</td>
                <td>
                    <asp:TextBox ID="txtCETRollNo" runat="server" MaxLength="10" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCETRollNo" runat="server" Display="None" ControlToValidate="txtCETRollNo"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCETRollNo" runat="server" Display="None" ValidationExpression="\d{10}" ControlToValidate="txtCETRollNo"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr id="trCETName" runat="server">
                        <td align="right">Candidate DOB as on CET Marksheet </td>
                        <td>
                            <asp:TextBox ID="txtCETDOB" runat="server" MaxLength="10"  onmouseover="ddrivetip('Please Select DOB. It should be in DD/MM/YYYY format.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>(DD/MM/YYYY)
                            <asp:RequiredFieldValidator ID="rfvCETDOB" runat="server"  ControlToValidate="txtCETDOB"  Display="None"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvCERDOB" runat="server" ControlToValidate="txtCETDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper DOB." ></asp:CustomValidator>
                        </td>
                    </tr>
            <tr id="trCheckCETDetails" runat="server">
                <td colspan="2" align="center">
                    <asp:Button ID="btnCheckCETDetails" runat="server" Text="Check CET Details" CssClass="InputButton" BackColor="Red" OnClick="btnCheckCETDetails_Click" /></td>
            </tr>
        </table>

        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" Visible="false" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
       
        if (document.getElementById("rightContainer_ContentTable2_txtCETDOB") != null) {
            var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtCETDOB'));
        }
    </script>
</asp:Content>
