<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmApplicationFees.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmApplicationFees" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type = "text/javascript">
        function Printit() {
            document.getElementById("topdiv").style.display = 'none';
           /* document.getElementById("left1").style.display = 'none';*/
            document.getElementById("footer1").style.display = 'none';
            document.getElementById("btnPrint").style.display = 'none';
            document.getElementById("rightContainer_cbDisplayApplicationFee_btnBack").style.display = 'none';
            document.getElementById("rightContainer1").style.width = '900px';

            window.print();

            document.getElementById("topdiv").style.display = 'none';
            /*document.getElementById("left1").style.display = 'none';*/
            document.getElementById("footer1").style.display = '';
            document.getElementById("btnPrint").style.display = '';
            document.getElementById("rightContainer_cbDisplayApplicationFee_btnBack").style.display = '';
            document.getElementById("rightContainer1").style.width = '79.7%';
        }
    </script>
    <asp:UpdateProgress runat="server" id="PageUpdateProgress">
        <ProgressTemplate>
            <img src ="../Images/BigProgress.gif" alt = "" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upQualification">
        <ContentTemplate>
            <cc1:ContentBox ID="cbCalculateApplicationFee" runat="server" HeaderText="Calculate Your Application Fee">
		        <table class="AppFormTable">
                    <tr>
                        <td style = "width:50%;" align = "right">Select Candidature Type</td>
                        <td style = "width:50%;">
                            <asp:DropDownList ID="ddlCandidatureType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCandidatureType_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Candidature Type.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                            <font color = "red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCandidatureType" runat="server" ControlToValidate="ddlCandidatureType" Display="None" ErrorMessage="Please Select Candidature Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
			        <tr runat = "server" id = "trCategory">
                        <td align = "right">Select Category</td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server" 
                                onmouseover="ddrivetip('Please Select Category.')" onmouseout="hideddrivetip()" 
                                onselectedindexchanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <font color = "red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvCategory" runat="server" ControlToValidate="ddlCategory" Display="None" ErrorMessage="Please Select Category." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trAppliedForEWS2" runat="server" visible="false">
                        <td align="right">Do you belong to EWS (Economically Weaker Section)?</td>
                        <td>
                            <asp:DropDownList id="ddlAppliedForEWS" Runat="Server" AutoPostBack="true"  onmouseover="ddrivetip('Please Select EWS Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
	                            <asp:ListItem Value="No">No</asp:ListItem>
	                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvAppliedForEWS" runat="server" ControlToValidate="ddlAppliedForEWS" Display="None" ErrorMessage="Please Select EWS Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr runat = "server" id = "trPH">
                        <td align="right">Person with Disability</td>
                        <td style = "width:70%;"><asp:DropDownList id="ddlPHType" Runat="Server" onmouseover="ddrivetip('Please Select Person with Disability.')" onmouseout="hideddrivetip()"></asp:DropDownList></td>
                    </tr>                                        
                </table>
                <br />
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnProceed" runat="server" Text="Calculate Application Fee" CssClass="InputButton" OnClick="btnProceed_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                        </td>
                    </tr>
                </table>
                <br />
            </cc1:ContentBox>
            <cc1:ContentBox ID="cbDisplayApplicationFee" runat="server" HeaderText="Your Application Fee Details">
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="<<< Back" CssClass="InputButton" OnClick="btnBack_Click"  />
                        </td>
                    </tr>
                </table>
                <br />
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 50%" align="right">Candidature Type</td>
                        <td style="width: 50%"><asp:Label ID="lblCandidatureType" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Category</td>
                        <td><asp:Label ID="lblCategory" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Person with Disability</td>
                        <td><asp:Label ID="lblPHType" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Application Fee (<span class="rupee">Rs.</span>)</td>
                        <td><asp:Label ID="lblApplicationFee" runat="server" Font-Bold = "true"></asp:Label></td>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
