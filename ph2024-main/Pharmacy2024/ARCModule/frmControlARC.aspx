<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmControlARC.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmControlARC" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Add ARC">
        <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 25%">ARC Officer Name</td>
                <td style="width: 75%">
                    <asp:TextBox ID="txtARCOfficerName" runat="server" Width="200px" MaxLength="250"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvARCOfficerName" runat="server" ControlToValidate="txtARCOfficerName" ErrorMessage="Please Enter ARC Officer Name to be Added." Display="none" ValidationGroup="ADD"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">ARC Officer Mobile No</td>
                <td>
                    <asp:TextBox ID="txtARCOfficerMobileNo" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvARCOfficerMobileNo" runat="server" ControlToValidate="txtARCOfficerMobileNo" Display="None" ErrorMessage="Please Enter ARC Officer Mobile No to be Added." ValidationGroup="ADD"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revARCOfficerMobileNo" runat="server" ControlToValidate="txtARCOfficerMobileNo" Display="None" ErrorMessage="ARC Officer Mobile No to be Added Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$" ValidationGroup="ADD"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add ARC" OnClick="btnAdd_Click" CssClass="InputButton" ValidationGroup="ADD" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ADD" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox3" runat="server" HeaderText="Update ARC">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="25%">Select ARC</td>
                <td width="75%">
                    <asp:DropDownList ID="ddlARCUpdate" runat="server" Width="95%"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvARCUpdate" runat="server" ControlToValidate="ddlARCUpdate" ErrorMessage="Please Select ARC to be Updated." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="UPDATE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">ARC Officer Name</td>
                <td>
                    <asp:TextBox ID="txtARCOfficerNameUpdate" runat="server" Width="200px" MaxLength="250"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvARCOfficerNameUpdate" runat="server" ControlToValidate="txtARCOfficerNameUpdate" ErrorMessage="Please Enter ARC Officer Name to be Updated." Display="none" ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">ARC Officer Mobile No</td>
                <td>
                    <asp:TextBox ID="txtARCOfficerMobileNoUpdate" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvARCOfficerMobileNoUpdate" runat="server" ControlToValidate="txtARCOfficerMobileNoUpdate" Display="None" ErrorMessage="Please Enter ARC Officer Mobile No to be Updated." ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revARCOfficerMobileNoUpdate" runat="server" ControlToValidate="txtARCOfficerMobileNoUpdate" Display="None" ErrorMessage="ARC Officer Mobile No to be Updated Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$" ValidationGroup="UPDATE"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update ARC" OnClick="btnUpdate_Click" CssClass="InputButton" ValidationGroup="UPDATE" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UPDATE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Delete ARC">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="25%">Select ARC</td>
                <td width="75%">
                    <asp:DropDownList ID="ddlARCDelete" runat="server" Width="95%"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvARCDelete" runat="server" ControlToValidate="ddlARCDelete" ErrorMessage="Please Select ARC to be Deleted." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="DELETE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete ARC" OnClick="btnDelete_Click" CssClass="InputButton" ValidationGroup="DELETE" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="DELETE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
