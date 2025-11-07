<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCompositeReportForRO.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmCompositeReportForRO" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable2" runat="server" Width = "100%" Height="400px" ScrollBars = "auto">
        <asp:Button ID="btnExporttoExcel" runat="server" CssClass = "InputButtonRed" Text="Export to Excel" OnClick="btnExporttoExcel_Click" />
        <br /><br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <b>Select Course Type : </b>
                    <asp:DropDownList ID="ddlCourseType" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "ddlCourseType_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>B.Pharmacy</asp:ListItem>
                        <asp:ListItem>Pharm.D</asp:ListItem>
                        <%--<asp:ListItem>EWS</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
                <td align="center">
                    <b>Select Type : </b>
                    <asp:DropDownList ID="ddlTNA" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTNA_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>TFWS</asp:ListItem>
                        <asp:ListItem>NON TFWS</asp:ListItem>
                        <%--  <asp:ListItem>EWS</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvReport" ShowHeader="false" ShowFooter = "true" runat="server" CellPadding="10" CellSpacing="10" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" OnRowCreated="gvReport_RowCreated">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteCode" HeaderText = "InstituteCode">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteName" HeaderText = "InstituteName">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CAPIntake" HeaderText = "CAPIntake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "CAPAdmittedBefore" HeaderText = "CAPAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CAPAdmittedAfter" HeaderText = "CAPAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "CAPAdmitted" HeaderText = "CAPAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CAPCancelled" HeaderText = "CAPCancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CAPVacancy" HeaderText = "CAPVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ACAPIntake" HeaderText = "ACAPIntake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "ACAPAdmittedBefore" HeaderText = "ACAPAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ACAPAdmittedAfter" HeaderText = "ACAPAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "ACAPAdmitted" HeaderText = "ACAPAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ACAPCancelled" HeaderText = "ACAPCancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ACAPVacancy" HeaderText = "ACAPVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CAPMIIntake" HeaderText = "CAPMIIntake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "CAPMIAdmittedBefore" HeaderText = "CAPMIAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CAPMIAdmittedAfter" HeaderText = "CAPMIAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "CAPMIAdmitted" HeaderText = "CAPMIAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CAPMICancelled" HeaderText = "CAPMICancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CAPMIVacancy" HeaderText = "CAPMIVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ACAPMIIntake" HeaderText = "ACAPMIIntake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "ACAPMIAdmittedBefore" HeaderText = "ACAPMIAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ACAPMIAdmittedAfter" HeaderText = "ACAPMIAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "ACAPMIAdmitted" HeaderText = "ACAPMIAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ACAPMICancelled" HeaderText = "ACAPMICancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ACAPMIVacancy" HeaderText = "ACAPMIVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ILIntake" HeaderText = "ILIntake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "ILAdmittedBefore" HeaderText = "ILAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ILAdmittedAfter" HeaderText = "ILAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "ILAdmitted" HeaderText = "ILAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ILCancelled" HeaderText = "ILCancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ILVacancy" HeaderText = "ILVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalIntake" HeaderText = "TotalIntake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "TotalAdmittedBefore" HeaderText = "TotalAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalAdmittedAfter" HeaderText = "TotalAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "TotalAdmitted" HeaderText = "TotalAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalCancelled" HeaderText = "TotalCancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalVacancy" HeaderText = "TotalVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "JKIntake" HeaderText = "JKIntake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "JKAdmittedBefore" HeaderText = "JKAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "JKAdmittedAfter" HeaderText = "JKAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "JKAdmitted" HeaderText = "JKAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "JKCancelled" HeaderText = "JKCancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "JKVacancy" HeaderText = "JKVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "OAAAdmittedBefore" HeaderText = "OAAAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "OAAAdmittedAfter" HeaderText = "OAAAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "OAAAdmitted" HeaderText = "OAAAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "OAACancelled" HeaderText = "OAACancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
            
            <asp:BoundField DataField = "TotalEWSIntake" HeaderText = "TotalEWSIntake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "TotalAdmittedBefore" HeaderText = "TotalAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalAdmittedAfter" HeaderText = "TotalAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "TotalEWSAdmitted" HeaderText = "TotalEWSAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalEWSCancelled" HeaderText = "TotalEWSCancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalEWSVacancy" HeaderText = "TotalEWSVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
