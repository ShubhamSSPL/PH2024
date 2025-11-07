<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmPayApplicationFeeDifference.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmPayApplicationFeeDifference" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="server">
       <script lang="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Pay Application Fee">
        <table class="AppFormTable">
            <tr>
                <td style="width:50%" align="right">Application Fee to be Paid (<span class="rupee">Rs.</span>)</td>
                <td style="width:50%"><asp:Label ID="lblApplicationFeeToBePaid" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                </td>
            </tr>
        </table>
        <br />
	</cc1:ContentBox>
</asp:Content>
