<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmCheckResult.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmCheckResult" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        function numbersonly(e) 
        {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) 
            {
                if (unicode < 48 || unicode > 57) 
                {
                    return false
                }
            }
        }
        function Printit() 
        {
            document.getElementById("top1").style.display = 'none';
            document.getElementById("top2").style.display = 'none';
            document.getElementById("left1").style.display = 'none';
            document.getElementById("footer1").style.display = 'none';
            document.getElementById("btnPrint").style.display = 'none';
            document.getElementById("rightContainer1").style.width = '900px';

            window.print();

            document.getElementById("top1").style.display = '';
            document.getElementById("top2").style.display = '';
            document.getElementById("left1").style.display = '';
            document.getElementById("footer1").style.display = '';
            document.getElementById("btnPrint").style.display = '';
            document.getElementById("rightContainer1").style.width = '79.7%';
        }
    </script>
    <cc1:ContentBox ID="cbCheckResult" runat="server" HeaderText="MAH-MBA/MMS-CET 2020 Result">
        <table class="AppFormTable" width = "40%" align="center" id = "tblResult" runat = "server">
            <tr>
                <th colspan="2">Enter Your Registration Number OR Roll Number to View Your MAH-MBA/MMS-CET 2020 Result</th>
            </tr>
            <tr>
                <td style ="width:50%" align="right"><b>Enter Registration Number / Roll Number</b></td>
                <td style ="width:50%">
                    <asp:TextBox ID="txtRegistrationNo" runat="server" Width="100px" MaxLength="10" onkeypress="return numbersonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvRegistrationNo" runat="server" ErrorMessage="Please Enter Your Registration Number / Roll Number." ControlToValidate="txtRegistrationNo" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <center>
                        <asp:Button ID="btnProceed" runat="server" Text="SUBMIT" CssClass="InputButton" OnClick="btnProceed_Click"  />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    </center>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbDisplayResult" runat="server" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
			    <td style="border-right-width:0px;" align="center"><img src="../Images/dtelogo.jpg" alt = "" /></td>
			    <td style="border-left-width:0px;" align="center">
				    <b>
					    <font size="4">S</font><font size="2">TATE</font> <font size="4">C</font><font size="2">OMMON</font> <font size="4">E</font><font size="2">NTRANCE</font> <font size="4">T</font><font size="2">EST</font> <font size="4">C</font><font size="2">ELL,</font> <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font>
                        <br />
                        <font size = "1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
					    <br /><br />
					    <font size="4">MAH-MBA/MMS-CET 2020 Result</font>
				    </b>
			    </td>
		    </tr>
            <tr>
                <td colspan = "2" align = "center">
                    <font size = "4">
                        Registration Number : <asp:Label id="lblApplicationID" runat="server" Font-Bold="True"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Roll Number : <asp:Label id="lblSeatNo" runat="server" Font-Bold="True"></asp:Label>
                    </font>
                </td>
            </tr>
        </table>  
        <table class="AppFormTable">
            <tr>
                <td style="width:50%;border-top-width:0px;" align="right">Candidate's Full Name</td>
                <td style="width:50%;border-top-width:0px;"><asp:Label id="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td> 
            </tr>
            <tr>
                <td align="center" colspan="2"><b>Your MAH-MBA/MMS-CET 2020 Result is..</b></td>
            </tr>
            <tr>
                <td align="right">CET Score (OutOf 200)</td>
                <td><asp:Label id="lblCETScore" runat="server" Font-Bold = "true"></asp:Label></td> 
            </tr>
            <tr>
                <td align="right">CET Percentile</td>
                <td><asp:Label id="lblCETPercentile" runat="server" Font-Bold = "true"></asp:Label></td> 
            </tr>
            <tr>
		        <td colspan="2"><font color = "red"><b>Result Published On : 10/03/2020</b></font></td>
	        </tr>
            <tr>
                <td colspan="2">
                    <p align="justify"><b>Disclaimer : </b>Neither State CET Cell nor Government of Maharashtra State is responsilbe for any inadvertent error that may have crept in the results being published on NET. The results published on NET are for immediate information to the examinees.</p>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <input id="btnPrint" type="button" value="  Print  " class="InputButton" onclick="Printit()" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>

