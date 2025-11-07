<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmControlProjectConfiguration.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmControlProjectConfiguration" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <img src="../Images/BigProgress.gif" alt="" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upProjectConfiguration">
        <ContentTemplate>
            <cc1:ContentBox ID="cbProjectConfigurationDetails" runat="server" HeaderText="Control Project Configuration">
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 40%;" align="right">Key Details</td>
                        <td style="width: 60%;">
                            <asp:Label ID="lblAppKeyDetails" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr id="trTextBox" runat="server">
                        <td align="right">Key Value</td>
                        <td>
                            <asp:TextBox ID="txtAppValue" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font> (MM/DD/YYYY)
                            <asp:RequiredFieldValidator ID="rfvAppValue" runat="server" ErrorMessage="Please Enter Key Value." ControlToValidate="txtAppValue" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trDropDownList" runat="server">
                        <td align="right">Key Value</td>
                        <td>
                            <asp:DropDownList ID="ddlAppValue" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvAppValue" runat="server" ErrorMessage="Please Select Key Value." ControlToValidate="ddlAppValue" Display="None" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="InputButton" OnClick="btnUpdate_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" BackColor="#F6223F" OnClick="btnCancel_Click" ValidationGroup="Cancel" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnAppKey" runat="server" />
                <asp:HiddenField ID="hdnControlRequired" runat="server" />
            </cc1:ContentBox>
            <cc1:ContentBox ID="cbProjectConfigurationList" runat="server" HeaderText="Project Configuration List">
                <asp:GridView ID="gvProjectConfigurationList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" CssClass="DataGrid" OnSelectedIndexChanging="gvProjectConfigurationList_SelectedIndexChanging">
                    <columns>                        
                        <asp:BoundField HeaderText="Sr. No." HtmlEncode="false">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AppKeyDetails" HeaderText="Key Details">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="50%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AppValue" HeaderText="Key Value">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="30%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" HeaderText="Edit" SelectText="Edit">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            <ControlStyle ForeColor="Blue" />
                        </asp:CommandField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblAppKey" runat="server" Text='<%# Eval("AppKey") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </columns>
                </asp:GridView>
                <br />
            </cc1:ContentBox>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
