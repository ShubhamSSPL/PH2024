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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmChoiceCodeList : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected override void OnPreInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request.Cookies["Theme"] == null)
            {
                Page.Theme = "default";
            }
            else
            {
                Page.Theme = Request.Cookies["Theme"].Value;
            }
        }
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
                    DataSet dsAPI = GetFromAPI();
                    if (dsAPI != null)
                    {
                        if (dsAPI.Tables.Count > 0)
                        {
                            if (dsAPI.Tables[0].Rows.Count > 0)
                            {
                                //   DataSet ds = reg.getAllChoiceCodeList();
                                List<viewChoiceCodeListFromPortal> viewChoiceCodeListFromPortal = new List<viewChoiceCodeListFromPortal>();
                                viewChoiceCodeListFromPortal = BusinessLayer.BalCommon.ReadTable<viewChoiceCodeListFromPortal>(dsAPI);

                                gvInstituteList.DataSource = dsAPI;

                                ChoiceCodeResult choiceCodeResult = new ChoiceCodeResult();
                                choiceCodeResult.TotalInstitutes = viewChoiceCodeListFromPortal.GroupBy(l => l.InstituteID).Distinct().Count();
                                choiceCodeResult.TotalIntake = viewChoiceCodeListFromPortal.Sum(x => x.TotalIntake);
                                choiceCodeResult.CAPotherthanMISeats = viewChoiceCodeListFromPortal.Sum(x => x.CAPSeats);
                                choiceCodeResult.CAPforMISeats = viewChoiceCodeListFromPortal.Sum(x => x.MinoritySeats);
                                choiceCodeResult.ILSeats = viewChoiceCodeListFromPortal.Sum(x => x.ILSeats);
                                choiceCodeResult.JKSeats = viewChoiceCodeListFromPortal.Sum(x => x.IntakeJK);

                                DataTable mytable = new DataTable();
                                mytable.Columns.Add("Details", typeof(string));
                                mytable.Columns.Add("Total", typeof(long));

                                DataRow dr = mytable.NewRow(); //Creating Row  
                                dr["Details"] = "Total Institutes";
                                dr["Total"] = choiceCodeResult.TotalInstitutes;
                                mytable.Rows.Add(dr); //adding to datatable  

                                DataRow drTotalIntake = mytable.NewRow(); //Creating Row  
                                drTotalIntake["Details"] = "Total Intake";
                                drTotalIntake["Total"] = choiceCodeResult.TotalIntake;
                                mytable.Rows.Add(drTotalIntake); //adding to datatable  

                                DataRow drCAPotherthanMISeats = mytable.NewRow(); //Creating Row  
                                drCAPotherthanMISeats["Details"] = "CAP other than MI Seats";
                                drCAPotherthanMISeats["Total"] = choiceCodeResult.CAPotherthanMISeats;
                                mytable.Rows.Add(drCAPotherthanMISeats); //adding to datatable

                                DataRow drCAPforMISeats = mytable.NewRow(); //Creating Row  
                                drCAPforMISeats["Details"] = "CAP for MI Seats";
                                drCAPforMISeats["Total"] = choiceCodeResult.CAPforMISeats;
                                mytable.Rows.Add(drCAPforMISeats); //adding to datatable  

                                DataRow drILSeats = mytable.NewRow(); //Creating Row  
                                drILSeats["Details"] = "IL Seats";
                                drILSeats["Total"] = choiceCodeResult.ILSeats;
                                mytable.Rows.Add(drILSeats); //adding to datatable  
                                DataRow drJKSeats = mytable.NewRow(); //Creating Row  
                                drJKSeats["Details"] = "JKSeats";
                                drJKSeats["Total"] = choiceCodeResult.JKSeats;
                                mytable.Rows.Add(drJKSeats); //adding to datatable  

                                gvSummary.DataSource = mytable;
                                gvSummary.DataBind();
                            }
                        }
                        else
                        {
                            shInfo.SetMessage("Error while getting data from Technical Site !", ShowMessageType.Information);
                        }
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
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DataSet ds = GetFromAPI();// reg.getAllChoiceCodeList();
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gvReport = new GridView();
                gvReport.DataSource = ds.Tables[0];
                gvReport.DataBind();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=ChoiceCodeList.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                gvReport.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
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
                    var response = client.GetAsync("api/InstDataForAdmission?viewName=viewChoiceCodeListFromDTEPortalPHARMACY").Result;
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
    }
}