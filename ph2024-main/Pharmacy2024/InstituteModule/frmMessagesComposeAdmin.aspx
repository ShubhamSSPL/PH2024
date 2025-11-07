<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmMessagesComposeAdmin.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmMessagesComposeAdmin" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
       .AppFormTable input {
            height: unset;
            padding: inherit;
        }
    </style>
    <script src="../Scripts/mcfCrop.js"></script>
   <%-- <script>
        $(document).ready(function () {
            initContainer("cropContainer", 80, 1000, 800, "../Images/", 500, cb);
            function cb(data, fileName, fileExt) {               
                if (data.length > 0) {
                    $('#imgCropped').val(data);
                }
                else {
                    alert("Please Select File");
                }
            }

        })
    </script>--%>
     <script>
         $(document).ready(function () {
             $('#rightContainer_ContentTable2_fileInput1').change(function () {
                 var x = document.getElementById("rightContainer_ContentTable2_fileInput1");
                 var sFileName = x.value;

                 var KB = 0;
                 var fs = x.files.item(0).size;
                 KB = (fs / 1024).toFixed(2);

                 if (parseFloat(KB) < 501) {
                     document.getElementById("rightContainer_ContentTable2_fileInput1").style.display = "block";

                     var files = !!this.files ? this.files : [];
                     var reader = new FileReader();
                     reader.readAsDataURL(files[0]);
                     reader.onload = function (e) {
                         document.getElementById("thumimg").src = e.target.result;
                     };
                     reader.readAsDataURL(this.files[0]);

                     document.getElementById("rightContainer_ContentTable2_fileInput1").innerHTML = x.value;
                     {
                         $('#thumimg').attr('src', Image_file);
                     };
                 }
                 else {
                     alert("Selected file must be less than 500KB");
                     x.value = "";
                     document.getElementById("thumimg").src = "";

                     return false;
                 }
             });
         })
     </script>
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
        function MessageChanged() {
            if (document.getElementById('rightContainer_ContentTable2_txtMsg').value.length > 1000) {
                document.getElementById('rightContainer_ContentTable2_txtMsg').value = document.getElementById('rightContainer_ContentTable2_txtMsg').value.substring(0, 1000);
            }
            document.getElementById('countCharacters').innerHTML = document.getElementById('rightContainer_ContentTable2_txtMsg').value.length;
        }
        function SMSChanged() {
            if (document.getElementById('rightContainer_ContentTable2_txtSMSContent').value.length > 150) {
                document.getElementById('rightContainer_ContentTable2_txtSMSContent').value = document.getElementById('rightContainer_ContentTable2_txtSMSContent').value.substring(0, 150);
            }
            document.getElementById('countSMSCharacters').innerHTML = document.getElementById('rightContainer_ContentTable2_txtSMSContent').value.length;
        }
        function ClickOnChk(temp) {
            if (document.getElementById(temp).checked) {
                document.getElementById(temp).parentElement.parentElement.style.background = "#fdfad5";
            }
            else {
                document.getElementById(temp).parentElement.parentElement.style.background = "white";
            }

            var grid = document.getElementById('<%=gvList.ClientID %>');
            var inputList = grid.getElementsByTagName("input")
            var count = true;
            for (var i = 1; i < inputList.length; i++) {
                if (!inputList[i].checked) {
                    count = false;
                    break;
                }
            }
            document.getElementById('rightContainer_ContentTable2_gvList_ctl01_chkAll').checked = count;
        }
        function checkAll(select) {
            var grid = document.getElementById('<%=gvList.ClientID %>');
            var inputList = grid.getElementsByTagName("input")

            for (var i = 1; i < inputList.length; i++) {
                inputList[i].checked = select;
                if (inputList[i].checked == true) {
                    grid.rows[i].cells[0].childNodes[0].parentNode.parentNode.style.background = "#fdfad5";
                }
                else {
                    grid.rows[i].cells[0].childNodes[0].parentNode.parentNode.style.background = "white";
                }
            }
        }
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder">
            <tr align="center">
                <td><a href="../InstituteModule/frmMessagesNonRepliedAdmin.aspx"><font size="2"><b>|Non Replied Messages|</b></font></a></td>
                <td><a href="../InstituteModule/frmMessagesRepliedAdmin.aspx"><font size="2"><b>|Replied Messages|</b></font></a></td>
                <td><a href="../InstituteModule/frmMessagesComposeAdmin.aspx"><font size="2" color="red"><b>|Compose Message|</b></font></a></td>
                <td><a href="../InstituteModule/frmMessagesSentAdmin.aspx"><font size="2"><b>|Sent Messages|</b></font></a></td>
                <td><a href="../InstituteModule/frmMessagesStarMarked.aspx"><font size = "2"><b>| Star Marked Messages |</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Compose Message">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upExamCenter" UpdateMode="Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSend" />
                <asp:PostBackTrigger ControlID="chkBroadcastRO" />
                <asp:PostBackTrigger ControlID="chkBroadcastInstitute" />
                <asp:PostBackTrigger ControlID="chkInsertAddress" />
                <asp:PostBackTrigger ControlID="chkMessage" />
                <asp:PostBackTrigger ControlID="chkSMS" />
                <asp:PostBackTrigger ControlID="btnInsertAddresses" />
            </Triggers>
            <ContentTemplate>
                <table class="AppFormTable" id = "tblMessage" runat = "server">
                    <tr>
                        <td style = "width:25%;" align="right" valign="baseline">To</td>
                        <td style = "width:75%;">
                            <asp:TextBox ID="txtTo" runat="server" ReadOnly="True" Width = "90%" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTo" runat="server" ControlToValidate="txtTo" ErrorMessage="Please Enter To." Display = "None" ValidationGroup = "Send"></asp:RequiredFieldValidator>
                            <br /><br />
                            <asp:CheckBox id="chkBroadcastRO" runat="server" CssClass="AClass" Text=" ALL RO" AutoPostBack="True" OnCheckedChanged="Broadcast_CheckedChanged" />
                            &nbsp;&nbsp;
                            <asp:CheckBox id="chkBroadcastInstitute" runat="server" CssClass="AClass" Text=" ALL Institute" AutoPostBack="True" OnCheckedChanged="Broadcast_CheckedChanged" />
                            &nbsp;&nbsp;
                            <asp:CheckBox id="chkInsertAddress" runat="server" CssClass="AClass" Text=" Insert Address" AutoPostBack="True" OnCheckedChanged="Broadcast_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td align = "right"></td>
                        <td>
                            <asp:CheckBox id="chkMessage" runat="server" CssClass="AClass" Text=" Send Message" AutoPostBack="True" OnCheckedChanged="SendMessage_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox id="chkSMS" runat="server" CssClass="AClass" Text=" Send SMS" AutoPostBack="True" OnCheckedChanged="SendSMS_CheckedChanged" />
                        </td>
                    </tr>
                    <tr id = "trMessage1" runat = "server" visible = "false">
                        <td align = "right" valign="baseline">Attachment 1</td>
                        <td><input id="fileInput1" type="file" runat="server" /><br />(Only .JPG, .JPEG, .PDF, .ZIP, .RAR, .XLS, .XLSX Formats Supported)</td>
                    </tr>
                    <tr id = "trMessage2" runat = "server" visible = "false">
                        <td align = "right" valign="baseline">Attachment 2</td>
                        <td><input id="fileInput2" type="file" runat="server" /><br />(Only .JPG, .JPEG, .PDF, .ZIP, .RAR, .XLS, .XLSX Formats Supported)</td>
                    </tr>
                    <tr id = "trMessage3" runat = "server" visible = "false">
                        <td align="right" valign="baseline">Message</td>
                        <td>
                            <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Width="90%" Height="150" MaxLength = "1000" onkeyup="MessageChanged()"></asp:TextBox>
                            <br />
                            <b>(<span id="countCharacters">0</span> / 1000 characters filled)</b>
                            <asp:RequiredFieldValidator ID="rfvMsg" runat="server" ControlToValidate="txtMsg" ErrorMessage="Please Enter Message." Display = "None" ValidationGroup = "Send"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id = "trSMS" runat = "server" visible = "false">
                        <td align="right" valign="baseline">SMS Content</td>
                        <td>
                            <asp:TextBox ID="txtSMSContent" runat="server" TextMode="MultiLine" MaxLength = "150" Width="90%" Height="50" onkeyup="SMSChanged()"></asp:TextBox>
                            <br />
                            <b>(<span id="countSMSCharacters">0</span> / 150 characters filled)</b>
                            <asp:RequiredFieldValidator ID="rfvSMSContent" runat="server" ControlToValidate="txtSMSContent" ErrorMessage="Please Enter SMS Content." Display = "None" ValidationGroup = "Send"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnSend" runat="server" Text="Send Message" CssClass="InputButton" OnClick="btnSend_Click" ValidationGroup = "Send" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup = "Send" />
                        </td>
                    </tr>
                </table>
                <table class="AppFormTableWithOutBorder" id="tblInsertAddress" runat="server" visible="false">
                    <tr>
                        <td align="center">Enter Search Details : 
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSearch" runat="server" ErrorMessage="Please Enter Search Details." Display="None" ControlToValidate="txtSearch" ValidationGroup="Search"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="InputButton" OnClick="btnSearch_Click" ValidationGroup="Search" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="Search" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" onclick="ClickOnChk(this.id)" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            Select All<br />
                                            <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this.checked)" />
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Width="10%" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="10%" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="RO/Institute Code" DataField="LoginID">
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="20%" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="20%" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="RO/Institute Name" DataField="Name">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="70%" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="70%" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnInsertAddresses" runat="server" Text="Insert Addresses" CssClass="InputButton" OnClick="btnInsertAddresses_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
   <%-- <script type="text/javascript">
        function closeUpload() {
            document.getElementById('<%=contentFileTest.ClientID %>').style.display = "none";
            document.getElementById('<%=btnUpload.ClientID %>').style.display = "block";
        }
        function OpenTestPopup(cntrl) {

            document.getElementById('<%=contentFileTest.ClientID %>').style.display = "block";
            document.getElementById('<%=contentFileTest.ClientID %>').setAttribute("tabindex", 1);
            document.getElementById('<%=contentFileTest.ClientID %>').focus();
            document.getElementById('<%=btnUpload.ClientID %>').style.display = "none";

        }
    </script>--%>
</asp:Content>
