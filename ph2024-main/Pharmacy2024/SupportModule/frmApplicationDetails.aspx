<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageWithOutLeftMenuSB.Master" AutoEventWireup="true" CodeBehind="frmApplicationDetails.aspx.cs" Inherits="Pharmacy2024.SupportModule.frmApplicationDetails" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/PrintFormHeader.ascx" TagName="PrintFormHeader" TagPrefix="ucPFH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <style>
        .inline-flex {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }
        .btn1 {
            padding: 10px;
            border-radius: 10px;
            width: 135px;
            height: 75px;
            border: none;
            margin: 5px;
        }

        .btn-red {
            background: #F6223F;
            color: white;
        }

        .btn-green {
            background: green;
            color: white;
        }

        .box1 {
            padding: 5px;
            background: #4e1864;
            color: white;
            margin: 2px;
        }

        .w1 {
            width: 13% !important;
        }

        .w2 {
            width: 30% !important;
        }

        .w3 {
            width: 25% !important;
        }

        .w4 {
            width: 30% !important;
        }

        @media screen and (max-width:768px) {
            .w1, .w2, .w3, .w4 {
                width: auto;
            }
        }

        .box1 span {
            font-size: 16px;
        }

        .btn2 {
            padding: 5px;
            border-radius: 10px;
            width: 100px;
            height: 65px;
            border: none;
            margin: 5px;
        }

        .img1 {
            width: 110px;
            height: 70px;
            padding: 5px;
        }

        .btnDate {
            padding: 2px 10px;
            background: whitesmoke;
            border: 1px solid #ccc;
        }

        .boxcap {
            padding: 10px;
            background: #2096cd52;
            border: 1px solid #ccc;
            font-size: 14px !important;
        }

        .box2 {
            padding: 10px 5px;
            background: #f0f0f0;
            border-radius: 10px;
        }

        .boxcaphead {
            padding: 5px;
            background: #f44a56;
            color: white;
            margin-bottom: 5px;
        }

        .boxcaptitle {
            font-size: 16px;
            font-weight: bold;
            padding: 10px;
        }
    </style>
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

        function OpenViewDocumentPopUp(cntrl) {

            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            var corrRow = cntrl.parentNode.parentNode;
            var filePath = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            var byteStream = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[1].value;
            //corrRow.cells[corrRow.cells.length - 5].innerText

            //document.getElementById('lblDocumentName').innerHTML = corrRow.cells[corrRow.cells.length - 5].innerText;
            document.getElementById('lblDocumentName').innerHTML = corrRow.cells[1].innerText;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + byteStream + '">';
                    document.getElementById('divDocument').style.overflow = "scroll";
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('divDocument').innerHTML = '<iframe src="' + byteStream + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                    document.getElementById('divDocument').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }



    </script>
    <script type="text/javascript">
          <%--  $(function () {
            $('#btnPrintApp').click(function () {
              
                var pid = GetParameterValues('PID');
               
                $('#divPrint').load('../AFCModule/frmPrintApplicationForm.aspx?PID=' + pid);

                function GetParameterValues(param) {
                    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                    for (var i = 0; i < url.length; i++) {
                        var urlparam = url[i].split('=');
                        if (urlparam[0] == param) {
                            return urlparam[1];
                        }
                    }
                }
            }
            );

            $('#btnPrintAck').click(function () {
                var pid = GetParameterValues('PID');

                $('#divPrint').load('../AFCModule/frmPrintAcknowledgement.aspx?PID=' + pid);

                function GetParameterValues(param) {
                    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                    for (var i = 0; i < url.length; i++) {
                        var urlparam = url[i].split('=');
                        if (urlparam[0] == param) {
                            return urlparam[1];
                        }
                    }
                }
            }
            );
        });--%>


        function PrintApp() {
            var pid = GetParameterValues('PID');
            $('#rightContainer_ContentBoxDocumentDetails').hide();
            $('#rightContainer_cntPrev').hide();
            $('#rightContainer_ContentBoxEntranceExamDetails').hide();
            $('#rightContainer_cntFail').hide();
            $('#rightContainer_CntChkGrievance').hide();
            $('#rightContainer_ContentBox1_tblApplicationFormStatus').hide();
            $('#rightContainer_tblpaymentmsg').hide();
            $('#divPrint').load('../AFCModule/frmPrintApplicationForm.aspx?PID=' + pid);
            $('#rightContainer_CntChkProvisionMerit').hide();
            $('#rightContainer_cntOptionForm').hide();
            $('#rightContainer_cntAllotmentDetails1').hide();
            $('#rightContainer_cntSelfArc1').hide();
            $('#rightContainer_cntInstituteReportingStatus1').hide();
            $('#rightContainer_cntOptionForm2').hide();
            $('#rightContainer_cntAllotmentDetails2').hide();
            $('#rightContainer_cntSelfArc2').hide();
            $('#rightContainer_cntInstituteReportingStatus2').hide();
            $('#rightContainer_cntOptionForm3').hide();
            $('#rightContainer_cntAllotmentDetails3').hide();
            $('#rightContainer_cntSelfArc3').hide();
            $('#rightContainer_cntInstituteReportingStatus3').hide();

            function GetParameterValues(param) {
                var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < url.length; i++) {
                    var urlparam = url[i].split('=');
                    if (urlparam[0] == param) {
                        return urlparam[1];
                    }
                }
            }
        };
        function PrintAck() {
            var pid = GetParameterValues('PID');
            $('#rightContainer_ContentBoxDocumentDetails').hide();
            $('#rightContainer_cntPrev').hide();
            $('#rightContainer_ContentBoxEntranceExamDetails').hide();
            $('#rightContainer_cntFail').hide();
            $('#rightContainer_CntChkGrievance').hide();
            $('#rightContainer_ContentBox1_tblApplicationFormStatus').hide();
            $('#rightContainer_tblpaymentmsg').hide();
            $('#rightContainer_CntChkProvisionMerit').hide();
            $('#rightContainer_cntOptionForm').hide();
            $('#rightContainer_cntAllotmentDetails1').hide();
            $('#rightContainer_cntSelfArc1').hide();
            $('#rightContainer_cntInstituteReportingStatus1').hide();
            $('#rightContainer_cntOptionForm2').hide();
            $('#rightContainer_cntAllotmentDetails2').hide();
            $('#rightContainer_cntSelfArc2').hide();
            $('#rightContainer_cntInstituteReportingStatus2').hide();
            $('#rightContainer_cntOptionForm3').hide();
            $('#rightContainer_cntAllotmentDetails3').hide();
            $('#rightContainer_cntSelfArc3').hide();
            $('#rightContainer_cntInstituteReportingStatus3').hide();
            $('#divPrint').load('../AFCModule/frmPrintAcknowledgement.aspx?PID=' + pid);

            function GetParameterValues(param) {
                var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < url.length; i++) {
                    var urlparam = url[i].split('=');
                    if (urlparam[0] == param) {
                        return urlparam[1];
                    }
                }
            }
        };
    </script>

    <script type="text/javascript" language="javascript">
        function ViewDoc(cntrl) {
            var corrRow = cntrl.parentNode.parentNode;
            var documentName = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value.toLowerCase();
            var m = documentName.toLowerCase().indexOf(".rar"); var k = documentName.toLowerCase().indexOf(".zip")
            if (m > -1) {
                window.open(documentName);
            }
            else if (k > -1) {
                window.open(documentName);
            }
            else {
                window.open($('#<%=hdnApplicationURL.ClientID %>').val() + "viewdocument.aspx?fn=" + documentName);
            }
            return false;
        }
        $body = $("body");
        $(document).on({
            ajaxStart: function () { $body.addClass("loading"); },
            ajaxStop: function () { $body.removeClass("loading"); }
        });
    </script>
    <script type="text/javascript">
        function ShowPopup(cntrl) {
            var corrRow = cntrl.parentNode.parentNode;
            var documentId = corrRow.getElementsByTagName("input")[1].value;
            window.open("../ViewMyDocument.aspx?documentID=" + documentId, "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes,");
        }
    </script>
     <script language="javascript" type = "text/javascript">
         function OpenPopUpWindow() {
             window.open("frmPrintAdmissionLetterAtIL.aspx?PID=<% = PID %>&ChoiceCode=<% = ChoiceCode %>", "Password", "width=1000px,height=500px,resizable=yes,scrollbars=yes");
         }
     </script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <style>
        .modal {
            display: none;
            position: fixed;
            z-index: 1000;
            top: 0;
            left: 0;
            height: 100%;
            width: 100%;
            background: rgba( 255, 255, 255, .8 ) url('../Images/BigProgress.gif') 50% 50% no-repeat;
        }

        body.loading {
            overflow: hidden;
        }

            body.loading .modal {
                display: block;
            }

        .NotVisible {
            display: none;
        }

        p {
            font-size: 14px;
        }
    </style>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" />
    <script type="text/javascript">        jQuery.noConflict();</script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible="false">
        <br />
        <center>
            <asp:Label ID="lblHeader" runat="server" Font-Size="Medium" Font-Bold="true" ForeColor="#383737"
                Width="92%">
                Welcome for Admission to 
                First Year of Four Year Degree Course in Pharmacy & First Year of Six Year Post Graduate Degree Course in Pharm. D. for the Academic Year <%= AdmissionYear %>
            </asp:Label>
        </center>
        <br />

        <table class="AppFormTable" id="tblLogin">
            <tr>
                <th colspan="9">Application Details
                </th>
            </tr>
            <tr align="center">
                <td>Application ID
                </td>
                <td>Candidate Name
                </td>
                <td>Father Name
                </td>
                <td>Mother Name
                </td>
                <td>Gender
                </td>
                <td>DOB
                </td>
                <td>CandidatureType
                </td>
                <td>last Modified by
                </td>
                <td>Last Modified On
                </td>
            </tr>
            <tr align="center">

                <td>
                    <asp:Label ID="lblLoginIDapp" runat="server" Font-Bold="true"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="lblUserNameapp" runat="server" Font-Bold="true"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="lblFatherNameapp" runat="server" Font-Bold="true"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="lblMothernameapp" runat="server" Font-Bold="true"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="lblGenderapp" runat="server" Font-Bold="true"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="lblDOBapp" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCandidaturetypeapp" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLastModifiedbyapp" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLastModifiedonapp" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>

        <table id="tblDiscrepancyDetails" runat="server" class="AppFormTable mt-3">
            <tr>
                <th style="border-top-width: 0px; background-color: red; color: wheat;" colspan="2"><b>Application Form Verification Status</b></th>
            </tr>
            <tr>
                <td>
                    <%--<font color="red"> --%>
                    <b>
                        <asp:Label ID="lblDiscrepancyStatus" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label></b>
                    <%--</font>--%>
                </td>
            </tr>
            <tr id="trDiscrepancy" runat="server" visible="false">
                <td>
                    <asp:GridView ID="gvDiscrepancy" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Application Form Step" DataField="LinkName" HtmlEncode="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Discrepancy In" DataField="DiscrepancyName" HtmlEncode="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Remark by SC Officer" DataField="DiscrepancyRemark" HtmlEncode="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40%" CssClass="Header" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                            </asp:BoundField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscrepancyID" runat="server" Text='<%# Eval("DiscrepancyID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplicationFormStepID" runat="server" Text='<%# Eval("ApplicationFormStepID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Go To Step" Visible="False">
                                <ItemTemplate>
                                    <asp:Button ID="btnStep" Enabled="false" runat="server" Text="Click To Edit" PostBackUrl='<%# Eval("LinkUrl") %>' CssClass="InputButton" BackColor="#cc66ff"></asp:Button>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </td>
            </tr>
            <tr id="trbutton" runat="server" visible="false">
                <td>
                    <div style="display: none">
                        <table>
                            <tr id="trEditButton" runat="server" visible="false">
                                <td align="center">
                                    <asp:Button ID="btnEditApplicationForm" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Edit Application Form" Height="40px" Font-Size="Medium" Font-Bold="true"></asp:Button></td>
                            </tr>
                            <tr id="trReSubmitButton" runat="server" visible="false">
                                <td align="center">
                                    <asp:Button ID="btnReSubmit" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to ReSubmit and Lock Application Form for E-Scrutiny" Height="40px" Font-Size="Medium" Font-Bold="true"></asp:Button></td>
                            </tr>
                            <tr id="trSubmitButton" runat="server" visible="false">
                                <td align="center">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Submit and Lock Application Form for E-Scrutiny" Height="40px" Font-Size="Medium" Font-Bold="true"></asp:Button></td>
                            </tr>
                            <tr id="trBookSlotButton" runat="server" visible="false">
                                <td align="center">
                                    <asp:Button ID="btnBookSlot" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Book a Slot" Height="40px" Font-Size="Medium" Font-Bold="true"></asp:Button></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>

    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false" align="center">
        <div class="">
            <div class="inline-flex">
                <div class="box1 w1">
                    <asp:Button ID="btnEntExamDetails" OnClick="btnEntExamDetails_Click" runat="server" Text="Entrance Exam Details ( NEET/CET)" Style="white-space: pre-line; width: 120px; height: 130px; text-align: center;"></asp:Button>

                </div>
                <div class="box1 w2">
                    <div class="inline-flex">
                        <button type="button" class="btn2 btn-red">Application Fee</button>
                        <button type="button" class="btn2 btn-red">Conversion Fee</button>
                        <button type="button" class="btn2 btn-red">Seat Acceptance Fee</button>
                    </div>
                    <div class="inline-flex">
                        <asp:Label ID="lblApplicationFee" runat="server" class="btn2 btn-red"></asp:Label>
                        <asp:Label ID="lblConversionFee" runat="server" class="btn2 btn-red"></asp:Label>
                        <asp:Label ID="lblSeatAcceptanceFee" runat="server" class="btn2 btn-red"></asp:Label>
                    </div>
                </div>
                <div class="box1 w3">
                    <div class="inline-flex">
                        <img src="../Images/SupportModuleImages/category.png" alt="category" class="img1">

                        <img src="../Images/SupportModuleImages/Category-of-Admission.png" alt="category" class="img1">
                    </div>
                    <div class="inline-flex">
                        <asp:Label ID="lblCategory" Style="text-align: center; padding: 10px; border-radius: 10px;" runat="server" Text=""> </asp:Label><br />

                        <asp:Label ID="lblCategoryForAdmissionBox" Style="text-align: center; padding: 10px; border-radius: 10px;" class="ml-5" runat="server" Text=""></asp:Label>
                        <%-- <button type="button" class="btn2 btn-red">OPEN</button>
                    <button type="button" class="btn2 btn-red">OBC</button>--%>
                    </div>

                </div>
                <div class="box1 w4">
                    <div class="inline-flex">
                        <asp:Image ID="imgEWS" runat="server" alt="category" class="img1" />
                        <asp:Image ID="imgTFWS" runat="server" alt="category" class="img1" />
                        <asp:Image ID="imgMinority" runat="server" alt="category" class="img1" />
                    </div>
                    <div class="inline-flex">
                        <asp:Image ID="imgPWD" runat="server" alt="category" class="img1" />
                        <asp:Image ID="imgOrphan" runat="server" alt="category" class="img1" />
                        <asp:Image ID="imgDef" runat="server" alt="category" class="img1" />
                    </div>

                </div>
            </div>
        </div>
        <div class="">
            <div class="inline-flex">
                <asp:Button ID="btnFormStatus" OnClick="btnFormStatus_Click" runat="server" Text="" Style="white-space: pre-line; width: 190px; height: 50px; text-align: center;"></asp:Button>
                <asp:Button ID="btnCheckUploadedDoc" runat="server" Text="Check Uploaded Document" Style="white-space: pre-line; width: 150px; height: 50px; text-align: center;" OnClick="btnCheckUploadedDoc_Click" BackColor=""></asp:Button>
                <asp:Button ID="btncheckPaymentHistory" OnClick="btncheckPaymentHistory_Click" runat="server" Text="Check Payment Details " BackColor="#D9332C" Style="white-space: pre-line; width: 190px; height: 50px; text-align: center;"></asp:Button>
                <asp:Button ID="btnPrintApplicationForm" OnClientClick="PrintApp(); return false;" runat="server" Text="" Style="white-space: pre-line; width: 190px; height: 50px; text-align: center;"></asp:Button>
                <asp:Button ID="btnPrintAcknowledgement" OnClientClick="PrintAck(); return false;" runat="server" Text="" Style="white-space: pre-line; width: 190px; height: 50px; text-align: center;"></asp:Button>
                <asp:Button ID="btnCheckGrivence" OnClick="btnCheckGrivence_Click" runat="server" Text="Check Grievance Status" Style="white-space: pre-line; width: 190px; height: 50px; text-align: center;" BackColor="#5CB85C"></asp:Button>
                <asp:Button ID="btnProvMeritNo" OnClick="btnProvMeritNo_Click" runat="server" Text="Provisional Merit List" Style="white-space: pre-line; width: 190px; height: 50px; text-align: center;" BackColor="#5CB85C"></asp:Button>
                <asp:Button ID="btnFinalMeritNo" runat="server" Text="Final Merit List" Style="white-space: pre-line; width: 190px; height: 50px; text-align: center;" BackColor="#5CB85C"></asp:Button>
                <asp:Button ID="btnILReporting" runat="server" Text="IL Reporting" Style="white-space: pre-line; width: 190px; height: 50px; text-align: center;" BackColor="#5CB85C" OnClick="btnILReporting_Click" Visible="true"></asp:Button>
            </div>
            <cc1:ContentBox ID="cbCapRound1" runat="server" HeaderVisible="false" align="center" Visible="false">
                <div class="boxcap mt-3">
                    <div class="row">
                        <div class="col-6" align="left">
                            <span class="boxcaptitle">CAP Round-I</span>
                        </div>
                        <%--<div class="col-6" align="right">
                    <button type="button" class="btnDate">Start Date</button>
                    <button type="button" class="btnDate">Date</button>
                    <button type="button" class="btnDate">End Date</button>
                    <button type="button" class="btnDate">Date</button>
                </div>--%>
                    </div>
                    <div class="row mt-3">
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%--<span class="boxcaphead">Option Form I</span>--%>
                                        <asp:Button ID="btnOptionForm1" runat="server" Text="Option Form CAP I" CssClass="boxcaphead" OnClick="btnOptionForm1_Click" BackColor="#3399ff" />
                                    </div>
                                </div>
                                <div class="row mt-3">
                            <div class="col-6 text-center">
                                Start Date
                                <br/>
                              <asp:Label ID="lblOptionForm1StartDate" runat="server"></asp:Label>                               
                            </div>
                            <div class="col-6 text-center">
                                End Date
                                <br />
                                <asp:Label ID="lblOptionForm1EndDate" runat="server"></asp:Label>          
                            </div>                           
                        </div>
                            </div>
                        </div>
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%--<span class="boxcaphead">Allotment Details</span>--%>
                                        <asp:Button ID="btnAllotmentDetails1" runat="server" Text="Allotment Details CAP I" CssClass="boxcaphead" OnClick="btnAllotmentDetails1_Click" BackColor="#3399ff" />
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-12 text-center">
                                        start Date
                                        <br />
                                        <asp:Label ID="lblAllotment1StartDate" runat="server"></asp:Label>
                                    </div>
                                    <%--  <div class="col-6 text-center">
                                End Date
                                <br />
                                 <asp:Label ID="lblAllotment1EndDate" runat="server"></asp:Label>     
                            </div>         --%>
                                </div>
                            </div>
                        </div>
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%--<span class="boxcaphead">Self ARC</span>--%>
                                        <asp:Button ID="btnSelfARC1" runat="server" Text="Self ARC CAP I" CssClass="boxcaphead" OnClick="btnSelfARC1_Click" BackColor="#3399ff" />
                                    </div>
                                </div>
                                  <div class="row mt-3">
                            <div class="col-6 text-center">
                                Start Date
                                <br />
                                <asp:Label ID="lblSelfARC1StartDate" runat="server"></asp:Label>     
                            </div>
                            <div class="col-6 text-center">
                                End Date
                                <br />
                                 <asp:Label ID="lblSelfARC1EndDate" runat="server"></asp:Label>     
                            </div>                           
                        </div>
                            </div>
                        </div>
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%--<span class="boxcaphead">Institute Reporting Status</span>--%>
                                        <asp:Button ID="btnInstituteReportingStatus1" runat="server" Text="Institute Reporting Status CAP I" CssClass="boxcaphead" OnClick="btnInstituteReportingStatus1_Click" BackColor="#3399ff" />
                                    </div>
                                </div>
                                  <div class="row mt-3">
                            <div class="col-6 text-center">
                                Start Date
                                <br />
                                <asp:Label ID="lblInstReporting1StartDate" runat="server"></asp:Label>     
                            </div>
                            <div class="col-6 text-center">
                                End Date
                                <br />
                                 <asp:Label ID="lblInstReporting1EndDate" runat="server"></asp:Label>     
                            </div>                           
                        </div>
                            </div>
                        </div>
                    </div>
                </div>
            </cc1:ContentBox>
            <cc1:ContentBox ID="cbCapRound2" runat="server" HeaderVisible="false" align="center" Visible="false">
                <div class="boxcap mt-3">
                    <div class="row">
                        <div class="col-6" align="left">
                            <span class="boxcaptitle">CAP Round-II</span>
                        </div>
                        <%--<div class="col-6" align="right">
                            <button type="button" class="btnDate">Start Date</button>
                            <button type="button" class="btnDate">Date</button>
                            <button type="button" class="btnDate">End Date</button>
                            <button type="button" class="btnDate">Date</button>
                        </div>--%>
                    </div>
                    <div class="row mt-3">
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%-- <span class="boxcaphead">Option Form I</span>--%>
                                        <asp:Button ID="btnOptionForm2" runat="server" Text="Option Form CAP II" CssClass="boxcaphead" OnClick="btnOptionForm2_Click" BackColor="#3399ff" />
                                    </div>
                                </div>
                                   <div class="row mt-3">
                                    <div class="col-6 text-center">
                                        Start Date
                                <br />
                                        <asp:Label ID="lblOptionForm2StartDate" runat="server"></asp:Label>        
                                    </div>
                                    <div class="col-6 text-center">
                                        End Date
                                <br />
                                         <asp:Label ID="lblOptionForm2EndDate" runat="server"></asp:Label>        
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%--<span class="boxcaphead">Allotment Details</span>--%>
                                        <asp:Button ID="btnAllotmentDetails2" runat="server" Text="Allotment Details CAP II" CssClass="boxcaphead" OnClick="btnAllotmentDetails2_Click" BackColor="#3399ff" Enabled="true" />
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-12 text-center">
                                        Start Date
                                <br />
                                        <asp:Label ID="lblAllotment2StartDate" runat="server"></asp:Label>
                                    </div>
                                   <%-- <div class="col-6 text-center">
                                        Start Date
                                <br />
                                        End Date
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%--<span class="boxcaphead">Self ARC</span>--%>
                                        <asp:Button ID="btnSelfArc2" runat="server" Text="Self ARC CAP II" CssClass="boxcaphead" OnClick="btnSelfArc2_Click" BackColor="#3399ff" Enabled="true" />
                                    </div>
                                </div>
                                  <div class="row mt-3">
                                    <div class="col-6 text-center">
                                        Start Date
                                <br />
                                        <asp:Label ID="lblSelfARC2StartDate" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-6 text-center">
                                        End Date
                                <br />
                                        <asp:Label ID="lblSelfARC2EndDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%--<span class="boxcaphead">Institute Reporting Status</span>--%>
                                        <asp:Button ID="btnInstituteReportingStatus2" runat="server" Text="Institute Reporting Status CAP II" CssClass="boxcaphead" OnClick="btnInstituteReportingStatus2_Click" BackColor="#3399ff" Enabled="true" />
                                    </div>
                                </div>
                                      <div class="row mt-3">
                                    <div class="col-6 text-center">
                                        Start Date
                                <br />
                                        <asp:Label ID="lblInstReporting2StartDate" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-6 text-center">
                                        End Date
                                <br />
                                        <asp:Label ID="lblInstReporting2EndDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </cc1:ContentBox>
            <cc1:ContentBox ID="cbCapRound3" runat="server" HeaderVisible="false" align="center" Visible="false">
                <div class="boxcap mt-3">
                    <div class="row">
                        <div class="col-6" align="left">
                            <span class="boxcaptitle">CAP Round-III</span>
                        </div>
                        <%--<div class="col-6" align="right">
                            <button type="button" class="btnDate">Start Date</button>
                            <button type="button" class="btnDate">Date</button>
                            <button type="button" class="btnDate">End Date</button>
                            <button type="button" class="btnDate">Date</button>
                        </div>--%>
                    </div>
                    <div class="row mt-3">
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%-- <span class="boxcaphead">Option Form I</span>--%>
                                        <asp:Button ID="btnOptionForm3" runat="server" Text="Option Form CAP III" CssClass="boxcaphead" OnClick="btnOptionForm3_Click" BackColor="#3399ff" />
                                    </div>
                                </div>
                                   <div class="row mt-3">
                                    <div class="col-6 text-center">
                                        Start Date
                                <br />
                                        <asp:Label ID="lblOptionForm3StartDate" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-6 text-center">
                                        End Date
                                <br />
                                       <asp:Label ID="lblOptionForm3EndDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%--<span class="boxcaphead">Allotment Details</span>--%>
                                        <asp:Button ID="btnAllotmentDetails3" runat="server" Text="Allotment Details CAP III" CssClass="boxcaphead" OnClick="btnAllotmentDetails3_Click" Enabled="true" BackColor="#3399ff" />
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-12 text-center">
                                        Start Date
                                <br />
                                        <asp:Label ID="lblAllotment3StartDate" runat="server"></asp:Label>
                                    </div>
                                   <%-- <div class="col-6 text-center">
                                        Start Date
                                <br />
                                        End Date
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%--<span class="boxcaphead">Self ARC</span>--%>
                                        <asp:Button ID="btnSelfArc3" runat="server" Text="Self ARC CAP III" CssClass="boxcaphead" OnClick="btnSelfArc3_Click" Enabled="true" BackColor="#3399ff" />
                                    </div>
                                </div>
                                  <div class="row mt-3">
                                    <div class="col-6 text-center"> 
                                        Start Date
                                <br />
                                        <asp:Label ID="lblSelfARC3StartDate" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-6 text-center">
                                        End Date
                                <br />
                                        <asp:Label ID="lblSelfARC3EndDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-3 ">
                            <div class="box2">
                                <div class="row">
                                    <div class="col-12">
                                        <%--<span class="boxcaphead">Institute Reporting Status</span>--%>
                                        <asp:Button ID="btnInstituteReportingStatus3" runat="server" Text="Institute Reporting Status CAP III" CssClass="boxcaphead" OnClick="btnInstituteReportingStatus3_Click" Enabled="true" BackColor="#3399ff" />
                                    </div>
                                </div>
                                       <div class="row mt-3">
                                    <div class="col-6 text-center">
                                        Start Date
                                <br />
                                        <asp:Label ID="lblInstReporting3StartDate" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-6 text-center">
                                        End Date
                                <br />
                                        <asp:Label ID="lblInstReporting3EndDate" runat="server"></asp:Label>
                                    </div>
                                   <%-- <div class="col-4">
                                        Admission Done
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </cc1:ContentBox>
        </div>
        <table id="tblApplicationFormStatus" runat="server" visible="false" class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;">Application Form Status
                </th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvApplicationFormLinksStatus" runat="server" AutoGenerateColumns="False"
                        Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Step ID">
                                <ItemTemplate>
                                    Step
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="LinkDescription" HeaderText="Step Details">
                                <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="55%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Button ID="btnFormStatus1" runat="server" Text='<%# Eval("LinkStatus") %>'
                                        CssClass="InputButton" BackColor='<%# System.Drawing.Color.FromName(Eval("LinkBackColor").ToString()) %>'
                                        Enabled="false"></asp:Button>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBoxEntranceExamDetails" runat="server" HeaderVisible="false" Visible="false">
        <table class="AppFormTable" runat="server">
            <tr>
                <th colspan="4" align="left"><%= MHTCETName %> Details:-<asp:Label ID="lblCETCandidateName" runat="server" Font-Bold="true"></asp:Label></th>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblAppearedForCETHeader" runat="server"> Appeared for CET</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAppearedForCET" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">
                    <asp:Label ID="lblCETRollNoHeader" runat="server">Roll No</asp:Label></td>
                <td>
                    <asp:Label ID="lblCETRollNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCETScore1" runat="server">
                <td align="right">Physics</td>
                <td>
                    <asp:Label ID="lblCETPhysicsScore" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Chemistry</td>
                <td>
                    <asp:Label ID="lblCETChemistryScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCETScore2" runat="server">
                <td align="right">Mathematics</td>
                <td>
                    <asp:Label ID="lblCETMathScore" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Biology</td>
                <td>
                    <asp:Label ID="lblCETBiologyScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCETScore3" runat="server">
                <td align="right">Total PCM</td>
                <td>
                    <asp:Label ID="lblCETPCMScore" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Total PCB</td>
                <td>
                    <asp:Label ID="lblCETPCBScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="left"><%=NEETName%> Details:-<asp:Label ID="lblNEETName" runat="server" Font-Bold="true"></asp:Label></th>
            </tr>
            <tr>
                <td align="right">Appeared for NEET</td>
                <td>
                    <asp:Label ID="lblAppearedForNEET" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">
                    <asp:Label ID="lblNEETRollNoHeader" runat="server">Roll No</asp:Label></td>
                <td>
                    <asp:Label ID="lblNEETRollNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trNEETScore1" runat="server">
                <td align="right">Physics</td>
                <td>
                    <asp:Label ID="lblNEETPhysicsScore" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Chemistry</td>
                <td>
                    <asp:Label ID="lblNEETChemistryScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trNEETScore2" runat="server">
                <td align="right">Biology (Botany & Zoology)</td>
                <td>
                    <asp:Label ID="lblNEETBiologyScore" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Total</td>
                <td>
                    <asp:Label ID="lblNEETTotalScore" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>


    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBoxDocumentDetails" runat="server" Visible="false" HeaderVisible="false">
        <table id="tblDocumentUploadStatus" runat="server" visible="false" class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;">Documents Upload Status
                </th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvRequiredDocumentsUploadStatus" runat="server" AutoGenerateColumns="False"
                        Width="100%" CellPadding="5" CssClass="DataGrid">
                        <Columns>
                            <asp:BoundField DataField="DocumentsUploadStatus" HeaderText="Documents Upload Status">
                                <ItemStyle Width="75%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid"
                                    CssClass="Item" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Total Documents">
                                <ItemTemplate>
                                    <asp:Button ID="btnTotalDocuments" runat="server" Text='<%# Eval("TotalDocuments") %>'
                                        Width="50px" CssClass="InputButton" BackColor='<%# System.Drawing.Color.FromName(Eval("BackColor").ToString()) %>'
                                        Enabled="false"></asp:Button>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana"
                                    CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana"
                                    CssClass="Header" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hdnCode" runat="server" />
                    <asp:HiddenField ID="hdnFileTypes" runat="server" />
                    <asp:HiddenField ID="hdnFileTypesCode" runat="server" />
                    <asp:HiddenField ID="hdnMaxSize" runat="server" />
                    <asp:HiddenField ID="hdnMaxSizeCode" runat="server" />
                    <asp:HiddenField ID="hdnFileAddress" runat="server" />
                    <asp:HiddenField ID="hdnUploadedFileName" runat="server" />
                    <asp:HiddenField ID="hdnOriginalFileName" runat="server" />
                    <asp:HiddenField ID="hdnUploadedFileURL" runat="server" />
                    <asp:HiddenField ID="hdnFileUploadURL" runat="server" />
                    <asp:HiddenField ID="hdnToken" runat="server" />
                    <asp:HiddenField ID="hdnApplicationURL" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvDocuments" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" BorderWidth="1" OnRowCommand="gvDocuments_RowCommand" EnableModelValidation="True"
                        OnRowDataBound="gvDocuments_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DocumentName" HeaderText="Document Name" ItemStyle-Wrap="true" HtmlEncode="False">
                                <ItemStyle Width="67%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UploadStatus" HeaderText="Upload Status">
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:BoundField>
                            <%--<asp:TemplateField HeaderText="Upload" Visible="false">
                                <ItemTemplate>
                                    <asp:Image ID="btnUpload" runat="server" AlternateText="Upload" ImageUrl="~/Images/ic_file_upload_black_48dp_2x.png" onclick="return OpenPOPup(this);" Style="cursor: pointer;color: #757575;" ToolTip="Upload" Visible='<%# Eval("FilePath").ToString()==""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                                    <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" onclick="javascript:OpenViewDocumentPopUp(this)" runat="server" />
                                    <asp:HiddenField ID="hidFURL" runat="server" Value='<%# Bind("FilePath") %>' />
                                    <asp:HiddenField ID="hidDID" runat="server" Value='<%# Bind("DocumentTransID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Edit" Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btndelete" runat="server" CommandArgument='<%# Bind("DocumentId") %>' CommandName="D" ImageUrl="~/Images/icon-delete.png" ToolTip="Edit" OnClientClick="return confirm('Your previously uploaded document will be deleted and you will have to upload a fresh one. Do you want to continue?');" Visible='<%# Eval("FilePath").ToString()!=""?true:false %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnDocId" runat="server" Value='<%# Bind("DocumentId") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnImgUrl" runat="server" Value='<%# Bind("FilePath") %>' />
                                    <asp:HiddenField ID="hdnImgByteArray" runat="server" Value='<%# Bind("FilePath") %>' />
                                </ItemTemplate>
                                <ControlStyle CssClass="NotVisible" />
                                <ItemStyle CssClass="NotVisible" />
                                <HeaderStyle CssClass="NotVisible" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <div class="modal"></div>
    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr>
                <td>
                    <div class="modal-body">
                        <div runat="server" id="divButtonPopup">
                            <table class="AppFormTableWithOutBorder" style="width: 5%; height: 15px;">
                                <tr>
                                    <td>
                                        <button type="button" onclick="zoominPopUp()">
                                            <img src="../Images/zoom-in.png" width="15px" height="15px"></button></td>
                                    <td>
                                        <button type="button" onclick="zoomoutPopUp()">
                                            <img src="../Images/zoom-out.png" width="15px" height="15px">
                                        </button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divDocument" class="doc-container"></div>
                    </div>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntPrev" runat="server" HeaderText="Paid Transactions Details" Visible="false">
        <%-- <table class = "AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color = "red">
                        <p align = "justify"><font color = "red"><b>Instructions :</b></font></p>
                        <ul class="list-text">
                            <li><p align = "justify"><font color = "red">Receipt for Online / Netbanking Payment can be taken by clicking on "Print" Button under "Print Receipt" Column.</font></p></li>
                        </ul>
                    </font>
                </td>
            </tr>
        </table>--%>
        <asp:GridView ID="grdPrevData" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:TemplateField>
                <asp:BoundField DataField="ReferenceNo" HeaderText="Reference No">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="Total Fee (<span class='rupee'>Rs.</span>)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PaymentInitiatedOn" HeaderText="Payment Initiated On">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="18%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="DateOfPayment" HeaderText="Payment Date">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PaidStatus" HeaderText="Payment Status">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="RefundStatus" HeaderText="Refund Status" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="12%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PrintBankReceipt" HeaderText="Print Receipt" HtmlEncode="false" Visible="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="12%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>

    </cc1:ContentBox>
    <cc1:ContentBox ID="cntFail" runat="server" HeaderText="Failed Transactions Details" Visible="false">
        <asp:GridView ID="grdFail" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemTemplate>
                        <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:TemplateField>
                <asp:BoundField DataField="ReferenceNo" HeaderText="Reference No">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="Total Fee (<span class='rupee'>Rs.</span>)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PaymentInitiatedOn" HeaderText="Payment Initiated On">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="18%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="PaidStatus" HeaderText="Payment Status">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="15%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="Reason" HeaderText="Reason" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="27%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="RefundStatus" HeaderText="Refund Status" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Item" Width="12%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Names="Verdana" CssClass="Header" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
    <div class="table-responsive">
        <table runat="server" id="tblpaymentmsg" visible="false" class="AppFormTable">
            <tr>
                <th height="100" align="center" valign="middle">
                    <asp:Label ID="Label1" runat="server" Text="There is no Payment Details Found" Font-Bold="True" Font-Size="Small"></asp:Label>
                </th>
            </tr>
        </table>
    </div>
    <cc1:ContentBox ID="CntChkGrievance" Visible="false" runat="server" HeaderText="Check Grievance Status">
        <div class="table-responsive">
            <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanging="gvMessages_SelectedIndexChanging" CssClass="DataGrid">

                <Columns>
                    <asp:BoundField DataField="" HeaderText="Sr. No.">
                        <ItemStyle Width="6%" HorizontalAlign="Center" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GrievanceID" HeaderText="Grievance ID" HtmlEncode="false">
                        <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <%-- <asp:BoundField DataField="Sender" HeaderText="From" HtmlEncode = "false">
                    <ItemStyle Width="10%" HorizontalAlign="Center"  CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>--%>
                    <asp:BoundField DataField="GrievanceSubject" HeaderText="Subject/Grievance Category">
                        <ItemStyle Width="10%" HorizontalAlign="Left" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GrievanceMessage" HeaderText="Grievance Message" HtmlEncode="false">
                        <ItemStyle Width="23%" HorizontalAlign="Left" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SentDateTime" HeaderText="Sent Time">
                        <ItemStyle Width="12%" HorizontalAlign="Center" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ApprovalStatus" HeaderText="Current Status">
                        <ItemStyle Width="12%" HorizontalAlign="Center" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <%--  <asp:CommandField ShowSelectButton="True" HeaderText="View" SelectText="View">
                        <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" ForeColor="Blue" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                        <ControlStyle Font-Bold="true" />
                    </asp:CommandField>--%>
                    <asp:BoundField DataField="ApprovedRemark" HeaderText="Approval Remark">
                        <ItemStyle Width="22%" HorizontalAlign="Left" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ApprovedDatetime" HeaderText="Approved Time">
                        <ItemStyle Width="12%" HorizontalAlign="Center" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ApprovedBy" HeaderText="Approved By">
                        <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="table-responsive">
            <table runat="server" id="tblMsg" visible="false" class="AppFormTable">
                <tr>
                    <th height="100" align="center" valign="middle">
                        <asp:Label ID="lbl_frmSentMessages_Messages" runat="server" Text="There is no Grievance in your Send Grievances" Font-Bold="True" Font-Size="Small"></asp:Label>
                    </th>
                </tr>
            </table>
        </div>

    </cc1:ContentBox>
    <cc1:ContentBox ID="CntChkProvisionMerit" Visible="false" runat="server" HeaderText="Provisional Merit Status (Only for Maharashtra State and All India Candidates)">
        <table class="AppFormTable" id="tblProvMeritEligible" runat="server">
            <tr>
                <th align="left" colspan="2"><b>Your Provisional Merit Status is...</b></th>
            </tr>
            <tr id="trStateGeneralMeritNo" runat="server" visible="false">
                <td style="width: 35%" align="right">State General Merit No</td>
                <td style="width: 65%">
                    <asp:Label ID="lblStateGeneralMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trUniversityGeneralMeritNo" runat="server" visible="false">
                <td align="right">University General Merit No</td>
                <td>
                    <asp:Label ID="lblUniversityGeneralMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trStateCategoryMeritNo" runat="server" visible="false">
                <td align="right">State Category Merit No</td>
                <td>
                    <asp:Label ID="lblStateCategoryMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trUniversityCategoryMeritNo" runat="server" visible="false">
                <td align="right">University Category Merit No</td>
                <td>
                    <asp:Label ID="lblUniversityCategoryMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trStateSBCMeritNo" runat="server" visible="false">
                <td align="right">State SBC Merit No</td>
                <td>
                    <asp:Label ID="lblStateSBCMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trUniversitySBCMeritNo" runat="server" visible="false">
                <td align="right">University SBC Merit No</td>
                <td>
                    <asp:Label ID="lblUniversitySBCMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trLadiesStateGeneralMeritNo" runat="server" visible="false">
                <td align="right">Ladies State General Merit No</td>
                <td>
                    <asp:Label ID="lblLadiesStateGeneralMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trLadiesUniversityGeneralMeritNo" runat="server" visible="false">
                <td align="right">Ladies University General Merit No</td>
                <td>
                    <asp:Label ID="lblLadiesUniversityGeneralMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trLadiesStateCategoryMeritNo" runat="server" visible="false">
                <td align="right">Ladies State Category Merit No</td>
                <td>
                    <asp:Label ID="lblLadiesStateCategoryMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trLadiesUniversityCategoryMeritNo" runat="server" visible="false">
                <td align="right">Ladies University Category Merit No</td>
                <td>
                    <asp:Label ID="lblLadiesUniversityCategoryMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trLadiesStateSBCMeritNo" runat="server" visible="false">
                <td align="right">Ladies State SBC Merit No</td>
                <td>
                    <asp:Label ID="lblLadiesStateSBCMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trLadiesUniversitySBCMeritNo" runat="server" visible="false">
                <td align="right">Ladies University SBC Merit No</td>
                <td>
                    <asp:Label ID="lblLadiesUniversitySBCMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trStatePHMeritNo" runat="server" visible="false">
                <td align="right">State PWD Merit No</td>
                <td>
                    <asp:Label ID="lblStatePHMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trUniversityPHMeritNo" runat="server" visible="false">
                <td align="right">University PWD Merit No</td>
                <td>
                    <asp:Label ID="lblUniversityPHMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trStateDefenceMeritNo" runat="server" visible="false">
                <td align="right">State Defence Merit No</td>
                <td>
                    <asp:Label ID="lblStateDefenceMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trTFWSMeritNo" runat="server" visible="false">
                <td align="right">TFWS Merit No</td>
                <td>
                    <asp:Label ID="lblTFWSMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trEWSMeritNo" runat="server" visible="false">
                <td align="right">EWS Merit No</td>
                <td>
                    <asp:Label ID="lblEWSMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trOrphanMeritNo" runat="server" visible="false">
                <td align="right">Orphan Merit No</td>
                <td>
                    <asp:Label ID="lblOrphanMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trKonkanStateGeneralMeritNo" runat="server" visible="false">
                <td align="right">Konkan State General Merit No</td>
                <td>
                    <asp:Label ID="lblKonkanStateGeneralMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trKonkanStateCategoryMeritNo" runat="server" visible="false">
                <td align="right">Konkan State Category Merit No</td>
                <td>
                    <asp:Label ID="lblKonkanStateCategoryMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trAIMeritNo" runat="server" visible="false">
                <td style="width: 35%" align="right">All India Merit No</td>
                <td style="width: 65%">
                    <asp:Label ID="lblAIMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trJKMeritNo" runat="server" visible="false">
                <td style="width: 35%" align="right">J&K Merit No</td>
                <td style="width: 65%">
                    <asp:Label ID="lblJKMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trNRIMeritNo" runat="server" visible="false">
                <td style="width: 35%" align="right">NRI Merit No</td>
                <td style="width: 65%">
                    <asp:Label ID="lblNRIMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trFNPIOMeritNo" runat="server" visible="false">
                <td style="width: 35%" align="right">Foreign Students / PIO / OCI Merit No</td>
                <td style="width: 65%">
                    <asp:Label ID="lblFNPIOMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr id="trCIWGCMeritNo" runat="server" visible="false">
                <td style="width: 35%" align="right">CIWGC Merit No</td>
                <td style="width: 65%">
                    <asp:Label ID="lblCIWGCMeritNo" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
        <table class="AppFormTableNew" id="tblProvMeritNotEligible" runat="server">
            <tr>
                <th height="100" align="center" valign="middle">
                    <asp:Label ID="Label2" runat="server" Text="You are not Eligible for Merit" Font-Bold="True" Font-Size="Small"></asp:Label>
                </th>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntOptionForm" Visible="false" runat="server" HeaderText="Option Form CAP I Status">
        <div class="table-responsive">
            <table class="AppFormTableWithOutBorder" id="tblOptionForm" runat="server" visible="false">
                <tr id="trOptionFormStatusCAPRound1" runat="server" visible="false">
                    <td>
                        <center><font size="2"><b>Status of Option Form Submission and Confirmation for CAP Round – I</b></font></center>
                        <table class="AppFormTableWithAllBorder">
                            <tr>
                                <td align="center" style="background-color: InfoBackground">
                                    <asp:Label ID="lblOptionFormStatusCAPRound1" Font-Bold="true" runat="server" Font-Size="Medium"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntAllotmentDetails1" Visible="false" runat="server" HeaderText="Allotment Details CAP I">
        <table id="tblAllotmentDetails" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td>
                    <center><font size="2"><b>Current Allotment Details CAP I</b></font></center>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 25%;" align="right">Institute Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 75%;">
                            <asp:Label ID="lblInstituteAllotted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Course Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblCourseAllotted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr id="trBenefitTaken" runat="server">
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Benefit Taken</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblBenefitTaken" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Seat Type Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblSeatTypeAllotted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Preference No. Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblPreferenceNoAllotted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                </td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetails" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td>
                    <center><font size="2"><b>Current Allotment Details CAP I</b></font></center>
                    <tr>
                        <td align="center" style="background-color: InfoBackground">
                            <asp:Label ID="lblAllotmentStatus" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntSelfArc1" Visible="false" runat="server" HeaderText="Seat Acceptance Status CAP I">
        <table id="tblSelfArc1" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td runat="server" id="tdSeatAcceptanceStatus">
                   <%-- <center><font size="2"><b>Seat Acceptance Status CAP I</b></font></center>--%>
                    <tr>
                        <td style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Step ID</b></td>
                        <td style="width: 65%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Step Details</b></td>
                        <td style="width: 20%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Status</b></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 1</td>
                        <td style="border: 1px solid #F0F0F0;">Self Verification Status [Candidate shall ensure the claims related with Qualifying Marks, category, gender, reservation, special reservation made by himself/herself in the applications form are correct and the relevant documents uploaded to substantiate claims are authentic and correct.]</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptanceStep1" runat="server" CssClass="InputButton"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 2</td>
                        <td style="border: 1px solid #F0F0F0;">choose Betterment Option [Freeze/Betterment (Not Freeze)]</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptanceStep2" runat="server" CssClass="InputButton"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 3</td>
                        <td style="border: 1px solid #F0F0F0;">Pay Seat Acceptance Fee - Rs. 1000/-</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptanceStep3" runat="server" CssClass="InputButton"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 4</td>
                        <td style="border: 1px solid #F0F0F0;">Confirm Seat Acceptance Letter</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptanceStep4" runat="server" CssClass="InputButton" Enabled="false"></asp:Button></td>
                    </tr>
                </td>
            </tr>
        </table>
        <table id="tblNoSelfArc1" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td>
                    <center><font size="2"><b>Seat Acceptance Status CAP I</b></font></center>
                    <tr>
                        <td align="center" style="background-color: InfoBackground">
                            <asp:Label ID="lblNoSelfArc1Status" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntInstituteReportingStatus1" Visible="false" runat="server" HeaderText="Institute Reporting Status CAP I">
        <tr>
            <td>
                <center><font size="2"><b>Current Admission Details CAP I</b></font></center>
                <table id="tblAdmissionDetails" runat="server" visible="false" class="AppFormTableWithAllBorder">
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 25%;" align="right">Institute Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 75%;">
                            <asp:Label ID="lblInstituteAdmitted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Course Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblCourseAdmitted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Seat Type Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblSeatTypeAdmitted" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Admission Round</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblAdmissionRound" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                </table>
                <table id="tblNoAdmissionDetails" runat="server" visible="false" class="AppFormTableWithAllBorder">
                    <tr>
                        <td align="center" style="background-color: InfoBackground">
                            <asp:Label ID="lblAdmissionStatus" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntOptionForm2" Visible="false" runat="server" HeaderText="Option Form CAP II Status">
        <div class="table-responsive">
            <table class="AppFormTableWithOutBorder" id="tblOptionForm2" runat="server" visible="false">
                <tr id="trOptionFormStatusCAPRound2" runat="server" visible="false">
                    <td>
                        <center><font size="2"><b>Status of Option Form Submission and Confirmation for CAP Round – II</b></font></center>
                        <table class="AppFormTableWithAllBorder">
                            <tr>
                                <td align="center" style="background-color: InfoBackground">
                                    <asp:Label ID="lblOptionFormStatusCAPRound2" Font-Bold="true" runat="server" Font-Size="Medium"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntAllotmentDetails2" Visible="false" runat="server" HeaderText="Allotment Details Cap II">
        <table id="tblAllotmentDetails2" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td>
                    <center><font size="2"><b>Current Allotment Details CAP II</b></font></center>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 25%;" align="right">Institute Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 75%;">
                            <asp:Label ID="lblInstituteAllotted2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Course Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblCourseAllotted2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr id="trBenefitTaken2" runat="server">
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Benefit Taken</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblBenefitTaken2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Seat Type Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblSeatTypeAllotted2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Preference No. Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblPreferenceNoAllotted2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                </td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetails2" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td>
                    <center><font size="2"><b>Current Allotment Details CAP II</b></font></center>
                    <tr>
                        <td align="center" style="background-color: InfoBackground">
                            <asp:Label ID="lblAllotmentStatus2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntSelfArc2" Visible="false" runat="server" HeaderText="Seat Acceptance Status CAP II">
        <table id="tblSelfArc2" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td runat="server" id="tdSeatAcceptanceStatus2">
                   <%-- <center><font size="2"><b>Seat Acceptance Status CAP II</b></font></center>--%>
                    <tr>
                        <td style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Step ID</b></td>
                        <td style="width: 65%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Step Details</b></td>
                        <td style="width: 20%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Status</b></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 1</td>
                        <td style="border: 1px solid #F0F0F0;">Self Verification Status [Candidate shall ensure the claims related with Qualifying Marks, category, gender, reservation, special reservation made by himself/herself in the applications form are correct and the relevant documents uploaded to substantiate claims are authentic and correct.]</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptance2Step1" runat="server" CssClass="InputButton"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 2</td>
                        <td style="border: 1px solid #F0F0F0;">choose Betterment Option [Freeze/Betterment (Not Freeze)]</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptance2Step2" runat="server" CssClass="InputButton"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 3</td>
                        <td style="border: 1px solid #F0F0F0;">Pay Seat Acceptance Fee - Rs. 1000/-</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptance2Step3" runat="server" CssClass="InputButton"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 4</td>
                        <td style="border: 1px solid #F0F0F0;">Confirm Seat Acceptance Letter</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptance2Step4" runat="server" CssClass="InputButton" Enabled="false"></asp:Button></td>
                    </tr>
                </td>
            </tr>
        </table>
        <table id="tblNoSelfArc2" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td>
                    <center><font size="2"><b>Seat Acceptance Status CAP II</b></font></center>
                    <tr>
                        <td align="center" style="background-color: InfoBackground">
                            <asp:Label ID="lblNoSelfArc2Status" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntInstituteReportingStatus2" Visible="false" runat="server" HeaderText="Institute Reporting Status CAP II">
        <tr>
            <td>
                <center><font size="2"><b>Current Admission Details CAP II</b></font></center>
                <table id="tblAdmissionDetails2" runat="server" visible="false" class="AppFormTableWithAllBorder">
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 25%;" align="right">Institute Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 75%;">
                            <asp:Label ID="lblInstituteAdmitted2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Course Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblCourseAdmitted2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Seat Type Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblSeatTypeAdmitted2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Admission Round</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblAdmissionRound2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                </table>
                <table id="tblNoAdmissionDetails2" runat="server" visible="false" class="AppFormTableWithAllBorder">
                    <tr>
                        <td align="center" style="background-color: InfoBackground">
                            <asp:Label ID="lblAdmissionStatus2" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntOptionForm3" Visible="false" runat="server" HeaderText="Option Form CAP III Status">
        <div class="table-responsive">
            <table class="AppFormTableWithOutBorder" id="tblOptionForm3" runat="server" visible="false">
                <tr id="trOptionFormStatusCAPRound3" runat="server" visible="false">
                    <td>
                        <center><font size="2"><b>Status of Option Form Submission and Confirmation for CAP Round – III</b></font></center>
                        <table class="AppFormTableWithAllBorder">
                            <tr>
                                <td align="center" style="background-color: InfoBackground">
                                    <asp:Label ID="lblOptionFormStatusCAPRound3" Font-Bold="true" runat="server" Font-Size="Medium"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntAllotmentDetails3" Visible="false" runat="server" HeaderText="Allotment Details CAP III">
        <table id="tblAllotmentDetails3" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td>
                    <center><font size="2"><b>Current Allotment Details CAP III</b></font></center>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 25%;" align="right">Institute Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 75%;">
                            <asp:Label ID="lblInstituteAllotted3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Course Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblCourseAllotted3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr id="trBenefitTaken3" runat="server">
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Benefit Taken</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblBenefitTaken3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Seat Type Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblSeatTypeAllotted3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Preference No. Allotted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblPreferenceNoAllotted3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                </td>
            </tr>
        </table>
        <table id="tblNoAllotmentDetails3" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td>
                    <center><font size="2"><b>Current Allotment Details CAP III</b></font></center>
                    <tr>
                        <td align="center" style="background-color: InfoBackground">
                            <asp:Label ID="lblAllotmentStatus3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntSelfArc3" Visible="false" runat="server" HeaderText="Seat Acceptance Status CAP III">
        <table id="tblSelfArc3" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td runat="server" id="tdSeatAcceptanceStatus3">
                   <%-- <center><font size="2"><b>Seat Acceptance Status CAP III</b></font></center>--%>
                    <tr>
                        <td style="width: 15%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Step ID</b></td>
                        <td style="width: 65%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Step Details</b></td>
                        <td style="width: 20%; border: 1px solid #F0F0F0; background-color: rgba(26, 188, 156, 0.22); text-align: center;"><b>Status</b></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 1</td>
                        <td style="border: 1px solid #F0F0F0;">Self Verification Status [Candidate shall ensure the claims related with Qualifying Marks, category, gender, reservation, special reservation made by himself/herself in the applications form are correct and the relevant documents uploaded to substantiate claims are authentic and correct.]</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptance3Step1" runat="server" CssClass="InputButton"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 2</td>
                        <td style="border: 1px solid #F0F0F0;">choose Betterment Option [Freeze/Betterment (Not Freeze)]</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptance3Step2" runat="server" CssClass="InputButton"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 3</td>
                        <td style="border: 1px solid #F0F0F0;">Pay Seat Acceptance Fee - Rs. 1000/-</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptance3Step3" runat="server" CssClass="InputButton"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="border: 1px solid #F0F0F0;" align="center">Step 4</td>
                        <td style="border: 1px solid #F0F0F0;">Confirm Seat Acceptance Letter</td>
                        <td style="border: 1px solid #F0F0F0;" align="center">
                            <asp:Button ID="btnSeatAcceptance3Step4" runat="server" CssClass="InputButton" Enabled="false"></asp:Button></td>
                    </tr>
                </td>
            </tr>
        </table>
        <table id="tblNoSelfArc3" runat="server" visible="false" class="AppFormTableWithAllBorder">
            <tr>
                <td>
                    <center><font size="2"><b>Seat Acceptance Status CAP III</b></font></center>
                    <tr>
                        <td align="center" style="background-color: InfoBackground">
                            <asp:Label ID="lblNoSelfArc3Status" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="cntInstituteReportingStatus3" Visible="false" runat="server" HeaderText="Institute Reporting Status CAP III">
        <tr>
            <td>
                <center><font size="2"><b>Current Admission Details CAP III</b></font></center>
                <table id="tblAdmissionDetails3" runat="server" visible="false" class="AppFormTableWithAllBorder">
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 25%;" align="right">Institute Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 75%;">
                            <asp:Label ID="lblInstituteAdmitted3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Course Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblCourseAdmitted3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Seat Type Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblSeatTypeAdmitted3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Admission Round</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblAdmissionRound3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                </table>
                <table id="tblNoAdmissionDetails3" runat="server" visible="false" class="AppFormTableWithAllBorder">
                    <tr>
                        <td align="center" style="background-color: InfoBackground">
                            <asp:Label ID="lblAdmissionStatus3" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </cc1:ContentBox>

    <cc1:ContentBox ID="cntILReporting" Visible="false" runat="server" HeaderText="Institute Level Admission Details">
        <tr>
            <td>
                <center><font size="2"><b> Institute Level Admission Details</b></font></center>
                 <table id="tblILReporting" runat="server" visible="false" class="AppFormTableWithAllBorder">
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 25%;" align="right">Institute Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0; width: 75%;">
                            <asp:Label ID="lblInstituteAdmittedIL" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Course Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblCourseAdmittedIL" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Seat Type Admitted</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblSeatTypeAdmittedIL" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;" align="right">Admission Round</td>
                        <td style="background-color: InfoBackground; border: 1px solid #F0F0F0;">
                            <asp:Label ID="lblAdmissionRoundIL" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Green"></asp:Label></td>
                    </tr>
                </table>
                <table id="tblNOILReporting" runat="server" visible="false" class="AppFormTableWithAllBorder">
                    <tr>
                        <td align="center" style="background-color: InfoBackground">
                            <asp:Label ID="lblNOILReportingStatus" runat="server" Font-Bold="true" Font-Size="Small" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </cc1:ContentBox>
    <div id="divPrint" class="AppFormTable">
    </div>
</asp:Content>
