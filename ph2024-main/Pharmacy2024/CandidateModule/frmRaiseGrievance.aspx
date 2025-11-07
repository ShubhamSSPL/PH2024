<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmRaiseGrievance.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmRaiseGrievance" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
   .dd_chk_select{
       width:90% !important;
       height: 35px !important;
    border-radius: 4px !important;
        }
  .dd_chk_select div#caption{
          top: 7px !important;
  }
    </style>
    <script>
        $(document).ready(function () {
            $('#rightContainer_ContentTable2_fileInput1').change(function () {
                var x = document.getElementById("rightContainer_ContentTable2_fileInput1");
                var blnValid = false;
                var _validFileExtensions = [".jpg", ".jpeg", ".pdf"];
                var sFileName = x.value;

                for (var j = 0; j < _validFileExtensions.length; j++) {
                    var sCurExtension = _validFileExtensions[j];
                    if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                        blnValid = true;
                        break;
                    }
                }

                if (!blnValid) {
                    alert("Sorry, Selected file is invalid, allowed extensions are: " + _validFileExtensions.join(", "));
                    document.getElementById("rightContainer_ContentTable2_btnSend").style.display = "none";
                    x.value = "";
                    document.getElementById("thumimg").src = "";

                    return false;
                }
                else {
                    var KB = 0;
                    var fs = x.files.item(0).size;
                    KB = (fs / 1024).toFixed(2);

                    if (parseFloat(KB) < 501) {
                        document.getElementById("rightContainer_ContentTable2_btnSend").style.display = "block";

                        var files = !!this.files ? this.files : [];
                        var reader = new FileReader();
                        reader.readAsDataURL(files[0]);
                        reader.onload = function (e) {
                            document.getElementById("thumimg").src = e.target.result;
                        };
                        reader.readAsDataURL(this.files[0]);

                        document.getElementById("rightContainer_ContentTable2_fileInput1").innerHTML = x.value;
                        {
                            $('#thumimg').attr('src', Image_file);
                        };
                    }
                    else {
                        alert("Sorry, selected file must be less than 500KB");
                        document.getElementById("rightContainer_ContentTable2_btnSend").style.display = "none";
                        x.value = "";
                        document.getElementById("thumimg").src = "";

                        return false;
                    }
                }
            });
        })
    </script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function MessageChanged() {
            if (document.getElementById('rightContainer_ContentTable2_txtMsg').value.length > 1000) {
                document.getElementById('rightContainer_ContentTable2_txtMsg').value = document.getElementById('rightContainer_ContentTable2_txtMsg').value.substring(0, 1000);
            }
            document.getElementById('countCharacters').innerHTML = document.getElementById('rightContainer_ContentTable2_txtMsg').value.length;
        }
    </script>

    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Send Grievance(तक्रार निवारण ई-सुविधा)" Visible="false">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upExamCenter" UpdateMode="Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSend" />
            </Triggers>
            <ContentTemplate>
                <div class="table-responsive">
                    <table class="AppFormTable">
                        <tr>
                            <td style="width: 20%;" align="right">To</td>
                            <td style="width: 80%;">
                                <asp:TextBox ID="txtTo" runat="server" ReadOnly="True">ADMIN</asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr>
                         <td align="right">Grievance In</td>
                        <td>
                            <asp:DropDownList ID="ddlMessageType" runat="server" Width = "60%" AutoPostBack="true" OnSelectedIndexChanged="ddlMessageType_SelectedIndexChanged"></asp:DropDownList>
                               <font color = "red"><sup>*</sup></font>
                           <asp:CompareValidator ID="cvMessageType" runat="server" ControlToValidate="ddlMessageType" Display="None" ErrorMessage="Please Select Grievance Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>--%>
                        <tr>
                            <td align="right">Grievance Type
                                <br />
                                तक्रारीचा प्रकार </td>
                            <td>
                                <asp:DropDownCheckBoxes ID="ddlTicketSubCategory" runat="server" AddJQueryReference="True" UseButtons="false" UseSelectAllNode="false" AutoPostBack="true" OnSelectedIndexChanged="ddlTicketSubCategory_SelectedIndexChanged">
                                    <Style SelectBoxWidth="60%" DropDownBoxBoxWidth="95%" DropDownBoxBoxHeight="130" />
                                    <Texts SelectBoxCaption="-- Select Grievance Sub Type --" />
                                </asp:DropDownCheckBoxes>
                                <font color="red"><sup>*</sup></font>
                                <asp:ExtendedRequiredFieldValidator ID="rfvTicketSubCategory" runat="server" ControlToValidate="ddlTicketSubCategory" ErrorMessage="Please Select at least one Grievance Sub Type." Display="none"></asp:ExtendedRequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Subject
                                <br />
                                विषय </td>
                            <td>
                                <asp:TextBox ID="txtSubject" runat="server" MaxLength="100" Width="90%"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <%--<asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject" ErrorMessage="Please Enter subject." Display = "none"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Attachment 1</td>
                            <td>
                                <input id="fileInput1" type="file" runat="server" style="height:40px"/><br />
                                <font color="red"><sup>(Only .JPG, .JPEG, .PDF Formats Supported and Maximum File Size Allowed : 500KB)</sup></font>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right">Attachment 2</td>
                            <td>
                                <input id="fileInput2" type="file" runat="server" /><br />
                                <font color="red"><sup>(Only .JPG, .JPEG, .PDF Formats Supported and Maximum File Size Allowed : 500KB)</sup></font>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">Grievance Details
                                <br />
                                तक्रारीचा तपशील</td>
                            <td>
                                <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Width="90%" Height="50" MaxLength="1000" onkeyup="MessageChanged()"></asp:TextBox>
                                <font color="red"><sup>*</sup></font>
                                <br />
                                (<span id="countCharacters">0</span> / 1000 characters filled)
                            <asp:RequiredFieldValidator ID="rfvMsg" runat="server" ControlToValidate="txtMsg" ErrorMessage="Please Enter Grievance Details." Display="none"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnSend" runat="server" Text="Send Grievance" CssClass="InputButton" OnClick="btnSend_Click" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>


