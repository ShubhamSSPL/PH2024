<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="ContentNewEditor.aspx.cs" Inherits="ContentManagement_ContentEditor" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script type="text/javascript" src="../SynthesysModules_Files/ckeditor/ckeditor.js"></script>

    <script language="Javascript" type="text/javascript">
        function GetConfirmation() {
            document.getElementById('<%=CBConfirmation.ClientID%>').Show('#000000', true);
            return false;
        }
        function HidePopUp() {
            var popup = document.getElementById("<%=CBConfirmation.ClientID %>");
            popup.Hide();
        }

        function VerifyContent() {

            if (document.getElementById('<%=DdlLanguage.ClientID %>').selectedIndex != 0) {
                var oEditor = CKEDITOR.instances.rightContainer_Content;
                var data = oEditor.getData();
                data = data.replace(/[\n\s\t]/g, "");
                data = data.substring(40);
                data = data.substring(0, data.length - 14);
                data = data.replace(/&nbsp;/g, "");
                data = data.replace(/<.*?>/g, "");
                if (data == '') {
                    alert('please enter some data');
                    return false;
                }
                else {

                    return true;
                }
            }
            else {
                alert('please select language');
                return false;
            }
        }

        function ManageImages() {
            window.open('../CMS/ManageImg.aspx', 'myPopup', 'height=300,width=600,left=200,top=200,resizable=yes,scrollbars=yes,toolbar=no,status=no');

            return false;
        }
        function ManageFiles() {
            document.getElementById('<%=cbManageFiles.ClientID%>').Show('#000000', true);
            document.getElementById('iFrameFiles').src = '../CMS/ManageFiles.aspx';
            return false;
        }
        function OpenLingualEditor() {
            document.getElementById('<%=cbLingualEditor.ClientID%>').Show('#000000', true);
            document.getElementById('iFrameLingualEditor').src = '../CMS/LingualEditor.aspx';
            return false;
        }
    </script>

    <table style="width: 670px">
        <tr>
            <td style="width: 50%">
                <div id="SiteMap" runat="Server" style="font-family: Verdana; font-size: 11px; color: Maroon;">
                </div>
            </td>
            <td align="right" style="width: 50%; font-family: Verdana; font-size: 11px; color: Maroon;">
                <b>Last Modified On: </b>
                <asp:Label ID="LblRecordModified" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <div class="pod">
        <table style="border-collapse: collapse; vertical-align: baseline; height: 15px; width: 670px">
            <tr>
                <td align="right">
                    <b>Added Content:&nbsp; </b>
                </td>
                <td>
                    <asp:DropDownList ID="ddlContents" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlContents_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="center">
                    <input type="button" id="btn_OpenLingualEditor" value="Open Lingual Editor" onclick="OpenLingualEditor()"
                        class="InputButton" /></td>
            </tr>



        </table>
    </div>
    <div class="pod">
        <table style="border-collapse: collapse; vertical-align: baseline; height: 30px; width: 670px">
            <tr>
                <td align="center" style="width: 200px; text-align: right;">
                    <b>Language: &nbsp;</b>
                    <asp:DropDownList ID="DdlLanguage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlLanguage_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td align="center" style="vertical-align: middle">
                    <asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click" OnClientClick="return VerifyContent()"
                        CssClass="InputButton" Height="20px" Width="50px" />
                </td>
                <td align="right" style="width: 200px; vertical-align: middle">
                    <input type="button" id="btnmanageimages" value="Manage Images" onclick="ManageImages()"
                        class="InputButton" />
                    &nbsp;&nbsp;
                </td>
                <td align="center" style="width: 100px; vertical-align: middle">
                    <input type="button" id="btnmanagefiles" value="Manage Files" onclick="ManageFiles()"
                        class="InputButton" />
                </td>
            </tr>
        </table>
    </div>
    <textarea cols="80" id="Content" name="Content" rows="30" runat="server">
    </textarea>

    <script type="text/javascript">
        //<![CDATA[

        CKEDITOR.replace('rightContainer_Content',
            {
                fullPage: true,
                height: 300,
                width: 690
            });
			//]]>
    </script>

    <ccm:ContentBox runat="server" ID="CBConfirmation" HeaderText="Clear Editor" BoxType="PopupBox">
        <table class="AppFormTable">
            <tr>
                <asp:HiddenField ID="HdnNewContent" runat="server" />
                <asp:HiddenField ID="hddSitemap" runat="server" />
                <td colspan="2">Are you sure you want to clear/reset the editor?
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Btn_Clear" runat="server" Text="Reset" CssClass="InputButton" Width="50px"
                        Height="20px" OnClientClick="ResetContent()" />
                    <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" CssClass="InputButton" Width="50px"
                        Height="20px" OnClientClick="HidePopUp()" /></td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox ID="cbManageImages" runat="server" HeaderText=" " BoxType="PopupBox"
        Width="60%" Height="400px">
        <iframe id="iFrameImages" frameborder="0" src="../SynthesysModules_Files/Resources/Wait.html"
            style="width: 98%; height: 98%"></iframe>
    </ccm:ContentBox>
    <ccm:ContentBox ID="cbManageFiles" runat="server" HeaderText=" " BoxType="PopupBox"
        Width="60%" Height="300px">
        <iframe id="iFrameFiles" frameborder="0" src="../SynthesysModules_Files/Resources/Wait.html"
            style="width: 98%; height: 98%"></iframe>
    </ccm:ContentBox>
    <ccm:ContentBox ID="cbLingualEditor" runat="server" HeaderText="Langauge Editor " BoxType="PopupBox"
        Width="60%" Height="500px" HorizontalAlign="Center">
        <iframe id="iFrameLingualEditor" frameborder="0" src="../SynthesysModules_Files/Resources/Wait.html"
            style="width: 98%; height: 98%"></iframe>
    </ccm:ContentBox>
</asp:Content>
