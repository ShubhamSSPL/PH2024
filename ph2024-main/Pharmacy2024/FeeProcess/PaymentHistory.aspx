<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="PaymentHistory.aspx.cs" Inherits="Pharmacy2024.FeeProcess.PaymentHistory" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>

<asp:Content ID="content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script type="text/javascript" language="javascript">
        window.sessionStorage
        function PrintForm(URL) {
            window.open(URL, "main", "toolbar=no,location=no,menubar=no,scrollbars=yes,width=700, height=600, left=100, top=25");
        }
        function ShowPopUp() {
            var stringURL = "RemoveApplicationFromCart.aspx";
            OpenPOPup(stringURL);
            return false;
        }
        function OpenPOPup(stringURL) {
            var iFrames = $("#IFASPXHolder");
            document.getElementById('IFASPXHolder').src = stringURL;

            if (!OASIS.Browser.IsIe)
                iFrames[0].style.width = "100%";

            $('#div_PopUp').modal({ onOpen: modalOpen, onClose: CancelPopUp });
        }
        function CancelPopUp() {
            document.getElementById('IFASPXHolder').src = "../Images/BigProgress.gif";
            $.modal.close();

            location.reload();
        }
    </script>
    <ccm:ContentBox ID="cntPrev" runat="server" HeaderText="Paid Transactions Details">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color = "red">
                        <p align = "justify"><font color = "red"><b>Instructions :</b></font></p>
                        <ul class="list-text">
                            <li><p align = "justify"><font color = "red">Receipt for Online / Netbanking Payment can be taken by clicking on "Print" Button under "Print Receipt" Column.</font></p></li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
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
    <ccm:ContentBox ID="cntFail" runat="server" HeaderText="Failed Transactions Details">      
        <asp:GridView ID="grdFail" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid table-responsive">
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
