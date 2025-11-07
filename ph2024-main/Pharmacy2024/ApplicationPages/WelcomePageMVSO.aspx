<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="WelcomePageMVSO.aspx.cs" Inherits="Pharmacy2024.ApplicationPages.WelcomePageMVSO" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script lang="javascript" type="text/javascript">
        window.history.forward(1);
        setTimeout(function () {
            document.getElementById('tblLogin').style.display = 'none';
        }, 10000);
    </script>
    <style>
        .modal-dialog {
            max-width: none !important;
        }

        .sostatus {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }

        .sobox {
            margin: 10px;
            padding: 25px;
            color: white;
            width: 24%;
            font-size: 1.20rem;
            text-align: center;
            border-radius: 7px;
        }

            .sobox a {
                color: white;
                text-decoration: underline;
            }

        .sostatus .buttonBlue {
            background: linear-gradient(45deg, #033c65, #0b96fa); 
        }

        .sostatus .buttonPurple {
            background: linear-gradient(45deg, #390954, #8f4ad4); 
        }

        .sostatus .buttonRed {
            background: linear-gradient(45deg, #61124e, #eb1357); 
        }

        .sostatus .buttonGreen {
            background: linear-gradient(45deg, #066d31, #25b3ac );
        }

        @media screen and (max-width:425px) {
            .sobox {
                width: 100%;
            }
        }
    </style>

    <script type="text/javascript">
        function ShowPopup() {
            /*function ShowPopup(title, body) {*/
            //$("#MyPopup  model-title").html(title);
            //$("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }
    </script>
    <!-- Bootstrap -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css">
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js"></script>
    <!-- Bootstrap -->
    <!-- Modal Popup -->
    <div id="MyPopup" class="modal fade" role="dialog" style="width: 100%">
        <div class="modal-dialog" style="width: 70%">
            <!-- Modal content-->
            <div class="modal-content" style="width: 100%">
                <div class="modal-header" style="width: 100%">
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body" style="width: 100%">
                    <img runat="server" src="~/Images/InstructionsInst.JPEG" style="width: 100%" />
                    <%--<asp:Image runat="server" ImageUrl="~/Images/InstructionsInst.JPG"/>--%>
                </div>
                <div class="modal-footer" style="width: 100%">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>

    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible="false">
        <br />
        <center>
            <asp:Label ID="lblHeader" runat="server" Font-Names="Bookman Old Style" Font-Size="Medium">
                Welcome for Admission to First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>
            </asp:Label>
        </center>
        <br />
        <table class="AppFormTable" id="tblLogin">
            <tr>
                <th colspan="4">Login Details</th>
            </tr>
            <tr>
                <td style="width: 20%" align="right">Login ID</td>
                <td style="width: 30%">
                    <asp:Label ID="lblLoginID" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 20%" align="right">User Name</td>
                <td style="width: 30%">
                    <asp:Label ID="lblUserName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">User Type</td>
                <td>
                    <asp:Label ID="lblUserType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">IP Address</td>
                <td>
                    <asp:Label ID="lblIPAddress" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Current Login Time</td>
                <td>
                    <asp:Label ID="lblCurrentLoginTime" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Previous Login Time</td>
                <td>
                    <asp:Label ID="lblPreviousLoginTime" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <%--<tr>
                <td colspan = "4">
                    <p align = "justify"><b>Instructions for SO :</b></p>
                    <ol class="list-text">
                        <li><p align = "justify">Confirm Application Form :  SC needs to confirm candidate's application form.</p></li>
                        <li><p align = "justify">Cancel Application Form :  SC can cancel the confirmed application form.</p></li>
                        <li><p align = "justify">Edit Application Form : SC can edit application form before and after confirmation if required.</p></li>
                        <li><p align = "justify">Edit Confirmed Documents : SC can change the status of submitted documents by the candidate.</p></li>
                        <li><p align = "justify">Check Application Status : SC can check the status of candidate's application process.</p></li>
                        <li><p align = "justify">Send SMS to Candidates : SC should send SMS to candidates after confirming his/her application.</p></li>
                    </ol>
                </td>
            </tr>--%>
        </table>
        <table class="AppFormTable">
            <tr>
                <td colspan="4">
                    <p align="justify"><b>Instructions for Scrutiny Officer (SO) :</b></p>
                    <ol class="list-text">
                        <li>
                            <p align="justify">Confirm Verification List :  SO needs to confirm Institute Submitted list.</p>
                        </li>
                        <li>
                            <p align="justify">SO verify Admitted Candidate list,  Select Recommended Not Recommended from list. </p>
                        </li>
                        <li>
                            <p align="justify">If any Descripency found Mark Not Recommended and select Reason for the same</p>
                        </li>
                        <%--  <li><p align = "justify">Edit Confirmed Documents : SC can change the status of submitted documents by the candidate.</p></li>
                        <li><p align = "justify">Check Application Status : SC can check the status of candidate's application process.</p></li>
                        <li><p align = "justify">Send SMS to Candidates : SC should send SMS to candidates after confirming his/her application.</p></li>--%>
                    </ol>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="HeadDiv text-center">
                        <span>Status</span>
                    </div>
                    <div class="sostatus mt-3">
                        <div class="sobox buttonBlue">
                            <span class="">Choice Codes Assigned :  </span>
                            <a class="">
                                <asp:HyperLink ID="hlInst" runat="server" NavigateUrl="~/MVModule/frmAllotedInstituteSO.aspx"></asp:HyperLink>
                            </a>
                        </div>
                        <div class="sobox buttonPurple">
                            <span class="">Candidates Assigned :</span>
                            <a class="">
                                <asp:HyperLink ID="hlCandidate" runat="server" NavigateUrl="~/MVModule/frmAllotedInstituteSO.aspx"></asp:HyperLink>
                            </a>
                        </div>
                        <div class="sobox buttonRed">
                            <span class="">Candidates Verified :</span>
                            <a class="">
                                <asp:Label ID="lblCndVerified" runat="server"></asp:Label>
                            </a>
                        </div>
                        <div class="sobox buttonGreen">
                            <span class="">Candidates Pending for Verification :</span>
                            <a class="">
                                <asp:Label ID="lblCndPending" runat="server"></asp:Label>
                            </a>
                        </div>
                    </div>
                </td>
            </tr>

        </table>
    </cc1:ContentBox>
</asp:Content>
