<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="WelcomePageCandidate.aspx.cs" Inherits="Pharmacy2024.ApplicationPages.WelcomePageCandidate" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/InstructionCAPRound2.ascx" TagName="CAP2" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/InstructionCAPRound3.ascx" TagName="CAP3" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .exurl {
            background: #e8ecf3;
            padding: 7px;
            font-size: 16px;
            border-left: 4px solid #604091;
            text-align: center;
            margin: 2px 5px;
            width: 280px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        setTimeout(function () {
            document.getElementById('tblLogin').style.display = 'none';
        }, 10000);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible="false">
        <br />
        <center>
            <asp:Label ID="lblHeader" runat="server" Font-Names="Bookman Old Style" Font-Size="Medium">
                Welcome for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>
            </asp:Label>
        </center>
        <br />
        <div class="table-responsive">
            <table class="AppFormTable" id="tblLogin">
                <tr>
                    <th colspan="4">Login Details</th>
                </tr>
                <tr>
                    <td style="width: 20%" align="right">Application ID</td>
                    <td style="width: 30%">
                        <asp:Label ID="lblLoginID" runat="server" Font-Bold="true"></asp:Label></td>
                    <td style="width: 20%" align="right">User Name</td>
                    <td style="width: 30%">
                        <asp:Label ID="lblUserName" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">User Role</td>
                    <td>
                        <asp:Label ID="lblUserType" runat="server" Font-Bold="true"></asp:Label></td>
                    <td align="right">IP Address</td>
                    <td>
                        <asp:Label ID="lblIPAddress" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">Current Login Time</td>
                    <td>
                        <asp:Label ID="lblCurrentLoginTime" runat="server" Font-Bold="true"></asp:Label></td>
                    <td align="right">Previous Login Time</td>
                    <td>
                        <asp:Label ID="lblPreviousLoginTime" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>
            </table>
        </div>
        <br />
        <div class="row w-100 mt-2" style="display: flex; justify-content: center">
            <div class="exurl">
                <asp:HyperLink ID="hlSendMobileSMS" runat="server" Visible="true" NavigateUrl="~/CandidateModule/CandidateSmsSent.aspx?SMSType=S" Target=""
                    Text="View Sent SMS"><asp:Image runat="server" ImageUrl="~/Images/sms.png" CssClass="img-fluid ml-2" Width="20px"/>
                </asp:HyperLink>
            </div>
            <div class="exurl">
                <asp:HyperLink ID="hlSendWhatsUpSMS" runat="server" Visible="true" NavigateUrl="~/CandidateModule/CandidateSmsSent.aspx?SMSType=W" Target=""
                    Text="View Sent WhatsApp"><asp:Image runat="server" ImageUrl="~/Images/whatsapp.png" CssClass="img-fluid ml-2" Width="20px"/>    
                </asp:HyperLink>
            </div>
            <div class="exurl">
                <asp:HyperLink ID="hlSendEmailBox" runat="server" Visible="true" NavigateUrl="~/CandidateModule/CandidateSmsSent.aspx?SMSType=E" Target=""
                    Text="View Sent Email"><asp:Image runat="server" ImageUrl="~/Images/email.png" CssClass="img-fluid ml-2" Width="20px"/>      
                </asp:HyperLink>
            </div>
        </div>

        <div class="table-responsive mt-3">
            <table class="AppFormTable" id="tblPayDifferenceFee" runat="server">
                <tr style="background-color: chartreuse">
                    <td align="center">
                        <asp:Button ID="Button1" runat="server" Text="Click Here to pay the remaining Application Fee difference of Rs. 200/- >>>" CssClass="InputButton" OnClick="btnDifferenceFee_Click" Height="27" />
                    </td>
                </tr>
            </table>
        </div>
        <table id="tblDiscrepancyDetails" runat="server" class="AppFormTable mt-3">
            <tr>
                <th style="border-top-width: 0px; background-color: red; color: wheat;" colspan="2"><b>Application Form Verification Status</b></th>
            </tr>
            <tr>
                <td>
                    <%--<font color="red"> --%>
                    <b>
                        <asp:Label ID="lblDiscrepancyStatus" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label></b>
                    <%--</font>--%>
                </td>
            </tr>
            <tr id="trDiscrepancy" runat="server" visible="false">
                <td>
                    <asp:GridView ID="gvDiscrepancy" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid  table-responsive">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Application Form Step" DataField="LinkName" HtmlEncode="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Discrepancy In" DataField="DiscrepancyName" HtmlEncode="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Remark by SC Officer" DataField="DiscrepancyRemark" HtmlEncode="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40%" CssClass="Header" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                            </asp:BoundField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscrepancyID" runat="server" Text='<%# Eval("DiscrepancyID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplicationFormStepID" runat="server" Text='<%# Eval("ApplicationFormStepID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Go To Step">
                                <ItemTemplate>
                                    <asp:Button ID="btnStep" runat="server" Text="Click To Edit" PostBackUrl='<%# Eval("LinkUrl") %>' CssClass="InputButton" BackColor="#cc66ff"></asp:Button>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </td>
            </tr>
            <tr id="trEditButton" runat="server" visible="false">
                <td align="center">
                    <asp:Button ID="btnEditApplicationForm" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Edit Application Form" Height="40px" Font-Size="Medium" Font-Bold="true" OnClick="btnEditApplicationForm_Click"></asp:Button></td>
            </tr>
            <tr id="trReSubmitButton" runat="server" visible="false">
                <td align="center">
                    <asp:Button ID="btnReSubmit" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to ReSubmit and Lock Application Form for E-Scrutiny" Height="40px" Font-Size="Medium" Font-Bold="true" OnClick="btnReSubmit_Click"></asp:Button></td>
            </tr>
            <tr id="trSubmitButton" runat="server" visible="false">
                <td align="center">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Submit and Lock Application Form for E-Scrutiny" Height="40px" Font-Size="Medium" Font-Bold="true" OnClick="btnSubmit_Click"></asp:Button></td>
            </tr>
            <tr id="trBookSlotButton" runat="server" visible="false">
                <td align="center">
                    <asp:Button ID="btnBookSlot" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Book a Slot" Height="40px" Font-Size="Medium" Font-Bold="true" OnClick="btnBookSlot_Click"></asp:Button></td>
            </tr>
        </table>
        <table id="tblARAStatus" runat="server" class="AppFormTable" visible="false">
            <tr>
                <th style="border-top-width: 0px; background-color: red; color: wheat;" colspan="2"><b>Admission Approved Status</b></th>
            </tr>
            <tr>
                <td>
                    <b>
                        <asp:Label ID="lblARAStatus" runat="server" ForeColor="Green" Font-Size="Medium" Visible="false"></asp:Label></b>
                </td>
            </tr>
        </table>
        <table id="tblApplicationFormStatus" runat="server" visible="false" class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;">Application Form Status</th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvApplicationFormLinksStatus" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Step ID">
                                <ItemTemplate>
                                    Step <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="LinkDescription" HeaderText="Step Details">
                                <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="55%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Button ID="btnFormStatus" runat="server" Text='<%# Eval("LinkStatus") %>' PostBackUrl='<%# Eval("LinkUrl") %>' CssClass="InputButton" BackColor='<%# System.Drawing.Color.FromName(Eval("LinkBackColor").ToString()) %>' Enabled='<%# Convert.ToBoolean(Eval("LinkEnabled")) %>'></asp:Button>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table id="tblDocumentUploadStatus" runat="server" visible="false" class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;">Required Documents Upload Status</th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvRequiredDocumentsUploadStatus" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField DataField="DocumentsUploadStatus" HeaderText="Documents Upload Status">
                                <ItemStyle Width="75%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Total Documents">
                                <ItemTemplate>
                                    <asp:Button ID="btnTotalDocuments" runat="server" Text='<%# Eval("TotalDocuments") %>' Width="50px" CssClass="InputButton" BackColor='<%# System.Drawing.Color.FromName(Eval("BackColor").ToString()) %>' Enabled="false"></asp:Button>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table id="tblApplicationFormInstructions" runat="server" visible="false" class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <br />
                    <b>Instructions to Fill Application Form</b>
                    <br />
                    <br />
                    <ol class="list-text">
                        <li>
                            <p align="justify">
                                Candidate shall read the Information and Notification given carefully.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                Candidate will have to fill up the Application Form Completely.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                Candidate has to verify the correctness of the information filled. In case of any
                                correction, the candidate can do it online before confirmation.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                Candidate will not be able to change the information after the confirmation of Application
                                Form.
                            </p>
                        </li>
                        <%-- <li>
                            <p align="justify">
                                e-Scrutiny mode, candidate will be able to change the information after the confirmation of Application by raising the e-grievance from their individual Login.
                            </p>
                        </li>
                        <li>
                            <p align="justify">
                                Candidates should confirm the Application Form through electronically from Scrutiny Center. Do not visit Scrutiny Center OR Do not send by post. (Only for Maharashtra
                                and OMS Candidates)
                            </p>
                        </li>--%>
                        <%-- <li>
                            <p align="justify">
                                Candidate is required to carry ALL Original Certificates at the Scrutiny Center
                                for verification and confirmation of Application Form and get the Receipt-cum-Acknowledgement
                                duly signed by Scrutiny Center.
                            </p>
                        </li>--%>
                        <%--      <li>
                            <p align="justify">
                                Before personally submitting printed Application Form, Please ensure that
                            </p>
                            <ol type='a'>
                                <li>
                                    <p align="justify">
                                        You have taken one copy of printout of Application Form.
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        You have signed the Application Form above the word 'Signature of Applicant'. You
                                        should also write Place and Date on the Form.
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        You have arranged ALL Original Certificates listed on Application Form. You must
                                        carry ALL Original Certificates with you before proceeding to Scrutiny Center.
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Please verify your data printed on Application Form. You can correct it till it
                                        is not confirmed at Scrutiny Center.
                                    </p>
                                </li>
                            </ol>
                        </li>--%>
                        <%-- <li>
                            <p align="justify">
                                After you submit the Application Form in Scrutiny Center, Scrutiny Center Officer will

                            </p>
                            <ol type='a'>
                                <li>
                                    <p align="justify">
                                        Scrutinize all required documents electronically by e-Scrutiny Officer, Confirm your Application Form online.
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        You can Print two copies of Receipt-cum-Acknowledgement of Application Form
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        If the mandate documents are not submitted properly than your application will be revert back to you online by e-Scrutiny Officer.
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Revert back application will be available on your individual Login for your corrective steps.

                                    </p>
                                </li>
                            </ol>
                        </li>
                        <li>
                            <p align="justify">
                                Preserve this Receipt as you are required to present it at later stages of Admission.
                            </p>
                        </li>--%>
                    </ol>
                </td>
            </tr>
        </table>
        <table id="tblProceedToCompleteApplicationForm" runat="server" visible="false" class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceedToCompleteApplicationForm" Text="Proceed to Complete Application Form >>>" runat="server" CssClass="InputButton" OnClick="btnProceedToCompleteApplicationForm_Click"></asp:Button></td>
            </tr>
        </table>
        <table class="AppFormTableWithOutBorder" id="tblAdmissionStatus" runat="server" visible="false">
            <tr>
                <td>
                    <center><font size="2"><b>Current Admission Details</b></font></center>
                    <table id="tblAdmissionDetails" runat="server" visible="false" class="AppFormTableWithAllBorder">
                        <tr>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 25%;" align="right">Institute Admitted</td>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 75%;">
                                <asp:Label ID="lblInstituteAdmitted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Course Admitted</td>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                                <asp:Label ID="lblCourseAdmitted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Seat Type Admitted</td>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                                <asp:Label ID="lblSeatTypeAdmitted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Admission Round</td>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                                <asp:Label ID="lblAdmissionRound" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                        </tr>
                    </table>
                    <table id="tblNoAdmissionDetails" runat="server" visible="false" class="AppFormTableWithAllBorder">
                        <tr>
                            <td align="center" style="background-color: InfoBackground">
                                <asp:Label ID="lblAdmissionStatus" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table class="AppFormTableWithOutBorder" id="tblOptionForm" runat="server" visible="false">
            <tr id="trOptionFormStatusCAPRound1" runat="server" visible="false">
                <td>
                    <center><font size="2"><b>Status of Option Form Submission and Confirmation for CAP Round – I</b></font></center>
                    <table class="AppFormTableWithAllBorder">
                        <tr>
                            <td align="center" style="background-color: InfoBackground">
                                <asp:Label ID="lblOptionFormStatusCAPRound1" Font-Bold="true" runat="server" Font-Size="Medium"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trOptionFormStatusCAPRound2" runat="server" visible="false">
                <td>
                    <center><font size="2"><b>Status of Option Form Submission and Confirmation for CAP Round – II</b></font></center>
                    <table class="AppFormTableWithAllBorder">
                        <tr>
                            <td align="center" style="background-color: InfoBackground">
                                <asp:Label ID="lblOptionFormStatusCAPRound2" Font-Bold="true" runat="server" Font-Size="Medium"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trOptionFormStatusCAPRound3" runat="server" visible="false">
                <td>
                    <center><font size="2"><b>Status of Option Form Submission and Confirmation for CAP Round – III</b></font></center>
                    <table class="AppFormTableWithAllBorder">
                        <tr>
                            <td align="center" style="background-color: InfoBackground">
                                <asp:Label ID="lblOptionFormStatusCAPRound3" Font-Bold="true" runat="server" Font-Size="Medium"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trOptionFormStatusCAPRound4" runat="server" visible="false">
                <td>
                    <center><font size="2"><b>Status of Option Form Submission and Confirmation for Additional Round for Government / Govt. Aided Institutes</b></font></center>
                    <table class="AppFormTableWithAllBorder">
                        <tr>
                            <td align="center" style="background-color: InfoBackground">
                                <asp:Label ID="lblOptionFormStatusCAPRound4" Font-Bold="true" runat="server" Font-Size="Small"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trOptionFormInstructionsCAPRound1" runat="server" visible="false">
                <td>
                    <ol class="list-text">
                        <li>
                            <p align="justify">The Candidate whose name appeared in Final Merit List (Maharashtra State / All India) is Eligible to Submit Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">The Candidate has to Submit and Confirm Online Option Form through Candidate Login by himself/herself.</p>
                        </li>
                        <li>
                            <p align="justify">The Scrutiny Center shall act only as facilitator for Candidate to Submit and Confirm Online Option Form. It will be the responsibility of the candidate to Submit and Confirm Online Option Form by himself/herself through their login. DO NOT SHARE PASSWORD and OTP, instead type the password by himself /herself.</p>
                        </li>
                        <li>
                            <p align="justify">Click on 'Fill / Edit Option Form' Button given below to fill the Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">After that, Candidate will have to select the Course & Other Search Criteria and then click on 'Search' button. All the Institutes under that Search Criteria will be displayed.</p>
                        </li>
                        <li>
                            <p align="justify">To shortlist an option candidate has to select the Institute by clicking on the Checkbox given in front of the Institute name.</p>
                        </li>
                        <li>
                            <p align="justify">Candidate can go on selecting as many options minimum one and maximum 300 choices of Institute & courses as candidate wants by clicking on the Institutes & Courses.</p>
                        </li>
                        <li>
                            <p align="justify">Once candidate finalizes all his options, only then candidate can click on Proceed button.</p>
                        </li>
                        <li>
                            <p align="justify">All the options selected by her/his will be shown.</p>
                        </li>
                        <li>
                            <p align="justify">If candidate wants to change the short listed options then candidate is also allowed to do so.</p>
                        </li>
                        <li>
                            <p align="justify">You can go on clicking one by one on the check box given in front of the option to set preferences with highest priority first in decreasing order of their preferences.</p>
                        </li>
                        <li>
                            <p align="justify">You are allowed to set preferences to maximum 300 options selected by you.</p>
                        </li>
                        <li>
                            <p align="justify">If you wish to reset the preferences then click on Reset preferences button or click on confirm button.</p>
                        </li>
                        <li>
                            <p align="justify">Then all the options in order of preferences given by you are shown.</p>
                        </li>
                        <li>
                            <p align="justify">Candidate can modify preferences, add choices, delete choices before confirmation of the online Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">You can repeat these steps as many times as you want till you Confirm your Option Form. <b>Once you are sure then confirm your Option Form by entering the password once again.</b> Candidate shall take print out of Receipt-cum-Acknowledgement of Option Form. After confirmation of Option form the candidate will not be able to change the option.</p>
                        </li>
                        <li>
                            <p align="justify">The Option Form just submitted, but not confirmed by the candidate himself/herself will not be processed for allotment.</p>
                        </li>
                        <li>
                            <p align="justify">Candidate should keep the printout of the online Option/Preference form after confirmation for future reference. They can view the detailed option form having the details of the Choice Codes.</p>
                        </li>
                    </ol>
                </td>
            </tr>
            <tr id="trOptionFormInstructionsCAPRound2" runat="server" visible="false">
                <td>
                    <ol class="list-text">
                        <li>
                            <p align="justify">The Candidate whose name appeared in Final Merit List (Maharashtra State / All India) is Eligible to Submit Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">The Candidate has to Submit and Confirm Online Option Form through Candidate Login by himself/herself.</p>
                        </li>
                        <li>
                            <p align="justify">The Scrutiny Center shall act only as facilitator for Candidate to Submit and Confirm Online Option Form. It will be the responsibility of the candidate to Submit and Confirm Online Option Form by himself/herself through their login. DO NOT SHARE PASSWORD and OTP, instead type the password by himself /herself.</p>
                        </li>
                        <li>
                            <p align="justify">Click on 'Fill / Edit Option Form' Button given below to fill the Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">After that, Candidate will have to select the Course & Other Search Criteria and then click on 'Search' button. All the Institutes under that Search Criteria will be displayed.</p>
                        </li>
                        <li>
                            <p align="justify">To shortlist an option candidate has to select the Institute by clicking on the Checkbox given in front of the Institute name.</p>
                        </li>
                        <li>
                            <p align="justify">She/he can go on selecting as many options as candidate wants by clicking on the Institutes.</p>
                        </li>
                        <li>
                            <p align="justify">Once candidate finalizes all his options, only then candidate can click on Proceed button.</p>
                        </li>
                        <li>
                            <p align="justify">All the options selected by her/his will be shown.</p>
                        </li>
                        <li>
                            <p align="justify">If candidate wants to change the short listed options then candidate is also allowed to do so.</p>
                        </li>
                        <li>
                            <p align="justify">You can go on clicking one by one on the check box given in front of the option to set preferences with highest priority first.</p>
                        </li>
                        <li>
                            <p align="justify">You are allowed to set preferences to maximum 300 options selected by you.</p>
                        </li>
                        <li>
                            <p align="justify">If you wish to reset the preferences then click on Reset preferences button or click on confirm button.</p>
                        </li>
                        <li>
                            <p align="justify">Then all the options in order of preferences given by you are shown.</p>
                        </li>
                        <li>
                            <p align="justify">Candidate can modify preferences, add choices, delete choices before confirmation of the online Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">You can repeat these steps as many times as you want till you Confirm your Option Form. <b>Once you are sure then confirm your Option Form by entering the password once again.</b> Candidate shall take print out of Receipt-cum-Acknowledgement of Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">The Option Form just submitted, but not confirmed by the candidate himself/herself will not be processed for allotment.</p>
                        </li>
                        <li>
                            <p align="justify">Candidate should keep the printout of the online Option/Preference form after confirmation for future reference. They can view the detailed option form having the details of the Choice Codes.</p>
                        </li>
                    </ol>
                </td>
            </tr>
            <tr id="trOptionFormInstructionsCAPRound3" runat="server" visible="false">
                <td>
                    <ol class="list-text">
                        <li>
                            <p align="justify">The Candidate whose name appeared in Final Merit List (Maharashtra State / All India) is Eligible to Submit Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">The Candidate has to Submit and Confirm Online Option Form through Candidate Login by himself/herself. </p>
                        </li>
                        <li>
                            <p align="justify">The Scrutiny Center shall act only as facilitator for Candidate to Submit and Confirm Online Option Form. It will be the responsibility of the candidate to Submit and Confirm Online Option Form by himself/herself through their login. DO NOT SHARE PASSWORD and OTP, instead type the password by himself /herself.</p>
                        </li>
                        <li>
                            <p align="justify">Click on 'Fill / Edit Option Form' Button given below to fill the Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">After that, Candidate will have to select the Course & Other Search Criteria and then click on 'Search' button. All the Institutes under that Search Criteria will be displayed.</p>
                        </li>
                        <li>
                            <p align="justify">To shortlist an option candidate has to select the Institute by clicking on the Checkbox given in front of the Institute name.</p>
                        </li>
                        <li>
                            <p align="justify">Candidate can go on selecting as many options as candidate wants by clicking on the Institutes.</p>
                        </li>
                        <li>
                            <p align="justify">Once candidate finalizes all his options, only then candidate can click on Proceed button.</p>
                        </li>
                        <li>
                            <p align="justify">All the options selected by her/his will be shown.</p>
                        </li>
                        <li>
                            <p align="justify">If candidate wants to change the short listed options then candidate is also allowed to do so.</p>
                        </li>
                        <li>
                            <p align="justify">You can go on clicking one by one on the check box given in front of the option to set preferences with highest priority first.</p>
                        </li>
                        <li>
                            <p align="justify">You are allowed to set preferences to maximum 300 options selected by you.</p>
                        </li>
                        <li>
                            <p align="justify">If you wish to reset the preferences then click on Reset preferences button or click on confirm button.</p>
                        </li>
                        <li>
                            <p align="justify">Then all the options in order of preferences given by you are shown.</p>
                        </li>
                        <li>
                            <p align="justify">Candidate can modify preferences, add choices, delete choices before confirmation of the online Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">You can repeat these steps as many times as you want till you Confirm your Option Form. <b>Once you are sure then confirm your Option Form by entering the password once again.</b> Candidate shall take print out of Receipt-cum-Acknowledgement of Option Form.</p>
                        </li>
                        <li>
                            <p align="justify">The Option Form just submitted, but not confirmed by the candidate himself/herself will not be processed for allotment.</p>
                        </li>
                        <li>
                            <p align="justify">Candidate should keep the printout of the online Option/Preference form after confirmation for future reference. They can view the detailed option form having the details of the Choice Codes.</p>
                        </li>
                    </ol>
                </td>
            </tr>
            <tr id="trOptionFormInstructionsCAPRound4" runat="server" visible="false">
                <td>
                    <p align="justify"><b>Additional Round for Admission to First Year of Under Graduate Technical Courses in Engineering and Technology in Government, Government Aided, University Departments and University Managed Departments :</b></p>
                    <br />
                    <ol class="list-text">
                        <li>
                            <p align="justify">Candidates who have confirmed the admission in earlier CAP Rounds and reported to the Institute are also eligible to participate in this Round.</p>
                        </li>
                        <li>
                            <p align="justify">Candidates may fill Option Form for higher preference even if there is no vacancy at this stage, in above mentioned Institute as the vacancies may arise due to allotment during the process dynamically.</p>
                        </li>
                    </ol>
                    <br />
                    <center><font size="4" color="red"><b><u>PRECAUTION / WARNING</u></b></font></center>
                    <br />
                    <font size="2" color="red">
                        <b>
                            <ol class="list-text">
                                <li>
                                    <p align="justify"><font size="2" color="red"><b>I have read all the rules of admission and Information brochure for admission to UG courses <%=CurrentYear%> and on understanding these Rules, I have filled this Option Form for consideration for allotment in Additional Round for Government / Government-Aided Institutes.</b></font></p>
                                </li>
                                <li>
                                    <p align="justify"><font size="2" color="red"><b>I am aware that if I get allotment/betterment in this round then my earlier admission in Govt, Aided or University Department (if any) shall be cancelled automatically and it will be mandatory for me to report to the allotted institute in this round.</b></font></p>
                                </li>
                                <li>
                                    <p align="justify"><font size="2" color="red"><b>I also know that vacancy created due to cancellation of admission (if any) shall be offered to other eligible candidate as per the inter se merit, therefore I shall not request for restoration of the earlier cancelled admission.</b></font></p>
                                </li>
                                <li>
                                    <p align="justify"><font size="2" color="red"><b>This additional Round is not applicable to Unaided Institutes.</b></font></p>
                                </li>
                                <li>
                                    <p align="justify"><font size="2" color="red"><b>The rules of refund of fees due to cancellation shall be applicable, if candidate get allotment in this round.</b></font></p>
                                </li>
                                <li>
                                    <p align="justify"><font size="2" color="red"><b>For any grievance candidate shall report to the respective Joint Director, Regional Office, Directorate Technical Education at Amravati / Aurangabad / Mumbai / Nashik / Nagpur / Pune only.</b></font></p>
                                </li>
                            </ol>
                        </b>
                    </font>
                </td>
            </tr>
            <tr id="trProceedToCompleteOptionForm" runat="server" visible="false">
                <td align="center">
                    <br />
                    <br />
                    <asp:Button ID="btnProceedToCompleteOptionForm" Text="Proceed to Fill Option Form >>>" runat="server" CssClass="InputButton" OnClick="btnProceedToCompleteOptionForm_Click"></asp:Button>
                </td>
            </tr>
        </table>
        <table class="AppFormTableWithOutBorder" id="tblSeatAcceptanceStatus" runat="server" visible="false">
            <tr>
                <td>
                    <center><font size="2"><b>Current Allotment Details</b></font></center>
                    <table id="tblAllotmentDetails" runat="server" visible="false" class="AppFormTableWithAllBorder">
                        <tr>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 25%;" align="right">Institute Allotted</td>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 75%;">
                                <asp:Label ID="lblInstituteAllotted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Course Allotted</td>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                                <asp:Label ID="lblCourseAllotted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                        </tr>
                        <tr id="trBenefitTaken" runat="server">
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Benefit Taken</td>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                                <asp:Label ID="lblBenefitTaken" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Seat Type Allotted</td>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                                <asp:Label ID="lblSeatTypeAllotted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Preference No. Allotted</td>
                            <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                                <asp:Label ID="lblPreferenceNoAllotted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                        </tr>
                    </table>
                    <table id="tblNoAllotmentDetails" runat="server" visible="false" class="AppFormTableWithAllBorder">
                        <tr>
                            <td align="center" style="background-color: InfoBackground">
                                <asp:Label ID="lblAllotmentStatus" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trSeatAcceptanceGrivanceStatus" runat="server" visible="false">
                <td>
                    <center><font size="2"><b>Seat Acceptance Grievance Status (Mandatory activity for Candidates)</b></font></center>
                    <table id="tblGrivanceStatus" runat="server" class="AppFormTableWithAllBorder">
                        <tr>
                            <th style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;">SC Code</th>
                            <th colspan="2" style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;">SC Name</th>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Label ID="lblFCCode" runat="server"></asp:Label></td>
                            <td colspan="2" style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Label ID="lblFCName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <th style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;">Coordinator Name</th>
                            <th style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;">Coordinator MobileNo</th>
                            <th style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;">Coordinator MobileNo</th>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Label ID="lblCoordinatorName" runat="server"></asp:Label></td>
                            <td style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Label ID="lblCoordinatorMobileNo" runat="server"></asp:Label></td>
                            <td style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Label ID="lblCoordinatorAltMobileNo" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <th style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;">Grievance Status</th>
                            <th colspan="2" style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;">FCMessage</th>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Label ID="lblGrivanceStatus" runat="server"></asp:Label></td>
                            <td colspan="2" style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Label ID="lblFCMessage" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server" id="trCVCMsg" visible="false">
                <td class="AppFormTable" colspan="4" style="color: red; font-weight: bold"><font size="2">Note : The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                    
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                </font>

                </td>
            </tr>
            <tr>
                <td runat="server" id="tdSeatAcceptanceStatus">
                    <center>
                        <font size="2"><b>
                            <asp:Label ID="lblSeatAccetanceStatus" runat="server" Text="Seat Acceptance Status"></asp:Label></b></font></center>
                    <table class="AppFormTableWithAllBorder">
                        <tr>
                            <td style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Step ID</b></td>
                            <td style="width: 65%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Step Details</b></td>
                            <td style="width: 20%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Status</b></td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #F0F0F0;" align="center">Step 1</td>
                            <td style="border: 1px solid #F0F0F0;">Self Verification Status [Candidate shall ensure the claims related with Qualifying Marks, category, gender, reservation, special reservation made by himself/herself in the applications form are correct and the relevant documents uploaded to substantiate claims are authentic and correct.]</td>
                            <td style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Button ID="btnSeatAcceptanceStep1" runat="server" CssClass="InputButton" OnClick="btnSeatAcceptanceStep_Click"></asp:Button></td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #F0F0F0;" align="center">Step 2</td>
                            <td style="border: 1px solid #F0F0F0;">
                                <asp:Label ID="lblStep2" runat="server" Text="Choose Seat Acceptance Option (Freeze/Betterment (Not Freeze))"></asp:Label></td>
                            <td style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Button ID="btnSeatAcceptanceStep2" runat="server" CssClass="InputButton" OnClick="btnSeatAcceptanceStep1_Click"></asp:Button></td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #F0F0F0;" align="center">Step 3</td>
                            <td style="border: 1px solid #F0F0F0;">Pay Seat Acceptance Fee - Rs. 1000/-</td>
                            <td style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Button ID="btnSeatAcceptanceStep3" runat="server" CssClass="InputButton" OnClick="btnSeatAcceptanceStep2_Click"></asp:Button></td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid #F0F0F0;" align="center">Step 4</td>
                            <td style="border: 1px solid #F0F0F0;">Confirm Seat Acceptance Letter</td>
                            <td style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Button ID="btnSeatAcceptanceStep4" runat="server" CssClass="InputButton" Enabled="false" OnClick="btnSeatAcceptanceStep4_Click"></asp:Button></td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr id="trCAP2Betterment" runat="server">
                            <td style="border: 1px solid #F0F0F0;" align="center">&nbsp;</td>
                            <td style="border: 1px solid #F0F0F0;">Give Seat Acceptance Option (Freeze) for CAP-III</td>
                            <td style="border: 1px solid #F0F0F0;" align="center">
                                <asp:Button ID="btnSeatAcceptanceStep5" runat="server" CssClass="InputButton" Enabled="false" OnClick="btnSeatAcceptanceStep5_Click"></asp:Button></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trInstructionsARCReportingCAPRound1" runat="server" visible="false">
                <td>
                    <center>
                        <font size="2"><b><u>Important Instructions to Candidates after Seat Allotment in respective
                            CAP Rounds</u></b></font></center>
                    <br /> 
                    <ol class="list-text" style="list-style-type: none">
                        <li id="lifirstprefcap1" runat="server" visible="False">
                            <p align="justify"><b>If a candidate is allotted the seat as per his first preference:-</b></p>
                            <ol type="a">
                                 <li>
                                    <p align="justify">
                                        If a candidate is allotted the seat as per his first preference, such allotment shall be auto freezed and the candidate shall accept the allotment so made. Such candidate shall then be not eligible for participation in the subsequent CAP rounds. Such candidates shall then report to ARC for verification of documents and payment of seat acceptance fee. Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat. If such candidate does not report to ARC for confirmation of seat acceptance, their claim on the allotted seat shall stand forfeited automatically and the seat shall become available for fresh allotment. For such candidate, the allotment so made shall be the final allotment;
                              <br />
                                        जर उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या  पसंतीक्रमांकावरील जागेचे वाटप झाल्यास असे वाटप प्रणालीतून आपोआप गोठविले जाईल व उमेदवार या जागेचा स्वीकार करेल. असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्यास पात्र नसतील. असे  उमेदवार प्रवेश उपस्थिती केंद्रावर जागास्वीकृती करिता कागदपत्राची पडताळणी व  जागा स्विकृती शुल्क भरण्यासाठी हजर होतील. तदनंतर असे उमेदवार वाटप करण्यात आलेल्या जागेवर प्रवेश घेण्यासाठी वाटप करण्यात आलेल्या  संस्थेमध्ये हजर होतील. असे उमेदवार जर प्रवेश उपस्थिती केंद्रावर जागास्वीकृती करिता हजर झाले नाहीत तर ते त्यांना वाटप करण्यात आलेल्या  जागेवरील हक्क  आपोआप गमावतील आणि ती  जागा पुढील वाटपासाठी उपलब्ध होईल.  अश्या  उमेदवारांकरिता करण्यात आलेले हे जागावाटप अंतिम असेल;
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">Reporting dates for admission in the allotted Institute <b>22/10/2024 to 24/10/2024</b></p>
                                </li>
                            </ol>
                        </li>
                        <li id="lisecondprefcap1" runat="server" visible="False">
                            <p align="justify"><b>If a candidate is allotted seat other than his first preference:-</b></p>
                            <ol type="a">
                                <li>
                                    <p align="justify">
                                        Candidate who have been allotted seat other than the first preference given by the candidate and if the candidate is satisfied with such allotment and do not wish to participate in further CAP rounds, such candidate can freeze the offered seat through candidate’s login. Once the candidate freezes the allotted seat, such candidate shall then report to ARC for verification of documents and payment of seat acceptance fee. Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat. If such candidate does not report to ARC for confirmation of seat acceptance, their claim on the allotted seat shall stand forfeited automatically and the seat shall become available for fresh allotment. For such candidate, the allotment so made shall be the final allotment. Such candidate shall then be not eligible for participation in the subsequent CAP rounds;
                              <br />
                                        ज्या उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या  पसंतीक्रमांकाखेरीज इतर  पसंतीक्रमांकावरील  जागेचे वाटप झाल्यास आणि उमेदवार या वाटपाने संतुष्ट असल्यास आणि केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी  होण्याची त्याची इच्छा नसल्यास उमेदवार त्याच्या लॉग-इन मधून त्यास देऊ केलेली जागा स्वतः गोठवू शकतो. अशा प्रकारे जागा गोठविल्यावर असे  उमेदवार प्रवेश उपस्थिती केंद्रावर जागास्वीकृती करिता कागदपत्राची पडताळणी व  जागा स्विकृती शुल्क भरण्यासाठी हजर होतील. तदनंतर असे उमेदवार वाटप करण्यात आलेल्या जागेवर प्रवेश घेण्यासाठी वाटप करण्यात आलेल्या  संस्थेमध्ये हजर होतील.  असे उमेदवार जर प्रवेश उपस्थिती केंद्रावर जागास्वीकृती करिता हजर झाले नाहीत तर ते त्यांना वाटप करण्यात आलेल्या  जागेवरील हक्क  आपोआप गमावतील आणि ती जागा पुढील वाटपासाठी उपलब्ध होईल.   अश्या  उमेदवारांकरिता करण्यात आलेले हे जागावाटप अंतिम असेल व असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्यास पात्र नसतील;
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">Reporting dates for admission in the allotted Institute <b>22/10/2024 to 24/10/2024 </b></p>
                                </li>
                            </ol>
                        </li>
                        <li id="lithirdprefcap1" runat="server" visible="False">
                            <p align="justify"><b>Candidate who wants to participate in the next Round :-</b></p>
                            <ol type="a">
                                  <li>
                                    <p align="justify">
                                        Candidate who have been allotted seat other than first preference and accepted the seat by reporting to ARC for confirmation of seat acceptance shall be eligible for participation in the subsequent rounds for betterment;
                               <br />
                                        ज्या उमेदवारांना त्याच्या विकल्प नमुन्यातील पहिल्या  पसंतीक्रमांकाखेरीज इतर  पसंतीक्रमांकावरील  जागेचे वाटप झाले  आणि उमेदवाराने  प्रवेश उपस्थिती केंद्रावर हजर  होवून जागास्वीकृती केली असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये वरच्या पसंतीक्रमावरील जागा मिळविण्याकरिता सहभागी होण्यास पात्र असतील.
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">
                                        Candidate who have been allotted seat other than first preference and not accepted the seat by not reporting to ARC for confirmation of seat acceptance shall be eligible for participation in the subsequent rounds;
                              <br />
                                        ज्या उमेदवारांना त्याच्या विकल्प नमुन्यातील पहिल्या  पसंतीक्रमांकाखेरीज इतर  पसंतीक्रमांकावरील  जागेचे वाटप झाले  आणि उमेदवाराने  प्रवेश उपस्थिती केंद्रावर हजर न होवून जागास्वीकृती केली नाही,  असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्यास पात्र असतील.
                                    </p>
                                </li>
                            </ol>
                        </li>
                        <ol type="a">
                            <li>
                                <p align="justify">After the first time Allotment, Candidate needs to Complete the Self-Verification and Seat Acceptance process through online mode from date <b>22/10/2024 to 24/10/2024 Up to 03:00 P.M </b>and Reporting to allotted Institute to confirm the admission from date <b>22/10/2024 to 24/10/2024 Up to 05:00 P.M.</b></p>
                            </li>
                            <li>
                                <p align="justify">Candidate shall ensure through login that his/her claims related with Qualifying Marks, category, gender, reservation, special reservation made by himself/herself in the applications form are correct and the relevant documents uploaded to substantiate his/her claims are authentic and correct.</p>
                            </li>
                            <%-- <li>
                            <p align="justify">
                                Candidates who submitted ($)Caste/ Tribe Validity Certificate receipt,  (#)Non Creamy Layer Certificate (NCL) receipt 
                            and (@)Economically Weaker Section (EWS) Certificate receipt during the document verification and confirmation period should Upload 
                            ($)Caste/ Tribe Validity Certificate, (#)Non Creamy Layer Certificate and (@)Economically Weaker Section (EWS) Certificate between 
                           <b>09/12/2021 and 11/12/2021 Up to 3 P.M. </b>through "Upload CVC/TVC,NCL,EWS Document" link from their individual login, otherwise these candidates 
                            shall be considered as Open category candidates and their allotment, if any, shall be cancelled
                            </p>
                        </li>--%>
                            <%--<li>
                            <p align="justify">Candidates who uploaded Certificates (CVC/TVC,NCL & EWS) between <b>09/12/2021 and 11/12/2021 Up to 3 P.M. </b>will be Verified through online by the Scrutiny Center. Until then, candidates will not be able to do self-Verification. Candidates will have the facility to do self-Verification & Seat Acceptance after e-Scrutiny of this certificate (CVC/TVC,NCL & EWS). Candidates who do Not Available their CVC/TVC, NCL and EWS certificate between <b>09/12/2021 and 11/12/2021 Up to 3 P.M. </b>will have the facility to do convert from Category to Open & Self-Verification only. Such Candidates and their allotment, if any, shall be cancelled.</p>
                        </li>--%>
                            <li>
                                <p align="justify">
                                    The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                                    
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                                </p>
                            </li>
                            <%-- <li>
                            <p align="justify">If Scrutiny Center found any discrepancy than in such case, candidate’s allotment get cancelled and candidate will eligible for next subsequent round on the basis of available details.</p>
                        </li>--%>
                            <li>
                                <p align="justify">At the time of reporting to Institute for confirming the allotted seat, the candidate shall produce all the original documents in support of the claims made in the application. In the event the candidate fails to produce the documents in support of the claim, Institute will reset the “Self Verification and Seat Acceptance “ post that candidate will do the again his/her Self verification and mark discrepancy to correct the information. </p>
                            </li>
                            <li>
                                <p align="justify">Candidate shall produce the original copies for verification to Institute. </p>
                            </li>
                            <li>
                                <p align="justify">Seat Acceptance Fees of Rs.1000/- (Rupees One Thousand only) shall be paid by online mode through candidate’s Login while doing Self Seat acceptance. It is treated as non-refundable processing fees.</p>
                            </li>
                            <%--  <li>
                            <p align="justify">Candidate has to do Self Verification for Seat acceptance, after the first time Allotment.</p>
                        </li>--%>
                        </ol>
                    </ol>
                    <center>
                        <font size="2"><b>*******************</b></font></center>
                </td>
            </tr>
            <tr id="trInstructionforNotAllotment" runat="server" visible="false">
                <td colspan="4">
                    <center><font size="2"><b><u>Important Instructions to Candidates in respective CAP Rounds</u></b></font></center>
                    <br />
                    <ol class="list-text" style="list-style-type: none">
                        <li id="linotAllotted" runat="server" visible="False">
                            <p align="justify"><b>General Instructions for all Candidate who have not allotted any seat in Subsequent Rounds:-</b></p>
                            <ol type="a">
                                <li>
                                    <p align="justify">
                                        You have not allotted any Seat in CAP Round I. You are eligible for next CAP Round.
                                        <br />
                                        तुम्हाला कॅप राउंड १ मध्ये जागेचे वाटप झालेले नाही. तुम्ही पुढील कॅप राउंड मध्ये भाग घेण्यास पात्र आहात.
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">For detail read Rule No 9 from the Information Brochure. (तपशीलवार माहितीसाठी माहितीपुस्तिकेतील नियम क्रमांक 9 वाचा.)</p>
                                </li>
                            </ol>
                        </li>
                        <li id="trNosubmittedOptions" runat="server" visible="False">
                            <p align="justify"><b>General Instructions for all Candidate who have not Submitted options for CAP Rounds :-</b></p>
                            <ol type="a">
                                <li>
                                    <p align="justify">
                                        You have not submited options for CAP Round I for seat allotment. You are eligible for next CAP Round.
                                        <br />
                                        तुम्ही कॅप राउंड १ मध्ये पर्याय सबमिट केले नसल्यामुळे तुम्हाला जागेचे वाटप झालेले नाही. तुम्ही पुढील कॅप राउंड मध्ये भाग घेण्यास पात्र आहात.
                                    </p>
                                </li>
                                <li>
                                    <p align="justify">For detail read Rule No 9 from the Information Brochure. (तपशीलवार माहितीसाठी माहितीपुस्तिकेतील नियम क्रमांक 9 वाचा.)</p>
                                </li>
                            </ol>
                        </li>
                    </ol>
                    <center><font size="2"><b>*******************</b></font></center>
                </td>

            </tr>
            <tr id="trInstructionsARCReportingCAPRound2" runat="server" visible="false">
                <td>
                    <uc1:CAP2 ID="CAP2" runat="server" />
                </td>

            </tr>
            <tr id="trInstructionsARCReportingCAPRound3" runat="server" visible="false">
                <td>
                    <uc2:CAP3 ID="CAP3" runat="server" />
                </td>
            </tr>
            <tr id="trInstructionsARCReportingCAPRound4" runat="server" visible="false">
                <td></td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
