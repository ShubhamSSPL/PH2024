<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="frmVerificationforCVCTVCNCLEWSDocument.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmVerificationforCVCTVCNCLEWSDocument" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
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
            height: 20px !important;
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
            max-width: 1150px !important;
            border: 1rem solid rgba(0,0,0,.1);
        }

        #rightContainer_contentAppleSarkarBarti {
            width: 100% !important;
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
                            var message = Pharmacy2024.AFCModule.frmVerificationforCVCTVCNCLEWSDocument.UploadDoc(data, documentID, hidJUD, hidDID, hidTID, fileName, fileExt, '<%= Request["PID"] %>');
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
                            var message = Pharmacy2024.AFCModule.frmVerificationforCVCTVCNCLEWSDocument.UploadDoc(data, documentID, hidJUD, hidDID, hidTID, fileName, fileExt, '<%= Request["PID"] %>');
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
                        var message = Pharmacy2024.AFCModule.frmVerificationforCVCTVCNCLEWSDocument.UploadDoc(data, documentID, hidJUD, hidDID, hidTID, fileName, fileExt, '<%= Request["PID"] %>');
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
    <table class="AppFormTableWithOutBorder" runat="server">
        <tr>
            <td>
                <font color="red">
                    <ol class="list-text">
                        <b>Note :</b>
                        <%--<li><p align="justify"><font color="red">Those candidate who have submitted the receipt of CVC/TVC/NCL/ Proforma V (EWS) at the time of application form filling and confirmation and now could not able to submit the original CVC/TVC/NCL/EWS certificate till the Last date of seat acceptance and reporting to the institute for CAP round I as per schedule can convert themselves into open / non-ews and will be able to complete seat acceptance and institute reporting for CAP round I..</font></p></li>
                            <li><p align="justify"><font color="red">Once you converted your self into OPEN/ NON EWS category then you are considered Only in OPEN/ NON EWS category for seat allotment in the next CAP round / additional institutional round.</font></p></li>
                            <li><p align="justify"><font color="red">OPEN/ NON EWS converted candidate will not be able to convert back into reserved / EWS category.</font></p></li>--%>
                        <li>
                            <p align="justify">
                                <font color="red">The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                                   
                                    <br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                                    <br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
                                    <br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.
                                </font>
                            </p>
                        </li>
                    </ol>
                </font>
            </td>
        </tr>
    </table>
    <table id="tblPersonalInfo" runat="server" class="AppFormTable" style="background-color: #e7fafe;">
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
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Upload CVC/TVC/NCL/EWS Certificate."
        Visible="False">
        <table class="AppFormTable">
            <tr>
                <td colspan="2">
                    <ol class="list-text">
                        <b>Important Instructions :</b>
                        <%--<li>If the candidate has already uploaded the Receipt at SC, Upload the Caste / Tribe Validity Certificate issued by the Scrutiny Committe and check Acknowledgement. </li>
                        <li>If the candidate could not  to submit the Caste / Tribe Validity Certificate on or Non-Creamy Layer Certificate before 07/12/2021 Up to 3 P.M. , candidate will convert to Open Category. </li>--%>
                        <li>The SC, ST, VJ/DT- NT(A), NT(B), NT(C), NT(D), SBC and EWS Candidates who submitted receipt of Caste/Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Caste/ Tribe Validity Certificate, Non Creamy Layer Certificate, EWS Certificate at Physical Scrutiny Center or E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category. 
                                        
                            <br /><br /> The SEBC and OBC Candidates who submitted receipt of Non Creamy Layer Certificate during registration, e-verification or physical document verification and confirmation period should upload and verify original Non Creamy Layer Certificate at E-Scrutiny Center and submit original certificate to the admitted institute on or before 06/11/2024 up to 03.00 P.M. otherwise these candidates admission will get automatically cancelled and shall be considered as Open category candidates for next institute level round provided candidate full fill eligibility criteria for open category.
                            <br /><br /> In case of SEBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 22 July 2024.
                            <br /><br /> In case of OBC Candidates, duration for submitting Caste Validity certificate will be as per the Maharashtra State Government Resolution No - संकिर्ण-2024/प्र.क्र.75/ आरक्षण-5 dated 05 September, 2024.
                        </li>
                    </ol>
                </td>
            </tr>
          <%--  <tr>
                <td colspan="2">&nbsp;
                </td>
            </tr>--%>
            <%--<tr>
                <td colspan="2" style="text-align: center">
                    <span id="msg" style="display: none"></span>
                </td>
            </tr>--%>
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
                            <asp:TemplateField HeaderText="Verified">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbnYes" runat="server" Text="&nbsp;Verified" GroupName="YesNo" Visible='<%# Eval("FilePath").ToString()!=""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Not Verified">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbnNo" runat="server" Text="&nbsp;Not Verified" GroupName="YesNo" Visible='<%# Eval("FilePath").ToString()!=""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="15%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Upload">
                                <ItemTemplate>
                                    <asp:Image ID="btnUpload" runat="server" AlternateText="Upload" ImageUrl="~/Images/ic_file_upload_black_48dp_2x.png" onclick="return OpenTestPopup(this);" Style="cursor: pointer; color: #757575;" ToolTip="Upload" Visible='<%# Eval("FilePath").ToString()==""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <a href="#" target="_blank" id="hrefURL" runat="server"></a>
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
                            <asp:TemplateField HeaderText="SC Verification Status" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsSubmittedAtAFC" runat="server" Text='<%# Eval("IsSubmittedAtAFC") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocumentID" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnDocId" runat="server" Value='<%# Bind("DocumentId") %>' />
                                    <asp:HiddenField ID="hdnImgByteArray" runat="server" Value='<%# Bind("FilePath") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Verify Document" CssClass="InputButton" OnClick="btnProceed_Click" />
                </td>
            </tr>
        </table>
       
    </cc1:ContentBox>
    <div id="contentFileTest" runat="server" style="display: none;">
        <table class="AppFormTable">
            <tr>
                <th style="width: 20%;" align="right">Upload Document For :</th>
                <th style="width: 75%;" align="left">
                    <b>
                        <label id="lbldoumentuplodName"></label>
                        <br />
                        <label style="color: red;">(Upload scan copy of Original Document only.)</label>
                        <br />
                        <label id="lbldoumentInstruction" style="color: red;"></label>
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
    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                    <br />
                    <b>
                        <label id="lbldoumentuplodName"></label>
                        
                    </b>
                </th>
            </tr>
            <tr>
                <td>
                    <div class="modal-body">
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
    <script>
        function OpenViewDocumentPopUp(cntrl) {


            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            var corrRow = cntrl.parentNode.parentNode;
            var filePath = corrRow.cells[corrRow.cells.length - 3].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            //corrRow.cells[corrRow.cells.length - 5].innerText
            var byteStream = corrRow.cells[corrRow.cells.length - 3].getElementsByTagName("input")[1].value;
            //document.getElementById('lblDocumentName').innerHTML = corrRow.cells[corrRow.cells.length - 7].innerText;
            document.getElementById('lblDocumentName').innerHTML = corrRow.cells[1].innerText;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" runat="server" src="' + byteStream + '">';
                    document.getElementById('divDocument').style.overflow = "auto";
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('divDocument').innerHTML = '<iframe src="' + byteStream + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                    document.getElementById('divDocument').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

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


        function OpenTestPopup(cntrl) {

            document.getElementById('<%=contentFileTest.ClientID %>').style.display = "block";
            document.getElementById('<%=contentFileTest.ClientID %>').setAttribute("tabindex", 1);
            document.getElementById('<%=contentFileTest.ClientID %>').focus();
            var corrRow = cntrl.parentNode.parentNode;
            document.getElementById("lbldoumentuplodName").innerText = corrRow.cells[1].innerText;
            var documentId = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
    //document.getElementById("thumimg").src = "";
<%--    document.getElementById('<%=flUpload.ClientID %>').value = "";--%>
            if (document.getElementById('<%=hdnCurrentDocId.ClientID %>') != null) {
                $("#<%=hdnCurrentDocId.ClientID %>").get(0).value = documentId;
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

                var ds = Pharmacy2024.AFCModule.frmVerificationforCVCTVCNCLEWSDocument.FillJuridiction(documentId, '<%= Request["PID"] %>');
                var categoryID = Pharmacy2024.AFCModule.frmVerificationforCVCTVCNCLEWSDocument.getCategoryID('<%= Request["PID"] %>');
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
            var categoryID = Pharmacy2024.AFCModule.frmVerificationforCVCTVCNCLEWSDocument.getCategoryID('<%= Request["PID"] %>');
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

            var dsDistrict = Pharmacy2024.AFCModule.frmVerificationforCVCTVCNCLEWSDocument.getDistrictForJuridiction(JurisdictionID);
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
                var dsTaluka = Pharmacy2024.AFCModule.frmVerificationforCVCTVCNCLEWSDocument.getTalukaForDistrict(DistrictID);
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

    </script>
</asp:Content>
