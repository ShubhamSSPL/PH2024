<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAdmissionLetter.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmAdmissionLetter" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        function OpenPopUpWindow() {
            window.open("frmPrintAdmissionLetter.aspx?PID=<% = PID %>&ChoiceCode=<% = ChoiceCode %>&CAPRound=<% = CAPRound %>", "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes");
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
                <td align="center"><font size="2"><b>Receipt-Cum-Acknowledgement of Confirmation of Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></b></font></td>
            </tr>
            <tr>
                <td align="center">
                    <font size="2">Application ID : </font>
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <font size="2">Receipt No : </font>
                    <asp:Label ID="lblReceiptNo" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" colspan="4" align="left">Personal Details</th>
            </tr>
            <tr>
                <td align="right">Candidate Name</td>
                <td colspan="3">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Gender</td>
                <td style="width: 25%">
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Date Of Birth</td>
                <td style="width: 25%">
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td>
                    <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Home University</td>
                <td>
                    <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category</td>
                <td>
                    <asp:Label ID="lblOriginalCategory" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Category for Admission</td>
                <td>
                    <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for EWS</td>
                <td>
                    <asp:Label ID="lblAppliedForEWS" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Applied for Orphan</td>
                <td>
                    <asp:Label ID="lblAppliedForOrphan" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Person with Disability</td>
                <td>
                    <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Defence Type</td>
                <td>
                    <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Linguistic Minority</td>
                <td>
                    <asp:Label ID="lblLinguisticMinority" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Religious Minority</td>
                <td>
                    <asp:Label ID="lblReligiousMinority" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for TFWS</td>
                <td colspan="2">
                    <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="left">Admission Details</th>
            </tr>
            <tr>
                <td align="right">Merit No</td>
                <td>
                    <asp:Label ID="lblMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Merit Marks</td>
                <td>
                    <asp:Label ID="lblMeritMarks" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Institute Name</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Name</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Choice Code</td>
                <td>
                    <asp:Label ID="lblChoiceCode" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Seat Type</td>
                <td>
                    <asp:Label ID="lblSeatType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Preference No.</td>
                <td>
                    <asp:Label ID="lblPreferenceNo" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Date of Admission</td>
                <td>
                    <asp:Label ID="lblAdmissionDate" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
              <th align = "left" colspan = "4"> Exam Name Details</th>
            </tr>
            <tr>
                <td align="right">Name As Per HSC Result</td>
                <td colspan="3">
                <asp:Label ID="lblNameAsPerHSCResult" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Name As Per MHT-CET Result</td>
                <td colspan="3">
                <asp:Label ID="lblCETCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr  runat="server" visible="false">
                <td align="right">Name As Per NEET Result</td>
                <td colspan="3">
                <asp:Label ID="lblNEETName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trFee1" runat="server">
                <th colspan="4" align="left">Fee Details</th>
            </tr>
            <tr id="trFee2" runat="server">
                <td colspan="4">
                    <asp:GridView ID="gvFeeList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="15%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FeeAmount" HeaderText="Fee Amount (<span class='rupee'>Rs.</span>)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDNumber" HeaderText="DD/Cheque Number">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="11%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDDate" HeaderText="Payment Date">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="11%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BankName" HeaderText="Bank Name">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BranchName" HeaderText="Branch Name">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="trDocumentsSubmitted1" runat="server">
                <th align="left" colspan="4">List of Documents Submitted at Institute</th>
            </tr>
            <tr id="trDocumentsSubmitted2" runat="server">
                <td colspan="4">
                    <asp:GridView ID="gvDocumentsSubmitted" runat="server" AutoGenerateColumns="False" Width="100%" BorderWidth="1px" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Document Name" ReadOnly="True" DataField="DocumentName" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" Width="90%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="trDocumentsNotSubmitted1" runat="server">
                <th align="left" colspan="4">List of Documents Not Submitted at Institute</th>
            </tr>
            <tr id="trDocumentsNotSubmitted2" runat="server">
                <td colspan="4">
                    <asp:GridView ID="gvDocumentsNotSubmitted" runat="server" AutoGenerateColumns="False" Width="100%" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Document Name" ReadOnly="True" DataField="DocumentName" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" Width="90%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="trComments" runat="server" visible="false">
                <td colspan="4"><b>Comments : </b>
                    <asp:Label ID="lblComments" runat="server"></asp:Label></td>
            </tr>
            <tr runat="server" id="trCVCMsg" visible="false">
                <td colspan="4" style="color:red"> <b>The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                   
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                </b> </td>
            </tr>
            <tr>
                <td colspan="4">
                    <center><b><font size = "2">Undertaking By Candidate</font></b></center>
                    <br />
                    <p align="justify">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        I hereby agree to confirm to rules, acts and laws enforced by Government from time to time. I hereby undertake that so long as I am student of College / Institute, I will not behave in a manner which may result in compelling the authorities to take disciplinary action against me. I fully understand that the Principal / Director of College / Institute will have rights to expel, rusticate me from the institute, for any infringement of the rules prescribed by the college / institute / university / government and the undertaking given above. I also herewith undertake that, at later stage, if it is found that  I have  submitted false certificate(s)/document(s), I am aware that my admission stands cancelled and fees paid by me will be forfeited. Further I will be subjected to legal and/or penal action as per the provisions of the law.
                    </p>
                </td>
            </tr>
            <tr>
                <td valign="bottom" colspan="2">Place :&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;Date :
                    <br />
                    <br />
                    <br />
                    Printed On :
                    <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="center" valign="bottom" colspan="2">
                    <br />
                    <br />
                    Signature of Candidate
                    <br />
                    (<asp:Label ID="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <center><b><font size = "2">Declaration by the College / Institute</font></b></center>
                    <br />
                    <p align="justify">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        We hereby declare that, we are admitting this Candidate to our Institution for the academic year <%= AdmissionYear %> on verification of Candidate's Identity and all the required documents mentioned. The candidate has paid the Fees mentioned in this receipt. We also declare that the admission of Candidate is confirmed in presence of the Candidate.
                    </p>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="width: 35%; border-top-width: 0px;">Printed By :
                    <asp:Label ID="lblPrintedBy" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    Reported By :
                    <asp:Label ID="lblReportedBy" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    Reported On :
                    <asp:Label ID="lblReportedOn" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 22%; border-top-width: 0px;" valign="bottom" align="center">Seal of Institution</td>
                <td style="width: 43%; border-top-width: 0px;" valign="bottom" align="center" colspan="2">Name, Designation and Signature of the Issuing Officer</td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <input id="btnPrint2" type="button" value="Print Admission Letter" class="InputButton" onclick="javascript: OpenPopUpWindow()" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
