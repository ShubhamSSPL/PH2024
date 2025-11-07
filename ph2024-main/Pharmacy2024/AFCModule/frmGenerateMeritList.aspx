<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmGenerateMeritList.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmGenerateMeritList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="MeritListContent" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="cbDownloadCandidateData" runat="server" HeaderText="Download Candidate Data">
        <table class="AppFormTable">
            <tr>
                <th style="width: 40%">Candidates Type</th>
                <th style="width: 30%">Total Count</th>
                <th style="width: 30%">Excel</th>
            </tr>
            <tr>
                <td align="right">Total Candidates</td>
                <td align="center">
                    <asp:Label ID="lblTotalCandidatesCount" runat="server"></asp:Label></td>
                <td align="center">
                    <asp:LinkButton ID="lnkbtnTotalCandidateCountExcel" Text="Excel" runat="server" OnClick="lnkbtnTotalCandidateCountExcel_Click"></asp:LinkButton></td>
            </tr>
            <tr>
                <td align="right">Eligible Candidates</td>
                <td align="center">
                    <asp:Label ID="lblEligibleCandidateCount" runat="server"></asp:Label></td>
                <td align="center">
                    <asp:LinkButton ID="lnkbtnEligibleCandidateCountExcel" Text="Excel" runat="server" OnClick="lnkbtnEligibleCandidateCountExcel_Click"></asp:LinkButton></td>
            </tr>
            <tr>
                <td align="right">Not Eligible Candidates</td>
                <td align="center">
                    <asp:Label ID="lblNotEligibleCandidateCount" runat="server"></asp:Label></td>
                <td align="center">
                    <asp:LinkButton ID="lnkbtnNotEligibleCandidateCountExcel" Text="Excel" runat="server" OnClick="lnkbtnNotEligibleCandidateCountExcel_Click"></asp:LinkButton></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbDownloadMeritList" runat="server" HeaderText="Download Merit List">
        <table class="AppFormTable">
            <tr>
                <th style="width: 35%">Merit List Type</th>
                <th style="width: 35%">Merit List Generated On</th>
                <th style="width: 30%">Excel</th>
            </tr>
            <tr id="trProvisionalMeritList" runat="server">
                <td align="right">Provisional Merit List</td>
                <td align="center">
                    <asp:Label ID="lblProvisionalMeritListLastModifiedOn" runat="server">-</asp:Label></td>
                <td align="center">
                    <asp:LinkButton ID="lnkbtnProvisionalMeritListExcel" Text="Excel" runat="server" Enabled="false" OnClick="lnkbtnProvisionalMeritListExcel_Click"></asp:LinkButton></td>
            </tr>
            <tr id="trFinalMeritList" runat="server">
                <td align="right">Final Merit List</td>
                <td align="center">
                    <asp:Label ID="lblFinalMeritListLastModifiedOn" runat="server">-</asp:Label></td>
                <td align="center">
                    <asp:LinkButton ID="lnkbtnFinalMeritListExcel" Text="Excel" runat="server" Enabled="false" OnClick="lnkbtnFinalMeritListExcel_Click"></asp:LinkButton></td>
            </tr>
            <tr id="trAllotmentMeritList" runat="server">
                <td align="right">Allotment Merit List</td>
                <td align="center">
                    <asp:Label ID="lblAllotmentMeritListLastModifiedOn" runat="server">-</asp:Label></td>
                <td align="center">
                    <asp:LinkButton ID="lnkbtnAllotmentMeritListExcel" Text="Excel" runat="server" Enabled="false" OnClick="lnkbtnAllotmentMeritListExcel_Click"></asp:LinkButton></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbGenerateMeritList" runat="server" HeaderText="Generate Merit List">
        <table class="AppFormTable">
            <tr>
                <th align="left" colspan="2">Select Merit List Type to be Generated</th>
            </tr>
            <tr>
                <td style="width: 40%;"></td>
                <td style="width: 60%; border-left-width: 0px;">
                    <asp:RadioButton ID="rbnProvisionalMeritList" runat="server" Text="&nbsp;&nbsp;Provisional Merit List" GroupName="MeritList" /></td>
            </tr>
            <tr>
                <td></td>
                <td style="border-left-width: 0px;">
                    <asp:RadioButton ID="rbnFinalMeritList" runat="server" Text="&nbsp;&nbsp;Final Merit List" GroupName="MeritList" /></td>
            </tr>
            <tr>
                <td></td>
                <td style="border-left-width: 0px;">
                    <asp:RadioButton ID="rbnAllotmentMeritList" runat="server" Text="&nbsp;&nbsp;Allotment Merit List" GroupName="MeritList" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <br />
                    <asp:Button ID="btnGenerateMeritList" runat="server" Text="Generate Merit List" CssClass="InputButton" OnClick="btnGenerateMeritList_Click" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    </cc1:ContentBox>
</asp:Content>
