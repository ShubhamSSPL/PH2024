<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Pharmacy2024.StaticPages.HomePage" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="Synthesys.Controls.LoginBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
        p {
            line-height: 18px;
            padding: 2px 2px 10px;
            margin: 0;
            font-size: 12px;
            font-family: Verdana;
            color: #000000;
        }

            p a {
                color: #1e5a9c;
                line-height: 18px;
                padding: 5px 5px;
                margin: 0;
                font-size: 12px;
                text-decoration: underline;
            }

                p a:link {
                    color: #A52A2A;
                    line-height: 18px;
                    padding: 5px 5px;
                    margin: 0;
                    font-size: 12px;
                    text-decoration: none;
                }

                p a:visited {
                    color: #A52A2A;
                    line-height: 18px;
                    padding: 5px 5px;
                    margin: 0;
                    font-size: 12px;
                    text-decoration: underline;
                }

                p a:hover {
                    color: #CC3838;
                    line-height: 18px;
                    padding: 5px 5px;
                    width: 100%;
                    margin: 0;
                    font-size: 12px;
                    text-decoration: none;
                }

                p a:active {
                    color: #CC3838;
                    line-height: 18px;
                    padding: 5px 5px;
                    margin: 0;
                    font-size: 12px;
                    text-decoration: underline;
                }

        .AppFormTable th {
            border: 1px solid white;
        }

        .talkbubble {
            position: relative;
        }

            .talkbubble:before {
                content: "";
                position: absolute;
                left: 100%;
                top: 50%;
                transform: translateY(-50%);
                width: 0;
                height: 0;
                border-top: 10px solid transparent;
                border-left: 12px solid #F6223F;
                border-bottom: 10px solid transparent;
            }
    </style>
    <%--ChotBot Script--%>

    <div class="middle-container-home">
        <cc1:ContentBox ID="ContentTable2" runat="server" HeaderVisible="false">
            <div class="middle-content">
                <table id="top3" style="width: 100%; padding: 0 3px; font-size: 13px; font-family: Verdana; border-collapse: collapse; border-width: 0 0 1px 0;">
                    <tr>
                        <td class="talkbubble" style="width: 100px; padding: 4px; height: 20px; background-color: #F6223F; border: 1px solid #F6223F; text-align: center; color: White; font-weight: bold;">IMPORTANT</td>
                        <td style="background-color: rgba(246, 34, 63, 0.05); border: 1px solid #f3a8b3; padding: 5px 0 5px 10px; color: Black;">
                            <div class="important-text">
                                <marquee runat="server" direction="alternate" scrollamount="2" scrolldelay="20" style="padding-left: 30px;" id="scrollerb" onmouseover="javascript:this.stop();" onmouseout="javascript:this.start();"></marquee>
                            </div>
                        </td>
                    </tr>
                </table>
                <br />
                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td align="left">Ongoing Events</td>
                        <td align="right">Click <a href="../StaticPages/frmImportantDates.aspx"><b>HERE</b></a> for Entire Schedule</td>
                    </tr>
                </table>
                <br />
                <table id="tblRegistrationLinks" runat="server" class="AppFormTableWithOutBorder">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnApply" Visible="true" runat="server" Text="New Registration" CssClass="InputButton" OnClick="btnApply_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAlreadyRegistered" Visible="true" runat="server" Text="Already Registered" CssClass="InputButton" OnClick="btnAlreadyRegistered_Click" />
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="gvImportantDates" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="DataGrid">
                    <Columns>
                        <asp:BoundField DataField="ActivityDetails" HeaderText="Activity" HtmlEncode="false">
                            <ItemStyle HorizontalAlign="Justify" Font-Size="11px" CssClass="Item" Width="75%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="11px" CssClass="Header" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Schedule" HeaderText="Schedule" HtmlEncode="false">
                            <ItemStyle HorizontalAlign="Center" Font-Size="11px" CssClass="Item" Width="25%" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="11px" CssClass="Header" Wrap="false" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>

                <br />

                <cc1:ContentBox ID="ContentBox4" runat="server" HeaderText="Final Merit List 2024-25">
                    <div class="middle-content">
                         <table class="AppFormTable table-responsive">
                             <tr>
                                <td align="center">
                                    <a href="<%=URL %>MeritListFiles/Final/PH2024_MH_MeritList_Final.pdf" target="_blank">Maharashtra State Merit List</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>MeritListFiles/Final/PH2024_AI_MeritList_Final.pdf" target="_blank">All India Merit List</a>
                                </td> 
                            </tr>
                        </table>
                    </div>
                </cc1:ContentBox>

                <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Provisional Merit List 2024-25" HorizontalAlign="Center">
                    <div class="middle-content">
                         <table class="AppFormTable table-responsive">
                             <tr>
                                <td align="center" >
                                    <a href="<%=URL %>MeritListFiles/Provisional/PH2024_MH_MeritList_Provisional.pdf" target="_blank">Maharashtra State Merit List</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>MeritListFiles/Provisional/PH2024_AI_MeritList_Provisional.pdf" target="_blank">All India Merit List</a>
                                </td> 
                            </tr>
                        </table>
                    </div>
                </cc1:ContentBox>

                <table class="AppFormTableWithOutBorder">
                    <tr>
                        <td style="width: 33%;">
                            <div class="row w-100 mx-auto">
                                <div class="col-sm-4 mb-2">
                                    <div class="card homepage" data-aos="zoom-out" data-aos-duration="3000">
                                        <div class="card-header1">
                                            <asp:Label ID="lblPanel2" runat="server" CssClass="news"></asp:Label>
                                        </div>
                                        <div class="card-body">
                                            <marquee align="justify" direction="up" onmouseout="this.start()" height="200px" onmouseover="this.stop()" scrollamount="1" scrolldelay="60" id="panel2" runat="server"></marquee>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4 mb-2">
                                    <div class="card homepage" data-aos="zoom-out" data-aos-duration="3000">
                                        <div class="card-header1">
                                            <asp:Label ID="lblPanel3" runat="server" CssClass="notification"></asp:Label>
                                        </div>
                                        <div class="card-body">
                                            <marquee align="justify" direction="up" onmouseout="this.start()" height="200px" onmouseover="this.stop()" scrollamount="1" scrolldelay="60" id="panel3" runat="server"></marquee>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4 mb-2">
                                    <div class="card homepage" data-aos="zoom-out" data-aos-duration="3000">
                                        <div class="card-header1">
                                            <asp:Label ID="lblPanel5" runat="server" CssClass="download"></asp:Label>
                                        </div>
                                        <div class="card-body">
                                            <marquee align="justify" direction="up" onmouseout="this.start()" height="200px" onmouseover="this.stop()" scrollamount="1" scrolldelay="60" id="panel5" runat="server"></marquee>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <br />

                <cc1:ContentBox ID="ContentBox1" runat="server" Visible="false">
                    <div class="middle-content">
                        <table class="AppFormTable table-responsive">
                            <tr>
                                <th style="width: 13%; text-align: center;" align="center" colspan="3" rowspan="1">CAP Round-I Cut Off                       
                                </th>
                                <th style="width: 13%; text-align: center;" align="center" colspan="3" rowspan="1">CAP Round-II Cut Off                        
                                </th>
                                <%-- <th style="width: 13%" align="center" colspan="4" rowspan="1">CAP Round-III Cut Off                       
                                </th>--%>
                                <%-- <th style = "width:18%" align="center" colspan="3" rowspan="1">
                                    CAP Round-Additional Cut Off                    
                                </th>--%>
                            </tr>
                            <tr>
                                <th align="center" style="text-align: center;">Seat Matrix</th>
                                <th align="center" style="text-align: center;"><b>MH </b></th>
                                <th align="center" style="text-align: center;"><b>AI </b></th>
                                <th align="center" style="text-align: center;">Vacancy</th>
                                <th align="center" style="text-align: center;"><b>MH </b></th>
                                <th align="center" style="text-align: center;"><b>AI </b></th>
                                <%--      <th align="center">Vacancy</th>
                                <th align="center"><b>MH </b></th>
                                <th align="center"><b>AI </b></th>--%>
                                <%--   <th align="center"><b>Diploma </b></th>--%>
                                <%--<th align="center"> Vacancy</th>
                                <th align="center" ><b>MH </b></th>
                                <th align="center" ><b>AI </b></th>--%>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href="<%=URL %>viewpublicdocument.aspx?menuid=1274" target="_blank">View</a>
                                </td>

                                <td align="center">

                                    <a href="<%=URL %>viewpublicdocument.aspx?menuid=1272" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>viewpublicdocument.aspx?menuid=1273" target="_blank">View</a>
                                </td>


                                <td align="center">
                                    <a href="<%=URL %>viewpublicdocument.aspx?menuid=1277" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>viewpublicdocument.aspx?menuid=1386" target="_blank">View</a>
                                </td>

                                <td align="center">
                                    <a href="<%=URL %>viewpublicdocument.aspx?menuid=1387" target="_blank">View</a>
                                </td>
                                <%-- <td align="center">
                                    <a href="<%=URL %>viewpublicdocument.aspx?menuid=1362" target="_blank">View</a>-
                                </td>--%>
                                <%--    <td align="center">
                                    <a href="<%=URL %>viewpublicdocument.aspx?menuid=3483" target="_blank">View</a>-
                                </td>

                                <td align="center">
                                     <a href="<%=URL %>viewpublicdocument.aspx?menuid=3484" target="_blank">View</a>-
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>viewpublicdocument.aspx?menuid=3485" target="_blank">View</a>-
                                </td>--%>
                                <%-- <td align="center">
                                  <b>-</b> 
                                     <a  href="<%=URL %>2017/2017ENGG_CAP4_AI_CutOff.pdf" target="_blank">View</a> 
                                </td>
                                  <td align="center">
                                  <b>-</b> 
                                    <a  href="<%=URL %>2017/2017ENGG_CAP4_AI_CutOff.pdf" target="_blank">View</a> 
                                </td>
                                  <td align="center">
                                   
                                   <a  href="<%=URL %>2017/2017ENGG_CAP4_AI_CutOff.pdf" target="_blank">View</a>
                                </td>--%>
                            </tr>
                            <tr>

                                <td colspan="2" align="center">
                                    <%if (IsDisplayProvisionalMeritList == 1)
                                        { %>

                                    <a href="<%=URL %>StaticPages/frmCheckProvisionalMeritStatus.aspx" target="_blank">Provisional Merit Status</a>
                                    <%} %>
                                    <%else
                                        {%>
                                    
                                    -
                                    <%} %>
                                </td>

                                <td colspan="2" align="center">
                                    <%if (IsDisplayFinalMeritList == 1)
                                        {%>
                                    <a href="<%=URL %>StaticPages/frmCheckFinalMeritStatus.aspx" target="_blank">Final Merit Status</a> <%} %>
                                    <%else
                                        { %>
                                    - <%} %>
                                </td>
                                <%--<td colspan="4" align="center">- <a  href="<%=url %>staticpages/frminstitutewiseallotmentlist.aspx" target="_blank">institute allotted list</a>
                                </td>--%>
                                <td colspan="2" align="center">
                                    <a href="<%=URL %>staticpages/frminstitutewiseallotmentlist.aspx" target="_blank">Institute Wise Allotment List</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </cc1:ContentBox>

                <cc1:ContentBox ID="ContentBox3" runat="server" HeaderText="Seat Matrix and Cut Off Lists of CAP Round for Previous Years">
                    <div class="middle-content">
                        <table class="AppFormTable  table-responsive">
                            <tr>
                                <th style="width: 13%; text-align: center;" align="center" colspan="1" rowspan="2">Year                          
                                </th>
                                <th style="width: 13%; text-align: center;" align="center" colspan="1" rowspan="2">Seat Matrix                          
                                </th>
                                <th style="width: 13%; text-align: center;" align="center" colspan="2" rowspan="1">CAP Round-I Cut Off                       
                                </th>
                                <th style="width: 13%; text-align: center;" align="center" colspan="2" rowspan="1">CAP Round-II Cut Off                        
                                </th>
                                <th style="width: 13%; text-align: center;" align="center" colspan="2" rowspan="1">CAP Round-III Cut Off                       
                                </th>
                                <%-- <th style="width: 18%; text-align: center;" align="center" colspan="2" rowspan="1">CAP Round-Additional Cut Off                    
                                </th>--%>
                            </tr>
                            <tr>
                                <th align="center" style="text-align: center;"><b>MH </b></th>
                                <th align="center" style="text-align: center;"><b>AI </b></th>
                                <th align="center" style="text-align: center;"><b>MH </b></th>
                                <th align="center" style="text-align: center;"><b>AI </b></th>
                                <th align="center" style="text-align: center;"><b>MH </b></th>
                                <th align="center" style="text-align: center;"><b>AI </b></th>
                                <%--  <th align="center" style="text-align: center;"><b>MH </b></th>
                                <th align="center" style="text-align: center;"><b>AI </b></th>--%>
                            </tr>
                            <%-- <tr>
                                <td align="center">2017-18
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2017/2017SeatMatrix.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2017/2017PHARMA_CAP1_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2017/2017PHARMA_CAP1_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2017/2017PHARMA_CAP2_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2017/2017PHARMA_CAP2_AI_CutOff.pdf" target="_blank">View</a>
                                </td>

                                <td align="center">
                                    <a href="<%=URL %>2017/2017PHARMA_CAP3_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2017/2017PHARMA_CAP3_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2017/2017PHARMA_CAP4_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2017/2017PHARMA_CAP4_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                            </tr>--%>
                            <%--<tr>
                                <td align="center">2018-19
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2018/2018SeatMatrix.pdf" target="_blank">View</a>
                                </td>

                                <td align="center">
                                    <a href="<%=URL %>2018/2018PHARMA_CAP1_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2018/2018PHARMA_CAP1_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2018/2018PHARMA_CAP2_CutOff_v3.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2018/2018PHARMA_CAP2_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2018/2018PHARMA_CAP3_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2018/2018PHARMA_CAP3_AI_CutOff.pdf" target="_blank">View</a>
                                </td> 
                                <td align="center">
                                    <a href="<%=URL %>2018/2018PHARMA_CAP4_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2018/2018PHARMA_CAP4_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center">2019-20
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2019/2019SeatMatrix.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2019/2019PHARMA_CAP1_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2019/2019PHARMA_CAP1_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2019/2019PHARMA_CAP2_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2019/2019PHARMA_CAP2_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2019/2019PHARMA_CAP3_CutOff.pdf" target="_blank">View</a>
                                </td>

                                <td align="center">
                                    <a href="<%=URL %>2019/2019PHARMA_CAP3_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <%-- <td align="center">- </td>
                                <td align="center">- </td>--%>
                            </tr>
                            <tr>
                                <td align="center">2020-21
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2020/2020SeatMatrix.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2020/2020PHARMA_CAP1_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2020/2020PHARMA_CAP1_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2020/2020PHARMA_CAP2_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2020/2020PHARMA_CAP2_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">- </td>
                                <td align="center">- </td>
                                <%-- <td align="center">- </td>
                                <td align="center">- </td>--%>
                            </tr>

                            <tr>
                                <td align="center">2021-22
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2021/2021SeatMatrix.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2021/2021PHARMA_CAP1_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2021/2021PHARMA_CAP1_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2021/2021PHARMA_CAP2_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2021/2021PHARMA_CAP2_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">- </td>
                                <td align="center">- </td>
                                <%-- <td align="center">- </td>
                                <td align="center">- </td>--%>
                            </tr>
                            <tr>
                                <td align="center">2022-23
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2022/2022SeatMatrix.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2022/2022PHARMA_CAP1_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2022/2022PHARMA_CAP1_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2022/2022PHARMA_CAP2_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2022/2022PHARMA_CAP2_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2022/2022PHARMA_CAP3_CutOff.pdf" target="_blank">View</a>
                                </td>

                                <td align="center">
                                    <a href="<%=URL %>2022/2022PHARMA_CAP3_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <%-- <td align="center">- </td>
                                <td align="center">- </td>--%>
                            </tr>














                            

                            <tr>
                                <td align="center">2023-24
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2023/2023SeatMatrix.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2023/2023PHARMA_CAP1_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2023/2023PHARMA_CAP1_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2023/2023PHARMA_CAP2_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2023/2023PHARMA_CAP2_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <td align="center">
                                    <a href="<%=URL %>2023/2023PHARMA_CAP3_CutOff.pdf" target="_blank">View</a>
                                </td>

                                <td align="center">
                                    <a href="<%=URL %>2023/2023PHARMA_CAP3_AI_CutOff.pdf" target="_blank">View</a>
                                </td>
                                <%-- <td align="center">- </td>
                                <td align="center">- </td>--%>
                            </tr>
                        </table>
                    </div>
                </cc1:ContentBox>
                <br />
            </div>
        </cc1:ContentBox>
    </div>
</asp:Content>


