using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pharmacy2024.UserControls
{
    public partial class InstructionCAPRound3 : System.Web.UI.UserControl
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                
                Int64 PID = 0;
                if (Session["UserTypeID"].ToString() == "91")
                {
                    PID = Convert.ToInt64(Session["UserID"].ToString());
                }
                else
                {
                    PID = Convert.ToInt64(Request.QueryString["PID"].ToString());
                }

                DataSet ds = reg.getAllotmentStatusCAPRound3ByPID(PID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ChoiceCodeAllotted"].ToString().Trim() != "NA")
                    {

                        if (ds.Tables[0].Rows[0]["ChoiceCodeAllottedCAPRound1and2"].ToString() == "NA")
                        {
                            trFirstTime.Visible = true;
                        }
                        else
                        {
                            trBeterment.Visible = true;
                        }
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[0]["ChoiceCodeAllottedCAPRound1and2"].ToString() == "NA")
                        {
                            if (ds.Tables[0].Rows[0]["OptionFormCancelFlag"].ToString() == "C" || ds.Tables[0].Rows[0]["OptionFormCancelFlag"].ToString() == "Y")
                            {
                                trEligibleButNotFilledOptionForm.Visible = true;
                            }
                            else
                            {
                                trSubmitOptionNoAllotment.Visible = true;
                            }
                        }
                        else
                        {
                            trNoBeterment.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
            }
        }
    }
}