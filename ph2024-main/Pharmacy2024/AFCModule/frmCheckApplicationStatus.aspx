<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCheckApplicationStatus.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmCheckApplicationStatus" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false" CornerStyle="SquareCut">
        <table class="AppFormTable">
            <tr>
                <td style="width: 30%" align="right">Application ID</td>
                <td style="width: 70%">
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate's Name</td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Application Form Status">
        <table class="AppFormTable">
            <tr>
                <td>
                    <asp:GridView ID="gvApplicationFormLinksStatus" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Step ID">
                                <ItemTemplate>
                                    Step <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="LinkDescription" HeaderText="Step Details">
                                <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="55%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Button ID="btnFormStatus" runat="server" Text='<%# Eval("LinkStatus") %>' CssClass="InputButton" BackColor='<%# System.Drawing.Color.FromName(Eval("LinkBackColor").ToString()) %>' Enabled="false"></asp:Button>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
