<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" CodeBehind="frmShortListOptions.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound3.frmShortListOptions" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_ContentTable1_gvOptionsList input[type='checkbox'] {
            width: 20px;
            height: 20px;
        }

        #rightContainer_ContentTable1_gvSelectedOptionsList input[type='checkbox'] {
            width: 20px;
            height: 20px;
        }

        #layoutSidenav #layoutSidenav_content {
            margin-left: unset !important;
        }

        #rightContainer_ContentTable1_gvSelectedOptionsList input[type='checkbox'] {
            width: 20px;
            height: 20px;
        }

        #rightContainer_ContentBox1_ContentBoxOverlayTwo {
            position: fixed !important;
        }

        #rightContainer_ContentBox1 {
            position: fixed !important;
            top: 10% !important;
            width: 80%;
            z-index: 2000 !important;
        }

        @media screen and (max-width:768px) {
            #rightContainer_ContentBox1 {
                top: 10% !important;
                width: 90%;
            }
        }
    </style>
    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/ContentBox.js"></script>
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            var success = document.getElementById('<%= hdnStepID.ClientID%>').value;
            for (var i = 1; i <= success; i++) {
                $('#nav' + i).addClass('sf-success');
            }
        });
    </script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function highlightRow() {
            if (event.srcElement.parentNode.parentNode.className != "SelectedRow") {
                event.srcElement.parentNode.parentNode.className = "SelectedRow";
            }
            else {
                event.srcElement.parentNode.parentNode.className = "";
            }
        }
        function openPopUpBox() {
            document.getElementById("<%=ContentBox1.ClientID %>").Show('#000000', true);
        }
    </script>
    <cc1:ContentBox ID="cbMenu" runat="server" HeaderVisible="false">
        <center>
            <div class="stepsForm">
                <div class="sf-steps">
                    <div class="sf-steps-content">
                        <div id="nav1" class="sf-active">
                            <span>1</span><a id="a_1" runat="server" class="formWizard" href="frmShortListOptions.aspx?tms=101">Shortlist Your Options</a>
                        </div>
                        <div id="nav2">
                            <span>2</span><a id="a_2" runat="server" class="formWizard" href="frmSetPreferences.aspx?tms=101">Set Your Preferences</a>
                        </div>
                        <div id="nav3">
                            <span>3</span><a id="a_3" runat="server" class="formWizard" href="frmOptionFormSummary.aspx?tms=101">Option Form Summary</a>
                        </div>
                        <div id="nav4">
                            <span>4</span><a id="a_4" runat="server" class="formWizard" href="frmConfirmOptionForm.aspx?tms=101">Confirm Your Option Form</a>
                        </div>
                    </div>
                </div>
            </div>
        </center>
        <input type="hidden" id="hdnStepID" runat="server" />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Shortlist Your Options">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <asp:Button ID="btnViewInformation" runat="server" Text="View Personal Information & Important Instructions" CssClass="InputButton" BackColor="#5cb85c" OnClientClick="openPopUpBox();" OnClick="btnViewInformation_click" CausesValidation="false"></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel runat="server" ID="upShortListOptions">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td colspan="2" align="right">Select Course Name</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlCourse" runat="server"></asp:DropDownList>
                            <asp:CompareValidator ID="cvCourse" runat="server" ControlToValidate="ddlCourse" Display="None" ErrorMessage="Please Select Course." Operator="NotEqual" ValueToCompare="0" ValidationGroup="Search"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;" align="right">Select University</td>
                        <td style="width: 30%;">
                            <asp:DropDownList ID="ddlUniversity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUniversity_SelectedIndexChanged" Width="100%"></asp:DropDownList></td>
                        <td style="width: 25%;" align="right">Select District</td>
                        <td style="width: 25%;">
                            <asp:DropDownList ID="ddlDistrict" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">Select Course Status</td>
                        <td>
                            <asp:DropDownList ID="ddlCourseStatus1" runat="server"></asp:DropDownList></td>
                        <td align="right">Select Course Autonomy Status</td>
                        <td>
                            <asp:DropDownList ID="ddlCourseStatus2" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">Select Course Minority Status</td>
                        <td>
                            <asp:DropDownList ID="ddlCourseStatus3" runat="server"></asp:DropDownList></td>
                        <td align="right">Select TFWS Status</td>
                        <td>
                            <asp:DropDownList ID="ddlTFWSStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTFWSStatus_SelectedIndexChanged">
                                <asp:ListItem Value="A">All</asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Button ID="btnSearch" runat="server" Text="Search Institute" CssClass="InputButton" OnClick="btnSearch_click" ValidationGroup="Search" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="Search" />
                        </td>
                    </tr>
                    <tr id="TFSWNOT" runat="server" visible="false">
                        <td align="center" colspan="4">
                            <font color="red"><b>Note :</b>TFWS choice code allotted candidate can not change their course in 2nd year.</font>
                        </td>
                    </tr>
                </table>
                <br />
                <table id="tblSelectOptions" runat="server" class="AppFormTable">
                    <tr>
                        <td align="right">
                            <br />
                            <asp:Button ID="btnAdopt" runat="server" Text="ADD Selected Options" CssClass="InputButton" BackColor="#5cb85c" OnClick="btnAddSelectedOptions_click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <th align="left"><font size="2">Select Options of Your Choice</font></th>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvOptionsList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" BorderWidth="1" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField HeaderText="Sr. No.">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" HtmlEncode="false">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="52%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UniversityName" HeaderText="University Name">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="24%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="9%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAddOptions" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChoiceCode" runat="server" Text='<%# Eval("ChoiceCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <br />
                            <asp:Button ID="btnAddSelectedOptions" runat="server" Text="ADD Selected Options" CssClass="InputButton" BackColor="#5cb85c" OnClick="btnAddSelectedOptions_click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
                <table id="tblMsg" runat="server" class="AppFormTable">
                    <tr>
                        <th height="60" align="center" valign="middle">
                            <asp:Label ID="lblMessage" runat="server" Text="No More Options Available for this Search Criteria" Font-Bold="True" Font-Size="Small"></asp:Label>
                        </th>
                    </tr>
                </table>
                <br />
                <table id="tblSelectedOptions" runat="server" class="AppFormTable" style="background-color: #eaeaea">
                    <tr>
                        <th align="left"><font size="2">Your Shortlisted Options</font></th>
                    </tr>

                    <tr>
                        <td>
                            <asp:GridView ID="gvSelectedOptionsList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" BorderWidth="1" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField HeaderText="Sr. No.">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" HtmlEncode="false">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="38%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UniversityName" HeaderText="University Name">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="19%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseType" HeaderText="SL / HU / OHU">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="18%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkDeleteOptions" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChoiceCode" runat="server" Text='<%# Eval("ChoiceCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <br />
                            <asp:Button ID="btnDeleteSelectedOptions" runat="server" Text="Delete Selected Options" CssClass="InputButton" BackColor="#d9332c" CausesValidation="false" OnClick="btnDeleteSelectedOptions_click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

        <table class="AppFormTableWithOutBorder" style="background-color: #eaeaea">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" /></td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox1" runat="server" BoxType="PopupBox" BackColor="#e7fafe" Height="430px" ScrollBars="Auto" HeaderText="Personal Information & Important Instructions">
        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
            <ContentTemplate>
                <table class="AppFormTable" style="background-color: #e7fafe;">
                    <tr>
                        <th colspan="4" align="left">Personal Information</th>
                    </tr>
                    <tr>
                        <td style="width: 20%" align="right">Application ID</td>
                        <td style="width: 30%">
                            <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
                        <td style="width: 20%" align="right">Candidate Name</td>
                        <td style="width: 30%">
                            <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Gender</td>
                        <td>
                            <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
                        <td align="right">Date of Birth</td>
                        <td>
                            <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Candidature Type</td>
                        <td>
                            <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
                        <td align="right">Home University</td>
                        <td>
                            <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Category for Admission</td>
                        <td>
                            <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label></td>
                        <td align="right">Person with Disability</td>
                        <td>
                            <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Applied for EWS </td>
                        <td>
                            <asp:Label ID="lblAppliedforEWS" runat="server" Font-Bold="true"></asp:Label></td>
                        <td align="right">Applied for Orphan </td>
                        <td>
                            <asp:Label ID="lblAppliedforOrphan" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Defence Type</td>
                        <td>
                            <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label></td>
                        <td align="right">Applied for TFWS</td>
                        <td>
                            <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Minority Candidature Type</td>
                        <td colspan="3">
                            <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">Important Instructions</th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <ol class="list-text">
                                <li><p align = "justify">SL - State Level.</p></li>
                                <li><p align = "justify">HU - Home University.</p></li>
                                <li><p align = "justify">OHU - Other than Home University.</p></li>
                                <asp:Label id="lblChoiceCodeStatus" runat="server"></asp:Label>
                                <li><p align = "justify">Select Course Name, University, District, Status, Autonomy Status and Minority Status and Click on 'Search Institute' Button. A list of all Institutes under that Course will be displayed.</p></li>
                                <li><p align = "justify">After selecting Institutes Click on 'Add Selected Options' Button.</p></li>
                                <li><p align = "justify">In case you want to remove some options selected by you, then click on check box given in front of Institutes in 'Your Shortlisted Options'. After selecting Institutes Click on 'Delete Selected Options' Button.</p></li>
                                <li><p align = "justify">After shortlisting your all options, click on 'Save & Proceed' Button.</p></li>
                                <li><p align = "justify"><b>TFWS</b> - Tuition Fee Waiver Scheme. Seats available for admission as per AICTE's Tuition Fee Waiver Scheme under this course.</p></li>
                            </ol>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>


