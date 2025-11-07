<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="ARANoofInstFeePaidList.aspx.cs" Inherits="Pharmacy2024.MVModule.ARANoofInstFeePaidList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <cc1:ContentBox ID="cbListOfInst" runat="server" HeaderText="List Of Institutes Fee Paid" Width = "100%" ScrollBars = "auto">
        <center><asp:Label ID="lblInstituteName" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:GridView ID="gvReport" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" 
            CellPadding="5" CssClass = "DataGrid" OnRowDataBound="gvReport_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText = "Sr. No." ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

               <%-- <asp:HyperLinkField DataTextField = "InstituteCode" DataNavigateUrlFields="InstituteCode" DataNavigateUrlFormatString = "frmAllotedCCLDTE.aspx?InstituteCode={0}" HeaderText = "No Of Institutes">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField> --%>
                 <asp:BoundField DataField="InstituteCode" HeaderText="Institute <br/>  Code" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false"  />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false"  />
                </asp:BoundField> 
                
                 <asp:BoundField DataField="FeesPaidAmt" HeaderText="Total Fees <br/> Paid" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>                                                         
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
