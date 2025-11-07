<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmGetARCProfile.aspx.cs" Inherits="Pharmacy2024.ARCModule.frmGetARCProfile" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script type="text/javascript" language="javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Get Profile">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upResetPassword">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 25%" align="right">Select User Type</td>
                        <td style="width: 75%">
                            <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="33">ARC Officer</asp:ListItem>
                                <asp:ListItem Value="34">Sub-ARC Officer</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvUserType" runat="server" ControlToValidate="ddlUserType" Display="None" ErrorMessage="Please Select User Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Select User</td>
                        <td>
                            <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvUser" runat="server" ControlToValidate="ddlUser" Display="None" ErrorMessage="Please Select User." Operator="NotEqual" ValueToCompare="-- Select --"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                <table id="tblARCProfile" runat="server" class="AppFormTable" visible="false">
                    <tr>
                        <th style="border-top-width: 0px" colspan="4" align="left">ARC Details</th>
                    </tr>
                    <tr>
                        <td align="right">ARC Name</td>
                        <td colspan="3">
                            <asp:Label ID="lblARCName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">ARC Address</td>
                        <td colspan="3">
                            <asp:Label ID="lblARCAddress" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 25%;" align="right">ARC Phone No.</td>
                        <td style="width: 25%;">
                            <asp:Label ID="lblARCPhoneNo" runat="server"></asp:Label></td>
                        <td style="width: 25%;" align="right">ARC Fax No.</td>
                        <td style="width: 25%;">
                            <asp:Label ID="lblARCFaxNo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">Co-Ordinator Details</th>
                    </tr>
                    <tr>
                        <td align="right">Name</td>
                        <td>
                            <asp:Label ID="lblCoordinatorName" runat="server"></asp:Label></td>
                        <td align="right">Designation</td>
                        <td>
                            <asp:Label ID="lblCoordinatorDesignation" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Mobile No. 1</td>
                        <td>
                            <asp:Label ID="lblCoordinatorMobileNo" runat="server"></asp:Label></td>
                        <td align="right">Mobile No. 2</td>
                        <td>
                            <asp:Label ID="lblCoordinatorAltMobileNo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">E-mail ID</td>
                        <td>
                            <asp:Label ID="lblCoordinatorEmailID" runat="server"></asp:Label></td>
                        <td align="right">Phone No.</td>
                        <td>
                            <asp:Label ID="lblCoordinatorPhoneNo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <th colspan="4" align="left">Security Question Details</th>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">Security Question</td>
                        <td colspan="2">
                            <asp:Label ID="lblSecurityQuestion" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">Security Answer</td>
                        <td colspan="2">
                            <asp:Label ID="lblSecurityAnswer" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
