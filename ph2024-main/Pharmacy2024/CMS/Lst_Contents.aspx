<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="Lst_Contents.aspx.cs" Inherits="CMS_Lst_Contents" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script type="text/javascript" src="../Scripts/AjaxLoader.js"></script>
    <script type="text/javascript">
        var atk;
        function FillContent(value) {
            debugger;
            if (value != '-- Select --') {
                language = value;
//          var e=document.getElementById('<%=ddlLanguage.ClientID %>');
                //          language=e.options[e.selectedIndex].value;
                //          document.getElementById("rightContainer_ccbMenu_ddlGroup").selectedIndex=0;
                //          document.getElementById("rightContainer_ccbMenu_ddlGroup").disabled=true;
                //          document.getElementById("MenuGrid").rows[0].cells[0].innerHTML='';
                //          if(value!=undefined)
                atk = new Synthesys.AjaxTimeKeeper(new Array(4, 8, 12), 'rightContainer_ccbContent', '<b>Fetching</b>', '../Images/BigProgress.gif');
                atk.Start('CMS_Lst_Contents.FillContent', language, FillContent_Callback);
            }
        }
        function FillContent_Callback(response) {
            debugger;
            atk.Stop();
            var conGrid = document.getElementById("ContentGrid");
            var htmlContent;
            var ds = response.value;
            if (ds.Tables[0].Rows.length > 0) {
                document.getElementById('trButtons').style.display = '';
                htmlContent = "<table id=\"TblBranch\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                for (var i = 0; i < response.value.Tables[0].Rows.length; i++) {

                    if (i == 0)
                        htmlContent += "<tr class=\"Header\" ><th scope=\"col\">Sr.No</th><th scope=\"col\" >ContentName</th><th>Edit</th><th>Delete</th></tr>";
                    htmlContent += "<tr class=\"NormalRow\" valign=\"center\">";
                    htmlContent += "<td align=\"center\" >" + parseInt(i + 1) + "</td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;width:100px\" >" + ds.Tables[0].Rows[i].ContentName + "</td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../Images/edit.gif\" onclick=\"showAddEdit('Edit'," + parseInt(i + 1) + ")\"/></a></td>";
                    htmlContent += "<td align=\"center\" style=\"background-color:transparent;\"><a ><img src=\"../Images/delete.gif\" onclick=\"Delete(" + parseInt(i + 1) + ")\"/></a></td>";
                    htmlContent += "<td align=\"center\" style=\"display:none\">" + ds.Tables[0].Rows[i].ContentId + "</td>";
                    htmlContent += "</tr>";

                }

            }
            else {
                document.getElementById('trButtons').style.display = '';
                htmlContent = "<table id=\"TblBranch\"  class=\"AppFormTable\"  cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse\" >";
                htmlContent += "<tr><td><font color=\"red\">No Content Found !!!</font></td></tr>";
            }
            conGrid.rows[0].cells[0].innerHTML = htmlContent;
        }
    </script>

    <cc1:ContentBox ID="ccbContent" runat="server" HeaderText="Added Content">
        <table class="AppFormTable">

            <tr>
                <td align="right" style="width: 50%">Select Language:</td>
                <td>
                    <asp:DropDownList ID="ddlLanguage" runat="server" onchange="FillContent(this.value)"></asp:DropDownList></td>
            </tr>
            <tr id="trButtons" style="display: none">
                <td colspan="2">
                    <table class="AppFormTable">
                        <tr align="center">
                            <td>
                                <input id="btnAdd" type="button" value="Add New" class="InputButton" onclick="showAddEdit('Add', 0)" />
                                <%--<asp:Button ID="btnSaveAll" runat="server" Text="Save" CssClass="InputButton" OnClick="btnSaveAll_Click" OnClientClick="return ValidateAll()"/>--%>
                            </td>
                        </tr>
                    </table>

                </td>

            </tr>
            <tr>
                <td colspan="2">
                    <table class="AppFormTable" id="ContentGrid">
                        <tr>
                            <td></td>
                        </tr>


                    </table>



                </td>
            </tr>

        </table>

    </cc1:ContentBox>
</asp:Content>
