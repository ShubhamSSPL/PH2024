<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPage.Master" AutoEventWireup="true" CodeBehind="frmFAQs.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmFAQs" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <script src="../Scripts/jquery-1.11.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        .tooltip
        {
            display: none;
            position: absolute;
            border: 1px solid #333;
            background-color: #161616;
            border-radius: 5px;
            padding: 10px;
            color: #fff;
            font-size: 12px Arial;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.accordion-title, .question').on('click', function () {
                $(this).parent().toggleClass('onn');
            });

            $('.tooltip').hover(function () {
                var title = $(this).attr('title');
                $(this).data('tipText', title).removeAttr('title');
                $('<p class="tooltip"></p>').text(title).appendTo('body').fadeIn('slow');
            }, function () {
                $(this).attr('title', $(this).data('tipText'));
                $('.tooltip').remove();
            }).mousemove(function (e) {
                var mousex = e.pageX + 20;
                var mousey = e.pageY + 10;
                $('.tooltip')
        .css({ top: mousey, left: mousex })
            });
        });
    </script>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="FAQs">
        <asp:Repeater ID="SectionRepeater" runat="server" OnItemDataBound="SectionRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="accordion-item onn">
                    <div class="accordion-title">
                        <span title="click to view or hide <%#DataBinder.Eval(Container.DataItem,"SectionName")%> FAQ"><%#DataBinder.Eval(Container.DataItem,"SectionName")%></span> 
                    </div>
                    <asp:Repeater ID="QuestionRepeater" runat="server">
                        <HeaderTemplate>
                            <div class="accordion-body">
                                <div class="holder">
                                    <div class="qa-holder">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="qa onn">
                                <div class="question">
                                    <span class="sr" title="click to view or hide answer">Q.</span>
                                    <%#DataBinder.Eval(Container.DataItem, "Question")%>
                                </div>
                                <div class="answer">
                                    <span class="sr"><%#DataBinder.Eval(Container.DataItem, "AnswerSR")%></span>
                                    <%#DataBinder.Eval(Container.DataItem, "Answer")%>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div></div></div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </cc1:ContentBox>
</asp:Content>
