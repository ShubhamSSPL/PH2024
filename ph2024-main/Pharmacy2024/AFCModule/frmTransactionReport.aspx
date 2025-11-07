<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmTransactionReport.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmTransactionReport" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        //    function isDOBValid(sender, args) {
        //        var dateStr = document.getElementById("ctl00_rightContainer_ContentTable1_txtStartDate").value;
        //        if (dateStr.length == 0) {
        //            args.IsValid = false;
        //            return;
        //        }
        //        var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        //        var matchArray = dateStr.match(datePat);
        //        if (matchArray == null) {
        //            args.IsValid = false;
        //            return;
        //        }
        //        month = matchArray[3];
        //        day = matchArray[1];
        //        year = matchArray[5];
        //        if (year < 1900 || year >= 2080) {
        //            args.IsValid = false;
        //            return;
        //        }
        //        if (month < 1 || month > 12) {
        //            args.IsValid = false;
        //            return;
        //        }
        //        if (day < 1 || day > 31) {
        //            args.IsValid = false;
        //            return;
        //        }
        //        if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
        //            args.IsValid = false;
        //            return;
        //        }
        //        if (month == 2) {
        //            var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
        //            if (day > 29 || (day == 29 && !isleap)) {
        //                args.IsValid = false;
        //                return;
        //            }
        //        }
        //    }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            if (document.getElementById('ctl00_rightContainer_ContentTable1_txtStartDate') != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable1_txtStartDate'));
            }
            if (document.getElementById('ctl00_rightContainer_ContentTable1_txtEndDate') != null) {
                var dp_cal1 = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable1_txtEndDate'));
            }
        }
        window.onload = load;
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Login Report" Width="100%">

        <table class="AppFormTable">
            <tr id="trLoginID" runat="server">
                <td align="right" style="width: 25%">Login ID</td>
                <td style="width: 25%">
                    <asp:TextBox ID="txtAppID" MaxLength="100" Text="PH19" runat="server" onmouseover="ddrivetip('Please Enter Login ID.')" onmouseout="hideddrivetip()"></asp:TextBox>
                </td>
                <td align="right" style="width: 25%">Txn Status</td>
                <td style="width: 25%">
                    <asp:DropDownList ID="ddlPaidStatus" runat="server" onmouseover="ddrivetip('Please Select Txn Status.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                </td>
            </tr>
            <tr id="tr2" runat="server">
                <td align="right" style="width: 25%">Start Date</td>
                <td style="width: 25%">
                    <asp:TextBox ID="txtStartDate" runat="server" MaxLength="10" onmouseover="ddrivetip('Please Select Start Date. It should be in DD/MM/YYYY format.')" onmouseout="hideddrivetip()"></asp:TextBox>
                </td>
                <td align="right" style="width: 25%">End Date</td>
                <td style="width: 25%">
                    <asp:TextBox ID="txtEndDate" MaxLength="10" runat="server" onmouseover="ddrivetip('Please Select End Date. It should be in DD/MM/YYYY format.')" onmouseout="hideddrivetip()"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table class="AppFormTable">
            <tr>
                <td align="center">
                    <asp:Button ID="btnGenerate" runat="server" Text="Generate" CssClass="InputButton" OnClick="btnGenerate_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>

        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:Button ID="btnexporttoExcel" runat="server" Text="Export To Excel" OnClick="btnexporttoExcel_Click" Visible="false" />
                </td>
            </tr>
        </table>

        <br />
        <asp:GridView ID="gvTransactionReport" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField DataField="TxDate" HeaderText="Txn Date">
                    <ItemStyle HorizontalAlign="Center" Width="14%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationFormNo" HeaderText="Application No">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicantName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Center" Width="16%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidatureTypeName" HeaderText="Type">
                    <ItemStyle HorizontalAlign="Center" Width="12%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CategoryName" HeaderText="Category">
                    <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PHTypeDetails" HeaderText="PH Type">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Purpose" HeaderText="Fee Type">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FeeAmount" HeaderText="Amount">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PaidStatus" HeaderText="Txn Status">
                    <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        var dp_cal;
        var dp_cal1;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable1_txtStartDate'));
            dp_cal1 = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable1_txtEndDate'));
        };
    </script>
</asp:Content>
