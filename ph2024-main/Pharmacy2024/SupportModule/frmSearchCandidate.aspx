<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" CodeBehind="frmSearchCandidate.aspx.cs" Inherits="Pharmacy2024.SupportModule.frmSearchCandidate" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .AppFormTable input {
            height: 25px !important;
        }

        @media only screen and (width: 320px) {
            #layoutSidenav {
                margin-top: 65.5% !important;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 88% !important;
            }
        }

        @media only screen and (max-width: 425px) {
            #layoutSidenav {
                margin-top: 48.5%;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 80%;
            }
        }

        @media only screen and (width: 768px) {
            #layoutSidenav {
                margin-top: 14% !important;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 46%;
            }
        }
    </style>
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
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
        function makeUpper() {
            document.getElementById("rightContainer_ContentTable2_txtCandidateName").value = document.getElementById("rightContainer_ContentTable2_txtCandidateName").value.toUpperCase();
            document.getElementById("rightContainer_ContentTable2_txtFatherName").value = document.getElementById("rightContainer_ContentTable2_txtFatherName").value.toUpperCase();
            document.getElementById("rightContainer_ContentTable2_txtMotherName").value = document.getElementById("rightContainer_ContentTable2_txtMotherName").value.toUpperCase();
        }
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtDOB").value;
            if (dateStr.length == 0) {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat);
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
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Search Candidate">
        <table class="AppFormTable">
            <tr>
                <th colspan="7" align="left">Enter the following Information</th>
            </tr>
            <tr align="center">
                <td>Application ID</td>
                <td>Candidate's Name</td>
                <td>Father's Name</td>
                <td>Mother's Name</td>
                <td>DOB (DD/MM/YYYY)</td>
                <td>Mobile</td>
                <td>Email Id </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:TextBox ID="txtApplicationID" runat="server" Width="120px" MaxLength="300" ></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtCandidateName" runat="server" Width="200px" MaxLength="300" onKeyPress="return charonly(event)"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="revCandidateName" runat="server" ControlToValidate="txtCandidateName" Display="None" ErrorMessage="Candidate's Name must contain only alphabets,' and space." ValidationExpression="[a-zA-Z' ]+"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtFatherName" runat="server" Width="120px" MaxLength="300" onKeyPress="return charonly(event)"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="revFatherName" runat="server" ControlToValidate="txtFatherName" Display="None" ErrorMessage="Father's Name must contain only alphabets,' and space." ValidationExpression="[a-zA-Z' ]+"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtMotherName" runat="server" Width="120px" MaxLength="300" onKeyPress="return charonly(event)"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="revMotherName" runat="server" ControlToValidate="txtMotherName" Display="None" ErrorMessage="Mother's Name must contain only alphabets,' and space." ValidationExpression="[a-zA-Z' ]+"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" Width="120px"></asp:TextBox>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper DOB."></asp:CustomValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" Width="120px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo"
                        Display="None" ErrorMessage="Mobile No Should be Proper and of 10 Digits." ValidationExpression="^[1-9]\d{9}$"></asp:RegularExpressionValidator>

                </td>
                <td>
                    <asp:TextBox ID="txtemail" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEMailID" runat="server" ControlToValidate="txtemail"
                        Display="None" ErrorMessage="Please Enter Valid E-Mail ID." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" CssClass="InputButton" OnClick="btnSubmit_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvReport" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No." ItemStyle-Width="5%" ItemStyle-CssClass="Item" HeaderStyle-CssClass="Header" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataTextField="ApplicationNo" DataNavigateUrlFields="PersonalID" DataNavigateUrlFormatString="frmApplicationDetails.aspx?PID={0}" HeaderText="ApplicationID">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Footer" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="PersonalID" HeaderText="Course Name" Visible="false">
                    <ItemStyle HorizontalAlign="Left" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Left" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="DOB" HeaderText="DOB">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="MotherName" HeaderText="Mother Name" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>               
                   <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                   <asp:BoundField DataField="EMailID" HeaderText="Email" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                  <asp:BoundField DataField="ApplicationStatus" HeaderText="Application Status" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>

            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDOB'));
        };
    </script>
</asp:Content>

