<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmControlSO.aspx.cs" Inherits="Pharmacy2024.MVModule.frmControlSO" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <script type="text/javascript">
        function AllowAlphabet(e) 
        { 
            isIE = document.all ? 1 : 0 
            keyEntry = !isIE ? e.which : event.keyCode; 
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
                return true;
            else 
            { 
                /*alert('Please Enter Only Character values.'); */
                return false;
            }
        }
    </script>

    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Add Scrutiny Officer">
        <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 30%">Scrutiny Officer Name</td>
                <td style="width: 70%">
                    <asp:TextBox ID="txtSOName" runat="server" Width="500px" MaxLength="250" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RegularExpressionValidator id="valRegEx" runat="server"  ControlToValidate="txtSOName"  ValidationExpression="[^a-z][A-Z]+$"
                    ErrorMessage="* entry only character value."  display="dynamic">* </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvSOName" runat="server" ControlToValidate="txtSOName" ErrorMessage="Please Enter Scrutiny Officer Name to be Added." Display="none" ValidationGroup="ADD"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Scrutiny Officer Mobile No</td>
                <td><%--txtSubAFCOfficerMobileNo--%>
                    <asp:TextBox ID="txtSOMobileNo" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvtxtSOMobileNo" runat="server" ControlToValidate="txtSOMobileNo" Display="None" ErrorMessage="Please Enter Scrutiny Officer Mobile No to be Added." ValidationGroup="ADD"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revtxtSOMobileNo" runat="server" ControlToValidate="txtSOMobileNo" Display="None" ErrorMessage="Scrutiny Officer Mobile No to be Added Should be Proper and of 10 Digits." ValidationExpression="^[7-9]\d{9}$" ValidationGroup="ADD"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Scrutiny Officer Email Id</td>
                <td>
                    <asp:TextBox ID="txtSOEmailId" runat="server" MaxLength="100" Width="500px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvtxtSOEmailId" runat="server" ControlToValidate="txtSOEmailId" Display="None" ErrorMessage="Please Enter E-Mail ID."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revtxtSOEmailId" runat="server" ControlToValidate="txtSOEmailId" Display="Dynamic" ErrorMessage="Please Enter Valid E-Mail ID." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Scrutiny Officer Designation</td>
                <td>
                    <asp:TextBox ID="txtSODesignation" runat="server" MaxLength="100" Width="500px" TextMode="MultiLine" Height="75px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:Label ID="lblSODesignation" runat="server" Width="300px" Height="75px" ForeColor="Red"
                        Text="Enter Designation in Detail. For eg. Lecturer Electronics, Govt. Polytechnic, Mumbai"></asp:Label>
                    <font color="red"></font>
                    <asp:RequiredFieldValidator ID="rfvtxtSODesignation" runat="server" ControlToValidate="txtSODesignation" Display="None" ErrorMessage="Please Enter Scrutiny Officer Designation to be Added." ValidationGroup="ADD"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add SO" OnClick="btnAdd_Click" CssClass="InputButton" ValidationGroup="ADD" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ADD" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox3" runat="server" HeaderText="Update Scrutiny Officer">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="30%">Select Srutiny Officer</td>
                <td width="70%">
                    <asp:DropDownList ID="ddlSOUpdate" runat="server" Width="95%" AutoPostBack="true" OnSelectedIndexChanged="ddlSOUpdate_SelectedIndexChanged"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSOUpdate" runat="server" ControlToValidate="ddlSOUpdate" ErrorMessage="Please Select Srutiny Officer to be Updated." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="UPDATE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Scrutiny Officer Name</td>
                <td>
                    <asp:TextBox ID="txtScrutinyOfficerNameUpdate" runat="server" Width="500px" MaxLength="250"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvScrutinyOfficerNameUpdate" runat="server" ControlToValidate="txtScrutinyOfficerNameUpdate" ErrorMessage="Please Enter Srutiny Officer Name to be Updated." Display="none" ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Scrutiny Officer Mobile No</td>
                <td>
                    <asp:TextBox ID="txtScrutinyOfficerMobileNoUpdate" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSubAFCOfficerMobileNoUpdate" runat="server" ControlToValidate="txtScrutinyOfficerMobileNoUpdate" Display="None" ErrorMessage="Please Enter Srutiny Officer Mobile No to be Updated." ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revSubAFCOfficerMobileNoUpdate" runat="server" ControlToValidate="txtScrutinyOfficerMobileNoUpdate" Display="None" ErrorMessage="Srutiny Officer Mobile No to be Updated Should be Proper and of 10 Digits." ValidationExpression="^[7-9]\d{9}$" ValidationGroup="UPDATE"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Scrutiny Officer  Email Id</td>
                <td>
                    <asp:TextBox ID="txtScrutinyOfficerEmailIDUpdate" runat="server" MaxLength="100" Width="500px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvScrutinyOfficerEmailIDUpdate" runat="server" ControlToValidate="txtScrutinyOfficerEmailIDUpdate" Display="None" ErrorMessage="Please Enter E-Mail ID."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revScrutinyOfficerEmailIDUpdate" runat="server" ControlToValidate="txtScrutinyOfficerEmailIDUpdate" Display="None" ErrorMessage="Please Enter Valid E-Mail ID." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td align="right">Scrutiny Officer Designation</td>
                <td>
                    <asp:TextBox ID="txtScrutinyOfficerDesignationUpdate" runat="server" MaxLength="150" Width="500px" Height="75px" TextMode="MultiLine"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:Label ID="lblScrutinyOfficerDesignationUpdate" runat="server" Width="300px" Height="75px" ForeColor="Red"
                        Text="Enter Designation in Detail. For eg. Lecturer Electronics, Govt. Polytechnic, Mumbai"></asp:Label>
                    <font color="red"> </font>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtScrutinyOfficerDesignationUpdate" Display="None" ErrorMessage="Please Enter Scrutiny Officer Designation to be Updated." ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update SO" OnClick="btnUpdate_Click" CssClass="InputButton" ValidationGroup="UPDATE" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UPDATE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Delete Scrutiny Officer">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="30%">Select Srutiny Officer</td>
                <td width="70%">
                    <asp:DropDownList ID="ddlSODelete" runat="server" Width="95%"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSubAFCDelete" runat="server" ControlToValidate="ddlSODelete" ErrorMessage="Please Select Srutiny Officer to be Deleted." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="DELETE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete SO" OnClick="btnDelete_Click" CssClass="InputButton" ValidationGroup="DELETE" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="DELETE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
