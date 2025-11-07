<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="WelcomePageMVDTE.aspx.cs" Inherits="Pharmacy2024.ApplicationPages.WelcomePageMVDTE" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
   <script lang="javascript" type="text/javascript">
       window.history.forward(1);
       setTimeout(function () {
           document.getElementById('tblLogin').style.display = 'none';
       }, 10000);
   </script>
    <style>
.buttonGreen {
background: linear-gradient( 
45deg
 , #ea690c, #bc4ac3); /* Green */
border: none;
color: white;
padding: 5px 10px;
text-align: center;
text-decoration: none;
display: inline-block;
font-size: 16px;
height:140px;
border-radius:5px;
}
.buttonBlue {
 background: linear-gradient(
45deg
, #007bff, #d788ff); /* Blue */  
border: none;
color: white;
padding: 5px 10px;
text-align: center;
text-decoration: none;
display: inline-block;
font-size: 16px;
height:140px;
border-radius:5px;
}

.buttonPurpal {
    background: linear-gradient( 
45deg
 , #9c00ff, #f4717e); /* Blue */ 
border: none;
color: white;
padding: 5px 10px;
text-align: center;
text-decoration: none;
display: inline-block;
font-size: 16px;
height:140px;
border-radius:5px;
}

.buttonYellow {
background: linear-gradient( 
45deg
 , #ffc107, #ea690c); /* Yellow */
border: none;
color: white;
padding: 5px 10px;
text-align: center;
text-decoration: none;
display: inline-block;
font-size: 16px;
height:140px;
border-radius:5px;
}
.buttonBrown {
        background: linear-gradient(
45deg
, #0fc003, #09b5bc);
/* Brown */
border: none;
color: white;
padding: 5px 10px;
text-align: center;
text-decoration: none;
display: inline-block;
font-size: 16px;
height:140px;
border-radius:5px;
}
.buttonRed {
    background: linear-gradient( 
45deg
 , #c8db1c, #698908); /* Red */
border: none;
color: white;
padding: 5px 10px;
text-align: center;
text-decoration: none;
display: inline-block;
font-size: 16px;
height:140px;
border-radius:5px;
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
<script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />
<!-- Bootstrap -->
<!-- Modal Popup -->
<div id="MyPopup"  class="modal fade" role="dialog" style="width:100%">
    <div class="modal-dialog" style="width:100%">
        <!-- Modal content-->
        <div class="modal-content" style="width:100%">
            <div class="modal-header" style="width:100%">
                <button type="button" class="close" data-dismiss="modal">
                    &times;</button>
                <h4 class="modal-title">
                </h4>
            </div>
            <div class="modal-body" style="width:100%">
                <img runat="server" src="~/Images/InstructionsInst.JPEG" width="1000" />
                <%--<asp:Image runat="server" ImageUrl="~/Images/InstructionsInst.JPG"/>--%>
            </div>
            <div class="modal-footer" style="width:100%">
                <button type="button" class="btn btn-danger" data-dismiss="modal">
                    Close</button>
            </div>
        </div>
    </div>
</div>

    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible = "false">
        <br />
        <center> 
            <asp:Label ID = "lblHeader" runat = "server" Font-Names="Bookman Old Style" Font-Size = "Medium">
                Welcome for Admission to First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>
            </asp:Label>
        </center>
        <br />
        <table class = "AppFormTable" id="tblLogin">
            <tr>
                <th colspan = "4">Login Details</th>
            </tr>
            <tr>
                <td style = "width:20%" align = "right">Login ID</td>
                <td style = "width:30%"><asp:Label ID = "lblLoginID" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td style = "width:20%" align = "right">User Name</td>
                <td style = "width:30%"><asp:Label ID = "lblUserName" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align = "right">User Type</td>
                <td><asp:Label ID = "lblUserType" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right">IP Address</td>
                <td><asp:Label ID = "lblIPAddress" runat = "server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align = "right">Current Login Time</td>
                <td><asp:Label ID = "lblCurrentLoginTime" runat = "server" Font-Bold = "true"></asp:Label></td>
                <td align = "right">Previous Login Time</td>
                <td><asp:Label ID = "lblPreviousLoginTime" runat = "server" Font-Bold = "true"></asp:Label></td>
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
        <table class = "AppFormTable">
            <tr>
                  <td colspan = "4">
                       <%--<p align = "justify"><b>Instructions for Scrutiny Officer (SO) :</b></p>
                    <ol class="list-text">
                        <li><p align = "justify">Confirm Verification List :  SO needs to confirm Institute Submitted list.</p></li>
                        <li><p align = "justify">SO verify Admitted Candidate list,  Select Recommended Not Recommended from list. </p></li>
                        <li><p align = "justify">If any Descripency found Mark Not Recommended and select Reason for the same</p></li>
                      <li><p align = "justify">Edit Confirmed Documents : SC can change the status of submitted documents by the candidate.</p></li>
                        <li><p align = "justify">Check Application Status : SC can check the status of candidate's application process.</p></li>
                        <li><p align = "justify">Send SMS to Candidates : SC should send SMS to candidates after confirming his/her application.</p></li>
                    </ol>--%>
                      </td>
            </tr>
            <tr>
                <td>
                      <div class="card card-dark border-0 " >
                    <div class="card-header text-center">
                      Status
                    </div>
                    <div class="card-body" >
						<div class="row text-center">
							<div class="col-sm-4">
								<div class="card card2">
									<h4 class=""> No. of Institutes :  
                                    <span class="text-danger"> 
                                        <asp:label ID="lblInst" runat="server"></asp:label>
                                    </span></h4>									
								</div>
							</div>
							<div class="col-sm-4" >
								<div class="card card2" >
									<h4 class="">No of Institues Submitted Merit List for verification :
									<span class="text-danger">
                                       <asp:label ID="lblMVSubmitted" runat="server"></asp:label>
									</span></h4>
								</div>
							</div>
                            </div>                        
                    </div>
                </div>
                </td>
            </tr>
                            <tr>
                <td>
                      <div class="card card-dark border-0 " >                    
                    <div class="card-body" >
						<div class="row text-center">
                            <div class="col-sm-4">
								<div class="card card3" >
									<h4 class="">No of Institues Verified by RO :
									<span class="text-danger">
                                        <asp:Label ID="lblROVerified" runat="server"></asp:Label>
									</span></h4>
								</div>
							</div>
                            <div class="col-sm-4">
								<div class="card card3" >
									<h4 class="">No of Institues Verified by DTE :
									<span class="text-danger">
                                        <asp:Label ID="lblDTEVerified" runat="server"></asp:Label>
									</span></h4>
								</div>
							</div>
						</div>                        
                    </div>
                </div>
                </td>
            </tr>

        </table>
        </cc1:ContentBox>
</asp:Content>

