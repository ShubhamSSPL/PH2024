<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmInstitute_VerificationCandidateDocuments.aspx.cs" Inherits="Pharmacy2024.ARAModule.frmInstitute_VerificationCandidateDocuments" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script> 
    <script type="text/javascript">
        function ShowPopup(cntrl) {
            var corrRow = cntrl.parentNode.parentNode;
            var documentId = corrRow.cells[corrRow.cells.length - 3].getElementsByTagName("input")[1].value;
            window.open("../ViewMyDocumentForARA.aspx?documentID=" + documentId, "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes,");
        }
    </script>
    <style>
        .NotVisible
        {
            display:none;
        }
    </style>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Confirm Application Form">
     <asp:HiddenField ID="hdnApplicationURL" runat="server" />
        <table class = "AppFormTable">
            <tr> 
                <td style="width: 20%" align="right"><font size="3" color = "red">Application ID</font></td>
                <td style="width: 15%"><font size="3" color = "red"><asp:Label id="lblApplicationID" runat="server" Font-Bold="True"></asp:Label></font></td>
            
                <%--<td style="width: 10%" align="right"><font size="3" color = "red">Version No </font></td>
                <td style="width: 10%"><font size="3" color = "red"><asp:Label id="lblVersionNo" runat="server" Font-Bold="True"></asp:Label></font></td>
            
                <td style="width: 20%" align="right"><font size="3" color = "red">Last Modified On</font></td>
                <td style="width: 20%"><font size="3" color = "red"><asp:Label id="lblLastModifiedOn" runat="server" Font-Bold="True"></asp:Label></font></td>--%>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width:0px;" colspan = "4" align = "left">Personal Details</th>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name</td>
                <td colspan="2"><asp:Label ID="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center" rowspan="12"><asp:Image ID="imgPhotograph" Width = "133" Height="171" runat="server" AlternateText="Candidate Photograph" /></td>
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
                </th>
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
            <tr id = "trHSCMathMarks" runat = "server">
                <td align="right">HSC Mathematics Marks</td>
                <td align="center"><asp:Label id="lblHSCMathMarksObtained" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCMathMarksOutOf" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="center"><asp:Label id="lblHSCMathPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
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
                <td align="right">Qualifying Exam</td>
                <td><asp:Label ID="lblQualifyingExam" runat="server" Font-Bold = "true"></asp:Label></td>
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
                <td align = "right">PCM</td>
                <td><asp:Label ID = "lblCETTotalScore" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan = "4" align = "left"><%= JEEName %>:-<asp:Label id="lblJEEName" runat="server" Font-Bold="true"></asp:Label></th>
            </tr>
            <tr>
                <td align = "right">Appeared for JEE</td>
                <td><asp:Label ID = "lblAppearedForJEE" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right"><asp:Label id="lblJEERollNoHeader" runat="server">Application No</asp:Label></td>
                <td><asp:Label ID = "lblJEERollNo" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trJEEScore1" runat = "server">
                <td align = "right">Physics</td>
                <td><asp:Label ID = "lblJEEPhysicsScore" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right">Chemistry </td>
                <td><asp:Label ID = "lblJEEChemistryScore" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trJEEScore2" runat = "server">
                <td align = "right">Mathematics</td>
                <td><asp:Label ID = "lblJEEMathScore" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right">Total</td>
                <td><asp:Label ID = "lblJEETotalScore" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan = "4" align = "left">List of Required Documents</th>
            </tr>
            <tr>
                <td colspan = "4">
                    <font color="red" >Documents shown in red color are not uploaded. You can not verify that documents without uploading.</font>
                  <br/>
                    <asp:GridView style="margin-top: 10px;" ID="gvDocuments" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth = "1px" BorderStyle = "Solid" CssClass="DataGrid" OnRowDataBound="gvDocuments_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  CssClass="Item" Width = "8%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" BorderWidth = "1px" BorderStyle = "Solid"   CssClass="Item" Width = "57%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Verified">
                                <ItemTemplate><asp:RadioButton ID="rbnYes" runat="server" Text = "&nbsp;Verified" GroupName = "YesNo" /></ItemTemplate>  
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"   CssClass="Item" Width = "12%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Not Verified">
                                <ItemTemplate><asp:RadioButton ID="rbnNo" runat="server" Text = "&nbsp;Not Verified" GroupName = "YesNo" /></ItemTemplate>  
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"   CssClass="Item" Width = "15%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  CssClass="Header" />
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="View">
                                <ItemTemplate>                                
                                  <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                  <img src="" id="imgDoc" Style="cursor: pointer; max-width: 40px" onclick="javascript:OpenViewDocumentPopUp(this)" runat="server" />
                                  <asp:HiddenField ID="hidFURL" runat="server" Value='<%# Bind("FilePath") %>' />
                                   <asp:HiddenField ID="hidDID" runat="server" Value='<%# Bind("DocumentTransID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsSubmitted" runat="server" Text='<%# Eval("IsSubmittedByInstituteForRo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  CssClass="Header" />
                            </asp:TemplateField> 
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblROIsSubmitted" runat="server" Text='<%# Eval("IsSubmittedByRo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblARAIsSubmitted" runat="server" Text='<%# Eval("IsVerifyByAra") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocumentID" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  CssClass="Header" />
                            </asp:TemplateField>
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnIsBarcodeFetch" runat="server" Value='<%# Bind("IsBarcodeFetch") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>--%>
                                 <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnDocId" runat="server" Value='<%# Bind("DocumentID") %>' />
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
             <tr>
                <th align = "left" colspan = "4">Other Details</th>
             </tr>
            <tr>
                <td align="right">Remark</td>
                <td colspan = "3"><asp:TextBox ID="txtRemark" runat="server" TextMode = "MultiLine" Width = "98%" Rows = "3"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center"><asp:button id="btnProceed" runat="server" text="Send For RO" OnClick="btnProceed_Click" CssClass="InputButton" ></asp:button></td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <div class="modal"></div>
     <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%" Height="500px">
           <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
               <tr runat="server" id="trFetchDocView" style="display: none;">
            </tr>
            <tr>
                <td>
                    <div class="modal-body" style="height: 450px;">
                        <div runat="server" id="divButtonPopup">
                            <table class="AppFormTableWithOutBorder" style="width: 5%; height: 15px;">
                                <tr>
                                    <td>
                                        <button type="button" onclick="zoominPopUp()">
                                            <img src="../Images/zoom-in.png" width="15px" height="15px"></button></td>
                                    <td>
                                        <button type="button" onclick="zoomoutPopUp()">
                                            <img src="../Images/zoom-out.png" width="15px" height="15px">
                                        </button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divDocument" class="doc-container" style="width:50%; float:left;"></div>
                        <div runat="server" class="doc-container" id="divInfo" style="width:50%; float:right; overflow: auto;">
                            <table class="AppFormTable" style="width: 100%; height: 100%;" id="tbl_PersonalInfo" >
                                <tr>
                                    <th style="border-top-width:0px;" colspan = "4" align = "left">Personal Details</th>
                                </tr>
                                <tr>
                                    <td align="right">Candidate's Full Name</td>
                                    <td colspan="2"><asp:Label ID="lblCandidateNamePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Father's Name</td>
                                    <td colspan="2"><asp:Label ID="lblFatherNamePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Mother's Name</td>
                                    <td colspan="2"><asp:Label ID="lblMotherNamePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Gender</td>
                                    <td colspan="2"><asp:Label ID="lblGenderPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
			                        <td align="right">Date of Birth</td>
			                        <td colspan="2"><asp:Label  ID="lblDOBPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
		                        </tr>
                                <tr>
                                    <td align="right">Candidature Type</td>
                                    <td colspan="2"><asp:Label ID="lblCandidatureTypePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
	                                <td align="right">Home University</td>
		                            <td colspan="2""><asp:Label id="lblHomeUniversityPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Category</td>
                                    <td colspan="2"><asp:Label id="lblOriginalCategoryPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Category for Admission</td>
                                    <td colspan="2"><asp:Label id="lblCategoryForAdmissionPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Applied for EWS</td>
                                    <td colspan="2"><asp:Label ID="lblAppliedForEWSPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Person with Disability</td>
                                    <td colspan="2"><asp:Label id="lblPHTypePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Defence Type</td>
                                    <td colspan="2"><asp:Label id="lblDefenceTypePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Is Orphan Candidate</td>
                                    <td colspan="3"><asp:Label id="lblIsOrphanPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Applied for TFWS Seats</td>
                                    <td colspan="3"><asp:Label id="lblAppliedForTFWSPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Minority Candidature Type</td>
                                    <td colspan="3"><asp:Label ID="lblAppliedForMinoritySeatsPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr id = "trDocumentOfPopUp" runat = "server">
                                    <td align="right" colspan = "3"><asp:Label ID="lblDocumentOfHeadPopUp" runat="server"></asp:Label></td>
                                    <td><asp:Label id="lblDocumentOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr id = "trMothersNamePopUp" runat = "server">
                                    <td align="right" colspan = "3">Mother's Name as Appeared in Domacile Certificate</td>
                                    <td><asp:Label id="lblMothersNamePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr id = "trDistrict1PopUp" runat = "server">
                                    <td align = "right" colspan = "3"><asp:Label ID="lblQ1PopUp" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="lblDistrict1PopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr id = "trDistrict2PopUp" runat = "server">
                                    <td align = "right" colspan = "3"><asp:Label ID="lblQ2PopUp" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="lblDistrict2PopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">MHT-CET Application Fee Paid (<span class="rupee">Rs.</span>)</td>
                                    <td><asp:Label id="lblApplicationFeePaidAmountPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                    <td align="right">Online Application Fee Paid (<span class="rupee">Rs.</span>)</td>
                                    <td><asp:Label id="lblOnlineApplicationFeePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">Nationality</td>
                                    <td colspan="3"><asp:Label id="lblNationalityPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
                                </tr> 
                            </table>

                            <table class="AppFormTable" style="width: 100%; height: 100%;" id="tbl_QualInfo" >
                                 <tr>
									<th colspan = "4" align = "left">Qualification Details:-<asp:Label id="lblNameAsPerHSCResultPopUp" runat="server" Font-Bold="true"></asp:Label>
									</th>
								</tr>
								<tr>
									<td style="width: 25%" align="center"><b>Qualification</b></td>
									<td style="width: 25%" align="center"><b>Marks Obtained</b></td>
									<td style="width: 25%" align="center"><b>Marks OutOf</b></td>
									<td style="width: 25%" align="center"><b>Percentage</b></td>
								</tr>
								<tr id = "trSSCMathematicsMarksPopUp" runat = "server">
									<td align="right">SSC Mathematics Marks</td>
									<td align="center"><asp:Label id="lblSSCMathMarksObtainedPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblSSCMathMarksOutOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblSSCMathPercentagePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trSSCScienceMarksPopUp" runat = "server">
									<td align="right">SSC Science Marks</td>
									<td align="center"><asp:Label id="lblSSCScienceMarksObtainedPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblSSCScienceMarksOutOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblSSCSciencePercentagePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trSSCEnglishMarksPopUp" runat = "server">
									<td align="right">SSC English Marks</td>
									<td align="center"><asp:Label id="lblSSCEnglishMarksObtainedPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblSSCEnglishMarksOutOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblSSCEnglishPercentagePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trSSCTotalMarksPopUp" runat = "server">
									<td align="right">SSC Aggregate Marks</td>
									<td align="center"><asp:Label id="lblSSCTotalMarksObtainedPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblSSCTotalMarksOutOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblSSCTotalPercentagePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trHSCPhysicsMarksPopUp" runat = "server">
									<td align="right">HSC Physics Marks</td>
									<td align="center"><asp:Label id="lblHSCPhysicsMarksObtainedPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCPhysicsMarksOutOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCPhysicsPercentagePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trHSCMathMarksPopUp" runat = "server">
									<td align="right">HSC Mathematics Marks</td>
									<td align="center"><asp:Label id="lblHSCMathMarksObtainedPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCMathMarksOutOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCMathPercentagePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trHSCChemistryMarksPopUp" runat = "server">
									<td align="right">HSC Chemistry Marks</td>
									<td align="center"><asp:Label id="lblHSCChemistryMarksObtainedPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCChemistryMarksOutOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCChemistryPercentagePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trHSCSubjectMarksPopUp" runat = "server">
									<td align="right">HSC <asp:Label id="lblHSCSubjectPopUp" runat="server"></asp:Label> Marks</td>
									<td align="center"><asp:Label id="lblHSCSubjectMarksObtainedPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCSubjectMarksOutOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCSubjectPercentagePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trHSCEnglishMarksPopUp" runat = "server">
									<td align="right">HSC English Marks</td>
									<td align="center"><asp:Label id="lblHSCEnglishMarksObtainedPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCEnglishMarksOutOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCEnglishPercentagePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trHSCTotalMarksPopUp" runat = "server">
									<td align="right"><asp:Label id="lblHSCTotalMarksPopUp" runat="server">HSC Aggregate Marks</asp:Label></td>
									<td align="center"><asp:Label id="lblHSCTotalMarksObtainedPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCTotalMarksOutOfPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="center"><asp:Label id="lblHSCTotalPercentagePopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr> 
									<td align="right">SSC Board</td>
									<td colspan="3"><asp:Label ID="lblSSCBoardPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr>
									<td align="right">SSC Passing Year</td>
									<td><asp:Label id="lblSSCPassingYearPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="right">SSC Seat Number</td>
									<td><asp:Label id="lblSSCSeatNoPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr>
									<td align="right">Qualifying Exam</td>
									<td><asp:Label ID="lblQualifyingExamPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="right"><asp:Label id="lblHSCPassingStatusHeaderPopUp" runat="server">HSC Passing Status</asp:Label></td>
									<td><asp:Label ID="lblHSCPassingStatusPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr> 
									<td align="right"><asp:Label id="lblHSCBoardHeaderPopUp" runat="server">HSC Board</asp:Label></td>
									<td colspan = "3"><asp:Label ID="lblHSCBoardPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr>
									<td align="right"><asp:Label id="lblHSCPassingYearHeaderPopUp" runat="server">HSC Passing Year</asp:Label></td>
									<td><asp:Label id="lblHSCPassingYearPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
									<td align="right"><asp:Label id="lblHSCSeatNoHeaderPopUp" runat="server">HSC Seat Number</asp:Label></td>
									<td><asp:Label id="lblHSCSeatNoPopUp" runat="server" Font-Bold = "true"></asp:Label></td>
								</tr>
                            </table>

                            <table class="AppFormTable" style="width: 100%; height: 100%;" id="tbl_CETInfo" >
                                <tr>
                                    <th colspan = "4" align = "left"><%= MHTCETName %> Details:-<asp:Label id="lblCETCandidateNamePopUp" runat="server" Font-Bold="true"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td align = "right"><asp:Label ID = "lblAppearedForCETHeaderPopUp" runat = "server"> Appeared for CET</asp:Label> </td>
                                    <td><asp:Label ID = "lblAppearedForCETPopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
                                    <td align = "right"><asp:Label id="lblCETRollNoHeaderPopUp" runat="server">Roll No</asp:Label></td>
                                    <td><asp:Label ID = "lblCETRollNoPopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr id = "trCETScore1PopUp" runat = "server">
                                    <td align = "right">Physics</td>
                                    <td><asp:Label ID = "lblCETPhysicsScorePopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
                                    <td align = "right">Chemistry</td>
                                    <td><asp:Label ID = "lblCETChemistryScorePopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                                <tr id = "trCETScore2PopUp" runat = "server">
                                    <td align = "right">Mathematics</td>
                                    <td><asp:Label ID = "lblCETMathScorePopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
                                    <td align = "right">PCM</td>
                                    <td><asp:Label ID = "lblCETTotalScorePopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
                                </tr>
                            </table>

                            <table class="AppFormTable" style="width: 100%; height: 100%;" id="tbl_JEEInfo" >
                                 <tr>
									<th colspan = "4" align = "left"><%= JEEName %>:-<asp:Label id="lblJEENamePopUp" runat="server" Font-Bold="true"></asp:Label></th>
								</tr>
								<tr>
									<td align = "right">Appeared for JEE</td>
									<td><asp:Label ID = "lblAppearedForJEEPopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
									<td align = "right"><asp:Label id="lblJEERollNoHeaderPopUp" runat="server">Application No</asp:Label></td>
									<td><asp:Label ID = "lblJEERollNoPopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trJEEScore1PopUp" runat = "server">
									<td align = "right">Physics</td>
									<td><asp:Label ID = "lblJEEPhysicsScorePopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
									<td align = "right">Chemistry </td>
									<td><asp:Label ID = "lblJEEChemistryScorePopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
								</tr>
								<tr id = "trJEEScore2PopUp" runat = "server">
									<td align = "right">Mathematics</td>
									<td><asp:Label ID = "lblJEEMathScorePopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
									<td align = "right">Total</td>
									<td><asp:Label ID = "lblJEETotalScorePopUp" runat = "server" Font-Bold = "true"></asp:Label></td>
								</tr>
                            </table>
                        </div>
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
             var personalID = corrRow.cells[corrRow.cells.length - 2].getElementsByTagName("input")[0].value;
             var documentID = corrRow.cells[corrRow.cells.length - 3].getElementsByTagName("input")[0].value;
             var IsBarcodeFetch = corrRow.cells[corrRow.cells.length - 4].getElementsByTagName("input")[0].value;
             var byteStream = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[1].value;
             //corrRow.cells[corrRow.cells.length - 5].innerText
             if (IsBarcodeFetch == "Y") {
                 var dsResponse = Pharmacy2024.AFCModule.frmRequiredDocuments.GetDocumentFetchData(personalID, documentID);
                 var obj = JSON.parse(dsResponse.json);
                 if (obj.value.ApplicantName != null) {
                     if (documentID == 21) {
                         document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'block';
                         document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
                         var table = CastTable(obj);
                         document.getElementById('<%=trFetchDocView.ClientID %>').appendChild(table);


                     }
                     else if (documentID == 32 || documentID == 34) {
                         document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'block';
                         document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
                         var table = IncomeTable(obj);
                         document.getElementById('<%=trFetchDocView.ClientID %>').appendChild(table);

                     }
                     else if (documentID == 22) {
                         document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'block';
                         document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
                         var table = CastValidityTable(obj);
                         document.getElementById('<%=trFetchDocView.ClientID %>').appendChild(table);
                     }
                     else if (documentID == 1 || documentID == 2 || documentID == 11) {
                         document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'block';
                         document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
                         var table = AgeDomicileNationalityTable(obj);
                         document.getElementById('<%=trFetchDocView.ClientID %>').appendChild(table);
                     }
                     else if (documentID == 25) {
                         document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'block';
                         document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
                         DisabilityCertificateTable(obj);
                         document.getElementById('<%=trFetchDocView.ClientID %>').appendChild(table);
                     }
                 }
             }
             else {
                 document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'none';
                 document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
             }
             
             //Following is added by Ketan on 04MAY2021
            // alert(documentID);
            if (documentID == 41 || documentID == 42 || documentID == 43 || documentID == 44 || documentID == 45 || documentID == 46) {
                 document.getElementById('tbl_PersonalInfo').style.display = 'none';
                 document.getElementById('tbl_QualInfo').style.display = 'inline';
                 document.getElementById('tbl_CETInfo').style.display = 'none';
                 document.getElementById('tbl_JEEInfo').style.display = 'none';
            }
            else if (documentID == 73) {
                 document.getElementById('tbl_PersonalInfo').style.display = 'none';
                 document.getElementById('tbl_QualInfo').style.display = 'none';
                 document.getElementById('tbl_CETInfo').style.display = 'initial';
                 document.getElementById('tbl_JEEInfo').style.display = 'none';
            }
            else if (documentID == 68) {
                document.getElementById('tbl_PersonalInfo').style.display = 'none';
                document.getElementById('tbl_QualInfo').style.display = 'none';
                document.getElementById('tbl_CETInfo').style.display = 'none';
                document.getElementById('tbl_JEEInfo').style.display = 'initial';
            }
            else {
                document.getElementById('tbl_PersonalInfo').style.display = 'initial';
                document.getElementById('tbl_QualInfo').style.display = 'none';
                document.getElementById('tbl_CETInfo').style.display = 'none';
                document.getElementById('tbl_JEEInfo').style.display = 'none';
            }
             //End of Following is added by Ketan on 04MAY2021
           //document.getElementById('lblDocumentName').innerHTML = corrRow.cells[corrRow.cells.length - 5].innerText;
           document.getElementById('lblDocumentName').innerHTML = corrRow.cells[1].innerText;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + byteStream + '">';
                    document.getElementById('divDocument').style.overflow = "scroll";
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
         function CastTable(obj) {

             var table = document.createElement("table")
             table.setAttribute('class', 'AppFormTable');
             var tr0 = table.insertRow(0);
             var tr = table.insertRow(1);
             var tr1 = table.insertRow(-1);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
             th.colSpan = 5;
             th.style.backgroundColor = "white";
             th.style.textAlign = "center";
             tr0.appendChild(th);



             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Applicant Name ';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.ApplicantName;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Caste';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.Caste;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Barcode';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.Barcode;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'BenfiName';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.BenfiName;
             tr1.appendChild(td);


             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'ClosedOn ';
             tr.appendChild(th);
             var td = document.createElement("td");
             //td.innerHTML = obj.value.ClosedOn.Day + '/' + obj.value.ClosedOn.Month + '/' + obj.value.ClosedOn.Year;
             td.innerHTML = obj.value.ClosedOn;
             tr1.appendChild(td);

             return table;

         }
         function IncomeTable(obj) {

             var table = document.createElement("table")
             table.setAttribute('class', 'AppFormTable');
             var tr0 = table.insertRow(0);
             var tr = table.insertRow(1);
             var tr1 = table.insertRow(-1);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
             th.colSpan = 7;
             th.style.backgroundColor = "white";
             th.style.textAlign = "center";
             tr0.appendChild(th);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Applicant Name ';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.ApplicantName;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Barcode ';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.Barcode;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Years';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.Years;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'First Year Income';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.FirstYearIncome;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Second Year Income';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.SecondYearIncome;
             tr1.appendChild(td);
             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Third Year Income';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.ThirdYearIncome;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'BenfiName ';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.BenfiName;
             tr1.appendChild(td);

             return table;
         }
         function CastValidityTable(obj) {

             var table = document.createElement("table")
             table.setAttribute('class', 'AppFormTable');
             var tr0 = table.insertRow(0);
             var tr = table.insertRow(1);
             var tr1 = table.insertRow(-1);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
             th.colSpan = 7;
             th.style.backgroundColor = "white";
             th.style.textAlign = "center";
             tr0.appendChild(th);


             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Applicant Name ';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.ApplicantName;
             tr1.appendChild(td);



             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Barcode';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.Barcode;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'DistrictName';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.DistrictName;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'CertificateDate';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.CertificateDate;
             tr1.appendChild(td);


             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'TribeName ';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.TribeName;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'CommitteeName ';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.CommitteeName;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'ApplicationType ';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.ApplicationType;
             tr1.appendChild(td);

             return table;
         }
         function AgeDomicileNationalityTable(obj) {

             var table = document.createElement("table")
             table.setAttribute('class', 'AppFormTable');
             var tr0 = table.insertRow(0);
             var tr = table.insertRow(1);
             var tr1 = table.insertRow(-1);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
             th.colSpan = 5;
             th.style.backgroundColor = "white";
             th.style.textAlign = "center";
             tr0.appendChild(th);


             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Applicant Name ';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.ApplicantName;
             tr1.appendChild(td);



             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Barcode';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.Barcode;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'DistrictName';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.DistrictName;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'YearsOfResidency';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.YearsOfResidency;
             tr1.appendChild(td);


             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'BenfiName ';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.BenfiName;
             tr1.appendChild(td);



             //var th = document.createElement("th");      // TABLE HEADER.
             //th.innerHTML = 'Date ';
             //tr.appendChild(th);
             //var td = document.createElement("td");
             //td.innerHTML = obj.value.PaymentDate.Day + '/' + obj.value.PaymentDate.Month + '/' + obj.value.PaymentDate.Year;
             //tr1.appendChild(td);

             return table;
         }

         function DisabilityCertificateTable(obj) {

             var table = document.createElement("table")
             table.setAttribute('class', 'AppFormTable');
             var tr0 = table.insertRow(0);
             var tr = table.insertRow(1);
             var tr1 = table.insertRow(-1);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
             th.colSpan = 6;
             th.style.backgroundColor = "white";
             th.style.textAlign = "center";
             tr0.appendChild(th);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Applicant Name ';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.ApplicantName;
             tr1.appendChild(td);



             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Barcode';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.Barcode;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'DistrictName';
             tr.appendChild(th);

             var td = document.createElement("td");
             td.innerHTML = obj.value.DistrictName;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'PercentageOfDisability';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.PercentageOfDisability;
             tr1.appendChild(td);


             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'DisabilityType ';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.DisabilityType;
             tr1.appendChild(td);

             var th = document.createElement("th");      // TABLE HEADER.
             th.innerHTML = 'Date ';
             tr.appendChild(th);
             var td = document.createElement("td");
             td.innerHTML = obj.value.AllottedDate.Day + '/' + obj.value.AllottedDate.Month + '/' + obj.value.AllottedDate.Year;
             tr1.appendChild(td);


             return table;
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
    <script language="javascript" type = "text/javascript">
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
