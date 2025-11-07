<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmcreateUser.aspx.cs" Inherits="Pharmacy2024.AdminModule.frmcreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
     
     <script language="javascript" type = "text/javascript">
         window.history.forward(1);
         function DisableCopyPaste(e) {

             var message = "Right Click/Ctrl+C/Ctrl+V Options are not allowed.";
             var kCode = event.keyCode || e.charCode;
             //FF and Safari use e.charCode, while IE use e.keyCode
             if (kCode == 17 || kCode == 2) {
                 alert(message);
                 return false;
             }
             if (e.button == 2) {
                 alert(message);
                 return false;
             }
         }
         function AllowAlphabet(e) {
             isIE = document.all ? 1 : 0
             keyEntry = !isIE ? e.which : event.keyCode;
             if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
                 return true;
             else {
                 /*alert('Please Enter Only Character values.'); */
                 return false;
             }
         }
     </script>
    <table class="AppFormTable">
            <tr>
                <td align="right" style="width: 30%">User Type </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlUserType" BackColor="LemonChiffon" Font-Bold="true" Font-Size="Medium" runat="server" Width="50%" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSOSELECT" runat="server" ControlToValidate="ddlUserType" ErrorMessage="Please Select User Tpye." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="ADD"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 30%">Login Id </td>
                <td style="width: 70%">
                    <asp:TextBox ID="txtLoginId" runat="server" Width="500px" MaxLength="250" ></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                  <%--  <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server"  ControlToValidate="txtLoginId"  
                    ErrorMessage="* entry only character value."  display="dynamic">* </asp:RegularExpressionValidator>--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginId" ErrorMessage="Please Enter Login Id to be Added." Display="none" ValidationGroup="ADD"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 30%">Name</td>
                <td style="width: 70%">
                    <asp:TextBox ID="txtUserName" runat="server" Width="500px" MaxLength="250" ></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
               <%--     <asp:RegularExpressionValidator id="valRegEx" runat="server"  ControlToValidate="txtUserName"  ValidationExpression="[^a-z][A-Z]+$" ValidationGroup="ADD"
                    ErrorMessage="* entry only character value."  display="dynamic">* </asp:RegularExpressionValidator>--%>
<%--                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please User Name to be Added." Display="none" ValidationGroup="ADD"></asp:RequiredFieldValidator>--%>
                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName" Display="None" ErrorMessage="Please Enter User Name to be Added." ValidationGroup="ADD"></asp:RequiredFieldValidator>
               --%>
                </td>
            </tr>
            <tr>
                <td align="right">User Mobile No</td>
                <td><%--txtSubAFCOfficerMobileNo--%>
                    <asp:TextBox ID="txtuserMobileNo" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvtxtuserMobileNo" runat="server" ControlToValidate="txtuserMobileNo" Display="None" ErrorMessage="Please Enter User  Mobile No to be Added." ValidationGroup="ADD"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revtxtuserMobileNo" runat="server" ControlToValidate="txtuserMobileNo" Display="None" ErrorMessage="User Mobile No to be Added Should be Proper and of 10 Digits." ValidationExpression="^[7-9]\d{9}$" ValidationGroup="ADD"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">User Email Id</td>
                <td>
                    <asp:TextBox ID="txtuserEmailId" runat="server" MaxLength="100" Width="500px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvtxtuserEmailId" runat="server" ControlToValidate="txtuserEmailId" Display="None" ErrorMessage="Please Enter E-Mail ID." ValidationGroup="ADD"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revtxtuserEmailId" runat="server" ControlToValidate="txtuserEmailId" Display="Dynamic" ErrorMessage="Please Enter Valid E-Mail ID." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ADD"></asp:RegularExpressionValidator>
                </td>
            </tr>
             <tr>
                <td style="width: 50%;" align="right">User Password</td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength = "13" onKeyDown="return DisableCopyPaste(event)" onMouseDown="return DisableCopyPaste(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter Password." ValidationGroup="ADD" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" Display="None"  ValidationGroup="ADD" ErrorMessage=" Password must be 8 to 13 character long and must have at least one Upper case alphabet, one Lower case alphabet, one numeric value and one special character." ValidationExpression="^.*(?=^.{8,13}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Confirm  Password</td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" MaxLength = "13" onKeyDown="return DisableCopyPaste(event)" onMouseDown="return DisableCopyPaste(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please Enter Confirm Password." Display="None" ValidationGroup="ADD"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" ErrorMessage="Password and Confirm Password should be Same." ValidationGroup="ADD" Display = "None"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add User" OnClick="btnAdd_Click" CssClass="InputButton" ValidationGroup="ADD" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ADD" />
                </td>
            </tr>
        </table>
</asp:Content>
