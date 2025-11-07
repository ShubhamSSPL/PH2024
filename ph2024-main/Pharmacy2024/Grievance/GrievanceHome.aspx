<%@ Page Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="GrievanceHome.aspx.cs" Inherits="Pharmacy2024.Grievance.GrievanceHome" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
        .card-header {
            /*padding: 0.25rem 0.75rem;*/
            font-size: 18px;
            font-weight: 500;
        }
        .card-title {
            margin-bottom: 0rem;
        }
       /* h5 {
            font-size:xx-large;
        }*/
        .admisstion_ms_content_gv {
            width: 100%;
            font-size:14px;
        }
            .admisstion_ms_content_gv tr td {
                padding: 6px;
            }
        .mahait-table th {
            padding: 6px;
        }
        .table th {
            background-color: #e6f5e4;
        }
        .table td {
            vertical-align: middle;
        }       
    </style>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Ticket Management">
        <div class="row card-body w-100">
            <div class="col-md-12">
                <asp:UpdatePanel runat="server" ID="upGrievance">
                    <ContentTemplate>
                        <div class="row text-center">
                            <div class="col-md-12">
                                <asp:Button ID="btnPending" runat="server" Text="Pending Tickets" CssClass="btn btn-primary m-3" OnClick="btnPending_Click" CausesValidation="false" />
                                <asp:Button ID="btnInProcess" runat="server" Text="In-Process Tickets" CssClass="btn btn-primary m-3" OnClick="btnInProcess_Click" CausesValidation="false" />
                                <asp:Button ID="btnReplied" runat="server" Text="Replied Tickets" CssClass="btn btn-primary m-3" OnClick="btnReplied_Click" CausesValidation="false" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row mb-3">
                    <div class="col-md-4">
                        <div class="cardTicket text-white bg-info">
                            <div class="card-header text-center">Pending Tickets</div>
                            <div class="card-body">
                                <h5 class="card-title text-center"><asp:Label ID="lblPendingGrievances" runat="server">1234</asp:Label></h5>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="cardTicket text-white bg-warning">
                            <div class="card-header text-center">In-Process Tickets</div>
                            <div class="card-body">
                                <h5 class="card-title text-center"><asp:Label ID="lblInProcessGrievances" runat="server">1234</asp:Label></h5>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="cardTicket text-white bg-success">
                            <div class="card-header text-center">Replied Tickets</div>
                            <div class="card-body">
                                <h5 class="card-title text-center"><asp:Label ID="lblRepliedGrievances" runat="server">1234</asp:Label></h5>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive section">
                            <asp:GridView ID="gvList" class="table mahait-table text-center mahait-dt admisstion_ms_content_gv" BorderWidth="1px" runat="server" AutoGenerateColumns="false" OnRowCommand="gvList_RowCommand">
                                <Columns> 
                                    <asp:TemplateField HeaderText="Sr. No." HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1%>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GrievanceCategory" HeaderText="Category" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Width="35%" />
                                    <asp:TemplateField HeaderText="Pending Tickets" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnPendingGrievances" runat="server" CommandArgument='<%# Bind("GrievanceCategoryID") %>' CommandName="PendingGrievances" Text='<%# Bind("PendingGrievances") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="In-Process Tickets" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnInProcessGrievances" runat="server" CommandArgument='<%# Bind("GrievanceCategoryID") %>' CommandName="InProcessGrievances" Text='<%# Bind("InProcessGrievances") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Replied Tickets" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnRepliedGrievances" runat="server" CommandArgument='<%# Bind("GrievanceCategoryID") %>' CommandName="RepliedGrievances" Text='<%# Bind("RepliedGrievances") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>  
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </cc1:ContentBox>
    <br />
</asp:Content>
