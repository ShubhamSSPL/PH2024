<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSlotSelectedNotConfirmedList.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmSlotSelectedNotConfirmedList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
         <div class="wrapper wrapper-content animated fadeInRight">

        <div class="row w-100 mx-auto">
            <div class="col-xl-12">
                <div class="card mb-4">
                    <div class="card-header card-Status">
                        <i class="fas fa-list mr-1"></i>
                        Candidate Booked Slot Not Confirmed at SC List
                    </div>
                    <div class="card-body" style="overflow-x: auto">
                        <div class="row w-100 mx-auto">
                            <div class="col-xl-12">
                                <div class="card mb-4">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td style="width: 50%;" align="right">Select Date to Filter : </td>
                <td style="width: 50%;">
                    <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        </table>
         <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>

        <asp:GridView ID="gvCandidateList" runat="server" AutoGenerateColumns="False" Width="100%" OnPreRender="gvCandidateList_PreRender" OnRowCommand="gvCandidateList_RowCommand" CssClass="table table-striped DataGridForBootstrap">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application <br/> ID" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="SlotTime" HeaderText="Slot Time">
                    <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="SlotDate" HeaderText="SlotDate">
                    <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="FCID" HeaderText="SC Code" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CoordinatorName" HeaderText="SC Officer <br/> Name" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CoordinatorMobileNo" HeaderText="SC Officer <br/> MobileNo" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="false" />
                </asp:BoundField>
                 <asp:TemplateField HeaderText = "Status of Contact to Candidate">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRepliedMessage" runat="server" MaxLength = "1000" Height="80" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="60%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:TemplateField>
                 <asp:ButtonField HeaderText="Reply" ButtonType="Button" CommandName="Reply" Text="Update Contact Message" ControlStyle-CssClass="InputButton">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle Font-Bold="True" />
                </asp:ButtonField> 
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPersonalID" runat="server" Text='<%# Eval("PersonalID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
            0 !== $('#<%= gvCandidateList.ClientID %>').length && $('#<%= gvCandidateList.ClientID %>').DataTable({
               // dom: "Bfrtip",
              
                //buttons: [{
                //    extend: "copy",
                //    className: "btn btn-primary",
                //    title: 'Settlement Report For First Year Pharmacy Admissions'
                //}, {
                //    extend: "csv",
                //    className: "btn btn-danger",
                //    title: 'Settlement Report For First Year Pharmacy Admissions'

                //}, {
                //    extend: "excel",
                //    className: "btn btn-success",
                //    autoFilter: false,
                //    sheetName: 'POSTHSC',
                //    title: 'Settlement Report For First Year Pharmacy Admissions'
                //},
                //{
                //    extend: "pdf",
                //    className: "btn btn-info",
                //    title: 'Settlement Report For First Year Pharmacy Admissions'
                //},
                //{
                //    extend: "print",
                //    className: "btn btn-warning",
                //    title: 'Settlement Report For First Year Pharmacy Admissions'
                //    }
                //],
                paging: true,
                responsive: !0,
                ordering: false,
                info: true,
                search: true,
                pageLength: 10,

                title: "Settlement Report For First Year Pharmacy Admissions"

            })
        }();

        TableManageButtons.init();
    </script>
</asp:Content>
