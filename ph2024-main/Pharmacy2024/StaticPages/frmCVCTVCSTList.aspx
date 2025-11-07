<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmCVCTVCSTList.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCVCTVCSTList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" HeaderText = "LIST OF B.E. / B. Tech. CVC / TVC Candidates" runat="server" ScrollBars="Auto" Height="605px">
         <asp:Button ID="btnExporttoExcel" runat="server" CssClass = "InputButtonRed" Text="Export to Excel" OnClick="btnExporttoExcel_Click" />
        <br / />
         
        <asp:GridView ID="gvCVCTVCNonSTList" runat="server" ShowFooter="true" AutoGenerateColumns="True" Width="100%" CssClass = "DataGrid">
           <%-- <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Header" Width = "7%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:HyperLinkField DataTextField = "InstituteCode" DataNavigateUrlFields = "InstituteCode" DataNavigateUrlFormatString = "frmInstituteSummary.aspx?InstituteCode={0}" HeaderText = "Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width = "7%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:HyperLinkField>
                <asp:BoundField DataField = "InstituteName" HeaderText = "Institute Name offering B. Pharmacy and Pharm. D.">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Width = "65%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Right" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "Status" HeaderText = "Status">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width = "14%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalIntake" HeaderText = "Total Intake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width = "7%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
            </Columns>--%>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
