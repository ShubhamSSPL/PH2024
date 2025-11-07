<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="VerificationSummary.aspx.cs" Inherits="Pharmacy2024.E_FCModule.VerificationSummary" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_contentViewDocument {
            top: 14% !important;
            width: 90% !important;
        }
        .doc-container {
            height: 23rem;
            border: 1rem solid rgba(0,0,0,.1);
         
        }
    </style>
    <script src="../Scripts/epoch_classes.js" type="text/javascript" lang="javascript"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
        function isNCLIssueDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtNCLIssueDate").value;
            if (dateStr.length == 0) {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat); // is format OK?
            if (matchArray == null) {
                args.IsValid = false;
                return;
            }
            month = matchArray[3];
            day = matchArray[1];
            year = matchArray[5];
            if (year < 1900 || year >= 2080) {
                args.IsValid = false;
                return;
            }
            if (month < 1 || month > 12) {
                args.IsValid = false;
                return;
            }
            if (day < 1 || day > 31) {
                args.IsValid = false;
                return;
            }
            if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
                args.IsValid = false;
                return;
            }
            if (month == 2) {
                var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
                if (day > 29 || (day == 29 && !isleap)) {
                    args.IsValid = false;
                    return;
                }
            }
        }
        function compareNCLIssueDate(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtNCLIssueDate").value;
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat);
            if (matchArray == null) {
                var objCVValidateDate = document.getElementById("rightContainer_ContentTable2_cvCompareDate");
                args.IsValid = false;
            }
            else {
                month = matchArray[3];
                day = matchArray[1];
                year = matchArray[5];
                var date = new Date();
                if (year > date.getFullYear()) {
                    var objCVValidateDate = document.getElementById("rightContainer_ContentTable2_cvCompareDate");
                    args.IsValid = false;
                }
                else if (year < date.getFullYear()) {
                    args.IsValid = true;
                }
                else {
                    if (month > date.getMonth() + 1) {
                        var objCVValidateDate = document.getElementById("rightContainer_ContentTable2_cvCompareDate");
                        args.IsValid = false;
                    }
                    else if (month < date.getMonth() + 1) {
                        args.IsValid = true;
                    }
                    else {
                        if (day > date.getDate()) {
                            var objCVValidateDate = document.getElementById("rightContainer_ContentTable2_cvCompareDate");
                            args.IsValid = false;
                        }
                        else {
                            args.IsValid = true;
                        }
                    }
                }
            }
        }
    </script>
    <style>
        .pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .doc-container {
		    width:56rem;
            height: 25rem;
            border: 1rem solid rgba(0,0,0,.1);
        }
    </style>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Confirmation of Document Verification">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <ul class="list-text">
                            <p align = "justify"><font color = "red"><b>Instructions :</b></font></p>
                            <li><p align = "justify"><font color = "red">The Documents which Verified / Not Verified are shown below.</font></p></li>
                            <li><p align = "justify"><font color = "red">Click on 'Confirm Application Form' Button to Confirm the Application Form.</font></p></li>
                            <li><p align = "justify"><font color = "red">If you fill any mistake in clicking on Verified / Not Verified, Click on '<<< Back' Button to change the Verified / Not Verified Documents.</font></p></li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:Label ID="lblDocumentsSubmittedHead" runat="server"><b>List of Documents Verified :</b></asp:Label></td>
            </tr>
        </table>
        <asp:GridView ID="gvDocumentsSubmitted" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
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
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:Label ID="lblDocumentsNotSubmittedHead" runat="server"><b>List of Documents Not Verified :</b></asp:Label></td>
            </tr>
        </table>
        <asp:GridView ID="gvDocumentsNotSubmitted" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
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
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server"><b>Discrepancy Marked by SC Officer :</b></asp:Label></td>
            </tr>
        </table>
        <asp:GridView ID="gvDiscrepancy" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="Application Form Step" DataField="LinkName" HtmlEncode="false">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Discrepancy Name" DataField="DiscrepancyName" HtmlEncode="false">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Discrepancy Remark" DataField="DiscrepancyRemark" HtmlEncode="false">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                </asp:BoundField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblDiscrepancyID" runat="server" Text='<%# Eval("DiscrepancyID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblApplicationFormStepID" runat="server" Text='<%# Eval("ApplicationFormStepID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />

        <table class="AppFormTableWithOutBorder">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblDisplayDocumentSubmissionStatus" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr id="trNCLIssueDate" runat="server" visible="false">
                <td style="width: 25%" align="right">Enter NCL Issue Date</td>
                <td style="width: 75%">
                    <asp:TextBox ID="txtNCLIssueDate" runat="server" MaxLength="10" Width="110px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>(DD/MM/YYYY)
                    <asp:RequiredFieldValidator ID="rfvNCLIssueDate" runat="server" ErrorMessage="Please Enter NCL Issue Date." ControlToValidate="txtNCLIssueDate" Display="None"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvNCLIssueDate" runat="server" ControlToValidate="txtNCLIssueDate" ClientValidationFunction="isNCLIssueDateValid" Display="None" ErrorMessage="Please Enter Proper NCL Issue Date."></asp:CustomValidator>
                    <asp:CustomValidator ID="cvCompareDate" runat="server" ControlToValidate="txtNCLIssueDate" ClientValidationFunction="compareNCLIssueDate" Display="None" ErrorMessage="NCL Issue Date Should not be greater than Current Date."></asp:CustomValidator>
                </td>
            </tr>
            <tr id="trNCLValidUpTo" runat="server" visible="false">
                <td align="right">Enter NCL Valid UpTo</td>
                <td>
                    <asp:DropDownList ID="ddlNCLValidUpTo" runat="server">
                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                        <asp:ListItem Value="1">31 March 2025</asp:ListItem>
                        <asp:ListItem Value="2">31 March 2026</asp:ListItem>
                        <asp:ListItem Value="3">31 March 2027</asp:ListItem>
                    </asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvNCLValidUpTo" runat="server" ControlToValidate="ddlNCLValidUpTo" Display="None" ErrorMessage="Please Select NCL Valid UpTo." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr id="trNCLDOcument" runat="server" visible="false">
                <td align="right">NCL Document View </td>
                <td>
                    <%-- <asp:Button ID="btnviewNCL"   Text="View NCL Document"  onclick="javascript:OpenViewDocumentPopUp()" CssClass="InputButton" BackColor="#F6223F" CausesValidation="false"></asp:Button>--%>
                    <input type="button" ID="btnviewNCL"  value="View NCL Document"  onclick="javascript:OpenViewDocumentPopUp()" CssClass="InputButton" BackColor="#F6223F" CausesValidation="false"></input>
                     <input type="hidden" name="NCLURL" value="" id="hdnNCLURL" runat="server" />
                     <input type="hidden" name="NCLURLBase64" value="" id="hdnImgByteArray" runat="server" />
                    <%--<img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" onclick="javascript:OpenViewDocumentPopUp(this)" runat="server" />--%>
                </td>
            </tr>
            <tr>
                <td align="right">Comments</td>
                <td>
                    <asp:TextBox ID="txtComments" runat="server" Width="100%" Height="50px" MaxLength="250" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <br />
                    <asp:Button ID="btnBack" runat="server" Text="<<< Back" OnClick="btnBack_Click" CssClass="InputButton" BackColor="#F6223F" CausesValidation="false"></asp:Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnProceed" runat="server" Text="Confirm Application Form" OnClick="btnProceed_Click" CssClass="InputButton"></asp:Button>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="70%">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr>
                <td>
                    <div class="modal-body" style="height: 450px;">
                        <div runat="server" id="divButtonPopup" >  
                            <button type="button" onclick="zoominPopUp()" ><img src="../Images/zoom-in.png" width="15px" height="15px"></button> 
                            <button type="button" onclick="zoomoutPopUp()"><img src="../Images/zoom-out.png" width="15px" height="15px"> </button> 
                        </div>
                        <div id="divDocument" class="doc-container"></div>
                    </div>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
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

        function OpenViewDocumentPopUp() {

            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            var filePath = document.getElementById('<%=hdnNCLURL.ClientID %>').value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            var byteStream = document.getElementById('<%=hdnImgByteArray.ClientID %>').value;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + byteStream + '">';
                    document.getElementById('divDocument').style.overflow = "auto";
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
    <script lang="javascript" type="text/javascript">
        var dp_calNCLIssueDate;
        window.onload = function () {
            if (document.getElementById("rightContainer_ContentTable2_txtNCLIssueDate") != null) {
                dp_calNCLIssueDate = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtNCLIssueDate'));
            }
        };
    </script>
</asp:Content>
