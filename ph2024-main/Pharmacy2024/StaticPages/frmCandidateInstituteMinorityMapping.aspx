<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmCandidateInstituteMinorityMapping.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCandidateInstituteMinorityMapping" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" HeaderText = "Candidate Minority and Institute Minority Mapping" runat="server">
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" OnDataBound="gvList_DataBound" CssClass = "DataGrid">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Header" Width = "7%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "CandidateMinority" HeaderText = "Candidate's Linguistic and /or Religious Minority Status">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width = "20%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteMinority" HeaderText = "Institute Minority">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width = "20%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteName" HeaderText = "Educational Institutions for Allotment in Minority Quota">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Width = "50%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td><font color = "red" size = "2"><b>The Minority candidate's can fill the Choice Codes of Non-Minority or other Minority institutions.</b></font></td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
