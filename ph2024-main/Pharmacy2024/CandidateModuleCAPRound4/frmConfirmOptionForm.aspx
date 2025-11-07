<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenu.Master" AutoEventWireup="true" CodeBehind="frmConfirmOptionForm.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound4.frmConfirmOptionForm" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type = "text/javascript">
        $(document).ready(function () {
            var success = document.getElementById('<%= hdnStepID.ClientID%>').value;
            for (var i = 1; i <= success; i++) {
                $('#nav' + i).addClass('sf-success');
            }
        });
    </script>
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function clickButton(e, buttonid) 
        {
            var evt = e ? e : window.event;
            var bt = document.getElementById(buttonid);
            if (bt) 
            {
                if (evt.keyCode == 13) 
                {
                    bt.click();
                    return false;
                }
            }
        }
        function checkConfirmation(Source, args) 
        {
            var confirmationValue = confirm("I agree to Confirm my Option Form. \nI am aware that I will not be able to modify / change / alter my Choices once I confirm the Option Form.\n\nAre you sure you want to confirm your Option Form ?");
            if (confirmationValue == true) 
            {
                var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                cvCheckConfirmation.errormessage = 'We are confirming your Option Form. Please wait...';
                args.IsValid = true;
            }
            else 
            {
                var cvCheckConfirmation = document.getElementById("rightContainer_ContentTable2_cvCheckConfirmation");
                cvCheckConfirmation.errormessage = 'We are not confirming your Option Form...';
                args.IsValid = false;
            }
        }
        function openPopUpBox() 
        {
            document.getElementById("<%=ContentBox1.ClientID %>").Show('#000000', true);
        }
    </script>
    <cc1:ContentBox ID="cbMenu" runat="server" HeaderVisible="false">
        <center>
            <div class="stepsForm">
                <div class="sf-steps">
                    <div class="sf-steps-content">
                    	<div id ="nav1">
                        	<span>1</span><a id="a_1" runat="server" class="formWizard" href="frmShortListOptions.aspx?tms=101">Shortlist Your Options</a>
                        </div>
                        <div id="nav2">
                        	<span>2</span><a id="a_2" runat="server" class="formWizard" href="frmSetPreferences.aspx?tms=101">Set Your Preferences</a>
                        </div>
                        <div  id="nav3">
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
                            <asp:Button id="btnViewInformation" runat="server" Text="View Personal Information & Important Instructions" CssClass="InputButton" BackColor="#5cb85c" OnClientClick="openPopUpBox();" OnClick="btnViewInformation_click" CausesValidation="false"></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td align = "right">
                    <asp:Button id="btnInsert" runat="server" Text="Insert Choice Code" CssClass="InputButton" BackColor="#d9332c" OnClick="btnInsert_Click" CausesValidation="false"></asp:Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button id="btnInsertDirect" runat="server" Text="Insert Choice Code Directly" CssClass="InputButton" BackColor="#d9332c" OnClick="btnInsertDirect_Click" CausesValidation="false"></asp:Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button id="btnMove" runat="server" Text="Move Choice Code" CssClass="InputButton" BackColor="#d9332c" OnClick="btnMove_Click" CausesValidation="false"></asp:Button>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th colspan = "4" align = "left"><font size="2">List of Options Given By You</font></th>
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
           
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align = "center">
                    <asp:Button ID="btnProceed" runat="server" Text="Confirm Option Form" CssClass="InputButton" OnClick="btnProceed_Click"  />
                    <asp:CustomValidator ID="cvCheckConfirmation" runat="server" ClientValidationFunction="checkConfirmation" Display = "None" ErrorMessage=""></asp:CustomValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox1" runat="server" BoxType = "PopupBox" BackColor="#e7fafe" Width = "1000px" Height="530px" ScrollBars="Auto" HeaderText="Personal Information & Important Instructions">
        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
            <ContentTemplate>
                <table class="AppFormTable" style="background-color: #e7fafe;">
                    <tr>
                        <th colspan="4" align="left">Personal Information</th>
                    </tr>
                    <tr>
                        <td style="width: 20%" align="right">Application ID</td>
                        <td style="width: 30%"><asp:Label ID="lblApplicationID" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td style="width: 20%" align="right">Candidate Name</td>
                        <td style="width: 30%"><asp:Label ID="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Gender</td>
                        <td><asp:Label ID="lblGender" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Date of Birth</td>
			            <td><asp:Label  ID="lblDOB" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Candidature Type</td>
                        <td><asp:Label ID="lblCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Home University</td>
		                <td><asp:Label id="lblHomeUniversity" runat="server" Font-Bold = "true"></asp:Label></td>
		            </tr>
                    <tr>
                        <td align="right">Category for Admission</td>
                        <td><asp:Label id="lblCategoryForAdmission" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Person with Disability</td>
                        <td><asp:Label id="lblPHType" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                     <tr>
                        <td align="right">Applied for EWS </td>
                        <td><asp:Label id="lblAppliedforEWS" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Applied for Orphan </td>
                        <td><asp:Label id="lblAppliedforOrphan" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Defence Type</td>
                        <td><asp:Label id="lblDefenceType" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Applied for TFWS</td>
                        <td><asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Minority Candidature Type</td>
                        <td colspan="3"><asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>
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
                                <li><p align = "justify">Please verify the correctness of the information filled. In case of any correction, do it online before confirmation.</p></li>
                                <li><p align = "justify">You will not be able to modify preferences, add choices, delete choices after confirmation of Online Option Form.</p></li>
                                <li><p align = "justify">Your Option Form once confirmed will not be cancelled.</p></li>
                                <li><p align = "justify">Your Option Form once confirmed can not be changed.</p></li>
                                <li><p align = "justify">Once you are sure then confirm your Option Form and take print out of FINAL Receipt-Cum-Acknowledgement of Option Form. You can repeat these steps as many times as you want till you Confirm your Option Form.</p></li>
                                <li><p align = "justify">The Option Form just submitted, but not confirmed by the candidate himself/herself will not be processed for allotment for Additional Round for Government / Government-Aided Institutes.</font></p></li>
                            </ol>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>


