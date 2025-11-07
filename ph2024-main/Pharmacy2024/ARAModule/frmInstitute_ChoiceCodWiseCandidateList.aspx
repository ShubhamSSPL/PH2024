<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmInstitute_ChoiceCodWiseCandidateList.aspx.cs" Inherits="Pharmacy2024.ARAModule.frmInstitute_ChoiceCodWiseCandidateList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Candidate List For Application Form Verification">
        <center><asp:Label ID="lblFCName" Font-Bold="true" ForeColor="red" runat="server" Font-Size = "small" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid table-responsive" OnRowCommand="gvReport_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                </asp:TemplateField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID">
                    <ItemStyle HorizontalAlign="center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="30%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "Gender" HeaderText = "Gender No" visible="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "AdmissionDoneOn" HeaderText = "Admission Done On">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "FinalCandidatureType" HeaderText = "Candidature Type">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <%-- <asp:ButtonField HeaderText="Verify Application Form" ButtonType="Button" CommandName="Verify" Text="Verify Form" ControlStyle-CssClass="InputButton">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle Font-Bold="True" />
                </asp:ButtonField>--%>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPersonalID" runat="server" Text='<%# Eval("PersonalID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblInstituteStatus" runat="server" Text='<%# Eval("InstituteStatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Verify" >
                  <ItemTemplate>
                   <asp:Button ID="btnVerify" runat="server" Text="Verify Form" Visible='<%# ((Eval("InstituteStatus").ToString() == "A") && (Eval("RoStatus").ToString() == "I" ||Eval("RoStatus").ToString() == "A")) ? false : true %>' CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" CommandName="Verify"/>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" Width="6%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Verify" >
                  <ItemTemplate>
                   <asp:Button ID="btnRoVerify" runat="server" Text="Verify Form" Visible='<%# Eval("RoStatus").ToString() == "A" || Eval("RoStatus").ToString() == "R" ? false : true %>' CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" CommandName="Verify"/>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" Width="6%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Verify" >
                  <ItemTemplate>
                   <asp:Button ID="btnAraVerify" runat="server" Text="Verify Form" Visible='<%# Eval("AraStatus").ToString() == "A" || Eval("AraStatus").ToString() == "R" ? false : true %>' CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" CommandName="Verify"/>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" Width="6%" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>

</asp:Content>
