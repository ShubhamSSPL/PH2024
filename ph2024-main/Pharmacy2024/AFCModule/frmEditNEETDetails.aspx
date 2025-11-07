<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditNEETDetails.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEditNeetDetails_Fetch" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
      <style>
     #rightContainer_contentDocumentConferamtion {
            position: fixed !important;
            top: 25% !important;
            width:70%;
            z-index:2000 !important ;
        }

        @media only screen and (max-width: 768px) {
            #rightContainer_contentDocumentConferamtion {
                position: fixed !important;
                top: 20% !important;
                width:90%;                
            }
        }
       
    </style>
     <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);

        function ShowConfirmationBox() {
            document.getElementById('<%=contentDocumentConferamtion.ClientID %>').Show('', true, 'Fullscreen = yes');
        }

        function checkAppearedForNEET(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnAppearedForNEETYes").checked || document.getElementById("rightContainer_ContentTable2_rbnAppearedForNEETNo").checked) {
            }
            else {
                args.IsValid = false;
            }
        }

        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }

        function isDOBValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtNEETDOB").value;
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
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {

            if (document.getElementById("rightContainer_ContentTable2_txtNEETDOB") != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtNEETDOB'));
            }
        }

        window.onload = load;
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
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="NEET 2024 Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upNEET">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 50%" align="right">Have you Appeared for NEET <%=CurrentYear %></td>
                        <td style="width: 50%">
                            <asp:RadioButton ID="rbnAppearedForNEETYes" runat="server" GroupName="AppearedForNEET" Text="&nbsp;&nbsp;Yes" AutoPostBack="true" OnCheckedChanged="AppearedForNEET_CheckedChanged" onmouseover="ddrivetip('Please Select Appeared Status for NEET 2024.')" onmouseout="hideddrivetip()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnAppearedForNEETNo" runat="server" GroupName="AppearedForNEET" Text="&nbsp;&nbsp;No" AutoPostBack="true" OnCheckedChanged="AppearedForNEET_CheckedChanged" onmouseover="ddrivetip('Please Select Appeared Status for NEET 2024.')" onmouseout="hideddrivetip()" />
                            <asp:CustomValidator ID="cvAppearedForNEET" runat="server" ClientValidationFunction="checkAppearedForNEET" Display="None" ErrorMessage="Please Select Appeared Status for NEET 2024."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id="trNEETRollNo" runat="server">
                        <td align="right">Roll No</td>
                        <td>
                            <asp:TextBox ID="txtNEETRollNo" runat="server" MaxLength="10" Width="100px" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter NEET 2024 Roll No. It should be numeric and of 10 digits.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvNEETRollNo" runat="server" Display="None" ControlToValidate="txtNEETRollNo" ErrorMessage="Please Enter NEET 2024 Roll No."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETRollNo" runat="server" ErrorMessage="NEET 2024 Roll No. should be numeric and of 10 digits." ControlToValidate="txtNEETRollNo" Display="None" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cvNEETRollNo" runat="server" ErrorMessage="NEET 2024 Roll No. should not be zero." ControlToValidate="txtNEETRollNo" Display="None" Operator="NotEqual" ValueToCompare="0" Type="Integer"></asp:CompareValidator>
                        </td>
                    </tr>
                     <tr id = "trNEETDOB" runat = "server">
                        <td align="right">Candidate's DOB as on NEET Score Card </td>
                        <td>
                            <asp:TextBox ID="txtNEETDOB" runat="server" MaxLength="10" Width="20%" ></asp:TextBox>
                            <font color="red"><sup>*</sup></font>(DD/MM/YYYY)
                            <asp:RequiredFieldValidator ID="rfvNEETDOB" runat="server" ErrorMessage="Please Select DOB." ControlToValidate="txtNEETDOB" Display="None" ValidationGroup="NEET" ></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvNEETDOB" runat="server" ControlToValidate="txtNEETDOB" ClientValidationFunction="isDOBValid" Display="None" ErrorMessage="Please Select Proper DOB." ValidationGroup="NEET" ></asp:CustomValidator>
                        </td>
                    </tr>
                    
                    <tr id="trFetchNEETData" runat="server">
                        <td align="center" colspan="4">
                            <asp:Button ID="btnFetcNEETData" runat="server" Text="Get NEET Score Data" CssClass="InputButton" OnClick="btnFetchNEETData_Click" BackColor="Red" ValidationGroup="NEET"  />
                             <asp:ValidationSummary ID="ValidationSummary2" Runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="NEET"/>
                        </td>
                    </tr>    
	            </table>
                <table id="tblNEETDetail" runat="server" visible="false" class="AppFormTable">
                    <tr id = "trNEETScore0" runat = "server">
                        <td align = "right">Candidate Name As Per NEET</td>
                        <td><asp:Label ID = "lblCandidateNameasPerNEET" runat = "server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr id="trNEETScore1" runat="server">
                        <td align="right">Physics</td>
                        <td>
                            <asp:TextBox ID="txtNEETPhysicsScore" MaxLength="10" Width="100px" Enabled="false" runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Physics Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvNEETPhysicsScore" runat="server" Display="None" ControlToValidate="txtNEETPhysicsScore" ErrorMessage="Please Enter NEET 2024 Physics Percentile."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETPhysicsScore" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETPhysicsScore" ErrorMessage="NEET 2024 Physics Percentile Should be Numeric."></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETPhysicsScore" runat="server" ErrorMessage="NEET 2024 Physics Percentile Should be less than or equal to 100." ControlToValidate="txtNEETPhysicsScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id="trNEETScore2" runat="server">
                        <td style="width: 30%" align="right">Chemistry</td>
                        <td style="width: 20%">
                            <asp:TextBox ID="txtNEETChemistryScore" MaxLength="10" Width="100px" Enabled="false" runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Chemistry Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvNEETChemistryScore" runat="server" Display="None" ControlToValidate="txtNEETChemistryScore" ErrorMessage="Please Enter 2024 2024 Chemistry Percentile."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETChemistryScore" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETChemistryScore" ErrorMessage="NEET 2024 Chemistry Percentile Should be Numeric."></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETChemistryScore" runat="server" ErrorMessage="NEET 2024 Chemistry Percentile Should be less than or equal to 100." ControlToValidate="txtNEETChemistryScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id="trNEETScore3" runat="server">
                        <td align="right">Biology (Botany & Zoology)</td>
                        <td>
                            <asp:TextBox ID="txtNEETBiologyScore" MaxLength="10" Width="100px" Enabled="false" runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Biology (Botany & Zoology) Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvNEETBiologyScore" runat="server" Display="None" ControlToValidate="txtNEETBiologyScore" ErrorMessage="Please Enter NEET 2024 Biology (Botany & Zoology) Percentile."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETBiologyScore" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETBiologyScore" ErrorMessage="NEET 2024 Biology (Botany & Zoology) Percentile Should be Numeric."></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETBiologyScore" runat="server" ErrorMessage="NEET 2024 Biology (Botany & Zoology) Percentile Should be less than or equal to 100." ControlToValidate="txtNEETBiologyScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id="trNEETScore4" runat="server">
                        <td align="right">Total</td>
                        <td>
                            <asp:TextBox ID="txtNEETTotalScore" MaxLength="10" Width="100px" Enabled="false" runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Total Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvNEETTotalScore" runat="server" Display="None" ControlToValidate="txtNEETTotalScore" ErrorMessage="Please Enter NEET 2024 Total Percentile."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETTotalScore" runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETTotalScore" ErrorMessage="NEET 2024 Total Percentile Should be Numeric."></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETTotalScore" runat="server" ErrorMessage="NEET 2024 Total Percentile Should be less than or equal to 100." ControlToValidate="txtNEETTotalScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
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
      <cc1:ContentBox ID="contentDocumentConferamtion" runat="server" HeaderText="Self Confirmation" BoxType="PopupBox"  >
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblDisplayDocumentSubmissionStatus" ForeColor="Red">
                        Your name as per CAP Registration and name as per NEET Result Data is partially matching. Do you want to continue?</asp:Label>
                </td>
            </tr>
            <tr runat="server" id="trYesNo">
                <td align="right">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="InputButton" OnClick="btnYes_Click" />
                    &nbsp;
                </td>
                <td align="left">&nbsp;<asp:Button ID="btnNo" runat="server" Text="No" CssClass="InputButton" OnClick="btnNo_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
    </cc1:ContentBox>

       <script language="javascript" type="text/javascript">

           if (document.getElementById("rightContainer_ContentTable2_txtNEETDOB") != null) {
               var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtNEETDOB'));
           }
       </script>
</asp:Content>
 
