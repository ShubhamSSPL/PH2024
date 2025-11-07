<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageImg_withoutftp.aspx.cs" Inherits="ContentManagement_ManageImg_withoutftp" %>

<%@ Register Namespace="Synthesys.Controls" Assembly="Synthesys.Controls.ShowMessage" TagPrefix="cbxMsg" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Images</title>

    <script language="javascript" type="text/javascript">
        function ValidateOnSave() {
            var path = document.getElementById('imgUpload').value;
            if (path.length != 0) {
                var extens = path.split('.');
                var extention = extens[extens.length - 1].toUpperCase();

                if (extention != 'GIF' && extention != 'JPEG' && extention != 'JPG' && extention != 'BMP' &&
                    extention != 'PNG') {
                    alert('-Image format is invalid');
                    return false;
                }
            }
            else {
                alert('-Please select image');
                return false;
            }
        }

        function CheckOnDelete() {
            var imgIds = '';
            var arr = document.getElementById('MNgallery').getElementsByTagName('INPUT');
            for (j = 0; j < arr.length; j++)
                if (arr[j].type == 'checkbox' && arr[j].checked)
                    imgIds += arr[j].id + ',';

            if (imgIds == '') {
                alert('-Please select image to delete');
                return false;
            }
            else
                document.getElementById('<%=hdnImageID.ClientID%>').value = imgIds.substring(0, imgIds.lastIndexOf(','))
        }

        function UnCheckSelectAllbox(chkImg) {
            if (!chkImg.checked)
                document.getElementById('<%=chkSelectAll.ClientID%>').checked = false;
        }
        function SelectAllOnClick(flag) {
            var arr = document.getElementById('MNgallery').getElementsByTagName('INPUT');
            for (j = 0; j < arr.length; j++)
                if (arr[j].type == 'checkbox')
                    arr[j].checked = flag;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <cbxMsg:ShowMessage ID="showMsg" runat="server" />
        <table style="display: block; border: solid 1px #c0c0c0; width: 98%">
            <tr>
                <td colspan="3">
                    <b><u>Note : </u></b>
                    <ol>
                        <li>Format of <b>Image</b> should be of (.GIF, .JPEG,
                            .JPG, .BMP or .PNG) </li>
                        <%--<li> Image size should not be more than <b>2MB.</b> </li>--%>
                    </ol>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-weight: bold; text-align: center; display: block;">Manage Images
                </td>
            </tr>
            <tr>
                <td style="text-align: right; font-weight: bold; width: 20%; display: block; border: solid 1px #c0c0c0;">Select image path :
                </td>
                <td style="width: 60%; display: block; border: solid 1px #c0c0c0;">
                    <input id="imgUpload" type="file" runat="server" style="width: 90%" />
                </td>
                <td style="text-align: center; display: block; border: solid 1px #c0c0c0;">
                    <asp:Button ID="btnSaveImage" runat="server" Text=" Upload " ToolTip="Upload Image"
                        OnClick="btnSaveImage_Click" OnClientClick="return ValidateOnSave();"></asp:Button>
                </td>
            </tr>
        </table>
        <table id="tblPhotoes" runat="server" style="display: block; border: solid 1px #c0c0c0; width: 98%">
            <tr>
                <td align="center" colspan="3">
                    <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" onclick="SelectAllOnClick(this.checked);" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Repeater ID="repeaterPhotoes" runat="server">
                        <HeaderTemplate>
                            <table>
                                <tr id="MNgallery">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <td style="display: block; height: 7em; width: 8em; float: left; border: solid 1px #c0c0c0; margin: 3px;">
                                <input type="checkbox" id="<%#DataBinder.Eval(Container.DataItem, "ImageId")%>" onclick="UnCheckSelectAllbox(this)" />
                                <img src="<%#DataBinder.Eval(Container.DataItem, "Path")%>" alt="<%#DataBinder.Eval(Container.DataItem, "ImageName")%>"
                                    height="100" width="100" title="<%#DataBinder.Eval(Container.DataItem, "ImageName")%>" />
                            </td>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tr> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <input type="hidden" id="hdnImageID" runat="server" />
                </td>
            </tr>
            <tr>
                <td valign="middle" style="text-align: center" colspan="3">
                    <asp:ImageButton ID="prevImgBtn" runat="server" OnClick="prevImgBtn_Click" ImageUrl="~/SynthesysModules_Files/Images/prevbtn.gif" />
                    <asp:ImageButton ID="nxtImgBtn" runat="server" OnClick="nxtImgBtn_Click" ImageUrl="~/SynthesysModules_Files/Images/nextbtn.gif" />
                    <input type="hidden" id="hdnCurrentPageIndex" runat="server" />
                </td>
            </tr>
            <tr style="display: block; border: solid 1px #c0c0c0;">
                <td align="right" style="width: 50%;">
                    <input onclick="window.close();" type="button" value=" Close " />
                </td>
                <td align="left" colspan="3">
                    <asp:Button ID="btnDelete" runat="server" Text=" Delete " OnClick="btnDelete_Click"
                        OnClientClick="return CheckOnDelete();"></asp:Button>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
