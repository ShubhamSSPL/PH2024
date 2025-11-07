<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmPreviewApplicationForm.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmPreviewApplicationForm" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/PrintFormHeader.ascx" TagName="PrintFormHeader" TagPrefix="ucPFH" %>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
        .InnerBodyDiv {
            height: auto !important;
        }
        #rightContainer_contentDocumentConferamtion {
            position: fixed !important;
            top: 15% !important;
            width: 70%;
            z-index: 2000 !important;
        }
        @media only screen and (max-width: 768px) {
            #rightContainer_contentDocumentConferamtion {
                position: fixed !important;
                top: 10% !important;
                width: 90%;
            }
        }
    </style>
    <script lang="javascript" type="text/javascript">
        //window.history.forward(1);
        //function OpenPopUpWindow() {
        //    window.open("frmPrintApplicationForm.aspx", "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes");
        //}
        function ShowConfirmationBox() {
            document.getElementById('<%=contentDocumentConferamtion.ClientID %>').Show('', true);
        }

    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <asp:Label runat="server" ID="lblDisplayDocumentSubmissionStatus" Visible="false"></asp:Label>
                    </font>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <%--<input id="btnPrint1" type="button" runat = "server" value="Print Application Form" class="InputButton" onclick="javascript:OpenPopUpWindow()" />--%>
                    <asp:Button ID="btnProceed1" runat="server" Text="Submit Application Form >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                </td>
            </tr>
            <%-- <tr>
                <td>
                    <div id="Note">
                        <font color="red"> 
                          <asp:Label runat="server" ID="lblDisplayDocumentSubmissionStatus" Visible="false"></asp:Label>
	                        <ol class="list-text"><b>Important Instructions for Printing :</b>
	                            <li>
	                                Before printing acess the <b>"Page Setup"</b> Option from file menu and configure the following values :
	                                <ol type ="a" class="list-text">
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
	                    </font>-
                    </div>
                </td>
            </tr>
            <tr>
                <td><font size="3" color="blue"><b>Note : </b> After Printing of Application Form, Please Upload Required Documents. To Upload Documents, </font><asp:button id="btnUploadDocuments" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here " Height="40px" Font-Size="Medium" Font-Bold="true" OnClick="btnUploadDocuments_Click"></asp:button></td>
            </tr>--%>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <td><font size="2"><b>First Year of Four Year Degree Course in Pharmacy & First Year of Six Year Post Graduate Degree Course in Pharm. D. for the Academic Year <%= AdmissionYear %></b></font></td>
                <td style="border-left-width: 0px;" align="right"><font size="2"><b>Application Form</b></font></td>
            </tr>
        </table>
        <ucPFH:PrintFormHeader ID="printFH" runat="server"></ucPFH:PrintFormHeader>
        <table class="AppFormTable ">
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
                <td align="right">Alloted Scrutiny Center (SC) For E-Scrutiny </td>
                <td>
                    <asp:Label ID="lblEScrutiny" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
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
                    <asp:Image ID="imgPhotograph" Width="133" Height="171" runat="server" AlternateText="Candidate Photograph" />
                    <br />
                    <asp:Image ID="imgSignature" Width="133" Height="57" runat="server" AlternateText="Candidate Signature" />
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
                <td colspan="2">
                    <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label></td>
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
                <td colspan="3">
                    <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label></td>
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
                <td align="right">MHT-CET Application Fee Paid (<span class="rupee">Rs.</span>)</td>
                <td>
                    <asp:Label ID="lblApplicationFeePaidAmount" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Online Application Fee Paid (<span class="rupee">Rs.</span>)</td>
                <td>
                    <asp:Label ID="lblOnlineApplicationFee" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Nationality</td>
                <td colspan="3">
                    <asp:Label ID="lblNationality" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="left">Qualification Details:-<asp:Label ID="lblNameAsPerHSCResult" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                
            </tr>
            <tr>
                <td style="width: 25%" align="center"><b>Qualification</b></td>
                <td style="width: 25%" align="center"><b>Marks Obtained</b></td>
                <td style="width: 25%" align="center"><b>Marks OutOf</b></td>
                <td style="width: 25%" align="center"><b>Percentage</b></td>
            </tr>
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
                <th colspan="4" align="left"><%= MHTCETName %> Details:-<asp:Label ID="lblCETCandidateName" runat="server" Font-Bold="true"></asp:Label></th>
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
                <th colspan="4" align="left">NEET <%=CurrentYear%> Details:- <asp:Label ID="lblNEETName" runat="server" Font-Bold="true"></asp:Label></th>
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
                        <asp:Label ID="lblDocumenSubmittNote" runat="server"></asp:Label></p>
                    <%-- <p align="justify"><b>Note : </b><asp:Label ID = "lblDocumenSubmittNote" runat = "server">Submit one set of application form along with photocopies of documents mentioned below. SC Officer shall verify all original documents and put SC stamp with dated Signature on all photocopies of documents and return the same set of documents to the candidate along with Receipt-cum-Acknowledgement of application form.</asp:Label></p>--%>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <%--<tr>
                <th align = "left" style="border-top-width:0px;">List of Documents Required at the time of Document Verification and Confirmation at Scrutiny Center (Attach Photo Copies)</th>
            </tr>--%>
            <tr>
                <table class="AppFormTable">
                    <tr id="trDocumentsSubmitted1" runat="server">
                        <th align="left" style="border-top-width: 0px;">List of Documents Uploaded.</th>
                    </tr>
                    <tr id="trDocumentsSubmitted2" runat="server">
                        <td colspan="4">
                            <asp:GridView ID="gvDocumentsSubmitted" runat="server" AutoGenerateColumns="False" CssClass="DataGrid" Width="100%">
                                <Columns>
                                    <asp:BoundField HeaderText="Sr. No.">
                                        <HeaderStyle CssClass="Header" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                        <ItemStyle CssClass="Item" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DocumentName" HeaderText="Document Name" HtmlEncode="false">
                                        <HeaderStyle CssClass="Header" HorizontalAlign="Center" VerticalAlign="Middle" Width="90%" />
                                        <ItemStyle CssClass="Item" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocumentID" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="trDocumentsNotSubmitted1" runat="server" visible="false">
                        <th align="left">List of Documents Not Uploaded.</th>
                    </tr>
                    <tr id="trDocumentsNotSubmitted2" runat="server" visible="false">
                        <td id="tdDocumentsNotSubmitted2" colspan="4" style="background-color: #f14252"> <%--style="background-color: #f14252"--%>
                            <asp:GridView ID="gvDocumentsNotSubmitted" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px" CssClass="DataGrid" Width="100%">
                                <Columns>
                                    <asp:BoundField HeaderText="Sr. No.">
                                        <ItemStyle BorderStyle="Solid" BorderWidth="1px" CssClass="Item" Font-Names="Verdana" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" CssClass="Header" Font-Names="Verdana" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DocumentName" HeaderText="Document Name" HtmlEncode="false">
                                        <ItemStyle BorderStyle="Solid" BorderWidth="1px" CssClass="Item" Font-Names="Verdana" HorizontalAlign="Left" VerticalAlign="Middle" Width="90%" />
                                        <HeaderStyle BorderStyle="Solid" BorderWidth="1px" CssClass="Header" Font-Names="Verdana" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocumentID" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="tr1" runat="server" visible="false">
                        <td>
                            <asp:Label ID="Label2" runat="server" ForeColor="Red"><b>Remark : </b></asp:Label>
                        </td>
                    </tr>
                    <tr id="trComments" runat="server" visible="false">
                        <td>
                            <asp:Label ID="lblComments" runat="server"><b>Comments : </b></asp:Label>
                        </td>
                    </tr>
                </table>
            </tr>
            <tr>
            <td colspan="4">
                <table class="AppFormTableWithOutBorder" id="tblDiscrepancy" runat="server" visible="false">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server"><b>Discrepancy Marked by SC Officer :</b></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvDiscrepancy" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Application Form Step" DataField="LinkName" HtmlEncode="false">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Discrepancy Name" DataField="DiscrepancyName" HtmlEncode="false">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Discrepancy Remark" DataField="DiscrepancyRemark" HtmlEncode="false">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDiscrepancyID" runat="server" Text='<%# Eval("DiscrepancyID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplicationFormStepID" runat="server" Text='<%# Eval("ApplicationFormStepID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
            </tr>
            <tr id="trEligibilityRemark" runat="server" visible="false">
                <td>
                    <asp:Label ID="lblEligibilityRemark" runat="server" ForeColor="Red" Font-Size="Medium"><b>Remark : </b></asp:Label></td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblFooter1" runat="server">
            <tr>
                <td style="border-top-width: 0px;" colspan="2">
                    <center><b><font size="2">Declaration</font></b></center>
                    <br />
                    <p align="justify">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          I have read all the rules of admission and Information brochure for admission to UG courses <%=CurrentYear%> and on
understanding these Rules, I have filled this Application Form for Admission to
First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions <%= AdmissionYear %>. The information given by me in this application
is true to the best of my knowledge & belief. If at later stage, it is found that I
have furnished wrong information and/or forgery/Xerox copy or submitted false
certificate(s), I am aware that my admission stands cancelled and fees paid by
me will be forfeited. Further I will be subject to legal and/or penal action as per
the provisions of the law.

                    </p>
                </td>
            </tr>
            <tr>
                <td style="width: 60%">Place :&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Date :
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 40%" align="center" valign="bottom" rowspan="4">
                    <asp:Image ID="imgSignature1" Width="133" Height="57" runat="server" AlternateText="Candidate Signature" />
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
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center" width="100%">
                    <asp:Button ID="btnProceed" runat="server" Text="Submit Application Form >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <%--<input id="btnPrint2" type="button" runat="server" value="Print Application Form" class="InputButton" onclick="javascript: OpenPopUpWindow()" />--%>
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>


    <cc1:ContentBox ID="contentDocumentConferamtion" runat="server" HeaderText="Self Confirmation" BoxType="PopupBox">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblDisplayDocumentSubmissionStatus1" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="trYesNo">
                <td align="right">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="InputButton" OnClick="btnYes_Click" />
                    &nbsp;
                </td>
                <td align="left">&nbsp;<asp:Button ID="btnNo" runat="server" Text="No" CssClass="InputButton" OnClick="btnNo_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
