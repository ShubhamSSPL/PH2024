<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="UserMgt.aspx.cs" Inherits="MenuManagement_UserMgt" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/AjaxLoader.js"></script>

    <script type="text/javascript" language="javascript">
        var atk;
        function FilterRow(txt, col) {

            var table = document.getElementById('TblUserList');
            if (col == 1) {
                table.rows[1].cells[2].childNodes[0].value = "";
                table.rows[1].cells[3].childNodes[0].value = "";
            } else if (col == 2) {
                table.rows[1].cells[1].childNodes[0].value = "";
                table.rows[1].cells[3].childNodes[0].value = "";
            } else if (col == 3) {
                table.rows[1].cells[1].childNodes[0].value = "";
                table.rows[1].cells[2].childNodes[0].value = "";
            }

            var val = txt.value.toLowerCase();
            var ele;
            for (var i = 2; i < table.rows.length; i++) {
                ele = table.rows[i].cells[col].innerHTML.replace(/<[^>]+>/g, "");
                {
                    ele = ele.toLowerCase();
                    if (ele.substring(0, val.length) == val)
                        table.rows[i].style.display = '';
                    else
                        table.rows[i].style.display = 'none';
                }

            }
        }
        function GetListOfUsers(Value) {
            if (Value != '-- Select --') {
                atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddUser_DdlUserType', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
                atk.Start('MenuManagement_UserMgt.GetUsersUserTypeWise', Value, GetUsersUserTypeWise_Callback);
            }
        }
        function GetUsersUserTypeWise_Callback(response) {

            atk.Stop();
            var ds = response.value;
            var tbl = document.getElementById('UserGrid');
            if (ds.Tables[0].Rows.length > 0) {

                htmlContent = "<table id=\"TblUserList\"  class=\"AppFormTable\" Synthesysfilter=\"text-columns:1\" cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                for (var i = 0; i < response.value.Tables[0].Rows.length; i++) {
                    if (i == 0) {
                        htmlContent += "<tr class=\"Header\" ><th scope=\"col\">Sr.No</th><th scope=\"col\" >User Name</th><th scope=\"col\">Login</th><th>Password</th><th>IsActive</th><th>Edit</th><th>Delete</th></tr>";
                        htmlContent += "<tr class=\"NormalRow\" valign=\"center\"><td></td><td align=\"center\"><input id=\"TxtName\" type=\"text\" onkeyup=\"FilterRow(this,1)\" title=\"Enter Name to filter\" size=\"20\"/></td><td align=\"center\"><input id=\"TxtLoginId\" type=\"text\" onkeyup=\"FilterRow(this,2)\" title=\"Enter LoginId to filter\" size=\"20\"/></td><td align=\"center\"><input id=\"TxtPassword\" type=\"text\" onkeyup=\"FilterRow(this,3)\" title=\"Enter Password to filter\" size=\"20\"/></td><td></td><td></td><td></td></tr>";
                        htmlContent += "<tr class=\"NormalRow\" valign=\"center\">";
                        htmlContent += "<td align=\"center\" >" + parseInt(i + 1) + "</td>";
                        htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px\" >" + ds.Tables[0].Rows[i].UserName + "</td>";
                        htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px\" >" + ds.Tables[0].Rows[i].LoginID + "</td>";
                        htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px\" >" + ds.Tables[0].Rows[i].Password + "</td>";
                        var IsActive = ds.Tables[0].Rows[i].IsActive == "Y" ? "checked" : "";
                        htmlContent += "<td align=\"center\" ><input id=chkIsActive" + parseInt(i + 1) + " type=\"checkbox\"" + IsActive + "/></td>";
                        htmlContent += "<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"ShowEditUser('" + ds.Tables[0].Rows[i].LoginID + "','" + ds.Tables[0].Rows[i].Password + "')\" /></a></td>";
                        htmlContent += "<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/delete.gif\" onclick=\"ShowDeleteUser('" + ds.Tables[0].Rows[i].LoginID + "','" + ds.Tables[0].Rows[i].Password + "')\"/></a></td>";

                        htmlContent += "</tr>";
                    }
                    else {
                        htmlContent += "<tr class=\"NormalRow\" valign=\"center\">";
                        htmlContent += "<td align=\"center\" >" + parseInt(i + 1) + "</td>";
                        htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px\" >" + ds.Tables[0].Rows[i].UserName + "</td>";
                        htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px\" >" + ds.Tables[0].Rows[i].LoginID + "</td>";
                        htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px\" >" + ds.Tables[0].Rows[i].Password + "</td>";
                        var IsActive = ds.Tables[0].Rows[i].IsActive == "Y" ? "checked" : "";
                        htmlContent += "<td align=\"center\" ><input id=chkIsActive" + parseInt(i + 1) + " type=\"checkbox\"" + IsActive + "/></td>";
                        htmlContent += "<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/edit.gif\" onclick=\"ShowEditUser('" + ds.Tables[0].Rows[i].LoginID + "','" + ds.Tables[0].Rows[i].Password + "')\" /></a></td>";
                        htmlContent += "<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../SynthesysModules_Files/Images/delete.gif\" onclick=\"ShowDeleteUser('" + ds.Tables[0].Rows[i].LoginID + "','" + ds.Tables[0].Rows[i].Password + "')\"/></a></td>";

                        htmlContent += "</tr>";
                    }
                }
                document.getElementById("<%=Btn_Add.ClientID %>").style.display = '';
                  document.getElementById("<%=Btn_SaveUsers.ClientID %>").style.display = '';
              }
              else {

                  htmlContent = "<table id=\"TblUserList\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                  htmlContent += "<tr><td><font color=\"red\">No users Found !!!</font></td></tr>";
                  document.getElementById("<%=Btn_Add.ClientID %>").style.display = '';
                  document.getElementById("<%=Btn_SaveUsers.ClientID %>").style.display = 'none';
            }
            tbl.rows[0].cells[0].innerHTML = htmlContent;
        }
        function ShowAddPopUp() {
            document.getElementById('<%=TxtUserName.ClientID %>').value = '';
             document.getElementById('<%=TxtLoginId.ClientID %>').value = '';
             document.getElementById('<%=TxtPassword.ClientID %>').value = '';
             document.getElementById('<%=CbNewAddUser.ClientID%>').Show('#000000', true);
            return false;
        }
        function RefreshPage() {
            if (document.getElementById("<%=HdnRefreshPage.ClientID %>").value == "Y") {
                GetListOfUsers(document.getElementById("<%=DdlUserType.ClientID %>").value);
                document.getElementById("<%=HdnRefreshPage.ClientID %>").value = "";
            }
        }
        function ShowEditUser(LoginId, Password) {
            document.getElementById("<%=HdnLoginId.ClientID %>").value = LoginId;
             document.getElementById("<%=HdnPassword.ClientID %>").value = Password;
             atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddUser_DdlUserType', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
             atk.Start('MenuManagement_UserMgt.GetSpecificUserDetails', parseInt(document.getElementById("<%=DdlUserType.ClientID %>").value), LoginId, Password, GetSpecificUserDetails_Callback);

        }
        function GetSpecificUserDetails_Callback(response) {

            atk.Stop();
            var ds = response.value;
            if (ds.Tables[0].Rows.length > 0) {
                document.getElementById("<%=TxtEditUserName.ClientID %>").value = ds.Tables[0].Rows[0].UserName;
                document.getElementById("<%=TxtEditLogin.ClientID %>").value = ds.Tables[0].Rows[0].LoginID;
                document.getElementById("<%=TxtEditPassword.ClientID %>").value = ds.Tables[0].Rows[0].Password;
                if (ds.Tables[0].Rows[0].IsActive == "Y") {
                    document.getElementById("rightContainer_CbEditUser_rbtEditIsActive_0").checked = true;
                }
                else {
                    document.getElementById("rightContainer_CbEditUser_rbtEditIsActive_1").checked = true;
                }

                var popup = document.getElementById("<%=CbEditUser.ClientID %>");
                popup.Show('#000000', true);
            }
        }
        function HidePopUp() {
            var popup = document.getElementById("<%=CBDeleteUser.ClientID %>");
             popup.Hide();
             document.getElementById("<%=HdnRefreshPage.ClientID %>").value = "Y";
        }
        function ShowDeleteUser(LoginId, Password) {
            document.getElementById("<%=HdnLoginId.ClientID %>").value = LoginId;
             document.getElementById("<%=HdnPassword.ClientID %>").value = Password;
             atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddUser_DdlUserType', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
             atk.Start('MenuManagement_UserMgt.GetSpecificUserDetails', parseInt(document.getElementById("<%=DdlUserType.ClientID %>").value), LoginId, Password, DeleteUserDetails_Callback);

        }
        function DeleteUserDetails_Callback(response) {
            atk.Stop();
            var ds = response.value;
            if (ds.Tables[0].Rows.length > 0) {
                document.getElementById("<%=LblDeleteUserName.ClientID %>").innerHTML = ds.Tables[0].Rows[0].UserName;
                var popup = document.getElementById("<%=CBDeleteUser.ClientID %>");
                popup.Show('#000000', true);
            }
        }
        function CreateXML() {
            var xmlGroups = '<Users>';
            var table = document.getElementById("TblUserList");
            for (var i = 2; i < table.rows.length; i++) {
                var chk = 'chkIsActive' + (i - 1);
                var IsActive = document.getElementById(chk).checked ? "Y" : "N";

                xmlGroups = xmlGroups + '<User LoginId="' + table.rows[i].cells[2].innerHTML + '" IsActive="' + IsActive + '"></User>';
            }
            xmlGroups = xmlGroups + '</Users>';
            document.getElementById("<%=HdnXML.ClientID %>").value = xmlGroups;
        }
        function checkNewDataEntry() {
            var isValid = true;

            if (document.getElementById("<%=TxtUserName.ClientID %>").value == '') {
                alert('Please enter user name');
                isValid = false;
            }
            if (document.getElementById("<%=TxtLoginId.ClientID %>").value == '') {
                alert('Please enter login id');
                isValid = false;
            }
            if (document.getElementById("<%=TxtPassword.ClientID %>").value == '') {
                alert('Please enter password');
                isValid = false;
            }
            if (document.getElementById('rightContainer_CbNewAddUser_rbtIsActive_0').checked == false
                && document.getElementById('rightContainer_CbNewAddUser_rbtIsActive_1').checked == false) {
                alert('Please select if the user is active or not');
                isValid = false;
            }
            return isValid;
        }
        function checkEditedDataEntry() {
            var isValid = true;

            if (document.getElementById("<%=TxtEditUserName.ClientID %>").value == '') {
                alert('Please Enter user name');
                isValid = false;
            }
            if (document.getElementById("<%=TxtEditLogin.ClientID %>").value == '') {
                alert('Please enter login id');
                isValid = false;
            }
            if (document.getElementById("<%=TxtEditPassword.ClientID %>").value == '') {
                alert('Please enter password');
                isValid = false;
            }
            if (document.getElementById('rightContainer_CbEditUser_rbtEditIsActive_1').checked == false
                && document.getElementById('rightContainer_CbEditUser_rbtEditIsActive_0').checked == false) {
                alert('Please select if the user is active or not');
                isValid = false;
            }
            return isValid;

        }
        function DeleteUser() {
            var LoginId = document.getElementById("<%=HdnLoginId.ClientID %>").value;
            var Password = document.getElementById("<%=HdnPassword.ClientID %>").value;
            atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_CbAddUser_DdlUserType', '<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
            atk.Start('MenuManagement_UserMgt.DeleteUser', parseInt(document.getElementById("<%=DdlUserType.ClientID %>").value), LoginId, Password, DeleteUser_Callback);
        }
        function DeleteUser_Callback(response) {
            GetUsersUserTypeWise_Callback(response);
            HidePopUp();
        }
        Synthesys.FuncLib.AddLoadEvent(RefreshPage);
    </script>

    <asp:HiddenField ID="HdnRefreshPage" runat="server" />
    <asp:HiddenField ID="HdnLoginId" runat="server" />
    <asp:HiddenField ID="HdnXML" runat="server" />
    <asp:HiddenField ID="HdnPassword" runat="server" />
    <ccm:ContentBox runat="server" ID="CbAddUser" HeaderText="Add New User">
        <table class="AppFormTable">
            <tr>
                <td>
                    User Type</td>
                <td>
                    <asp:DropDownList ID="DdlUserType" runat="server" onchange="GetListOfUsers(this.value)">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Btn_Add" runat="server" Text="Add New User" OnClientClick=" return ShowAddPopUp()"
                        CssClass="InputButton" Width="150px" Height="20px" Style="display: none" />
                    <asp:Button ID="Btn_SaveUsers" runat="server" Text="Save Users" OnClientClick="CreateXML()"
                        OnClick="Btn_SaveUsers_Click" CssClass="InputButton" Width="150px" Height="20px"
                        Style="display: none" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="AppFormTable" id="UserGrid">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CbNewAddUser" HeaderText="New User Details" BoxType="PopupBox"
    Width="75%">
        <table class="AppFormTable">
            <tr>
                <td>
                    User Name</td>
                <td>
                    <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Login</td>
                <td>
                    <asp:TextBox ID="TxtLoginId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password</td>
                <td>
                    <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>
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
                <td align="center" colspan="2">
                    <asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click" CssClass="InputButton"
                        Width="50px" Height="20px" OnClientClick="return checkNewDataEntry()" /></td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CbEditUser" HeaderText="Edit User Details" BoxType="PopupBox"
    Width="75%">
        <table class="AppFormTable">
            <tr>
                <td>
                    User Name</td>
                <td>
                    <asp:TextBox ID="TxtEditUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Login</td>
                <td>
                    <asp:TextBox ID="TxtEditLogin" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password</td>
                <td>
                    <asp:TextBox ID="TxtEditPassword" runat="server"></asp:TextBox>
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
                <td align="center" colspan="2">
                    <asp:Button ID="Btn_Update" runat="server" Text="Update" OnClick="Btn_Update_Click"
                        CssClass="InputButton" Width="100px" Height="20px" OnClientClick="return checkEditedDataEntry()" /></td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox runat="server" ID="CBDeleteUser" HeaderText="Delete User" BoxType="PopupBox"
    Width="75%">
        <table class="AppFormTable">
            <tr>
                <td colspan="2">
                    Are you sure you want to delete the user:
                    <asp:Label ID="LblDeleteUserName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <input id="Btn_Delete" type="button" value="Delete" class="InputButton" onclick="DeleteUser()"
                        style="height: 20px; width: 50px" />
                    <input id="Btn_Cancel" type="button" value="Cancel" class="InputButton" onclick="HidePopUp()"
                        style="height: 20px; width: 50px" />
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
</asp:Content>
