<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmConsolatedAlladmissionCvcTvcReport.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmConsolatedAlladmissionCvcTvcReport" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
</head>
<body>
<form id="VacancyReportForm" runat="server">
<div class="header">
    <div class="header-left">
        <img alt="Logo" src="../Images/WebsiteLogo.png" />
    </div>
    <div class="header-right">
        <p class="logo-subtitle">
            State Common Entrance Test Cell, Government of Maharashtra
            <br />
        </p>
    </div>
</div>
<br />
<br />
<br />
<br />
<br />
<br />
<br />
 
    <cc1:ContentBox ID="ContentTable1"  HeaderText="" runat="server">
        <asp:GridView ID="gvReportEN" runat="server" ShowFooter="true"  OnDataBound="gvReportEN_DataBound"
            AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid" AlternatingRowStyle-BackColor="#EEF9F8">
              <Columns>
                <asp:BoundField DataField="SrNO" HeaderText="Sr.No.">
                    <ItemStyle Width="5%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                               CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                 <asp:BoundField DataField="AdmissionCategory" HeaderText="Category">
                    <ItemStyle Width="16%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalMeritTotal" HeaderText="No Of Candidates in Final Merit List">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AllotedSum_IN_CAP1" HeaderText="No of candidate Submitted CVC/TVC">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Alloted_NotSubInCAP1" HeaderText="No of candidate Not Submitted CVC/TVC">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="NOAllot_Submitted" HeaderText="No of candidate Submitted CVC/TVC">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="NOAllot_NotSubmitted" HeaderText=" No of candidate Not Submitted CVC/TVC">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ConvertToOpen" HeaderText="No of Candidate Converted to General">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                  <asp:BoundField DataField="NotEligible" HeaderText="Not Eligible due to CVC/TVC Non-Submission">
                      <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                                 CssClass="Item" />
                      <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                      <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                  </asp:BoundField>
              </Columns>
        </asp:GridView>
    </cc1:ContentBox>
    
    <br/>
    <br/>
        <cc1:ContentBox ID="ContentBoxPH" HeaderText="" runat="server">
        <asp:GridView ID="gvReportPH" runat="server" ShowFooter="true"  OnDataBound="gvReportPH_DataBound" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid" AlternatingRowStyle-BackColor="#EEF9F8">
              <Columns>
                <asp:BoundField DataField="SrNO" HeaderText="Sr.No.">
                    <ItemStyle Width="5%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                               CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                 <asp:BoundField DataField="AdmissionCategory" HeaderText="Category">
                    <ItemStyle Width="16%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalMeritTotal" HeaderText="No Of Candidates in Final Merit List">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AllotedSum_IN_CAP1" HeaderText="No of candidate Submitted CVC/TVC">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Alloted_NotSubInCAP1" HeaderText="No of candidate Not Submitted CVC/TVC">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="NOAllot_Submitted" HeaderText="No of candidate Submitted CVC/TVC">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="NOAllot_NotSubmitted" HeaderText=" No of candidate Not Submitted CVC/TVC">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ConvertToOpen" HeaderText="No of Candidate Converted to General">
                    <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                        CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                </asp:BoundField>
                  <asp:BoundField DataField="NotEligible" HeaderText="Not Eligible due to CVC/TVC Non-Submission">
                      <ItemStyle Width="13%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid"
                                 CssClass="Item" />
                      <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                      <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                  </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
 
</form>
</body>
</html>