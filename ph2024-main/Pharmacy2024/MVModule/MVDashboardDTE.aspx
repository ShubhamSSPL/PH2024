<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="MVDashboardDTE.aspx.cs" Inherits="Pharmacy2024.MVModule.MVDashboardDTE" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
     <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Region wise Statistics of Merit List Approval at RO and DTE Level" Width = "100%" ScrollBars = "auto">
        <%--<center><asp:Label ID="lblInstituteName" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>--%>
        
        <asp:GridView ID="gvDashboard" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>  
                <asp:BoundField DataField="RegionName" HeaderText="Region" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>               
                <asp:HyperLinkField DataTextField = "NoOfInst" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "frmMVInstitutes.aspx?RegionName={0}" HeaderText = "No Of Institutes">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>
                <asp:BoundField DataField="ZeroAdmInstCount" HeaderText="No Of <br/> Institutes <br/>having zero <br/> Admissions" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateAdmitted" HeaderText="No Of <br/> Candidates <br/>Admitted" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="NoOfInstFrezed" HeaderText="No Of Institutes <br/> which have <br/> Confirmed" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 
                <asp:BoundField DataField="NoOfInstAssigned" HeaderText="No Of Institute <br/> Assigned to SO" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 
                <asp:BoundField DataField="NoOfChoiceCodeAssigned" HeaderText="No Of <br/> Choice Codes <br/> Assigned to SO" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 


                <%--<asp:BoundField DataField="NoOfInstNotAssigned" HeaderText="No Of Institute <br/>Confirmed but <br/> Not Assigned <br/> to SO" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>--%>
                
                <asp:BoundField DataField="CandidateRecommeded" HeaderText="No Of <br/> Candidates <br/> Recommended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateNotRecommeded" HeaderText="No Of <br/> Candidates <br/> Not <br/> Recommended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateAssigned" HeaderText="No Of <br/> Candidates <br/> Assigned <br/> To SO" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <%--<asp:HyperLinkField DataTextField = "NoOfInstAssigned" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "frmInstituteAssigned.aspx?RegionName={0}" HeaderText = "No Of Institute Assigned to SO">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>
                <asp:BoundField DataField="NoOfInstNotAssigned" HeaderText="No Of Institute <br/>Confirmed but  <br/> Not Assigned <br/> to SO" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>--%>                
                <asp:HyperLinkField DataTextField = "NoOfInstVerifiedRO" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "frmInstVerifiedRO.aspx?RegionName={0}" HeaderText = "No Of Institute Confirmed by RO">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "NoOfInstNotVerifiedRO" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "frmInstVerifyRO.aspx?RegionName={0}" HeaderText = "No Of Institute Not Confirmed by RO">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "NoOfInstVerifiedDTE" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "frmInstVerifiedDTE.aspx?RegionName={0}" HeaderText = "No Of Institute Confirmed by DTE">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField = "NoOfInstNotVerifiedDTE" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "frmInstVerifyDTE.aspx?RegionName={0}" HeaderText = "No Of Institute Not Confirmed by DTE">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox> 
    <br><br>
     <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Region Wise Scrutiny Officers and Statistics of Merit List Approval" Width = "100%" ScrollBars = "auto">       
        
        <asp:GridView ID="gvDashboardSO" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>     
                <asp:BoundField DataField="RegionName" HeaderText="Region">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>                
                <asp:HyperLinkField DataTextField = "NoOfSO" DataNavigateUrlFields="RegionName" DataNavigateUrlFormatString = "frmSOList.aspx?RegionName={0}" HeaderText = "No Of SO">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>
                <asp:BoundField DataField="InstAssigned" HeaderText="No Of <br/> Institutes <br/> Assigned" HtmlEncode ="false" Visible="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>  
                <asp:BoundField DataField="CandidateRecommended" HeaderText="No Of <br/> Candidates <br/> Recommended" HtmlEncode ="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateNotRecommended" HeaderText="No Of <br/> Candidates <br/> Not Recommended" HtmlEncode ="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidatePending" HeaderText="No of <br/> Candidates <br/> Pending" HtmlEncode ="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>  
                <asp:BoundField DataField="CandidateAssigned" HeaderText="No of <br/> Candidates <br/> Assigned" HtmlEncode ="false">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
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
