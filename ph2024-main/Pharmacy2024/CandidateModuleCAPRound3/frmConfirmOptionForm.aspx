<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" CodeBehind="frmConfirmOptionForm.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound3.frmConfirmOptionForm" %>

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
    <style>
        .txtAlign {
            text-align: center;
        }

        #rightContainer_contentConfirmation {
            position: fixed !important;
            top: 20% !important;
            width: 80%;
            z-index: 2000 !important;
        }

        @media screen and (max-width:768px) {
            #rightContainer_contentConfirmation {
                top: 10% !important;
                width: auto;
            }
        }

        #rightContainer_contentConfirmation .HeadDiv a {
            display: none;
        }
    </style>
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" language="javascript"></script>
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
        function clickButton(e, buttonid) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
        function ShowConfirmationBox() {
            document.getElementById('<%=contentConfirmation.ClientID %>').Show('', true);
        }
        function checkConfirmation(Source, args) {
            var confirmationValue = confirm("I agree to Confirm my Option Form. \nI am aware that I will not be able to modify / change / alter my Choices once I confirm the Option Form.\n\nAre you sure you want to confirm your Option Form ?");
            if (confirmationValue == true) {
                var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                cvCheckConfirmation.errormessage = 'We are confirming your Option Form. Please wait...';
                args.IsValid = true;
            }
            else {
                var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                cvCheckConfirmation.errormessage = 'We are not confirming your Option Form...';
                args.IsValid = false;
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
                        <div id="nav1">
                            <span>1</span><a id="a_1" runat="server" class="formWizard" href="frmShortListOptions.aspx?tms=101">Shortlist Your Options</a>
                        </div>
                        <div id="nav2">
                            <span>2</span><a id="a_2" runat="server" class="formWizard" href="frmSetPreferences.aspx?tms=101">Set Your Preferences</a>
                        </div>
                        <div id="nav3">
                            <span>3</span><a id="a_3" runat="server" class="formWizard" href="frmOptionFormSummary.aspx?tms=101">Option Form Summary</a>
                        </div>
                        <div id="nav4" class="sf-active">
                            <span>4</span><a id="a_4" runat="server" class="formWizard" href="frmConfirmOptionForm.aspx?tms=101">Confirm Your Option Form</a>
                        </div>
                    </div>
                </div>
            </div>
        </center>
        <input type="hidden" id="hdnStepID" runat="server" />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Confirm Option Form">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <asp:Button ID="btnViewInformation" runat="server" Text="View Personal Information & Important Instructions" CssClass="InputButton" BackColor="#5cb85c" OnClientClick="openPopUpBox();" OnClick="btnViewInformation_click" CausesValidation="false"></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsert" runat="server" Text="Insert Choice Code" CssClass="InputButton" BackColor="#d9332c" OnClick="btnInsert_Click" CausesValidation="false"></asp:Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnInsertDirect" runat="server" Text="Insert Choice Code Directly" CssClass="InputButton" BackColor="#d9332c" OnClick="btnInsertDirect_Click" CausesValidation="false"></asp:Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnMove" runat="server" Text="Move Choice Code" CssClass="InputButton" BackColor="#d9332c" OnClick="btnMove_Click" CausesValidation="false"></asp:Button>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th colspan="4" align="left"><font size="2">List of Options Given By You</font></th>
            </tr>
            <tr>
                <td style="width: 25%" valign="top" align="center">
                    <asp:GridView ID="gvPreferencedOptionsList1" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField DataField="PreferenceNo" HeaderText="Preference Number">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="50%" />
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="50%" />
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 25%" valign="top" align="center">
                    <asp:GridView ID="gvPreferencedOptionsList2" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField DataField="PreferenceNo" HeaderText="Preference Number">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="50%" />
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="50%" />
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 25%" valign="top" align="center">
                    <asp:GridView ID="gvPreferencedOptionsList3" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField DataField="PreferenceNo" HeaderText="Preference Number">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="50%" />
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="50%" />
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 25%" valign="top" align="center">
                    <asp:GridView ID="gvPreferencedOptionsList4" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField DataField="PreferenceNo" HeaderText="Preference Number">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="50%" />
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="50%" />
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
             <tr>
                 
                <th colspan = "4" align = "left"><font size="2">Confirm Your Option Form</font></th>
            </tr>
            <tr>
                <td colspan = "4">
                    <p align="justify">
                        <font color="red" size="2">
                            <ol class="list-text">
                                <li>Filling up and confirmation of online option form having preferences of Courses and Institutions prior to respective CAP Rounds. Candidates may fill in preferences of Institutes and Courses in decreasing order of their preference as specified by Competent Authority. The option form once confirmed by the candidate through their login shall be considered for allotment in the respective CAP Rounds. </li>
                                <li>Candidates may fill in maximum 300 choices of Institutes and Courses in decreasing order of their preference. </li>
                                <li>In order to participate in the CAP (subject to fulfilment of the eligibility requirements of respective CAP round), it is MANDATORY to fill the Online Option Form for respective CAP Round. </li>
                                <li>It is mandatory for all eligible candidates to confirm the online option form. </li>
                                <li>After confirmation of Option form, the candidate will not be able to change the Options. </li>
                                <li>The serial number of blocks in the option form indicates preference of choice. Thus, the choice code of the institute filled by the candidate in block No. 1 will be considered as first preference (Highest Priority Choice). </li>
                                <li>Option form received through online submission only will be considered for further processing.  </li>
                                <li>Candidate shall confirm the submitted on-line Option Form by re-entering Login Password. The candidate can take a printout of the confirmed Option form for his record and future reference. </li>
                                <li>Candidates should not disclose their Application ID & Password to others to avoid impersonation. Competent Authority shall not be responsible for submissions done by others on behalf of the candidate. For Security reasons, candidates are instructed to keep changing the password and keep note of it in secured place. </li>
                            </ol>
                        </font>
                    </p>
                </td>
            </tr>

        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Confirm Option Form" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:CustomValidator ID="cvCheckConfirmation" runat="server" ClientValidationFunction="checkConfirmation" Display="None" ErrorMessage=""></asp:CustomValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
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
                                <asp:Label id="lblChoiceCodeStatus" runat="server"></asp:Label>
                                 <li><p align = "justify">Please verify the correctness of the information filled. In case of any correction, do it online before confirmation.</p></li>
                                <li><p align = "justify">You will not be able to modify preferences, add choices, delete choices after confirmation of Online Option Form.</p></li>
                                <li><p align = "justify">Your Option Form once confirmed will not be cancelled.</p></li>
                                <li><p align = "justify">Your Option Form once confirmed can not be changed.</p></li>
                                <li><p align = "justify">Once you are sure then confirm your Option Form and take print out of FINAL Receipt-Cum-Acknowledgement of Option Form. You can repeat these steps as many times as you want till you Confirm your Option Form.</p></li>
                                <li><p align = "justify">The Option Form just submitted, but not confirmed by the candidate himself/herself will not be processed for allotment for CAP Round - III.</p></li>
                            </ol>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
    <cc1:ContentBox ID="contentConfirmation" runat="server" HeaderText="Self Confirmation" BoxType="PopupBox">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td colspan="2">
                    <font color="red">
                        <p align="justify"><font color="red"><b>Note :</b></font></p>
                        <ul class="list-text">
                            <li>
                                <p align="justify"><font color="red">You have only selected TFWS choice codes. so you will be only processed for allotment in TFWS choice codes. You can also select other than TFWS choice codes. Do you want to proceed?</font></p>
                            </li>
                        </ul>
                    </font>
                </td>
            </tr>
           
            <tr runat="server" id="trYesNo">
                <td align="right">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="InputButton" OnClick="btnYes_Click" />
                    &nbsp;
                </td>
                <td align="left">&nbsp;<asp:Button ID="btnNo" runat="server" Text="No" CssClass="InputButton" OnClick="btnNo_Click" ValidationGroup="No" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="No" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>


