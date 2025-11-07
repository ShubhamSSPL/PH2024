<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="WelcomePageAFC.aspx.cs" Inherits="Pharmacy2024.ApplicationPages.WelcomePageAFC" %>

<%@ Register TagPrefix="ddlb" Assembly="OptionDropDownList" Namespace="OptionDropDownList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownList_OptGroup" Namespace="DropDownList_OptGroup" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        .AppFormTable {
            margin-bottom: 3%;
        }
    </style>
    <style>
        .buttonGreen {
            background: linear-gradient(45deg, #066d31, #25b3ac ); /* Green */
            border: none;
            color: white;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            border-radius: 7px;
            width: 100%;
        }

        .buttonBlue {
            background: linear-gradient(45deg, #033c65, #0b96fa); /* Blue */
            border: none;
            color: white;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            border-radius: 7px;
            width: 100%;
        }

        .buttonPurpal {
            background: linear-gradient(45deg, #390954, #8f4ad4); /* Blue */
            border: none;
            color: white;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            border-radius: 7px;
            width: 100%;
        }

        .buttonYellow {
            background: linear-gradient(45deg, #f6476e, #d88c1a); /* Yellow */
            border: none;
            color: white;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            border-radius: 7px;
            width: 100%;
        }

        .buttonBrown {
            background: linear-gradient(45deg, #6d1111, #ce6a3b); /* Brown */
            border: none;
            color: white;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            border-radius: 7px;
            width: 100%;
        }

        .buttonRed {
            background: linear-gradient(45deg, #61124e, #eb1357); /* Red */
            border: none;
            color: white;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            border-radius: 7px;
            width: 100%;
        }
        .btnheight1{
            height:100px;
            padding:5px !important;
        }
        @media screen and (max-width:1024px){
            .btnheight1{
                height:120px;
            }
        }
         @media (max-width:420px) and (min-width:320px){
            .btnheight1{
                height:152px;
            }
        }
         .btnheight2{
             height:120px;
             padding:5px !important;
         }
          @media screen and (max-width:768px){
            .btnheight2{
                height:105px;
                margin-bottom:10px;
            }
        }
          .btnheight3{
              height:100px;
              padding:5px !important;
          }
          @media screen and (max-width:1024px){
            .btnheight3{
                height:125px;
            }
          }
           @media (max-width:425px) and (min-width:375px){
            .btnheight3{
                height:105px;
            }
           }
    </style>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        setTimeout(function () {
            document.getElementById('tblLogin').style.display = 'none';
        }, 10000);
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderVisible="false">
        <br />
        <center>
            <asp:Label ID="lblHeader" runat="server" Font-Names="Bookman Old Style" Font-Size="Medium" Width="92%">
               Welcome for Admission to First Year of Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>
            </asp:Label>
        </center>
        <br />
       
        <cc1:ContentBox ID="tblDocVerification" runat="server" HeaderText="CVC TVC NCL EWS Document Verification [Need to clear on priority]" Visible="false">
            <center>
             <table class="AppFormTable" style="width:90%"  runat="server" >
                 <tr>
                     <td style="width:50%;">
                         <asp:Panel ID="Panel5" runat="server"  HorizontalAlign="Center" CssClass="buttonBlue btnheight1">
                            <asp:Label ID="lblNewCVCEWSNCL" runat="server" Text ="New CVC TVC NCL EWS Document Verification for Approval"></asp:Label>  <br />
                             <asp:LinkButton ID="LinkButton8" runat="server" ForeColor="WhiteSmoke" OnClick="btnNewCVCEWSNCL_Click" >
                           <asp:Label ID="lblCVCTVCCount" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                             </asp:LinkButton>
                            <br /> 
                            <asp:LinkButton ID="LinkButton10" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnNewCVCEWSNCL_Click"   />
                        </asp:Panel>
                     </td>
                     <td style="width:50%;">
                         <asp:Panel ID="Panel6" runat="server"  HorizontalAlign="Center" CssClass="buttonPurpal btnheight1">
                            <asp:Label ID="Label2" runat="server" Text ="Approve Correct Document"></asp:Label>  <br />
                             <asp:LinkButton ID="LinkButton12" runat="server" ForeColor="WhiteSmoke" OnClick="btnCorrectDocument_Click" >
                           <asp:Label ID="lblCorrectDocument" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                             </asp:LinkButton>
                            <br /> 
                            <asp:LinkButton ID="LinkButton14" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnCorrectDocument_Click"   />
                        </asp:Panel>
                     </td>  
                 </tr>
                   
             </table>
        </center>
        </cc1:ContentBox>


        <cc1:ContentBox ID="tblSAGrievanceDashBoardLinks" runat="server" HeaderText="Seat Acceptance Grievance Status Dashboard [Need to clear on priority]" Visible="false">
            <center>
             <table class="AppFormTable" style="width:90%"  runat="server" >
                 <tr>
                     <td>
                         <div class="row">
                             <div class="col-sm-3 col-6">
                                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" CssClass="buttonBlue btnheight2">
                                    <asp:Label ID="Label1" runat="server" Text ="New Grievances for Approval"></asp:Label>  <br />
                                    <asp:LinkButton ID="LinkButton7" runat="server" ForeColor="WhiteSmoke" OnClick="btnNewGrievances_Click" >
                                        <asp:Label ID="lblNewGrievances" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                                    </asp:LinkButton>
                                    <br /> 
                                    <asp:LinkButton ID="btnNewGrievances" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnNewGrievances_Click"   />
                                </asp:Panel>
                             </div>
                             <div class="col-sm-3 col-6 ">
                                 <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center" CssClass="buttonPurpal btnheight2">
                            <asp:Label ID="Label3" runat="server" Text ="Picked up Grievances"></asp:Label>  <br />
                             <asp:LinkButton ID="LinkButton9" runat="server" ForeColor="WhiteSmoke" OnClick="btnPickedupGrievances_Click" >
                           <asp:Label ID="lblPickedupGrievances" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                             </asp:LinkButton>
                            <br /> 
                            <asp:LinkButton ID="btnPickedupGrievances" runat="server" Text="View Details >>" ForeColor="WhiteSmoke"  OnClick="btnPickedupGrievances_Click" />
                        </asp:Panel>
                             </div>
                             <div class="col-sm-3 col-6 ">
                                 <asp:Panel ID="Panel3" runat="server"  HorizontalAlign="Center" CssClass="buttonRed btnheight2">
                            <asp:Label ID="Label5" runat="server" Text ="Rejected Grievances"></asp:Label>  <br />
                             <asp:LinkButton ID="LinkButton11" runat="server" ForeColor="WhiteSmoke" OnClick="btnRejectedGrievances_Click" >
                           <asp:Label ID="lblRejectedGrievances" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                             </asp:LinkButton>
                            <br /> 
                            <asp:LinkButton ID="btnRejectedGrievances" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnRejectedGrievances_Click"  />
                        </asp:Panel>
                             </div>
                             <div class="col-sm-3 col-6">
                                 <asp:Panel ID="Panel4" runat="server"  HorizontalAlign="Center" CssClass="buttonGreen btnheight2">
                            <asp:Label ID="Label7" runat="server" Text ="Approved Grievances"></asp:Label>  <br />
                             <asp:LinkButton ID="LinkButton13" runat="server" ForeColor="WhiteSmoke" OnClick="btnApprovedGrievances_Click" >
                           <asp:Label ID="lblApprovedGrievances" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                             </asp:LinkButton>
                            <br /> 
                            <asp:LinkButton ID="btnApprovedGrievances" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnApprovedGrievances_Click" />
                        </asp:Panel>
                             </div>
                         </div>
                         
                     </td> 
                     
                 </tr>
                   
             </table>
        </center>
        </cc1:ContentBox>

        <cc1:ContentBox ID="tblEFCDashBoardLinks" runat="server" HeaderText="E-SC Verification Status Dashboard" Visible="false">
            <center>
        <table class="AppFormTableWithOutBorder"  runat="server" >
            <tr>
                <td align="center">

                    <div class="row w-100 mx-auto">
                        <div class="col-sm-4 mb-3">
                             <asp:Panel ID="plnBlue" runat="server"  HorizontalAlign="Center" CssClass="buttonBlue btnheight3">
                        <asp:Label ID="lblBlue" runat="server" Text ="New Applications for Verification"></asp:Label>  <br />
                         <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="WhiteSmoke" OnClick="btnBlue_Click" >
                       <asp:Label ID="lblBlueCount" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                         </asp:LinkButton>
                        <br /> 
                        <asp:LinkButton ID="btnBlue" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnBlue_Click" />
                    </asp:Panel>
                        </div>
                        <div class="col-sm-4 mb-3">
                            <asp:Panel ID="plnPurpal" runat="server"   HorizontalAlign="Center" CssClass="buttonPurpal btnheight3">
                        <asp:Label ID="lblPurpal" runat="server" Text ="Picked up/Partially Verified Applications"></asp:Label>  <br />
                         <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="WhiteSmoke" OnClick="btnPurpal_Click" >
                        <asp:Label ID="lblPurpalCount" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                         </asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="btnPurpal" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnPurpal_Click" />
                    </asp:Panel>
                        </div>
                        <div class="col-sm-4 mb-3">
                             <asp:Panel ID="plnRed" runat="server"  HorizontalAlign="Center" CssClass="buttonRed btnheight3" >
                        <asp:Label ID="lblRed" runat="server" Text ="Reverted Back Applications"></asp:Label>  <br />
                         <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="WhiteSmoke" OnClick="btnRed_Click" >
                             <asp:Label ID="lblRedCount" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                         </asp:LinkButton>
                        <br /> 
                        <asp:LinkButton ID="btnRed" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnRed_Click"/>
                    </asp:Panel>
             
                        </div>
                        <div class="col-sm-4 mb-3">
                             <asp:Panel ID="plnYellow" runat="server"  HorizontalAlign="Center" CssClass="buttonYellow btnheight3">
                        <asp:Label ID="lblYellow" runat="server" Text ="Re-Submitted Applications"></asp:Label>  <br /> 
                        <asp:LinkButton ID="LinkButton4" runat="server" ForeColor="WhiteSmoke" OnClick="btnYellow_Click" >
                        <asp:Label ID="lblYellowCount" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                         </asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="btnYellow" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnYellow_Click"/>
                    </asp:Panel>
                        </div>
                        <div class="col-sm-4 mb-3">
                              <asp:Panel ID="plnBrown" runat="server"  HorizontalAlign="Center" CssClass="buttonBrown btnheight3">
                        <asp:Label ID="lblBrown" runat="server" Text ="No of Grievances for Approval"></asp:Label>  <br />
                         <asp:LinkButton ID="LinkButton5" runat="server" ForeColor="WhiteSmoke" OnClick="btnBrown_Click" >
                        <asp:Label ID="lblBrownCount" runat="server" Text="0" Font-Size="XX-Large"></asp:Label>
                         </asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="btnBrown" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnBrown_Click"/>
                    </asp:Panel>
                        </div>
                        <div class="col-sm-4 mb-3">
                             <asp:Panel ID="plnGreen" runat="server"  HorizontalAlign="Center" CssClass="buttonGreen btnheight3">
                        <asp:Label ID="lblGreen" runat="server" Text ="E-SC Verified / Confirmed Applications"></asp:Label> <br />
                         <asp:LinkButton ID="LinkButton6" runat="server" ForeColor="WhiteSmoke" OnClick="btnGreen_Click"  >
                        <asp:Label ID="lblGreenCount" runat="server" Text="0" Font-Size="XX-Large"> </asp:Label>
                         </asp:LinkButton>
                        <br />
                        <asp:LinkButton ID="btnGreen" runat="server" Text="View Details >>" ForeColor="WhiteSmoke" OnClick="btnGreen_Click"/>
                    </asp:Panel>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
                   </center>
        </cc1:ContentBox>


        <asp:UpdatePanel runat="server" ID="upSpecialReservation">
            <ContentTemplate>
                <table class="AppFormTable" id="tblDashboard" runat="server" visible="false">
                    <tr>
                        <th colspan="2" style="border-top-width: 0px;">Dashboard</th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center><b>Application Status Wise Report</b></center>
                            <asp:GridView ID="gvApplicationStatusReport" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="FormStatus" HeaderText="Application Status">
                                        <ItemStyle Width="80%" HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="20%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Select Date</td>
                        <td>
                            <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">Total Confirmed Under CAP at SCs</td>
                        <td>
                            <asp:Label ID="lblCAPConfirmed" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">Total Confirmed Under Non-CAP at SCs</td>
                        <td>
                            <asp:Label ID="lblNonCAPConfirmed" runat="server"></asp:Label></td>
                    </tr>
                    <tr id="trDashboardType" runat="server">
                        <td style="text-align: right">Select Dashboard Type : </td>
                        <td>
                            <asp:DropDownList ID="ddlDashboard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDashboard_SelectedIndexChanged">
                                <asp:ListItem Value="1">Confirmed At SCs</asp:ListItem>
                               <asp:ListItem Value="2">Provisional Merit List</asp:ListItem>
                                 <asp:ListItem Value="3">Final Merit List</asp:ListItem>
                                <asp:ListItem Value="4">Fill completely But not Confirmed</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%;" valign="top">
                            <center><b>Candidature Type Wise Report</b></center>
                            <asp:GridView ID="gvCandidatureTypeWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="CandidatureTypeName" HeaderText="Candidature Type">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Home University Wise Report</b></center>
                            <asp:GridView ID="gvHomeUniversityWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="HomeUniversityName" HeaderText="Home University">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Category Wise Report</b></center>
                            <asp:GridView ID="gvCategoryWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="CategoryName" HeaderText="Category">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>PH Type Wise Report</b></center>
                            <asp:GridView ID="gvPHTypeWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="PHTypeDetails" HeaderText="PH Type">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Defence Type Wise Report</b></center>
                            <asp:GridView ID="gvDefenceTypeWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="DefenceTypeDetails" HeaderText="Defence Type">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Gender Wise Report</b></center>
                            <asp:GridView ID="gvGenderWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="GenderName" HeaderText="Gender">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>HSC Passing Year Wise Report</b></center>
                            <asp:GridView ID="gvHSCPassingYearWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="HSCPassingYear" HeaderText="HSC Passing Year">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Minority Status Wise Report</b></center>
                            <asp:GridView ID="gvMinorityReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="MinorityType" HeaderText="Minority Type" HtmlEncode="false">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 50%;" valign="top">
                            <center><b>Religion Wise Report</b></center>
                            <asp:GridView ID="gvReligionWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="ReligionName" HeaderText="Religion">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Region Wise Report</b></center>
                            <asp:GridView ID="gvRegionWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="RegionName" HeaderText="Region">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Mother Tongue Wise Report</b></center>
                            <asp:GridView ID="gvMotherTongueWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="MotherTongueName" HeaderText="Mother Tongue">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <center><b>Annual Family Income Wise Report</b></center>
                            <asp:GridView ID="gvAnnualFamilyIncomeWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="AnnualFamilyIncomeDetails" HeaderText="Annual Family Income">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>HSC Board Wise Report</b></center>
                            <asp:GridView ID="gvHSCBoardWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="BoardName" HeaderText="Board">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>Orphan Status Wise Report</b></center>
                            <asp:GridView ID="gvOrphanStatusWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="Orphan" HeaderText="Orphan Status">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <center><b>EWS Status Wise Report</b></center>
                            <asp:GridView ID="gvEWSStatusWiseReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
                                <Columns>
                                    <asp:BoundField DataField="EWS" HeaderText="EWS Status">
                                        <ItemStyle Width="70%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Right" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <ItemStyle Width="30%" HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Item" />
                                        <HeaderStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                        <FooterStyle HorizontalAlign="Center" BorderWidth="1px" BorderStyle="Solid" CssClass="Header" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
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
                <td align="right">User Role</td>
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
            <tr id="trWebSiteNavigation1" runat="server" visible="false">
                <th colspan="4">WebSite Navigation</th>
            </tr>
            <tr id="trWebSiteNavigation2" runat="server" visible="false">
                <td align="right">Select WebSite</td>
                <td colspan="3">
                    <%--<cc2:DropDownList_OptGroup ID="ddlWebSite" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWebSite_SelectedIndexChanged"></cc2:DropDownList_OptGroup></td>--%>
                    <ddlb:OptionGroupSelect ID="ddlWebSite" runat="server" AutoPostBack="true" OnValueChanged="ddlWebSite_SelectedIndexChanged"></ddlb:OptionGroupSelect>
                </td>
            </tr>
            <tr id="trInstrForPMode" runat="server">
                <td colspan="4">
                    <b>Instructions for SC  : </b>
                    <br />
                    <br />
                    <ol class="list-text">
                        <li>
                            <p align="justify">Confirm Application Form :  SC  needs to confirm candidate's application form.</p>
                        </li>
                        <li>
                            <p align="justify">Cancel Application Form :  SC  can cancel the confirmed application form.</p>
                        </li>
                        <li>
                            <p align="justify">Edit Application Form : SC  can edit application form before and after confirmation if required.</p>
                        </li>
                        <li>
                            <p align="justify">Edit Confirmed Documents : SC  can change the status of submitted documents by the candidate.</p>
                        </li>
                        <li>
                            <p align="justify">Check Application Status : SC  can check the status of candidate's application process.</p>
                        </li>
                        <%--<li>
                            <p align="justify">Send SMS to Candidates : SC should send SMS to candidates after confirming his/her application.</p>
                        </li>--%>
                    </ol>
                </td>
            </tr>
        </table>
        <table  class="AppFormTable" id="tblImportant">
            <tr>
            <td align="left">
                <p align = "justify" style="color:red"><b>Important Instructions for SC :</b></p>
                <ol class="list-text">
                    <li><p align = "justify">All SC should read information brochure thoroughly and follow the guidelines provided by State CET cell.</p></li>
                    <li><p align = "justify">SCs should visit CET cell website daily for the latest updates.</p></li>
                    <li><p align = "justify">All SCs should check the message box daily.</p></li>
                   <%-- <li><p align = "justify">All SC should resolve pending applications before the last date.</p></li>--%>
                    <li><p align = "justify">All SC should do proper counseling of candidates as per requirement.</p></li>
                    <li><p align = "justify">The State CET cell will take action against SCs who fail to follow the rules and regulations for verification of documents.</p></li>
                    <li><p align = "justify">In case of any assistance SC should communicate by message box and on special helpline provided by Agency.</p></li>
                    <li><p align = "justify">SC should ensure that they have verified the name, gender, signature, documents and format, as well as the status of candidates as stated in the application form, such as PH, EWS, TFWS, etc., as well as the supporting documents as per instructions from the CET-CELL</p></li>
                    <li><p align = "justify">For those candidates who submit a receipt for Caste Validity Certificates, SCs should ensure they submit original certificates before the CAP Round III of Institute Reporting date. If candidates fail to submit original documents, their allotment will be cancelled, and they will be converted to the open category, and they will be eligible for the next round.</p></li>
                    <li><p align = "justify">All SC are open from 10 am to 5.30 pm every day including Saturday and Sunday.  </p></li>
                </ol>
            </td>
         </tr>
                </table>
    </cc1:ContentBox>
</asp:Content>
