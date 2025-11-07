using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmFCWiseSlotBookingStausReport : System.Web.UI.Page
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
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            if (Session["UserTypeID"] == null || Session["UserTypeID"].ToString() == "91")
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            if (!IsPostBack)
            {
                try
                {
                    //gvEFC.DataSource = reg.GetEFCRegistrationandConfirmationStatusReport();
                    //gvEFC.DataBind();

                    gvReport.DataSource = reg.getFCWiseSlotBookingStausReport();
                    gvReport.DataBind();
                    Int32 Count = gvReport.Rows.Count;
                    Int32 colCount = gvReport.HeaderRow.Cells.Count;
                    //gvReport.Columns[1].ItemStyle.Width = 50;
                    for (Int32 i = 0; i < Count; i++)
                    {
                        gvReport.Rows[i].Cells[0].Width = new Unit("300px");
                        for (Int32 j = 1; j < colCount; j++)
                        {
                            //gvReport.Rows[i].Cells[1].Text = Convert.ToDateTime(gvReport.Rows[i].Cells[1].Text).ToString("dd/MM/yyyy");
                            gvReport.Rows[i].Cells[j].BackColor = ValidateSlotColor(gvReport.Rows[i].Cells[j].Text);
                        }
                        //gvReport.Rows[i].Cells[3].BackColor = ValidateSlotColor(gvReport.Rows[i].Cells[3].Text);
                        //gvReport.Rows[i].Cells[4].BackColor = ValidateSlotColor(gvReport.Rows[i].Cells[4].Text);
                        //gvReport.Rows[i].Cells[5].BackColor = ValidateSlotColor(gvReport.Rows[i].Cells[5].Text);
                        //gvReport.Rows[i].Cells[6].BackColor = ValidateSlotColor(gvReport.Rows[i].Cells[6].Text);
                        //gvReport.Rows[i].Cells[7].BackColor = ValidateSlotColor(gvReport.Rows[i].Cells[7].Text);
                        //gvReport.Rows[i].Cells[8].BackColor = ValidateSlotColor(gvReport.Rows[i].Cells[8].Text);


                        //if (gvReport.Rows[i].Cells[1].Text == "10/10/2026")
                        //{
                        //    gvReport.Rows[i].Cells[1].Text = "Total";
                        //}
                    }
                    lblPrintedOn.Text = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);
                }
                catch (Exception ex)
                {
                    Logging.LogException(ex, "[Page Level Error]");
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        public Color ValidateSlotColor(string result)
        {
            string[] slot = result.Split('/');
            if (slot.Length > 1)
            { 
                if(Convert.ToInt32(slot[1]) !=0)
                {
                    decimal percent = (Convert.ToInt32(slot[0]) / Convert.ToInt32(slot[1])) * 100;
                    if (percent < 20)
                        return System.Drawing.Color.Green;
                    else if (percent > 20 && percent < 60)
                        return System.Drawing.Color.Yellow;
                    else if (percent > 59 && percent < 90)
                        return System.Drawing.Color.Magenta;
                    else if (percent >= 90)
                        return System.Drawing.Color.Red;
                    else
                        return System.Drawing.Color.White;
                }
                else
                {
                    return System.Drawing.Color.White;
                }
            }
            else
                return System.Drawing.Color.White;
        }
    }
}