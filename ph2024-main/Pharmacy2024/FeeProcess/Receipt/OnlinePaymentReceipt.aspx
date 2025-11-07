<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlinePaymentReceipt.aspx.cs" Inherits="Pharmacy2024.FeeProcess.Receipt.OnlinePaymentReceipt" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
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
                border: 1px solid #fff;
            }
        </style>
    </head>
    <body onload="window.print();">
        <form id="form1" runat="server" method="post">
            <table width="90%" id="table-2" align="center">
                <tr>
                    <td align="center">
                        <b>
                              <font size="4">S</font><font size="2">TATE</font> <font size="4">C</font><font size="2">OMMON</font> <font size="4">E</font><font size="2">NTRANCE</font> <font size="4">T</font><font size="2">EST</font> <font size="4">C</font><font size="2">ELL,</font> <font size="4">M</font><font size="2">AHARASHTRA</font> <font size="4">S</font><font size="2">TATE</font>
                        <br />
                        <font size = "1">8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</font>
                            <br /><br />
                            <font size = "3">Detailed Payment Receipt</font>
                        </b>
                    </td>
                </tr>
            </table>
            <table width="90%" id="table-2" align="center">
                <tr>
                    <td width="35%" align="right">Payee&nbsp; Id</td>
                    <td width="65%"><asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">&nbsp;Name Of Payee</td>
                    <td><asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>                      
               <%-- <tr>
                    <td align="right">Mobile Number</td>
                    <td><asp:Label ID="lblMobileNo" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>--%>
                <tr>
                    <td align="right">Reference Number</td>
                    <td><asp:Label ID="lblReferenceNo" runat="server" Font-Bold="true"></asp:Label></td>
                </tr> 
                <tr>
                    <td align="right">Transaction Amount</td>
                    <td><asp:Label ID="lblTransactionAmount" runat="server" Font-Bold="true"></asp:Label></td>
                </tr> 
                <tr>
                    <td align="right">Payment Initiation Date</td>
                    <td><asp:Label ID="lblPaymentInitiationDate" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>  
                <tr>
                    <td align="right">Payment Status</td>
                    <td><asp:Label ID="lblPaymentStatus" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>  
                <tr>
                    <td align="right">Mode Of Payment</td>
                    <td><asp:Label ID="lblPaymentMode" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>   
                <tr>
                    <td align="right">Purpose</td>
                    <td><asp:Label ID="lblPurpose" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>          
            </table>
        </form>
    </body> 
</html>
