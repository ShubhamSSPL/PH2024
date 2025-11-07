<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAnalysisofAllotmentandReportingatARCforCAPRoundI.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmAnalysisofAllotmentandReportingatARCforCAPRoundI" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="https://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" />
    <script type="text/javascript">    jQuery.noConflict();</script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Analysis of Allotment and Reporting at ARC ( Freeze / Non Freeze) for CAP Round's" Width="100%" Height="400px" ScrollBars="Auto">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:Button ID="btnexporttoExcel" runat="server" Text="Export To Excel" OnClick="btnexporttoExcel_Click" Visible="false" />
                </td>
            </tr>
        </table>

        <br />

        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <b>Select CAP Round : </b>
                    <asp:DropDownList ID="ddlCAPRound" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCAPRound_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select CAP Round</asp:ListItem>
                        <asp:ListItem Value="1">CAP Round 1</asp:ListItem>
                        <asp:ListItem Value="2">CAP Round 2</asp:ListItem>
                        <asp:ListItem Value="3">CAP Round 3</asp:ListItem>
                        <asp:ListItem Value="4">CAP Round 4</asp:ListItem>
                        <%--<asp:ListItem Value="5">CAP Round 5</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />

        <asp:GridView ID="gvAnalysisofAllotmentandReportingatARCforCAPRoundI" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" ScrollBars="auto">
            <Columns>
                <%--<asp:BoundField DataField = "SrNo" HeaderText="Sr. No.">
                    <ItemStyle  HorizontalAlign="Center" Width="5%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>--%>
                <asp:BoundField DataField="TotalCandidates" HeaderText="Total Candidates Allotted In CAP Round I">
                    <ItemStyle HorizontalAlign="Center" Width="14%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FirstOptionAlloted" HeaderText="No. of First Option Allotted Candidates">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="OtherThan1stoptionCandidates" HeaderText="No. of Candidates Other Than First Option Allotted">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalAutoFreeze" HeaderText="Total No. of Candidates Auto Freeze">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Freeze" HeaderText="Total No. of Candidates Freeze">
                    <ItemStyle HorizontalAlign="Center" Width="14%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="NonFreeze" HeaderText="Total No. of Candidates Auto Non Freeze">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AutoFreezeAtARC" HeaderText="Total No. of Candidates Auto Freeze And Confirmed At ARC">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FreezeAtARC" HeaderText="Total No. of Candidates Freeze And Confirmed At ARC">
                    <ItemStyle HorizontalAlign="Center" Width="14%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalNonFreezeAtARC" HeaderText="Total No. of Candidates Non Freeze And Confirmed At ARC ">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="NotSelectedStatus" HeaderText="No of Candidates not selected Status">
                    <ItemStyle HorizontalAlign="Center" Width="14%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>

</asp:Content>
