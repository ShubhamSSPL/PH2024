<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmUploadRequiredDocumentsStep.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep" EnableEventValidation="false" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" runat="server">

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
            .doc-container{
            height:16rem !important;
  
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
        .divopacity
        {
            width:100%;
            height:100%;
            position:absolute;
            z-index:1000;
            background:#345678;
            opacity:0.3;
            text-align:center;
        }
    </style>


    <script src="../Scripts/mcfCrop.js"></script>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
    <script src="../Scripts/MahaITDocumentFetch.js"></script>
    <link rel="stylesheet" href="https://unpkg.com/font-awesome@4.7.0/css/font-awesome.min.css" crossorigin="anonymous">
   
    <script>
        function sleep(milliseconds) {
            const date = Date.now();
            let currentDate = null;
            do {
                currentDate = Date.now();
            } while (currentDate - date < milliseconds);
        }
        $(document).ready(function () {
            <%--document.getElementById('<%=divspinner.ClientID %>').style.display = 'block'; --%>

            initContainer("cropContainer", 80, 1500, 1500, "../Images/", 500, cb);
            function cb(data, fileName, fileExt) {
                //console.log(data);
                // alert(fileName + "." + fileExt);
                document.getElementById('<%=divspinner.ClientID %>').style.display = 'block';
                //document.getElementById('cropContainer').style.display = 'none';
                //  sleep(10000);
                if (data.length > 10) {

                    var documentID = $("#<%=hdnCurrentDocId.ClientID %>").get(0).value;
                    var barcode = $("#<%=hdnbarcode.ClientID %>").get(0).value;
                    var checkBarcode = $("#<%=hdncheckBarcode.ClientID %>").get(0).value;
                    var CandidateBarcode = document.getElementById('<%= txtEnterbarcode. ClientID %>').value;
                    if (documentID == "21") {
                        var ddlDistrict = document.getElementById("<%=ddlDistrict.ClientID %>");
                        var ddlJuridiction = document.getElementById("<%=ddlJuridiction.ClientID %>");
                        var ddlTaluka = document.getElementById("<%=ddlTaluka.ClientID %>");
                        var hidJUD = ddlJuridiction.options[ddlJuridiction.selectedIndex].value
                        var hidDID = ddlDistrict.options[ddlDistrict.selectedIndex].value
                        var hidTID = ddlTaluka.options[ddlTaluka.selectedIndex].value

                        $("#<%=hdncheckBarcode.ClientID %>").get(0).value;


                        if (hidJUD == "0") {
                            alert("Select Issuing Authority");
                            document.getElementById('<%=divspinner.ClientID %>').style.display = 'none';
                            return;
                        }
                        else if (hidDID == "0") {
                            alert("Select District");
                            document.getElementById('<%=divspinner.ClientID %>').style.display = 'none';
                            return;
                        }
                        else if (hidTID == "0") {
                            alert("Select Taluka");
                            document.getElementById('<%=divspinner.ClientID %>').style.display = 'none';
                            return;
                        }
                        else {
                            var message = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.UploadDoc(data, documentID, hidJUD, hidDID, hidTID, fileName, fileExt, checkBarcode, barcode, '<%= Request["PID"] %>', CandidateBarcode);
                            if (message.value == "The File has been uploaded.") {
                                $('#<%=btnUploadComplete.ClientID %>').show().click().hide();
                            }
                            else {
                                alert(message.error.Message);
                                document.getElementById('<%=divspinner.ClientID %>').style.display = 'none';
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
                            document.getElementById('<%=divspinner.ClientID %>').style.display = 'none';
                            return;
                        }
                        else if (hidDID == "0") {
                            alert("Select District");
                            document.getElementById('<%=divspinner.ClientID %>').style.display = 'none';
                            return;
                        }
                        else {
                            var message = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.UploadDoc(data, documentID, hidJUD, hidDID, hidTID, fileName, fileExt, checkBarcode, barcode, '<%= Request["PID"] %>', CandidateBarcode);
                            if (message.value == "The File has been uploaded.") {
                                $('#<%=btnUploadComplete.ClientID %>').show();
                                $('#<%=btnUploadComplete.ClientID %>').click();
                                $('#<%=btnUploadComplete.ClientID %>').hide();
                            }
                            else {
                                alert(message.error.Message);
                                document.getElementById('<%=divspinner.ClientID %>').style.display = 'none';
                            }
                        }
                    }
                    else {
                        var message = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.UploadDoc(data, documentID, hidJUD, hidDID, hidTID, fileName, fileExt, checkBarcode, barcode, '<%= Request["PID"] %>', CandidateBarcode);
                        if (message.value == "The File has been uploaded.") {
                            $('#<%=btnUploadComplete.ClientID %>').show();
                            $('#<%=btnUploadComplete.ClientID %>').click();
                            $('#<%=btnUploadComplete.ClientID %>').hide();
                        }
                        else {
                            alert(message.error.Message);
                            document.getElementById('<%=divspinner.ClientID %>').style.display = 'none';
                        }
                    }
                }
                else {
                    alert("Please Select File");
                    document.getElementById('<%=divspinner.ClientID %>').style.display = 'none';
                }
              //  document.getElementById('<%=divspinner.ClientID %>').style.display = 'none'; 
                //document.getElementById('<%=divup.ClientID %>').style.display = 'block'; 

                //end
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

        //$(document).ready(function () {
        //    $("div[id$=dvProgress]").fadeOut("fast");
        //}
    </script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <style>
        .modal {
            display: none;
            position: fixed;
            z-index: 1000;
            top: 0;
            left: 0;
            height: 100%;
            width: 100%;
            background: rgba( 255, 255, 255, .8 ) url('../Images/BigProgress.gif') 50% 50% no-repeat;
        }

        body.loading {
            overflow: hidden;
        }

            body.loading .modal {
                display: block;
            }

        .NotVisible {
            display: none;
        }
        .spinner{
            width:100px;
        }
    </style>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" />
    <script type="text/javascript">jQuery.noConflict();</script>

    <script src="https://fengyuanchen.github.io/shared/google-analytics.js" crossorigin="anonymous"></script>
    <script type="text/javascript" src="../dist/main.js"></script>


      <div id="divspinner" class="divopacity" style="display:none" runat="server" >
        <img src="../Images/spinner.gif" class="spinner" />
    </div>

    <ccm:contentbox id="ContentBox1" runat="server" headervisible="false">
        <table class="AppFormTable">
            <tr>
                <td style="width:50%" align="right">Application ID</td>
                <td style="width:50%"><asp:Label ID="lblApplicationID" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate's Name</td>
                <td><asp:Label ID="lblCandidateName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
        </table>
    </ccm:contentbox>

    <ccm:ContentBox ID="cntDocument" HeaderText="Upload Required Documents" runat="server">
        <asp:HiddenField ID="hdnCode" runat="server" />
        <asp:HiddenField ID="hdnFileTypes" runat="server" />
        <asp:HiddenField ID="hdnFileTypesCode" runat="server" />
        <asp:HiddenField ID="hdnMaxSize" runat="server" />
        <asp:HiddenField ID="hdnMaxSizeCode" runat="server" />
        <asp:HiddenField ID="hdnFileAddress" runat="server" />
        <asp:HiddenField ID="hdnUploadedFileName" runat="server" />
        <asp:HiddenField ID="hdnOriginalFileName" runat="server" />
        <asp:HiddenField ID="hdnUploadedFileURL" runat="server" />
        <asp:HiddenField ID="hdnFileUploadURL" runat="server" />
        <asp:HiddenField ID="hdnApplicationURL" runat="server" />
        <asp:HiddenField ID="hdnToken" runat="server" />

        <table class="AppFormTable">
            <tr>
                <td colspan="4">
                    <font color="red">
                        <p align = "justify"><font color = "red"><b>Instructions :</b></font></p>
                        <ul class="list-text">
                            <li><p align = "justify"><font color = "red">Please Use Latest Version Of <b>Google Chrome</b> or <b>Mozilla Firefox</b> To Upload Documents.</font></p></li>
                            <li><p align = "justify"><font color = "red">File Types Allowed : <b><asp:Label ID="lblFileTypesAllowed" runat="server"></asp:Label></b>.</font></p></li>
                            <li><p align = "justify"><font color = "red">Maximum File Size Allowed : <b><asp:Label ID="lblMaxFileSize" runat="server"></asp:Label></b>.</font></p></li>
                        </ul>
                    </font>
                </td>
            </tr>

            <%-- <tr>
                <td style="width:25%;" align="right">File Types Allowed</td>
                <td style="width:25%;" ><b><asp:Label ID="lblFileTypesAllowed" runat="server"></asp:Label> </b></td>
            
                <td style="width:25%;" align="right">Maximum File Size Allowed</td>
                <td style="width:25%;"><b><asp:Label ID="lblMaxFileSize" runat="server"></asp:Label></b></td>
            </tr>--%>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" CssClass="DataGrid" BorderWidth="1" OnRowCommand="gvDocuments_RowCommand" EnableModelValidation="True" Width="100%" OnRowDataBound="gvDocuments_RowDataBound">
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
                                    <asp:ImageButton ID="btndelete" runat="server" CommandArgument='<%# Bind("DocumentId") %>' CommandName="D" ImageUrl="~/Images/icon-delete.png" ToolTip="Edit" OnClientClick="return confirm('Your previously uploaded document will be deleted and you will have to upload a fresh one. Do you want to continue?');" Visible='<%# Eval("FilePath").ToString()!=""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnIsBarcodeFetch" runat="server" Value='<%# Bind("IsBarcodeFetch") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
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
                                    <asp:HiddenField ID="hdnPersonalID" runat="server" Value='<%# Bind("PersonalID") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnImgUrl" runat="server" Value='<%# Bind("FilePath") %>' />
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
            <%--    <tr>
                <td colspan="2">
                    <p align="justify">
                        <b><u>Certificate of the Indian Nationality</u> :-</b>
                        <br />
                        The certificate of Indian Nationality, which is usually issued by the Tahshildar/Executive Magistrate/Dy. Collector of the concerned Taluka/District wherein the candidate ordinarily resides. In lieu of the <b>"Certificate of Indian Nationality"</b> any one of the following certificate will also be acceptable - 
                        <br />
                        <ul class="list-text">
                            <li>The School leaving Certificate indicating the Nationality of the candidate as 'Indian'.</li>
                            <li>Indian Passport in the name of the candidate, issued by appropriate authorities.</li>
                            <li>Birth Certificate of the Candidate indicating the place of birth in India.</li>
                        </ul>
                        <br />
                        <p align="justify">
                            <b><u>Domicile Certificate</u> :-</b>
                            <br />
                            Domicile certificate issued by the Maharashtra State’s appropriate authorities will be considered valid. The domicile certificate of Mother of the candidate shall be supported with marriage certificate and legal proof of change in name if any. Such candidates will be required to submit birth certificate clearly mentioning the name of the mother.
                        </p>
                        <br />
                        <p align="justify">
                            <b><u>Non-Creamy Layer Certificate</u> :-</b>
                            <br />
                            A candidate belonging to ‘Creamy Layer’ amongst the categories VJ/DT-NT(A), NT(B), NT(C), NT(D), SBC and OBC must note that the provision of reservation is NOT applicable to him/her. A candidate claiming benefit of reservation under the categories VJ/DT-NT(A), NT(B), NT(C), NT(D), SBC and OBC above will be required to produce <b>&quot;Non-Creamy Layer Certificate&quot;</b> in the name of the candidate as specified in the <b>Government Resolution No. CBC-10/2008/C.R.697/BCW-5</b>, dated 27th February 2009 or its updated version from time to time. <b>This certificate should be valid up to 31st March <%=NextYear%>.</b> However, such a Non-Creamy Layer Certificate shall be produced in any case on or before the last date of filling up of Application Form, failing which the category claim, will not be granted.
                        </p>
                    </p>
                </td>
            </tr>--%>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvDocumentsSubmitted" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" Visible="false">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" CssClass="Header" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Document Name" DataField="DocumentName" HtmlEncode="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90%" CssClass="Header" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                            </asp:BoundField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocumentID" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvDocumentsNotSubmitted" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" Visible="false">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No.">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" CssClass="Header" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Document Name" DataField="DocumentName" HtmlEncode="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90%" CssClass="Header" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                            </asp:BoundField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocumentID" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr runat="server" id="trInstructions" visible="true">
                <td colspan="2">
                    <p align="justify">
                        <b><u>Certificate of the Indian Nationality</u> :-</b>
                        <br />
                        The certificate of Indian Nationality, which is usually issued by the Tahshildar/Executive Magistrate/Dy. Collector of the concerned Taluka/District wherein the candidate ordinarily resides. In lieu of the <b>"Certificate of Indian Nationality"</b> any one of the following certificate will also be acceptable - 
                        <br />
                        <ul class="list-text">
                            <li>The School leaving Certificate indicating the Nationality of the candidate as 'Indian'.</li>
                            <%--<li>Indian Passport in the name of the candidate, issued by appropriate authorities.</li>--%>
                            <li>Birth Certificate of the Candidate indicating the place of birth in India.</li>
                        </ul>
                        <br />
                        <p align="justify">
                            <b><u>Domicile Certificate</u> :-</b>
                            <br />
                            Domicile certificate issued by the Maharashtra State’s appropriate authorities will be considered valid. The domicile certificate of Mother of the candidate shall be supported with marriage certificate and legal proof of change in name if any. Such candidates will be required to submit birth certificate clearly mentioning the name of the mother.
                        </p>
                        <br />
                        <p align="justify">
                            <b><u>Non-Creamy Layer Certificate</u> :-</b>
                            <br />
                            A candidate belonging to ‘Creamy Layer’ amongst the categories VJ/DT-NT(A), NT(B), NT(C), NT(D), SBC and OBC must note that the provision of reservation is NOT applicable to him/her. A candidate claiming benefit of reservation under the categories VJ/DT-NT(A), NT(B), NT(C), NT(D), SBC and OBC above will be required to produce <b>&quot;Non-Creamy Layer Certificate&quot;</b> in the name of the candidate as specified in the <b>Government Resolution No. CBC-10/2008/C.R.697/BCW-5</b>, dated 27th February 2009 or its updated version from time to time. <b>This certificate should be valid up to 31st March <%=NextYear%>.</b> <%--However, such a Non-Creamy Layer Certificate shall be produced in any case on or before the last date of filling up of Application Form, failing which the category claim, will not be granted.--%>
                        </p>
                    </p>
                </td>
            </tr>
        </table>

    </ccm:ContentBox>

    <ccm:ContentBox ID="contentDocumentConferamtion" runat="server" HeaderText="Self Confirmation" BoxType="PopupBox" Width="70%">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblDisplayDocumentSubmissionStatus" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <%--  <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click"  OnClientClick="return ValidateDocuments();"/>
                </td>
            </tr>--%>

            <tr runat="server" id="trYesNo">
                <td align="right">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="InputButton" OnClick="btnYes_Click" />
                    &nbsp;
                </td>
                <td align="left">&nbsp;<asp:Button ID="btnNo" runat="server" Text="No" CssClass="InputButton" OnClick="btnNo_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
    </ccm:ContentBox>

    <ccm:ContentBox ID="contentFileUpload" runat="server" HeaderText="Upload File" BoxType="PopupBox" Width="70%">
        <%--   <table class="AppFormTable">
            <tr>
                <td style="width: 25%;" align="right">Document Name :</td>
                <td align="left" colspan="2">
                    <b>
                        <label id="lbldoumentuplodName"></label>
                    </b>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;" align="right">Select Document</td>
                <td style="width: 50%;"> --%>
        <asp:FileUpload runat="server" ID="flUpload" />
        <input id="fileUpload" runat="server" type="file" style="display: none" />
        <%--</td>
                <td style="width: 25%;">
                    <img style="max-width: 80px" src="" class="" id="thumimg" alt="">
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr id="trJuridiction" runat="server" style="display: none">
                <td style="width: 25%;">
                    <asp:Label ID="lblJuridiction" runat="server">Jurisdiction</asp:Label>
                </td>
                <td style="width: 75%;" colspan="2">
                    <asp:DropDownList ID="ddlJuridiction" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Juridiction.')" onmouseout="hideddrivetip()" onchange="getDistrict(this.value)"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                </td>
            </tr>
            <tr id="trDistrict" runat="server" style="display: none">
                <td style="width: 25%;">
                    <asp:Label ID="lblDistrict" runat="server">District</asp:Label>
                </td>
                <td style="width: 75%;" colspan="2">
                    <asp:DropDownList ID="ddlDistrict" runat="server" Width="90%" onmouseover="ddrivetip('Please Select District.')" onmouseout="hideddrivetip()" onchange="getTaluka(this.value)"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                </td>
            </tr>
            <tr id="trTaluka" runat="server" style="display: none">
                <td style="width: 25%;">
                    <asp:Label ID="lblTaluka" runat="server">Taluka</asp:Label>
                </td>
                <td style="width: 75%;" colspan="2">
                    <asp:DropDownList ID="ddlTaluka" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Taluka.')" onmouseout="hideddrivetip()"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td align="center" colspan="3"> --%>
        <asp:Button ID="btnSaveUpload" OnClientClick="return checkfrmupload();" runat="server" CssClass="InputButtonRed" Style="display: none" Text="Upload" OnClick="btnSaveUpload_Click" />
        <%--<input type="hidden" runat="server" id="hidDID" />
                    <input type="hidden" runat="server" id="hidJUD" /><input type="hidden" runat="server" id="hidTID" />
                </td>
            </tr>
        </table>
        <asp:HiddenField runat="server" ID="hdnCurrentDocId" />--%>
    </ccm:ContentBox>

    <ccm:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%" Height="500px">
      <div class="table-responsive">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr runat="server" id="trFetchDocView" style="display: none;">
            </tr>
            <tr>
                <td>
                    <div class="modal-body p-0" style="height: 450px;">
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
          </div>
    </ccm:ContentBox>



    <ccm:ContentBox ID="contentAppleSarkarBarti" runat="server" BoxType="ContentBox" Width="80%" Height="500px" Style="display: none;" HeaderText="Upload Document">

        <div runat="server" id="divuploaddoc">
            <div class="table-responsive">
                <table class="AppFormTable">
                    <tr>

                        <th align="right" colspan="3">
                            <div class="row w-100 mx-auto">
                                <div class="col-sm-2">
                                    Upload Document For :
                                </div>
                                <div class="col-sm-9">
                                    <b>
                                        <label id="lbldoumentuplodName"></label>
                                    </b>
                                </div>
                                <div class="col-1">
                                    <button type="button" onclick="closeUpload()" style="width: 10px; height: 10px;" title="Close">
                                        <img src="../Images/ContentBox_close.gif"></button>
                                </div>
                            </div>
                        </th>

                    </tr>
                    <tr id="traaplesarkar" runat="server">
                        <td align="right" colspan="3">

                            <div class="row w-100  mx-auto">
                                <div class="col-4 col-md-3 ">
                                    <asp:Label ID="lblAapleSarkar" runat="server">Do you have Document from Aaple Sarkar Portal ? </asp:Label>
                                </div>
                                <div class="col-8 col-md-9 text-left">
                                    <asp:RadioButton ID="btnrdYes" name="bedStatus" runat="server" GroupName="Doc" Text="&nbsp;&nbsp;&nbsp; Yes" value="Yes" />
                                    &nbsp; 
                    <asp:RadioButton ID="btnrdNo" name="bedStatus" runat="server" GroupName="Doc" Text="&nbsp;&nbsp;&nbsp; No" value="No" />
                                    <%--<asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="checkEWSDocument" Display="None" ErrorMessage="Please Select Do you have EWS Certificate."></asp:CustomValidator>--%>

                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr runat="server" id="trEnterBarcodeID">
                        <td align="right">Enter Barcode Id From your Certificate :
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEnterbarcode" MaxLength="20" onKeyPress="return numbersonly(event)" />
                            <asp:HyperLink ID="hltxtEnterbarcode" runat="server" NavigateUrl="" Target="_blank" Text="Click here View Sample Document"></asp:HyperLink>
                        </td>
                    </tr>

                    <tr runat="server" id="trBarcode">
                        <td align="right">
                            <div class="row w-100 mx-auto">
                                <div class="col-4 col-md-3">
                                    Enter Barcode Id From your Certificate :
                                </div>
                                <div class="col-8 col-md-9 text-left">
                                    <asp:TextBox runat="server" ID="txtbarcode" onKeyPress="return numbersonly(event)" />
                                </div>
                            </div>
                        </td>

                    </tr>
                    <tr runat="server" id="trDocFetchbtn">
                        <td colspan="3" align="center">
                            <asp:Button ID="btnFetchDocument" OnClientClick="ValidateBarcode(event)" runat="server" CssClass="InputButtonRed" Text="Fetch Document" />
                            <button class="btn btn-primary" type="button" disabled style="display:none" id="btnwait" runat="server">
                                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                Loading...
                            </button>
                        </td>
                    </tr>
                    <tr runat="server" id="trresult" style="display: none"></tr>
                    <tr runat="server" id="trUploadDoc">
                        <td colspan="2" align="center">
                            <asp:Button ID="btnUploadDocument" runat="server" CssClass="InputButtonRed" Text="Verify Details and Processed for Document Upload" OnClientClick="viewUploadDocumentDiv(event)" />
                        </td>
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
            </div>

            <table class="AppFormTable">
                <tr>
                    <td align="center" colspan="3">
                        <asp:Button ID="btnUploadComplete" OnClientClick="return checkfrmupload();" runat="server" Style="display: none; color: aliceblue" Text="" OnClick="btnUploadComplete_Click" />
                        <input type="hidden" runat="server" id="hidDID" />
                        <input type="hidden" runat="server" id="hidJUD" /><input type="hidden" runat="server" id="hidTID" />
                        <input type="hidden" runat="server" id="hidResponse" />
                        <input type="hidden" runat="server" id="hdnCategoryID" />

                    </td>
                </tr>
            </table>

            <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
            <asp:HiddenField ID="hdncheckBarcode" runat="server" />
            <asp:HiddenField ID="hdnbarcode" runat="server" />
          
            <div id="divup" runat="server">
                 
                <div id="cropContainer" class="wrapper"></div>
            </div>
        </div>
        <script>
            function viewUploadDocumentDiv(e) {
                e.preventDefault();
                if (Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.InsertUpdateDocumentFetchData(document.getElementById('<%=hidResponse.ClientID %>').value, $("#<%=hdnCurrentDocId.ClientID %>").get(0).value)) {
                    document.getElementById('<%=divup.ClientID %>').style.display = "block";
                    document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                    document.getElementById('<%=trresult.ClientID %>').style.display = "none";
                    document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = 'none';
                    document.getElementById('<%=txtbarcode.ClientID %>').value = '';
                    document.getElementById('<%=trBarcode.ClientID %>').style.display = 'none';
                    document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'none';
                    LoadDistrictTalukaJuridicaiton($("#<%=hdnCurrentDocId.ClientID %>").get(0).value);
                }
                else {
                    alert('Some thing went wrong !');
                }
            }
            function ValidateBarcode(e) {
                e.preventDefault();
                document.getElementById('<%=btnFetchDocument.ClientID %>').style.display = 'none';
                document.getElementById('<%=btnwait.ClientID %>').style.display = 'block';
                var docID = $("#<%=hdnCurrentDocId.ClientID %>").get(0).value;
                if (document.getElementById('<%=txtbarcode.ClientID %>').value > 0) {


                    var dsResponse = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.FetchDocument(docID, document.getElementById('<%=txtbarcode.ClientID %>').value);
                    var obj = JSON.parse(dsResponse.json);
                    if (obj.value.ApplicantName != null) {

                        $("#<%=hdnbarcode.ClientID %>").get(0).value = document.getElementById('<%=txtbarcode.ClientID %>').value;
                        $("#<%=hdncheckBarcode.ClientID %>").get(0).value = 'Y';
                        document.getElementById('<%=hidResponse.ClientID %>').value = JSON.stringify(obj.value);

                        if (docID == 21) {
                            document.getElementById('<%=trresult.ClientID %>').style.display = 'block';
                            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                            var table = CastTable(obj);
                            document.getElementById('<%=trresult.ClientID %>').appendChild(table);
                            document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'block';

                        }
                        else if (docID == 32 || docID == 34) {
                            document.getElementById('<%=trresult.ClientID %>').style.display = 'block';
                            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                            var table = IncomeTable(obj);
                            document.getElementById('<%=trresult.ClientID %>').appendChild(table);
                            document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'block';
                        }
                        else if (docID == 22) {
                            document.getElementById('<%=trresult.ClientID %>').style.display = 'block';
                            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                            var table = CastValidityTable(obj);
                            document.getElementById('<%=trresult.ClientID %>').appendChild(table);
                            document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'block';
                        }
                        else if (docID == 1 || docID == 2 || docID == 11) {
                            document.getElementById('<%=trresult.ClientID %>').style.display = 'block';
                            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                            var table = AgeDomicileNationalityTable(obj);
                            document.getElementById('<%=trresult.ClientID %>').appendChild(table);
                            document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'block';
                        }
                        else if (docID == 25) {
                            document.getElementById('<%=trresult.ClientID %>').style.display = 'block';
                            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                            var table = DisabilityCertificateTable(obj);
                            document.getElementById('<%=trresult.ClientID %>').appendChild(table);
                            document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'block';
                        }
                        else if (docID == 24) {
                            document.getElementById('<%=trresult.ClientID %>').style.display = 'block';
                            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                            var table = NCLTable(obj);
                            document.getElementById('<%=trresult.ClientID %>').appendChild(table);
                            document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'block';
                        }

                    }
                    else {
                        document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                        document.getElementById('<%=trresult.ClientID %>').innerHTML += "<td colspan='3'> No Record Found with the given Barcode !</td>";
                        alert("No Record Found with the given Barcode !!");
                        $("#<%=hdnbarcode.ClientID %>").get(0).value = '';
                        $("#<%=hdncheckBarcode.ClientID %>").get(0).value = 'N';

                    }
                }
                else {
                    alert("Please Enter Barcode  !!")
                }
                document.getElementById('<%=btnFetchDocument.ClientID %>').style.display = 'block';
                document.getElementById('<%=btnwait.ClientID %>').style.display = 'none';
                return false;
            }
            function numbersonly(e) {
                var unicode = e.charCode ? e.charCode : e.keyCode
                var docID = $("#<%=hdnCurrentDocId.ClientID %>").get(0).value;
                if (unicode != 8 && docID != 22) {
                    if (unicode < 48 || unicode > 57) {
                        return false
                    }
                }
            }

            $(document).ready(function () {

                $("[id*=btnrdNo]").bind("click", function () {
                    //If the CheckBox is Checked then enable the TextBoxes in thr Row.
                    if ($(this).is(":checked")) {
                        $("#<%=hdnbarcode.ClientID %>").get(0).value = "";
                        $("#<%=hdncheckBarcode.ClientID %>").get(0).value = "N";
                        document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = 'none';
                        document.getElementById('<%=trBarcode.ClientID %>').style.display = 'none';
                        document.getElementById('<%=txtbarcode.ClientID %>').value = '';
                        document.getElementById('<%=trUploadDoc.ClientID %>').style.display = "none";
                        document.getElementById('<%=divup.ClientID %>').style.display = "revert";
                        LoadDistrictTalukaJuridicaiton($("#<%=hdnCurrentDocId.ClientID %>").get(0).value);
                        document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                        document.getElementById('<%=trresult.ClientID %>').style.display = "none";
                    } else {
                        $("#<%=hdnbarcode.ClientID %>").get(0).value = "";
                        $("#<%=hdncheckBarcode.ClientID %>").get(0).value = "N";
                        document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = "revert";
                        document.getElementById('<%=trBarcode.ClientID %>').style.display = "revert";
                        document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'none';
                        document.getElementById('<%=divup.ClientID %>').style.display = "none";
                        document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                        document.getElementById('<%=trresult.ClientID %>').style.display = "none";
                    }

                });
                $("[id*=btnrdYes]").bind("click", function () {
                    if ($(this).is(":checked")) {

                        $("#<%=hdnbarcode.ClientID %>").get(0).value = "";
                        $("#<%=hdncheckBarcode.ClientID %>").get(0).value = "N";
                        document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = "revert";
                        document.getElementById('<%=trBarcode.ClientID %>').style.display = "revert";
                        document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'none';
                        document.getElementById('<%=divup.ClientID %>').style.display = "none";
                        document.getElementById("<%=trJuridiction.ClientID %>").style.display = "none";
                        document.getElementById("<%=trDistrict.ClientID %>").style.display = "none";
                        document.getElementById("<%=trTaluka.ClientID %>").style.display = "none";
                        document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                        document.getElementById('<%=trresult.ClientID %>').style.display = "none";

                    } else {
                        $("#<%=hdnbarcode.ClientID %>").get(0).value = "";
                        $("#<%=hdncheckBarcode.ClientID %>").get(0).value = "N";
                        document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = 'none';
                        document.getElementById('<%=trBarcode.ClientID %>').style.display = 'none';
                        document.getElementById('<%=txtbarcode.ClientID %>').value = '';
                        document.getElementById('<%=trUploadDoc.ClientID %>').style.display = "revert";
                        document.getElementById('<%=divup.ClientID %>').style.display = "none";
                        document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                        document.getElementById('<%=trresult.ClientID %>').style.display = "none";
                    }

                });
                var parameter = Sys.WebForms.PageRequestManager.getInstance();

                parameter.add_endRequest(function () {
                    $("[id*=btnrdNo]").bind("click", function () {
                        //If the CheckBox is Checked then enable the TextBoxes in thr Row.
                        if ($(this).is(":checked")) {

                            $("#<%=hdnbarcode.ClientID %>").get(0).value = "";
                            $("#<%=hdncheckBarcode.ClientID %>").get(0).value = "N";
                            document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = 'none';
                            document.getElementById('<%=trBarcode.ClientID %>').style.display = 'none';
                            document.getElementById('<%=txtbarcode.ClientID %>').value = '';
                            document.getElementById('<%=trUploadDoc.ClientID %>').style.display = "none";
                            document.getElementById('<%=divup.ClientID %>').style.display = "revert";
                            LoadDistrictTalukaJuridicaiton($("#<%=hdnCurrentDocId.ClientID %>").get(0).value);
                            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                            document.getElementById('<%=trresult.ClientID %>').style.display = "none";
                        } else {
                            document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = "revert";
                            document.getElementById('<%=trBarcode.ClientID %>').style.display = "revert";
                            document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'none';
                            document.getElementById('<%=divup.ClientID %>').style.display = "none";
                            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                            document.getElementById('<%=trresult.ClientID %>').style.display = "none";
                        }
                    });
                    $("[id*=btnrdYes]").bind("click", function () {
                        if ($(this).is(":checked")) {
                            $("#<%=hdnbarcode.ClientID %>").get(0).value = "";
                            $("#<%=hdncheckBarcode.ClientID %>").get(0).value = "N";
                            document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = "revert";
                            document.getElementById('<%=trBarcode.ClientID %>').style.display = "revert";
                            document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'none';
                            document.getElementById('<%=divup.ClientID %>').style.display = "none";
                            document.getElementById("<%=trJuridiction.ClientID %>").style.display = "none";
                            document.getElementById("<%=trDistrict.ClientID %>").style.display = "none";
                            document.getElementById("<%=trTaluka.ClientID %>").style.display = "none";
                            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                            document.getElementById('<%=trresult.ClientID %>').style.display = "none";
                        } else {
                            document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = 'none';
                            document.getElementById('<%=trBarcode.ClientID %>').style.display = 'none';
                            document.getElementById('<%=trUploadDoc.ClientID %>').style.display = "revert";
                            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
                            document.getElementById('<%=trresult.ClientID %>').style.display = "none";
                        }
                    });
                });
            });
        </script>
    </ccm:ContentBox>
    <%--</ccm:ContentBox>--%>
    <table class="AppFormTableWithOutBorder">
        <%--<tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="Label1"  ForeColor="Red"></asp:Label>
                </td>
            </tr>--%>
        <tr>
            <td align="center" colspan="2" runat="server" visible="false">
                <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
            </td>
        </tr>

        <%-- <tr runat="server" id="tr1">
                <td align="center">
                    <asp:Button ID="Button1" runat="server" Text="Yes" CssClass="InputButton" OnClick="btnYes_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="Button2" runat="server" Text="No" CssClass="InputButton" OnClick="btnNo_Click" />
                </td>
            </tr>--%>
    </table>
    <script type="text/javascript">

        function closeUpload() {
            document.getElementById('<%=contentAppleSarkarBarti.ClientID %>').style.display = "none";
            //document.getElementById('<%=btnProceed.ClientID %>').style.display = "block";
            document.getElementById('<%=cntDocument.ClientID %>').style.display = "block";
        }

        function OpenTestPopup(cntrl) {
            document.getElementById('<%=btnrdYes.ClientID %>').checked = false;
            document.getElementById('<%=btnrdNo.ClientID %>').checked = false;
            document.getElementById('<%=txtbarcode.ClientID %>').value = "";
            document.getElementById('<%= txtEnterbarcode. ClientID %>').value = "";

            // var docIDarray = ["1", "2", "11", "21", "22", "25", "32", "34"];
            var docIDarray = ["10000"];
            document.getElementById('<%=trresult.ClientID %>').innerHTML = "";
            document.getElementById('<%=trresult.ClientID %>').style.display = "none";
            document.getElementById('<%=divup.ClientID %>').style.display = "none";
            document.getElementById('<%=trInstructions.ClientID %>').style.display = "none";
            //document.getElementById('<%=btnProceed.ClientID %>').style.display = "none";
            document.getElementById('<%=contentAppleSarkarBarti.ClientID %>').focus();
            var corrRow = cntrl.parentNode.parentNode;
            document.getElementById("lbldoumentuplodName").innerText = corrRow.cells[1].innerText;
            var documentId = corrRow.cells[corrRow.cells.length - 3].getElementsByTagName("input")[0].value;
            $("#<%=hdnCurrentDocId.ClientID %>").get(0).value = documentId;
            document.getElementById('<%=cntDocument.ClientID %>').style.display = 'none';
            document.getElementById('<%=contentAppleSarkarBarti.ClientID %>').style.display = 'revert';
            document.getElementById('<%=contentAppleSarkarBarti.ClientID %>').setAttribute("tabindex", 1);
            document.getElementById("<%=trJuridiction.ClientID %>").style.display = "none";
            document.getElementById("<%=trDistrict.ClientID %>").style.display = "none";
            document.getElementById("<%=trTaluka.ClientID %>").style.display = "none";
            document.getElementById('<%=trEnterBarcodeID.ClientID %>').style.display = 'none';


            if (docIDarray.includes(documentId)) {
                var docID = $("#<%=hdnCurrentDocId.ClientID %>").get(0).value;
                var categoryID = $("#<%=hdnCategoryID.ClientID %>").get(0).value;
                if (docID == 22) {
                    if ((categoryID == "3")) {
                        document.getElementById('<%=traaplesarkar.ClientID %>').style.display = 'revert';
                        document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = 'none';
                        document.getElementById('<%=txtbarcode.ClientID %>').value = '';
                        document.getElementById('<%=trBarcode.ClientID %>').style.display = 'none';
                        document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'none';
                        document.getElementById('<%=trEnterBarcodeID.ClientID %>').style.display = 'revert';
                    }
                    else if (categoryID == "2" || categoryID == "4" || categoryID == "5" || categoryID == "6" || categoryID == "7" || categoryID == "8" || categoryID == "9" || categoryID == "10") {
                        // check for BartintDocId.ClientID %>").get(0).value = documentId;
                        LoadDistrictTalukaJuridicaiton($("#<%=hdnCurrentDocId.ClientID %>").get(0).value);
                        document.getElementById('<%=traaplesarkar.ClientID %>').style.display = 'none';
                        document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = 'none';
                        document.getElementById('<%=txtbarcode.ClientID %>').value = '';
                        document.getElementById('<%=trBarcode.ClientID %>').style.display = 'none';
                        document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'none';
                        document.getElementById('<%=divup.ClientID %>').style.display = "revert";
               <%-- document.getElementById('<%=contentFileTest.ClientID %>').style.display = "block";--%>
                        document.getElementById('<%=divuploaddoc.ClientID %>').style.display = 'revert';
                        document.getElementById('<%=divuploaddoc.ClientID %>').setAttribute("tabindex", 1);
                        document.getElementById('<%=trEnterBarcodeID.ClientID %>').style.display = 'revert';
                        $("#<%=hdnCurrentDocId.ClientID %>").get(0).value = documentId;
                    }
                }
                else {
                    document.getElementById('<%=traaplesarkar.ClientID %>').style.display = 'revert';
                    document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = 'none';
                    document.getElementById('<%=txtbarcode.ClientID %>').value = '';
                    document.getElementById('<%=trBarcode.ClientID %>').style.display = 'none';
                    document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'none';
                }
            }
            else {
                LoadDistrictTalukaJuridicaiton($("#<%=hdnCurrentDocId.ClientID %>").get(0).value);
                document.getElementById('<%=traaplesarkar.ClientID %>').style.display = 'none';
                document.getElementById('<%=trDocFetchbtn.ClientID %>').style.display = 'none';
                document.getElementById('<%=txtbarcode.ClientID %>').value = '';
                document.getElementById('<%=trBarcode.ClientID %>').style.display = 'none';
                document.getElementById('<%=trUploadDoc.ClientID %>').style.display = 'none';
                document.getElementById('<%=divup.ClientID %>').style.display = "revert";
               <%-- document.getElementById('<%=contentFileTest.ClientID %>').style.display = "block";--%>
                document.getElementById('<%=divuploaddoc.ClientID %>').style.display = 'revert';
                document.getElementById('<%=divuploaddoc.ClientID %>').setAttribute("tabindex", 1);

                $("#<%=hdnCurrentDocId.ClientID %>").get(0).value = documentId;
            }
        }
        function getDistrict(JurisdictionID) {
            document.getElementById("<%=hidDID.ClientID %>").value = "45"
            var categoryID = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.getCategoryID('<%= Request["PID"] %>');
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

            var dsDistrict = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.getDistrictForJuridiction(JurisdictionID);
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
                var dsTaluka = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.getTalukaForDistrict(DistrictID);
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

        function OpenViewDocumentPopUp(cntrl) {


            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            var corrRow = cntrl.parentNode.parentNode;
            var filePath = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            var personalID = corrRow.cells[corrRow.cells.length - 2].getElementsByTagName("input")[0].value;
            var documentID = corrRow.cells[corrRow.cells.length - 3].getElementsByTagName("input")[0].value;
            var IsBarcodeFetch = corrRow.cells[corrRow.cells.length - 4].getElementsByTagName("input")[0].value;
            var byteStream = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[1].value;
            //corrRow.cells[corrRow.cells.length - 5].innerText
            if (IsBarcodeFetch == "Y") {
                var dsResponse = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.GetDocumentFetchData(personalID, documentID);
                DisplayFetchDocu(dsResponse, documentID, IsBarcodeFetch);
            }
            else {
                document.getElementById('rightContainer_contentViewDocument_trFetchDocView').style.display = 'none';
                document.getElementById('rightContainer_contentViewDocument_trFetchDocView').innerHTML = "";
            }
          <%--  if (IsBarcodeFetch == "Y") {
                var dsResponse = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.GetDocumentFetchData(personalID, documentID);
                var obj = JSON.parse(dsResponse.json);
                if (obj.value.ApplicantName != null) {
                    if (documentID == 21) {
                        document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'block';
                        document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
                        var table = CastTable(obj);
                        document.getElementById('<%=trFetchDocView.ClientID %>').appendChild(table);


                    }
                    else if (documentID == 32 || documentID == 34) {
                        document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'block';
                        document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
                        var table = IncomeTable(obj);
                        document.getElementById('<%=trFetchDocView.ClientID %>').appendChild(table);

                    }
                    else if (documentID == 22) {
                        document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'block';
                        document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
                        var table = CastValidityTable(obj);
                        document.getElementById('<%=trFetchDocView.ClientID %>').appendChild(table);
                    }
                    else if (documentID == 1 || documentID == 2 || documentID == 11) {
                        document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'block';
                        document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
                        var table = AgeDomicileNationalityTable(obj);
                        document.getElementById('<%=trFetchDocView.ClientID %>').appendChild(table);
                    }
                    else if (documentID == 25) {
                        document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'block';
                        document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
                        var table = DisabilityCertificateTable(obj);
                        document.getElementById('<%=trFetchDocView.ClientID %>').appendChild(table);
                    }
                }
            }
            else {
                document.getElementById('<%=trFetchDocView.ClientID %>').style.display = 'none';
                document.getElementById('<%=trFetchDocView.ClientID %>').innerHTML = "";
            }--%>
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
        function ShowConfirmationBox() {
            document.getElementById('<%=contentDocumentConferamtion.ClientID %>').Show('', true, 'Fullscreen = yes');
        }
        function LoadDistrictTalukaJuridicaiton(documentId) {
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

                var ds = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.FillJuridiction(documentId, '<%= Request["PID"] %>');
                var categoryID = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.getCategoryID();
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
            if (documentId == "21" || documentId == "22" || documentId == "36" || documentId == "32" || documentId == "24" || documentId == "11" || documentId == "2" || documentId == "1") {
                document.getElementById('<%=trEnterBarcodeID.ClientID %>').style.display = 'revert';
            }
            else {
                document.getElementById('<%=trEnterBarcodeID.ClientID %>').style.display = 'none';
            }
            if (documentId == "21") {
                $("[id$='hltxtEnterbarcode']").attr("href", "/SampleDocuments/CasteCertificate.JPG")
            }
            if (documentId == "22") {
                $("[id$='hltxtEnterbarcode']").attr("href", "/SampleDocuments/CasteValidity.JPG")
            }
            if (documentId == "36") {
                $("[id$='hltxtEnterbarcode']").attr("href", "/SampleDocuments/EWSCertificate.JPG")
            }
            if (documentId == "32") {
                $("[id$='hltxtEnterbarcode']").attr("href", "/SampleDocuments/IncomeCertificate.JPG")
            }
            if (documentId == "24") {
                $("[id$='hltxtEnterbarcode']").attr("href", "/SampleDocuments/NCLCertificate.JPG")
            }
            if (documentId == "1" || documentId == "2" || documentId == "11") {
                $("[id$='hltxtEnterbarcode']").attr("href", "/SampleDocuments/NationalityandDomicileCertificate.JPG")
            }
        }
    </script>
    <%--<script type="text/javascript">
        document.onmousedown = disableRightclick;
        var message = "Right click is not allowed !!";
        function disableRightclick(evt) {
            if (evt.button == 2) {
                alert(message);
                return false;
            }
        }
    </script>--%>




    <script type="text/javascript" lang="javascript">
        Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep
        function checkfrmupload() {
            var documentid = document.getElementById("<%=hdnCurrentDocId.ClientID %>").value;
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
        function OpenPOPup(cntrl) {

            document.getElementById("rightContainer_contentFileUpload_btnSaveUpload").style.display = "none";
            var corrRow = cntrl.parentNode.parentNode;
            document.getElementById("lbldoumentuplodName").innerText = corrRow.cells[1].innerText;
            var documentId = corrRow.cells[corrRow.cells.length - 3].getElementsByTagName("input")[0].value;
            document.getElementById("thumimg").src = "";
            document.getElementById("rightContainer_contentFileUpload_flUpload").value = "";
            $("#<%=hdnCurrentDocId.ClientID %>").get(0).value = documentId;
            document.getElementById("<%=trJuridiction.ClientID %>").style.display = "none";
            document.getElementById("<%=trDistrict.ClientID %>").style.display = "none";
            document.getElementById("<%=trTaluka.ClientID %>").style.display = "none";

            document.getElementById('<%=contentFileUpload.ClientID %>').Show('', true);
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

                var ds = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.FillJuridiction(documentId, '<%= Request["PID"] %>');
                var categoryID = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.getCategoryID('<%= Request["PID"] %>');
                if (ds.value.Tables[0].Rows.length > 0) {
                    for (var i = 0; i < ds.value.Tables[0].Rows.length; i++) {
                        var opt = document.createElement("option");
                        document.getElementById("<%=ddlJuridiction.ClientID %>").options.add(opt);
                        opt.text = ds.value.Tables[0].Rows[i].JurisdictionDetails;
                        opt.value = ds.value.Tables[0].Rows[i].JurisdictionID;
                    }
                    document.getElementById("<%=trJuridiction.ClientID %>").style.display = "block";

                    document.getElementById("<%=trDistrict.ClientID %>").style.display = "block";
                    var opt = document.createElement("option");
                    document.getElementById("<%=ddlDistrict.ClientID %>").options.add(opt);
                    opt.text = "-- Select District --";
                    opt.value = "0";
                }
                if (documentId == 21) {
                    document.getElementById("<%=lblJuridiction.ClientID %>").innerHTML = 'Issuing Authority';
                    document.getElementById("<%=trTaluka.ClientID %>").style.display = "block";

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
            var categoryID = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.getCategoryID();
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

            var dsDistrict = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.getDistrictForJuridiction(JurisdictionID);
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
                var dsTaluka = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.getTalukaForDistrict(DistrictID);
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
        function ViewDoc(cntrl) {
            var corrRow = cntrl.parentNode.parentNode;
            var documentName = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value.toLowerCase();
            var m = documentName.toLowerCase().indexOf(".rar"); var k = documentName.toLowerCase().indexOf(".zip")
            if (m > -1) {
                window.open(documentName);
            }
            else if (k > -1) {
                window.open(documentName);
            }
            else {
                window.open($('#<%=hdnApplicationURL.ClientID %>').val() + "viewdocument.aspx?fn=" + documentName);
            }
            return false;
        }
        function UploadFile() {
            $('#<%=hdnUploadedFileName.ClientID %>').val('');
            $('#<%=hdnUploadedFileURL.ClientID %>').val('');
            $('#<%=hdnOriginalFileName.ClientID %>').val('');
            //if (typeof FormData == "undefined") {
            //    alert("Please Use Latest Version Of Google Chrome Or Mozilla Firefox To Upload Documents");
            //    return false;
            //}
            //var data = new FormData();

            //var files = cropCtx.canvas.toDataURL("image/jpeg", 80 / 100)//$("#fileUpload").get(0).files;

            if (files.length > 0) {

                var documentID = $("#<%=hdnCurrentDocId.ClientID %>").get(0).value;
                if (documentID == "21") {
                    var ddlDistrict = document.getElementById("rightContainer_contentFileTest_ddlDistrict");
                    var ddlJuridiction = document.getElementById("rightContainer_contentFileTest_ddlJuridiction");
                    var ddlTaluka = document.getElementById("rightContainer_contentFileTest_ddlTaluka");
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
                        var message = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.UploadDoc(files, documentID, hidJUD, hidDID, hidTID, '<%= Request["PID"] %>');
                        if (message.value == "The File has been uploaded.") {
                            $('#<%=btnUploadComplete.ClientID %>').show();
                            $('#<%=btnUploadComplete.ClientID %>').click();
                        }
                        else {
                            alert(message.value);
                        }
                    }
                }
                else if (documentID == "22") {
                    var ddlDistrict = document.getElementById("rightContainer_contentFileTest_ddlDistrict");
                    var ddlJuridiction = document.getElementById("rightContainer_contentFileTest_ddlJuridiction");
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
                        var message = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.UploadDoc(files, documentID, hidJUD, hidDID, hidTID, '<%= Request["PID"] %>');
                        if (message.value == "The File has been uploaded.") {
                            $('#<%=btnUploadComplete.ClientID %>').show();
                            $('#<%=btnUploadComplete.ClientID %>').click();
                        }
                        else {
                            alert(message.value);
                        }
                    }
                }
                else {
                    var message = Pharmacy2024.AFCModule.frmUploadRequiredDocumentsStep.UploadDoc(files, documentID, hidJUD, hidDID, hidTID, '<%= Request["PID"] %>');
                    if (message.value == "The File has been uploaded.") {
                        $('#<%=btnUploadComplete.ClientID %>').show();
                        $('#<%=btnUploadComplete.ClientID %>').click();
                    }
                    else {
                        alert(message.value);
                    }
                }

                //var fileSize = files.size;
                //var maxFileSize = $('#<%= hdnMaxSize.ClientID%>').val();
                //maxFileSize = maxFileSize * 1024;
                ///var extenstion = files[0].name.split('.').pop();
                //extenstion = extenstion.toLowerCase();
                //var ind = $('#<%=hdnFileTypes.ClientID %>').val().indexOf(extenstion);
               // if (fileSize <= maxFileSize) {
                 //   if (ind != -1) {
                   //     $('#<%=hdnOriginalFileName.ClientID %>').val(files[0].name);
                     //   $('#btnUploadFile').hide();
                     <%--   data.append("UploadedImage", files);
                        data.append("Token", $('#<%=hdnToken.ClientID %>').val());
                        $('#<%=contentFileUpload.ClientID %>').hide();

                        var ajaxRequest = $.ajax({
                            type: "POST",
                            url: $('#<%=hdnFileUploadURL.ClientID %>').val(),
                            contentType: false,
                            processData: false,
                            data: data
                        });

                        ajaxRequest.done(function (data) {
                            var response = $.parseJSON(data);
                            if (response.Result == 1) {
                                $('#<%=hdnUploadedFileName.ClientID %>').val(response.FileName);
                                $('#<%=hdnUploadedFileURL.ClientID %>').val(response.FileURL);
                                $('#<%=btnSaveUpload.ClientID %>').click();
                            }
                            else {
                                alert('Error Occured:' + response.Message);
                                document.getElementById('<%=contentFileUpload.ClientID %>').Hide();
                                //$('#btnUploadFile').show();
                            }
                        });

                        ajaxRequest.error(function (xhr, status) {
                            console.log(xhr);
                            console.log(status);
                            document.getElementById('<%=contentFileUpload.ClientID %>').Hide();
                            alert('Upload failed, try again later');
                            //$('#btnUploadFile').show();
                        });--%>
                    <%--}
                    else {
                        alert('Allowed File Types Are ' + $('#<%= hdnFileTypes.ClientID%>').val());
                    }--%>
                //}
                //else {
                 //   alert('Maximum File Size Allowed Is ' + $('#<%= hdnMaxSize.ClientID%>').val() + ' KB');
                //}
            }
            else {
                alert("Please Select File");
            }
        }

        $body = $("body");
        $(document).on({
            ajaxStart: function () { $body.addClass("loading"); },
            ajaxStop: function () { $body.removeClass("loading"); }
        });
    </script>
</asp:Content>
