<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="AddTopMenu.aspx.cs" Inherits="MenuManagement_AddTopMenu" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_ccbAddEdit, #rightContainer_ccbAddEdit{
            top:20% !important;
            height:500px;
            overflow:auto;
            z-index:2000 !important;
         
        }
        @media only screen and (max-width: 768px){
            #rightContainer_ccbAddEdit, #rightContainer_ccbAddEdit{
                height:400px;
                width:90% !important;
            }
        }
    </style>
    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/AjaxLoader.js"></script>

    <script type="text/javascript" language="javascript" src="../SynthesysModules_Files/PageScripts/AddTopMenu.js"></script>

    <cc1:ContentBox ID="ccbMenu" runat="server" HeaderText="Menu Management">
        <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 50%">
                        Select UserType:</td>
                    <td>
                        <asp:DropDownList ID="ddlUserType" runat="server" onchange="GetMenus(this.value)">
                        </asp:DropDownList></td>
            </tr>
            <tr align="center" id="trButtons" style="display:none">
                <td colspan="2">
                    <input id="btnAdd" type="button" value="Add New" class="InputButton" onclick="showAddEdit(0)" />
                    <asp:Button ID="btnSaveAll" runat="server" Text="Save" CssClass="InputButton" OnClientClick="return ValidateAll()"
                        OnClick="btnSaveAll_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" id="MenuGrid">
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ccbAddEdit" runat="server" HeaderText="Add/Edit Menu" BoxType="PopupBox"
    Width="75%">
        <table class="AppFormTable" id="tblLink">
            <tr>
                <td colspan="2">
                    Menu Name:<input id="txtMenuName" type="text" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    <input id="chkAddEditIsActive" type="checkbox" checked runat="server" />&nbsp;&nbsp;IsActive</td>
                <td>
                    Order:<asp:Label ID="lblAddEditOrder" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input id="chkmultiLingualLink" type="checkbox" checked runat="server" onclick="ShowLanguageRow(this, '')" />Do
                    you want to make this menu multilingual ?
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" id="btn_OpenLingualEditorContent" value="Open Lingual Editor" onclick="OpenLingualEditor()"
                        class="InputButton" />
                    
                    </td>
            </tr>
            <tr id="trLanguage" style="display: none">
                <td colspan="2">
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
                                <ItemStyle HorizontalAlign="right" Width="7%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSrNo" runat="server" Text="<%# (Container.DataItemIndex+1) %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="LanguageId" HeaderText="LanguageId" ItemStyle-HorizontalAlign="right"
                                HtmlEncode="false" />
                            <asp:BoundField DataField="LanguageName" HeaderText="Language" ItemStyle-HorizontalAlign="left"
                                HtmlEncode="false" />
                            <asp:BoundField HeaderText="Select" ItemStyle-HorizontalAlign="Center" HtmlEncode="false"
                                ItemStyle-Width="9%" />
                            <asp:BoundField HeaderText="Text" ItemStyle-HorizontalAlign="Center" HtmlEncode="false"
                                ItemStyle-Width="9%" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 25%">
                    Select Groups:</td>
                <td id="GroupGrid">
                    </td>
            </tr>
            <tr id="trAddEdit">
                <td colspan="2" align="center">
                    <asp:Button ID="btnLinkSave" runat="server" Text="Save" CssClass="InputButton" OnClientClick="return ValidateAddEdit()"
                        OnClick="btnAddEdit_Save" /></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbLingualEditor" runat="server" HeaderText="Langauge Editor "
        BoxType="PopupBox" Width="75%" Height="500px" HorizontalAlign="Center">
        <iframe id="iFrameLingualEditor" frameborder="0" src="../SynthesysModules_Files/Resources/Wait.html"
            style="width: 98%; height: 98%"></iframe>
    </cc1:ContentBox>
    <asp:HiddenField ID="hddText" runat="server" />
    <asp:HiddenField ID="hddMultilingual" runat="server" />
    <asp:HiddenField ID="hddAddEditIndex" runat="server" />
    <asp:HiddenField ID="hddUserType" runat="server" />
    <script type="text/javascript">
        var atk;
        var UserTId = '';
        function GetMenus(UserTypeId) {
            UserTId = UserTypeId;
            document.getElementById('<%=hddUserType.ClientID %>').value = UserTId;
            atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_ccbMenu', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
            atk.Start('MenuManagement_AddTopMenu.GetMenus', UserTypeId, GetMenus_Callback);
        }
        function GetMenus_Callback(response) {
            //alert(response.value);
            atk.Stop();
            var MenuGrid = document.getElementById("MenuGrid");
            var htmlContent;
            var ds = response.value;
            if (ds.Tables[0].Rows.length > 0) {
                document.getElementById('trButtons').style.display = '';
                htmlContent = "<table id=\"gvMenu\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                for (var i = 0; i < response.value.Tables[0].Rows.length; i++) {

                    if (i == 0)
                        htmlContent += "<tr class=\"Header\" ><th scope=\"col\">Sr.No</th><th scope=\"col\" >MenuName</th><th scope=\"col\">MenuOrder</th><th>IsActive</th><th>Edit</th><th>Delete</th></tr>";
                    htmlContent += "<tr class=\"NormalRow\" valign=\"center\">";
                    htmlContent += "<td align=\"center\" >" + parseInt(i + 1) + "</td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px\" >" + ds.Tables[0].Rows[i].MenuName + "</td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;\"><input id=chk" + parseInt(i + 1) + " type=\"checkbox\" onclick=\"Ordering(this," + parseInt(i + 1) + ")\" checked/>&nbsp;&nbsp;<span id=\"lbl" + parseInt(i + 1) + "\" ><b>" + ds.Tables[0].Rows[i].MenuOrder + "</b></span></td>";
                    var IsActive = ds.Tables[0].Rows[i].IsActive == 1 ? "checked" : "";
                    htmlContent += "<td align=\"center\" ><input id=chkIsActive" + parseInt(i + 1) + " type=\"checkbox\" " + IsActive + "/></td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"showAddEdit(" + parseInt(i + 1) + ")\"/></a></td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/delete.gif\" onclick=\"Delete(" + parseInt(i + 1) + ")\"/></a></td>";
                    htmlContent += "<td align=\"center\" style=\"display:none\">" + ds.Tables[0].Rows[i].MenuId + "</td>";
                    htmlContent += "<td align=\"center\" style=\"display:none\">" + ds.Tables[0].Rows[i].GroupIds + "</td>";
                    //                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].MenuId+"</td>";
                    //                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].IsNew+"</td>";
                    //                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].DetailId+"</td>";
                    //                      htmlContent+="<td align=\"center\" style=\"display:none\">"+ds.Tables[0].Rows[i].TypeOfMenu+"</td>";
                    //                      htmlContent+="<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"showSelectedUsers("+parseInt(i+1)+")\"/></a></td>";

                    htmlContent += "</tr>";
                    //MenuArray[i+1]=ds.Tables[0].Rows[i].DetailId+'#'+ds.Tables[0].Rows[i].IsActive;
                }

            }
            else {
                document.getElementById('trButtons').style.display = '';
                htmlContent = "<table id=\"TblBranch\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                htmlContent += "<tr><td><font color=\"red\">No Menus Found !!!</font></td></tr>";
            }
            MenuGrid.innerHTML = htmlContent;
            var GroupGrid = document.getElementById("GroupGrid");
            if (ds.Tables[1].Rows.length > 0) {
                htmlContent = "<table id=\"lstGroup\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                for (var i = 0; i < response.value.Tables[1].Rows.length; i++) {

                    if (i == 0)
                        htmlContent += "<tr class=\"Header\" ><th scope=\"col\">Sr.No</th><th scope=\"col\" >Group Name</th><th>Select</th></tr>";
                    htmlContent += "<tr class=\"NormalRow\" valign=\"center\">";
                    htmlContent += "<td align=\"center\" >" + parseInt(i + 1) + "</td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px\" >" + ds.Tables[1].Rows[i].GroupName + "</td>";
                    htmlContent += "<td align=\"center\" style=\"display:none\">" + ds.Tables[1].Rows[i].GroupId + "</td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;\"><input id=grOrder" + parseInt(i + 1) + " type=\"checkbox\" onclick=\"GroupOrdering(this," + parseInt(i + 1) + ")\" />&nbsp;&nbsp;<span style=\"display:none\" id=\"lbl2" + parseInt(i + 1) + "\" ></span></td>";
                    htmlContent += "</tr>";

                }
            }
            else {

                htmlContent = "<table id=\"TblBranch\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                htmlContent += "<tr><td><font color=\"red\">No Groups Found !!!</font></td></tr>";
            }
            GroupGrid.innerHTML = htmlContent;

        }
        function OpenLingualEditor() {
        //document.getElementById('<%=cbLingualEditor.ClientID%>').Show('#000000',true);
            //document.getElementById('iFrameLingualEditor').src='../CMS/LingualEditor.aspx'; 
            window.open('../CMS/LingualEditor.aspx', 'myPopup', 'height=500,width=600,left=200,top=200,resizable=yes,scrollbars=yes,toolbar=no,status=no');
            return false;
        }
        function RetainValues() {
            if (document.getElementById('<%=hddUserType.ClientID %>').value != '') {
            GetMenus(document.getElementById('<%=hddUserType.ClientID %>').value);
            }
        }
        Synthesys.FuncLib.AddLoadEvent(RetainValues);
    </script>
     <script type="text/javascript">
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
