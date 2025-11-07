<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrintAdmissionLetterAtIL.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmPrintAdmissionLetterAtIL" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1" runat="server">
        <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
        <link rel="stylesheet" href="../Styles/Style.css" type="text/css" />
    </head>
    <style>
        #shInfo img{
            height: 10px;
        }
    </style>
    <body onload = "window.print();">
        <form id="form1" runat="server">
            <cc1:ShowMessage id="shInfo" runat="server"></cc1:ShowMessage>
            <table class="AppFormTable">
                <tr>
                    <td align = "center"><font size = "2"><b>Receipt-Cum-Acknowledgement of Confirmation of Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></b></font></td>
                 </tr>
                <tr>
                    <td align = "center">
                        <font size = "2">Application ID : </font><asp:Label id="lblApplicationID" runat="server" Font-Bold="True" Font-Size = "Small"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <font size = "2">Receipt No : </font><asp:Label id="lblReceiptNo" runat="server" Font-Bold="True" Font-Size = "Small"></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="AppFormTable">
                <tr>
                    <th style="border-top-width:0px;" colspan = "4" align = "left">Personal Details</th>
                </tr>
                <tr>
                    <td align = "right">Candidate Name</td>
                    <td colspan = "3"><asp:Label id="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width:25%" align = "right">Gender</td>
                    <td style="width:25%"><asp:Label id="lblGender" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td style="width:25%" align="right">Date Of Birth</td>
                    <td style="width:25%"><asp:Label id="lblDOB" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">Candidature Type</td>
                    <td><asp:Label id="lblCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td align="right">Home University</td>
	                <td><asp:Label id="lblHomeUniversity" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">Category</td>
                    <td><asp:Label id="lblOriginalCategory" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td align="right">Category for Admission</td>
                    <td><asp:Label id="lblCategoryForAdmission" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">Applied for EWS</td>
                    <td><asp:Label id="lblAppliedForEWS" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td align="right">Applied for Orphan</td>
                    <td><asp:Label id="lblAppliedForOrphan" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">Person with Disability</td>
                    <td><asp:Label id="lblPHType" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td align="right">Defence Type</td>
                    <td><asp:Label id="lblDefenceType" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">Linguistic Minority</td>
                    <td><asp:Label ID="lblLinguisticMinority" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td align="right">Religious Minority</td>
                    <td><asp:Label ID="lblReligiousMinority" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                <td align="right">Applied for TFWS</td>
                <td colspan="3">
                    <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">HSC Eligibility Marks</td>
                    <td><asp:Label id="lblHSCEligibilityPercentage" runat="server" Font-Bold = "true"></asp:Label></td> 
                    <td align="right">Diploma Eligibility Marks</td>
                    <td><asp:Label id="lblDiplomaEligibilityPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">CET PCMB Max Percentile</td>
                    <td><asp:Label id="lblCETPCMBMAX" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td align="right">NEET Total Percentile</td>
                    <td><asp:Label id="lblNEETTotal" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">State General Merit No</td>
                    <td><asp:Label id="lblStateGeneralMeritNo" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td align="right">AI Merit No</td>
                    <td><asp:Label id="lblAIMertiNo" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <th colspan = "4" align = "left">Admission Details (Admission Done by Institute)</th>
                </tr>
                <tr>
                    <td align="right">Merit No</td>
                    <td><asp:Label id="lblMeritNo" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td align="right">Merit Marks</td>
                    <td><asp:Label id="lblMeritMarks" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">Institute Name</td>
                    <td colspan = "3"><asp:Label id="lblInstituteName" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">Course Name</td>
                    <td colspan = "3"><asp:Label id="lblCourseName" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">Choice Code</td>
                    <td><asp:Label id="lblChoiceCode" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td align="right">Date of Admission</td>
                    <td><asp:Label id="lblAdmissionDate" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                   <td align="right">Seat Type</td>
                    <td colspan="3"><asp:Label id="lblSeatType" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr id = "trFee1" runat = "server">
                    <th colspan = "4" align = "left">Fee Details</th>
                </tr>
                <tr id = "trFee2" runat = "server">
                    <td colspan = "4">
                        <asp:GridView ID="gvFeeList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth = "1px" CssClass="DataGrid">
                            <Columns>
                                <asp:BoundField HeaderText="Sr. No.">
                                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "8%" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode">
                                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "15%" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FeeAmount" HeaderText="Fee Amount (<span class='rupee'>Rs.</span>)" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "10%" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DDNumber" HeaderText="DD/Cheque Number">
                                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "11%" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DDDate" HeaderText="Payment Date">
                                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "11%" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BankName" HeaderText="Bank Name">
                                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "25%" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BranchName" HeaderText="Branch Name">
                                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "20%" />
                                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr id = "trComments" runat = "server" visible = "false">
                    <td colspan = "4"><b>Comments : </b><asp:Label id="lblComments" runat="server"></asp:Label></td>
                </tr>
                <tr> 
                    <td colspan = "4">
                        <center><b><font size = "2">Undertaking By Candidate</font></b></center>
                        <br />
                        <p align = "justify">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            I hereby agree to confirm to rules, acts and laws enforced by Government from time to time. I hereby undertake that so long as I am student of College / Institute, I will not behave in a manner which may result in compelling the authorities to take disciplinary action against me. I fully understand that the Principal / Director of College / Institute will have rights to expel, rusticate me from the institute, for any infringement of the rules prescribed by the college / institute / university / government and the undertaking given above. I also herewith undertake that, at later stage, if it is found that  I have  submitted false certificate(s)/document(s), I am aware that my admission stands cancelled and fees paid by me will be forfeited. Further I will be subjected to legal and/or penal action as per the provisions of the law.
                        </p>
                    </td>
                </tr>
                <tr>
                    <td valign = "bottom" colspan = "2">
                        Place :&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;Date :
                        <br /><br /><br />
                        Printed On : <asp:Label id="lblPrintedOn" runat="server" Font-Bold = "true"></asp:Label>
                    </td>
                    <td align = "center" valign = "bottom" colspan = "2">
                        <br /><br /> 
                        Signature of Candidate
                        <br/>
                        (<asp:Label id="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
                    </td>
                </tr>
                <tr> 
                    <td colspan = "4">
                        <center><b><font size = "2">Declaration by the College / Institute</font></b></center>
                        <br />
                        <p align = "justify">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            We hereby declare that, we are admitting this Candidate to our Institution for the academic year <%= AdmissionYear %> on verification of Candidate's Identity and all the required documents mentioned. The candidate has paid the Fees mentioned in this receipt. We also declare that the admission of Candidate is confirmed in presence of the Candidate.
                        </p>
                    </td>
                </tr>
            </table>
            <table class="AppFormTable">
                <tr>
                    <td style="width:35%;border-top-width:0px;">
                        Printed By : <asp:Label id="lblPrintedBy" runat="server" Font-Bold="True"></asp:Label>
                        <br /><br />
                        Reported By : <asp:Label id="lblReportedBy" runat="server" Font-Bold="True"></asp:Label>
                        <br /><br />
                        Reported On : <asp:Label id="lblReportedOn" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td style="width:22%;border-top-width:0px;" valign="bottom" align="center">Seal of Institution</td>
                    <td style="width:43%;border-top-width:0px;" valign="bottom" align="center" colspan = "2">Name, Designation and Signature of the Issuing Officer</td>
                </tr>
            </table>
        </form>
    </body>
</html>