<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmMessagesNonRepliedAdmin.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmMessagesNonRepliedAdmin" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">
      <style>
        #rightContainer_contentViewDocument{
            top:12% !important;
        }
        .doc-container{
            height:22rem;
        }
    </style>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder">
            <tr align="center">
                <td><a href="../ARCModule/frmMessagesNonRepliedAdmin.aspx"><font size="2" color="red"><b>|Non Replied Messages|</b></font></a></td>
                <td><a href="../ARCModule/frmMessagesRepliedAdmin.aspx"><font size="2"><b>|Replied Messages|</b></font></a></td>
                <td><a href="../ARCModule/frmMessagesComposeAdmin.aspx"><font size="2"><b>|Compose Message|</b></font></a></td>
                <td><a href="../ARCModule/frmMessagesSentAdmin.aspx"><font size="2"><b>|Sent Messages|</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Non-Replied Messages">
        <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanging="gvMessages_SelectedIndexChanging" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Sender" HeaderText="From" HtmlEncode="false">
                    <ItemStyle Width="15%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Subject" HeaderText="Subject">
                    <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Message" HeaderText="Message" HtmlEncode="false">
                    <ItemStyle Width="43%" HorizontalAlign="Left" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SentDateTime" HeaderText="Sent Time">
                    <ItemStyle Width="12%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:CommandField ShowSelectButton="True" HeaderText="Reply" SelectText="Reply">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle Font-Bold="true" />
                </asp:CommandField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblFrom" runat="server" Text='<%# Eval("From") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table runat="server" id="tblMsg" visible="false" class="AppFormTable">
            <tr>
                <th height="100" align="center" valign="middle">
                    <asp:Label ID="lbl_frmSentMessages_Messages" runat="server" Text="There is no Message in your Non-Replied Messages" Font-Bold="True" Font-Size="Small"></asp:Label>
                </th>
            </tr>
        </table>
    </cc1:ContentBox>
      
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
