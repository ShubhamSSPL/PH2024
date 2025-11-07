<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmControlSubARC.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmControlSubARC" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Add Sub-ARC">
        <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 30%">Sub-ARC Officer Name</td>
                <td style="width: 70%">
                    <asp:TextBox ID="txtSubARCOfficerName" runat="server" Width="200px" MaxLength="250"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSubARCOfficerName" runat="server" ControlToValidate="txtSubARCOfficerName" ErrorMessage="Please Enter Sub-ARC Officer Name to be Added." Display="none" ValidationGroup="ADD"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Sub-ARC Officer Mobile No</td>
                <td>
                    <asp:TextBox ID="txtSubARCOfficerMobileNo" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSubARCOfficerMobileNo" runat="server" ControlToValidate="txtSubARCOfficerMobileNo" Display="None" ErrorMessage="Please Enter Sub-ARC Officer Mobile No to be Added." ValidationGroup="ADD"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revSubARCOfficerMobileNo" runat="server" ControlToValidate="txtSubARCOfficerMobileNo" Display="None" ErrorMessage="Sub-ARC Officer Mobile No to be Added Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$" ValidationGroup="ADD"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add Sub-ARC" OnClick="btnAdd_Click" CssClass="InputButton" ValidationGroup="ADD" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ADD" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox3" runat="server" HeaderText="Update Sub-ARC">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="30%">Select Sub-ARC</td>
                <td width="70%">
                    <asp:DropDownList ID="ddlSubARCUpdate" runat="server" Width="95%"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSubARCUpdate" runat="server" ControlToValidate="ddlSubARCUpdate" ErrorMessage="Please Select Sub-ARC to be Updated." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="UPDATE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Sub-ARC Officer Name</td>
                <td>
                    <asp:TextBox ID="txtSubARCOfficerNameUpdate" runat="server" Width="200px" MaxLength="250"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSubARCOfficerNameUpdate" runat="server" ControlToValidate="txtSubARCOfficerNameUpdate" ErrorMessage="Please Enter Sub-ARC Officer Name to be Updated." Display="none" ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Sub-ARC Officer Mobile No</td>
                <td>
                    <asp:TextBox ID="txtSubARCOfficerMobileNoUpdate" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSubARCOfficerMobileNoUpdate" runat="server" ControlToValidate="txtSubARCOfficerMobileNoUpdate" Display="None" ErrorMessage="Please Enter Sub-ARC Officer Mobile No to be Updated." ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revSubARCOfficerMobileNoUpdate" runat="server" ControlToValidate="txtSubARCOfficerMobileNoUpdate" Display="None" ErrorMessage="Sub-ARC Officer Mobile No to be Updated Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$" ValidationGroup="UPDATE"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Sub-ARC" OnClick="btnUpdate_Click" CssClass="InputButton" ValidationGroup="UPDATE" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UPDATE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Delete Sub-ARC">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="30%">Select Sub-ARC</td>
                <td width="70%">
                    <asp:DropDownList ID="ddlSubARCDelete" runat="server" Width="95%"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSubARCDelete" runat="server" ControlToValidate="ddlSubARCDelete" ErrorMessage="Please Select Sub-ARC to be Deleted." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="DELETE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete Sub-ARC" OnClick="btnDelete_Click" CssClass="InputButton" ValidationGroup="DELETE" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="DELETE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
