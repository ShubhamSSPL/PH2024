<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="frmControlImportantDates.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmControlImportantDates" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .AppFormTable .col-sm-6{
           margin-bottom:8px;
        }
    </style>
    <script type="text/javascript" src="../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.datetimepicker.js"></script>
    <script type="text/javascript" src="../Scripts/moment.js"></script>
    <link rel="stylesheet" type="text/css" media="all" href="../Styles/jquery.datetimepicker.css" />
    <script src="../Scripts/epoch_classes_current.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function isStartDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtStartDate").value;
            if (dateStr.length == 0) {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat); // is format OK?
            if (matchArray == null) {
                args.IsValid = false;
                return;
            }
            month = matchArray[3];
            day = matchArray[1];
            year = matchArray[5];
            if (year < 1900 || year >= 2080) {
                args.IsValid = false;
                return;
            }
            if (month < 1 || month > 12) {
                args.IsValid = false;
                return;
            }
            if (day < 1 || day > 31) {
                args.IsValid = false;
                return;
            }
            if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
                args.IsValid = false;
                return;
            }
            if (month == 2) {
                var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
                if (day > 29 || (day == 29 && !isleap)) {
                    args.IsValid = false;
                    return;
                }
            }
        }
        function isEndDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtEndDate").value;
            if (dateStr.length == 0) {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat); // is format OK?
            if (matchArray == null) {
                args.IsValid = false;
                return;
            }
            month = matchArray[3];
            day = matchArray[1];
            year = matchArray[5];
            if (year < 1900 || year >= 2080) {
                args.IsValid = false;
                return;
            }
            if (month < 1 || month > 12) {
                args.IsValid = false;
                return;
            }
            if (day < 1 || day > 31) {
                args.IsValid = false;
                return;
            }
            if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
                args.IsValid = false;
                return;
            }
            if (month == 2) {
                var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
                if (day > 29 || (day == 29 && !isleap)) {
                    args.IsValid = false;
                    return;
                }
            }
        }
        function validateDate(sender, args) {
            var dateFrom = document.getElementById("rightContainer_ContentTable2_txtStartDate").value;
            var dateTo = document.getElementById("rightContainer_ContentTable2_txtEndDate").value;
            var cvValidateDate = document.getElementById("rightContainer_ContentTable2_cvValidateDate");
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArrayFrom = dateFrom.match(datePat);
            var matchArrayTo = dateTo.match(datePat);

            if (matchArrayFrom == null || matchArrayTo == null) {
                cvValidateDate.errormessage = 'Please select proper Dates.';
                args.IsValid = false;
            }
            else {
                monthFrom = matchArrayFrom[3];
                dayFrom = matchArrayFrom[1];
                yearFrom = matchArrayFrom[5];
                monthTo = matchArrayTo[3];
                dayTo = matchArrayTo[1];
                yearTo = matchArrayTo[5];

                if (Date.parse(monthFrom + '/' + dayFrom + '/' + yearFrom) > Date.parse(monthTo + '/' + dayTo + '/' + yearTo)) {
                    cvValidateDate.errormessage = 'End Date should not be greater then Start Date.';
                    args.IsValid = false;
                }
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Control Important Dates">
        <table class="AppFormTable">
            <tr>
                <td align="right" colspan="4">
                    <div class="row">
                        <div class="col-4 col-lg-3 pt-2">
                            Activity Details
                        </div>
                        <div class="col-8 col-lg-9 text-left">
                            <asp:TextBox ID="txtActivity" runat="server" MaxLength="10000" Width="95%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvActivity" runat="server" ControlToValidate="txtActivity" Display="None" ErrorMessage="Please Enter Activity Details."></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </td>

            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6">
                                    Start Date
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtStartDate" runat="server" MaxLength="10" Width="85%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ErrorMessage="Please Enter Start Date." ControlToValidate="txtStartDate" Display="none"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvStartDate" runat="server" ControlToValidate="txtStartDate" ClientValidationFunction="isStartDateValid" Display="None" ErrorMessage="Please Enter Proper Start Date."></asp:CustomValidator>
                                    <asp:CustomValidator ID="cvValidateDate" runat="server" ClientValidationFunction="validateDate" Display="None" ErrorMessage=""></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6">
                                    Start Time
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtStartTime" runat="server" MaxLength="50" Width="85%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6">
                                    Activity End Date
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtEndDate" runat="server" MaxLength="10" Width="85%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ErrorMessage="Please Enter End Date." ControlToValidate="txtEndDate" Display="none"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvEndDate" runat="server" ControlToValidate="txtEndDate" ClientValidationFunction="isEndDateValid" Display="None" ErrorMessage="Please Enter Proper End Date."></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6">
                                    Activity End Time
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtEndTime" runat="server" MaxLength="50" Width="85%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6">
                                    Display Start Date Time
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtDisplayStartDateTime" runat="server" Width="85%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvDisplayStartDateTime" runat="server" ErrorMessage="Please Enter Display Start Date Time." ControlToValidate="txtDisplayStartDateTime" Display="none"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-4 col-lg-6">
                                    Display End Date Time
                                </div>
                                <div class="col-8 col-lg-6 text-left">
                                    <asp:TextBox ID="txtDisplayEndDateTime" runat="server" Width="85%"></asp:TextBox>
                                    <font color="red"><sup>*</sup></font>
                                    <asp:RequiredFieldValidator ID="rfvDisplayEndDateTime" runat="server" ErrorMessage="Please Enter Display End Date Time." ControlToValidate="txtDisplayEndDateTime" Display="none"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <div class="row w-100 mx-auto">
                        <div class="col-4 col-lg-3">
                            Activity Type
                        </div>
                        <div class="col-8 col-lg-9 text-left">
                            <asp:DropDownList ID="ddlActivityType" runat="server">
                                <asp:ListItem Value="0">-- Select Activity --</asp:ListItem>
                                <asp:ListItem Value="General">General for All</asp:ListItem>
                                <asp:ListItem Value="JK">Others</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvActivityType" runat="server" ControlToValidate="ddlActivityType" ErrorMessage="Please Select Activity Type." Operator="NotEqual" ValueToCompare="0" Display="none"></asp:CompareValidator>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="InputButton" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="InputButton" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" BackColor="#F6223F" OnClick="btnCancel_Click" ValidationGroup="Cancel" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="Cancel" />
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnActivityID" runat="server" />
    </cc1:ContentBox>
    <br />
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Important Dates List">
        <asp:GridView ID="gvImportantDatesList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" CssClass="DataGrid" OnRowDeleting="gvImportantDatesList_RowDeleting" OnSelectedIndexChanging="gvImportantDatesList_SelectedIndexChanging">
            <Columns>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblActivityID" runat="server" Text='<%# Eval("ActivityID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Sr. No." HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ActivityDetails" HeaderText="Activity" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="53%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FirstDate" HeaderText="First Date" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="LastDate" HeaderText="Last Date" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:CommandField ShowSelectButton="True" HeaderText="Edit" SelectText="Edit">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle ForeColor="Blue" />
                </asp:CommandField>
                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle ForeColor="Blue" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        var dp_calStartDate;
        var dp_calEndDate;
        window.onload = function () {
            dp_calStartDate = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtStartDate'));
            dp_calEndDate = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtEndDate'));
        };
    </script>
    <script type="text/javascript">
        function activityDisplayStartDateTime(ActivityDisplayStartDateTime) {
            document.getElementById("rightContainer_ContentTable2_txtDisplayStartDateTime").value = moment(ActivityDisplayStartDateTime).format('DD/MM/YYYY HH:mm');
        }
        function activityDisplayEndDateTime(ActivityDisplayEndDateTime) {
            document.getElementById("rightContainer_ContentTable2_txtDisplayEndDateTime").value = moment(ActivityDisplayEndDateTime).format('DD/MM/YYYY HH:mm');
        }

        jQuery(document).ready(function () {
            $('#rightContainer_ContentTable2_txtDisplayStartDateTime').datetimepicker({
                dayOfWeekStart: 1,
                lang: 'en',
                startDate: new Date(),
                format: 'd/m/Y H:i',
                formatTime: 'g:i A',
                ampm: true,
                pick12HourFormat: true
            });

            $('#rightContainer_ContentTable2_txtDisplayEndDateTime').datetimepicker({
                dayOfWeekStart: 1,
                lang: 'en',
                startDate: new Date(),
                format: 'd/m/Y H:i',
                formatTime: 'g:i A',
                ampm: true,
                pick12HourFormat: true

            });
            $('#rightContainer_ContentTable2_btnUpdate').click(function () {
                $('#rightContainer_ContentTable2_hdnStartDateTime').val($('#txtDisplayStartDateTime').val());
                $('#rightContainer_ContentTable2_hdnEndDateTime').val($('#txtDisplayEndDateTime').val());
            });

            $('#rightContainer_ContentTable2_btnAdd').click(function () {
                $('#rightContainer_ContentTable2_hdnStartDateTime').val($('#txtDisplayStartDateTime').val());
                $('#rightContainer_ContentTable2_hdnEndDateTime').val($('#txtDisplayEndDateTime').val());
            });
        });
    </script>
</asp:Content>
