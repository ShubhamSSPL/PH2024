<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="SMSEmailTemplate.aspx.cs" Inherits="Pharmacy2024.AdminModule.SMSEmailTemplate" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="server">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js" integrity="sha256-VazP97ZCwtekAsvgPBSUwPFKdrwD3unUfSGVYrahUqU=" crossorigin="anonymous" type="text/javascript"></script>
    <script type="text/javascript">
        window.history.forward(1);
        function alphabetsOnly(evt) {
            var keyCode = (evt.which) ? evt.which : evt.keyCode;

            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode >= 123) && (keyCode != 32) && (keyCode != 39) && (keyCode != 8)) {
                return false;
            }
            else {
                return true;
            }
        }
        $(document).ready(function () {
            $(".block").draggable({ helper: 'clone' });


            // drag zone 

            $("#shoppingCart").droppable({
                accept: ".block",
                drop: function (ev, ui) {
                    var droppedItem = $(ui.draggable).clone();
                    $(this)[0].children[0].value += droppedItem.context.innerText;
                }
            });
        });
    </script>
    <style runat="server" type="text/css">
        #leftbox {
            width: 150px;
            height: 150px;
            border: 1px solid red;
            float: left;
            margin-left: 10px;
        }

        #rightbox {
            width: 150px;
            height: 150px;
            border: 1px solid black;
            float: left;
            margin-left: 10px;
        }
        .Gridbox {}
        .InputButton {
            margin-left: 150px;
        }
    </style>
    <cc1:ContentBox ID="ContentTable2"   runat="server" HeaderText="SMS Email Template Details" HorizontalAlign="NotSet" Font-Italic="False" Width="100%">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
            <ProgressTemplate>
                <img src="../Images/BigProgress.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div>
            <asp:Label ID="lblmessage" runat="server" Visible="false"></asp:Label>
        </div>
        <table class="AppFormTable">
            <tr>
                <th colspan="4" align="left">Template Details</th>
            </tr>
            <tr>
                <td align="right">Template Name</td>
                <td colspan="3">
                    <asp:TextBox ID="txtname" runat="server" TextMode="SingleLine" onkeypress="return alphabetsOnly(event)"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvtxtname" runat="server" ErrorMessage="Please Enter Template Name." ControlToValidate="txtname" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Template Type</td>
                <td style="width: 25%">
                    <asp:DropDownList ID="ddltemplateType" runat="server">
                        <asp:ListItem Value="0">-- Select Template Type --</asp:ListItem>
                        <asp:ListItem Value="SMS">SMS</asp:ListItem>
                        <asp:ListItem Value="Email">Email</asp:ListItem>
                    </asp:DropDownList>
                    <font color="red"><sup>*</sup></font>
                     <asp:CompareValidator ID="cvTemplateType" runat="server" ControlToValidate="ddltemplateType" Display="None" ErrorMessage="Please Select Template Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td style="width: 25%" align="right">System Name</td>
                <td style="width: 25%">
                    <asp:TextBox ID="txtSystemName" runat="server" TextMode="SingleLine" onkeypress="return alphabetsOnly(event)"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvSystemName" runat="server" ErrorMessage="Please Enter System Name." ControlToValidate="txtSystemName" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="Hid" runat="server" />
        <table class="AppFormTable">
             <tr>
                <th colspan="2" align="left">Message For Selected</th>
            </tr>
            <tr>
                <td style="width:25%;">
                    <div id="shoppingCart">
                        <asp:TextBox ID="txttemplate" class="textbox" runat="server" TextMode="MultiLine" Style="width: 500px; overflow: auto; height: 100px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxttemplate" runat="server" ErrorMessage="Please Enter Message." ControlToValidate="txttemplate" Display="None"></asp:RequiredFieldValidator>
                    </div>
                </td>
                <td style="width:75%;">
                    <div>
                        <asp:DataList ID="dltemplatekey" RepeatDirection="Vertical" runat="server" RepeatColumns="4" BorderStyle="Solid" BorderColor="#CACACA" BorderWidth="1px">
                            <ItemTemplate>
                                
                                <div class="block">
                                    
                                            <%# Eval("Name") %>
                                        
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </td>
            </tr>
        </table>
         <br />
        <br />
        <table class = "AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                     <asp:Button ID="btnsave" runat="server" Text="Save Template" CssClass="InputButton" OnClick="btnsave_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:GridView ID="GridSmsEmailTemplate" runat="server" OnPageIndexChanging="OnPageIndexChanging" AutoGenerateColumns="False"  OnSelectedIndexChanged="OnSelectedIndexChanged" AllowPaging="True" PageSize="5" ValidateRequestMode="Disabled" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="283px" Width="100%">  
            <Columns>  
               
                <asp:TemplateField HeaderText="ID">  
                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                    <ItemTemplate>  
                        <asp:Label  ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField  HeaderText="Name">  
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label>  
                    </ItemTemplate>  
                    
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Template">  
                    <ItemStyle Width="46%" />
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Template" runat="server" Text='<%#Eval("Template") %>'></asp:Label>  
                    </ItemTemplate>  
                    
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Type">  
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Type" runat="server" Text='<%#Eval("Type") %>'></asp:Label>  
                    </ItemTemplate>  
                   
                </asp:TemplateField>  
                 <asp:TemplateField HeaderText="SystemName"> 
                     <ItemStyle HorizontalAlign="Center" Width="15%" />
                    <ItemTemplate>  
                        <asp:Label ID="lbl_SystemName" runat="server" Text='<%#Eval("SystemName") %>'></asp:Label>  
                    </ItemTemplate>  
                    
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Edit">
                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                    <ItemTemplate>
                        <asp:LinkButton Text="Edit" CausesValidation="false" ID="lnkEdit" runat="server" CommandName="select" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>  
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" ForeColor="#ffffff" Font-Bold="True"/>  
            <PagerSettings PageButtonCount="5" />
            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />
            <RowStyle ForeColor="#000066"/>  
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>  
         <br />
         <br />
        <table class="AppFormTable">
            <tr>
                <th colspan="2" align="left">Template Field Details</th>
            </tr>
            <tr>
                <td><asp:Label ID="lblTemplateFiled" runat="server" Text="Template Filed Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtTemplateName" ValidationGroup="TemplateFiled" runat="server" Height="24px"  Width="342px" style="margin-left: 16px"></asp:TextBox>
                    <font color="red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtTemplateName"  ValidationGroup="TemplateFiled" runat="server" ErrorMessage="Please Enter Template Name." ControlToValidate="txtTemplateName" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <asp:Button ID="btnSaveTemplateField" ValidationGroup="TemplateFiled" runat="server" Text="Save Template Field" CssClass="InputButton"  OnClick="btnSaveTemplateField_Click"  Width="162px" />
                    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="TemplateFiled" Runat="server" ShowSummary="False" ShowMessageBox="True"  />
                </td>
            </tr>
        </table>
        <br />
        <br />
    </cc1:ContentBox>
</asp:Content>