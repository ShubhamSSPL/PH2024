<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrintOptionForm.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound1.frmPrintOptionForm" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1" runat="server">
        <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
        <link rel="stylesheet" href="../Styles/Style.css" type="text/css" />
    </head>
    <body onload = "window.print();">
        <form id="form1" runat="server">
            <cc1:ShowMessage id="shInfo" runat="server"></cc1:ShowMessage>
            <table class="AppFormTable" id="tblHeader2" runat="server">
                <tr>
                    <td style="width:10%;border-right-width:0px;" align="center"><img src="../Images/WebsiteLogo.png" alt = ""  style="width:73px; height:auto"/></td>
                    <td style="width:80%;border-left-width:0px;" align="center">
                        <b>
                            <img src="../Images/WebsiteLogoOld_Print.png" alt = ""  /><br/>
                            <font size="4">G</font><font size="2">OVERNMENT</font> <font size="4">O</font><font size="2">F</font> <font size="4">M</font><font size="2">AHARASHTRA</font><BR />
                            <font size="4">S</font><font size="2">TATE</font> <font size="4">C</font><font size="2">OMMON</font> <font size="4">E</font><font size="2">NTRANCE</font> <font size="4">T</font><font size="2">EST</font> <font size="4">C</font><font size="2">ELL,</font> <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font>
                            <br />
                            <font size = "1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
                            <br /><br />
                            <font size="2"><b>Receipt-cum-Acknowledgement of Option Form for CAP Round - I for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></b></font>
                        </b>
                    </td>
                    <td style="width:10%;border-left-width:0px;" align="center"><img src="../Images/ARAFINAL.png" alt = ""  style="width:73px; height:auto"/></td>
                </tr>
            </table>
            <table class="AppFormTable">
                <tr>
                    <td style="border-top-width:0px;" align = "center">
                        <font size = "2">
                            Application ID : 
                            <asp:Label id="lblApplicationID" runat="server" Font-Bold="True"></asp:Label>
                            &nbsp;&nbsp;
                            Version No : 
                            <asp:Label id="lblVersionNo" runat="server" Font-Bold="True"></asp:Label>
                        </font>
                    </td>
                </tr>
            </table>
            <table class="AppFormTable">
            <tr>
                <th style="border-top-width:0px;" colspan = "4" align = "left"><font size="2">Personal Details</font></th>
            </tr>
            <tr>
                <td style="width: 20%" align="right">Candidate's Name</td>
                <td style="width: 30%"><asp:Label ID="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td>

                 <td style="width: 20%" align="right">Father's Name</td>
                <td><asp:Label ID="lblFatherName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            
            <tr>
                <td align="right">Mother's Name</td>
                <td><asp:Label ID="lblMotherName" runat="server" Font-Bold = "true"></asp:Label></td>

                <td align="right">Gender</td>
                <td><asp:Label ID="lblGender" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            
            <tr>
			    <td align="right">Date of Birth</td>
			    <td><asp:Label  ID="lblDOB" runat="server" Font-Bold = "true"></asp:Label></td>

                <td align="right">Candidature Type</td>
                <td><asp:Label ID="lblCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>
		    </tr>
            
            <tr>
	            <td align="right">Home University</td>
		        <td><asp:Label id="lblHomeUniversity" runat="server" Font-Bold = "true"></asp:Label></td>

                <td align="right">Category</td>
                <td><asp:Label id="lblOriginalCategory" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            
            <tr>
                <td align="right">Category for Admission</td>
                <td><asp:Label id="lblCategoryForAdmission" runat="server" Font-Bold = "true"></asp:Label></td>

                <td align="right">Applied for EWS </td>
                <td><asp:Label id="lblAppliedforEWS" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            
            <tr>
                <td align="right">Applied for Orphan </td>
                <td><asp:Label id="lblAppliedforOrphan" runat="server" Font-Bold = "true"></asp:Label></td>

                <td align="right">Person with Disability</td>
                <td><asp:Label id="lblPHType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            
            <tr>
                <td align="right">Minority Candidature Type</td>
                <td><asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>

                <td align="right">Applied for TFWS</td>
                <td><asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Defence Type</td>
                <td colspan="3" style="width:20%"><asp:Label id="lblDefenceType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
        </table>
            <table class="AppFormTable">
                <tr>
                    <th style="border-top-width:0px;" colspan = "4" align = "left"><font size="2">Options Given By Candidate</font></th>
                </tr>
                  <tr>
                <td colspan="4">
                <asp:Label ID="lblFirstChoice" runat="server"></asp:Label>
                </td>
                    </tr>
                <tr>
                    <td style="width: 25%" valign="top" align="center">
		                <asp:GridView id="gvPreferencedOptionsList1" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" BorderWidth = "1px">
	                        <Columns>
	                            <asp:BoundField DataField="PreferenceNo" HeaderText="Preference Number">
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width = "50%" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                </asp:BoundField>
		                        <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width = "50%" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                </asp:BoundField>
	                        </Columns>
                        </asp:GridView>
		            </td>
		            <td style="width: 25%" valign="top" align="center">
			           <asp:GridView id="gvPreferencedOptionsList2" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" BorderWidth = "1px">
	                        <Columns>
	                            <asp:BoundField DataField="PreferenceNo" HeaderText="Preference Number">
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width = "50%" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                </asp:BoundField>
		                        <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width = "50%" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                </asp:BoundField>
	                        </Columns>
                        </asp:GridView>
		            </td>
		            <td style="width: 25%" valign="top" align="center">
			            <asp:GridView id="gvPreferencedOptionsList3" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" BorderWidth = "1px">
	                        <Columns>
	                            <asp:BoundField DataField="PreferenceNo" HeaderText="Preference Number">
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width = "50%" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                </asp:BoundField>
		                        <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width = "50%" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                </asp:BoundField>
	                        </Columns>
                        </asp:GridView>
                    </td>
                    <td style="width: 25%" valign="top" align="center">
			            <asp:GridView id="gvPreferencedOptionsList4" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" BorderWidth = "1px">
	                        <Columns>
	                            <asp:BoundField DataField="PreferenceNo" HeaderText="Preference Number">
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width = "50%" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                </asp:BoundField>
		                        <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                    <ItemStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width = "50%" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                                </asp:BoundField>
	                        </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr id="trInstructions" runat="server">
                    <td colspan = "4"><asp:Label id="lblInstructions" runat="server"></asp:Label></td>
                </tr>
              
                 <tr>
                <td colspan = "4">
                    <p align="justify">
                        <font color="red" size="2">जर उमेदवारास त्याच्या विकल्प नमुन्यातील पहिल्या पसंतीक्रमांकावरील(AutoFreeze) जागेचे वाटप झाल्यास असे वाटप प्रणालीतून आपोआप गोठविले जाईल व उमेदवार या जागेचा स्वीकार करेल. असे उमेदवार केंद्रीभूत प्रवेश प्रक्रियेच्या (कॅप) पुढील फेरींमध्ये सहभागी होण्यास पात्र नसतील. अश्या उमेदवारांना नंतर त्याच्या/तिच्या लॉगइनद्वारे कागदपत्रांची  पडताळणी ऑनलाइन पूर्ण करून जागा स्वीकृती शुल्क भरणे गरजेचे आहे. तदनंतर असे उमेदवार वाटप करण्यात आलेल्या जागेवर प्रवेश घेण्यासाठी वाटप करण्यात आलेल्या संस्थेमध्ये विहित वेळेत हजर होतील. जर अशा उमेदवाराने त्याच्या /तिच्या लॉगइनद्वारे ऑनलाइन सीट स्वीकृती (स्वयं पडताळणी) पूर्ण केली नाही तर ते त्यांना वाटप करण्यात आलेल्या जागेवरील हक्क आपोआप गमावतील आणि ती जागा पुढील फेरींसाठी उपलब्ध होईल. अश्या उमेदवारांकरिता करण्यात आलेले पहिल्या पसंतीक्रमांकावरील(AutoFreeze) हे जागावाटप अंतिम असेल.
                                <br />
                                <br />
                                If a candidate is allotted the seat as per his first preference, such allotment shall be auto freezed and the candidate shall accept the allotment so made. Such candidate shall then be not eligible for participation in the subsequent CAP rounds. Such candidates then complete the seat acceptance process self verification online through his/her login of documents and payment of seat acceptance fee. Thereafter such candidates shall report to the allotted institute and seek admission on the allotted seat. If such candidate does'nt complete online seat acceptance ( Self Verification) through his/her login, their claim on the allotted seat shall stand forfeited automatically and the seat shall become available for fresh allotment. For such candidate, the allotment so made shall be the final allotment.
                         </font>
                    </p>
                </td>
            </tr>
            </table>
            <table class="AppFormTable">
                <tr> 
                    <th style="border-top-width:0px;" align="center" colspan = "2"><font size="2">Declaration</font></th>
                </tr>
                <tr>
                    <td colspan = "2">
                        <p align = "justify">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            I have read all the rules of admission and Information brochure for admission to UG courses <%=CurrentYear%> and on understanding these Rules, I have filled this Option Form for consideration for CAP Round - I for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>. The information given by me in this Option Form is true to the best of my knowledge & belief. If at later stage, it is found that I have furnished wrong information and/or submitted false certificate(s), I am aware that my admission stands cancelled and fees paid by me will be forfeited. Further I will be subject to legal and/or penal action as per the provisions of the law.
                        </p>
                    </td>
                </tr>
                <tr>
                    <td style="width: 60%">Printed On : <asp:Label id="lblPrintedOn" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td style="width: 40%" align = "center" valign="bottom" rowspan="3">
                      <asp:Image ID="imgSignature1" width="133" Height="57" runat="server" AlternateText="Candidate Signature" />
                      <br />
                        Signature of Candidate
                        <br />
                        Confirmed By :(<asp:Label id="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
                    </td>
                </tr>
                <tr>
                    <td>Last Modified On : <asp:Label id="lblLastModifiedOn" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr>
                    <td>Last Modified By : <asp:Label id="lblLastModifiedBy" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr> 
                    <th align="center" colspan = "2"><font size="2">For Office Use Only</font></th>
                </tr>
                <tr>
                    <td colspan = "2">
                        <p align = "justify">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            The Option Form for CAP Round - I for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %> is confirmed as per the choices given above. We hereby acknowledge the confirmed Option Form.
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>Confirmed On : <asp:Label id="lblConfirmedOn" runat="server" Font-Bold = "true"></asp:Label></td>
                    <td align = "center" valign="bottom" rowspan="2">
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
                    <td>Confirmed By : <asp:Label id="lblConfirmedBy" runat="server" Font-Bold = "true"></asp:Label></td>
                </tr>
                <tr >
                <td align="center" colspan = "2">
                   <b>*This is a computer-generated document. No signature is required.* </b>
                </td>
            </table>
        </form>
    </body>
</html>


