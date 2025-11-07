<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="EVerificationUniversityAndCategoryDetails.aspx.cs" Inherits="Pharmacy2024.E_FCModule.EVerificationUniversityAndCategoryDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/CandidateBasicInfo.ascx" TagName="BInfo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <script src="../Scripts/MahaITDocumentFetch.js"></script>
    <style>
        input[type="radio"] {
            /*margin: 10px 10px;*/
            margin-right: 8px;
        }

        #layoutSidenav #layoutSidenav_content {
            margin-left: unset !important;
        }
      
        @media only screen and (max-width: 768px) {
            .AppFormTableWithOutBorder input {
                font-size: 11px;
            }
        }
        .pdfobject-container img{
            width:100%;
        }
    </style>
   
    <script src="../Scripts/jquery.js"></script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Candidate Details">
        <uc1:BInfo ID="CandidateBasicInformation" runat="server" />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Home District Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="table-responsive">
            <table class="AppFormTable">

                <tr>
                    <td style="vertical-align: top;">
                        <div class="row w-100 mx-auto">
                            <div class="col-sm-6 mb-3">
                                <table class="AppFormTable">
                                    <tr>
                                        <th align="left" colspan="2">Home District Details</th>

                                    </tr>
                                    <tr>

                                        <td style="width: 25%;" colspan="2">
                                            <asp:Label ID="lblCandidatureType" runat="server" Text="Your Type of Candidature : "></asp:Label></td>
                                    </tr>
                                    <tr runat="server" id="trDocumentOf">
                                        <td style="width: 25%;" align="right">
                                            <asp:Label ID="QDocumentOf" runat="server"></asp:Label></td>
                                        <td style="width: 15%;">
                                            <asp:Label ID="lblDocumentOf" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trMothersName">
                                        <td align="right">Mother's Name as appeared in Domicile Certificate</td>
                                        <td valign="top">
                                            <asp:Label ID="lblMothersName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trQ2">
                                        <td align="right">
                                            <asp:Label ID="lblQ2" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblDistrict2" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trQ21">
                                        <td align="right">
                                            <asp:Label ID="lblQ21" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblTaluka2" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trCategoryHead">
                                        <th colspan="2" align="left">Category Details</th>
                                    </tr>
                                    <tr runat="server" id="trCategory">
                                        <td align="right">Category</td>
                                        <td>
                                            <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trOpenCaste">
                                        <td align="right">Caste Name</td>
                                        <td>
                                            <asp:Label ID="lblCasteNameForOpen" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trAppliedForEWS1" runat="server" visible="false">
                                        <td align="right">Annual Family Income</td>
                                        <td>
                                            <asp:Label ID="lblAnnualFamilyIncome" runat="server" Font-Bold="true"></asp:Label></td>
                                    </tr>
                                    <tr id="trAppliedForEWS2" runat="server" visible="false">
                                        <td align="right">Applied for EWS</td>
                                        <td>
                                            <asp:Label ID="lblAppliedForEWS" runat="Server"></asp:Label>
                                            <asp:Label ID="lblAppliedForEWSMsg" runat="server" ForeColor="red" Font-Bold="true" Visible="false">You are Not Eligible for EWS Seats because Your Parents having Annual Income Above 8 Lacs.</asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trReservedCaste">
                                        <td align="right">Caste Name</td>
                                        <td>
                                            <asp:Label ID="lblCaste" runat="server" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trNCLStatus">
                                        <td align="right">Non-Creamy Layer Certificate Status</td>
                                        <td>
                                            <asp:Label ID="lblNCLStatus" runat="server">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-sm-6 ">
                                <h2 class="font-weight-bold text-primary">Document for Data Verification</h2>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table class="AppFormTableWithOutBorder">
                                            <tr id="trdocument" runat="server" visible="false">
                                                <td>
                                                    <%--<asp:Label ID="lbldoclistname" runat="server" Width="250px" Font-Bold="true">Document List : </asp:Label>--%>
                                                    <%--<asp:DropDownList ID="ddlDocumentList" runat="server" OnSelectedIndexChanged="ddlDocumentList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>--%>
                                                    <asp:RadioButtonList ID="ReadoDocumentList" runat="server" OnSelectedIndexChanged="ReadoDocumentList_CheckedChanged" AutoPostBack="true" CssClass="radioButtonListDocVerification"></asp:RadioButtonList>

                                                </td>

                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label runat="server" ID="lblLoadDocumentName"></asp:Label>
                                                    <div runat="server" id="divcondoc" style="display: none;"></div>
                                                    <div runat="server" id="divBotton">
                                                        <button type="button" onclick="zoomin()">
                                                            <img src="../Images/zoom-in.png" width="15px" height="15px"></button>
                                                        <button type="button" onclick="zoomout()">
                                                            <img src="../Images/zoom-out.png" width="15px" height="15px">
                                                        </button>
                                                    </div>
                                                    <div runat="server" id="divLoadDocument" class="pdfobject-container"></div>

                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                    </td>

                </tr>
            </table>
        </div>
        <div class="table-responsive">
            <table runat="server" id="tblNCLApplied" class="AppFormTable">
                <tr>
                    <td align="right" style="width: 25%; border-top-width: 0px;">Non-Creamy Layer Certificate Application Number</td>
                    <td style="width: 25%; border-top-width: 0px;">
                        <asp:Label ID="lblNCLApplicationNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">Non-Creamy Layer Certificate Application Date</td>
                    <td>
                        <asp:Label ID="lblNCLApplicationDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">Non-Creamy Layer Certificate Issuing Authority Name</td>
                    <td>
                        <asp:Label ID="lblNCLAuthority" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="table-responsive">
            <table runat="server" id="tblDocuments" style="width: 100%;" class="AppFormTable">
                <tr>
                    <th align="left">List of Documents for Verification</th>
                </tr>
                <tr runat="server" id="trDocumentVerification">
                    <td>
                        <font color="red">Documents shown in red color are not uploaded. You can not verify that documents without uploading.</font>
                        <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid" OnRowDataBound="gvDocuments_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="8%" />
                                    <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                </asp:TemplateField>
                                <%--<asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="8%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>--%>
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

        <cc1:ContentBox ID="ContentTableDeiscripency" runat="server" HeaderText="Update Status of Verification" Width="100%">
            <div class="table-responsive">
                <asp:UpdatePanel ID="updatepnl" runat="server">
                    <%-- <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmitDiscripancy" />
            </Triggers>--%>
                    <ContentTemplate>
                        <table class="AppFormTableWithOutBorder" runat="server" id="tblDiscripancy">
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="gvDiscrepancy" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid" OnRowDataBound="gvDiscrepancy_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="5%" />
                                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DiscrepancyName" HeaderText="Particulars" HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="20%" />
                                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Status of Verification">
                                                <ItemTemplate>
                                                    <asp:RadioButton ID="rbnYes" runat="server" Text="&nbsp;Verified" GroupName="YesNo" AutoPostBack="true" OnCheckedChanged="rbnYes_CheckedChanged" />
                                                    &nbsp; &nbsp;&nbsp;
                                             <asp:RadioButton ID="rbnNo" runat="server" Text="&nbsp;Not Accepted" GroupName="YesNo" AutoPostBack="true" OnCheckedChanged="rbnNo_CheckedChanged" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="25%" />
                                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                            </asp:TemplateField>
                                            <%--     <asp:TemplateField HeaderText="Mark Discrepancy">
                                        <ItemTemplate>
                                           
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="15%" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                    </asp:TemplateField>--%>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIsVerifiedAtAFC" runat="server" Text='<%# Eval("IsVerifiedAtAFC") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDiscrepancyID" runat="server" Text='<%# Eval("DiscrepancyID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIsDiscrepancyMarked" runat="server" Text='<%# Eval("IsDiscrepancyMarked") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDocumentId" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Discrepancy Remark">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDiscrepancyRemark" runat="server" Text='<%# Bind("DiscrepancyRemark") %>' TextMode="MultiLine" Height="50" Width="90%" Enabled="false" />
                                                    <asp:RequiredFieldValidator ID="rfvtxtDiscrepancyRemark" ControlToValidate="txtDiscrepancyRemark" runat="server" Enabled="false"
                                                        ErrorMessage="Discrepancy Remark is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="lblStar" runat="server" Visible="false" Text="*" Font-Bold="false" ForeColor="Red"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="50%" />
                                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <%--  <tr>
                        <td align="center">
                            <asp:Button ID="btnSubmitDiscripancy" runat="server" Text="Submit" CssClass="InputButton" OnClick="btnSubmitDiscripancy_Click" ValidationGroup="subgrp" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancelDiscripancy" runat="server" Text="Discard" CssClass="InputButton" OnClick="btnCancelDiscripancy_Click" />
                        </td>
                    </tr>--%>
                        </table>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </cc1:ContentBox>

        <table class="AppFormTableWithOutBorder" runat="server" id="tblSubmit">
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblmessage" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnECandidateDashboard" runat="server" Text="Verification Dashboard" CssClass="InputButton" OnClick="btnECandidateDashboard_Click" />
                </td>
                <td align="left">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                </td>
            </tr>
        </table>

        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="70%">
        <table class="AppFormTable ">
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
                var dsResponse = Pharmacy2024.E_FCModule.EVerificationUniversityAndCategoryDetails.GetDocumentFetchData(personalID, documentID);
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

        function zoomin() {
            var GFG = document.getElementById('<%=imgDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth + 100) + "px";
        }

        function zoomout() {
            var GFG = document.getElementById('<%=imgDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth - 100) + "px";
        }

        function LoadDocument(filePath, DocumentName, personalID, documentID, IsBarcodeFetch) {
            document.getElementById('<%=lblLoadDocumentName.ClientID %>').innerHTML = "";
            // document.getElementById('divLoadDocument').innerHTML = '';
            //document.getElementById('lblLoadDocumentName').innerHTML = '';
            //var corrRow = cntrl.parentNode.parentNode;
            // var filePath = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
     <%--       document.getElementById('<%=lblLoadDocumentName.ClientID %>').innerHTML = DocumentName;--%>

            if (IsBarcodeFetch == "Y") {
                var dsResponse = Pharmacy2024.E_FCModule.EVerificationUniversityAndCategoryDetails.GetDocumentFetchData(personalID, documentID);
                DisplayFetchDocuVerification(dsResponse, documentID, IsBarcodeFetch);
            }
            else {
                document.getElementById('rightContainer_ContentTable2_divcondoc').style.display = 'none';
                document.getElementById('rightContainer_ContentTable2_divcondoc').innerHTML = "";
            }
            var dsResponse = Pharmacy2024.ViewMyDocument.GetCandidateDocumentAsBase64(filePath);
            var byteStream = dsResponse.value;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divBotton.ClientID %>').style.display = 'inline';
                    document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<img id="imgDoc" runat="server" src="' + byteStream + '">';
                    document.getElementById('<%=divLoadDocument.ClientID %>').style.overflow = "auto";
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<iframe src="' + byteStream + '" autostart="true" style="width:100%;height:450px;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divBotton.ClientID %>').style.display = 'none';
                    document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:450px;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }
        function HideMarkDiscripencyDoc(filePath, DocumentName) {
            HideMarkDiscripency();
            document.getElementById('<%=lblLoadDocumentName.ClientID %>').innerHTML = "";
            // document.getElementById('divLoadDocument').innerHTML = '';
            //document.getElementById('lblLoadDocumentName').innerHTML = '';
            //var corrRow = cntrl.parentNode.parentNode;
            // var filePath = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            document.getElementById('<%=lblLoadDocumentName.ClientID %>').innerHTML = DocumentName;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<img   src="' + filePath + '">';
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<iframe src="' + filePath + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<embed src="' + filePath + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }

        function MarkDiscripency() {
            document.getElementById('<%=ContentTableDeiscripency.ClientID %>').Show('', true);
            document.getElementsByClassName("HeadDiv")[3].children[1].hidden = true;
            document.getElementById('<%=lblmessage.ClientID%>').innerText = '';
            document.getElementById('<%=tblSubmit.ClientID %>').style.visibility = "hidden";
        }
        function HideMarkDiscripency() {
            document.getElementById('<%=ContentTableDeiscripency.ClientID %>').Hide('', true);
            document.getElementById('<%=tblSubmit.ClientID %>').style.visibility = "visible";
            //document.getElementById('<%=tblSubmit.ClientID %>').Show('', true);
        }

    </script>
</asp:Content>
