<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmMeritListVerificationRODTE.aspx.cs" Inherits="Pharmacy2024.MVModule.frmMeritListVerification" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <p align = "justify"><b>Instructions for Scrutiny Office :</b></p>
                    <ol class="list-text">
                        <li><p align = "justify"> Rows Maked in Grey Color are Cancelled Admissions.</p></li>
                        <li><p align = "justify">Rows Maked in Light Blue Color are Not Recommended Candidates.</p></li>
                        <li><p align = "justify">If candidate is marked as not recommended it is mendetory to select discrepancy type and fill Nature Of Discrepancy in Short accordingly.</p></li>
                    </ol>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="Candidate List" Width = "100%" ScrollBars = "auto">
        <center><asp:Label ID="lblInstituteName" Font-Bold="true" ForeColor="red" runat="server" Font-Size = "small" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" CssClass = "DataGrid" AllowSorting="True"
            OnRowDataBound="gvReport_RowDataBound" OnSorting="gvReport_Sorting" DataKeyNames="PersonalID">
            <Columns> 
                 <asp:BoundField DataField = "num_row" HeaderText="Sr. No." SortExpression="num_row">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />                   
                </asp:BoundField>
                <asp:TemplateField HeaderText="PersonalID" Visible="false">  
             <ItemTemplate> 
                 <asp:Label ID="lblPID" Text='<%# Bind("PersonalID") %>' Visible="false" runat="server"></asp:Label>                  
             </ItemTemplate>  
         </asp:TemplateField> 
                <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID" SortExpression="ApplicationID">
                    <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate Name" SortExpression="CandidateName">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>                
                <asp:BoundField DataField = "MeritNo" HeaderText = "Merit No" SortExpression="MeritNo">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="6%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "MeritMarks" HeaderText = "Merit Marks" SortExpression="MeritMarks">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="6%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "SeatTypeAllotted" HeaderText = "Seat Type" SortExpression="SeatTypeAllotted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="6%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <%--<asp:BoundField DataField = "ReportingStatus" HeaderText = "Admission Status">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="8%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>--%>
                 <asp:TemplateField HeaderText = "Admission Status" SortExpression="ReportingStatus">
                <ItemTemplate>                    
                <asp:Label ID="lblAdmissionStatus" runat="server" Text='<%#Bind("ReportingStatus") %>' Visible = "true" />                
            </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>
                <%--<asp:HyperLinkField Text="View Documents" DataNavigateUrlFields="PersonalID,ApplicationID" DataNavigateUrlFormatString = "frmViewDocuments.aspx?PID={0}&Code={0}&ApplicationID={1}" HeaderText = "">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
                <asp:TemplateField HeaderText="">
      <ItemTemplate>
          <asp:HyperLink ID="link" runat="server" Text='View Documents' Target="_blank" />
      </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
    </asp:TemplateField>
                <asp:TemplateField HeaderText=" Recomended" ControlStyle-Width="150" SortExpression="IsAccepted">
                    <ItemTemplate>                      
                         <asp:RadioButton ID="rbtAccept" Text='Recomended' Checked='<%# Eval("IsAccepted") %>' runat="server" GroupName="Status"
                        OnCheckedChanged="rbtAccept_CheckedChanged" AutoPostBack="true"/>
                        <asp:RadioButton ID="rbtReject" Text='Not Recomended' Checked='<%# Eval("IsRejected") %>' runat="server" GroupName="Status"
                         OnCheckedChanged="rbtReject_CheckedChanged" AutoPostBack="true"  /> 
                     </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>               
                <asp:TemplateField HeaderText = "Discrepancy">
            <ItemTemplate>
                <asp:Label ID="lblMVDiscrepency" runat="server" Text='<%#Bind("MVDiscrepencyID") %>' Visible = "false" />
                <asp:Label ID="lblSelected" runat="server" Text='' Visible = "true" />                
                <asp:DropDownCheckBoxes ID="ddlMVDiscrepency" runat="server" AddJQueryReference="True" UseButtons="false" UseSelectAllNode="false" AutoPostBack="true"  OnSelectedIndexChanged="SelectedIndexChanged">
                                    <Style SelectBoxWidth="200" DropDownBoxBoxWidth="250" DropDownBoxBoxHeight="150" />
                                    <Texts SelectBoxCaption="-- Select Discrepancy Type --" />
                                </asp:DropDownCheckBoxes>
               </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
        </asp:TemplateField>
         <asp:TemplateField>
      <HeaderTemplate >
      <asp:Label ID="lblDescription" runat="server" Text="Nature Of Discrepancy in Short" />
      </HeaderTemplate>
                <ItemTemplate>                    
                    <asp:textbox ID="txtDescription" Text='<%#Bind("MVDiscrepancyRemark") %>' runat="server" 
                        Columns='30' Enabled ="false" TextMode="MultiLine" ></asp:textbox>                
                </ItemTemplate> 
             <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <p></p> <p></p>
        <div><center><asp:Button ID="btnSubmitAll" runat="server" Text="Submit" CssClass="InputButton" OnClick="btnSubmitAll_Click" /></center></div>
        <p></p> <p></p>
    </cc1:ContentBox>
</asp:Content>

