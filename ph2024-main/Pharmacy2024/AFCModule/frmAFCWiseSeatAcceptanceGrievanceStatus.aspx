<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master" CodeBehind="frmAFCWiseSeatAcceptanceGrievanceStatus.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmAFCWiseSeatAcceptanceGrievanceStatus" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "SC Wise Seat Acceptance Grievances Pending for Verification">
        <asp:GridView ID="gvAFCWiseReport"  ShowFooter = "true" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" OnRowDataBound="gvAFCWiseReport_RowDataBound">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>
                <%--<asp:HyperLinkField DataTextField = "AFCName" DataNavigateUrlFields="RegionID,InstituteID" DataNavigateUrlFormatString = "frmSubAFCWiseSeatAcceptanceGrievanceListForVerification.aspx?RegionID={0}&InstituteID={1}" HeaderText = "SC Name">
                    <ItemStyle HorizontalAlign="Left" Width="85%" CssClass = "Item" Wrap = "true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Right" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:TemplateField HeaderText="SC Name">
                   <ItemTemplate>
                     <asp:HyperLink ID="hprLink" runat="server" 
                          NavigateUrl='frmSubAFCWiseSeatAcceptanceGrievanceListForVerification.aspx'
                          Text='<%# Eval("AFCName") %>' >
                     </asp:HyperLink>
                       <asp:HiddenField ID="hidRegionID" runat="server" Value='<%# Bind("RegionID") %>' />
                        <asp:HiddenField ID="hidInstituteID" runat="server" Value='<%# Bind("InstituteID") %>' />
                        <asp:HiddenField ID="hidGrievanceStatusFlag" runat="server" Value='<%# Bind("GrievanceStatusFlag") %>' />
                   </ItemTemplate>
                     <ItemStyle HorizontalAlign="Left" Width="85%" CssClass = "Item" Wrap = "true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Right" CssClass = "Footer" />
                </asp:TemplateField>
                <asp:BoundField DataField = "Cnt" HeaderText = "Total Grievance<br /> Pending for Verification" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>


