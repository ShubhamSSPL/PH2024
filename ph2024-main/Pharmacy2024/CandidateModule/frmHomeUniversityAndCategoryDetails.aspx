<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmHomeUniversityAndCategoryDetails.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmHomeUniversityAndCategoryDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
   
    <script src="../Scripts/epoch_classes.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function isAppDateValid(sender, args) 
        {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtAppDate").value;
            //Add Date current date validation
            var date = dateStr.substring(0, 2);
            var month = dateStr.substring(3, 5);
            var year = dateStr.substring(6, 10);
            var SleDate = new Date(year, month - 1, date);
            var CurDate = new Date();

            if (SleDate > CurDate) {
                //Do something..
                alert("Date Should Not Be Greater Than Today!");
                args.IsValid = false;
                return;
            }
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
        function isNCLApplicationDateValid(sender, args) 
        {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtNCLApplicationDate").value;
            //Add Date current date validation
            var date = dateStr.substring(0, 2);
            var month = dateStr.substring(3, 5);
            var year = dateStr.substring(6, 10);
            var SleDate = new Date(year, month - 1, date);
            var CurDate = new Date();

            if (SleDate > CurDate) {
                //Do something..
                alert("Date Should Not Be Greater Than Today!");
                args.IsValid = false;
                return;
            }
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

        function isEWSApplicationDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtEWSApplicationDate").value;
            //Add Date current date validation
            var date = dateStr.substring(0, 2);
            var month = dateStr.substring(3, 5);
            var year = dateStr.substring(6, 10);
            var SleDate = new Date(year, month - 1, date);
            var CurDate = new Date();

            if (SleDate > CurDate) {
                //Do something..
                alert("Date Should Not Be Greater Than Today!");
                args.IsValid = false;
                return;
            }
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
        function load() 
        {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() 
        {
            if (document.getElementById('rightContainer_ContentTable2_txtAppDate') != null) 
            {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtAppDate'));
            }
            if (document.getElementById('rightContainer_ContentTable2_txtNCLApplicationDate') != null) 
            {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtNCLApplicationDate'));
            }
            if (document.getElementById('rightContainer_ContentTable2_txtEWSApplicationDate') != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtEWSApplicationDate'));
            }
        }
        window.onload = load;
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Home University & Category Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upHomeUniversity">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <th colspan="2" align="left">
                            Home University Details
                        </th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblCandidatureType" runat="server" Text="Your Type of Candidature : "></asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" id="trDocumentForTypeA">
                        <td align="right">
                            Select Type of Document required for uploading (Type-A) <br /> प्रकार -अ साठीचे प्रमाणपत्र निवडा
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDocumentForTypeA" runat="server" onmouseover="ddrivetip('Select Type of Document required for uploading (Type-A)')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvDocumentForTypeA" runat="server" ControlToValidate="ddlDocumentForTypeA" Display="None" ErrorMessage="Please Select Type of Document required for uploading (Type-A)." Operator="NotEqual" ValueToCompare="N"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trDocumentOf">
                        <td align="right">
                            <asp:Label ID="QDocumentOf" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDocumentOf" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDocumentOf_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvDocumentOf" runat="server" ControlToValidate="ddlDocumentOf" Display="None" ErrorMessage="" ValueToCompare="N" Operator="NotEqual" ></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trMothersName">
                        <td align="right">
                            Enter Mother's Name as appeared in Domicile Certificate

                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtMothersName" runat="server" onmouseover="ddrivetip('Enter Mother's Name as appeared in Domicile Certificate.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvMothersName" runat="server" ControlToValidate="txtMothersName" Display="None" ErrorMessage="Please Enter Mother's Name as appeared in Domicile Certificate."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trQ1">
                        <td align="right">
                            <asp:Label ID="lblQ1" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistrict1" runat="server" onmouseover="ddrivetip('Select District from which Candidate has Passed SSC')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvDistrict1" runat="server" Display="None" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlDistrict1" ErrorMessage=""></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trQ2">
                        <td align="right">
                            <asp:Label ID="lblQ2" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistrict2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict2_SelectedIndexChanged" onmouseover="ddrivetip('Select District from which Candidate has Passed HSC / Diploma')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvDistrict2" runat="server" Display="None" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlDistrict2" ErrorMessage=""></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trQ21">
                        <td align="right">
                            <asp:Label ID="lblQ21" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTaluka2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTaluka2_SelectedIndexChanged" onmouseover="ddrivetip('Select Taluka from which Candidate has Passed HSC / Diploma')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvTaluka2" runat="server" Display="None" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlTaluka2" ErrorMessage=""></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr runat = "server" id = "trQ31Village">
                        <td style = "width:50%;" align = "right"><asp:Label id="lblQ31Village" Runat="server"></asp:Label></td>
                        <td style = "width:50%;">
                            <asp:DropDownList id="ddlQ31Village" Runat="server"></asp:DropDownList>
	                        <font color = "red"><sup>*</sup></font>
	                        <asp:CompareValidator id="cvVillage2" Runat="server" Display="None" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlQ31Village"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%;" align="right">
                            Your Home University<br /> मुळ विद्यापीठ
                        </td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblHomeUniversity" runat="Server" Font-Bold="true"></asp:Label>
                            <asp:HiddenField ID="hdnHomeUniversityID" runat="server" />
                        </td>
                    </tr>
                    <tr runat="server" id="trCategoryHead">
                        <th colspan="2" align="left" style="border-top-width: 0px;">
                            Category Details
                        </th>
                    </tr>
                    <tr runat="server" id="trCategory">
                        <td align="right">
                            Select Category to Which You Belong<br />आपला जात प्रवर्ग निवडा
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" Width="90%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" onmouseover="ddrivetip('Select Category to Which You Belong')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCategory" runat="server" ControlToValidate="ddlCategory" Display="None" ErrorMessage="Please Select Category." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trAppliedForEWS1" runat="server" visible="false">
                        <td align="right">
                            Your Annual Family Income<br /> कौटुंबिक वार्षिक उत्पन्न

                        </td>
                        <td>
                            <asp:Label ID="lblAnnualFamilyIncome" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trAppliedForEWS2" runat="server" visible="false">
                        <td align="right">
                            Do you want to Apply for EWS (Economically Weaker Section) Seats ?<br />आपण ईडब्ल्यूएस (आर्थिकदृष्ट्या कमकुवत विभाग) जागांसाठी अर्ज करू इच्छिता?

                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAppliedForEWS" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlAppliedForEWS_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Apply for EWS Seats Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvews" runat="server" ControlToValidate="ddlAppliedForEWS" Display="None" ErrorMessage="Please Select Apply for EWS Seats Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                            <asp:Label ID="lblAppliedForEWS" runat="server" ForeColor="red" Font-Bold="true" Visible="false">You are Not Eligible for EWS Seats because Your Parents having Annual Income Above 8 Lacs.</asp:Label>
                            <asp:HyperLink ID="hlEWSProforma" runat="server" Visible="false" NavigateUrl="~/SampleDocuments/ProformaV.pdf" Target="_blank" Text="Click here for required format of Proforma - V"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr runat="server" id="trOpenCaste">
                        <td align="right">
                            Enter Caste Name<br />जातीचे नाव प्रविष्ट करा

                        </td>
                        <td>
                            <asp:TextBox ID="txtCasteNameForOpen" runat="server" MaxLength="100" autocomplete="off" onmouseover="ddrivetip('Enter Caste Name.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCasteNameForOpen" runat="server" ErrorMessage="Please Enter Caste Name." ControlToValidate="txtCasteNameForOpen" Display="None"></asp:RequiredFieldValidator>
                            <%--<ajaxToolkit:AutoCompleteExtender runat="server" BehaviorID="AutoCompleteEx" ID="autoComplete1" TargetControlID="txtCasteNameForOpen" ServicePath="~/Services/AutoComplete/AutoComplete.asmx" ServiceMethod="GetOpenCastList" MinimumPrefixLength="2" CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20" CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" DelimiterCharacters=";, :">
                                <Animations>
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
                                </Animations>
                            </ajaxToolkit:AutoCompleteExtender>--%>
                        </td>
                    </tr>
                    <tr runat="server" id="trReservedCaste">
                        <td align="right">
                            Select Caste to Which You Belong<br />आपल्या जातीचे नाव निवडा
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCaste" Width="90%" runat="server" onmouseover="ddrivetip('Select Caste to Which You Belong.')" onmouseout="hideddrivetip()" ></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCaste" runat="server" ControlToValidate="ddlCaste" Display="None" ErrorMessage="Please Select Caste." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trCasteValidityStatus">
                        <td align="right">
                            Select Caste / Tribe Validity Certificate Status <br /> जात / जमात वैधता प्रमाणपत्राची स्थिती निवडा
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCasteValidityStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCasteValidityStatus_SelectedIndexChanged" onmouseover="ddrivetip('Select Caste / Tribe Validity Certificate Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="R">Available</asp:ListItem>
                                <asp:ListItem Value="A">Applied but Not Received</asp:ListItem>
                                <%--<asp:ListItem Value="N">Not Applied</asp:ListItem>--%>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCasteValidityStatus" runat="server" ControlToValidate="ddlCasteValidityStatus" Display="None" ErrorMessage="Please Select Caste / Tribe Validity Certificate Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>                    
                </table>
                <table runat="server" id="tblCasteValidityApplied" class="AppFormTable">
                    <tr>
                        <td style="width: 50%;border-top-width: 0px;" align="right">
                            Caste / Tribe Validity Certificate Application Number
                        </td>
                        <td style="width: 50%;border-top-width: 0px;">
                            <asp:TextBox ID="txtCVCApplicationNo" runat="server" onmouseover="ddrivetip('Enter Caste/Tribe Validity Certificate Application Number')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCVCApplicationNo" runat="server" ErrorMessage="Please Enter Caste / Tribe Validity Certificate Application Number." ControlToValidate="txtCVCApplicationNo" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Caste / Tribe Validity Certificate Application Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtAppDate" runat="server" onmouseover="ddrivetip('Enter Caste/Tribe Validity Certificate Application Date')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvAppDate" runat="server" ErrorMessage="Please Enter  Caste / Tribe Validity Certificate Application Date." ControlToValidate="txtAppDate" Display="None"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvAppDate" runat="server" ControlToValidate="txtAppDate" ClientValidationFunction="isAppDateValid" Display="None" ErrorMessage="Please Select Proper Caste / Tribe Validity Certificate Application Date."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Caste / Tribe Validity Certificate Issuing Authority Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtCVCAuthority" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCVCAuthority" runat="server" ErrorMessage="Please Enter Caste / Tribe Validity Certificate Issuing Authority Name." ControlToValidate="txtCVCAuthority" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Caste / Tribe Validity Certificate Issuing District
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCVCDistrict" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCVCDistrict" runat="server" Display="None" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlCVCDistrict" ErrorMessage="Please Select Caste / Tribe Validity Certificate Issuing District."></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Name As Per Caste / Tribe Validity Certificate
                        </td>
                        <td>
                            <asp:TextBox ID="txtCVCName" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCVCName" runat="server" ErrorMessage="Please Enter Name As Per Caste / Tribe Validity Certificate." ControlToValidate="txtCVCName" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Caste Certificate Number
                        </td>
                        <td>
                            <asp:TextBox ID="txtCCNumber" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvCCNumber" runat="server" ErrorMessage="Please Enter Caste Certificate Number." ControlToValidate="txtCCNumber" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="AppFormTable">
                    <tr runat="server" id="trNCLStatus">
                        <td style="width: 50%;border-top-width: 0px;" align="right">
                            Select Non-Creamy Layer Certificate Status<br />उन्नत / प्रगत गटात मोडत असलेल्या प्रमाणपत्राची स्थिती निवडा

                        </td>
                        <td style="width: 50%;border-top-width: 0px;">
                            <asp:DropDownList ID="ddlNCLStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNCLStatus_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Non-Creamy Layer Certificate Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="R">Available</asp:ListItem>
                                <%--<asp:ListItem Value="A">Applied but Not Received</asp:ListItem>
                                <asp:ListItem Value="N">Not Applied</asp:ListItem>--%>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvNCLStatus" runat="server" ControlToValidate="ddlNCLStatus" Display="None" ErrorMessage="Please Select Non-Creamy Layer Certificate Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                <table runat="server" id="tblNCLApplied" class="AppFormTable">
                    <tr>
                        <td align="right" style="width: 50%; border-top-width: 0px;">
                            Non-Creamy Layer Certificate Application Number<br />नॉन-क्रीमी लेयर प्रमाणपत्र अर्ज क्रमांक
                        </td>
                        <td style="width: 50%; border-top-width: 0px;">
                            <asp:TextBox ID="txtNCLApplicationNo" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvNCLApplicationNo" runat="server" ErrorMessage="Please Enter Non-Creamy Layer Certificate Application Number." ControlToValidate="txtNCLApplicationNo" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Non-Creamy Layer Certificate Application Date<br />नॉन-क्रीमी लेयर प्रमाणपत्र अर्ज करण्याची तारीख
                        </td>
                        <td>
                            <asp:TextBox ID="txtNCLApplicationDate" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvNCLApplicationDate" runat="server" ErrorMessage="Please Enter Non-Creamy Layer Certificate Application Date." ControlToValidate="txtNCLApplicationDate" Display="None"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvNCLApplicationDate" runat="server" ControlToValidate="txtNCLApplicationDate" ClientValidationFunction="isNCLApplicationDateValid" Display="None" ErrorMessage="Please Select Proper Non-Creamy Layer Certificate Application Date."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Non-Creamy Layer Certificate Issuing Authority Name<br />उन्नत किंवा प्रगत गटात मोडत नसल्याबाबतचे शासनाच्या समकक्ष प्राधिकारणाने निर्गमित केलेले प्रमाणपत्र
                        </td>
                        <td>
                            <asp:TextBox ID="txtNCLAuthority" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvNCLAuthority" runat="server" ErrorMessage="Please Enter Non-Creamy Layer Certificate Issuing Authority Name." ControlToValidate="txtNCLAuthority" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table class="AppFormTable">
                    <tr runat="server" id="trEWSStatus">
                        <td style="width: 50%; border-top-width: 0px;" align="right">Select EWS Certificate Status<br />
                            ईडब्ल्यूएस (आर्थिक दृष्ट्या दुर्बल घटक ) प्रमाणपत्राची स्थिती निवडा
                        </td>
                        <td style="width: 50%; border-top-width: 0px;">
                            <asp:DropDownList ID="ddlEWSStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEWSStatus_SelectedIndexChanged" onmouseover="ddrivetip('Please Select EWS Certificate Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="R">Available</asp:ListItem>
                                <%--<asp:ListItem Value="A">Applied but Not Received</asp:ListItem>
                                <asp:ListItem Value="N">Not Applied</asp:ListItem>--%>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvEWSStatus" runat="server" ControlToValidate="ddlEWSStatus" Display="None" ErrorMessage="Please Select EWS Certificate Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                 <table runat="server" id="tblEWSApplied" class="AppFormTable">
                    <tr>
                        <td align="right" style="width: 50%; border-top-width: 0px;">EWS Certificate Application Number<br />
                            ईडब्ल्यूएस (आर्थिक दृष्ट्या दुर्बल घटक ) प्रमाणपत्राचा अर्ज क्रमांक
                        </td>
                        <td style="width: 50%; border-top-width: 0px;">
                            <asp:TextBox ID="txtEWSApplicationNo" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvEWSApplicationNo" runat="server" ErrorMessage="Please Enter EWS Certificate Application Number." ControlToValidate="txtEWSApplicationNo" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">EWS Certificate Application Date<br />
                            ईडब्ल्यूएस (आर्थिक दृष्ट्या दुर्बल घटक ) प्रमाणपत्राचा अर्ज दिनांक
                        </td>
                        <td>
                            <asp:TextBox ID="txtEWSApplicationDate" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvEWSApplicationDate" runat="server" ErrorMessage="Please Enter EWS Certificate Application Date." ControlToValidate="txtEWSApplicationDate" Display="None"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvEWSApplicationDate" runat="server" ControlToValidate="txtEWSApplicationDate" ClientValidationFunction="isEWSApplicationDateValid" Display="None" ErrorMessage="Please Select Proper EWS Certificate Application Date."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr >
                        <td align="right">EWS Certficate Issuing District<br />
                            ईडब्ल्यूएस (आर्थिक दृष्ट्या दुर्बल घटक ) प्रमाणपत्र निर्गमित प्राधिकरणाचे जिल्हा
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEWSDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEWSDistrict_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvDistrictEWS" runat="server" Display="None" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlEWSDistrict" ErrorMessage="Please Select the EWS Certificate Issuing District."></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"> EWS Certficate Issuing Taluka<br />
                           ईडब्ल्यूएस (आर्थिक दृष्ट्या दुर्बल घटक ) प्रमाणपत्र निर्गमित प्राधिकरणाचे तालुका 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEWSTaluka" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvTalukaEWS" runat="server" Display="None" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlEWSTaluka" ErrorMessage="Please Select the EWS Certificate Issuing Taluka."></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                <table class="AppFormTable">
                    <tr>
                        <td style="border-top-width: 0px;">
                            <font color="red"><b>Instructions :</b></font>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction1">
                        <td style="border-top-width: 0px;">
                            <asp:Label ID="lblRequiredDocumentsByCandidatureType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction2">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload the Caste Certificate clearly mentioning the Category of the Candidate and also the remarks that the Caste is recognised as backward class in the State of Maharashtra.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction3">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload the Caste / Tribe Validity Certificate in the name of the Candidate, issued by the caste validity committee of Maharashtra State.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction4">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red" size="2"><b>Due to Non Availability of the Caste / Tribe Validity Certificate, Category benefit can not be Claimed</b>.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction5">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Non-Creamy Layer Certificate issued by Sub Divisional officer or Deputy Collector of the district in addition to the caste certificate valid upto 31st March <%=NextYear%>.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction6">
                        <td style="border-top-width:0px;">
                            <p align = "justify"><font color = "red" size="2"><b>Due to Non Availability of Non-Creamy Layer Certificate, Category benefit can not be Claimed.</b></font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction7">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Eligibility Certificate for Economically Weaker Section.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction8">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Receipt of Submission of Application Form for Caste / Tribe Validity Certificate.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction9">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Receipt of Submission of Application Form for Non-Creamy Layer Certificate.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction10">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Receipt of Submission of Application Form for Eligibility Certificate for Economically Weaker Section.</font></p>
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
    <script language="javascript" type="text/javascript">
        if (document.getElementById('rightContainer_ContentTable2_txtAppDate') != null) 
        {
            var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtAppDate'));
        }
        if (document.getElementById('rightContainer_ContentTable2_txtNCLApplicationDate') != null) 
        {
            var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtNCLApplicationDate'));
        }
    </script>
</asp:Content>

