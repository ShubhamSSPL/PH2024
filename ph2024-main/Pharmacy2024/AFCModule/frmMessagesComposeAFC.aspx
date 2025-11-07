<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/DynamicMasterPageSB.master" CodeBehind="frmMessagesComposeAFC.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmMessagesComposeAFC" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <style>
        * {
            margin: 0;
        }
        html, body {
            height: 100%;
        }
        #rightContainer_ContentTable2_contentFileTest {
            width: 700px;
        }
        .wrapper {
            width: 700px;
            background-color: gray;
        }
        .push {
            height: 50px;
        }
        .tbl {
            display: table;
            width: 100%;
            /*            background-color: #c4a000;*/
            /*  background-color: #d6deeb85;*/
            background-color: #04a2b3
        }
        .full {
            width: 100%
        }
        .c20 {
            display: table-cell;
            padding: 15px;
            width: 20%;
            text-align: center;
        }
        .c50 {
            display: table-cell;
            padding: 15px;
            width: 50%;
            text-align: center;
        }
        button {
            border: 0px;
            width: 100%;
            min-height: 35px;
            cursor: pointer;
        }
        /*.left-area {
            width: 18%;
        }*/
        .msgtable {
            display: flex;
            font-size: 16px;
            margin: 20px 0px;
            width: 100% !important;
        }
        .msgtbLeft {
            width: 15% !important;
            text-align: right;
        }
        .msgtbRight {
            width: 100%;
            margin-left: 20px;
        }
        #divBaseCanvas {
            height: 400px !important;
        }
        div.dd_chk_select {
            height: none;
            padding: 7px;
        }
        div.dd_chk_drop {
            top: 28px;
        }
        .gvsubject {
            padding: 7px;
            border: 1px solid #CCCCCC;
        }
        .btnUplodHide{
            display:none !important;
        }
    </style>
    <script lang="javascript" type = "text/javascript">
        window.history.forward(1);
        function MessageChanged() {
            if (document.getElementById('rightContainer_ContentTable2_txtMsg').value.length > 1000) {
                document.getElementById('rightContainer_ContentTable2_txtMsg').value = document.getElementById('rightContainer_ContentTable2_txtMsg').value.substring(0, 1000);
            }
            document.getElementById('countCharacters').innerHTML = document.getElementById('rightContainer_ContentTable2_txtMsg').value.length;
        }
    </script>
    <script src="../Scripts/mcfCrop.js"></script>
    <script>
        $(document).ready(function () {
            initContainer("cropContainer", 80, 1000, 800, "../Images/", 500, cb);
            function cb(data, fileName, fileExt) {
                //console.log(data);
                // alert(fileName + "." + fileExt);
                if (data.length > 0) {
                    $('#imgCropped').val(data);
                }
                else {
                    alert("Please Select File");
                }
            }

        })
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class = "AppFormTableWithOutBorder">
            <tr align = "center">
                <td><a href="../AFCModule/frmMessagesNonRepliedAFC.aspx"><font size = "2"><b>| Non Replied Messages |</b></font></a></td>
                <td><a href="../AFCModule/frmMessagesRepliedAFC.aspx"><font size = "2"><b>| Replied Messages |</b></font></a></td>
                <td><a href="../AFCModule/frmMessagesComposeAFC.aspx"><font size = "2" color = "red"><b>| Compose Message |</b></font></a></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Compose Message">
        <font color = "red">
            <ol class="list-text"><b>Note :</b>
                <li>If you have already sent a message and that is not replied by ADMIN, then please don't send message again for same purpose. If you want to send something is same case, then edit your Non-Replied Message and send.</li>
            </ol>
        </font>
        <br />
        <div class="table-responsive" style="padding: 0px 20px;">
            <div class="msgtable">
                <div class="msgtbLeft">To :</div>
                <div class="msgtbRight"><asp:TextBox ID="txtTo" runat="server" ReadOnly="True">ADMIN</asp:TextBox></div>
            </div>
            <div class="msgtable">
                <div class="msgtbLeft">Subject :</div>
                <div class="msgtbRight">
                    <asp:TextBox ID="txtSubject" runat="server" MaxLength = "100" Width = "90%" CssClass="gvsubject"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject" ErrorMessage="Please Enter subject." Display = "none"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="msgtable">
                <div class="msgtbLeft">Attachment 1 :</div>
                <div class="msgtbRight">
                    <input id="fileInput1" type="file" runat="server" style="height: 100%; display: none;" class="width-password"/> (Only .JPG, .JPEG, .PDF Formats Supported)
                    <br />
                    <asp:Image ID="btnUpload" runat="server" AlternateText="Upload" ImageUrl="~/Images/btn_chooseFile.jpg" onclick="return OpenTestPopup(this);" Style="cursor: pointer; color: #757575; height: 30px;" ToolTip="Click here to Upload attachement." />
                    <div id="contentFileTest" runat="server" style="display: none;">
                        <table class="AppFormTable">
                            <tr>
                                <th style="width: 25%;" align="right"></th>
                                <th style="width: 70%;" align="left">
                                    <b>
                                        <label id="lbldoumentuplodName"></label>
                                    </b>
                                </th>
                                <th align="center">
                                    <button type="button" onclick="closeUpload()" style="width: 30px;" title="Close">
                                        <img src="../Images/ContentBox_close.gif"></button>
                                </th>
                            </tr>
                        </table>

                        <input type="hidden" name="imgCropped" id="imgCropped" />
                        <div id="cropContainer" class="wrapper"></div>
                    </div>
                </div>
            </div>
            <div style="display:none">
                <div align = "right">Attachment 2</div>
                <div><input id="fileInput2" type="file" runat="server" /> (Only .JPG, .JPEG, .PDF Formats Supported)</div>
            </div>
            <div class="msgtable">
                <div class="msgtbLeft">Message :</div>
                <div class="msgtbRight">
                    <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Width="90%" Height="150" MaxLength = "1000" onkeyup="MessageChanged()"></asp:TextBox>
                    <br />
                    (<span id="countCharacters">0</span> / 1000 characters filled)
                    <asp:RequiredFieldValidator ID="rfvMsg" runat="server" ControlToValidate="txtMsg" ErrorMessage="Please Enter Message." Display = "none"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div>
                <div align="center">
                    <asp:Button ID="btnSend" runat="server" Text="Send Message" CssClass="InputButton" OnClick="btnSend_Click" OnClientClick="saveImage(80)" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </div>
            </div>
        </div>
    </cc1:ContentBox>
     <script type="text/javascript">
         function closeUpload() {
             document.getElementById('<%=contentFileTest.ClientID %>').style.display = "none";
            document.getElementById('<%=btnUpload.ClientID %>').style.display = "block";
         }
         function OpenTestPopup(cntrl) {

             document.getElementById('<%=contentFileTest.ClientID %>').style.display = "block";
            document.getElementById('<%=contentFileTest.ClientID %>').setAttribute("tabindex", 1);
            document.getElementById('<%=contentFileTest.ClientID %>').focus();
            document.getElementById('<%=btnUpload.ClientID %>').style.display = "none";

         }
     </script>
</asp:Content>


