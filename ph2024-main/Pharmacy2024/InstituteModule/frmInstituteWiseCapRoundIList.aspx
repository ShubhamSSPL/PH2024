<%@ Page  Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master"   AutoEventWireup="true" Async="true" AsyncTimeout="100000" Buffer="true" CodeBehind="frmInstituteWiseCapRoundIList.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmInstituteWiseCapRoundIList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">

    <div class="wrapper wrapper-content animated fadeInRight">

        <div class="row w-100 mx-auto">
            <div class="col-xl-12">
                <div class="card mb-4">
                    <div class="card-header card-Status">
                        <i class="fas fa-list mr-1"></i>
                        Institue Wise CAP Round I, II & III Allotment List 
                    </div>
                    <div class="card-body" style="overflow-x: auto">
                        <div class="row w-100 mx-auto">
                            <div class="col-xl-12">
                                <div class="card mb-4">

                                    <div class="row">
                                        <div class="col-lg-2 sf-align-right">
                                            <h6>Select Type : </h6>
                                        </div>
                                        <div class="col-sm-4 col-5-offset">

                                            <asp:DropDownList ID="ddlSMSType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSMSType_SelectedIndexChanged">
                                                <asp:ListItem Value="1">All</asp:ListItem>
                                                <asp:ListItem Value="2">Non TFWS</asp:ListItem>
                                                <asp:ListItem Value="3">TFWS</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <br />
                                    <asp:GridView ID="gvSMSList" runat="server" AutoGenerateColumns="False" Width="100%" OnPreRender="gvSMSList_PreRender" CssClass="table table-striped DataGridForBootstrap">
                                        <Columns>
                                            <%-- <asp:BoundField HeaderText="Sr. No.">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="7%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="ApplicationID" HeaderText="ApplicationID">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                               <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SeatTypeAllotted" HeaderText="Seat Type Allotted">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="PrefStatus" HeaderText="Preference Details">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="InstituteReportingStatus" HeaderText="Institute Reporting Status">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                      <%--      <asp:BoundField DataField="MeritNo" HeaderText="Merit No">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MeritMarks" HeaderText="Merit Marks">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>--%>
                                            <%--<asp:BoundField DataField="PreferenceNoAllotted" HeaderText="Preference No Allotted">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="SeatAcceptanceStatus" HeaderText="Seat Acceptance Status">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SeatAcceptanceConfermation" HeaderText="Seat Acceptance Confirmation">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvRegion" runat="server" AutoGenerateColumns="False" Width="100%" OnPreRender="gvRegion_PreRender" CssClass="table table-striped DataGridForBootstrap">
                                        <Columns>
                                             <asp:BoundField DataField="InstituteID" HeaderText="Institute ID">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApplicationID" HeaderText="ApplicationID">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SeatTypeAllotted" HeaderText="Seat Type Allotted">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                              <asp:BoundField DataField="PrefStatus" HeaderText="Preference Details">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="RegionID" HeaderText="Region ID">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="InstituteReportingStatus" HeaderText="Institute Reporting Status">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                           <%-- <asp:BoundField DataField="MeritNo" HeaderText="Merit No">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MeritMarks" HeaderText="Merit Marks">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>--%>
                                            <%--<asp:BoundField DataField="PreferenceNoAllotted" HeaderText="Preference No Allotted">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>--%>
                                             <asp:BoundField DataField="SeatAcceptanceStatus" HeaderText="Seat Acceptance Status">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SeatAcceptanceConfermation" HeaderText="Seat Acceptance Confirmation">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
            0 !== $('#<%= gvSMSList.ClientID %>').length && $('#<%= gvSMSList.ClientID %>').DataTable({
                dom: "Bfrtip",
                paging: true,
                buttons: [{
                //    extend: "copy",
                //    className: "btn btn-primary",
                //    title: 'First Year Under Graduate Technical Courses in Engineering and Technology Admissions 2024-25'
                //}, {
                //    extend: "csv",
                //    className: "btn btn-danger",
                //    title: ' First Year Under Graduate Technical Courses in Engineering and Technology Admissions 2024-25'

                //}, {
                    extend: "excel",
                    className: "btn btn-success",
                    autoFilter: false,
                    sheetName: 'Pharmacy',
                    title: 'First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions 2024-25'
                }//, {
                //    extend: "pdf",
                //    className: "btn btn-info",
                //    title: ' First Year Under Graduate Technical Courses in Engineering and Technology Admissions 2024-25'
                //}, {
                //    extend: "print",
                //    className: "btn btn-warning",
                //    title: 'First Year Under Graduate Technical Courses in Engineering and Technology Admissions 2024-25'
                //}],
                //"columnDefs": [
                //    {
                //        "targets": [0],
                //        "visible": false,
                //        "searchable": false
                //    },
                //    {
                //        "targets": [1],
                //        "visible": false
                //    }
                ],
                responsive: !0,
                ordering: true,
                info: true,
                search: true,
                pageLength: 10,
                title: "First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions 2024-25"
                 

            })
        }();
        var handleDataTableButtonsRegion = function () {
            "use strict";
            0 !== $('#<%= gvRegion.ClientID %>').length && $('#<%= gvRegion.ClientID %>').DataTable({
                dom: "Bfrtip",
                paging: true,
                buttons: [{
                    extend: "copy",
                    className: "btn btn-primary",
                    title: 'First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions 2024-25'
                }, {
                    extend: "csv",
                    className: "btn btn-danger",
                    title: ' First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions 2024-25'

                }, {
                    extend: "excel",
                    className: "btn btn-success",
                    autoFilter: false,
                        sheetName: 'Pharmacy',
                    title: ' First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions 2024-25'
                }, {
                    extend: "pdf",
                        className: "btn btn-info",
                        orientation: 'landscape',
                    title: ' First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions 2024-25'
                }, {
                    extend: "print",
                    className: "btn btn-warning",
                    title: 'First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions 2024-25'
                }],
                //"columnDefs": [
                //    {
                //        "targets": [0],
                //        "visible": false,
                //        "searchable": false
                //    },
                //    {
                //        "targets": [1],
                //        "visible": false
                //    }
                //],
                responsive: !0,
                ordering: true,
                info: true,
                search: true,
                pageLength: 10,

                title: "First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions 2024-25"

            })
        }();
        handleDataTableButtonsRegion.init();
        TableManageButtons.init();

    </script>
</asp:Content>
