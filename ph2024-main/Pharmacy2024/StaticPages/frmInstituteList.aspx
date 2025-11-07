<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmInstituteList.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmInstituteList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" HeaderText = "List of Institutes Participating in CAP" runat="server">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color = "red">
                        <ol class="list-text"><b>Instructions :</b>
                            <li><p align = "justify"><font color = "red">Click on Institute Code to view the Institute Information.</font></p></li>
                        </ol>
                    </font>
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvInstituteList" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid">
            <Columns> 
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
                <asp:BoundField DataField = "InstituteName" HeaderText = "Institute Name" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Width = "65%"  />
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
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>