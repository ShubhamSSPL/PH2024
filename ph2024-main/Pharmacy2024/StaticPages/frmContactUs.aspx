<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmContactUs.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmContactUs" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" Runat="Server">
    <style>
          /*@media only screen and (max-width: 320px) {
            #layoutSidenav {
                margin-top: 61.5% !important;
            }
        }
        @media (max-width: 425px) and (min-width:321px) {
            #layoutSidenav {
                margin-top: 45% !important;
            }
        }*/
        @media only screen and (max-width: 768px) {
            #layoutSidenav {
                margin-left: 225px;
              
            }    
        }
        .sb-nav-fixed #layoutSidenav #layoutSidenav_content {
           /* padding-left: 0px;*/
            top: 177px;
            }
        }
    </style>
    <cc1:ContentBox ID="ContentTable1" runat="server" HeaderText="Contact Us">
        <table class = "AppFormTableWithOutBorder">
		    <%--<tr>
                <td><font size="2"><b>HEAD OFFICE</b></font></td>
            </tr>
            <tr>
                <td><b>Address : </b>305, Government Polytechnic Building, 49 Kherwadi, Ali Yawar Jung Marg, Bandra (E), Mumbai - 400 051(M.S.)</td>
            </tr>
            <tr>
                <td><b>Phone : </b>022 – 2647 6034 / 2647 6037 / 26473719</td>
            </tr>
            <tr>
                <td><b>E-Mail : </b>maharashtra.cetcell@gmail.com</td>
            </tr>
            <tr>
                <td><b>Website : </b>www.mahacet.org/cetcell</td>
            </tr>
            <tr><td></td></tr>
            <tr><td></td></tr>
            <tr><td></td></tr>--%>
           <%-- <tr>
                <td><font size="2"><b>CET CELL</b></font></td>
            </tr>--%>
            <tr>
               <tr>
               <td><b>Address : </b>State Common Entrance Test Cell, Maharashtra State, <br />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;8th Floor, New Excelsior Building, A.K.Nayak Marg, Fort, Mumbai-400001. (M.S.)</td>
           </tr>
            </tr>
          <%--  <tr>
                <td><b>Phone : </b>022-2016157 / 59 / 53/ 34 / 19 / 28</td>
            </tr>--%>
           <%-- <tr>
                <td><b>Techanical Helpline Number (10:00 AM to 06:00 PM) </b>: +91-9175108612, 18002660160  </td>
            </tr>--%>
            <%--<tr>
                <td><b>Fax No : </b>--</td>
            </tr>--%>
            <tr>
              <%--  <td><b>E-Mail : </b>ph23.mahacet@gmail.com</td>--%>
            </tr>
             <tr>
               <td><b>Website : </b> <a href="http://www.mahacet.org" target="_blank">http://www.mahacet.org</a></td>
           </tr>
		</table>
    </cc1:ContentBox>
</asp:Content>
