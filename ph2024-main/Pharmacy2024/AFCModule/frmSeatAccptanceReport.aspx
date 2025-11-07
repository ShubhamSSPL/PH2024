<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSeatAccptanceReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmSeatAccptanceReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="https://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" />
    <script type="text/javascript">    jQuery.noConflict();</script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Seat Acceptance Analysis" Width="100%" Height="400px" ScrollBars="Auto">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:Button ID="btnexporttoExcel" runat="server" Text="Export To Excel" OnClick="btnexporttoExcel_Click" Visible="false" />
                </td>
            </tr>
        </table>

        <br />
        <asp:GridView ID="gvSeatAccptanceReport" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <%--<asp:BoundField DataField = "SrNo" HeaderText="Sr. No.">
                    <ItemStyle  HorizontalAlign="Center" Width="5%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>--%>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID">
                    <ItemStyle HorizontalAlign="Center" Width="14%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AllotedChoiceCode" HeaderText="AllotedChoiceCode">
                    <ItemStyle HorizontalAlign="Center" Width="14%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SeatTypeCode" HeaderText="SeatTypeCode">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AllotedChoiceNo" HeaderText="AllotedChoiceNo">
                    <ItemStyle HorizontalAlign="Center" Width="14%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ReservationType" HeaderText="ReservationType">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SeatAcceptanceStatus" HeaderText="SeatAcceptanceStatus">
                    <ItemStyle HorizontalAlign="Center" Width="14%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ReportingStatus" HeaderText="ReportingStatus">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>

</asp:Content>


