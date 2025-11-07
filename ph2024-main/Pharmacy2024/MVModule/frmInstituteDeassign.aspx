<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmInstituteDeassign.aspx.cs" Inherits="Pharmacy2024.MVModule.frmInstituteDeassign" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <table class="AppFormTableWithOutBorder">
          <tr>   
                <td colspan = "4">
                    <p align = "justify"><b>Instructions for Regional Office :</b></p>
                    <ol class="list-text">
                        <li><p align = "justify">Select Scrutiny Officer From DropDown</p></li>
                        <li><p align = "justify">Select institute from list to Deassign SO for Merit List Verification </p></li>                       
                    </ol>
                </td>
          </tr>
            <tr>
               <td align="left" colspan = "1" style="font-size:medium; font-weight:600" >Select Srutiny Officer :               
                    <asp:DropDownList ID="ddlSOSELECT" BackColor="LemonChiffon" Font-Bold="true" runat="server" Width="45%" OnSelectedIndexChanged="ddlSOSELECT_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                    <asp:CompareValidator ID="cvSOSELECT" runat="server" ControlToValidate="ddlSOSELECT" ErrorMessage="Please Select Srutiny Officer to be Assign." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="UPDATE"></asp:CompareValidator>
                </td> 
                </tr>
          <tr>
                <td>
                    <asp:Label ID='lblSOProfile' runat="server"></asp:Label> 
                </td>
            </tr>
           
      <tr>
          <td align="center" colspan="2"> 
     <asp:GridView ID="gvReport" ShowHeader="true" ShowFooter = "false" runat="server" CellPadding="10" CellSpacing="10" AutoGenerateColumns="False" Width="100%" 
         CssClass = "DataGrid" AllowPaging="true"  OnPageIndexChanging="gvReport_PageIndexChanging" PageSize="25">
            <Columns> 
                 <asp:TemplateField HeaderText="InstituteId" runat="server" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblinstituteid" runat="server" Text='<%# Bind("InstituteCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Assign">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Font-Bold="true" CssClass="Header"
                            Font-Size="10px" Wrap="true" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Item" Font-Size="10px" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="middle" CssClass="Header" Font-Size="10px" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAssign" runat="server" OnCheckedChanged="chkAssign_CheckChanged" AutoPostBack="true"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField = "InstituteCode" HeaderText = "InstituteCode">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteName" HeaderText = "Institute Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap = "true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "true" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>               
                <asp:BoundField DataField = "TotalIntake" HeaderText = "Total Intake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "true" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>             
                <asp:BoundField DataField = "TotalAdmitted" HeaderText = "Total Admitted" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "true" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>               
            </Columns>
        </asp:GridView>
              </td>
      </tr>
      <tr>
                <td align="center" colspan = "2">
                     <asp:Button ID="btnUpdate" runat="server" Text="Deassign to SO" OnClick="btnUpdate_Click" CssClass="InputButton" ValidationGroup="UPDATE" />
                     <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UPDATE" />
                </td>
            </tr>
          </table>
</asp:Content>
