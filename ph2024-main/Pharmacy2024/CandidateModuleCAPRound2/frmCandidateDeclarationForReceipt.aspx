<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmCandidateDeclarationForReceipt.aspx.cs" Inherits="Pharmacy2024.CandidateModuleCAPRound2.frmCandidateDeclarationForReceipt" %>


<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .form-input {
            border: 1px solid #d9d9d9;
            font-size: 13px;
            height: 34px;
            padding: 4px;
            border-radius: 4px;
            color: #000000
        }

        .AppFormTable input {
            height: auto;
            padding: 4px;
        }
    </style>
    <style>
        * {
            margin: 0;
        }

        html, body {
            height: 100%;
        }

        .wrapper {
            width: 100% !important;
            height: auto !important;
            background-color: gray;
        }

        .push {
            height: 50px;
        }

        .tbl {
            display: table;
            width: 100%;
            /*            background-color: #c4a000;*/
            /*  background-color: #E9F7F9;*/
            background-color: #04a2b3
        }

        .full {
            width: 100%
        }

        .c20 {
            display: table-cell;
            padding: 15px;
            width: 20%;
            text-align: center;
        }

        .c50 {
            display: table-cell;
            padding: 15px;
            width: 50%;
            text-align: center;
        }

        button {
            border: 0px;
            width: 100%;
            min-height: 35px;
            cursor: pointer;
        }
    </style>


    <style>
        .pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .doc-container {
            width: 65.6rem;
            height: 25rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .InnerBodyDiv {
            height: auto !important;
        }

        #rightContainer_contentAppleSarkarBarti {
            width: 100% !important;
        }

        #rightContainer_contentViewDocument {
            top: 11% !important;
            width: 85% !important;
        }

        @media only screen and (max-width: 768px) {

            #rightContainer_contentViewDocument {
                top: 32% !important;
                width: 100% !important;
            }

            .doc-container {
                height: 16rem !important;
            }
        }

        @media only screen and (max-width: 1024px) {

            #rightContainer_contentViewDocument {
                top: 20% !important;
                width: 100% !important;
            }
        }
    </style>

    <style>
        .divopacity {
            width: 100%;
            height: 100%;
            position: absolute;
            z-index: 1000;
            background: #345678;
            opacity: 0.3;
            text-align: center;
        }
    </style>
    <style>
           #rightContainer_contentDocumentConferamtion_chkIAgree {
            width: 20px;
            height: 20px;
             }
          #rightContainer_contentDocumentConferamtion {
            position: fixed !important;
            top: 15% !important;
            width:70%;          
            z-index:2000 !important ;
        }
          #rightContainer_contentDocumentConferamtion .BodyDiv{
                height:450px;
            }

        @media only screen and (max-width: 768px) {
            #rightContainer_contentDocumentConferamtion {
                position: fixed !important;
                top: 20% !important;
                width:90%;    
                height:300px !important;
            }
            #rightContainer_contentDocumentConferamtion .BodyDiv{
                height:350px;
            }
        }


         #rightContainer_contentDocumentConferamtionCON_chkIAgree {
            width: 20px;
            height: 20px;
             }
          #rightContainer_contentDocumentConferamtionCON {
            position: fixed !important;
            top: 15% !important;
            width:70%;          
            z-index:2000 !important ;
        }
          #rightContainer_contentDocumentConferamtionCON .BodyDiv{
                height:450px;
            }

        @media only screen and (max-width: 768px) {
            #rightContainer_contentDocumentConferamtionCON {
                position: fixed !important;
                top: 20% !important;
                width:90%;    
                height:300px !important;
            }
            #rightContainer_contentDocumentConferamtionCON .BodyDiv{
                height:350px;
            }
        }

        p {
            line-height: 18px;
            padding: 2px 2px 10px;
            margin: 0;
            font-size: 12px;
            font-family: Verdana;
            color: #000000;
        }

            p a {
                color: #1e5a9c;
                line-height: 18px;
                padding: 5px 5px;
                margin: 0;
                font-size: 12px;
                text-decoration: underline;
            }

                p a:link {
                    color: #A52A2A;
                    line-height: 18px;
                    padding: 5px 5px;
                    margin: 0;
                    font-size: 12px;
                    text-decoration: none;
                }

                p a:visited {
                    color: #A52A2A;
                    line-height: 18px;
                    padding: 5px 5px;
                    margin: 0;
                    font-size: 12px;
                    text-decoration: underline;
                }

                p a:hover {
                    color: #CC3838;
                    line-height: 18px;
                    padding: 5px 5px;
                    width: 100%;
                    margin: 0;
                    font-size: 12px;
                    text-decoration: none;
                }

                p a:active {
                    color: #CC3838;
                    line-height: 18px;
                    padding: 5px 5px;
                    margin: 0;
                    font-size: 12px;
                    text-decoration: underline;
                }

        .AppFormTable th {
            border: 1px solid #9365d8;
        }

        .AppFormTable td {
            border: 1px solid #e1e5e8;
        }

        .talkbubble {
            position: relative;
        }

            .talkbubble:before {
                content: "";
                position: absolute;
                left: 100%;
                top: 50%;
                transform: translateY(-50%);
                width: 0;
                height: 0;
                border-top: 10px solid transparent;
                border-left: 12px solid #F6223F;
                border-bottom: 10px solid transparent;
            }
           
            
    </style>
    <script src="../Scripts/mcfCrop.js"></script>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript">jQuery.noConflict();</script>
    <script src="https://fengyuanchen.github.io/shared/google-analytics.js" crossorigin="anonymous"></script>
    <script type="text/javascript" src="../dist/main.js"></script>
  
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);

        function ShowConfirmationBox() {
            document.getElementById('<%=contentDocumentConferamtion.ClientID %>').Show('', true, 'Fullscreen = yes');
        }
        function ShowConfirmationBoxCON() {
            document.getElementById('<%=contentDocumentConferamtionCON.ClientID %>').Show('', true, 'Fullscreen = yes');
        }
        window.onload = load;

    </script>

    <table class="AppFormTable" style="background-color: #e7fafe;">
        <tr>
            <th colspan="4" align="left">Personal Information
            </th>
        </tr>
        <tr>
            <td style="width: 20%" align="right">Application ID
            </td>
            <td style="width: 30%">
                <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td style="width: 20%" align="right">Candidate Name
            </td>
            <td style="width: 30%">
                <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Gender
            </td>
            <td>
                <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Date of Birth
            </td>
            <td>
                <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Candidature Type
            </td>
            <td>
                <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Home University
            </td>
            <td>
                <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Category for Admission
            </td>
            <td>
                <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Person with Disability
            </td>
            <td>
                <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Applied for EWS
            </td>
            <td>
                <asp:Label ID="lblAppliedforEWS" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Applied for Orphan
            </td>
            <td>
                <asp:Label ID="lblAppliedforOrphan" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Defence Type
            </td>
            <td>
                <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td align="right">Applied for TFWS
            </td>
            <td>
                <asp:Label ID="lblAppliedForTFWS" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Minority Candidature Type
            </td>
            <td colspan="3">
                <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
   

    <%--CVCTVC--%>

    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Continue with receipt or Convert to Open"
        Visible="False">
        <br />
        <table class="AppFormTable">
            <tr>
                <td colspan="2">

                    <ol class="list-text">
                        <b>Important Instructions :</b>
                     <li><p align = "justify">As per the decision taken by the competent authority during CAP - I, We restored your category to your original category as per the final merit list and now if you want to convert your category to OPEN / NON-EWS. You are allow to convert it for remaining subsequent rounds.</p></li>
                     <li><p align = "justify">Candidate those who have selected Betterment/Not Freeze & submitted receipt of CVC/TVC,EWS, or NCL is aware that he can not submit the document before the last day of CAP round II Reporting date ,such a candidate can convert himself/herself in to open category / NON-EWS while filling CAP Round II Option Form. If Candidate availed benefit of Category / EWS in CAP Round I, those candidate seat will get cancelled and candidate will be considered in to OPEN category / NON-EWS for the Subsequent rounds of CAP and if the Candidate not availed the benefit of the Category / EWS in CAP Round I, those candidates seat will be retained & the candidate will be considered in to Open category / NON-EWS for Subsequent rounds of CAP.</p></li>
                     <li><p align = "justify">Candidates those who have not allotted any seat in CAP Round I , Can convert himself/herself in to OPEN category / NON-EWS if they are aware that they will not be able to produce original document of CVC/TVC,NCL or EWS till the last day of CAP Round II Reporting date & such candidates will be eligible for Allotment of seat in CAP Round II in Open Category / NON-EWS.</p></li>
                     <li><p align = "justify">Once you converted yourself into OPEN category / NON-EWS then you are considered Only in OPEN category / NON-EWS for seat allotment in the next CAP round / additional institutional round.</p></li>
                     <li><p align = "justify">OPEN category / NON-EWS converted candidate will not be able to convert back into reserved / EWS category.</p></li>
                    </ol>
                    
                 <ul class="list-text">
                        <font color="red" ><b>Note: As per the decision taken by the Competent Authority during CAP Round-I, We restored candidates categories back to their original categories as per the final merit list and now if candidate want to convert himself/herself to Open/Non-EWS(In the case of EWS candidate) before CAP-II Option form submission are allow to convert for remaining subsequent rounds.</b></font>
                    </ul>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnYes" runat="server" Text="Continue With Receipt" CssClass="InputButton" OnClick="btnYes_Click" />
                    <br />
                    <font color="red" ><b>(Candidate need to submit original document on or before 22/12/2021 upto 05:00PM.)</b></font>
                </td>
                <td align="center">
                    <asp:Button ID="btnNo" runat="server" Text="Convert to Open" CssClass="InputButton"  OnClick="btnNo_Click" />
                    <br />
                    <font color="red" ><b>(If you have availed benefit of Category/EWS in CAP Round I then allotted seat will be cancelled.)</b></font>
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Convert to Open Not having CVC/TVC or NCL Certificate"
        Visible="False">
        <br />
        <table class="AppFormTable">
            <tr>   
                <td colspan="2"> 

                    <ol class="list-text">
                        <b>Important Instructions :</b>
                       <%-- <li><p align = "justify">Candidate those who have selected Betterment/Not Freeze & submitted receipt of CVC/TVC,EWS, or NCL is aware that he can not submit the document before the last day of CAP round II Reporting date ,such a candidate can convert himself/herself in to open category while filling CAP Round II Option Form. If Candidate availed benefit of Category/EWS in CAP Round I, those candidate seat will get cancelled and candidate will be considered in to OPEN category for the Subsequent rounds of CAP and if the Candidate not availed the benefit of the Category/EWS in CAP Round I, those candidates seat will be retained & the candidate will be considered in to Open category for Subsequent rounds of CAP.</p></li>
                        <li><p align = "justify">Candidates those who have not allotted any seat in CAP Round I , Can convert himself/herself in to OPEN category if they are aware that they will not be able to produce original document of CVC/TVC,NCL or EWS till the last day of CAP Round II Reporting date & such candidates will be eligible for Allotment of seat in CAP Round II in Open Category.</p></li>
                     --%>
                     <li><p align = "justify">As per the decision taken by the competent authority during CAP - I, We restored your category to your original category as per the final merit list and now if you want to convert your category to OPEN / NON-EWS. You are allow to convert it for remaining subsequent rounds.</p></li>
                     <li><p align = "justify">Candidate those who have selected Betterment/Not Freeze & submitted receipt of CVC/TVC,EWS, or NCL is aware that he can not submit the document before the last day of CAP round II Reporting date ,such a candidate can convert himself/herself in to open category / NON-EWS while filling CAP Round II Option Form. If Candidate availed benefit of Category / EWS in CAP Round I, those candidate seat will get cancelled and candidate will be considered in to OPEN category / NON-EWS for the Subsequent rounds of CAP and if the Candidate not availed the benefit of the Category / EWS in CAP Round I, those candidates seat will be retained & the candidate will be considered in to Open category / NON-EWS for Subsequent rounds of CAP.</p></li>
                     <li><p align = "justify">Candidates those who have not allotted any seat in CAP Round I , Can convert himself/herself in to OPEN category / NON-EWS if they are aware that they will not be able to produce original document of CVC/TVC,NCL or EWS till the last day of CAP Round II Reporting date & such candidates will be eligible for Allotment of seat in CAP Round II in Open Category / NON-EWS.</p></li>
                     <li><p align = "justify">Once you converted yourself into OPEN category / NON-EWS then you are considered Only in OPEN category / NON-EWS for seat allotment in the next CAP round / additional institutional round.</p></li>
                     <li><p align = "justify">OPEN category / NON-EWS converted candidate will not be able to convert back into reserved / EWS category.</p></li>
                    </ol>
                    
                 <ul class="list-text">
                        <font color="red" ><b>Note: As per the decision taken by the Competent Authority during CAP Round-I, We restored candidates categories back to their original categories as per the final merit list and now if candidate want to convert himself/herself to Open/Non-EWS(In the case of EWS candidate) before CAP-II Option form submission are allow to convert for remaining subsequent rounds.</b></font>
                    </ul>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnConvertToOpen" runat="server" Text="Process to Convert to OPEN"  CssClass="InputButton" OnClick="btnConvertToOpen_Click" />
                    <br />
                    <font color="red" ><b>(If you have availed benefit of Category/EWS in CAP Round I then allotted seat will be cancelled.)</b></font>
                </td>
                <%-- <td align="center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="InputButton" OnClick="btnCancel_Click" />
                </td>--%>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
     <%--EWS--%>

    <cc1:ContentBox ID="ContentBoxEWS" runat="server" HeaderText="Continue with receipt or Convert to Non-EWS"
        Visible="False">
        <br />
        <table class="AppFormTable">
            <tr>  
                <td colspan="2"> 

                    <ol class="list-text">
                        <b>Important Instructions :</b>
                     <li><p align = "justify">As per the decision taken by the competent authority during CAP - I, We restored your category to your original category as per the final merit list and now if you want to convert your category to OPEN / NON-EWS. You are allow to convert it for remaining subsequent rounds.</p></li>
                     <li><p align = "justify">Candidate those who have selected Betterment/Not Freeze & submitted receipt of CVC/TVC,EWS, or NCL is aware that he can not submit the document before the last day of CAP round II Reporting date ,such a candidate can convert himself/herself in to open category / NON-EWS while filling CAP Round II Option Form. If Candidate availed benefit of Category / EWS in CAP Round I, those candidate seat will get cancelled and candidate will be considered in to OPEN category / NON-EWS for the Subsequent rounds of CAP and if the Candidate not availed the benefit of the Category / EWS in CAP Round I, those candidates seat will be retained & the candidate will be considered in to Open category / NON-EWS for Subsequent rounds of CAP.</p></li>
                     <li><p align = "justify">Candidates those who have not allotted any seat in CAP Round I , Can convert himself/herself in to OPEN category / NON-EWS if they are aware that they will not be able to produce original document of CVC/TVC,NCL or EWS till the last day of CAP Round II Reporting date & such candidates will be eligible for Allotment of seat in CAP Round II in Open Category / NON-EWS.</p></li>
                     <li><p align = "justify">Once you converted yourself into OPEN category / NON-EWS then you are considered Only in OPEN category / NON-EWS for seat allotment in the next CAP round / additional institutional round.</p></li>
                     <li><p align = "justify">OPEN category / NON-EWS converted candidate will not be able to convert back into reserved / EWS category.</p></li>
                    </ol>
                    
                 <ul class="list-text">
                        <font color="red" ><b>Note: As per the decision taken by the Competent Authority during CAP Round-I, We restored candidates categories back to their original categories as per the final merit list and now if candidate want to convert himself/herself to Open/Non-EWS(In the case of EWS candidate) before CAP-II Option form submission are allow to convert for remaining subsequent rounds.</b></font>
                    </ul>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnEWSYes" runat="server" Text="Continue With Receipt" CssClass="InputButton" OnClick="btnYes_Click" />
                    <br />
                    <font color="red" ><b>(Candidate need to submit original document on or before 22/12/2021 upto 05:00PM.)</b></font>
                </td>
                <td align="center">
                    <asp:Button ID="btnEWSNo" runat="server" Text="Convert to Non-EWS" CssClass="InputButton"  OnClick="btnEWSNo_Click" />
                    <br />
                    <font color="red" ><b>(If you have availed benefit of Category/EWS in CAP Round I then allotted seat will be cancelled.)</b></font>
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    
    <cc1:ContentBox ID="ContentBoxEWSOpen" runat="server" HeaderText="Convert to Non-EWS Not having EWS Certificate"
        Visible="False">
        <br />
        <table class="AppFormTable">
            <tr>
                <td colspan="2"> 

                    <ol class="list-text">
                        <b>Important Instructions :</b>
                     <li><p align = "justify">As per the decision taken by the competent authority during CAP - I, We restored your category to your original category as per the final merit list and now if you want to convert your category to OPEN / NON-EWS. You are allow to convert it for remaining subsequent rounds.</p></li>
                     <li><p align = "justify">Candidate those who have selected Betterment/Not Freeze & submitted receipt of CVC/TVC,EWS, or NCL is aware that he can not submit the document before the last day of CAP round II Reporting date ,such a candidate can convert himself/herself in to open category / NON-EWS while filling CAP Round II Option Form. If Candidate availed benefit of Category / EWS in CAP Round I, those candidate seat will get cancelled and candidate will be considered in to OPEN category / NON-EWS for the Subsequent rounds of CAP and if the Candidate not availed the benefit of the Category / EWS in CAP Round I, those candidates seat will be retained & the candidate will be considered in to Open category / NON-EWS for Subsequent rounds of CAP.</p></li>
                     <li><p align = "justify">Candidates those who have not allotted any seat in CAP Round I , Can convert himself/herself in to OPEN category / NON-EWS if they are aware that they will not be able to produce original document of CVC/TVC,NCL or EWS till the last day of CAP Round II Reporting date & such candidates will be eligible for Allotment of seat in CAP Round II in Open Category / NON-EWS.</p></li>
                     <li><p align = "justify">Once you converted yourself into OPEN category / NON-EWS then you are considered Only in OPEN category / NON-EWS for seat allotment in the next CAP round / additional institutional round.</p></li>
                     <li><p align = "justify">OPEN category / NON-EWS converted candidate will not be able to convert back into reserved / EWS category.</p></li>
                    </ol>
                    
                 <ul class="list-text">
                        <font color="red" ><b>Note: As per the decision taken by the Competent Authority during CAP Round-I, We restored candidates categories back to their original categories as per the final merit list and now if candidate want to convert himself/herself to Open/Non-EWS(In the case of EWS candidate) before CAP-II Option form submission are allow to convert for remaining subsequent rounds.</b></font>
                    </ul>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnEWSConvertToOpen" runat="server" Text="Process to Convert to Non-EWS" CssClass="InputButton" OnClick="btnEWSConvertToOpen_Click" />
                    <br />
                    <font color="red" ><b>(If you have availed benefit of Category/EWS in CAP Round I then allotted seat will be cancelled.)</b></font>
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    
    <cc1:ContentBox ID="cbPassword" runat="server">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upQualification">
            <ContentTemplate>
                <asp:HiddenField ID="hdnPassword" runat="server" />
                <table id="tblPasword" class="AppFormTable" runat="server">

                    <tr id="tr2" runat="server">
                        <td align="right" style="width: 50%;">Enter Your Login Password to receive OTP
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20" autocomplete="off"></asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                Display="None" ErrorMessage="Enter Password" ValidationGroup="password"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <br />
                    <tr>
                        <td align="center" colspan="3">
                            <br />
                            <br />
                            <asp:Button ID="btnpassword" runat="server" Text="Verify Password" CssClass="InputButton"
                                OnClick="btnpassword_Click" ValidationGroup="password" Style="font-size: medium; height: 30px; font-weight: bold; background-color: red;" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                                ShowMessageBox="True" ValidationGroup="password" />
                        </td>
                    </tr>
                </table>
                <table id="tblOtp" class="AppFormTable" runat="server">
                    <tr id="trMobileNo" runat="server" visible="False">
                        <td colspan="4" align="center">OTP has been sent your Mobile No :  
                            <asp:Label ID="lblMaskMobileno" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">Enter One Time Password (OTP)
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtOneTimePassword" runat="server" MaxLength="6" onKeyPress="return numbersonly(event)"
                                autocomplete="off"> </asp:TextBox>
                            <font color="red"><sup>*</sup></font>
                            <asp:RequiredFieldValidator ID="rfvOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword"
                                Display="None" ErrorMessage="Please Enter One Time Password (OTP)." ValidationGroup="otp"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revOneTimePassword" runat="server" ControlToValidate="txtOneTimePassword"
                                Display="None" ErrorMessage="One Time Password (OTP) Should be of 6 Digits."
                                ValidationExpression="\d{6}" ValidationGroup="otp"></asp:RegularExpressionValidator>
                            <asp:Button ID="btnCall" runat="server" CssClass="InputButton mt-2" OnClick="btnCall_Click"
                                Text="Retry on Call" Visible="false" ValidationGroup="call" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <br />
                            <br />
                            <asp:Button ID="btnVerifyOtp" runat="server" Text="Verify OTP"
                                CssClass="InputButton" OnClick="btnVerifyOtp_Click" ValidationGroup="otp" Style="font-size: medium; height: 40px; font-weight: bold; background-color: red;" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False"
                                ShowMessageBox="True" ValidationGroup="otp" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>

    <cc1:ContentBox ID="contentDocumentConferamtion" runat="server" HeaderText="Self Confirmation" BoxType="PopupBox"  >
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td colspan="2">
                     <asp:Label runat="server" ID="lblDisplayDocumentSubmissionStatus" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>  
                <td colspan="2" > 
                    <ol class="list-text">
                        <b>Important Instructions :</b>
                        <li><p align = "justify">Candidate those who have selected Betterment/Not Freeze & submitted receipt of CVC/TVC,EWS, or NCL is aware that he can not submit the document before the last day of CAP round II Reporting date ,such a candidate can convert himself/herself in to open category while filling CAP Round II Option Form. If Candidate availed benefit of Category/EWS in CAP Round I, those candidate seat will get cancelled and candidate will be considered in to OPEN category for the Subsequent rounds of CAP and if the Candidate not availed the benefit of the Category/EWS in CAP Round I, those candidates seat will be retained & the candidate will be considered in to Open category for Subsequent rounds of CAP.</p></li>
                        <li><p align = "justify">Candidates those who have not allotted any seat in CAP Round I , Can convert himself/herself in to OPEN category if they are aware that they will not be able to produce original document of CVC/TVC,NCL or EWS till the last day of CAP Round II Reporting date & such candidates will be eligible for Allotment of seat in CAP Round II in Open Category.</p></li>
                     
                      <%--<li><p align = "justify">Candidate those who have selected Betterment/Not Freeze & submitted receipt of CVC/TVC,EWS, or NCL is aware that he can not submit the document before the last day of CAP round II Reporting date ,such a candidate can convert himself/herself in to open category / NON-EWS while filling CAP Round II Option Form. If Candidate availed benefit of Category / EWS in CAP Round I, those candidate seat will get cancelled and candidate will be considered in to OPEN category / NON-EWS for the Subsequent rounds of CAP and if the Candidate not availed the benefit of the Category / EWS in CAP Round I, those candidates seat will be retained & the candidate will be considered in to Open category / NON-EWS for Subsequent rounds of CAP.</p></li>
                     <li><p align = "justify">Candidates those who have not allotted any seat in CAP Round I , Can convert himself/herself in to OPEN category / NON-EWS if they are aware that they will not be able to produce original document of CVC/TVC,NCL or EWS till the last day of CAP Round II Reporting date & such candidates will be eligible for Allotment of seat in CAP Round II in Open Category / NON-EWS.</p></li>
                     <li><p align = "justify">Once you converted yourself into OPEN category / NON-EWS then you are considered Only in OPEN category / NON-EWS for seat allotment in the next CAP round / additional institutional round.</p></li>--%>
                     <li><p align = "justify">OPEN category / NON-EWS converted candidate will not be able to convert back into reserved / EWS category.</p></li>
                    </ol>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    <p align="justify" style="color:red">
                    <asp:CheckBox ID="chkIAgree" runat="server" AutoPostBack="false"/> 
                        <font color="red"><b> I have read all Important Instructions.</b></font>
                        </p>
                    </td>
                </tr>
            <tr runat="server" id="trYesNo">
                <td align="right"><asp:Button ID="Button1" runat="server" Text="Yes" CssClass="InputButton" OnClick="btnYesR_Click"  Width="100px"/></td>
                <td align="left"><asp:Button ID="Button2" runat="server" Text="No" CssClass="InputButton" OnClick="btnNoR_Click"  Width="100px"/> </td>
                
            </tr> 
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="contentDocumentConferamtionCON" runat="server" HeaderText="Self Confirmation" BoxType="PopupBox"  >
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td colspan="2">
                     <asp:Label runat="server" ID="lblDisplayDocumentSubmissionStatusCON" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>  
                <td colspan="2" > 
                    <ol class="list-text">
                        <b>Important Instructions :</b>
                        <li><p align = "justify">Candidate those who have selected Betterment/Not Freeze & submitted receipt of CVC/TVC,EWS, or NCL is aware that he can not submit the document before the last day of CAP round II Reporting date ,such a candidate can convert himself/herself in to open category while filling CAP Round II Option Form. If Candidate availed benefit of Category/EWS in CAP Round I, those candidate seat will get cancelled and candidate will be considered in to OPEN category for the Subsequent rounds of CAP and if the Candidate not availed the benefit of the Category/EWS in CAP Round I, those candidates seat will be retained & the candidate will be considered in to Open category for Subsequent rounds of CAP.</p></li>
                        <li><p align = "justify">Candidates those who have not allotted any seat in CAP Round I , Can convert himself/herself in to OPEN category if they are aware that they will not be able to produce original document of CVC/TVC,NCL or EWS till the last day of CAP Round II Reporting date & such candidates will be eligible for Allotment of seat in CAP Round II in Open Category.</p></li>
                     
                  <%--   <li><p align = "justify">Candidate those who have selected Betterment/Not Freeze & submitted receipt of CVC/TVC,EWS, or NCL is aware that he can not submit the document before the last day of CAP round II Reporting date ,such a candidate can convert himself/herself in to open category / NON-EWS while filling CAP Round II Option Form. If Candidate availed benefit of Category / EWS in CAP Round I, those candidate seat will get cancelled and candidate will be considered in to OPEN category / NON-EWS for the Subsequent rounds of CAP and if the Candidate not availed the benefit of the Category / EWS in CAP Round I, those candidates seat will be retained & the candidate will be considered in to Open category / NON-EWS for Subsequent rounds of CAP.</p></li>
                     <li><p align = "justify">Candidates those who have not allotted any seat in CAP Round I , Can convert himself/herself in to OPEN category / NON-EWS if they are aware that they will not be able to produce original document of CVC/TVC,NCL or EWS till the last day of CAP Round II Reporting date & such candidates will be eligible for Allotment of seat in CAP Round II in Open Category / NON-EWS.</p></li>
                     <li><p align = "justify">Once you converted yourself into OPEN category / NON-EWS then you are considered Only in OPEN category / NON-EWS for seat allotment in the next CAP round / additional institutional round.</p></li>--%>
                     <li><p align = "justify">OPEN category / NON-EWS converted candidate will not be able to convert back into reserved / EWS category.</p></li>
                    </ol>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    <p align="justify" style="color:red">
                    <asp:CheckBox ID="chkIAgreeCON" runat="server" AutoPostBack="false"/> 
                        <font color="red"><b> I have read all Important Instructions.</b></font>
                        </p>
                    </td>
                </tr>
            <tr runat="server" id="tr3">
                <td align="right"><asp:Button ID="Button3" runat="server" Text="Yes" CssClass="InputButton" OnClick="btnYesRC_Click" Width="100px"/></td>
                <td align="left"><asp:Button ID="Button4" runat="server" Text="No" CssClass="InputButton" OnClick="btnNoRC_Click"  Width="100px" /> </td>
                
            </tr> 
        </table>
    </cc1:ContentBox>
    
</asp:Content>
