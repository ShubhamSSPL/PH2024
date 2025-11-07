<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmFCDailySlotLimitUpdate.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmFCDailySlotLimitUpdate" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible="true" HeaderText="Update Daily Slot Capacity For Physical Scrutiny">

        <table class="AppFormTableWithOutBorder" id="tblUpdateSlot" runat="server">
            <tr>
                <td align="center">
                    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid" OnRowDataBound="gvList_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" onclick="ClickOnChk(this.id)" />
                                </ItemTemplate>
                                <%--    <HeaderTemplate>
                                Select All<br />
                                <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this.checked)" />
                            </HeaderTemplate>--%>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Width="10%" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="10%" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="SlotDate" DataField="SlotDate">
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="20%" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="20%" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="AvailableSlots">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAvilableSlots" runat="server" Text='<%# Bind("AvilableSlots") %>' Enabled="false" />
                                    <asp:RequiredFieldValidator ID="rfvtxtAvilableSlots" ControlToValidate="txtAvilableSlots" runat="server"
                                        ErrorMessage="AvilableSlots is Required" ForeColor="Red" Display="Static"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator runat="server" ID="cvtxtAvilableSlot" ControlToValidate="txtAvilableSlots" ControlToCompare="txtBooked" Operator="GreaterThanEqual" Type="Integer"
                                        ErrorMessage="Avilable Slot should be grater than Booked Slots." ForeColor="Red" Display="Static"></asp:CompareValidator>
                                    <asp:CompareValidator runat="server" ID="cvAvilablegrater" ControlToValidate="txtAvilableSlots" Operator="GreaterThan" ValueToCompare="31" Type="Integer"
                                        ErrorMessage="Avilable Slot should be greater than or equal to 32." ForeColor="Red" Display="Static"></asp:CompareValidator>

                                    <%-- <asp:Label ID ="lblStar" runat="server" visible="false" Text="*" Font-Bold="false" ForeColor="Red"></asp:Label> --%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="50%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:TemplateField>
                            <%-- <asp:BoundField HeaderText="AvilableSlots" DataField="AvilableSlots">
                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="20%" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="20%" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                        </asp:BoundField>--%>

                            <%--<asp:BoundField HeaderText="Booked" DataField="Booked">
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="20%" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="70%" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                        </asp:BoundField>--%>

                            <asp:TemplateField HeaderText="Booked">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBooked" runat="server" Text='<%# Bind("Booked") %>' ReadOnly="true" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="50%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblFCDateID" runat="server" Text='<%# Eval("FCDateID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnUpdaeSlot" runat="server" Text="Update Slot" CssClass="InputButton" OnClick="btnUpdaeSlot_Click" />
                </td>
            </tr>
        </table>
        <script type="text/javascript" language="javascript">
            function checkitem(checkBox, textBox1, rfvAvilableSlot, cvAvilableSlot) {

                var e = document.getElementById(textBox1.id);
                var f = document.getElementById(checkBox.id);
                var rfv = document.getElementById(rfvAvilableSlot.id);
                var cv = document.getElementById(cvAvilableSlot.id);
                if (f.checked == true) {
                    e.disabled = false;
                    rfv.disabled = false;
                    cv.disabled = false;
                }
                else {
                    e.disabled = true;
                    rfv.disabled = true;
                    cv.disabled = true;

                }

            }
        </script>
    </cc1:ContentBox>
</asp:Content>