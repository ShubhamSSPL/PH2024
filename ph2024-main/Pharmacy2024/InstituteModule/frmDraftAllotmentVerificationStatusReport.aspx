<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmDraftAllotmentVerificationStatusReport.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmDraftAllotmentVerificationStatusReport" %>


<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .DataGridForBootstrap th{
           text-align: center !important;
       }
    </style>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Draft Allotment Verification Status Report">
        <table class="AppFormTableWithOutBorder">
            <tr id="trRegion" runat="server" visible="false">
                <td align="right" width="50%">Select Region :
                </td>
                <td>
                    <asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                        <asp:ListItem Value="0">All</asp:ListItem>
                        <asp:ListItem Value="1">Amravati</asp:ListItem>
                        <asp:ListItem Value="2">Aurangabad</asp:ListItem>
                        <asp:ListItem Value="3">Mumbai</asp:ListItem>
                        <asp:ListItem Value="4">Nagpur</asp:ListItem>
                        <asp:ListItem Value="5">Nashik</asp:ListItem>
                        <asp:ListItem Value="6">Pune</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">Select Verification Status :
                </td>
                <td>

                    <asp:DropDownList ID="ddlVerificationStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlVerificationStatus_SelectedIndexChanged">
                        <asp:ListItem Value="0">All</asp:ListItem>
                        <asp:ListItem Value="Y">Verified</asp:ListItem>
                        <asp:ListItem Value="N">Not Verified</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trVerificationDetails" runat="server" visible="false">
                <td align="right">Allotment Status :
                </td>
                <td>
                    <asp:DropDownList ID="ddlVerificationDetails" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlVerificationDetails_SelectedIndexChanged">
                        <asp:ListItem Value="0">All</asp:ListItem>
                        <asp:ListItem Value="Y">Allotment ok</asp:ListItem>
                        <asp:ListItem Value="N">Issue in Allotment</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <%-- <tr>
                <td>
                    <asp:Button ID="btnProceed" runat="server" Text="Submit >>>" OnClick="btnProceed_Click" CssClass="InputButton"></asp:Button>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="false" />
                </td>
            </tr>--%>
        </table>
        <br />
        <div class="wrapper wrapper-content animated fadeInRight">
            <div class="card">
                 <%--<div class="card-header card-Status">
                    <i class="fas fa-list mr-1"></i>
                    Draft Allotment Verification Status Report
                </div>--%>
                <div class="card-body">
                    <asp:GridView ID="gvCandidateList" runat="server" AutoGenerateColumns="False" Width="100%" OnPreRender="gvReport_PreRender" CssClass="Datagrid  DataGridForBootstrap">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="InstituteName" HeaderText="Institute Name">
                                <ItemStyle HorizontalAlign="Left" Width="35%" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CoordinatorName" HeaderText="Coordinator Name">
                                <ItemStyle HorizontalAlign="Center" Width="13%" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CoordinatorMobileNo" HeaderText="Coordinator Mobile No">
                                <ItemStyle HorizontalAlign="Center" Width="9%" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CoordinatorAltMobileNo" HeaderText="Coordinator Alt Mobile No">
                                <ItemStyle HorizontalAlign="Center" Width="9%" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VerificationStatus" HeaderText="Is Allottment Found OK">
                                <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Remark" HeaderText="Remark">
                                <ItemStyle HorizontalAlign="Center" Width="17%" CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
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
            0 !== $('#<%= gvCandidateList.ClientID %>').length && $('#<%= gvCandidateList.ClientID %>').DataTable({
                dom: "Bfrtip",
                paging: true,
                buttons: [{
                    extend: "excel",
                    className: "btn btn-success",
                    autoFilter: false,
                    sheetName: 'Pharmacy2024',
                    title: 'Draft Allotment Verification Status Report'
                }],
                responsive: !0,
                ordering: false,
                info: true,
                search: true,
                pageLength: 30,

                title: "Draft Allotment Verification Status Report"

            })
        }();

        TableManageButtons.init();
    </script>
</asp:Content>

