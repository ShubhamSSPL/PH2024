<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCompositeReportByCourse.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmCompositeReportByCourse" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Composite Report By Course" Width = "100%" Height = "350px" ScrollBars = "auto">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <b>Select Course Type : </b>
                    <asp:DropDownList ID="ddlCourseType" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "ddlCourseType_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>B.Pharmacy</asp:ListItem>
                        <asp:ListItem>Pharm.D</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" ShowFooter = "true" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="Course">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPIntake" HeaderText="CAP (Excluding Minority) Intake">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPAdmitted" HeaderText="CAP (Excluding Minority) Admitted">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ACAPAdmitted" HeaderText="Against CAP (Excluding Minority) Admitted">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MIIntake" HeaderText="CAP (Minority) Intake">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPMIAdmitted" HeaderText="CAP (Minority) Admitted">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ACAPMIAdmitted" HeaderText="Against CAP (Minority) Admitted">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ILIntake" HeaderText="IL Intake">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ILAdmitted" HeaderText="IL Admitted">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Total Intake">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Total Admitted">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Total Vacancy">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="JKAdmitted" HeaderText="JK Admitted">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="OthersAdmitted" HeaderText="Others Admitted">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
