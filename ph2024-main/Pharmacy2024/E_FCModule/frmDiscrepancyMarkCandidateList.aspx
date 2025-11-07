<%@ Page Language="C#"  MasterPageFile = "~/MasterPages/DynamicMasterPageSB.master"  AutoEventWireup="true" CodeBehind="frmDiscrepancyMarkCandidateList.aspx.cs" Inherits="Pharmacy2024.E_FCModule.frmDiscrepancyMarkCandidateList" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText = "Reverted Back Candidate List">
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td style="width: 50%;" align="right">Select Date to Filter : </td>
                <td style="width: 50%;"><asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        </table>
        <asp:GridView ID="gvCandidateList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" OnRowDataBound="gvCandidateList_RowDataBound">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:TemplateField ItemStyle-Width="20px">
                    <ItemTemplate>
                        <a href="JavaScript:divexpandcollapse('div<%# Eval("PersonalID") %>');">
                            <img id="imgdiv<%# Eval("PersonalID") %>" width="9px" border="0" src="../Images/plus.gif" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPersonalID" runat="server" Text='<%# Eval("PersonalID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate Name">
                    <ItemStyle HorizontalAlign="Left" Width="35%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                  <asp:BoundField DataField = "MobileNo" HeaderText = "Mobile No"  visible="true">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "LastModifiedOnFCVerificationStatus" HeaderText = "Last Modified <br /> SC Verification Status" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="25%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "LastModifiedByFCVerificationStatus" HeaderText = "Last Modified By <br /> SC Verification Status" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:BoundField DataField = "LastModifiedByIPAddressFCVerificationStatus" HeaderText = "Last Modified By <br /> IPAddress SC Verification Status" HtmlEncode = "false">
                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false"/>
                </asp:BoundField>
                <asp:TemplateField >
                    <ItemTemplate>
                         
                        <tr >
                            <td colspan="7">
                                <div id="div<%# Eval("PersonalID") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                    <table class="AppFormTable" style="border-color:red !important; border-width:1px !important;">
                                        <tr >
                                            <th align="left" style="font-size: 14px;font-weight: 500; color: #ffffff; padding: 10px; letter-spacing: 0.04em; background-color: #f14252; border-color: #bcd5ec;">
                                                <asp:Label ID="Label1" runat="server"><b>Discrepancy(s) Marked by SC Officer :</b></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvChildGrid" runat="server" AutoGenerateColumns="false" CellPadding="2" BorderWidth = "1px" BorderStyle = "Solid" CssClass="DataGrid" Width="100%">
                                                    <Columns>
                                                       <asp:BoundField HeaderText="Application Form Step" DataField="LinkName" HtmlEncode="false">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Discrepancy In" DataField="DiscrepancyName" HtmlEncode="false">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" CssClass="Header" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Remark by SC Officer" DataField="DiscrepancyRemark" HtmlEncode="false">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40%" CssClass="Header" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="Item" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>

                                            </td>
                                        </tr>
                                    </table>
                                    
                                </div> 
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPrintedOn" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="red" Font-Names="Verdana"></asp:Label>
    </cc1:ContentBox>
    
    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../Images/minus.gif";
            } else {
                div.style.display = "none";
                img.src = "../Images/plus.gif";
            }
        }
    </script>
</asp:Content>

