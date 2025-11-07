<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditCandidatureTypeDetailsNew.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEditCandidatureTypeDetailsNew" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
     <style>
        @media screen and (max-width:425px){
            .AppFormTable .col-sm-6{
                padding:5px;
            }
            .p1{
                text-align:left;
            }
            .p2{
                text-align:right;
            }
        }
    </style>
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%" align="right">Application ID</td>
                <td style="width: 50%">
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate's Full Name</td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Candidature Type Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upHomeUniversity">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <th colspan="2" align="left">Candidature Type Details</th>
                    </tr>
                    <tr>
                        <td style="width: 50%;" align="right">Candidature Type</td>
                        <td style="width: 50%;">
                            <asp:DropDownList ID="ddlCandidatureType" runat="server" AutoPostBack="true" onmouseover="ddrivetip('Please Select Candidature Type.')" onmouseout="hideddrivetip()" OnSelectedIndexChanged="ddlCandidatureType_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCandidatureType" runat="server" ControlToValidate="ddlCandidatureType" Display="None" ErrorMessage="Please Select Candidature Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                 <table class="AppFormTable" id="tblCheckFCRDetails" runat="server" style="display: block" visible="false">
                    <tr id="trCheckFCRDetails" runat="server">
                        <td style="width: 50%" align="right">Enter Foreign Registration Application Number</td>
                        <td style="width: 50%">
                            <%--<asp:TextBox ID="txtFCRApplicationFormNo" MaxLength="11" runat="server" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color="red">*</font>
                    <asp:RequiredFieldValidator ID="rfvFCRApplicationFormNo" runat="server" Display="None" ControlToValidate="txtFCRApplicationFormNo" ErrorMessage="Please Enter YourEnter Foreign Registration Application Number."></asp:RequiredFieldValidator>--%>
                            <input type="text" id="txtFCRApplicationFormNo" maxlength="11" runat="server" required />
                        </td>
                    </tr>
                    <tr id="trCheckFCRDOB" runat="server">
                        <td align="right">Enter Date Of Birth</td>
                        <td>
                            <input type="text" id="txtDOB" maxlength="10" runat="server" required />
                            <%--<asp:TextBox ID="txtDOB" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                    <font color="red"><sup>*</sup></font> (DD/MM/YYYY)
                            <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB" Display="None" ErrorMessage="Please Enter Your Date of Birth."></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper Date of Birth."></asp:CustomValidator>--%>
                        </td>
                    </tr>
                    <tr id="trFCRGetData" runat="server">
                        <td colspan="2" align="center">
                            <asp:Button ID="btnFCRGetData" runat="server" Text="Check Foreign Registration Details" CssClass="InputButton" BackColor="Red" OnClick="btnCheckFCRGetData_Click" />

                            <br />
                            <asp:Label ID="lblNote" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table id="tblFRNoDetails" runat="server" class="AppFormTable" visible="false">
                    <tr id="trFCRApplicationNo" runat="server" visible="false">
                        <td colspan="4" style="width: 50%" align="right">FCR Candidate Application No </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRApplicationNo" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 50%" align="right">Candidate Name As Per FCR </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 50%" align="right">Candidature Type Name As Per FCR </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRCandidatureTypeName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 50%" align="right">Mother Name As Per FCR </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRMotherName" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 50%" align="right">Gender As Per FCR </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRGender" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 50%" align="right">DOB As Per FCR </td>
                        <td colspan="2" style="width: 50%">
                            <asp:Label ID="lblFCRDOB" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

        <table class="AppFormTableWithOutBorder">
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
