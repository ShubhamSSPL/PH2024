<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSearchCandidate.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmSearchCandidate" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/epoch_classes.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function charonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if ((unicode != 8) && (unicode != 32) && (unicode != 39)) {
                if ((unicode < 65 || unicode > 90) && (unicode < 96 || unicode > 122)) {
                    return false
                }
            }
        }
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        function makeUpper() {
            document.getElementById("ctl00_rightContainer_ContentTable1_txtCandidateName").value = document.getElementById("ctl00_rightContainer_ContentTable1_txtCandidateName").value.toUpperCase();
        }
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("ctl00_rightContainer_ContentTable1_txtDOB").value;
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
    </script>
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <img src="../Images/BigProgress.gif" alt="" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upHomeUniversity">
    <ContentTemplate>
    <ccb:ContentBox ID="ContentTable1" runat="server" HeaderText="Search Candidate">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <p align="justify"><font color="red"><b>Instructions :</b></font></p>
                        <ul class="list-text">
                            <li>
                                <p align="justify"><font color="red">Please Enter Application No and/or Candidate's Name and/or DOB and/or Mobile No. and/or E-Mail ID to Search Candidate.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Please Enter atleast one parameter.</font></p>
                            </li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable">
             <tr>
                <td style="width: 25%" align="right"><b>Application ID</b></td>
                <td>
                    <asp:TextBox ID="txtApplicationNo" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revApplicationNo" runat="server" ControlToValidate="txtApplicationNo" Display="None" ErrorMessage="Application ID should be proper." ValidationExpression="^[A-Za-z]{2}23[0-9]{5,}$"></asp:RegularExpressionValidator>
                </td>
                <td align="right" style="width: 25%"><b>DOB (DD/MM/YYYY)</b></td>
                <td style="width: 25%">
                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper DOB."></asp:CustomValidator>
                </td>

            </tr>
            <tr>
                <td style="width: 25%" align="right"><b>Candidate's Name</b></td>
                <td colspan="3">
                    <asp:TextBox ID="txtCandidateName" runat="server" Width="300px" MaxLength="300" onKeyPress="return charonly(event)"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revCandidateName" runat="server" ControlToValidate="txtCandidateName" Display="None" ErrorMessage="Candidate's Name must contain only alphabets,' and space." ValidationExpression="[a-zA-Z' ]+"></asp:RegularExpressionValidator>
                </td>

            </tr>
            <tr>
                <td align="right"><b>Mobile No</b></td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="None" ErrorMessage="Mobile No Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                </td>
                <td align="right"><b>E-Mail ID</b></td>
                <td>
                    <asp:TextBox ID="txtEMailID" runat="server" MaxLength="100"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEMailID" runat="server" ControlToValidate="txtEMailID" Display="None" ErrorMessage="Please Enter Valid E-Mail ID." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="btnSearch" runat="server" Text="Search Candidate" CssClass="InputButton" OnClick="btnSearch_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
    </ccb:ContentBox>
    <ccb:ContentBox ID="ContentBox2" runat="server" Visible="false" HeaderText="Candidate Details">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <p align="justify"><font color="red"><b>Instructions :</b></font></p>
                        <ul class="list-text">
                            <li>
                                <p align="justify"><font color="red">Please Click on Application ID to Print Application Form.</font></p>
                            </li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvApplicationDetails" ShowFooter="false" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="12%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="35%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="DOB" HeaderText="DOB">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationStatus" HeaderText="Application Status">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="35%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </ccb:ContentBox>
    <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script language="javascript" type="text/javascript">
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('ctl00_rightContainer_ContentTable1_txtDOB'));
        };
    </script>
</asp:Content>
