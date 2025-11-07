<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCVCTVCNonSTListCM.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCVCTVCNonSTListCM" %>
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
    <table>
        <td style="width: 25%;" align="right">
           Select Authority District &nbsp&nbsp&nbsp&nbsp
        </td>
        <td style="width: 25%;">
            <asp:DropDownList ID="ddlCDistrict" runat="server" Width="90%" AutoPostBack="true"
                OnSelectedIndexChanged="ddlCDistrict_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </table>
    <br />
    <br />
    <cc1:ContentBox ID="ContentBox1" HeaderText="" runat="server" ScrollBars="Auto" Height="205px">
      <asp:Button ID="btnexport" runat="server" CssClass="InputButtonRed" Text="Export to Excel"
            OnClick="btnexport_Click" />
        <asp:GridView ID="GridView1" runat="server" ShowFooter="false" AutoGenerateColumns="false" ShowHeader="false"
            Width="100%" CssClass="DataGrid" EmptyDataText="No Records Found" OnRowCreated="GridView1_RowCreated">
            <Columns>
                <asp:BoundField DataField="SrNo" HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="Course" HeaderText="Course">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="LDate" HeaderText="LDate">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="SCTBE" HeaderText="SCNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="VJDTTBE" HeaderText="DTVJNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="SBCTBE" HeaderText="SBCNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="OBCTBE" HeaderText="OBCNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
               <asp:BoundField DataField="TotalT" HeaderText="TotalT">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>

                  <asp:BoundField DataField="SCNSBE" HeaderText="SCNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="VJDTNSBE" HeaderText="VJDTNSBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="SBCNSBE" HeaderText="SBCNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="OBCNSBE" HeaderText="OBCNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalNS" HeaderText="TotalNS">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>


                 <asp:BoundField DataField="SCNBE" HeaderText="SCNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="VJDTNBE" HeaderText="DTVJNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="SBCNBE" HeaderText="SBCNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="OBCNBE" HeaderText="OBCNBE">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalN" HeaderText="TotalN">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField> 
                

            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
  <cc1:ContentBox ID="ContentTable1" HeaderText=""
        runat="server" ScrollBars="Auto" Height="605px">
        <asp:Button ID="btnExporttoExcel" runat="server" CssClass="InputButtonRed" Text="Export to Excel"
            OnClick="btnExporttoExcel_Click" />
        <br />
        <asp:GridView ID="gvCVCTVCNonSTList" runat="server" ShowFooter="true" AutoGenerateColumns="True"
            Width="100%" CssClass="DataGrid" EmptyDataText="No Records Found" >
        </asp:GridView>
    </cc1:ContentBox> 
    </form>
</body>
</html>
