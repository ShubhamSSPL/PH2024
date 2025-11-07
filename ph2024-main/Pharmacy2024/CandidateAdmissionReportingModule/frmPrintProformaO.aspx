<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrintProformaO.aspx.cs" Inherits="Pharmacy2024.CandidateAdmissionReportingModule.frmPrintProformaO" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <cc1:ShowMessage id="shInfo" runat="server"></cc1:ShowMessage>
        <table class="AppFormTable">
            <tr>
                <td align="center"><font size="4"><b>Application Form for Cancellation of Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></b></font></td>
            </tr>
            <tr>
                <td align="center">
                    <font size="2">Application ID : </font>
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" colspan="4" align="left">Personal Details</th>
            </tr>
            <tr>
                <td align="right">Candidate Name</td>
                <td colspan="3">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Gender</td>
                <td style="width: 25%">
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 25%" align="right">Date Of Birth</td>
                <td style="width: 25%">
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="left">Admission Details</th>
            </tr>
            <tr>
                <td align="right">Institute Name</td>
                <td colspan="3">
                    <asp:Label ID="lblInstituteName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Name</td>
                <td colspan="3">
                    <asp:Label ID="lblCourseName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Seat Type</td>
                <td>
                    <asp:Label ID="lblSeatType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Preference No.</td>
                <td>
                    <asp:Label ID="lblPreferenceNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Date of Admission</td>
                <td>
                    <asp:Label ID="lblAdmissionDate" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Admitted Through</td>
                <td>
                    <asp:Label ID="lblAdmittedThrough" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trFee1" runat="server">
                <th colspan="4" align="left">Fee Details</th>
            </tr>
            <tr id="trFee2" runat="server">
                <td colspan="4">
                    <asp:GridView ID="gvFeeList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="15%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FeeAmount" HeaderText="Fee Amount">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDNumber" HeaderText="DD/Cheque Number">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="11%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DDDate" HeaderText="Payment Date">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="11%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BankName" HeaderText="Bank Name">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BranchName" HeaderText="Branch Name">
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <p align="justify">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            I request you to kindly return my original documents and refund the fees paid as per the rules.
                    </p>
                </td>
            </tr>
            <tr>
                <td valign="bottom" colspan="2">Place :&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;Date :
                        <br />
                    <br />
                    Online Cancelled On :
                    <asp:Label ID="lblOnlineCancelledOn" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    Printed On :
                    <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="center" valign="bottom" colspan="2">
                    <br />
                    <br />
                    Signature of Candidate
                        <br />
                    (<asp:Label ID="lblDeclarationName" runat="server" Font-Bold="True"></asp:Label>)
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <center><b><font size="2">For Office Use Only</font></b></center>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
