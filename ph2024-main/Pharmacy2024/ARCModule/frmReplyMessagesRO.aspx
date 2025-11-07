<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmReplyMessagesRO.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmReplyMessagesRO" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script lang="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class = "AppFormTableWithOutBorder">
            <tr align = "center">
                <td><a href="../ARCModule/frmMessagesNonRepliedRO.aspx"><font size = "2" color = "red"><b>|Non Replied Messages|</b></font></a></td>
                <td><a href="../ARCModule/frmMessagesRepliedRO.aspx"><font size = "2"><b>|Replied Messages|</b></font></a></td>
                <td><a href="../ARCModule/frmMessagesComposeRO.aspx"><font size = "2"><b>|Compose Message|</b></font></a></td>
                <td><a href="../ARCModule/frmMessagesSentRO.aspx"><font size = "2"><b>|Sent Messages|</b></font></a></td>
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
                    </ItemTemplate>
                    <ItemStyle Width="60%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:TemplateField>
                <asp:ButtonField HeaderText = "Reply" ButtonType = "Button" CommandName = "Reply" Text = "Reply" ControlStyle-CssClass = "InputButton" ItemStyle-Font-Size="Small">
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
  <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="70%">
            <table class="AppFormTable">
            <tr>
                <th align="left"> 
                    <label id="lblDocumentName"></label>  
                </th>
            </tr> 
            <tr>
                <td>
                    <div class="modal-body" style="height:400px;">
                        <div style="width:100%;height:400px;" id="divDocument"></div>
                    </div>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <div class="modal"></div>

    <script type="text/javascript">

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
                    document.getElementById('divDocument').innerHTML = '<img style="width:100%;height:98%;" src="' + byteStream + '">';
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('divDocument').innerHTML = '<iframe src="' + byteStream + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
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



