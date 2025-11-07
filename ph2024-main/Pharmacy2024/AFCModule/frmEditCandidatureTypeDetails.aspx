<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditCandidatureTypeDetails.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEditCandidatureTypeDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/epoch_classes.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function checkMinorityStatus(sender, args) {
            if (document.getElementById("ctl00_rightContainer_ContentTable2_chkLinguisticMinority").checked || document.getElementById("ctl00_rightContainer_ContentTable2_chkReligiousMinority").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
        function isAppDateValid(sender, args) {
            var dateStr = document.getElementById("ctl00_rightContainer_ContentTable2_txtAppDate").value;
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
            if (document.getElementById('ctl00_rightContainer_ContentTable2_txtAppDate') != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable2_txtAppDate'));
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
                <td align="right">Candidate's Full Name</td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Candidature Type, Home University, Category & Special Reservation Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upHomeUniversity">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <th colspan="2" align="left">Candidature Type Details</th>
                    </tr>
                    <tr>
                        <td style="width: 50%;" align="right">Candidature Type</td>
                        <td style="width: 50%;">
                            <asp:DropDownList ID="ddlCandidatureType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCandidatureType_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Candidature Type.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCandidatureType" runat="server" ControlToValidate="ddlCandidatureType" Display="None" ErrorMessage="Please Select Candidature Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                <table id="tblHomeUniversity" runat="server" class="AppFormTable">
                    <tr>
                        <th colspan="2" align="left" style="border-top-width: 0px;">Home University Details</th>
                    </tr>
                    <tr id="trDocumentForTypeA" runat="server">
                        <td align="right">Select Document Submitting at SC for Type-A</td>
                        <td>
                            <asp:DropDownList ID="ddlDocumentForTypeA" runat="server" onmouseover="ddrivetip('Please Select Document Submitting at SC for Type-A.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvDocumentForTypeA" runat="server" ControlToValidate="ddlDocumentForTypeA" Display="None" ErrorMessage="Please Select Document Submitting at SC for Type-A." Operator="NotEqual" ValueToCompare="N"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trDocumentOf" runat="server">
                        <td align="right">
                            <asp:Label ID="QDocumentOf" runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlDocumentOf" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDocumentOf_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvDocumentOf" runat="server" ControlToValidate="ddlDocumentOf" Display="None" ErrorMessage="" Operator="NotEqual" ValueToCompare="N"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trMothersName" runat="server">
                        <td align="right">Enter Mother's Name as appeared in Domicile Certificate</td>
                        <td>
                            <asp:TextBox ID="txtMothersName" runat="server" onmouseover="ddrivetip('Please Enter Mother\'s Name as appeared in Domicile Certificate.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvMothersName" runat="server" ControlToValidate="txtMothersName" Display="None" ErrorMessage="Please Enter Mother's Name as appeared in Domicile Certificate."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trQ1" runat="server">
                        <td align="right">
                            <asp:Label ID="lblQ1" runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlDistrict1" runat="server" ToolTip=""></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvDistrict1" runat="server" Display="None" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlDistrict1" ErrorMessage=""></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trQ2" runat="server">
                        <td align="right">
                            <asp:Label ID="lblQ2" runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlDistrict2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict2_SelectedIndexChanged" ToolTip=""></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvDistrict2" runat="server" Display='none' ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlDistrict2" ErrorMessage=""></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trQ21" runat="server">
                        <td align="right">
                            <asp:Label ID="lblQ21" runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlTaluka2" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvTaluka2" runat="server" Display='none' ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlTaluka2" ErrorMessage=""></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%;" align="right">Your Home University</td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblHomeUniversity" runat="Server" Font-Bold="true"></asp:Label>
                            <asp:HiddenField ID="hdnHomeUniversityID" runat="server" />
                        </td>
                    </tr>
                </table>
                <table id="tblCategory" runat="server" class="AppFormTable">
                    <tr>
                        <th colspan="2" align="left" style="border-top-width: 0px;">Category Details</th>
                    </tr>
                    <tr>
                        <td style="width: 50%;" align="right">Select Category to Which You Belong</td>
                        <td style="width: 50%;">
                            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Category.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCategory" runat="server" ControlToValidate="ddlCategory" Display="None" ErrorMessage="Please Select Category." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trOpenCaste" runat="server">
                        <td align="right">Enter Caste Name</td>
                        <td>
                            <asp:TextBox ID="txtCasteNameForOpen" runat="server" MaxLength="100" autocomplete="off" onmouseover="ddrivetip('Please Enter Caste Name.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCasteNameForOpen" runat="server" ErrorMessage="Please Enter Caste Name." ControlToValidate="txtCasteNameForOpen" Display="None"></asp:RequiredFieldValidator>
                            <ajaxToolkit:AutoCompleteExtender runat="server" BehaviorID="AutoCompleteEx" ID="autoComplete1" TargetControlID="txtCasteNameForOpen" ServicePath="~/Services/AutoComplete/AutoComplete.asmx" ServiceMethod="GetOpenCastList" MinimumPrefixLength="2" CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" DelimiterCharacters=";, :">
                                <animations>
                                    <OnShow>
                                        <Sequence>
                                            <OpacityAction Opacity="0" />
                                            <HideAction Visible="true" />
                                            <ScriptAction Script="
                                                var behavior = $find('AutoCompleteEx');
                                                if (!behavior._height) {
                                                    var target = behavior.get_completionList();
                                                    behavior._height = target.offsetHeight - 2;
                                                    target.style.height = '0px';
                                                }" />
                                            <Parallel Duration=".4">
                                                <FadeIn />
                                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                                            </Parallel>
                                        </Sequence>
                                    </OnShow>
                                    <OnHide>
                                        <Parallel Duration=".4">
                                            <FadeOut />
                                            <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                                        </Parallel>
                                    </OnHide>
                                </animations>
                            </ajaxToolkit:AutoCompleteExtender>
                        </td>
                    </tr>
                    <tr id="trReservedCaste" runat="server">
                        <td align="right">Select Caste to Which You Belong</td>
                        <td>
                            <asp:DropDownList ID="ddlCaste" runat="server" onmouseover="ddrivetip('Please Select Caste.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCaste" runat="server" ControlToValidate="ddlCaste" Display="None" ErrorMessage="Please Select Caste." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trCasteValidityStatus" runat="server">
                        <td align="right">Select Caste / Tribe Validity Certificate Status</td>
                        <td>
                            <asp:DropDownList ID="ddlCasteValidityStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCasteValidityStatus_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Caste / Tribe Validity Certificate Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="R">Available</asp:ListItem>
                                <asp:ListItem Value="A">Applied but Not Received</asp:ListItem>
                                <asp:ListItem Value="N">Not Applied</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCasteValidityStatus" runat="server" ControlToValidate="ddlCasteValidityStatus" Display="None" ErrorMessage="Please Select Caste / Tribe Validity Certificate Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trCasteValidityApplied1">
                        <td style="width: 50%;" align="right">Caste / Tribe Validity Certificate Application Number
                        </td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="txtCVCApplicationNo" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCVCApplicationNo" runat="server" ErrorMessage="Please Enter Caste / Tribe Validity Certificate Application Number." ControlToValidate="txtCVCApplicationNo" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trCasteValidityApplied2">
                        <td align="right">Caste / Tribe Validity Certificate Application Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtAppDate" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvAppDate" runat="server" ErrorMessage="Please Enter  Caste / Tribe Validity Certificate Application Date." ControlToValidate="txtAppDate" Display="None"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvAppDate" runat="server" ControlToValidate="txtAppDate" ClientValidationFunction="isAppDateValid" Display="None" ErrorMessage="Please Select Proper Caste / Tribe Validity Certificate Application Date."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trCasteValidityApplied3">
                        <td align="right">Caste / Tribe Validity Certificate Issuing Authority Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtCVCAuthority" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCVCAuthority" runat="server" ErrorMessage="Please Enter Caste / Tribe Validity Certificate Issuing Authority Name." ControlToValidate="txtCVCAuthority" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trCasteValidityApplied4">
                        <td align="right">Caste / Tribe Validity Certificate Issuing District
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCVCDistrict" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCVCDistrict" runat="server" Display="None" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlCVCDistrict" ErrorMessage="Please Select Caste / Tribe Validity Certificate Issuing District."></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trCasteValidityApplied5">
                        <td align="right">Name As Per Caste / Tribe Validity Certificate
                        </td>
                        <td>
                            <asp:TextBox ID="txtCVCName" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCVCName" runat="server" ErrorMessage="Please Enter Name As Per Caste / Tribe Validity Certificate." ControlToValidate="txtCVCName" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trCasteValidityApplied6">
                        <td align="right">Caste Certificate Number
                        </td>
                        <td>
                            <asp:TextBox ID="txtCCNumber" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCCNumber" runat="server" ErrorMessage="Please Enter Caste Certificate Number." ControlToValidate="txtCCNumber" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table id="tblSpecialReservation" runat="server" class="AppFormTable">
                    <tr>
                        <th colspan="2" align="left" style="border-top-width: 0px;">Special Reservation Details</th>
                    </tr>
                    <tr>
                        <td style="width: 50%;" align="right">Person with Disability</td>
                        <td style="width: 50%;">
                            <asp:DropDownList ID="ddlPHType" runat="Server" onmouseover="ddrivetip('Please Select Person with Disability.')" onmouseout="hideddrivetip()"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">Is Parent a Defence Personnel</td>
                        <td>
                            <asp:DropDownList ID="ddlDefenceType" runat="Server" onmouseover="ddrivetip('Please Select Is Parent a Defence Personnel.')" onmouseout="hideddrivetip()"></asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td align="right">Are you Orphan?</td>
                        <td>
                            <asp:DropDownList ID="ddlIsOrphan" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlIsOrphan_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Are you Orphan Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvIsOrphan" runat="server" ControlToValidate="ddlIsOrphan" Display="None" ErrorMessage="Please Select Are you Orphan." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trMinority" runat="server">
                        <td align="right">Do You Belongs to Minority Candidature Type ?</td>
                        <td>
                            <asp:DropDownList ID="ddlAppliedForMinoritySeats" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlAppliedForMinoritySeats_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Apply for Minority Seats Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="Not Applicable">-- Select --</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvAppliedForMinoritySeats" runat="server" ControlToValidate="ddlAppliedForMinoritySeats" Display="None" ErrorMessage="Please Select Apply for Minority Seats Status." Operator="NotEqual" ValueToCompare="Not Applicable"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trMinorityStatus" runat="server">
                        <td align="right">Your Minority Status</td>
                        <td>
                            <asp:CheckBox ID="chkLinguisticMinority" runat="server" Text="&nbsp;&nbsp;Linguistic Minority" GroupName="MinorityStatus" AutoPostBack="True" OnCheckedChanged="LinguisticMinorityStatus_CheckedChanged" onmouseover="ddrivetip('Please Select Your Minority Status.')" onmouseout="hideddrivetip()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkReligiousMinority" runat="server" Text="&nbsp;&nbsp;Religious Minority" GroupName="MinorityStatus" AutoPostBack="True" OnCheckedChanged="ReligiousMinorityStatus_CheckedChanged" onmouseover="ddrivetip('Please Select Your Minority Status.')" onmouseout="hideddrivetip()" />
                            <asp:CustomValidator ID="cvMinorityStatus" runat="server" ClientValidationFunction="checkMinorityStatus" Display="None" ErrorMessage="Please Select Your Minority Status."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id="trLinguisticMinority" runat="server">
                        <td align="right">Linguistic Minority Type</td>
                        <td>
                            <asp:DropDownList ID="ddlLinguisticMinority" runat="server" onmouseover="ddrivetip('Please Select Linguistic Minority Type.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvLinguisticMinority" runat="server" ControlToValidate="ddlLinguisticMinority" Display="None" ErrorMessage="Please Select Linguistic Minority Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trReligiousMinority" runat="server">
                        <td align="right">Religious Minority Type</td>
                        <td>
                            <asp:DropDownList ID="ddlReligiousMinority" runat="server" onmouseover="ddrivetip('Please Select Religious Minority Type.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvReligiousMinority" runat="server" ControlToValidate="ddlReligiousMinority" Display="None" ErrorMessage="Please Select Religious Minority Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
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
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>

