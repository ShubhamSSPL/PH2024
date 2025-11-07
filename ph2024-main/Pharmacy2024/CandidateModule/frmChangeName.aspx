<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmChangeName.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmChangeName" %>
 

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        function makeUpper() {
            document.getElementById("rightContainer_ContentTable2_txtCandidateName").value = document.getElementById("rightContainer_ContentTable2_txtCandidateName").value.toUpperCase();
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Change Candidate Name">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upAddress">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td colspan="2">
                            <ol class="list-text">
                                <b>Important Instructions for Correction in Name :</b>
                                <li>The candidate should carry the necessary original documents such as mentioned in
                                    the admit card to prove identity. </li>
                                <li>The candidate should get approved the request of change in name at Scrutiny
                                    Center, by providing the original documents. </li>
                                <li>After approval of the request of change in name by Scrutiny Center, the correct
                                    name will be reflected in the Application Form. </li>
                            </ol>
                        </td>
                    </tr>
                     <tr>  <td colspan="2">&nbsp;</td></tr>
                    <tr id="trOldCandidateName" runat="server">
                        <td style="width: 50%;" align="right">
                            Candidate Name(As Per CET)
                        </td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblOldCandidateName" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trDOB" runat="server">
                        <td style="width: 50%;" align="right">
                            Date of Birth
                        </td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trHSCName" runat="server">
                        <td style="width: 50%;" align="right">
                            Do you want to correct full name as per HSC
                        </td>
                        <td style="width: 50%;">
                            <asp:RadioButton ID="rbnNameOnHSCYes" runat="server" GroupName="NameOnHSC" Text="&nbsp;&nbsp;Yes"
                                AutoPostBack="true" OnCheckedChanged="NameOnHSC_CheckedChanged" onmouseover="ddrivetip('Please Select Name on HCS.')"
                                onmouseout="hideddrivetip()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnNameOnHSCNo" runat="server" GroupName="NameOnHSC" Text="&nbsp;&nbsp;No"
                                AutoPostBack="true" OnCheckedChanged="NameOnHSC_CheckedChanged" onmouseover="ddrivetip('Please Select Name on HCS.')"
                                onmouseout="hideddrivetip()" />
                            <asp:CustomValidator ID="cvNameOnHSC" runat="server" ClientValidationFunction="checkNameOnHSC"
                                Display="None" ErrorMessage="Please Select Appeared Status for <%= MHTCETName %>."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id="trNewCandidateName" runat="server">
                        <td style="width: 50%;" align="right">
                            New Candidate Name
                        </td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblNewCandidateName" runat="server" Font-Bold="true"></asp:Label>
                            <br /><font color = "red">(As appeared on HSC Marksheet)</font>
                        </td>
                    </tr>
                    <tr id="trCandidateName" runat="server" visible="false">
                        <td style="width: 50%;" align="right">
                            Enter New Candidate Name
                        </td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="txtCandidateName" style="width: 375px;" runat="server" MaxLength="100" onmouseover="ddrivetip('Please Enter New Candidate Name.')"
                                onmouseout="hideddrivetip()" onblur="makeUpper()"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvCandidateName" runat="server" ControlToValidate="txtCandidateName"
                                Display="None" ErrorMessage="Please Enter New Candidate Name."></asp:RequiredFieldValidator>
                                <br /><font color = "red">(As appeared on HSC Marksheet)</font>
                        </td>
                    </tr>
                </table>
                <br />
                <table class="AppFormTable">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSubmite" runat="server" Text="Submit" CssClass="InputButton" OnClick="btnSubmite_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                ShowMessageBox="True" />
                        </td>
                    </tr>
                </table>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>

