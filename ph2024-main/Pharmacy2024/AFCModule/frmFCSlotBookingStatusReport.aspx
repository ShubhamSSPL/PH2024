<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmFCSlotBookingStatusReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmFCSlotBookingStatusReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="SC Capacity Increase/Decrease Status">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td style="width: 50%;" align="right">Select Date to Filter : </td>
                <td style="width: 50%;">
                    <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr id="trFclist" runat="server" visible="false">
                <td style="width: 50%;" align="right">Select SC to Filter : </td>
                <td style="width: 50%;">
                    <asp:DropDownList ID="ddlFCList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFC_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        </table>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
        <asp:GridView ID="gvCandidateList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="FCID" HeaderText="SC Code - Name" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass="Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="SlotDate" HeaderText="Slot Date" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="AvilableSlots" HeaderText="Current Slot Booking <br/> Capacity <br/> (1 SC Officer = 35 Slot) " HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="Booked" HeaderText="Current Booking by Candidate">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="true" />
                </asp:BoundField>
                <asp:BoundField DataField="OfficerReq" HeaderText="Required No. of SC Officer" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="true" />
                </asp:BoundField>
                <asp:BoundField DataField="AlertMsg" HeaderText="Alert Msg - to Institute" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="25%" CssClass="Item" Wrap="false"  />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="true" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>

    </cc1:ContentBox>
</asp:Content>