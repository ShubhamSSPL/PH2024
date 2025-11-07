<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPages/DynamicMasterPageSB.master" CodeBehind="frmDocumentForApproval.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmDocumentForApproval" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script lang="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
     <style>
        .pdfobject-container {
            height: 30rem;
            border: 1rem solid rgba(0,0,0,.1);
        }

        .doc-container {
            height: 25rem;
            border: 1rem solid rgba(0,0,0,.1);
        }
        #rightContainer_contentViewDocument {
            top: 13% !important;
            width: 90% !important;
        }
    </style>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderVisible="false">
        <table class = "AppFormTableWithOutBorder">
            <tr align = "center">
                <td><a href="../AFCModule/frmDocumentForApproval.aspx"><font size = "2" color = "red"><b>| Documents for Approval |</b></font></a></td>
               <%-- <td><a href="../AFCModule/frmGrievancesApprovedAFC.aspx"><font size = "2"><b>| Approved Grievances |</b></font></a></td>
                <td><a href="../AFCModule/frmGrievancesRejectedAFC.aspx"><font size = "2"><b>| Rejected Grievances |</b></font></a></td> --%>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Documents for Approval">
        <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="gvMessages_RowCommand" OnRowDataBound ="gvMessages_RowDataBound" CssClass="DataGrid">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID" HtmlEncode = "false">
                    <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name">
                    <ItemStyle Width="20%" HorizontalAlign="Left" CssClass="Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="DocType" HeaderText="Document Type" HtmlEncode = "false">
                    <ItemStyle Width="8%" HorizontalAlign="Left" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" Wrap="true"/>
                </asp:BoundField>
                <asp:BoundField DataField="AllotmentStatus" HeaderText="Allotment Status">
                    <ItemStyle Width="8%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalCategory" HeaderText="Category">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>
                <asp:BoundField DataField="FinalAppliedForEWS" HeaderText="EWS Status">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" Wrap="true"/>
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:BoundField>

                
                <asp:TemplateField HeaderText="View">
                    <ItemTemplate>                                
                        <a href="#" target="_blank" id="hrefURL" runat="server"></a>
                        <img src="" id="imgDoc" Style="cursor: pointer; max-width: 40px" onclick="javascript:OpenViewDocumentPopUp(this)" runat="server" />
                        <asp:HiddenField ID="hidFURL" runat="server" Value="<%# Bind('FilePath') %>" />
                         <asp:HiddenField ID="hdnImgByteArray" runat="server" Value='<%# Bind("FilePath") %>' />                      
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Header" />
                </asp:TemplateField>

                <asp:TemplateField  HeaderText="Approval Status">
                    <ItemTemplate>
                        <asp:RadioButton ID="rbnYes" runat="server" Text = "&nbsp;Approve" GroupName = "YesNo" />
                        <asp:RadioButton ID="rbnNo" runat="server" Text = "&nbsp;Reject" GroupName = "YesNo" />
                    </ItemTemplate>  
                    <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid"  Font-Names="Verdana" CssClass="Item" Width = "15%" />
                    <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Header" />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText = "Remark">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRepliedMessage" runat="server" MaxLength = "200" Height="50" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="20%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                </asp:TemplateField>

                <asp:ButtonField HeaderText = "Reply" ButtonType = "Button" CommandName = "Reply" Text = "Reply" ControlStyle-CssClass = "InputButton">
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle Font-Bold="True" />
                </asp:ButtonField> 
                <asp:TemplateField Visible = "false">
                    <ItemTemplate>
                        <%--<asp:Label ID="lblFrom" runat="server" Text='<%# Eval("From") %>'></asp:Label>--%>
                        <asp:Label ID="lblDocumentID" runat="server" Text='<%# Eval("DocumentID") %>'></asp:Label>
                        <asp:Label ID="lblPersonalID" runat="server" Text='<%# Eval("PersonalID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table runat = "server" id = "tblMsg" visible="false" class = "AppFormTable">
            <tr>
                <th height = "100" align="center" valign = "middle">
                    <asp:Label ID="lbl_frmSentMessages_Messages" runat="server" Text="There is no Document in your Non-Replied Documents" Font-Bold="True" Font-Size="Small"></asp:Label>
                </th>
            </tr>
        </table>
    </cc1:ContentBox> 
 <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%" Height="500px">
            <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr>
                <td>
                    <div class="modal-body" style="height: 450px;">
                        <div runat="server" id="divButtonPopup">
                            <table class="AppFormTableWithOutBorder" style="width: 5%; height: 15px;">
                                <tr>
                                    <td>
                                        <button type="button" onclick="zoominPopUp()">
                                            <img src="../Images/zoom-in.png" width="15px" height="15px"></button></td>
                                    <td>
                                        <button type="button" onclick="zoomoutPopUp()">
                                            <img src="../Images/zoom-out.png" width="15px" height="15px">
                                        </button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divDocument" class="doc-container"></div>
                    </div>
                </td>
            </tr>
        </table>
    </cc1:ContentBox> 
    <div class="modal"></div>

    <script type="text/javascript">

        function zoominPopUp() {
            var GFG = document.getElementById('<%=imgPopUpDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth + 100) + "px";
        }

        function zoomoutPopUp() {
            var GFG = document.getElementById('<%=imgPopUpDoc.ClientID %>');
            var currWidth = GFG.clientWidth;
            GFG.style.width = (currWidth - 100) + "px";
        }

        <%--function OpenViewDocumentPopUp(filePathFromDB) {

            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            //var corrRow = cntrl.parentNode.parentNode;
            var filePath = filePathFromDB;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            //corrRow.cells[corrRow.cells.length - 5].innerText

            document.getElementById('lblDocumentName').innerHTML = 'Attachment'; //corrRow.cells[corrRow.cells.length - 5].innerText;

            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + filePath + '">';
                    document.getElementById('divDocument').style.overflow = "scroll";
                    break;
                case 'zip':
                case 'rar':
                    document.getElementById('divDocument').innerHTML = '<iframe src="' + filePath + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                    document.getElementById('divDocument').innerHTML = '<embed src="' + filePath + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                    break;
                default:
                    alert("File type not supported");
            }
        }--%>

        function OpenViewDocumentPopUp(cntrl) {

            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
             document.getElementById('divDocument').innerHTML = '';
             document.getElementById('lblDocumentName').innerHTML = '';
             var corrRow = cntrl.parentNode.parentNode;
             var filePath = corrRow.cells[corrRow.cells.length - 4].getElementsByTagName("input")[0].value;
             var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
             //corrRow.cells[corrRow.cells.length - 5].innerText

             //document.getElementById('lblDocumentName').innerHTML = corrRow.cells[corrRow.cells.length - 5].innerText;
            document.getElementById('lblDocumentName').innerHTML = corrRow.cells[3].innerText;
            var byteStream = corrRow.cells[corrRow.cells.length - 4].getElementsByTagName("input")[1].value;
             switch (extension) {
                 case 'jpg':
                 case 'png':
                 case 'gif':
                 case 'jpeg':
                 case 'bmp':
                     document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                     document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + byteStream + '">';
                    document.getElementById('divDocument').style.overflow = "scroll";
                    break;
                case 'zip':
                case 'rar':
                     document.getElementById('divDocument').innerHTML = '<iframe src="' + byteStream + '" autostart="true" style="width:100%;height:98%;">';
                    break;
                case 'pdf':
                     document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                     document.getElementById('divDocument').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';

                     break;
                 default:
                     alert("File type not supported");
             }
         }
    </script>
 <%--   <script type="text/javascript">
        document.onmousedown = disableRightclick;
        var message = "Right click is not allowed !!";
        function disableRightclick(evt) {
            if (evt.button == 2) {
                alert(message);
                return false;
            }
        }
    </script>--%>
</asp:Content>
