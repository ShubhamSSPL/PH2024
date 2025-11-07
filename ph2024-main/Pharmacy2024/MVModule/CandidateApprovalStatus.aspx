<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateApprovalStatus.aspx.cs" Inherits="Pharmacy2024.MVModule.CandidateApprovalStatus" %>
<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<!DOCTYPE html> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
    <link rel="stylesheet" href="../Styles/Style.css" type="text/css" />
    <style type="text/css" media="screen">
        .Header {
            text-align: center;
            font-weight: bold;
            font-family: Verdana;
            font-size: 8px;
            background-color: #d8d8d8;
            color: #000000;
            vertical-align: top;
            border-top-width: 1px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 0px;
            border-style: solid;
            border-color: #c8c8c8;
        }

        .Footer {
            text-align: center;
            font-weight: bold;
            font-family: Verdana;
            font-size: 8px;
            background-color: #d8d8d8;
            color: #000000;
            vertical-align: top;
            border-top-width: 0px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 0px;
            border-style: solid;
            border-color: #c8c8c8;
        }

        .InnerText {
            text-align: center;
            font-family: Verdana;
            font-size: 8px;
            color: #000000;
            vertical-align: top;
            border-top-width: 0px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 0px;
            border-style: solid;
            border-color: #c8c8c8;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:10px;">
           <%-- <asp:Button ID="btnSubmit" runat="server" Text="Back to Home Page" CssClass="InputButton" PostBackUrl="~/ApplicationPages/WelcomePageInstitute.aspx"/>
        --%>
             <table class='AppFormTableWithOutBorder'>
                <tr>
                    <td style='width: 7%;' align='center'>
                        <img src='../Images/ARAFINAL.png' />

                    </td>
                    <td style='width: 93%;' align='center'>
                        <b><font size='3'>Admission Regulating Authority, Government of Maharashtra</font><br />
                            9th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)<br />
                            <br />
                            <font size='2'>List of Candidates Admitted to First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admission for the Academic Year <%= AdmissionYear %> </font>
                            <br />
                            <b><font size='3'>Proforma (B)</font></b>
                            <br />
                            <font size='2'></b></td>                    
                </tr>
            </table>  
            <table class="AppFormTableWithOutBorder">
                <tr >
                    <td style="text-align: left">
                        <h5 style="margin-top:10px;">
                            Institute Code: <asp:Label ID="lblInstCode" runat="server" Text="" Font-Size="Small" ForeColor="#990033"></asp:Label> <br />
                            Institute Name: <asp:Label ID="lblInstName" runat="server" Text="" Font-Size="Small" ForeColor="#990033"></asp:Label> </h5>
                    </td>
                </tr>
            </table>
             <br />
            <asp:GridView ID="gvReport" runat="server" ShowFooter="false" AutoGenerateColumns="False" 
                Width="75%" CellPadding="5" CssClass = "DataGrid" OnRowDataBound="OnRowDataBound">
            <Columns>
                <asp:TemplateField HeaderText = "Sr. No. (1)" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:BoundField DataField="CourseNameAdmitted" HeaderText="Course Name  <br/> (2)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="ApplicationID" HeaderText="Application <br/> ID <br/> (3)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                           
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate <br/> Name <br/> (4)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 
                
                <asp:BoundField DataField="Gender" HeaderText="Gender  <br/> (5)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                
                <asp:BoundField DataField="AdmissionDoneOn" HeaderText="Entrance <br/> Exam  <br/> (6)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="MeritMarks" HeaderText="Merit  <br/> Marks  <br/> (7)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                
                <asp:BoundField DataField="AdmissionCategory" HeaderText="Category / <br/> Orphan  <br/> (8)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="PH_DefenceType" HeaderText="PH / <br/> Defence <br/> Type  <br/> (9)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="SeatTypeAdmitted" HeaderText="Seat <br/> Type  <br/> (10)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="CAPRoundAdmitted" HeaderText="CAP <br/> Round  <br/> (11)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="ApprovalStatus" HeaderText="Approval <br/> Status  <br/> (12)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="Discrepancy" HeaderText="Nature <br/> of <br/> Discrepency  <br/> (13)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="MVDiscrepancyRemark" HeaderText="Discrepency <br/> Remark  <br/> (14)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
              
            </Columns>
        </asp:GridView> 

            
        </div>
    </form>
</body>
</html>
