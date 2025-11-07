<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrintAdmissionApprovalFeeReceipt.aspx.cs" Inherits="Pharmacy2024.ARAModule.frmPrintAdmissionApprovalFeeReceipt" %>
<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%--<%@ Register Src="../UserControls/PrintFormHeader.ascx" TagName="PrintFormHeader" TagPrefix="ucPFH" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1" runat="server">
        <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
        <link rel="stylesheet" href="../Styles/Style.css" type="text/css" />
    </head>
    <body onload = "window.print();">
        <form id="form1" runat="server"> 
            <cc1:ShowMessage id="shInfo" runat="server"></cc1:ShowMessage>
            <table class="AppFormTable">
                <tr>
                    <td style="width:75%;"><font size = "2"><b>First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions <%= CurrentYear %></b></font></td>
                    <td style="width:25%;border-left-width:0px;" align = "right"><font size = "2"><b>Processing Fee Statement</b></font></td>
                </tr>
            </table>
            <%-- <ucPFH:PrintFormHeader Id="printFH" runat="server"></ucPFH:PrintFormHeader>--%>
            <table class="AppFormTable">
                <tr>
                    <td style="width:10%;border-top-width:0px;border-right-width:0px;" align="center"><img src="../Images/WebsiteLogo.png" alt = ""  style="width:73px; height:auto"/></td>
                    <td style="width:80%;border-top-width:0px;border-left-width:0px;" align="center">
                        <b>
                            <img src="../Images/WebsiteLogoOld_Print.png" alt = ""  /><br/>
                            <font size="4">G</font><font size="2">OVERNMENT</font> <font size="4">O</font><font size="2">F</font> <font size="4">M</font><font size="2">AHARASHTRA</font><BR />
                            <font size="4">A</font><font size="2">DMISSION</font> <font size="4">R</font><font size="2">EGULATING</font> <font size="4">A</font><font size="2">UTHORITY, </font>  <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font>
                            <br />
                            <font size = "1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
                            <br /><br />
                            <font size = "1">PROCESSING FEE STATEMENT FOR THE ACADEMIC YEAR <%= AdmissionYear %></font>
                            <%--<asp:Label id="lblTitle" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Small" Visible="false"><br /><br />For Non-CAP Admissions to Institution Level and ACAP Seats after CAP</asp:Label>--%>
                        </b>
                    </td>
                     <td style="width:10%;border-top-width:0px;border-left-width:0px;" align="center"><img src="../Images/ARAFINAL.png" alt = ""  style="width:73px; height:auto"/></td>
                </tr>
            </table>
            
            
            &nbsp;&nbsp;To,<br />
            &nbsp;&nbsp;<b>The Hon'ble Chairman,</b><br />
            &nbsp;&nbsp;ADMISSIONS REGULATING AUTHORITY, M.S. MUMBAI,<br />
            &nbsp;&nbsp;Maharashtra State, Mumbai - 400 001
            <table class="AppFormTable">
                <tr>
                    <th style="border-top-width:0px;" colspan = "2" align = "left">College Details</th>
                </tr>
                <tr>
                    <td style="width: 40%;" align="right">Code of the Institute</td>
                    <td style="width: 60%,">
                        <asp:Label ID="lblInstituteCode" runat="server" Font-Bold = "true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%;" align="right">Name of Institute</td>
                    <td style="width: 60%,">                        
                        <asp:Label ID="lblInstituteName" runat="server" Font-Bold = "true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%;" align="right">Institute Email ID</td>
                    <td style="width: 60%,">
                        <asp:Label ID="lblEmail" runat="server" Font-Bold = "true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%;" align="right">Institute Mobile</td>
                    <td style="width: 60%,">
                        <asp:Label ID="lblMobile" runat="server" Font-Bold = "true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40%;" align="right">Address</td>
                    <td style="width: 60%;"><asp:Label ID="lblInstituteAddress" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 40%;" align="right">Course</td>
                    <td style="width: 60%;"><b>B.Pharmacy/ Pharm.D.</b></td>
                </tr>
                <tr>
                    <td style="width: 40%;" align="right">Status</td>
                    <td style="width: 60%;"><asp:Label ID="lblStatus" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <th colspan = "2" align = "left">Composite Report
                    </th>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvReportComposite" ShowHeader="false" ShowFooter = "true" runat="server" CellPadding="10" CellSpacing="10" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" OnRowCreated="gvReportComposite_RowCreated">
                            <Columns> 
                                <asp:BoundField HeaderText="Sr. No.">
                                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" Wrap = "false" />
                                </asp:BoundField>
                                <asp:BoundField DataField = "ChoiceCodeDisplay" HeaderText = "ChoiceCodeDisplay">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField = "CourseName" HeaderText = "CourseName">
                                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                                </asp:BoundField>
                                <asp:BoundField DataField = "SanctionIntake" HeaderText = "Sanction Intake">
                                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                                </asp:BoundField>
                                <asp:BoundField DataField = "CAPAdmitted" HeaderText = "CAPAdmitted">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField = "ACAPAdmitted" HeaderText = "ACAPAdmitted">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField = "CAPMIAdmitted" HeaderText = "CAPMIAdmitted">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField = "ACAPMIAdmitted" HeaderText = "ACAPMIAdmitted">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField = "ILAdmitted" HeaderText = "ILAdmitted">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>
                                
                                <asp:BoundField DataField = "TotalAdmitted" HeaderText = "TotalAdmitted">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>
                                
                                <asp:BoundField DataField = "JKAdmitted" HeaderText = "JKAdmitted">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>
                                
                                <asp:BoundField DataField = "OAAAdmitted" HeaderText = "OAAAdmitted">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField = "TotalEWSAdmitted" HeaderText = "TotalEWSAdmitted">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField = "TotalAdmittedUploaded" HeaderText = "TotalAdmittedUploaded">
                                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                                </asp:BoundField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <th colspan = "2" align = "left">Processing Fee Statement:-<asp:Label id="lblNameAsPerHSCResult" runat="server" Font-Bold="true"></asp:Label>
                    </th>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvDashboardInstitute" runat="server" ShowFooter = "true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid"  >
                            <Columns>
                                <asp:BoundField DataField="CourseName" HeaderText="Course Name<br/>(1)" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" Wrap="true" Width="35%"/>
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="true" />
                                    <FooterStyle HorizontalAlign="Right" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CourseStatus1" HeaderText="Course Status" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" Wrap="true" Width="15%"/>
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="true" />
                                    <FooterStyle HorizontalAlign="Right" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CAPIntake" HeaderText="CAP <br />Intake<br/>(2)" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TFWSIntake" HeaderText="TFWS <br />Intake<br/>(3)" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                </asp:BoundField> 
                                <asp:BoundField DataField="DSEIntake" HeaderText="DSE <br />Intake<br/>(4)" HtmlEncode="false" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="AnyOtherSchemeIntake" HeaderText="Any Other <br />Scheme <br /> Intake<br/>(4)" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalNoofSeats" HeaderText="Total No of <br />Seats<br/>(5) = <br /> (2+4)" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="IntakeAmount" HeaderText="Intake Amount<br />(6) = (5) * <span class='rupee'>Rs.</span> 100/- <br />(Equal to or Not Less <br /> than <span class='rupee'>Rs.</span> 20000/-)" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="ILIntake" HeaderText="IL <br />Intake <br />(7)" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="NRIIntake" HeaderText="NRI <br />Intake <br />(8)" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="ILAmount" HeaderText="IL<br />Amount <br />(9) = (7) * <span class='rupee'>Rs.</span> 2000/-" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="NRIAmount" HeaderText="NRI<br />Amount <br />(10) = (8) * <span class='rupee'>Rs.</span> 3000/-" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalAmount" HeaderText="Amount Payable  <br />as  <br /> Processing Fee(<span class='rupee'>Rs.</span>) <br /> (11) = (6 + 9 + 10)" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                </asp:BoundField> 
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr> 
                 
            </table> 
            
            <table class="AppFormTable">
                <tr> 
                    <td colspan = "3">
                        <%--<center><b><font size = "2">Declaration</font></b></center>--%>
                        <p align = "justify">
                            <b>Undertaking:</b> I hereby declare that above information furnished by me is correct.
                        </p>
                    </td>
                </tr>
                <tr> 
                    <td style="width: 40%">
                        <br /><br />
                        <center>Place<br />
                        Confirm Date: <asp:Label id="lblConfirmDate" runat="server"></asp:Label><br />
                        Print Date: <asp:Label id="lblPrintDateInst" runat="server"></asp:Label></center>
                    </td>
                    <td>
                        <br /><br /><br />
                        <center>Seal</center>
                    </td>
                    <td style="width: 40%">
                        <br /><br />
                        <center>Signature of Dean / Principal / Head of the Institute<br />
                        <asp:Label id="lblInstCodeName" runat="server"></asp:Label></center>
                    </td>
                </tr>
            </table>

            <table class="AppFormTable">
                <tr> 
                    <td style="width: 20%;" align = "center">
                        <b>Institute Code</b>
                    </td>
                    <td style="width: 20%" align = "center">
                        <b>Receipt Number</b>
                    </td>
                    <td style="width: 20%" align = "center">
                        <b>Processing Fees (<span class="rupee">Rs.</span>)</b>
                    </td>
                    <td style="width: 20%" align = "center">
                        <b>Status</b>
                    </td>
                    <td align = "center">
                        <b>Bank Reference No.</b>
                    </td>
                </tr>
                <tr> 
                    <td align = "center">
                        <asp:Label id="lblInstCodeBottom" runat="server"></asp:Label>
                    </td>
                    <td align = "center">
                        <asp:Label id="lblReceiptNo" runat="server"></asp:Label>
                    </td>
                    <td align = "center">
                        <asp:Label ID="lblAdmissionApprovalFeePaid" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                    <td align = "center">
                        Paid
                    </td>
                    <td align = "center">
                        <asp:Label id="lblBankReferenceNo" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            <table class="AppFormTable">
                
                <tr>
                    <td style="width: 60%">
                        Place :&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Date : <asp:Label id="lblDate" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="width: 40%" align = "center" valign = "bottom" rowspan = "4"> 
                        Sd/-
                        <br/>
                        <asp:Label id="lblSecretary" runat="server" Text="Secretary" Font-Bold="True"></asp:Label><br/>
                        <asp:Label id="lblSecretary1" runat="server" Text="Admissions Regulating Authority" Font-Bold="True"></asp:Label>
                        
                       
                    </td>
                </tr>
                <tr>
                    <td>Printed On : <asp:Label id="lblPrintedOn" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
                <tr>
                    <td>Last Modified On : <asp:Label id="lblLastModifiedOn" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
                <tr>
                    <td>Last Modified By : <asp:Label id="lblLastModifiedBy" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
            </table>
        </form>
    </body>
</html>
