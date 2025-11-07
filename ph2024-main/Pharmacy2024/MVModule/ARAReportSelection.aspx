<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="ARAReportSelection.aspx.cs" Inherits="Pharmacy2024.MVModule.ARAReportSelection" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
     <cc1:ContentBox ID="cbChoiceCD" runat="server" HeaderText="Choice Code Wise Admitted, Recommended, Not Recommended" Width = "100%" ScrollBars = "auto">
         
         <Table ID="Table1" runat="server">
             <tr>
                 <td><h4> Select Report Filter from list below :</h4></td>                 
             </tr>
             <tr><td>&nbsp;&nbsp;</td></tr>
             
             <tr>
                 <td><h6>
                     <asp:RadioButton ID="rbtFilterA" runat="server" GroupName="filter" Text="" Checked="True" /> &nbsp;&nbsp;
                     List of Institutes where processing fees not applicable.</h6>
                 </td>                 
             </tr>
             <tr><td>&nbsp;&nbsp;</td></tr>

             <tr>
                 <td><h6>
                     <asp:RadioButton ID="rbtFilterB" runat="server" GroupName="filter" Text="" Checked="False" /> &nbsp;&nbsp;
                     List of Institutes Verified by DTE and proposal submitted to ARA.</h6>
                 </td>                 
             </tr>
             <tr><td>&nbsp;&nbsp;</td></tr>

             <tr>
                 <td><h6>
                     <asp:RadioButton ID="rbtFilterC" runat="server" GroupName="filter" Text="" Checked="False" /> &nbsp;&nbsp;
                     List of Institutes Verified by DTE but proposal not submitted to ARA.</h6>
                 </td>                 
             </tr>
             <tr><td>&nbsp;&nbsp;</td></tr>

             <tr>
                 <td><h6>
                     <asp:RadioButton ID="rbtFilterD" runat="server" GroupName="filter" Text="" Checked="False" /> &nbsp;&nbsp;
                     List of Institutes Not verified by DTE.</h6>
                 </td>            
             </tr>
             <tr><td>&nbsp;&nbsp;</td></tr>

             <tr>
                 <td><h6>
                     <asp:RadioButton ID="rbtFilterE" runat="server" GroupName="filter" Text="" Checked="False" /> &nbsp;&nbsp;
                     List of Institutes having zero admissions.</h6>
                 </td>
             </tr>
             <tr><td>&nbsp;&nbsp;</td></tr>

             <tr>
                 <td><h6>
                     <asp:RadioButton ID="rbtFilterG" runat="server" GroupName="filter" Text="" Checked="False" /> &nbsp;&nbsp;
                     List of Institutes - PHARM. D.</h6>
                 </td>
             </tr>
             <tr><td>&nbsp;&nbsp;</td></tr>

             <tr>
                 <td><h6>
                     <asp:RadioButton ID="rbtFilterH" runat="server" GroupName="filter" Text="" Checked="False" /> &nbsp;&nbsp;
                     List of Institutes - B. Pharmacy</h6>
                 </td>
             </tr>
             <tr><td>&nbsp;&nbsp;</td></tr>
             
             <tr>
                 <td>
                     <asp:Button ID="btnSubmit" runat="server" Text="View Report" CssClass="InputButton"  OnClick="btnSubmit_Click" />
                 </td>
             </tr>
         </Table>
    </cc1:ContentBox>
</asp:Content>
