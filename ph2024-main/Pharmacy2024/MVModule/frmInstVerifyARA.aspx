<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmInstVerifyARA.aspx.cs" Inherits="Pharmacy2024.MVModule.frmInstVerifyARA" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">

    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <link href="../Styles/epoch_styles.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/epoch_classes_DOB.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        function Selectallcheckbox(val) {
            if (!$(this).is(':checked')) {
                $('input:checkbox').prop('checked', val.checked);
            } else {
                $("#chkroot").removeAttr('checked');
            }
        }
    </script>
    
    <cc1:ContentBox ID="ContentTable2" runat="server" HeaderText="List of Institutes (Proposal Submitted to ARA) (B.Pharm)" Width = "100%" ScrollBars = "auto">
        <center><asp:Label ID="lblMsg" CssClass="LabelClass" Font-Bold="true" ForeColor="red" runat="server" Font-Names="Verdana"></asp:Label></center>
        <br />
        <asp:Button ID="btnExporttoExcel" runat="server" CssClass = "InputButtonRed" Text="Export to Excel" OnClick="btnExporttoExcel_Click" />
        <br />
        <asp:GridView ID="gvExcel" ShowHeader="true" ShowFooter = "false" runat="server" CellPadding="10" 
            CellSpacing="10" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" Visible="false">
            <Columns> 
               
                <asp:BoundField DataField = "InstituteCode" HeaderText = "Institute Code">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>

                <asp:BoundField DataField = "InstituteName" HeaderText = "Institute Name">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                
                <asp:BoundField DataField = "TotalIntake" HeaderText = "Total Intake">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>

                <asp:BoundField DataField = "TotalAdmitted" HeaderText = "Total Admitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
               
                <asp:BoundField DataField = "TotalVacancy" HeaderText = "Vacancy">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>

                <asp:BoundField DataField = "CandidateRecommeded" HeaderText = "Recommended for Approval">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
               
                <asp:BoundField DataField = "CandidateNotRecommeded" HeaderText = "Not Recommended for Approval">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>

                <asp:BoundField DataField = "TotalCancelled" HeaderText = "Admission Cancelled">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
               
                <asp:BoundField DataField = "RemarksDTE" HeaderText = "Remarks, If Any">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                
            </Columns>
        </asp:GridView>
        <br /><h4><b>
        ARA Approval Date :
        <asp:TextBox ID="txtApprovalDate" runat="server" MaxLength="10" ReadOnly="false" Style="width: 250px;" BorderColor="#003366" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>&nbsp;
                                   <%-- <asp:ImageButton ID="Image1" runat="Server" AlternateText="Click &#13;&#10; to show calendar"
                                        ImageUrl="../images/calendar.gif" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                        FilterType="Custom,Numbers" TargetControlID="txtApprovalDate" ValidChars="/">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" Enabled="True"
                                        Format="dd/MM/yyyy" PopupButtonID="Image1" TargetControlID="txtApprovalDate">
                                    </ajaxToolkit:CalendarExtender></b></h4>--%>
        <br />
        <br />

        <asp:GridView ID="gvReport" ShowHeader="true" ShowFooter = "false" runat="server" CellPadding="10" CellSpacing="10" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid">
            <Columns>
             <asp:TemplateField>
                 <HeaderTemplate>
                    <asp:CheckBox ID="checkAll" runat="server" onclick = "javascript:Selectallcheckbox(this);" />
                 </HeaderTemplate>
                 <ItemTemplate>
                    <asp:CheckBox ID="chkVerify" Checked="true" runat="server" />
                 </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
            </asp:TemplateField>

                <asp:TemplateField HeaderText="Institute Code" Visible="true" >  
             <ItemTemplate> 
                 <asp:Label ID="lblInstCode" runat="server" Text='<%#Bind("InstituteCode") %>'  /> 
                 </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
            </asp:TemplateField>

              <asp:BoundField DataField="InstituteName" HeaderText="Institute  Name " HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                
                <asp:BoundField DataField="TotalIntake" HeaderText="Sactioned <br/> Intake" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="TotalAdmitted" HeaderText="Total <br/> Admitted" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                
                <asp:BoundField DataField="TotalVacancy" HeaderText="Vacancy" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="CandidateRecommeded" HeaderText="Recommended <br/> For <br/> Approval" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="CandidateNotRecommeded" HeaderText="Not <br/> Recommended <br/> For <br/> Approval" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="TotalCancelled" HeaderText="Admission <br/> Cancelled" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="RemarksDTE" HeaderText="Remarks, <br/> If Any" HtmlEncode="false">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap="true" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Header" Wrap="false" />
                </asp:BoundField>
                                                           
            </Columns>
        </asp:GridView>
        <p></p> <p></p>
        <div><center><asp:Button ID="btnSubmit" runat="server" Text="Verify Institutes" CssClass="InputButton" OnClientClick="return confirm('Are you sure you want to verify selected institutes ?');" OnClick="btnSubmit_Click" /></center></div>
        <p></p> <p></p>
    </cc1:ContentBox>

     <script language="javascript" type="text/javascript">
         var dp_cal;
         window.onload = function () {
             dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('rightContainer_ContentTable2_txtApprovalDate'));
         };
     </script>
</asp:Content>


