<%@ Page Language="C#"  MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master"  AutoEventWireup="true" CodeBehind="frmConfirmedCandidateList.aspx.cs" Inherits="Pharmacy2024.E_FCModule.frmConfirmedCandidateList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
   <%-- <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "E-SC Verified / Confirmed Candidate List">--%>
          <div class="row w-100 mx-auto">
        <div class="col-xl-12">
            <div class="card mb-4">
                <div class="card-header card-Status">
                    <i class="fas fa-database mr-1"></i>
                    "E-SC Verified / Confirmed Candidate List
                </div>
                <div class="card-body" style="overflow-x: auto">
                    <div class="row w-100 mx-auto">
                        <div class="col-xl-12">
                            <div class="card mb-4 border-0">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td style="width: 50%;" align="right">Select Date to Filter : </td>
                <td style="width: 50%;"><asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        </table>
        <asp:GridView ID="gvCandidateList" runat="server" AutoGenerateColumns="False" Width="100%" OnPreRender="gvCandidateList_PreRender" CssClass="table table-striped DataGridForBootstrap">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate Name">
                    <ItemStyle HorizontalAlign="Left" Width="35%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                     <asp:BoundField DataField = "MobileNo" HeaderText = "Mobile No" Visible="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "LastModifiedOnFCVerificationStatus" HeaderText = "Last Modified <br /> SC Verification Status" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="25%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "LastModifiedByFCVerificationStatus" HeaderText = "Last Modified By <br /> SC Verification Status" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "LastModifiedByIPAddressFCVerificationStatus" HeaderText = "Last Modified By <br /> IPAddress SC Verification Status" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "IsConfirmedUnderEWS" HeaderText = "Is Confirmed<br /> Under EWS" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
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

