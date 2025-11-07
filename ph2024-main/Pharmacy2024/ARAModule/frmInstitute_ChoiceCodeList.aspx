<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageARA.Master" AutoEventWireup="true" CodeBehind="frmInstitute_ChoiceCodeList.aspx.cs" Inherits="Pharmacy2024.ARAModule.frmInstitute_ChoiceCodeList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <cc1:ContentBox ID="ContentTable2" runat="server" Width = "100%" Height="400px" ScrollBars = "auto">
        <asp:Button ID="btnExporttoExcel" runat="server" CssClass = "InputButtonRed" Text="Export to Excel" OnClick="btnExporttoExcel_Click" />
        <br /><br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <b>Select Course Type : </b>
                    <asp:DropDownList ID="ddlCourseType" runat="server" AutoPostBack = "true" OnSelectedIndexChanged = "ddlCourseType_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>TFWS</asp:ListItem>
                        <asp:ListItem>NON TFWS</asp:ListItem>
                        <%--<asp:ListItem>EWS</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvReport" ShowHeader="false" ShowFooter = "true" runat="server" CellPadding="10" CellSpacing="10" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid" OnRowCreated="gvReport_RowCreated">
            <Columns> 
                <asp:BoundField HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                <asp:HyperLinkField DataTextField = "ChoiceCodeDisplay" DataNavigateUrlFields="ChoiceCode,ChoiceCodeDisplay" DataNavigateUrlFormatString = "frmInstitute_ChoiceCodWiseCandidateList.aspx?ChoiceCode={0}&ChoiceCodeDisplay={1}"  HeaderText = "ChoiceCodeDisplay">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:HyperLinkField>
                <%--<asp:BoundField DataField = "ChoiceCodeDisplay" HeaderText = "ChoiceCode">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>--%>
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
                
                <asp:BoundField DataField = "InstApproved" HeaderText = "InstApproved">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                
                <asp:BoundField DataField = "InstRejected" HeaderText = "InstRejected">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>
               
                <asp:BoundField DataField = "PendingAtInst" HeaderText = "PendingAtInst">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                
                <asp:BoundField DataField = "ROApproved" HeaderText = "ROApproved">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>
                
                <asp:BoundField DataField = "RORejected" HeaderText = "RORejected">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
               
                <asp:BoundField DataField = "PendingAtRO" HeaderText = "PendingAtRO">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>
                
                <asp:BoundField DataField = "ARAApproved" HeaderText = "ARAApproved">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                
                <asp:BoundField DataField = "ARARejected" HeaderText = "ARARejected">
                    <ItemStyle HorizontalAlign="Center" Width="30%" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Font-Size="10px"/>
                    <FooterStyle HorizontalAlign="Center" CssClass = "Footer" />
                </asp:BoundField>
                
                <asp:BoundField DataField = "PendingAtARA" HeaderText = "PendingAtARA">
                    <ItemStyle HorizontalAlign="Center" CssClass = "Item" Wrap = "false" />
                    <HeaderStyle HorizontalAlign="Center" CssClass = "Header" Wrap = "false" />
                    <FooterStyle HorizontalAlign="center" CssClass = "Footer" Wrap = "false" />
                </asp:BoundField>
                
            </Columns>
        </asp:GridView>
    </cc1:ContentBox>
       <script type="text/javascript">
        document.onmousedown = disableRightclick;
        var message = "Right click is not allowed !!";
        function disableRightclick(evt) {
            if (evt.button == 2) {
                alert(message);
                return false;
            }
        }
    </script>
</asp:Content>





