<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmOptionForm.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound2.frmOptionForm" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .setmargin {
            margin-left: -225px;
        }

        .unsetmargin {
            margin-left: unset !important;
        }
    </style>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function OpenPopUpWindow() {
            window.open("frmPrintOptionForm.aspx", "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes");
        }
        window.onload = function (e) {
            const queryString = window.location.search;
            const urlParams = new URLSearchParams(queryString);
            const tms = urlParams.get('tms')
            if (tms != null) {
                document.getElementById("layoutSidenav_content").classList.add('unsetmargin');
            }
            else {
                document.getElementById("layoutSidenav_content").classList.add('setmargin');
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <input id="btnPrint1" type="button" runat="server" value="Print Option Form" class="InputButton" onclick="javascript:OpenPopUpWindow()" />
                </td>
            </tr>
            <tr>
                <td>
                    <div id="Note">
                        <font color="red">
                            <ol class="list-text">
                                <b>Important Instructions for Printing :</b>
                                <li>Before printing acess the <b>"Page Setup"</b> Option from file menu and configure the following values :
	                                <ol type="a" class="list-text">
                                        <li>Left Margin = 0.25</li>
                                        <li>Right Margin = 0.25</li>
                                        <li>Top Margin = 0.25</li>
                                        <li>Bottom Margin = 0.25</li>
                                        <li>Header should be blank</li>
                                        <li>Footer should be blank</li>
                                    </ol>
                                </li>
                                <li>Make sure that the printer is ready with <b>A4</b> size papers in it.</li>
                                <li>The online system will print <b>Option Form</b>.</li>
                                <li>Confirm whether you have received correct set of printout if not then please take the printouts again.</li>
                            </ol>
                        </font>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <td style="width: 10%; border-right-width: 0px;" align="center">
                    <img src="../Images/WebsiteLogo.png" alt="" style="width: 73px; height: auto" /></td>
                <td style="width: 80%; border-left-width: 0px;" align="center">
                    <b>
                        <img src="../Images/WebsiteLogoOld_Print.png" alt="" /><br />
                        <font size="4">G</font><font size="2">OVERNMENT</font> <font size="4">O</font><font size="2">F</font> <font size="4">M</font><font size="2">AHARASHTRA</font><br />
                        <font size="4">S</font><font size="2">TATE</font> <font size="4">C</font><font size="2">OMMON</font> <font size="4">E</font><font size="2">NTRANCE</font> <font size="4">T</font><font size="2">EST</font> <font size="4">C</font><font size="2">ELL,</font> <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font>
                        <br />
                        <font size="1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
                        <br />
                        <br />
                        Receipt-cum-Acknowledgement of Option Form for CAP Round - II for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>
                    </b>
                </td>
                <td style="width: 10%; border-left-width: 0px;" align="center">
                    <img src="../Images/ARAFINAL.png" alt="" style="width: 73px; height: auto" /></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="border-top-width: 0px;" align="center">
                    <font size="2">Application ID : 
                        <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;
                        Version No : 
                        <asp:Label ID="lblVersionNo" runat="server" Font-Bold="True"></asp:Label>
                    </font>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" colspan="4" align="left"><font size="2">Personal Details</font></th>
            </tr>
            <tr>
                <td style="width: 22%" align="right">Candidate's Name</td>
                <td style="width: 30%">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>

                <td style="width: 20%" align="right">Father's Name</td>
                <td>
                    <asp:Label ID="lblFatherName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>

            <tr>
                <td align="right">Mother's Name</td>
                <td>
                    <asp:Label ID="lblMotherName" runat="server" Font-Bold="true"></asp:Label></td>

                <td align="right">Gender</td>
                <td>
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>

            <tr>
                <td align="right">Date of Birth</td>
                <td>
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label></td>

                <td align="right">Candidature Type</td>
                <td>
                    <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>

            <tr>
                <td align="right">Home University</td>
                <td>
                    <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label></td>

                <td align="right">Category</td>
                <td>
                    <asp:Label ID="lblOriginalCategory" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>

            <tr>
                <td align="right">Category for Admission</td>
                <td>
                    <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label></td>

                <td align="right">Applied for EWS </td>
                <td>
                    <asp:Label ID="lblAppliedforEWS" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>

            <tr>
                <td align="right">Applied for Orphan </td>
                <td>
                    <asp:Label ID="lblAppliedforOrphan" runat="server" Font-Bold="true"></asp:Label></td>

                <td align="right">Person with Disability</td>
                <td>
                    <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>

            <tr>
                <td align="right">Minority Candidature Type</td>
                <td>
                    <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>

                <td align="right">Applied for TFWS</td>
                <td>
                    <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>

            <tr>
                <td align="right">Defence Type</td>
                <td colspan="3" style="width: 20%">
                    <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" colspan="4" align="left"><font size="2">Options Given By Candidate</font></th>
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
            <tr id="trInstructions" runat="server">
                <td colspan="4">
                    <asp:Label ID="lblInstructions" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4">
                    <p align="justify">
                        <font color="red">ज्या उमेदवारांना पहिल्या पसंतीक्रमांकाखेरीज इतर  पसंतीक्रमांकावरील जागेचे वाटप झाले आणि पडताळणी स्वत: च्या लॉग-इन मधून करावी अशा उमेदवारांनी नविन विकल्प नमुना भरतांना  त्यांना पूर्वीच्या फेरीमध्ये वाटप झालेला विकल्प त्यांच्या पसंतीक्रमाच्या यादीत नमूद करणार नाहीत, संगणकीय प्रणालीद्वारे तो विकल्प यादीच्या शेवटी समाविष्ट करण्यात येईल. जर वरच्या पसंतीक्रमानुसार नवीन जागेचे वाटप करण्यात आले की अगोदर करण्यात आलेले वाटप आपोआप रदद होईल. वरच्या पसंतीक्रमानुसार नवीन जागेचे वाटप न झाल्यास पूर्वीच्या फेरीमधील वाटप अबाधित राहील.
                            <br />
                            <br />
                            Candidates who have been allotted seat other than first preference and through candidate’s Login & Verify the correctness of the seat allotment made, whilst filling fresh option form, he/she need not fill the preference already allotted to the candidate in the previous round. Once upward preference is allotted to such candidate, his earlier seat allotment shall stand automatically cancelled. In the event of no such upward preference is allotted, his previous allotment stands retained.
                            <br />
                           <%-- <br />
                            उमेदवारास दुसऱ्य प्रवेशफेरी नंतर वरच्या पसंतीक्रमावरील जागेच्या वाटपाची संधी नसेल. दुसऱ्य प्रवेश फेरीमध्ये सहभागी झालेल्या उमेदवारांना दुसऱ्य फेरीत करण्यात आलेले वाटप किंवा पूर्वीचे अबाधित ठेवण्यात आलेले वाटप हे अंतिम वाटप असेल.
                            <br />
                            <br />
                            There shall be no further betterment option available to the candidate after round-II. The allotment made and/or allotment retained in round-II for participating candidates in round-II shall be final.--%>
                        </font>
                    </p>
                </td>
            </tr>
            <tr id="receiptcandidates" runat="server" visible="false">
                <td colspan="4">
                    <p align="justify">
                        <font color="red">The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                            
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                            <br />
                            <br />
                            The Option Form for CAP Round II shall be considered subject to fulfillment of other eligibility conditions.
                        </font>
                    </p>
                </td>

            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" align="center" colspan="2"><font size="2">Declaration</font></th>
            </tr>
            <tr>
                <td colspan="2">
                    <p align="justify">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        I have read all the rules of admission and Information brochure for admission to UG courses <%=CurrentYear%> and on understanding these Rules, I have filled this Option Form for consideration for CAP Round - II for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>. The information given by me in this Option Form is true to the best of my knowledge & belief. If at later stage, it is found that I have furnished wrong information and/or submitted false certificate(s), I am aware that my admission stands cancelled and fees paid by me will be forfeited. Further I will be subject to legal and/or penal action as per the provisions of the law.
                    </p>
                </td>
            </tr>
            <tr>
                <td style="width: 60%">Printed On :
                    <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 40%" align="center" valign="bottom" rowspan="3">Signature of Candidate
                    <br />
                    Confirmed By :(<asp:Label ID="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
                </td>
            </tr>
            <tr>
                <td>Last Modified On :
                    <asp:Label ID="lblLastModifiedOn" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td>Last Modified By :
                    <asp:Label ID="lblLastModifiedBy" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <th align="center" colspan="2"><font size="2">For Office Use Only</font></th>
            </tr>
            <tr>
                <td colspan="2">
                    <p align="justify">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        The Option Form for CAP Round - II for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %> is confirmed as per the choices given above. We hereby acknowledge the confirmed Option Form.
                    </p>
                </td>
            </tr>
            <tr>
                <td>Confirmed On :
                    <asp:Label ID="lblConfirmedOn" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center" valign="bottom" rowspan="2">
                    <%--sd./--%>
                    <br />
                    Commissioner
                    <%--Chairman, Admission Committee (Technical
                    <br />
                    Education) & Exam Coordinator--%>
                    <br />
                    State CET Cell, MS, Mumbai 
                </td>
            </tr>
            <tr>
                <td>Confirmed By :
                    <asp:Label ID="lblConfirmedBy" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center" width="100%">
                    <input id="btnPrint2" type="button" value="Print Option Form" class="InputButton" onclick="javascript:OpenPopUpWindow()" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
