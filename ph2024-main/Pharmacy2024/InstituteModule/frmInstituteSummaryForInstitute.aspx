<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmInstituteSummaryForInstitute.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmInstituteSummaryForInstitute" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script type="text/javascript" src="../SynthesysModules_Files/Scripts/ContentBox.js"></script>
    <script language="javascript" type = "text/javascript">
        function openPopUpBox() {
            document.getElementById("<%=ContentBox2.ClientID %>").Show('#000000', true);
        }
        function Summation() {
            var subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_GOPENH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GOPENH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSCH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSCH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSTH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSTH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GVJH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GVJH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT1H").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT1H").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT2H").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT2H").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT3H").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT3H").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GOBCH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GOBCH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSEBCH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSEBCH").innerHTML);
            document.getElementById("rightContainer_ContentBox2_TOTALGH").innerHTML = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_LOPENH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LOPENH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSCH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSCH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSTH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSTH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LVJH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LVJH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT1H").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT1H").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT2H").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT2H").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT3H").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT3H").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LOBCH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LOBCH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSEBCH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSEBCH").innerHTML);
            document.getElementById("rightContainer_ContentBox2_TOTALLH").innerHTML = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSCH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSCH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSTH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSTH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCVJH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCVJH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT1H").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT1H").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT2H").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT2H").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT3H").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT3H").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCOBCH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCOBCH").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSEBCH").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSEBCH").innerHTML);
            document.getElementById("rightContainer_ContentBox2_TOTALPHCH").innerHTML = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_GOPENO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GOPENO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSCO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSTO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSTO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GVJO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GVJO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT1O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT1O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT2O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT2O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT3O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT3O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GOBCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GOBCO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSEBCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSEBCO").innerHTML);
            document.getElementById("rightContainer_ContentBox2_TOTALGO").innerHTML = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_LOPENO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LOPENO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSCO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSTO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSTO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LVJO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LVJO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT1O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT1O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT2O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT2O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT3O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT3O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LOBCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LOBCO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSEBCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSEBCO").innerHTML);
            document.getElementById("rightContainer_ContentBox2_TOTALLO").innerHTML = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSCO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSTO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSTO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCVJO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCVJO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT1O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT1O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT2O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT2O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT3O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT3O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCOBCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCOBCO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSEBCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSEBCO").innerHTML);
            document.getElementById("rightContainer_ContentBox2_TOTALPHCO").innerHTML = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFSCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFSCO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFSTO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFSTO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFVJO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFVJO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFNT1O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFNT1O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFNT2O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFNT2O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFNT3O").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFNT3O").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFOBCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFOBCO").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFSEBCO").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFSEBCO").innerHTML);
            // subResult += (document.getElementById("ctl00_rightContainer_ContentBox2_EWS").innerHTML == "") ? 0 : parseInt(document.getElementById("ctl00_rightContainer_ContentBox2_EWS").innerHTML);
            subResult += (document.getElementById("rightContainer_ContentBox2_ORPHAN").innerHTML == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_ORPHAN").innerHTML);
            document.getElementById("rightContainer_ContentBox2_TOTALDEFO").innerHTML = subResult;
        }
        function load() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler() {
            Summation();
        }
        window.onload = load;
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Institute Summary">
        <table class="AppFormTable">
            <tr>
                <td align="right">Institute Code</td>
                <td colspan="3"><asp:Label ID="lblInstituteCode" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Institute Name</td>
                <td colspan="3"><asp:Label ID="lblInstituteName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Institute Address</td>
                <td colspan="3"><asp:Label ID="lblInstituteAddress" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">DTE Region</td>
                <td><asp:Label ID="lblRegion" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">District</td>
                <td><asp:Label ID="lblDistrict" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td style ="width:25%" align="right">Status 1</td>
                <td style ="width:30%"><asp:Label ID="lblStatus1" runat="server" Font-Bold = "true"></asp:Label></td>
                <td style ="width:25%" align="right">Status 2</td>
                <td style ="width:20%"><asp:Label ID="lblStatus2" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Status 3</td>
                <td colspan = "3"><asp:Label ID="lblStatus3" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Boys Hostel Capacity</td>
                <td><asp:Label ID="lblBoysHostelCapacityIYear" runat="server" Font-Bold = "true"></asp:Label> (1st Year)</td>
                <td align="right">Girls Hostel Capacity</td>
                <td><asp:Label ID="lblGirlsHostelCapacityIYear" runat="server" Font-Bold = "true"></asp:Label> (1st Year)</td>
            </tr>
            <tr>
                <td align="right">Public Remark</td>
                <td colspan = "3"><asp:Label ID="lblPublicRemark" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox7" runat="server" HeaderText="Course Details" Width = "100%" ScrollBars = "Auto">
        <asp:UpdateProgress runat="server" id="UpdateProgress1">
            <ProgressTemplate>
                <img src ="../Images/BigProgress.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upDDDetails">
            <ContentTemplate>
                <asp:GridView ID="gvChoiceCodeList" runat="server" DataKeyNames = "ChoiceCode" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid" OnRowCommand = "gvChoiceCodeList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" Wrap = "false" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                            <ItemStyle HorizontalAlign="Left" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" Wrap = "false" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UniversityName" HeaderText="University">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CourseStatus1" HeaderText="Status">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CourseStatus2" HeaderText="Autonomy Status">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CourseStatus3" HeaderText="Minority Status">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CourseShift" HeaderText="Shift">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AccreditationDetails" HeaderText="Accreditation Details">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Gender" HeaderText="Gender Status">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" Wrap = "false" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IsStateLevel" HeaderText="State Level">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IsTFWS" HeaderText="TFWS">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IsKonkan" HeaderText="Konkan">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IsNRI" HeaderText="NRI Quota">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IsPIO" HeaderText="PIO Quota">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalIntake" HeaderText="Total Intake">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ParticipateInCAP" HeaderText="Participate In CAP">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CourtCaseRemark" HeaderText="Court Case Remark">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Seat Distribution">
                            <ItemStyle HorizontalAlign="Center" Font-Size="9px" CssClass = "Item" Wrap = "false" />
                            <HeaderStyle HorizontalAlign="Center"  Font-Size="9px" CssClass = "Header" />
                            <ItemTemplate>
                                <asp:LinkButton ID="btnSeatDistribution" runat="server" Text="View" CommandName="SeatDistribution" OnClientClick="openPopUpBox();" CommandArgument='<%#Eval("ChoiceCode") %>' ValidationGroup = "SeatDistribution" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </cc1:ContentBox>
    <br />
    <cc1:ContentBox ID="ContentBox2" runat="server" BoxType = "PopupBox" Width = "1000px" HeaderText="Seat Distribution">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td align="right">Course Name</td>
                        <td colspan = "3"><asp:Label ID="lblCourseName" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="right">Total Intake</td>
                        <td style="width: 25%"><asp:Label ID="lblTotalIntake" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td style="width: 25%" align="right">CAP (Excluding Minority) Intake</td>
                        <td style="width: 25%"><asp:Label ID="lblCAPIntake" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">CAP (Minority) Intake</td>
                        <td><asp:Label ID="lblMIIntake" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">Institutional Intake</td>
                        <td><asp:Label ID="lblILIntake" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">MS CAP (Excluding Minority) Intake</td>
                        <td><asp:Label ID="lblMSIntake" runat="server" Font-Bold = "true"></asp:Label></td>
                        <td align="right">AI CAP (Excluding Minority) Intake</td>
                        <td><asp:Label ID="lblAIIntake" runat="server" Font-Bold = "true"></asp:Label></td>
                    </tr>
                       <tr>
                   <td align="right">EWS Intake</td>
                        <td colspan="3"><asp:Label ID="EWS" runat="server" Font-Bold = "true"></asp:Label>
                        </td>
                
                 
            </tr>
                </table>
                <table class="AppFormTable">
                    <tr>
                        <th colspan="2"></th>
                        <th>OPEN</th>
                        <th>SC</th>
                        <th>ST</th>
                        <th>DT/VJ</th>
                        <th>NT-B</th>
                        <th>NT-C</th>
                        <th>NT-D</th>
                        <th>OBC</th>
                        <th>SEBC</th>
                       <%-- <th>EWS</th>--%>
                        <th>ORPHAN</th>
                        <th>TOTAL</th>
                    </tr>
                    <tr>
                        <td style = "width:8%" align = "center" rowspan="3"><b>HU</b></td>
                        <td style = "width:8%" align = "center"><b>G</b></td>
                        <td style = "width:7%" align = "center"><asp:Label ID="GOPENH" runat="server"></asp:Label></td>
                        <td style = "width:7%" align = "center"><asp:Label ID="GSCH" runat="server"></asp:Label></td>
                        <td style = "width:7%" align = "center"><asp:Label ID="GSTH" runat="server"></asp:Label></td>
                        <td style = "width:7%" align = "center"><asp:Label ID="GVJH" runat="server"></asp:Label></td>
                        <td style = "width:7%" align = "center"><asp:Label ID="GNT1H" runat="server"></asp:Label></td>
                        <td style = "width:7%" align = "center"><asp:Label ID="GNT2H" runat="server"></asp:Label></td>
                        <td style = "width:7%" align = "center"><asp:Label ID="GNT3H" runat="server"></asp:Label></td>
                        <td style = "width:7%" align = "center"><asp:Label ID="GOBCH" runat="server"></asp:Label></td>
                        <td style = "width:7%" align = "center"><asp:Label ID="GSEBCH" runat="server"></asp:Label></td>
                       <%-- <td style = "width:7%" align = "center">--</td>--%>
                        <td style = "width:7%" align = "center">--</td>
                        <td style = "width:7%" align = "center"><asp:Label ID="TOTALGH" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align = "center"><b>L</b></td>
                        <td align = "center"><asp:Label ID="LOPENH" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LSCH" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LSTH" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LVJH" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LNT1H" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LNT2H" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LNT3H" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LOBCH" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LSEBCH" runat="server"></asp:Label></td>
                       <%-- <td align = "center">--</td>--%>
                        <td align = "center">--</td>
                        <td align = "center"><asp:Label ID="TOTALLH" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align = "center"><b>PH</b></td>
                        <td align = "center"><asp:Label ID="PHCH" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCSCH" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCSTH" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCVJH" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCNT1H" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCNT2H" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCNT3H" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCOBCH" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCSEBCH" runat="server"></asp:Label></td>
                       <%-- <td align = "center">--</td>--%>
                        <td align = "center">--</td>
                        <td align = "center"><asp:Label ID="TOTALPHCH" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align = "center" rowspan="3"><b>OHU</b></td>
                        <td align = "center"><b>G</b></td>
                        <td align = "center"><asp:Label ID="GOPENO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="GSCO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="GSTO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="GVJO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="GNT1O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="GNT2O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="GNT3O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="GOBCO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="GSEBCO" runat="server"></asp:Label></td>
                       <%-- <td align = "center">--</td>--%>
                        <td align = "center">--</td>
                        <td align = "center"><asp:Label ID="TOTALGO" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align = "center"><b>L</b></td>
                        <td align = "center"><asp:Label ID="LOPENO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LSCO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LSTO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LVJO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LNT1O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LNT2O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LNT3O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LOBCO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="LSEBCO" runat="server"></asp:Label></td>
                       <%-- <td align = "center">--</td>--%>
                        <td align = "center">--</td>
                        <td align = "center"><asp:Label ID="TOTALLO" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align = "center"><b>PH</b></td>
                        <td align = "center"><asp:Label ID="PHCO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCSCO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCSTO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCVJO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCNT1O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCNT2O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCNT3O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCOBCO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="PHCSEBCO" runat="server"></asp:Label></td>
                       <%-- <td align = "center">--</td>--%>
                        <td align = "center">--</td>
                        <td align = "center"><asp:Label ID="TOTALPHCO" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align = "center"><b>SL</b></td>
                        <td align = "center"><b>DEF</b></td>
                        <td align = "center"><asp:Label ID="DEFO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="DEFSCO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="DEFSTO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="DEFVJO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="DEFNT1O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="DEFNT2O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="DEFNT3O" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="DEFOBCO" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="DEFSEBCO" runat="server"></asp:Label></td>
                       <%-- <td align = "center"><asp:Label ID="EWS" runat="server"></asp:Label></td>--%>
                        <td align = "center"><asp:Label ID="ORPHAN" runat="server"></asp:Label></td>
                        <td align = "center"><asp:Label ID="TOTALDEFO" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>

