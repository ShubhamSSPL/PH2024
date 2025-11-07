<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmFrezeCandidateList.aspx.cs" Inherits="Pharmacy2024.MVModule.frmFrezeCandidateList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server"> 
    <p align = "justify"><b>Instructions for Institute for Submitting Candidate's List to Ro:</b></p>
                    <ol class="list-text">
                        <li><p align = "justify"> Rows Maked in Grey Color are Cancelled Admissions.</p></li>
                        <li><p align = "justify"> Do verify the documents for admitted candidate's before submitting candidate's list to Ro for Merit List verification.</p></li>
                        <li><p align = "justify"> Once Candidate's list is submitted, the same will be locked for Merit list verification</p></li>
                    </ol>
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="List of candidate's" Width = "100%" ScrollBars = "auto">
        <center><asp:Label ID="lblMsg" Font-Bold="true" ForeColor="red" runat="server" Font-Size ="Medium" Font-Names="Verdana"></asp:Label></center>
        <br />
        <center><asp:Label ID="lblMsg2" Font-Bold="true" ForeColor="red" runat="server" Font-Size ="Medium" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:LinkButton ID="btnShowList" runat="server" OnClick="btnShowList_Click" Font-Size ="Small" Font-Names="Verdana">Click Here to Display Candidate's List</asp:LinkButton>
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" CssClass = "DataGrid" AllowSorting="True"
            OnRowDataBound="gvReport_RowDataBound" OnSorting="gvReport_Sorting" DataKeyNames="PersonalID">
            <Columns> 
                 <asp:BoundField DataField = "num_row" HeaderText="Sr. No." SortExpression="num_row">                    
                     <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />                   
                </asp:BoundField>
                <asp:BoundField DataField = "PersonalID" HeaderText="Personal ID" SortExpression="PersonalID">                    
                     <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />                   
                </asp:BoundField>                
                <asp:BoundField DataField = "ChoiceCodeDisplay" HeaderText = "Choice Code" SortExpression="ChoiceCodeDisplay">
                    <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID" SortExpression="ApplicationID">
                    <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>                
                <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate's Name" SortExpression="CandidateName">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Width="30%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "MeritNo" HeaderText = "Merit No" SortExpression="MeritNo">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "MeritMarks" HeaderText = "Merit Marks" SortExpression="MeritMarks">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "SeatTypeAdmitted" HeaderText = "Seat Type" SortExpression="SeatTypeAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>                
                  <asp:TemplateField HeaderText = "Admission Status" SortExpression="AdmStatus">
                <ItemTemplate>                    
                <asp:Label ID="lblAdmissionStatus" runat="server" Text='<%#Bind("AdmStatus") %>' Visible = "true" />                
            </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>
                <asp:BoundField DataField = "CancelRequestOn" HeaderText = "Cancel Request Raised On" SortExpression="CancelRequestOn">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField> 
                <asp:BoundField DataField = "AdmCategory" HeaderText = "Admission Category" SortExpression="AdmCategory">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField> 
                <asp:TemplateField HeaderText="View Documents">
                    <ItemTemplate>
                            <asp:HyperLink ID="link" runat="server" Text='View Documents' Target="_blank" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>               
            </Columns>
        </asp:GridView>
         <br /><br />
        <asp:Label ID="lblOthers" Text="Over And Above Candidate's List" Font-Bold="true" Font-Size="Medium" ForeColor="#cc0066" runat="server"></asp:Label>
        <asp:GridView ID="gvOthers" runat="server" AutoGenerateColumns="False" CssClass = "DataGrid" AllowSorting="True"
            OnRowDataBound="gvOthers_RowDataBound" OnSorting="gvOthers_Sorting" DataKeyNames="PersonalID">
            <Columns> 
                 <asp:BoundField DataField = "num_row" HeaderText="Sr. No." SortExpression="num_row">                    
                     <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />                   
                </asp:BoundField>
                <asp:BoundField DataField = "PersonalID" HeaderText="Personal ID" SortExpression="PersonalID">                    
                     <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />                   
                </asp:BoundField>                
                <asp:BoundField DataField = "ChoiceCodeDisplay" HeaderText = "Choice Code" SortExpression="ChoiceCodeAllotted">
                    <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID" SortExpression="ApplicationID">
                    <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>                
                <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate's Name" SortExpression="CandidateName">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Width="30%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "MeritNo" HeaderText = "Merit No" SortExpression="MeritNo">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "MeritMarks" HeaderText = "Merit Marks" SortExpression="MeritMarks">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "SeatTypeAdmitted" HeaderText = "Seat Type" SortExpression="SeatTypeAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>                
                  <asp:TemplateField HeaderText = "Admission Status" SortExpression="AdmStatus">
                <ItemTemplate>                    
                <asp:Label ID="lblAdmissionStatus" runat="server" Text='<%#Bind("AdmStatus") %>' Visible = "true" />                
            </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>
                <asp:BoundField DataField = "CancelRequestOn" HeaderText = "Cancel Request Raised On" SortExpression="CancelRequestOn">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField> 
                <asp:BoundField DataField = "AdmCategory" HeaderText = "Admission Category" SortExpression="AdmCategory">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField> 
                <asp:TemplateField HeaderText="View Documents">
                    <ItemTemplate>
                            <asp:HyperLink ID="link" runat="server" Text='View Documents' Target="_blank" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>
        <br /><br />
        <asp:Label ID="lblEWS" Text="EWS Candidate's List" Font-Bold="true" Font-Size="Medium" ForeColor="#cc0066" runat="server"></asp:Label>
        <asp:GridView ID="gvEWS" runat="server" AutoGenerateColumns="False" CssClass = "DataGrid" AllowSorting="True"
            OnRowDataBound="gvEWS_RowDataBound" OnSorting="gvEWS_Sorting" DataKeyNames="PersonalID">
            <Columns> 
                 <asp:BoundField DataField = "num_row" HeaderText="Sr. No." SortExpression="num_row">                    
                     <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />                   
                </asp:BoundField>
                <asp:BoundField DataField = "PersonalID" HeaderText="Personal ID" SortExpression="PersonalID">                    
                     <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />                   
                </asp:BoundField>                
                <asp:BoundField DataField = "ChoiceCodeDisplay" HeaderText = "Choice Code" SortExpression="ChoiceCodeAllotted">
                    <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID" SortExpression="ApplicationID">
                    <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>                
                <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate's Name" SortExpression="CandidateName">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Width="30%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "MeritNo" HeaderText = "Merit No" SortExpression="MeritNo">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "MeritMarks" HeaderText = "Merit Marks" SortExpression="MeritMarks">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "SeatTypeAdmitted" HeaderText = "Seat Type" SortExpression="SeatTypeAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>                
                  <asp:TemplateField HeaderText = "Admission Status" SortExpression="AdmStatus">
                <ItemTemplate>                    
                <asp:Label ID="lblAdmissionStatus" runat="server" Text='<%#Bind("AdmStatus") %>' Visible = "true" />                
            </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>
                <asp:BoundField DataField = "CancelRequestOn" HeaderText = "Cancel Request Raised On" SortExpression="CancelRequestOn">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField> 
                <asp:BoundField DataField = "AdmCategory" HeaderText = "Admission Category" SortExpression="AdmCategory">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField> 
                <asp:TemplateField HeaderText="View Documents">
                    <ItemTemplate>
                            <asp:HyperLink ID="link" runat="server" Text='View Documents' Target="_blank" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>
        <br /><br />
        <asp:Label ID="lblTFWS" Text="TFWS Candidate's List" Font-Bold="true" Font-Size="Medium" ForeColor="#cc0066" runat="server"></asp:Label>
        <asp:GridView ID="gvTFWS" runat="server" AutoGenerateColumns="False" CssClass = "DataGrid" AllowSorting="True"
            OnRowDataBound="gvTFWS_RowDataBound" OnSorting="gvTFWS_Sorting" DataKeyNames="PersonalID">
            <Columns> 
                 <asp:BoundField DataField = "num_row" HeaderText="Sr. No." SortExpression="num_row">                    
                     <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />                   
                </asp:BoundField>
                <asp:BoundField DataField = "PersonalID" HeaderText="Personal ID" SortExpression="PersonalID">                    
                     <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />                   
                </asp:BoundField>                
                <asp:BoundField DataField = "ChoiceCodeDisplay" HeaderText = "Choice Code" SortExpression="ChoiceCodeAllotted">
                    <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID" SortExpression="ApplicationID">
                    <ItemStyle HorizontalAlign="center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>                
                <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate's Name" SortExpression="CandidateName">
                    <ItemStyle HorizontalAlign="left" CssClass = "Item" Width="30%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "MeritNo" HeaderText = "Merit No" SortExpression="MeritNo">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "MeritMarks" HeaderText = "Merit Marks" SortExpression="MeritMarks">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>
                <asp:BoundField DataField = "SeatTypeAdmitted" HeaderText = "Seat Type" SortExpression="SeatTypeAdmitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField>                
                  <asp:TemplateField HeaderText = "Admission Status" SortExpression="AdmStatus">
                <ItemTemplate>                    
                <asp:Label ID="lblAdmissionStatus" runat="server" Text='<%#Bind("AdmStatus") %>' Visible = "true" />                
            </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>
                <asp:BoundField DataField = "CancelRequestOn" HeaderText = "Cancel Request Raised On" SortExpression="CancelRequestOn">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField> 
                <asp:BoundField DataField = "AdmCategory" HeaderText = "Admission Category" SortExpression="AdmCategory">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Width="10%" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:BoundField> 
                <asp:TemplateField HeaderText="View Documents">
                    <ItemTemplate>
                            <asp:HyperLink ID="link" runat="server" Text='View Documents' Target="_blank" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>
                <%--<asp:HyperLinkField Text="View Documents" DataNavigateUrlFields="PersonalID,ApplicationID" DataNavigateUrlFormatString = "frmViewDocuments.aspx?PID={0}&Code={0}&ApplicationID={1}" HeaderText = "">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>--%>
            </Columns>
        </asp:GridView>
        <p></p> <p></p>
        <div><center><asp:Button ID="btnSubmit" runat="server" Text="Submit List for Merit List Verification" CssClass="InputButton" OnClientClick="return confirm('Are you sure you want to submit Candidate's List for Merit list Verification ?');" OnClick="btnSubmit_Click" /></center></div>
        <p></p> <p></p>
    </cc1:ContentBox>
</asp:Content>
