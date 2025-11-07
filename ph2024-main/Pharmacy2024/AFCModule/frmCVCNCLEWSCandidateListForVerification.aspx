<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCVCNCLEWSCandidateListForVerification.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmCVCNCLEWSCandidateListForVerification" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <div class="row w-100 mx-auto">
        <div class="col-xl-12">
            <div class="card mb-4">
                <div class="card-header card-Status">
                    <i class="fas fa-database mr-1"></i>
                    
                    CVC/TVC NCL EWS  Request for Verification of Document
                </div>
                <div class="card-body" style="overflow-x: auto">
                    <div class="row w-100 mx-auto">
                        <div class="col-xl-12">
                            <div class="card mb-4">
                                <asp:GridView ID="gvCandidateList" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="gvCandidateList_RowCommand" OnPreRender="gvCandidateList_PreRender" CssClass="table table-striped DataGridForBootstrap">
                                    <Columns>
                                        <asp:BoundField HeaderText="Sr. No.">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ApplicationID" HeaderText="Application ID">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                                            <ItemStyle HorizontalAlign="Left" Width="35%" CssClass="Item" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ConfirmedDateTime" HeaderText="Confirmed Date Time">
                                            <ItemStyle HorizontalAlign="Center" Width="25%" CssClass="Item" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ConfirmedBy" HeaderText="Confirmed By">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AllotmentStatus" HeaderText="Allotment Status">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                                        </asp:BoundField>

                                        <asp:ButtonField HeaderText="Verify Application Form" ButtonType="Button" CommandName="Verify" Text="Verify CVC/TVC NCL EWS Document" ControlStyle-CssClass="InputButton">
                                            <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                                            <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            <ControlStyle Font-Bold="True" />
                                        </asp:ButtonField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPersonalID" runat="server" Text='<%# Eval("PersonalID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVerificationMode" runat="server" Text='<%# Eval("FCVerificationFor") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
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
    <%--</cc1:ContentBox>--%>
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
            0 !== $('#<%= gvCandidateList.ClientID %>').length && $('#<%= gvCandidateList.ClientID %>').DataTable({
                //dom: "Bfrtip",
                paging: true,
                //// buttons: [{
                //     extend: "copy",
                //     className: "btn btn-primary",
                //     title: 'E-SC Verified / Confirmed Candidate List'
                // }, {
                //     extend: "csv",
                //     className: "btn btn-danger",
                //         title: 'E-SC Verified / Confirmed Candidate List'

                // }, {
                //     extend: "excel",
                //     className: "btn btn-success",
                //     autoFilter: false,
                //     sheetName: 'POSTHSC',
                //         title: 'E-SC Verified / Confirmed Candidate List'
                // }, {
                //     extend: "pdf",
                //     className: "btn btn-info",
                //         title: 'E-SC Verified / Confirmed Candidate List'
                // }, {
                //     extend: "print",
                //     className: "btn btn-warning",
                //         title: 'E-SC Verified / Confirmed Candidate List'
                // }],
                responsive: !0,
                ordering: true,
                info: true,
                search: true,
                pageLength: 10,

                title: "E-SC Verified / Confirmed Candidate List"

            })

        }();
    </script>
    <script type="text/javascript">
        <%-- $(document).ready(function () {
            $('#<%= gvReport.ClientID %>').dataTable({
                 
            });
        }); --%>
        TableManageButtons.init();
    </script>
</asp:Content>
