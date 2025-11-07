<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmDownloadRegisterdCandidateDataWithAdmissionDetails.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmDownloadRegisterdCandidateDataWithAdmissionDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
 <style>
        .Hide 
        { 
            display:none; 
        }
    </style>
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "Admitted Candidate List" Width = "100%" Height = "400px" ScrollBars = "auto">
       <%-- <asp:Button ID="btnExporttoExcel" runat="server" CssClass = "InputButton" Text="Export to Excel" OnClick="btnExporttoExcel_Click" />
        <br /><br />--%>
       <%--  <asp:Button ID="Button1" runat="server" CssClass = "InputButton" Text="Export to Excel" OnClick="OnExportExcel" />--%>
        <br /><br />
        <asp:GridView ID="gvAdmittedCandidateList" runat="server" AutoGenerateColumns="true" Width="100%" CellPadding="5" CssClass = "DataGrid"   >
            <%--<Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FatherName" HeaderText="Father Name">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MotherName" HeaderText="Mother Name">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Gender" HeaderText="Gender">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="DOB" HeaderText="DOB">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Religion" HeaderText="Religion">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Region" HeaderText="Region">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MotherTongue" HeaderText="Mother Tongue">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AnnualFamilyIncome" HeaderText="Annual Family Income">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAddressLine1" HeaderText="Address Line 1">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAddressLine2" HeaderText="Address Line 2">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CAddressLine3" HeaderText="Address Line 3">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CState" HeaderText="State">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CDistrict" HeaderText="District">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CTaluka" HeaderText="Taluka">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CVillage" HeaderText="Village">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CPincode" HeaderText="Pincode">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="EMailID" HeaderText="E-Mail ID">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PhoneNo" HeaderText="Phone No">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Hide" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Hide" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalCandidatureType" HeaderText="Candidature Type">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalHomeUniversity" HeaderText="Home University">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalCategory" HeaderText="Category">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalPHType" HeaderText="PH Type">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalDefenceType" HeaderText="Defence Type">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalLinguisticMinority" HeaderText="Linguistic Minority">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalReligiousMinority" HeaderText="Religious Minority">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SSCBoard" HeaderText="SSC Board">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SSCPassingYear" HeaderText="SSC Passing Year">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SSCSeatNo" HeaderText="SSC Seat No">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SSCMathPercentage" HeaderText="SSC Math Percentage">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SSCTotalPercentage" HeaderText="SSC Total Percentage">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="HSCBoard" HeaderText="HSC Board">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="HSCPassingYear" HeaderText="HSC Passing Year">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="HSCSeatNo" HeaderText="HSC Seat No">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="HSCPhysicsPercentage" HeaderText="HSC Physics Percentage">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="HSCChemistryPercentage" HeaderText="HSC Chemistry Percentage">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="HSCSubject" HeaderText="HSC Additional Subject for Eligiblity">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="HSCSubjectPercentage" HeaderText="HSC Subject Percentage">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="HSCBioTechnologyPercentage" HeaderText="HSC Bio-Technology Percentage">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="HSCTotalPercentage" HeaderText="HSC Total Percentage">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="EligibilityPercentage" HeaderText="Eligibility Percentage">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CETRollNo" HeaderText="CET Roll No">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CETScore" HeaderText="CET Score">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MeritNo" HeaderText="Merit No">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="MeritMarks" HeaderText="Merit Marks">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteCodeAdmitted" HeaderText="Institute Code">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteNameAdmitted" HeaderText="Institute Name">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseNameAdmitted" HeaderText="Course Name">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ChoiceCodeAdmitted" HeaderText="Choice Code">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="SeatTypeAdmitted" HeaderText="Seat Type">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="AdmissionDate" HeaderText="Admission Date">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ReportedDate" HeaderText="Reported Date">
                    <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                </asp:BoundField>
            </Columns>--%>
        </asp:GridView>
    </cc1:ContentBox>
</asp:Content>
