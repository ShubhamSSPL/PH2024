<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAccountRecovery.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmAccountRecovery" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <style>
         /*@media only screen and (width: 320px) {
            #layoutSidenav {
                margin-top: 75.5% !important;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 97% !important;
            }
        }

        @media only screen and (max-width: 425px) {
            #layoutSidenav {
                margin-top: 52.5%;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 89%;
            }
        }

        @media only screen and (width: 768px) {
            #layoutSidenav {
                margin-top: 17.5% !important;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 59%;
            }
        }

        @media only screen and (width:1024px) {
            #layoutSidenav {
                margin-top: 12.4%;
            }

            .sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
                margin-top: 57%;
            }
        }*/
    </style>
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function checkAccountRecovery(sender, args) 
        {
            if (document.getElementById("rightContainer_ContentTable1_rbnForgotPassword").checked || document.getElementById("rightContainer_ContentTable1_rbnForgotApplicationID").checked) 
            {
            }
            else 
            {
                args.IsValid = false;
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Having trouble signing in ?">
        <br />
        <table class = "AppFormTable">
            <tr>
                <th align = "left">Please Select</th>
            </tr>
            <tr>
                <td style="width: 70%">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbnForgotPassword" runat="server" Text="&nbsp;&nbsp;I forgot my Password." GroupName="AccountRecovery"  />
                    <br /><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbnForgotApplicationID" runat="server" Text="&nbsp;&nbsp;I forgot my Application ID" GroupName="AccountRecovery" />
                    <asp:CustomValidator ID="cvAccountRecovery" runat="server" ClientValidationFunction="checkAccountRecovery" Display="None" ErrorMessage="Please Select atleast one option."></asp:CustomValidator>
                    <br /><br /><br /><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnContinue" runat="server" Text="CONTINUE" CssClass="InputButton" Width = "100px" OnClick="btnContinue_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                    <br /><br />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>


