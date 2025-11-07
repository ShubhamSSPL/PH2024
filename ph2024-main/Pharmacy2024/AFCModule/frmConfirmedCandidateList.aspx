<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmConfirmedCandidateList.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmConfirmedCandidateList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Confirmed Candidate List">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td style="width: 50%;" align="right">Select Date to Filter : </td>
                <td style="width: 50%;">
                    <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        </table>
        <asp:GridView ID="gvCandidateList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Left" Width="35%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ConfirmedDateTime" HeaderText="Confirmed Date Time">
                    <ItemStyle HorizontalAlign="Center" Width="25%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ConfirmedBy" HeaderText="Confirmed By">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ConfirmedByIPAddress" HeaderText="Confirmed By<br />IP Address" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField = "VerificationMode" HeaderText = "Verification<br />Mode" HtmlEncode = "false" Visible="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>

