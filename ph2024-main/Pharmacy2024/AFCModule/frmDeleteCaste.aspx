<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmDeleteCaste.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmDeleteCaste" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder">
            <tr align="center">
                <td><a href="../AFCModule/frmAddCaste.aspx"><font size="2"><b>| Add Caste |</b></font></a></td>
                <td><a href="../AFCModule/frmUpdateCaste.aspx"><font size="2"><b>| Update Caste |</b></font></a></td>
                <td><a href="../AFCModule/frmDeleteCaste.aspx"><font color="red" size="2"><b>| Delete Caste |</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox1" HeaderText="Delete Caste" runat="server">
        <table class="AppFormTable">
            <tr>
                <td style="width: 20%;" align="right">Select Category</td>
                <td style="width: 80%;">
                    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                    <asp:CompareValidator ID="cvCategory" runat="server" ControlToValidate="ddlCategory" ErrorMessage="Please Select Category." ValueToCompare="-- Select Category --" Operator="NotEqual" ValidationGroup="DeleteCaste" Display="none"></asp:CompareValidator>
                </td>
            </tr>
            <tr id="CasteDelete" runat="server">
                <td align="right">Select Caste</td>
                <td>
                    <asp:DropDownList ID="ddlCasteDelete" runat="server"></asp:DropDownList>
                    <asp:CompareValidator ID="cvCaste" runat="server" ControlToValidate="ddlCasteDelete" ErrorMessage="Please Select Caste." ValueToCompare="-- Select Caste --" Operator="NotEqual" ValidationGroup="DeleteCaste" Display="none"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete Caste" OnClick="btnDelete_Click" CssClass="InputButton" ValidationGroup="DeleteCaste" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="DeleteCaste" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
