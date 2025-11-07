<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmControlAFC.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmControlAFC" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Add SC">
        <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 25%">SC Officer Name</td>
                <td style="width: 75%">
                    <asp:TextBox ID="txtAFCOfficerName" runat="server" Width="200px" MaxLength="250"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvAFCOfficerName" runat="server" ControlToValidate="txtAFCOfficerName" ErrorMessage="Please Enter SC Officer Name to be Added." Display="none" ValidationGroup="ADD"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">SC Officer Mobile No</td>
                <td>
                    <asp:TextBox ID="txtAFCOfficerMobileNo" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvAFCOfficerMobileNo" runat="server" ControlToValidate="txtAFCOfficerMobileNo" Display="None" ErrorMessage="Please Enter SC Officer Mobile No to be Added." ValidationGroup="ADD"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revAFCOfficerMobileNo" runat="server" ControlToValidate="txtAFCOfficerMobileNo" Display="None" ErrorMessage="SC Officer Mobile No to be Added Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$" ValidationGroup="ADD"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add SC" OnClick="btnAdd_Click" CssClass="InputButton" ValidationGroup="ADD" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ADD" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox3" runat="server" HeaderText="Update SC">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="25%">Select SC</td>
                <td width="75%">
                    <asp:DropDownList ID="ddlAFCUpdate" runat="server" Width="95%"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvAFCUpdate" runat="server" ControlToValidate="ddlAFCUpdate" ErrorMessage="Please Select SC to be Updated." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="UPDATE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">SC Officer Name</td>
                <td>
                    <asp:TextBox ID="txtAFCOfficerNameUpdate" runat="server" Width="200px" MaxLength="250"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvAFCOfficerNameUpdate" runat="server" ControlToValidate="txtAFCOfficerNameUpdate" ErrorMessage="Please Enter SC Officer Name to be Updated." Display="none" ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">SC Officer Mobile No</td>
                <td>
                    <asp:TextBox ID="txtAFCOfficerMobileNoUpdate" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvAFCOfficerMobileNoUpdate" runat="server" ControlToValidate="txtAFCOfficerMobileNoUpdate" Display="None" ErrorMessage="Please Enter SC Officer Mobile No to be Updated." ValidationGroup="UPDATE"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revAFCOfficerMobileNoUpdate" runat="server" ControlToValidate="txtAFCOfficerMobileNoUpdate" Display="None" ErrorMessage="SC Officer Mobile No to be Updated Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$" ValidationGroup="UPDATE"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update SC" OnClick="btnUpdate_Click" CssClass="InputButton" ValidationGroup="UPDATE" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UPDATE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Delete SC">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="25%">Select SC</td>
                <td width="75%">
                    <asp:DropDownList ID="ddlAFCDelete" runat="server" Width="95%"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvAFCDelete" runat="server" ControlToValidate="ddlAFCDelete" ErrorMessage="Please Select SC to be Deleted." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="DELETE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete SC" OnClick="btnDelete_Click" CssClass="InputButton" ValidationGroup="DELETE" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="DELETE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
