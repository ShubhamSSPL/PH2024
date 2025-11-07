using BusinessLayer;
using DataAccess.Implementation;
using EntityModel;
using forProjectCustomExceptions;
using Newtonsoft.Json;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.ApplicationPages
{
    public partial class WelcomePageInstitute : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        public string AdmissionYear = Global.AdmissionYear;
        //protected override void OnPreInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    if (Request.Cookies["Theme"] == null)
        //    {
        //        Page.Theme = "default";
        //    }
        //    else
        //    {
        //        Page.Theme = Request.Cookies["Theme"].Value;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginID"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    Int32 UserTypeID = Convert.ToInt32(Session["UserTypeID"].ToString());
                    string UserLoginID = Session["UserLoginID"].ToString();

                    DataSet dsLoginDetails = reg.getLoginDetails(UserLoginID, UserTypeID);
                    if (dsLoginDetails.Tables[0].Rows.Count > 0)
                    {
                        lblLoginID.Text = dsLoginDetails.Tables[0].Rows[0]["LoginID"].ToString();
                        lblUserName.Text = dsLoginDetails.Tables[0].Rows[0]["UserName"].ToString();
                        lblUserType.Text = dsLoginDetails.Tables[0].Rows[0]["UserTypeName"].ToString();
                        DateTime CurrentLoginDateTime = Convert.ToDateTime(dsLoginDetails.Tables[0].Rows[0]["CurrentLoginDateTime"].ToString());
                        lblCurrentLoginTime.Text = CurrentLoginDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", CurrentLoginDateTime);
                        DateTime LastLoginDateTime = Convert.ToDateTime(dsLoginDetails.Tables[0].Rows[0]["LastLoginDateTime"].ToString());
                        lblPreviousLoginTime.Text = LastLoginDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", LastLoginDateTime);
                        lblIPAddress.Text = UserInfo.GetIPAddress();
                    }

                    if (UserTypeID == 43)
                    {
                        DataSet dsIP = reg.getInstituteProfileDS(Convert.ToInt32(Session["UserID"].ToString()));
                        if (dsIP.Tables[0].Rows.Count > 0)
                        {
                            if (dsIP.Tables[0].Rows[0]["InstitutePhoneNo"].ToString().Length == 0)
                            {
                                Response.Redirect("../InstituteModule/frmInstituteProfile.aspx");
                            }
                        }

                        //gvChoiceCodeListFromDTEPortal.DataSource = reg.getAllChoiceCodeListFromDTEPortalForInstitute(UserLoginID);
                        //gvChoiceCodeListFromDTEPortal.DataBind();

                        //if (gvChoiceCodeListFromDTEPortal.Rows.Count > 0)
                        //{
                        //    cbInstitute.Visible = true;
                        //}
                    }

                    //DataSet dsDashboard = reg.getDashboardInstitute(UserTypeID, UserLoginID);
                    DataSet dsDashboard = null;
                    Int64 Total = 0;

                    //if (dsDashboard.Tables[14].Rows.Count > 0)
                    if (dsDashboard != null)
                    {
                        cbDashboard1.Visible = true;
                        cbDashboard2.Visible = true;

                        lblCAPIntake.Text = dsDashboard.Tables[0].Rows[0]["CAPIntake"].ToString();
                        lblCAPAdmitted.Text = dsDashboard.Tables[0].Rows[0]["CAPAdmitted"].ToString();
                        lblACAPAdmitted.Text = dsDashboard.Tables[0].Rows[0]["ACAPAdmitted"].ToString();
                        lblCAPVacancy.Text = dsDashboard.Tables[0].Rows[0]["ACAPVacancy"].ToString();
                        lblMIIntake.Text = dsDashboard.Tables[0].Rows[0]["CAPMIIntake"].ToString();
                        lblMIAdmitted.Text = dsDashboard.Tables[0].Rows[0]["CAPMIAdmitted"].ToString();
                        lblAMIAdmitted.Text = dsDashboard.Tables[0].Rows[0]["ACAPMIAdmitted"].ToString();
                        lblMIVacancy.Text = dsDashboard.Tables[0].Rows[0]["ACAPMIVacancy"].ToString();
                        lblILIntake.Text = dsDashboard.Tables[0].Rows[0]["ILIntake"].ToString();
                        lblILAdmitted.Text = dsDashboard.Tables[0].Rows[0]["ILAdmitted"].ToString();
                        lblILVacancy.Text = dsDashboard.Tables[0].Rows[0]["ILVacancy"].ToString();
                        lblTotalIntake.Text = dsDashboard.Tables[0].Rows[0]["TotalIntake"].ToString();
                        lblTotalAdmitted.Text = dsDashboard.Tables[0].Rows[0]["TotalAdmitted"].ToString();
                        lblTotalVacancy.Text = dsDashboard.Tables[0].Rows[0]["TotalVacancy"].ToString();
                        lblJKAdmitted.Text = dsDashboard.Tables[0].Rows[0]["JKAdmitted"].ToString();
                        lblOAAAdmitted.Text = dsDashboard.Tables[0].Rows[0]["OAAAdmitted"].ToString();

                        gvCandidatureTypeWiseReport.DataSource = dsDashboard.Tables[1];
                        gvCandidatureTypeWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvCandidatureTypeWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvCandidatureTypeWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvCandidatureTypeWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvCandidatureTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvHomeUniversityWiseReport.DataSource = dsDashboard.Tables[2];
                        gvHomeUniversityWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvHomeUniversityWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvHomeUniversityWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvHomeUniversityWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvHomeUniversityWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvCategoryWiseReport.DataSource = dsDashboard.Tables[3];
                        gvCategoryWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvCategoryWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvCategoryWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvCategoryWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvCategoryWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvPHTypeWiseReport.DataSource = dsDashboard.Tables[4];
                        gvPHTypeWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvPHTypeWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvPHTypeWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvPHTypeWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvPHTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvDefenceTypeWiseReport.DataSource = dsDashboard.Tables[5];
                        gvDefenceTypeWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvDefenceTypeWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvDefenceTypeWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvDefenceTypeWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvDefenceTypeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvGenderWiseReport.DataSource = dsDashboard.Tables[6];
                        gvGenderWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvGenderWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvGenderWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvGenderWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvGenderWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvReligionWiseReport.DataSource = dsDashboard.Tables[7];
                        gvReligionWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvReligionWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvReligionWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvReligionWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvReligionWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvRegionWiseReport.DataSource = dsDashboard.Tables[8];
                        gvRegionWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvRegionWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvRegionWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvRegionWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvRegionWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvMotherTongueWiseReport.DataSource = dsDashboard.Tables[9];
                        gvMotherTongueWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvMotherTongueWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvMotherTongueWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvMotherTongueWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvMotherTongueWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvAnnualFamilyIncomeWiseReport.DataSource = dsDashboard.Tables[10];
                        gvAnnualFamilyIncomeWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvAnnualFamilyIncomeWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvAnnualFamilyIncomeWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvAnnualFamilyIncomeWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvAnnualFamilyIncomeWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvHSCBoardWiseReport.DataSource = dsDashboard.Tables[11];
                        gvHSCBoardWiseReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvHSCBoardWiseReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvHSCBoardWiseReport.Rows[i].Cells[1].Text));
                        }
                        gvHSCBoardWiseReport.FooterRow.Cells[0].Text = "Total";
                        gvHSCBoardWiseReport.FooterRow.Cells[1].Text = Total.ToString();

                        if (dsDashboard.Tables[12].Rows.Count > 0)
                        {
                            gvHSCPassingYearWiseReport.DataSource = dsDashboard.Tables[12];
                            gvHSCPassingYearWiseReport.DataBind();
                            Total = 0;
                            for (Int32 i = 0; i < gvHSCPassingYearWiseReport.Rows.Count; i++)
                            {
                                Total += Convert.ToInt64((gvHSCPassingYearWiseReport.Rows[i].Cells[1].Text));
                            }
                            gvHSCPassingYearWiseReport.FooterRow.Cells[0].Text = "Total";
                            gvHSCPassingYearWiseReport.FooterRow.Cells[1].Text = Total.ToString();
                        }

                        gvMinorityReport.DataSource = dsDashboard.Tables[13];
                        gvMinorityReport.DataBind();
                        Total = 0;
                        for (Int32 i = 0; i < gvMinorityReport.Rows.Count; i++)
                        {
                            Total += Convert.ToInt64((gvMinorityReport.Rows[i].Cells[1].Text));
                        }
                        gvMinorityReport.FooterRow.Cells[0].Text = "Total";
                        gvMinorityReport.FooterRow.Cells[1].Text = Total.ToString();

                        gvDashboardInstitute.DataSource = dsDashboard.Tables[14];
                        gvDashboardInstitute.DataBind();

                        Int32 TotalInstitutes = 0;
                        Int32 IntakeCurrentYear_AsPerAICTEBeforeLastDate = 0;
                       // Int32 IntakeCurrentYear_AsPerAICTEAfterLastDate = 0;
                        Int32 IntakeCurrentYear_AsPerGR = 0;
                        Int32 IntakeCurrentYear_AsPerUniversity = 0;
                        Int32 IntakeCurrentYear_AsPerDTEForAdmission = 0;
                        Int32 IntakeCurrentYear_FinalForAdmission = 0;

                        for (Int32 k = 0; k < gvDashboardInstitute.Rows.Count; k++)
                        {
                            TotalInstitutes += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[3].Text);
                            IntakeCurrentYear_AsPerAICTEBeforeLastDate += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[4].Text);
                            //IntakeCurrentYear_AsPerAICTEAfterLastDate += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[5].Text);
                            IntakeCurrentYear_AsPerGR += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[5].Text);
                            IntakeCurrentYear_AsPerUniversity += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[6].Text);
                            IntakeCurrentYear_AsPerDTEForAdmission += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[7].Text);
                            IntakeCurrentYear_FinalForAdmission += Convert.ToInt32(gvDashboardInstitute.Rows[k].Cells[8].Text);
                        }
                        gvDashboardInstitute.FooterRow.Cells[2].Text = "Total";
                        gvDashboardInstitute.FooterRow.Cells[3].Text = TotalInstitutes.ToString();
                        gvDashboardInstitute.FooterRow.Cells[4].Text = IntakeCurrentYear_AsPerAICTEBeforeLastDate.ToString();
                       // gvDashboardInstitute.FooterRow.Cells[5].Text = IntakeCurrentYear_AsPerAICTEAfterLastDate.ToString();
                        gvDashboardInstitute.FooterRow.Cells[5].Text = IntakeCurrentYear_AsPerGR.ToString();
                        gvDashboardInstitute.FooterRow.Cells[6].Text = IntakeCurrentYear_AsPerUniversity.ToString();
                        gvDashboardInstitute.FooterRow.Cells[7].Text = IntakeCurrentYear_AsPerDTEForAdmission.ToString();
                        gvDashboardInstitute.FooterRow.Cells[8].Text = IntakeCurrentYear_FinalForAdmission.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=ChoiceCodeList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            gvChoiceCodeListFromDTEPortal.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        public DataSet GetFromAPI()
        {
            //List<Table> lstchoiceCode = new List<Table>();
            DataSet myDataSet = new DataSet();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["TechnicalSiteUrl"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("api/InstDataForAdmission?degreeLevel=UG&degreeName=PHARMACY").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;
                        //JObject json =  JObject.Parse(responseString);
                        dynamic parsedJson = JsonConvert.DeserializeObject(responseString);
                        myDataSet = JsonConvert.DeserializeObject<DataSet>(parsedJson);
                        // lstchoiceCode =  JsonConvert.DeserializeObject<List<Table>>(parsedJson);

                    }
                }
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "api/InstDataForAdmission?degreeLevel=UG&degreeName=PHARMACY", "");
            }
            return myDataSet;
        }

        public DataSet GetFromAPIView()
        {
            //List<Table> lstchoiceCode = new List<Table>();
            DataSet myDataSet = new DataSet();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["TechnicalSiteUrl"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("api/InstDataForAdmission?viewName=CETCELL_viewDashboardInstituteAdminPHARMACY").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;
                        //JObject json =  JObject.Parse(responseString);
                        dynamic parsedJson = JsonConvert.DeserializeObject(responseString);
                        myDataSet = JsonConvert.DeserializeObject<DataSet>(parsedJson);
                        // lstchoiceCode =  JsonConvert.DeserializeObject<List<Table>>(parsedJson);

                    }
                }
            }
            catch (Exception ex)
            {
                long messageID = ExceptionMessages.GetMessageDetails();
                new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "GetFromAPIView", "View Name : CETCELL_viewDashboardInstituteAdminPHARMACY");
            }
            return myDataSet;
        }
    }
}