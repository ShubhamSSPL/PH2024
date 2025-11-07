<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrintOptionFormCAPRound1.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmPrintOptionFormCAPRound1" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
    <link rel="stylesheet" href="../Styles/Style.css" type="text/css" />
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <cc1:ShowMessage id="shInfo" runat="server"></cc1:ShowMessage>
        <table class="AppFormTable">
            <tr>
                <td style="width: 10%; border-right-width: 0px;" align="center">
                    <img src="../Images/dtelogo.jpg" alt="" /></td>
                <td style="width: 90%; border-left-width: 0px;" align="center">
                    <b>
                        <font size="4">S</font><font size="2">TATE</font> <font size="4">C</font><font size="2">OMMON</font> <font size="4">E</font><font size="2">NTRANCE</font> <font size="4">T</font><font size="2">EST</font> <font size="4">C</font><font size="2">ELL,</font> <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font>
                        <br />
                        <font size="1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
                        <br />
                        <br />
                        <font size="2"><b>Receipt-cum-Acknowledgement of Option Form for CAP Round - I for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></b></font>
                    </b>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="border-top-width: 0px;" align="center">
                    <font size="3">Application ID : 
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
                <th style="border-top-width: 0px;" colspan="2" align="left">Personal Details</th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Candidate's Full Name</td>
                <td style="width: 75%">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Father's Name</td>
                <td>
                    <asp:Label ID="lblFatherName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Mother's Name</td>
                <td>
                    <asp:Label ID="lblMotherName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Gender</td>
                <td>
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Date of Birth</td>
                <td>
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td>
                    <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Home University</td>
                <td>
                    <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category</td>
                <td>
                    <asp:Label ID="lblOriginalCategory" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category for Admission</td>
                <td>
                    <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Person with Disability</td>
                <td>
                    <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Defence Type</td>
                <td>
                    <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
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
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" align="center" colspan="2"><font size="2">Declaration</font></th>
            </tr>
            <tr>
                <td colspan="2">
                    <p align="justify">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            I have read all the rules of admission and Information brochure for admission to UG courses <%=CurrentYear%> and on understanding these Rules, I have filled this Option Form for consideration for CAP Round - I for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>. The information given by me in this Option Form is true to the best of my knowledge & belief. If at later stage, it is found that I have furnished wrong information and/or submitted false certificate(s), I am aware that my admission stands cancelled and fees paid by me will be forfeited. Further I will be subject to legal and/or penal action as per the provisions of the law.
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
                            The Option Form for CAP Round - I for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %> is confirmed as per the choices given above. We hereby acknowledge the confirmed Option Form.
                    </p>
                </td>
            </tr>
            <tr>
                <td>Confirmed On :
                    <asp:Label ID="lblConfirmedOn" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="center" valign="bottom" rowspan="2">Commissioner & Competent Authority
                        <br />
                    CET Cell, Maharashtra State, Mumbai
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
