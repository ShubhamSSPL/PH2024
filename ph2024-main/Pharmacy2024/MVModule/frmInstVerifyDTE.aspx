<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmInstVerifyDTE.aspx.cs" Inherits="Pharmacy2024.MVModule.frmInstVerifyDTE" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">

    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script language="javascript" type="text/javascript">
        function Selectallcheckbox(val) {
            if (!$(this).is(':checked')) {
                $('input:checkbox').prop('checked', val.checked);
            } else {
                $("#chkroot").removeAttr('checked');
            }
        }
    </script>

    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="List of Institutes which are verified by RO but NOT verified by DTE" Width = "100%" ScrollBars = "auto">
        <center><asp:Label ID="lblMsg" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:GridView ID="gvReport" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
                <%-- <asp:TemplateField>
                 <HeaderTemplate>
                    <asp:CheckBox ID="checkAll" runat="server" onclick = "javascript:Selectallcheckbox(this);" />
                 </HeaderTemplate>
                 <ItemTemplate>
                    <asp:CheckBox ID="chkVerify" Checked="false" runat="server" />
                 </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
            </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Institute Code" Visible="false" >  
             <ItemTemplate> 
                 <asp:Label ID="lblInstCode" runat="server" Text='<%#Bind("InstituteCode") %>'  /> 
                 </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
            </asp:TemplateField>
                <asp:HyperLinkField DataTextField = "InstituteCode" DataNavigateUrlFields="InstituteCode" DataNavigateUrlFormatString = "frmAllotedCCLDTE.aspx?InstituteCode={0}" HeaderText = "Institute Code">
                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>                
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
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
                <asp:BoundField DataField="Recomended" HeaderText="Recomended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="NotRecomended" HeaderText="Not <br/> Recomended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:HyperLinkField Text="Confirm" DataNavigateUrlFields="InstituteCode" DataNavigateUrlFormatString = "frmMLVCertificateDTE.aspx?InstituteCode={0}" 
                    HeaderText = "Verify Institute" ControlStyle-Font-Bold="true" ControlStyle-BackColor="Wheat" ControlStyle-BorderColor="LightYellow" ControlStyle-BorderStyle="Solid" Target="_blank">
                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>                                             
            </Columns>
        </asp:GridView>
        <p></p> <p></p>
        <%--<div><center><asp:Button ID="btnSubmit" runat="server" Text="Verify Institutes" CssClass="InputButton" OnClientClick="return confirm('Are you sure you want to verify selected institutes ?');" OnClick="btnSubmit_Click" /></center></div>--%>
        <p></p> <p></p>
    </cc1:ContentBox>
</asp:Content>

