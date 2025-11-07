<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmEditScannedImages.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEditScannedImages" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #photoFile{
            height:50px;
        }
        #imgPhotograph{
            height:400px;            
        }
         #signFile{
            height:50px;
        }
        #imgSignature{
            height:400px;            
        }
        .left-area{
            width:18%;
        }
    </style>
    <link href="../JCropJsCss/jquery.Jcorp.css" rel="stylesheet" />
    <script type="text/javascript" src="../JCropJsCss/jquery.min.js"></script>
    <script type="text/javascript" src="../JCropJsCss/jquery.Jcrop.js"></script>
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script type="text/javascript">
        //        $(function () {
        //            $('#filePhotograph').change();

        //            $('#btnCrop').click(function () {
        //                getCrop();
        //            });
        //        });


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
        function getCroppedImageSign() {
            if (document.getElementById('<%= imgSignature.ClientID %>') != null)
                document.getElementById('<%= imgSignature.ClientID %>').style.display = "none";
            getCropSign();
            $('[id*=divCroppingSign]').hide();
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

        function SetCoordinates(c) {
            $('#imgX1').val(c.x);
            $('#imgY1').val(c.y);
            $('#imgWidth').val(c.w);
            $('#imgHeight').val(c.h);
            $('#btnCrop').show();
            $('[id*=btnUpload]').hide();
        };
        function SetCoordinatesSign(c) {
            $('#imgSignX1').val(c.x);
            $('#imgSignY1').val(c.y);
            $('#imgSignWidth').val(c.w);
            $('#imgSignHeight').val(c.h);
            $('#btnCropSign').show();
            $('[id*=btnUpload]').hide();
        };

    </script>
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
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible = "false">
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
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbUploadScannedImages" runat="server" HeaderText="Upload Photograph and Signature">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <ol class="list-text"><b>Note :</b>
                            <li><p align="justify"><font color="red">The Photograph and Signature Image should be in jpg/jpeg/png format.</font></p></li>
                            <li><p align="justify"><font color="red">Size of the Photograph and Signature Image must be greater than 4 KB and less than 100 KB.</font></p></li>
                            <li><p align="justify"><font color="red">Dimension of Photograph and Signature Image should be 3.5 CM (width) * 4.5 CM (Height) only.</font></p></li>
                            <li><p align="justify"><font color="red">Ensure that Photograph and Signature Image is of good quality.</font></p></li>
                            <li><p align="justify"><font color="red">Use <b>'BROWSE'</b> button to set Photograph Image Path and Click <b>'PREVIEW'</b> Button to Verify Your Photograph.</font></p></li>
                        </ol>
                    </font>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr id="trPhotograph" runat="server">
                <td style="width: 20%" align= "right">Photograph</td>
                <td style="width: 40%">
                   <%-- <asp:FileUpload ID="filePhotograph" runat="server" onmouseover="ddrivetip('Please Enter Photograph Path.')" onmouseout="hideddrivetip()" />
                    <asp:RequiredFieldValidator ID="rfvPhotograph" runat="server" ControlToValidate="filePhotograph" Display="None" ErrorMessage="Please Enter Photograph Path."></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvPhotograph" runat="server" ClientValidationFunction="ValidatePhotoUpload" Display="None" ErrorMessage="Please upload Photograph Having Extension .jpg, .jpeg or .png." ></asp:CustomValidator>--%>
                    <input type="file" id="photoFile" accept=".jpg,.png,.jpeg" onchange="onFileUploadChange();"  onmouseover="ddrivetip('Please Enter Photograph Path.')" onmouseout="hideddrivetip()" />
                </td>
                <td style="width: 40%" align="center">
                    <asp:Image ID="imgPhotograph" Width="133" Height="171" runat="server" Visible="false" AlternateText="Candidate Photograph" />
                    <br />
                    <canvas id="canvas" height="5" width="5"></canvas>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center;">
                   <div id="divCropping" runat="server" style="display: none">
                        <table>
                            <tr>
                                <td valign="top">
                                    <img class="jcrop-tracker" id="Image1" src="" alt="" style="display: none" />
                                </td>
                                <td valign="top">
                                    <div style="width: 200px; height: 250px; overflow: hidden;">
                                        <img src="" id="preview" />
                                    </div>
                                    <br />
                                    <br />
                                    <input type="button" id="btnCrop" value="Crop" style="display: none" onclick="getCroppedImage();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr id="trSignature" runat="server">
                <td align="right">Signature</td>
                <td>
                    <%--<asp:FileUpload ID="fileSignature" runat="server" onmouseover="ddrivetip('Please Enter Signature Path.')" onmouseout="hideddrivetip()" />
                    <asp:RequiredFieldValidator ID="rfvSignature" runat="server" ControlToValidate="fileSignature" Display="None" ErrorMessage="Please Enter Signature Path."></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvSignature" runat="server" ClientValidationFunction="ValidateSignUpload" Display="None" ErrorMessage="Please upload Signature Having Extension .jpg, .jpeg or .png." ></asp:CustomValidator>--%>
                    <input type="file" id="signFile" accept=".jpg,.png,.jpeg" onchange="onFileUploadChangeSign();" onmouseover="ddrivetip('Please Enter Signature Path.')" onmouseout="hideddrivetip()" />
                </td>
                <td align="center">
                    <asp:Image ID="imgSignature" Width="133" Height="171" runat="server" Visible="false" AlternateText="Candidate Signature" />
                    <br />
                    <canvas id="canvasSign" height="5" width="5"></canvas>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center;">
                    <div id="divCroppingSign" runat="server" style="display: none">
                        <table>
                            <tr>
                                <td valign="top">
                                    <img class="jcrop-tracker" id="Image1Sign" src="" alt="" style="display: none" />
                                </td>
                                <td valign="top">
                                    <div style="width: 200px; height: 250px; overflow: hidden;">
                                        <img src="" id="previewSign" />
                                    </div>
                                    <br />
                                    <br />
                                    <input type="button" id="btnCropSign" value="Crop" style="display: none" onclick="getCroppedImageSign();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center;">
                    <asp:Button ID="btnPreview" CssClass="InputButton" runat="server" Text="Upload" Visible="false" /><%-- OnClick="btnPreview_Click"--%>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"  ShowSummary="False" />
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" Style="display: none" />
                </td>
            </tr>
        </table>
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
    <cc1:ContentBox ID="cbUploadedScannedImages" runat="server" HeaderText="Uploaded Photograph and Signature">
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
                <td align="center"><asp:ImageButton ID="btnPhotograph" runat="server" Width="133" Height="171" OnClick="btnPhotograph_Click" onmouseover="ddrivetip('Click on Image to change it.')" onmouseout="hideddrivetip()" /></td>
                <td align="center"><asp:ImageButton ID="btnSignature" runat="server" Width="133" Height="57" OnClick="btnSignature_Click" onmouseover="ddrivetip('Click on Image to change it.')" onmouseout="hideddrivetip()" /></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cbProceed" runat="server" HeaderVisible="false" Visible="false">
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center"><asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" CausesValidation="false" /></td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
  <%--  <script type="text/javascript" src="../Scripts/jquery-1.11.2.min.js"></script>--%>
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



