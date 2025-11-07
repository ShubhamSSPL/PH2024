<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmViewGrievance.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmViewGrievance" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <style>
        /*.pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .doc-container {
            height: 25rem;
            border: 1rem solid rgba(0,0,0,.1);
        }
       
        #rightContainer_contentViewDocument {
            top: 14% !important;
            width: 90% !important;
        }*/
        
      
    </style>

    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="View Grievance Details(तक्रार तपशील पहा)" Visible="false">
        <div class="table-responsive">
            <table class="AppFormTable">
                <tr>
                    <td align="center" colspan="2"><b>Grievance ID (तक्रार क्रमांक):
                        <asp:Label ID="lblGrievanceID" runat="server"></asp:Label>
                    </b></td>
                </tr>
                <tr>
                    <td style="width: 40%;" align="right"><b>Grievance Sub Type/Subject
                        <br />तक्रारीचा प्रकार / विषय</td>
                    <td style="width: 60%;" align="left">
                        <asp:Label ID="lblSubject" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right"><b>Grievance Details 
                        <br />
                        तक्रारीचा तपशील</b></td>
                    <td align="left">
                        <asp:Label ID="lblGrievanceMessage" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" valign="top"><b>Sent Date Time
                        <br />
                        तक्रार पाठविण्याचा दिनांक आणि वेळ </b></td>
                    <td align="left">
                        <asp:Label ID="lblSentTime" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" valign="top"><b>Current Status
                        <br />
                        सध्य स्थिती</b></td>
                    <td align="left">
                        <asp:Label ID="lblApprovalStatus" runat="server"></asp:Label></td>
                </tr>
                <tr id="trReplyRemark" runat="server">
                    <td align="right" valign="top"><b>Reply/Remark From SC
                        <br />
                        SC कडून प्रत्युत्तर</b></td>
                    <td align="left">
                        <asp:Label ID="lblReplyRemark" runat="server"></asp:Label></td>
                </tr>
                <tr id="trReplyBy" runat="server">
                    <td align="right" valign="top"><b>Status Updated By
                        <br />
                        स्थिती अद्यतनित द्वारा </b></td>
                    <td align="left">
                        <asp:Label ID="lblReplyBy" runat="server"></asp:Label></td>
                </tr>
                <tr id="trReplyDate" runat="server">
                    <td align="right" valign="top"><b>Current Status Updated Date Time
                        <br />
                        सध्य स्थिती अद्यतन दिनांक आणि वेळ </b></td>
                    <td align="left">
                        <asp:Label ID="lblReplyDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="InputButton" OnClick="btnClose_Click" />
                    </td>
                </tr>
            </table>
        </div>
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
                    <div class="modal-body" >
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
    <div class="modal"></div>

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

        function OpenViewDocumentPopUp(filePathFromDB) {

            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            //var corrRow = cntrl.parentNode.parentNode;
            var filePath = filePathFromDB;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            //corrRow.cells[corrRow.cells.length - 5].innerText

            document.getElementById('lblDocumentName').innerHTML = 'Attachment'; //corrRow.cells[corrRow.cells.length - 5].innerText;
            var dsResponse = Pharmacy2024.ViewMessageBoxDocument.GetBlobContentAsBase64(filePathFromDB);
            var byteStream = dsResponse.value;
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
    <script type="text/javascript">
        document.onmousedown = disableRightclick;
        var message = "Right click is not allowed !!";
        function disableRightclick(evt) {
            if (evt.button == 2) {
                alert(message);
                return false;
            }
        }
    </script>
</asp:Content>


