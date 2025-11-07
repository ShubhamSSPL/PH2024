<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCheckCandidateEligibilityForCapRound.aspx.cs" Inherits="Pharmacy2024.AdminModule.frmCheckCandidateEligibilityForCapRound" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
 <%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">

    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Check Eligibility for CAP Round">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Application ID</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="11" Text="PH20" Width="110px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ControlToValidate="txtApplicationID" Display="None" ErrorMessage="Please Enter Application ID."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed >>>" CssClass="InputButtonRed" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>  <br />
    </cc1:ContentBox>
       <cc1:ContentBox ID="ContentBox1" runat="server"   HeaderText="Eligible Candidate Details">
        <asp:Label runat="server" ID="lblApplicationID" Font-Bold="true" Font-Size="Medium"> Application ID :</asp:Label>
        <asp:Label runat="server" ID="lblPersonalID" Font-Bold="true" Font-Size="Medium"> Personal ID :</asp:Label>
             <br />
           <asp:GridView ID="gvCheckEligibleCand" runat="server" AutoGenerateColumns="true"  CssClass="DataGrid" BorderWidth="1" EnableModelValidation="True" Width="100%"></asp:GridView>
    </cc1:ContentBox>
    </asp:Content>
