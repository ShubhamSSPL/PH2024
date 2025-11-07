<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAddCaste.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmAddCaste" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder">
            <tr align="center">
                <td><a href="../AFCModule/frmAddCaste.aspx"><font color="red" size="2"><b>| Add Caste |</b></font></a></td>
                <td><a href="../AFCModule/frmUpdateCaste.aspx"><font size="2"><b>| Update Caste |</b></font></a></td>
                <td><a href="../AFCModule/frmDeleteCaste.aspx"><font size="2"><b>| Delete Caste |</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox1" HeaderText="Add Caste" runat="server">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Caste Name</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtCasteName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCasteName" runat="server" ControlToValidate="txtCasteName" ErrorMessage="Please Enter Caste Name." ValidationGroup="AddCaste" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Caste Serial Number</td>
                <td>
                    <asp:TextBox ID="txtCasteSerialNumber" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCasteSerialNumber" runat="server" ControlToValidate="txtCasteSerialNumber" ErrorMessage="Please Enter Caste Serial Number." ValidationGroup="AddCaste" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Caste Category</td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                    <asp:CompareValidator ID="cvCategory" runat="server" ErrorMessage="Please Select Caste Category." Operator="NotEqual" ValueToCompare="-- Select Category --" ControlToValidate="ddlCategory" ValidationGroup="AddCaste" Display="none"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnAddVenue" runat="server" Text="Add Caste" OnClick="btnAddCaste_Click" CssClass="InputButton" ValidationGroup="AddCaste" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="AddCaste" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
