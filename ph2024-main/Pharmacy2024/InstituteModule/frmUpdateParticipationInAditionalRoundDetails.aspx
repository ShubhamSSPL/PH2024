<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmUpdateParticipationInAditionalRoundDetails.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmUpdateParticipationInAditionalRoundDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function checkParticipationInCap(sender, args) 
        {
            if (document.getElementById("rightContainer_ContentTable1_rbnYes").checked || document.getElementById("rightContainer_ContentTable1_rbnNo").checked) 
            {
            }
            else 
            {
                args.IsValid = false;
            }
        }
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Participation In Aditional CAP Round">
    <table class="AppFormTableWithOutBorder">
                <tr>
                    <td>
                        <center><font size="2"><b><u>महत्वाच्या सूचना :</u></b></font></center>
                        <br />
                        <ol class="list-text">
                                 
                                    <li><p align = "justify">ज्या विनानुदानित औषधनिर्माणशास्त्र संस्थाना या प्रवेश प्रक्रियेमध्ये भाग घ्यावयाचा आहे अशा औषधनिर्माणशास्त्र पदवी अभ्यासक्रमाच्या संस्थांनी संचालनालयाच्या संकेतस्थळावर  संस्थेच्या Login मधून अतिरिक्त फेरीमध्ये समाविष्ट करून घेण्यासाठी व केंद्रीभूत प्रवेश प्रक्रियेमधून त्यांचेकडे परत करण्यात आलेल्या जागा पुन्हा केंद्रीभूत प्रवेश प्रक्रियेसाठी समर्पित करण्यासाठी स्वीकृती देणे आवश्यक आहे.</p></li>
                                    <li><p align = "justify">अर्ज करणाऱ्या औषधनिर्माणशास्त्र संस्थांनी तिसरी फेरी झाल्यानंतर केंद्रीभूत प्रवेश प्रक्रियेमधून त्यांचेकडे परत करण्यात आलेल्या जागाच्या बदल्यात जर संस्था स्तरावर प्रवेश दिलेले असतील तर त्याची माहिती online पद्धतीने संचालनालयाच्या संकेतस्थळावर Update करणे आवश्यक आहे.</p></li>
                                    <li><p align = "justify">संस्थेने Online पध्दतीने अतिरिक्त फेरीमध्ये समाविष्ट होण्यासाठी स्वीकृती दिल्यानंतर  त्या औषधनिर्माणशास्त्र संस्थेच्या केंद्रीभूत प्रवेश प्रक्रियेमधून शिल्लक राहिलेल्या रिक्त जागा आपोआप अतिरिक्त फेरीसाठी घेण्यात येतील.  त्यानंतर संस्थाना त्यामध्ये कोणत्याही प्रकारचा बदल कोणत्याही सबबीखाली करता येणार नाही. व संस्थेस अशा जागा संस्था स्तरावर भरता  येणार नाहीत.</p></li>
                                
                        </ol>
                    </td>
                </tr>
            </table>
        <table class="AppFormTable"> 
        </tr>
            <tr>
                <td style="width: 50%;" align="right">
                    Do you wish to Participate in Additional CAP Round?
                </td>
                <td style="width: 50%;">
                    <asp:RadioButton ID="rbnYes" runat="server" GroupName="ParticipationInCap" Text="&nbsp;&nbsp;Yes" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbnNo" runat="server" GroupName="ParticipationInCap" Text="&nbsp;&nbsp;No" />
                    <asp:CustomValidator ID="cvParticipationInCap" runat="server" ClientValidationFunction="checkParticipationInCap" Display="None" ErrorMessage="Please Select Participation In Aditional CAP Round."></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <br />
                    <asp:Button ID="btnProceed" runat="server" Text=" Save & Proceed >>> " CssClass="InputButton" OnClick="btnProceed_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                    <br /><br />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
