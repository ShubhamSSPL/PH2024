<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="EditHomePage.aspx.cs" Inherits="StaticPages_HomePage" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <link href="../SynthesysModules_Files/inettuts/inettuts.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function ClearCookie() {
            document.getElementById('rightContainer_ContentTable1_HdnCookie').value = '';
        }
    </script>

    <ccm:ContentBox ID="ContentTable1" runat="server" BorderColor="White" HorizontalAlign="Left"
        HeaderText="" HeaderVisible="false" BorderStyle="Dotted" BorderWidth="0" Collapsed="true"
        Style="margin-top: 0px;">
        <table id="tblmaincontent" border="0" cellpadding="0" cellspacing="0" style="margin-top: 0px;">
            <tr>
                <td valign="top">
                    <!--middle content start-->
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="450px" height="80px" valign="top">
                                <img src="../SynthesysModules_Files/Images/Website_CenterImage.jpeg" alt="Web Site" />
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="1" cellspacing="2" style="margin-left: 4px;">
                        <tr>
                            <td style="border-bottom: 1px dotted #919191; border-top: 1px dotted #919191;">
                                <b>
                                    <asp:Label ID="LblPanel1" runat="server" Text="Label"></asp:Label></b></td>
                            <td width="445px" height="25px" valign="middle" style="border-bottom: 1px dotted #919191; border-top: 1px dotted #919191;">
                                <marquee id="panel1marquee" runat="server" align="justify" direction="left" onmouseout="this.start()"
                                    onmouseover="this.stop()" style="padding: 1px; font-family: verdana; font-size: 11px; padding-left: 5px; color: #03585b; border-bottom: 1px"
                                    scrollamount="1" scrolldelay="30"></marquee>
                            </td>
                        </tr>
                    </table>
                    <center>
                        <asp:Button ID="BtnReset" runat="server" Text="Reset Interface" OnClientClick="ClearCookie()"
                            CssClass="InputButton" />
                        <asp:Button ID="BtnSaveData" runat="server" Text="Save Panels order" OnClick="BtnSaveData_Click"
                            CssClass="InputButton" />
                    </center>
                    <%--<a href="HomePageMovable_dbtrial.aspx" onclick="deletecook();">Reset interface</a>--%>
                    <div id="columns">
                        <ul id="column1" class="column">
                            <li class="widget color-red" id="intro">
                                <div class="widget-head">
                                    <h6>
                                        <asp:Label ID="LblPanel2" runat="server" Text="Label"></asp:Label></h6>
                                </div>
                                <div class="widget-content">
                                    <p>
                                        <br />
                                        <marquee align="justify" direction="up" onmouseout="this.start()" onmouseover="this.stop()"
                                            scrollamount="1" scrolldelay="60" style="padding-right: 1px; padding-left: 5px; background-attachment: fixed; padding-bottom: 1px; color: #6d6254; padding-top: 1px; background-repeat: no-repeat; height: 80px"> 
                                <table id="Panel2List" runat="server" >           
                                </table>
                                 <div class="more"><asp:HyperLink ID="HpLinkPanel2" CssClass="more" runat="server" Visible="false">More..</asp:HyperLink></div>                                                                                 
                                </marquee>
                                    </p>
                                </div>
                            </li>
                            <li class="widget color-red" id="widget2">
                                <div class="widget-head">
                                    <h6>
                                        <asp:Label ID="LblPanel4" runat="server" Text="Label"></asp:Label></h6>
                                </div>
                                <div class="widget-content">
                                    <p>
                                        <br />
                                        <table id="Panel4List" runat="server">
                                        </table>
                                        <div class="more">
                                            <asp:HyperLink ID="HpLinkPanel4" CssClass="more" runat="server" Visible="false">More..</asp:HyperLink>
                                        </div>
                                    </p>
                                </div>
                            </li>

                        </ul>
                        <ul id="column2" class="column">
                            <li class="widget color-red" id="widget3">
                                <div class="widget-head">
                                    <h6>
                                        <asp:Label ID="LblPanel3" runat="server" Text="Label"></asp:Label></h6>
                                </div>
                                <div class="widget-content">
                                    <p>
                                        <br />
                                        <table id="Panel3List" runat="server">
                                        </table>
                                        <div class="more">
                                            <asp:HyperLink ID="HpLinkPanel3" runat="server" Visible="false">More..</asp:HyperLink>
                                        </div>
                                    </p>
                                </div>
                            </li>
                            <li class="widget color-red" id="widget4">
                                <div class="widget-head">
                                    <h6>
                                        <asp:Label ID="LblPanel5" runat="server" Text="Label"></asp:Label></h6>
                                </div>
                                <div class="widget-content">
                                    <p>
                                        <br />
                                        <table id="Panel5List" runat="server">
                                        </table>
                                        <div class="more">
                                            <asp:HyperLink ID="HpLinkPanel5" runat="server" Visible="false">More..</asp:HyperLink>
                                        </div>
                                    </p>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <%--<table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="middle" align="left" class="middlebox1">
                                <div>
                                    <asp:Label ID="LblPanel2" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                          <td style="width:5px;">
                            </td>
                            <td valign="middle" align="left" valign="middle" class="middlebox1">
                                <div><asp:Label ID="LblPanel3" runat="server" Text="Label"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="middlebox2" valign="top">
                                <br />
                                <marquee align="justify" direction="up" onmouseout="this.start()" onmouseover="this.stop()"
                                    scrollamount="1" scrolldelay="60" style="padding-right: 1px; padding-left: 5px;
                                    background-attachment: fixed; padding-bottom: 1px; color: #6d6254; padding-top: 1px;
                                    background-repeat: no-repeat; height: 80px"> 
                                <table id="Panel2List" runat="server" >           
                                </table>
                                 <div class="more"><asp:HyperLink ID="HpLinkPanel2" CssClass="more" runat="server" Visible="false">More..</asp:HyperLink></div>                                                                                 
                                </marquee>
                            </td>
                            <td style="width:5px;">
                            </td>
                            <td class="middlebox2" valign="top">
                                <br />
                                <table id="Panel3List" runat="server">
                                </table>
                                <div class="more">
                                    <asp:HyperLink ID="HpLinkPanel3" runat="server" Visible="false">More..</asp:HyperLink>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td valign="middle" class="middlebox1">
                                <div><asp:Label ID="LblPanel4" runat="server" Text="Label"></asp:Label></div>
                            </td>
                           <td style="width:5px;">
                            </td>
                            <td valign="middle" class="middlebox1">
                                <div><asp:Label ID="LblPanel5" runat="server" Text="Label"></asp:Label></div>
                            </td>
                        </tr>
                        <tr style="height: 100px">
                            <td class="middlebox2" valign="top">
                                <br />
                                <table id="Panel4List" runat="server">
                                </table>
                                <div class="more"><asp:HyperLink ID="HpLinkPanel4" CssClass="more" runat="server" Visible="false">More..</asp:HyperLink></div>
                            </td>
                            <td style="width:5px;">
                            </td>
                            <td class="middlebox2" valign="top">
                                <br />
                                <table id="Panel5List" runat="server">
                                </table>
                                <div class="more"><asp:HyperLink ID="HpLinkPanel5" runat="server" Visible="false">More..</asp:HyperLink></div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="5px">
                            </td>
                        </tr>
                    </table>--%>
                </td>
                <!--middle content end-->
                <!--right content start  -->
                <td style="width: 8px">&nbsp;</td>
                <td valign="top" align="center" style="width: 170px">
                    <ccm:ContentBox runat="server" ID="CBLogIn" HeaderText="Log In" Height="130px" Width="170px">
                        <center>
                            <table id="tbllogin" runat="server" style="margin-top: 0px;">
                            </table>
                        </center>
                    </ccm:ContentBox>
                    <table id="Panel6List" runat="server" visible="false">
                        <tr>
                            <td class="loginbtn">
                                <%--<a id="btnPanel6" runat="server"></a>--%>
                                <asp:Button ID="btnPanel6" runat="server" Text="Button" Width="170px" CssClass="InputButton" />
                            </td>
                        </tr>
                    </table>
                    <table id="tblrightmenu1" style="border: 1px dotted #4a8f7d; margin-top: 5px; margin-left: 1px;"
                        width="170px">
                        <tr>
                            <td style="width: 170px; height: 100px;">
                                <div class="slideshow">
                                    <a href="http://elearning.Synthesys.org/">
                                        <img src="../SynthesysModules_Files/AddImages/p1.jpg" width="170" height="100" /></a>
                                    <a href="http://Synthesys.Synthesys.org/">
                                        <img src="../SynthesysModules_Files/AddImages/p2.jpg" width="170" height="100" /></a>
                                    <a href="http://eduegov.Synthesys.org/">
                                        <img src="../SynthesysModules_Files/AddImages/p4.jpg" width="170" height="100" /></a>
                                    <a href="http://elearning.Synthesys.org/">
                                        <img src="../SynthesysModules_Files/AddImages/p5.jpg" width="170" height="100" /></a>
                                    <a href="http://eduegov.Synthesys.org/">
                                        <img src="../SynthesysModules_Files/AddImages/p3.jpg" width="170" height="100" /></a>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 170px; height: 70px;">
                                <div style="height: 100%; width: 100%">
                                    <a href="http://easy.Synthesys.org/registration/" target="_blank">
                                        <img src="../SynthesysModules_Files/Images/easy_web.jpg" style="width: 100%; height: 100%" /></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <!--right content end-->
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="HdnCookie" runat="server" />
        <asp:HiddenField ID="hddImportantDates" runat="server" />

        <script type="text/javascript">
            var hddFlag = document.getElementById('<%=hddImportantDates.ClientID %>').value;

        </script>

    </ccm:ContentBox>

    <script type="text/javascript" src="../SynthesysModules_Files/inettuts/jquery-1.2.6.min.js"></script>

    <script type="text/javascript">
        $('<style type="text/css">.column{visibility:hidden;}</style>').appendTo('head');
        //$('body').css({background: '#000 url(img/load.gif) no-repeat center'})
    </script>

    <script type="text/javascript" src="../SynthesysModules_Files/inettuts/jquery-ui-personalized-1.6rc2.min.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/inettuts/cookie.jquery.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/inettuts/inettuts_save.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/inettuts/delete-cookie.js"></script>

    <link rel="stylesheet" type="text/css" href="../SynthesysModules_Files/Style/jquery-frontier-cal-1.3.2.css" />
    <link rel="stylesheet" type="text/css" href="../SynthesysModules_Files/Style/colorpicker.css" />
    <link rel="stylesheet" type="text/css" href="../SynthesysModules_Files/Style/jquery-ui-1.8.1.custom.css" />
    <%--<script type="text/javascript" src="../SynthesysModules_Files/Scripts/Jquery_image.js"></script>--%>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/FuncLib.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/AjaxLoader.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/jquery-1.4.2-ie-fix.min.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/jquery-ui-1.8.1.custom.min.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/jshashtable-2.1.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/SmallCalender.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/colorpicker.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/jquery.qtip-1.0.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/PageScripts/SmallCalendarPage.js"></script>

    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/ImageRotator.js"></script>

    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('.slideshow').cycle({
                fx: 'zoom',
                delay: -9000
            });
        });

        var atk, whatTitle;
        var eventId;
        var stDT, endDT;
    </script>

    <style type="text/css" media="screen">
        body {
            font-size: 62.5%;
        }

        .shadow {
            -moz-box-shadow: 3px 3px 4px #aaaaaa;
            -webkit-box-shadow: 3px 3px 4px #aaaaaa;
            box-shadow: 3px 3px 4px #aaaaaa;
            /* For IE 8 */
            -ms-filter: "progid:DXImageTransform.Microsoft.Shadow(Strength=4, Direction=135, Color='#aaaaaa')";
            /* For IE 5.5 - 7 */
            filter: progid:DXImageTransform.Microsoft.Shadow(Strength=4, Direction=135, Color='#aaaaaa');
        }
    </style>
</asp:Content>
