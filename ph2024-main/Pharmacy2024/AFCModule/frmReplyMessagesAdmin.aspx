<%@ Page Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.master" AutoEventWireup="true" CodeBehind="frmReplyMessagesAdmin.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmReplyMessagesAdmin" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script lang="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <style>
        .pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .doc-container {
            height: 25rem;
            border: 1rem solid rgba(0,0,0,.1);
        }
    </style>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class = "AppFormTableWithOutBorder">
            <tr align = "center">
                <td><a href="../AFCModule/frmMessagesNonRepliedAdmin.aspx"><font size = "2" color = "red"><b>| Non Replied Messages |</b></font></a></td>
                <td><a href="../AFCModule/frmMessagesRepliedAdmin.aspx"><font size = "2"><b>| Replied Messages |</b></font></a></td>
                <td><a href="../AFCModule/frmMessagesComposeAdmin.aspx"><font size = "2"><b>| Compose Message |</b></font></a></td>
                <td><a href="../AFCModule/frmMessagesSentAdmin.aspx"><font size = "2"><b>| Sent Messages |</b></font></a></td>
                <td><a href="../AFCModule/frmMessagesStarMarked.aspx"><font size = "2"><b>| Star Marked Messages |</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Reply Message">
        <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" OnRowCommand="gvMessages_RowCommand">
            <Columns>
                <asp:BoundField DataField="Message" HeaderText="Message" HtmlEncode = "false">
                    <ItemStyle Width="35%" HorizontalAlign="Left" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:TemplateField HeaderText = "Reply Message">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRepliedMessage" runat="server" MaxLength = "1000" Height="80" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        <br />
                        <asp:checkbox id="chkIsStarMarked" runat="server" Text="Mark as Star"/>
                    </ItemTemplate>
                    <ItemStyle Width="60%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:TemplateField>
                <asp:ButtonField HeaderText = "Reply" ButtonType = "Button" CommandName = "Reply" Text = "Reply" ControlStyle-CssClass = "InputButton">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle Font-Bold="True" />
                </asp:ButtonField> 
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblMessageID" runat="server" Text='<%# Eval("MessageID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
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



