using BusinessLayer;
using Pharmacy2024;
using Synthesys.Controls;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Pharmacy2024.StaticPages
{
    public partial class HomePage : System.Web.UI.Page
    {
        private readonly IBusinessService _IbusinessService = new BusinessServiceImp();
        public string URL = ConfigurationManager.AppSettings["ApplicationURL"];
        public string AdmissionYear = Global.AdmissionYear;
        public Int16 IsDisplayFinalMeritList = Global.DisplayFinalMeritList;
        public Int16 IsDisplayProvisionalMeritList = Global.DisplayProvisionalMeritList;
        public int ApplicationFormFilling = Global.ApplicationFormFilling;
        public string IsCAPRegistrationStart = Global.IsCAPRegistrationStart;
        // private string clients;
        // public string Clients { get { return clients; } }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            //   this.clients = Global.ApplicationFormPrefix;
            HttpCookie cookie = new HttpCookie("Theme", "default");
            cookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(cookie);

            Page.Theme = "default";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ContentBox1.HeaderText = "Seat Matrix and Cut Off Lists of CAP Round for Current Year " + Global.AdmissionYear;
            if (DateTime.Now < Global.ApplicationFormFillingStartDateTime || DateTime.Now > Global.ApplicationFormFillingEndDateTime)
            {
                tblRegistrationLinks.Visible = false;
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
           
            if (!IsPostBack)
            {
                DataSet ds = null;
                try
                {
                    ds = getDataForGetMenusForPanel();

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            panel2.InnerHtml = "";
                            panel3.InnerHtml = "";
                            panel5.InnerHtml = "";
                            Int32 panel2count = 0, panel3count = 0, panel5count = 0;

                            for (Int32 i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                                img.ImageUrl = "~/SynthesysModules_Files/Images/brownbullet12.gif";
                                switch (ds.Tables[0].Rows[i]["GroupID"].ToString())
                                {
                                    case "2":
                                        if (panel2count < 5)
                                        {
                                            if (Int32.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                                            {
                                                panel2.InnerHtml = panel2.InnerHtml + @"<p align = ""justify""><a target=""_blank"" href=""" + ds.Tables[0].Rows[i]["MenuUrl"].ToString() + @""">" + ds.Tables[0].Rows[i]["MenuName"].ToString() + "</a></p>";
                                                panel2count++;
                                            }
                                            else
                                            {
                                                panel2.InnerHtml = panel2.InnerHtml + @"<p align = ""justify"">" + ds.Tables[0].Rows[i]["MenuName"].ToString() + "</p>";
                                                panel2count++;
                                            }
                                        }
                                        else if (panel2count == 5)
                                        {
                                            panel2.InnerHtml = panel2.InnerHtml + @"<p align=""right""><a target=""_blank"" href=""../CMS/ListOfLinks?gid=2"">More..</a></p>";
                                            panel2count++;
                                        }
                                        break;
                                    case "3":
                                        if (panel3count < 5)
                                        {
                                            if (Int32.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                                            {
                                                panel3.InnerHtml = panel3.InnerHtml + @"<p align = ""justify""><a target=""_blank"" href=""" + ds.Tables[0].Rows[i]["MenuUrl"].ToString() + @""">" + ds.Tables[0].Rows[i]["MenuName"].ToString() + "</a></p>";
                                                panel3count++;
                                            }
                                            else
                                            {
                                                panel3.InnerHtml = panel3.InnerHtml + @"<p align = ""justify"">" + ds.Tables[0].Rows[i]["MenuName"].ToString() + "</p>";
                                                panel3count++;
                                            }
                                        }
                                        else if (panel3count == 5)
                                        {
                                            panel3.InnerHtml = panel3.InnerHtml + @"<p align=""right""><a target=""_blank"" href=""../CMS/ListOfLinks?gid=3"">More..</a></p>";
                                            panel3count++;
                                        }
                                        break;
                                    case "5":
                                        if (panel5count < 5)
                                        {
                                            if (Int32.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                                            {
                                                panel5.InnerHtml = panel5.InnerHtml + @"<p align = ""justify""><a target=""_blank"" href=""" + ds.Tables[0].Rows[i]["MenuUrl"].ToString() + @""">" + ds.Tables[0].Rows[i]["MenuName"].ToString() + "</a></p>";
                                                panel5count++;
                                            }
                                            else
                                            {
                                                panel5.InnerHtml = panel5.InnerHtml + @"<p align = ""justify"">" + ds.Tables[0].Rows[i]["MenuName"].ToString() + "</p>";
                                                panel5count++;
                                            }
                                        }
                                        else if (panel5count == 5)
                                        {
                                            panel5.InnerHtml = panel5.InnerHtml + @"<p align=""right""><a target=""_blank"" href=""../CMS/ListOfLinks?gid=3"">More..</a></p>";
                                            panel5count++;
                                        }
                                        break;
                                }
                            }
                        }

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            for (Int32 i = 0; i < ds.Tables[1].Rows.Count; i++)
                            {
                                switch (ds.Tables[1].Rows[i]["GroupId"].ToString())
                                {
                                    case "2":
                                        lblPanel2.Text = ds.Tables[1].Rows[i]["GroupDisplayText"].ToString();
                                        break;
                                    case "3":
                                        lblPanel3.Text = ds.Tables[1].Rows[i]["GroupDisplayText"].ToString();
                                        break;
                                    case "5":
                                        lblPanel5.Text = ds.Tables[1].Rows[i]["GroupDisplayText"].ToString();
                                        break;
                                }
                            }
                        }
                    }
                    ds = getDateForGetImplinks();
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            HyperLink hp;
                            Literal lit;
                            Image SepImg;

                            for (Int32 i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (Int32.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                                {
                                    hp = new HyperLink();
                                    hp.Text = " " + ds.Tables[0].Rows[i]["MenuName"].ToString() + " ";
                                    hp.NavigateUrl = ds.Tables[0].Rows[i]["MenuUrl"].ToString();
                                    hp.CssClass = "";
                                    scrollerb.Controls.Add(hp);
                                    SepImg = new Image();
                                    SepImg.ImageUrl = "~/SynthesysModules_Files/Images/large-dia7.gif";
                                    scrollerb.Controls.Add(SepImg);
                                }
                                else
                                {
                                    lit = new Literal();
                                    lit.Text = " " + ds.Tables[0].Rows[i]["MenuName"].ToString() + " ";
                                    scrollerb.Controls.Add(lit);
                                    SepImg = new Image();
                                    SepImg.ImageUrl = "~/SynthesysModules_Files/Images/large-dia7.gif";
                                    scrollerb.Controls.Add(SepImg);
                                }
                            }
                        }
                    }


                    if (Global.CurrentDate != DateTime.Now.ToString("dd/MM/yyyy"))
                    {
                        Global.TopImportantDates = _IbusinessService.getTopActiveImportantDates();
                        Global.CurrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                    }

                    gvImportantDates.DataSource = Global.TopImportantDates.Tables[0];
                    gvImportantDates.DataBind();

                    for (Int32 i = 0; i < gvImportantDates.Rows.Count; i++)
                    {
                        if (gvImportantDates.Rows[i].Cells[1].Text == "09/12/2020  to 21/12/2020 Up to 11:59 P.M.")
                            gvImportantDates.Rows[i].Cells[1].Text = gvImportantDates.Rows[i].Cells[1].Text.Replace("09/12/2020  to 21/12/2020 Up to 11:59 P.M.", "09/12/2020  to 21*/12/2020 Up to 11:59 P.M.");
                        if (gvImportantDates.Rows[i].Cells[1].Text == "09/12/2020  to 22/12/2020 Up to 5 P.M.")
                            gvImportantDates.Rows[i].Cells[1].Text = gvImportantDates.Rows[i].Cells[1].Text.Replace("09/12/2020  to 22/12/2020 Up to 5 P.M.", "09/12/2020  to 22*/12/2020 Up to 5 P.M.");

                        if (i == 2)
                        {
                            //gvImportantDates.Rows[i].Cells[0].Text = gvImportantDates.Rows[i].Cells[1].Text;
                            gvImportantDates.Rows[i].Cells[0].ColumnSpan = 2;
                            gvImportantDates.Rows[i].Cells.RemoveAt(1);
                            //gvImportantDates.Rows[i].Cells.RemoveAt(2);
                            //gvImportantDates.Rows[i].Cells.RemoveAt(1);
                        }

                    }
                }
                catch (Exception ex)
                {
                    //Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
                finally
                {
                    if (ds != null)
                    {
                        ds.Dispose();
                        ds = null;
                    }
                }
            }
        }
        private DataSet getDataForGetMenusForPanel()
        {
            SqlParameter[] para = { };
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("Menu_Mgt_GetMenusForPanel", para);
            }
            finally
            {
                db.Dispose();
            }
        }
        private DataSet getDateForGetImplinks()
        {
            SqlParameter[] para = { };
            DBConnection db = new DBConnection();
            try
            {
                return db.ExecuteDataSet("Menu_Mgt_GetImplinks", para);
            }
            finally
            {
                db.Dispose();
            }
        }
        protected void btnApply_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (IsCAPRegistrationStart == "Y")
                {
                    if (ApplicationFormFilling == 1)
                    {
                        Response.Redirect("../RegistrationModule/frmCheckCETDetails", true);
                    }
                    else
                    {
                        shInfo.SetMessage("Registration for ACAP / Non-CAP admission is closed.", ShowMessageType.Information);
                    }
                }
                else
                {
                    shInfo.SetMessage("Registration for ACAP / Non-CAP admissions will be start on 09 August 2024.", ShowMessageType.Information);
                }

            }
            catch (Exception ex)
            {

                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnAlreadyRegistered_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Response.Redirect("../StaticPages/frmLoginPage", false);
            }
            catch (Exception ex)
            {
                //Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}