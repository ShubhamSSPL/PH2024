<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" CodeBehind="frmInsertChoiceCodeDirect.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound2.frmInsertChoiceCodeDirect" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>      
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
        .Optionfrmbtn1 {
            width: auto;
            margin-right: 5px;
            margin-bottom: 0.5rem;
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
        function openPopUpBox() {
            document.getElementById("<%=ContentBox1.ClientID %>").Show('#000000', true);
        }
    </script>
    <cc1:ContentBox ID="cbMenu" runat="server" HeaderVisible="false">
        <center>
            <div class="stepsForm">
                <div class="sf-steps">
                    <div class="sf-steps-content">
                        <div id="nav1">
                            <span>1</span><a id="a_1" runat="server" class="formWizard" href="frmShortListOptions.aspx?tms=101">Shortlist Your Options</a>
                        </div>
                        <div id="nav2">
                            <span>2</span><a id="a_2" runat="server" class="formWizard" href="frmSetPreferences.aspx?tms=101">Set Your Preferences</a>
                        </div>
                        <div id="nav3" class="sf-active">
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
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Insert Choice Code">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <div class="row w-100 mx-auto">
                        <div class="col-sm-5 px-0">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                <ContentTemplate>
                                    <asp:Button ID="btnViewInformation" runat="server" Text="View Personal Information & Important Instructions" CssClass="InputButton" BackColor="#5cb85c" OnClientClick="openPopUpBox();" OnClick="btnViewInformation_click" CausesValidation="false"></asp:Button>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-7 text-md-right px-0">
                            <asp:Button ID="btnInsert" runat="server" Text="Insert Choice Code" CssClass="InputButton Optionfrmbtn1" BackColor="#d9332c" OnClick="btnInsert_Click" CausesValidation="false"></asp:Button>

                            <asp:Button ID="btnMove" runat="server" Text="Move Choice Code" CssClass="InputButton Optionfrmbtn1" BackColor="#d9332c" OnClick="btnMove_Click" CausesValidation="false"></asp:Button>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upInsertOptions">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 40%;" align="right">Enter Choice Code</td>
                        <td style="width: 60%;">
                            <asp:TextBox ID="txtChoiceCode" runat="server" MaxLength="12" Width="120px"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:Button ID="btnVerifyChoiceCode" runat="server" Text="Verify Choice Code" CssClass="InputButton mt-2" BackColor="Red" OnClick="btnVerifyChoiceCode_Click" />
                            <asp:RequiredFieldValidator ID="rfvChoiceCode" runat="server" ControlToValidate="txtChoiceCode" Display="None" ErrorMessage="Please Enter Choice Code." ValidationGroup="Insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trInstituteName" runat="server" visible="false">
                        <td align="right">Institute Name</td>
                        <td>
                            <asp:Label ID="lblInstituteName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trCourseName" runat="server" visible="false">
                        <td align="right">Course Name</td>
                        <td>
                            <asp:Label ID="lblCourseName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trInvalid" runat="server" visible="false">
                        <td colspan="2" align="center">
                            <asp:Label ID="lblInvalid" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Select Preference Number at which you want to Insert</td>
                        <td>
                            <asp:DropDownList ID="ddlPreferenceNo" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                        </td>
                    </tr>
                </table>
                <br />
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnInsertDirect" runat="server" Text="Insert Choice Code" CssClass="InputButton" BackColor="#5cb85c" OnClick="btnInsertDirect_click" ValidationGroup="Insert" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="Insert" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <div class="table-responsive">
                    <table id="tblPreferencedOptionsList" runat="server" class="AppFormTable">
                        <tr>
                            <th align="left"><font size="2">Your Preferenced Choice Codes List</font></th>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvPreferencedOptionsList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" BorderWidth="1" CssClass="DataGrid">
                                    <Columns>
                                        <asp:BoundField DataField="PreferenceNo" HeaderText="Preference Number">
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
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table class="AppFormTableWithOutBorder">
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
                                <li>
                                    <p align="justify">SL - State Level.</p>
                                </li>
                                <li>
                                    <p align="justify">HU - Home University.</p>
                                </li>
                                <li>
                                    <p align="justify">OHU - Other than Home University.</p>
                                </li>
                                <asp:Label ID="lblChoiceCodeStatus" runat="server"></asp:Label>
                            </ol>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>


