<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmInstructionsAfterRegistration.aspx.cs" Inherits="Pharmacy2024.RegistrationModule.frmInstructionsAfterRegistration" %>
 
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        /* @media only screen and (width: 320px) {
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
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Instructions">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center"><b><font size="2" color="green">Registered Successfully for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %></font></b></td>
            </tr>
            <tr>
                <td align="center"><br /><font size = "4" color = "red"><b>Application ID : <asp:Label ID="lblApplicationID" runat="server"></asp:Label></b></font></td>
            </tr>
            <tr>
                <td align="left">
                    <br />
                    <p align = "justify"><b>Important Instruction :</b></p>
                    <br />
                    <ol class="list-text">
                        <li><p align = "justify">Please note down system generated Application ID and chosen Password for all future logins.</p></li>
                        <li><p align = "justify">Candidate is advised not to disclose or share their password with anybody. CET Cell will not be responsible for violation or misuse of the password of a candidate.</p></li>
                        <li><p align = "justify">Candidate can change his/her passwords after login, if desired.</p></li>
                        <li><p align = "justify">Candidate should remember to log out at the end of their session so that the particulars of the candidate cannot be tampered or modified by unauthorized persons.</p></li>
                        <li><p align = "justify">Candidate can reset Password using a verification code sent via text message (SMS) to Candidate's Registered Mobile No.</p></li>
                        <li><p align = "justify">Application ID has been sent to Candidate's Registered Mobile Number.</p></li>
                    </ol>
                </td>
            </tr>
            <tr>
                <td align = "center">
                    <br />
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed to Complete Application Form >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
</asp:Content>

