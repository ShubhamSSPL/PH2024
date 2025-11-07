<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmGetInstituteProfile.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmGetInstituteProfile" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script type="text/javascript" language="javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Get Institute Profile">
        <asp:UpdateProgress runat="server" id="PageUpdateProgress">
            <ProgressTemplate>
                <img src ="../Images/BigProgress.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upResetPassword">
            <ContentTemplate>
                <table  class="AppFormTable">
                    <tr>
                        <td style = "width:20%" align="right">Select Institute</td>
                        <td style = "width:80%">
                            <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged" Width = "95%"></asp:DropDownList>
                            <font color = "red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvInstitute" runat="server" ControlToValidate="ddlInstitute" Display="None" ErrorMessage="Please Select Institute." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                <table id = "tblInstituteProfile" runat = "server" class="AppFormTable" visible = "false">
                    <tr>
                        <th style = "border-top-width:0px" colspan = "4" align = "left">Institute Details</th>
                    </tr>
                    <tr>
                        <td align="right">Institute Name</td>
                        <td colspan = "3"><asp:Label ID="lblInstituteName" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Institute Address</td>
                         <td colspan="3"><asp:Label ID="lblInstituteAddress" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 25%;" align="right">Institute Phone No.</td>
                        <td style="width: 25%;"><asp:Label ID="lblInstitutePhoneNo" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td style="width: 25%;" align="right">Institute Fax No.</td>
                        <td style="width: 25%;"><asp:Label ID="lblInstituteFaxNo" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <th colspan = "4" align = "left">Co-Ordinator Details</th>
                    </tr>
                    <tr>
                        <td align="right">Name</td>
                        <td><asp:Label ID="lblCoordinatorName" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Designation</td>
                        <td><asp:Label ID="lblCoordinatorDesignation" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Mobile No. 1</td>
                        <td><asp:Label ID="lblCoordinatorMobileNo" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Mobile No. 2</td>
                        <td><asp:Label ID="lblCoordinatorAltMobileNo" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">E-mail ID</td>
                        <td><asp:Label ID="lblCoordinatorEmailID" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Phone No.</td>
                        <td><asp:Label ID="lblCoordinatorPhoneNo" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>

