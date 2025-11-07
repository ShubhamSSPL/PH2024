<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmControlMasterAFC.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmControlMasterAFC" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Add Master SC">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="20%">Select Institute</td>
                <td width="80%">
                    <asp:DropDownList ID="ddlInstituteAdd" runat="server" Width="100%"></asp:DropDownList>
                    <asp:CompareValidator ID="cvInstituteAdd" runat="server" ControlToValidate="ddlInstituteAdd" ErrorMessage="Please Select Institute to be Added as Master SC." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="ADD"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add Master SC" OnClick="btnAdd_Click" CssClass="InputButton" ValidationGroup="ADD" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ADD" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Delete Master SC">
        <table class="AppFormTable">
            <tr>
                <td align="right" width="20%">Select Institute</td>
                <td width="80%">
                    <asp:DropDownList ID="ddlInstituteDelete" runat="server" Width="100%"></asp:DropDownList>
                    <asp:CompareValidator ID="cvInstituteDelete" runat="server" ControlToValidate="ddlInstituteDelete" ErrorMessage="Please Select Institute to be Deleted from Master SC." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="DELETE"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete Master SC" OnClick="btnDelete_Click" CssClass="InputButton" ValidationGroup="DELETE" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="DELETE" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
