<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmMessagesRepliedInstitute.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmMessagesRepliedInstitute" %>
  <%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
     <script lang="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class = "AppFormTableWithOutBorder">
            <tr align = "center">
                <td><a href="../InstituteModule/frmMessagesNonRepliedInstitute.aspx"><font size = "2"><b>&nbsp;&nbsp;|&nbsp;&nbsp;Non Replied Messages&nbsp;&nbsp;|&nbsp;&nbsp;</b></font></a></td>
                <td><a href="../InstituteModule/frmMessagesRepliedInstitute.aspx"><font size = "2" color = "red"><b>&nbsp;&nbsp;|&nbsp;&nbsp;Replied Messages&nbsp;&nbsp;|&nbsp;&nbsp;</b></font></a></td>
                <td><a href="../InstituteModule/frmMessagesComposeInstitute.aspx"><font size = "2"><b>&nbsp;&nbsp;|&nbsp;&nbsp;Compose Message&nbsp;&nbsp;|&nbsp;&nbsp;</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Replied Messages">
        <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" OnLoad="gvMessages_Load" OnRowDataBound="gvMessages_RowDataBound" OnSelectedIndexChanging="gvMessages_SelectedIndexChanging" OnRowCommand="gvMessages_RowCommand" >
            <Columns>
                <asp:BoundField DataField="" HeaderText="Sr. No.">
                    <ItemStyle Width="7%" HorizontalAlign="center" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:TemplateField ItemStyle-Width="20px">
                    <ItemTemplate>
                         <a href="JavaScript:divexpandcollapse('div<%# Eval("MessageID") %>');">
                            <img id="imgdiv<%# Eval("MessageID") %>" width="15px" border="0" src="../Images/plus.gif" />
                        </a>  
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Subject" HeaderText="Subject">
                    <ItemStyle Width="18%" HorizontalAlign="Left" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Message" HeaderText="Message" HtmlEncode = "false">
                    <ItemStyle Width="30%" HorizontalAlign="Left" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SentDateTime" HeaderText="Sent Time">
                    <ItemStyle Width="10%" HorizontalAlign="Center" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="RepliedMessage" HeaderText="Reply">
                    <ItemStyle Width="25%" HorizontalAlign="Left" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="RepliedDateTime" HeaderText="Reply Time">
                    <ItemStyle Width="10%" HorizontalAlign="Center" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Reply">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnReplyCount" runat="server" Value='<%# Bind("ReplyCount") %>' />
                        <asp:Button ID="btnReply" Text="Reply" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Reply" ToolTip="Reply" Visible='<%# Eval("IsStarMarked") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblReplyCount" runat="server" Text='<%# Eval("ReplyCount") %>'></asp:Label>
                        <asp:Label ID="lblMessageID" runat="server" Text='<%# Eval("MessageID") %>'></asp:Label>
                        <asp:Label ID="lblFrom" runat="server" Text='<%# Eval("From") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="7">
                                <div id="div<%# Eval("MessageID") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                    <asp:GridView ID="gvChildGrid" runat="server" AutoGenerateColumns="false" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="RepliedMessage" HeaderText="Reply" HtmlEncode="false">
                                                <ItemStyle Width="80%" HorizontalAlign="Left" CssClass="Item" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RepliedDateTime" HeaderText="Reply Time" DataFormatString="{0:dd/MM/yyyy hh:mm:ss tt}">
                                                <ItemStyle Width="12%" HorizontalAlign="Center" CssClass="Item" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RepliedBy" HeaderText="Replied By">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
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
                <th height = "60" align="center" valign = "middle">
                    <asp:Label ID="lbl_frmSentMessages_Messages" runat="server" Text="There is no Message in your Replied Messages" Font-Bold="True" Font-Size="Small"></asp:Label>
                </th>
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

        function ShowExapandEutton() {
            var grid = document.getElementById("<%= gvMessages.ClientID%>");
            for (var i = 1; i < grid.rows.length; i += 1) {

                if (grid.rows[i].cells[1] != null) {
                    if (grid.rows[i].cells[7] != null) {
                        if (grid.rows[i].cells[7].getElementsByTagName("input")[0].value > 1) {
                            //grid.rows[i].cells[7];
                            grid.rows[i].cells[1].firstElementChild.firstElementChild.style.display = "block";
                        }
                        else {
                            grid.rows[i].cells[1].firstElementChild.firstElementChild.style.display = "none";
                        }
                    }
                    else {
                        grid.rows[i].cells[1].firstElementChild.firstElementChild.style.display = "none";
                    }
                }
                //i += 1;

            }
        }


    </script>
</asp:Content>
