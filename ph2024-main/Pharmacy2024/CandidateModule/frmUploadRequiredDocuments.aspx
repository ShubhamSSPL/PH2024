<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmUploadRequiredDocuments.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmUploadRequiredDocuments" EnableEventValidation="false" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/blitzer/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="
        crossorigin="anonymous"></script>
    <script type="text/javascript">
        function ShowPopup(cntrl) {
            var corrRow = cntrl.parentNode.parentNode;
            var documentId = corrRow.cells[corrRow.cells.length - 4].getElementsByTagName("input")[1].value;
            window.open("../ViewMyDocument.aspx?documentID=" + documentId, "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes,");
        }
    </script>
    <script>
        $(document).ready(function () {

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
                    if (parseFloat(KB) < 500) {

                        document.getElementById("rightContainer_contentFileUpload_btnSaveUpload").style.display = "block";

                        var files = !!this.files ? this.files : [];
                        var reader = new FileReader(); // instance of the FileReader
                        reader.readAsDataURL(files[0]); // read the local file

                        reader.onload = function (e) {
                            document.getElementById("thumimg").src = e.target.result;
                        };
                        // read the image file as a data URL.
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
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <style>
       /* #rightContainer_contentFileUpload_ContentBoxOverlayTwo, #rightContainer_contentViewDocument_ContentBoxOverlayTwo {
            position: fixed !important;
            height: 100% !important;
        }

        #rightContainer_contentFileUpload, #rightContainer_contentViewDocument {
            
            top: auto !important;
            margin-top: -95%;
        }


        #rightContainer_contentFileUpload_flUpload {
            padding-bottom: 36px;
            width: 100% !important
        }

        .InnerBodyDiv, .modal-body {
            height: auto !important;
        }
        .doc-container{
            height:300px !important;
        }
           @media only screen and (min-width: 1024px) {
           #rightContainer_contentFileUpload, #rightContainer_contentViewDocument {
         
            margin-top: -150%;
        }
        }
          @media only screen and (min-width: 1360px) {
           #rightContainer_contentFileUpload, #rightContainer_contentViewDocument {
         
            margin-top: -95%;
        }
        }
            @media only screen and (min-width: 1400px) {
           #rightContainer_contentFileUpload, #rightContainer_contentViewDocument {
         
            margin-top: -85%;
        }
        }
          @media only screen and (min-width: 1600px) {
           #rightContainer_contentFileUpload, #rightContainer_contentViewDocument {
         
            margin-top: -60%;
        }
        }
               @media only screen and (min-width: 1920px) {
           #rightContainer_contentFileUpload, #rightContainer_contentViewDocument {
         
            margin-top: -49%;
        }
        }
        @media only screen and (max-width: 768px) {
            #rightContainer_contentFileUpload {
                left: 0px !important;
                width: 100% !important;
                bottom: 150px;
                margin-top: 0%;
            }
            #rightContainer_contentViewDocument{
                   left: 0px !important;
                width: 100% !important;
                bottom: 0px;
                margin-top: 0%;
            }
             .doc-container{
            height:200px !important;
        }
              .InnerBodyDiv{
            height:auto!important;
            overflow: hidden;
        }
             #lblDocumentName{
                 width:75%;
             }

        }

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

        p {
            font-size: 14px;
        }*/
    </style>
    <%-- <style>
        .pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .doc-container {
            height: 25rem;
            border: 1rem solid rgba(0,0,0,.1);
        }
    </style>--%>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" />
    <script type="text/javascript">        jQuery.noConflict();</script>
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
                <td colspan="2">
                    <font color="red">
                        <p align="justify">
                            <font color="red"><b>Instructions :</b></font></p>
                        <ul class="list-text">
                            <li>
                                <p align="justify">
                                    <font color="red">Please Use Latest Version Of <b>Google Chrome</b> or <b>Mozilla Firefox</b>
                                        To Upload Documents.</font></p>
                            </li>
                        </ul>
                    </font>
                </td>
            </tr>
            <tr>
                <td style="width: 40%" align="right">File Types Allowed
                </td>
                <td style="width: 60%">
                    <b>
                        <asp:Label ID="lblFileTypesAllowed" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td align="right">Maximum File Size Allowed
                </td>
                <td>
                    <b>
                        <asp:Label ID="lblMaxFileSize" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" CssClass="DataGrid"
                        BorderWidth="1" OnRowCommand="gvDocuments_RowCommand" EnableModelValidation="True"
                        Width="100%" OnRowDataBound="gvDocuments_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" ItemStyle-Wrap="true"
                                HtmlEncode="False">
                                <ItemStyle Width="67%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UploadStatus" HeaderText="Upload Status">
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Upload">
                                <ItemTemplate>
                                    <asp:Image ID="btnUpload" runat="server" AlternateText="Upload" ImageUrl="~/Images/ic_file_upload_black_48dp_2x.png"
                                        onclick="return OpenPOPup(this);" Style="cursor: pointer; color: #757575;" ToolTip="Upload"
                                        Visible='<%# Eval("FilePath").ToString()==""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                    <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" runat="server" onclick="javascript:OpenViewDocumentPopUp(this)" />
                                    <asp:HiddenField ID="hidFURL" runat="server" Value='<%# Eval("FilePath") %>' />
                                    <asp:HiddenField ID="hidDID" runat="server" Value='<%# Eval("DocumentTransID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btndelete" runat="server" CommandArgument='<%# Bind("DocumentId") %>'
                                        CommandName="D" ImageUrl="~/Images/icon-delete.png" ToolTip="Edit" OnClientClick="return confirm('Your previously uploaded document will be deleted and you will have to upload a fresh one. Do you want to continue?');"
                                        Visible='<%# Eval("FilePath").ToString()!=""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
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
            <tr>
                <td colspan="2">
                    <div class=" border-box">
                        <p align="justify">
                            <b><u>Certificate of the Indian Nationality</u> :-</b>
                            <br />
                            The certificate of Indian Nationality, which is usually issued by the Tahshildar/Executive
                        Magistrate/Dy. Collector of the concerned Taluka/District wherein the candidate
                        ordinarily resides. In lieu of the <b>"Certificate of Indian Nationality"</b> any
                        one of the following certificate will also be acceptable -
                        <br />
                            <ul class="" style="margin-left: 23px;">
                                <li>The School leaving Certificate indicating the Nationality of the candidate as 'Indian'.</li>
                                <%--<li>Indian Passport in the name of the candidate, issued by appropriate authorities.</li>--%>
                                <li>Birth Certificate of the Candidate indicating the place of birth in India.</li>
                            </ul>
                            <br />
                            <p align="justify">
                                <b><u>Domicile certificate</u> :-</b>
                                <br />
                                Domicile certificate issued by the Maharashtra State’s appropriate authorities will
                            be considered valid. The domicile certificate of Mother of the candidate shall be
                            supported with marriage certificate and legal proof of change in name if any. Such
                            candidates will be required to submit birth certificate clearly mentioning the name
                            of the mother.
                            </p>
                            <br />
                            <p align="justify">
                                <b><u>Caste/Tribe Validity Certificate</u> :-</b>
                                <br />
                                The candidates belonging to <b><i>SC, ST, VJ/DT (NT(A)), NT(B), NT(C), NT(D), SBC and OBC</i></b> categories should produce <b>&quot;Caste/Tribe Validity Certificate&quot;</b>
                                issued by Scrutiny Committee of Social Welfare Department/Tribal Department at <b><u>the time of submission</u></b> of CAP application form for the Admission. (If
                            the candidate not having the validity certificate, the policy of Social Justice
                            &amp; Welfare and Tribal Development Department shall be implemented and the documents
                            to be submitted accordingly will be notified on the website.)
                            </p>
                            <br />
                            <p align="justify">
                                <b><u>Non-Creamy Layer Certificate</u> :-</b>
                                <br />
                                A candidate belonging to ‘Creamy Layer’ amongst the categories VJ/DT-NT(A), NT(B),
                            NT(C), NT(D), SBC, OBC and SEBC must note that the provision of reservation is NOT applicable
                            to him/her. A candidate claiming benefit of reservation under the categories VJ/DT-NT(A),
                            NT(B), NT(C), NT(D), SBC, OBC and SEBC above will be required to produce <b>&quot;Non-Creamy
                                Layer Certificate&quot;</b> in the name of the candidate as specified in the
                            <b>Government Resolution No. CBC-10/2008/C.R.697/BCW-5</b>, dated 27th February
                            2009 or its updated version from time to time. <b>This certificate should be valid up
                                to 31st March <%=NextYear%>.</b> However, such a Non-Creamy Layer Certificate shall be
                            produced in any case on or before the last date of filling up of Application Form
                            for Admission to Engineering/Technology, failing which the category claim, will
                            not be granted.
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                            </p>
                        </p>
                    </div>
                </td>
            </tr>
        </table>
    </ccm:ContentBox>
    <ccm:ContentBox ID="contentFileUpload" runat="server" HeaderText="Upload File" BoxType="PopupBox" Width="70%">
        <table class="AppFormTable">
            <tr>
                <td style="width: 25%;" align="right">Select Document
                </td>
                <td style="width: 50%;">
                    <asp:FileUpload runat="server" ID="flUpload" />
                    <input id="fileUpload" runat="server" type="file" style="display: none" />
                </td>
                <td style="width: 25%;">
                    <img style="max-width: 80px" src="" class="" id="thumimg" alt="">
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr id="trJuridiction" runat="server" style="display: none">
                <td style="width: 25.4%;" align="right">
                    <asp:Label ID="lblJuridiction" runat="server">Jurisdiction</asp:Label>
                </td>
                <td style="width: 75%;" colspan="2">
                    <asp:DropDownList ID="ddlJuridiction" runat="server" Width="90%" onchange="getDistrict(this.value)">
                    </asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <%--<asp:CompareValidator ID="cvJuridiction" runat="server" ControlToValidate="ddlJuridiction" Display="None" ErrorMessage="Please Select Juridiction." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
                </td>
                <td style="border-left: none;"></td>
            </tr>
            <tr id="trDistrict" runat="server" style="display: none">
                <td style="width: 25.4%;" align="right">
                    <asp:Label ID="lblDistrict" runat="server">District</asp:Label>
                </td>
                <td style="width: 75%;" colspan="2">
                    <asp:DropDownList ID="ddlDistrict" runat="server" Width="90%" onchange="getTaluka(this.value)">
                    </asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <%--<asp:CompareValidator ID="cvDistrict" runat="server" ControlToValidate="ddlDistrict" Display="None" ErrorMessage="Please Select District." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
                </td>
                <td style="border-left: none;"></td>
            </tr>
            <tr id="trTaluka" runat="server" style="display: none">
                <td style="width: 25.4%;" align="right">
                    <asp:Label ID="lblTaluka" runat="server">Taluka</asp:Label>
                </td>
                <td style="width: 75%;" colspan="2">
                    <asp:DropDownList ID="ddlTaluka" runat="server" Width="90%">
                    </asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <%--<asp:CompareValidator ID="cvTaluka" runat="server" ControlToValidate="ddlTaluka" Display="None" ErrorMessage="Please Select Taluka." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
                </td>
                <td style="border-left: none;"></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="btnSaveUpload" OnClientClick="return checkfrmupload();" runat="server"
                        CssClass="InputButtonRed" Style="display: none" Text="Upload" OnClick="btnSaveUpload_Click" />
                    <input type="hidden" runat="server" id="hidDID" />
                    <input type="hidden" runat="server" id="hidJUD" /><input type="hidden" runat="server"
                        id="hidTID" />
                    <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />--%>
                    <%--<input id="btnUploadFile" type="button" onclick="UploadFile();" value="Upload File" class="InputButton" style="display: none" />--%>
                </td>
            </tr>
        </table>
        <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
    </ccm:ContentBox>
    <div class="modal">
    </div>
    <ccm:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%">
       <div class="table-responsive">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr>
                <td>
                    <div class="modal-body p-0" >
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
    <script type="text/javascript">

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
           var byteStream = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[1].value;
           document.getElementById('lblDocumentName').innerHTML = corrRow.cells[1].innerText;
           switch (extension) {
               case 'jpg':
               case 'png':
               case 'gif':
               case 'jpeg':
               case 'bmp':
                   document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                   document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + byteStream + '">';
                    document.getElementById('divDocument').style.overflow = "scroll";
                    break;
                case 'zip':
                case 'rar':
                   document.getElementById('divDocument').innerHTML = '<iframe src="' + byteStream + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                   document.getElementById('divDocument').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }

    </script>
    <script type="text/javascript" language="javascript">

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
            var documentId = corrRow.cells[corrRow.cells.length - 2].getElementsByTagName("input")[0].value;
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

                var ds = Pharmacy2024.CandidateModule.frmUploadRequiredDocuments.FillJuridiction(documentId);
                var categoryID = Pharmacy2024.CandidateModule.frmUploadRequiredDocuments.getCategoryID();
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
                    document.getElementById("rightContainer_contentFileUpload_lblJuridiction").innerHTML = 'Issuing Authority';
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
            //return false;

            // return checkfrmupload(documentId);
        }

        function getDistrict(JurisdictionID) {
            document.getElementById('rightContainer_contentFileUpload_hidDID').value = "45"
            var categoryID = Pharmacy2024.CandidateModule.frmUploadRequiredDocuments.getCategoryID();
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

            var dsDistrict = Pharmacy2024.CandidateModule.frmUploadRequiredDocuments.getDistrictForJuridiction(JurisdictionID);
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
                var dsTaluka = Pharmacy2024.CandidateModule.frmUploadRequiredDocuments.getTalukaForDistrict(DistrictID);
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
            var documentName = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            //window.open(documentName,"pdf");
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
            if (typeof FormData == "undefined") {
                alert("Please Use Latest Version Of Google Chrome Or Mozilla Firefox To Upload Documents");
                return false;
            }
            var data = new FormData();

            var files = $("#fileUpload").get(0).files;

            if (files.length > 0) {

                var fileSize = files[0].size;
                var maxFileSize = $('#<%= hdnMaxSize.ClientID%>').val();
                maxFileSize = maxFileSize * 1024;
                var extenstion = files[0].name.split('.').pop();
                extenstion = extenstion.toLowerCase();
                var ind = $('#<%=hdnFileTypes.ClientID %>').val().indexOf(extenstion);
                if (fileSize <= maxFileSize) {
                    if (ind != -1) {

                        //                       

                        $('#<%=hdnOriginalFileName.ClientID %>').val(files[0].name);
                        $('#btnUploadFile').hide();
                        data.append("UploadedImage", files[0]);
                        data.append("Token", $('#<%=hdnToken.ClientID %>').val());
                        $('#<%=contentFileUpload.ClientID %>').hide();

                        var ajaxRequest = $.ajax({
                            type: "POST",
                            url: $('#<%=hdnFileUploadURL.ClientID %>').val(),
                            contentType: false,
                            processData: false,
                            data: data
                        });
                        // If one file has been selected in the HTML file input element
                        //                        var blobUri = $('#<%=hdnFileUploadURL.ClientID%>').val();
                        //                        var blobService = AzureStorage.Blob.createBlobServiceWithSas(blobUri, $('#<%=hdnToken.ClientID %>').val());
                        //                        var file = document.getElementById('fileinput').files[0];

                        //                        var customBlockSize = fileSize > 1024 * 1024 * 32 ? 1024 * 1024 * 4 : 1024 * 512;
                        //                        blobService.singleBlobPutThresholdInBytes = customBlockSize;

                        //                        var finishedOrError = false;
                        //                        blobService.createContainerIfNotExists('mycontainer', function (error, result) {
                        //                            if (error) {
                        //                                alert('Error Occured:' + error);
                        //                            } else {
                        //                                alert('Container Created mycontainer');
                        //                            }
                        //                        });
                        //                        var speedSummary = blobService.createBlockBlobFromBrowserFile('mycontainer', files.name, files, { blockSize: customBlockSize }, function (error, result, response) {
                        //                            finishedOrError = true;
                        //                            if (error) {
                        //                                // Upload blob failed
                        //                                alert('Error Occured:' + error);
                        //                                document.getElementById('<%=contentFileUpload.ClientID %>').Hide();
                        //                                $('#btnUploadFile').show();
                        //                            } else {
                        //                                $('#<%=hdnUploadedFileName.ClientID %>').val(response.FileName);
                        //                                $('#<%=hdnUploadedFileURL.ClientID %>').val(response.FileURL);
                        //                                $('#<%=btnSaveUpload.ClientID %>').click();
                        //                            }
                        //                        });
                        //                        refreshProgress();
                        //                        speedSummary.on('progress', function () {
                        //                            var process = speedSummary.getCompletePercent();
                        //                            displayProcess(process);
                        //                        });
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
                                $('#btnUploadFile').show();
                            }
                        });

                        ajaxRequest.error(function (xhr, status) {
                            console.log(xhr);
                            console.log(status);
                            document.getElementById('<%=contentFileUpload.ClientID %>').Hide();
                            alert('Upload failed, try again later');
                            $('#btnUploadFile').show();
                        });
                    }
                    else {
                        alert('Allowed File Types Are ' + $('#<%= hdnFileTypes.ClientID%>').val());
                    }
                }
                else {
                    alert('Maximum File Size Allowed Is ' + $('#<%= hdnMaxSize.ClientID%>').val() + ' KB');
                }
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

