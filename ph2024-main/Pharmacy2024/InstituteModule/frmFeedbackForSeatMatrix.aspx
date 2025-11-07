<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmFeedbackForSeatMatrix.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmFeedbackForSeatMatrix" %>


<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
   
    <cc1:ContentBox ID="ctVerification" runat="server" HeaderText = "Seat Matrix Feedback">
         <table class="AppFormTable" style="width:100%;">
            <tr>
               <td align="right">Select Status
                   <font color="red"><sup>*</sup></font>
               </td>
                <td>                     
                    <asp:RadioButtonList ID="rbLstRequest" runat="server" Width="95%" CssClass="radioButtonList">
                        <asp:ListItem Value="Yes" Text="Verified and Found ok" ></asp:ListItem>
                        <asp:ListItem Value="No" Text="Issue in Allotment"  ></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="rfvrbLstRequest" runat="server" ForeColor="Red" Font-Bold="true" ControlToValidate="rbLstRequest" ErrorMessage="Please choose One option for Status"> </asp:RequiredFieldValidator>
                </td>
            </tr>        
            <tr>
                <td align="right">Comments/Remark
                    <font color="red"><sup>*</sup></font>
                </td>
                <td >                    
                    <asp:TextBox ID="txtComments" runat="server" Width="95%" Height="70px" MaxLength="550" TextMode="MultiLine"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvtxtComments" ControlToValidate="txtComments"  runat="server"  ErrorMessage="Please Enter Comments/Remark." ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
               </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnProceed" runat="server" Text="Submit >>>" OnClick="btnProceed_Click" CssClass="InputButton"></asp:Button></td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="false" />
            </tr>
            
        </table>
    </cc1:ContentBox>
</asp:Content>



