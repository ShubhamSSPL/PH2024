<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentModeSelection.aspx.cs" Inherits="Pharmacy2024.FeeProcess.PaymentModeSelection" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="content-type" content="text/html; charset=utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
        <link rel="stylesheet" type="text/css" href="CSS/template.css" />
        <script type="text/javascript" src="Scripts/jquery-1.11.1.min.js"></script>
        <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
        <script type="text/javascript" src="Scripts/custom.js"></script>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    </head>
    <body>
        <div class="holder">
            <cc2:ShowMessage ID="ShowMsg" runat="server"></cc2:ShowMessage>
        </div>
        <form id="Form1" runat="server">
            <div class="main">
                <main id="content">
                    <section id="main-content" class="col-md-9"></section> 
                    <div class="container">
    		            <div class="page-header">
                            <h2>Payment Mode Selection</h2>
                        </div>
    		            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 cart_details">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                	            <h4>Total Amount : <asp:Label  ID="lblCartAmount" runat="server" Font-Bold="true"/></h4>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right">
                                <a class="btn btn-highlight2 btn-md btn-success" id="popovercart" data-placement="bottom">
                                    <i class="fa fa-shopping-cart fa-2"></i>
                                    Course Applied : <asp:Label  ID="lblCartCount" runat="server" Font-Bold="true"/>
                                </a>
                                <div id="popovercartlist" runat="server"  style="display:none;"></div>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 bhoechie-tab-container">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 bhoechie-tab-menu">
                                <div id="divPayGroup" runat="server" class="list-group"></div>
                            </div>
                            <div id="divPayMode" runat="server" class="col-lg-9 col-md-9 col-sm-9 col-xs-9 bhoechie-tab"></div>
                        </div>
                        <div id="divSubmit" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 cart_details text-center">
                            <div style="margin-top:20px;">
                                <a href="#"data-toggle="modal" data-target="#terms" >Terms & Condition</a>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <p style="font-size:14px;"> 
                                        <asp:CheckBox ID="chAgree" Checked="false" runat="server" />
                                        I agree Terms & Condition
                                    </p> 
                                </label>
                            </div>
                            <asp:Button id="btnSubmit" runat="server" CssClass="btn btn-highlight2 btn-md btn-success proceed" Text="Proceed >>>" OnClientClick="return getpaymentMode();"  OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </main>
                <div class="modal fade modal-alt in" id="axis" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title text-center" id="myModalLabel">Instructions</h4>
                            </div>
                            <div class="modal-body" id="divInstruction"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade modal-alt in" id="terms" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title text-center" id="myModalLabel">Terms & Condition</h4>
                        </div>
                        <div class="modal-body" id="divTerms">
                            Please read these terms carefully before using the online payment facility. By using the online payment facility on this website you accept these terms. If you do not accept these terms do not use this facility.
                            <ol>
                                <li>Fee Once Paid is Not Refundable </li>
                            </ol>
                        </div>
                        <div class="modal-footer">
                            <p class="text-center"><button type="button" class="btn btn-primary" data-dismiss="modal">ok</button></p>
                        </div>
                    </div>
                </div>
            </div>
            <script>
                $(document).ready(function () {
                    $("div.bhoechie-tab-menu>div.list-group>a").click(function (e) {
                        e.preventDefault();
                        $(this).siblings('a.active').removeClass("active");
                        $(this).addClass("active");
                        var index = $(this).index();
                        $("div.bhoechie-tab>div.bhoechie-tab-content").removeClass("active");
                        $("div.bhoechie-tab>div.bhoechie-tab-content").eq(index).addClass("active");
                    });




                    $("input[type=radio]").on("click", function () {
                        $('#axis').modal();
                    });

                });


                function ShowDetails(PaymentMode, PayModeGroup) {

                    var str = new Array();
                    var arrMode = $("#<%=hdnModeInstruction.ClientID %>").val().split("|");

                    for (var i = 0; i < arrMode.length; i++) {
                        arrInstruction = arrMode[i].split("#");

                        if (arrInstruction[0] == PaymentMode) {
                            // $("#rightContainer_CBPaymentMode_lbl" + PayModeGroup).text("Instructions : " + arrInstruction[1]);
                            $("#divInstruction").html(arrInstruction[1]);
                            break;
                        }
                    }
                }


                function getpaymentMode() {
                    if ($("#<%=divPayMode.ClientID %> input:radio:checked").length == 0) {
                        alert("Please select pyment mode to proceed.")
                        return false;
                    }
                    else {
                        if ($("#<%=chAgree.ClientID %>").is(":checked")) {
                            var Mode = $("#<%=divPayMode.ClientID %> input:radio:checked")[0];

                            $("#<%=hdnPaymentMode.ClientID %>").val($(Mode).val());
                            // alert($("#<%=hdnPaymentMode.ClientID %>").val());
                            $("#<%=hdnModeInstruction.ClientID %>").val(''); 
                            return confirm("Do you want to proceed with current payment selection ?\n you will be redirected to Payment Gateway for payment.");
                        }
                        else {
                            alert("Please accept terms & conditions to proceed.");
                            return false;
                        }
                    }
                }


            </script>
            <script>
                $(function () {

                    // Enabling Popover Example 1 - HTML (content and title from html tags of element)
                    $("[data-toggle=popover]").popover('toggle');

                    // Enabling Popover Example 2 - JS (hidden content and title capturing)
                    $("#popovercart").popover({
                        html: true,
                        content: function () {
                            return $('#popovercartlist').html();
                        }
                    });

                });
            </script>
            <asp:HiddenField ID="hdnModeInstruction" runat="server" Value="" />
            <asp:HiddenField ID="hdnPaymentMode" runat="server" Value="" />
        </form>
    </body>
</html>
