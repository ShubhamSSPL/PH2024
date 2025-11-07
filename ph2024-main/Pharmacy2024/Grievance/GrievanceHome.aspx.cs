using BusinessLayer;
using Org.BouncyCastle.Asn1.Tsp;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.Grievance
{
    public partial class GrievanceHome : System.Web.UI.Page
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
            Session["GrievanceCategoryID"] = null;
            if (!IsPostBack)
            {
                ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
                try
                {
                    DataSet ds = new BusinessServiceImp().GetGrievanceDashboard(Convert.ToInt32(Session["UserTypeID"]), Session["UserLoginID"].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblPendingGrievances.Text = ds.Tables[0].Rows[0]["PendingGrievances"].ToString();
                        lblInProcessGrievances.Text = ds.Tables[0].Rows[0]["InProcessGrievances"].ToString();
                        lblRepliedGrievances.Text = ds.Tables[0].Rows[0]["RepliedGrievances"].ToString();
                    }

                    gvList.DataSource = ds.Tables[1];
                    gvList.DataBind();
                }
                catch (System.Threading.ThreadAbortException t)
                {
                }
                catch (Exception ex)
                {
                    shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
                }
            }
        }
        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (e.CommandName == "PendingGrievances")
                {
                    Session["GrievanceCategoryID"] = Convert.ToInt16(e.CommandArgument);

                    Response.Redirect("../Grievance/PendingGrievanceList.aspx", true);
                }
                else if (e.CommandName == "InProcessGrievances")
                {
                    Session["GrievanceCategoryID"] = Convert.ToInt16(e.CommandArgument);

                    Response.Redirect("../Grievance/InProcessGrievanceList.aspx", true);
                }
                else if (e.CommandName == "RepliedGrievances")
                {
                    Session["GrievanceCategoryID"] = Convert.ToInt16(e.CommandArgument);

                    Response.Redirect("../Grievance/RepliedGrievanceList.aspx", true);
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
        protected void btnPending_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Grievance/PendingGrievanceList.aspx", true);
        }
        protected void btnInProcess_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Grievance/InProcessGrievanceList.aspx", true);
        }
        protected void btnReplied_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Grievance/RepliedGrievanceList.aspx", true);
        }
    }
}