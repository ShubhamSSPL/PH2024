<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="UploadImages.aspx.cs" Inherits="CMS_UploadImages" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cbx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">

    <script language="javascript" type="text/javascript">
        function ValidateOnSave() {
            var logoFlag = true, centerImage = true;
            var path = document.getElementById('<%=imgLogo.ClientID %>').value;
            var pathH = document.getElementById('<%=imgHeader.ClientID %>').value;
            if (path.length != 0) {
                var extens = path.split('.');
                var extention = extens[extens.length - 1].toUpperCase();

                if (extention != 'GIF' && extention != 'JPEG' && extention != 'JPG' && extention != 'BMP' &&
                    extention != 'PNG') {
                    alert('-Logo format is invalid');
                    return false;
                }
            }
            else {
                logoFlag = false;
            }

            if (pathH.length != 0) {
                var extens = pathH.split('.');
                var extention = extens[extens.length - 1].toUpperCase();

                if (extention != 'GIF' && extention != 'JPEG' && extention != 'JPG' && extention != 'BMP' &&
                    extention != 'PNG') {
                    alert('-Header format is invalid');
                    return false;
                }
            }
            else {
                centerImage = false;
            }
            //				if (path.length != 0)
            //				{
            //					var extens = path.split('.');
            //					var extention = extens[extens.length-1].toUpperCase();
            //					
            //					if(extention!='GIF' && extention!='JPEG' && extention!='JPG' && extention!='BMP'  &&
            //					        extention!='PNG')
            //					{
            //						alert('-Center image format is invalid');
            //						return false;
            //					}
            //				}
            //				else
            //				{
            //				    centerImage=false;
            ////					alert('-Please select Center image');
            ////					return false;
            //				}
            //
            if (!logoFlag && !centerImage) {
                alert('-Please select Logo \n -Please select Center image')
                return false;
            }
            //				else 
            //                {
            //				    if (!logoFlag) {
            //				        alert('-Please select Logo')
            //				        return false;
            //				    }
            //				    if (!centerImage) {
            //				        alert('-Please select Header')
            //				        return false;
            //				    } 
            //				} 
        }


    </script>

    <cbx:ContentBox ID="cbxContentManagement" runat="server" HeaderText="Upload Images">
        <div>
            <b><u>Note : </u></b>
            <ol>
                <li>Format of <b>Logo image</b> should be of (.GIF, .JPEG, .JPG, .BMP or .PNG)
                </li>
                <li>Logo image size should not be more than <b>5KB.</b> </li>
                <%--<li>1. &nbsp;&nbsp; Format of <b>Logo or Center image</b> should be of (.GIF, .JPEG, .JPG, .BMP or .PNG)
                </li>
                <li>2. &nbsp;&nbsp; Logo image size should not be more than <b>5KB.</b> </li>
                <li>3. &nbsp;&nbsp; Center image size should not be more than <b>60KB.</b> </li>--%>
            </ol>
        </div>
        <table class="AppFormTable">
            <tr>
                <td style="width: 25%; text-align: left">Upload Logo :
                </td>
                <td>
                    <input id="imgLogo" type="file" runat="server" style="width: 90%" />
                </td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: left">Upload Center Image :
                </td>
                <td>
                    <input id="imgHeader" type="file" runat="server" style="width: 90%" />
                </td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <asp:Button ID="btnSaveImage" runat="server" Text=" Upload " ToolTip="Upload Image"
                        OnClientClick="return ValidateOnSave();" CssClass="InputButton" OnClick="btnSaveImage_Click"></asp:Button>
                </td>
            </tr>
        </table>
    </cbx:ContentBox>
</asp:Content>
