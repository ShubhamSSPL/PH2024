<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="RazorPayRefund.aspx.cs" Inherits="Pharmacy2024.AdminModule.RazorPayRefund" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">

        <div class="row w-100 mx-auto">
            <div class="col-xl-12">
                <div class="card mb-4">
                    <div class="card-header card-Status">
                        <i class="fas fa-list mr-1"></i>
                        List of All Settlement 
                    </div>
                    <div class="card-body" style="overflow-x: auto">
                        <div class="row w-100 mx-auto">
                            <div class="col-xl-12">
                                <div class="card mb-4">
                                    <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" OnPreRender="gvReport_PreRender" CssClass="table table-striped DataGridForBootstrap" ShowFooter="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No." HeaderStyle-BackColor="#88CED5" HeaderStyle-ForeColor="White">
                                                <ItemTemplate>
                                                    <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Id" HeaderText="Settlement Id">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CreatedAt" HeaderText="Settlement Date">
                                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Status" HeaderText="Status">
                                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PersonalID" HeaderText="PersonalID">
                                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ReferenceNo" HeaderText="ReferenceNo">
                                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="amount" HeaderText=" Refund Amount">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amount">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Fee" HeaderText="Fees">
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Tax" HeaderText="Tax">
                                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PaymentStatus" HeaderText="PaymentStatus">
                                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TransectionDate" HeaderText="Transection Date">
                                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="PaymentId" HeaderText="PaymentId">
                                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                                            </asp:BoundField>

                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--    </cc1:ContentBox>--%>

    <script src="../SBAdmin/dist/js/jquery-3.3.1.min.js"></script>
    <script src="../SBAdmin/dist/js/jquery.dataTables.min.js"></script>
    <script src="../SBAdmin/dist/js/dataTables.bootstrap4.min.js"></script>
    <script src="../SBAdmin/dist/js/buttons.bootstrap4.min.js"></script>
    <script src="../SBAdmin/dist/js/dataTables.buttons.min.js"></script>
    <script src="../SBAdmin/dist/js/jszip.min.js"></script>
    <script src="../SBAdmin/dist/js/pdfmake.min.js"></script>
    <script src="../SBAdmin/dist/js/vfs_fonts.js"></script>
    <script src="../SBAdmin/dist/js/buttons.html5.min.js"></script>
    <script src="../SBAdmin/dist/js/buttons.print.min.js"></script>
    <script src="../SBAdmin/dist/js/buttons.colVis.min.js"></script>
    <script src="../SBAdmin/dist/js/datatables-init.js"></script>

    <script>
        var handleDataTableButtons = function () {
            "use strict";
            0 !== $('#<%= gvReport.ClientID %>').length && $('#<%= gvReport.ClientID %>').DataTable({
                dom: "Bfrtip",
                paging: true,
                buttons: [{
                    extend: "copy",
                    className: "btn btn-primary",
                    title: 'Settlement Report For First Year Pharmacy Admissions'
                }, {
                    extend: "csv",
                    className: "btn btn-danger",
                    title: 'Settlement Report For First Year Pharmacy Admissions'

                }, {
                    extend: "excel",
                    className: "btn btn-success",
                    autoFilter: false,
                    sheetName: 'POSTHSC',
                    title: 'Settlement Report For First Year Pharmacy Admissions'
                },
                {
                    extend: "pdf",
                    className: "btn btn-info",
                    title: 'Settlement Report For First Year Pharmacy Admissions'
                },
                {
                    extend: "print",
                    className: "btn btn-warning",
                    title: 'Settlement Report For First Year Pharmacy Admissions'
                }],
                responsive: !0,
                ordering: true,
                info: true,
                search: true,
                pageLength: 20,

                title: "Settlement Report For First Year Pharmacy Admissions"

            })
        }();

        TableManageButtons.init();
    </script>

</asp:Content>
