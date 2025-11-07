<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ApplicationStatestics.aspx.cs" Inherits="Pharmacy2024.StaticPages.ApplicationStatestics" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownList_OptGroup" Namespace="DropDownList_OptGroup" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <title></title>
 
 <link rel=Stylesheet href="../Styles/TableStyle.css" />
 <style type="text/css">
body
{
    margin: 0;
    padding: 0;
    font-family: Arial;
}
.modal
{
    position: fixed;
    z-index: 1999;
    height: 100%;
    width: 100%;
    top: 0;
    background-color: Black;
    filter: alpha(opacity=60);
    opacity: 0.6;
    -moz-opacity: 0.8;
}
.center
{
    z-index: 1000;
    margin: 300px auto;
    padding: 10px;
    width: 130px;
    background-color: White;
    border-radius: 10px;
    filter: alpha(opacity=100);
    opacity: 1;
    -moz-opacity: 1;
}
.center img
{
    height: 128px;
    width: 128px;
}
.main-table 
{
    width:60%;
}
@media only screen and (max-width: 768px) {
.main-table 
{
    width:100%;
}
}
</style>
</head>

<body>
    <form id="form1" runat="server">

<div ID="rightContainer" runat="Server">
<asp:ScriptManager runat="server" ID="MainScriptManager" />
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible = "false">
     
        <center> 
            <asp:Label ID = "lblHeader" runat = "server" Font-Names="Bookman Old Style" Font-Size = "Medium"  >
               Welcome for Admission to First Year of Full Time Under Graduate Technical Courses for the Academic Year <%= AdmissionYear %>
            </asp:Label>
        </center>
        <asp:UpdateProgress runat="server" id="PageUpdateProgress" AssociatedUpdatePanelID="upDashboard">
            <ProgressTemplate>
                <%--<div class="modal">
                    <div class="center">--%>
                        <img src ="../Images/BigProgress.gif" alt = "" />
                   <%-- </div>
                </div>--%>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upDashboard">
            <ContentTemplate>
            <table width="100%">
                <tr>
                    <td width="45%" align="right">
                        <asp:button id="btnAll"  runat="server" CssClass="InputButton btn" BackColor="#5cb85c"  Text=" ALL "   Font-Bold="true" OnClick="btnAll_Click" ></asp:button>
                    </td>
                    <td width="10%" align="center">
                        <asp:button id="btnFE"  runat="server" CssClass="InputButton btn" BackColor="white"  Text=" BE / B.Tech "   Font-Bold="true" OnClick="btnFE_Click" ></asp:button>
                    </td>
                    <td width="45%" align="left">
                        <asp:button id="btnPH" runat="server" CssClass="InputButton btn" BackColor="white" Text=" B. Pharmacy & Pharm. D "   Font-Bold="true" OnClick="btnPH_Click"></asp:button>
                    </td>
                </tr>
            </table>
                <table class = "main-table d-block mx-auto" id = "tblDashboard" runat = "server" visible = "false" >
                    
                    <tr>
                        <td align="center" class="pt-3">
                             <asp:Label ID = "lblHeader1"  runat = "server" Font-Names="Bookman Old Style" Font-Bold="true" Font-Size = "Medium"   >
                            </asp:Label>
                        </td>
                    </tr>
                    <tr id="trAll" runat="server" visible="false">
                        <td valign = "top" width="60%" align="center">
                            <center><b>Application Status Wise Report</b></center>
                            <asp:GridView ID="gvApplicationStatusReportAll" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid  table1">
                                <Columns>
                                    <asp:BoundField DataField="FormStatus" HeaderText="Application Status">
                                        <ItemStyle HorizontalAlign="Right" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FETotal" HeaderText="BE/B.Tech">
                                        <ItemStyle  HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PHTotal" HeaderText="B. Pharm & Pharm. D.">
                                        <ItemStyle  HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                          </td>
                     </tr>

                    <tr id="trFC" runat="server" visible="false">
                        <td valign = "top" width="60%" align="center">
                            <center><b>Application Status Wise Report</b></center>
                            <asp:GridView ID="gvApplicationStatusReport" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid  table1">
                                <Columns>
                                    <asp:BoundField DataField="FormStatus" HeaderText="Application Status">
                                        <ItemStyle HorizontalAlign="Right" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle  HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                          </td>
                    </tr>
                    <tr id="trCategory" runat="server" visible="false">
                        <td valign = "top" width="60%" align="center">
                            <center ><b>Category Wise Confirmed at SC Report</b></center>
                            <asp:GridView ID="gvCategoryWiseReport" runat="server" ShowFooter = "true" AutoGenerateColumns="False"  CellPadding="5" CssClass="DataGrid  table4 ">
                            <Columns>
                                <asp:BoundField DataField="CategoryName" HeaderText="Category">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Total" HeaderText="Total">
                                    <ItemStyle  HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" CssClass="Header" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    </tr>
                    <tr id="trCVC" runat="server" visible="false">
                        <td valign = "top" width="60%" align="center">
                            <center><b>CVC / TVC Status Wise Report</b></center>
                            <asp:GridView ID="gvCVCStatus" runat="server" AutoGenerateColumns="true" ShowFooter="true" Width="100%" CellPadding="5" CssClass="DataGrid " RowStyle-HorizontalAlign="Center">
                            </asp:GridView>
                        </td>
                     </tr>
                    <tr id="trNCL" runat="server" visible="false">
                        <td valign = "top" width="60%" align="center">
                            <center><b>NCL Status Wise Report</b></center>
                            <asp:GridView ID="gvNCLStatus" runat="server" AutoGenerateColumns="true" ShowFooter="true" Width="100%" CellPadding="5" CssClass="DataGrid " RowStyle-HorizontalAlign="Center">
                            </asp:GridView>
                        </td>
                    </tr>
                    
                    
                     <%--<tr id="trDashboardType" runat="server">
                        <td style="text-align: right">Select Dashboard Type : </td>
                        <td>
                            <asp:DropDownList ID="ddlDashboard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDashboard_SelectedIndexChanged" CssClass="form-control pl-2">
                                <asp:ListItem Value="1">Confirmed At SCs</asp:ListItem>
                                <asp:ListItem Value="2">Provisional Merit List</asp:ListItem>
                                <asp:ListItem Value="3">Final Merit List</asp:ListItem>
                                <asp:ListItem Value="4">Fill Completyly But not Confirmed</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</div>

    </form>
</body>
</html>


