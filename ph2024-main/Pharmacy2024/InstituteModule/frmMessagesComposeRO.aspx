<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmMessagesComposeRO.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmMessagesComposeRO" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function MessageChanged() 
        {
            if (document.getElementById('rightContainer_ContentTable2_txtMsg').value.length > 1000) 
            {
                document.getElementById('rightContainer_ContentTable2_txtMsg').value = document.getElementById('rightContainer_ContentTable2_txtMsg').value.substring(0, 1000);
            }
            document.getElementById('countCharacters').innerHTML = document.getElementById('rightContainer_ContentTable2_txtMsg').value.length;
        }
        function ClickOnChk(temp) 
        {
            if (document.getElementById(temp).checked) 
            {
                document.getElementById(temp).parentElement.parentElement.style.background = "#fdfad5";
            }
            else 
            {
                document.getElementById(temp).parentElement.parentElement.style.background = "white";
            }

            var grid = document.getElementById('<%=gvList.ClientID %>');
            var inputList = grid.getElementsByTagName("input")
            var count = true;
            for (var i = 1; i < inputList.length; i++) 
            {
                if (!inputList[i].checked) 
                {
                    count = false;
                    break;
                }
            }
            document.getElementById('rightContainer_ContentTable2_gvList_ctl01_chkAll').checked = count;
        }
        function checkAll(select) 
        {
            var grid = document.getElementById('<%=gvList.ClientID %>');
            var inputList = grid.getElementsByTagName("input")

            for (var i = 1; i < inputList.length; i++) 
            {
                inputList[i].checked = select;
                if (inputList[i].checked == true) 
                {
                    grid.rows[i].cells[0].childNodes[0].parentNode.parentNode.style.background = "#fdfad5";
                }
                else 
                {
                    grid.rows[i].cells[0].childNodes[0].parentNode.parentNode.style.background = "white";
                }
            }
        }
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class = "AppFormTableWithOutBorder">
            <tr align = "center">
                <td><a href="../InstituteModule/frmMessagesNonRepliedRO.aspx"><font size = "2"><b>|Non Replied Messages|</b></font></a></td>
                <td><a href="../InstituteModule/frmMessagesRepliedRO.aspx"><font size = "2"><b>|Replied Messages|</b></font></a></td>
                <td><a href="../InstituteModule/frmMessagesComposeRO.aspx"><font size = "2" color = "red"><b>|Compose Message|</b></font></a></td>
                <td><a href="../InstituteModule/frmMessagesSentRO.aspx"><font size = "2"><b>|Sent Messages|</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Compose Message">
        <asp:UpdateProgress runat="server" id="PageUpdateProgress">
            <ProgressTemplate>
                <img src ="../Images/BigProgress.gif" alt = "" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upExamCenter" UpdateMode = "Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSend" />
            </Triggers>
            <ContentTemplate>
                <table class="AppFormTable" id = "tblMessage" runat = "server">
                    <tr>
                        <td style = "width:15%;" align="right">To</td>
                        <td style = "width:85%;">
                            <asp:RadioButton id="rbnAdmin" runat="server" CssClass="AClass" Text=" ADMIN" GroupName = "Broadcast" AutoPostBack="True" OnCheckedChanged="Broadcast_CheckedChanged" />
                            &nbsp;&nbsp;
                            <asp:RadioButton id="rbnInstitute" runat="server" CssClass="AClass" Text=" Institute" GroupName = "Broadcast" AutoPostBack="True" OnCheckedChanged="Broadcast_CheckedChanged" />
                            <br />
                            <asp:TextBox ID="txtTo" runat="server" ReadOnly="True" Width = "90%" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTo" runat="server" ControlToValidate="txtTo" ErrorMessage="Please Enter To." Display = "None" ValidationGroup = "Send"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align = "right">Attachment 1</td>
                        <td><input id="fileInput1" type="file" runat="server" /><br />(Only .JPG, .JPEG, .PDF, .ZIP, .RAR, .XLS, .XLSX Formats Supported)</td>
                    </tr>
                   <%-- <tr>
                        <td align = "right">Attachment 2</td>
                        <td><input id="fileInput2" type="file" runat="server" /><br />(Only .JPG, .JPEG, .PDF, .ZIP, .RAR, .XLS, .XLSX Formats Supported)</td>
                    </tr>--%>
                    <tr>
                        <td align="right">Message</td>
                        <td>
                            <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Width="90%" Height="50" MaxLength = "1000" onkeyup="MessageChanged()"></asp:TextBox>
                            <br />
                            <b>(<span id="countCharacters">0</span> / 1000 characters filled)</b>
                            <asp:RequiredFieldValidator ID="rfvMsg" runat="server" ControlToValidate="txtMsg" ErrorMessage="Please Enter Message." Display = "None" ValidationGroup = "Send"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnSend" runat="server" Text="Send Message" CssClass="InputButton" OnClick="btnSend_Click" ValidationGroup = "Send" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup = "Send" />
                        </td>
                    </tr>
                </table>
                <table class="AppFormTableWithOutBorder" id = "tblInsertAddress" runat = "server" visible = "false">
                    <tr>
                        <td>
                            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth = "1px" BorderStyle = "Solid" CssClass = "DataGrid">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox id = "chkSelect" runat="server" onclick ="ClickOnChk(this.id)" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            Select All<br />
                                            <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this.checked)" />
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Width="10%" BorderWidth = "1px" BorderStyle = "Solid" CssClass = "Item" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="10%" BorderWidth = "1px" BorderStyle = "Solid" CssClass = "Header" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="RO/Institute Code" DataField="LoginID">
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="20%" BorderWidth = "1px" BorderStyle = "Solid" CssClass = "Item" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="20%" BorderWidth = "1px" BorderStyle = "Solid" CssClass = "Header" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="RO/Institute Name" DataField="Name">
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="70%" BorderWidth = "1px" BorderStyle = "Solid" CssClass = "Item" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="70%" BorderWidth = "1px" BorderStyle = "Solid" CssClass = "Header" />
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
</asp:Content>