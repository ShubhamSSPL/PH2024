<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenu.Master" AutoEventWireup="true" CodeBehind="frmSetPreferences.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound4.frmSetPreferences" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <style>
            #rightContainer_ContentTable1_dgSetPreferences input[type='checkbox'] { width: 20px; height: 20px;} 
            #rightContainer_ContentTable1_dgSetPreferences input[type='text'] { width: 50px; height: 20px; font-weight:bold; text-align:center; font-size:medium; background-color:transparent; } 
    </style>
    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/ContentBox.js"></script>
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
        var Counter = "<%= CheckCount %>";
        function checkone(sender, args) 
        {
            if (Counter <= 0) 
            {
                args.IsValid = false;
                return;
            }
            var tbl = document.getElementById("rightContainer_ContentTable1_dgSetPreferences");
            for (var i = 1; i < tbl.rows.length; i++) 
            {
                tbl.rows[i].cells[8].children[0].disabled = false;
            }
            args.IsValid = true;
        }
        function checkpass(chkBox) 
        {
            if (chkBox.checked == true) 
            {
                if (Counter == 300) 
                {
                    chkBox.checked = false;
                    alert('You can not select Institutes more than 300.');
                    return;
                }
                Counter++;
                chkBox.parentNode.nextSibling.children[0].value = Counter;
                chkBox.parentNode.parentNode.className = "SelectedRow";
            }
            else 
            {
                chkBox.parentNode.parentNode.className = "";
                var temp, SeqNo = 0;
                temp = chkBox.parentNode.nextSibling.children[0].value;
                Counter--;
                chkBox.parentNode.nextSibling.children[0].value = "";
                var fNode, lNode, cNode;
                fNode = chkBox.parentNode.parentNode.parentNode.firstChild;
                lNode = chkBox.parentNode.parentNode.parentNode.lastChild;
                cNode = fNode.nextSibling;

                while (cNode != lNode) 
                {
                    if (Synthesys.Browser.IsIe) 
                    {
                        SeqNo = cNode.lastChild.children[0].value;

                        if (eval(SeqNo) > eval(temp)) 
                        {
                            cNode.lastChild.children[0].value = cNode.lastChild.children[0].value - 1;
                        }
                    }
                    else 
                    {
                        SeqNo = cNode.lastElementChild.children[0].value;

                        if (eval(SeqNo) > eval(temp)) 
                        {
                            cNode.lastElementChild.children[0].value = cNode.lastElementChild.children[0].value - 1;
                        }
                    }
                    cNode = cNode.nextSibling;
                }
                SeqNo = cNode.lastChild.children[0].value;
                if (eval(SeqNo) > eval(temp)) 
                {
                    cNode.lastChild.children[0].value = cNode.lastChild.children[0].value - 1;
                }
            }
        }
        function ressetpref() 
        {
            var table = document.getElementById("rightContainer_ContentTable1_dgSetPreferences");
            var chkArray = table.getElementsByTagName("input");

            for (i = 0; i <= chkArray.length - 1; i++) 
            {
                if (chkArray[i].type == 'checkbox') 
                {
                    chkArray[i].checked = false;
                }
                if (chkArray[i].type == 'text') 
                {
                    chkArray[i].value = '';
                }
                chkArray[i].parentNode.parentNode.className = '';
            }
            Counter = 0;
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
                        <div id="nav2" class="sf-active">
                        	<span>2</span><a id="a_2" runat="server" class="formWizard" href="frmSetPreferences.aspx?tms=101">Set Your Preferences</a>
                        </div>
                        <div  id="nav3">
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
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Set Preferences">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <asp:Button id="btnViewInformation" runat="server" Text="View Personal Information & Important Instructions" CssClass="InputButton" BackColor="#5cb85c" OnClientClick="openPopUpBox();" OnClick="btnViewInformation_click" CausesValidation="false"></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:DataGrid id="dgSetPreferences" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="5" OnItemDataBound="dgSetPreferences_ItemDataBound" CssClass = "DataGrid">
            <Columns>
                <asp:BoundColumn HeaderText="Sr. No.">
	                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold = "true" Width="5%" CssClass = "Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass = "Item" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="InstituteCode" ReadOnly="True" HeaderText="Institute Code">
	                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold = "true" Width="5%" CssClass = "Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass = "Item" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="InstituteName" ReadOnly="True" HeaderText="Institute Name" >
	                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold = "true" Width="35%" CssClass = "Header" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" CssClass = "Item" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="UniversityName" ReadOnly="True" HeaderText="University Name">
	                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold = "true" Width="20%" CssClass = "Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass = "Item" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField = "CourseType" HeaderText="SL / HU / OHU">
	                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold = "true" Width="5%" CssClass = "Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass = "Item" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="CourseName" HeaderText="Course Name">
	                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold = "true" Width="15%" CssClass = "Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass = "Item" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ChoiceCodeDisplay" ReadOnly="True" HeaderText="Choice Code">
	                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold = "true" Width="5%" CssClass = "Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass = "Item" />
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Set Preference">
	                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold = "true" Width="5%" CssClass = "Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass = "Item" />
	                <ItemTemplate>
		                <asp:CheckBox id="chkSetPreferences" runat="server"></asp:CheckBox>
	                </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Preference No.">
	                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold = "true" Width="5%" CssClass = "Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass = "Item" />
	                <ItemTemplate>
                        <asp:TextBox ID="txtPreferenceNo" runat="server" Text = '<%# Eval("PreferenceNo") %>' Enabled="true" ></asp:TextBox>
	                </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblChoiceCode" runat="server" Text='<%# Eval("ChoiceCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPreferenceNo" runat="server" Text='<%# Eval("PreferenceNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <input id="btnResetPref" onclick="ressetpref();" type="button" value="Reset my Preferences" class="InputButton" style="background-color:Red" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:CustomValidator ID="cvPreferances" runat="server" ErrorMessage="Please Set Preferences for Atleast One Choice Code." ClientValidationFunction="checkone" Display="None"></asp:CustomValidator>
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
                                <li><p align = "justify">Please click on the check boxes one by one to give your Preferences. When you click particular check box of an Institute the Preference will be generated and shown in the text box adjoining to the checkbox.</p></li>
                                <li><p align = "justify">You can set preferences to 300 options selected by you.</p></li>
                                <li><p align = "justify">You can reset the preferences by clicking on 'Reset My Preferences' Button.</p></li>
                                <li><p align = "justify">After setting all your Preferences, click on 'Save & Proceed' Button.</p></li>
                            </ol>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
    <script language="javascript" type = "text/javascript">
        var tbl = document.getElementById("rightContainer_ContentTable1_dgSetPreferences");
        for (var i = 1; i < tbl.rows.length; i++) 
        {
            tbl.rows[i].cells[8].children[0].disabled = true;
        }
    </script>
</asp:Content>


