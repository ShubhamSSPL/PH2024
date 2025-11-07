<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frmTotalAdmittedandVacancyARA.aspx.cs"
    Inherits="Pharmacy2024.StaticPages.frmTotalAdmittedandVacancyARA" %>

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
  <%--  <table>
        <td style="width: 25%;" align="right">
           Select Authority District &nbsp&nbsp&nbsp&nbsp
        </td>
        <td style="width: 25%;">
            <asp:DropDownList ID="ddlCDistrict" runat="server" Width="90%" AutoPostBack="true"
                OnSelectedIndexChanged="ddlCDistrict_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </table>--%>
    <br />
     <asp:Button ID="btnExporttoExcel" runat="server" CssClass="InputButtonRed" Text="Export to Excel"
            OnClick="btnExporttoExcel_Click" />
    <br />
    <cc1:ContentBox ID="ContentBox1" HeaderText="" runat="server" ScrollBars="Auto">
        <asp:GridView ID="GridView1" runat="server" ShowFooter="false" AutoGenerateColumns="false" ShowHeader="false"
            Width="100%" CssClass="DataGrid" EmptyDataText="No Records Found" OnRowCreated="GridView1_RowCreated">
            <Columns>
                <asp:BoundField DataField="Srno" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="GVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 
                 <asp:BoundField DataField="GAInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GAIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GAAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="GAVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="UMInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UMIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UMAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="UMVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>


                <asp:BoundField DataField="UAInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UAIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UAAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="UAVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>


                 <asp:BoundField DataField="TInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="TVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>

    <br />
    <br />
    <cc1:ContentBox ID="ContentTable1" HeaderText=""
        runat="server" ScrollBars="Auto" Height="605px">
        <asp:Button ID="btnExporttoExcel2" runat="server" CssClass="InputButtonRed" Text="Export to Excel"
            OnClick="btnExporttoExcel2_Click" />
        <br />
        <asp:GridView ID="GridView2" runat="server" ShowFooter="false" AutoGenerateColumns="false" ShowHeader="false"
            Width="100%" CssClass="DataGrid" EmptyDataText="No Records Found" OnRowCreated="GridView2_RowCreated">
            <Columns>
                <asp:BoundField DataField="Srno" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="GVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 
                 <asp:BoundField DataField="GAInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GAIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GAAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="GAVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="UMInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UMIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UMAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="UMVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>


                <asp:BoundField DataField="UAInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UAIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UAAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="UAVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>


                 <asp:BoundField DataField="TInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="TVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
   
    <%--<cc1:ContentBox ID="ContentBox2" HeaderText=""
        runat="server" ScrollBars="Auto" Height="605px">
        <asp:Button ID="btnExporttoExcel3" runat="server" CssClass="InputButtonRed" Text="Export to Excel"
            OnClick="btnExporttoExcel3_Click" />
        <br />
        <asp:GridView ID="GridView3" runat="server" ShowFooter="false" AutoGenerateColumns="false" ShowHeader="false"
            Width="100%" CssClass="DataGrid" EmptyDataText="No Records Found" OnRowCreated="GridView3_RowCreated">
            <Columns>
                <asp:BoundField DataField="Srno" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="GVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 
                 <asp:BoundField DataField="GAInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GAIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="GAAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="GAVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="UMInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UMIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UMAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="UMVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>


                <asp:BoundField DataField="UAInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UAIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="UAAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="UAVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>


                 <asp:BoundField DataField="TInst" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TIntake" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TAdmitted" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="TVacancy" HeaderText="">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="center" CssClass="Footer" Wrap="false" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>--%> 
    </form>
</body>
</html>

