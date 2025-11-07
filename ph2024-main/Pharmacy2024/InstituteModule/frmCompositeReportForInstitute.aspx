<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCompositeReportForInstitute.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmCompositeReportForInstitute" %>
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
                      <%--  <asp:ListItem>EWS</asp:ListItem>--%>
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
                <asp:HyperLinkField DataTextField = "ChoiceCodeDisplay" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmPrintAdmittedCandidateListToSubmit.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}" Target="_blank" HeaderText = "ChoiceCodeDisplay">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <%--<asp:BoundField DataField = "ChoiceCodeDisplay" HeaderText = "ChoiceCode">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "CourseName" HeaderText = "CourseName">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CAPIntake" HeaderText = "CAPIntake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:HyperLinkField DataTextField = "CAPAdmittedBefore" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=CAPAB" HeaderText = "CAPAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "CAPAdmittedAfter" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=CAPAA" HeaderText = "CAPAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:HyperLinkField DataTextField = "CAPAdmitted" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=CAPA" HeaderText = "CAPAdmitted">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "CAPCancelled" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=CAPC" HeaderText = "CAPCancelled">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
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
                <%--<asp:HyperLinkField DataTextField = "ACAPAdmittedBefore" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ACAPAB" HeaderText = "ACAPAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "ACAPAdmittedAfter" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ACAPAA" HeaderText = "ACAPAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:HyperLinkField DataTextField = "ACAPAdmitted" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ACAPA" HeaderText = "ACAPAdmitted">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "ACAPCancelled" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ACAPC" HeaderText = "ACAPCancelled">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
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
                <%--<asp:HyperLinkField DataTextField = "CAPMIAdmittedBefore" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=CAPMIAB" HeaderText = "CAPMIAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "CAPMIAdmittedAfter" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=CAPMIAA" HeaderText = "CAPMIAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:HyperLinkField DataTextField = "CAPMIAdmitted" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=CAPMIA" HeaderText = "CAPMIAdmitted">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "CAPMICancelled" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=CAPMIC" HeaderText = "CAPMICancelled">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
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
                <%--<asp:HyperLinkField DataTextField = "ACAPMIAdmittedBefore" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ACAPMIAB" HeaderText = "ACAPMIAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "ACAPMIAdmittedAfter" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ACAPMIAA" HeaderText = "ACAPMIAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:HyperLinkField DataTextField = "ACAPMIAdmitted" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ACAPMIA" HeaderText = "ACAPMIAdmitted">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "ACAPMICancelled" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ACAPMIC" HeaderText = "ACAPMICancelled">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
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
                <%--<asp:HyperLinkField DataTextField = "ILAdmittedBefore" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ILAB" HeaderText = "ILAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "ILAdmittedAfter" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ILAA" HeaderText = "ILAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:HyperLinkField DataTextField = "ILAdmitted" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ILA" HeaderText = "ILAdmitted">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "ILCancelled" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=ILC" HeaderText = "ILCancelled">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
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
                <%--<asp:HyperLinkField DataTextField = "TotalAdmittedBefore" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=TAB" HeaderText = "TotalAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "TotalAdmittedAfter" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=TAA" HeaderText = "TotalAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:HyperLinkField DataTextField = "TotalAdmitted" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=TA" HeaderText = "TotalAdmitted">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "TotalCancelled" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=TC" HeaderText = "TotalCancelled">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
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
                <%--<asp:HyperLinkField DataTextField = "JKAdmittedBefore" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=JKAB" HeaderText = "JKAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "JKAdmittedAfter" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=JKAA" HeaderText = "JKAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:HyperLinkField DataTextField = "JKAdmitted" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=JKA" HeaderText = "JKAdmitted">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "JKCancelled" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=JKC" HeaderText = "JKCancelled">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:BoundField DataField = "JKVacancy" HeaderText = "JKVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:HyperLinkField DataTextField = "OAAAdmittedBefore" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=OAAAB" HeaderText = "OAAAdmittedBefore">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "OAAAdmittedAfter" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=OAAAA" HeaderText = "OAAAdmittedAfter">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:HyperLinkField DataTextField = "OAAAdmitted" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=OAAA" HeaderText = "OAAAdmitted">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "OAACancelled" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=OAAC" HeaderText = "OAACancelled">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
            
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
              
            <asp:HyperLinkField DataTextField = "TotalEWSAdmitted" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=EWSA" HeaderText = "TotalEWSAdmitted">
                <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
            </asp:HyperLinkField>
           <%-- <asp:BoundField DataField = "TotalEWSAdmitted" HeaderText = "TotalEWSAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
            
            
            <asp:HyperLinkField DataTextField = "TotalEWSCancelled" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmCompositeReport.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}&Flag=EWSC" HeaderText = "TotalEWSCancelled">
                <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
            </asp:HyperLinkField>
               <%-- <asp:BoundField DataField = "TotalEWSCancelled" HeaderText = "TotalEWSCancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "TotalEWSVacancy" HeaderText = "TotalEWSVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
