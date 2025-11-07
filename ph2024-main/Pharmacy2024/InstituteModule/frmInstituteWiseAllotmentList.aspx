<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmInstituteWiseAllotmentList.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmInstituteWiseAllotmentList" %>


<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Institute-Wise Allotment List">
        <asp:GridView ID="gvInstituteList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid" OnRowDataBound="gvInstituteList_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" Width="58%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:BoundField>
                      <%--<asp:BoundField DataField="DownloadRound1" HeaderText="CAP-I Mock" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>--%>
                <%--     <asp:BoundField DataField="DownloadRound1" HeaderText="CAP-I" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>--%>
                <%--<asp:BoundField DataField="DownloadRound2" HeaderText="CAP-II Mock" HtmlEncode = "false"  >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>--%>
                <asp:TemplateField HeaderText="CAP-I Mock">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnCap1" runat="server"
                            PostBackUrl='<%# "~/InstituteModule/frmviewpdfmock.aspx?InstId="+ Eval("InstituteCode") +"&Rnd=1" %>'
                            ImageUrl="~/Images/download.png" ImageAlign="Middle" Visible="false"></asp:ImageButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CAP-II Mock">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnCap2" runat="server" 
                            PostBackUrl='<%# "~/InstituteModule/frmviewpdfmock.aspx?InstId="+ Eval("InstituteCode") +"&Rnd=2" %>'
                            ImageUrl="~/Images/download.png" ImageAlign="Middle" Visible="false"></asp:ImageButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Header" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CAP-III Mock">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnCap3" runat="server"
                                    PostBackUrl='<%# "~/InstituteModule/frmviewpdfmock.aspx?InstId="+ Eval("InstituteCode") +"&Rnd=3" %>' 
                                    ImageUrl="~/Images/download.png" ImageAlign="Middle" Visible="false"></asp:ImageButton>
                            </ItemTemplate>
             <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:TemplateField> 

                <%--  <asp:BoundField DataField="DownloadRound3" HeaderText="CAP-III" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>--%>
                <%--  <asp:BoundField DataField="DownloadRound4" HeaderText="Additional Round" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>--%>
            </Columns>
        </asp:GridView>
        <%--<br />
        <br />
        <iframe id="displayPDf" src="https://ph2024.mahacet.org/CAP-II_Mock/CAPR-II_3012.pdf"></iframe>--%>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ctVerification" runat="server" HeaderText="Draft Allotment Feedback">
        <table class="AppFormTable" style="width: 100%;">
            <tr>
                <td align="right" valign="baseline">Select Status
                    <font color="red"><sup>*</sup></font>
                </td>
                <td>                    
                    <asp:RadioButtonList ID="rbLstRequest" runat="server" Width="95%" CssClass="radioButtonList">
                        <asp:ListItem Value="Yes" Text="Verified and Found ok"></asp:ListItem>
                        <asp:ListItem Value="No" Text="Issue in Allotment"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="rfvrbLstRequest" runat="server" ForeColor="Red" Font-Bold="true" ControlToValidate="rbLstRequest" ErrorMessage="Please choose One option for Status" ValidationGroup="Feedback"> </asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td align="right" valign="baseline">Comments/Remark
                    <font color="red"><sup>*</sup></font>
                </td>
                <td>                    
                    <asp:TextBox ID="txtComments" runat="server" Width="95%" Height="70px" MaxLength="550" TextMode="MultiLine" ValidationGroup="Feedback"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtComments" ControlToValidate="txtComments" runat="server" ErrorMessage="Please Enter Comments/Remark." ForeColor="Red" Font-Bold="true" ValidationGroup="Feedback"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnProceed" runat="server" Text="Submit >>>" OnClick="btnProceed_Click" CssClass="InputButton" ValidationGroup="Feedback"></asp:Button></td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="false" ValidationGroup="Feedback"/>
            </tr>

        </table>
    </cc1:ContentBox>
</asp:Content>



