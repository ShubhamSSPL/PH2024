<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSelectChoiceCodeForAdmissionCancellation.aspx.cs" Inherits="Pharmacy2024.CandidateAdmissionReportingModule.frmSelectChoiceCodeForAdmissionCancellation" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="cbSelectAdmission" runat="server" HeaderText = "Select Admission">
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid">
            <Columns> 
                <asp:BoundField DataField="ProceedURL" HeaderText="Select" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteCode" HeaderText = "Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteName" HeaderText = "Institute Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Width="45%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "CourseName" HeaderText = "Course Name">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="20%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "ChoiceCodeDisplay" HeaderText = "Choice Code">
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
                <asp:BoundField DataField = "AdmittedThrough" HeaderText = "Admitted Through">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
