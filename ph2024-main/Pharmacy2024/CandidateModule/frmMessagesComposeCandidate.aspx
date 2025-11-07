<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmMessagesComposeCandidate.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmMessagesComposeCandidate" %>
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
        <div class="table-responsive">
            <table class="AppFormTableWithOutBorder">
                <tr align="center">
                    <td><a href="../CandidateModule/frmMessagesNonRepliedCandidate.aspx"><font size="2" ><b>| Non Replied Messages |</b></font></a></td>
                    <td><a href="../CandidateModule/frmMessagesRepliedCandidate.aspx"><font size="2"><b>| Replied Messages |</b></font></a></td>
                    <td><a href="../CandidateModule/frmMessagesComposeCandidate.aspx"><font size="2" color="red"><b>| Compose Message |</b></font></a></td>
                </tr>
            </table>
        </div>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Compose Message">
        <div class="table-responsive">
            <table class="AppFormTable">
                <tr>
                    <td style="width: 15%;" align="right" >To</td>
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
                        <input id="fileInput1" type="file" style="height:100%; " class="width-password" runat="server" />
                        (Only .JPG, .JPEG, .PDF Formats Supported)</td>
                </tr>
                <tr style="display: none">
                    <td align="right">Attachment 2</td>
                    <td>
                        <input id="fileInput2" type="file" runat="server" />
                        (Only .JPG, .JPEG, .PDF Formats Supported)</td>
                </tr>
                <tr>
                    <td align="right" valign="top">Message</td>
                    <td>
                        <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Width="90%" Height="150" MaxLength="1000" onkeyup="MessageChanged()"></asp:TextBox>
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
        </div>
    </cc1:ContentBox>
</asp:Content>


