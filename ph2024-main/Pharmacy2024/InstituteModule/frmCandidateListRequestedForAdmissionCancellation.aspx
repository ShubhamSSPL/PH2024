<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCandidateListRequestedForAdmissionCancellation.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmCandidateListRequestedForAdmissionCancellation" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "List of Candidates Applied for Cancellation of Admission but Admission Not Cancelled" Width = "100%" Height = "400px" ScrollBars = "Auto">
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" OnSelectedIndexChanging="gvReport_SelectedIndexChanging">
            <Columns> 
                <asp:CommandField ShowSelectButton="True" HeaderText = "Cancel Admission" SelectText="Cancel Admission">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:CommandField> 
                <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "MobileNo" HeaderText = "Mobile No">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>--%>
                <asp:BoundField DataField = "InstituteCode" HeaderText = "Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteName" HeaderText = "Institute Name">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CourseName" HeaderText = "Course Name">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "ChoiceCodeDisplay" HeaderText = "Choice Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "RequestedDateTime" HeaderText = "Requested Date Time">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPersonalID" runat="server" Text='<%# Eval("PersonalID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblChoiceCode" runat="server" Text='<%# Eval("ChoiceCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblCAPRound" runat="server" Text='<%# Eval("CAPRound") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblInstituteCode" runat="server" Text='<%# Eval("InstituteCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
</asp:Content>