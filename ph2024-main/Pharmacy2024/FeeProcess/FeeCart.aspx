<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="FeeCart.aspx.cs" Inherits="Pharmacy2024.FeeProcess.FeeCart" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="ccm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <style>
        .Hide 
        { 
            display:none; 
        }
    </style>
    <script type="text/javascript" language="javascript">
        function ValidatePayment() 
        {
            var trPost = document.getElementById('<%=trPostGroup.ClientID%>');
            var posts = trPost.getElementsByTagName('input');
            var totalFee = 0;
            var currRow;

            for (i = 0; i < posts.length; i++) 
            {
                if (posts[i].type == "checkbox" && posts[i].checked) 
                {
                    return true;
                }
            }

            alert('Select Admission Group to proceed for payment');
            return false;
        }
        function DisplayTotalFee() {

            CheckDifferentPayGroup();

            var trPost = document.getElementById('<%=trPostGroup.ClientID%>');
            var posts = trPost.getElementsByTagName('input');
            var totalFee = 0;
            var currRow;
            var initialGroup = 0;
            var nextGroup = 0;       

            for (i = 0; i < posts.length; i++) 
            {
                if (posts[i].type == "checkbox" && posts[i].checked) {
                    currRow = posts[i].parentNode.parentNode;

                    nextGroup = 0;
                    nextGroup = parseFloat(currRow.cells[currRow.cells.length - 1].innerHTML, 10);

                    if (initialGroup == 0 && nextGroup > 0) {

                        initialGroup = nextGroup;
                    }

                    if (initialGroup > 0 && nextGroup > 0) {
                        if (initialGroup != nextGroup) {
                            alert('You can select only same payment Group items for payment proceeding. ');
                            return false;
                        }
                    }


                    totalFee += parseFloat(currRow.cells[currRow.cells.length - 4].innerHTML, 10);
                }
            }

            document.getElementById('<%=lblTotalFee.ClientID%>').innerHTML = totalFee +".00";
        }

        function CheckDifferentPayGroup() {

            var trPost = document.getElementById('<%=trPostGroup.ClientID%>');
            var posts = trPost.getElementsByTagName('input');
            var initialGroup = 0;
            var nextGroup = 0;           

            var currRow;

            for (i = 0; i < posts.length; i++) {
                if (posts[i].type == "checkbox" && posts[i].checked) {
                    currRow = posts[i].parentNode.parentNode;
                    nextGroup=0;
                    nextGroup = parseFloat(currRow.cells[currRow.cells.length - 1].innerHTML, 10);

                    //totalFee += parseFloat(currRow.cells[currRow.cells.length - 1].innerHTML, 10);
                                       
                }
            }

            
        }


    </script>
 <ccm:ContentBox ID="ContentCart" runat="server" HeaderText="Application Fee Cart">
        <asp:HiddenField ID="hdnPayMode" Value="" runat="server" />
        <table id="tblPayment" runat="server" class="AppFormTable">
            <tr>
                <td colspan="2">
                    <span style="color: #FF0000"><b>Note : </b></span>Following Payment has not been done. Select the admission(s) for which you want to pay the fee.
                </td>
            </tr>
            <tr id="trPostGroup" runat="server" style="display:none">
                <td colspan="2">
                    <br />
                    Select the Admission Group to Make Payment & Click On "Proceed To Payment >>>" Button. 
                    <br /><br />
                    <asp:GridView ID="grdFee" runat="server" AutoGenerateColumns="false" EnableModelValidation="True" Width="100%" CellPadding="2" BorderWidth = "1px" BorderStyle = "Solid" CssClass="DataGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Select">               
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPostGroup" runat="server" onclick="DisplayTotalFee();" Checked=<%# Bind("IsSelected")%> />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Item" Width = "10%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Admission Group" DataField="ItemName">
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Item" Width = "50%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Fee Amount(<span class='rupee'>Rs.</span>)" DataField="Fee" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Item" Width = "20%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Header" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Admission Group ID" DataField="ItemId">
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Hide" Width = "20%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Hide" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Last Payment Date" DataField="LastPaymentDate">
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Hide" Width = "20%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Hide" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Payment Group" DataField="PaymentGroup">
                                <ItemStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Hide" Width = "20%" />
                                <HeaderStyle HorizontalAlign="Center" BorderWidth = "1px" BorderStyle = "Solid" Font-Names="Verdana" CssClass="Hide" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width:45%" align="right">Total Fee</td>
                <td style="width:55%">
                    <asp:Label ID="lblTotalFee" runat="server" Text="0" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <br />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidatePayment" ForeColor="Red"></asp:CustomValidator>
                    <asp:Button ID="btnPayment" runat="server" CssClass="InputButton" Text="Proceed To Payment >>>" onclick="btnPayment_Click"  />
                    <br /><br />
                </td>
            </tr>
        </table>
        <script>
            DisplayTotalFee();
        </script>
    </ccm:ContentBox>
</asp:Content>
