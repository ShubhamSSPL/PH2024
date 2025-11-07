<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMLVCertificate.aspx.cs" Inherits="Pharmacy2024.MVModule.frmMLVCertificate" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>..:: Admission Regulating Authority, Government of Maharashtra ::..</title>
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
            <table class='AppFormTableWithOutBorder'>
                <tr>
                    <td style='width: 7%;' align='center'>
                        <img src="../Images/ARAFINAL.png" />

                    </td>
                    <td style='width: 93%;' align='center'>
                        <b><font size='3'>Admission Regulating Authority, Government of Maharashtra</font><br />
                            9th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)<br />
                            <br />
                            <font size='2'>List of Candidates Admitted to First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions <%= AdmissionYear %></font>
                            <br />
                            <br />
                          
                            
                            <font size='2'><b></td>
                </tr>
            </table>
            <table class="AppFormTableWithOutBorder">
                <tr>
                    <td>
                        <h2 style="text-align: center">CERTIFICATE</h2>
                    </td>
                </tr>
                <tr >
                    <td style="text-align: center">
                        <h3 style="margin-top:10px;">This is to certify that this Directorate has verified the admissions of students admitted at
                            institute <asp:Label ID="lblInstCode" runat="server" Text=""></asp:Label>-<asp:Label ID="lblInstName" runat="server" Text=""></asp:Label> for B.Pharmacy & Post Graduate Pharm.D for the Academic Year <%= AdmissionYear %>, the detailed report is given below, -</h3>
                    </td>
                </tr>
            </table>
             <br /><br />
          <%--  <table cellspacing="0" class="AppFormTable">
                <tbody>
                    <tr>
                        <td bgcolor="#d8d8d8" width="2%" align="Center"><b>Sr. No.</b></td>
                        <td bgcolor="#d8d8d8" width="4%" align="Center"><b>Choice Code, Branch Name and Shift, if any </b></td>
                        <td bgcolor="#d8d8d8" width="4%" align="Center"><b>Type of Admission within</b></td>
                        <td bgcolor="#d8d8d8" width="4%" align="Center"><b>Intake</b></td>
                        <td bgcolor="#d8d8d8" width="4%" align="Center"><b>No. of students admitted</b></td>
                        <td bgcolor="#d8d8d8" width="4%" align="Center"><b>No. of admissions  approved</b></td>
                        <td bgcolor="#d8d8d8" width="4%" align="Center"><b>Sr.No. of admissions found certain discrepancy*(Total discrepancies)</b></td>
                        <td bgcolor="#d8d8d8" width="4%" align="Center"><b>Sr.No. of admissions found not Eligible # (Total not eligible)</b></td>
                        <td bgcolor="#d8d8d8" width="4%" align="Center"><b>Sr.No. of student cancelled / Not Joined the course, if any(Total cancelled)</b></td>
                        <td bgcolor="#d8d8d8" width="4%" align="Center"><b>Remark</b></td>
                    </tr>
                    <tr>
                        <td bgcolor="#d8d8d8" align="Center"><b>1</b></td>
                        <td bgcolor="#d8d8d8"  align="Center"><b>2</b></td>
                        <td bgcolor="#d8d8d8" align="Center"><b>3</b></td>
                        <td bgcolor="#d8d8d8" align="Center"><b>4</b></td>
                        <td bgcolor="#d8d8d8" align="Center"><b>5</b></td>
                        <td bgcolor="#d8d8d8" align="Center"><b>6</b></td>
                        <td bgcolor="#d8d8d8" align="Center"><b>7</b></td>
                        <td bgcolor="#d8d8d8" align="Center"><b>8</b></td>
                        <td bgcolor="#d8d8d8" align="Center"><b>9</b></td>
                        <td bgcolor="#d8d8d8" align="Center"><b>10</b></td>
                    </tr>
                    
                </tbody>

            </table>--%>
           
            
            <asp:GridView ID="gvReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" Width="70%" CellPadding="5" CssClass = "DataGrid">
            <Columns>
             <%--   <asp:TemplateField HeaderText="Institute Code" >  
             <ItemTemplate> 
                 <asp:Label ID="lblInstCode" runat="server" Text='<%#Bind("InstituteCode") %>'  /> 
                 </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
            </asp:TemplateField>  --%>               
           <%--     <asp:HyperLinkField DataTextField = "InstituteName" DataNavigateUrlFields="InstituteCode" DataNavigateUrlFormatString = "frmAllotedChoiceCodeList.aspx?InstituteCode={0}" HeaderText = "Institute Code">
                    <ItemStyle HorizontalAlign="Left" Width="50%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:BoundField DataField="CourseName" HeaderText="CourseName <br/> (1)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                    <%--<asp:BoundField DataField="ChoiceCode" HeaderText="ChoiceCode" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>--%>
                    <%--<asp:BoundField DataField="CourseName" HeaderText="CourseName" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>--%>
                 <asp:BoundField DataField="TPA" HeaderText="Type of Admission with in <br/> (Choice Code) <br/> (2)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="TotalIntake" HeaderText="Total <br/> Intake <br/> (3)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalAdmitted" HeaderText="Total <br/> Admitted <br/> (4)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="IsAccepted" HeaderText="No. of admissions <br/>  approved <br/> (5)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="IsRejected" HeaderText="Sr.No. of admissions <br/> found certain discrepancy* <br/> (Total discrepancies) <br/> (6)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                <asp:BoundField DataField="IsCancelled" HeaderText="Sr.No. of students <br/> cancelled or not joined <br/> the course,  <br/> (Total discrepancies) <br/> (7)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
              <%--  <asp:BoundField DataField="NotRecomended" HeaderText="Not <br/> Recomended" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>--%>
              
               <%--     <asp:HyperLinkField DataTextField = "InstituteCode" DataNavigateUrlFields="InstituteCode" DataNavigateUrlFormatString = "frmMLVCertificate.aspx?InstituteCode={0}" HeaderText = "Certificate">
                    <ItemStyle HorizontalAlign="Left" Width="50%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
            </Columns>
        </asp:GridView> 
            
            <br /><br />
            <font size="2">General remarks, if any,-</font>
            <br />
            <asp:TextBox runat="server" ID="txtRemarks" MaxLength ="500" TextMode="MultiLine" Rows="5" Columns="100" Enabled="false"></asp:TextBox>
            <br /><br />
            <font size="2" color="#000000">The numbers of admissions shown in column No. 4 are scrutinized & verified 
                as per rules / regulations laid down by the respective authorities. Admissions shown in column no 4 except
                admissions with Sr. No marked in column 6 are recommended for approval. Sr. No of admissions shown in 
                column 6 & 7 are not recommended for approval.
            </font>
            <br /><br /><br /><br />
            <table style="font-family: Verdana; color: #000000" width="100%;">
                <tbody>
                    <tr>
                         <td align="left" style="font-weight: bold; font-size: 12px">
                            Date: <asp:Label runat="server" ID="lblDt"></asp:Label></td>
                        
                        <td align="right" style="font-weight: bold; font-size: 12px;">
                           Verified by <asp:Label runat="server" ID="lblUsr"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
              <br /><br /><br /><br />
            <table style="border-bottom:1px dotted #333; font-family: Verdana; color: #000000" width="100%;">
                <tbody>
                    <tr>
                        <td align="left" style="font-weight: bold; font-size: 12px">
                            Place:	<asp:Label runat="server" ID="lblPlace"></asp:Label></td>
                        <td align="right" style="font-weight: bold; font-size: 12px;">RO Seal </td>
                        <td align="right" style="font-weight: bold; font-size: 12px;"> Sign(Name)<br />Joint Director Regional Office,</td>
                    </tr>
                </tbody>
            </table>
             <br /><br />
            <table class="AppFormTableWithOutBorder">
                <tr>
                    <td>
                        <p style="text-align: center;font-size:12px">(For DTE Use only) </p>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <p style="font-size:12px">The numbers of admissions shown in column No. 4 are scrutinized & verified 
                as per rules / regulations laid down by the respective authorities. Admissions shown in column no 4 except
                admissions with Sr. No marked in column 6 are recommended for approval. Sr. No of admissions shown in 
                column 6 & 7 are not recommended for approval.</p>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="font-weight: bold; font-size: 12px">
                            Date: <asp:Label runat="server" ID="lblDTEDate"></asp:Label></td>
                </tr>
            </table>
             <br /><br /> <br /><br />
            <br /><br />
            <table style="font-family: Verdana; color: #000000" width="100%;">
                <tbody>
                    <tr>
                        <td align="left" style="font-weight: bold; font-size: 12px">Seal	</td>
                        <td align="right" style="font-weight: bold; font-size: 12px;">Director </td>
                        <td align="right" style="font-weight: bold; font-size: 12px;">(Technical Education, M.S., Mumbai)</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
