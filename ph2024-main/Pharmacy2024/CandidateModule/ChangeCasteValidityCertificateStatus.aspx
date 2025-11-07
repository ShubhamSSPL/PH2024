<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="ChangeCasteValidityCertificateStatus.aspx.cs" Inherits="Pharmacy2024.CandidateModule.ChangeCasteValidityCertificateStatus" %>
 
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
 <script src="https://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
    <script>
        
        $(document).ready(function () {

            $('#rightContainer_ContentTable2_flUpload').change(function () {
                var x = document.getElementById("rightContainer_ContentTable2_flUpload");

                var blnValid = false;
                var _validFileExtensions = [".jpg", ".jpeg",  ".pdf", ".png"];
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
                    document.getElementById("rightContainer_ContentTable2_btnSubmite").style.display = "none";
                    x.value = "";
                    document.getElementById("thumimg").src = "";
                    return false;
                }

                else {
                    var KB = 0;
                    var fs = x.files.item(0).size;
                    KB = (fs / 1024).toFixed(2);
                    if (parseFloat(KB) < 500) {

                        document.getElementById("rightContainer_ContentTable2_btnSubmite").style.display = "block";

                        var files = !!this.files ? this.files : [];
                        var reader = new FileReader(); // instance of the FileReader
                        reader.readAsDataURL(files[0]); // read the local file

                        reader.onload = function (e) {
                            document.getElementById("thumimg").src = e.target.result;
                        };
                        // read the image file as a data URL.
                        reader.readAsDataURL(this.files[0]);

                        document.getElementById("rightContainer_ContentTable2_flUpload").innerHTML = x.value;
                        {
                            $('#thumimg').attr('src', Image_file);
                        };
                    }
                    else {
                        alert("Sorry, selected file must be less than 200KB");
                        document.getElementById("rightContainer_ContentTable2_btnSubmite").style.display = "none";
                        x.value = "";
                        document.getElementById("thumimg").src = "";
                        return false;
                    }
                }
            });
        })

        function showRows() {
            if (document.getElementById("rightContainer_ContentTable2_ddlCasteValidityStatus").value == "A") {
                document.getElementById("tr1").style.display = "table-row";
                document.getElementById("tr3").style.display = "table-row";
                document.getElementById("tr2").style.display = "table-row";
                document.getElementById("tr4").style.display = "table-row";
                document.getElementById("tr5").style.display = "table-row";
                document.getElementById("tr6").style.display = "table-row";
                document.getElementById("msg").style.display = "block";
                document.getElementById("msg").innerHTML = "<b>Please Upload Caste Validity Certificate Application Receipt</b>";
            }
            else {
                document.getElementById("tr1").style.display = "none";
                document.getElementById("tr2").style.display = "none";
                document.getElementById("tr3").style.display = "none";
                document.getElementById("tr4").style.display = "none";
                document.getElementById("tr5").style.display = "none";
                document.getElementById("tr6").style.display = "none";

            }
            if (document.getElementById("rightContainer_ContentTable2_ddlCasteValidityStatus").value == "R") {
                document.getElementById("msg").style.display = "block";
                document.getElementById("msg").innerHTML = "<b>Please Upload Caste Validity Certificate</b>";
            }
        }
        function checkDocsInfo() {
            if (document.getElementById("rightContainer_ContentTable2_ddlCasteValidityStatus").value == "A") {
                if (document.getElementById("rightContainer_ContentTable2_txtCVCApplicationNo").value == "") {
                    alert("Caste / Tribe Validity Certificate Application Number is Required");
                    document.getElementById("rightContainer_ContentTable2_txtCVCApplicationNo").focus();
                    return false;
                }
                else if (document.getElementById("rightContainer_ContentTable2_txtAppDate").value == "") {
                    alert("Caste / Tribe Validity Certificate Application Date is Required");
                    document.getElementById("rightContainer_ContentTable2_txtAppDate").focus();
                    return false;
                }
                else if (document.getElementById("rightContainer_ContentTable2_txtCVCAuthority").value == "") {
                    alert("Caste / Tribe Validity Certificate Issuing Authority Name is Required");
                    document.getElementById("rightContainer_ContentTable2_txtCVCAuthority").focus();
                    return false;
                }
                else if (document.getElementById("rightContainer_ContentTable2_ddlCVCDistrict").value == "0") {
                    alert("Caste / Tribe Validity Certificate Issuing District");
                    document.getElementById("rightContainer_ContentTable2_ddlCVCDistrict").focus();
                    return false;
                }
                else if (document.getElementById("rightContainer_ContentTable2_txtCVCName").value == "") {
                    alert("Name as Per Caste / Tribe Validity Certificate is Required");
                    document.getElementById("rightContainer_ContentTable2_txtCVCName").focus();
                    return false;
                }
                else if (document.getElementById("rightContainer_ContentTable2_txtCCNumber").value == "") {
                    alert("Caste Certificate Number is Required");
                    document.getElementById("rightContainer_ContentTable2_txtCCNumber").focus();
                    return false;
                }
            }
            return true;
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Change Caste Validity Certificate Status">
       
                <table class="AppFormTable" style="display:none;">
                    <tr >
                        <td colspan="2">
                            <ol class="list-text">
                                <b>Important Instructions for :</b>
                                <li>You are required to submit the Caste / Tribe Validity Certificate or Receipt of Application in the name of
                                    the Candidate, issued by the caste validity committee of Maharashtra State at the
                                    time of Document Verification at SC. </li>
                            </ol>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%;" align="right">
                            Caste / Tribe Validity Status(As Per Registration)
                        </td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblOldStatus" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Select Caste / Tribe Validity Certificate Status
                        </td>
                        <td>
                            <asp:DropDownList onchange="showRows();" ID="ddlCasteValidityStatus" runat="server" onmouseover="ddrivetip('Please Select Caste / Tribe Validity Certificate Status.')"
                                onmouseout="hideddrivetip()">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="R">Available</asp:ListItem>
                                <asp:ListItem Value="A">Applied and Not Received</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="revCasteValidityStatus" runat="server" ControlToValidate="ddlCasteValidityStatus"
                                ErrorMessage="Please Select Caste / Tribe Validity Certificate Status." InitialValue="0"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" style="text-align:center">
                           <span id="msg" style="display:none"></span>
                        </td>
                    </tr>

                     <tr id="tr1"  style="display:none">
                        <td style="width: 50%;" align="right">
                            Caste / Tribe Validity Certificate Application Number
                        </td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="txtCVCApplicationNo" runat="server"></asp:TextBox>&nbsp;<font color="red"><sup>*</sup></font>
                        </td>
                    </tr>

                     <tr id="tr2" style="display:none">
                        <td style="width: 50%;" align="right">
                            Caste / Tribe Validity Certificate Application Date
                        </td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="txtAppDate" runat="server"></asp:TextBox>&nbsp;<font color="red"><sup>*</sup></font>
                        </td>
                    </tr>

                     <tr id="tr3" style="display:none">
                        <td style="width: 50%;" align="right">
                            Caste / Tribe Validity Certificate Issuing Authority Name
                        </td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="txtCVCAuthority" runat="server"></asp:TextBox>&nbsp;<font color="red"><sup>*</sup></font>
                        </td>
                    </tr >
                      <tr id="tr6" style="display:none">
                        <td align="right">
                            Caste / Tribe Validity Certificate Issuing District
                        </td>
                        <td>
                            <asp:DropDownList id="ddlCVCDistrict" Runat="server"></asp:DropDownList>
	                        <font color = "red"><sup>*</sup></font>
	                        <asp:CompareValidator id="cvCVCDistrict" Runat="server" Display="None" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlCVCDistrict" ErrorMessage="Please Select Caste / Tribe Validity Certificate Issuing District."></asp:CompareValidator>
                        </td>
                    </tr>

                     <tr id="tr4" style="display:none">
                        <td style="width: 50%;" align="right">
                            Name as Per Caste / Tribe Validity Certificate
                        </td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="txtCVCName" runat="server"></asp:TextBox>&nbsp;<font color="red"><sup>*</sup></font>
                        </td>
                    </tr>

                    <tr id="tr5" style="display:none">
                        <td style="width: 50%;" align="right">
                            Caste Certificate Number
                        </td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="txtCCNumber" runat="server"></asp:TextBox>&nbsp;<font color="red"><sup>*</sup></font>
                        </td>
                    </tr>




                    <tr runat="server" id="trFileUpload">
                        <td style="width: 25%;" align="right">
                            Select Document
                        </td>
                        <td style="width: 50%; vertical-align:top;">
                           <asp:FileUpload runat="server" ID="flUpload" />
                            
                            <img style="max-width: 80px" src="" class="" id="thumimg" alt="">
                        </td>
                    </tr>
                     <%--<asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label>--%>
                     <asp:HiddenField runat="server" ID="lblCandidateName" />
                     <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
                </table>
                <br />
                <table class="AppFormTable" style="display:none;">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSubmite" OnClientClick="return checkDocsInfo();" runat="server" Text="Submit" CssClass="InputButton" OnClick="btnSubmite_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <table class="AppFormTable" id="tblReqDetails" runat="server">
                <tr >
                        <td colspan="2">
                            <ol class="list-text">
                                <b>Request Details</b>
                                <li>Your submitted details of the Caste / Tribe Validity Certificate or Receipt of Application</li>
                            </ol>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Caste / Tribe Validity Certificate Status
                        </td>
                        <td>
                            <asp:Label ID="lblCVS" Font-Bold="true" runat="server"></asp:Label>
                        </td>
                    </tr>


                      <tr id="tr7" runat="server" visible="false">
                        <td style="width: 50%;" align="right">
                            Caste / Tribe Validity Certificate Application Number
                        </td>
                        <td style="width: 50%;">
                             <asp:Label ID="lblCVCApplicationNo" runat="server"></asp:Label>
                        </td>
                    </tr>

                     <tr id="tr8" runat="server" visible="false">
                        <td style="width: 50%;" align="right">
                            Caste / Tribe Validity Certificate Application Date
                        </td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblCVCApplicationDate" runat="server"></asp:Label>
                        </td>
                    </tr>

                     <tr id="tr9" runat="server" visible="false">
                        <td style="width: 50%;" align="right">
                            Caste / Tribe Validity Certificate Issuing Authority Name
                        </td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblCVCAuthority" runat="server"></asp:Label>
                        </td>
                    </tr >
                      <tr id="tr10" runat="server" visible="false">
                        <td align="right">
                            Caste / Tribe Validity Certificate Issuing District
                        </td>
                        <td>
                           <asp:Label ID="lblCVCDistrict" runat="server"></asp:Label>
                        </td>
                    </tr>

                     <tr id="tr11" runat="server" visible="false">
                        <td style="width: 50%;" align="right">
                            Name as Per Caste / Tribe Validity Certificate
                        </td>
                        <td style="width: 50%;">
                            <asp:Label ID="lblCVCName" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr id="tr12" runat="server" visible="false">
                        <td style="width: 50%;" align="right">
                            Caste Certificate Number
                        </td>
                        <td style="width: 50%;">
                           <asp:Label ID="lblCCNumber" runat="server"></asp:Label>
                        </td>
                    </tr>

                     <tr>
                        <td style="width: 50%;" align="right">
                            Request Status
                        </td>
                        <td style="width: 50%;">
                           <asp:Label ID="lblRStatus" Font-Bold="true" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>
        
    </cc1:ContentBox>
</asp:Content>

