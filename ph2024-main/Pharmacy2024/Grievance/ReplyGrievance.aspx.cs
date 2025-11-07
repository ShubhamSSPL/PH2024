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
using Pharmacy2024.UserControls;

namespace Pharmacy2024.Grievance
{
    public partial class ReplyGrievance : System.Web.UI.Page
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
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Pharmacy2024.ViewMessageBoxDocument));
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
                Int64 GrievanceID = Convert.ToInt64(Request.QueryString["GID"].ToString());
                Int16 IsAllGrievancesReplied = 1;

                DataTable dt = new BusinessServiceImp().GetGrievanceList(GrievanceID).Tables[0];

                for (Int32 i = 0; i < dt.Rows.Count; i++)
                {
                    GrievanceInfo grievanceInfo = (GrievanceInfo)LoadControl("~/UserControls/GrievanceInfo.ascx");

                    grievanceInfo._GrievanceID = dt.Rows[i]["GrievanceID"].ToString();
                    grievanceInfo._ApplicationID = dt.Rows[i]["ApplicationID"].ToString();
                    grievanceInfo._GrievanceCategory = dt.Rows[i]["GrievanceCategory"].ToString();
                    grievanceInfo._SentBy = dt.Rows[i]["SentBy"].ToString();
                    grievanceInfo._SentDateTime = Convert.ToDateTime(dt.Rows[i]["SentDateTime"].ToString());
                    grievanceInfo._Grievance = dt.Rows[i]["Grievance"].ToString();
                    grievanceInfo._GrievanceFileURL = dt.Rows[i]["GrievanceFileURL"].ToString();
                    grievanceInfo._RepliedBy = dt.Rows[i]["RepliedBy"].ToString();
                    grievanceInfo._RepliedDateTime = dt.Rows[i]["RepliedDateTime"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(dt.Rows[i]["RepliedDateTime"].ToString());
                    grievanceInfo._RepliedGrievance = dt.Rows[i]["RepliedGrievance"].ToString();
                    grievanceInfo._RepliedGrievanceFileURL = dt.Rows[i]["RepliedGrievanceFileURL"].ToString();
                    grievanceInfo._GrievanceStatus = dt.Rows[i]["GrievanceStatus"].ToString();
                    grievanceInfo._GrievanceStatusUpdatedDateTime = Convert.ToDateTime(dt.Rows[i]["CurrentStatusUpdatedDateTime"].ToString());

                    plcGrievance.Controls.Add(grievanceInfo);

                    if (dt.Rows[i]["RepliedGrievance"].ToString().Length == 0)
                    {
                        IsAllGrievancesReplied = 0;
                    }
                }

                divReply.Visible = false;

                if (IsAllGrievancesReplied == 0)
                {
                    divReply.Visible = true;
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
        protected void btnReply_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                Int64 GrievanceID = Convert.ToInt64(Request.QueryString["GID"].ToString());
                string RepliedGrievance = txtRepliedGrievance.Text;
                string RepliedGrievanceFileURL = "";
                if (fileAttachment.PostedFile.ContentLength > 0)
                {
                    Stream objStream = fileAttachment.PostedFile.InputStream;
                    FileInfo objFileInfo = new FileInfo(fileAttachment.PostedFile.FileName);
                    string fileName = Session["UserLoginID"].ToString() + "_" + DateTime.Now.Ticks.ToString() + objFileInfo.Extension;

                    RepliedGrievanceFileURL = new AzureDocumentUpload().UploadDocument(ConfigurationManager.AppSettings["BlobContainerName"].ToLower(), fileName.ToLower(), objStream, fileAttachment.PostedFile.ContentType, "grievance");

                    if (string.IsNullOrEmpty(RepliedGrievanceFileURL))
                    {
                        shInfo.SetMessage("Error has encountered during file upload. Please try again.", ShowMessageType.UserError);
                        return;
                    }
                }
                string UserLoginID = Session["UserLoginID"].ToString();
                string IPAddress = UserInfo.GetIPAddress();

                string returnValue = new BusinessServiceImp().ReplyGrievance(GrievanceID, RepliedGrievance, RepliedGrievanceFileURL, UserLoginID, IPAddress);
                if (returnValue == "Y")
                {
                    GetGrievanceList();

                    txtRepliedGrievance.Text = "";

                    shInfo.SetMessage("Ticket Replied Successfully.", ShowMessageType.Information);
                }
                else
                {
                    GetGrievanceList();

                    shInfo.SetMessage(returnValue, ShowMessageType.UserError);
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