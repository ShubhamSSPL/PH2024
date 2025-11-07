<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" EnableEventValidation="False" CodeBehind="frmUploadRequiredDocuments.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmUploadRequiredDocuments" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        /* #rightContainer_contentViewDocument{
            top:12% !important;
        }
        .doc-container{
            height:24rem;
        }*/
    </style>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
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
    <script type="text/javascript">
        function ShowPopup(cntrl) {
            var corrRow = cntrl.parentNode.parentNode;
            var documentId = corrRow.getElementsByTagName("input")[1].value;
            window.open("../ViewMyDocument.aspx?documentID=" + documentId, "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes,");
        }
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
    </style>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" />
    <script type="text/javascript">        jQuery.noConflict();</script>
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
    <ccm:contentbox id="cntDocument" headertext="Upload Required Documents" runat="server">
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
        <asp:HiddenField ID="hdnToken" runat="server" />
         <asp:HiddenField ID="hdnApplicationURL" runat="server" />
        <table class="AppFormTable">
            <tr>
                <td colspan="2">
                    <font color = "red">
                        <b>Instructions</b> :
                        <br /><br />
                        <ul class="list-text">
                            <li><p align = "justify"><font color = "red">Please Use Latest Version Of <b>Google Chrome</b> or <b>Mozilla Firefox</b> To Upload Documents.</font></p></li>
                        </ul>
                    </font>
                </td>
            </tr>
            <tr>
                <td style="width:40%" align="right">File Types Allowed</td>
                <td style="width:60%"><b><asp:Label ID="lblFileTypesAllowed" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
                <td align="right">Maximum File Size Allowed</td>
                <td><b><asp:Label ID="lblMaxFileSize" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" BorderWidth="1" OnRowCommand="gvDocuments_RowCommand" EnableModelValidation="True"
                    onrowdatabound="gvDocuments_RowDataBound">
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
                                    <asp:Image ID="btnUpload" runat="server" AlternateText="Upload" ImageUrl="~/Images/ic_file_upload_black_48dp_2x.png" onclick="return OpenPOPup(this);" Style="cursor: pointer;color: #757575;" ToolTip="Upload" Visible='<%# Eval("FilePath").ToString()==""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>                                
                                  <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                  <img src="" id="imgDoc" Style="cursor: pointer; max-width: 40px" onclick="javascript:OpenViewDocumentPopUp(this)" runat="server" />
                                  <asp:HiddenField ID="hidFURL" runat="server" Value="<%# Bind('FilePath') %>" />
                                   <asp:HiddenField ID="hidDID" runat="server" Value="<%# Bind('DocumentTransID') %>" />
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
                    <br />
                    <p align="justify">
                        <b><u>Certificate of the Indian Nationality</u> :-</b>
                        <br /><br />
                        The certificate of Indian Nationality, which is usually issued by the Tahshildar/Executive Magistrate/Dy. Collector of the concerned Taluka/District wherein the candidate ordinarily resides. In lieu of the <b>"Certificate of Indian Nationality"</b> any one of the following certificate will also be acceptable -
                        <br />
                        <ul class="list-text">
                            <li>The School leaving Certificate indicating the Nationality of the candidate as 'Indian'.</li>
                            <%--<li>Indian Passport in the name of the candidate, issued by appropriate authorities.</li>--%>
                            <li>Birth Certificate of the Candidate indicating the place of birth in India.</li>
                        </ul>
                    </p>
                    <p align="justify">
                        <br /><br />
                        <b><u>Domicile certificate</u> :-</b>
                        <br /><br />
                        Domicile certificate issued by the Maharashtra State’s appropriate authorities will be considered valid. The domicile certificate of Mother of the candidate shall be supported with marriage certificate and legal proof of change in name if any. Such candidates will be required to submit birth certificate clearly mentioning the name of the mother.
                    </p>
                    <p align="justify">
                        <br /><br />
                        <b><u>Caste/Tribe Validity Certificate</u> :-</b>
                        <br /><br />
                        The candidates belonging to <b><i>SC, ST, VJ/DT (NT(A)), NT(B), NT(C), NT(D), SBC and OBC</i></b> categories should produce <b>"Caste/Tribe Validity Certificate"</b> issued by Scrutiny Committee of Social Welfare Department/Tribal Department at <b><u>the time of submission</u></b> of CAP application form for the Admission. (If the candidate not having the validity certificate, the policy of Social Justice & Welfare and Tribal Development Department shall be implemented and the documents to be submitted accordingly will be notified on the website.) 
                    </p>
                    <p align="justify">
                        <br /><br />
                        <b><u>Non-Creamy Layer Certificate</u> :-</b>
                        <br /><br />
                        A candidate belonging to ‘Creamy Layer’ amongst the categories VJ/DT-NT(A), NT(B), NT(C), NT(D), SBC, OBC and SEBC must note that the provision of reservation is NOT applicable to him/her. A candidate claiming benefit of reservation under the categories VJ/DT-NT(A), NT(B), NT(C), NT(D), SBC, OBC and SEBC above will be required to produce <b>"Non-Creamy Layer Certificate"</b> in the name of the candidate as specified in the <b>Government Resolution No. CBC-10/2008/C.R.697/BCW-5</b>, dated 27th February 2009 or its updated version from time to time. <b>This certificate should be valid up to 31st March <%=NextYear%>.</b> <%--However, such a Non-Creamy Layer Certificate shall be produced in any case on or before the last date of filling up of Application Form for Admission to Engineering/Technology, failing which the category claim, will not be granted.--%>
                    </p>
                    <br />
                </td>
            </tr>
        </table>
    </ccm:contentbox>
    <ccm:contentbox id="contentFileUpload" runat="server" headertext="Upload File" boxtype="PopupBox" width="40%">
            <table class="AppFormTable">
             <tr>
                 <td style="width: 25%;" align="right">Document Name :</td>
                <td align="left" colspan="2">
                    <b><label id="lbldoumentuplodName"></label></b>
                </td>
            </tr>
            <tr>
                <td style="width:25%;" align="right">Select Document</td>
                <td style="width:50%;"><asp:FileUpload runat="server" ID="flUpload" /> 
                    <input id="fileUpload" runat="server" type="file" style="display:none" />
                </td>
                <td style="width:25%;"><img style="max-width:80px" src="~/img/staff.png" class="" id="thumimg" alt=""></td>
            </tr>
        </table>
        <table class="AppFormTable">
                    <tr id="trJuridiction" runat="server" style="display: none">
                        <td style="width: 24%;" align="right">
                            <asp:Label ID="lblJuridiction" runat="server">Jurisdiction</asp:Label>
                        </td>
                        <td colspan="2" style="width: 75%;">
                            <asp:DropDownList ID="ddlJuridiction" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Juridiction.')"
                                onmouseout="hideddrivetip()" onchange="getDistrict(this.value)">
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                           <%-- <asp:CompareValidator ID="cvJuridiction" runat="server" ControlToValidate="ddlJuridiction"
                                Display="None" ErrorMessage="Please Select Juridiction." Operator="NotEqual"
                                ValueToCompare="0"></asp:CompareValidator>--%>
                        </td>
                        <td style="border-left:none;"></td>
                    </tr>
                    <tr id="trDistrict" runat="server" style="display: none">
                        <td align="right" style="width: 24%;" >
                            <asp:Label ID="lblDistrict" runat="server">District</asp:Label>
                        </td>
                        <td colspan="2" style="width: 75%;" >
                        
                            <asp:DropDownList ID="ddlDistrict" runat="server" Width="90%" onmouseover="ddrivetip('Please Select District.')"
                                onmouseout="hideddrivetip()" onchange="getTaluka(this.value)">
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                           <%-- <asp:CompareValidator ID="cvDistrict" runat="server" ControlToValidate="ddlDistrict"
                                Display="None" ErrorMessage="Please Select District." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
                        </td>
                        <td style="border-left:none;"></td>
                    </tr>
                    <tr id="trTaluka" runat="server" style="display: none">
                        <td align="right" style="width: 24%;" >
                            <asp:Label ID="lblTaluka" runat="server">Taluka</asp:Label>
                        </td>
                        <td colspan="2" style="width: 275%;" >
                            <asp:DropDownList ID="ddlTaluka" runat="server" Width="90%" onmouseover="ddrivetip('Please Select Taluka.')"
                                onmouseout="hideddrivetip()">
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                          <%--  <asp:CompareValidator ID="cvTaluka" runat="server" ControlToValidate="ddlTaluka"
                                Display="None" ErrorMessage="Please Select Taluka." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
                        </td>
                        <td style="border-left:none;"></td>
                    </tr>
                </table>
        <table class="AppFormTable">
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="btnSaveUpload"  OnClientClick="return checkfrmupload('22');" runat="server" CssClass="InputButtonRed" Style="display: none"
                                Text="Upload" OnClick="btnSaveUpload_Click" />
                                <input type="hidden" runat="server" id="hidDID" />
                                <input type="hidden" runat="server" id="hidJUD" /><input type="hidden" runat="server" id="hidTID" />
                                <input type="hidden" runat="server" id="hidPID" />
                         <%--   <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                ShowMessageBox="True" />--%>
                            <%--     <input id="btnUploadFile" type="button" onclick="UploadFile();" value="Upload File"
                        class="InputButton" style="display: none" />--%>
                        </td>
                    </tr>
                </table>
        <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
    </ccm:contentbox>
     <div class="modal"></div>
  <ccm:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%">
           <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
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
            //corrRow.cells[corrRow.cells.length - 5].innerText

            //document.getElementById('lblDocumentName').innerHTML = corrRow.cells[corrRow.cells.length - 5].innerText;
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
        AFCModule_frmUploadRequiredDocuments
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
            document.getElementById("<%=hidPID.ClientID %>").value = '<%= Request["PID"] %>';
            document.getElementById("rightContainer_contentFileUpload_btnSaveUpload").style.display = "none";
            var corrRow = cntrl.parentNode.parentNode;
            var documentId = corrRow.cells[corrRow.cells.length - 2].getElementsByTagName("input")[0].value;
            document.getElementById("lbldoumentuplodName").innerText = corrRow.cells[1].innerText;
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
                var ds = Pharmacy2024.AFCModule.frmUploadRequiredDocuments.FillJuridiction(documentId, '<%= Request["PID"] %>');
                var categoryID = Pharmacy2024.AFCModule.frmUploadRequiredDocuments.getCategoryID('<%= Request["PID"] %>');
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
            //return false;

            // return checkfrmupload(documentId);
        }

        function getDistrict(JurisdictionID) {
            document.getElementById('rightContainer_contentFileUpload_hidDID').value = "45"
            var categoryID = Pharmacy2024.AFCModule.frmUploadRequiredDocuments.getCategoryID('<%= Request["PID"] %>');
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

            var dsDistrict = Pharmacy2024.AFCModule.frmUploadRequiredDocuments.getDistrictForJuridiction(JurisdictionID);
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
                var dsTaluka = Pharmacy2024.AFCModule.frmUploadRequiredDocuments.getTalukaForDistrict(DistrictID);
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
