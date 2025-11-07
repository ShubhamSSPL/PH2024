<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmARAPenalty.aspx.cs" Inherits="Pharmacy2024.MVModule.frmARAPenalty" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
   <style>
        .MyCalendar .ajax__calendar_container
        {
            border: 1px solid #646464;
            background-color:whitesmoke;
            color: red;
        }
        .MyCalendar .ajax__calendar_container th
        {
            padding: 0px;
        }
        .MyCalendar .ajax__calendar_container td
        {
            background-color: whitesmoke;
            padding: 0px;
        }
        .MyCalendar .ajax__calendar_other .ajax__calendar_day, .MyCalendar .ajax__calendar_other .ajax__calendar_year
        {
            color: black;
        }
        .MyCalendar .ajax__calendar_hover .ajax__calendar_day, .MyCalendar .ajax__calendar_hover .ajax__calendar_month, .MyCalendar .ajax__calendar_hover .ajax__calendar_year
        {
            color: black;
        }
        .MyCalendar .ajax__calendar_active .ajax__calendar_day, .MyCalendar .ajax__calendar_active .ajax__calendar_month, .MyCalendar .ajax__calendar_active .ajax__calendar_year
        {
            color: black;
            font-weight: bold;
        }
    </style>
    <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 30%">Enter Institute Code:</td>
                <td><%--txtSubAFCOfficerMobileNo--%>
                    <asp:TextBox ID="txtInstCode" runat="server" MaxLength="4" Width="200px"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="InputButton" ValidationGroup="ADD" />
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvtxtInstCode" runat="server" ControlToValidate="txtInstCode" Display="None" ErrorMessage="Please Enter Institute Code." ValidationGroup="ADD"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revtxtInstCode" runat="server" ControlToValidate="txtInstCode" Display="None" ErrorMessage="Institute Code Accepts numerical value Only." ValidationExpression="^[0-9]+" ValidationGroup="ADD"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Institute Name:</td>
                <td>
                    <asp:Label ID="lblInstName" runat="server" Text="" Width="100%" Height="25px"></asp:Label>
                </td>
            </tr>   
            
            <tr>
                <td align="right">Apply Penalty:</td>
                <td>
                    <asp:DropDownList ID="ddlProposal" runat="server" Width="200px" Height="25px"></asp:DropDownList>                    
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Save Proposal Status" OnClick="btnAdd_Click" CssClass="InputButton" ValidationGroup="ADD" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ADD" />
                </td>
            </tr>
        </table>

    <script language="javascript" type="text/javascript">
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_txtProposalDate')); 
        };
    </script>
</asp:Content>
