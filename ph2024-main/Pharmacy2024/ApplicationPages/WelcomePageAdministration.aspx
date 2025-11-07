<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="WelcomePageAdministration.aspx.cs" Inherits="Pharmacy2024.ApplicationPages.WelcomePageAdministration" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register TagPrefix="ddlb" Assembly="OptionDropDownList" Namespace="OptionDropDownList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible="false">
        <br />
        <center>
            <asp:Label ID="lblHeader" runat="server" Font-Names="Bookman Old Style" Font-Bold="false" Font-Size="Medium" Width="92%">
                Welcome for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>
            </asp:Label>
        </center>
        <br />
        <table class="AppFormTable">
            <tr>
                <th colspan="4">Login Details</th>
            </tr>
            <tr>
                <td style="width: 20%" align="right">Login ID</td>
                <td style="width: 30%">
                    <asp:Label ID="lblLoginID" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 20%" align="right">User Name</td>
                <td style="width: 30%">
                    <asp:Label ID="lblUserName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">User Role</td>
                <td>
                    <asp:Label ID="lblUserType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">IP Address</td>
                <td>
                    <asp:Label ID="lblIPAddress" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Current Login Time</td>
                <td>
                    <asp:Label ID="lblCurrentLoginTime" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Previous Login Time</td>
                <td>
                    <asp:Label ID="lblPreviousLoginTime" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trWebSiteNavigation1" runat="server" visible="false">
                <th colspan="4">WebSite Navigation</th>
            </tr>
            <tr id="trWebSiteNavigation2" runat="server" visible="false">
                <td align="right">Select WebSite</td>
                <td colspan="3">
                    <ddlb:optiongroupselect ID="ddlWebSite" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWebSite_SelectedIndexChanged"></ddlb:optiongroupselect></td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>

