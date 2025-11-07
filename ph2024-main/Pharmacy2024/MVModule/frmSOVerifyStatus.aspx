<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmSOVerifyStatus.aspx.cs" Inherits="Pharmacy2024.MVModule.frmSOVerifyStatus" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="SO wise Merit List Verification Status" Width = "100%" ScrollBars = "auto">
        <center><asp:Label ID="lblInstituteName" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:GridView ID="gvReport" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>               
                <asp:BoundField DataField="InstituteCode" HeaderText="Institute <br/> Code" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>                
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TotatIntake" HeaderText="Total <br/> Intake" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalAdmitted" HeaderText="Total <br/> Admitted" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalAdmCanceled" HeaderText="Total <br/> Cancelled" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="Recomended" HeaderText="Recommended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="NotRecomended" HeaderText="Not <br/> Recommended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="IsVerified" HeaderText="Is <br /> Verified" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 
                <asp:BoundField DataField="VerifiedBySO" HeaderText="Verified<br />By SO" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>                            
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
