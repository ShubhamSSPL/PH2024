<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrintARAApprovalLetterInst.aspx.cs" Inherits="Pharmacy2024.ARAModule.frmPrintARAApprovalLetterInst" %>

<%@ Register Src="~/UserControls/PrintFormHeaderARA.ascx" TagName="PrintFormHeaderARA" TagPrefix="ucPFHARA" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>..:: Admission Regulating Authority, Government of Maharashtra ::..</title>
    <link rel="stylesheet" href="../Styles/Style.css" type="text/css" />
</head>
    <style>
        p,td,li{
            font-size:18px;
        }
        .AppFormTableWithOutBorder td{
            font-size:18px;
        }
        .AppFormTable th{
            font-size:18px;
        }
        .AppFormTable td{
            font-size:16px;
        }
        body{
            margin:50px;
        }
        .logo-img{
           width:30%;
        }
         div.a {
            text-indent: 50px;
        }
        .DataGrid th{
            font-size:12px;
        }
         .DataGrid td{
            font-size:10px;
        }
    </style>
    <style>
        P.pagebreakhere {page-break-before: always}
    </style>
<body>

    <form id="form1" runat="server">
       <%-- <table class="AppFormTableWithOutBorder">
            <tbody>
                <tr>
                    <td style="width: 20%;" align="center">
                        <img alt="Logo" src="../Images/ARAFINAL.png" class="logo-img img-fluid"></td>
                    <td style="width: 60%;" align="center">
                        <h2>Government of Maharashtra,</h2>
                        <h3>Admission Regulating Authority, </h3>
                    </td>
                    <td style="width: 20%;" align="center">
                        <img alt="Logo" src="../Images/WebsiteLogo.png" class="logo-img img-fluid">
                     </td>
                </tr>
               
               <tr>
                   <td >
                       9th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Near CSMT Mumbai-400001. (M.S.)
                   </td>
                   <td></td>
                   <td >
                       Tele No. : 022 - 2201 6159<br />
                       Website : <a href="http://www.maha-ara.org">http://www.maha-ara.org</a>
                       <br />
                       E-Mail&nbsp;&nbsp;&nbsp; : maharashtra.ara@gmail.com
                   </td>
               </tr>
            </tbody>
        </table>--%>
        <ucPFHARA:PrintFormHeaderARA ID="printFHARA" runat="server"></ucPFHARA:PrintFormHeaderARA>        
        <br />
        <hr />
        <br />
        <table class="AppFormTableWithOutBorder" >
            <tbody>
                <tr>
                    <td>
                    <b> No. ARA/Approval/<%=AdmissionYear%>/<asp:Label ID="lblInstCode1" runat="server" Text="Label"></asp:Label></b>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblAprovalDt3" runat="server" Text="Label" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        To,<br />
                        The Dean/Principal,<br />
                        <asp:Label ID="lblInstCode" runat="server" Text="Label"></asp:Label><br />
                        <asp:Label ID="lblinstName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>               
            </tbody>
        </table>
         <br /><br />
       <table class="AppFormTableWithOutBorder">
           <tr style="margin-left: 30px">
               <td >
                   <p><strong>Sub:</strong> Approval of provisional admissions granted by your Institute in Course <asp:Label ID ="lblCourse" runat="server"></asp:Label> for Academic Year <%=AdmissionYear%>.</p>
                    <br /> <br />
                   <p><strong>Ref:</strong> 1) Minutes of the Meeting of Admissions Regulating Authority held on dated 
                       <asp:Label ID="lblAprovalDt1" runat="server" Text=""></asp:Label>
                   </p>
                   &nbsp; &nbsp; &nbsp;&nbsp;
                   <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2) Minutes of the meeting of Admissions Regulating Authority held on dated 01/09/2024. </p>
             <br />
               </td>
           </tr>
       </table>       
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="left">        
                    <p>
                             Sir/Madam,
                        </p><br />
                    <div class="a">
                        
                        <p  align="justify">
                           
                             The Authority has received a proposal on <asp:Label ID="lblProposalDt" runat="server" Text=""></asp:Label>, for Approval of Admission of candidates provisionally
                admitted in your Institute/College for the Academic Year <%=AdmissionYear%>.
                        </p>
                    </div><br />
            <div class="a">
                <p  align="justify">
                    On the basis of verification report, submitted by the concerned Directorate, the Authority has
                resolved its decision in the meeting held on <asp:Label ID="lblAprovalDt2" runat="server" Text=""></asp:Label>, which is published on the website of ARA.
                Accordingly, by the Order of Admissions Regulating Authority, Mumbai it is hereby informed that the
                Authority is, prima face, satisfied as to the correctness of eligibility and data of provisionally admitted
                students in your college and decided to accord its approval for students in your institute for the
                Academic Year <%=AdmissionYear%>. <asp:Label ID="lblPenalty" runat="server" Text="Subject to payment of penalty of Rs. 1 Lakh for delay submission of the Admission Approval proposal." Visible="false" Font-Bold="True"></asp:Label> 
                    The names of the student approved/not approved are attached here with. The discrepancies found during physical verification have been already informed to you, the details of which are as under ;-
                </p>
            </div>
                </td>
            </tr>
        </table>
        <br />    
        <br />
       
        <table class="AppFormTable" style="text-align: center; width: 100%">
            <tr>
                <th style="width: 15%">Total Intake                    
                </th>
                <th style="width: 15%">No. of Students Admitted
                    <br />
                    Provisionally by the college
                </th>
                <th  style="width: 15%">No. of Students whose admission
                    <br />
                    is approved by ARA
                </th>
                <th  style="width: 15%">No. of admissions not approved
                </th>
                <th  style="width: 15%">Admission cancelled
                </th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblIntake" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTAdm" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAAdm" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblRAdm" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCAdm" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="left">
                    <div class="a">
                        <p  align="justify">
                            The names of the student approved/not approved are attached here with. The above
        admissions have been electronically scrutinized as well as physically verified. The discrepancies found
        during physical verification have been already informed to you.
                        </p>
                    </div><br />
                    <div class="a">
                        <p align="justify">
                            It is, however, made clear that this approval is granted on the basis of the documents and the
            information supplied and made available for verification by your college. In case the information so
            given is found incorrect and/or in case, any illegality or irregularity caused in such admissions is
            brought to notice of the Authority at later point of time, it will be open for the Authority to take
            appropriate action in that regard.
                        </p>
                    </div>
                </td>
            </tr>
        </table>     
       <br /><br /><br />
            <table style="margin-top:50px;width:100%">
                <tr style="">
                    <td align="center" style="width:30%">
                    </td>
                    <td style="width:40%">&nbsp;</td>
                    <td align="center" style="width:30%">(J.P, DANGE),<br />
                        CHAIRMAN,<br />
                        ADMISSIONS REGULATING AUTHORITY AND<br />
                        FORMER CHIEF SECRETARY,<br />
                        MAHARASHTRA STATE.
                    </td>
                </tr>
            </table>
       <br /><br /><br />

        <table class="AppFormTableWithOutBorder">
            <tbody>
                <tr>
                    <td>
                        <p>Copy to :</p>
                        <ol type="1" style="margin-left: 40px;">
                            <li>The Commissioner, Commissioner Social Welfare, Pune
                            </li>
                            <li>The Commissioner, Department of Tribal Development, Tribal Development Bhavan, Nashik – 422002.
                            </li>
                            <li>The Director, Other Backward Bahujan Welfare Department, Pune – 411001.
                            </li>
                            <li>The Director, Technical Education, Mumbai
                            </li>
                            <li>The Registrar,&nbsp;<asp:Label ID="lblUniversity" runat="server" Text=""></asp:Label>
                            </li>
                            <li>Select File, Admissions Regulating Authority
                            </li>
                        </ol>
                    </td>
                </tr>
            </tbody>
        </table>
        <p class="pagebreakhere"></p>
        <br /><br /><br />
        <table class="AppFormTableWithOutBorder">
            <tbody>
                <tr>
                    <td>
                       <b><center> Proforma - B </center></b><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Institute Code :</b><asp:Label ID="lblInstCode2" runat="server" Text="Label"></asp:Label><br />
                        <b>Institute Name :</b><asp:Label ID="lblInstName1" runat="server" Text="Label"></asp:Label><br /><br />
                    </td>
                </tr>
            </tbody>
        </table>
       <div>           
       <asp:GridView ID="gvReport" runat="server" ShowFooter="false" AutoGenerateColumns="False" 
                Width="95%" CellPadding="5" CssClass = "DataGrid" OnRowDataBound="OnRowDataBound" Font-Size="18px"
           RowStyle-Height="50px" RowStyle-Font-Size="14px">
            <Columns>
                <asp:TemplateField HeaderText = "Sr. No. (1)" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" runat="server" Font-Size="14px"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:BoundField DataField="CourseNameAdmitted" HeaderText="Course Name <br/>(2)" HtmlEncode="false" >
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px" width="20px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="PersonalID" HeaderText="Application <br/> ID <br/>(3)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                           
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate <br/> Name <br/>(4)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 
                
                <asp:BoundField DataField="Gender" HeaderText="Gender <br/>(5)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                
                <asp:BoundField DataField="AdmissionDoneOn" HeaderText="Entrance <br/> Exam <br/>(6)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="MeritMarks" HeaderText="Merit  <br/> Marks <br/>(7)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                
                <asp:BoundField DataField="AdmissionCategory" HeaderText="Category / <br/> Orphan <br/>(8)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="SeatTypeAdmitted" HeaderText="Seat <br/> Type <br/>(9)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="CAPRoundAdmitted" HeaderText="CAP <br/> Round <br/>(10)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="ApprovalStatus" HeaderText="Approval <br/> Status <br/>(11)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="Discrepancy" HeaderText="Nature <br/> of <br/> Discrepency <br/>(12)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="MVDiscrepancyRemark" HeaderText="Discrepency <br/> Remark <br/>(13)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" Font-Size="14px"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
              
            </Columns>
        </asp:GridView> 
       </div>
    </form>

</body>
</html>

