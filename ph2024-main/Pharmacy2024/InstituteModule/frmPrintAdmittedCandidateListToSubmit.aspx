<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrintAdmittedCandidateListToSubmit.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmPrintAdmittedCandidateListToSubmit" %>

<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
        <link rel="stylesheet" href="../Styles/Style.css" type="text/css" />
        <style type="text/css" media="screen">
            .Header
            {
                text-align:center; font-weight:bold; font-family:Verdana; font-size:8px; background-color:#d8d8d8; color:#000000; vertical-align:top; border-top-width:1px; border-right-width:1px; border-bottom-width:1px; border-left-width:0px; border-style:solid; border-color:#c8c8c8;
            }
            .Footer
            {
                text-align:center; font-weight:bold; font-family:Verdana; font-size:8px; background-color:#d8d8d8; color:#000000; vertical-align:top; border-top-width:0px; border-right-width:1px; border-bottom-width:1px; border-left-width:0px; border-style:solid; border-color:#c8c8c8;
            }
            .InnerText
            {
                text-align:center; font-family:Verdana; font-size:8px; color:#000000; vertical-align:top; border-top-width:0px; border-right-width:1px; border-bottom-width:1px; border-left-width:0px; border-style:solid; border-color:#c8c8c8;
            }
        </style>
    </head>
    <body onload = "window.print();">
        <form id="form1" runat="server">
            <cc1:ShowMessage id="shInfo" runat="server"></cc1:ShowMessage>
            <asp:PlaceHolder ID="divCandidateReportHolder" runat="server" ></asp:PlaceHolder>
        </form>
    </body>
</html>