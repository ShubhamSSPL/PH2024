<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmOptionForm.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound4.frmOptionForm" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function OpenPopUpWindow() 
        {
            window.open("frmPrintOptionForm.aspx", "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes");
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderVisible="false">
        <table class="AppFormTableWithOutBorder">
		    <tr>
		        <td align="center">
		            <input id="btnPrint1" type="button" runat = "server" value="Print Option Form" class="InputButton" onclick="javascript:OpenPopUpWindow()" />
			    </td>
		    </tr>
            <tr>
                <td>
                    <div id = "Note">
                        <font color="red"> 
	                        <ol class="list-text"><b>Important Instructions for Printing :</b>
	                            <li>
	                                Before printing acess the <b>"Page Setup"</b> Option from file menu and configure the following values :
	                                <ol type ="a" class="list-text">
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
                <td align="center"><img src="../Images/Header.jpg" alt = "" /></td>
            </tr>
            <tr>
                <td align="center"><font size="2"><b>Receipt-cum-Acknowledgement of Option Form for Additional Round for Government / Government-Aided Institutes for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></b></font></td>
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
                <th style="border-top-width:0px;" colspan = "2" align = "left"><font size="2">Personal Details</font></th>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Candidate's Name</td>
                <td style="width: 75%"><asp:Label ID="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Father's Name</td>
                <td><asp:Label ID="lblFatherName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Mother's Name</td>
                <td><asp:Label ID="lblMotherName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Gender</td>
                <td><asp:Label ID="lblGender" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
			    <td align="right">Date of Birth</td>
			    <td><asp:Label  ID="lblDOB" runat="server" Font-Bold = "true"></asp:Label></td>
		    </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td><asp:Label ID="lblCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
	            <td align="right">Home University</td>
		        <td><asp:Label id="lblHomeUniversity" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category</td>
                <td><asp:Label id="lblOriginalCategory" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category for Admission</td>
                <td><asp:Label id="lblCategoryForAdmission" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
             <tr>
                <td align="right">
                    Applied for EWS
                </td>
                <td>
                    <asp:Label ID="lblAppliedforEWS" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Applied for Orphan
                </td>
                <td>
                    <asp:Label ID="lblAppliedforOrphan" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">Person with Disability</td>
                <td><asp:Label id="lblPHType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Defence Type</td>
                <td><asp:Label id="lblDefenceType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for TFWS</td>
                <td><asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Minority Candidature Type</td>
                <td><asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width:0px;" colspan = "4" align = "left"><font size="2">Options Given By Candidate</font></th>
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
        </table>
        <table class="AppFormTable">
            <tr> 
                <th style="border-top-width:0px;" align="center" colspan = "2"><font size="2">Declaration</font></th>
            </tr>
            <tr>
                <td colspan = "2">
                    <p align = "justify">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        I have read all the rules of admission and Information brochure for admission to UG courses <%=CurrentYear%> and on understanding these Rules, I have filled this Option Form for consideration for allotment in Additional Round for Government / Government-Aided Institutes.
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        I am aware that if I get allotment / betterment in this round then my earlier admission in Govt, Aided or University Department (if any) shall be cancelled automatically and it will be mandatory for me to report to the allotted institute in this round.
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        I also know that vacancy created due to cancellation of admission (if any) shall be offered to other eligible candidate as per the inter se merit, therefore I shall not request for restoration of the earlier cancelled admission.
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        The rules of refund of fees due to cancellation shall be applicable, if I get allotment in this round.
                    </p>
                </td>
            </tr>
            <tr>
                <td style="width: 60%">Printed On : <asp:Label id="lblPrintedOn" runat="server" Font-Bold = "true"></asp:Label></td>
                <td style="width: 40%" align = "center" valign="bottom" rowspan="3"> 
                    Signature of Candidate
                    <br />
                    (<asp:Label id="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
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
                        The Option Form for Additional Round for Government / Government-Aided Institutes for Admission to First Year of Under Graduate Technical Courses in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %> is confirmed as per the choices given above. We hereby acknowledge the confirmed Option Form.
                    </p>
                </td>
            </tr>
            <tr>
                <td>Confirmed On : <asp:Label id="lblConfirmedOn" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align = "center" valign="bottom" rowspan="2">
                    Commissioner & Competent Authority
                    <br />
                    State CET Cell, Maharashtra State, Mumbai
                </td>
            </tr>
            <tr>
                <td>Confirmed By : <asp:Label id="lblConfirmedBy" runat="server" Font-Bold = "true"></asp:Label></td>
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
