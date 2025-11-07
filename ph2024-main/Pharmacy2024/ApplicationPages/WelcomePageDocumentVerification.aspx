<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="WelcomePageDocumentVerification.aspx.cs" Inherits="Pharmacy2024.ApplicationPages.WelcomePageDocumentVerification" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
     <script language="javascript" type = "text/javascript">
        window.history.forward(1);
     </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible = "false" Width="99%" ScrollBars="Auto">
        <br />
        <center> 
            <asp:Label ID = "lblHeader" runat = "server" Font-Names="Bookman Old Style" Font-Size = "Medium">
                Welcome for Admission to First Year of Post Graduate Technical Courses in Engineering and Technology for the Academic Year <%= AdmissionYear %>
            </asp:Label>
        </center>
        <br />
        <table class = "AppFormTable">
            <tr>
                <th colspan = "4">Login Details</th>
            </tr>
            <tr>
                <td style = "width:20%" align = "right">Login ID</td>
                <td style = "width:30%"><asp:Label ID = "lblLoginID" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td style = "width:20%" align = "right">User Name</td>
                <td style = "width:30%"><asp:Label ID = "lblUserName" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align = "right">User Type</td>
                <td><asp:Label ID = "lblUserType" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right">IP Address</td>
                <td><asp:Label ID = "lblIPAddress" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align = "right">Current Login Time</td>
                <td><asp:Label ID = "lblCurrentLoginTime" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right">Previous Login Time</td>
                <td><asp:Label ID = "lblPreviousLoginTime" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
