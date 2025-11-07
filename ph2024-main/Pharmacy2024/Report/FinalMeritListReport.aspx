<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="FinalMeritListReport.aspx.cs" Inherits="Pharmacy2024.Report.FinalMeritListReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

 

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:content id="Content1" contentplaceholderid="rightContainer" runat="Server">
     <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Merit List Generation">
        <table class="AppFormTable">
            <tr>
                <td>
                <asp:DropDownList ID="ddlMeritType" runat="server" AutoPostBack="true" 
                        onmouseover="ddrivetip('Please Select Merit Type.')" 
                        onmouseout="hideddrivetip()" 
                        onselectedindexchanged="ddlMeritType_SelectedIndexChanged">
                                <asp:ListItem Value = "0">-- Select --</asp:ListItem>
                                <asp:ListItem Value = "MH">MH</asp:ListItem>
                                <asp:ListItem Value = "AI">AI</asp:ListItem>
                               <%-- <asp:ListItem Value = "JK">JK</asp:ListItem>--%>
                            </asp:DropDownList>
                </td>
            </tr>
        </table>
        <rsweb:ReportViewer ID="reportViewer" runat="server" ClientIDMode="Static" Height="700px" Width="1000px" Visible="False">
        </rsweb:ReportViewer>
    </cc1:ContentBox>
    </asp:content>