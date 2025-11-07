using BusinessLayer;
using Org.BouncyCastle.Asn1.Tsp;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.Grievance
{
    public partial class CheckGrievanceStatus : System.Web.UI.Page
    {
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
            if (!IsPostBack)
            {
                GetGrievanceList();
            }
        }
        protected void GetGrievanceList()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                gvGrievanceList.DataSource = new BusinessServiceImp().CheckGrievanceStatus(Session["UserLoginID"].ToString(), txtSearch.Text);
                gvGrievanceList.DataBind();
            }
            catch (System.Threading.ThreadAbortException t)
            {
            }
            catch (Exception ex)
            {
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvGrievanceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime SentDateTime = Convert.ToDateTime(e.Row.Cells[4].Text);
                    e.Row.Cells[4].Text = SentDateTime.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", SentDateTime);
                }
            }
            catch (System.Threading.ThreadAbortException t)
            {
            }
            catch (Exception ex)
            {
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void gvGrievanceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 GrievanceID = Convert.ToInt64(e.CommandArgument);

                if (GrievanceID > 0)
                {
                    Response.Redirect("../Grievance/ViewGrievance.aspx?GID=" + GrievanceID + "&Flag=C", true);
                }
            }
            catch (System.Threading.ThreadAbortException t)
            {
            }
            catch (Exception ex)
            {
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetGrievanceList();
        }
    }
}