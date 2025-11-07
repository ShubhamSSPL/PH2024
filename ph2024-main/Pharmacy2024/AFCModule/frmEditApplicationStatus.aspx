<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditApplicationStatus.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEditApplicationStatus" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function checkStatus(sender, args) {
            if (document.getElementById("ctl00_rightContainer_ContentTable1_rbnBlock").checked || document.getElementById("ctl00_rightContainer_ContentTable1_rbnUnBlock").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Edit Application Status">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upApplicationStatus">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 40%" align="right">Select Application</td>
                        <td style="width: 60%">
                            <asp:DropDownList ID="ddlApplication" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlApplication_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvApplication" runat="server" ControlToValidate="ddlApplication" Display="None" ErrorMessage="Please Select Application." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Select Status</td>
                        <td>
                            <asp:RadioButton ID="rbnBlock" runat="server" GroupName="Status" Text="&nbsp;&nbsp;Block" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnUnBlock" runat="server" GroupName="Status" Text="&nbsp;&nbsp;Un-Block" />
                            <asp:CustomValidator ID="cvStatus" runat="server" ClientValidationFunction="checkStatus" Display="None" ErrorMessage="Please Select Status."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <br />
                            <asp:Button ID="btnSave" runat="server" Text="Save Application Status" CssClass="InputButton" OnClick="btnSave_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
