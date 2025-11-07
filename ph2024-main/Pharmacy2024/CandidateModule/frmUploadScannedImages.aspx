<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmUploadScannedImages.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmUploadScannedImages" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/HintBox.js" type="text/javascript" lang="javascript"></script>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
    <%--    <link href="../JCropJsCss/jquery.Jcorp.css" rel="stylesheet" />
    <script type="text/javascript" src="../JCropJsCss/jquery.min.js"></script>
    <script type="text/javascript" src="../JCropJsCss/jquery.Jcrop.js"></script>--%>
    <style>
        * {
            margin: 0;
        }

        html, body {
            height: 100%;
        }

        .wrapper {
            /*width: 100% !important;*/
            width: 437px;
            height: auto !important;
            margin: 0 auto -20px;
            background-color: gray;
        }

        .push {
            height: 50px;
        }

        .tbl {
            display: table;
            width: 100%;
           
            /*background-color: #E9F7F9;*/
        }
        #idMenu{
          /*  background-color: #bc487e;*/
           background: var(--bgHead);
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
            vertical-align: top;
        }

        button {
            border: 0px;
            width: 100%;
            min-height: 35px;
            cursor: pointer;
        }
        /*.left-area{
            width:18%;
        }*/
    </style>
    <script src="../Scripts/mcfCrop.js"></script>
    <%--    <script type="text/javascript">
        //        $(function () {
        //            $('#filePhotograph').change();

        //            $('#btnCrop').click(function () {
        //                getCrop();
        //            });
        //        });

        // -- SECTION FOR PHOTO
        function onFileUploadChange() {

            if (validate()) {

                $('[id*=divCropping]').show();
                $('[id*=btnProceed]').hide();
                $('#Image1').hide();

                var reader = new FileReader();
                reader.onload = function (e) {
                    var jcrop_api;
                    var bounds, boundx, boundy;

                    $('#Image1').show();
                    $('#Image1').attr("src", e.target.result);
                    $('#preview').attr("src", e.target.result);

                    // destroy Jcrop if it is existed
                    if (typeof jcrop_api != 'undefined') {
                        jcrop_api.destroy();
                        jcrop_api = null;
                        $('#preview').css({
                            width: Math.round(rx * boundx) + 'px',
                            height: Math.round(ry * boundy) + 'px',
                            marginLeft: '-' + Math.round(rx * coords.x) + 'px',
                            marginTop: '-' + Math.round(ry * coords.y) + 'px'
                        });
                    }

                    $('#Image1').Jcrop({
                        onChange: showPreview,
                        onSelect: showPreview,
                        setSelect: [25, 20, 200, 250],
                        aspectRatio: 200 / 250,
                        allowResize: true
                    }, function () {
                        jcrop_api = this;
                        bounds = jcrop_api.getBounds();
                        boundx = bounds[0];
                        boundy = bounds[1];
                    });

                    function showPreview(coords) {
                        if (parseInt(coords.w) > 0) {
                            //$('#btnCrop').show();
                            var rx = 200 / coords.w;
                            var ry = 250 / coords.h;

                            $('#preview').css({
                                width: Math.round(rx * boundx) + 'px',
                                height: Math.round(ry * boundy) + 'px',
                                marginLeft: '-' + Math.round(rx * coords.x) + 'px',
                                marginTop: '-' + Math.round(ry * coords.y) + 'px'
                            });

                            SetCoordinates(coords);
                        }
                    };
                }
                reader.readAsDataURL($('#photoFile')[0].files[0]);
                $("#photoFile")[0].value = '';
                clearCrop();
            }
        }
        function clearCrop() {
            var JcropAPI = $('#Image1').data('Jcrop');
            if (JcropAPI != null) {
                JcropAPI.destroy();
            }
        }
        function getCroppedImage() {
            if (document.getElementById('<%= imgPhotograph.ClientID %>') != null)
                document.getElementById('<%= imgPhotograph.ClientID %>').style.display = "none";
            getCrop();
            $('[id*=divCropping]').hide();
        }

        function getCrop() {
            var x1 = $('#imgX1').val();
            var y1 = $('#imgY1').val();
            var width = $('#imgWidth').val();
            var height = $('#imgHeight').val();
            var canvas = $("#canvas")[0];
            var context = canvas.getContext('2d');
            var img = new Image();
            img.onload = function () {
                canvas.height = height;
                canvas.width = width;
                context.drawImage(img, x1, y1, width, height, 0, 0, width, height);
                $('#imgCropped').val(canvas.toDataURL());
                $('[id*=btnUpload]').show();
            };
            img.src = $('#Image1').attr("src");

            clearCrop();
        };

        function SetCoordinates(c) {
            $('#imgX1').val(c.x);
            $('#imgY1').val(c.y);
            $('#imgWidth').val(c.w);
            $('#imgHeight').val(c.h);
            $('#btnCrop').show();
            $('[id*=btnUpload]').hide();
        };
        //-- END of PHOTO SECTION

        // -- SECTION FOR SIGN
        function onFileUploadChangeSign() {

            if (validateSign()) {

                $('[id*=divCroppingSign]').show();
                $('[id*=btnProceed]').hide();
                $('#Image1Sign').hide();

                var reader = new FileReader();
                reader.onload = function (e) {
                    var jcrop_api;
                    var bounds, boundx, boundy;

                    $('#Image1Sign').show();
                    $('#Image1Sign').attr("src", e.target.result);
                    $('#previewSign').attr("src", e.target.result);

                    // destroy Jcrop if it is existed
                    if (typeof jcrop_api != 'undefined') {
                        jcrop_api.destroy();
                        jcrop_api = null;
                        $('#previewSign').css({
                            width: Math.round(rx * boundx) + 'px',
                            height: Math.round(ry * boundy) + 'px',
                            marginLeft: '-' + Math.round(rx * coords.x) + 'px',
                            marginTop: '-' + Math.round(ry * coords.y) + 'px'
                        });
                    }

                    $('#Image1Sign').Jcrop({
                        onChange: showPreviewSign,
                        onSelect: showPreviewSign,
                        setSelect: [25, 20, 200, 250],
                        //aspectRatio: 200 / 250,
                        allowResize: true
                    }, function () {
                        jcrop_api = this;
                        bounds = jcrop_api.getBounds();
                        boundx = bounds[0];
                        boundy = bounds[1];
                    });

                    function showPreviewSign(coords) {
                        if (parseInt(coords.w) > 0) {
                            //$('#btnCrop').show();
                            var rx = 200 / coords.w;
                            var ry = 250 / coords.h;

                            $('#previewSign').css({
                                width: Math.round(rx * boundx) + 'px',
                                height: Math.round(ry * boundy) + 'px',
                                marginLeft: '-' + Math.round(rx * coords.x) + 'px',
                                marginTop: '-' + Math.round(ry * coords.y) + 'px'
                            });

                            SetCoordinatesSign(coords);
                        }
                    };
                }
                reader.readAsDataURL($('#signFile')[0].files[0]);
                $("#signFile")[0].value = '';
                clearCropSign();
            }
        }
        function clearCropSign() {
            var JcropAPI = $('#Image1Sign').data('Jcrop');
            if (JcropAPI != null) {
                JcropAPI.destroy();
            }
        }
        function getCroppedImageSign() {
            if (document.getElementById('<%= imgSignature.ClientID %>') != null)
                document.getElementById('<%= imgSignature.ClientID %>').style.display = "none";
            getCropSign();
            $('[id*=divCroppingSign]').hide();
        }

        function getCropSign() {
            var x1 = $('#imgSignX1').val();
            var y1 = $('#imgSignY1').val();
            var width = $('#imgSignWidth').val();
            var height = $('#imgSignHeight').val();
            var canvas = $("#canvasSign")[0];
            var context = canvas.getContext('2d');
            var img = new Image();
            img.onload = function () {
                canvas.height = height;
                canvas.width = width;
                context.drawImage(img, x1, y1, width, height, 0, 0, width, height);
                $('#imgSignCropped').val(canvas.toDataURL());
                $('[id*=btnUpload]').show();
            };
            img.src = $('#Image1Sign').attr("src");

            clearCropSign();
        };

        function SetCoordinatesSign(c) {
            $('#imgSignX1').val(c.x);
            $('#imgSignY1').val(c.y);
            $('#imgSignWidth').val(c.w);
            $('#imgSignHeight').val(c.h);
            $('#btnCropSign').show();
            $('[id*=btnUpload]').hide();
        };
          //-- END of SIGN SECTION


    </script>--%>
    <script type="text/javascript">

        function validate() {

            var maxFileSize = 102400; // 100 KB
            var minFileSize = 4096; // 4 KB
            var array = ['jpg', 'jpeg', 'png'];
            var fileControl = document.getElementById("photoFile");
            var Extension = fileControl.value.substring(fileControl.value.lastIndexOf('.') + 1).toLowerCase();
            if (array.indexOf(Extension) <= -1) {
                alert("Photograph Image should be in jpg/jpeg/png format.");
                $("#photoFile")[0].value = '';
                return false;
            }
            else {

                if (fileControl.files[0].size < minFileSize || fileControl.files[0].size > maxFileSize) {
                    alert("Photograph Image Size must be greater than 4 KB and less than 100 KB.");
                    $("#photoFile")[0].value = '';
                    return false;
                } else {
                    return true;
                }
            }
        }

        function validateSign() {

            var maxFileSize = 102400; // 100 KB
            var minFileSize = 4096; // 4 KB
            var array = ['jpg', 'jpeg', 'png'];
            var fileControl = document.getElementById("signFile");
            var Extension = fileControl.value.substring(fileControl.value.lastIndexOf('.') + 1).toLowerCase();
            if (array.indexOf(Extension) <= -1) {
                alert("Signature Image should be in jpg/jpeg/png format.");
                $("#signFile")[0].value = '';
                return false;
            }
            else {

                if (fileControl.files[0].size < minFileSize || fileControl.files[0].size > maxFileSize) {
                    alert("Signature Image Size must be greater than 4 KB and less than 100 KB.");
                    $("#signFile")[0].value = '';
                    return false;
                } else {
                    return true;
                }
            }
        }
    </script>
    <script lang="javascript" type="text/javascript">

        window.history.forward(1);
        $(document).ready(function () {
            $('#rightContainer_cbUploadScannedImages_ddlPhotoSign').change(function () {
                if (document.getElementById("<%=ddlPhotoSign.ClientID %>").value == "0") {
                    $('#cropContainer').empty();
                }
                if (document.getElementById("<%=ddlPhotoSign.ClientID %>").value == "1") {
                    $('#cropContainer').empty();
                    initContainer("cropContainer", 80, 200, 150, "../Images/", 500, cb);
                }
                if (document.getElementById("<%=ddlPhotoSign.ClientID %>").value == "2") {
                    $('#cropContainer').empty();
                    initContainer("cropContainer", 80, 150, 200, "../Images/", 500, cb);
                }
            })
            //initContainer("cropContainer", 80, 250, 300, "../Images/", 500, cb);
            function cb(data, fileName, fileExt) {

                if (data.length < 10) {
                    alert("Please select file to Upload.");
                    return;
                }

                if (fileExt == "pdf") {
                    alert("only image file are allowed");
                    return;
                }
                if (document.getElementById("<%=ddlPhotoSign.ClientID %>").value == "0") {
                    alert("Please Select the Upload type Photograph / Signature");
                    return;
                }

                if (document.getElementById("<%=ddlPhotoSign.ClientID %>").value == "0") {
                    alert("Please Select the Upload type Photograph / Signature");
                    return;
                }
                if (document.getElementById("<%=ddlPhotoSign.ClientID %>").value == "1") {
                    $('#imgCropped').val(data);
                }
                else if (document.getElementById("<%=ddlPhotoSign.ClientID %>").value == "2") {
                    $('#imgSignCropped').val(data);
                }
                //if ($('#imgCropped')[0].value == "" || $('#imgSignCropped')[0].value == "") {
                //    alert("Upload Photograph / Signature")
                //    initContainer("cropContainer", 100, 0, 0, "../Images/", 500, cb);
                //}
                //else {
                $('[id*=btnUpload]').show().click().hide();
                //}
                //alert(fileName + "." + fileExt);
            }
            $('<%=trPhotograph.ClientID %>').hide();
            $('<%=trSignature.ClientID %>').hide();

            $('<%=ddlPhotoSign.ClientID %>').change(function () {
                var ddlPhotoSign = $('<%=ddlPhotoSign.ClientID %>');
                var selectedvalue = ddlPhotoSign[0].options[ddlPhotoSign[0].selectedIndex].value;
                if (selectedvalue == "1") {
                    $('<%=trPhotograph.ClientID %>').show();
                }
                if (selectedvalue == "2") {
                    $('<%=trSignature.ClientID %>').show();
                }

            });


        });


    </script>




    <cc1:ContentBox ID="cbUploadScannedImages" runat="server" HeaderText="Upload Photograph & Signature">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <ol class="list-text"><b>Note :</b>
                            <li><p align="justify"><font color="red">The Photograph Image should be in jpg/jpeg/png format.</font></p></li>
                            <li><p align="justify"><font color="red">Size of the Photograph Image must be greater than 4 KB and less than 100 KB.</font></p></li>
                            <li><p align="justify"><font color="red">Dimension of Photograph Image should be 3.5 CM (width) * 4.5 CM (Height) only.</font></p></li>
                            <li><p align="justify"><font color="red">Ensure that Photograph Image is of good quality.</font></p></li>
                            <li><p align="justify"><font color="red">Use <b>'BROWSE'</b> button to set Photograph Image Path and Click <b>'PREVIEW'</b> Button to Verify Your Photograph.</font></p></li>
                        </ol>
                    </font>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>

                <td colspan="2" align="left">Select Upload Type : 
                     <asp:DropDownList ID="ddlPhotoSign" runat="server">
                         <asp:ListItem Value="0" Text="--Select --"> </asp:ListItem>
                         <asp:ListItem Value="1" Text="Photograph"> </asp:ListItem>
                         <asp:ListItem Value="2" Text="Signature"> </asp:ListItem>
                     </asp:DropDownList>
                </td>
            </tr>

        </table>

        <div class="tbl">
            <div class="c50">
                <table class="AppFormTable">
                    <tr id="trPhotograph" runat="server">
                        <%--<td style="width: 40%" rowspan="2">
              
                    <%-- <input type="file" id="photoFile" accept=".jpg,.png,.jpeg" onchange="onFileUploadChange();" onmouseover="ddrivetip('Please Enter Photograph Path.')" onmouseout="hideddrivetip()" />
                </td>--%>


                        <td style="width: 40%" align="center">Photograph
                    <br />
                            छायाचित्र
                            <br />
                            <asp:Image ID="imgPhotograph" Width="133" Height="171" runat="server" Visible="false" AlternateText="Candidate Photograph" />
                            <br />
                            <canvas id="canvas" height="5" width="5"></canvas>
                        </td>
                    </tr>

                    <tr id="trSignature" runat="server">

                        <%-- <td>
                    <%--<input type="file" id="signFile" accept=".jpg,.png,.jpeg" onchange="onFileUploadChangeSign();" onmouseover="ddrivetip('Please Enter Signature Path.')" onmouseout="hideddrivetip()" />--%>
                        <%-- </td>--%>
                        <td align="center">Signature
                    <br />
                            स्वाक्षरी
                            <br />
                            <asp:Image ID="imgSignature" Width="133" Height="57" runat="server" Visible="false" AlternateText="Candidate Signature" />
                            <br />
                            <canvas id="canvasSign" height="5" width="5"></canvas>
                        </td>
                    </tr>

                    <%--<tr>
                <td colspan="3" style="text-align: center;">
                   
                </td>
            </tr>--%>
                </table>
                <asp:Button ID="btnPreview" CssClass="InputButton" runat="server" Text="Upload" Visible="false" /><%-- OnClick="btnPreview_Click"--%>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                <asp:Button ID="btnUpload" runat="server" Text="" OnClick="Upload" Style="display: none; background-color: #C4A000" />
            </div>
            <div class="c50">
                <div id="cropContainer" class="wrapper"></div>
            </div>
        </div>


        <input type="hidden" name="imgX1" id="imgX1" />
        <input type="hidden" name="imgY1" id="imgY1" />
        <input type="hidden" name="imgWidth" id="imgWidth" />
        <input type="hidden" name="imgHeight" id="imgHeight" />
        <input type="hidden" name="imgCropped" id="imgCropped" />

        <input type="hidden" name="imgSignX1" id="imgSignX1" />
        <input type="hidden" name="imgSignY1" id="imgSignY1" />
        <input type="hidden" name="imgSignWidth" id="imgSignWidth" />
        <input type="hidden" name="imgSignHeight" id="imgSignHeight" />
        <input type="hidden" name="imgSignCropped" id="imgSignCropped" />
    </cc1:ContentBox>


    <cc1:ContentBox ID="cbUploadedScannedImages" runat="server" HeaderText="Uploaded Photograph & Signature">
        <div id="divInstructionsForChange" runat="server">
            <table class="AppFormTableWithOutBorder">
                <tr>
                    <td>
                        <font color="red">
                            <ol class="list-text"><b>Note :</b>
                                <li><p align="justify"><font color="red">If You Want to Change Photograph, Then Click on Photograph.</font></p></li>
                            </ol>
                        </font>
                    </td>
                </tr>
            </table>
        </div>
        <table class="AppFormTable">
            <%--<tr>
                <th colspan="2" align="left" style="border-top-width: 0px;">Scanned Images</th>
            </tr>--%>
            <%--<tr>
                <td style="width: 50%" align="center">Photograph</td>
                <td style="width: 50%" align="center">Signature</td>
            </tr>--%>
            <tr>
                <td align="center">
                    <asp:ImageButton ID="btnPhotograph" runat="server" Width="133" Height="171" OnClick="btnPhotograph_Click" onmouseover="ddrivetip('Click on Image to change it.')" onmouseout="hideddrivetip()" /></td>
                <td align="center">
                    <asp:ImageButton ID="btnSignature" runat="server" Width="133" Height="57" OnClick="btnSignature_Click" onmouseover="ddrivetip('Click on Image to change it.')" onmouseout="hideddrivetip()" /></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbProceed" runat="server" HeaderVisible="false" Visible="false">
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" CausesValidation="false" /></td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <%--<script type="text/javascript" src="../Scripts/jquery-1.11.2.min.js"></script>--%>
    <script type="text/javascript">
        window.history.forward(1);
        var validFilesTypes = ["png", "jpg", "jpeg"];
        function ValidatePhotoUpload(sender, args) {
            var file = $('#photoFile');
            var path = file.value;
            var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
            var isValidFile = false;
            for (var i = 0; i < validFilesTypes.length; i++) {
                if (ext == validFilesTypes[i]) {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile) {
                args.IsValid = false;
            }
        }

    </script>
</asp:Content>



