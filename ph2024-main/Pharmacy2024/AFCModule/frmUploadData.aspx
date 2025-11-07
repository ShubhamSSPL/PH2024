<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPage.Master" AutoEventWireup="true" CodeBehind="frmUploadData.aspx.cs" Inherits="Pharmacy2024.AFCModule.frmUploadData" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
        var validFilesTypes = ["mdb", "accdb", "xls", "xlsx", "csv"];
        function ValidateFile(sender, args) {
            var file = document.getElementById("<%=fileUpload.ClientID%>");
            var path = file.value;
            var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
            var isValidFile = false;
            for (var i = 0; i < validFilesTypes.length; i++) {
                if (ext == validFilesTypes[i]) {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile) {
                args.IsValid = false;
            }
        }
    </script>
    <cc1:ContentBox runat="server" ID="cbUploadFile" HeaderText="Upload File">
        <asp:UpdatePanel runat="server" ID="uPanelUploadFile" UpdateMode="Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
            </Triggers>
            <ContentTemplate>
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td>
                            <font color="red">
                                <ol class="list-text">
                                    <b>Instructions :</b><br />
                                    <br />
                                    <li>
                                        <p align="justify"><font color="red">Please select the File which you want to upload.</font></p>
                                    </li>
                                    <li>
                                        <p align="justify"><font color="red">Please upload a File with Extension .mdb, .accdb, .xls, .xlsx and .csv.</font></p>
                                    </li>
                                </ol>
                            </font>
                        </td>
                    </tr>
                </table>
                <br />
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 30%" align="right">Select File Path</td>
                        <td style="width: 40%">
                            <asp:FileUpload ID="fileUpload" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvFileUpload" runat="server" ControlToValidate="fileUpload" ErrorMessage="Please Select File Path." Display="None" ValidationGroup="UploadFile"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 30%; border-left-width: 0px;">
                            <asp:Button ID="btnUpload" CssClass="InputButtonRed" runat="server" Text="Upload File" OnClick="btnUpload_Click" ValidationGroup="UploadFile" />
                            <asp:CustomValidator ID="cvValidateFile" runat="server" ClientValidationFunction="ValidateFile" Display="None" ErrorMessage="Invalid File. Please upload a File with Extension .mdb, .accdb, .xls, .xlsx and .csv." ValidationGroup="UploadFile"></asp:CustomValidator>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True" ValidationGroup="UploadFile" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
    <br />
    <cc1:ContentBox runat="server" ID="ContentBox1" HeaderText="Upload Data">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">
                        <ol class="list-text">
                            <b>Steps to Upload Data :</b><br />
                            <br />
                            <li>
                                <p align="justify"><font color="red">Select Source File Type first. A list of all the Files under that File Type will be displayed.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">After that, Select Source File Name of which data you want to upload.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">After that, Select Source Table Name of which data you want to upload.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">After that, Select Destination Table Name to which you want to upload data.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">If Destination Table does not exists, then select [New Table] as Destination Table.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">After that, map the Source Table Columns and Destination Table Columns.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">If you don't want to map any specific Source Table Column, then don't select Destination Table Column.</font></p>
                            </li>
                            <li>
                                <p align="justify"><font color="red">After that, Click on 'Upload Data' Button.</font></p>
                            </li>
                        </ol>
                    </font>
                </td>
            </tr>
        </table>
        <br />
        <asp:UpdateProgress runat="server" ID="uProgressUploadFile">
            <ProgressTemplate>
                <br />
                <center>
                    <img src="../Images/loading6.gif" alt="" /></center>
                <br />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="upFiles">
            <ContentTemplate>
                <table class="AppFormTable">
                    <tr>
                        <td style="width: 30%" align="right">Select Source File Type</td>
                        <td style="width: 70%">
                            <asp:DropDownList ID="ddlSourceFileType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSourceFileType_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value=".mdb">.mdb</asp:ListItem>
                                <asp:ListItem Value=".accdb">.accdb</asp:ListItem>
                                <asp:ListItem Value=".xls">.xls</asp:ListItem>
                                <asp:ListItem Value=".xlsx">.xlsx</asp:ListItem>
                                <asp:ListItem Value=".csv">.csv</asp:ListItem>
                            </asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvSourceFileType" runat="server" ControlToValidate="ddlSourceFileType" Display="None" ErrorMessage="Please Select Source File Type." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Select Source File Name</td>
                        <td>
                            <asp:DropDownList ID="ddlSourceFileName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSourceFileName_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvSourceFileName" runat="server" ControlToValidate="ddlSourceFileName" Display="None" ErrorMessage="Please Select Source File Name." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Select Source Table Name</td>
                        <td>
                            <asp:DropDownList ID="ddlSourceTableName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSourceTableName_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvSourceTableName" runat="server" ControlToValidate="ddlSourceTableName" Display="None" ErrorMessage="Please Select Source Table Name." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Select Destination Table Name</td>
                        <td>
                            <asp:DropDownList ID="ddlDestinationTableName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDestinationTableName_SelectedIndexChanged"></asp:DropDownList>
                            <font color="red"><sup>*</sup></font>
                            <asp:CompareValidator ID="cvDestinationTableName" runat="server" ControlToValidate="ddlDestinationTableName" Display="None" ErrorMessage="Please Select Destination Table Name." Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                <table class="AppFormTable" id="tblColumnsList" runat="server">
                    <tr>
                        <th style="width: 50%; border-top-width: 0px;">Source Table Columns List</th>
                        <th style="width: 50%; border-top-width: 0px;">Destination Table Columns List</th>
                    </tr>
                </table>
                <br />
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnUploadData" CssClass="InputButton" runat="server" Text="Upload Data" OnClick="btnUploadData_Click" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="False" ShowMessageBox="True" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </cc1:ContentBox>
</asp:Content>
