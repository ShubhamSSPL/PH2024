<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSeatAcceptanceFeeDetails.aspx.cs" Inherits="Pharmacy2024.CandidateAdmissionReportingModule.frmSeatAcceptanceFeeDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/epoch_classes_current.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        function checkPaymentMode(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnOnline").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
        function isDDDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtDDDate").value;
            if (dateStr.length == 0) {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat); // is format OK?
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
            if (document.getElementById('rightContainer_ContentTable2_txtDDDate') != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDDDate'));
            }
        }
        window.onload = load;
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Pay Seat Acceptance Fee">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upQualification">
            <ContentTemplate>
                <table class="AppFormTableWithOutBorder">
                    <td>
                            <font color="red">	
                                <ol class="list-text"><b>Instructions :</b><br /><br />
                                    <li><p align = "justify"><font color = "red">The Seat Acceptance Fee is <b>Rs. 1,000/-</b> for All Candidates.</font></p></li>
                                    <li><p align = "justify"><font color = "red">The candidate can pay the seat acceptance fee by Online Mode.</font></p></li>
                                    <li><p align = "justify"><font color = "red">The Candidate has to pay the Seat Acceptance Fees Rs 1000 rupees(Non-Refundable) during First Seat Acceptance only.</font></p></li>
                                    <li><p align = "justify"><font color = "red">Fail to complete online seat Acceptance during the given time period will be considered as - 'the Candidate has Rejected the Offered Seat'.</font></p></li>
                                    <li><p align = "justify"><font color = "red">You will not able to change your Seat acceptance status after Payment.</font></p></li>
                                </ol>
                            </font>
                            <br />
                        </td>
                </table>
                <table id="tblSeatAcceptanceStatusDetails" runat="server" class="AppFormTable" visible="false">
                    <tr>
                        <th style="border-top-width: 0px;" align="left" colspan="4">Seat Acceptance Details</th>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="right">
                            <div class="row w-100 mx-auto">
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                         Your Seat Acceptance Status is :
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:Label ID="lblSeatAcceptanceStatus" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-4 col-lg-6 px-0">
                                           Self Confirmation Status
                                        </div>
                                        <div class="col-8 col-lg-6 text-left pt-2">
                                            <asp:Label ID="lblSeatAcceptanceConfirmationDetails" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>

                    </tr>
                </table>
                <br />
                <br />
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 30%" align="right">Select Payment Mode</td>
                        <td style="width: 70%">
                            <asp:RadioButton ID="rbnOnline" runat="server" GroupName="PaymentMode" Text="&nbsp;&nbsp;Online (Credit Card / Debit Card / Net Banking)" AutoPostBack="true" OnCheckedChanged="PaymentMode_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnDD" runat="server" GroupName="PaymentMode" Text="&nbsp;&nbsp;Demand Draft" AutoPostBack="true" OnCheckedChanged="PaymentMode_CheckedChanged" Visible="false" />
                            <asp:CustomValidator ID="cvPaymentMode" runat="server" ClientValidationFunction="checkPaymentMode" Display="None" ErrorMessage="Please Select Payment Mode."></asp:CustomValidator>
                        </td>
                    </tr>
                </table>
                <table class="AppFormTable" id="tblDDDetails" runat="server">
                    <tr>
                        <td style="width: 25%; border-top-width: 0px;" align="right">DD Amount (<span class="rupee">Rs.</span>)</td>
                        <td style="width: 25%; border-top-width: 0px;">
                            <asp:TextBox ID="txtDDAmount" runat="server" Width="89%" Enabled="false" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvDDAmount" runat="server" ErrorMessage="Please Enter DD Amount." ControlToValidate="txtDDAmount" Display="None"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 25%; border-top-width: 0px;" align="right">DD Number</td>
                        <td style="width: 25%; border-top-width: 0px;">
                            <asp:TextBox ID="txtDDNumber" runat="server" Width="89%" MaxLength="6" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvDDNo" runat="server" ErrorMessage="Please Enter DD Number." ControlToValidate="txtDDNumber" Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revDDNo" runat="server" ErrorMessage="DD Number should be Numeric and of 6 Digits." ControlToValidate="txtDDNumber" ValidationExpression="\d{6}" Display="None"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">DD Date</td>
                        <td>
                            <asp:TextBox ID="txtDDDate" runat="server" MaxLength="10" Width="40%"></asp:TextBox>
                            <font color="red"><b>*</b></font> <font size="1">(DD/MM/YYYY)</font>
                            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="Please Enter DD Date." ControlToValidate="txtDDDate" Display="None"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvDDDate" runat="server" ControlToValidate="txtDDDate" ClientValidationFunction="isDDDateValid" Display="None" ErrorMessage="Please Select Proper DD Date."></asp:CustomValidator>
                        </td>
                        <td align="right">Bank Name</td>
                        <td>
                            <asp:DropDownList ID="ddlBankName" runat="server" Width="89%" AutoPostBack="true" OnSelectedIndexChanged="ddlBankName_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red">*</font>
                            <asp:CompareValidator ID="cvBankName" runat="server" ControlToValidate="ddlBankName" ErrorMessage="Please Select Bank Name." ValueToCompare="0" Operator="NotEqual" Display="None"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trOtherBankName" runat="server">
                        <td align="right">Other Bank Name</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtOtherBankName" runat="server" MaxLength="100"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvOtherBankName" runat="server" ErrorMessage="Please Enter Other Bank Name." ControlToValidate="txtOtherBankName" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Branch Name</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtBranchName" runat="server" MaxLength="100"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvBranchName" runat="server" Display="None" ControlToValidate="txtBranchName" ErrorMessage="Please Enter Branch Name."></asp:RequiredFieldValidator>
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
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                    <asp:HiddenField ID="hdnFeeID" runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <script language="javascript" type="text/javascript">
            if (document.getElementById('ctl00_rightContainer_ContentTable2_txtDDDate') != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable2_txtDDDate'));
            }
        </script>
    </cc1:ContentBox>
</asp:Content>
