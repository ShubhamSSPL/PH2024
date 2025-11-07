<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAskApplicationIDAtIL.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmAskApplicationIDAtIL" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server">
        <table class="AppFormTableWithOutBorder" id="tblInstructions" runat="server" visible="false">
            <tr>
                <td>
                    <b>Instructions : </b>
                    <br /><br />
                    <ol class="list-text">
                        <li><p align = "justify">Institute can collect Fee in Cash/Demand Draft. If candidate submits Cash/Demand Draft/ Pay Order / Online System then institute is required to enter details in the system.</p></li>
                        <li><p align = "justify">Select course in which the Candidate has taken admission.</p></li>
                        <li><p align = "justify">Institute should carefully select "Course" and "Seat Type" as per Candidate’s preferred option and admit candidate.</p></li>
                        <li><p align = "justify">On Successful admission of the candidate, the system shall generate Receipt Number for Receipt-cum-Acknowledgement of admission.</p></li>
                        <%--<li><p align = "justify">The cut-off date for admission for Maharashtra, All India, NRI, PIO/OCI, FOREIGN STUDENT & CIWGC is 29/01/2021 Up to 5 P.M. Such candidates should be reported on or before 29/01/2021 Up to 5 P.M. The admissions can be Uploaded up to 29/01/2021 Up to 5 P.M. The window for Uploading the Institutional Level seats shall be closed after 29/01/2021 Up to 5 P.M.</p></li>--%>
                        <li><p align = "justify">The Admissions to the North East and Union Territory Candidates allotted by appropriate authority appointed by MHRD can be uploaded by the institutions.</p></li>
                    </ol>
                    <br />
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%;" align="right">Application ID</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="11" Width="110px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ErrorMessage="Please Enter Application ID." ControlToValidate = "txtApplicationID" Display="None"></asp:RequiredFieldValidator>
                </td> 
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbSelectAdmission" runat="server" HeaderText = "Select Admission">
        <table class="AppFormTable">
            <tr>
                <td align="right">Application ID</td>
                <td><asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td> 
            </tr>
            <tr>
                <td style="width:30%;border-bottom-width:0px;" align="right">Candidate Name</td>
                <td style="width:70%;border-bottom-width:0px;"><asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td> 
            </tr>
        </table>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid">
            <Columns> 
                <asp:BoundField DataField="ProceedURL" HeaderText="Select" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteCode" HeaderText = "Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteAllotted" HeaderText = "Institute Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Width="45%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "CourseAllotted" HeaderText = "Course Name">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="20%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "ChoiceCodeAllotted" HeaderText = "Choice Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "SeatTypeAllotted" HeaderText = "Seat Type">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "AdmissionDate" HeaderText = "Admission Date">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>