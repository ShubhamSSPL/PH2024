<%@ Page Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="PendingGrievanceList.aspx.cs" Inherits="Pharmacy2024.Grievance.PendingGrievanceList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
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
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Pending Tickets">
        <div class="row card-body w-100">
            <div class="col-md-12">
                <asp:UpdatePanel runat="server" ID="upGrievance">
                    <ContentTemplate>
                        <div class="row text-center">
                            <div class="col-md-12">
                                <a href="GrievanceHome.aspx" Class="btn  m-3" style="color:white;background:grey"><i class="fa fa-home mr-2" aria-hidden="true"></i>Home</a>
                                <asp:Button ID="btnPending" runat="server" Text="Pending Tickets" CssClass="btn btn-primary m-3" BackColor="blue" OnClick="btnPending_Click" CausesValidation="false" />
                                <asp:Button ID="btnInProcess" runat="server" Text="In-Process Tickets" CssClass="btn btn-primary m-3" OnClick="btnInProcess_Click" CausesValidation="false" />
                                <asp:Button ID="btnReplied" runat="server" Text="Replied Tickets" CssClass="btn btn-primary m-3" OnClick="btnReplied_Click" CausesValidation="false" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3"></div>
                            <div class="col-md-9">
                                <div class="form-group">
                                    <div class="form-inline">
                                        <asp:TextBox ID="txtSearch" runat="server" placeholder="Enter Ticket ID / Login ID" MaxLength="15" CssClass="form-control col-md-6"></asp:TextBox>
                                        <div class="col-md-2 text-center">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-success btn-sm ml-2 mt-1" OnClick="btnSearch_Click" />
                                        </div>
                                        <div id="validationDialog" style="display: none">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator ID="rfvSearch" runat="server" ErrorMessage="Please Enter Ticket ID / Login ID." ControlToValidate="txtSearch" Display="None"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gvGrievanceList" runat="server" AutoGenerateColumns="false" CssClass="table mahait-table text-center mahait-dt admisstion_ms_content_gv" OnRowDataBound="gvGrievanceList_RowDataBound" OnRowCommand="gvGrievanceList_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Open" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Width="8%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnView" runat="server" CommandName="V" CommandArgument='<%#Eval("GrievanceID")%>' Text="<i class='fa fa-eye' style='font-size:24px'></i>" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="GrievanceID" HeaderText="Ticket ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Width="10%" />
                                        <asp:BoundField DataField="ApplicationID" HeaderText="Login ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Width="15%" />
                                        <asp:BoundField DataField="GrievanceCategory" HeaderText="Category" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Width="25%" />
                                        <asp:BoundField DataField="SentDateTime" HeaderText="Sent Date Time" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Width="17%" />
                                        <asp:BoundField DataField="GrievanceStatus" HeaderText="Current Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="1px" ItemStyle-BorderWidth="1px" ItemStyle-BorderColor="#EEEEEE" HeaderStyle-BorderColor="#EEEEEE" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Width="25%" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </cc1:ContentBox>
    <br />
</asp:Content>
