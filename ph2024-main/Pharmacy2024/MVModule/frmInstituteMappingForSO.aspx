<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmInstituteMappingForSO.aspx.cs" Inherits="Pharmacy2024.MVModule.frmInstituteMappingForSO" %>
  <%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
      <table class="AppFormTableWithOutBorder">
          <tr>
              <td>
                     <tr>
                <td colspan = "4">
                    <p align = "justify"><b>Instructions for Regional Office :</b></p>
                    <ol class="list-text">
                        <li><p align = "justify">Select Scrutiny Officer From DropDown</p></li>
                        <li><p align = "justify">Select institute from list to Assign SO for Merit List Verification </p></li>
                       
                    </ol>
                </td>
            </tr>
              </td>
          </tr>
            <tr  >
               <td align="left" colspan = "1" style="font-size:medium; font-weight:600" >Select Srutiny Officer :               
                    <asp:DropDownList ID="ddlSOSELECT" BackColor="LemonChiffon" Font-Bold="true" Font-Size="Medium" runat="server" Width="50%" OnSelectedIndexChanged="ddlSOSELECT_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
               <td>
                   <b>Candidates already Assigned: <asp:Label ID='lblAssigned' runat="server" ForeColor="Red"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   Candidates Pending for Verification: <asp:Label ID='lblPending' runat="server" ForeColor="Red"></asp:Label></b>
                </td> 
            </tr>
          <tr>
               <td>
                   <b>Candidates selected for Assignment: <asp:Label ID='lblNewAssigned' runat="server" ForeColor="Red"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  Total No. Of Candidates after Assignment: <asp:Label ID='lblNewPending' runat="server" ForeColor="Red"></asp:Label></b>
                </td> 
            </tr>
      <tr>
           <tr  >
               <td align="left" colspan = "1" style="font-size:medium; font-weight:600" >Select Institute :               
                    <asp:DropDownList ID="ddlInstitute" BackColor="LemonChiffon" Font-Bold="true" Font-Size="Medium" runat="server" Width="50%" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                   <%-- <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlSOSELECT" ErrorMessage="Please Select Srutiny Officer to be Assign." Operator="NotEqual" ValueToCompare="-- Select --" Display="none" ValidationGroup="UPDATE"></asp:CompareValidator>--%>
                </td> 
                </tr>
          <td align="center" colspan="2"> 
     <asp:GridView ID="gvReport" ShowHeader="true" ShowFooter = "false" runat="server" CellPadding="10" CellSpacing="10" AutoGenerateColumns="False" Width="100%" 
         CssClass = "DataGrid" AllowPaging="true"  OnPageIndexChanging="gvReport_PageIndexChanging" PageSize="25">
            <Columns> 
              <%--  <asp:BoundField HeaderText="Assign">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>--%>
                 <asp:TemplateField HeaderText="InstituteId" runat="server" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblinstituteid" runat="server" Text='<%# Bind("InstituteCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Choice Code" runat="server" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblChoiceCode" runat="server" Text='<%# Bind("NormalChoiceCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Choice Code TFWS" runat="server" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblChoiceCodeTFWS" runat="server" Text='<%# Bind("TFWSChoiceCode") %>'></asp:Label>
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
               <asp:BoundField DataField = "CourseCode" HeaderText = "Course Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "true" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>               
                <asp:BoundField DataField = "CourseName" HeaderText = "Course Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap = "false" />
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
                     <asp:Button ID="btnUpdate" runat="server" Text="Assign to SO" OnClick="btnUpdate_Click" CssClass="InputButton" ValidationGroup="UPDATE" />
      <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UPDATE" />
                </td>
            </tr>
          </table>
         <table class="AppFormTableWithOutBorder">
       
                     <tr>
                <td colspan = "2">
                    <p align = "justify"><b>List of Scrutiny Officer Assigned to Institute :</b></p>
                    <ol class="list-text">
                        <li><p align = "justify">Select Scrutiny Officer From DropDown</p></li>
                        <li><p align = "justify">Select institute from list to Assign SO for Merit List Verification </p></li>
                       
                    </ol>
                </td>
            </tr>
              <tr>
          <td align="center" colspan="2"> 
     <%--<asp:GridView ID="gvassignInstbySO" ShowHeader="true" ShowFooter = "false" runat="server" CellPadding="10" CellSpacing="10" AutoGenerateColumns="False" Width="100%" 
         CssClass = "DataGrid" AllowPaging="true"  OnPageIndexChanging="gvReport_PageIndexChanging" PageSize="25">
            <Columns> 
                   <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass = "Item" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>
                <asp:TemplateField HeaderText = "Sr. No." ItemStyle-Width="5%" ItemStyle-CssClass = "Item" HeaderStyle-CssClass ="Header" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                <ItemTemplate >
                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
                </asp:TemplateField>
               
                 <asp:TemplateField HeaderText="InstituteId" runat="server" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblinstituteid" runat="server" Text='<%# Bind("InstituteCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField = "SONAME" HeaderText = "Scrutiny Officer">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
          
                <asp:BoundField DataField = "InstituteCode" HeaderText = "InstituteCode">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "InstituteName" HeaderText = "InstituteName">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalIntake" HeaderText = "TotalIntake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>             
                <asp:BoundField DataField = "TotalAdmitted" HeaderText = "TotalAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalCancelled" HeaderText = "TotalCancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "TotalVacancy" HeaderText = "TotalVacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
               
            </Columns>
        </asp:GridView>--%>


              <asp:GridView ID="gvassignInstbySO" ShowFooter = "false" runat="server" CellPadding="5" AutoGenerateColumns="False" Width="100%" 
         CssClass = "DataGrid"  AllowSorting="True" OnSorting="gvassignInstbySO_Sorting">
            <Columns> 
                
                <asp:BoundField DataField="num_row" HeaderText="Sr. No." SortExpression="num_row">
                    <ItemStyle HorizontalAlign="Center"  Width="10%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>


                <asp:HyperLinkField DataTextField = "SOName" DataNavigateUrlFields="SOID" DataNavigateUrlFormatString = "frmSOVerifyStatus.aspx?SOID={0}" HeaderText = "Name Of SO" SortExpression="SOName">
                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" BackColor="#cccccc" Font-Bold="true"/>
                </asp:HyperLinkField> 
               
                 <asp:BoundField DataField="Designation" HeaderText="Designation">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false"  BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>

                <asp:BoundField DataField="SOMobile" HeaderText="Mobile No.">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>

                <asp:BoundField DataField="Email" HeaderText="Email">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>

                <asp:BoundField DataField="NoOfinstAssigned" HeaderText="No Of <br/> Choice Codes <br/> Assigned" HtmlEncode="false" SortExpression="NoOfinstAssigned">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>

                <asp:BoundField DataField="CandidatesRecommended" HeaderText="No of <br/> Candidates <br/> Recommended" HtmlEncode="false" SortExpression="CandidatesRecommended">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>

                <asp:BoundField DataField="CandidatesNotRecommended" HeaderText="No of <br/> Candidates <br/> Not Recommended" HtmlEncode="false" SortExpression="CandidatesNotRecommended">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>

                <asp:BoundField DataField="CandidatesPending" HeaderText="No of <br/> Candidates <br/> Pending" HtmlEncode="false" SortExpression="CandidatesPending">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>

                <asp:BoundField DataField="NoOfCandidates" HeaderText="No of <br/> Candidates <br/> Assigned" HtmlEncode="false" SortExpression="NoOfCandidates">
                    <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:BoundField>

               <asp:TemplateField HeaderText = "% Pending">
                <ItemTemplate>                    
                <asp:Label ID="lblPending" runat="server" Text="" Visible = "true" />                
            </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center"  Width="15%" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" BackColor="#cccccc" Font-Bold="true"/>
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>

              </td>
      </tr>
             </table>
             
</asp:Content>
