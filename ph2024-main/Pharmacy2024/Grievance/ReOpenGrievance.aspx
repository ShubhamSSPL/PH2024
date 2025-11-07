<%@ Page Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="ReOpenGrievance.aspx.cs" Inherits="Pharmacy2024.Grievance.ReOpenGrievance" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
        .modal-body {
            height: 250px;
            overflow: auto;
        }

        @media (min-height: 500px) {
            .modal-body {
                height: 400px;
            }
        }

        @media (min-height: 800px) {
            .modal-body {
                height: 600px;
            }
        }

        .btnwidth {
            min-width: 150px;
        }

        .modal-header {
            padding: 0.5rem;
        }

        .control-label {
            font-weight: 500;
            color: #4e4e4e;
            font-size: 14px;
        }

        .required {
            color: #dd2a2a;
        }
    </style>
    <script>
        window.history.forward(1);
        function MessageChanged() {
            if (document.getElementById('rightContainer_ContentTable2_txtGrievance').value.length > 1000) {
                document.getElementById('rightContainer_ContentTable2_txtGrievance').value = document.getElementById('rightContainer_ContentTable2_txtGrievance').value.substring(0, 1000);
            }
            document.getElementById('countCharacters').innerHTML = document.getElementById('rightContainer_ContentTable2_txtGrievance').value.length;
        }
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Reply Ticket">
        <div class="row card-body w-100">
            <div class="col-md-12">
                <div class="row mt-2">
                    <div class="col-md-12">
                        <asp:PlaceHolder ID="plcGrievance" runat="server" />
                    </div>
                </div>
                <div id="divReOpen" runat="server" class="row mt-2">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label">Query <span class="required">*</span></label>
                            <asp:TextBox ID="txtGrievance" runat="server" MaxLength="1000" CssClass="form-control" TextMode="MultiLine" Height="120" onkeyup="MessageChanged()"></asp:TextBox>
                            <br />
                            <b>(<span id="countCharacters">0</span> / 1000 characters filled)</b>
                            <asp:RequiredFieldValidator ID="rfvGrievance" runat="server" ErrorMessage="Please Enter Query." ControlToValidate="txtGrievance" Display="None"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Attachment</label>
                            <div class="custom-file">
                                <asp:FileUpload ID="fileAttachment" runat="server" CssClass="form-control custom-file-input" />
                                <label class="custom-file-label control-label" for="customFile">
                                    Choose file
                                </label>
                            </div>
                            <asp:CustomValidator ID="cvCheckAttachment" runat="server" ClientValidationFunction="CheckAttachment" Display="None"></asp:CustomValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label" style="margin-bottom: 3px;">&nbsp;</label>
                            <br />
                            <label class="control-label">
                                File Types Allowed : <b>jpg, jpeg, png, bmp, pdf</b>
                                <br />
                                Maximum File Size Allowed : <b>1 MB</b>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btnReOpen" runat="server" Text="Re-Open" CssClass="btn btn-success btn-sm" OnClick="btnReOpen_Click" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                    </div>
                </div>
            </div>
        </div>
    </cc1:ContentBox>
    <br />
    <div class="modal" id="modalDocument" tabindex="-1" role="dialog">
        <div class="modal-dialog" style="min-width: 90%;" role="Document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="headerTitle" style="vertical-align: middle;">Document Details</h5>
                    <button type="button" class="btn btn-danger" data-dismiss="modal" aria-label="Close" style="margin-top: 2px;">
                        X
                    </button>
                </div>
                <div class="modal-body" id="ModalBody">
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
                    <div style="width: 100%; height: 400px" id="divDocument"></div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnFileTypesAllowed" runat="server" Value="jpg, jpeg, png, bmp, pdf" />
    <asp:HiddenField ID="hdnMaxFileSizeAllowed" runat="server" Value="1024" />
    <script language="javascript" type="text/javascript">
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
        $(document).ready(function () {
            $('.second-box').click(function (e) {
                e.preventDefault();

                var FileName = 'Attachment';
                var FileURL = $(this).attr('href');
                var extension = FileURL.split('.').pop();
                var dsResponse = Pharmacy2024.ViewMessageBoxDocument.GetCandidateGrievanceDocumentAsBase64(FileURL);
                var byteStream = dsResponse.value;
                $('#headerTitle').text(FileName);

                switch (extension) {
                    case 'jpg':
                    case 'png':
                    case 'gif':
                    case 'jpeg':
                    case 'bmp':

                        document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                        document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + byteStream + '">';
                        $("#modalDocument").modal('show');
                        break;
                    case 'pdf':
                        document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                        document.getElementById('divDocument').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';
                        $("#modalDocument").modal('show');
                }
            })
        });
        function CheckAttachment(sender, args) {
            var value = $("#<%=fileAttachment.ClientID %>").val();

            if (value != '') {
                var files = $("#<%=fileAttachment.ClientID %>").get(0).files;
                var fileExtenstion = files[0].name.split('.').pop().toLowerCase();
                var fileSize = files[0].size;
                var maxFileSizeAllowed = $('#<%= hdnMaxFileSizeAllowed.ClientID%>').val();
                var fileTypesAllowed = $('#<%=hdnFileTypesAllowed.ClientID %>').val();

                if (fileSize > maxFileSizeAllowed * 1024) {
                    sender.errormessage = 'Maximum File Size Allowed is ' + maxFileSizeAllowed + ' KB.';
                    args.IsValid = false;
                }
                else if (fileTypesAllowed.indexOf(fileExtenstion) == -1) {
                    sender.errormessage = 'Only ' + fileTypesAllowed + ' Files are Allowed.';
                    args.IsValid = false;
                }
            }
        }
    </script>
    <script>
        $('input[type="file"]').change(function (e) {
            var fileName = e.target.files[0].name;
            $('.custom-file-label').html(fileName);
        });
    </script>
</asp:Content>
