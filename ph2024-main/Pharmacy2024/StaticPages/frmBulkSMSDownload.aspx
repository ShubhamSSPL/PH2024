<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" Async="true" AsyncTimeout="100000" Buffer="true" CodeBehind="frmBulkSMSDownload.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmBulkSMSDownload" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">

    <div class="wrapper wrapper-content animated fadeInRight">

        <div class="row w-100 mx-auto">
            <div class="col-xl-12">
                <div class="card mb-4">
                    <div class="card-header card-Status">
                        <i class="fas fa-list mr-1"></i>
                        Bulk SMS data 
                    </div>
                    <div class="card-body" style="overflow-x: auto">
                        <div class="row w-100 mx-auto">
                            <div class="col-xl-12">
                                <div class="card mb-4">

                                    <div class="row">
                                        <div class="col-lg-2 sf-align-right">
                                            <h6>Select SMS Type : </h6>
                                        </div>
                                        <div class="col-sm-4 col-5-offset">

                                            <asp:DropDownList ID="ddlSMSType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSMSType_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select --</asp:ListItem>
                                                
                                               <%-- <asp:ListItem Value="AFLDR">Application From Last Date Reminder</asp:ListItem>
                                                <asp:ListItem Value="PScrutinyFilledcompleteButNotConfirmed">PScrutinyFilledcompleteButNotConfirmed</asp:ListItem> 
                                                <asp:ListItem Value="TotalRegisteredButNotFilledCompletely">TotalRegistered But Not Filled Completely</asp:ListItem>
                                                <asp:ListItem Value="TotalFilledCompletelyButNotConfirmedatFCs">Total Filled Completely But Not Confirmedat SCs</asp:ListItem>
                                                <asp:ListItem Value="ConfirmCancelledForm">ConfirmCancelledForm</asp:ListItem>
                                                <asp:ListItem Value="DiscrepancyNotSolved">Discrepancy Not Solved</asp:ListItem>--%>
                                                
                                                  
                                                   <%-- <asp:ListItem Value="NonCAPToCAP">Non-CAP To CAP</asp:ListItem>
                                                 <asp:ListItem Value="NotInPmeritButEligibleForFmeritSA">Not In Provisinal merit But Eligible For Final Merit Single Acknowledgement</asp:ListItem>
                                                <asp:ListItem Value="NotInPmeritButEligibleForFmeritMA">Not In Provisinal merit But Eligible For Final Merit Multiple Acknowledgement</asp:ListItem>
                                                      --%>


                                                <%--<asp:ListItem Value="AFLDR">Application From Last Date Reminder</asp:ListItem> 
                                                <asp:ListItem Value="DiscrepancyNotSolved">Discrepancy Not Solved</asp:ListItem>
                                                <asp:ListItem Value="EVerificationApplicationFormNotLocked">EVerificationApplicationFormNotLocked</asp:ListItem>
                                                <asp:ListItem Value="LockAndResubmit">LockAndResubmit</asp:ListItem>
                                                <asp:ListItem Value="RevertedBackCandidates">RevertedBackCandidates</asp:ListItem> 
                                                <asp:ListItem Value="LockGrievance">LockGrievance</asp:ListItem>
                                                <asp:ListItem Value="ConfirmCancelledForm">ConfirmCancelledForm</asp:ListItem>
                                                <asp:ListItem Value="PScrutinyFilledcompleteButNotConfirmed">PScrutinyFilledcompleteButNotConfirmed</asp:ListItem>--%>

                                               <%-- <asp:ListItem Value="RevertedBackCandidatesCompulsoryDiscrepancy">RevertedBackCandidatesCompulsoryDiscrepancy</asp:ListItem>
                                                <asp:ListItem Value="EVeriAppFormNotLockedGrievancePeriod">EVeriAppFormNotLockedGrievancePeriod</asp:ListItem>
                                                <asp:ListItem Value="PVeriAppFormNotLockedGrievancePeriod">PVeriAppFormNotLockedGrievancePeriod</asp:ListItem>
                                                <asp:ListItem Value="RevertedBackNonSubmissionofDocumentAndNotEligible">RevertedBackNonSubmissionofDocumentAndNotEligible</asp:ListItem>
                                                <asp:ListItem Value="ConfirmCancelledForm">ConfirmCancelledForm</asp:ListItem> --%>

                                              <%--  <asp:ListItem Value="EWSOCR">EWSOCR</asp:ListItem> 
                                                <asp:ListItem Value="TFWSOCR">TFWSOCR</asp:ListItem>--%>
                                                 
                                                <%--<asp:ListItem Value="CVCOCR">CVCOCR</asp:ListItem>                                                 
                                                <asp:ListItem Value="NCLOCR">NCLOCR</asp:ListItem>--%>

                                               <%-- <asp:ListItem Value="OFormCAPRound1LastDate"> CAP Round I Option Form Reminder Last Day</asp:ListItem>--%>
                                                  
                                               <%-- <asp:ListItem Value="OFormCAPRound2LastDate"> CAP Round II Option Form Reminder Last Day</asp:ListItem>
                                                <asp:ListItem Value="InstituteCAPReportingForRound1LastDate">Institute CAPReporting For Round1 LastDate</asp:ListItem>
                                                <asp:ListItem Value="ARCReportingCAPRound1LastDate">ARC Reporting CAPRound1 Last Date</asp:ListItem>--%>

                                               

                                                   <%-- <asp:ListItem Value="CVCNCLEWSPending"> CVC NCL EWS Pending</asp:ListItem>
                                                <asp:ListItem Value="OFormCAPRound2LastDate"> CAP Round II Option Form Reminder Last Day</asp:ListItem>
                                                <asp:ListItem Value="OFormCAPRound3LastDate"> CAP Round II Option Form Not Locked</asp:ListItem> 

                                                      

                                                 <asp:ListItem Value="CVCNCLEWSPendingENDEligible"> CVCNCLEWS Pending END Eligible</asp:ListItem>
                                                <asp:ListItem Value="CVCNCLEWSPendingENDNotEligible">CVCNCLEWS Pending END Not Eligible </asp:ListItem> 
                                                 <asp:ListItem Value="CVCNCLEWSAdmissionCancelled">CVCNCLEWS Admission Cancelled </asp:ListItem>--%>

                                                 <%-- <asp:ListItem Value="PScrutinyFilledcompleteButNotConfirmed">PScrutinyFilledcompleteButNotConfirmed</asp:ListItem>
                                                 <asp:ListItem Value="ConfirmCancelledForm">ConfirmCancelledForm</asp:ListItem>
                                                 <asp:ListItem Value="CVCNCLEWSPendingNew2022">CVCNCLEWSPendingNew2022</asp:ListItem>--%>

                                              <%-- <asp:ListItem Value="AFLDR">Application From Last Date Reminder</asp:ListItem>
                                                 <asp:ListItem Value="DiscrepancyNotSolved">Discrepancy Not Solved</asp:ListItem>
                                                 <asp:ListItem Value="LockAndResubmit">LockAndResubmit</asp:ListItem>
                                                 <asp:ListItem Value="EVerificationApplicationFormNotLocked">EVerificationApplicationFormNotLocked</asp:ListItem>
                                                <asp:ListItem Value="TotalRegisteredButNotFilledCompletely">TotalRegistered But Not Filled Completely</asp:ListItem> 
                                                <asp:ListItem Value="PScrutinyNotFilledcomplete">PScrutinyNotFilledcomplete</asp:ListItem> 
                                                <asp:ListItem Value="LockGrievance">LockGrievance</asp:ListItem>
                                                <asp:ListItem Value="OFormCAPRound1LastDate">OFormCAPRound1LastDate</asp:ListItem>
                                                <asp:ListItem Value="ProvisionalAllotmentDisplayCAPRound1">ProvisionalAllotmentDisplayCAPRound1</asp:ListItem>--%>

                                               <%-- <asp:ListItem Value="ARCReportingCAPRound1LastDate">ARCReportingCAPRound1LastDate</asp:ListItem>
                                                <asp:ListItem Value="InstituteCAPReportingForRound1LastDate">InstituteCAPReportingForRound1LastDate</asp:ListItem>--%>

                                               <%-- <asp:ListItem Value="OFormCAPRound2LastDate">OFormCAPRound2LastDate</asp:ListItem>--%> 
                                                    
                                                <%--<asp:ListItem Value="InstituteCAPReportingForRound2LastDate">Institute CAPReporting For Round2 LastDate</asp:ListItem>
                                                <asp:ListItem Value="ARCReportingCAPRound2LastDate">ARC Reporting CAPRound2 Last Date</asp:ListItem>--%>

                                                <%--  <asp:ListItem Value="ReceiptReminder">ReceiptReminder</asp:ListItem>--%>
                                                  <asp:ListItem Value="OFormCAPRound3LastDate">OFormCAPRound3LastDate</asp:ListItem>

                                                <%-- <asp:ListItem Value="CVCNCLEWSPendingNew2022">CVC NCL EWS Pending Reminder 2022 </asp:ListItem> --%>
                                                <%-- <asp:ListItem Value="InstituteCAPReportingForRound3LastDate">Institute CAPReporting For Round3 LastDate</asp:ListItem>
                                                <asp:ListItem Value="ARCReportingCAPRound3LastDate">ARC Reporting CAPRound3 Last Date</asp:ListItem>--%>

                                                 <%--<asp:ListItem Value="AdmissionNotCancelledConvertedToOpen">AdmissionNotCancelledConvertedToOpen</asp:ListItem>
                                                 <asp:ListItem Value="AdmissionCancelledEligibleForNext">AdmissionCancelledEligibleForNext</asp:ListItem>
                                                 <asp:ListItem Value="AdmissionCancelledNotEligibleForNext">AdmissionCancelledNotEligibleForNext</asp:ListItem>

                                                 <asp:ListItem Value="NotAdmittedConvertToOpenEligibleForIL">NotAdmittedConvertToOpenEligibleForIL</asp:ListItem>
                                                 <asp:ListItem Value="NotAdmittedConvertToOpenNotEligibleForIL">NotAdmittedConvertToOpenNotEligibleForIL</asp:ListItem>
                                                
                                                <asp:ListItem Value="CategoryConversionFeeNotPaid">CategoryConversionFeeNotPaid</asp:ListItem>--%>

                                                <asp:ListItem Value="SEBC_CVC_6MonthLastDate">SEBC_CVC_6MonthLastDate</asp:ListItem>
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
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="18%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EMailID" HeaderText="EMailID">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SMS" HeaderText="SMS">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="42%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SMSUnit" HeaderText="SMSLenght">
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

        TableManageButtons.init();
         
    </script>
</asp:Content>
