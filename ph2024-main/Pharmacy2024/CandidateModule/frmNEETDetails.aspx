<%@ Page Language="C#" MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master" AutoEventWireup="true" CodeBehind="frmNEETDetails.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmNEETDetails_Fetch" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <style>
     #rightContainer_contentDocumentConferamtion {
            position: fixed !important;
            top: 15% !important;
            width:70%;
            z-index:2000 !important ;
        }

        @media only screen and (max-width: 768px) {
            #rightContainer_contentDocumentConferamtion {
                position: fixed !important;
                top: 10% !important;
                width:90%;                
            }
        }
       
    </style>
      <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type = "text/javascript">
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
    <cc1:ContentBox ID="ContentTable2" runat="server" >
        <asp:UpdateProgress runat="server" id="PageUpdateProgress">
            <ProgressTemplate>
                <img src ="../Images/BigProgress.gif" alt = "" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upNEET">
            <ContentTemplate>
            <table class = "AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color = "red">
                        <p align = "justify"><font color = "red"><b>Note :</b></font></p>
                        <ul class="list-text">
                            <li><p align = "justify"><font color = "red">For All India Candidates preference shall be given to the candidate obtaining non zero positive score in NEET over the candidates who obtained non zero score in MHTCET <%= CurrentYear %>.</font></p></li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
	            <table class="AppFormTable">
                     
                    <tr>
                        <td style="width: 50%" align ="right">Have you Appeared for NEET <%= CurrentYear %>? <br /> आपण नीट-<%= CurrentYear %> पात्रता परिक्षेत उत्तीर्ण आहेत का ?</td>
                        <td style="width: 50%">
                            <asp:RadioButton ID="rbnAppearedForNEETYes" runat="server" GroupName="AppearedForNEET" Text="&nbsp;&nbsp;Yes" AutoPostBack = "true" OnCheckedChanged="AppearedForNEET_CheckedChanged" onmouseover="ddrivetip('Please Select Appeared Status for NEET 2024.')" onmouseout="hideddrivetip()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnAppearedForNEETNo" runat="server" GroupName="AppearedForNEET" Text="&nbsp;&nbsp;No" AutoPostBack = "true" OnCheckedChanged="AppearedForNEET_CheckedChanged" onmouseover="ddrivetip('Please Select Appeared Status for NEET 2024.')" onmouseout="hideddrivetip()" />
                            <asp:CustomValidator ID="cvAppearedForNEET" runat="server" ClientValidationFunction="checkAppearedForNEET" Display="None"  ></asp:CustomValidator>
                        </td>
                    </tr>
	                <tr id = "trNEETRollNo" runat = "server">
                        <td align="right">Roll No <br /> आसन क्रमांक</td>
			            <td>
                            <asp:TextBox ID="txtNEETRollNo" Runat="server" MaxLength="10" Width = "110px" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter NEET 2024 Roll No. It should be numeric and of 10 digits.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvNEETRollNo" Runat="server" Display="None" ControlToValidate="txtNEETRollNo" ValidationGroup="NEET" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETRollNo" Runat="server"  ControlToValidate="txtNEETRollNo" Display="None" ValidationExpression="\d{10}" ValidationGroup="NEET"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cvNEETRollNo" Runat="server"  ControlToValidate="txtNEETRollNo" Display="None" Operator="NotEqual" ValueToCompare="0" Type="Integer" ValidationGroup="NEET"></asp:CompareValidator>
                        </td>
			        </tr>
                    <tr id = "trNEETDOB" runat = "server">
                        <td align="right">Candidate's DOB as on NEET Score Card </td>
                        <td>
                            <asp:TextBox ID="txtNEETDOB" runat="server" MaxLength="10" Width="110px" ></asp:TextBox>
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
                        <td align = "right" width="50%">Candidate Name As Per NEET</td>
                        <td width="50%"><asp:Label ID = "lblCandidateNameasPerNEET" runat = "server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr id = "trNEETScore1" runat = "server">
                        <td align="right">Physics <br /> भौतिकशास्‍त्र</td>
                        <td>
                            <asp:TextBox id="txtNEETPhysicsScore" MaxLength="10" Width="100px" Enabled="false" Runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Physics Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red">*</font>
                            <asp:RequiredFieldValidator id="rfvNEETPhysicsScore" Runat="server" Display="None" ControlToValidate="txtNEETPhysicsScore" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revNEETPhysicsScore" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETPhysicsScore" ></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETPhysicsScore" runat="server"  ControlToValidate="txtNEETPhysicsScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id = "trNEETScore2" runat = "server">
                        <td align="right">Chemistry <br /> रसायनशास्‍त्र</td>
                        <td >
                            <asp:TextBox id="txtNEETChemistryScore" MaxLength="10" Width="100px" Enabled="false" Runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Chemistry Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red">*</font>
                            <asp:RequiredFieldValidator id="rfvNEETChemistryScore" Runat="server" Display="None" ControlToValidate="txtNEETChemistryScore" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revNEETChemistryScore" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETChemistryScore" ></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETChemistryScore" runat="server"  ControlToValidate="txtNEETChemistryScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id = "trNEETScore3" runat = "server">
                        <td align="right">Biology (Botany & Zoology) <br />जिवशास्‍त्र ( वनस्पतीशास्‍त्र व प्राणीशास्‍त्र)</td>
                        <td>
                            <asp:TextBox id="txtNEETBiologyScore" MaxLength="10" Width="100px" Enabled="false" Runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Biology (Botany & Zoology) Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red">*</font>
                            <asp:RequiredFieldValidator id="rfvNEETBiologyScore" Runat="server" Display="None" ControlToValidate="txtNEETBiologyScore" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revNEETBiologyScore" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETBiologyScore" ></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETBiologyScore" runat="server"  ControlToValidate="txtNEETBiologyScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id = "trNEETScore4" runat = "server">
                        <td align="right">Total <br /> एकुण</td>
                        <td>
                            <asp:TextBox id="txtNEETTotalScore" MaxLength="10" Width="100px" Enabled="false" Runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Total Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red">*</font>
                            <asp:RequiredFieldValidator id="rfvNEETTotalScore" Runat="server" Display="None" ControlToValidate="txtNEETTotalScore" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revNEETTotalScore" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETTotalScore" ></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETTotalScore" runat="server"  ControlToValidate="txtNEETTotalScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
	            </table>

                 <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                    <asp:Button ID="btnChangeCETDetails" runat="server" Text="Click Here to Edit CET Details >>>" CssClass="InputButton" OnClick="btnChangeCETDetails_Click" Visible="false" />
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
