<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmApplicationForm.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmApplicationForm" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function OpenPopUpWindow() {
            window.open("frmPrintApplicationForm.aspx?PID=<% = PID %>", "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes");
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder" id="tblPrint1" runat="server">
            <tr>
                <td align="center">
                    <input id="btnPrint1" type="button" runat="server" value="Print Application Form" class="InputButton" onclick="javascript: OpenPopUpWindow()" />
                </td>
            </tr>
            <tr>
                <td>
                    <div id="Note">
                        <font color="red">
                            <ol class="list-text">
                                <b>Important Instructions for Printing :</b>
                                <li>Before printing acess the <b>"Page Setup"</b> Option from file menu and configure the following values :
	                                <ol type="a" class="list-text">
                                        <li>Left Margin = 0.25</li>
                                        <li>Right Margin = 0.25</li>
                                        <li>Top Margin = 0.25</li>
                                        <li>Bottom Margin = 0.25</li>
                                        <li>Header should be blank</li>
                                        <li>Footer should be blank</li>
                                    </ol>
                                </li>
                                <li>Make sure that the printer is ready with <b>A4</b> size papers in it.</li>
                                <li>The online system will print <b>Application Form</b>.</li>
                                <li>Confirm whether you have received correct set of printout if not then please take the printouts again.</li>
                            </ol>
                        </font>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable" id="tblHeader1" runat="server">
            <tr>
                <td style="width: 85%; border-right-width:0px"><font size="2"><b>First Year of Four Year Degree Course in Pharmacy & First Year of Six Year Post Graduate Degree Course in Pharm. D. for the Academic Year <%= AdmissionYear %></b></font></td>
                <td style="width: 25%; border-left-width: 0px;" align="right"><font size="2"><b>Application Form</b></font></td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblHeader2" runat="server">
            <tr>
                <td style="width: 10%; border-top-width: 0px; border-right-width: 0px;" align="center">
                    <img src="../Images/WebsiteLogo.png" alt="" style="width: 73px; height: auto" /></td>
                <td style="width: 80%; border-top-width: 0px; border-left-width: 0px; border-right-width:0px" align="center">
                    <b>
                        <img src="../Images/WebsiteLogoOld_Print.png" alt="" /><br />
                        <font size="4">G</font><font size="2">OVERNMENT</font> <font size="4">O</font><font size="2">F</font> <font size="4">M</font><font size="2">AHARASHTRA</font><br />
                        <font size="4">S</font><font size="2">TATE</font> <font size="4">C</font><font size="2">OMMON</font> <font size="4">E</font><font size="2">NTRANCE</font> <font size="4">T</font><font size="2">EST</font> <font size="4">C</font><font size="2">ELL,</font> <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font>
                        <br />
                        <font size="1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
                        <br />
                        <br />
                        Application Form for Admission to First Year of Four Year Degree Course in Pharmacy & First Year of Six Year Post Graduate Degree Course in Pharm. D. for the Academic Year <%= AdmissionYear %>
                        <asp:Label ID="lblTitle" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Small" Visible="false"><br /><br />For Non-CAP Admissions to Institution Level and ACAP Seats after CAP</asp:Label>
                    </b>
                </td>
                <td style="width: 10%; border-top-width: 0px; border-left-width: 0px;" align="center">
                    <img src="../Images/ARAFINAL.png" alt="" style="width: 73px; height: auto" /></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="border-top-width: 0px;" align="center">
                    <font size="3">Application ID : 
                        <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;
                        Version No : 
                        <asp:Label ID="lblVersionNo" runat="server" Font-Bold="True"></asp:Label>
                    </font>
                </td>
            </tr>
        </table>
         <table class="AppFormTable" runat="server" id="tblEScrutiny" visible="false">
            <tr>
                <td align="right">"Alloted Scrutiny Center (e-SC) For e-Scrutiny	"  </td>
                <td>
                    <asp:Label ID="lblEScrutiny" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="AppFormTable" runat="server" id="tblPhysicalScrutiny" visible="false">
            <tr>
                <td align="right">Booked Slot  Date (DD/MM/YYYY) and Time</td>
                <td>
                    <asp:Label ID="lblSlotDateTime" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">SC Name and Address</td>
                <td>
                    <asp:Label ID="lblFCDetails" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" colspan="4" align="left">Personal Details</th>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name</td>
                <td colspan="2">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center" rowspan="12">
                     <asp:Image ID="imgPhotograph" width="133" Height="171" runat="server" AlternateText="Candidate Photograph" />
                    <br />
                    <asp:Image ID="imgSignature" width="133" Height="57" runat="server" AlternateText="Candidate Signature" />

                </td>
            </tr>
            <tr>
                <td align="right">Father's Name</td>
                <td colspan="2">
                    <asp:Label ID="lblFatherName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Mother's Name</td>
                <td colspan="2">
                    <asp:Label ID="lblMotherName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Gender</td>
                <td colspan="2">
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Date of Birth</td>
                <td colspan="2">
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td colspan="2">
                    <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Home University</td>
                <td colspan="2""><asp:Label id="lblHomeUniversity" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category</td>
                <td colspan="2">
                    <asp:Label ID="lblOriginalCategory" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category for Admission</td>
                <td colspan="2">
                    <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for EWS</td>
                <td colspan="2">
                    <asp:Label ID="lblAppliedForEWS" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Person with Disability</td>
                <td colspan="2">
                    <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Defence Type</td>
                <td colspan="2">
                    <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Is Orphan Candidate</td>
                <td colspan="3">
                    <asp:Label ID="lblIsOrphan" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
             <tr>
                <td align="right">Applied for TFWS Seats</td>
                <td colspan="3"><asp:Label id="lblAppliedForTFWS" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Minority Candidature Type</td>
                <td colspan="3">
                    <asp:Label ID="lblAppliedForMinoritySeats" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trDocumentOf" runat="server">
                <td align="right" colspan="3">
                    <asp:Label ID="lblDocumentOfHead" runat="server"></asp:Label></td>
                <td>
                    <asp:Label ID="lblDocumentOf" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trMothersName" runat="server">
                <td align="right" colspan="3">Mother's Name as Appeared in Domacile Certificate</td>
                <td>
                    <asp:Label ID="lblMothersName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trDistrict1" runat="server">
                <td align="right" colspan="3">
                    <asp:Label ID="lblQ1" runat="server"></asp:Label></td>
                <td>
                    <asp:Label ID="lblDistrict1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trDistrict2" runat="server">
                <td align="right" colspan="3">
                    <asp:Label ID="lblQ2" runat="server"></asp:Label></td>
                <td>
                    <asp:Label ID="lblDistrict2" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
                <tr id="trTaluka" runat="server">
                <td colspan="3" align="right">
                    <asp:Label ID="lblQ3" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTaluka" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr id="trVillage" runat="server">
                <td colspan="3" align="right">
                    <asp:Label ID="lblQ4" runat="server"></asp:Label>
                </td>
                <td>
                     <asp:Label ID="lblvillage" runat="server" Font-Bold="true"></asp:Label>
                </td>

            </tr>
            <tr>
                <td colspan="3" align="right">Nationality</td>
                <td >
                    <asp:Label ID="lblNationality" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trFCRApplicationNo" runat="server">
                <td colspan="3" align="right">FCR Application No</td>
                <td ><asp:Label id="lblFCRApplicationNo" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">MHT-CET Application Fee Paid (<span class="rupee">Rs.</span>)</td>
                <td>
                    <asp:Label ID="lblApplicationFeePaidAmount" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Online Application Fee Paid (<span class="rupee">Rs.</span>)</td>
                <td>
                    <asp:Label ID="lblOnlineApplicationFee" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            
            <tr>
                <th colspan="4" align="left">Qualification Details:-<asp:Label id="lblNameAsPerHSCResult" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                
            </tr>
            <tr>
                <td style="width: 25%" align="center"><b>Qualification</b></td>
                <td style="width: 25%" align="center"><b>Marks Obtained</b></td>
                <td style="width: 25%" align="center"><b>Marks OutOf</b></td>
                <td style="width: 25%" align="center"><b>Percentage</b></td>
            </tr>
            <%--<tr>
                <td align="right">SSC Mathematics Marks</td>
                <td align="center"><asp:Label id="lblSSCMathMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCMathMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCMathPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">SSC Aggregate Marks</td>
                <td align="center"><asp:Label id="lblSSCTotalMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCTotalMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCTotalPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>--%>
            <tr>
                <td align="right">HSC Physics Marks</td>
                <td align="center">
                    <asp:Label ID="lblHSCPhysicsMarksObtained" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblHSCPhysicsMarksOutOf" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblHSCPhysicsPercentage" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC Chemistry Marks</td>
                <td align="center">
                    <asp:Label ID="lblHSCChemistryMarksObtained" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblHSCChemistryMarksOutOf" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblHSCChemistryPercentage" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC
                    <asp:Label ID="lblHSCSubject" runat="server"></asp:Label>
                    Marks</td>
                <td align="center">
                    <asp:Label ID="lblHSCSubjectMarksObtained" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblHSCSubjectMarksOutOf" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblHSCSubjectPercentage" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC English Marks</td>
                <td align="center">
                    <asp:Label ID="lblHSCEnglishMarksObtained" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblHSCEnglishMarksOutOf" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblHSCEnglishPercentage" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC Aggregate Marks</td>
                <td align="center">
                    <asp:Label ID="lblHSCTotalMarksObtained" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblHSCTotalMarksOutOf" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblHSCTotalPercentage" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trDiplomaTotalMarks" runat="server" visible="false">
                <td align="right">
                    <asp:Label ID="lblDiplomaTotalMarks" runat="server">Diploma Aggregate Marks</asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblDiplomaTotalMarksObtained" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblDiplomaTotalMarksOutOf" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center">
                    <asp:Label ID="lblDiplomaTotalPercentage" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">SSC Board</td>
                <td colspan="3">
                    <asp:Label ID="lblSSCBoard" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">SSC Passing Year</td>
                <td>
                    <asp:Label ID="lblSSCPassingYear" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">SSC Seat Number</td>
                <td>
                    <asp:Label ID="lblSSCSeatNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC Board</td>
                <td colspan="3">
                    <asp:Label ID="lblHSCBoard" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC Passing Year</td>
                <td>
                    <asp:Label ID="lblHSCPassingYear" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">HSC Seat Number</td>
                <td>
                    <asp:Label ID="lblHSCSeatNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC Passing Status</td>
                <td colspan="3">
                    <asp:Label ID="lblHSCPassingStatus" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="left"><%= MHTCETName %> Details :- <asp:Label id="lblCETCandidateName" runat="server" Font-Bold="true"></asp:Label></th>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblAppearedForCETHeader" runat="server"> Appeared for CET</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAppearedForCET" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">
                    <asp:Label ID="lblCETRollNoHeader" runat="server">Roll No</asp:Label></td>
                <td>
                    <asp:Label ID="lblCETRollNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCETScore1" runat="server">
                <td align="right">Physics</td>
                <td>
                    <asp:Label ID="lblCETPhysicsScore" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Chemistry</td>
                <td>
                    <asp:Label ID="lblCETChemistryScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCETScore2" runat="server">
                <td align="right">Mathematics</td>
                <td>
                    <asp:Label ID="lblCETMathScore" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Biology</td>
                <td>
                    <asp:Label ID="lblCETBiologyScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCETScore3" runat="server">
                <td align="right">Total PCM</td>
                <td>
                    <asp:Label ID="lblCETPCMScore" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Total PCB</td>
                <td>
                    <asp:Label ID="lblCETPCBScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="left"><%= NEETName%> Details<asp:Label id="lblNEETName" runat="server" Font-Bold="true"></asp:Label></th>
            </tr>
            <tr>
                <td align="right">Appeared for NEET</td>
                <td>
                    <asp:Label ID="lblAppearedForNEET" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">
                    <asp:Label ID="lblNEETRollNoHeader" runat="server">Roll No</asp:Label></td>
                <td>
                    <asp:Label ID="lblNEETRollNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trNEETScore1" runat="server">
                <td align="right">Physics</td>
                <td>
                    <asp:Label ID="lblNEETPhysicsScore" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Chemistry</td>
                <td>
                    <asp:Label ID="lblNEETChemistryScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trNEETScore2" runat="server">
                <td align="right">Biology (Botany & Zoology)</td>
                <td>
                    <asp:Label ID="lblNEETBiologyScore" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Total</td>
                <td>
                    <asp:Label ID="lblNEETTotalScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr id="Not1" runat="server" visible="false">
                <td style="border-top-width: 0px;">
                    <p align="justify"><b>Note : </b>
                        <p align="justify"><b>Note : </b><asp:Label ID = "lblDocumenSubmittNote" runat = "server"></asp:Label></p>
                        <%--<asp:Label ID="lblDocumenSubmittNote" runat="server">Submit one set of application form along with photocopies of documents mentioned below. SC Officer shall verify all original documents and put SC stamp with dated Signature on all photocopies of documents and return the same set of documents to the candidate along with Receipt-cum-Acknowledgement of application form.</asp:Label></p>--%>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th align="left" style="border-top-width: 0px;">List of Documents Required at the time of Document Verification and Confirmation at Scrutiny Center (Attach Photo Copies)</th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" Width="100%" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="90%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="trEligibilityRemark" runat="server" visible="false">
                <td>
                    <asp:Label ID="lblEligibilityRemark" runat="server"><b>Remark : </b></asp:Label></td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblFooter1" runat="server">
            <tr>
                <td style="border-top-width: 0px;" colspan="2">
                    <center><b><font size="2">Declaration</font></b></center>
                    <br />
                    <p align="justify">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        I have read all the rules of admission and Information brochure for admission to UG courses <%=CurrentYear%> and on understanding these Rules, I have filled this Application Form for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>. The information given by me in this application is true to the best of my knowledge &amp; belief. If at later stage, it is found that I have furnished wrong information and/or submitted false certificate(s), I am aware that my admission stands cancelled and fees paid by me will be forfeited. Further I will be subject to legal and/or penal action as per the provisions of the law.
                    </p>
                </td>
            </tr>
            <tr>
                <td style="width: 60%">Place :&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Date :
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 40%" align="center" valign="bottom" rowspan="4">
                    <asp:Image ID="imgSignature1" width="133" Height="57" runat="server" AlternateText="Candidate Signature" Visible="false" />
                    <br />
                    Signature of Applicant
                    <br />
                    (<asp:Label ID="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
                </td>
            </tr>
            <tr>
                <td>Printed On :
                    <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td>Last Modified On :
                    <asp:Label ID="lblLastModifiedOn" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td>Last Modified By :
                    <asp:Label ID="lblLastModifiedBy" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder" id="tblPrint2" runat="server">
            <tr>
                <td align="center" width="100%">
                    <input id="btnPrint2" type="button" runat="server" value="Print Application Form" class="InputButton" onclick="javascript: OpenPopUpWindow()" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
