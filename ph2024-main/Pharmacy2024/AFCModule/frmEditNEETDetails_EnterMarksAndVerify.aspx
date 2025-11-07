<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditNEETDetails_EnterMarksAndVerify.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmEditNEETDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/HintBox.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        function checkAppearedForNEET(sender, args) {
            if (document.getElementById("rightContainer_ContentTable2_rbnAppearedForNEETYes").checked || document.getElementById("rightContainer_ContentTable2_rbnAppearedForNEETNo").checked) {
            }
            else {
                args.IsValid = false;
            }
        }

        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class="AppFormTable">
            <tr>
                <td style="width: 50%" align="right">Application ID</td>
                <td style="width: 50%">
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidate's Name</td>
                <td>
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="NEET 2024 Details">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upNEET">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 50%" align="right">Have you Appeared for NEET <%=CurrentYear %></td>
                        <td style="width: 50%">
                            <asp:RadioButton ID="rbnAppearedForNEETYes" runat="server" GroupName="AppearedForNEET" Text="&nbsp;&nbsp;Yes" AutoPostBack="true" OnCheckedChanged="AppearedForNEET_CheckedChanged" onmouseover="ddrivetip('Please Select Appeared Status for NEET 2024.')" onmouseout="hideddrivetip()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbnAppearedForNEETNo" runat="server" GroupName="AppearedForNEET" Text="&nbsp;&nbsp;No" AutoPostBack="true" OnCheckedChanged="AppearedForNEET_CheckedChanged" onmouseover="ddrivetip('Please Select Appeared Status for NEET 2024.')" onmouseout="hideddrivetip()" />
                            <asp:CustomValidator ID="cvAppearedForNEET" runat="server" ClientValidationFunction="checkAppearedForNEET" Display="None" ErrorMessage="Please Select Appeared Status for NEET 2024."></asp:CustomValidator>
                        </td> 
                    </tr>

                    <tr id="trNEETDocument" runat="server" visible="false">
                        <td align="right">NEET Document View </td>
                        <td>
                             <input type="button" id="btnviewNCL" value="View NEET Score Card" onclick="javascript:OpenViewDocumentPopUp()" cssclass="InputButton" backcolor="#F6223F" causesvalidation="false"></input>
                             <input type="hidden" name="NCLURL" value="" id="hdnNCLURL" runat="server" />
                        </td>
                    </tr>

                    <tr id="trNEETRollNo" runat="server">
                        <td align="right">Roll No</td>
                        <td>
                            <asp:TextBox ID="txtNEETRollNo" runat="server" MaxLength="10" Width="100px" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter NEET 2024 Roll No. It should be numeric and of 10 digits.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvNEETRollNo" runat="server" Display="None" ControlToValidate="txtNEETRollNo" ErrorMessage="Please Enter NEET 2024 Roll No."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETRollNo" runat="server" ErrorMessage="NEET 2024 Roll No. should be numeric and of 10 digits." ControlToValidate="txtNEETRollNo" Display="None" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cvNEETRollNo" runat="server" ErrorMessage="NEET 2024 Roll No. should not be zero." ControlToValidate="txtNEETRollNo" Display="None" Operator="NotEqual" ValueToCompare="0" Type="Integer"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr id="trNEETScore1" runat="server">
                        <td align="right">Physics Percentile</td>
                        <td>
                            <asp:TextBox ID="txtNEETPhysicsScore" MaxLength="11" Width="100px" runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Physics Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvNEETPhysicsScore" runat="server" Display="None" ControlToValidate="txtNEETPhysicsScore" ErrorMessage="Please Enter NEET 2024 Physics Percentile."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETPhysicsScore" runat="server" Display="None" ValidationExpression="^\d{1,3}\.\d{7}$" ControlToValidate="txtNEETPhysicsScore" ErrorMessage="Please Enter NEET 2024 Physics Percentile as per NEET Score card."></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETPhysicsScore" runat="server" ErrorMessage="NEET 2024 Physics Percentile Should be less than or equal to 100." ControlToValidate="txtNEETPhysicsScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id="trNEETScore2" runat="server">
                        <td style="width: 30%" align="right">Chemistry Percentile</td>
                        <td style="width: 20%">
                            <asp:TextBox ID="txtNEETChemistryScore" MaxLength="11" Width="100px" runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Chemistry Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvNEETChemistryScore" runat="server" Display="None" ControlToValidate="txtNEETChemistryScore" ErrorMessage="Please Enter NEET 2024 Chemistry Percentile."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETChemistryScore" runat="server" Display="None" ValidationExpression="^\d{1,3}\.\d{7}$" ControlToValidate="txtNEETChemistryScore" ErrorMessage="Please Enter NEET 2024 Chemistry Percentile as per NEET Score card."></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETChemistryScore" runat="server" ErrorMessage="NEET 2024 Chemistry Percentile Should be less than or equal to 100." ControlToValidate="txtNEETChemistryScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id="trNEETScore3" runat="server">
                        <td align="right">Biology (Botany & Zoology) Percentile</td>
                        <td>
                            <asp:TextBox ID="txtNEETBiologyScore" MaxLength="11" Width="100px" runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Biology (Botany & Zoology) Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvNEETBiologyScore" runat="server" Display="None" ControlToValidate="txtNEETBiologyScore" ErrorMessage="Please Enter NEET 2024 Biology (Botany & Zoology) Percentile."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETBiologyScore" runat="server" Display="None" ValidationExpression="^\d{1,3}\.\d{7}$" ControlToValidate="txtNEETBiologyScore" ErrorMessage="Please Enter NEET 2024 Biology (Botany & Zoology) Percentile as per NEET Score card."></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETBiologyScore" runat="server" ErrorMessage="NEET 2024 Biology (Botany & Zoology) Percentile Should be less than or equal to 100." ControlToValidate="txtNEETBiologyScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id="trNEETScore4" runat="server">
                        <td align="right">Total Percentile</td>
                        <td>
                            <asp:TextBox ID="txtNEETTotalScore" MaxLength="11" Width="100px" runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Total Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color="red">*</font>
                            <asp:RequiredFieldValidator ID="rfvNEETTotalScore" runat="server" Display="None" ControlToValidate="txtNEETTotalScore" ErrorMessage="Please Enter NEET 2024 Total Percentile."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETTotalScore" runat="server" Display="None" ValidationExpression="^\d{1,3}\.\d{7}$" ControlToValidate="txtNEETTotalScore" ErrorMessage="Please Enter NEET 2024 Total Percentile as per NEET Score card."></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETTotalScore" runat="server" ErrorMessage="NEET 2024 Total Percentile Should be less than or equal to 100." ControlToValidate="txtNEETTotalScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
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
            //var corrRow = cntrl.parentNode.parentNode;
            var filePath = document.getElementById('<%=hdnNCLURL.ClientID %>').value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            //corrRow.cells[corrRow.cells.length - 5].innerText

            // document.getElementById('lblDocumentName').innerHTML = corrRow.cells[corrRow.cells.length - 5].innerText;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + filePath + '">';
                    document.getElementById('divDocument').style.overflow = "auto";
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('divDocument').innerHTML = '<iframe src="' + filePath + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                    document.getElementById('divDocument').innerHTML = '<embed src="' + filePath + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }

    </script>
</asp:Content>
