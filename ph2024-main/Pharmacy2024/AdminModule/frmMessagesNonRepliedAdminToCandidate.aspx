<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmMessagesNonRepliedAdminToCandidate.aspx.cs" Inherits="Pharmacy2024.AdminModule.frmMessagesNonRepliedAdminToCandidate" %>
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
                <td><a href="../AdminModule/frmMessagesNonRepliedAdminToCandidate.aspx"><font size = "2" color = "red"><b>| Non Replied Messages |</b></font></a></td>
                <td><a href="../AdminModule/frmMessagesRepliedAdminToCandidate.aspx"><font size = "2"><b>| Replied Messages |</b></font></a></td>
               <%-- <td><a href="../AdminModule/frmMessagesSentAdmin.aspx"><font size = "2"><b>| Sent Messages |</b></font></a></td>--%>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Non-Replied Messages">
        <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gvMessages_RowDataBound" OnSelectedIndexChanging="gvMessages_SelectedIndexChanging" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:TemplateField ItemStyle-Width="20px">
                    <ItemTemplate>
                        <a href="JavaScript:divexpandcollapse('div<%# Eval("MessageID") %>');">
                            <img id="imgdiv<%# Eval("MessageID") %>" width="9px" border="0" src="../Images/plus.gif" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
            
                <asp:BoundField DataField="MessageID" HeaderText="Ticket ID" >
                    <ItemStyle Width="10%" HorizontalAlign="Center" Font-Size="9px" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header"  />
                </asp:BoundField>
                <asp:BoundField DataField="Sender" HeaderText="From" HtmlEncode = "false">
                    <ItemStyle Width="15%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Subject" HeaderText="Subject">
                    <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Message" HeaderText="Message" HtmlEncode = "false">
                    <ItemStyle Width="43%" HorizontalAlign="Left" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SentDateTime" HeaderText="Sent Time"  DataFormatString="{0:dd/MM/yyyy hh:mm:ss tt}">
                    <ItemStyle Width="12%" HorizontalAlign="Center" Font-Size="9px" CssClass="Item"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header"  />
                </asp:BoundField>
                <asp:CommandField ShowSelectButton="True" HeaderText = "Reply" SelectText="Reply">
                    <ItemStyle Width="5%" HorizontalAlign="Center"  CssClass="Item" ForeColor="Blue" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle Font-Bold = "true" />
                </asp:CommandField> 
                <asp:TemplateField Visible = "false">
                    <ItemTemplate>
                        <asp:Label ID="lblFrom" runat="server" Text='<%# Eval("From") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <ItemTemplate>
                        <tr>
                            <td colspan="6">
                            <div id="div<%# Eval("MessageID") %>" style="display: none; position: relative; left: 15px; overflow: auto">
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
                                </asp:GridView>
                                </div> 
                            </td>
                            
                              
                            
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table runat = "server" id = "tblMsg" visible="false" class = "AppFormTable">
            <tr>
                <th height = "100" align="center" valign = "middle">
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
    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../Images/minus.gif";
            } else {
                div.style.display = "none";
                img.src = "../Images/plus.gif";
            }
        }
    </script>
</asp:Content>