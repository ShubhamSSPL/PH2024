<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmAllotedInstituteSO.aspx.cs" Inherits="Pharmacy2024.MVModule.frmAllotedInstituteSO" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
     <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="List Of Institutes Assigned for Merit List Verification" Width = "100%" ScrollBars = "auto">
         <table class="AppFormTableWithOutBorder">
          <tr>
              <td>
                     <tr>
                <td colspan = "4">
                    <p style="font-size:medium;" align = "justify"><b>Important Note :</b></p>
                    <ol class="list-text">
                        <li><p style="font-size:medium" align = "justify">Changes can be made by SO till the Institute is not confirmed/verified by RO.</p></li>
                        <li><p style="font-size:medium" align = "justify">Institute hilighted in 'Gray' color is verified by RO. Hence no changes can be made. </p></li>
                       
                    </ol>
                </td>
            </tr>
              </td>
          </tr>
         </table>
         <center><asp:Label ID="lblInstituteName" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:GridView ID="gvReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
                <asp:BoundField DataField="num_row" HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:HyperLinkField DataTextField = "InstituteCode" DataNavigateUrlFields="InstituteCode" DataNavigateUrlFormatString = "frmAllotedChoiceCodeList.aspx?InstituteCode={0}" HeaderText = "Institute Code">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField>
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Right" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="TotalAdmitted" HeaderText="Candidates <br/> Assigned" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <%--<asp:BoundField DataField="TotalAdmCanceled" HeaderText="Total <br /> Admission <br /> Cancelled" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>--%>
                <asp:BoundField DataField="Recomended" HeaderText="Candidates <br/> Recommended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="NotRecomended" HeaderText="Candidates <br/> Not <br/> Recommended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="IsVerified" HeaderText="Is <br /> Verified" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>                 
                <asp:TemplateField HeaderText="Is <br /> Verified <br/> By RO">
                    <ItemTemplate>                    
                        <asp:Label ID="lblInstStatus" runat="server" Text='<%#Bind("IsVerifiedRO") %>' Visible = "true" />                
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
