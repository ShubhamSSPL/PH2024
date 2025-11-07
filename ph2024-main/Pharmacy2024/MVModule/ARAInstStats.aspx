<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ARAInstStats.aspx.cs" Inherits="Pharmacy2024.MVModule.ARAInstStats" %>
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
                            <font size='2'>Institutewise Report From Directorate </font>
                            <br />
                            <b><font size='3'>Proforma (A)</font></b>
                            <br />
                            <font size='2'></b></td>
                </tr>
            </table>  
            <table class="AppFormTableWithOutBorder">
                <tr >
                    <td style="text-align: left">
                        <h5 style="margin-top:10px;">
                            Name of the Course: First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D <br />
                        </h5>
                    </td>
                    <td style="text-align: center">                        
                    </td>
                    <td style="text-align: right">
                        <h5 style="margin-top:10px;">
                            Cut-off Date: 10/01/2024 <br />
                        </h5>
                    </td>
                </tr>
            </table>
             <br />
            <asp:GridView ID="gvReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="100%" 
                CellPadding="5" CssClass = "DataGrid" OnRowDataBound="OnRowDataBound">
            <Columns>

                <asp:TemplateField HeaderText = "Sr. No. (1)" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:BoundField DataField="InstituteCode" HeaderText="Institute Code <br/>(2)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name <br/>(3)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                           
                <asp:BoundField DataField="PaidStatus" HeaderText="Processing <br/> Fees <br/> Paid <br/>(4)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 

                <asp:BoundField DataField="Proposal" HeaderText="Date of <br/> Proposal <br/> Submitted <br/> to ARA <br/>(5)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                
                <asp:BoundField DataField="TotalIntake" HeaderText="Sactioned <br/> Intake <br/>(6)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="TotalAdmitted" HeaderText="Total <br/> Admitted <br/>(7)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                
                <asp:BoundField DataField="TotalVacancy" HeaderText="Vacancy <br/>(8)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="CandidateRecommeded" HeaderText="Recommended <br/> For <br/> Approval <br/>(9)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="CandidateNotRecommeded" HeaderText="Not <br/> Recommended <br/> For <br/> Approval <br/>(10)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="TotalCancelled" HeaderText="Admission <br/> Cancelled <br/>(11)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="RemarksDTE" HeaderText="Remarks, <br/> If Any <br/>(12)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
              
            </Columns>
        </asp:GridView> 

            
        </div>
        <br />
        <div>
            <Center><asp:Button ID="btnBack" runat="server" Text="Back" PostBackUrl="~/ApplicationPages/WelcomePageMVDTE.aspx" CssClass="InputButton" /></Center>
        </div>
    </form>
</body>
</html>
