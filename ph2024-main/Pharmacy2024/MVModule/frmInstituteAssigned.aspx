<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmInstituteAssigned.aspx.cs" Inherits="Pharmacy2024.MVModule.frmInstituteAssigned" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
     <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="List Of Institutes Assigned to SO for Merit List Verification" Width = "100%" ScrollBars = "auto">
        <center><asp:Label ID="lblInstituteName" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:GridView ID="gvReport" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid"
            AllowSorting="True" OnRowDataBound="gvReport_RowDataBound" OnSorting="gvReport_Sorting" DataKeyNames="InstituteCode">
            <Columns>
                <%--<asp:BoundField DataField="num_row" HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>--%>
              <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code" SortExpression="InstituteCode">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" SortExpression="InstituteName">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="NoOfAdmmited" HeaderText="No of <br/> Admitted <br/> Candidates" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="NoOfRecommend" HeaderText="No of <br/> Recommended <br/> Candidates" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="NoOfNotRecommend" HeaderText="No of <br/> Not Recommended <br/> Candidates" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="AssignedToSO" HeaderText="Assigned To SO" SortExpression="AssignedToSO">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 
                 <%--<asp:BoundField DataField="IsVerifiedBySO" HeaderText="Verified By SO" SortExpression="IsVerifiedBySO">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>--%>
                <asp:TemplateField HeaderText = "Confirmed By SO" SortExpression="IsVerifiedBySO">
                <ItemTemplate>                    
                <asp:Label ID="lblInstStatus" runat="server" Text='<%#Bind("IsVerifiedBySO") %>' Visible = "true" />                
            </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
