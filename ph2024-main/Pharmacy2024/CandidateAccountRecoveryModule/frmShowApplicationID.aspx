<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmShowApplicationID.aspx.cs" Inherits="Pharmacy2024.CandidateAccountRecoveryModule.frmShowApplicationID" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
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
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Message">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center"><br /><font size = "4" color = "red"><b>Your Application ID : <asp:Label ID="lblApplicationID" runat="server"></asp:Label></b></font></td>
            </tr>
            <tr>
                <td align="left">
                    <br />
                    Kindly note down your Application ID that is required for future reference.
                </td>
            </tr>
            <tr>
                <td align = "center">
                    <br />
                    <asp:Button ID="btnProceed" runat="server" Text="Click Here to Login" CssClass="InputButton" OnClick="btnProceed_Click" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
