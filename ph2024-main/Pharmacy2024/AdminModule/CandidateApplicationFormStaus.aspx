<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="CandidateApplicationFormStaus.aspx.cs" Inherits="Pharmacy2024.AdminModule.CandidateApplicationFormStaus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">

    <table id="tblDiscrepancyDetails" runat="server" class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px; background-color: red; color:wheat;" colspan="2"><b>Application Form Verification Status</b></th>
            </tr>
            <tr>
                <td>
                    <%--<font color="red"> --%>
                        <b><asp:Label id="lblDiscrepancyStatus" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label></b>
                    <%--</font>--%>
                </td>
            </tr>
            <tr id="trDiscrepancy" runat="server" visible="false">
                <td>
                    <asp:GridView ID="gvDiscrepancy" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
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
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscrepancyID" runat="server" Text='<%# Eval("DiscrepancyID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplicationFormStepID" runat="server" Text='<%# Eval("ApplicationFormStepID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Go To Step">
                                <ItemTemplate>
                                    <asp:Button ID="btnStep" runat="server" Text="Click To Edit" PostBackUrl='<%# Eval("LinkUrl") %>' CssClass="InputButton" BackColor="#cc66ff"></asp:Button>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </td>
            </tr>
            <tr id="trEditButton" runat="server" visible="false" >
                <td align="center"><asp:button id="btnEditApplicationForm" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Edit Application Form" Height="40px" Font-Size="Medium" Font-Bold="true"  ></asp:button></td>
            </tr>
            <tr id="trReSubmitButton" runat="server" visible="false" >
                <td align="center"><asp:button id="btnReSubmit" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to ReSubmit and Lock Application Form for E-Scrutiny" Height="40px" Font-Size="Medium" Font-Bold="true"  ></asp:button></td>
            </tr>
            <tr id="trSubmitButton" runat="server" visible="false" >
                <td align="center"><asp:button id="btnSubmit" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Submit and Lock Application Form for E-Scrutiny" Height="40px" Font-Size="Medium" Font-Bold="true"  ></asp:button></td>
            </tr>
            <tr id="trBookSlotButton" runat="server" visible="false" >
                <td align="center"><asp:button id="btnBookSlot" runat="server" CssClass="InputButton" BackColor="#5cb85c" Text=" Click Here to Book a Slot" Height="40px" Font-Size="Medium" Font-Bold="true"  ></asp:button></td>
            </tr>
        </table>
    <table id="tblApplicationFormStatus" runat="server" visible="false" class="AppFormTable">
            <tr>
                <th style="border-top-width: 0px;" colspan="2">Application Form Status</th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvApplicationFormLinksStatus" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2" BorderWidth="1px" BorderStyle="Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Step ID">
                                <ItemTemplate>
                                    Step <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="20%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="LinkDescription" HeaderText="Step Details">
                                <ItemStyle HorizontalAlign="Left" CssClass="Item" Width="55%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Button ID="btnFormStatus" runat="server" Text='<%# Eval("LinkStatus") %>' PostBackUrl='<%# Eval("LinkUrl") %>' CssClass="InputButton" BackColor='<%# System.Drawing.Color.FromName(Eval("LinkBackColor").ToString()) %>' Enabled='<%# Convert.ToBoolean(Eval("LinkEnabled")) %>' ></asp:Button>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" CssClass="Item" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" CssClass="Header" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>

                <%--<td>
                    <table id="Table1" runat="server" class="AppFormTable">
                        <tr>
                            <td>Application Form Completed</td>
                            <td>No</td>
                        </tr>
                        <tr>
                            <td>Pick By SC</td>
                            <td>No</td>
                        </tr>
                        <tr>
                            <td>Confirm By SC</td>
                            <td>No</td>
                        </tr>
                        <tr>
                            <td>Discripancy by SC & Count</td>
                            <td>0</td>
                        </tr>
                        <tr>
                            <td>Form Can Edit</td>
                            <td>Yes</td>
                        </tr>
                        <tr>
                            <td>Ticket Rquest Status</td>
                            <td>No Ticket Raise</td>
                        </tr>
                    </table>
                </td>--%>
            </tr>
          
        </table>
    <table>
         <tr id="trEligibilityRemark" runat="server" visible="false">
            <td>
                <asp:Label ID="lblEligibilityRemark" runat="server" ForeColor="Red" Font-Size="Medium"><b>Remark : </b></asp:Label></td>
        </tr>
    </table>
</asp:Content>
