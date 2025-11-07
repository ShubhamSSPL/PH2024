<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmControlReportQuery.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmControlReportQuery" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="ControlReportQuery" ContentPlaceHolderID="rightContainer" runat="Server">
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <img src="../Images/BigProgress.gif" alt="" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upHomeUniversity">
        <ContentTemplate>
            <cc1:ContentBox ID="cbControlReportQuery" runat="server" HeaderText="Control Report Query">
                <style type="text/css">
                    .fk-fail-msg {
                        background: url("../Images/1420553413_678069-sign-error-16.png") no-repeat scroll 5px 10px #FCC;
                        border: 1px solid #F00;
                        color: black;
                        font-size: 13px;
                        padding: 10px 0 10px 30px;
                        text-align: left;
                        text-transform: Capitalize;
                    }
                </style>
                <script type="text/javascript" src="../Scripts/jquery-1.11.2.min.js"></script>
                <script type="text/javascript">
                    function pageLoad() {
                        var txtAreaQuery = document.getElementById('ctl00_rightContainer_cbControlReportQuery_txtReportQuery');
                        $(txtAreaQuery).blur(function (e) {
                            ExecuteSQL(event);
                        });
                        $('#ctl00_rightContainer_cbControlReportQuery_btnAdd').click(function (event) {
                            ExecuteSQL(event);
                        });
                    }
                    function ExecuteSQL(event) {
                        var anyErrorSQLFlag = "No-Error";
                        var rejectedkeywords = $('#ctl00_rightContainer_cbControlReportQuery_rejectedkeywordlist').text().split(',');
                        var SQLQuery = $('#ctl00_rightContainer_cbControlReportQuery_txtReportQuery').val().toUpperCase();

                        for (var i = 0; i < SQLQuery.length; i++) {
                            if ((SQLQuery.charCodeAt(i) >= 65 && SQLQuery.charCodeAt(i) <= 90) || (SQLQuery.charCodeAt(i) >= 97 && SQLQuery.charCodeAt(i) <= 122) || (SQLQuery.charCodeAt(i) >= 48 && SQLQuery.charCodeAt(i) <= 57)) {
                            }
                            else {
                                SQLQuery = SQLQuery.substr(0, i) + ' ' + SQLQuery.substr(i + 1);
                            }
                        }
                        console.log(SQLQuery);
                        if (SQLQuery.length > 0) {
                            var QueryWords = SQLQuery.split(' ');
                            for (var i = 0; i < QueryWords.length; i++) {
                                for (var j = 0; j < rejectedkeywords.length; j++) {
                                    if (QueryWords[i] === rejectedkeywords[j]) {
                                        $('#ctl00_rightContainer_cbControlReportQuery_error').css('margin-top', '10px');
                                        $('.fk-fail-msg').html("<b>Please Don't Use Keyword " + QueryWords[i] + "</b>");
                                        $('.FindErrorByUsingScript').show('blind');
                                        anyErrorSQLFlag = "Error";
                                        $('#ctl00_rightContainer_cbControlReportQuery_txtReportQuery').val($('#ctl00_rightContainer_cbControlReportQuery_txtReportQuery').text().replace(rejectedkeywords[i], ''));
                                        event.preventDefault();
                                    }
                                }
                            }
                            setTimeout(function () { $(".FindErrorByUsingScript").hide('blind'); }, 3000);
                        }
                    }
                </script>
                <div id="rejectedkeywordlist" runat="server" style="display: none;"></div>
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 20%;" align="right">Report Name</td>
                        <td style="width: 80%;">
                            <asp:TextBox ID="txtReportName" runat="server" MaxLength="500" Width="70%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvReportName" runat="server" ControlToValidate="txtReportName" Display="None" ErrorMessage="Please Enter Report Name."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Select Table/View</td>
                        <td>
                            <div id="QuerySelect">
                                <asp:DropDownList ID="ddlTableView" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTableView_SelectedIndexChanged"></asp:DropDownList></div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Report Query</td>
                        <td>
                            <asp:TextBox ID="txtReportQuery" runat="server" MaxLength="8000" Width="70%" TextMode="MultiLine" Height="200px"></asp:TextBox>
                            <asp:ListBox ID="lbColumn" runat="server" Height="200px" Width="28%" Font-Size="Smaller"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvReportQuery" runat="server" ControlToValidate="txtReportQuery" Display="None" ErrorMessage="Please Enter Report Query."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="InputButton" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="InputButton" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" BackColor="#F6223F" OnClick="btnCancel_Click" ValidationGroup="Cancel" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div id="ScrollgvResultSet" runat="Server"></div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="FindErrorByUsingScript" style="display: none;">
                            <div class="fk-fail-msg" id="error" style="position: relative;"></div>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnReportID" runat="server" />
            </cc1:ContentBox>
            <br />
            <cc1:ContentBox ID="cbReportsList" runat="server" HeaderText="Reports List">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" CssClass="DataGrid" OnRowDeleting="gvList_RowDeleting" OnSelectedIndexChanging="gvList_SelectedIndexChanging" OnRowCommand="gvList_RowCommand">
                    <columns>
                        <asp:BoundField HeaderText="Sr. No.">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReportName" HeaderText="Report Name">
                            <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="70%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                        </asp:BoundField>
                        <asp:ButtonField CommandName="Excel" HeaderText="Excel" Text="Excel">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                            <ControlStyle ForeColor="Blue" />
                        </asp:ButtonField>
                        <asp:CommandField ShowSelectButton="True" HeaderText="Edit" SelectText="Edit">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                            <ControlStyle ForeColor="Blue" />
                        </asp:CommandField>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                            <ControlStyle ForeColor="Blue" />
                        </asp:CommandField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblReportID" runat="server" Text='<%# Eval("ReportID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </columns>
                </asp:GridView>
            </cc1:ContentBox>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
