<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmUploadCVCNCLCertificate.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmUploadCVCNCLCertificate" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="https://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="
        crossorigin="anonymous"></script>
    <script>

        $(document).ready(function () {

            $('#ctl00_rightContainer_ContentTable2_flUpload').change(function () {
                var x = document.getElementById("ctl00_rightContainer_ContentTable2_flUpload");

                var blnValid = false;
                var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".pdf", ".png"];
                var sFileName = x.value;
                for (var j = 0; j < _validFileExtensions.length; j++) {
                    var sCurExtension = _validFileExtensions[j];
                    if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                        blnValid = true;
                        break;
                    }
                }

                if (!blnValid) {
                    alert("Sorry, selected file is invalid, allowed extensions are: " + _validFileExtensions.join(", "));
                    document.getElementById("ctl00_rightContainer_ContentTable2_btnSubmite").style.display = "none";
                    x.value = "";
                    document.getElementById("thumimg").src = "";
                    return false;
                }

                else {
                    var KB = 0;
                    var fs = x.files.item(0).size;
                    KB = (fs / 1024).toFixed(2);
                    if (parseFloat(KB) < 200) {

                        document.getElementById("ctl00_rightContainer_ContentTable2_btnSubmite").style.display = "block";

                        var files = !!this.files ? this.files : [];
                        var reader = new FileReader(); // instance of the FileReader
                        reader.readAsDataURL(files[0]); // read the local file

                        reader.onload = function (e) {
                            document.getElementById("thumimg").src = e.target.result;
                        };
                        // read the image file as a data URL.
                        reader.readAsDataURL(this.files[0]);

                        document.getElementById("ctl00_rightContainer_ContentTable2_flUpload").innerHTML = x.value;
                        {
                            $('#thumimg').attr('src', Image_file);
                        };
                    }
                    else {
                        alert("Sorry, selected file must be less than 200KB");
                        document.getElementById("ctl00_rightContainer_ContentTable2_btnSubmite").style.display = "none";
                        x.value = "";
                        document.getElementById("thumimg").src = "";
                        return false;
                    }
                }
            });
        })
    </script>

    <table class="AppFormTable" style="background-color: #e7fafe;">
        <tr>
            <th colspan="4" align="left">Personal Information
            </th>
        </tr>
        <tr>
            <td style="width: 20%" align="right">Application ID
            </td>
            <td style="width: 30%">
                <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td style="width: 20%" align="right">Candidate Name
            </td>
            <td style="width: 30%">
                <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Gender
            </td>
            <td>
                <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Date of Birth
            </td>
            <td>
                <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Candidature Type
            </td>
            <td>
                <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Home University
            </td>
            <td>
                <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Category for Admission
            </td>
            <td>
                <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Person with Disability
            </td>
            <td>
                <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Applied for EWS
            </td>
            <td>
                <asp:Label ID="lblAppliedforEWS" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Applied for Orphan
            </td>
            <td>
                <asp:Label ID="lblAppliedforOrphan" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Defence Type
            </td>
            <td colspan="3">
                <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <%--<td align="right">
                    Applied for TFWS
                </td>
                <td>
                    <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label>
                </td>--%>
        </tr>
        <tr>
            <td align="right">Minority Candidature Type
            </td>
            <td colspan="3">
                <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>

    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Upload CVC TVC Certificate"
        Visible="False">
        <br />
        <table class="AppFormTable">
            <tr>
                <td colspan="2">
                    <ol class="list-text">
                        <b>Important Instructions for :</b>
                        <li>If the candidate has already uploaded the Receipt at SC, Upload the Caste /Tribe
                            Validity Certificate issued by the Scrutiny Committe and Issue the Acknowledgement
                            to the canddiate. </li>
                        <li>If the candidate fails to submit the Caste /Tribe Validity Certificate on or before
                            15/7/2019 , candidate convert to Open Category. </li>
                    </ol>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnYes" runat="server" Text="Upload CVC / TVC" CssClass="InputButton"
                        OnClick="btnYes_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="btnNo" runat="server" Text="Convert to Open" CssClass="InputButton"
                        OnClick="btnNo_Click" Visible="false" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Upload CVC TVC Certificate"
        Visible="False">
        <table class="AppFormTable">
            <tr>
                <td colspan="2">
                    <ol class="list-text">
                        <b>Important Instructions :</b>
                        <li>If the candidate has already uploaded the Receipt at SC, Upload the Caste / Tribe Validity Certificate issued by the Scrutiny Committe and Issue the fresh Acknowledgement of Application form to the candidate. </li>
                        <li>2.	If the candidate could not  to submit the Caste / Tribe Validity Certificate on or before 15/7/2019 , candidate convert to Open Category. </li>
                    </ol>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;
                </td>
            </tr>
            <%-- <tr id="trdocument" runat="server">
                        <td align="right">
                            Select Document To Be Upload 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDocumentID" runat="server" onmouseover="ddrivetip('Please Select Document To Be Upload.')"
                                onmouseout="hideddrivetip()">                           
                               
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="revDocumentID" runat="server" ControlToValidate="ddlDocumentID"
                                ErrorMessage="Please Select Document To Be Upload." InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
            <tr>
                <td colspan="2" style="text-align: center">
                    <span id="msg" style="display: none"></span>
                </td>
            </tr>
            <tr runat="server" id="trFileUpload">
                <td style="width: 25%;" align="right">Select Document
                </td>
                <td style="width: 50%; vertical-align: top;">
                    <asp:FileUpload runat="server" ID="flUpload" />
                    <img style="max-width: 80px" src="" class="" id="thumimg" alt="">
                </td>
            </tr>
            <%--<asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label>--%>
            <%--    <asp:HiddenField runat="server" ID="lblCandidateName" />--%>
            <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSubmite" runat="server" Text="Submit" CssClass="InputButton" OnClick="btnSubmite_Click" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Convert to Open Not having CVC TVC Certificate"
        Visible="False">
        <br />
        <table class="AppFormTable">
            <tr>
                <td colspan="2">
                    <ol class="list-text">
                        <b>Important Instructions for :</b>
                        <li>Allotment of Candidate will be cancelled and candidate will convert to OPEN Category. Eligible for Next Round.</li>
                    </ol>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnConvertToOpen" runat="server" Text="Process to Convert to OPEN"
                        CssClass="InputButton" OnClick="btnConvertToOpen_Click" />
                </td>
                <%-- <td align="center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" OnClick="btnCancel_Click" />
                </td>--%>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox3" runat="server" HeaderText="Pay Application Form Fee Difference"
        Visible="False">
        <br />
        <table class="AppFormTable">
            <tr>
                <td colspan="2">
                    <ol class="list-text">
                        <b>Important Instructions for :</b>
                        <li>Candidate category converted to Open collect the Difference Application Form Fee
                            .</li>
                        <li>Candidate is Eligible for Next Round on the basis of Open Category.</li>
                    </ol>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnPayApplictionFormFee" runat="server" Text="Pay Application Form Fee Difference"
                        CssClass="InputButton" OnClick="btnPayApplictionFormFee_Click" />
                </td>
                <%-- <td align="center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" OnClick="btnCancel_Click" />
                </td>--%>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>

</asp:Content>
