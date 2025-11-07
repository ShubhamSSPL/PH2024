<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmSpecialReservationDetails.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmSpecialReservationDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
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
    <style>
        #rightContainer_ContentTable1_ddlDefenceType{
            margin-top:10px;
        }
    </style>
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
                        <th colspan = "2" align = "left"><asp:Label ID="lblPWDHeader" runat="server">PWD and Defence Details</asp:Label></th>
                    </tr>
                    <tr>
                        <td style="width: 42%;" align="right">
                            Person with Disability<br />अपंग / दिव्यांग प्रकार निवडा

                        </td>
                        <td style="width: 58%;">
                            <asp:DropDownList ID="ddlPHType" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlPHType_SelectedIndexChanged"></asp:DropDownList>
                            <br /><font color="red"><asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></font>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Is Parent a Defence Personnel<br />पालक संरक्षण सेवेत असल्यास पर्याय निवडा

                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDefenceType" Width="100%" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlDefenceType_SelectedIndexChanged"></asp:DropDownList>
                            <br />
                            <asp:HyperLink ID="h1DefenceProformaC" runat="server" Visible="false" NavigateUrl="~/SampleDocuments/ProformaC.pdf" Target="_blank" Text="Click here for required format of Proforma – C"></asp:HyperLink><br />
                            <asp:HyperLink ID="h1DefenceProformaDorE" runat="server" Visible="false" NavigateUrl="~/SampleDocuments/ProformaDorE.pdf" Target="_blank" Text="Click here for required format of Proforma – D/E"></asp:HyperLink>
                            
                        </td>
                    </tr>
                     <tr>
                        <td align="right">
                            Your Annual Family Income<br /> कौटुंबिक वार्षिक उत्पन्न

                        </td>
                        <td>
                            <asp:Label ID="lblAnnualFamilyIncome" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">
                            Do you want to Apply for TFWS (Tuition Fee Waiver Scheme) Seats ? <br />तुम्हाला टीएफडब्ल्यूएस (शिक्षण शुल्क माफी योजना) जागांसाठी अर्ज करायचा आहे काय?

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
                        <th colspan="2" align="left">
                            Orphan Details
                        </th>
                    </tr>
                    <tr>
                        <td align="right">
                            Are You Orphan ?<br />तुम्ही अनाथ आहात का?

                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIsOrphan" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlIsOrphan_SelectedIndexChanged" onmouseover="ddrivetip('Please Select Orphan Status.')" onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvIsOrphan" runat="server" ControlToValidate="ddlIsOrphan" Display="None" ErrorMessage="Please Select Orphan Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                            <asp:HyperLink ID="h1OrphanProformaU" runat="server" Visible="false" NavigateUrl="~/SampleDocuments/ProformaU.pdf" Target="_blank" Text="Click here for required format of Proforma – U"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr id="trOrphan1" runat="server">
                        <td align="right">
                            Orphan Registration No
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrphanRegistrationNo" runat="server"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvOrphanRegistrationNo" runat="server" ErrorMessage="Please Enter Orphan Registration No." ControlToValidate="txtOrphanRegistrationNo" Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trOrphan2" runat="server">
                        <td align="right">
                            Do You have Any Relative ?
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOrphanHasRelative" runat="Server">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvOrphanHasRelative" runat="server" ControlToValidate="ddlOrphanHasRelative" Display="None" ErrorMessage="Please Select Orphan Relative Status." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trMinorityHeader" runat="server">
                        <th colspan = "2" align = "left">Minority Details</th>
                    </tr>
                    <tr id="trMinority" runat="server">
                        <td align="right">
                            Do You Belongs to Minority Candidature Type ?<br />आपण अल्पसंख्याक प्रवर्गात मोडत आहात का?

                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAppliedForMinoritySeats" runat="Server" AutoPostBack="true" OnSelectedIndexChanged="ddlAppliedForMinoritySeats_SelectedIndexChanged">
                                <asp:ListItem Value="Not Applicable">-- Select --</asp:ListItem>
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList><font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvAppliedForMinoritySeats" runat="server" ControlToValidate="ddlAppliedForMinoritySeats" Display="None" ErrorMessage="Please Select Apply for Minority Seats Status." Operator="NotEqual" ValueToCompare="Not Applicable"></asp:CompareValidator>
                            <asp:HyperLink ID="hlMinorityProformaOGR" runat="server" Visible="false" NavigateUrl="~/SampleDocuments/ProformaOGR.pdf" Target="_blank" Text="Click here for Proforma - O GR "></asp:HyperLink>
                            <br />
                            <asp:HyperLink ID="hlMinorityProformaInstruction" runat="server" Visible="false" NavigateUrl="~/SampleDocuments/ProformaO.pdf" Target="_blank" Text="If your Minority Details are not mentioned on your LC/TC Click here for required format of Proforma O."></asp:HyperLink>
                        </td>
                    </tr>
                    <tr id="trMinorityStatus" runat="server">
                        <td align="right">
                            Your Minority Status<br />आपली अल्पसंख्याक स्थिती

                        </td>
                        <td>
                            <asp:CheckBox ID="chkLinguisticMinority" runat="server" Text="&nbsp;&nbsp;Linguistic Minority" GroupName="MinorityStatus" AutoPostBack="True" OnCheckedChanged="LinguisticMinorityStatus_CheckedChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            <asp:CheckBox ID="chkReligiousMinority" runat="server" Text="&nbsp;&nbsp;Religious Minority" GroupName="MinorityStatus" AutoPostBack="True" OnCheckedChanged="ReligiousMinorityStatus_CheckedChanged" />
                            <asp:CustomValidator ID="cvMinorityStatus" runat="server" ClientValidationFunction="checkMinorityStatus" Display="None" ErrorMessage="Please Select Your Minority Status."></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr id="trMotherTongue" runat="server">
                        <td align="right">
                            Your Mother Tongue<br />आपली मातृभाषा

                        </td>
                        <td>
                            <asp:Label ID="lblMotherTongue" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trLinguisticMinority" runat="server">
                        <td align="right">
                            Linguistic Minority Type भाषीक अल्पसंख्याक     
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLinguisticMinority" Width="90%" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvLinguisticMinority" runat="server" ControlToValidate="ddlLinguisticMinority" Display="None" ErrorMessage="Please Select Linguistic Minority Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                            <asp:Label ID="lblLinguisticMinority" runat="server" ForeColor = "red" Font-Bold ="true" Visible = "false">You are Not Eligible for Linguistic Minority because Your Mother Tongue is Marathi. </asp:Label>
                        </td>
                    </tr>
                    <tr id="trReligion" runat="server">
                        <td align="right">
                            Your Religion<br />आपला धर्म

                        </td>
                        <td>
                            <asp:Label ID="lblReligion" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trReligiousMinority" runat="server">
                        <td align="right">
                            Religious Minority Type धार्मिक अल्पसंख्याक
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReligiousMinority" Width="90%" runat="server"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvReligiousMinority" runat="server" ControlToValidate="ddlReligiousMinority" Display="None" ErrorMessage="Please Select Religious Minority Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                            <asp:Label ID="lblReligiousMinority" runat="server" ForeColor = "red" Font-Bold ="true" Visible = "false">You are Not Eligible for Religious Minority because Your Religion is Hindu.</asp:Label>
                        </td>
                    </tr>
                </table>
                <table class="AppFormTable">
                    <tr runat="server" id="trInstruction1">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Certificate of Disability from the Director, All India Institute of Physically Handicapped, Mumbai or Dean / Civil Surgeon of the Government / Civil Hospitals.</font></p>
                            <asp:HyperLink ID="h1disabilityProforma" runat="server" NavigateUrl="~/SampleDocuments/Proformadisability.pdf" Target="_blank" Text="Click here for required format of Certificate of Disability"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction3">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Defence Service Certificate in the Proforma - C.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction4">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Domicile Certificate of Father / Mother who is an Ex-Service Personnel is Domiciled in Maharashtra.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction5">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Domicile Certificate of Father / Mother who is an Active Defence Service Personnel is Domiciled in Maharashtra.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction6">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Defence Service Certificate in the Proforma - C and D/E .</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction7">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Income Certificate of Parents issued by competent authoirty of Govt. Of Maharashtra having Annual Income below Rs. 8 Lacs Valid till 31st March <%=NextYear%>.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction2">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Orphan Certificate / Proforma - U.</font></p>
                        </td>
                    </tr>
                    <tr runat="server" id="trInstruction8">
                        <td style="border-top-width: 0px;">
                            <p align="justify"><font color="red">You are required to Upload Declaration of the Candidate for the respective Linguistic / Religious Minority Community in Proforma - O <b>OR</b> School Leaving Certificate having information pertaining to Religion / Mother tongue .</font></p>
                            
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
