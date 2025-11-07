<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmResetPassword.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmResetPassword" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script type="text/javascript" language="javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Reset Password">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <p align="justify"><font color="red"><b>The Password must be as per the following Password policy :</b></font></p>
                        <br />
                        <ul class="list-text">
                            <li>
                                <p align="justify"><font color="red">Password must be 8 to 13 character long.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one Upper case alphabet.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one Lower case alphabet.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one numeric value.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">Password must have at least one special characters eg.!@#$%^&*-</font></p>
                            </li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
        <br />
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
                                <asp:ListItem Value="23">SC Officer</asp:ListItem>
                                <asp:ListItem Value="24">Sub-SC Officer</asp:ListItem>
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
                    <tr>
                        <td align="right">Login ID</td>
                        <td>
                            <asp:Label ID="lblLoginID" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">New Password</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="13" ToolTip="Please Enter New Password. Password must be 8 to 13 character long. Password must have at least one Upper case alphabet. Password must have at least one Lower case alphabet. Password must have at least one numeric value. Password must have at least one special characters eg.!@#$%^&*-."></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter New Password." Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Password must be 8 to 13 character long. Password must have at least one Upper case alphabet. Password must have at least one Lower case alphabet. Password must have at least one numeric value. Password must have at least one special characters eg.!@#$%^&*-." ValidationExpression="^.*(?=^.{8,13}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Confirm New Password</td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" MaxLength="13" ToolTip="Please Enter Confirm New Password."></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please Enter Confirm New Password." Display="None"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" ErrorMessage="Password and Confirm New Password should be Same." Display="None"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="InputButton" OnClick="btnResetPassword_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
