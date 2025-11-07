<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditSpecialReservationDetails.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEditSpecialReservationDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function checkMinorityStatus(sender, args) {
            if (document.getElementById("rightContainer_ContentTable1_chkLinguisticMinority").checked || document.getElementById("rightContainer_ContentTable1_chkReligiousMinority").checked) {
            }
            else {
                args.IsValid = false;
            }
        }
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%" align="right">Application ID</td>
                <td style="width: 50%">
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate's Name</td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Special Reservation Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upSpecialReservation">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <th colspan="2" align="left">
                            <asp:Label ID="lblPWDHeader" runat="server">PWD and Defence Details</asp:Label></th>
                    </tr>
                    <tr>
                        <td style="width: 50%;" align="right">Person with Disability
                        </td>
                        <td style="width: 50%;">
                            <asp:DropDownList ID="ddlPHType" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlPHType_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red">
                                <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></font>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Is Parent a Defence Personnel
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDefenceType" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlDefenceType_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                      <tr>
                        <td align="right">
                            Your Annual Family Income
                        </td>
                        <td>
                            <asp:Label ID="lblAnnualFamilyIncome" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Do you want to Apply for TFWS (Tuition Fee Waiver Scheme) Seats ?
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAppliedForTFWS" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlAppliedForTFWS_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList><font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvAppliedForTFWS" runat="server" ControlToValidate="ddlAppliedForTFWS" Display="None" ErrorMessage="Please Select Apply for TFWS Seats Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                            <asp:Label ID="lblAppliedForTFWS" runat="server" ForeColor="red" Font-Bold="true" Visible="false">As your Parents having Annual Income above 8 Lacs.</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="2" align="left">Orphan Details
                        </th>
                    </tr>
                    <tr>
                        <td align="right">Are You Orphan ?
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIsOrphan" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlIsOrphan_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Orphan Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvIsOrphan" runat="server" ControlToValidate="ddlIsOrphan" Display="None" ErrorMessage="Please Select Orphan Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trMinorityHeader" runat="server">
                        <th colspan="2" align="left">Minority Details</th>
                    </tr>
                    <tr id="trMinority" runat="server">
                        <td align="right">Do You Belongs to Minority Candidature Type ?
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAppliedForMinoritySeats" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlAppliedForMinoritySeats_SelectedIndexChanged">
                                <asp:ListItem Value="Not Applicable">-- Select --</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList><font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvAppliedForMinoritySeats" runat="server" ControlToValidate="ddlAppliedForMinoritySeats" Display="None" ErrorMessage="Please Select Apply for Minority Seats Status." Operator="NotEqual" ValueToCompare="Not Applicable"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trMinorityStatus" runat="server">
                        <td align="right">Your Minority Status
                        </td>
                        <td>
                            <asp:CheckBox ID="chkLinguisticMinority" runat="server" Text="&nbsp;&nbsp;Linguistic Minority" GroupName="MinorityStatus" AutoPostBack="True" OnCheckedChanged="LinguisticMinorityStatus_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkReligiousMinority" runat="server" Text="&nbsp;&nbsp;Religious Minority" GroupName="MinorityStatus" AutoPostBack="True" OnCheckedChanged="ReligiousMinorityStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvMinorityStatus" runat="server" ClientValidationFunction="checkMinorityStatus" Display="None" ErrorMessage="Please Select Your Minority Status."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id="trMotherTongue" runat="server">
                        <td align="right">Your Mother Tongue
                        </td>
                        <td>
                            <asp:Label ID="lblMotherTongue" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trLinguisticMinority" runat="server">
                        <td align="right">Linguistic Minority Type
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLinguisticMinority" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvLinguisticMinority" runat="server" ControlToValidate="ddlLinguisticMinority" Display="None" ErrorMessage="Please Select Linguistic Minority Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                            <asp:Label ID="lblLinguisticMinority" runat="server" ForeColor="red" Font-Bold="true" Visible="false">You are Not Eligible for Linguistic Minority because Your Mother Tongue is Marathi. </asp:Label>
                        </td>
                    </tr>
                    <tr id="trReligion" runat="server">
                        <td align="right">Your Religion
                        </td>
                        <td>
                            <asp:Label ID="lblReligion" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trReligiousMinority" runat="server">
                        <td align="right">Religious Minority Type
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReligiousMinority" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvReligiousMinority" runat="server" ControlToValidate="ddlReligiousMinority" Display="None" ErrorMessage="Please Select Religious Minority Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                            <asp:Label ID="lblReligiousMinority" runat="server" ForeColor="red" Font-Bold="true" Visible="false">You are Not Eligible for Religious Minority because Your Religion is Hindu.</asp:Label>
                        </td>
                    </tr>
                </table>
                <table class="AppFormTable">
                    <tr runat="server" id="trInstruction1">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to submit Certificate of Disability from the Director, All India Institute of Physically Handicapped, Mumbai or Dean / Civil Surgeon of the Government / Civil Hospitals. at the time of Document Verification at SC.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction3">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to submit Defence Service Certificate in the Proforma - C at the time of Document Verification at SC.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction4">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to submit Domicile Certificate of Father / Mother who is an Ex-Service Personnel is Domiciled in Maharashtra at the time of Document Verification at SC.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction5">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to submit Domicile Certificate of Father / Mother who is an Active Defence Service Personnel is Domiciled in Maharashtra. at the time of Document Verification at SC.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction6">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to submit Defence Service Certificate in the Proforma - C and D/E at the time of Document Verification at SC.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction7">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to submit Income Certificate of Parents issued by competent authoirty of Govt. Of Maharashtra having Annual Income below Rs. 8 Lacs at the time of Document Verification at SC.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction2">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to submit Orphan Certificate / Proforma - U at the time of Document Verification at SC.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction8">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to submit Declaration of the Candidate for the respective Linguistic / Religious Minority Community in Proforma - O <b>OR</b> School Leaving Certificate having information pertaining to Religion / Mother tongue at the time of Document Verification at SC.</font></p>
                            <asp:HyperLink ID="hlMinorityProformaOGR" runat="server" NavigateUrl="~/SampleDocuments/ProformaOGR.pdf" Target="_blank" Text="Click here for Proforma - O GR "></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
