<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintFormHeader.ascx.cs" Inherits="Pharmacy2024.UserControls.PrintFormHeader" %>
<table class="AppFormTable" id="tblHeader2" runat="server">
    <tr>
        <td style="width: 10%; border-right-width: 0px;" align="center">
            <img src="../Images/WebsiteLogo.png" alt="" style="width: 73px; height: auto" /></td>
        <td style="width: 80%; border-left-width: 0px; border-right-width:0px;" align="center">
            <b>
                <img src="../Images/WebsiteLogoOld_Print.png" alt="" /><br />
                <font size="4">G</font><font size="2">OVERNMENT</font><font size="4">O</font><font size="2">F</font><font size="4">M</font><font size="2">AHARASHTRA</font>
                <br />
                <font size="4">S</font><font size="2">TATE</font><font size="4">C</font><font size="2">OMMON</font><font size="4">E</font><font size="2">NTRANCE</font><font size="4">T</font><font size="2">EST</font><font size="4">C</font><font size="2">ELL,</font><font size="4">M</font><font size="2">AHARASHTRA</font><font size="4">S</font><font size="2">TATE</font>
                <br />
                <font size="1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
                <br />
                <br />
                <font size="2"><b><asp:Label runat="server" ID="lblHeaderTitle"></asp:Label></b></font>
                <asp:Label id="lblTitle" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Small" Visible="false"><br /><br />For Non-CAP Admissions to Institution Level and ACAP Seats after CAP</asp:Label>
            </b>
        </td>
        <td style="width: 10%; border-left-width: 0px;" align="center">
            <img src="../Images/ARAFINAL.png" alt="" style="width: 73px; height: auto" /></td>
    </tr>
</table>
