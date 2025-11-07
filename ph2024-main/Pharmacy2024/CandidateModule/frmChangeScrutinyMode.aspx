<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmChangeScrutinyMode.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmChangeScrutinyMode" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<%@ Register Src="../UserControls/PScrutiny.ascx" TagName="PScrutiny" TagPrefix="PS1" %>
<%@ Register Src="../UserControls/EScrutiny.ascx" TagName="EScrutiny" TagPrefix="ES1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style >
        #rightContainer_ContentTableFCVerification{
           z-index:90 !important;
           top:unset !important;
               left: 3px !important;
               width:98% !important;
        }
    </style>
     <script type = "text/javascript">
         function ConfirmChangeToPScrutiny() {
             var confirm_value = document.createElement("INPUT");
             confirm_value.type = "hidden";
             confirm_value.name = "confirm_value";
             if (confirm("Are you sure to Change your Mode of Scrutiny from E-Scrutiny to Physical Scrutiny Mode?")) {
                 confirm_value.value = "Yes";
             } else {
                 confirm_value.value = "No";
             }
             document.forms[0].appendChild(confirm_value);
         }

         function ConfirmChangeToEScrutiny() {
             var confirm_value = document.createElement("INPUT");
             confirm_value.type = "hidden";
             confirm_value.name = "confirm_value";
             if (confirm("Are you sure to Change your Mode of Scrutiny from Physical Scrutiny to E-Scrutiny Mode?")) {
                 confirm_value.value = "Yes";
             } else {
                 confirm_value.value = "No";
             }
             document.forms[0].appendChild(confirm_value);
         }
     </script>
       <cc1:ContentBox ID="ContentTableFCVerification" runat="server" HeaderText="Change SC Verification Mode/Option"  Width="100%">
        <asp:Label ID="lblmessage" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
          
        <table class="AppFormTable" >
            <tr>
                <th align="left">
                    Current SC Verification Mode
                </th>
            </tr>
            <tr>
                <td>
                    <PS1:PScrutiny ID="SelectdPScrutiny" runat="server" />
                    <ES1:EScrutiny ID="SelectedEScrutiny" runat="server" />  
                </td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblChnageTo" runat="server" visible="false" >
            <tr>
                <th align="left">
                    Change SC Verification Mode to 
                </th>
            </tr>
            <tr>
                <td>
                    <PS1:PScrutiny ID="ChoosePScrutiny" runat="server" />
                    <ES1:EScrutiny ID="ChooseEScrutiny" runat="server" /> 
                </td>
            </tr>

            <tr>
                <td align="center">
                    <asp:Button ID="btnPScrutiny" runat="server" Text="Physical Scrutiny & Proceed >>>" CssClass="InputButton" OnClick="btnPScrutiny_Click" OnClientClick="ConfirmChangeToPScrutiny()" />
                    <asp:Button ID="btnEScrutiny" runat="server" Text="E-Scrutiny Mode & Proceed >>>" CssClass="InputButton" OnClick="btnEScrutiny_Click" OnClientClick="ConfirmChangeToEScrutiny()" />
                </td>
            </tr>
        </table> 

    </cc1:ContentBox>

</asp:Content>
