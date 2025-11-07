<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmMessagesComposeARC.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmMessagesComposeARC" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function MessageChanged() {
            if (document.getElementById('rightContainer_ContentTable2_txtMsg').value.length > 1000) {
                document.getElementById('rightContainer_ContentTable2_txtMsg').value = document.getElementById('rightContainer_ContentTable2_txtMsg').value.substring(0, 1000);
            }
            document.getElementById('countCharacters').innerHTML = document.getElementById('rightContainer_ContentTable2_txtMsg').value.length;
        }
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder">
            <tr align="center">
                <td><a href="../ARCModule/frmMessagesNonRepliedARC.aspx"><font size="2"><b>&nbsp;&nbsp;|&nbsp;&nbsp;Non Replied Messages&nbsp;&nbsp;|&nbsp;&nbsp;</b></font></a></td>
                <td><a href="../ARCModule/frmMessagesRepliedARC.aspx"><font size="2"><b>&nbsp;&nbsp;|&nbsp;&nbsp;Replied Messages&nbsp;&nbsp;|&nbsp;&nbsp;</b></font></a></td>
                <td><a href="../ARCModule/frmMessagesComposeARC.aspx"><font size="2" color="red"><b>&nbsp;&nbsp;|&nbsp;&nbsp;Compose Message&nbsp;&nbsp;|&nbsp;&nbsp;</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Compose Message">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <ol class="list-text">
                            <b>Note :</b>
                            <li>If you have already sent a message and that is not replied by ADMIN, then please don't send message again for same purpose. If you want to send something is same case, then edit your Non-Replied Message and send.</li>
                        </ol>
                    </font>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <td style="width: 15%;" align="right">To</td>
                <td style="width: 85%;">
                    <asp:TextBox ID="txtTo" runat="server" ReadOnly="True">ADMIN</asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">Subject</td>
                <td>
                    <asp:TextBox ID="txtSubject" runat="server" MaxLength="100" Width="90%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject" ErrorMessage="Please Enter subject." Display="none"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Attachment 1</td>
                <td>
                    <input id="fileInput1" type="file" runat="server" />
                    (Only .JPG, .JPEG, .PDF Formats Supported)</td>
            </tr>
            <%--   <tr>
                <td align = "right">Attachment 2</td>
                <td><input id="fileInput2" type="file" runat="server" /> (Only .JPG, .JPEG, .PDF Formats Supported)</td>
            </tr>--%>
            <tr>
                <td align="right" valign="top">Message</td>
                <td>
                    <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Width="90%" Height="50" MaxLength="1000" onkeyup="MessageChanged()"></asp:TextBox>
                    <br />
                    (<span id="countCharacters">0</span> / 1000 characters filled)
                    <asp:RequiredFieldValidator ID="rfvMsg" runat="server" ControlToValidate="txtMsg" ErrorMessage="Please Enter Message." Display="none"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnSend" runat="server" Text="Send Message" CssClass="InputButton" OnClick="btnSend_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
