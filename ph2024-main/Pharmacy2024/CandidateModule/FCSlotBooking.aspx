<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="FCSlotBooking.aspx.cs" Inherits="Pharmacy2024.CandidateModule.FCSlotBooking" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_ContentTableFCVerification {
            position: fixed !important;
            top: 10% !important;
            /*left:200px !important;*/
            width: 70%;
            z-index: 2000 !important;
        }
            #rightContainer_ContentTableFCVerification .tbheight1 {
                height: 500px;
                overflow: auto;
            }
        @media only screen and (max-width: 1024px) {
            #rightContainer_ContentTableFCVerification {
                top: 10% !important;
                width: 95% !important;
            }
                #rightContainer_ContentTableFCVerification .tbheight1 {
                    height: 400px;
                    overflow: auto;
                }
        }
    </style>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/epoch_classes_furturedate.js" type="text/javascript" lang="javascript"></script>
    <script>
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentBox1_txtSlotDate").value;
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
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="true" HeaderText="Book Slot for SC Verification">
        <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 40%;">District :
                </td>
                <td>
                    <asp:DropDownList ID="ddlCDistrict" runat="server" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="ddlCDistrict_SelectedIndexChanged"></asp:DropDownList>
                    <%--<font color="red"><sup>*</sup></font>--%>
                    <asp:CompareValidator ID="cvCDistrict" runat="server" ControlToValidate="ddlCDistrict" Display="None" ErrorMessage="Please Select District." Operator="NotEqual" ValueToCompare="0" ValidationGroup="grSlotSelection"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Scrutiny Centers :
                </td>
                <td visible="false">
                    <asp:DropDownList ID="ddlFC" runat="server" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="ddlFC_SelectedIndexChanged">
                        <%--<font color="red"><sup>*</sup></font>--%>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cvFC" runat="server" ControlToValidate="ddlFC" Display="None" ErrorMessage="Please Select Scrutiny Centers." Operator="NotEqual" ValueToCompare="0" ValidationGroup="grSlotSelection"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Select Date (DD/MM/YYYY)</td>
                <td>
                    <asp:DropDownList ID="ddlDate" runat="server" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">
                        <%--<font color="red"><sup>*</sup></font>--%>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cvDate" runat="server" ControlToValidate="ddlDate" Display="None" ErrorMessage="Please Select Date." Operator="NotEqual" ValueToCompare="0" ValidationGroup="grSlotSelection"></asp:CompareValidator>
                </td>
            </tr>
        </table>
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="View Slots" CssClass="InputButton" OnClick="btnProceed_Click" ValidationGroup="grSlotSelection" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="grSlotSelection" />
                </td>
            </tr>
        </table>
        <table class="AppFormTable" runat="server" style="background: #ffeaaa; padding: 5px;">
            <tr>
                <td style="border-top-width: 0px;">
                    <p align="justify">
                        <b>Note : </b>
                        <asp:Label runat="server">NRI/PIO/OCI/CIWGC/FN candidates should send the print of online filled & confirmed application form & required documents by hand/speed post/courier for verification & confirmation to <b>“The Principal, Bombay College of Pharmacy, Kalina, Santacruz, Mumbai – 400 098“</b></asp:Label>
                    </p>
                    <%--<p align="justify"><asp:Label ID = "" runat = "server" ForeColor="red"></asp:Label></p>--%>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderVisible="true" HeaderText="Booked Slot Details for SC Verification" Visible="false">
        <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 50%;">ApplicationID :
                </td>
                <td>
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">CandidateName :
                </td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">Booked Slot  Date (DD/MM/YYYY) and Time</td>
                <td>
                    <asp:Label ID="lblSlotDateTime" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">SC Name and Address</td>
                <td>
                    <asp:Label ID="lblFCDetails" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnUpdateSlot" runat="server" Text="Re-Schedule SC Verification" CssClass="InputButton" OnClick="btnUpdateSlot_Click" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>






    <cc1:ContentBox ID="ContentTable1" runat="server" Visible="false">
        <asp:GridView ID="gvSlots" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid"
            OnRowCommand="gvSlots_RowCommand" OnRowDataBound="gvSlots_RowDataBound">
            <Columns>
                <asp:BoundField DataField="StartTime" HeaderText="Start Time - END Time" HtmlEncode="false">
                    <ItemStyle Width="20%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AvilableSlots" HeaderText="Total Slots">
                    <ItemStyle Width="10%" HorizontalAlign="center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="BookedSlots" HeaderText="Booked Slots" HtmlEncode="false">
                    <ItemStyle Width="10%" HorizontalAlign="center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="VacantSlots" HeaderText="Vacant Slots">
                    <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <%--<asp:ButtonField HeaderText="Book Slot" ButtonType="Button" CommandName="BookSlot" Text="Book Slot" ControlStyle-CssClass="InputButton" Visible="true">
                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Bottom" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle Font-Bold="True" />
                </asp:ButtonField>--%>
                <asp:TemplateField HeaderText="Book Slot">
                    <ItemTemplate>
                        <asp:Button ID="BookSlot" Text="Book Slot" CommandName="BookSlot" Visible="true" runat="server" OnClientClick="return confirm('Are You Sure You Want to Book this Slot Final Confirmation ?');" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Bottom" CssClass="Item" />
                    <ControlStyle Font-Bold="True" />
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblEndTime" runat="server" Text='<%# Eval("EndTime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblSlotId" runat="server" Text='<%# Eval("SlotId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblFCDateID" runat="server" Text='<%# Eval("FCDateID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblTimeLapsFlag" runat="server" Text='<%# Eval("TimeLapsFlag") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblEnableFlag" runat="server" Text='<%# Eval("EnableFlag") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblCoutLapsFlag" runat="server" Text='<%# Eval("CoutLapsFlag") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <script lang="javascript" type="text/javascript"> 
            function GetConfrim() {
                if (confirm("Are You Sure final confirmation ?")) {
                    return true;
                } else {
                    return false;
                }
            }
        </script>

    </cc1:ContentBox>

    <table runat="server" id="tblMsg" visible="false" class="AppFormTable">
        <tr>
            <th height="100" align="center" valign="middle">
                <asp:Label ID="lbl_message" runat="server" Text="There are No Slots Avilable for the Selected Criteria" Font-Bold="True" Font-Size="Small"></asp:Label>
            </th>
        </tr>
    </table>


    <script lang="javascript" type="text/javascript">
        var dp_cal;
        window.onload = function () {
            document.getElementById('rightContainer_ContentBox1_txtSlotDate').innerText = "";
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentBox1_txtSlotDate'));
            dp_cal.startDay.value = new Date();
        };
    </script>



    <cc1:ContentBox ID="ContentTableFCVerification" runat="server" CssClass="position-fixed" HeaderText="Select SC Verification Mode/Option" BoxType="PopupBox" Width="70%">
        <asp:Label ID="lblmessage" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
        <div class="tbheight1">
            
            <table class="AppFormTable" id="tblPScrutiny" runat="server">
                <tr>
                    <th align="left" style="background: #269226; color: White; border: 1px solid green">
                        <font size="3">Physical Scrutiny Mode - Candidate Document verification and confirmation through in person scrutiny</font>
                    </th>
                </tr>
                <tr>
                    <td style="background-color: #def3de; border: 1px solid green">
                        <%-- <p align="justify"><b>Physical Scrutiny :- Candidate Document verification and confirmation through in person scrutiny :-</b></p>--%>
                        <ol class="list-text" type="a">
                            <li>
                                <p align="justify">If the Candidate selects the mode of verification as physical scrutiny through their login.</p>
                            </li>
                            <li>
                                <p align="justify">Candidates will have to visit the Scrutiny Center in person for document verification and confirmation.</p>
                            </li>
                            <li>
                                <p align="justify">In this mode candidate will select a nearby SC center and select the available time slot for document verification and confirmation.</p>
                            </li>
                            <li>
                                <p align="justify">For any document discrepancy found, candidates can visit the SC center.</p>
                            </li>
                            <li>
                                <p align="justify">SC center will facilitate support to candidates to resolve the all discrepancy.</p>
                            </li>
                        </ol>
                        <%--<br />--%>
                        <%-- <br />--%>
                        <center>
                            <asp:Button ID="btnPScrutiny" runat="server" Text="Physical Scrutiny & Proceed >>>" CssClass="InputButton" OnClick="btnPScrutiny_Click" /></center>
                        <%--<br />--%>
                    </td>
                </tr>
            </table>
            <table class="AppFormTable" id="tblEScrutiny" runat="server">
                <tr>
                    <th align="left" style="background: #e8be42; color: White; border: 1px solid #c5b20b">
                        <font size="3">E-Scrutiny Mode - Candidate Document verification and confirmation through e-scrutiny</font>
                    </th>
                </tr>
                <tr>
                    <td style="background-color: #fffbd6; border: 1px solid #c5b20b">

                        <%--  <p align="justify"><b>e-scrutiny : -  Candidate Document verification and confirmation through e-scrutiny :-</b></p>--%>
                        <ol class="list-text" type="a">
                            <li>
                                <p align="justify">If the Candidate selects the mode of verification as e-scrutiny through their login.</p>
                            </li>
                            <li>
                                <p align="justify">Candidates will have to upload all their documents.</p>
                            </li>
                            <li>
                                <p align="justify">e-SC shall electronically verify candidate’s information and do the confirmation.</p>
                            </li>
                            <li>
                                <p align="justify">Candidates can raise their grievance online for any found discrepancy.</p>
                            </li>
                            <li>
                                <p align="justify">e-SC will Facilitate to support candidates to resolve all grievances.</p>
                            </li>
                        </ol>
                        <%--<br />--%>
                        <%--   <br />--%>
                        <center>
                            <asp:Button ID="btnEScrutiny" runat="server" Text="E-Scrutiny Mode & Proceed >>>" CssClass="InputButton" OnClick="btnEScrutiny_Click" /></center>
                        <%--<br />--%>
                    </td>
                </tr>
            </table>
        </div>
    </cc1:ContentBox>
    <script>
        function ShowFCVerificationPopUp() {
            document.getElementById('<%=ContentTableFCVerification.ClientID %>').Show('', true);
            document.getElementsByClassName("HeadDiv")[1].children[1].hidden = true;

        }
        function HideFCVerificationPopUp() {
            document.getElementById('<%=ContentTableFCVerification.ClientID %>').Hide('', true);
        }
        <%--function CustomValidator1_ClientValidate(source, args) {
            if (document.getElementById("<%= rbnEFCverification.ClientID %>").checked || document.getElementById("<%= rbnFCVerification.ClientID %>").checked) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }

        }--%>
    </script>
</asp:Content>
