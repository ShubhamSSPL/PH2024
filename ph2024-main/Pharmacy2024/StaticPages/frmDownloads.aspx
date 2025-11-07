<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaticMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmDownloads.aspx.cs" Inherits="Pharmacy2024.StaticPages.frmDownloads" %>
<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContainer" runat="Server">
    <style>
         /* @media only screen and (max-width: 320px) {
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
    </style>
    <cc1:ContentBox runat="server" ID="cb" HeaderText="Downloads">
        <table id="tblLinks" runat="server" class="AppFormTableWithOutBorder"></table>
    </cc1:ContentBox> 
</asp:Content>
