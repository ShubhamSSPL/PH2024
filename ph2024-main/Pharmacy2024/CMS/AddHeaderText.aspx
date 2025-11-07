<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="AddHeaderText.aspx.cs" Inherits="CMS_AddHeaderText" ValidateRequest="false" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cbx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">


    <script type="text/javascript" src="../SynthesysModules_Files/ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
</script>
    <div class="pod">
        <table style="border-collapse: collapse; vertical-align: baseline; height: 30px; width: 670px">
            <tr>
                <td style="width: 200px; text-align: left;">
                    <b>Language: </b>
                    <asp:DropDownList ID="DdlLanguage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlLanguage_Change">
                    </asp:DropDownList>
                </td>
                <td>
                    <input type="button" id="btn_OpenLingualEditorText" value="Open Lingual Editor" onclick="OpenLingualEditor()"
                        class="InputButton" />

                </td>

            </tr>
        </table>
    </div>
    <cbx:ContentBox ID="cbxContentManagement" runat="server" HeaderText="Add Header Text">

        <table class="AppFormTable">
            <tr align="center">
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save Header Text" CssClass="InputButton" OnClick="btnSave_Click" /></td>
            </tr>
            <tr>
                <td>
                    <textarea cols="80" id="Content" name="Content" rows="30" runat="server"></textarea>

                    <script type="text/javascript">
                        //<![CDATA[

                        CKEDITOR.replace('rightContainer_cbxContentManagement_Content',
                            {
                                fullPage: true,
                                height: 100
                            });
			//]]>
                    </script>

                </td>
            </tr>
        </table>

    </cbx:ContentBox>
    <script type="text/javascript">
        function OpenLingualEditor() {

            window.open('../CMS/LingualEditor.aspx', 'myPopup', 'height=500,width=600,left=200,top=200,resizable=yes,scrollbars=yes,toolbar=no,status=no');
            return false;
        }
    </script>


</asp:Content>
