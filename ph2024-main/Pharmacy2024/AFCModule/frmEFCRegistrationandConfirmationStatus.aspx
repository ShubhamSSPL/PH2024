<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmEFCRegistrationandConfirmationStatus.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEFCRegistrationandConfirmationStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
     <center><b>E SC Application Form Status Report</b></center>
    <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
        <Columns>
            <%--<asp:TemplateField HeaderText="Sr. No.">
                <ItemTemplate>
                    <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="9%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:TemplateField>--%>
            <asp:BoundField DataField="Registered" HeaderText="Registered" HtmlEncode="false">
                <ItemStyle HorizontalAlign="center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="RegisteredandCompletedForm" HeaderText="Registered and Completed Form" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="Confirmed" HeaderText="Confirmed" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="PinckedandPending" HeaderText="Pincked and Pending" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="NotPicked" HeaderText="Not Picked" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="PerConfirmed" HeaderText="% Confirmed" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="PerPinckedandPending" HeaderText="% Pincked and Pending" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="PerNotPicked" HeaderText="% Not Picked" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>


        </Columns>
    </asp:GridView>
    Printed On : <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True"></asp:Label>
</asp:Content>
