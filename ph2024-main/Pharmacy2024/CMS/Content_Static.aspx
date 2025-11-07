<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="Content_Static.aspx.cs" Inherits="ContentManagement_Content_Static" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">

    <script type="text/javascript">

        function PrintPage() {

            var table = document.getElementById("<%=InnerContent.ClientID %>");

            var header = '<table  style="border-collapse:collapse;width:100%"><tr><td style="font-size:18px; font-weight:bold; font-family:vardana; border-bottom:1px solid #cecece;"><br/><br/>' + document.getElementById("rightContainer_cbxContent_tdllblContentTitle").innerHTML + '<br/><br/></td><td style="font-size:14px; font-weight:normal;text-align:right; font-family:vardana; border-bottom:1px solid #cecece;">' + document.getElementById("rightContainer_cbxContent_lblUpdationDate").innerHTML + '<br/><br/></td></tr></table>';
            var data = table.innerHTML;

            var WinPrint =
                window.open('', '', 'left=0,top=0,width=800%,height=500%,toolbar=0,scrollbars=1,status=0');
            var htmlContent = '<html><head><link href="../SynthesysModules_Files/Style/MainStyle.css" type="text/css" rel="stylesheet" /></head><body style="font-size:14px; font-family:vardana;">' + header + '' + data + '</body> </html>'
            WinPrint.document.write(htmlContent);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();

        }
        function ChangeLabelContentTitle() {
            var str = document.getElementById('rightContainer_cbxContent_tdllblContentTitle').innerHTML.split(">");
            if (str.length > 1) {
                var str1 = str[1].split("<");
                document.getElementById('rightContainer_cbxContent_tdllblContentTitle').innerHTML = '<span style="font-family:Arial Unicode MS; font-size:25px; font-weight:bold;">' + str1[0] + '</span>';
            }
            else
                document.getElementById('rightContainer_cbxContent_tdllblContentTitle').innerHTML = str[0];
        }
        Synthesys.FuncLib.AddLoadEvent(ChangeLabelContentTitle);
    </script>

    <ccm:ContentBox ID="cbxContent" runat="server" HorizontalAlign="Left" HeaderText=""
        HeaderVisible="false" Collapsed="true">
        <table class="Appformtable" style="width: 100%" border="0">
            <tr align="right">
                <td colspan="2">
                    <input id="Button1" type="button" value="Print" class="InputButton" onclick="PrintPage()" />
                </td>
            </tr>
            <tr>
                <td id="tdllblContentTitle" style="width: 75%; vertical-align: bottom; text-align: left; font-weight: bold; font-family: @Arial Unicode MS; font-size: 25px; color: Maroon"
                    align="left"
                    valign="baseline" class="llblContentTitle" runat="server"></td>
                <td style="width: 25%" align="right">
                    <ul style="width: 100%; height: 30px; list-style-type: none; margin: 0px; padding: 0px;">
                        <li style="margin: 0px; padding: 0px;">
                            <asp:Label ID="lblUpdationDate" runat="server" ForeColor="Maroon" Font-Bold="false"
                                Font-Names="verdana" Font-Size="10px"></asp:Label>
                        </li>
                    </ul>
                </td>
            </tr>
        </table>
        <hr style="height: 1px;" />
        <div id="Content" style="padding: 15px; width: 650px; overflow: hidden">
            <p>
                <asp:Label ID="InnerContent" EnableViewState="false" runat="server"></asp:Label>
            </p>
        </div>
    </ccm:ContentBox>
</asp:Content>
