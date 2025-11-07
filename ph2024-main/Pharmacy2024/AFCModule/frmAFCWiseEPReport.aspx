<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master" CodeBehind="frmAFCWiseEPReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmAFCWiseEPReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "SC Wise Report">
        <asp:GridView ID="gvAFCWiseReport"  ShowFooter = "true" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No. <br/> 1" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>
               <%-- <asp:HyperLinkField DataTextField = "AFCName" DataNavigateUrlFields="RegionID,InstituteID" DataNavigateUrlFormatString = "frmSubAFCWiseReport.aspx?RegionID={0}&InstituteID={1}" HeaderText = "SC Name">
                    <ItemStyle HorizontalAlign="Left" Width="85%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Right" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:BoundField DataField = "AFCName" HeaderText = "SC Name <br/> 2" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"  />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalApplicationFormsConfirmed" HeaderText="Total Application Forms Confirmed <br/> 3 =(4+6)" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="PConfirmed" HeaderText="Total Application Forms Physical Confirmed <br/> 4" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalAssigedForEScrutiny" HeaderText="Total Application Forms Assigned for E Scrutiny <br/> 5 =(6+7+8+9+10+11+12)" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="EConfirmed" HeaderText="Total Application Forms E Scrutiny Confirmed <br/> 6" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="EScrutinyPending" HeaderText="Total Application Forms Pending For E Scrutiny <br/> 7" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="EScrutinyPicked" HeaderText="Total Application Forms Picked for E Scrutiny <br/> 8" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="RevertedBack" HeaderText="Application form reverted back due to non submission of Mandatory Document <br/> 9" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="GrivanceRaised" HeaderText="Confirm by SC and Grievance raised by Candidate <br/> 10" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="AssignANDReSubmitted" HeaderText="Submitted and Unlock by SC and Re Submitted by Candidate <br/> 11" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
                <asp:BoundField DataField="AssignButNotReSubmitted" HeaderText="Unlock by Candiate and Not Re Submitted by Candidate <br/> 12" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>
               <%-- <asp:BoundField DataField="PercentPending" HeaderText="% Pending <br/> 13">
                    <ItemStyle HorizontalAlign="Center" Width="40%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" />
                </asp:BoundField>--%>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>


