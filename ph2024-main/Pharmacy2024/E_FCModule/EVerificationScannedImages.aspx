<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" CodeBehind="EVerificationScannedImages.aspx.cs" Inherits="Pharmacy2024.E_FCModule.EVerificationScannedImages" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/CandidateBasicInfo.ascx" TagName="BInfo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
         #layoutSidenav #layoutSidenav_content {
            margin-left: unset !important;
        }

        @media only screen and (max-width: 768px) {
            .AppFormTableWithOutBorder input {
                font-size: 11px;
            }
        }
    </style>
      <script lang="javascript" type = "text/javascript">
          window.history.forward(1);
      </script>
    <script src="../Scripts/jquery.js"></script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Candidate Details">
        <uc1:BInfo ID="CandidateBasicInformation" runat="server" />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Candidate Photo">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <table class="AppFormTable">
            <tr>
                <th colspan="6" align="left">Photo Details</th>
            </tr>
            <tr>
                <td align="right" rowspan="5">Photo </td>
                <td colspan="2" rowspan="5">
                    <asp:Image ID="imgPhotograph" Width="133" Height="171" runat="server" AlternateText="Candidate Photograph" />
                </td>
                <td align="right" rowspan="5">Signature </td>
                 <td colspan="2" rowspan="5">
                    <asp:Image ID="imgSignature"  Width="133" Height="57" runat="server" AlternateText="Candidate Signature" />
                </td>
            </tr>
        </table>
        <br />

        <cc1:ContentBox ID="ContentTableDeiscripency" runat="server" HeaderText="Update Status of Verification" Width="100%">
       <div class="table-responsive">
            <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <table class="AppFormTableWithOutBorder" runat="server" id="tblDiscripancy">
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvDiscrepancy" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid" OnRowDataBound="gvDiscrepancy_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="5%" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DiscrepancyName" HeaderText="Particulars" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="20%" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Status of Verification">
                                        <ItemTemplate>
                                            <asp:RadioButton ID="rbnYes" runat="server" Text="&nbsp;Verified" GroupName="YesNo" AutoPostBack="true" OnCheckedChanged="rbnYes_CheckedChanged" />
                                            &nbsp; &nbsp;&nbsp;
                                             <asp:RadioButton ID="rbnNo" runat="server" Text="&nbsp;Not Accepted" GroupName="YesNo" AutoPostBack="true" OnCheckedChanged="rbnNo_CheckedChanged" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="25%" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsVerifiedAtAFC" runat="server" Text='<%# Eval("IsVerifiedAtAFC") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDiscrepancyID" runat="server" Text='<%# Eval("DiscrepancyID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsDiscrepancyMarked" runat="server" Text='<%# Eval("IsDiscrepancyMarked") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discrepancy Remark">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDiscrepancyRemark" runat="server" Text='<%# Bind("DiscrepancyRemark") %>' TextMode="MultiLine" Height="50" Width="90%" Enabled="false" />
                                            <asp:RequiredFieldValidator ID="rfvtxtDiscrepancyRemark" ControlToValidate="txtDiscrepancyRemark"  runat="server" Enabled="false" 
                                                  ErrorMessage="Discrepancy Remark is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:Label ID ="lblStar" runat="server" visible="false" Text="*" Font-Bold="false" ForeColor="Red"></asp:Label> 
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Item" Width="50%" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" CssClass="Header" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
              
            </ContentTemplate>
        </asp:UpdatePanel>
            </div>
    </cc1:ContentBox>
        <table class="AppFormTableWithOutBorder" runat="server" id="tblSubmit">
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblmessage" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnECandidateDashboard" runat="server" Text="Verification Dashboard" CssClass="InputButton" OnClick="btnECandidateDashboard_Click" />
                </td>
                <td align="left">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>


    <script type="text/javascript">

        function MarkDiscripency() {
            document.getElementById('<%=ContentTableDeiscripency.ClientID %>').Show('', true);
            document.getElementsByClassName("HeadDiv")[2].children[1].hidden = true;
            document.getElementById('<%=lblmessage.ClientID%>').innerText = '';
            document.getElementById('<%=tblSubmit.ClientID %>').style.visibility = "hidden";
        }
        function HideMarkDiscripency() {
            document.getElementById('<%=ContentTableDeiscripency.ClientID %>').Hide('', true);
            document.getElementById('<%=tblSubmit.ClientID %>').style.visibility = "visible";
        }

    </script>
</asp:Content>
