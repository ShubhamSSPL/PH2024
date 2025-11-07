<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmAllOthersCandidateList.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmAllOthersCandidateList" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <asp:UpdateProgress runat="server" id="PageUpdateProgress">
        <ProgressTemplate>
            <img src ="../Images/BigProgress.gif" alt = "" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="upAddress">
        <ContentTemplate>
            <cc1:ContentBox ID="ContentTable1" runat="server">
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td>
                            <p align = "justify"><font color = "red"><b>Note :</b> In case of Children of NRI/OCI/PIO, CIWGC, FN Candidates, after registration & confirmation of their application at SC shall approach directly to the Institute for admission where such quota is granted by the appropriate authority.</font></p>
                    <p align = "justify"><font color = "red">As per Information Brochure rule 3(4) (b) Supernumerary Seats for OCI/ PIO,
                        Foreign Students and the Children of Indian Workers in Gulf Countries
                        Candidates -For these seats the candidates shall initially apply to the
                        Competent Authority for verification of documents and then to respective
                        institutes, to enable the institutions to give admissions to such eligible
                        applicants on the basis of inter-se merit. It is pre-requisite and mandatory to
                        apply for verification of documents to the Competent Authority to be eligible
                        for admission under this quota.</font></p>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            Select Candidature Type : 
                            <asp:DropDownList ID="ddlCandidatureType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCandidatureType_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                <asp:ListItem Value="1">NRI</asp:ListItem>
                                <asp:ListItem Value="2">OCI/PIO</asp:ListItem>
                                <asp:ListItem Value="3">CIWGC</asp:ListItem>
                                <asp:ListItem Value="4">Foreign Students</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" CssClass = "DataGrid">
                    <Columns> 
                        <asp:BoundField DataField = "SrNo" HeaderText="Sr. No.">
                            <ItemStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Item" Width = "8%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField = "ApplicationID" HeaderText = "Application ID">
                            <ItemStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Item" Width = "10%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField = "CandidateName" HeaderText = "Candidate Name">
                            <ItemStyle HorizontalAlign="Left" Font-Size = "10px" CssClass = "Item" Width = "20%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField = "CandidatureType" HeaderText = "Candidature Type">
                            <ItemStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Item" Width = "17%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField = "EligibilityPercentage" HeaderText = "Eligibility %">
                            <ItemStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Item" Width = "10%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField = "HSCMBMAXPercentage" HeaderText = " (HSC MB Max %)">
                            <ItemStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Item" Width = "10%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>
                        <%--<asp:BoundField DataField = "HSCSubjectPercentage" HeaderText = "HSC Subject % %">
                            <ItemStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Item" Width = "10%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>--%>
                        <asp:BoundField DataField = "HSCPhysicsPercentage" HeaderText = "HSC Physics %">
                            <ItemStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Item" Width = "10%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField = "HSCTotalPercentage" HeaderText = "HSC Total %">
                            <ItemStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Item" Width = "10%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField = "ApplicationStatus" HeaderText = "Confirmed by SC">
                            <ItemStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Item" Width = "15%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField = "ConfirmedDateTime" HeaderText = "Confirmed On">
                            <ItemStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Item" Width = "30%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size = "10px" CssClass = "Header" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td>
                            <p align = "justify"><font color = "red"><b>Eligibility % :</b> The candidate should have passed the HSC or its equivalent examination with Physics and Mathematics as compulsory subjects along with one of the Chemistry or Biotechnology or Biology or Technical Vocational subjects, and obtained at least 45% marks in the above subjects taken together.</font></p>
                            <p align = "justify"><font color = "red"><b>Merit % :</b> Percentage of marks in the subjects Physics, Chemistry and Mathematics added together at HSC (In case of Diploma, Diploma %).</font></p>
                        </td>
                    </tr>
                </table>
            </cc1:ContentBox>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
