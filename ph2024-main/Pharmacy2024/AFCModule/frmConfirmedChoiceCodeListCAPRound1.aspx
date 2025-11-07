<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmConfirmedChoiceCodeListCAPRound1.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmConfirmedChoiceCodeListCAPRound1" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
     <style>
         @media print {
            .HeadDiv span {
                color: black !important;
            }
        }
    </style>
    <script type="text/javascript">
        function Printit() {
            document.getElementById("topdiv").style.display = 'none';
            //document.getElementById("top2").style.display = 'none';
            //document.getElementById("left1").style.display = 'none';
            document.getElementById("footer").style.display = 'none';
            document.getElementById("btnPrint").style.display = 'none';
            document.getElementById("rightContainer1").style.width = '900px';

            window.print();

            document.getElementById("topdiv").style.display = '';
            //document.getElementById("top2").style.display = '';
            // document.getElementById("left1").style.display = '';
            document.getElementById("footer").style.display = '';
            document.getElementById("btnPrint").style.display = '';
            document.getElementById("rightContainer1").style.width = '79.7%';
        }
    </script>   
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Personal Details">
        <table class="AppFormTable">
            <tr>
                <td style="width: 20%" align="right">Application ID</td>
                <td style="width: 30%">
                    <asp:Label ID="lblApplicationID" runat="server" Font-Bold="true"></asp:Label></td>
                <td style="width: 20%" align="right">Candidate Name</td>
                <td style="width: 30%">
                    <asp:Label ID="lblCandidateName" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Gender</td>
                <td>
                    <asp:Label ID="lblGender" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Date of Birth</td>
                <td>
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Candidature Type</td>
                <td>
                    <asp:Label ID="lblCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Home University</td>
                <td>
                    <asp:Label ID="lblHomeUniversity" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Category for Admission</td>
                <td>
                    <asp:Label ID="lblCategoryForAdmission" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Person with Disability</td>
                <td>
                    <asp:Label ID="lblPHType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Defence Type</td>
                <td>
                    <asp:Label ID="lblDefenceType" runat="server" Font-Bold="true"></asp:Label></td>
                <td align="right">Minority Candidature Type</td>
                <td>
                    <asp:Label ID="lblMinorityCandidatureType" runat="server" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable3" runat="server" HeaderText="Preferences Given By Candidate">
        <asp:GridView ID="gvPreferencedOptionsList" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass="DataGrid">
            <Columns>
                <asp:BoundField DataField="PreferenceNo" HeaderText="Pref No">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteCode" HeaderText="Inst Code">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                </asp:BoundField>
                <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" HtmlEncode="false">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="38%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" CssClass="Item" />
                </asp:BoundField>
                <asp:BoundField DataField="UniversityName" HeaderText="University Name">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="19%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseType" HeaderText="SL / HU / OHU">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="Course Name">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="18%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                </asp:BoundField>
                <asp:BoundField DataField="ChoiceCodeDisplay" HeaderText="Choice Code">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" Width="5%" CssClass="Header" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Important Instructions">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td colspan="4">
                    <ol class="list-text">
                        <li>
                            <p align="justify">SL - State Level.</p>
                        </li>
                        <li>
                            <p align="justify">HU - Home University.</p>
                        </li>
                        <li>
                            <p align="justify">OHU - Other than Home University.</p>
                        </li>
                        <asp:Label ID="lblChoiceCodeStatus" runat="server"></asp:Label>
                    </ol>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <input id="btnPrint" type="button" value="  Print  " class="InputButton" onclick="Printit()" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>
