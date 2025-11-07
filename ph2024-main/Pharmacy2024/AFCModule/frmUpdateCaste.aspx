<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmUpdateCaste.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmUpdateCaste" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder">
            <tr align="center">
                <td><a href="../AFCModule/frmAddCaste.aspx"><font size="2"><b>| Add Caste |</b></font></a></td>
                <td><a href="../AFCModule/frmUpdateCaste.aspx"><font color="red" size="2"><b>| Update Caste |</b></font></a></td>
                <td><a href="../AFCModule/frmDeleteCaste.aspx"><font size="2"><b>| Delete Caste |</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTableControl" runat="server" HeaderText="Update Caste">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Select Category</td>
                <td style="width: 50%;">
                    <asp:DropDownList ID="ddlCategoryEdit" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoryEdit_SelectedIndexChanged"></asp:DropDownList>
                    <asp:CompareValidator ID="cvCategoryEdit" runat="server" ControlToValidate="ddlCategoryEdit" ErrorMessage="Please Select Category to Edit." ValueToCompare="-- Select Category --" Operator="NotEqual" Display="None"></asp:CompareValidator>
                </td>
            </tr>
            <tr id="CasteEdit" runat="server">
                <td align="right">Select Caste</td>
                <td>
                    <asp:DropDownList ID="ddlCasteEdit" runat="server" Width="50%" OnSelectedIndexChanged="ddlCasteEdit_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:CompareValidator ID="cvCasteEdit" runat="server" ControlToValidate="ddlCasteEdit" ErrorMessage="Please Select Caste to Edit." ValueToCompare="-- Select Caste --" Operator="NotEqual" Display="none"></asp:CompareValidator>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <br />
    <cc1:ContentBox ID="ContentTableControlEditVenue" runat="server" HeaderText="Update Caste">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Caste Name</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtCasteName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCasteName" runat="server" ControlToValidate="txtCasteName" ErrorMessage="Please Enter Caste Name." Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Caste Serial Number</td>
                <td>
                    <asp:TextBox ID="txtCasteSerialNumber" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCasteSerialNumber" runat="server" ControlToValidate="txtCasteSerialNumber" ErrorMessage="Please Enter Caste Serial Number." Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Update" OnClick="btnSubmit_Click" CssClass="InputButton" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
