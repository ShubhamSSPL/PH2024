<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmInstitute_ChoiceCodeList.aspx.cs" Inherits="Pharmacy2024.MVModule.frmInstitute_ChoiceCodeList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
     <p align = "justify"><b>Note:</b></p>
                    <ol class="list-text">
                        <li><p align = "justify"> Submit Candidate List for merit list verification.</p></li>
                        <li><p align = "justify"> Candidate list Can be submitted only after process fee is paid.</p></li>
                        <li><p align = "justify"> Candidats List is already submitted for Course's Maked in Grey Color.</p></li>   
                        <%--<li><p align = "justify"> For Technical Support Call on +91-8879692687 between (10:00 AM to 06:00 PM, Monday to Saturday).</p></li>--%>
                    </ol> 
    <cc1:ContentBox ID="ContentTable2" runat="server" Width = "100%" Height="400px" ScrollBars = "auto">
        <asp:Button ID="btnExporttoExcel" runat="server" CssClass = "InputButtonRed" Text="Export to Excel" OnClick="btnExporttoExcel_Click"  Visible="false"/>
        <br /><br />
        <%--<table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <b>Select Course Type : </b>
                    <asp:DropDownList ID="ddlCourseType" runat="server" Visible="false" AutoPostBack = "true" OnSelectedIndexChanged = "ddlCourseType_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>TFWS</asp:ListItem>
                        <asp:ListItem>NON TFWS</asp:ListItem>                        
                    </asp:DropDownList>
                </td>
            </tr>
        </table>--%>
        <br />
        <asp:GridView ID="gvReport" ShowHeader="true" ShowFooter = "true" runat="server" CellPadding="10" CellSpacing="10" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" 
            OnRowDataBound="gvReport_RowDataBound">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:HyperLinkField DataTextField = "ChoiceCodeDisplay" Visible="false" DataNavigateUrlFields="NormalChoiceCode,TFWSChoiceCode" DataNavigateUrlFormatString = "frmInstitute_ChoiceCodWiseCandidateList.aspx?NormalChoiceCode={0}&TFWSChoiceCode={1}"  HeaderText = "ChoiceCodeDisplay">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:BoundField DataField = "ChoiceCodeDisplay" Visible="false" HeaderText = "ChoiceCode">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>
                <asp:BoundField DataField = "CourseName" HeaderText = "CourseName">
                    <ItemStyle HorizontalAlign="Left" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:BoundField DataField = "CAPAdmitted" HeaderText = "Admitted">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:HyperLinkField  Text="Print" Target="_blank"  DataNavigateUrlFields="NormalChoiceCode,TFWSChoiceCode" DataNavigateUrlFormatString = "frmCandidatesList.aspx?NormalChoiceCode={0}&TFWSChoiceCode={1}"  HeaderText = "Print Candidate List">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <asp:HyperLinkField    Text="Submit" DataNavigateUrlFields="NormalChoiceCode,TFWSChoiceCode" DataNavigateUrlFormatString = "frmFrezeCandidateList.aspx?NormalChoiceCode={0}&TFWSChoiceCode={1}"  HeaderText = "Submit Candidate List">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField> 
                                 
                
                 <asp:TemplateField HeaderText = "Is Verified" Visible = "false" >
                <ItemTemplate>                    
                <asp:Label ID="lblVerified" runat="server" Text='<%#Bind("IsVerifiedByInstitute") %>' />                
            </ItemTemplate>
                     <HeaderStyle HorizontalAlign="Center" CssClass = "Header" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>

        <cc1:contentbox id="contentSecretKey" runat="server" headertext="Secret Key" boxtype="PopupBox"
                    width="50%" headervisible="false">
        <table class="AppFormTable">
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Text="This Screate is only for Testing Purpose. Merit List Verification Process is not statrted yet. It will be starting soon... "
                               ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblmsg" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;" align="right">
                    Enter Secret Key
                </td>
                <td style="width: 50%;">
                    <asp:TextBox ID="txtkey" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSecretKey" runat="server" OnClick="btnSecretKey_Click" Text="Submit"
                                ValidationGroup="secret" />
                </td>
            </tr>
        </table>
        <asp:HiddenField runat="server" ID="hdnCurrentDocId" />
    </cc1:contentbox>
    <script language="javascript" type="text/javascript">
        function showSecretKey() {
            document.getElementById('<%=contentSecretKey.ClientID %>').Show('', true);
        } 
    </script>

       <%--<script type="text/javascript">
        document.onmousedown = disableRightclick;
        var message = "Right click is not allowed !!";
        function disableRightclick(evt) {
            if (evt.button == 2) {
                alert(message);
                return false;
            }
        }
    </script>--%>
</asp:Content>





