<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DynamicMasterPageSB.Master" AutoEventWireup="true" CodeBehind="frmEditCourseInformation.aspx.cs" Inherits="Pharmacy2024.InstituteModule.frmEditCourseInformation" %>

<%@ Register Assembly="Synthesys.Controls.ContentBox" Namespace="Synthesys.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightContainer" Runat="Server">
     <style>
        .txtAlign 
        { 
            text-align:center; 
        }
    </style>
    <script language="javascript" type = "text/javascript">
        window.history.forward(1);
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false
                }
            }
        }
        function Summation() {
            var subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_GOPENH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GOPENH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSCH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSCH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSTH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSTH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GVJH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GVJH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT1H").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT1H").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT2H").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT2H").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT3H").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT3H").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GOBCH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GOBCH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSEBCH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSEBCH").value);
            document.getElementById("rightContainer_ContentBox2_TOTALGH").value = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_LOPENH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LOPENH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSCH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSCH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSTH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSTH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LVJH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LVJH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT1H").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT1H").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT2H").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT2H").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT3H").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT3H").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LOBCH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LOBCH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSEBCH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSEBCH").value);
            document.getElementById("rightContainer_ContentBox2_TOTALLH").value = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSCH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSCH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSTH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSTH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCVJH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCVJH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT1H").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT1H").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT2H").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT2H").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT3H").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT3H").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCOBCH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCOBCH").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSEBCH").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSEBCH").value);
            document.getElementById("rightContainer_ContentBox2_TOTALPHCH").value = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_GOPENO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GOPENO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSCO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSTO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSTO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GVJO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GVJO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT1O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT1O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT2O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT2O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GNT3O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GNT3O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GOBCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GOBCO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_GSEBCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_GSEBCO").value);
            document.getElementById("rightContainer_ContentBox2_TOTALGO").value = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_LOPENO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LOPENO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSCO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSTO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSTO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LVJO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LVJO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT1O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT1O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT2O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT2O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LNT3O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LNT3O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LOBCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LOBCO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_LSEBCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_LSEBCO").value);
            document.getElementById("rightContainer_ContentBox2_TOTALLO").value = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSCO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSTO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSTO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCVJO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCVJO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT1O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT1O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT2O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT2O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCNT3O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCNT3O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCOBCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCOBCO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_PHCSEBCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_PHCSEBCO").value);
            document.getElementById("rightContainer_ContentBox2_TOTALPHCO").value = subResult;

            subResult = 0;
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFSCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFSCO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFSTO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFSTO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFVJO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFVJO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFNT1O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFNT1O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFNT2O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFNT2O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFNT3O").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFNT3O").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFOBCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFOBCO").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_DEFSEBCO").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_DEFSEBCO").value);
            // subResult += (document.getElementById("ctl00_rightContainer_ContentBox2_EWS").value == "") ? 0 : parseInt(document.getElementById("ctl00_rightContainer_ContentBox2_EWS").value);
            subResult += (document.getElementById("rightContainer_ContentBox2_ORPHAN").value == "") ? 0 : parseInt(document.getElementById("rightContainer_ContentBox2_ORPHAN").value);
            document.getElementById("rightContainer_ContentBox2_TOTALDEFO").value = subResult;
        }
        function checkTotalIntake(sender, args) {
            var TotalIntake = document.getElementById("rightContainer_ContentBox1_txtTotalIntake").value;
            var CAPIntake = document.getElementById("rightContainer_ContentBox1_txtCAPIntake").value;
            var ILIntake = document.getElementById("rightContainer_ContentBox1_txtILIntake").value;
            var MIIntake = document.getElementById("rightContainer_ContentBox1_txtMIIntake").value;

            if (parseFloat(TotalIntake) != (parseFloat(CAPIntake) + parseFloat(ILIntake) + parseFloat(MIIntake))) {
                args.IsValid = false;
            }
        }
        function checkCAPIntake(sender, args) {
            var CAPIntake = document.getElementById("rightContainer_ContentBox1_txtCAPIntake").value;
            var MSIntake = document.getElementById("rightContainer_ContentBox1_txtMSIntake").value;
            var AIIntake = document.getElementById("rightContainer_ContentBox1_txtAIIntake").value;

            if (parseFloat(CAPIntake) != (parseFloat(MSIntake) + parseFloat(AIIntake))) {
                args.IsValid = false;
            }
        }
        function checkMSIntake(sender, args) {
            var MSIntake = document.getElementById("rightContainer_ContentBox1_txtMSIntake").value;
            var TOTALGH = document.getElementById("rightContainer_ContentBox2_TOTALGH").value;
            var TOTALLH = document.getElementById("rightContainer_ContentBox2_TOTALLH").value;
            var TOTALPHCH = document.getElementById("rightContainer_ContentBox2_TOTALPHCH").value;
            var TOTALGO = document.getElementById("rightContainer_ContentBox2_TOTALGO").value;
            var TOTALLO = document.getElementById("rightContainer_ContentBox2_TOTALLO").value;
            var TOTALPHCO = document.getElementById("rightContainer_ContentBox2_TOTALPHCO").value;
            var TOTALDEFO = document.getElementById("rightContainer_ContentBox2_TOTALDEFO").value;

            if (parseFloat(MSIntake) != (parseFloat(TOTALGH) + parseFloat(TOTALLH) + parseFloat(TOTALPHCH) + parseFloat(TOTALGO) + parseFloat(TOTALLO) + parseFloat(TOTALPHCO) + parseFloat(TOTALDEFO))) {
                args.IsValid = false;
            }
        }

        function InitializeClear() {

            document.getElementById("rightContainer_ContentBox2_GOPENH").value = GOPENH;
            document.getElementById("rightContainer_ContentBox2_GSCH").value = GSCH;
            document.getElementById("rightContainer_ContentBox2_GSTH").value = GSTH;
            document.getElementById("rightContainer_ContentBox2_GVJH").value = GVJH;
            document.getElementById("rightContainer_ContentBox2_GNT1H").value = GNT1H;
            document.getElementById("rightContainer_ContentBox2_GNT2H").value = GNT2H;
            document.getElementById("rightContainer_ContentBox2_GNT3H").value = GNT3H;
            document.getElementById("rightContainer_ContentBox2_GOBCH").value = GOBCH;
            document.getElementById("rightContainer_ContentBox2_GSEBCH").value = GSEBCH;
            document.getElementById("rightContainer_ContentBox2_TOTALGH").value = TOTALGH;

            document.getElementById("rightContainer_ContentBox2_LOPENH").value = LOPENH;
            document.getElementById("rightContainer_ContentBox2_LSCH").value = LSCH;
            document.getElementById("rightContainer_ContentBox2_LSTH").value = LSTH;
            document.getElementById("rightContainer_ContentBox2_LVJH").value = LVJH;
            document.getElementById("rightContainer_ContentBox2_LNT1H").value = LNT1H;
            document.getElementById("rightContainer_ContentBox2_LNT2H").value = LNT2H;
            document.getElementById("rightContainer_ContentBox2_LNT3H").value = LNT3H;
            document.getElementById("rightContainer_ContentBox2_LOBCH").value = LOBCH;
            document.getElementById("rightContainer_ContentBox2_LSEBCH").value = LSEBCH;
            document.getElementById("rightContainer_ContentBox2_TOTALLH").value = TOTALLH;

            document.getElementById("rightContainer_ContentBox2_PHCH").value = PHCH;
            document.getElementById("rightContainer_ContentBox2_PHCSCH").value = PHCSCH;
            document.getElementById("rightContainer_ContentBox2_PHCSTH").value = PHCSTH;
            document.getElementById("rightContainer_ContentBox2_PHCVJH").value = PHCVJH;
            document.getElementById("rightContainer_ContentBox2_PHCNT1H").value = PHCNT1H;
            document.getElementById("rightContainer_ContentBox2_PHCNT2H").value = PHCNT2H;
            document.getElementById("rightContainer_ContentBox2_PHCNT3H").value = PHCNT3H;
            document.getElementById("rightContainer_ContentBox2_PHCOBCH").value = PHCOBCH;
            document.getElementById("rightContainer_ContentBox2_PHCSEBCH").value = PHCSEBCH;
            document.getElementById("rightContainer_ContentBox2_TOTALPHCH").value = TOTALPHCH;

            document.getElementById("rightContainer_ContentBox2_GOPENO").value = GOPENO;
            document.getElementById("rightContainer_ContentBox2_GSCO").value = GSCO;
            document.getElementById("rightContainer_ContentBox2_GSTO").value = GSTO;
            document.getElementById("rightContainer_ContentBox2_GVJO").value = GVJO;
            document.getElementById("rightContainer_ContentBox2_GNT1O").value = GNT1O;
            document.getElementById("rightContainer_ContentBox2_GNT2O").value = GNT2O;
            document.getElementById("rightContainer_ContentBox2_GNT3O").value = GNT3O;
            document.getElementById("rightContainer_ContentBox2_GOBCO").value = GOBCO;
            document.getElementById("rightContainer_ContentBox2_GSEBCO").value = GSEBCO;
            document.getElementById("rightContainer_ContentBox2_TOTALGO").value = TOTALGO;

            document.getElementById("rightContainer_ContentBox2_LOPENO").value = LOPENO;
            document.getElementById("rightContainer_ContentBox2_LSCO").value = LSCO;
            document.getElementById("rightContainer_ContentBox2_LSTO").value = LSTO;
            document.getElementById("rightContainer_ContentBox2_LVJO").value = LVJO;
            document.getElementById("rightContainer_ContentBox2_LNT1O").value = LNT1O;
            document.getElementById("rightContainer_ContentBox2_LNT2O").value = LNT2O;
            document.getElementById("rightContainer_ContentBox2_LNT3O").value = LNT3O;
            document.getElementById("rightContainer_ContentBox2_LOBCO").value = LOBCO;
            document.getElementById("rightContainer_ContentBox2_LSEBCO").value = LSEBCO;
            document.getElementById("rightContainer_ContentBox2_TOTALLO").value = TOTALLO;

            document.getElementById("rightContainer_ContentBox2_PHCO").value = PHCO;
            document.getElementById("rightContainer_ContentBox2_PHCSCO").value = PHCSCO;
            document.getElementById("rightContainer_ContentBox2_PHCSTO").value = PHCSTO;
            document.getElementById("rightContainer_ContentBox2_PHCVJO").value = PHCVJO;
            document.getElementById("rightContainer_ContentBox2_PHCNT1O").value = PHCNT1O;
            document.getElementById("rightContainer_ContentBox2_PHCNT2O").value = PHCNT2O;
            document.getElementById("rightContainer_ContentBox2_PHCNT3O").value = PHCNT3O;
            document.getElementById("rightContainer_ContentBox2_PHCOBCO").value = PHCOBCO;
            document.getElementById("rightContainer_ContentBox2_PHCSEBCO").value = PHCSEBCO;
            document.getElementById("rightContainer_ContentBox2_TOTALPHCO").value = TOTALPHCO;

            document.getElementById("rightContainer_ContentBox2_DEFO").value = DEFO;
            document.getElementById("rightContainer_ContentBox2_DEFSCO").value = DEFSCO;
            document.getElementById("rightContainer_ContentBox2_DEFSTO").value = DEFSTO;
            document.getElementById("rightContainer_ContentBox2_DEFVJO").value = DEFVJO;
            document.getElementById("rightContainer_ContentBox2_DEFNT1O").value = DEFNT1O;
            document.getElementById("rightContainer_ContentBox2_DEFNT2O").value = DEFNT2O;
            document.getElementById("rightContainer_ContentBox2_DEFNT3O").value = DEFNT3O;
            document.getElementById("rightContainer_ContentBox2_DEFOBCO").value = DEFOBCO;
            document.getElementById("rightContainer_ContentBox2_DEFSEBCO").value = DEFSEBCO;
            document.getElementById("rightContainer_ContentBox2_TOTALDEFO").value = TOTALDEFO;

            document.getElementById("rightContainer_ContentBox2_txtDEFCommon").value = DEFT;
            document.getElementById("rightContainer_ContentBox2_txtPHCommon").value = PHT;
            document.getElementById("rightContainer_ContentBox2_ORPHAN").value = ORPHAN;
        }


        let GOPENH = 0; GSCH = 0; GSTH = 0; GVJH = 0; GNT1H = 0; GNT2H = 0; GNT3H = 0; GOBCH = 0; GSEBCH = 0; TOTALGH = 0;
        let LOPENH = 0; LSCH = 0; LSTH = 0; LVJH = 0; LNT1H = 0; LNT2H = 0; LNT3H = 0; LOBCH = 0; LSEBCH = 0; TOTALLH = 0;
        let PHCH = 0; PHCSCH = 0; PHCSTH = 0; PHCVJH = 0; PHCNT1H = 0; PHCNT2H = 0; PHCNT3H = 0; PHCOBCH = 0; PHCSEBCH = 0; TOTALPHCH = 0;

        let GOPENO = 0; GSCO = 0; GSTO = 0; GVJO = 0; GNT1O = 0; GNT2O = 0; GNT3O = 0; GOBCO = 0; GSEBCO = 0; TOTALGO = 0;
        let LOPENO = 0; LSCO = 0; LSTO = 0; LVJO = 0; LNT1O = 0; LNT2O = 0; LNT3O = 0; LOBCO = 0; LSEBCO = 0; TOTALLO = 0;
        let PHCO = 0; PHCSCO = 0; PHCSTO = 0; PHCVJO = 0; PHCNT1O = 0; PHCNT2O = 0; PHCNT3O = 0; PHCOBCO = 0; PHCSEBCO = 0; TOTALPHCO = 0;
        let DEFO = 0; DEFSCO = 0; DEFSTO = 0; DEFVJO = 0; DEFNT1O = 0; DEFNT2O = 0; DEFNT3O = 0; DEFOBCO = 0; DEFSEBCO = 0; TOTALDEFO = 0;

        let DEFT = 0; PHT = 0; ORPHAN = 0;

        function windowOnload() {

            GOPENH = document.getElementById("rightContainer_ContentBox2_GOPENH").value;
            GSCH = document.getElementById("rightContainer_ContentBox2_GSCH").value;
            GSTH = document.getElementById("rightContainer_ContentBox2_GSTH").value;
            GVJH = document.getElementById("rightContainer_ContentBox2_GVJH").value;
            GNT1H = document.getElementById("rightContainer_ContentBox2_GNT1H").value;
            GNT2H = document.getElementById("rightContainer_ContentBox2_GNT2H").value;
            GNT3H = document.getElementById("rightContainer_ContentBox2_GNT3H").value;
            GOBCH = document.getElementById("rightContainer_ContentBox2_GOBCH").value;
            GSEBCH = document.getElementById("rightContainer_ContentBox2_GSEBCH").value;
            TOTALGH = document.getElementById("rightContainer_ContentBox2_TOTALGH").value;

            LOPENH = document.getElementById("rightContainer_ContentBox2_LOPENH").value;
            LSCH = document.getElementById("rightContainer_ContentBox2_LSCH").value;
            LSTH = document.getElementById("rightContainer_ContentBox2_LSTH").value;
            LVJH = document.getElementById("rightContainer_ContentBox2_LVJH").value;
            LNT1H = document.getElementById("rightContainer_ContentBox2_LNT1H").value;
            LNT2H = document.getElementById("rightContainer_ContentBox2_LNT2H").value;
            LNT3H = document.getElementById("rightContainer_ContentBox2_LNT3H").value;
            LOBCH = document.getElementById("rightContainer_ContentBox2_LOBCH").value;
            LSEBCH = document.getElementById("rightContainer_ContentBox2_LSEBCH").value;
            TOTALLH = document.getElementById("rightContainer_ContentBox2_TOTALLH").value;

            PHCH = document.getElementById("rightContainer_ContentBox2_PHCH").value;
            PHCSCH = document.getElementById("rightContainer_ContentBox2_PHCSCH").value;
            PHCSTH = document.getElementById("rightContainer_ContentBox2_PHCSTH").value;
            PHCVJH = document.getElementById("rightContainer_ContentBox2_PHCVJH").value;
            PHCNT1H = document.getElementById("rightContainer_ContentBox2_PHCNT1H").value;
            PHCNT2H = document.getElementById("rightContainer_ContentBox2_PHCNT2H").value;
            PHCNT3H = document.getElementById("rightContainer_ContentBox2_PHCNT3H").value;
            PHCOBCH = document.getElementById("rightContainer_ContentBox2_PHCOBCH").value;
            PHCSEBCH = document.getElementById("rightContainer_ContentBox2_PHCSEBCH").value;
            TOTALPHCH = document.getElementById("rightContainer_ContentBox2_TOTALPHCH").value;

            GOPENO = document.getElementById("rightContainer_ContentBox2_GOPENO").value;
            GSCO = document.getElementById("rightContainer_ContentBox2_GSCO").value;
            GSTO = document.getElementById("rightContainer_ContentBox2_GSTO").value;
            GVJO = document.getElementById("rightContainer_ContentBox2_GVJO").value;
            GNT1O = document.getElementById("rightContainer_ContentBox2_GNT1O").value;
            GNT2O = document.getElementById("rightContainer_ContentBox2_GNT2O").value;
            GNT3O = document.getElementById("rightContainer_ContentBox2_GNT3O").value;
            GOBCO = document.getElementById("rightContainer_ContentBox2_GOBCO").value;
            GSEBCO = document.getElementById("rightContainer_ContentBox2_GSEBCO").value;
            TOTALGO = document.getElementById("rightContainer_ContentBox2_TOTALGO").value;

            LOPENO = document.getElementById("rightContainer_ContentBox2_LOPENO").value;
            LSCO = document.getElementById("rightContainer_ContentBox2_LSCO").value;
            LSTO = document.getElementById("rightContainer_ContentBox2_LSTO").value;
            LVJO = document.getElementById("rightContainer_ContentBox2_LVJO").value;
            LNT1O = document.getElementById("rightContainer_ContentBox2_LNT1O").value;
            LNT2O = document.getElementById("rightContainer_ContentBox2_LNT2O").value;
            LNT3O = document.getElementById("rightContainer_ContentBox2_LNT3O").value;
            LOBCO = document.getElementById("rightContainer_ContentBox2_LOBCO").value;
            LSEBCO = document.getElementById("rightContainer_ContentBox2_LSEBCO").value;
            TOTALLO = document.getElementById("rightContainer_ContentBox2_TOTALLO").value;

            PHCO = document.getElementById("rightContainer_ContentBox2_PHCO").value;
            PHCSCO = document.getElementById("rightContainer_ContentBox2_PHCSCO").value;
            PHCSTO = document.getElementById("rightContainer_ContentBox2_PHCSTO").value;
            PHCVJO = document.getElementById("rightContainer_ContentBox2_PHCVJO").value;
            PHCNT1O = document.getElementById("rightContainer_ContentBox2_PHCNT1O").value;
            PHCNT2O = document.getElementById("rightContainer_ContentBox2_PHCNT2O").value;
            PHCNT3O = document.getElementById("rightContainer_ContentBox2_PHCNT3O").value;
            PHCOBCO = document.getElementById("rightContainer_ContentBox2_PHCOBCO").value;
            PHCSEBCO = document.getElementById("rightContainer_ContentBox2_PHCSEBCO").value;
            TOTALPHCO = document.getElementById("rightContainer_ContentBox2_TOTALPHCO").value;

            DEFO = document.getElementById("rightContainer_ContentBox2_DEFO").value;
            DEFSCO = document.getElementById("rightContainer_ContentBox2_DEFSCO").value;
            DEFSTO = document.getElementById("rightContainer_ContentBox2_DEFSTO").value;
            DEFVJO = document.getElementById("rightContainer_ContentBox2_DEFVJO").value;
            DEFNT1O = document.getElementById("rightContainer_ContentBox2_DEFNT1O").value;
            DEFNT2O = document.getElementById("rightContainer_ContentBox2_DEFNT2O").value;
            DEFNT3O = document.getElementById("rightContainer_ContentBox2_DEFNT3O").value;
            DEFOBCO = document.getElementById("rightContainer_ContentBox2_DEFOBCO").value;
            DEFSEBCO = document.getElementById("rightContainer_ContentBox2_DEFSEBCO").value;
            TOTALDEFO = document.getElementById("rightContainer_ContentBox2_TOTALDEFO").value;

            DEFT = document.getElementById("rightContainer_ContentBox2_txtDEFCommon").value;
            PHT = document.getElementById("rightContainer_ContentBox2_txtPHCommon").value;
            ORPHAN = document.getElementById("rightContainer_ContentBox2_ORPHAN").value;
        }

        window.onload = windowOnload;
    </script>
    <cc1:ContentBox ID="ContentBox1" runat="server" HeaderText="Course Information">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <font color="red">	
                        <b>Instructions :</b><br /><br />
                        <ol class="list-text">
                            <li><p align = "justify"><font color = "red">Total Intake and SUM of CAP (Excluding Minority) Intake, CAP (Minority) Intake and Institutional Intake should be same.</font></p></li>
                            <li><p align = "justify"><font color = "red">SUM of CAP (Excluding Minority) should be same of SUM of MS CAP (Excluding Minority) Intake and AI CAP (Excluding Minority) Intake.</font></p></li>
                            <li><p align = "justify"><font color = "red">MS CAP (Excluding Minority) and Total of Seat Distribution should be same.</font></p></li>
                        </ol>
                    </font>
                </td>
            </tr>
        </table>
        <table class="AppFormTable">
            <tr>
                <td align="right">Course Name</td>
                <td colspan = "3"><asp:Label ID="lblCourseName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">University Name</td>
                <td colspan = "3"><asp:Label ID="lblUniversityName" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%" align="right">Status 1</td>
                <td style="width: 25%"><asp:Label ID="lblCourseStatus1" runat="server" Font-Bold = "true"></asp:Label></td>
                <td style="width: 25%" align="right">Status 2</td>
                <td style="width: 25%"><asp:Label ID="lblCourseStatus2" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Status 3</td>
                <td><asp:Label ID="lblCourseStatus3" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Shift</td>
                <td><asp:Label ID="lblCourseShift" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Accreditation</td>
                <td colspan="3"><asp:Label ID="lblAccreditation" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Course Gender</td>
                <td><asp:Label ID="lblGender" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Is Govt. Course</td>
                <td><asp:Label ID="lblIsGov" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Is State Level Course</td>
                <td><asp:Label ID="lblIsStateLevel" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Is TFWS Course</td>
                <td><asp:Label ID="lblIsTFWS" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Is Konkan Course</td>
                <td><asp:Label ID="lblIsKonkan" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Is NRI Quota</td>
                <td><asp:Label ID="lblIsNRI" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Is PIO Quota</td>
                <td><asp:Label ID="lblIsPIO" runat="server" Font-Bold = "true"></asp:Label></td>
                <td align="right">Participate in CAP</td>
                <td><asp:Label ID="lblParticipateInCAP" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Court Case Remark</td>
                <td colspan = "3"><asp:Label ID="lblCourtCaseRemark" runat="server" Font-Bold = "true"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Total Intake</td>
                <td>
                    <asp:TextBox ID="txtTotalIntake" runat="server" Width = "70px" MaxLength="3" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvTotalIntake" runat="server" ControlToValidate="txtTotalIntake" Display="None" ErrorMessage="Please Enter Total Intake."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTotalIntake" runat="server" ControlToValidate="txtTotalIntake" Display="None" ErrorMessage="Total Intake is not correctly entered." ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
                <td align="right">CAP (Excluding Minority) Intake</td>
                <td>
                    <asp:TextBox ID="txtCAPIntake" runat="server" Width = "70px" MaxLength="3" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvCAPIntake" runat="server" ControlToValidate="txtCAPIntake" Display="None" ErrorMessage="Please Enter CAP (Excluding Minority) Intake."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCAPIntake" runat="server" ControlToValidate="txtCAPIntake" Display="None" ErrorMessage="CAP (Excluding Minority) Intake is not correctly entered." ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">CAP (Minority) Intake</td>
                <td>
                    <asp:TextBox ID="txtMIIntake" runat="server" Width = "70px" MaxLength="3" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvMIIntake" runat="server" ControlToValidate="txtMIIntake" Display="None" ErrorMessage="Please Enter CAP (Minority) Intake."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revMIIntake" runat="server" ControlToValidate="txtMIIntake" Display="None" ErrorMessage="CAP (Minority) Intake is not correctly entered." ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
                <td align="right">Institutional Intake</td>
                <td>
                    <asp:TextBox ID="txtILIntake" runat="server" Width = "70px" MaxLength="3" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvILIntake" runat="server" ControlToValidate="txtILIntake" Display="None" ErrorMessage="Please Enter Institutional Intake."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revILIntake" runat="server" ControlToValidate="txtILIntake" Display="None" ErrorMessage="Institutional Intake is not correctly entered." ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">MS CAP (Excluding Minority) Intake</td>
                <td>
                    <asp:TextBox ID="txtMSIntake" runat="server" Width = "70px" MaxLength="3" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvMSIntake" runat="server" ControlToValidate="txtMSIntake" Display="None" ErrorMessage="Please Enter MS CAP (Excluding Minority) Intake."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revMSIntake" runat="server" ControlToValidate="txtMSIntake" Display="None" ErrorMessage="MS CAP (Excluding Minority) Intake is not correctly entered." ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
                <td align="right">AI CAP (Excluding Minority) Intake</td>
                <td>
                    <asp:TextBox ID="txtAIIntake" runat="server" Width = "70px" MaxLength="3" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="rfvAIIntake" runat="server" ControlToValidate="txtAIIntake" Display="None" ErrorMessage="Please Enter AI CAP (Excluding Minority) Intake."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revAIIntake" runat="server" ControlToValidate="txtAIIntake" Display="None" ErrorMessage="AI CAP (Excluding Minority) Intake is not correctly entered." ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
            </tr>
             <tr>
                <td align="right">EWS Intake</td>
                <td colspan="3">
                    <asp:TextBox ID="EWS" runat="server" Width = "70px" MaxLength="3" onKeyPress="return numbersonly(event)"></asp:TextBox>
                    <font color = "red"><sup>*</sup></font>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMSIntake" Display="None" ErrorMessage="Please Enter MS CAP (Excluding Minority) Intake."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMSIntake" Display="None" ErrorMessage="MS CAP (Excluding Minority) Intake is not correctly entered." ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
                 
            </tr>
        </table>
    </cc1:ContentBox>
    <cc1:ContentBox ID="ContentBox2" runat="server" HeaderText="Seat Distribution of MS CAP (Excluding Minority) Intake">
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td>
                    <div id="divInitialClear" style="text-align: right;font-size:small;"><b style="color: Blue; cursor: pointer; text-decoration: underline" onclick="InitializeClear()"><asp:Label ID="lblInitialClear" runat="server">Clear all</asp:Label></b></div>
                </td>
            </tr>
        </table>
        <br />
        <table class="AppFormTable">
            <tr>
                <th colspan="2"></th>
                <th>OPEN</th>
                <th>SC</th>
                <th>ST</th>
                <th>DT/VJ</th>
                <th>NT-B</th>
                <th>NT-C</th>
                <th>NT-D</th>
                <th>OBC</th>
                <th>SEBC</th>
                <%--<th>EWS</th>--%>
                <th>ORPHAN</th>
                <th>TOTAL</th>
            </tr>
            <tr>
                <td style = "width:8%" align = "center" rowspan="3"><b>HU</b></td>
                <td style = "width:8%" align = "center"><b>G</b></td>
                <td style = "width:7%" align = "center"><asp:TextBox ID="GOPENH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td style = "width:7%" align = "center"><asp:TextBox ID="GSCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td style = "width:7%" align = "center"><asp:TextBox ID="GSTH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td style = "width:7%" align = "center"><asp:TextBox ID="GVJH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td style = "width:7%" align = "center"><asp:TextBox ID="GNT1H" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td style = "width:7%" align = "center"><asp:TextBox ID="GNT2H" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td style = "width:7%" align = "center"><asp:TextBox ID="GNT3H" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td style = "width:7%" align = "center"><asp:TextBox ID="GOBCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td style = "width:7%" align = "center"><asp:TextBox ID="GSEBCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
             <%--   <td style = "width:7%" align = "center"></td>--%>
                <td style = "width:7%" align = "center"></td>
                <td style = "width:7%" align = "center"><asp:TextBox ID="TOTALGH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
            </tr>
            <tr>
                <td align = "center"><b>L</b></td>
                <td align = "center"><asp:TextBox ID="LOPENH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LSCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LSTH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LVJH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LNT1H" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LNT2H" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LNT3H" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LOBCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LSEBCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
               <%-- <td align = "center"></td>--%>
                <td align = "center"></td>
                <td align = "center"><asp:TextBox ID="TOTALLH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
            </tr>
            <tr>
                <td align = "center"><b>PH</b></td>
                <td align = "center"><asp:TextBox ID="PHCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCSCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCSTH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCVJH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCNT1H" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCNT2H" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCNT3H" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCOBCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCSEBCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
               <%-- <td align = "center"></td>--%>
                <td align = "center"></td>
                <td align = "center"><asp:TextBox ID="TOTALPHCH" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
            </tr>
            <tr>
                <td align = "center" rowspan="3"><b>OHU</b></td>
                <td align = "center"><b>G</b></td>
                <td align = "center"><asp:TextBox ID="GOPENO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="GSCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="GSTO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="GVJO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="GNT1O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="GNT2O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="GNT3O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="GOBCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="GSEBCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
              <%--  <td align = "center"></td>--%>
                <td align = "center"></td>
                <td align = "center"><asp:TextBox ID="TOTALGO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
            </tr>
            <tr>
                <td align = "center"><b>L</b></td>
                <td align = "center"><asp:TextBox ID="LOPENO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LSCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LSTO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LVJO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LNT1O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LNT2O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LNT3O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LOBCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="LSEBCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <%--<td align = "center"></td>--%>
                <td align = "center"></td>
                <td align = "center"><asp:TextBox ID="TOTALLO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
            </tr>
            <tr>
                <td align = "center"><b>PH</b></td>
                <td align = "center"><asp:TextBox ID="PHCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCSCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCSTO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCVJO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCNT1O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCNT2O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCNT3O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCOBCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="PHCSEBCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
              <%--  <td align = "center"></td>--%>
                <td align = "center"></td>
                <td align = "center"><asp:TextBox ID="TOTALPHCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
            </tr>
            <tr>
                <td align = "right" colspan="6"><b>PWD Common Reserved Seats :</b></td> 
                <td align = "left" colspan="5"><asp:TextBox ID="txtPHCommon" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
            </tr>
            <tr>
                <td align = "center"><b>SL</b></td>
                <td align = "center"><b>DEF</b></td>
                <td align = "center"><asp:TextBox ID="DEFO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="DEFSCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="DEFSTO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="DEFVJO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="DEFNT1O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="DEFNT2O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="DEFNT3O" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="DEFOBCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="DEFSEBCO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
               <%-- <td align = "center"><asp:TextBox ID="EWS" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>--%>
                <td align = "center"><asp:TextBox ID="ORPHAN" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
                <td align = "center"><asp:TextBox ID="TOTALDEFO" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
            </tr>
            <tr>
                <td align = "right" colspan="6"><b>DEF Common Reserved Seats :</b> </td>
                <td align = "left" colspan="5"><asp:TextBox ID="txtDEFCommon" runat="server" Width="50px" MaxLength = "3" CssClass="txtAlign" onblur="Summation()" onKeyPress="return numbersonly(event)">0</asp:TextBox></td>
            </tr>
        </table>
        <br />
        <table class="AppFormTableWithOutBorder">
            <tr>
                <td align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Save & Proceed >>>" CssClass="InputButton" OnClick="btnProceed_Click" />
                </td>
            </tr>
        </table>
        <br />
    </cc1:ContentBox>
    <asp:CustomValidator ID="cvCheckTotalIntake" runat="server" ClientValidationFunction="checkTotalIntake" Display="None" ErrorMessage="Total Intake and SUM of CAP (Excluding Minority) Intake, CAP (Minority) Intake and Institutional Intake should be same."></asp:CustomValidator>
    <asp:CustomValidator ID="cvCheckCAPIntake" runat="server" ClientValidationFunction="checkCAPIntake" Display="None" ErrorMessage="SUM of CAP (Excluding Minority) should be same of SUM of MS CAP (Excluding Minority) Intake and AI CAP (Excluding Minority) Intake."></asp:CustomValidator>
    <asp:CustomValidator ID="cvCheckMSIntake" runat="server" ClientValidationFunction="checkMSIntake" Display="None" ErrorMessage="MS CAP (Excluding Minority) and Total of Seat Distribution should be same."></asp:CustomValidator>
    <asp:ValidationSummary ID="ValidationSummary1" Runat="server" ShowSummary="False" ShowMessageBox="True" />
    <script language="javascript" type="text/javascript">
        Summation();
    </script>
</asp:Content>
