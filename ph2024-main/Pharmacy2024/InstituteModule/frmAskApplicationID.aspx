<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAskApplicationID.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmAskApplicationID" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Application ID</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="11" Width="110px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ErrorMessage="Please Enter Application ID." ControlToValidate="txtApplicationID" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbSelectAdmission" runat="server" HeaderText="Select Admission">
        <table class="AppFormTable">
            <tr>
                <td align="right">Application ID</td>
                <td>
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 30%; border-bottom-width: 0px;" align="right">Candidate Name</td>
                <td style="width: 70%; border-bottom-width: 0px;">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr runat="server" id="trCVCMsg" visible="false">
                <td colspan="2" style="color:red">The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                    
<br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 16/12/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
<br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
<br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.

</td>
            </tr>
        </table>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField DataField="ProceedURL" HeaderText="Select" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteAllotted" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="45%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseAllotted" HeaderText="Course Name">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ChoiceCodeAllotted" HeaderText="Choice Code">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SeatTypeAllotted" HeaderText="Seat Type">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAPRound" HeaderText="CAP Round">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AdmissionDate" HeaderText="Admission Date">
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
