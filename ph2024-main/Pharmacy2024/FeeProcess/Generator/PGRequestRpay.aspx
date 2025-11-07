<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PGRequestRpay.aspx.cs" Inherits="Pharmacy2024.FeeProcess.Generator.PGRequestRpay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
    <style type="text/css">
        .style2
        {
            color: #006600;
            font-size: medium;
        }
    </style>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p align="center" class="style2">
            <strong>You are being redirected to Payment Gateway. Please be paitent....</strong></p>
        <br />
        <br />
        <p align="center" class="style2">
            <strong>Do not press back or refresh button....</strong></p>
        <br />
        <br />
        <br />
        <table width="100%" align="center">
            <tr>
                <td valign="middle" align="center">
                    <img src="../Images/Processing1.gif" alt="Processing. Please wait..." />
                </td>
            </tr>
        </table>
    </div>
    <input type="hidden" runat="server" id="key" name="key" />
    <input type="hidden" runat="server" id="hash" name="hash" />
    <input type="hidden" runat="server" id="txnid" name="txnid" />
    <input type="hidden" runat="server" id="enforce_paymethod" name="enforce_paymethod" />
    </form>
    <input type="hidden" runat="server" id="orderID" name="orderID" />
    <input type="hidden" runat="server" id="payamount" name="payamount" />
    <input type="hidden" runat="server" id="nameofpayment" name="nameofpayment" />
    <input type="hidden" runat="server" id="purpose" name="purpose" />
    <input type="hidden" runat="server" id="prefilname" name="prefilname" />
    <input type="hidden" runat="server" id="prefilemail" name="prefilemail" />
    <input type="hidden" runat="server" id="prefilmobile" name="prefilmobile" />
    <input type="hidden" runat="server" id="referenceNo" name="referenceNo" />
    <input type="hidden" runat="server" id="pid" name="pid" />
<input type="hidden" runat="server" id="rzkey" name="rzkey" />
</body>
 
<script type="text/javascript">
    $(document).ready(function () {
        var amount = document.getElementById('payamount').value;
        var nameofpayment = document.getElementById('nameofpayment').value;
        var purpose = document.getElementById('purpose').value;
        var prefilname = document.getElementById('prefilname').value;
        var prefileemail = document.getElementById('prefilemail').value;
        var prefilmobile = document.getElementById('prefilmobile').value;
        var referenceNo = document.getElementById('referenceNo').value;
        var PID = document.getElementById('pid').value;
        var orderID = document.getElementById('orderID').value;
        var rzkey = document.getElementById('rzkey').value;
        var options = {
            "key": rzkey,
            "amount": amount,
            "name": "MHTCET CELL, Mumbai",
            "order_id": orderID,
            "description": purpose,
            "image": "https://ph2020.mahacet.org/Images/WebsiteLogo.png",
            //"callback_url": "./Response/charge.aspx",
            "handler": function (response) {
                //  alert(response.razorpay_payment_id);
                var paymentid = response.razorpay_payment_id;
                var order_id = response.razorpay_order_id;
                var signature = response.razorpay_signature;
                if (paymentid != "" && order_id != "" && signature != "")
                    window.location = '../Response/charge.aspx?razorpay_payment_id=' + paymentid + '&razorpay_order_id=' + order_id + '&razorpay_signature=' + signature + '&paidamount=' + amount + '&refno=' + referenceNo;
                else
                    window.location = '../PaymentDetails.aspx'
            },
            "prefill": {
                "name": prefilname,
                "email": prefileemail,
                "contact": prefilmobile

            },
            "notes": {
                "referenceNo": referenceNo,
                "pid": PID,
                "feefor": purpose
            },
            /**
            * You can track the modal lifecycle by adding the below code in your options
            */
            "modal": {
                "ondismiss": function () {
                    window.location = '../PaymentDetails.aspx'
                }
            }
        };
        var rzp1 = new Razorpay(options);
        if (parseInt(amount) > 99) {
            rzp1.open();
        }
    });
</script>
</html>