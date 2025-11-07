<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmSOList.aspx.cs" Inherits="Pharmacy2024.MVModule.frmSOList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Scrutiny Officer Wise Statistics of Merit List Approval" Width = "100%" ScrollBars = "auto">
        <%--<center><asp:Label ID="lblInstituteName" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>--%>
        <br />
        <asp:GridView ID="gvReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid" 
            AllowSorting="True" OnSorting="gvReport_Sorting">
            <Columns>
                <asp:BoundField DataField="num_row" HeaderText="Sr. No." SortExpression="num_row">
                    <ItemStyle HorizontalAlign="Center"  Width="10%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:HyperLinkField DataTextField = "SOName" DataNavigateUrlFields="SOID" DataNavigateUrlFormatString = "frmSOVerifyStatus.aspx?SOID={0}" HeaderText = "Name Of SO" SortExpression="SOName">
                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField> 
                <asp:BoundField DataField="Designation" HeaderText="Designation">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false"  BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="SOMobile" HeaderText="Mobile No.">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="NoOfinstAssigned" HeaderText="No Of <br/> Institutes <br/> Assigned" HtmlEncode="false" SortExpression="NoOfinstAssigned">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="CandidatesRecommended" HeaderText="No of <br/> Candidates <br/> Recommended" HtmlEncode="false" SortExpression="CandidatesRecommended">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="CandidatesNotRecommended" HeaderText="No of <br/> Candidates <br/> Not Recommended" HtmlEncode="false" SortExpression="CandidatesNotRecommended">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="CandidatesPending" HeaderText="No of <br/> Candidates <br/> Pending" HtmlEncode="false" SortExpression="CandidatesPending">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="NoOfCandidates" HeaderText="No of <br/> Candidates <br/> Assigned" HtmlEncode="false" SortExpression="NoOfCandidates">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <%--<asp:BoundField DataField="PerPending" HeaderText="% Pending" HtmlEncode="false" SortExpression="PerPending">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>--%>
                <asp:TemplateField HeaderText = "% Pending">
                <ItemTemplate>                    
                <asp:Label ID="lblPending" runat="server" Text="" Visible = "true" />                
            </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </cc1:ContentBox> 
</asp:Content>
