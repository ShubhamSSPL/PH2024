<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="FCApplicationFormVerificationDashboard.aspx.cs" Inherits="Pharmacy2024.E_FCModule.FCApplicationFormVerificationDashboard" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/CandidateBasicInfo.ascx" TagName="BInfo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
      <script lang="javascript" type = "text/javascript">
        window.history.forward(1);
      </script>

    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Candidate Details">
        <uc1:BInfo ID="CandidateBasicInformation" runat="server" />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Steps of Verification">
        <center><asp:Label ID="lblFCName" Font-Bold="true" ForeColor="red" runat="server" Font-Size = "small" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:GridView ID="gvApplicationFormLinksStatus" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid table-responsive"
            OnRowCommand="gvApplicationFormLinksStatus_RowCommand" OnRowDataBound="gvApplicationFormLinksStatus_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Step ID">
                    <ItemTemplate>
                        Step <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:TemplateField>
                <asp:BoundField DataField="LinkDescription" HeaderText="Step Details">
                    <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="55%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                 <asp:BoundField DataField="VerificationStatus" HeaderText="Verification Status">
                    <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="55%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:ButtonField HeaderText="Verify" ButtonType="Button" CommandName="Verify" Text="Verify Step" ControlStyle-CssClass="InputButton">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle Font-Bold="True" />
                </asp:ButtonField>
                 <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblApplicationFormStepID" runat="server" Text='<%# Eval("ApplicationFormStepID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPersonalID" runat="server" Text='<%# Eval("PersonalID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--    <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Button ID="btnFormStatus" runat="server" Text='<%# Eval("LinkStatus") %>' PostBackUrl='<%# Eval("LinkUrl") %>' CssClass="InputButton" BackColor='<%# System.Drawing.Color.FromName(Eval("LinkBackColor").ToString()) %>' Enabled='<%# Convert.ToBoolean(Eval("LinkEnabled")) %>'></asp:Button>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>

     <table id="tblDuplicateMobile" runat="server" class="AppFormTable" visible="false">
            <tr  >
                <td align="center"><asp:button id="btnSubmit" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Submit Discrepancy for Duplicate Mobile No" Height="40px" Font-Size="Medium" Font-Bold="true" OnClick="btnSubmit_Click"></asp:button></td>
            </tr>
    </table>
      <table id="tblDuplicateCETApplicationFormNo" runat="server" class="AppFormTable" visible="false">
            <tr  >
                <td align="center"><asp:button id="btnMarkDuplicateCETApplicationNo" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Submit Discrepancy for Duplicate CET Application Number" Height="40px" Font-Size="Medium" Font-Bold="true" OnClick="btnMarkDuplicateCETApplicationNo_Click"></asp:button></td>
            </tr>
    </table>
    <table id="tblDuplicateNEETRollNo" runat="server" class="AppFormTable" visible="false">
            <tr  >
                <td align="center"><asp:button id="btnMarkDuplicateNEETRollNo" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Submit Discrepancy for Duplicate NEET Roll No" Height="40px" Font-Size="Medium" Font-Bold="true" OnClick="btnMarkDuplicateNEETRollNo_Click"></asp:button></td>
            </tr>
    </table>
    <table id="tblDuplicateHSCSeatNo" runat="server" class="AppFormTable" visible="false">
            <tr  >
                <td align="center"><asp:button id="btnHSCSeatNoSubmit" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Submit Discrepancy for Duplicate HSC Seate No" Height="40px" Font-Size="Medium" Font-Bold="true" OnClick="btnHSCSeatNoSubmit_Click"></asp:button></td>
            </tr>
    </table>
</asp:Content>

