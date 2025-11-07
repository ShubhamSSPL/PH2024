<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" CodeBehind="frmEVerificationCVCTVCNCLEWS.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEVerificationCVCTVCNCLEWS" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/CandidateBasicInfo.ascx" TagName="BInfo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
        #rightContainer_contentViewDocument{
            top:15% !important;
            width:80% !important;
        }
    </style>
      <script lang="javascript" type = "text/javascript">
          window.history.forward(1);
      </script>
    <style>
        input[type="radio"] {
            /*margin: 10px 10px;*/
            margin-right: 8px;
        }
    </style>
    <style>
         .pdfobject-container { height: 30rem; border: 1rem solid rgba(0,0,0,.1); }
         .doc-container { height: 25rem; border: 1rem solid rgba(0,0,0,.1); }
    </style>
    <script src="../Scripts/jquery.js"></script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Candidate Details">
        <uc1:BInfo ID="CandidateBasicInformation" runat="server" />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Special Reservation Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <table class="AppFormTable">
            <tr>
                <th align="left">Special Reservation </th>
                <th align="left">Document for Data Verification </th>
            </tr>
            <tr>
                <td style="vertical-align: top;">
        <table class="AppFormTable" style="background-color: #e7fafe;">
        <tr>
            <th colspan="4" align="left">Personal Information
            </th>
        </tr>
        <tr>
            <td style="width: 20%" align="right">Application ID
            </td>
            <td style="width: 30%">
                <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td style="width: 20%" align="right">Candidate Name
            </td>
            <td style="width: 30%">
                <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Gender
            </td>
            <td>
                <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Date of Birth
            </td>
            <td>
                <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Candidature Type
            </td>
            <td>
                <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Home University
            </td>
            <td>
                <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Category for Admission
            </td>
            <td>
                <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Person with Disability
            </td>
            <td>
                <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Applied for EWS
            </td>
            <td>
                <asp:Label ID="lblAppliedforEWS" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Applied for Orphan
            </td>
            <td>
                <asp:Label ID="lblAppliedforOrphan" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Defence Type
            </td>
            <td>
                <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Applied for TFWS
            </td>
            <td>
                <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Minority Candidature Type
            </td>
            <td >
                <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Cast Name
            </td>
            <td>
                <asp:Label ID="lblCastName" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
                <td style="width: 60%;" runat="server" id="tdDocuments">

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="AppFormTableWithOutBorder">
                                <tr id="trdocument" runat="server" visible="false">
                                    <td>
                                        <asp:Label ID="lbldoclistname" runat="server" Width="250px" Font-Bold="true">Document List : </asp:Label>
                                        <%--<asp:DropDownList ID="ddlDocumentList" runat="server" OnSelectedIndexChanged="ddlDocumentList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>--%>
                                        <asp:RadioButtonList ID="ReadoDocumentList" runat="server" OnSelectedIndexChanged="ReadoDocumentList_CheckedChanged" AutoPostBack="true" CssClass="radioButtonListDocVerification"></asp:RadioButtonList>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblLoadDocumentName"></asp:Label> 
                                        <div runat="server" id="divBotton" >  
                                            <button type="button" onclick="zoomin()" ><img src="../Images/zoom-in.png" width="15px" height="15px"></button> 
                                            <button type="button" onclick="zoomout()"><img src="../Images/zoom-out.png" width="15px" height="15px"> </button> 
                                        </div>
                                        <div runat="server" id="divLoadDocument" class="pdfobject-container"></div>

                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
        </table>
         
        <br />
         <table runat="server" id="tblDocuments" style="width: 100%;" class="AppFormTable">
            <tr>
                <th align="left">List of Documents for Verification</th>
            </tr>
            <tr runat="server" id="trDocumentVerification">
                <td >
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
      <cc1:ContentBox ID="ContentTableDeiscripency" runat="server" HeaderText="Update Status of Verification" Width="100%">
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
                                            <asp:RequiredFieldValidator ID="rfvtxtDiscrepancyRemark" ControlToValidate="txtDiscrepancyRemark"  runat="server" Enabled="false" 
                                                 ErrorMessage="Discrepancy Remark is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:Label ID ="lblStar" runat="server" visible="false" Text="*" Font-Bold="false" ForeColor="Red"></asp:Label> 
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

    </cc1:ContentBox>
        <table class="AppFormTableWithOutBorder" runat="server" id="tblSubmit">
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblmessage" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
          
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Verify Document" CssClass="InputButton" OnClick="btnProceed_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="Convert to Open" CssClass="InputButton" OnClick="btnBack_Click" visible="false"/>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="70%">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr>
                <td>
                    <div class="modal-body" style="height: 450px;">
                        <div runat="server" id="divButtonPopup" >  
                            <button type="button" onclick="zoominPopUp()" ><img src="../Images/zoom-in.png" width="15px" height="15px"></button> 
                            <button type="button" onclick="zoomoutPopUp()"><img src="../Images/zoom-out.png" width="15px" height="15px"> </button> 
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

        function LoadDocument(filePath, DocumentName) {
            document.getElementById('<%=lblLoadDocumentName.ClientID %>').innerHTML = "";
            // document.getElementById('divLoadDocument').innerHTML = '';
            //document.getElementById('lblLoadDocumentName').innerHTML = '';
            //var corrRow = cntrl.parentNode.parentNode;
            // var filePath = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
     <%--       document.getElementById('<%=lblLoadDocumentName.ClientID %>').innerHTML = DocumentName;--%>
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
            <%--document.getElementById('<%=lblLoadDocumentName.ClientID %>').innerHTML = DocumentName;--%>
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<img  src="' + filePath + '">';
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