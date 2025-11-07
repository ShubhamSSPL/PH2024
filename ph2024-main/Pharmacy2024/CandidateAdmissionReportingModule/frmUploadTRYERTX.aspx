<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="frmUploadTRYERTX.aspx.cs" Inherits="Pharmacy2024.CandidateAdmissionReportingModule.frmUploadTRYERTX" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .form-input {
            border: 1px solid #d9d9d9;
            font-size: 13px;
            height: 34px;
            padding: 4px;
            border-radius: 4px;
            color: #000000
        }

        .AppFormTable input {
            height: auto;
            padding: 4px;
        }
    </style>
    <style>
        * {
            margin: 0;
        }

        html, body {
            height: 100%;
        }

        .wrapper {
            width: 100% !important;
            height: auto !important;
            background-color: gray;
        }

        .push {
            height: 50px;
        }

        .tbl {
            display: table;
            width: 100%;
            /*            background-color: #c4a000;*/
            /*  background-color: #E9F7F9;*/
            background-color: #04a2b3
        }

        .full {
            width: 100%
        }

        .c20 {
            display: table-cell;
            padding: 15px;
            width: 20%;
            text-align: center;
        }

        .c50 {
            display: table-cell;
            padding: 15px;
            width: 50%;
            text-align: center;
        }

        button {
            border: 0px;
            width: 100%;
            min-height: 35px;
            cursor: pointer;
        }
    </style>


    <style>
        .pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .doc-container {
            width: 65.6rem;
            height: 25rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .InnerBodyDiv {
            height: auto !important;
        }

        #rightContainer_contentAppleSarkarBarti {
            width: 100% !important;
        }

        #rightContainer_contentViewDocument {
            top: 11% !important;
            width: 85% !important;
        }

        @media only screen and (max-width: 768px) {

            #rightContainer_contentViewDocument {
                top: 32% !important;
                width: 100% !important;
            }

            .doc-container {
                height: 16rem !important;
            }
        }

        @media only screen and (max-width: 1024px) {

            #rightContainer_contentViewDocument {
                top: 20% !important;
                width: 100% !important;
            }
        }
    </style>

    <style>
        .divopacity {
            width: 100%;
            height: 100%;
            position: absolute;
            z-index: 1000;
            background: #345678;
            opacity: 0.3;
            text-align: center;
        }
    </style>
    <script src="../Scripts/mcfCrop.js"></script>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript">jQuery.noConflict();</script>
    <script src="https://fengyuanchen.github.io/shared/google-analytics.js" crossorigin="anonymous"></script>
    <script type="text/javascript" src="../dist/main.js"></script>
    <script>
        $(document).ready(function () {
            //  initContainer("EWScropContainer", 80, 1000, 800, "../Images/", 500, cb);
            initContainer("cropContainer", 80, 1000, 800, "../Images/", 500, cb);
            function cb(data, fileName, fileExt) {
                //console.log(data);
                // alert(fileName + "." + fileExt);
                if (data.length > 7) {
                    if (document.getElementById('<%=hdnCurrentDocId.ClientID %>') != null) {
                        var documentID = $("#<%=hdnCurrentDocId.ClientID %>").get(0).value;
                    }
                    if (document.getElementById('<%=HiddenField1.ClientID %>') != null) {
                        var documentID = $("#<%=HiddenField1.ClientID %>").get(0).value;
                    }
                    if (documentID == "21") {
                        var ddlDistrict = document.getElementById("<%=ddlDistrict.ClientID %>");
                        var ddlJuridiction = document.getElementById("<%=ddlJuridiction.ClientID %>");
                        var ddlTaluka = document.getElementById("<%=ddlTaluka.ClientID %>");
                        var hidJUD = ddlJuridiction.options[ddlJuridiction.selectedIndex].value
                        var hidDID = ddlDistrict.options[ddlDistrict.selectedIndex].value
                        var hidTID = ddlTaluka.options[ddlTaluka.selectedIndex].value
                        if (hidJUD == "0") {
                            alert("Select Issuing Authority");
                            return;
                        }
                        else if (hidDID == "0") {
                            alert("Select District");
                            return;
                        }
                        else if (hidTID == "0") {
                            alert("Select Taluka");
                            return;
                        }
                        else {
                            var message = Pharmacy2024.CandidateAdmissionReportingModule.frmUploadTRYERTX.UploadDoc(data, documentID, hidJUD, hidDID, hidTID, fileName, fileExt);
                            if (message.value == "The File has been uploaded.") {
                                $('#<%=btnUploadComplete.ClientID %>').show().click().hide();
                            }
                            else {
                                alert(message.error.Message);
                            }
                        }
                    }
                    else if (documentID == "22") {
                        var ddlDistrict = document.getElementById("<%=ddlDistrict.ClientID %>");
                        var ddlJuridiction = document.getElementById("<%=ddlJuridiction.ClientID %>");
                        var hidJUD = ddlJuridiction.options[ddlJuridiction.selectedIndex].value
                        var hidDID = ddlDistrict.options[ddlDistrict.selectedIndex].value
                        if (hidJUD == "0") {
                            alert("Select Issuing Authority");
                            return;
                        }
                        else if (hidDID == "0") {
                            alert("Select District");
                            return;
                        }
                        else {
                            var message = Pharmacy2024.CandidateAdmissionReportingModule.frmUploadTRYERTX.UploadDoc(data, documentID, hidJUD, hidDID, hidTID, fileName, fileExt);
                            if (message.value == "The File has been uploaded.") {
                                $('#<%=btnUploadComplete.ClientID %>').show();
                                $('#<%=btnUploadComplete.ClientID %>').click();
                                $('#<%=btnUploadComplete.ClientID %>').hide();
                            }
                            else {
                                alert(message.error.Message);
                            }
                        }
                    }
                    else {
                        var message = Pharmacy2024.CandidateAdmissionReportingModule.frmUploadTRYERTX.UploadDoc(data, documentID, hidJUD, hidDID, hidTID, fileName, fileExt);
                        if (message.value == "The File has been uploaded.") {
                            $('#<%=btnUploadComplete.ClientID %>').show().click();
                            //$('#<%=btnUploadComplete.ClientID %>').click();
                            $('#<%=btnUploadComplete.ClientID %>').hide();

                        }
                        else {
                            alert(message.error.Message);
                        }
                    }
                }
                else {
                    alert("Please Select File");
                }
            }
            $('#rightContainer_contentFileUpload_flUpload').change(function () {
                var x = document.getElementById("rightContainer_contentFileUpload_flUpload");
                var blnValid = false;
                var _validFileExtensions = [".jpg", ".jpeg", ".pdf", ".png"];
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
                    document.getElementById("rightContainer_contentFileUpload_btnSaveUpload").style.display = "none";
                    x.value = "";
                    document.getElementById("thumimg").src = "";

                    return false;
                }
                else {
                    var KB = 0;
                    var fs = x.files.item(0).size;
                    KB = (fs / 1024).toFixed(2);

                    if (parseFloat(KB) < 501) {
                        document.getElementById("rightContainer_contentFileUpload_btnSaveUpload").style.display = "block";

                        var files = !!this.files ? this.files : [];
                        var reader = new FileReader();
                        reader.readAsDataURL(files[0]);
                        reader.onload = function (e) {
                            document.getElementById("thumimg").src = e.target.result;
                        };
                        reader.readAsDataURL(this.files[0]);

                        document.getElementById("rightContainer_contentFileUpload_flUpload").innerHTML = x.value;
                        {
                            $('#thumimg').attr('src', Image_file);
                        };
                    }
                    else {
                        alert("Sorry, selected file must be less than 500KB");
                        document.getElementById("rightContainer_contentFileUpload_btnSaveUpload").style.display = "none";
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
            <td>
                <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Applied for TFWS
            </td>
            <td>
                <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Minority Candidature Type
            </td>
            <td colspan="3">
                <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
  

    <%--CVCTVC--%>

    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Upload CVC TVC / NCL Certificate"
        Visible="False">
        <br />
        <table class="AppFormTable">
           
            <tr>
                <td align="center">
                    <asp:Button ID="btnYes" runat="server" Text="Upload CVC / TVC / NCL" CssClass="InputButton"
                        OnClick="btnYes_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="btnNo" runat="server" Text="Convert to Open" CssClass="InputButton" Visible="false"
                        OnClick="btnNo_Click" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Upload CVC TVC Certificate"
        Visible="False">
        <table class="AppFormTable">
           
            <tr>
                <td colspan="2">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <span id="msg" style="display: none"></span>
                </td>
            </tr>
            <tr id="trDocUploadInstructionYes" runat="server" visible="true">
                <td colspan="2">
                    <asp:GridView ID="gvCVCNCL" runat="server" AutoGenerateColumns="False" CssClass="DataGrid" BorderWidth="1" OnRowCommand="gvCVCNCL_RowCommand" EnableModelValidation="True" Width="100%" OnRowDataBound="gvCVCNCL_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" ItemStyle-Wrap="true" HtmlEncode="False">
                                <ItemStyle Width="67%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UploadStatus" HeaderText="Upload Status">
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Upload">
                                <ItemTemplate>
                                    <asp:Image ID="btnUpload" runat="server" AlternateText="Upload" ImageUrl="~/Images/ic_file_upload_black_48dp_2x.png" onclick="return OpenTestPopup(this);" Style="cursor: pointer; color: #757575;" ToolTip="Upload" Visible='<%# Eval("FilePath").ToString()==""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                    <%--<img src="" id="imgDoc" Style="cursor: pointer; max-width: 40px" runat="server" />--%>
                                    <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" runat="server" onclick="javascript:OpenViewDocumentPopUp(this)" />
                                    <asp:HiddenField ID="hidFURL" runat="server" Value='<%# Bind("FilePath") %>' />
                                    <asp:HiddenField ID="hidDID" runat="server" Value='<%# Bind("DocumentTransID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btndelete" runat="server" CommandArgument='<%# Bind("DocumentId") %>' CommandName="D" ImageUrl="~/Images/icon-delete.png" ToolTip="Edit"
                                        OnClientClick="return confirm('Your previously uploaded document will be deleted and you will have to upload a fresh one. Do you want to continue?');"
                                        Visible='<%# Eval("FilePath").ToString()!=""?true:false %>' Style="height: 50px !important" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SC Verification Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsSubmittedAtAFC" runat="server" Text='<%# Eval("IsSubmittedAtAFC") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnDocId" runat="server" Value='<%# Bind("DocumentId") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnImgUrl" runat="server" Value='<%# Bind("FilePath") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <%-- <tr runat="server" id="trFileUpload">
                <td style="width: 25%;" align="right">Select Document
                </td>
                <td style="width: 50%; vertical-align: top;">
                    <asp:FileUpload runat="server" ID="flUpload" />
                    <img style="max-width: 80px" src="" class="" id="thumimg" alt="">
                </td>
            </tr>--%>
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
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Convert to Open Not having CVC TVC or NCL Certificate"
        Visible="False">
        <br />
        <table class="AppFormTable">
            
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

    <%--Diff Fee--%>
    <cc1:ContentBox ID="ContentBox3" runat="server" HeaderText="Pay Application Form Fee Difference"
        Visible="False">
        <br />
        <table class="AppFormTable">
            
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

    <%--NCL--%>
    <cc1:ContentBox ID="ContentBoxNCL" runat="server" HeaderText="Upload NCL Certificate"
        Visible="False">
        <br />
        <table class="AppFormTable">
            
            <tr>
                <td align="center">
                    <asp:Button ID="btnNCLYes" runat="server" Text="Upload NCL" CssClass="InputButton" OnClick="btnNCLYes_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="btnNCLNo" runat="server" Text="Convert to Open" CssClass="InputButton" OnClick="btnNCLNo_Click" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTableNCL" runat="server" HeaderText="Upload NCL Certificate"
        Visible="False">
        <table class="AppFormTable">
            
            <tr>
                <td colspan="2">&nbsp;
                </td>
            </tr>

            <tr>
                <td colspan="2" style="text-align: center">
                    <span id="msg" style="display: none"></span>
                </td>
            </tr>
            <tr runat="server" id="trFileUploadNCL">
                <td style="width: 25%;" align="right">Select Document
                </td>
                <td style="width: 50%; vertical-align: top;">
                    <asp:FileUpload runat="server" ID="flUploadNCL" />
                    <img style="max-width: 80px" src="" class="" id="thumimg" alt="">
                </td>
            </tr>
            <%--<asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label>--%>
            <%--    <asp:HiddenField runat="server" ID="lblCandidateName" />--%>
            <%--  <asp:HiddenField runat="server" ID="hdnCurrentDocId" />--%>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSubmiteNCL" runat="server" Text="Submit" CssClass="InputButton" OnClick="btnSubmiteNCL_Click" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBoxNCLOpen" runat="server" HeaderText="Convert to Open Not having NCL Certificate"
        Visible="False">
        <br />
        <table class="AppFormTable">
           
            <tr>
                <td align="center">
                    <asp:Button ID="btnNCLConvertToOpen" runat="server" Text="Process to Convert to OPEN"
                        CssClass="InputButton" OnClick="btnNCLConvertToOpen_Click" />
                </td>
                <%-- <td align="center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" OnClick="btnCancel_Click" />
                </td>--%>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>

    <%--EWS--%>

    <cc1:ContentBox ID="ContentBoxEWS" runat="server" HeaderText="Upload EWS Certificate"
        Visible="False">
        <br />
        <table class="AppFormTable">
           
            <tr>
                <td align="center">
                    <asp:Button ID="btnEWSYes" runat="server" Text="Upload EWS Certificate" CssClass="InputButton"
                        OnClick="btnEWSYes_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="btnEWSNo" runat="server" Text="Convert to Non-EWS" CssClass="InputButton" Visible="false"
                        OnClick="btnEWSNo_Click" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTableEWS" runat="server" HeaderText="Upload EWS Certificate"
        Visible="False">
        <table class="AppFormTable">
            
            <tr>
                <td colspan="2">&nbsp;
                </td>
            </tr>

            <tr>
                <td colspan="2" style="text-align: center">
                    <span id="msg" style="display: none"></span>
                </td>
            </tr>
            <tr id="tr1" runat="server" visible="true">
                <td colspan="2">
                    <asp:GridView ID="gvEWS" runat="server" AutoGenerateColumns="False" CssClass="DataGrid" BorderWidth="1" OnRowCommand="gvEWS_RowCommand" EnableModelValidation="True" Width="100%" OnRowDataBound="gvEWS_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" ItemStyle-Wrap="true" HtmlEncode="False">
                                <ItemStyle Width="67%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UploadStatus" HeaderText="Upload Status">
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Upload">
                                <ItemTemplate>
                                    <asp:Image ID="btnUpload" runat="server" AlternateText="Upload" ImageUrl="~/Images/ic_file_upload_black_48dp_2x.png" onclick="return OpenTestPopup(this);" Style="cursor: pointer; color: #757575;" ToolTip="Upload" Visible='<%# Eval("FilePath").ToString()==""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                    <%--<img src="" id="imgDoc" Style="cursor: pointer; max-width: 40px" runat="server" />--%>
                                    <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" runat="server" onclick="javascript:OpenViewDocumentPopUp(this)" />
                                    <asp:HiddenField ID="hidFURL" runat="server" Value='<%# Bind("FilePath") %>' />
                                    <asp:HiddenField ID="hidDID" runat="server" Value='<%# Bind("DocumentTransID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btndelete" runat="server" CommandArgument='<%# Bind("DocumentId") %>' CommandName="D" ImageUrl="~/Images/icon-delete.png" ToolTip="Edit"
                                        OnClientClick="return confirm('Your previously uploaded document will be deleted and you will have to upload a fresh one. Do you want to continue?');"
                                        Visible='<%# Eval("FilePath").ToString()!=""?true:false %>' Style="height: 50px !important" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SC Verification Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsSubmittedAtAFC" runat="server" Text='<%# Eval("IsSubmittedAtAFC") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnDocId" runat="server" Value='<%# Bind("DocumentId") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnImgUrl" runat="server" Value='<%# Bind("FilePath") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <%--<tr runat="server" id="trFileUploadEWS">
                <td style="width: 25%;" align="right">Select Document
                </td>
                <td style="width: 50%; vertical-align: top;">
                    <asp:FileUpload runat="server" ID="flUploadEWS" />
                    <img style="max-width: 80px" src="" class="" id="thumimg" alt="">
                </td>
            </tr>--%>
            <%--<asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label>--%>
            <%--    <asp:HiddenField runat="server" ID="lblCandidateName" />--%>
            <asp:HiddenField runat="server" ID="HiddenField1" />
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSubmiteEWS" runat="server" Text="Submit" CssClass="InputButton" OnClick="btnSubmiteEWS_Click" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBoxEWSOpen" runat="server" HeaderText="Convert to Non-EWS Not having EWS Certificate"
        Visible="False">
        <br />
        <table class="AppFormTable">
           
            <tr>
                <td align="center">
                    <asp:Button ID="btnEWSConvertToOpen" runat="server" Text="Process to Convert to Non-EWS" 
                        CssClass="InputButton" OnClick="btnEWSConvertToOpen_Click" />
                </td>
                <%-- <td align="center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" OnClick="btnCancel_Click" />
                </td>--%>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>

    <%-- Document View Part --%>
    <%-- <div id="contentFileTestEWS" runat="server" style="display: none;">
        <table class="AppFormTable">
            <tr>
                <th style="width: 25%;" align="right">Upload Document For :</th>
                <th style="width: 70%;" align="left">
                    <b>
                        <label id="lbldoumentuplodNameEWS"></label>
                    </b>
                </th>
                <th align="center">
                    <button type="button" onclick="closeUploadEWS()" style="width: 10px; height: 10px;" title="Close">
                        <img src="../Images/ContentBox_close.gif"></button>
                </th>
            </tr>
        </table>
        <table class="AppFormTable">
        </table>
        <table class="AppFormTable">
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="btnUploadCompleteEWS" OnClientClick="return checkfrmuploadEWS();" runat="server" Style="display: none; color: aliceblue" Text="" OnClick="btnUploadComplete_Click" />
                </td>
            </tr>
        </table>
        <asp:HiddenField runat="server" ID="hidDoc" />
        <div id="cropContainer" class="wrapper"></div>
    </div>--%>
    <div id="contentFileTest" runat="server" style="display: none;">
        <table class="AppFormTable">
            <tr>
                <th style="width: 25%;" align="right">Upload Document For :</th>
                <th style="width: 70%;" align="left">
                    <b>
                        <label id="lbldoumentuplodName"></label>
                    </b>
                </th>
                <th align="center">
                    <button type="button" onclick="closeUpload()" style="width: 10px; height: 10px;" title="Close">
                        <img src="../Images/ContentBox_close.gif"></button>
                </th>
            </tr>
            <tr id="trJuridiction" runat="server" style="display: none">
                <td style="width: 25%;" align="right">
                    <asp:Label ID="lblJuridiction" runat="server">Jurisdiction</asp:Label>
                </td>
                <td style="width: 75%;" colspan="2">
                    <asp:DropDownList ID="ddlJuridiction" runat="server" Width="50%" onchange="getDistrict(this.value)"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                </td>
            </tr>
            <tr id="trDistrict" runat="server" style="display: none">
                <td style="width: 25%;" align="right">
                    <asp:Label ID="lblDistrict" runat="server">District</asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlDistrict" runat="server" Width="50%" onchange="getTaluka(this.value)"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                </td>
            </tr>
            <tr id="trTaluka" runat="server" style="display: none">
                <td style="width: 25%;" align="right">
                    <asp:Label ID="lblTaluka" runat="server">Taluka</asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlTaluka" runat="server" Width="50%"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
        </table>
        <table class="AppFormTable">
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="btnUploadComplete" OnClientClick="return checkfrmupload();" runat="server" Style="display: none; color: aliceblue" Text="" OnClick="btnUploadComplete_Click" />
                    <input type="hidden" runat="server" id="hidDID" />
                    <input type="hidden" runat="server" id="hidJUD" /><input type="hidden" runat="server" id="hidTID" />
                </td>
            </tr>
        </table>
        <asp:HiddenField runat="server" ID="HiddenField3" />
        <div id="cropContainer" class="wrapper"></div>
        <%--<div id="app" class="app"></div>--%>
    </div>

    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%" Height="600px" Style="position: fixed !important">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr>
                <td>
                    <div class="modal-body" style="height: 450px; overflow: scroll">
                        <div runat="server" id="divButtonPopup">
                            <table class="AppFormTableWithOutBorder" style="width: 5%; height: 15px;">
                                <tr>
                                    <td>
                                        <button type="button" onclick="zoominPopUp()">
                                            <img src="../Images/zoom-in.png" width="15px" height="15px"></button></td>
                                    <td>
                                        <button type="button" onclick="zoomoutPopUp()">
                                            <img src="../Images/zoom-out.png" width="15px" height="15px">
                                        </button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divDocument" class="doc-container"></div>
                    </div>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbPassword" runat="server">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upQualification">
            <ContentTemplate>
                <asp:HiddenField ID="hdnPassword" runat="server" />
                <table id="tblPasword" class="AppFormTable" runat="server">

                    <tr id="tr2" runat="server">
                        <td align="right" style="width: 50%;">Enter Your Login Password to receive OTP
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20" autocomplete="off"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                Display="None" ErrorMessage="Enter Password" ValidationGroup="password"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <br />
                    <tr>
                        <td align="center" colspan="3">
                            <br />
                            <br />
                            <asp:Button ID="btnpassword" runat="server" Text="Verify Password" CssClass="InputButton"
                                OnClick="btnpassword_Click" ValidationGroup="password" Style="font-size: medium; height: 30px; font-weight: bold; background-color: red;" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                ShowMessageBox="True" ValidationGroup="password" />
                        </td>
                    </tr>
                </table>
                <table id="tblOtp" class="AppFormTable" runat="server">
                    <tr id="trMobileNo" runat="server" visible="False">
                        <td colspan="4" align="center">OTP has been sent your Mobile No :  
                            <asp:Label ID="lblMaskMobileno" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">Enter One Time Password (OTP)
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtOneTimePassword" runat="server" MaxLength="6" onKeyPress="return numbersonly(event)"
                                autocomplete="off"> </asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword"
                                Display="None" ErrorMessage="Please Enter One Time Password (OTP)." ValidationGroup="otp"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword"
                                Display="None" ErrorMessage="One Time Password (OTP) Should be of 6 Digits."
                                ValidationExpression="\d{6}" ValidationGroup="otp"></asp:RegularExpressionValidator>
                            <asp:Button ID="btnCall" runat="server" CssClass="InputButton mt-2" OnClick="btnCall_Click"
                                Text="Retry on Call" Visible="false" ValidationGroup="call" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <br />
                            <br />
                            <asp:Button ID="btnVerifyOtp" runat="server" Text="Verify OTP"
                                CssClass="InputButton" OnClick="btnVerifyOtp_Click" ValidationGroup="otp" Style="font-size: medium; height: 40px; font-weight: bold; background-color: red;" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False"
                                ShowMessageBox="True" ValidationGroup="otp" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
    <script>
        function OpenViewDocumentPopUp(cntrl) {


            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            var corrRow = cntrl.parentNode.parentNode;
            var filePath = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            //corrRow.cells[corrRow.cells.length - 5].innerText

            //document.getElementById('lblDocumentName').innerHTML = corrRow.cells[corrRow.cells.length - 7].innerText;
            document.getElementById('lblDocumentName').innerHTML = corrRow.cells[1].innerText;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" runat="server" src="' + filePath + '">';
                    document.getElementById('divDocument').style.overflow = "auto";
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('divDocument').innerHTML = '<iframe src="' + filePath + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                    document.getElementById('divDocument').innerHTML = '<embed src="' + filePath + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                    //  document.getElementById('divDocument').innerHTML = '<embed id="plugin" type="application/x-google-chrome-pdf" src="' + filePath + '" stream-url="chrome-extension://mhjfbmdgcfjbbpaeojofohoefgiehjai/665b5a2f-dda0-4dda-a801-8a83a2c13f5f" headers = "cache-control: private, max-age=0, must-revalidate content-disposition: inline; content-length: 77059 content-type: application/pdf; charset=utf-8 date: Tue, 04 Aug 2020 19:28:48 GMT pragma: public server: Microsoft-IIS/10.0 status: 200 x-aspnet-version: 4.0.30319 x-powered-by: ASP.NETx-sourcefiles: =?UTF-8?B?RTpcRGV2ZW5kcmFcR2l0UmVwb3NpdG9yeVxwb3N0aHNjZGlwbG9tYTIwMjBfbmV3YXBwXFBvc3RIU0NEaXBsb21hMjAyMFxWaWV3UHVibGljRG9jdW1lbnQ=?=" background-color="0xFF525659" top-toolbar-height="56" javascript = "allow" full-frame="" >';
                    break;
                default:
                    alert("File type not supported");
            }
        }
        function zoominPopUp() {
            var GFG = document.getElementById('<%=imgPopUpDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth + 100) + "px";
        }

        function zoomoutPopUp() {
            var GFG = document.getElementById('<%=imgPopUpDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth - 100) + "px";
        }
        function closeUpload() {
            document.getElementById('<%=contentFileTest.ClientID %>').style.display = "none";
            if (document.getElementById('<%=btnSubmite.ClientID %>') != null) {
                document.getElementById('<%=btnSubmite.ClientID %>').style.display = "block";
            }
            if (document.getElementById('<%=btnSubmiteEWS.ClientID %>') != null) {
                doument.getElementById('<%=btnSubmiteEWS.ClientID %>').style.display = "block";
            }
        }

        function OpenTestPopup(cntrl) {
            if (document.getElementById('<%=btnSubmite.ClientID %>') != null) {
                document.getElementById('<%=btnSubmite.ClientID %>').style.display = "none";
            }
            if (document.getElementById('<%=btnSubmiteEWS.ClientID %>') != null) {
                document.getElementById('<%=btnSubmiteEWS.ClientID %>').style.display = "none";
            }


            document.getElementById('<%=contentFileTest.ClientID %>').style.display = "block";
            document.getElementById('<%=contentFileTest.ClientID %>').setAttribute("tabindex", 1);
            document.getElementById('<%=contentFileTest.ClientID %>').focus();
            var corrRow = cntrl.parentNode.parentNode;
            document.getElementById("lbldoumentuplodName").innerText = corrRow.cells[1].innerText;
            var documentId = corrRow.cells[corrRow.cells.length - 2].getElementsByTagName("input")[0].value;
    //document.getElementById("thumimg").src = "";
<%--    document.getElementById('<%=flUpload.ClientID %>').value = "";--%>
            if (document.getElementById('<%=hdnCurrentDocId.ClientID %>') != null) {
                $("#<%=hdnCurrentDocId.ClientID %>").get(0).value = documentId;
            }
            if (document.getElementById('<%=HiddenField1.ClientID %>') != null) {
                $("#<%=HiddenField1.ClientID %>").get(0).value = documentId;
            }
            document.getElementById("<%=trJuridiction.ClientID %>").style.display = "none";
            document.getElementById("<%=trDistrict.ClientID %>").style.display = "none";
            document.getElementById("<%=trTaluka.ClientID %>").style.display = "none";

            if (documentId == "21" || documentId == "22") {
                var ddlDistrict = document.getElementById("<%=ddlDistrict.ClientID %>");
                while (ddlDistrict.hasChildNodes())
                    ddlDistrict.removeChild(ddlDistrict.childNodes[0]);

                var ddl = document.getElementById("<%=ddlJuridiction.ClientID %>");
                while (ddl.hasChildNodes())
                    ddl.removeChild(ddl.childNodes[0]);
                if (documentId == 21) {
                    var opt = document.createElement("option");
                    document.getElementById("<%=ddlJuridiction.ClientID %>").options.add(opt);
                    opt.text = "-- Select Issuing Authority --";
                    opt.value = "0";
                }
                else {
                    var opt = document.createElement("option");
                    document.getElementById("<%=ddlJuridiction.ClientID %>").options.add(opt);
                    opt.text = "-- Select Jurisdiction --";
                    opt.value = "0";
                }

                var ds = Pharmacy2024.CandidateAdmissionReportingModule.frmUploadTRYERTX.FillJuridiction(documentId);
                var categoryID = Pharmacy2024.CandidateAdmissionReportingModule.frmUploadTRYERTX.getCategoryID();
                if (ds.value.Tables[0].Rows.length > 0) {
                    for (var i = 0; i < ds.value.Tables[0].Rows.length; i++) {
                        var opt = document.createElement("option");
                        document.getElementById("<%=ddlJuridiction.ClientID %>").options.add(opt);
                        opt.text = ds.value.Tables[0].Rows[i].JurisdictionDetails;
                        opt.value = ds.value.Tables[0].Rows[i].JurisdictionID;
                    }
                    document.getElementById("<%=trJuridiction.ClientID %>").style.display = "revert";

                    document.getElementById("<%=trDistrict.ClientID %>").style.display = "revert";
                    var opt = document.createElement("option");
                    document.getElementById("<%=ddlDistrict.ClientID %>").options.add(opt);
                    opt.text = "-- Select District --";
                    opt.value = "0";
                }
                if (documentId == 21) {
                    document.getElementById("<%=lblJuridiction.ClientID %>").innerHTML = 'Issuing Authority';
                    document.getElementById("<%=trTaluka.ClientID %>").style.display = "revert";

                    var opt = document.createElement("option");
                    document.getElementById("<%=ddlTaluka.ClientID %>").options.add(opt);
                    opt.text = "-- Select Taluka --";
                    opt.value = "0";
                }
            }
            else {
                document.getElementById("<%=trJuridiction.ClientID %>").style.display = "none";
                document.getElementById("<%=trDistrict.ClientID %>").style.display = "none";
                document.getElementById("<%=trTaluka.ClientID %>").style.display = "none";
            }
        }
        function getDistrict(JurisdictionID) {
            document.getElementById("<%=hidDID.ClientID %>").value = "45"
            var categoryID = Pharmacy2024.CandidateAdmissionReportingModule.frmUploadTRYERTX.getCategoryID();
            var ddl = document.getElementById("<%=ddlDistrict.ClientID %>");
            while (ddl.hasChildNodes())
                ddl.removeChild(ddl.childNodes[0]);

            var ddlTaluka = document.getElementById("<%=ddlTaluka.ClientID %>");
            while (ddlTaluka.hasChildNodes())
                ddlTaluka.removeChild(ddlTaluka.childNodes[0]);

            var opt = document.createElement("option");
            document.getElementById("<%=ddlDistrict.ClientID %>").options.add(opt);
            opt.text = "-- Select District --";
            opt.value = "0";

            var dsDistrict = Pharmacy2024.CandidateAdmissionReportingModule.frmUploadTRYERTX.getDistrictForJuridiction(JurisdictionID);
            if (dsDistrict.value.Tables[0].Rows.length > 0) {
                for (var i = 0; i < dsDistrict.value.Tables[0].Rows.length; i++) {
                    var opt = document.createElement("option");
                    document.getElementById("<%=ddlDistrict.ClientID %>").options.add(opt);
                    opt.text = dsDistrict.value.Tables[0].Rows[i].DistrictName;
                    opt.value = dsDistrict.value.Tables[0].Rows[i].DistrictID;
                }
            }
            if (document.getElementById("<%=hdnCurrentDocId.ClientID %>").value == "21") {
                var opt = document.createElement("option");
                document.getElementById("<%=ddlTaluka.ClientID %>").options.add(opt);
                opt.text = "-- Select Taluka --";
                opt.value = "0";
            }
        }
        function getTaluka(DistrictID) {
            var ddl = document.getElementById("<%=ddlTaluka.ClientID %>");
            while (ddl.hasChildNodes())
                ddl.removeChild(ddl.childNodes[0]);

            var opt = document.createElement("option");
            document.getElementById("<%=ddlTaluka.ClientID %>").options.add(opt);
            opt.text = "-- Select Taluka --";
            opt.value = "0";
            if (DistrictID != 0) {
                var dsTaluka = Pharmacy2024.CandidateAdmissionReportingModule.frmUploadTRYERTX.getTalukaForDistrict(DistrictID);
                if (dsTaluka.value.Tables[0].Rows.length > 0) {
                    for (var i = 0; i < dsTaluka.value.Tables[0].Rows.length; i++) {
                        var opt = document.createElement("option");
                        document.getElementById("<%=ddlTaluka.ClientID %>").options.add(opt);
                        opt.text = dsTaluka.value.Tables[0].Rows[i].TalukaName;
                        opt.value = dsTaluka.value.Tables[0].Rows[i].TalukaID;
                    }
                }
            }
            else {
                while (ddl.hasChildNodes())
                    ddl.removeChild(ddl.childNodes[0]);
                var opt = document.createElement("option");
                document.getElementById("<%=ddlTaluka.ClientID %>").options.add(opt);
                opt.text = "-- Select Taluka --";
                opt.value = "0";
            }

        }

        function checkfrmupload() {
            if (document.getElementById('<%=hdnCurrentDocId.ClientID %>') != null) {
                var documentid = $("#<%=hdnCurrentDocId.ClientID %>").get(0).value;
            }
            if (document.getElementById('<%=HiddenField1.ClientID %>') != null) {
                var documentid = $("#<%=HiddenField1.ClientID %>").get(0).value;
            }
            if (documentid == "21" || documentid == "22") {
                if (document.getElementById("<%=ddlJuridiction.ClientID %>").value == "0") {
                    alert("Please select Juridiction");
                    return false;
                }
                if (document.getElementById("<%=ddlDistrict.ClientID %>").value == "0") {
                    alert("Please select District");
                    return false;
                }
                if (documentid == "21") {
                    if (document.getElementById("<%=ddlTaluka.ClientID %>").value == "0") {
                        alert("Please select Taluka");
                        return false;
                    }
                    document.getElementById("<%=hidTID.ClientID %>").value = document.getElementById("<%=ddlTaluka.ClientID %>").value;
                }
            }

            document.getElementById("<%=hidDID.ClientID %>").value = document.getElementById("<%=ddlDistrict.ClientID %>").value;
            document.getElementById("<%=hidJUD.ClientID %>").value = document.getElementById("<%=ddlJuridiction.ClientID %>").value;
            return true;
        }
        function checkfrmuploadEWS() {
            return true;
        }

        <%--function closeUploadEWS() {
            document.getElementById('<%=contentFileTestEWS.ClientID %>').style.display = "none";
            document.getElementById('<%=btnSubmiteEWS.ClientID %>').style.display = "block";
        }

        function OpenTestPopupEWS(cntrl) {
            document.getElementById('<%=btnSubmiteEWS.ClientID %>').style.display = "none";
            document.getElementById('<%=contentFileTestEWS.ClientID %>').style.display = "block";
            document.getElementById('<%=contentFileTestEWS.ClientID %>').setAttribute("tabindex", 1);
            document.getElementById('<%=contentFileTestEWS.ClientID %>').focus();
            var corrRow = cntrl.parentNode.parentNode;
            document.getElementById("lbldoumentuplodNameEWS").innerText = corrRow.cells[1].innerText;
            var documentId = corrRow.cells[corrRow.cells.length - 2].getElementsByTagName("input")[0].value;
        }--%>
    </script>
</asp:Content>
