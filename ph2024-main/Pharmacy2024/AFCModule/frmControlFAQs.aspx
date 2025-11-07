<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmControlFAQs.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmControlFAQs" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
        <ProgressTemplate>
            <img src="../Images/BigProgress.gif" alt="" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upFAq">
        <ContentTemplate>
            <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Control FAQs">
                <table class="AppFormTable">
                    <tr>
                        <td align="right">Question</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtQuestion" runat="server" MaxLength="500" Width="95%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" ControlToValidate="txtQuestion" Display="None" ErrorMessage="Please Enter Question."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Answer</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtAnswer" runat="server" MaxLength="1000" Width="95%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ControlToValidate="txtAnswer" Display="None" ErrorMessage="Please Enter Answer."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%;" align="right">FAQ Type</td>
                        <td style="width: 25%;">
                            <asp:DropDownList ID="ddlFAQType" runat="server" Width="89%">
                                <asp:ListItem Value="0">-- Select FAQ Type --</asp:ListItem>
                                <asp:ListItem Value="Policy">Policy</asp:ListItem>
                                <asp:ListItem Value="Technical">Technical</asp:ListItem>
                                <asp:ListItem Value="Maharashtra, Minority and All India Candidates - CAP Option Form / Reporting">Maharashtra, Minority and All India Candidates - CAP Option Form / Reporting</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvFAQType" runat="server" ControlToValidate="ddlFAQType" ErrorMessage="Please Select FAQ Type." Operator="NotEqual" ValueToCompare="0" Display="none"></asp:CompareValidator>
                        </td>
                        <td style="width: 25%;" align="right">Seq No</td>
                        <td style="width: 25%;">
                            <asp:DropDownList ID="ddlSeqNo" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvSeqNo" runat="server" ControlToValidate="ddlSeqNo" ErrorMessage="Please Select Seq No." Operator="NotEqual" ValueToCompare="0" Display="none"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="InputButton" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="InputButton" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" BackColor="#F6223F" OnClick="btnCancel_Click" ValidationGroup="Cancel" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="Cancel" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnFAQID" runat="server" />
            </cc1:ContentBox>
            <br />
            <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="FAQ List">
                <asp:GridView ID="gvFAQList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" CssClass="DataGrid" OnRowDeleting="gvFAQList_RowDeleting" OnSelectedIndexChanging="gvFAQList_SelectedIndexChanging">
                    <columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblFAQID" runat="server" Text='<%# Eval("FAQID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Sr. No." HtmlEncode="false">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "5%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Question" HeaderText="Question" HtmlEncode="false">
                            <ItemStyle HorizontalAlign="Left" CssClass="Item" Width = "35%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Answer" HeaderText="Answer" HtmlEncode="false">
                            <ItemStyle HorizontalAlign="Left" CssClass="Item" Width = "40%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FAQType" HeaderText="FAQ Type" HtmlEncode="false">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "5%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SeqNo" HeaderText="Seq No" HtmlEncode="false">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "5%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" HeaderText = "Edit" SelectText="Edit">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "5%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            <ControlStyle ForeColor="Blue" />
                        </asp:CommandField>
                         <asp:CommandField ShowDeleteButton="True"  HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" CssClass="Item" Width = "5%" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            <ControlStyle ForeColor="Blue" />
                        </asp:CommandField>
                    </columns>
                </asp:GridView>
            </cc1:ContentBox>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
