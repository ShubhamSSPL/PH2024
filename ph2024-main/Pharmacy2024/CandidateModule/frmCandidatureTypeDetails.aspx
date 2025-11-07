<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCandidatureTypeDetails.aspx.cs" Inherits="Pharmacy2024.CandidateModule.frmCandidatureTypeDetails" %>
 
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function selectSingleCandidatureType(rdbtnid) 
        {
            var rdBtn = document.getElementById(rdbtnid);
            var rdBtnList = document.getElementsByTagName("input");
            for (i = 0; i < rdBtnList.length; i++) 
            {
                if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id) 
                {
                    rdBtnList[i].checked = false;
                }
            }
            var FCRApplicationFormNo = document.getElementById("rightContainer_ContentTable2_txtFCRApplicationFormNo");
            var FCRDOB = document.getElementById("rightContainer_ContentTable2_txtDOB");
            var getid = document.getElementById(rdbtnid).id;
            if ((getid != 'rightContainer_ContentTable2_gvCandidatureType_rbnCandidatureType_10') ||
                (getid != 'rightContainer_ContentTable2_gvCandidatureType_rbnCandidatureType_11') ||
                (getid != 'rightContainer_ContentTable2_gvCandidatureType_rbnCandidatureType_12') ||
                (getid != 'rightContainer_ContentTable2_gvCandidatureType_rbnCandidatureType_13')) {
                console.log("Hello world");

                if (document.getElementById("rightContainer_ContentTable2_tblCheckFCRDetails").style.display = 'block') {
                    document.getElementById("rightContainer_ContentTable2_tblCheckFCRDetails").style.display = 'none';
                    document.getElementById("rightContainer_ContentTable2_btnProceed").visible = true;

                    FCRApplicationFormNo.removeAttribute('required', '');
                    FCRDOB.removeAttribute('required', '');
                }
                if (document.getElementById("rightContainer_ContentTable2_tblFRNoDetails").style.display = 'block') {
                    document.getElementById("rightContainer_ContentTable2_tblFRNoDetails").style.display = 'none';
                }
            }
        }
        function checkCandidatureType(Source, args) 
        {
            var gvCandidatureType = document.getElementById("rightContainer_ContentTable2_gvCandidatureType");
            var rdoArray = gvCandidatureType.getElementsByTagName("input");

            for (i = 0; i <= rdoArray.length - 1; i++) 
            {
                if (rdoArray[i].type == 'radio') 
                {
                    if (rdoArray[i].checked) 
                    {
                        args.IsValid = true;
                        return;
                    }
                }
            }
            args.IsValid = false;
        }
        function isDateValid(sender, args) {
            var dateStr = document.getElementById("rightContainer_ContentTable2_txtDOB").value;
            if (dateStr.length == 0) {
                args.IsValid = false;
                return;
            }
            var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var matchArray = dateStr.match(datePat);
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
                args.IsValid = false;rightContainer_ContentTable2_txtDOB
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
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {

            if (document.getElementById("rightContainer_ContentTable2_txtDOB") != null) {
                var dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDOB'));
            }
        }
        window.onload = load;
    </script>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Claim Your Type of Candidature">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color = "red">
                        <p align = "justify"><font color = "red"><b>Note :</b></font></p>
                        <ul class="list-text">
                            <li><p align = "justify"><font color = "red">Read all the types carefully and claim your Type of Candidature by clicking on the radio button and then click on 'Save & Proceed' Button.</font></p></li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvCandidatureType" runat="server" AutoGenerateColumns="False" Width = "100%" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Eligibility Requirement"  DataField="Eligibility" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="73%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" CssClass="Item"/>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Select Candidature Type">
                    <ItemTemplate>
                        <br />
                        <asp:RadioButton ID="rbnCandidatureType" runat="server" GroupName = "CandidatureType" OnClick="javascript:selectSingleCandidatureType(this.id)" />
                        <asp:HiddenField ID="hdnCandidatureTypeID" runat="server" Value = '<%#Eval("CandidatureTypeID")%>' />
                        <br />
                        <asp:Label ID="lblCandidatureTypeName" runat="server" Text='<%# Eval("CandidatureTypeName") %>' Font-Bold = "true"></asp:Label>
                        <br /><br />
                    </ItemTemplate>    
                    <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" CssClass="Item"/>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="27%" CssClass="Header"/>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <table class="AppFormTable" id="tblCheckFCRDetails" runat="server" style="display:block">
            <tr id="trCheckFCRDetails" runat="server">
                <td style="width: 50%" align="right">Enter Foreign Registration Application Number</td>
                <td style="width: 50%">
                    <%--<asp:TextBox ID="txtFCRApplicationFormNo" MaxLength="11" runat="server" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color="red">*</font>
                    <asp:RequiredFieldValidator ID="rfvFCRApplicationFormNo" runat="server" Display="None" ControlToValidate="txtFCRApplicationFormNo" ErrorMessage="Please Enter YourEnter Foreign Registration Application Number."></asp:RequiredFieldValidator>--%>
                    <input type="text" id="txtFCRApplicationFormNo" maxlength="11" runat="server" required/>
                </td>
            </tr>
            <tr id="trCheckFCRDOB" runat="server">
                <td align="right">Enter Date Of Birth</td>
                <td>
                    <input type="text" id="txtDOB" maxlength="10" runat="server" required/>
                    <%--<asp:TextBox ID="txtDOB" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                    <font color="red"><sup>*</sup></font> (DD/MM/YYYY)
                            <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB" Display="None" ErrorMessage="Please Enter Your Date of Birth."></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="isDateValid" Display="None" ErrorMessage="Please Select Proper Date of Birth."></asp:CustomValidator>--%>
                </td>
            </tr>
            <tr id="trFCRGetData" runat="server">
                <td colspan="2" align="center">                 
                    <asp:Button ID="btnFCRGetData" runat="server" Text="Check Foreign Registration Details" CssClass="InputButton" BackColor="Red" OnClick="btnCheckFCRGetData_Click"/>
                    
                    <br />
                    <asp:Label ID="lblNote" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <table id="tblFRNoDetails" runat="server" class="AppFormTable">
            <tr id="trFCRApplicationNo" runat="server" visible="false">
                <td colspan="4" style="width: 50%" align="right">FCR Candidate Application No </td>
                <td colspan="2" style="width: 50%">
                    <asp:Label ID="lblFCRApplicationNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 50%" align="right">Candidate Name As Per FCR </td>
                <td colspan="2" style="width: 50%">
                    <asp:Label ID="lblFCRCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 50%" align="right">Candidature Type Name As Per FCR </td>
                <td colspan="2" style="width: 50%">
                    <asp:Label ID="lblFCRCandidatureTypeName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 50%" align="right">Mother Name As Per FCR </td>
                <td colspan="2" style="width: 50%">
                    <asp:Label ID="lblFCRMotherName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 50%" align="right">Gender As Per FCR </td>
                <td colspan="2" style="width: 50%">
                    <asp:Label ID="lblFCRGender" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" style="width: 50%" align="right">DOB As Per FCR </td>
                <td colspan="2" style="width: 50%">
                    <asp:Label ID="lblFCRDOB" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:CustomValidator ID="cvCandidatureType" runat="server" ErrorMessage="Please Select Type of Candidature." ClientValidationFunction="checkCandidatureType" Display="None"></asp:CustomValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <script language="javascript" type="text/javascript">
        if (document.getElementById("rightContainer_ContentTable2_txtDOB") != null) {
            var dp_cal;
            window.onload = function () {
                dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtDOB'));
            };
        }

    </script>
</asp:Content>



