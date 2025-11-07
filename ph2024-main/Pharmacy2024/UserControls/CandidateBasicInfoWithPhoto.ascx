<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CandidateBasicInfoWithPhoto.ascx.cs" Inherits="Pharmacy2024.UserControls.CandidateBasicInfoWithPhoto" %>


<table class="AppFormTable">
    <tr>
        <td style="border-top-width: 0px;" align="center">
            <font size="3">
                        Application ID : 
                        <asp:Label id="lblApplicationID" runat="server" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;
                        Version No : 
                        <asp:Label id="lblVersionNo" runat="server" Font-Bold="True"></asp:Label> <br /><br />
               <%-- Course Applied	:
                        <asp:Label id="lblCourseApplied" runat="server" Font-Size = "Medium" Font-Bold="True"></asp:Label>--%>
                    </font>
        </td>
         <td align="Left">Candidate's Name : <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label> <br />
            Gender : <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label> <br />
            Candidature Type :  <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label> <br />
            Category for Admission : <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label>
        </td>
        <td align="center">
            <asp:Image ID="imgPhotograph" Width="96" Height="91" runat="server" AlternateText="Candidate Photograph" /></td>
    </tr>
</table>
<table class="AppFormTable">
   <%-- <tr>
        <th style="border-top-width: 0px;" colspan="4">Personal Details</th>
    </tr>--%>
    <tr>
       
       <%-- <td align="center">
            <asp:Image ID="imgPhotograph" Width="133" Height="171" runat="server" AlternateText="Candidate Photograph" /></td>--%>
    </tr>
     
</table>
