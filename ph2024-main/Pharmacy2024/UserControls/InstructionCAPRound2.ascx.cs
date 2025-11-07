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
    public partial class InstructionCAPRound2 : System.Web.UI.UserControl
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

                DataSet ds = reg.getAllotmentStatusCAPRound2ByPID(PID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ChoiceCodeAllotted"].ToString().Trim() != "NA")
                    {

                        if (ds.Tables[0].Rows[0]["ChoiceCodeAllottedCAPRound1"].ToString() == "NA")
                        {
                            if (ds.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString() == "1")
                            {
                                trFirstTimeFirstPrefrence.Visible = true;
                            }
                            else
                            {
                                trFirsttimeOtherThanFirstPrefrence.Visible = true;
                            }
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[0]["PreferenceNoAllotted"].ToString() == "1")
                            {
                                trBetermentFirstPreference.Visible = true;
                            }
                            else
                            {
                                trBetermentOtherThanFirstPreference.Visible = true;
                            }
                        }
                    }
                    else
                    {

                        if (ds.Tables[0].Rows[0]["ChoiceCodeAllottedCAPRound1"].ToString() == "NA")
                        {
                            if (ds.Tables[0].Rows[0]["EligibleForCAPRound2"].ToString() == "0")
                            {
                                //lblNotAllotted.Text = "Not Eligible for CAP Round-II. Hence No Seat is Allotted in CAP Round-II.";
                            }
                            else
                            {
                                if (ds.Tables[0].Rows[0]["OptionFormCancelFlag"].ToString() == "C" ||
                                    ds.Tables[0].Rows[0]["OptionFormCancelFlag"].ToString() == "Y")
                                {
                                    // lblNotAllotted.Text = "Option Form is not Confirmed for CAP Round-II. Hence No Seat is Allotted in CAP Round-II.";
                                    trEligibleButNotFilledOptionForm.Visible = true;
                                }
                                else
                                {
                                    // lblNotAllotted.Text = "Not Allotted in CAP Round-II.";
                                    trSubmitOptionNoAllotment.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[0]["EligibleForCAPRound2"].ToString() == "0")
                            {
                                //lblNotAllotted.Text = "Not Eligible for CAP Round-II. Hence No Betterment in CAP Round-II.";
                            }
                            else
                            {
                                if (ds.Tables[0].Rows[0]["OptionFormCancelFlag"].ToString() == "C" ||
                                    ds.Tables[0].Rows[0]["OptionFormCancelFlag"].ToString() == "Y")
                                {
                                    // lblNotAllotted.Text = "Option Form is not Confirmed for CAP Round-II. Hence No Betterment in CAP Round-II.";
                                    trNoBeterment.Visible = true;
                                }
                                else
                                {
                                    // lblNotAllotted.Text = "No Betterment in CAP Round-II.";
                                    trNoBeterment.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                // shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
    }
}