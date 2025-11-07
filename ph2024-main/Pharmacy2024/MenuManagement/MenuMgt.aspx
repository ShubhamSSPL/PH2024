<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" EnableEventValidation="False" ValidateRequest="false" CodeBehind="MenuMgt.aspx.cs" Inherits="MenuManagement_MenuMgt_New" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
     <style>
        #rightContainer_ccbAddEdit, #rightContainer_ccbAddEdit, #rightContainer_ccbSpecificUser{
            top:20% !important;            
            height:500px;
            overflow:auto;
            z-index:2000 !important;
        }
        @media only screen and (max-width: 768px){
            #rightContainer_ccbAddEdit, #rightContainer_ccbAddEdit, #rightContainer_ccbSpecificUser{
                height:400px;
                width:90% !important;
            }
        }       
    </style>
    <script type="text/javascript" language="javascript" src="../SynthesysModules_Files/Scripts/FilterTable.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/AjaxLoader.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/jquery.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/jquery-calendar.js"></script>

    <link href="../SynthesysModules_Files/Style/jquery-calendar.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../SynthesysModules_Files/Style/styles.css" />


    <script type="text/javascript" language="javascript" src="../SynthesysModules_Files/PageScripts/NewMenuMgt.js"></script>

    <script type="text/javascript" language="javascript">
        var atk, userType = '', MaximumOrder, AddEditFlag, AddEditIndex, att, atk2;
        var radioCheckbox, MenuIndex, Calender;
        var MenuArray = new Array();
        var UserLoginId ='<%=Session["UserLoginId"] %>'
        Synthesys.FuncLib.AddLoadEvent(addTimePicker);
        function addTimePicker() {
            document.getElementById('calendar_div').style.zIndex = 600;
            $("#<%=txtStartDt.ClientID%>, #<%=txtStartDt.ClientID%>").calendar();
                $("#<%=txtEndDt.ClientID%>, #<%=txtEndDt.ClientID%>").calendar();
                $("#<%=txtContentStartDate.ClientID%>, #<%=txtContentStartDate.ClientID%>").calendar();
                $("#<%=txtContentEndDate.ClientID%>, #<%=txtContentEndDate.ClientID%>").calendar();
                $("#<%=TextEndDt.ClientID%>, #<%=TextEndDt.ClientID%>").calendar();
                $("#<%=TextStartDt.ClientID%>, #<%=TextStartDt.ClientID%>").calendar();
                $("#<%=HyperlinkEndDt.ClientID%>, #<%=HyperlinkEndDt.ClientID%>").calendar();
                $("#<%=HyperlinkStartDt.ClientID%>, #<%=HyperlinkStartDt.ClientID%>").calendar();
                $("#<%=FilelinkEndDt.ClientID%>, #<%=FilelinkEndDt.ClientID%>").calendar();
                $("#<%=FilelinkStartDt.ClientID%>, #<%=FilelinkStartDt.ClientID%>").calendar();
        }
    </script>
    <cc1:ContentBox ID="ccbMenu" runat="server" HeaderText="Menu Management">
        <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 50%">
                    Select UserType:</td>
                <td>
                    <asp:DropDownList ID="ddlUserType" runat="server" onchange="FillGroup(this.value)">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 50%">
                    Select Group:</td>
                <td>
                    <asp:DropDownList ID="ddlGroup" runat="server" onchange="GetMenus(this.value)">
                    </asp:DropDownList></td>
            </tr>
            <tr id="trButtons" style="display: none">
                <td colspan="2">
                    <table class="AppFormTable">
                        <tr align="center">
                            <td>
                                <input id="btnAdd" type="button" value="Add New" class="InputButton" onclick="showAddEdit('Add', 0)" />
                                <asp:Button ID="btnSaveAll" runat="server" Text="Save" CssClass="InputButton" OnClick="btnSaveAll_Click"
                                    OnClientClick="return ValidateAll()" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="AppFormTable" id="MenuGrid">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ccbAddEdit" runat="server" HeaderText="Add/Edit Menu" BoxType="PopupBox"
    Width="75%">
        <table class="AppFormTable" id="tblOptions">
            <tr>
                <td>
                    <asp:RadioButtonList ID="rbOptions" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="true" Text="Link" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Content" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Text" Value="2"></asp:ListItem>
                        <asp:ListItem Text="External Hyperlink" Value="3"></asp:ListItem>
                        <asp:ListItem Text="File" Value="4"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <input id="btnNext" type="button" value="Next>>" onclick="ShowAddEditTables()" class="InputButton" /></td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblLink" style="display: none">
            <tr>
                <td align="right">
                    Select Module:</td>
                <td>
                    <asp:DropDownList ID="ddlModule" runat="server" onchange="getMenusModuleWise(this.value)">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    Select Menu:</td>
                <td>
                    <asp:DropDownList ID="ddlMenu" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">
                    Display Text:</td>
                <td>
                    <input id="txtLinkName" type="text" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    <input id="chkAddEditIsActive" type="checkbox" checked runat="server" />&nbsp;&nbsp;IsActive</td>
                <td>
                    <input id="chkAddEditNewLink" type="checkbox" checked runat="server" />&nbsp;&nbsp;New
                    Link</td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkScheduleLink" runat="server" type="checkbox" onclick="ShowDateRow(this, 'Link')" />&nbsp;&nbsp;<b>Do
                        you want to schedule this link ?</b>
                </td>
            </tr>
            <tr id="trDtLink" style="display: none">
                <td>
                    Start Date & Time:
                    <input id="txtStartDt" type="text" runat="server" size="16" />
                    </td>
                    <td>
                        End Date & Time:
                        <input id="txtEndDt" type="text" runat="server" size="16" />
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkmultiLingualLink" runat="server" type="checkbox" onclick="ShowLanguageRow(this, 'Link')" />&nbsp;&nbsp;<b>Do
                        you want to make this link multilingual ?</b>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" id="btn_OpenLingualEditorLink" value="Open Lingual Editor" onclick="OpenLingualEditor()"
                        class="InputButton" />
                </td>
            </tr>
            <tr id="trMLink" style="display: none">
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Order:<asp:Label ID="lblAddEditOrder" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnLinkSave" runat="server" Text="Save" CssClass="InputButton" OnClientClick="return ValidateLink('Link')"
                        OnClick="btnLink_Save" /></td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblContent" style="display: none">
            <tr id="ContentMenuName">
                <td align="right">
                    Menu Name:
                </td>
                <td>
                    <input id="txtContentMenuName" type="text" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <input id="ContentIsActive" type="checkbox" checked runat="server" />&nbsp;&nbsp;IsActive</td>
                <td>
                    <input id="ContentIsNew" type="checkbox" checked runat="server" />&nbsp;&nbsp;New
                    Link</td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkScheduleContent" runat="server" type="checkbox" onclick="ShowDateRow(this, 'Content')" />&nbsp;&nbsp;<b>Do
                        you want to schedule this link ?</b>
                </td>
            </tr>
            <tr id="trDtContent" style="display: none">
                <td>
                    Start Date & Time:
                    <input id="txtContentStartDate" type="text" runat="server" size="16" />
                     </td>
                    <td>
                        End Date & Time:
                        <input id="txtContentEndDate" type="text" runat="server" size="16" />
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkmultiLingualContent" runat="server" type="checkbox" onclick="ShowLanguageRow(this, 'Content')" />&nbsp;&nbsp;<b>Do
                        you want to make this link multilingual ?</b>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" id="btn_OpenLingualEditorContent" value="Open Lingual Editor" onclick="OpenLingualEditor()"
                        class="InputButton" />
                </td>
            </tr>
            <tr id="trMContent" style="display: none">
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Order:<asp:Label ID="lblContentOrder" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnContentSave" runat="server" Text="Save" CssClass="InputButton"
                        OnClientClick="return ValidateLink('Content')" OnClick="btnContent_Save" />
                    <asp:Button ID="BbtnContentSave2" runat="server" Text="Save & Redirect To Content >>"
                        CssClass="InputButton" OnClientClick="return ValidateLink('Content')" OnClick="btnContent_SavenRedirect" />
                </td>
            </tr>
        </table>
        <table class="AppFormTable" id="tblText" style="display: none">
            <tr>
                <td align="right">
                    Menu Text:
                </td>
                <td>
                    <asp:TextBox ID="txtText" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="chkTextIsActive" type="checkbox" checked runat="server" />&nbsp;&nbsp;IsActive</td>
                <td>
                    <input id="chkTextIsNew" type="checkbox" checked runat="server" />&nbsp;&nbsp;New
                    Link</td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkScheduleText" runat="server" type="checkbox" onclick="ShowDateRow(this, 'Text')" />&nbsp;&nbsp;<b>Do
                        you want to schedule this link ?</b>
                        
                </td>
            </tr>
            <tr id="trDtText" style="display: none">
                <td>
                    Start Date & Time:
                    <input id="TextStartDt" type="text" runat="server" size="16" />
                     </td>
                    <td>
                        End Date & Time:
                        <input id="TextEndDt" type="text" runat="server" size="16" />
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkmultilingualText" runat="server" type="checkbox" onclick="ShowLanguageRow(this, 'Text')" />&nbsp;&nbsp;<b>Do
                        you want to make this link multilingual ?</b>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" id="btn_OpenLingualEditorText" value="Open Lingual Editor" onclick="OpenLingualEditor()"
                        class="InputButton" />
                </td>
            </tr>
            <tr id="trMText" style="display: none">
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Order:<asp:Label ID="lblTextOrder" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Save" CssClass="InputButton" OnClientClick="return ValidateLink('Text')"
                        OnClick="btnText_Save" /></td>
            </tr>
        </table>

        <table class="AppFormTable" id="tblHyperlink" style="display: none">
        <tr>
                <td align="right">
                    HyperLink Name:
                </td>
                <td>
                    <asp:TextBox ID="txtHyperlinkName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    External Hyperlink:
                </td>
                <td>
                    <asp:TextBox ID="txtHyperlink" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="chkHyperlinkIsActive" type="checkbox" checked runat="server" />&nbsp;&nbsp;IsActive</td>
                <td>
                    <input id="chkHyperlinkIsNew" type="checkbox" checked runat="server" />&nbsp;&nbsp;New
                    Link</td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkSchedulehyperlink" runat="server" type="checkbox" onclick="ShowDateRow(this, 'Hyperlink')" />&nbsp;&nbsp;<b>Do
                        you want to schedule this link ?</b>
                        
                </td>
            </tr>
            <tr id="trDtHyperlink" style="display: none">
                <td>
                    Start Date & Time:
                    <input id="HyperlinkStartDt" type="text" runat="server" size="16" />
                     </td>
                    <td>
                        End Date & Time:
                        <input id="HyperlinkEndDt" type="text" runat="server" size="16" />
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkmultilingualHyperlink" runat="server" type="checkbox" onclick="ShowLanguageRow(this, 'Hyperlink')" />&nbsp;&nbsp;<b>Do
                        you want to make this link multilingual ?</b>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" id="btn_OpenLingualEditorHyperlink" value="Open Lingual Editor" onclick="OpenLingualEditor()"
                        class="InputButton" />
                </td>
            </tr>
            <tr id="trMHyperlink" style="display: none">
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Order:<asp:Label ID="lblHyperlinkOrder" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button3" runat="server" Text="Save" CssClass="InputButton" OnClientClick="return ValidateLink('Hyperlink')"
                        OnClick="btnHyperlink_Save" /></td>
            </tr>
        </table>
		<table class="AppFormTable" id="tblFile" style="display: none">
        <tr>
                <td align="right">
                    File Link Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFilelinkName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Select File:
                </td>
                <td>
                     <asp:DropDownList ID="ddlFileList" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="chkFilelinkIsActive" type="checkbox" checked runat="server" />&nbsp;&nbsp;IsActive</td>
                <td>
                    <input id="chkFilelinkIsNew" type="checkbox" checked runat="server" />&nbsp;&nbsp;New
                    Link</td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkSchedulefilelink" runat="server" type="checkbox" onclick="ShowDateRow(this, 'Filelink')" />&nbsp;&nbsp;<b>Do
                        you want to schedule this link ?</b>
                        
                </td>
            </tr>
            <tr id="trDtFilelink" style="display: none">
                <td>
                    Start Date & Time:
                    <input id="FilelinkStartDt" type="text" runat="server" size="16" />
                     </td>
                    <td>
                        End Date & Time:
                        <input id="FilelinkEndDt" type="text" runat="server" size="16" />
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkmultilingualFilelink" runat="server" type="checkbox" onclick="ShowLanguageRow(this, 'Filelink')" />&nbsp;&nbsp;<b>Do
                        you want to make this link multilingual ?</b>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" id="btn_OpenLingualEditorFilelink" value="Open Lingual Editor" onclick="OpenLingualEditor()"
                        class="InputButton" />
                </td>
            </tr>
            <tr id="trMFilelink" style="display: none">
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Order:<asp:Label ID="lblFilelinkOrder" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button4" runat="server" Text="Save" CssClass="InputButton" OnClientClick="return ValidateLink('Filelink')"
                        OnClick="btnFilelink_Save" /></td>
            </tr>
        </table>
        <table id="tblLanguage" style="display: none">
            <tr>
                <td>
                    <asp:GridView ID="gvLanguage" runat="server" AutoGenerateColumns="false" CssClass="AppFormTable"
                        OnRowDataBound="gvLanguage_RowDataBound" HorizontalAlign="Center" RowStyle-VerticalAlign="Middle">
                        <SelectedRowStyle CssClass="SelectedRow" />
                        <EditRowStyle CssClass="EditRow" />
                        <AlternatingRowStyle CssClass="AlternateRow" />
                        <FooterStyle CssClass="Footer" />
                        <HeaderStyle CssClass="Header" />
                        <RowStyle CssClass="NormalRow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Right" Width="7%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSrNo" runat="server" Text="<%# (Container.DataItemIndex+1) %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="LanguageId" HeaderText="LanguageId" ItemStyle-HorizontalAlign="Right"
                                HtmlEncode="false" />
                            <asp:BoundField DataField="LanguageName" HeaderText="Language" ItemStyle-HorizontalAlign="Left"
                                HtmlEncode="false" />
                            <asp:BoundField HeaderText="Select" ItemStyle-HorizontalAlign="Center" HtmlEncode="false"
                                ItemStyle-Width="9%" />
                            <asp:BoundField HeaderText="Text" ItemStyle-HorizontalAlign="Center" HtmlEncode="false"
                                ItemStyle-Width="9%" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ccbUser" runat="server" HeaderText="Select Users" BoxType="PopupBox"
        Width="75%">
        <table class="AppFormTable" id="tblSearchCriteria">
            <tr>
                <td align="right">
                    <b>Search Criteria</b>:
                </td>
                <td>
                    By User Name:
                    <asp:CheckBox ID="chkByName" runat="server" onClick="RadioEffect(this)" />&nbsp;&nbsp;
                    By Login Id:
                    <asp:CheckBox ID="chkByLogin" runat="server" onClick="RadioEffect(this)" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:TextBox ID="txtSearchbox" runat="server"></asp:TextBox></td>
                <td>
                    <input id="btnSeacrh" type="button" value="Search Users" class="InputButton" onclick="SearchUsers()" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="AppFormTable" id="UserGrid">
                        <tr id="trUser" style="display: none" align="center">
                            <td>
                                <input type="button" value="Save" class="InputButton" onclick="Validate_UserCheckBox()" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ccbSpecificUser" runat="server" HeaderText="Selected Users" BoxType="PopupBox"
    Width="75%">
        <table style="width: 100%">
            <tr>
                <td>
                    <table class="AppFormTable" id="tblMenuWiseUser">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbLingualEditor" runat="server" HeaderText="Langauge Editor "
        BoxType="PopupBox" Width="60%" Height="500px" HorizontalAlign="Center">
        <iframe id="iFrameLingualEditor" frameborder="0" src="../SynthesysModules_Files/Resources/Wait.html"
            style="width: 98%; height: 98%"></iframe>
    </cc1:ContentBox>
    <asp:HiddenField ID="hddText" runat="server" />
    <asp:HiddenField ID="hddUserType" runat="server" />
    <asp:HiddenField ID="hddGroup" runat="server" />
    <asp:HiddenField ID="hddMultilingual" runat="server" />
    <asp:HiddenField ID="hddAddEditIndex" runat="server" />

    <script type="text/javascript">

        function OpenLingualEditor() {
   // document.getElementById('<%=cbLingualEditor.ClientID%>').Show('#000000',true);
            // document.getElementById('iFrameLingualEditor').src='../CMS/LingualEditor.aspx'; 
            window.open('../CMS/LingualEditor.aspx', 'myPopup', 'height=500,width=600,left=200,top=200,resizable=yes,scrollbars=yes,toolbar=no,status=no');
            return false;
        }
        function RetainValues() {
            if (document.getElementById('<%=hddUserType.ClientID %>').value != '') {
                FillGroup();
            }
        }
        Synthesys.FuncLib.AddLoadEvent(RetainValues);

        var qs = (function (a) {
            if (a == "") return {};
            var b = {};
            for (var i = 0; i < a.length; ++i) {
                var p = a[i].split('=');
                if (p.length != 2) continue;
                b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " "));
            }
            return b;
        })(window.location.search.substr(1).split('&'));

        if (qs["UserTypeId"] != null) {
            userType = qs["UserTypeId"];
            document.getElementById('rightContainer_hddGroup').value = qs["GroupID"];
            //FillGroup(qs["UserTypeId"]);
            GetMenus(qs["GroupID"]);
            document.getElementById("rightContainer_ccbMenu_ddlGroup").value = qs["GroupID"];
            document.getElementById('rightContainer_ccbMenu_ddlUserType').value = qs["UserTypeId"];
        }
        $(function () {
            if (typeof AjaxPro != 'undefined' && AjaxPro && AjaxPro.Request && AjaxPro.Request.prototype) {
                AjaxPro.Request.prototype.doStateChange = function () {
                    this.onStateChanged(this.xmlHttp.readyState, this);
                    if (this.xmlHttp.readyState != 4 || !this.isRunning) {
                        return;
                    }
                    this.duration = new Date().getTime() - this.__start;
                    if (this.timeoutTimer != null) {
                        clearTimeout(this.timeoutTimer);
                    }
                    var res = this.getEmptyRes();
                    if (this.xmlHttp.status == 200 && (this.xmlHttp.statusText == "OK" || !this.xmlHttp.statusText)) {
                        res = this.createResponse(res);
                    } else {
                        res = this.createResponse(res, true);
                        res.error = { Message: this.xmlHttp.statusText, Type: "ConnectFailure", Status: this.xmlHttp.status };
                    }
                    this.endRequest(res);
                };
            }
        });
    </script>

</asp:Content>
