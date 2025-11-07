<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditCategoryDetails.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmEditCategoryDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible = "false">
        <table class="AppFormTable">
            <tr>
                <td style="width:50%" align="right">Application ID</td>
                <td style="width:50%"><asp:Label ID="lblApplicationID" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate's Name</td>
                <td><asp:Label ID="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Category Details">
        <asp:UpdateProgress runat="server" id="PageUpdateProgress">
            <ProgressTemplate>
                <img src ="../Images/BigProgress.gif" alt = "" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upHomeDistrict">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td style = "width:50%;" align = "right">Select Category</td>
                        <td style = "width:50%;">
                            <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                            <font color = "red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCategory" runat="server" ControlToValidate="ddlCategory" Display="None" ErrorMessage="Please Select Category." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>