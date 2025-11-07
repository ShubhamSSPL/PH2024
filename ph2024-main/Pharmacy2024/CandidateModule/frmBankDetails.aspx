<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmBankDetails.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmBankDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <script>

        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        function checkAadhaarNumber() {
            document.getElementById("<%=chkConfirmAadhaarDeclaration.ClientID %>").checked = false;

            if (document.getElementById("<%=txtAadhaarNumber.ClientID %>").value.length == 12) {
                document.getElementById("<%=trAadhaarDeclaration.ClientID %>").style.display = '';
                document.getElementById("<%=cvValidateAadhaarDeclaration.ClientID %>").enabled = true;
            }
            else {
                document.getElementById("<%=trAadhaarDeclaration.ClientID %>").style.display = 'none';
                document.getElementById("<%=cvValidateAadhaarDeclaration.ClientID %>").enabled = false;
                document.getElementById("<%=chkConfirmAadhaarDeclaration.ClientID %>").checked = false;
            }
        }
        function validateAadhaarDeclaration(sender, args) {
            if (document.getElementById("<%=chkConfirmAadhaarDeclaration.ClientID %>").checked == true) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Aadhaar Linked Bank A/C Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <center> This information may be used for Direct Benefit Transfer (DBT) for various Scholarship schemes of Government of Maharashtra </center>

        <table class="AppFormTableWithAllBorder" id="tblAccountDetails" runat="server">
            <tr>
                <td align="right">Aadhaar Number</td>
                <td>
                    <asp:Label ID="lblAadharNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Bank Name</td>
                <td>
                    <asp:Label ID="lblBankName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">IFSC Code</td>
                <td>
                    <asp:Label ID="lblIFSCCode" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Bank Account No</td>
                <td>
                    <asp:Label ID="lblAccountNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Name of the Bank Account Holder</td>
                <td>
                    <asp:Label ID="lblHolderName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnUpdate" Visible="true" runat="server" Text="Update" CssClass="InputButton" OnClick="btnUpdate_Click" />
                </td>
            </tr>


        </table>



        <table class="AppFormTable" Id="tblEnterBankDetails" runat="server">
            <tr>
                <td align="right" colspan="4">
                    <div class="row ">
                        <div class="col-sm-12">
                            <div class="row  w-100 mx-auto">
                                <div class="col-4 col-lg-3 px-0 py-1">
                                    Aadhaar Number<br />
                                    <%-- आधार क्रमांक--%>
                                </div>
                                <div class="col-8 col-lg-8 text-left py-1">
                                    <asp:TextBox ID="txtAadhaarNumber" runat="server" Width="90%" MaxLength="12" autocomplete="off" onKeyUp="checkAadhaarNumber()" onKeyPress="return numbersonly(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revAadhaarNumber" runat="server" ControlToValidate="txtAadhaarNumber" Display="None" ErrorMessage="Aadhaar Number No Should be Proper and of 12 Digits." ValidationExpression="\d{12}$"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr id="trAadhaarDeclaration" runat="server">
                <td colspan="4">
                    <p align="justify">
                        <asp:CheckBox ID="chkConfirmAadhaarDeclaration" runat="server" />
                        <font color="red"> I, the holder of Aadhaar Number given above, hereby give my consent to DTE to obtain my Aadhaar number for authentication with UIDAI. DTE has informed me that my identity information would only be used for admission purpose and will be submitted to CIDR only for the purpose of authentication.</font>
                        <asp:CustomValidator ID="cvValidateAadhaarDeclaration" runat="server" Display="None" ClientValidationFunction="validateAadhaarDeclaration" ErrorMessage="Please Accept Declaration for Aadhaar."></asp:CustomValidator>
                    </p>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <div class="row w-100 mx-auto  ">
                        <div class="col-sm-6 px-0">
                            <div class="row w-100 mx-auto  ">
                                <div class="col-4 col-lg-6 px-0">
                                    Bank Name
                            <br />
                                    <%--भ्रमणध्वनी क्रमांक--%>
                                </div>
                                <div class="col-8 col-lg-6 text-left py-1">
                                    <asp:TextBox ID="txtBankName" runat="server" MaxLength="100" Width="90%" ValidationGroup="bankdetails"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvBankName" runat="server" ControlToValidate="txtBankName" Display="None" ErrorMessage="Please Enter Bank Name." ValidationGroup="bankdetails"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 px-0">
                            <div class="row w-100 mx-auto  ">
                                <div class="col-4 col-lg-3 px-0">
                                    IFSC Code
                            <br />
                                    <%--ई - मेल आयडी--%>
                                </div>
                                <div class="col-8 col-lg-6 text-left py-1">
                                    <asp:TextBox ID="txtIFSCCode" runat="server" MinLength="11" MaxLength="11" Width="90%" ValidationGroup="bankdetails"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="valMin" runat="server" ControlToValidate="txtIFSCCode" ErrorMessage=" Minimum length is 11" ValidationExpression=".{11}.*" Display="Dynamic" ValidationGroup="bankdetails" />
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvIFSCCode" runat="server" ControlToValidate="txtIFSCCode" Display="None" ErrorMessage="Please Enter IFSC Code." ValidationGroup="bankdetails"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto  ">
                        <div class="col-4 col-lg-3 pr-0">
                            Bank Account No
                    <br />
                            <%--संकेतशब्द निवडा--%>
                        </div>
                        <div class="col-8 col-lg-9 text-left py-2">
                            <asp:TextBox ID="txtBankAccountNo" runat="server" MaxLength="16" ValidationGroup="bankdetails"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtBankAccountNo" ErrorMessage="Enter Your Bank Account No." Display="None" ValidationGroup="bankdetails"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto  ">
                        <div class="col-4 col-lg-3 pr-0">
                            Re Enter Bank Account No
                    <br />
                            <%-- संकेतशब्दाची  पुष्टी करा--%>
                        </div>
                        <div class="col-8 col-lg-9 text-left py-2">
                            <asp:TextBox ID="txtReBankAccountNo" runat="server" TextMode="Password" MaxLength="16" ValidationGroup="bankdetails"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtReBankAccountNo" ErrorMessage="Please Re Enter Bank Account No." Display="None" ValidationGroup="bankdetails"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtReBankAccountNo" ControlToValidate="txtBankAccountNo" ErrorMessage="Account No and Re Enter Bank Account No should be Same." Display="None" ValidationGroup="bankdetails"></asp:CompareValidator>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" class="col-form-label" colspan="4">
                    <div class="row w-100 mx-auto  px-0 ">
                        <div class="col-4 col-lg-3 text-right px-0 py-1">
                            Name of the Bank Account Holder
                        <br />
                            <%-- उमेदवाराचे पूर्ण नाव--%>
                        </div>
                        <div class="col-8 col-lg-8 text-left py-1">

                            <div class="">
                                <asp:TextBox ID="txtAccountHolderName" CssClass="col-form-control " runat="server" Width="90%" MaxLength="60" ValidationGroup="bankdetails"></asp:TextBox>

                                <font color="red"><sup>*</sup></font>
                                <asp:RequiredFieldValidator ID="rfvCandidateName" runat="server" ErrorMessage="Please Enter Account Holder Name." ControlToValidate="txtAccountHolderName" Display="None" ValidationGroup="bankdetails"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorCandidateName" runat="server" ControlToValidate="txtAccountHolderName" Display="None" ErrorMessage="Special characters Not Allowed in Name of the Bank Account Holder." ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="bankdetails"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <div id="tblEnterBankButtonDetails" runat="server" class="AppFormTableWithOutBorder">
            <%--<table id="tblRegistrationLinks" runat="server" class="AppFormTableWithOutBorder">--%>
            <%--<tr>--%>
            <div class="row justify-content-center w-100 mx-auto">
                <div class="d-flex justify-content-center">
                    <asp:Button ID="btnProceed" runat="server" Text="SUbmit" CssClass="InputButton" OnClick="btnProceed_Click" ValidationGroup="bankdetails" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="bankdetails" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnSkip" Visible="true" runat="server" Text="Skip" CssClass="InputButton" OnClick="btnSkip_Click" />
                </div>
            </div>
            <%--</tr>
                </table>--%>
        </div>

        <br />
    </cc1:ContentBox>
    <script lang="javascript" type="text/javascript">
        checkAadhaarNumber();
    </script>
</asp:Content>
