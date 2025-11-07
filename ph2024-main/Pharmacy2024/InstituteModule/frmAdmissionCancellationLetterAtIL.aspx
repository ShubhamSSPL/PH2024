<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAdmissionCancellationLetterAtIL.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmAdmissionCancellationLetterAtIL" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        function OpenPopUpWindow() 
        {
            window.open("frmPrintAdmissionCancellationLetterAtIL.aspx?PID=<% = PID %>&ChoiceCode=<% = ChoiceCode %>", "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes");
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
                <td align = "center"><font size = "2"><b>Receipt-Cum-Acknowledgement of Cancellation of Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></b></font></td>
             </tr>
            <tr>
                <td align = "center">
                    <font size = "2">Application ID : </font><asp:Label id="lblApplicationID" runat="server" Font-Bold="True" Font-Size = "Small"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <font size = "2">Receipt No : </font><asp:Label id="lblReceiptNo" runat="server" Font-Bold="True" Font-Size = "Small"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width:0px;" colspan = "4" align = "left">Personal Details</th>
            </tr>
            <tr>
                <td align = "right">Candidate Name</td>
                <td colspan = "3"><asp:Label id="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:25%" align = "right">Gender</td>
                <td style="width:25%"><asp:Label id="lblGender" runat="server" Font-Bold = "true"></asp:Label></td>
                <td style="width:25%" align="right">Date Of Birth</td>
                <td style="width:25%"><asp:Label id="lblDOB" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td><asp:Label id="lblCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Home University</td>
	            <td><asp:Label id="lblHomeUniversity" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category</td>
                <td><asp:Label id="lblOriginalCategory" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Category for Admission</td>
                <td><asp:Label id="lblCategoryForAdmission" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for EWS</td>
                <td><asp:Label id="lblAppliedForEWS" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Applied for Orphan</td>
                <td><asp:Label id="lblAppliedForOrphan" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Person with Disability</td>
                <td><asp:Label id="lblPHType" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Defence Type</td>
                <td><asp:Label id="lblDefenceType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Linguistic Minority</td>
                <td><asp:Label ID="lblLinguisticMinority" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Religious Minority</td>
                <td><asp:Label ID="lblReligiousMinority" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Applied for TFWS</td>
                <td colspan="2">
                <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">HSC Eligibility Marks</td>
                <td><asp:Label id="lblHSCEligibilityPercentage" runat="server" Font-Bold = "true"></asp:Label></td> 
                <td align="right">Diploma Eligibility Marks</td>
                <td><asp:Label id="lblDiplomaEligibilityPercentage" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan = "4" align = "left">Admission Details</th>
            </tr>
            <tr>
                <td align="right">Merit No</td>
                <td><asp:Label id="lblMeritNo" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Merit Marks</td>
                <td><asp:Label id="lblMeritMarks" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Institute Name</td>
                <td colspan = "3"><asp:Label id="lblInstituteName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Name</td>
                <td colspan = "3"><asp:Label id="lblCourseName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Choice Code</td>
                <td><asp:Label id="lblChoiceCode" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Seat Type</td>
                <td><asp:Label id="lblSeatType" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
        <tr>
            <td align="right">Cancellation Requested by Candidate</td>
            <td><asp:Label id="lblCancellationRequestedOn" runat="server" Font-Bold = "true"></asp:Label></td>
            <td align="right">Cancellation Requested by IP Address</td>
            <td><asp:Label id="lblCancellationRequestedByIPAddress" runat="server" Font-Bold = "true"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">Online Cancellation Date</td>
            <td><asp:Label id="lblCancelledOn" runat="server" Font-Bold = "true"></asp:Label></td>
            <td align="right">Online Cancelled by Institute</td>
            <td><asp:Label id="lblCancelledBy" runat="server" Font-Bold = "true"></asp:Label></td>
        </tr>
            <tr>
                <td align="right">Online Cancelled by IP Address</td>
                <td><asp:Label id="lblCancelledByIPAddress" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Cancellation Charge (<span class='rupee'>Rs.</span>)</td>
                <td><asp:Label id="lblCancellationCharge" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr id = "trFeePaid1" runat = "server">
                <th colspan = "4" align = "left">Fee Details</th>
            </tr>
            <tr id = "trFeePaid2" runat = "server">
                <td colspan = "4">
                    <asp:GridView ID="gvFeePaidList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth = "1px" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "8%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "15%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FeeAmount" HeaderText="Fee Amount (<span class='rupee'>Rs.</span>)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "10%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDNumber" HeaderText="DD/Cheque Number">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "11%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDDate" HeaderText="Payment Date">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "11%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BankName" HeaderText="Bank Name">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BranchName" HeaderText="Branch Name">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "20%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id = "trFeeRefund1" runat = "server">
                <th colspan = "4" align = "left">Refund Details</th>
            </tr>
            <tr id = "trFeeRefund2" runat = "server">
                <td colspan = "4">
                    <asp:GridView ID="gvFeeRefundList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth = "1px" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "8%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "15%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FeeAmount" HeaderText="Refund Amount (<span class='rupee'>Rs.</span>)" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "10%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDNumber" HeaderText="DD/Cheque Number">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "11%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDDate" HeaderText="Payment Date">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "11%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BankName" HeaderText="Bank Name">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BranchName" HeaderText="Branch Name">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "20%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id = "trReasonForCancellation" runat = "server" visible = "false">
                <td colspan = "4"><b>Reason of Cancellation : </b><asp:Label id="lblComments" runat="server"></asp:Label></td>
            </tr>
            <tr> 
                <td colspan = "4">
                    <center><b><font size = "2">Declaration by the College / Institute</font></b></center>
                    <br />
                    <p align = "justify">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        We herewith declare that, we are cancelling the confirmed admission of this Candidate for the acedamic year <%= AdmissionYear %> based on the written consent of the Candidate. All the submitted original documents  are returned to the Candidate. The fees paid by the Candidate is refunded after deductting the cancellation charges mentioned above. The candidate cancelled admission as per rule no. 16 of information brochure.
                    </p>
                </td>
            </tr>
            <tr>
                <td colspan = "2">
                    Printed By : <asp:Label id="lblPrintedBy" runat="server" Font-Bold="True"></asp:Label>
                   <%-- <br /><br />
                    Cancelled By : <asp:Label id="lblCancelledBy" runat="server" Font-Bold="True"></asp:Label>
                    <br /><br />
                    Cancelled On : <asp:Label id="lblCancelledOn" runat="server" Font-Bold="True"></asp:Label>--%>
                </td>
                <td  valign="bottom" align="center" colspan = "2">Seal & Signature of the Issuing Institute Officer</td>
            </tr>
            <tr> 
                <td colspan = "4">
                    <center><b><font size = "2">Undertaking & Acknowledgement By Candidate</font></b></center>
                    <br />
                    <p align = "justify">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        I hereby undertake that my admission for the acedamic year <%= AdmissionYear %> is cancelled based on my written consent. I am aware that once my admission from this institute is cancelled, my claim on the allotted seat for this college stand null and void. 
                        <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        I hereby acknowledge that all the original documents and the fees after deducting cancellation charges are returned to me by the college.
                    </p>
                </td>
            </tr>
            <tr>
                <td valign = "bottom" colspan = "2">
                    Place :&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;Date :
                    <br /><br />
                    Printed On : <asp:Label id="lblPrintedOn" runat="server" Font-Bold = "true"></asp:Label>
                   <%-- <br /><br />
                    Cancellation Requested On : <asp:Label id="lblCancellationRequestedOn" runat="server" Font-Bold = "true"></asp:Label>--%>
                </td>
                <td align = "center" valign = "bottom" colspan = "2">
                    <br /><br /> 
                    Signature of Candidate
                    <br/>
                    (<asp:Label id="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
		    <tr>
		        <td align="center" width="100%">
		             <input id="btnPrint2" type="button" value="Print Admission Cancellation Letter" class="InputButton" onclick="javascript:OpenPopUpWindow()" />
			    </td>
		    </tr>
	    </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
