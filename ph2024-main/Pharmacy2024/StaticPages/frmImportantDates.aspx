<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmImportantDates.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmImportantDates" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .hidden {
            display: none;
        }        
       @media only screen and (max-width: 768px) {
            #layoutSidenav #layoutSidenav_content {
                margin-left: 0px !important;
            }
        }        
    </style>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Important Dates">
        <table class="AppFormTableWithOutBorder table-responsive">
            <tr>
                <td>
                    <center><font color = "red" size = "2"><b>Schedule of Activities for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></b></font></center>
                </td>
            </tr>
        </table>
        <br />
        <div class="table-responsive">
            <asp:GridView ID="gvImportantDatesGeneral" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" OnRowCreated="gvImportantDatesGeneral_RowCreated" ShowHeader="false" OnRowDataBound="gvImportantDatesGeneral_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Sr. No." HtmlEncode="false">
                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="7%" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ActivityDetails" HeaderText="Activity" HtmlEncode="false">
                        <ItemStyle HorizontalAlign="Justify" CssClass="Item" Width="69%" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FirstDate" HeaderText="First Date" HtmlEncode="false">
                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="12%" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LastDate" HeaderText="Last Date" HtmlEncode="false">
                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="12%" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ActivityStatus" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
       <%-- <table class="AppFormTableWithOutBorder table-responsive">
            <tr>
                <td>
                    <center><font color = "red" size = "2"><b>Schedule of Activities for J&K Migrant Candidates</b></font></center>
                </td>
            </tr>
        </table>--%>
        <br />
        <asp:GridView ID="gvImportantDatesJK" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" OnRowCreated="gvImportantDatesJK_RowCreated" ShowHeader="false" OnRowDataBound="gvImportantDatesJK_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="Sr. No." HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Font-Size="11px" CssClass="Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="10px" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ActivityDetails" HeaderText="Activity" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Justify" Font-Size="11px" CssClass="Item" Width="60%" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="10px" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FirstDate" HeaderText="First Date" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Font-Size="11px" CssClass="Item" Width="16%" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="10px" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="LastDate" HeaderText="Last Date" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Font-Size="11px" CssClass="Item" Width="16%" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="10px" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ActivityStatus" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
            </Columns>
        </asp:GridView>
        <br />
        <table class="AppFormTableWithOutBorder table-responsive">
            <tr>
                <td>
                    <p align="justify"><font size="2"><b><i>Note</i> : </b></font>The schedule given above is provisional and may change due to unavoidable circumstances. The revised schedule will be notified on website <a href="http://ph2024.mahacet.org" target="_blank">http://ph2024.mahacet.org</a></p>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>

