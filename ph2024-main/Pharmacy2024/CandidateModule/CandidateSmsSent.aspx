<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="CandidateSmsSent.aspx.cs" Inherits="Pharmacy2024.CandidateModule.CandidateSmsSent" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
        .nav-pills a{
            font-size: 16px;
            margin:5px;
            background: #b7835f;
            color: white !important;
        }
    </style>
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
    </script>
    <nav class="nav nav-pills nav-justified mt-3 mb-3">
        <asp:LinkButton runat="server" ID="lkgvSentSMS" CssClass="nav-item inner-item nav-link " Text='SMS <img src="../Images/sms.png" alt="Image" width="20px" />' ForeColor="Black" OnClick="gvSentSMS_Click">            
        </asp:LinkButton>
        <asp:LinkButton runat="server" ID="lkgvSendWhatsUpSMS" CssClass="nav-item inner-item nav-link " Text='WhatsApp <img src="../Images/whatsapp.png" alt="Image" width="20px" />' ForeColor="Black" OnClick="gvSendWhatsUpSMS_Click">           
        </asp:LinkButton>
        <asp:LinkButton runat="server" ID="lkgvSendEmail" CssClass="nav-item inner-item nav-link " Text='Email <img src="../Images/email.png" alt="Image" width="20px" />' ForeColor="Black" OnClick="gvSendEmail_Click">          
        </asp:LinkButton>
    </nav>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="">

        <div class="tab-content box-shadow">
            <div id="overview" class="tab-pane fade in active show">
                <div class="table-responsive" id="dvgvSentSMS" runat="server">
                    <asp:GridView ID="gvSentSMS" runat="server" AutoGenerateColumns="False" CssClass="DataGrid" BorderWidth="1" EnableModelValidation="True" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" ItemStyle-Wrap="true" HtmlEncode="False">
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSContent" HeaderText="SMS Content" ItemStyle-Wrap="true" HtmlEncode="False">
                                <ItemStyle Width="40%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SentDateTime" HeaderText="Sent Date Time" ItemStyle-Wrap="true" HtmlEncode="False">
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSType" HeaderText="SMS Type" ItemStyle-Wrap="true" HtmlEncode="False">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

        <div class="table-responsive" id="dvgvSendWhatsUpSMS" runat="server">
            <asp:GridView ID="gvSendWhatsUpSMS" runat="server" AutoGenerateColumns="False" CssClass="DataGrid" BorderWidth="1" EnableModelValidation="True" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No.">
                        <ItemTemplate>
                            <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" ItemStyle-Wrap="true" HtmlEncode="False">
                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="WhatsUpMessage" HeaderText="WhatsApp Message" ItemStyle-Wrap="true" HtmlEncode="False">
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SentDateTime" HeaderText="Sent Date Time" ItemStyle-Wrap="true" HtmlEncode="False">
                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SMSType" HeaderText="WhatsApp Type" ItemStyle-Wrap="true" HtmlEncode="False">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="table-responsive" id="dvgvSendEmail" runat="server">
            <asp:GridView ID="gvSendEmail" runat="server" AutoGenerateColumns="False" CssClass="DataGrid" BorderWidth="1" EnableModelValidation="True" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No.">
                        <ItemTemplate>
                            <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="EmailID" HeaderText="Email ID" ItemStyle-Wrap="true" HtmlEncode="False">
                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SendEmailMaessage" HeaderText="Email Maessage" ItemStyle-Wrap="true" HtmlEncode="False">
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SentDateTime" HeaderText="Sent Date Time" ItemStyle-Wrap="true" HtmlEncode="False">
                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SMSType" HeaderText="Email Type" ItemStyle-Wrap="true" HtmlEncode="False">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </cc1:ContentBox>
</asp:Content>
