<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupPaymentReceipt.aspx.cs" Inherits="Pharmacy2024.FeeProcess.Receipt.GroupPaymentReceipt" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Deccan Education Society's
Fergusson College(Autonomous), Pune
Admission Process, 2020
</title>
        <style type="text/css">
        #table-2
        {
            border: 5px solid #e3e3e3;
            background-color: #f2f2f2;
            border-radius: 6px;
            -webkit-border-radius: 6px;
            -moz-border-radius: 6px;
        }
        #table-2 td, #table-2 th
        {
            padding: 5px;
            color: #333;
        }
        #table-2 thead
        {
            font-family: "Lucida Sans Unicode" , "Lucida Grande" , sans-serif;
            padding: .2em 0 .2em .5em;
            text-align: left;
            color: #4B4B4B;
            background-color: #C8C8C8;
            background-image: -webkit-gradient(linear, left top, left bottom, from(#f2f2f2), to(#e3e3e3), color-stop(.6,#B3B3B3));
            background-image: -moz-linear-gradient(top, #D6D6D6, #B0B0B0, #B3B3B3 90%);
            border-bottom: solid 1px #999;
        }
        #table-2 th
        {
            font-family: 'Helvetica Neue' , Helvetica, Arial, sans-serif;
            font-size: 14px;
            line-height: 16px;
            font-style: normal;
            font-weight: normal;
            text-align: center;
            text-shadow: white 1px 1px 1px;
        }
        #table-2 td
        {
            line-height: 15px;
            font-family: 'Helvetica Neue' , Helvetica, Arial, sans-serif;
            font-size: 12px;
            border-bottom: 1px solid #fff;
            border-top: 1px solid #fff;
        }
        #table-2 td:hover
        {
            background-color: #fff;
        }
    </style>
    </head>
<body onload="window.print();">
  <%--  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<center><b>( Applicant's Copy )</b></center>--%>
    <div id="divMain">
        <form id="form1" runat="server" method="post">
        <table   width="70%" id="table-2" align="center">
        <tr>
                <td align="center" colspan="2">
                  <b> Deccan Education Society's
Fergusson College(Autonomous), Pune
Admission Process, 2020 </b>
                </td>              
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <b>
                        <asp:Label ID="lblHeaderText1" runat="server" Text="Detailed Payment Receipt" /></b>
                </td>
                </tr>
            <tr>
                <td align="right" width="30%"><img alt="" height="27px" src="../../Resources/Barcode.aspx?ApplicationFormNo=<%=referenceNo%>" /></td>
                </tr>           
        </table>
        <table width="70%" id="table-2" align="center">
            <tr>
                <td align="right" width="25%">
                    <strong>  Aplication Form No. :</strong> 
                </td>
                <td>
                    <asp:Label ID="lblApplicationFormNo" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                   <strong>Applicant Name :</strong> 
                </td>
                <td>
                    <asp:Label ID="lblApplicantName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>                      
            <tr>
                <td align="right">
                     <strong> Mobile No. :</strong> 
                </td>
                <td>
                    <asp:Label ID="lblMobileNo" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                     <strong> ReferenceNo :</strong> 
                </td>
                <td>
                    <asp:Label ID="lblReferenceNo" runat="server" Text="grn"></asp:Label>
                </td>
            </tr> 
            <tr>
                <td align="right">
                     <strong> Transaction Amount :</strong> 
                </td>
                <td>
                    <asp:Label ID="lblAmount" runat="server" Text="grn"></asp:Label>
                </td>
            </tr> 
            <tr>
                <td align="right">
                     <strong> Payment Initiation Date :</strong> 
                </td>
                <td>
                    <asp:Label ID="lblCrDate" runat="server" Text="grn"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td align="right">
                     <strong> Payment Status :</strong> 
                </td>
                <td>
                    <asp:Label ID="lblPaidStatus" runat="server" Text="grn"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td align="right">
                     <strong> Mode Of Payment :</strong> 
                </td>
                <td>
                    <asp:Label ID="lblMode" runat="server" Text="grn"></asp:Label>
                </td>
            </tr>            
             <tr>
                <td align="left" colspan="2">
                   <strong> List of Courses :</strong>
                </td>
               
            </tr>
            <tr id="trCandidateList" runat="server">
                <td colspan="2">
                <asp:GridView Width="100%" ID="GVApplicantList"  runat="server" AutoGenerateColumns="False"
                        EnableModelValidation="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No. ">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle"  Width="2%" />
                                <ItemTemplate>
                                    <%# int.Parse(DataBinder.Eval(Container,"RowIndex").ToString()) +1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationFormNo" HeaderText="Application FormNo"  />
                            <%--<asp:BoundField DataField="AdvertismentName" HeaderText="Advertisement Number"/>--%>
                            <asp:BoundField DataField="PostName" HeaderText="Course Name"  />
                            <asp:BoundField DataField="Fees" HeaderText="Fees" ItemStyle-HorizontalAlign="Center" />  
                            <asp:BoundField DataField="PaidStatus" HeaderText="Payment Status" ItemStyle-HorizontalAlign="Center" />                           
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        </form>
    </div>   
</html>