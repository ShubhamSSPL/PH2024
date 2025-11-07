<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrintOptionForm.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound3.frmPrintOptionForm" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
    <link rel="stylesheet" href="../Styles/Style.css" type="text/css" />
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <cc1:ShowMessage ID="shInfo" runat="server"></cc1:ShowMessage>
        <%--<table class="AppFormTable">
                <tr>
                    <%--<td align="center"><img src="../Images/Header.jpg" alt = "" /></td> 
                </tr>
                <tr>
                    <td align="center"><font size="2"><b>Receipt-cum-Acknowledgement of Option Form for CAP Round - III for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></b></font></td>
                </tr>
            </table> --%>
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
                        <font size="2"><b>Receipt-cum-Acknowledgement of Option Form for CAP Round - III for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></b></font>
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
                <td style="width: 25%" align="right">Candidate's Name</td>
                <td style="width: 75%" colspan="3">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Father's Name</td>
                <td>
                    <asp:Label ID="lblFatherName" runat="server" Font-Bold="true"></asp:Label></td>          
                <td align="right">Mother's Name</td>
                <td>
                    <asp:Label ID="lblMotherName" runat="server" Font-Bold="true"></asp:Label></td>
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
                <td align="right">Category</td>
                <td>
                    <asp:Label ID="lblOriginalCategory" runat="server" Font-Bold="true"></asp:Label></td>           
                <td align="right">Category for Admission</td>
                <td>
                    <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label></td>
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
                <td align="right">Person with Disability</td>
                <td>
                    <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></td>            
                <td align="right">Defence Type</td>
                <td>
                    <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for TFWS</td>
                <td>
                    <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label></td>            
                <td align="right">Minority Candidature Type</td>
                <td>
                    <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
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
                        <font color="red">
                            <ol class="list-text">
                                    <li>Filling up and confirmation of online option form having preferences of Courses and Institutions prior to respective CAP Rounds. Candidates may fill in preferences of Institutes and Courses in decreasing order of their preference as specified by Competent Authority. The option form once confirmed by the candidate through their login shall be considered for allotment in the respective CAP Rounds.</li>
                                    <li>Candidates may fill in maximum 300 choices of Institutes and Courses in decreasing order of their preference.</li>
                                    <li>In order to participate in the CAP (subject to fulfilment of the eligibility requirements of respective CAP round), it is MANDATORY to fill the Online Option Form for respective CAP Round.</li>
                                    <li>It is mandatory for all eligible candidates to confirm the online option form.</li>
                                    <li>After confirmation of Option form, the candidate will not be able to change the Options.</li>
                                    <li>The serial number of blocks in the option form indicates preference of choice. Thus, the choice code of the institute filled by the candidate in block No. 1 will be considered as first preference (Highest Priority Choice).</li>
                                    <li>Option form received through online submission only will be considered for further processing. </li>
                                    <li>Candidate shall confirm the submitted on-line Option Form by re-entering Login Password. The candidate can take a printout of the confirmed Option form for his record and future reference.</li>
                                    <li>Candidates should not disclose their Application ID & Password to others to avoid impersonation. Competent Authority shall not be responsible for submissions done by others on behalf of the candidate. For Security reasons, candidates are instructed to keep changing the password and keep note of it in secured place.</li>
                                </ol>
                        </font>
                    </p>
                </td>
            </tr>
            <tr id="receiptcandidates" runat="server" visible="false">
                <td colspan="4">
                    <p align="justify">
                        <font color="red">The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                            
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

                            <br />
                            <br />
                            The Option Form for CAP Round III shall be considered subject to fulfillment of other eligibility conditions.
                        </font>
                    </p>
                </td>

            </tr>
        </table>
        <table class="AppFormTable">
            <tr id="trCVC" runat="server" visible="false">
                <%--<td colspan = "4">
                            $ --Candidates should submit Caste Validity Certificate/ Tribe Validity Certificate before 10 August 2019 at Application Receipt Centers to claim Category benefit for admission, otherwise your admission shall stand cancelled.
                        </td>--%>
            </tr>
            <tr id="trNCL" runat="server" visible="false">
                <%--<td colspan = "4">
                            # -- Candidates should submit Non Creamy Layer Certificate valid up to 31/03/2019, at Application Receipt Centers to claim Category benefit for admission, otherwise your admission shall stand cancelled.
                        </td>--%>
            </tr>
            <tr>
                <th style="border-top-width: 0px;" align="center" colspan="2"><font size="2">Declaration</font></th>
            </tr>
            <tr>
                <td colspan="2">
                    <p align="justify">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            I have read all the rules of admission and Information brochure for admission to UG courses <%=CurrentYear%> and on understanding these Rules, I have filled this Option Form for consideration for CAP Round - III for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>. The information given by me in this Option Form is true to the best of my knowledge & belief. If at later stage, it is found that I have furnished wrong information and/or submitted false certificate(s), I am aware that my admission stands cancelled and fees paid by me will be forfeited. Further I will be subject to legal and/or penal action as per the provisions of the law.
                    </p>
                </td>
            </tr>
            <tr>
                <td style="width: 60%">Printed On :
                    <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 40%" align="center" valign="bottom" rowspan="3">Signature of Candidate
                        <br />
                    (<asp:Label ID="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
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
                            The Option Form for CAP Round - III for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %> is confirmed as per the choices given above. We hereby acknowledge the confirmed Option Form.
                    </p>
                </td>
            </tr>
            <tr>
                <td>Confirmed On :
                    <asp:Label ID="lblConfirmedOn" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center" valign="bottom" rowspan="2">Commissioner & Competent Authority
                        <br />
                    State CET Cell, Maharashtra State, Mumbai
                </td>
            </tr>
            <tr>
                <td>Confirmed By :
                    <asp:Label ID="lblConfirmedBy" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>


