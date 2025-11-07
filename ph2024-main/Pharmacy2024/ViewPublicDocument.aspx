<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPublicDocument.aspx.cs" Inherits="Pharmacy2024.ViewPublicDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<style>
    embed {
        height: 100%;
        width: 100%;
    }
</style>


<body>
    <form id="form1" runat="server">
        <div id="divLoadDocument" runat="server">
            <%--<img id="imgFullWindow" class="full-window-img" runat="server" />--%>
        </div>

        <script type="text/javascript">
            function b64toBlob(b64Data, contentType, sliceSize) {
                contentType = contentType || '';
                sliceSize = sliceSize || 512;

                var byteCharacters = atob(b64Data);
                var byteArrays = [];

                for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
                    var slice = byteCharacters.slice(offset, offset + sliceSize);

                    var byteNumbers = new Array(slice.length);
                    for (var i = 0; i < slice.length; i++) {
                        byteNumbers[i] = slice.charCodeAt(i);
                    }

                    var byteArray = new Uint8Array(byteNumbers);

                    byteArrays.push(byteArray);
                }

                var blob = new Blob(byteArrays, { type: contentType });
                return blob;
            }

            function LoadPublicDocument(b64Data) {
                var contentType = 'application/pdf';
                var blob = b64toBlob(b64Data, contentType);
                var blobUrl = URL.createObjectURL(blob);

                document.getElementById('<%=divLoadDocument.ClientID %>').innerHTML = '<embed src="' + blobUrl + '#toolbar=0" autostart="true" style="width:100%;height:750px;">';
            }


           </script>
    </form>


</body>
</html>
