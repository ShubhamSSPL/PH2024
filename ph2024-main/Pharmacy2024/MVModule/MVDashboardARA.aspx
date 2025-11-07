<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="MVDashboardARA.aspx.cs" Inherits="Pharmacy2024.MVModule.MVDashboardARA" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
     <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Region wise Statistics for First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D " Width = "100%" ScrollBars = "auto">
        <%--<center><asp:Label ID="lblInstituteName" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>--%>
        
        <asp:GridView ID="gvDashboardPH" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid" OnRowDataBound="gvDashboardPH_RowDataBound">
            <Columns>  
                <asp:BoundField DataField="RegionName" HeaderText="Region" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>  
                
                <asp:HyperLinkField DataTextField = "NoofInstitutes" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "ARAInstList.aspx?RegionName={0}" HeaderText = "No Of Institutes">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>

                <%--<asp:BoundField DataField="NoofInstitutes" HeaderText="No Of <br/> Institutes" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>--%>

                <%--<asp:BoundField DataField="NoofInstFeePaid" HeaderText="No Of Institutes <br/> Fee Paid" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                   <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> --%>
                <asp:HyperLinkField DataTextField = "NoofInstFeePaid" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "ARANoofInstFeePaidList.aspx?RegionName={0}" HeaderText = "No Of Institutes <br/> Fee Paid">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>

                <asp:BoundField DataField="TotalAmt" HeaderText="Total Fee <br/> Collected" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> 

               <%-- <asp:BoundField DataField="VerifiedRO" HeaderText="No Of Institute  <br/> Confirmed by RO" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> --%>
                <asp:HyperLinkField DataTextField = "VerifiedRO" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "ARANoOfInstConfirmedByROList.aspx?RegionName={0}" HeaderText = "No Of Institute  <br/> Confirmed by RO">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>

               <%-- <asp:BoundField DataField="VerifiedDTE" HeaderText="No Of Institute  <br/> Confirmed by DTE" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>--%>
                 <asp:HyperLinkField DataTextField = "VerifiedDTE" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "ARANoOfInstConfirmedByDTEList.aspx?RegionName={0}" HeaderText = "No Of Institute  <br/> Confirmed by DTE">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>

                <%--<asp:BoundField DataField="Proposal" HeaderText="No Of Institute <br/> Submitted <br/> Physical <br/> Proposal" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>  --%>
                <asp:HyperLinkField DataTextField = "Proposal" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "ARANoOfInstPhysicalProposalList.aspx?RegionName={0}" HeaderText = "No Of Institute <br/> Submitted <br/> Physical <br/> Proposal">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox> 
    <br />
    <br />
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Region wise Statistics for First Year Degree in Engineering/Technology (B.E. / B.Tech)" Width = "100%" ScrollBars = "auto">
        <%--<center><asp:Label ID="lblInstituteName" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>--%>
        
        <asp:GridView ID="gvDashboardFE" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid" OnRowDataBound="gvDashboardFE_RowDataBound">
            <Columns>  
                <asp:BoundField DataField="RegionName" HeaderText="Region" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> 
                <%--<asp:BoundField DataField="RegionName" HeaderText="Region" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>--%>
                <%--<asp:HyperLinkField DataTextField = "NoOfInst" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "frmMVInstitutes.aspx?RegionName={0}" HeaderText = "No Of Institutes">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>--%>
                <asp:BoundField DataField="NoofInstitutes" HeaderText="No Of <br/> Institutes" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="NoofInstFeePaid" HeaderText="No Of Institutes <br/> Fee Paid" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> 
                <asp:BoundField DataField="TotalAmt" HeaderText="Total Fee <br/> Collected" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                   <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> 
                <asp:BoundField DataField="VerifiedRO" HeaderText="No Of Institute  <br/> Confirmed by RO" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> 
                <asp:BoundField DataField="VerifiedDTE" HeaderText="No Of Institute  <br/> Confirmed by DTE" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="Proposal" HeaderText="No Of Institute <br/> Submitted <br/> Physical <br/> Proposal" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>                
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
    <br />
    <br />
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Region wise Statistics for First Year Post Graduate Technical Courses in Engineering and Technology (M.E. / M.Tech.) " Width = "100%" ScrollBars = "auto">
        <%--<center><asp:Label ID="lblInstituteName" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>--%>
        
        <asp:GridView ID="gvDashboardME" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid" OnRowDataBound="gvDashboardME_RowDataBound">
            <Columns>  
                <asp:BoundField DataField="RegionName" HeaderText="Region" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> 
                <%--<asp:BoundField DataField="RegionName" HeaderText="Region" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>--%>
                <%--<asp:HyperLinkField DataTextField = "NoOfInst" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "frmMVInstitutes.aspx?RegionName={0}" HeaderText = "No Of Institutes">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>--%>
                <asp:BoundField DataField="NoofInstitutes" HeaderText="No Of <br/> Institutes" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="NoofInstFeePaid" HeaderText="No Of Institutes <br/> Fee Paid" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> 
                <asp:BoundField DataField="TotalAmt" HeaderText="Total Fee <br/> Collected" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> 
                <asp:BoundField DataField="VerifiedRO" HeaderText="No Of Institute  <br/> Confirmed by RO" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField> 
                <asp:BoundField DataField="VerifiedDTE" HeaderText="No Of Institute  <br/> Confirmed by DTE" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="Proposal" HeaderText="No Of Institute <br/> Submitted <br/> Physical <br/> Proposal" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>                
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>

