<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmVacancyAfterUpdationForAdditionalRound.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmVacancyAfterUpdationForAdditionalRound" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <table class="AppFormTableWithOutBorder">
        <tr>
            <td align="center">
                <b>Select Course : </b>
                <asp:DropDownList ID="ddlCourseType" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "ddlCourseType_SelectedIndexChanged">
                    <asp:ListItem>B.Pharmacy</asp:ListItem>
                    <asp:ListItem>Pharm.D</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnChoiceCode" runat="server" />
    <br />
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Vacancy for Aditional Round">
        <table class="AppFormTable">
            <tr>
                <td align="right">Course Name</td>
                <td colspan = "3"><asp:Label ID="lblCourseName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:30%" align="right"> Against CAP (Excluding Minority) Vacancy</td>
                <td style="width: 20%"><asp:Label ID="lblMSIntake" runat="server" Font-Bold = "true"></asp:Label></td>
                <td style="width: 30%" align="right">Against CAP (Minority) Vacancy</td>
                <td style="width: 20%"><asp:Label ID="lblMIIntake" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <th rowspan = "2">Category Wise Vacancy of CAP (Excluding Minority)</th>
                <th colspan = "2">OPEN</th>
                <th colspan = "2">SC</th>
                <th colspan = "2">ST</th>
                <th colspan = "2">DT/VJ</th>
                <th colspan = "2">NT-1</th>
                <th colspan = "2">NT-2</th>
                <th colspan = "2">NT-3</th>
                <th colspan = "2">OBC</th>
                <th rowspan = "2">PWD</th>
                <th rowspan = "2">DEF</th>
                <th rowspan = "2">AI</th>
                <th rowspan = "2">TOTAL</th>
            </tr>
            <tr>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
            </tr>
            <tr>
                <td style = "width:11%" align = "center"><b>HU</b></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GOPENH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LOPENH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GSCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LSCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GSTH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LSTH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GVJDTH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LVJDTH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GNTBH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LNTBH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GNTCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LNTCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GNTDH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LNTDH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GOBCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LOBCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="PHCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="DEFH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="AIH" runat="server"></asp:Label></td>
                <td style = "width:5%" align = "center"><asp:Label ID="TOTALH" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td align = "center"><b>OHU</b></td>
                <td align = "center"><asp:Label ID="GOPENO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LOPENO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GSCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LSCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GSTO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LSTO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GVJDTO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LVJDTO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GNTBO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LNTBO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GNTCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LNTCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GNTDO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LNTDO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GOBCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LOBCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="PHCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="DEFO" runat="server"></asp:Label></td>
                 <td align = "center"><asp:Label ID="lblAIIntake" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="TOTALO" runat="server"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
