<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmStatisticCandidatesappliedbasisofReceipt.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmStatisticCandidatesappliedbasisofReceipt" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
.left-area{
width:18%!important;
}
</style>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Statistic of the Candidate" Width="100%" Height="600px" >
   
        <br />
          <asp:Button ID="btnExporttoExcel" runat="server" CssClass="InputButtonRed" Text="Export to Excel" OnClick="btnExporttoExcel_Click" />
     <br />
    
                                    
                                         <%--<div class="clearfix">

                                         </div>--%>
                                                    <div runat="server" id="divexport" >
                            <h2 style="color: red">
                                First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions  <%= AdmissionYear %> </h2>
                                    <br />
                                                        <h1 style="color: black" > Statistic of Candidates applied on the basis of Receipt (<asp:Label ID ="lblDate" runat="server"></asp:Label>)</h1>
                                        <br />

                                    <asp:GridView ID="gvReport" ShowHeader="false" ShowFooter="true" runat="server" CellPadding="10" CellSpacing="10" AutoGenerateColumns="False" Width="100%" OnRowCreated="gvReport_RowCreated" OnPreRender="gvReport_PreRender" CssClass="DataGrid">
                                        <Columns>
                                            <asp:BoundField HeaderText="Sr. No.  (1)">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="6%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="true" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CategoryName" HeaderText="Category (2)">
                                                <ItemStyle HorizontalAlign="center" CssClass="Item" Width="10%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NoofCandidatesinFinalMeritList" HeaderText="No of Candidates in Final Merit List <br/> (3)">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SubmittedbyCandidateandVerifiedbySCCVC" HeaderText="Submitted  by Candidate and Verified by SC CVC <br/> (4)">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="6%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SubmittedbyCandidatesandnotVerifiedbySCCVC" HeaderText="Submitted by Candidates and not Verified by SC CVC">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="6%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NotsubmittedbycandidatesCVC" HeaderText="Not submitted by candidates CVC">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="6%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalCVC" HeaderText="Total CVC">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="8%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SubmittedbyCandidateandVerifiedbySCNCL" HeaderText="Submitted by Candidate and Verified by SC NCL">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SubmittedbyCandidatesandnotVerifiedbySCNCL" HeaderText="Submitted by Candidates and not Verified by SC NCL">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="6%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NotsubmittedbycandidatesNCL" HeaderText="Not submitted by candidates NCL">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalNCL" HeaderText="Total NCL">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="6%" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SubmittedbyCandidateandVerifiedbySCEWS" HeaderText="Submitted  by Candidate and Verified by SC EWS">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SubmittedbyCandidatesandnotVerifiedbySCEWS" HeaderText="Submitted by Candidates and not Verified by SC EWS">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NotsubmittedbycandidatesEWS" HeaderText="Not submitted by candidates EWS">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalEWS" HeaderText="Total EWS">
                                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Wrap="false" />
                                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                                                <FooterStyle HorizontalAlign="Center" CssClass="Footer" Wrap="false" />
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
    </div>
         </cc1:ContentBox>

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
                paging: false,
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
                //responsive: !0,
                //ordering: true,
                info: false,
                search: false,
                // pageLength: 10,

                title: "First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions 2024-25"

            })
        }();

        TableManageButtons.init();

    </script>
    <%--</cc1:ContentBox>--%>
</asp:Content>
