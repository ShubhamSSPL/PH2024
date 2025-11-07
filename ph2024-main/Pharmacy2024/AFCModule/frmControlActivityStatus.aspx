<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmControlActivityStatus.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmControlActivityStatus" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script type="text/javascript" src="../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.datetimepicker.js"></script>
    <script type="text/javascript" src="../Scripts/moment.js"></script>
    <link rel="stylesheet" type="text/css" media="all" href="../Styles/jquery.datetimepicker.css" />
    <script language="javascript" type="text/javascript">
        jQuery(document).ready(function () {
            $('#rightContainer_cbActivityStatusDetails_txtActivityStartDateTime').datetimepicker({
                dayOfWeekStart: 1,
                lang: 'en',
                startDate: new Date(),
                format: 'd/m/Y H:i',
                formatTime: 'g:i A',
                ampm: true,
                pick12HourFormat: true
            });

            $('#rightContainer_cbActivityStatusDetails_txtActivityEndDateTime').datetimepicker({
                dayOfWeekStart: 1,
                lang: 'en',
                startDate: new Date(),
                format: 'd/m/Y H:i',
                formatTime: 'g:i A',
                ampm: true,
                pick12HourFormat: true

            });
        });
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            if (document.getElementById("rightContainer_cbActivityStatusDetails_txtActivityEndDateTime") != null) {
                var ActivityStartDateTime = document.getElementById("rightContainer_cbActivityStatusDetails_txtActivityStartDateTime").value;
                var ActivityEndDateTime = document.getElementById("rightContainer_cbActivityStatusDetails_txtActivityEndDateTime").value;

                if (ActivityStartDateTime.length > 0) {
                    document.getElementById("rightContainer_cbActivityStatusDetails_txtActivityStartDateTime").value = moment(ActivityStartDateTime).format('DD/MM/YYYY HH:mm');
                }
                if (ActivityEndDateTime.length > 0) {
                    document.getElementById("rightContainer_cbActivityStatusDetails_txtActivityEndDateTime").value = moment(ActivityEndDateTime).format('DD/MM/YYYY HH:mm');
                }

                jQuery(document).ready(function () {
                    $('#rightContainer_cbActivityStatusDetails_txtActivityStartDateTime').datetimepicker({
                        dayOfWeekStart: 1,
                        lang: 'en',
                        startDate: new Date(),
                        format: 'd/m/Y H:i',
                        formatTime: 'g:i A',
                        ampm: true,
                        pick12HourFormat: true
                    });

                    $('#rightContainer_cbActivityStatusDetails_txtActivityEndDateTime').datetimepicker({
                        dayOfWeekStart: 1,
                        lang: 'en',
                        startDate: new Date(),
                        format: 'd/m/Y H:i',
                        formatTime: 'g:i A',
                        ampm: true,
                        pick12HourFormat: true

                    });
                });
            }
        }
        window.onload = load;
    </script>
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <img src="../Images/BigProgress.gif" alt="" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upActivityStatus">
        <ContentTemplate>
            <cc1:ContentBox ID="cbActivityStatusDetails" runat="server" HeaderText="Control Activity Status">
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 50%;" align="right">Activity Name</td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblActivity" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Activity Start Date Time</td>
                        <td>
                            <asp:TextBox ID="txtActivityStartDateTime" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">Activity End Date Time</td>
                        <td>
                            <asp:TextBox ID="txtActivityEndDateTime" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="InputButton" OnClick="btnUpdate_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" BackColor="#F6223F" OnClick="btnCancel_Click" ValidationGroup="Cancel" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnActivityName" runat="server" />
            </cc1:ContentBox>
            <cc1:ContentBox ID="cbActivityStatusList" runat="server" HeaderText="Activity Status List">
                <asp:GridView ID="gvActivityStatusList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" CssClass="DataGrid" OnSelectedIndexChanging="gvActivityStatusList_SelectedIndexChanging">
                    <columns>                        
                        <asp:BoundField HeaderText="Sr. No." HtmlEncode="false">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ActivityDetails" HeaderText="Activity">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ActivityStartDateTime" HeaderText="Activity Start Date Time">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ActivityEndDateTime" HeaderText="Activity End Date Time">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" HeaderText="Edit" SelectText="Edit">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            <ControlStyle ForeColor="Blue" />
                        </asp:CommandField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblActivityName" runat="server" Text='<%# Eval("ActivityName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </columns>
                </asp:GridView>
                <br />
            </cc1:ContentBox>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
