<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VirtualKeyBoard.aspx.cs" Inherits="AppForm_VirtualKeyBoard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <%--<link href="../Styles/MainStyle.css" type="text/css" rel="stylesheet" />--%>

    <script type="text/javascript" src="http://www.google.com/jsapi?key=ABQIAAAADDiu_6wbtPKUdTwvo5PUXxRstwrbG3HBruZLE3SUNqFG39q3WhQoZBRJCPcWhvtzECvuVf2jkIj2Hw"></script>

    <script type="text/javascript">
        //object of keyBoard 
        var kbd;

        //loads package for KeyBoard.
        google.load("elements", "1", { packages: "keyboard" });

        function KBLoad() {

            //Destination Language Required for KeyBoard if hidden Field Value is Different then please change the ID here

            var destinationlang = window.parent.document.getElementById('<%=Request.QueryString["hdn"].ToString()%>').value;

            kbd = new google.elements.keyboard.Keyboard([destinationlang], ['txtUnicode']);

        }
        //function Required After the load if it is Different then Change the function.
        google.setOnLoadCallback(KBLoad);

        function Submit() {
            // Original Language textbox where text is going to get copied if it is different then change the ID.
            window.parent.document.getElementById('<%=Request.QueryString["txt"].ToString()%>').value += document.getElementById("txtUnicode").value;
       document.getElementById("txtUnicode").value = "";

       //pop up contentbox which contains the iFrame for keyBoard page  if its different then change the ID.
       window.parent.document.getElementById('<%=Request.QueryString["cb"].ToString()%>').Hide();
        }


    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>To See the Keys in Native Language Please click on Alt+Ctrl and to insert Special
                        character click on<img alt="special Character key" src="../SynthesysModules_Files/Images/KBKey.JPG" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtUnicode" class="textInput" runat="server"></asp:TextBox>
                        <input type="button" id="btnOK" class="InputButton" value="OK" onclick="Submit()" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
