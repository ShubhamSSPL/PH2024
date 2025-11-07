<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmChoiceCodePrefrencesByCandidate.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmChoiceCodePrefrencesByCandidate" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="ChoiceCodePrefrencesByCandidate" Width = "100%" ScrollBars = "auto">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <b>Select CAP Round : </b>
                    <asp:DropDownList ID="ddlCAPRound" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "ddlCAPRound_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select CAP Round</asp:ListItem>
                        <asp:ListItem Value="1">CAP Round 1</asp:ListItem>
                        <asp:ListItem Value="2">CAP Round 2</asp:ListItem>
                        <asp:ListItem Value="3">CAP Round 3</asp:ListItem>
                        <asp:ListItem Value="4">CAP Round 4</asp:ListItem>
                        <%--<asp:ListItem Value="5">CAP Round 5</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>        
    </cc1:ContentBox>
    <br />
    <cc1:ContentBox ID="ContentBoxControl" runat="server" HeaderText="InActive Choice Code but Candidate given Prefrences" Width = "100%" Height = "300px" ScrollBars = "auto">
        <asp:GridView ID="gvInActiveChoiceCode" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
                <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalIntake" HeaderText="Total Intake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <table runat = "server" id = "tblMsgNewChoiceCode" visible="false" class = "AppFormTable">
            <tr>
                <th height = "100" align="center" valign = "middle">
                    <asp:Label ID="lblMsgNewChoiceCode" runat="server" Text="No New Choice Codes Available." Font-Bold="True" Font-Size="Small"></asp:Label>
                </th>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <br />
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Active Choice Code but Candidate not given Prefrences" Width = "100%" Height = "300px" ScrollBars = "auto">
        <asp:GridView ID="gvActiveChoiceCode" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
                <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="ChoiceCode">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="HomeUniversityName" HeaderText="University">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseStatus1" HeaderText="Course Status 1">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseStatus2" HeaderText="Course Status 2">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseStatus3" HeaderText="Course Status 3">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseShift" HeaderText="Shift">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="Accreditation" HeaderText="Accreditation">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="AccreditationFrom" HeaderText="Accreditation From">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="AccreditationPeriod" HeaderText="Accreditation Period">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="Gender" HeaderText="Gender">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="IsGov" HeaderText="Is Gov">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="IsNRI" HeaderText="Is NRI">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="IsPIO" HeaderText="Is PIO">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalIntake" HeaderText="Total Intake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="JKIntake" HeaderText="JK Intake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="CourtCaseRemark" HeaderText="Court Case Remark">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField="ParticipateInCAP" HeaderText="Participate In CAP">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <table runat = "server" id = "tblMsgUpdateChoiceCode" visible="false" class = "AppFormTable">
            <tr>
                <th height = "100" align="center" valign = "middle">
                    <asp:Label ID="lblMsgUpdateChoiceCode" runat="server" Text="No Choice Codes Available for Updation." Font-Bold="True" Font-Size="Small"></asp:Label>
                </th>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
