<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmForgotPassword.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmForgotPassword" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Forgot Your Password ?">
        <table class = "AppFormTable">
            <tr>
                <th align = "left">Forgot Your Password ?</th>
            </tr>
            <tr>
                <td style="width: 70%">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Select User Type : 
                    <asp:DropDownList ID="ddlUserType" runat="server">
                        <asp:ListItem Value = "0">-- Select User Type --</asp:ListItem>
                        <asp:ListItem Value = "91">Candidate / Applicant</asp:ListItem>
                        <asp:ListItem Value = "21">Admin</asp:ListItem>
                        <asp:ListItem Value = "22">Regional Office</asp:ListItem>
                        <asp:ListItem Value = "31">Sub Regional Office</asp:ListItem>
                        <asp:ListItem Value = "33">ARC Officer</asp:ListItem>
                        <asp:ListItem Value = "34">Sub-ARC Officer</asp:ListItem>
                        <asp:ListItem Value = "23">SC Officer</asp:ListItem>
                        <asp:ListItem Value = "24">Sub-SC Officer</asp:ListItem>
                        <asp:ListItem Value = "43">College</asp:ListItem>
                    </asp:DropDownList>
                    <font color = "red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvUserType" runat="server" ControlToValidate="ddlUserType" Display="None" ErrorMessage="Please Select User Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    <br /><br /><br /><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnContinue" runat="server" Text="CONTINUE" CssClass="InputButton" Width = "100px" OnClick="btnContinue_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                    <br /><br />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
