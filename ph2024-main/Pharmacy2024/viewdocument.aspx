<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewdocument.aspx.cs" Inherits="Pharmacy2024.viewdocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    <div style="width:100%; text-align:center">
    <div id="divFrame" runat="server" visible="false">
    <iframe src="https://docs.google.com/gview?url=<%=Request["fn"] %>&embedded=true" style="width:718px; height:700px;" frameborder="0"></iframe>
    </div>
    <asp:Image runat="server" ID="imgFile" Visible="false" />
    </div>
    </form>
</body>
</html>
