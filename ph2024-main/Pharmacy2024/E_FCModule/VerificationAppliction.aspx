<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="VerificationAppliction.aspx.cs" Inherits="Pharmacy2024.E_FCModule.VerificationAppliction" ValidateRequest="false" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
    </script> 
           <script src="../Scripts/MahaITDocumentFetch.js"></script>
    <script type="text/javascript">
        function ShowPopup(cntrl) {
            var corrRow = cntrl.parentNode.parentNode;
            var documentId = corrRow.cells[corrRow.cells.length - 2].getElementsByTagName("input")[1].value;
            window.open("../ViewMyDocument.aspx?documentID=" + documentId, "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes,");
        }
    </script>
    <style>
        .NotVisible {
            display: none;
        }

        /* .pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }
           #rightContainer_contentViewDocument {
            top: 14% !important;
            width: 90% !important;
        }
          .doc-container {
            height: 23rem;
            border: 1rem solid rgba(0,0,0,.1);
         
        }*/

        @media only screen and (max-width: 768px) {
            .AppFormTableWithOutBorder input {
                font-size: 11px;
            }
            /* #rightContainer_contentViewDocument {
                top: 26% !important;
                width: 100% !important;
            }

            .doc-container {
                height: 14rem;
                border: 1rem solid rgba(0,0,0,.1);
                width:100%!important;
            }*/
        }
    </style>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Confirm Application Form">
        <div class="table-responsive">
        <table class="AppFormTable">
            <tr>
                <td align="right"><font size="2" color="red">Application ID</font></td>
                <td><font size="2" color="red"><asp:Label id="lblApplicationID" runat="server" Font-Bold="True"></asp:Label></font></td>
            </tr>
            <tr>
                <td style="width: 50%" align="right"><font size="2" color="red">Version No</font></td>
                <td style="width: 50%"><font size="2" color="red"><asp:Label id="lblVersionNo" runat="server" Font-Bold="True"></asp:Label></font></td>
            </tr>
            <tr>
                <td align="right"><font size="2" color="red">Last Modified On</font></td>
                <td><font size="2" color="red"><asp:Label id="lblLastModifiedOn" runat="server" Font-Bold="True"></asp:Label></font></td>
            </tr>
            
        </table>
            </div>
        <asp:HiddenField ID="hdnApplicationURL" runat="server" />
         <div class="table-responsive">
        <table class="AppFormTable">
                  <tr>
                <th style="border-top-width:0px;" colspan = "4" align = "left">Personal Details</th>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name</td>
                <td colspan="2"><asp:Label ID="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center" rowspan="12">
                    <asp:Image ID="imgPhotograph" Width = "133" Height="171" runat="server" AlternateText="Candidate Photograph" />
                     <br />
                    <asp:Image ID="imgSignature" width="133" Height="57" runat="server" AlternateText="Candidate Signature" />
                </td>
            </tr>
            <tr>
                <td align="right">Father's Name</td>
                <td colspan="2"><asp:Label ID="lblFatherName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Mother's Name</td>
                <td colspan="2"><asp:Label ID="lblMotherName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Gender</td>
                <td colspan="2"><asp:Label ID="lblGender" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
			    <td align="right">Date of Birth</td>
			    <td colspan="2"><asp:Label  ID="lblDOB" runat="server" Font-Bold = "true"></asp:Label></td>
		    </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td colspan="2"><asp:Label ID="lblCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
	            <td align="right">Home University</td>
		        <td colspan="2""><asp:Label id="lblHomeUniversity" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category</td>
                <td colspan="2"><asp:Label id="lblOriginalCategory" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category for Admission</td>
                <td colspan="2"><asp:Label id="lblCategoryForAdmission" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for EWS</td>
                <td colspan="2"><asp:Label ID="lblAppliedForEWS" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Person with Disability</td>
                <td colspan="2"><asp:Label id="lblPHType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Defence Type</td>
                <td colspan="2"><asp:Label id="lblDefenceType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Is Orphan Candidate</td>
                <td colspan="3"><asp:Label id="lblIsOrphan" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for TFWS Seats</td>
                <td colspan="3"><asp:Label id="lblAppliedForTFWS" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Minority Candidature Type</td>
                <td colspan="3"><asp:Label ID="lblAppliedForMinoritySeats" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trDocumentOf" runat = "server">
                <td align="right" colspan = "3"><asp:Label ID="lblDocumentOfHead" runat="server"></asp:Label></td>
                <td><asp:Label id="lblDocumentOf" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trMothersName" runat = "server">
                <td align="right" colspan = "3">Mother's Name as Appeared in Domacile Certificate</td>
                <td><asp:Label id="lblMothersName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trDistrict1" runat = "server">
                <td align = "right" colspan = "3"><asp:Label ID="lblQ1" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblDistrict1" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trDistrict2" runat = "server">
                <td align = "right" colspan = "3"><asp:Label ID="lblQ2" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblDistrict2" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">MHT-CET Application Fee Paid (<span class="rupee">Rs.</span>)</td>
                <td><asp:Label id="lblApplicationFeePaidAmount" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Online Application Fee Paid (<span class="rupee">Rs.</span>)</td>
                <td><asp:Label id="lblOnlineApplicationFee" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Nationality</td>
                <td colspan="3"><asp:Label id="lblNationality" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr> 
            <tr>
                <th colspan = "4" align = "left">Qualification Details:-<asp:Label id="lblNameAsPerHSCResult" runat="server" Font-Bold="true"></asp:Label>
                
            </tr>
            <tr>
	            <td style="width: 25%" align="center"><b>Qualification</b></td>
		        <td style="width: 25%" align="center"><b>Marks Obtained</b></td>
    		    <td style="width: 25%" align="center"><b>Marks OutOf</b></td>
	    	    <td style="width: 25%" align="center"><b>Percentage</b></td>
            </tr>
            <tr id = "trSSCMathematicsMarks" runat = "server">
                <td align="right">SSC Mathematics Marks</td>
                <td align="center"><asp:Label id="lblSSCMathMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCMathMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCMathPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trSSCScienceMarks" runat = "server">
                <td align="right">SSC Science Marks</td>
                <td align="center"><asp:Label id="lblSSCScienceMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCScienceMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCSciencePercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trSSCEnglishMarks" runat = "server">
                <td align="right">SSC English Marks</td>
                <td align="center"><asp:Label id="lblSSCEnglishMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCEnglishMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCEnglishPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trSSCTotalMarks" runat = "server">
                <td align="right">SSC Aggregate Marks</td>
                <td align="center"><asp:Label id="lblSSCTotalMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCTotalMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblSSCTotalPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trHSCPhysicsMarks" runat = "server">
                <td align="right">HSC Physics Marks</td>
                <td align="center"><asp:Label id="lblHSCPhysicsMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCPhysicsMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCPhysicsPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <%--<tr id = "trHSCMathMarks" runat = "server">
                <td align="right">HSC Mathematics Marks</td>
                <td align="center"><asp:Label id="lblHSCMathMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCMathMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCMathPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>--%>
            <tr id = "trHSCChemistryMarks" runat = "server">
                <td align="right">HSC Chemistry Marks</td>
                <td align="center"><asp:Label id="lblHSCChemistryMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCChemistryMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCChemistryPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trHSCSubjectMarks" runat = "server">
                <td align="right">HSC <asp:Label id="lblHSCSubject" runat="server"></asp:Label> Marks</td>
                <td align="center"><asp:Label id="lblHSCSubjectMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCSubjectMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCSubjectPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trHSCEnglishMarks" runat = "server">
                <td align="right">HSC English Marks</td>
                <td align="center"><asp:Label id="lblHSCEnglishMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCEnglishMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCEnglishPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trHSCTotalMarks" runat = "server">
                <td align="right"><asp:Label id="lblHSCTotalMarks" runat="server">HSC Aggregate Marks</asp:Label></td>
                <td align="center"><asp:Label id="lblHSCTotalMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCTotalMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCTotalPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr> 
                <td align="right">SSC Board</td>
                <td colspan="3"><asp:Label ID="lblSSCBoard" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">SSC Passing Year</td>
                <td><asp:Label id="lblSSCPassingYear" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">SSC Seat Number</td>
                <td><asp:Label id="lblSSCSeatNo" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <%--<td align="right">Qualifying Exam</td>
                <td><asp:Label ID="lblQualifyingExam" runat="server" Font-Bold = "true"></asp:Label></td>--%>
                <td align="right"><asp:Label id="lblHSCPassingStatusHeader" runat="server">HSC Passing Status</asp:Label></td>
                <td><asp:Label ID="lblHSCPassingStatus" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr> 
                <td align="right"><asp:Label id="lblHSCBoardHeader" runat="server">HSC Board</asp:Label></td>
                <td colspan = "3"><asp:Label ID="lblHSCBoard" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right"><asp:Label id="lblHSCPassingYearHeader" runat="server">HSC Passing Year</asp:Label></td>
                <td><asp:Label id="lblHSCPassingYear" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right"><asp:Label id="lblHSCSeatNoHeader" runat="server">HSC Seat Number</asp:Label></td>
                <td><asp:Label id="lblHSCSeatNo" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan = "4" align = "left"><%= MHTCETName %> Details:-<asp:Label id="lblCETCandidateName" runat="server" Font-Bold="true"></asp:Label></th>
            </tr>
            <tr>
                <td align = "right"><asp:Label ID = "lblAppearedForCETHeader" runat = "server"> Appeared for CET</asp:Label> </td>
                <td><asp:Label ID = "lblAppearedForCET" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right"><asp:Label id="lblCETRollNoHeader" runat="server">Roll No</asp:Label></td>
                <td><asp:Label ID = "lblCETRollNo" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trCETScore1" runat = "server">
                <td align = "right">Physics</td>
                <td><asp:Label ID = "lblCETPhysicsScore" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right">Chemistry</td>
                <td><asp:Label ID = "lblCETChemistryScore" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trCETScore2" runat = "server">
                <td align = "right">Mathematics</td>
                <td><asp:Label ID = "lblCETMathScore" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right">Biology</td>
                <td><asp:Label ID = "lblCETBiologyScore" runat = "server" Font-Bold = "true"></asp:Label></td>
                
            </tr>
            <tr id = "trCETScore3" runat = "server">
                <td align = "right">Total PCM</td>
                <td><asp:Label ID = "lblCETPCMScore" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right">Total PCB</td>
                <td><asp:Label ID = "lblCETPCBScore" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan = "4" align = "left"><%=NEETName%> Details<asp:Label id="lblNEETName" runat="server" Font-Bold="true"></asp:Label></th>
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
            <tr>
                <td colspan="4">
                    <table class="AppFormTableWithOutBorder" id="tblDiscrepancy" runat="server" visible="false" style="border-color: red; border-width: 1px;">
                        <tr>
                            <th align="left" style="font-size: 14px; font-weight: 500; color: #ffffff; padding: 10px; letter-spacing: 0.04em; background-color: #f14252; border-color: #bcd5ec;">
                                <asp:Label ID="Label1" runat="server"><b>Discrepancy(s) Marked by SC Officer :</b></asp:Label>
                            </th>
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
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Discrepancy Name" DataField="DiscrepancyName" HtmlEncode="false">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Discrepancy Remark" DataField="DiscrepancyRemark" HtmlEncode="false">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40%" CssClass="Header" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
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
            <tr>
                <th colspan="4" align="left">List of Required Documents</th>
            </tr>
            <tr>
                <td colspan="4">
                    <font color="red">Documents shown in red color are not uploaded. You can not verify that documents without uploading.</font>
                    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid" OnRowDataBound="gvDocuments_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="8%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="57%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Verified">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbnYes" runat="server" Text="&nbsp;Verified" GroupName="YesNo" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="12%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Not Accepted">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbnNo" runat="server" Text="&nbsp;Not Accepted" GroupName="YesNo" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="15%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                    <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" onclick="javascript:OpenViewDocumentPopUp(this)" runat="server" />
                                    <asp:HiddenField ID="hidFURL" runat="server" Value='<%# Bind("FilePath") %>' />
                                    <asp:HiddenField ID="hidDID" runat="server" Value='<%# Bind("DocumentTransID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsSubmitted" runat="server" Text='<%# Eval("IsSubmittedAtAFC") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocumentID" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnIsBarcodeFetch" runat="server" Value='<%# Bind("IsBarcodeFetch") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnDocId" runat="server" Value='<%# Bind("DocumentId") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnPersonalID" runat="server" Value='<%# Bind("PersonalID") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnImgUrl" runat="server" Value='<%# Bind("FilePath") %>' />
                                    <asp:HiddenField ID="hdnImgByteArray" runat="server" Value='<%# Bind("FilePath") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
             </div>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                     <asp:Button ID="btnBack" runat="server" Text="<<< Back" OnClick="btnBack_Click" CssClass="InputButton" BackColor="#F6223F" CausesValidation="false"></asp:Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" OnClick="btnProceed_Click" CssClass="InputButton"></asp:Button></td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="70%">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr runat="server" id="trFetchDocView" style="display: none;"></tr>
            <tr>
                <td>
                    <div class="modal-body">
                        <div runat="server" id="divButtonPopup">
                            <button type="button" onclick="zoominPopUp()">
                                <img src="../Images/zoom-in.png" width="15px" height="15px"></button>
                            <button type="button" onclick="zoomoutPopUp()">
                                <img src="../Images/zoom-out.png" width="15px" height="15px">
                            </button>
                        </div>
                        <div id="divDocument" class="doc-container"></div>
                    </div>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>

    <script type="text/javascript">

        function zoominPopUp() {
            var GFG = document.getElementById('<%=imgPopUpDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth + 100) + "px";
        }

        function zoomoutPopUp() {
            var GFG = document.getElementById('<%=imgPopUpDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth - 100) + "px";
        }

        function OpenViewDocumentPopUp(cntrl) {

            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            var corrRow = cntrl.parentNode.parentNode;
            var filePath = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            //corrRow.cells[corrRow.cells.length - 5].innerText
            var personalID = corrRow.cells[corrRow.cells.length - 2].getElementsByTagName("input")[0].value;
            var documentID = corrRow.cells[corrRow.cells.length - 3].getElementsByTagName("input")[0].value;
            var IsBarcodeFetch = corrRow.cells[corrRow.cells.length - 4].getElementsByTagName("input")[0].value;
            var byteStream = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[1].value;
            //corrRow.cells[corrRow.cells.length - 5].innerText
            if (IsBarcodeFetch == "Y") {
                var dsResponse = Pharmacy2024.E_FCModule.EVerificationCandidatureType.GetDocumentFetchData(personalID, documentID);
                DisplayFetchDocu(dsResponse, documentID, IsBarcodeFetch);
            }
            else {
                document.getElementById('rightContainer_contentViewDocument_trFetchDocView').style.display = 'none';
                document.getElementById('rightContainer_contentViewDocument_trFetchDocView').innerHTML = "";
            }
            document.getElementById('lblDocumentName').innerHTML = corrRow.cells[1].innerText;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + byteStream + '">';
                    document.getElementById('divDocument').style.overflow = "auto";
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('divDocument').innerHTML = '<iframe src="' + byteStream + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                    document.getElementById('divDocument').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }

    </script>
    <%--<script type="text/javascript">
        document.onmousedown = disableRightclick;
        var message = "Right click is not allowed !!";
        function disableRightclick(evt) {
            if (evt.button == 2) {
                alert(message);
                return false;
            }
        }
    </script>--%>



    <script lang="javascript" type="text/javascript">
        function ViewDoc(cntrl) {
            var corrRow = cntrl.parentNode.parentNode;
            var documentName = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var m = documentName.toLowerCase().indexOf(".rar"); var k = documentName.toLowerCase().indexOf(".zip")

            if (m > -1) {
                window.open(documentName);
            }
            else if (k > -1) {
                window.open(documentName);
            }
            else {
                window.open(document.getElementById('<%=hdnApplicationURL.ClientID %>').value + "viewdocument.aspx?fn=" + documentName);
            }

            return false;
        }
    </script>
</asp:Content>



