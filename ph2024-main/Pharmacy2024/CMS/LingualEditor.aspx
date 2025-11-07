<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LingualEditor.aspx.cs" Inherits="CMS_LingualEditor" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript" src="http://www.google.com/jsapi?key=ABQIAAAA1XbMiDxx_BTCY2_FkPh06RRaGTYH6UMl8mADNa0YKuWNNa8VNxQEerTAUcfkyrr6OwBovxn7TDAH5Q"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/LanguageTranslation.js"></script>

    <script language="javascript" src="../SynthesysModules_Files/Scripts/FuncLib.js" type="text/javascript"></script>

    <script language="javascript" src="../SynthesysModules_Files/Scripts/ContentBox.js" type="text/javascript"></script>

    <script type="text/javascript">

        var XMLFILE = "../SynthesysModules_Files/LanguageTranslation.config.xml"; //xml path for parsing.
        var TXTCONTROL = "CBLangTraslation_txtName";//TextBox Control for the language translation
        var DROPDOWN = "languageDropDown";//ID of language DropDown
        var HIDDENCONTROL = "CBLangTraslation_hdnKBLang";//giddenField for Keyboard Language
        var POPUPBOX = "CBKeyBoard";//ID of Content box where iframe is used
        var LABELCONTROL = "CBLangTraslation_lblLangText";// used to change the text infront of text box



        function showKeyBoard() {


            var destnpage = "VirtualKeyBoard.aspx?txt=" + TXTCONTROL + "&hdn=" + HIDDENCONTROL + "&cb=" + POPUPBOX;
            //iframe ID
            document.getElementById("kbFrame").src = destnpage;

            //Content Box Having The IFrame.
            document.getElementById("CBKeyBoard").Show('black', true);


        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; vertical-align: middle">
            <ccm:ContentBox ID="CBLangTraslation" runat="server" HeaderText="Lingual Editor"
                HeaderVisible="True" Width="500px" HorizontalAlign="Center">
                <table class="Appformtable">
                    <tr id="trddl">
                        <td style="width: 100px" align="right">Select Language</td>
                        <td colspan="2" align="left">
                            <select id="languageDropDown" class="ddlInput" onchange="languageChangeHandler()">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" align="right">
                            <asp:Label ID="lblLangText" runat="server" Text="Type in Native Language"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="textInput" TextMode="MultiLine" Height="100px" Width="250px"></asp:TextBox>

                        </td>
                        <td>
                            <img alt="KeyBoard" src="../SynthesysModules_Files/Images/KeyBoardLanguage.JPG" onclick="showKeyBoard()"
                                class="InputButton" width="60" height="40" /></td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnKBLang" runat="server" Value="bn_phone" />
            </ccm:ContentBox>
            <ccm:ContentBox ID="CBKeyBoard" runat="server" HeaderText="KeyBoard" HeaderVisible="True"
                BoxType="PopupBox" Width="450px" HorizontalAlign="Center">
                <iframe id="kbFrame" width="400" height="300" style="text-align: center"></iframe>
            </ccm:ContentBox>
        </div>
    </form>
</body>
</html>
