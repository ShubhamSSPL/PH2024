<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAcknowledgementByVersionNo.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmAcknowledgementByVersionNo" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
        function OpenPopUpWindow() {
            var sel = document.getElementById("rightContainer_ContentBox1_ddlApplicationFormVersion");
            var opt = sel.options[sel.selectedIndex];
            window.open("frmPrintAcknowledgementByVersionNo?VersionNo=" + opt.value + "&PID="+ <% = PID %>, "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes");
        }
    </script>

    <style>
       /* .pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .doc-container {
            height: 22rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        #rightContainer_contentViewDocument {
            top: 12% !important
        }*/
        .doc-container img{
            width:100%;
        }
        .AppFormTableWithOutBorder select{
            margin-left:10px;
        }
    </style>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false" Visible="false">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="right">Acknowledgement Version No
                </td>
                <td>
                    <asp:DropDownList ID="ddlApplicationFormVersion" runat="server" Width="60%" OnSelectedIndexChanged="ddlApplicationFormVersion_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderVisible="false" Visible="false">
        <br />
        <table class="AppFormTable " id="tblHeader1" runat="server" >
             <tr>
                <td style="width: 89%;"><font size="2"><b>First Year of Four Year Degree Course in Pharmacy & First Year of Six Year Post Graduate Degree Course in Pharm. D. for the Academic Year <%= AdmissionYear %></b></font></td>
                <td style="border-left-width: 0px;" align="right"><font size="2"><b>Acknowledgement</b></font></td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblHeader2" runat="server">
            <tr>
                <td style="width: 10%; border-top-width: 0px; border-right-width: 0px;" align="center">
                    <img src="../Images/WebsiteLogo.png" alt="" style="width: 73px; height: auto" /></td>
                <td style="width: 80%; border-top-width: 0px; border-left-width: 0px; border-right-width:0px;" align="center">
                    <b>
                        <img src="../Images/WebsiteLogoOld_Print.png" alt="" /><br />
                        <font size="4">G</font><font size="2">OVERNMENT</font> <font size="4">O</font><font size="2">F</font> <font size="4">M</font><font size="2">AHARASHTRA</font><br />
                        <font size="4">S</font><font size="2">TATE</font> <font size="4">C</font><font size="2">OMMON</font> <font size="4">E</font><font size="2">NTRANCE</font> <font size="4">T</font><font size="2">EST</font> <font size="4">C</font><font size="2">ELL,</font> <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font>
                        <br />
                        <font size="1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
                        <br />
                        <br />
                        Receipt-cum-Acknowledgement for Admission to First Year of Four Year Degree Course in Pharmacy & First Year of Six Year Post Graduate Degree Course in Pharm. D. for the Academic Year <%= AdmissionYear %>
                        <asp:Label ID="lblTitle" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Small" Visible="false"><br /><br />For Non-CAP Admissions to Institutional Quota and Vacant Seats after CAP</asp:Label>
                    </b>
                </td>
                <td style="width: 10%; border-top-width: 0px; border-left-width: 0px;" align="center">
                    <img src="../Images/ARAFINAL.png" alt="" style="width: 73px; height: auto" /></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="border-top-width: 0px;" align="center">
                    <font size="3">
                        Application ID : 
                        <asp:Label id="lblApplicationID" runat="server" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;
                        Application Version No : 
                        <asp:Label id="lblVersionNo" runat="server" Font-Bold="True"></asp:Label>
                    </font>
                </td>
            </tr>
        </table>
        <table class="AppFormTable" runat="server" id="tblPhysicalScrutiny" visible="false">
           <%-- <tr>
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
            </tr>--%>

        </table>
         <table class="AppFormTable" runat="server" id="tblEScrutiny" visible="false">
            <tr>
                 <td align="right">Alloted Scrutiny Center (e-SC) For e-Scrutiny </td>
                <td>
                    <asp:Label ID="lblEScrutiny" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
          <table class="AppFormTable" runat="server" id="tblPhysicaScrutiny" visible="false">
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
                <th colspan="4" align="left"><%= MHTCETName %> Details:- <asp:Label id="lblCETCandidateName" runat="server" Font-Bold="true"></asp:Label></th>
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
                <th colspan="4" align="left"><%= NEETName%> Details:-<asp:Label id="lblNEETName" runat="server" Font-Bold="true"></asp:Label></th>
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
            <tr id="trDocumentsSubmitted1" runat="server">
                <th align="left" style="border-top-width: 0px;">List of Documents Verified at Scrutiny Center</th>
            </tr>
            <tr id="trDocumentsSubmitted2" runat="server">
                <td>
                    <asp:GridView ID="gvDocumentsSubmitted" runat="server" AutoGenerateColumns="False" Width="100%" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid" OnRowDataBound="gvDocuments_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Document Name" DataField="DocumentName" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="90%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsUploaded" runat="server" Text='<%# Eval("IsUploaded") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                    <%--<img src="" id="imgDoc" Style="cursor: pointer; max-width: 40px" runat="server" />--%>
                                    <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" runat="server" onclick="javascript:OpenViewDocumentPopUp(this)" />
                                    <asp:HiddenField ID="hidFURL" runat="server" Value='<%# Bind("AbsoluteFilePath") %>' />
                                    <asp:HiddenField ID="hdnImgByteArray" runat="server" Value='<%# Bind("AbsoluteFilePath") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="trDocumentsNotSubmitted1" runat="server">
                <th align="left">List of Documents Not Verified at Scrutiny Center</th>
            </tr>
            <tr id="trDocumentsNotSubmitted2" runat="server">
                <td>
                    <asp:GridView ID="gvDocumentsNotSubmitted" runat="server" AutoGenerateColumns="False" Width="100%" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Document Name" DataField="DocumentName" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="90%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="trEligibilityRemark" runat="server" visible="false">
                <td>
                    <asp:Label ID="lblEligibilityRemark" runat="server" ForeColor="Red"><b>Remark : </b></asp:Label></td>
            </tr>
            <tr id="trComments" runat="server" visible="false">
                <td>
                   <b>Comments : </b> <asp:Label ID="lblComments" runat="server"></asp:Label></td>
            </tr>
             
            <tr id="trNationalityDocumentNot" runat="server" visible="false">
                <td>
                    <%-- <b><font size="2">Remark :</font></b>--%>
                    <%--<p align="justify">
                        As you have not submitted any on of the document to prove the Nationality, it is mandatory for you to submit the required document at the time of reporting to the allotted Institute for admission. In case of non submittion of the document your allotment/admission shall stand cancelled.
                    </p>--%>
                </td>
            </tr>
            <tr id="trEWSNotSubmittedSEBC" runat="server" visible="false">
                <td>
                     <b><font size="2">Remark :</font></b>
                    <p align="justify">
                        “ I am aware that I have to provide a prescribed eligibility Certificate for the Economically Weaker Section (EWS) at the time of admission at the Institute. In case of non submission of the document my admission shall stand cancelled”  
                    </p>
                </td>
            </tr>
            <tr id="trTFWSPH" runat="server" visible="false">
                <td>
                     <b><font size="2">Remark :</font></b>
                    <p align="justify">
                        “ I am aware that I have to provide a prescribed Income Certificate of Parents issued by competent authoirty of Govt. Of Maharashtra having Annual Income upto Rs. 8 Lacs. at the time of admission at the Institute. In case of non submission of the document my admission shall stand cancelled”  
                    </p>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="border-top-width: 0px;" colspan="2">
                    <center><b><font size = "2">Declaration</font></b></center>
                    <br />
                    <p align="justify">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         I have read all the rules of admission and Information brochure for admission to UG courses <%=CurrentYear%> and on understanding these Rules, I have filled this Application Form for Admission to First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions <%= AdmissionYear %>. The information given by me in this application is true to the best of my knowledge & belief. If at later stage, it is found that I have furnished wrong information and/or forgery/Xerox copy or submitted false certificate(s), I am aware that my admission stands cancelled and fees paid by me will be forfeited. Further I will be subject to legal and/or penal action as per the provisions of the law.
                    </p>
                </td>
            </tr>

            <tr>
                <td style="width: 60%">Place :&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Date :
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 40%" align="center" valign="bottom" rowspan="3">
                     <asp:Image ID="imgSignature1" width="133" Height="57" runat="server" AlternateText="Candidate Signature" />
                    <br />
                    Signature of ApplicantSignature of Applicant
                    <br />
                    (<asp:Label ID="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
                </td>
            </tr>
            <tr>
                <td>Last Modified On :
                    <asp:Label ID="lblLastModifiedOn" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td>Last Modified By :
                    <asp:Label ID="lblLastModifiedBy" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="2">For Office Use Only</th>
            </tr>
            <tr>
                <td>Printed On :
                    <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True"></asp:Label></td>
                <td align="center" valign="bottom" rowspan="3"><b>Seal & Signature of the Issuing SC Officer</b></td>
            </tr>
            <tr>
                <td>Confirmed On :
                    <asp:Label ID="lblConfirmedOn" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td>Confirmed By :
                    <asp:Label ID="lblConfirmedBy" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center" width="100%">
                    <input id="btnPrint2" type="button" runat="server" value="Print Acknowledgement" class="InputButton" onclick="javascript: OpenPopUpWindow()" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr>
                <td>
                    <div class="modal-body">
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
            document.getElementById('lblDocumentName').innerHTML = corrRow.cells[1].innerText;
            var byteStream = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[1].value;
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
                    document.getElementById('divDocument').innerHTML = '<embed src="' + filePath + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }

    </script>
</asp:Content>
