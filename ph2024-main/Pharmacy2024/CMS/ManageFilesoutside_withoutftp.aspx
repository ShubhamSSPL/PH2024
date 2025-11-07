<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageFilesoutside_withoutftp.aspx.cs" Inherits="ContentManagement_ManageFilesoutside_withoutftp" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">

    <script language="javascript" type="text/javascript">
        function ValidateOnSave() {
            var path = document.getElementById('rightContainer_cb_fileUpload').value;
            if (path.length != 0) {
                var extens = path.split(".");
                var extension = extens[extens.length - 1].toUpperCase();
                if (extension != 'DOC' && extension != 'DOCX' && extension != 'TXT' && extension != 'XLS' &&
                    extension != 'XLSX' && extension != 'PDF' && extension != 'PPT' && extension != 'PPTX' && extension != 'ZIP' &&
                    extension != 'RAR') {
                    alert('-File format is invalid');
                    return false;
                }
            }
            else {
                alert('-Please select file');
                return false;
            }
        }

        function CheckOnDelete() {
            var fileIds = '';
            var arr = document.getElementById('<%=gvFiles.ClientID%>').getElementsByTagName('INPUT');
            for (j = 0; j < arr.length; j++)
                if (arr[j].type == 'checkbox' && arr[j].checked && arr[j].id != 'chkHeader')
                    fileIds += arr[j].id + ',';

            if (fileIds == '') {
                alert('-Please select file to delete');
                return false;
            }
            else
                document.getElementById('<%=hdnFileID.ClientID%>').value = fileIds.substring(0, fileIds.lastIndexOf(','))
        }

        function UnCheckSelectAllbox(chkFile) {
            if (!chkFile.checked)
                document.getElementById('chkHeader').checked = false;
        }
        function SelectAllOnClick(flag) {
            var arr = document.getElementById('<%=gvFiles.ClientID%>').getElementsByTagName('INPUT');
            for (j = 0; j < arr.length; j++)
                if (arr[j].type == 'checkbox')
                    arr[j].checked = flag;
        }
    </script>
    <ccm:ContentBox runat="server" ID="cb" Width="700px" HeaderText="Manage File">
        <table class="AppFormTable">
            <tr>
                <td colspan="3">
                    <b><u>Note : </u></b>
                    <ol>
                        <li>Format of <b>File</b> should be of (.DOC, .DOCX, .TXT, .XLSX, .PDF, .PPT, .ZIP or
                            .RAR) </li>
                        <%--<li> File size should not be more than <b>2MB.</b> </li>--%>
                    </ol>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-weight: bold; text-align: center; display: block;">Manage Files
                </td>
            </tr>
            <tr>
                <td style="text-align: right; font-weight: bold; width: 20%; display: block; border: solid 1px #c0c0c0;">Select file path :
                </td>
                <td style="width: 60%; display: block; border: solid 1px #c0c0c0;">
                    <input id="fileUpload" type="file" runat="server" style="width: 90%" />
                </td>
                <td style="text-align: center; display: block; border: solid 1px #c0c0c0;">
                    <asp:Button ID="btnSaveFile" runat="server" Text=" Upload " ToolTip="Upload File"
                        OnClick="btnSaveFile_Click" OnClientClick="return ValidateOnSave();"></asp:Button>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="False" CssClass="DataGrid"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="15%" HeaderText="Sr. No" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblSrNo" runat="server" Text="<%#(Container.DataItemIndex)+1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" HeaderText="Name of File" DataField="FileName"
                                ItemStyle-HorizontalAlign="left" ItemStyle-Width="50%"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkHeader" onclick="SelectAllOnClick(this.checked)" />
                                    <label for="chkHeader">
                                        Select All</label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" id="<%#DataBinder.Eval(Container.DataItem, "FileId")%>" onclick="UnCheckSelectAllbox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"
                                HeaderText="File Location">
                                <ItemTemplate>
                                    <asp:Label ID="lblFileLocation" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderStyle-CssClass="NotVisible" HeaderText="FileId" DataField="FileId"
                                ItemStyle-CssClass="NotVisible"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <input type="hidden" id="hdnFileID" runat="server" />
                </td>
            </tr>
            <tr id="trDelete" runat="server">
                <td colspan="3" style="text-align: center">
                    <asp:Button ID="btnDelete" runat="server" Text=" Delete " ToolTip="Delete file" OnClick="btnDelete_Click"
                        OnClientClick="return CheckOnDelete();"></asp:Button>
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
</asp:Content>

