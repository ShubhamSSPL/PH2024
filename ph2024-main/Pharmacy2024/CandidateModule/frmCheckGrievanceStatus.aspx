<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCheckGrievanceStatus.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmCheckGrievanceStatus" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
       /* #rightContainer_contentViewDocument {
            top: 14% !important;
            width: 90% !important;
        }
           .pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .doc-container {
            height: 25rem;
            border: 1rem solid rgba(0,0,0,.1);
        }*/
         #rightContainer_contentViewDocument{
            top:15% !important;
            height:500px;
            
            width:60%;
            z-index:2000 !important;
        }
        @media only screen and (max-width: 768px){
             #rightContainer_contentViewDocument{
            top:20% !important;
            width:90% !important;           
            height:350px;

            }
            
        }
    </style>
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Check Grievance Status">
        <div class="table-responsive">
            <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanging="gvMessages_SelectedIndexChanging" CssClass="DataGrid">

                <Columns>
                    <asp:BoundField DataField="" HeaderText="Sr. No.">
                        <ItemStyle Width="6%" HorizontalAlign="Center" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GrievanceID" HeaderText="Grievance ID" HtmlEncode="false">
                        <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <%-- <asp:BoundField DataField="Sender" HeaderText="From" HtmlEncode = "false">
                    <ItemStyle Width="10%" HorizontalAlign="Center"  CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>--%>
                    <asp:BoundField DataField="GrievanceSubject" HeaderText="Subject/Grievance Category">
                        <ItemStyle Width="10%" HorizontalAlign="Left" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GrievanceMessage" HeaderText="Grievance Message" HtmlEncode="false">
                        <ItemStyle Width="23%" HorizontalAlign="Left" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SentDateTime" HeaderText="Sent Time">
                        <ItemStyle Width="12%" HorizontalAlign="Center" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ApprovalStatus" HeaderText="Current Status">
                        <ItemStyle Width="12%" HorizontalAlign="Center" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" HeaderText="View" SelectText="View">
                        <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" ForeColor="Blue" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        <ControlStyle Font-Bold="true" />
                    </asp:CommandField>
                    <%-- <asp:BoundField DataField="ApprovedRemark" HeaderText="Approval Remark">
                    <ItemStyle Width="22%" HorizontalAlign="Left"  CssClass="Item"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header"  />
                </asp:BoundField>--%>
                    <%--<asp:BoundField DataField="ApprovedDatetime" HeaderText="Approved Time">
                    <ItemStyle Width="12%" HorizontalAlign="Center"  CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header"  />
                </asp:BoundField>--%>
                    <%--<asp:BoundField DataField="ApprovedBy" HeaderText="Approved By">
                    <ItemStyle Width="5%" HorizontalAlign="Center"  CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header"  />
                </asp:BoundField>--%>
                </Columns>
            </asp:GridView>
        </div>
        <div class="table-responsive">
            <table runat="server" id="tblMsg" visible="false" class="AppFormTable">
                <tr>
                    <th height="100" align="center" valign="middle">
                        <asp:Label ID="lbl_frmSentMessages_Messages" runat="server" Text="There is no Grievance in your Send Grievances" Font-Bold="True" Font-Size="Small"></asp:Label>
                    </th>
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
