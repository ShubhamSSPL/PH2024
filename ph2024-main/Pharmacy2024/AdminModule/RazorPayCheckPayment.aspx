<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="RazorPayCheckPayment.aspx.cs" Inherits="Pharmacy2024.AdminModule.RazorPayCheckPayment" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
 <%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">

    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Fetch Form RazorPay">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Application ID</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="11" Text="PH24" Width="100px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ControlToValidate="txtApplicationID" Display="None" ErrorMessage="Please Enter Application ID."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed >>>" CssClass="InputButtonRed" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>

    <cc1:ContentBox ID="ContentBox1" runat="server"   HeaderText="Razor Pay Detils">
        <asp:Label runat="server" ID="lblApplicationID" Font-Bold="true" Font-Size="Medium"> Application ID :</asp:Label>
        <asp:Label runat="server" ID="lblPersonalID" Font-Bold="true" Font-Size="Medium"> Personal ID :</asp:Label>
        <asp:GridView ID="gvPaymentStatus" runat="server" AutoGenerateColumns="False" CssClass="DataGrid" BorderWidth="1" EnableModelValidation="True" Width="100%"
            OnRowCommand="gvPaymentStatus_RowCommand" >
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>
                <asp:BoundField DataField="PID" HeaderText="Personal ID" ItemStyle-Wrap="true" HtmlEncode="False">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="ReferenceNo" HeaderText="Reference No">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="RPPaymentId" HeaderText="Payment ID">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="ItemName" HeaderText="Fee For">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="Amount TO Pay">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="AmountPaid" HeaderText="Amount Paid">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status of payment">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="CreatedAt" HeaderText="CreatedAt">
                    <ItemStyle Width="20%" />
                </asp:BoundField>
                 <asp:ButtonField HeaderText="Payment Reconcileation" ButtonType="Button" CommandName="Reconcile" Text="Payment Reconcileation" ControlStyle-CssClass="InputButton" >
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle Font-Bold="True" />
                </asp:ButtonField>

            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
    <br />
     <ccm:ContentBox ID="cntPrev" runat="server" HeaderText="Paid Transactions Details From System">
        <asp:GridView ID="grdPrevData" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:TemplateField>
                <asp:BoundField DataField="ReferenceNo" HeaderText="Reference No">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="Total Fee (<span class='rupee'>Rs.</span>)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PaymentInitiatedOn" HeaderText="Payment Initiated On">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="18%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="DateOfPayment" HeaderText="Payment Date">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PaidStatus" HeaderText="Payment Status">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="RefundStatus" HeaderText="Refund Staus" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="12%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PrintBankReceipt" HeaderText="Print Receipt" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="12%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                 
            </Columns>
        </asp:GridView>
    </ccm:ContentBox>
    <br />
    <ccm:ContentBox ID="cntFail" runat="server" HeaderText="Failed Transactions Details From System">      
        <asp:GridView ID="grdFail" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:TemplateField>
                <asp:BoundField DataField="ReferenceNo" HeaderText="Reference No">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="Total Fee (<span class='rupee'>Rs.</span>)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PaymentInitiatedOn" HeaderText="Payment Initiated On">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="18%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PaidStatus" HeaderText="Payment Status">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Reason" HeaderText="Reason" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="27%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
                 <asp:BoundField DataField="RefundStatus" HeaderText="Refund Staus" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Item" Width="12%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </ccm:ContentBox>
</asp:Content>
