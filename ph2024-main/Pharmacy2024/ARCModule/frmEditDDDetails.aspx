<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditDDDetails.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmEditDDDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/epoch_classes_current.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        function isDDDateValid(sender, args) {
            var dateStr = document.getElementById("ctl00_rightContainer_ContentTable2_txtDDDate").value;
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
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            if (document.getElementById('ctl00_rightContainer_ContentTable2_tblDDDetails') != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable2_txtDDDate'));
            }
        }
        window.onload = load;
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Edit DD Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upQualification">
            <ContentTemplate>
                <table id="tblDDDetails" runat="server" class="AppFormTable">
                    <tr>
                        <td style="width: 40%" align="right">DD Amount (<span class="rupee">Rs.</span>)</td>
                        <td style="width: 60%">
                            <asp:TextBox ID="txtDDAmount" runat="server" Enabled="false" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvDDAmount" runat="server" ErrorMessage="Please Enter DD Amount." ControlToValidate="txtDDAmount" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">DD Number</td>
                        <td>
                            <asp:TextBox ID="txtDDNumber" runat="server" MaxLength="6" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvDDNo" runat="server" ErrorMessage="Please Enter DD Number." ControlToValidate="txtDDNumber" Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revDDNo" runat="server" ErrorMessage="DD Number should be Numeric and of 6 Digits." ControlToValidate="txtDDNumber" ValidationExpression="\d{6}" Display="None"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">DD Date</td>
                        <td>
                            <asp:TextBox ID="txtDDDate" runat="server" MaxLength="10"></asp:TextBox>
                            <font color="red"><b>*</b></font> (DD/MM/YYYY)
                            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="Please Enter DD Date." ControlToValidate="txtDDDate" Display="None"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvDDDate" runat="server" ControlToValidate="txtDDDate" ClientValidationFunction="isDDDateValid" Display="None" ErrorMessage="Please Select Proper DD Date."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Bank Name</td>
                        <td>
                            <asp:DropDownList ID="ddlBankName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBankName_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red">*</font>
                            <asp:CompareValidator ID="cvBankName" runat="server" ControlToValidate="ddlBankName" ErrorMessage="Please Select Bank Name." ValueToCompare="0" Operator="NotEqual" Display="None"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trOtherBankName" runat="server">
                        <td align="right">Other Bank Name</td>
                        <td>
                            <asp:TextBox ID="txtOtherBankName" runat="server" MaxLength="100"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvOtherBankName" runat="server" ErrorMessage="Please Enter Other Bank Name." ControlToValidate="txtOtherBankName" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Branch Name</td>
                        <td>
                            <asp:TextBox ID="txtBranchName" runat="server" MaxLength="100"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvBranchName" runat="server" Display="None" ControlToValidate="txtBranchName" ErrorMessage="Please Enter Branch Name."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" CssClass="InputButton" OnClick="btnUpdate_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CssClass="InputButton" OnClick="btnCancel_Click" ValidationGroup="Cancel" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                            <asp:HiddenField ID="hdnFeeID" runat="server" />
                        </td>
                    </tr>
                </table>
                <table class="AppFormTable">
                    <tr>
                        <th style="border-top-width: 0px;" colspan="2" align="left">List of DDs</th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvDDList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" BorderWidth="1" OnSelectedIndexChanging="gvDDList_SelectedIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="FeeType" HeaderText="Fee Type">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="20%" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DDAmount" HeaderText="DD Amount">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="10%" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DDNumber" HeaderText="DD Number">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="10%" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DDDate" HeaderText="DD Date">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="10%" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BankName" HeaderText="Bank Name">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="25%" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FeeLockStatus" HeaderText="DD Status">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="20%" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Edit" SelectText="Edit">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                    </asp:CommandField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFeeID" runat="server" Text='<%# Eval("FeeID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <script language="javascript" type="text/javascript">
            if (document.getElementById('ctl00_rightContainer_ContentTable2_tblDDDetails') != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable2_txtDDDate'));
            }
        </script>
    </cc1:ContentBox>
</asp:Content>
