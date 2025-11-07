<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="NEETDiscrepancy.aspx.cs" Inherits="Pharmacy2024.CandidateModule.NEETDiscrepancy" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
    </script>

    <table id="tblNEETDetailsold" runat="server" class="AppFormTable">

        <tr>
            <th colspan="4" style="border-top-width: 0px;" align="left"><%=NEETName %></th>
        </tr>
        <tr>
            <td colspan="2" style="width: 50%" align="right">Candidate Name As Per NEET</td>
            <td colspan="2" style="width: 50%">
             <asp:Label ID="lblCandidateNameold" runat="server" Font-Bold="true"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 50%" align="right">Roll No</td>
            <td colspan="2" style="width: 50%">
             <asp:Label ID="lblNEETRollNoold" runat="server" Font-Bold="true"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 50%" align="right">Physics Percentile</td>
            <td colspan="2" style="width: 50%">
             <asp:Label ID="lblphysicsold" runat="server" Font-Bold="true"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 50%" align="right">Chemistry Percentile</td>
            <td colspan="2" style="width: 50%">
             <asp:Label ID="lblchemistryold" runat="server" Font-Bold="true"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 50%" align="right">Biology (Botany & Zoology) Percentile</td>
            <td colspan="2" style="width: 50%">
             <asp:Label ID="lblbiologyold" runat="server" Font-Bold="true"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="width: 50%" align="right">Total Percentile</td>
            <td colspan="2" style="width: 50%">
             <asp:Label ID="lbltotalold" runat="server" Font-Bold="true"></asp:Label></td>
        </tr>

    </table>
    <cc1:ContentBox ID="ContentTable2" runat="server" >
        <asp:UpdateProgress runat="server" id="PageUpdateProgress">
            <ProgressTemplate>
                <img src ="../Images/BigProgress.gif" alt = "" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upNEET">
            <ContentTemplate>
            <table class = "AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color = "red">
                        <p align = "justify"><font color = "red"><b>Note :</b></font></p>
                        <ul class="list-text">
                            <li><p align = "justify"><font color = "red">preference shall be given to the candidate obtaining non zero positive score in NEET over the candidates who obtained non zero score in MHTCET <%= CurrentYear %>.</font></p></li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>
	            <table class="AppFormTable">
                     
                    
	                <tr id = "trNEETRollNo" runat = "server">
                        <td align="right">Roll No <br /> आसन क्रमांक</td>
			            <td>
                            <asp:TextBox ID="txtNEETRollNo" Runat="server" MaxLength="10" Width = "100px" onKeyPress="return numbersonly(event)" onmouseover="ddrivetip('Please Enter NEET 2024 Roll No. It should be numeric and of 10 digits.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvNEETRollNo" Runat="server" Display="None" ControlToValidate="txtNEETRollNo" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNEETRollNo" Runat="server"  ControlToValidate="txtNEETRollNo" Display="None" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cvNEETRollNo" Runat="server"  ControlToValidate="txtNEETRollNo" Display="None" Operator="NotEqual" ValueToCompare="0" Type="Integer"></asp:CompareValidator>
                        </td>
			        </tr>
                    <tr id = "trNEETScore1" runat = "server">
                        <td align="right">Physics Percentile<br /> भौतिकशास्‍त्र</td>
                        <td>
                            <asp:TextBox id="txtNEETPhysicsScore" MaxLength="10" Width="100px" Runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Physics Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red">*</font>
                            <asp:RequiredFieldValidator id="rfvNEETPhysicsScore" Runat="server" Display="None" ControlToValidate="txtNEETPhysicsScore" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revNEETPhysicsScore" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETPhysicsScore" ></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETPhysicsScore" runat="server"  ControlToValidate="txtNEETPhysicsScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id = "trNEETScore2" runat = "server">
                        <td style="width: 30%" align="right">Chemistry Percentile <br /> रसायनशास्‍त्र</td>
                        <td style="width: 20%">
                            <asp:TextBox id="txtNEETChemistryScore" MaxLength="10" Width="100px" Runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Chemistry Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red">*</font>
                            <asp:RequiredFieldValidator id="rfvNEETChemistryScore" Runat="server" Display="None" ControlToValidate="txtNEETChemistryScore" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revNEETChemistryScore" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETChemistryScore" ></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETChemistryScore" runat="server"  ControlToValidate="txtNEETChemistryScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id = "trNEETScore3" runat = "server">
                        <td align="right">Biology (Botany & Zoology) Percentile <br />जिवशास्‍त्र ( वनस्पतीशास्‍त्र व प्राणीशास्‍त्र)</td>
                        <td>
                            <asp:TextBox id="txtNEETBiologyScore" MaxLength="10" Width="100px" Runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Biology (Botany & Zoology) Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red">*</font>
                            <asp:RequiredFieldValidator id="rfvNEETBiologyScore" Runat="server" Display="None" ControlToValidate="txtNEETBiologyScore" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revNEETBiologyScore" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETBiologyScore" ></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETBiologyScore" runat="server"  ControlToValidate="txtNEETBiologyScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr id = "trNEETScore4" runat = "server">
                        <td align="right">Total Percentile<br /> एकुण</td>
                        <td>
                            <asp:TextBox id="txtNEETTotalScore" MaxLength="10" Width="100px" Runat="server" onmouseover="ddrivetip('Please Enter NEET 2024 Total Percentile. It should be numeric.')" onmouseout="hideddrivetip()"></asp:TextBox>
                            <font color = "red">*</font>
                            <asp:RequiredFieldValidator id="rfvNEETTotalScore" Runat="server" Display="None" ControlToValidate="txtNEETTotalScore" ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator id="revNEETTotalScore" Runat="server" Display="None" ValidationExpression="[0-9.]+" ControlToValidate="txtNEETTotalScore" ></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="rvNEETTotalScore" runat="server"  ControlToValidate="txtNEETTotalScore" Display="None" MaximumValue="100" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
	            </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>
