<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditCancelAdmission.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmEditCancelAdmission" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script src="../Scripts/epoch_classes_current.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function numbersonly(e) 
        {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) 
            {
                if (unicode < 48 || unicode > 57) 
                {
                    return false
                }
            }
        }
        function checkPaymentMode(sender, args) 
        {
            if (document.getElementById("rightContainer_ContentTable2_rbnPaymentModeDD").checked || document.getElementById("rightContainer_ContentTable2_rbnPaymentModeCash").checked || document.getElementById("rightContainer_ContentTable2_rbnPaymentModeOnline").checked) 
            {
            }
            else 
            {
                args.IsValid = false;
            }
        }
        function isDDDateValid(sender, args) 
        {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtDDDate").value;
            if (dateStr.length == 0) 
            {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat); // is format OK?
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
        function checkConfirmation(Source, args) 
        {
            var confirmationValue = confirm("Are you sure you want to delete this Record ?");
            if (confirmationValue == true) 
            {
                var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                cvCheckConfirmation.errormessage = 'We are deleting this Record. Please wait...';
                args.IsValid = true;
            }
            else 
            {
                var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                cvCheckConfirmation.errormessage = 'We are not deleting this Record...';
                args.IsValid = false;
            }
        }
        function load() 
        {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() 
        {
            if (document.getElementById('rightContainer_ContentTable2_txtDDDate') != null) 
            {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDDDate'));
            }
        }
        window.onload = load;
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Edit Cancel Candidate Admission">
        <asp:UpdatePanel runat="server" ID="upConfirmAdmission">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <th align = "left" colspan = "4">Personal Details</th>
                    </tr>
                    <tr>
                        <td align="right">Application ID</td>
                        <td colspan = "3"><asp:Label id="lblApplicationID" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align = "right">Candidate Name</b></td>
                        <td colspan = "3"><asp:Label id="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align = "right">Gender</td>
                        <td style="width: 25%"><asp:Label id="lblGender" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td style="width: 25%" align="right">Date Of Birth</td>
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
                        <td align="right">Applied for EWS</td>
                        <td><asp:Label id="lblAppliedForEWS" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Applied for Orphan</td>
                        <td><asp:Label id="lblAppliedForOrphan" runat="server" Font-Bold = "true"></asp:Label></td>
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
                        <th align = "left" colspan = "4">Allotment Details</th>
                    </tr>
                    <tr>
                        <td align="right">Merit No</td>
                        <td><asp:Label id="lblMeritNo" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Merit Marks</td>
                        <td><asp:Label id="lblMeritMarks" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Institute Allotted</td>
                        <td colspan = "3"><asp:Label id="lblInstituteAllotted" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Course Allotted</td>
                        <td colspan = "3"><asp:Label id="lblCourseAllotted" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Seat Type Allotted</td>
                        <td><asp:Label id="lblSeatTypeAllotted" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Preference No. Allotted</td>
                        <td><asp:Label id="lblPreferenceNoAllotted" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <th align = "left" colspan = "4">Cancellation Charge Details</th>
                    </tr>
                    <tr>
                        <td align="right">Cancellation Charge (<span class="rupee">Rs.</span>)</td>
                        <td colspan = "3">
                            <asp:TextBox ID="txtCancellationCharge" runat="server" MaxLength = "7" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCancellationCharge" runat="server" ErrorMessage="Please Enter Cancellation Charge." ControlToValidate="txtCancellationCharge" Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCancellationCharge" runat="server" ErrorMessage="Cancellation Charge should be Numeric." ControlToValidate="txtCancellationCharge" Display="None" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align = "left">Refund Details</th>
                        <th align = "right" colspan = "3">Total Amount (<span class="rupee">Rs.</span>) : <asp:Label ID="lblTotalFeeAmount" runat="server"></asp:Label></th>
                    </tr>
                    <tr>
                        <td align = "right">Payment Mode</td>
                        <td colspan = "3">
                            <asp:RadioButton ID="rbnPaymentModeDD" runat="server" Text="&nbsp;&nbsp;Demand Draft / Cheque" GroupName="PaymentMode" AutoPostBack="true" OnCheckedChanged="PaymentMode_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnPaymentModeCash" runat="server" Text="&nbsp;&nbsp;Cash" GroupName="PaymentMode" AutoPostBack="true" OnCheckedChanged="PaymentMode_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnPaymentModeOnline" runat="server" Text="&nbsp;&nbsp;Online Transfer to Institute Account" GroupName="PaymentMode" AutoPostBack="true" OnCheckedChanged="PaymentMode_CheckedChanged" />
                            <asp:CustomValidator ID="cvPaymentMode" runat="server" ClientValidationFunction="checkPaymentMode" Display="None" ErrorMessage="Please Select Payment Mode." ValidationGroup = "AddUpdate"></asp:CustomValidator>
                        </td>
                    </tr>
		            <tr id = "trDD1" runat = "server"> 
		                <td align="right" colspan = "2">Demand Draft / Cheque Number</td>
                        <td colspan = "2">
                            <asp:TextBox ID="txtDDNumber" Runat="server" MaxLength="6" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvDDNumber" Runat="server" ErrorMessage="Please Enter Demand Draft / Cheque Number." ControlToValidate="txtDDNumber" Display="None" ValidationGroup = "AddUpdate"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revDDNumber" Runat="server" ErrorMessage="Demand Draft / Cheque Number should be numeric and of 6 digits." ControlToValidate="txtDDNumber" ValidationExpression="\d{6}" Display="None" ValidationGroup = "AddUpdate"></asp:RegularExpressionValidator>
                        </td>
	                </tr>
	                <tr id = "trDD2" runat = "server">
                        <td align="right" colspan = "2">Demand Draft / Cheque Amount (<span class="rupee">Rs.</span>)</td>
                        <td colspan = "2">
                            <asp:TextBox ID="txtDDAmount" Runat="server" MaxLength = "7" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvDDAmount" Runat="server" ErrorMessage="Please Enter Demand Draft / Cheque Amount." ControlToValidate="txtDDAmount" Display="None" ValidationGroup = "AddUpdate"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvDDAmount" Runat="server" ControlToValidate="txtDDAmount" ErrorMessage="Demand Draft / Cheque Amount sholud be numeric." Operator="DataTypeCheck" Type="Integer" Display="None" ValidationGroup = "AddUpdate"></asp:CompareValidator>
                        </td>
	                </tr>
    	            <tr id = "trDD3" runat = "server">
		                <td align="right" colspan = "2">Demand Draft / Cheque Date</td>
		                <td colspan = "2">
			                <asp:TextBox  ID="txtDDDate" runat="server" MaxLength="10"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvDDDate" Runat="server" ErrorMessage="Please Enter Demand Draft / Cheque Date." ControlToValidate="txtDDDate" Display="None" ValidationGroup = "AddUpdate"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvDDDate" runat="server" ControlToValidate="txtDDDate" ClientValidationFunction="isDDDateValid" Display="None" ErrorMessage="Please Select Proper DD Date." ValidationGroup = "AddUpdate"></asp:CustomValidator>
                        </td>
		            </tr>
	                <tr id = "trDD4" runat = "server">
                        <td align="right" colspan = "2">Drawee Bank Name</td>
                        <td colspan = "2">
                            <asp:DropDownList ID="ddlBankName" Runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBankName_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red">*</font>
                            <asp:CompareValidator ID="cvBankName" Runat="server" ControlToValidate="ddlBankName" ErrorMessage="Please Select Bank Name." ValueToCompare="0" Operator="NotEqual" Display="None" ValidationGroup = "AddUpdate"></asp:CompareValidator>
                        </td>
		            </tr>
		            <tr id = "trDD5" runat = "server">
                        <td align = "right" colspan = "2">Other Drawee Bank Name</td>
                        <td colspan = "2">
                            <asp:TextBox ID="txtOtherBankName" Runat="server" MaxLength="120"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvOtherBankName" Runat="server" ErrorMessage="Please Enter Other Drawee Bank Name." ControlToValidate="txtOtherBankName" Display="None" ValidationGroup = "AddUpdate"></asp:RequiredFieldValidator>
                        </td>
		            </tr>
	                <tr id = "trDD6" runat = "server">
                        <td align="right" colspan = "2">Drawee Branch Name</td>
                        <td colspan = "2">
                            <asp:TextBox ID="txtBranchName" Runat="server" MaxLength="100"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator id="rfvBranchName" Runat="server" Display="None" ControlToValidate="txtBranchName" ErrorMessage="Please Enter Drawee Branch Name." ValidationGroup = "AddUpdate"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id = "trCash" runat = "server">
                        <td align="right" colspan = "2">Amount (<span class="rupee">Rs.</span>)</td>
                        <td colspan = "2">
                            <asp:TextBox ID="txtCashAmount" Runat="server"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvCashAmount" Runat="server" ErrorMessage="Please Enter Cash / Online Transfered Amount." ControlToValidate="txtCashAmount" Display="None" ValidationGroup = "AddUpdate"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvCashAmount" Runat="server" ControlToValidate="txtCashAmount" ErrorMessage="Cash / Online Transfered Amount sholud be numeric." Operator="DataTypeCheck" Type="Integer" Display="None" ValidationGroup = "AddUpdate"></asp:CompareValidator>
                        </td>
	                </tr>
                    <tr id = "trFeeButtons" runat = "server">
                        <td align="center" colspan = "4">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="InputButton" OnClick="btnAdd_Click" ValidationGroup = "AddUpdate"/>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="InputButton" OnClick="btnUpdate_Click" ValidationGroup = "AddUpdate"/>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="InputButton" OnClick="btnDelete_Click" ValidationGroup = "Delete"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" OnClick="btnCancel_Click" ValidationGroup = "Cancel"/>
                            <asp:CustomValidator ID="cvCheckConfirmation" runat="server" ClientValidationFunction="checkConfirmation" Display = "None" ErrorMessage="" ValidationGroup = "Delete"></asp:CustomValidator>
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup = "Delete" />
                            <asp:ValidationSummary ID="ValidationSummary3" Runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup = "AddUpdate" />
                            <asp:HiddenField ID="hdnFeeID" runat="server" />
                        </td>
                    </tr>
                    <tr id = "trInstituteFeeList" runat = "server">
                        <td colspan = "4">
                            <asp:GridView ID="gvFeeList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth = "1px" CssClass="DataGrid" OnRowCommand = "gvFeeList_RowCommand">
                                <Columns>
                                    <asp:BoundField HeaderText="Sr. No.">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "5%" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "14%" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FeeAmount" HeaderText="Refund Amount (<span class='rupee'>Rs.</span>)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "10%" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DDNumber" HeaderText="DD/Cheque Number">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "10%" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DDDate" HeaderText="Payment Date">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "10%" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BankName" HeaderText="Bank Name">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "23%" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BranchName" HeaderText="Branch Name">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "18%" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "5%" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnEdit" runat="server" Text="Edit" CommandName="EditFee" CommandArgument='<%#Eval("FeeID") %>' ValidationGroup = "Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "5%" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete" CommandName="DeleteFee" CommandArgument='<%#Eval("FeeID") %>' ValidationGroup = "Del" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <th align = "left" colspan = "4">Other Details</th>
                    </tr>
                    <tr>
                        <td align="right">Reason of Cancellation</td>
                        <td colspan = "3"><asp:TextBox ID="txtRemark" runat="server" TextMode = "MultiLine" Width = "98%" Rows = "3"></asp:TextBox></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Edit Cancel Candidate Admission" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>