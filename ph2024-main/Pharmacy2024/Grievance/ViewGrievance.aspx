<%@ Page Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="ViewGrievance.aspx.cs" Inherits="Pharmacy2024.Grievance.ViewGrievance" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <style>
        .modal-body {
            height: 250px;
            overflow: auto;
        }

        @media (min-height: 500px) {
            .modal-body {
                height: 400px;
            }
        }

        @media (min-height: 800px) {
            .modal-body {
                height: 600px;
            }
        }

        .btnwidth {
            min-width: 150px;
        }

        .modal-header {
            padding: 0.5rem;
        }
    </style>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="View Ticket Details">
        <div class="row card-body w-100">
            <div class="col-md-12">
                <asp:UpdatePanel runat="server" ID="upGrievance">
                    <ContentTemplate>
                        <div id="divGrievances" runat="server" class="row text-center">
                            <div class="col-md-12">
                                <asp:Button ID="btnPending" runat="server" Text="Pending Tickets" CssClass="btn btn-primary m-3" OnClick="btnPending_Click" CausesValidation="false" />
                                <asp:Button ID="btnInProcess" runat="server" Text="In-Process Tickets" CssClass="btn btn-primary m-3" BackColor="blue" OnClick="btnInProcess_Click" CausesValidation="false" />
                                <asp:Button ID="btnReplied" runat="server" Text="Replied Tickets" CssClass="btn btn-primary m-3" OnClick="btnReplied_Click" CausesValidation="false" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row mt-2">
                    <div class="col-md-12">
                        <asp:PlaceHolder ID="plcGrievance" runat="server" />
                    </div>
                </div>
                <div class="row mt-2 mb-2 text-center">
                    <div class="col-md-12">
                        <asp:Button ID="btnReOpen" runat="server" Text="Re-Open" CssClass="InputButton" OnClick="btnReOpen_Click" CausesValidation="false" />
                        <asp:Button ID="btnReply" runat="server" Text="Reply" CssClass="InputButton" OnClick="btnReply_Click" CausesValidation="false" />
                        <%--<asp:Button ID="btnForward" runat="server" Text="Forward" CssClass="btn btn-success btn-sm m-2 btnwidth" OnClick="btnForward_Click" CausesValidation="false" />--%>
                    </div>
                </div>
            </div>
        </div>
    </cc1:ContentBox>
    <br />
    <div class="modal" id="modalDocument" tabindex="-1" role="dialog">
        <div class="modal-dialog" style="min-width: 90%;" role="Document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="headerTitle" style="vertical-align: middle;">Document Details</h5>
                    <button type="button" class="btn btn-danger" data-dismiss="modal" aria-label="Close" style="margin-top: 2px;">
                        X
                    </button>
                </div>
                <div class="modal-body" id="ModalBody">
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
                    <div style="width: 100%; height: 400px" id="divDocument"></div>
                </div>
            </div>
        </div>
    </div>
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

        $(document).ready(function () {
            $('.second-box').click(function (e) {
                e.preventDefault();

                var FileName = 'Attachment';
                var FileURL = $(this).attr('href');
                var extension = FileURL.split('.').pop();
                var dsResponse = Pharmacy2024.ViewMessageBoxDocument.GetCandidateGrievanceDocumentAsBase64(FileURL);
                var byteStream = dsResponse.value;

                $('#headerTitle').text(FileName);

                switch (extension) {
                    case 'jpg':
                    case 'png':
                    case 'gif':
                    case 'jpeg':
                    case 'bmp':

                        /*document.getElementById('divDocument').innerHTML = '<iframe src="' + FileURL + '" autostart="true" style="width:100%;height:98%;border:none;">';*/
                        document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'inline';
                        document.getElementById('divDocument').innerHTML = '<img id="imgPopUpDoc" style="width:25rem;" runat="server" src="' + byteStream + '">';
                        $("#modalDocument").modal('show');
                        break;
                    case 'pdf':
                        document.getElementById('<%=divButtonPopup.ClientID %>').style.display = 'none';
                        document.getElementById('divDocument').innerHTML = '<embed src="' + byteStream + '#toolbar=0" autostart="true" style="width:100%;height:98%;">';
                        $("#modalDocument").modal('show');
                }
            })
        });
    </script>
</asp:Content>
