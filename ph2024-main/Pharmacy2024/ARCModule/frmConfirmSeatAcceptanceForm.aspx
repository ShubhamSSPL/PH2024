<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmConfirmSeatAcceptanceForm.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmConfirmSeatAcceptanceForm" %>

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
    <style>
        .pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .doc-container {
		    width:65.6rem;
            height: 25rem;
            border: 1rem solid rgba(0,0,0,.1);
        }
    </style>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Confirm Seat Acceptance Form">
        <table class="AppFormTable">
            <tr>
                <th align="left" colspan="4">Personal Details</th>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name</td>
                <td colspan="3">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Gender</td>
                <td style="width: 25%">
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">DOB (DD/MM/YYYY)</td>
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
                <td align="right">Minority Candidature Type</td>
                <td colspan="3">
                    <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC Physics</td>
                <td>
                    <asp:Label ID="lblHSCPhysicsPercentage" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">HSC Chemistry</td>
                <td>
                    <asp:Label ID="lblHSCChemistryPercentage" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC
                    <asp:Label ID="lblHSCSubject" runat="server"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lblHSCSubjectPercentage" runat="server" Font-Bold="true"></asp:Label></td>
                <%--<td align="right">HSC Bio-Technology</td>
                <td><asp:Label id="lblHSCBioTechnologyPercentage" runat="server" Font-Bold = "true"></asp:Label></td>--%>
            </tr>
            <tr>
                <td align="right">HSC Aggregate</td>
                <td>
                    <asp:Label ID="lblHSCTotalPercentage" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Diploma Aggregate</td>
                <td>
                    <asp:Label ID="lblDiplomaTotalPercentage" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">MH Merit No</td>
                <td>
                    <asp:Label ID="lblMHMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">MH Merit Percentile</td>
                <td>
                    <asp:Label ID="lblMHMeritScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">AI Merit No</td>
                <td>
                    <asp:Label ID="lblAIMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">AI Merit Percentile</td>
                <td>
                    <asp:Label ID="lblAIMeritScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblAllotmentDetailsCAPRound1" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="4">Provisional Allotment Details (CAP Round-I)</th>
            </tr>
            <tr>
                <td align="right">Institute Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteAllottedCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseAllottedCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCommentsCAPRound1">
                <td colspan="4">
                    <asp:Label ID="lblCommentsCAPRound1" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetailsCAPRound1" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">Provisional Allotment Details (CAP Round-I)</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Allotment Status</td>
                <td style="width: 75%">
                    <asp:Label ID="lblAllotmentStatusCAPRound1" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblAllotmentDetailsCAPRound2" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="4">Provisional Allotment Details (CAP Round-II)</th>
            </tr>
            <tr>
                <td align="right">Institute Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteAllottedCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseAllottedCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCommentsCAPRound2">
                <td colspan="4">
                    <asp:Label ID="lblCommentsCAPRound2" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetailsCAPRound2" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">Provisional Allotment Details (CAP Round-II)</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Allotment Status</td>
                <td style="width: 75%">
                    <asp:Label ID="lblAllotmentStatusCAPRound2" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblAllotmentDetailsCAPRound3" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="4">Provisional Allotment Details (CAP Round-III)</th>
            </tr>
            <tr>
                <td align="right">Institute Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteAllottedCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseAllottedCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCommentsCAPRound3">
                <td colspan="4">
                    <asp:Label ID="lblCommentsCAPRound3" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetailsCAPRound3" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">Provisional Allotment Details (CAP Round-III)</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Allotment Status</td>
                <td style="width: 75%">
                    <asp:Label ID="lblAllotmentStatusCAPRound3" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblAllotmentDetailsCAPRound4" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="4">Provisional Allotment Details (Separate Admission Round)</th>
            </tr>
            <tr>
                <td align="right">Institute Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteAllottedCAPRound4" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Allotted</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseAllottedCAPRound4" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Type Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSeatTypeAllottedCAPRound4" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Preference No. Allotted</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPreferenceNoAllottedCAPRound4" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCommentsCAPRound4">
                <td colspan="4">
                    <asp:Label ID="lblCommentsCAPRound4" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetailsCAPRound4" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">Provisional Allotment Details (Separate Admission Round)</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Allotment Status</td>
                <td style="width: 75%">
                    <asp:Label ID="lblAllotmentStatusCAPRound4" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table id="tblSeatAcceptanceStatusDetails" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">Seat Acceptance Details</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Seat Acceptance Status</td>
                <td style="width: 75%">
                    <asp:Label ID="lblSeatAcceptanceStatus" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Seat Acceptance Confirmation Details</td>
                <td>
                    <asp:Label ID="lblSeatAcceptanceConfirmationDetails" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label></td>
            </tr>
        </table>
        <table id="tblSeatAcceptanceFeeDetails" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px;" align="left">Seat Acceptance Fee Details</th>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvFeeDetails" runat="server" AutoGenerateColumns="False" Width="100%" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="15%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDAmount" HeaderText="Amount">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDNumber" HeaderText="Reference Number<br />/ DD Number" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="15%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDDate" HeaderText="Payment Date<br />/ DD Date" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="12%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BankName" HeaderText="Bank Name">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="30%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FeeLockStatus" HeaderText="Payment Status">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="18%" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" align="left" colspan="2">List of Required Documents</th>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" CssClass="DataGrid" OnRowDataBound="gvDocuments_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="57%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Verified">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbnYes" runat="server" Text="&nbsp;Verified" GroupName="YesNo" /></ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="12%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Not Verified">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbnNo" runat="server" Text="&nbsp;Not Verified" GroupName="YesNo" /></ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="15%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                        <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" onclick="javascript:OpenViewDocumentPopUp(this)" runat="server" />
                                    <asp:HiddenField ID="hidFURL" runat="server" Value="<%# Bind('FilePath') %>" />
                                    <asp:HiddenField ID="hidDID" runat="server" Value="<%# Bind('DocumentTransID') %>" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsSubmitted" runat="server" Text='<%# Eval("IsSubmittedAtARC") %>'></asp:Label>
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
            <tr>
                <td style="width: 10%" align="right"><b>Comments</b></td>
                <td style="width: 90%">
                    <asp:TextBox ID="txtComments" runat="server" Width="99%" Height="50px" MaxLength="250" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Confirm Seat Acceptance Form" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
        <script language="javascript" type="text/javascript">
            var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDDDate'));
            function ViewDoc(cntrl) {
                var corrRow = cntrl.parentNode.parentNode;
                var documentName = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
                window.open(documentName);
                return false;
            }
        </script>
    </cc1:ContentBox>
    <div class="modal">
    </div>
    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%" Height="500px">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
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
</asp:Content>
