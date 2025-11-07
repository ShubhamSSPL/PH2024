<%@ Page Language="C#"  MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master"  AutoEventWireup="true" CodeBehind="frmNEETConfirmedCandidateList.aspx.cs" Inherits="Pharmacy2024.E_FCModule.frmNEETConfirmedCandidateList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
   <%-- <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "E-SC Verified / Confirmed Candidate List">--%>
          <div class="row w-100 mx-auto">
        <div class="col-xl-12">
            <div class="card mb-4">
                <div class="card-header card-Status">
                    <i class="fas fa-database mr-1"></i>
                    NEET Verified / Confirmed Candidate List
                </div>
                <div class="card-body" style="overflow-x: auto">
                    <div class="row w-100 mx-auto">
                        <div class="col-xl-12">
                            <div class="card mb-4 border-0">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td style="width: 50%;" align="right">Select Date to Filter : </td>
                <td style="width: 50%;"><asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        </table>
        <asp:GridView ID="gvCandidateList" runat="server" AutoGenerateColumns="False" Width="100%" OnPreRender="gvCandidateList_PreRender" CssClass="table table-striped DataGridForBootstrap" OnRowCommand="gvCandidateList_RowCommand">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="7%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate  Name">
                    <ItemStyle HorizontalAlign="Left" Width="20%" CssClass = "Item" Wrap = "true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                     <asp:BoundField DataField = "MobileNo" HeaderText = "Mobile No" Visible="true">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "NEETPhysicsScore" HeaderText = "Physics <br /> Score" HtmlEncode = "false" HeaderStyle-Wrap="true">
                    <ItemStyle HorizontalAlign="Center" Width="8%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "NEETChemistryScore" HeaderText = "Chemistry <br />  Score" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="8%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "NEETBiologyScore" HeaderText = "Biology <br /> (Botany & Zoology) <br /> Score" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="8%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "NEETTotalScore" HeaderText = "Total <br /> Score" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="8%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "LastModifiedOnFCVerificationStatus" Visible="false" HeaderText = "Last Modified <br /> SC Verification Status" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="25%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "ConfirmedBy"  HeaderText = "Confirmed <br /> By" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "LastModifiedByIPAddressFCVerificationStatus" Visible="false" HeaderText = "Last Modified By <br /> IPAddress SC Verification Status" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "IsConfirmedUnderNEET" HeaderText = "Is Confirmed<br /> Under NEET" HtmlEncode = "false" Visible="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                
                <asp:BoundField DataField = "VerificationMode" HeaderText = "Verification <br /> Mode" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="8%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                
                 
                <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                        <a href="#"  id="hrefURL" runat="server" onclick="javascript:OpenViewDocumentPopUp(this)">View</a>
                        <img src="" id="imgDoc" style="cursor: pointer; max-width: 40px" runat="server" onclick="javascript:OpenViewDocumentPopUp(this)" />
                        <asp:HiddenField ID="hidFURL" runat="server" Value='<%# Bind("FilePath") %>' />
                        <asp:HiddenField ID="hdnImgByteArray" runat="server" Value='<%# Bind("FilePath") %>' />
                       <%-- <asp:HiddenField ID="hidDID" runat="server" Value='<%# Bind("DocumentTransID") %>' />--%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                </asp:TemplateField>
                 <asp:ButtonField HeaderText="Edit" ButtonType="Button" CommandName="Edit" Text="Edit" ControlStyle-CssClass="InputButton" >
                    <ItemStyle Width="5%" HorizontalAlign="Center" CssClass="Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                    <ControlStyle Font-Bold="True" />
                </asp:ButtonField>
                  <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPersonalID" runat="server" Text='<%# Eval("PersonalID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
                                  </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <cc1:ContentBox ID="contentViewDocument" runat="server" HeaderText="View Document" BoxType="PopupBox" Width="80%" Height="500px">
      <div class="table-responsive">
        <table class="AppFormTable">
            <tr>
                <th align="left">
                    <label id="lblDocumentName"></label>
                </th>
            </tr>
            <tr runat="server" id="trFetchDocView" style="display: none;">
            </tr>
            <tr>
                <td>
                    <div class="modal-body p-0" style="height: 450px;">
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
          </div>
    </cc1:ContentBox>
    <%--</cc1:ContentBox>--%>
     <script src="../SBAdmin/dist/js/jquery-3.3.1.min.js"></script>
    <script src="../SBAdmin/dist/js/jquery.dataTables.min.js"></script>
    <script src="../SBAdmin/dist/js/dataTables.bootstrap4.min.js"></script>
    <script src="../SBAdmin/dist/js/buttons.bootstrap4.min.js"></script>
    <script src="../SBAdmin/dist/js/dataTables.buttons.min.js"></script>
    <script src="../SBAdmin/dist/js/jszip.min.js"></script>
    <script src="../SBAdmin/dist/js/pdfmake.min.js"></script>
    <script src="../SBAdmin/dist/js/vfs_fonts.js"></script>
    <script src="../SBAdmin/dist/js/buttons.html5.min.js"></script>
    <script src="../SBAdmin/dist/js/buttons.print.min.js"></script>
    <script src="../SBAdmin/dist/js/buttons.colVis.min.js"></script>
    <script src="../SBAdmin/dist/js/datatables-init.js"></script>
   
    <script type="text/javascript">
        <%-- $(document).ready(function () {
            $('#<%= gvReport.ClientID %>').dataTable({
                 
            });
        }); --%>
        TableManageButtons.init();

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

        function OpenViewDocumentPopUp(cntrl) {
            document.getElementById('<%=contentViewDocument.ClientID %>').Show('', true);
            document.getElementById('divDocument').innerHTML = '';
            document.getElementById('lblDocumentName').innerHTML = '';
            var corrRow = cntrl.parentNode.parentNode;
            var filePath = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[0].value;
            var extension = filePath.substr((filePath.lastIndexOf('.') + 1));
            var byteStream = corrRow.cells[corrRow.cells.length - 1].getElementsByTagName("input")[1].value;
         
            document.getElementById('lblDocumentName').innerHTML = corrRow.cells[1].innerText;
            switch (extension) {
                case 'jpg':
                case 'png':
                case 'gif':
                case 'jpeg':
                case 'bmp':
                    document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                    document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" runat="server" src="' + byteStream + '">';
                    document.getElementById('divDocument').style.overflow = "auto";
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
    <script>
        var handleDataTableButtons = function () {
            "use strict";
            0 !== $('#<%= gvCandidateList.ClientID %>').length && $('#<%= gvCandidateList.ClientID %>').DataTable({
                dom: "Bfrtip",
                paging: true,
                buttons: [
                    //{
                    //extend: "copy",
                    //className: "btn btn-primary",
                    //title: 'NEET Confirmed Candidates List'
                    //},
                    {
                    extend: "csv",
                    className: "btn btn-danger",
                    title: 'NEET Confirmed Candidates List'

                    },
                    {
                    extend: "excel",
                    className: "btn btn-success",
                    autoFilter: false,
                    sheetName: 'Pharmacy',
                        title: 'NEET Confirmed Candidates List'
                    }//,
                    //{
                    //extend: "pdf",
                    //className: "btn btn-info",
                    //    title: 'NEET Confirmed Candidates List'
                    //}//,
                    //{
                    //extend: "print",
                    //className: "btn btn-warning",
                    //    title: 'NEET Confirmed Candidates List'
                    //}
                ],
               
                responsive: !0,
                ordering: true,
                info: true,
                search: true,
                pageLength: 10,

                title: "NEET Confirmed Candidates List"

            })
        }();

        TableManageButtons.init();

    </script>
</asp:Content>

