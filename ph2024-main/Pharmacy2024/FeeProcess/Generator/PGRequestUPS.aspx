<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PGRequestUPS.aspx.cs" Inherits="Pharmacy2024.FeeProcess.Generator.PGRequestUPS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>  
        <script type="text/javascript">
            $(document).ready(function () {
                $("#nonseamless").submit();
            });
        </script>
        <style type="text/css">
            .style2
            {
                color: #006600;
                font-size: medium;
            }
        </style>
    </head>

<body>
<form id="nonseamless" method="post" name="redirect" action=" https://secure.ccavenue.com/transaction/transaction.do?command=initiateTransaction"> 
    <input type="hidden" id="encRequest" name="encRequest" value="<%=strEncRequest%>"/>
    <input type="hidden" name="access_code" id="Hidden1" value="<%=strAccessCode%>"/>
</form>
</body>

   <%--  PayU <body>
        <form id="form1" runat="server">
            <div>
                <p align="center" class="style2"><strong>You are being redirected to Payment Gateway. Please be paitent....</strong></p>
                <br />
                <br />
                <p align="center" class="style2"> <strong>Do not press back or refresh button....</strong></p>
                <br />
                <br />
                <br />
                <table width="100%" align="center">
                    <tr>
                        <td valign="middle" align="center"><img src="../Images/Processing1.gif" alt="Processing. Please wait..." /> </td>
                    </tr>
                </table>
            </div>
            <input type="hidden" runat="server" id="key" name="key" />
      <input type="hidden" runat="server" id="hash" name="hash"  />
            <input type="hidden" runat="server" id="txnid" name="txnid" />
             <input type="hidden" runat="server" id="enforce_paymethod" name="enforce_paymethod" />
        </form>
    </body>--%>
</html>