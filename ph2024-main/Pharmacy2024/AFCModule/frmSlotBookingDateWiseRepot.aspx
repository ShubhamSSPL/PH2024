<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSlotBookingDateWiseRepot.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmSlotBookingDateWiseRepot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
      <center><b>E SC Application Form Status Report</b></center>
    <asp:GridView ID="gvEFC" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
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
            <asp:BoundField DataField="PickedandPending" HeaderText="Picked and Pending" HtmlEncode="false">
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
            <asp:BoundField DataField="PerPinckedandPending" HeaderText="% Picked and Pending" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="PerNotPicked" HeaderText="% Not Picked" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>


        </Columns>
    </asp:GridView>

    <br /> <br />
    <asp:Label ID="lblgreen" runat="server" BackColor="Green" Font-Bold="true" ForeColor="Black">Green Booking less than 20%</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblyellow" runat="server" BackColor="Yellow" Font-Bold="true" ForeColor="Black">Yellow Booking 20% to 59%</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblmagents" runat="server" BackColor="Magenta" Font-Bold="true" ForeColor="Black">Magents Booking 60% to 89%</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblred" runat="server" BackColor="Red" Font-Bold="true" ForeColor="Black">Red More than or equal to 90%</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
        <Columns>
            <asp:TemplateField HeaderText="Sr. No.">
                <ItemTemplate>
                    <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="9%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:TemplateField>
            <asp:BoundField DataField="SlotDate" HeaderText="SlotDate" HtmlEncode="false">
                <ItemStyle HorizontalAlign="center" CssClass="Item" Width="10%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="Amravati" HeaderText="Amravati <br/> 1" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="Aurangabad" HeaderText="Aurangabad <br/> 2" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="Mumbai" HeaderText="Mumbai <br/> 3" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="Nagpur" HeaderText="Nagpur <br/> 4" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="Nashik" HeaderText="Nashik <br/> 5" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="Pune" HeaderText="Pune <br/> 6" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>
            <asp:BoundField DataField="Total" HeaderText="Total" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
            </asp:BoundField>


        </Columns>
    </asp:GridView>
    Printed On : <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True"></asp:Label>

</asp:Content>
