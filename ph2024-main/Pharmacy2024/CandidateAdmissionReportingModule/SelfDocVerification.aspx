<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="SelfDocVerification.aspx.cs" Inherits="Pharmacy2024.CandidateAdmissionReportingModule.SelfDocVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">


    <%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
    <%@ Register Src="../UserControls/CandidateBasicInfo.ascx" TagName="BInfo" TagPrefix="uc1" %>

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
        function isNumberKeyHSC(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            var inputValue = $("#rightContainer_txtHSCPercentage").val();
            if (charCode == 46) {
                if (inputValue.length == 2) {
                    if (inputValue.indexOf('.') < 1) {
                        return true;
                    }
                }
                return false;
            }
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            if (inputValue.length == 5) {
                return false;
            }
            return true;
        }
        function isNumberKeySSC(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            var inputValue = $("#rightContainer_txtSSCPercentage").val()
            if (charCode == 46) {
                if (inputValue.length == 2) {
                    if (inputValue.indexOf('.') < 1) {
                        return true;
                    }
                }
                return false;
            }
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            if (inputValue.length == 5) {
                return false;
            }
            return true;
        }
        function showRetryTiemout() {
            var rCounter = 45
            var timerInterval = setInterval(function () {
                document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#1abc9c";
                document.getElementById("rightContainer_cbPassword_btnCall").disabled = true;
                document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry in " + rCounter + " Second";

                if (rCounter == 0) {
                    rCounter = 45;
                }
                rCounter--;
            }, 1000);
            setTimeout(function () {
                document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#2966C0";
                document.getElementById("rightContainer_cbPassword_btnCall").disabled = false;
                document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry on Call";
                document.getElementById("rightContainer_cbPassword_rfvOneTimePassword").enabled = false;
                document.getElementById("rightContainer_cbPassword_revOneTimePassword").enabled = false;

                clearInterval(timerInterval);
            }, 45000);
        }
        function showRetryTiemouts() {

            var rCounter = 45
            var timerInterval = setInterval(function () {
                document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#1abc9c";
                document.getElementById("rightContainer_cbPassword_btnCall").disabled = true;
                document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry in " + rCounter + " Second";

                if (rCounter == 0) {
                    rCounter = 45;
                }
                rCounter--;
            }, 1000);
            setTimeout(function () {
                document.getElementById("rightContainer_cbPassword_btnCall").style.backgroundColor = "#2966C0";
                document.getElementById("rightContainer_cbPassword_btnCall").disabled = false;
                document.getElementById("rightContainer_cbPassword_btnCall").value = "Retry on Call";
                document.getElementById("rightContainer_cbPassword_rfvOneTimePassword").enabled = false;
                document.getElementById("rightContainer_cbPassword_revOneTimePassword").enabled = false;
                clearInterval(timerInterval);
            }, 45000);
        }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            if (document.getElementById("rightContainer_cbPassword_tblOtp") != null) {
                showRetryTiemout();
            }
        }
        window.onload = load;
    </script>

    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Candidate Details">
        <uc1:BInfo ID="CandidateBasicInformation" runat="server" />
    </cc1:ContentBox>

    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <img src="../Images/BigProgress.gif" alt="" />
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" ClientIDMode="AutoID">
        <ContentTemplate>
            <div>Note:- Candidate shall ensure the correctness of the Parameters Listed below with current status by selecting the appropriate Radio button. </div>
            <div class="table-responsive">
                <table class="AppFormTable">
                    <tr>
                        <th>List of Parameters to be Checked by Candidate </th>
                        <th>Current Status </th>
                        <th>Correct </th>
                        <th>InCorrect </th>
                        <th>Status </th>
                    </tr>
                    <tr id="trGender" runat="server">
                        <td align="right">Gender
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentGender" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="chkGenderV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="GenderStatus" AutoPostBack="True" OnCheckedChanged="GenderStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkGendreNV" runat="server" Text="" GroupName="GenderStatus" AutoPostBack="True" OnCheckedChanged="GenderStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:Label ID="lblGenderStatus" runat="server">Not Selected </asp:Label>
                        </td>
                    </tr>
                    <tr id="trCandidature" runat="server">
                        <td align="right">Candidature
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentCandidature" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="chkCandidatureV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="CandidatureStatus" AutoPostBack="True" OnCheckedChanged="CandidatureStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkCandidatureNV" runat="server" Text="" GroupName="CandidatureStatus" AutoPostBack="True" OnCheckedChanged="CandidatureStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvCandidatureStatus" runat="server" ClientValidationFunction="checkCandidatureStatus" Display="None" ErrorMessage="Please Select Candidature Status."></asp:CustomValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblCandidatureStatus" runat="server">Not Selected </asp:Label>
                        </td>
                    </tr>
                    <tr id="trCategory" runat="server">
                        <td align="right">Category for Admission
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentCategory" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="chkCategoryV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="CategoryStatus" AutoPostBack="True" OnCheckedChanged="CategoryStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkCategoryNV" runat="server" Text="" GroupName="CategoryStatus" AutoPostBack="True" OnCheckedChanged="CategoryStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvCategoryStatus" runat="server" ClientValidationFunction="checkCategoryStatus" Display="None" ErrorMessage="Please Select Category Status."></asp:CustomValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblCategoryStatus" runat="server">Not Selected </asp:Label>
                        </td>
                    </tr>
                    <tr id="trEWS" runat="server">
                        <td align="right">EWS
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentEWS" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="chkEWSV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="EWSStatus" AutoPostBack="True" OnCheckedChanged="EWSStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkEWSNV" runat="server" Text="" GroupName="EWSStatus" AutoPostBack="True" OnCheckedChanged="EWSStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvEWSStatus" runat="server" ClientValidationFunction="checkEWSStatus" Display="None" ErrorMessage="Please Select EWS Status."></asp:CustomValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblEWSStatus" runat="server">Not Selected </asp:Label>
                        </td>
                    </tr>
                    <tr id="trPH" runat="server">
                        <td align="right">PWD
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentPWD" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="chkPWDV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="PWDStatus" AutoPostBack="True" OnCheckedChanged="PWDStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkPWDNV" runat="server" Text="" GroupName="PWDStatus" AutoPostBack="True" OnCheckedChanged="PWDStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvPWDStatus" runat="server" ClientValidationFunction="checkPWDStatus" Display="None" ErrorMessage="Please Select PWD Status."></asp:CustomValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblPWDStatus" runat="server">Not Selected </asp:Label>
                        </td>
                    </tr>
                    <tr id="trDef" runat="server">
                        <td align="right">DEF
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentDEF" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="chkDefV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="DEFStatus" AutoPostBack="True" OnCheckedChanged="DEFStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkDefNV" runat="server" Text="" GroupName="DEFStatus" AutoPostBack="True" OnCheckedChanged="DEFStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvDEFStatus" runat="server" ClientValidationFunction="checkDEFStatus" Display="None" ErrorMessage="Please Select DEF Status."></asp:CustomValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblDefStatus" runat="server">Not Selected </asp:Label>
                        </td>
                    </tr>
                    <tr id="trorphan" runat="server">
                        <td align="right">ORPHAN
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentOrphan" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="chkOrphanV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="OrphanStatus" AutoPostBack="True" OnCheckedChanged="OrphanStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkOrphanNV" runat="server" Text="" GroupName="OrphanStatus" AutoPostBack="True" OnCheckedChanged="OrphanStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvOrphanStatus" runat="server" ClientValidationFunction="checkOrphanStatus" Display="None" ErrorMessage="Please Select ORPHAN Status."></asp:CustomValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblOrphanStatus" runat="server">Not Selected </asp:Label>
                        </td>
                    </tr>
                    <tr id="trTFWS" runat="server">
                        <td align="right">TFWS
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentTFWS" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="chkTFWSV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="TFWSStatus" AutoPostBack="True" OnCheckedChanged="TFWSStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkTFWSNV" runat="server" Text="" GroupName="TFWSStatus" AutoPostBack="True" OnCheckedChanged="TFWSStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvTFWSStatus" runat="server" ClientValidationFunction="checkTFWSStatus" Display="None" ErrorMessage="Please Select TFWS Status."></asp:CustomValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblTFWSStatus" runat="server">Not Selected </asp:Label>
                        </td>
                    </tr>
                    <tr id="trLinguisticMinority" runat="server">
                        <td align="right">Linguistic Minority
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentLinguistic" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="chkLinguisticMinorityV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="LinguisticMinorityStatus" AutoPostBack="True" OnCheckedChanged="LinguisticMinorityStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkLinguisticMinorityNV" runat="server" Text="" GroupName="LinguisticMinorityStatus" AutoPostBack="True" OnCheckedChanged="LinguisticMinorityStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvLinguisticMinorityStatus" runat="server" ClientValidationFunction="checkLinguisticMinorityStatus" Display="None" ErrorMessage="Please Select Linguistic Minority Status."></asp:CustomValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblLinguisticMinorityStatus" runat="server">Not Selected </asp:Label>
                        </td>
                    </tr>
                    <tr id="trReligiousMinority" runat="server">
                        <td align="right">Religious Minority
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentReligious" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="chkReligiousMinorityV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="ReligiousMinorityStatus" AutoPostBack="True" OnCheckedChanged="ReligiousMinorityStatus_CheckedChanged" />
                        </td>
                        <td>
                            <asp:RadioButton ID="chkReligiousMinorityNV" runat="server" Text="" GroupName="ReligiousMinorityStatus" AutoPostBack="True" OnCheckedChanged="ReligiousMinorityStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvReligiousMinorityStatus" runat="server" ClientValidationFunction="checkReligiousMinorityStatus" Display="None" ErrorMessage="Please Select Religious Minority Status."></asp:CustomValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblReligiousMinorityStatus" runat="server">Not Selected </asp:Label>
                        </td>
                    </tr>
                    <tr id="trQualificationPH" runat="server">
                        <td colspan="5">
                            <table class="AppFormTable">
                                <tr>
                                    <th><b>List of Parameters to be Checked by Candidate </th>
                                    <th><b>Current Status
                                        <br />
                                        (Marks Obtained / Marks Outof) </b></th>
                                    <th><b>Correct </b></th>
                                    <th><b>InCorrect</b> </th>
                                    <th><b>Corrected Marks Obtained </b></th>
                                    <th><b>Corrected Marks OutOf </b></th>
                                    <th><b>Status </b></th>
                                </tr>
                                <tr id="trHSCPercentage" runat="server">
                                    <td align="right">HSC Percentage
                                    </td>
                                    <td>
                                        <asp:Label ID="lblHSCCurrentPercentage" runat="server"></asp:Label>
                                        <asp:Label ID="lblHSCPercentagecmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCPercengageV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="HSCPercentageStatus" AutoPostBack="True" OnCheckedChanged="HSCPercengage_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCPercengageNV" runat="server" Text="" GroupName="HSCPercentageStatus" AutoPostBack="True" OnCheckedChanged="HSCPercengage_CheckedChanged" />
                                        <asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="checkHSCAggregateStatus" Display="None" ErrorMessage="Please Select HSC Percentage Status."></asp:CustomValidator>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtHSCPercentage" runat="server" Width="100px" onKeyPress="return isNumberKeyHSC(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Enter Your HSC Percentage Marks." ControlToValidate="txtHSCPercentage" Display="None"></asp:RequiredFieldValidator>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblHSCPercentageStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                <tr id="trHSCTotal" runat="server">
                                    <td align="right">HSC Total
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentHSCAggregate" runat="server"></asp:Label>
                                        <asp:Label ID="lblHSCTotalCmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCAggregateV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="HSCAggregateStatus" AutoPostBack="True" OnCheckedChanged="HSCAggregateStatus_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCAggregateNV" runat="server" Text="" GroupName="HSCAggregateStatus" AutoPostBack="True" OnCheckedChanged="HSCAggregateStatus_CheckedChanged" />
                                        <asp:CustomValidator ID="cvHSCAggregateStatus" runat="server" ClientValidationFunction="checkHSCAggregateStatus" Display="None" ErrorMessage="Please Select HSC Total Status."></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCTotal" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvHSCTotal" runat="server" ErrorMessage="Please Enter Your HSC Total Marks." ControlToValidate="txtHSCTotal" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCTotalOutof" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Your HSC Total Marks Outof." ControlToValidate="txtHSCTotalOutof" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblHSCAggregateStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>

                                <tr id="trPhysics" runat="server">
                                    <td align="right">HSC Physics
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentHSCPhysics" runat="server"></asp:Label>
                                        <asp:Label ID="lblHSCPhysicscmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCPhysicsV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="HSCPhysicsStatus" AutoPostBack="True" OnCheckedChanged="HSCPhysicsStatus_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCPhysicsNV" runat="server" Text="" GroupName="HSCPhysicsStatus" AutoPostBack="True" OnCheckedChanged="HSCPhysicsStatus_CheckedChanged" />
                                        <asp:CustomValidator ID="cvHSCPhysicsStatus" runat="server" ClientValidationFunction="checkHSCPhysicsStatus" Display="None" ErrorMessage="Please Select HSC Physics Status."></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCPhysicsStatus" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvHSCPhysicsStatus" runat="server" ErrorMessage="Please Enter Your HSC Physics Marks." ControlToValidate="txtHSCPhysicsStatus" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCPhysicsStatusOutOf" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Your HSC Physics Marks Outof." ControlToValidate="txtHSCPhysicsStatusOutOf" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblHSCPhysicsStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                <tr id="trHSCChemistry" runat="server">
                                    <td align="right">HSC Chemistry
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentHSCChemistry" runat="server"></asp:Label>
                                        <asp:Label ID="lblHSCChemistrycmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCChemistryV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="HSCChemistryStatus" AutoPostBack="True" OnCheckedChanged="HSCChemistryStatus_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCChemistryNV" runat="server" Text="" GroupName="HSCChemistryStatus" AutoPostBack="True" OnCheckedChanged="HSCChemistryStatus_CheckedChanged" />
                                        <asp:CustomValidator ID="cvHSCChemistryStatus" runat="server" ClientValidationFunction="checkHSCChemistryStatus" Display="None" ErrorMessage="Please Select HSC Chemistry Status."></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCChemistryStatus" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvHSCChemistryStatus" runat="server" ErrorMessage="Please Enter Your HSC Chemistry Marks." ControlToValidate="txtHSCChemistryStatus" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCChemistryOutofMarks" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Your HSC Chemistry Marks Outof." ControlToValidate="txtHSCChemistryOutofMarks" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblHSCChemistryStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                <tr id="trHSCBiology" runat="server">
                                    <td align="right">HSC Biology
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentHSCBiology" runat="server"></asp:Label>
                                        <asp:Label ID="lblHSCBiologycmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCBiologyV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="HSCBiologyStatus" AutoPostBack="True" OnCheckedChanged="HSCBiologyStatus_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCBiologyNV" runat="server" Text="" GroupName="HSCBiologyStatus" AutoPostBack="True" OnCheckedChanged="HSCBiologyStatus_CheckedChanged" />
                                        <asp:CustomValidator ID="cvHSCBiologyStatus" runat="server" ClientValidationFunction="checkHSCBiologyStatus" Display="None" ErrorMessage="Please Select HSC Biology Status."></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCBiology" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvHSCBiology" runat="server" ErrorMessage="Please Enter Your HSC Biology Marks." ControlToValidate="txtHSCBiology" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCBiologyOutofMarks" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Your HSC Biology Marks Outof." ControlToValidate="txtHSCBiologyOutofMarks" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblHSCBiologyStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                <tr id="trHSCMathematics" runat="server">
                                    <td align="right">HSC Mathematics
                                   
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentHSCMathematics" runat="server"></asp:Label>
                                        <asp:Label ID="lblHSCMathematicscmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCMathematicsV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="HSCMathematicsStatus" AutoPostBack="True" OnCheckedChanged="HSCMathematicsStatus_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCMathematicsNV" runat="server" Text="" GroupName="HSCMathematicsStatus" AutoPostBack="True" OnCheckedChanged="HSCMathematicsStatus_CheckedChanged" />
                                        <asp:CustomValidator ID="cvHSCMathematics" runat="server" ClientValidationFunction="checkHSCMathematicsStatus" Display="None" ErrorMessage="Please Select HSC Mathematics Status."></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCMathematics" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvHSCMathematics" runat="server" ErrorMessage="Please Enter Your HSC Mathematics Marks." ControlToValidate="txtHSCMathematics" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCMathematicsOutof" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter Your HSC Mathematics Marks Outof." ControlToValidate="txtHSCMathematicsOutof" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblHSCMathematicsStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                <tr id="trHSCEnglish" runat="server">
                                    <td align="right">HSC English
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentHSCEnglish" runat="server"></asp:Label>
                                        <asp:Label ID="lblHSCEnglishcmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCEnglishV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="HSCEnglishStatus" AutoPostBack="True" OnCheckedChanged="HSCEnglishStatus_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkHSCEnglishNV" runat="server" Text="" GroupName="HSCEnglishStatus" AutoPostBack="True" OnCheckedChanged="HSCEnglishStatus_CheckedChanged" />
                                        <asp:CustomValidator ID="cvHSCEnglish" runat="server" ClientValidationFunction="checkHSCEnglishStatus" Display="None" ErrorMessage="Please Select HSC English Status."></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCEnglish" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvHSCEnglishStatus" runat="server" ErrorMessage="Please Enter Your HSC English Marks." ControlToValidate="txtHSCEnglish" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHSCEnglishOutof" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Your HSC English Marks Outof." ControlToValidate="txtHSCEnglishOutof" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblHSCEnglishStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                <tr id="trDiploma" runat="server">
                                    <td align="right">Diploma Marks - 
                                        <asp:Label ID="lblDiplomaMarkType" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentDiploma" runat="server"></asp:Label>
                                        <asp:Label ID="lblDiplomacmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkDiplomaV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="DiplomaStatus" AutoPostBack="True" OnCheckedChanged="DiplomaStatus_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkDiplomaNV" runat="server" Text="" GroupName="DiplomaStatus" AutoPostBack="True" OnCheckedChanged="DiplomaStatus_CheckedChanged" />
                                        <asp:CustomValidator ID="cvDiploma" runat="server" ClientValidationFunction="checkHSCPhysicsStatus" Display="None" ErrorMessage="Please Select Diploma Marks Status."></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDiplomaMarks" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please Enter Your Diploma Marks." ControlToValidate="txtDiplomaMarks" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDiplomaOutofMarks" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Please Enter Your Diploma Marks Outof." ControlToValidate="txtDiplomaOutofMarks" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDiplomaStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                <tr id="trSSCTotal" runat="server">
                                    <td align="right">SSC Total
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentSSCTotal" runat="server"></asp:Label>
                                        <asp:Label ID="lblSSCTotalcmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSSCTotalV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="SSCTotal" AutoPostBack="True" OnCheckedChanged="SSCTotalStatus_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSSCTotalNV" runat="server" Text="" GroupName="SSCTotal" AutoPostBack="True" OnCheckedChanged="SSCTotalStatus_CheckedChanged" />
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="checkSSCTotalStatus" Display="None" ErrorMessage="Please Select SSC Total Status."></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSSCTotal" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvtxtSSCTotal" runat="server" ErrorMessage="Please Enter Your SSC Total Marks." ControlToValidate="txtSSCTotal" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSSCTotalOutof" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Your SSC Total Marks Outof." ControlToValidate="txtSSCTotalOutof" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltxtSSCTotalStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                <tr id="trSSCMath" runat="server">
                                    <td align="right">SSC Mathematics
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentSSCMathematics" runat="server"></asp:Label>
                                        <asp:Label ID="lblSSCMathematicscmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSSCMathematicsV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="SSCMathematics" AutoPostBack="True" OnCheckedChanged="SSCMathematicsStatus_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSSCMathematicsNV" runat="server" Text="" GroupName="SSCMathematics" AutoPostBack="True" OnCheckedChanged="SSCMathematicsStatus_CheckedChanged" />
                                        <asp:CustomValidator ID="cvSSCMathematicsStatus" runat="server" ClientValidationFunction="checkSSCMathematicsStatus" Display="None" ErrorMessage="Please Select Mathematics Total Status."></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSSCMathematics" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="rfvSSCMathematics" runat="server" ErrorMessage="Please Enter Your SSC Mathematics Marks." ControlToValidate="txtSSCMathematics" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSSCMathematicsOutOf" runat="server" Width="100px" onKeyPress="return numbersonly(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Your SSC Mathematics Marks Outof." ControlToValidate="txtSSCMathematicsOutOf" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMathematicsStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                <tr id="trSSCPercentage" runat="server">
                                    <td align="right">SSC Percentage
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSSCCurrentPercentage" runat="server"></asp:Label>
                                        <asp:Label ID="lblSSCPercentagecmp" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSSCPercengageV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="SSCPercentageStatus" AutoPostBack="True" OnCheckedChanged="SSCPercengage_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkSSCPercengageNV" runat="server" Text="" GroupName="SSCPercentageStatus" AutoPostBack="True" OnCheckedChanged="SSCPercengage_CheckedChanged" />
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="checkHSCAggregateStatus" Display="None" ErrorMessage="Please Select SSC Percentage Status."></asp:CustomValidator>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtSSCPercentage" runat="server" Width="100px" onKeyPress="return isNumberKeySSC(event)" Enabled="false"></asp:TextBox>
                                        <font color="red"><sup>*</sup></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Your SSC Percentage Marks." ControlToValidate="txtHSCPercentage" Display="None"></asp:RequiredFieldValidator>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblSSCPercentageStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                <tr id="trIntermediateGradeDrawing" runat="server">
                                    <td align="right">Intermediate Grade Drawing
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentIntermediateGradeDrawing" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkIntermediateGradeDrawingV" runat="server" CssClass="width-password" Text="&nbsp;&nbsp;" GroupName="IntermediateGradeDrawingStatus" AutoPostBack="True" OnCheckedChanged="IntermediateGradeDrawingStatus_CheckedChanged" />
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="chkIntermediateGradeDrawingNV" runat="server" Text="" GroupName="IntermediateGradeDrawingStatus" AutoPostBack="True" OnCheckedChanged="IntermediateGradeDrawingStatus_CheckedChanged" />
                                        <asp:CustomValidator ID="cvIntermediateGradeDrawingStatus" runat="server" ClientValidationFunction="checkIntermediateGradeDrawingStatus" Display="None" ErrorMessage="Please Select Intermediate Grade Drawing Status."></asp:CustomValidator>
                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="lblIntermediateGradeDrawingNo" runat="server" Visible="false"> No </asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIntermediateGradeDrawingStatus" runat="server">Not Selected </asp:Label>
                                    </td>
                                </tr>
                                 <asp:HiddenField ID="hdnSubjectID" runat="server" />
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="table-responsive">
                <table class="AppFormTable">
                    <tr>
                        <th colspan="4" align="left">List of Required Documents</th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <%-- <font color="red">Documents shown in red color are not uploaded. You can not verify that documents without uploading.</font>--%>
                            <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid" OnRowDataBound="gvDocuments_RowDataBound">
                                <Columns>
                                    <asp:BoundField HeaderText="Sr. No.">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="8%" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DocumentName" HeaderText="Document Name" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="57%" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Verified at SC"  >
                                        <ItemTemplate>
                                            <asp:RadioButton ID="rbnYes" runat="server" Text="&nbsp;Verified" GroupName="YesNo" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="12%" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Not Accepted" >
                                        <ItemTemplate>
                                            <asp:RadioButton ID="rbnNo" runat="server" Text="&nbsp;Not Accepted" GroupName="YesNo" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="15%" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                            <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" onclick="javascript:OpenViewDocumentPopUp(this)" runat="server" />
                                            <asp:HiddenField ID="hidFURL" runat="server" Value='<%# Bind("FilePath") %>' />
                                            <asp:HiddenField ID="hidDID" runat="server" Value='<%# Bind("DocumentTransID") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsSubmitted" runat="server" Text='<%# Eval("IsSubmittedAtAFC") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocumentID" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnImgUrl" runat="server" Value='<%# Bind("FilePath") %>' />
                                            <asp:HiddenField ID="hdnImgByteArray" runat="server" Value='<%# Bind("FilePath") %>' />
                                        </ItemTemplate>
                                        <ControlStyle CssClass="NotVisible" />
                                        <ItemStyle CssClass="NotVisible" />
                                        <HeaderStyle CssClass="NotVisible" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <table class="AppFormTableWithOutBorder">
                <tr>
                    <td align="center">
                        <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" OnClick="btnProceed_Click" CssClass="InputButton"></asp:Button></td>
                    <asp:CustomValidator ID="cvGenderStatus" runat="server" ClientValidationFunction="checkGenderStatus" Display="None" ErrorMessage="Please Select Gender Status."></asp:CustomValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="false" />
                </tr>
            </table>
            <br />
            <cc1:ContentBox ID="contentConfermation" runat="server" HeaderText="Self Confirmation" BoxType="ContentBox">
                <div class="table-responsive">
                    <table class="AppFormTableWithOutBorder">
                        <tr>
                            <td>
                                <asp:Label ID="lblDisplayDocumentSubmissionStatus" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox runat="server" ID="MyCheckBox" AutoPostBack="true" CssClass="AcceptedAgreement" />
                                <asp:CustomValidator runat="server" ID="CheckBoxRequired" EnableClientScript="true"
                                    OnServerValidate="CheckBoxRequired_ServerValidate"
                                    ClientValidationFunction="CheckBoxRequired_ClientValidate" ForeColor="Red"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>   <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="InputButton"></asp:Button>
                            
                                <asp:Button ID="btnSave" runat="server" Text="Save & Proceed >>>" OnClick="btnSave_Click" CssClass="InputButton"></asp:Button>
                                 </center>
                            </td>
                        </tr>
                    </table>
                </div>

            </cc1:ContentBox>
            <cc1:ContentBox ID="contentOTPVerify" runat="server" HeaderText="Self Grievance Confirm Password">
                <asp:HiddenField ID="hdnPassword" runat="server" />
                <div class="table-responsive">
                    <table class="AppFormTable">
                        <tr id="trEligibilityRemark" runat="server" visible="false">
                            <td colspan="4">
                                <asp:Label ID="lblEligibilityRemark" runat="server" ForeColor="Red"><b>Remark : </b></asp:Label></td>
                        </tr>
                    </table>
                    <table id="tblPasword" class="AppFormTable" runat="server">

                        <tr id="tr1" runat="server">
                            <td align="right" style="width: 50%;">Enter Your Login Password
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20" autocomplete="off"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                    Display="None" ErrorMessage="Enter Password" ValidationGroup="password"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <br />
                        <tr>
                            <td align="center" colspan="3">
                                <br />
                                <br />
                                <asp:Button ID="btnpassword" runat="server" Text="Verify Password" CssClass="InputButton"
                                    OnClick="btnpassword_Click" ValidationGroup="password" Style="font-size: medium; height: 30px; font-weight: bold; background-color: red;" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False"
                                    ShowMessageBox="True" ValidationGroup="password" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="table-responsive">
                    <table id="tblOtp" class="AppFormTable" runat="server">
                        <tr id="trMobileNo" runat="server" visible="False">
                            <td colspan="4" align="center">OTP has been sent your Mobile No :  
                                <asp:Label ID="lblMaskMobileno" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%">Enter One Time Password (OTP)
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtOneTimePassword" runat="server" MaxLength="6" onKeyPress="return numbersonly(event)"
                                    autocomplete="off"> </asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword"
                                    Display="None" ErrorMessage="Please Enter One Time Password (OTP)." ValidationGroup="otp"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword"
                                    Display="None" ErrorMessage="One Time Password (OTP) Should be of 6 Digits."
                                    ValidationExpression="\d{6}" ValidationGroup="otp"></asp:RegularExpressionValidator>
                                <asp:Button ID="btnCall" runat="server" CssClass="InputButton" OnClick="btnCall_Click"
                                    Text="Retry on Call" Visible="false" ValidationGroup="call" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <br />
                                <br />
                                <asp:Button ID="btnVerifyOtp" runat="server" Text="Verify OTP for Submit Self Grievance for Verification"
                                    CssClass="InputButton" OnClick="btnVerifyOtp_Click" ValidationGroup="otp" Style="font-size: medium; height: 30px; font-weight: bold; background-color: red;" />
                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowSummary="False"
                                    ShowMessageBox="True" ValidationGroup="otp" />
                            </td>
                        </tr>
                    </table>
                </div>
            </cc1:ContentBox>
        </ContentTemplate>
    </asp:UpdatePanel>

    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="70%">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr>
                <td>
                    <div class="modal-body">
                        <div runat="server" id="divButtonPopup">
                            <button type="button" onclick="zoominPopUp()">
                                <img src="../Images/zoom-in.png" width="15px" height="15px"></button>
                            <button type="button" onclick="zoomoutPopUp()">
                                <img src="../Images/zoom-out.png" width="15px" height="15px">
                            </button>
                        </div>
                        <div id="divDocument" class="doc-container"></div>
                    </div>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <script>
        function zoominPopUp() {
            var GFG = document.getElementById('<%=imgPopUpDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth + 100) + "px";
        }

        function zoomoutPopUp() {
            var GFG = document.getElementById('<%=imgPopUpDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth - 100) + "px";
        }

        function OpenViewDocumentPopUp(cntrl) {

            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            var corrRow = cntrl.parentNode.parentNode;
            var filePath = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            var byteStream = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[1].value;
            document.getElementById('lblDocumentName').innerHTML = corrRow.cells[1].innerText;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + byteStream + '">';
                    document.getElementById('divDocument').style.overflow = "auto";
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('divDocument').innerHTML = '<iframe src="' + byteStream + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                    document.getElementById('divDocument').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }
        function CheckBoxRequired_ClientValidate(sender, e) {
            e.IsValid = jQuery(".AcceptedAgreement input:checkbox").is(':checked');

        }
    </script>
</asp:Content>
