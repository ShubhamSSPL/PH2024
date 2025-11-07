<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" Async="true" AsyncTimeout="35000000" CodeBehind="SMSReminder.aspx.cs" Inherits="Pharmacy2024.AdminModule.SMSReminder" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js" integrity="sha256-VazP97ZCwtekAsvgPBSUwPFKdrwD3unUfSGVYrahUqU=" crossorigin="anonymous" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
           function checkTemplate(sender, args) 
        {
                if (document.getElementById("rightContainer_ContentTable2_rbnrbnTemplateEditYes").checked || document.getElementById("rightContainer_ContentTable2_rbnrbnTemplateEditNo").checked ) {
                }
                else {
                    args.IsValid = false;
                } 
        }
                $(document).ready(function () {
            $(".block").draggable({ helper: 'clone' });


            // drag zone 

            $("#shoppingCart").droppable({
                accept: ".block",
                drop: function (ev, ui) {
                    var droppedItem = $(ui.draggable).clone();
                    $(this)[0].children[0].value += droppedItem.context.innerText;
                }
            });
        });
    </script>
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <img src="../Images/BigProgress.gif" alt="" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upProjectConfiguration">
        <ContentTemplate>
            <cc1:ContentBox ID="cbReminderSMS" runat="server" HeaderText="Reminder SMS">
                <table class="AppFormTable">
                    <tr id="trDropDownList" runat="server">
                        <td align="right">SMS For</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlsmsTemplate" runat="server" OnSelectedIndexChanged="ddlsmsTemplate_SelectedIndexChange" AutoPostBack="true"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvAppValue" runat="server" ErrorMessage="Please Select Key Value." ControlToValidate="ddlsmsTemplate" Display="None" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trTemplateradiobtn" runat="server">
                        <td align="right">Template Edit</td>
                        <td colspan="2">
                            <asp:RadioButton ID="rbnrbnTemplateEditYes" runat="server" GroupName="TemplateEdit" Text="&nbsp;&nbsp;Yes" AutoPostBack="true" OnCheckedChanged="TemplateEdit_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnTemplateEditNo" runat="server" GroupName="TemplateEdit" Text="&nbsp;&nbsp;No" Checked="true" AutoPostBack="true" OnCheckedChanged="TemplateEdit_CheckedChanged" />
                            <asp:CustomValidator ID="cvQualifyingExam" runat="server" ClientValidationFunction="checkTemplate" Display="None" ErrorMessage="Please Select Qualifying Exam."></asp:CustomValidator>

                        </td>
                    </tr>
                    <table class="AppFormTable">
                        <tr>
                            <th align="left" colspan="2">Message For Selected</th>
                        </tr>
                        <tr>
                            <td style="width: 25%;">
                                <div id="shoppingCart">
                                    <asp:TextBox ID="txttemplate" runat="server" class="textbox" Style="width: 500px; overflow: auto; height: 100px;" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxttemplate" runat="server" ControlToValidate="txttemplate" Display="None" ErrorMessage="Please Enter Message."></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td style="width: 75%;">
                                <div id="tdTemplateFields" runat="server" visible="false">
                                    <asp:DataList ID="dltemplatekey" runat="server" BorderColor="#CACACA" BorderStyle="Solid" BorderWidth="1px" RepeatColumns="4" RepeatDirection="Vertical">
                                        <ItemTemplate>
                                            <div class="block">
                                                <%# Eval("Name") %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <tr>
                    </tr>
                    <tr id="trUpdateTemplate" runat="server" visible="false">
                        <td colspan="3">
                            <asp:Button ID="btnUpdateTemplate" runat="server" Text="Update Template" CssClass="InputButton" OnClick="btnUpdateTemplate_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="btnSendSMS" runat="server" Text="Send SMS" CssClass="InputButton" OnClick="btnSendSMS_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                        </td>
                    </tr>
                </table>
            </cc1:ContentBox>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
