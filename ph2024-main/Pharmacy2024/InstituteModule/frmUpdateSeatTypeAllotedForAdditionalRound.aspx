<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmUpdateSeatTypeAllotedForAdditionalRound.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmUpdateSeatTypeAllotedForAdditionalRound" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
    </script>
    <table class="AppFormTableWithOutBorder">
        <tr>
            <td align="center">
                <b>Select Course : </b>
                <asp:DropDownList ID="ddlCourseType" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "ddlCourseType_SelectedIndexChanged">
                    <asp:ListItem>B.Pharmacy</asp:ListItem>
                    <asp:ListItem>Pharm.D</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnChoiceCode" runat="server" />
    <br />
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Current CAP Vacancy (Excluding Minority)">
        <table class="AppFormTable">
            <tr>
                <td align="right">Course Name</td>
                <td colspan = "3"><asp:Label ID="lblCourseName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:30%" align="right"> Against CAP (Excluding Minority) Vacancy</td>
                <td style="width: 20%"><asp:Label ID="lblMSIntake" runat="server" Font-Bold = "true"></asp:Label></td>
                <td style="width: 30%" align="right">Against CAP (Minority) Vacancy</td>
                <td style="width: 20%"><asp:Label ID="lblMIIntake" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <th rowspan = "2">Category Wise Vacancy of CAP (Excluding Minority)</th>
                <th colspan = "2">OPEN</th>
                <th colspan = "2">SC</th>
                <th colspan = "2">ST</th>
                <th colspan = "2">DT/VJ</th>
                <th colspan = "2">NT-1</th>
                <th colspan = "2">NT-2</th>
                <th colspan = "2">NT-3</th>
                <th colspan = "2">OBC</th>
                <th rowspan = "2">PWD</th>
                <th rowspan = "2">DEF</th>
                <th rowspan = "2">AI</th>
                <th rowspan = "2">TOTAL</th>
            </tr>
            <tr>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
                <th>G</th>
                <th>L</th>
            </tr>
            <tr>
                <td style = "width:11%" align = "center"><b>HU</b></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GOPENH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LOPENH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GSCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LSCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GSTH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LSTH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GVJDTH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LVJDTH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GNTBH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LNTBH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GNTCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LNTCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GNTDH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LNTDH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="GOBCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="LOBCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="PHCH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="DEFH" runat="server"></asp:Label></td>
                <td style = "width:4%" align = "center"><asp:Label ID="AIH" runat="server"></asp:Label></td>
                <td style = "width:5%" align = "center"><asp:Label ID="TOTALH" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td align = "center"><b>OHU</b></td>
                <td align = "center"><asp:Label ID="GOPENO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LOPENO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GSCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LSCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GSTO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LSTO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GVJDTO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LVJDTO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GNTBO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LNTBO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GNTCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LNTCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GNTDO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LNTDO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="GOBCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="LOBCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="PHCO" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="DEFO" runat="server"></asp:Label></td>
                 <td align = "center"><asp:Label ID="lblAIIntake" runat="server"></asp:Label></td>
                <td align = "center"><asp:Label ID="TOTALO" runat="server"></asp:Label></td>
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="List of Candidates Addmitted Against CAP (As you update the admission, the current CAP Vacancy shown above shall be  updated automatically) ">
        <asp:GridView ID="gvACPCandidates" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid" OnRowCommand="gvACPCandidates_RowCommand" OnRowDataBound="gvACPCandidates_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="7%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="ApplicationID" HeaderText="Application ID" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="12%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass = "Item" Width="30%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                  <asp:BoundField DataField="Gender" HeaderText="Gender" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="5%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField="CategoryName" HeaderText="Category" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:BoundField>
                <asp:TemplateField HeaderText = "Select Seat Type Against Admitted">
                    <ItemTemplate>
                         <asp:DropDownList ID="ddlSeatType" runat="server" Width="90%">
                            <asp:ListItem>-- Seat Type --</asp:ListItem>
                            <asp:ListItem>AI</asp:ListItem>
                            <asp:ListItem>GNT1H</asp:ListItem>
                            <asp:ListItem>GNT1O</asp:ListItem>
                            <asp:ListItem>GNT2H</asp:ListItem>
                            <asp:ListItem>GNT2O</asp:ListItem>
                            <asp:ListItem>GNT3H</asp:ListItem>
                            <asp:ListItem>GNT3O</asp:ListItem>
                            <asp:ListItem>GOBCH</asp:ListItem>
                            <asp:ListItem>GOBCO</asp:ListItem>
                            <asp:ListItem>GOPENH</asp:ListItem>
                            <asp:ListItem>GOPENO</asp:ListItem>
                            <asp:ListItem>GSCH</asp:ListItem>
                            <asp:ListItem>GSCO</asp:ListItem>
                            <asp:ListItem>GSTH</asp:ListItem>
                            <asp:ListItem>GSTO</asp:ListItem>
                            <asp:ListItem>GVJH</asp:ListItem>
                            <asp:ListItem>GVJO</asp:ListItem>
                            <asp:ListItem>LNT1H</asp:ListItem>
                            <asp:ListItem>LNT1O</asp:ListItem>
                            <asp:ListItem>LNT2H</asp:ListItem>
                            <asp:ListItem>LNT2O</asp:ListItem>
                            <asp:ListItem>LNT3H</asp:ListItem>
                            <asp:ListItem>LNT3O</asp:ListItem>
                            <asp:ListItem>LOBCH</asp:ListItem>
                            <asp:ListItem>LOBCO</asp:ListItem>
                            <asp:ListItem>LOPENH</asp:ListItem>
                            <asp:ListItem>LOPENO</asp:ListItem>
                            <asp:ListItem>LSCH</asp:ListItem>
                            <asp:ListItem>LSCO</asp:ListItem>
                            <asp:ListItem>LSTH</asp:ListItem>
                            <asp:ListItem>LSTO</asp:ListItem>
                            <asp:ListItem>LVJH</asp:ListItem>
                            <asp:ListItem>LVJO</asp:ListItem>
                            <asp:ListItem>PWDC</asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hidSeatType" runat="server" Value="<%# Bind('SeatTypeAllotedForAditionalRound') %>" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="18%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:TemplateField>
                <asp:ButtonField HeaderText = "Update" ButtonType = "Button" CommandName = "Updateq" Text = "Update" ControlStyle-CssClass = "InputButton" ControlStyle-Font-Size="11px">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Item" Width="13%" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass = "Header" />
                </asp:ButtonField> 
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPersonalID" runat="server" Text='<%# Eval("PersonalID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
         <p align = "justify"><font Size = "2" color = "red"><b>Current CAP Vacancy shown above after updating the admission of candidates is correct.</b></font></p>
        <br />
        <br />
         <table class="AppFormTableWithOutBorder">
             <tr runat="server" id="trpasswordbtn">
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text=" Confirm Institute Data "
                        CssClass="InputButton" BackColor="#d9332c" OnClick="btnProceed_Click" />
                </td>
            </tr>
        </table>
    </cc1:ContentBox>
</asp:Content>