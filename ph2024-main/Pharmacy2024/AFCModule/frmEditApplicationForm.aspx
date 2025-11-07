<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditApplicationForm.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEditApplicationForm" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Edit Application Form">
       
        <table class="AppFormTable">
            <tr>
                <th colspan="4" align="left">Registration Details
                    <asp:ImageButton ID="btnRegistrationDetails" runat="server" ImageUrl="../Images/edit.gif" Height="16px" OnClick="btnRegistrationDetails_Click" /></th>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name</td>
                <td colspan="3">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Father's Name</td>
                <td>
                    <asp:Label ID="lblFatherName" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Mother's Name</td>
                <td>
                    <asp:Label ID="lblMotherName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Gender</td>
                <td>
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">DOB (DD/MM/YYYY)</td>
                <td>
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Religion</td>
                <td>
                    <asp:Label ID="lblReligion" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Region</td>
                <td>
                    <asp:Label ID="lblRegion" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Mother Tongue</td>
                <td>
                    <asp:Label ID="lblMotherTongue" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Annual Family Income</td>
                <td>
                    <asp:Label ID="lblAnnualFamilyIncome" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Nationality</td>
                <td colspan="3">
                    <asp:Label ID="lblNationality" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="left">Candidature Type Details
                    <asp:ImageButton ID="btnCandidatureTypeDetails" runat="server" ImageUrl="../Images/edit.gif" Height="16px" OnClick="btnCandidatureTypeDetails_Click" /></th>
            </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td colspan="3">
                    <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trHeadHomeUniversityAndCategoryDetails" runat="server">
                <th colspan="4" align="left">Home University and Category Details
                    <asp:ImageButton ID="btnHomeUniversityAndCategoryDetails" runat="server" ImageUrl="../Images/edit.gif" Height="16px" OnClick="btnHomeUniversityAndCategoryDetails_Click" /></th>
            </tr>
            <tr runat="server" id="trDocumentOf">
                <td align="right" colspan="3">
                    <asp:Label ID="lblDocumentOfHead" runat="server"></asp:Label></td>
                <td>
                    <asp:Label ID="lblDocumentOf" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr runat="server" id="trMothersName">
                <td align="right" colspan="3">Mother's Name as Appeared in Domacile Certificate</td>
                <td>
                    <asp:Label ID="lblMothersName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr runat="server" id="trDistrict1">
                <td align="right" colspan="3">
                    <asp:Label ID="lblQ1" runat="server"></asp:Label></td>
                <td>
                    <asp:Label ID="lblDistrict1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr runat="server" id="trDistrict2">
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
                <td align="right">Home University</td>
                <td colspan="3">
                    <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category</td>
                <td colspan="3">
                    <asp:Label ID="lblOriginalCategory" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category for Admission</td>
                <td colspan="3">
                    <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for EWS</td>
                <td colspan="3">
                    <asp:Label ID="lblAppliedForEWS" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trHeadSpecialReservationDetails" runat="server">
                <th colspan="4" align="left">Special Reservation Details
                    <asp:ImageButton ID="btnSpecialReservationDetails" runat="server" ImageUrl="../Images/edit.gif" Height="16px" OnClick="btnSpecialReservationDetails_Click" /></th>
            </tr>
            <tr>
                <td align="right">Person with Disability</td>
                <td colspan="3">
                    <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Defence Type</td>
                <td colspan="3">
                    <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Are you Orphan?</td>
                <td colspan="3">
                    <asp:Label ID="lblIsOrphan" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for TFWS</td>
                <td colspan = "3"><asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Minority Candidature Type</td>
                <td colspan="3">
                    <asp:Label ID="lblAppliedForMinoritySeats" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="left">Qualification Details
                    <asp:ImageButton ID="btnQualificationDetails" runat="server" ImageUrl="../Images/edit.gif" Height="16px" OnClick="btnQualificationDetails_Click" /></th>
            </tr>
            <%-- <tr>
	            <td style="width: 25%" align="center"><b>Qualification</b></td>
		        <td style="width: 25%" align="center"><b>Marks Obtained</b></td>
    		    <td style="width: 25%" align="center"><b>Marks OutOf</b></td>
	    	    <td style="width: 25%" align="center"><b>Percentage</b></td>
            </tr>
            <tr>
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
                <th colspan="4" align="left"><%= MHTCETPercentile %></th>
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
                <th colspan="4" align="left">NEET <%=CurrentYear%> Details 
                    <asp:ImageButton ID="btnNEETDetails" runat="server" ImageUrl="../Images/edit.gif" Height="16px" OnClick="btnNEETDetails_Click" /></th>
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
            <tr>
                <th colspan="4" align="left" style="border-top-width: 0px;">Photograph and Signature
                    <asp:ImageButton ID="btnScannedImages" runat="server" ImageUrl="../Images/edit.gif" Height="16px" OnClick="btnScannedImages_Click" /></th>
            </tr>
           <tr>
				<td colspan="2" align = "center"><asp:Image ID="imgPhotograph" Width = "133" Height="171" runat="server" AlternateText="Candidate Photograph" /></td>
                <td colspan="2" align = "center"><asp:Image ID="imgSignature" Width = "133" Height="171" runat="server" AlternateText="Candidate Signature" /></td>
			</tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th align="left" style="border-top-width: 0px;">List of Required Documents</th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="11px" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="11px" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="11px" CssClass="Item" Width="90%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="11px" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
