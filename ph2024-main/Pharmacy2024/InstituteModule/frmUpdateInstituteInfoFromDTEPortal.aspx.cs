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
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.InstituteModule
{
    public partial class frmUpdateInstituteInfoFromDTEPortal : System.Web.UI.Page
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
            

                    gvNewChoiceCode.DataSource = reg.getNewChoiceCodesAvailable();
                    gvNewChoiceCode.DataBind();

                    if (gvNewChoiceCode.Rows.Count == 0)
                    {
                        btnInsertNewChoiceCode.Visible = false;
                        tblMsgNewChoiceCode.Visible = true;
                    }

                    gvUpdateChoiceCode.DataSource = reg.getChoiceCodesAvailableForUpdate();
                    gvUpdateChoiceCode.DataBind();

                    if (gvUpdateChoiceCode.Rows.Count == 0)
                    {
                        btnUpdateChoiceCodes.Visible = false;
                        tblMsgUpdateChoiceCode.Visible = true;
                    }
                    else
                    {
                        Int32 Count = gvUpdateChoiceCode.Rows.Count;
                        for (Int32 i = 0; i < Count; i++)
                        {
                            if (gvUpdateChoiceCode.Rows[i].Cells[1].Text != gvUpdateChoiceCode.Rows[i].Cells[2].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[1].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[2].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[3].Text != gvUpdateChoiceCode.Rows[i].Cells[4].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[3].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[4].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[5].Text != gvUpdateChoiceCode.Rows[i].Cells[6].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[5].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[6].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[7].Text != gvUpdateChoiceCode.Rows[i].Cells[8].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[7].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[8].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[9].Text != gvUpdateChoiceCode.Rows[i].Cells[10].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[9].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[10].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[11].Text != gvUpdateChoiceCode.Rows[i].Cells[12].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[11].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[12].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[13].Text != gvUpdateChoiceCode.Rows[i].Cells[14].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[13].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[14].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[15].Text != gvUpdateChoiceCode.Rows[i].Cells[16].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[15].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[16].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[17].Text != gvUpdateChoiceCode.Rows[i].Cells[18].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[17].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[18].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[19].Text != gvUpdateChoiceCode.Rows[i].Cells[20].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[19].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[20].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[21].Text != gvUpdateChoiceCode.Rows[i].Cells[22].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[21].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[22].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[23].Text != gvUpdateChoiceCode.Rows[i].Cells[24].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[23].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[24].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[25].Text != gvUpdateChoiceCode.Rows[i].Cells[26].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[25].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[26].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[27].Text != gvUpdateChoiceCode.Rows[i].Cells[28].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[27].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[28].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[29].Text != gvUpdateChoiceCode.Rows[i].Cells[30].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[29].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[30].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[31].Text != gvUpdateChoiceCode.Rows[i].Cells[32].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[31].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[32].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[33].Text != gvUpdateChoiceCode.Rows[i].Cells[34].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[33].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[34].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[35].Text != gvUpdateChoiceCode.Rows[i].Cells[36].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[35].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[36].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[37].Text != gvUpdateChoiceCode.Rows[i].Cells[38].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[37].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[38].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[39].Text != gvUpdateChoiceCode.Rows[i].Cells[40].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[39].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[40].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[41].Text != gvUpdateChoiceCode.Rows[i].Cells[42].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[41].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[42].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[43].Text != gvUpdateChoiceCode.Rows[i].Cells[44].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[43].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[44].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[45].Text != gvUpdateChoiceCode.Rows[i].Cells[46].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[45].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[46].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[47].Text != gvUpdateChoiceCode.Rows[i].Cells[48].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[47].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[48].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[49].Text != gvUpdateChoiceCode.Rows[i].Cells[50].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[49].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[50].BackColor = System.Drawing.Color.Red;
                            }
                        }
                    }

                    gvDeleteChoiceCode.DataSource = reg.getChoiceCodesAvailableForDelete();
                    gvDeleteChoiceCode.DataBind();

                    if (gvDeleteChoiceCode.Rows.Count == 0)
                    {
                        btnDeleteChoiceCodes.Visible = false;
                        tblMsgDeleteChoiceCode.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void btnInsertNewChoiceCode_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
              

                if (reg.insertNewChoiceCodes(Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    gvNewChoiceCode.DataSource = reg.getNewChoiceCodesAvailable();
                    gvNewChoiceCode.DataBind();

                    if (gvNewChoiceCode.Rows.Count == 0)
                    {
                        btnInsertNewChoiceCode.Visible = false;
                        tblMsgNewChoiceCode.Visible = true;
                    }

                    shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnUpdateChoiceCodes_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                 

                if (reg.updateChoiceCodes(Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    gvUpdateChoiceCode.DataSource = reg.getChoiceCodesAvailableForUpdate();
                    gvUpdateChoiceCode.DataBind();

                    if (gvUpdateChoiceCode.Rows.Count == 0)
                    {
                        btnUpdateChoiceCodes.Visible = false;
                        tblMsgUpdateChoiceCode.Visible = true;
                    }
                    else
                    {
                        Int32 Count = gvUpdateChoiceCode.Rows.Count;
                        for (Int32 i = 0; i < Count; i++)
                        {
                            if (gvUpdateChoiceCode.Rows[i].Cells[1].Text != gvUpdateChoiceCode.Rows[i].Cells[2].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[1].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[2].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[3].Text != gvUpdateChoiceCode.Rows[i].Cells[4].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[3].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[4].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[5].Text != gvUpdateChoiceCode.Rows[i].Cells[6].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[5].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[6].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[7].Text != gvUpdateChoiceCode.Rows[i].Cells[8].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[7].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[8].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[9].Text != gvUpdateChoiceCode.Rows[i].Cells[10].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[9].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[10].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[11].Text != gvUpdateChoiceCode.Rows[i].Cells[12].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[11].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[12].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[13].Text != gvUpdateChoiceCode.Rows[i].Cells[14].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[13].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[14].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[15].Text != gvUpdateChoiceCode.Rows[i].Cells[16].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[15].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[16].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[17].Text != gvUpdateChoiceCode.Rows[i].Cells[18].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[17].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[18].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[19].Text != gvUpdateChoiceCode.Rows[i].Cells[20].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[19].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[20].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[21].Text != gvUpdateChoiceCode.Rows[i].Cells[22].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[21].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[22].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[23].Text != gvUpdateChoiceCode.Rows[i].Cells[24].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[23].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[24].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[25].Text != gvUpdateChoiceCode.Rows[i].Cells[26].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[25].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[26].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[27].Text != gvUpdateChoiceCode.Rows[i].Cells[28].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[27].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[28].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[29].Text != gvUpdateChoiceCode.Rows[i].Cells[30].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[29].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[30].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[31].Text != gvUpdateChoiceCode.Rows[i].Cells[32].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[31].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[32].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[33].Text != gvUpdateChoiceCode.Rows[i].Cells[34].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[33].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[34].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[35].Text != gvUpdateChoiceCode.Rows[i].Cells[36].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[35].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[36].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[37].Text != gvUpdateChoiceCode.Rows[i].Cells[38].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[37].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[38].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[39].Text != gvUpdateChoiceCode.Rows[i].Cells[40].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[39].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[40].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[41].Text != gvUpdateChoiceCode.Rows[i].Cells[42].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[41].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[42].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[43].Text != gvUpdateChoiceCode.Rows[i].Cells[44].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[43].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[44].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[45].Text != gvUpdateChoiceCode.Rows[i].Cells[46].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[45].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[46].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[47].Text != gvUpdateChoiceCode.Rows[i].Cells[48].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[47].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[48].BackColor = System.Drawing.Color.Red;
                            }
                            if (gvUpdateChoiceCode.Rows[i].Cells[49].Text != gvUpdateChoiceCode.Rows[i].Cells[50].Text)
                            {
                                gvUpdateChoiceCode.Rows[i].Cells[49].BackColor = System.Drawing.Color.Red;
                                gvUpdateChoiceCode.Rows[i].Cells[50].BackColor = System.Drawing.Color.Red;
                            }
                        }
                    }

                    shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnDeleteChoiceCodes_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
   

                if (reg.deleteChoiceCodes(Session["UserLoginID"].ToString(), UserInfo.GetIPAddress()))
                {
                    gvDeleteChoiceCode.DataSource = reg.getChoiceCodesAvailableForDelete();
                    gvDeleteChoiceCode.DataBind();

                    if (gvDeleteChoiceCode.Rows.Count == 0)
                    {
                        btnDeleteChoiceCodes.Visible = false;
                        tblMsgDeleteChoiceCode.Visible = true;
                    }

                    shInfo.SetMessage("Information Saved Successfully.", ShowMessageType.Information);
                }
                else
                {
                    shInfo.SetMessage("There is some problem in Data Saving. Please try again.", ShowMessageType.UserError);
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        //public DataSet GetFromAPI()
        //{
        //    //List<Table> lstchoiceCode = new List<Table>();
        //    DataSet myDataSet = new DataSet();
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["TechnicalSiteUrl"]);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //            var response = client.GetAsync("api/InstDataForAdmission?viewName=viewChoiceCodeListFromDTEPortalPHARMACY").Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                string responseString = response.Content.ReadAsStringAsync().Result;
        //                //JObject json =  JObject.Parse(responseString);
        //                dynamic parsedJson = JsonConvert.DeserializeObject(responseString);
        //                myDataSet = JsonConvert.DeserializeObject<DataSet>(parsedJson);
        //                // lstchoiceCode =  JsonConvert.DeserializeObject<List<Table>>(parsedJson);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        long messageID = ExceptionMessages.GetMessageDetails();
        //        new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "api/InstDataForAdmission?degreeLevel=UG&degreeName=PHARMACY", "");
        //    }
        //    return myDataSet;
        //}
    }
}