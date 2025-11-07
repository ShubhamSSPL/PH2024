<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmRequiredDocuments.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmRequiredDocuments" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <style>
        .NotVisible {
            display: none;
        }
    </style>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Confirm Application Form">
        <asp:HiddenField ID="hdnApplicationURL" runat="server" />
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%" align="right"><font size="3" color="red">Version No</font></td>
                <td style="width: 50%"><font size="3" color="red">
                    <asp:Label ID="lblVersionNo" runat="server" Font-Bold="True"></asp:Label></font></td>
            </tr>
            <tr>
                <td align="right"><font size="3" color="red">Last Modified On</font></td>
                <td><font size="3" color="red">
                    <asp:Label ID="lblLastModifiedOn" runat="server" Font-Bold="True"></asp:Label></font></td>
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
            <tr>
                <td align="right">MHT-CET Application Fee Paid (<span class="rupee">Rs.</span>)</td>
                <td>
                    <asp:Label ID="lblApplicationFeePaidAmount" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Online Application Fee Paid (<span class="rupee">Rs.</span>)</td>
                <td>
                    <asp:Label ID="lblOnlineApplicationFee" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            
            <tr>
                <th colspan="4" align="left">Qualification Details:-<asp:Label id="lblNameAsPerHSCResult" runat="server" Font-Bold="true"></asp:Label>
                
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
                <th colspan="4" align="left"><%= MHTCETName %> Details:-<asp:Label id="lblCETCandidateName" runat="server" Font-Bold="true"></asp:Label></th>
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
                                    <asp:RadioButton ID="rbnYes" runat="server" Text="&nbsp;Verified" GroupName="YesNo" /></ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="12%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Not Verified">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbnNo" runat="server" Text="&nbsp;Not Verified" GroupName="YesNo" /></ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="15%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                        <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" runat="server" onclick="javascript:OpenViewDocumentPopUp(this)"/>
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
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" OnClick="btnProceed_Click" CssClass="InputButton"></asp:Button></td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <div class="modal"></div>
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
           var byteStream = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[1].value;
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

   </script>
    <script language="javascript" type="text/javascript">
        function ViewDoc(cntrl) {
            var corrRow = cntrl.parentNode.parentNode;
            var documentName = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            //window.open(documentName,"pdf");
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
