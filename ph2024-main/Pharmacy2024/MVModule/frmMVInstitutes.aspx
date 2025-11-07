<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmMVInstitutes.aspx.cs" Inherits="Pharmacy2024.MVModule.frmMVInstitutes" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
     <p align = "justify"><b>Note:</b></p>
                    <ol class="list-text">
                        <li><p align = "justify"> Rows Maked in Grey Color are institute where Candidate's list is not yet confirmed by institute.</p></li>
                        
                    </ol> 
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="List Of Institutes" Width = "100%" ScrollBars = "auto">
        <center><asp:Label ID="lblInstituteName" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:GridView ID="gvReport" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid"
            AllowSorting="True" OnRowDataBound="gvReport_RowDataBound" OnSorting="gvReport_Sorting" DataKeyNames="InstituteCode">
            <Columns>
                <%--<asp:BoundField DataField="num_row" HeaderText="Sr. No." SortExpression="num_row">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>--%>
              <asp:BoundField DataField="InstituteCode" HeaderText="Institute <br/>  Code" HtmlEncode="false" SortExpression="InstituteCode">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" SortExpression="InstituteName" >
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false"  />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false"  />
                </asp:BoundField>
                 <asp:BoundField DataField="TotatIntake" HeaderText="Totat <br/> Intake" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 
                 <asp:BoundField DataField="TotalAdmitted" HeaderText="Total <br/> Admitted" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 
                 <asp:BoundField DataField="Recomended" HeaderText="Total <br/> Recommended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="NotRecomended" HeaderText="Total <br/> Not <br/> Recommended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>                  
                <asp:TemplateField HeaderText = "Confirmed By Institute" SortExpression="IsVerifiedByInstitute">
                    <ItemTemplate>                    
                        <asp:Label ID="lblInstStatus" runat="server" Text='<%#Bind("IsVerifiedByInstitute") %>' Visible = "true" />                
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "Verified By SO" SortExpression="IsVerifiedSO">
                    <ItemTemplate>                    
                        <asp:Label ID="lblInstStatusSO" runat="server" Text='<%#Bind("IsVerifiedSO") %>' Visible = "true" />                
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "Verified By RO" SortExpression="IsVerifiedByRO">
                    <ItemTemplate>                    
                        <asp:Label ID="lblInstStatusRO" runat="server" Text='<%#Bind("IsVerifiedByRO") %>' Visible = "true" />                
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "Verified By DTE" SortExpression="IsVerifiedByDTE">
                    <ItemTemplate>                    
                        <asp:Label ID="lblInstStatusDTE" runat="server" Text='<%#Bind("IsVerifiedByDTE") %>' Visible = "true" />                
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>

