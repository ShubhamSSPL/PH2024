<%@ Page Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="SendGrievance.aspx.cs" Inherits="Pharmacy2024.Grievance.SendGrievance" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
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
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Generate Ticket">
        <div class="row card-body w-100">
            <div class="col-md-12">
                <asp:UpdatePanel ID="upGrievance" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label class="control-label">Login ID <span class="required">*</span></label>
                                    <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="15" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvApplicationID" runat="server" ErrorMessage="Please Enter Login ID." ControlToValidate="txtApplicationID" Display="None"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="control-label">Category <span class="required">*</span></label>
                                    <asp:DropDownList ID="ddlGrievanceCategory" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGrievanceCategory_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:CompareValidator ID="cvGrievanceCategory" runat="server" ControlToValidate="ddlGrievanceCategory" Display="None" ErrorMessage="Please Select Category." Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="col-md-5" id="trOtherGrievanceCategory" runat="server">
                                <div class="form-group">
                                    <label class="control-label">Other Category <span class="required">*</span></label>
                                    <asp:TextBox ID="txtOtherGrievanceCategory" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvOtherGrievanceCategory" runat="server" ErrorMessage="Please Enter Other Category." ControlToValidate="txtOtherGrievanceCategory" Display="None"></asp:RequiredFieldValidator>
                                </div>
                            </div>                            
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
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
                            <label class="control-label" style="margin-bottom:3px;">&nbsp;</label>
                            <br />
                            <label class="control-label">
                                File Types Allowed : <b>jpg, jpeg, png, bmp, pdf</b>
                                <br />
                                Maximum File Size Allowed : <b>1 MB</b>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btnSend" runat="server" Text="Generate Ticket" CssClass="btn btn-success btn-sm" OnClick="btnSend_Click" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                    </div>
                </div>
            </div>
        </div>
    </cc1:ContentBox>
    <br />
    <asp:HiddenField ID="hdnFileTypesAllowed" runat="server" Value="jpg, jpeg, png, bmp, pdf" />
    <asp:HiddenField ID="hdnMaxFileSizeAllowed" runat="server" Value="1024" />
    <script language="javascript" type = "text/javascript">
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
