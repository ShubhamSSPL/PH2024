<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" EnableEventValidation="False" ValidateRequest="false" CodeBehind="AddMenu.aspx.cs" Inherits="MenuManagement_AddMenu" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_CbAddNewMenu, #rightContainer_CBEditMenu, #rightContainer_CBDeleteMenu{
            top:20% !important;
            height:500px;
            overflow:auto;
            z-index:2000 !important;
        }
        @media only screen and (max-width: 768px){
            #rightContainer_CbAddNewMenu, #rightContainer_CBEditMenu, #rightContainer_CBDeleteMenu{
                height:400px;
                width:90% !important;
            }
        }
    </style>
    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/AjaxLoader.js"></script>

    <script type="text/javascript" language="javascript">
        var atk;
        var atk1;
        function GetListUrl() {
            
            //document.getElementById('tblMenuDetails').style.display='none';
            document.getElementById("<%=LblNoModuleMsg.ClientID %>").style.display = 'none';
            document.getElementById("<%=Btn_AddNewMenu.ClientID %>").style.display = 'none';
            document.getElementById("<%=Btn_SaveMenus.ClientID %>").style.display = 'none';
            var sel_Index = document.getElementById("<%=DdlModule.ClientID %>").selectedIndex;
            var selected_text = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].text;
            var selected_value = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].value;

            if (selected_text != '-- Select --') {
                atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddMenu_DdlModule', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
                atk.Start('MenuManagement_AddMenu.GetUrlModuleWise', selected_text, selected_value, GetUrlModuleWise_Callback);
            }
        }
        function GetUrlModuleWise_Callback(response) {
            atk.Stop();
            var ds = response.value;

            var ddl = document.getElementById("<%=DdlUrl.ClientID %>");
             while (ddl.hasChildNodes())
                 ddl.removeChild(ddl.childNodes[0]);

             if (ds.Tables[0].Rows.length > 0) {
                 for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
                     var opt = document.createElement("option");
                     document.getElementById("<%=DdlUrl.ClientID %>").options.add(opt);
                        opt.text = ds.Tables[0].Rows[i].Text;
                        opt.value = ds.Tables[0].Rows[i].Value;
                    }
                    //document.getElementById('tblMenuDetails').style.display=''
                }
                else {
                    document.getElementById("<%=LblNoModuleMsg.ClientID %>").style.display = '';
             }

             var tbl = document.getElementById('MenuGrid');
             if (ds.Tables[1].Rows.length > 0) {
                 htmlContent = "<table id=\"TblMenuList\"  class=\"AppFormTable\" Synthesysfilter=\"text-columns:1\" cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                 for (var i = 0; i < response.value.Tables[1].Rows.length; i++) {
                     if (i == 0)
                         htmlContent += "<tr class=\"Header\" ><th scope=\"col\" >Sr.No</th><th scope=\"col\" >Menu Name</th><th>IsActive</th><th>Edit</th><th>Delete</th></tr>";
                     htmlContent += "<tr class=\"NormalRow\" valign=\"center\">";
                     htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:50px\" >" + parseInt(i + 1) + "</td>";
                     htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px;display:none\" >" + ds.Tables[1].Rows[i].MenuId + "</td>";
                     htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:200px\" >" + ds.Tables[1].Rows[i].MenuName + "</td>";

                     var IsActive = ds.Tables[1].Rows[i].IsActive == 1 ? "checked" : "";
                     htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:50px\"><input id=chkIsActive" + parseInt(i + 1) + " type=\"checkbox\"" + IsActive + "/></td>";
                     htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:50px\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"ShowEditMenu(" + ds.Tables[1].Rows[i].MenuId + ")\" /></a></td>";
                     htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:50px\"><a ><img src=\"../SynthesysModules_Files/Images/delete.gif\" onclick=\"ShowDeleteMenu(" + ds.Tables[1].Rows[i].MenuId + ")\"/></a></td>";

                     htmlContent += "</tr>";
                 }
                 document.getElementById("<%=Btn_AddNewMenu.ClientID %>").style.display = '';
                    document.getElementById("<%=Btn_SaveMenus.ClientID %>").style.display = '';
                }
                else {

                    htmlContent = "<table id=\"TblMenuList\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                    htmlContent += "<tr><td><font color=\"red\">No Menus Found !!!</font></td></tr>";
                    document.getElementById("<%=Btn_AddNewMenu.ClientID %>").style.display = '';
                    document.getElementById("<%=Btn_SaveMenus.ClientID %>").style.display = 'none';
            }
            tbl.rows[0].cells[0].innerHTML = htmlContent;


        }
        function GetExistingMenuList() {
            document.getElementById("<%=Btn_AddNewMenu.ClientID %>").style.display = 'none';
             document.getElementById("<%=Btn_SaveMenus.ClientID %>").style.display = 'none';
             var sel_Index = document.getElementById("<%=DdlModule.ClientID %>").selectedIndex;
             var selected_value = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].value;
            if (selected_value != '-- Select --') {
                atk1 = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddMenu_DdlModule', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
                atk1.Start('MenuManagement_AddMenu.GetExistingMenuList', selected_value, GetExistingMenuList_Callback);
            }

        }
        function GetExistingMenuList_Callback(response) {
            atk1.Stop();
            var ds = response.value;
            var tbl = document.getElementById('MenuGrid');
            if (ds.Tables[0].Rows.length > 0) {
                htmlContent = "<table id=\"TblMenuList\"  class=\"AppFormTable\" Synthesysfilter=\"text-columns:1\" cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                for (var i = 0; i < response.value.Tables[0].Rows.length; i++) {
                    if (i == 0)
                        htmlContent += "<tr class=\"Header\" ><th scope=\"col\" >Sr.No</th><th scope=\"col\" >Menu Name</th><th>IsActive</th><th>Edit</th><th>Delete</th></tr>";
                    htmlContent += "<tr class=\"NormalRow\" valign=\"center\">";
                    htmlContent += "<td align=\"center\"style=\"background-color:transparent;width:50px\" >" + parseInt(i + 1) + "</td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px;display:none\" >" + ds.Tables[0].Rows[i].MenuId + "</td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:200px\" >" + ds.Tables[0].Rows[i].MenuName + "</td>";

                    var IsActive = ds.Tables[0].Rows[i].IsActive == 1 ? "checked" : "";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:50px\"><input id=chkIsActive" + parseInt(i + 1) + " type=\"checkbox\"" + IsActive + "/></td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:50px\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"ShowEditMenu(" + ds.Tables[0].Rows[i].MenuId + ")\" /></a></td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:50px\"><a ><img src=\"../SynthesysModules_Files/Images/delete.gif\" onclick=\"ShowDeleteMenu(" + ds.Tables[0].Rows[i].MenuId + ")\"/></a></td>";

                    htmlContent += "</tr>";
                }
                document.getElementById("<%=Btn_AddNewMenu.ClientID %>").style.display = '';
                    document.getElementById("<%=Btn_SaveMenus.ClientID %>").style.display = '';
                }
                else {

                    htmlContent = "<table id=\"TblMenuList\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                    htmlContent += "<tr><td><font color=\"red\">No Menus Found !!!</font></td></tr>";
                    document.getElementById("<%=Btn_AddNewMenu.ClientID %>").style.display = '';
                    document.getElementById("<%=Btn_SaveMenus.ClientID %>").style.display = 'none';
            }
            tbl.rows[0].cells[0].innerHTML = htmlContent;
        }
        function AddMenu() {
            var isValid = true;

            //validate Authentication Mode
            var DdlAuthenticationMode = document.getElementById("<%=DdlAuthenticationMode.ClientID %>");
             var SelectedMode = DdlAuthenticationMode.options[DdlAuthenticationMode.selectedIndex].value;

             if (SelectedMode == '--Select--') {
                 alert('Please select an authentication mode');
                 isValid = false;
             }
             //validate Menu Name
             if (document.getElementById("<%=TxtMenuName.ClientID %>").value == '') {
                 alert('Please enter a menu name');
                 isValid = false;
             }

             //validate Active or InActive
             if (document.getElementById('rightContainer_CbAddNewMenu_rbtIsActive_0').checked == false
                 && document.getElementById('rightContainer_CbAddNewMenu_rbtIsActive_1').checked == false) {
                 alert('Please select if the menu is active or not');
                 isValid = false;
             }

             //validate URL

             if (document.getElementById("rbtInternal").checked == true) {
                 var Ddl = document.getElementById("<%=DdlUrl.ClientID %>");
                var SelectedUrl = Ddl.options[Ddl.selectedIndex].value;

                if (SelectedUrl != '--Select--') {
                    document.getElementById("<%=HdnSelectedUrl.ClientID %>").value = SelectedUrl;
                }
                else {
                    alert('Please select a Url');
                    isValid = false;
                }
            }
            else if (document.getElementById("rbtExternal").checked == true) {
                var Url = document.getElementById("txtExternalLink").value;
                Url = Url.trim();
                if (Url == "") {
                    alert('Please enter a proper external link');
                    isValid = false;
                } else {
                    document.getElementById("<%=HdnSelectedUrl.ClientID %>").value = Url;
                 }
             }


             if (isValid) {

                 var sel_Index = document.getElementById("<%=DdlModule.ClientID %>").selectedIndex;
                var selected_Mod_Value = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].value;
                var selected_Mod_text = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].text;
                var MenuName = document.getElementById("<%=TxtMenuName.ClientID %>").value;
                var Url = document.getElementById("<%=HdnSelectedUrl.ClientID %>").value;
                var IsActive = document.getElementById('rightContainer_CbAddNewMenu_rbtIsActive_0').checked == true ? "1" : "0";
                var UserId = document.getElementById("<%=HdnUserLogin.ClientID %>").value;
                var QueryString = document.getElementById("<%=TxtQueryString.ClientID %>").value;


                atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddMenu_DdlModule', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
                atk.Start('MenuManagement_AddMenu.AddNewMenu', selected_Mod_Value, MenuName, Url, IsActive, SelectedMode, UserId, QueryString, selected_Mod_text, AddNewMenu_Callback);

            }
            else {
                return isValid;
            }

        }
        function AddNewMenu_Callback(response) {
            atk.Stop();
            GetUrlModuleWise_Callback(response);
            HidePopUp(document.getElementById("<%=CbAddNewMenu.ClientID %>"));
        }


        function RefreshPage() {
            if (document.getElementById("<%=HdnRefreshPage.ClientID %>").value == "Y") {
                 GetExistingMenuList();
                 document.getElementById("<%=HdnRefreshPage.ClientID %>").value = "";
            }
        }
        function ShowEditMenu(Value) {
            document.getElementById("<%=HdnMenuId.ClientID %>").value = Value;

             var sel_Index = document.getElementById("<%=DdlModule.ClientID %>").selectedIndex;
             var selected_text = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].text;

            atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddMenu_DdlModule', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
            atk.Start('MenuManagement_AddMenu.GetSpecificMenuDetails', parseInt(Value), selected_text, GetSpecificMenuDetails_Callback);

        }
        function GetSpecificMenuDetails_Callback(response) {
            atk.Stop();
            var ds = response.value;
            var ddl = document.getElementById("<%=DdlEditUrl.ClientID %>");
             while (ddl.hasChildNodes())
                 ddl.removeChild(ddl.childNodes[0]);
             if (ds.Tables[0].Rows.length > 0) {
                 for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
                     var opt = document.createElement("option");
                     document.getElementById("<%=DdlEditUrl.ClientID %>").options.add(opt);
                     opt.text = ds.Tables[0].Rows[i].Text;
                     opt.value = ds.Tables[0].Rows[i].Value;
                 }
             }


             if (ds.Tables[1].Rows.length > 0) {
                 document.getElementById("<%=TxtEditMenuName.ClientID %>").value = ds.Tables[1].Rows[0].MenuName;
                document.getElementById("<%=DdlEditUrl.ClientID %>").value = ds.Tables[1].Rows[0].MenuUrl;
                document.getElementById("<%=TxtEditQueryString.ClientID %>").value = ds.Tables[1].Rows[0].QueryString;
                document.getElementById("<%=DdlEditAuthenticationMode.ClientID %>").value = ds.Tables[1].Rows[0].AuthenticationMode;

                if (ds.Tables[1].Rows[0].IsActive == true) {
                    document.getElementById("rightContainer_CBEditMenu_rbtEditIsActive_0").checked = true;
                }
                else {
                    document.getElementById("rightContainer_CBEditMenu_rbtEditIsActive_1").checked = true;
                }

                //changes done here for external link  
                var ddl = document.getElementById("<%=DdlEditUrl.ClientID %>");
                var rbt = document.getElementsByName("rbtEditLink");
                var txt = document.getElementById("txtEditExternalLink");

                txt.value = "";
                ddl.style.display = "";
                txt.style.display = "none";
                rbt[0].checked = true;

                if (ddl.value == "" || ddl.value == "--Select--") {
                    ddl.value = "--Select--";
                    ddl.style.display = "none";
                    txt.style.display = "";
                    txt.value = ds.Tables[1].Rows[0].MenuUrl;
                    rbt[1].checked = true;
                }
                var popup = document.getElementById("<%=CBEditMenu.ClientID %>");
                popup.Show('#000000', true);
            }
        }
        function SaveEditedUrl() {
            var isValid = true;

            //validate Edited Menu Name
            if (document.getElementById("<%=TxtEditMenuName.ClientID %>").value == '') {
                 alert('Please enter a menu name');
                 isValid = false;
             }

             //validate Acitve or InActive
             if (document.getElementById('rightContainer_CBEditMenu_rbtEditIsActive_0').checked == false
                 && document.getElementById('rightContainer_CBEditMenu_rbtEditIsActive_1').checked == false) {
                 alert('Please select if the menu is active or not');
                 isValid = false;
             }

             //validate Edited URL
             var Ddl = document.getElementById("<%=DdlEditUrl.ClientID %>");
             var SelectedUrl = Ddl.options[Ddl.selectedIndex].value;

             if (document.getElementById("rbtEditInternal").checked == true) {
                 if (SelectedUrl != '--Select--') {
                     document.getElementById("<%=HdnEditedUrl.ClientID %>").value = SelectedUrl;

                }
                else {
                    alert('Please select a Url');
                    isValid = false;
                }
            } else if (document.getElementById("rbtEditExternal").checked == true) {
                var Url = document.getElementById("txtEditExternalLink").value;
                Url = Url.trim();
                if (Url == "") {
                    alert('Please enter a proper external link');
                    isValid = false;
                } else {
                    document.getElementById("<%=HdnEditedUrl.ClientID %>").value = Url;
                 }

             }

             //Validate Authentication Mode
             var DdlAuthenticationMode = document.getElementById("<%=DdlEditAuthenticationMode.ClientID %>");
             var SelectedMode = DdlAuthenticationMode.options[DdlAuthenticationMode.selectedIndex].value;

             if (SelectedMode == '--Select--') {
                 alert('Please select an authentication mode');
                 isValid = false;
             }
             //if the data is valid save it
             if (isValid) {

                 var sel_Index = document.getElementById("<%=DdlModule.ClientID %>").selectedIndex;
                var selected_Mod_Value = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].value;
                var selected_Mod_text = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].text;
                var MenuId = document.getElementById("<%=HdnMenuId.ClientID %>").value;
                var MenuName = document.getElementById("<%=TxtEditMenuName.ClientID %>").value;
                var Url = document.getElementById("<%=HdnEditedUrl.ClientID %>").value;
                var IsActive = document.getElementById('rightContainer_CBEditMenu_rbtEditIsActive_0').checked == true ? "1" : "0";
                var UserId = document.getElementById("<%=HdnUserLogin.ClientID %>").value;
                var QueryString = document.getElementById("<%=TxtEditQueryString.ClientID %>").value;


                atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddMenu_DdlModule', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
                atk.Start('MenuManagement_AddMenu.UpdateMenu', selected_Mod_Value, MenuId, MenuName, Url, IsActive, SelectedMode, UserId, QueryString, selected_Mod_text, UpdateMenu_Callback);

            }
            else {
                return isValid;
            }

        }
        function UpdateMenu_Callback(response) {
            atk.Stop();
            GetUrlModuleWise_Callback(response);
            HidePopUp(document.getElementById("<%=CBEditMenu.ClientID %>"));
        }

        function ShowAddMenuPopup() {
            GetListUrl();
            document.getElementById("<%=TxtMenuName.ClientID %>").value = '';
             document.getElementById("<%=DdlAuthenticationMode.ClientID %>").selectedIndex = 0;
             document.getElementById('rightContainer_CBEditMenu_rbtEditIsActive_0').checked = true;
             document.getElementById("<%=TxtQueryString.ClientID %>").value = '';
             var popup = document.getElementById("<%=CbAddNewMenu.ClientID %>");
            popup.Show('#000000', true);
            return false;
        }
        function ShowDeleteMenu(Value) {
            document.getElementById("<%=HdnMenuId.ClientID %>").value = Value;
             var sel_Index = document.getElementById("<%=DdlModule.ClientID %>").selectedIndex;
             var selected_text = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].text;

            atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddMenu_DdlModule', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
            atk.Start('MenuManagement_AddMenu.GetSpecificMenuDetails', parseInt(Value), selected_text, DeleteMenuDetails_Callback);

        }
        function DeleteMenuDetails_Callback(response) {
            atk.Stop();
            var ds = response.value;
            if (ds.Tables[1].Rows.length > 0) {
                document.getElementById("<%=LblDeleteMenuName.ClientID %>").innerHTML = ds.Tables[1].Rows[0].MenuName;
                var popup = document.getElementById("<%=CBDeleteMenu.ClientID %>");
                popup.Show('#000000', true);
            }
        }
        function DeleteMenu() {
            var sel_Index = document.getElementById("<%=DdlModule.ClientID %>").selectedIndex;
             var selected_value = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].value;
             var selected_text = document.getElementById("<%=DdlModule.ClientID %>").options[sel_Index].text;
             var MenuId = document.getElementById("<%=HdnMenuId.ClientID %>").value;

            atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddMenu_DdlModule', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
            atk.Start('MenuManagement_AddMenu.DeleteMenu', selected_value, selected_text, MenuId, DeleteMenu_Callback);

        }
        function DeleteMenu_Callback(response) {
            GetUrlModuleWise_Callback(response);
            HidePopUp(document.getElementById("<%=CBDeleteMenu.ClientID %>"));
        }
        function HidePopUp(ContentBox) {
            var popup = ContentBox;
            popup.Hide();
            document.getElementById("<%=HdnRefreshPage.ClientID %>").value = "Y";
        }


        function CreateXML() {
            var xmlMenus = '<Menus>';
            var table = document.getElementById("TblMenuList");
            for (var i = 1; i < table.rows.length; i++) {
                var chk = 'chkIsActive' + i;
                var IsActive = document.getElementById(chk).checked ? "1" : "0";

                xmlMenus = xmlMenus + '<Menu MenuId="' + table.rows[i].cells[1].innerHTML + '" IsActive="' + IsActive + '"></Menu>';
            }
            xmlMenus = xmlMenus + '</Menus>';
            document.getElementById("<%=HdnXML.ClientID %>").value = xmlMenus;

             
        }
        function SaveMenus_Callback(response) {
            atk.Stop();
            GetUrlModuleWise_Callback(response);
        }

        function LinkTypeChanged(external) {
            var txt = document.getElementById("txtExternalLink");
            var ddl = document.getElementById("<%=DdlUrl.ClientID%>");
            ddl.style.display = (external ? "none" : "");
            txt.style.display = (external ? "" : "none");
            if (external && txt.value == "")
                txt.value = "http://";
        }
        function EditLinkTypeChanged(external) {
            var txt = document.getElementById("txtEditExternalLink");
            var ddl = document.getElementById("<%=DdlEditUrl.ClientID%>");
            ddl.style.display = (external ? "none" : "");
            txt.style.display = (external ? "" : "none");
            if (external && txt.value == "")
                txt.value = "http://";
        }

        function HideDeleteMenuPopUp() {
            var popup = document.getElementById("<%=CBDeleteMenu.ClientID %>");
            popup.Hide();
            document.getElementById("<%=HdnRefreshPage.ClientID %>").value = "Y";
        }
        Synthesys.FuncLib.AddLoadEvent(RefreshPage);
    </script>

    <asp:HiddenField ID="HdnSelectedUrl" runat="server" />
    <asp:HiddenField ID="HdnEditedUrl" runat="server" />
    <asp:HiddenField ID="HdnRefreshPage" runat="server" />
    <asp:HiddenField ID="HdnMenuId" runat="server" />
    <asp:HiddenField ID="HdnXML" runat="server" />
    <asp:HiddenField ID="HdnUserLogin" runat="server" />
    <ccm:ContentBox runat="server" ID="CbAddMenu" HeaderText="Add New Menu">
        <table class="AppFormTable">
            <tr>
                <td align="right">
                    Select Module</td>
                <td>
                    <asp:DropDownList ID="DdlModule" runat="server" onchange="return GetListUrl()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                   <input id="Btn_AddNewMenu" type="button" value="Add New Menu" class="InputButton" runat="server" onclick="return ShowAddMenuPopup()" style="display:none" />
                   <asp:Button ID="Btn_SaveMenus" runat="server" Text="Save Menus" OnClientClick="CreateXML()" OnClick="Btn_SaveMenus_Click" CssClass="InputButton" Style="display: none" /></td>
            </tr>
        </table>
        <asp:Label ID="LblNoModuleMsg" runat="server" Text="No such module exist in the current project"
            Style="display: none" Font-Bold="true" ForeColor="red"></asp:Label>
        <table class="AppFormTable" id="MenuGrid">
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CbAddNewMenu" HeaderText="Add New Menu" BoxType="PopupBox"
    Width="75%">
        <table class="AppFormTable" id="tblMenuDetails">
            <tr>
                <td>
                    Menu Name</td>
                <td>
                    <asp:TextBox ID="TxtMenuName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Url</td>
                <td>                
                <input type="radio" name="rbtLink" id="rbtInternal" onclick="LinkTypeChanged(!this.checked);" checked="checked" /><label for="rbtInternal">Internal</label>					
				<input type="radio" name="rbtLink" id="rbtExternal" onclick="LinkTypeChanged(this.checked);" /><label for="rbtExternal">External</label>
					
					<br />
					
                
                
                    <asp:DropDownList ID="DdlUrl" runat="server" Width="250px">
                    </asp:DropDownList>
                    
                    <input type="text" id="txtExternalLink" style="width: 245px;display:none" />
                    </td>
            </tr>
            <tr>
                <td>
                    Is Active</td>
                <td>
                    <asp:RadioButtonList ID="rbtIsActive" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    Query String</td>
                <td>
                    <asp:TextBox ID="TxtQueryString" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Authentication Mode</td>
                <td>
                    <asp:DropDownList ID="DdlAuthenticationMode" runat="server">
                        <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                        <asp:ListItem Text="Public" Value="1"></asp:ListItem>
                        <asp:ListItem Text="System" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Private" Value="3"></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                <input id="Btn_Save" type="button" value="Save" class="InputButton" onclick="return AddMenu()" />
                   </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBEditMenu" HeaderText="Edit Menu" BoxType="PopupBox"
    Width="75%">
        <table class="AppFormTable" id="TblSpecificMenuDetail">
            <tr>
                <td>
                    Menu Name</td>
                <td>
                    <asp:TextBox ID="TxtEditMenuName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Url</td>
                <td>
                
                
                <input type="radio" name="rbtEditLink" id="rbtEditInternal" onclick="EditLinkTypeChanged(!this.checked);" checked="checked" /><label for="rbtInternal">Internal</label>					
				<input type="radio" name="rbtEditLink" id="rbtEditExternal" onclick="EditLinkTypeChanged(this.checked);" /><label for="rbtExternal">External</label>
					
					<br />	
                
                   <asp:DropDownList ID="DdlEditUrl" runat="server" Width="250px">
                    </asp:DropDownList>
                    
                    <input type="text" id="txtEditExternalLink" style="width: 245px" />
                
                    </td>
            </tr>
            <tr>
                <td>
                    Is Active</td>
                <td>
                    <asp:RadioButtonList ID="rbtEditIsActive" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    Query String</td>
                <td>
                    <asp:TextBox ID="TxtEditQueryString" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Authentication Mode</td>
                <td>
                    <asp:DropDownList ID="DdlEditAuthenticationMode" runat="server">
                        <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                        <asp:ListItem Text="Public" Value="1"></asp:ListItem>
                        <asp:ListItem Text="System" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Private" Value="3"></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                  <input id="Btn_Update" type="button" value="Update" class="InputButton" onclick="return SaveEditedUrl()" />
                    </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBDeleteMenu" HeaderText="Delete Menu" BoxType="PopupBox"
    Width="75%">
        <table class="AppFormTable">
            <tr>
                <td colspan="2">
                    Are you sure you want to delete the Menu:
                    <asp:Label ID="LblDeleteMenuName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                    <br />
                    <b>This will delete all the links which are formed from this menu.Do still want to delete this developers menu?</b>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                            <input id="Btn_Delete" type="button" value="Delete" class="InputButton" onclick="DeleteMenu()" />
                            <input id="Btn_Cancel" type="button" value="Cancel" class="InputButton" onclick="HideDeleteMenuPopUp()" />                  
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
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
