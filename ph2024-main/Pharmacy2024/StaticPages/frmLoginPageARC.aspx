<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmLoginPageARC.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmLoginPageARC" %>

<%@ Register Assembly="Synthesys.Controls.LoginBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        #rightContainer_cbLoginBox_LoginBox1_btnUpdateSecurityPin {
            margin-left: 10px;
            margin-bottom: -7px;
        }
    </style>
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>
    <script>
        $(document).ready(function () {
            $('#rightContainer_cbLoginBox_LoginBox1_txtSecurityPin').keyup(function () {
                var inputValue = $(this).val();
                var upperCaseValue = inputValue.toUpperCase();
                $(this).val(upperCaseValue);
            });
        });
    </script>
    <script>
        function load() {

            var tblLogin = document.getElementsByTagName("table")[2];
            var tblCaptcha = document.getElementsByTagName("table")[3];

            if (tblLogin.rows.length == 3) {
                var rowUserName = tblLogin.rows[1];
                var rowPassword = tblLogin.rows[2];
                var rowSignBtn = tblLogin.rows[2];

                var rowCaptcha = tblCaptcha.rows[0];

                tblLogin.deleteRow(2);

                tblCaptcha.insertRow(1).innerHTML = rowSignBtn.innerHTML;
            }
            if (tblLogin.rows.length == 4) {
                var rowUserName = tblLogin.rows[0];
                var rowPassword = tblLogin.rows[1];
                var rowMessage = tblLogin.rows[2];
                var rowSignBtn = tblLogin.rows[3];

                var rowCaptcha = tblCaptcha.rows[0];

                tblLogin.deleteRow(3);

                tblCaptcha.insertRow(1).innerHTML = rowSignBtn.innerHTML;
            }
        }
        window.onload = load;
    </script>

    <cc1:ContentBox runat="server" ID="cbLoginBox" HeaderText="Login">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td style="width: 40%;" valign="top">

                    <div class="row w-100  mx-auto">
                        <div class="col-sm-4  px-0">
                            <center>
                                <cc1:LoginBox ID="LoginBox1" runat="server" LoginButtonType="Button" UseFormsAuthentication="true" LoginButtonImageUrl="~/SynthesysModules_Files/Images/btn-login.png" PasswordLabelText="Password : " UserNameLabelText="Login ID : " LoginButtonText="Sign In" Font-Names="verdana" Font-Size="12px" ShowBorder="false" FailureText="Invalid Login ID or Password.">
                                    <loginbuttonstyle cssclass="InputButton" />
                                    <textboxstyle width="120" />
                                </cc1:LoginBox>
                            </center>
                        </div>
                        <div class="col-sm-8  text-left">
                            <font color="red">
                                <p align="justify"><font color="red"><b>Instructions :</b></font></p>
                                <ol class="list-text">
                                    <li>
                                        <p align="justify"><font color="red">Please enter your Login ID and Password.</font></p>
                                    </li>
                                    <li>
                                        <p align="justify"><font color="red">You are advised not to disclose or share your password with anybody.</font></p>
                                    </li>
                                    <li>
                                        <p align="justify"><font color="red">Only authorised users are allowed to proceed further.</font></p>
                                    </li>
                                    <li>
                                        <p align="justify"><font color="red">Your IP Address and other information will be captured for security reasons.</font></p>
                                    </li>
                                </ol>
                            </font>
                        </div>
                    </div>


                </td>

            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>

