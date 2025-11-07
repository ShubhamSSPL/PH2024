<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmInstitute_AdmissionApprovalFeeDetails.aspx.cs" Inherits="Pharmacy2024.ARAModule.frmInstitute_AdmissionApprovalFeeDetails" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script src="../Scripts/epoch_classes_current.js" type="text/javascript" language="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type = "text/javascript">
        function numbersonly(e) 
        {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) 
            {
                if (unicode < 48 || unicode > 57) 
                {
                    return false
                }
            }
        }
        function checkPaymentMode(sender, args) 
        {
            if (document.getElementById("rightContainer_ContentTable2_rbnOnline").checked) 
            {
            }
            else 
            {
                args.IsValid = false;
            }
        }
        function isDDDateValid(sender, args) 
        {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtDDDate").value;
            if (dateStr.length == 0) 
            {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat); // is format OK?
            if (matchArray == null) 
            {
                args.IsValid = false;
                return;
            }
            month = matchArray[3];
            day = matchArray[1];
            year = matchArray[5];
            if (year < 1900 || year >= 2080) 
            {
                args.IsValid = false;
                return;
            }
            if (month < 1 || month > 12) 
            {
                args.IsValid = false;
                return;
            }
            if (day < 1 || day > 31) 
            {
                args.IsValid = false;
                return;
            }
            if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) 
            {
                args.IsValid = false;
                return;
            }
            if (month == 2) 
            {
                var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
                if (day > 29 || (day == 29 && !isleap)) 
                {
                    args.IsValid = false;
                    return;
                }
            }
        }
        function load() 
        {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() 
        {
            if (document.getElementById('rightContainer_ContentTable2_txtDDDate') != null) 
            {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDDDate'));
            }
        }
        window.onload = load;
    </script>
        <script language="javascript" type = "text/javascript">
            window.history.forward(1);
            function OpenPopUpWindow() {
                window.open("frmPrintAdmissionApprovalFeeReceipt.aspx", "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes");
            }
        </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Pay Admission Approval Fee">
        <asp:UpdateProgress runat="server" id="PageUpdateProgress">
            <ProgressTemplate>
                <img src ="../Images/BigProgress.gif" alt = "" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upQualification">
            <ContentTemplate>
                <%--<table class="AppFormTableWithOutBorder">
                    <tr>
                        <td>
                            <font color="red">	
                                <ol class="list-text"><b>Instructions :</b><br /><br />
                                    <li><p align = "justify"><font color = "red">The Admission Approval Fee is <b>Rs. 1,000/-</b> for All Institutes.</font></p></li>
                                    <li><p align = "justify"><font color = "red">The Institute can pay the Admission Approval fee by Online Mode.</font></p></li>
                                    
                                </ol>
                            </font>
                            <br />
                        </td>
                    </tr>
                </table>--%>
                <table class="AppFormTable">
                    <tr>
                        <th colspan="2">Process Fee Details</th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvDashboardInstitute" runat="server" ShowFooter = "true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid"  >
                                <Columns>
                                    <asp:BoundField DataField="CourseName" HeaderText="Course Name<br/>(1)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" Wrap="true" Width="35%"/>
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="true" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseStatus1" HeaderText="Course Status" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" Wrap="true" Width="35%"/>
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="true" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CAPIntake" HeaderText="CAP <br />Intake<br/>(2)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TFWSIntake" HeaderText="TFWS <br />Intake<br/>(3)" HtmlEncode="false" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField> 
                                    <asp:BoundField DataField="DSEIntake" HeaderText="DSE <br />Intake<br/>(4)" HtmlEncode="false" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AnyOtherSchemeIntake" HeaderText="Any Other <br />Scheme <br /> Intake<br/>(3)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalNoofSeats" HeaderText="Total No of <br />Seats<br/>(4) = <br /> (2+3)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IntakeAmount" HeaderText="Intake Amount<br />(5) = (4) * <span class='rupee'>Rs.</span> 100/- <br />(Equal to or Not Less <br /> than <span class='rupee'>Rs.</span> 20000/-)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ILIntake" HeaderText="IL <br />Intake <br />(6)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NRIIntake" HeaderText="NRI <br />Intake <br />(7)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ILAmount" HeaderText="IL <br />Amount <br />(8) = <br />(6) * <span class='rupee'>Rs.</span> 2000/-" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NRIAmount" HeaderText="NRI<br />Amount <br />(9) = <br />(7) * <span class='rupee'>Rs.</span> 3000/-" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalAmount" HeaderText="Amount Payable  <br />as  <br /> Processing Fee(<span class='rupee'>Rs.</span>) <br /> (10) = (5 + 8 + 9)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField> 
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr> 
                     <tr>
                        <td style="width:50%" align="right">Online Process Fee to be Paid (<span class="rupee">Rs.</span>)</td>
                        <td style="width:50%"><asp:Label ID="lblApplicationFeeToBePaid" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width:30%" align="right">Select Payment Mode</td>
                        <td style="width:70%">
                            <asp:RadioButton ID="rbnOnline" runat="server" GroupName="PaymentMode" Text="&nbsp;&nbsp;Online (Credit Card / Debit Card / Net Banking)" AutoPostBack = "true" OnCheckedChanged="PaymentMode_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnDD" runat="server" GroupName="PaymentMode" Text="&nbsp;&nbsp;Demand Draft" AutoPostBack = "true" OnCheckedChanged="PaymentMode_CheckedChanged" Visible="false" />
                            <asp:CustomValidator ID="cvPaymentMode" runat="server" ClientValidationFunction="checkPaymentMode" Display="None" ErrorMessage="Please Select Payment Mode."></asp:CustomValidator>
                        </td> 
                    </tr>
                </table>
                <table class="AppFormTable" id="tblDDDetails" runat="server">
                    <tr>
                        <td style="width:25%;border-top-width:0px;" align="right">DD Amount (<span class="rupee">Rs.</span>)</td>
                        <td style="width:25%;border-top-width:0px;">
                            <asp:TextBox ID="txtDDAmount" runat="server" Width="89%" Enabled="false" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvDDAmount" Runat="server" ErrorMessage="Please Enter DD Amount." ControlToValidate="txtDDAmount" Display="None"></asp:RequiredFieldValidator>
                        </td>
			            <td style="width:25%;border-top-width:0px;" align="right">DD Number</td>
	                    <td style="width:25%;border-top-width:0px;">
                            <asp:TextBox ID="txtDDNumber" runat="server" Width="89%" MaxLength="6" onKeyPress="return numbersonly(event)"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvDDNo" Runat="server" ErrorMessage="Please Enter DD Number." ControlToValidate="txtDDNumber" Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revDDNo" Runat="server" ErrorMessage="DD Number should be Numeric and of 6 Digits." ControlToValidate="txtDDNumber" ValidationExpression="\d{6}" Display="None"></asp:RegularExpressionValidator>
                        </td>
		            </tr>
	    	        <tr>
			            <td align="right">DD Date</td>
				        <td>
				            <asp:TextBox  ID="txtDDDate" runat="server" MaxLength="10" Width="40%"></asp:TextBox>
                            <font color="red"><b>*</b></font> <font size="1">(DD/MM/YYYY)</font>
                            <asp:RequiredFieldValidator ID="rfvDate" Runat="server" ErrorMessage="Please Enter DD Date." ControlToValidate="txtDDDate" Display="None"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvDDDate" runat="server" ControlToValidate="txtDDDate" ClientValidationFunction="isDDDateValid" Display="None" ErrorMessage="Please Select Proper DD Date."></asp:CustomValidator>
                        </td>
                        <td align="right">Bank Name</td>
                        <td>
                            <asp:DropDownList ID="ddlBankName" runat="server" Width="89%" AutoPostBack="true" OnSelectedIndexChanged="ddlBankName_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red">*</font>
                            <asp:CompareValidator ID="cvBankName" runat="server" ControlToValidate="ddlBankName" ErrorMessage="Please Select Bank Name." ValueToCompare="0" Operator="NotEqual" Display="None"></asp:CompareValidator>
                        </td>
			        </tr>
			        <tr id = "trOtherBankName" runat = "server">
                        <td align = "right">Other Bank Name</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtOtherBankName" runat="server" MaxLength="100"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvOtherBankName" runat="server" ErrorMessage="Please Enter Other Bank Name." ControlToValidate="txtOtherBankName" Display="None"></asp:RequiredFieldValidator>
                        </td>
			         </tr>
		            <tr>
                        <td align="right">Branch Name</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtBranchName" Runat="server" MaxLength="100"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator id="rfvBranchName" Runat="server" Display="None" ControlToValidate="txtBranchName" ErrorMessage="Please Enter Branch Name."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align = "center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                    <asp:HiddenField ID="hdnFeeID" runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <script language="javascript" type="text/javascript">
            if (document.getElementById('rightContainer_ContentTable2_txtDDDate') != null) 
            {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDDDate'));
            }
        </script>
    </cc1:ContentBox>
     <cc1:ContentBox ID="ContentTable3" runat="server" HeaderText="Admission Approval Fee Paid Details">
          <asp:UpdateProgress runat="server" id="UpdateProgress1">
            <ProgressTemplate>
                <img src ="../Images/BigProgress.gif" alt = "" />
            </ProgressTemplate>
        </asp:UpdateProgress>
         <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                  <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td>
                            <font color="red">	
                                <ol class="list-text"><b>Instructions :</b><br /><br />
                                    <li><p align = "justify"><font color = "red">The Admission Approval Fee is Paid.</font></p></li>
                                </ol>
                            </font>
                            <br />
                        </td>
                    </tr>
                </table> 
                <table class="AppFormTable">
                    <tr>
                        <th colspan="2">Process Fee Details</th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvDashboardInstitute1" runat="server" ShowFooter = "true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid"  >
                                <Columns>
                                    <asp:BoundField DataField="CourseName" HeaderText="Course Name<br/>(1)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" Wrap="true" Width="35%"/>
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="true" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseStatus1" HeaderText="Course Status" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" Wrap="true" Width="35%"/>
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="true" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CAPIntake" HeaderText="CAP <br />Intake<br/>(2)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TFWSIntake" HeaderText="TFWS <br />Intake<br/>(3)" HtmlEncode="false" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField> 
                                    <asp:BoundField DataField="DSEIntake" HeaderText="DSE <br />Intake<br/>(4)" HtmlEncode="false" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AnyOtherSchemeIntake" HeaderText="Any Other <br />Scheme <br /> Intake<br/>(3)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalNoofSeats" HeaderText="Total No of <br />Seats<br/>(4) = <br /> (2+3)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IntakeAmount" HeaderText="Intake Amount<br />(5) = (4) * <span class='rupee'>Rs.</span> 100/- <br />(Equal to or Not Less <br /> than <span class='rupee'>Rs.</span> 20000/-)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ILIntake" HeaderText="IL <br />Intake <br />(6)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NRIIntake" HeaderText=" NRI <br />Intake <br />(7)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ILAmount" HeaderText="IL <br />Amount <br />(8) = <br />(7) * <span class='rupee'>Rs.</span> 2000/-" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NRIAmount" HeaderText="NRI<br />Amount <br />(9) = <br />(8) * <span class='rupee'>Rs.</span> 3000/-" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalAmount" HeaderText="Amount Payable  <br />as  <br /> Processing Fee(<span class='rupee'>Rs.</span>) <br /> (10) = (5 + 8 + 9)" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Wrap="false" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth = "1px" Font-Size="9px" BorderStyle = "Solid" CssClass="Header" Font-Bold="true"/>
                                    </asp:BoundField> 
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr> 
                     <tr>
                        <td style="width:50%" align="right">Online Process Fee Paid (<span class="rupee">Rs.</span>)</td>
                        <td style="width:50%"><asp:Label ID="lblAdmissionApprovalFeePaid" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
         <br />
         <table class="AppFormTableWithOutBorder">
            <tr>
                <td align = "center">
                    <input id="btnPrint1" type="button" runat="server" value="Print Receipt" class="InputButton" onclick="javascript: OpenPopUpWindow()" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
      <cc1:contentbox id="contentSecretKey" runat="server" headertext="Secret Key" boxtype="PopupBox"
                    width="50%" headervisible="false">
        <table class="AppFormTable">
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Text="This Screate is only for Testing Purpose. Merit List Verification Process is not statrted yet. It will be starting soon... "
                               ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblmsg" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;" align="right">
                    Enter Secret Key
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtkey" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSecretKey" runat="server" OnClick="btnSecretKey_Click" Text="Submit"
                                ValidationGroup="secret" />
                </td>
            </tr>
        </table>
        <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
    </cc1:contentbox>
      <script language="javascript" type="text/javascript">
          function showSecretKey() {
              document.getElementById('<%=contentSecretKey.ClientID %>').Show('', true);
          }
      </script>
</asp:Content>

