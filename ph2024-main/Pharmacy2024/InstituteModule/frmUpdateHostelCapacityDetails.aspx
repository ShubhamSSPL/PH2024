<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmUpdateHostelCapacityDetails.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmUpdateHostelCapacityDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function numbersonly(e) 
        {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) 
            {
                if (unicode < 48 || unicode > 57) 
                {
                    return false
                }
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Update Hostel Capacity Details">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Boys Hostel Capacity - 1st Year</td>
                <td style="width: 50%;"><asp:TextBox ID="txtBoysHostelCapacityIYear" runat="server" MaxLength="4" Width="50px" onKeyPress="return numbersonly(event)"></asp:TextBox></td> 
                <asp:RequiredFieldValidator ID="rfvBoysHostelCapacityIYear" runat="server" ErrorMessage="Please Enter Boys Hostel Capacity for 1st Year." ControlToValidate="txtBoysHostelCapacityIYear" Display = "None"></asp:RequiredFieldValidator>
            </tr>
            <tr>
                <td align="right">Girls Hostel Capacity - 1st Year</td>
                <td>
                    <asp:TextBox ID="txtGirlsHostelCapacityIYear" runat="server" MaxLength="4" Width="50px" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvGirlsHostelCapacityIYear" runat="server" ErrorMessage="Please Enter Girls Hostel Capacity for 1st Year." ControlToValidate="txtGirlsHostelCapacityIYear" Display = "None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <br />
                    <asp:Button ID="btnProceed" runat="server" Text=" Save " CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                    <br /><br />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>