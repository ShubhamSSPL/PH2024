<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmControlSubAFC.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmControlSubAFC" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Add Sub-SC">
        <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 30%">Sub-SC Officer Name</td>
                <td style="width: 70%">
                    <asp:TextBox ID="txtSubAFCOfficerName" runat="server" Width="200px" MaxLength="250"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSubAFCOfficerName" runat="server" ControlToValidate="txtSubAFCOfficerName" ErrorMessage="Please Enter Sub-SC Officer Name to be Added." Display="none" ValidationGroup="ADD"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Sub-SC Officer Mobile No</td>
                <td>
                    <asp:TextBox ID="txtSubAFCOfficerMobileNo" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSubAFCOfficerMobileNo" runat="server" ControlToValidate="txtSubAFCOfficerMobileNo" Display="None" ErrorMessage="Please Enter Sub-SC Officer Mobile No to be Added." ValidationGroup="ADD"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revSubAFCOfficerMobileNo" runat="server" ControlToValidate="txtSubAFCOfficerMobileNo" Display="None" ErrorMessage="Sub-SC Officer Mobile No to be Added Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$" ValidationGroup="ADD"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add Sub-SC" OnClick="btnAdd_Click" CssClass="InputButton" ValidationGroup="ADD" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ADD" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox3" runat="server" HeaderText="Update Sub-SC">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="30%">Select Sub-SC</td>
                <td width="70%">
                    <asp:DropDownList ID="ddlSubAFCUpdate" runat="server" Width="95%"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSubAFCUpdate" runat="server" ControlToValidate="ddlSubAFCUpdate" ErrorMessage="Please Select Sub-SC to be Updated." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="UPDATE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Sub-SC Officer Name</td>
                <td>
                    <asp:TextBox ID="txtSubAFCOfficerNameUpdate" runat="server" Width="200px" MaxLength="250"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSubAFCOfficerNameUpdate" runat="server" ControlToValidate="txtSubAFCOfficerNameUpdate" ErrorMessage="Please Enter Sub-SC Officer Name to be Updated." Display="none" ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Sub-SC Officer Mobile No</td>
                <td>
                    <asp:TextBox ID="txtSubAFCOfficerMobileNoUpdate" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSubAFCOfficerMobileNoUpdate" runat="server" ControlToValidate="txtSubAFCOfficerMobileNoUpdate" Display="None" ErrorMessage="Please Enter Sub-SC Officer Mobile No to be Updated." ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revSubAFCOfficerMobileNoUpdate" runat="server" ControlToValidate="txtSubAFCOfficerMobileNoUpdate" Display="None" ErrorMessage="Sub-SC Officer Mobile No to be Updated Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$" ValidationGroup="UPDATE"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Sub-SC" OnClick="btnUpdate_Click" CssClass="InputButton" ValidationGroup="UPDATE" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UPDATE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Delete Sub-SC">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="30%">Select Sub-SC</td>
                <td width="70%">
                    <asp:DropDownList ID="ddlSubAFCDelete" runat="server" Width="95%"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSubAFCDelete" runat="server" ControlToValidate="ddlSubAFCDelete" ErrorMessage="Please Select Sub-SC to be Deleted." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="DELETE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete Sub-SC" OnClick="btnDelete_Click" CssClass="InputButton" ValidationGroup="DELETE" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="DELETE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
