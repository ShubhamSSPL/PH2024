<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmReplyMessagesAdminToCandidate.aspx.cs" Inherits="Pharmacy2024.AdminModule.frmReplyMessagesAdminToCandidate" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
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
                <td><a href="../AdminModule/frmMessagesNonRepliedAdminToCandidate.aspx"><font size = "2" color = "red"><b>| Non Replied Messages |</b></font></a></td>
                <td><a href="../AdminModule/frmMessagesRepliedAdminToCandidate.aspx"><font size = "2"><b>| Replied Messages |</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Reply Message">
        <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" OnRowCommand="gvMessages_RowCommand" OnRowDataBound="gvMessages_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Message" HeaderText="Message" HtmlEncode = "false">
                    <ItemStyle Width="35%" HorizontalAlign="Left" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:TemplateField HeaderText = "Reply Message">
                    <ItemTemplate>
                        <asp:GridView ID="gvChildGrid" runat="server" AutoGenerateColumns="false" CellPadding="2" BorderWidth = "1px" BorderStyle = "Solid" CssClass="DataGrid" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="RepliedMessage" HeaderText="Reply" HtmlEncode = "false">
                                            <ItemStyle Width="80%" HorizontalAlign="Left" CssClass="Item"/>
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header"  />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RepliedDateTime" HeaderText="Reply Time" DataFormatString="{0:dd/MM/yyyy hh:mm:ss tt}">
                                            <ItemStyle Width="12%" HorizontalAlign="Center"  CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header"  />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RepliedBy" HeaderText="Replied By">
                                            <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header"  />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView><br />
                        <asp:TextBox ID="txtRepliedMessage" runat="server" MaxLength = "1000" Height="80" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="60%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:TemplateField>
                <asp:ButtonField HeaderText = "Reply" ButtonType = "Button" CommandName = "Reply" Text = "Reply" ControlStyle-CssClass = "InputButton">
                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Bottom" CssClass="Item" />
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
</asp:Content>
