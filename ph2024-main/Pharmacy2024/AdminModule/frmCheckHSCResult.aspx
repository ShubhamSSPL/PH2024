<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmCheckHSCResult.aspx.cs" Inherits="Pharmacy2024.AdminModule.frmCheckHSCResult" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
 <%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">

    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Fetch Form RazorPay">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">HSC Seat No</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtHSCSeatNo" runat="server" MaxLength="11" Text="" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ControlToValidate="txtHSCSeatNo" Display="None" ErrorMessage="Please Enter HSC Seat No."></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td style="width: 50%;" align="right">Passing Year</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtPassingYear" runat="server" MaxLength="4" Text="" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassingYear" Display="None" ErrorMessage="Please Enter PassingYear."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed >>>" CssClass="InputButtonRed" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>

    <cc1:ContentBox ID="ContentBox1" runat="server"   HeaderText="HSC Details Detils">
        <asp:Label runat="server" ID="lblApplicationID" Font-Bold="true" Font-Size="Medium"> HSC Seat No :</asp:Label>
        <asp:Label runat="server" ID="lblPersonalID" Font-Bold="true" Font-Size="Medium"> Passing Year :</asp:Label>
        <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="True" CssClass="DataGrid" BorderWidth="1" EnableModelValidation="True" Width="100%">
        </asp:GridView>
    </cc1:ContentBox>
    <br />
      
</asp:Content>
