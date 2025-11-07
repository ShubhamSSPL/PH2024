<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCandidatesList.aspx.cs" Inherits="Pharmacy2024.MVModule.frmCandidatesList" %>
<%@ Register Assembly="Synthesys.Controls.ShowMessage" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<!DOCTYPE html> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>..:: State Common Entrance Test Cell, Government of Maharashtra ::..</title>
    <link rel="stylesheet" href="../Styles/Style.css" type="text/css" />
    <style type="text/css" media="screen">
        .Header {
            text-align: center;
            font-weight: bold;
            font-family: Verdana;
            font-size: 8px;
            background-color: #d8d8d8;
            color: #000000;
            vertical-align: top;
            border-top-width: 1px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 0px;
            border-style: solid;
            border-color: #c8c8c8;
        }

        .Footer {
            text-align: center;
            font-weight: bold;
            font-family: Verdana;
            font-size: 8px;
            background-color: #d8d8d8;
            color: #000000;
            vertical-align: top;
            border-top-width: 0px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 0px;
            border-style: solid;
            border-color: #c8c8c8;
        }

        .InnerText {
            text-align: center;
            font-family: Verdana;
            font-size: 8px;
            color: #000000;
            vertical-align: top;
            border-top-width: 0px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 0px;
            border-style: solid;
            border-color: #c8c8c8;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:10px;">
            <asp:Button ID="btnSubmit" runat="server" Text="Back to Home Page" CssClass="InputButton" PostBackUrl="~/ApplicationPages/WelcomePageInstitute.aspx"/>
        
             <table class='AppFormTableWithOutBorder'>
                <tr>
                    <td style='width: 7%;' align='center'>
                        <img src="../Images/ARAFINAL.png" />

                    </td>
                    <td style='width: 93%;' align='center'>
                        <b><font size='3'>Admission Regulating Authority, Government of Maharashtra</font><br />
                            8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)<br />
                            <br />
                            <font size='2'>List of Candidates Admitted to First Year Under Graduate Technical Course in B.Pharmacy & Post Graduate Pharm.D Admissions <%= AdmissionYear %></font>
                            <br />
                            <br />
                            <font size='2'></b></td>
                </tr>
            </table>  
            <table class="AppFormTableWithOutBorder">
                <tr >
                    <td style="text-align: left">
                        <h5 style="margin-top:10px;">
                            Institute Code: <asp:Label ID="lblInstCode" runat="server" Text="" Font-Size="Small" ForeColor="#990033"></asp:Label> <br />
                            Institute Name: <asp:Label ID="lblInstName" runat="server" Text="" Font-Size="Small" ForeColor="#990033"></asp:Label> </h5>
                    </td>
                </tr>
            </table>
             <br />
            <asp:GridView ID="gvReport" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid"
                OnRowDataBound="gvReport_RowDataBound" DataKeyNames="PersonalID">
            <Columns>

                <asp:BoundField DataField="num_row" HeaderText="Sr.No." HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                           
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name - <br/> (Application ID)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField> 
                
                <asp:BoundField DataField="AdmCategory" HeaderText="Admission Category" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="CancelRequestOn" HeaderText="Cancel Request Raised On" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                
                <asp:TemplateField HeaderText = "Admission Status">
                    <ItemTemplate>                    
                        <asp:Label ID="lblAdmissionStatus" runat="server" Text='<%#Bind("AdmStatus") %>' Visible = "true" />                
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="true" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="View Documents">
                    <ItemTemplate>
                            <asp:HyperLink ID="link" runat="server" Text='View Documents' Target="_blank"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="true" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:BoundField DataField="PersonalID" HeaderText="Personal ID" HtmlEncode="false" Visible="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                 <asp:BoundField DataField="DocumentName" HeaderText="List of Documents" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:TemplateField HeaderText = "Remarks (Yes/ No)">
                    <ItemTemplate>                    
                        <asp:Label ID="lblRemarks" runat="server" Text="" Visible = "true" Width="15%"/>                
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>
              
            </Columns>
        </asp:GridView> 

            <br />
            <asp:Label ID="lblOthers" Text="Over and Above Candidate's List" Font-Bold="true" Font-Size="Medium" ForeColor="#cc0066" runat="server"></asp:Label>
            <asp:GridView ID="gvOthers" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid"
                OnRowDataBound="gvOthers_RowDataBound" DataKeyNames="PersonalID">
            <Columns>
                
                <asp:BoundField DataField="num_row" HeaderText="Sr.No." HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                            
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name - <br/> (Application ID)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>  
                                
                <asp:BoundField DataField="AdmCategory" HeaderText="Admission Category" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="CancelRequestOn" HeaderText="Cancel Request Raised On" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                                
                <asp:TemplateField HeaderText = "Admission Status">
                    <ItemTemplate>                    
                        <asp:Label ID="lblAdmissionStatus" runat="server" Text='<%#Bind("AdmStatus") %>' Visible = "true" />                
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="true" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="View Documents">
                    <ItemTemplate>
                            <asp:HyperLink ID="link" runat="server" Text='View Documents' Target="_blank"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="true" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:BoundField DataField="PersonalID" HeaderText="Personal ID" HtmlEncode="false" Visible="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                 <asp:BoundField DataField="DocumentName" HeaderText="List of Documents" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:TemplateField HeaderText = "Remarks (Yes/ No)">
                    <ItemTemplate>                    
                        <asp:Label ID="lblRemarks" runat="server" Text="" Visible = "true" Width="15%"/>                
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>

            <br />
            <asp:Label ID="lblEWS" Text="EWS Candidate's List" Font-Bold="true" Font-Size="Medium" ForeColor="#cc0066" runat="server"></asp:Label>
            <asp:GridView ID="gvEWS" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid"
                OnRowDataBound="gvEWS_RowDataBound" DataKeyNames="PersonalID">
            <Columns>
                
                <asp:BoundField DataField="num_row" HeaderText="Sr.No." HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                            
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name - <br/> (Application ID)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>  
                
                <asp:BoundField DataField="AdmCategory" HeaderText="Admission Category" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="CancelRequestOn" HeaderText="Cancel Request Raised On" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                
                <asp:TemplateField HeaderText = "Admission Status">
                    <ItemTemplate>                    
                        <asp:Label ID="lblAdmissionStatus" runat="server" Text='<%#Bind("AdmStatus") %>' Visible = "true" />                
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="true" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="View Documents">
                    <ItemTemplate>
                            <asp:HyperLink ID="link" runat="server" Text='View Documents' Target="_blank"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="true" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:BoundField DataField="PersonalID" HeaderText="Personal ID" HtmlEncode="false" Visible="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                 <asp:BoundField DataField="DocumentName" HeaderText="List of Documents" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:TemplateField HeaderText = "Remarks (Yes/ No)">
                    <ItemTemplate>                    
                        <asp:Label ID="lblRemarks" runat="server" Text="" Visible = "true" Width="15%"/>                
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>
              
            </Columns>
        </asp:GridView> 
            <br />
             <asp:Label ID="lblTFWS" Text="TFWS Candidate's List" Font-Bold="true" Font-Size="Medium" ForeColor="#cc0066" runat="server"></asp:Label>
            <asp:GridView ID="gvTFWS" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%" CellPadding="5" CssClass = "DataGrid"
                OnRowDataBound="gvTFWS_RowDataBound" DataKeyNames="PersonalID">
            <Columns>
                
                <asp:BoundField DataField="num_row" HeaderText="Sr.No." HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                            
                <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name - <br/> (Application ID)" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>  
                
                <asp:BoundField DataField="AdmCategory" HeaderText="Admission Category" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="CancelRequestOn" HeaderText="Cancel Request Raised On" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                                
                <asp:TemplateField HeaderText = "Admission Status">
                    <ItemTemplate>                    
                        <asp:Label ID="lblAdmissionStatus" runat="server" Text='<%#Bind("AdmStatus") %>' Visible = "true" />                
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="true" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="View Documents">
                    <ItemTemplate>
                            <asp:HyperLink ID="link" runat="server" Text='View Documents' Target="_blank"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="true" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>

                <asp:BoundField DataField="PersonalID" HeaderText="Personal ID" HtmlEncode="false" Visible="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                 <asp:BoundField DataField="DocumentName" HeaderText="List of Documents" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:TemplateField HeaderText = "Remarks (Yes/ No)">
                    <ItemTemplate>                    
                        <asp:Label ID="lblRemarks" runat="server" Text="" Visible = "true" Width="15%"/>                
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:TemplateField>
              
            </Columns>
        </asp:GridView> 
        </div>
    </form>
</body>
</html>
