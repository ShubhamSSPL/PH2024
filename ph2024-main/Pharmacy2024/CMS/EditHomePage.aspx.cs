using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxPro;
using Synthesys.CMS.BusinessLayer;
public partial class StaticPages_HomePage : System.Web.UI.Page
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(StaticPages_HomePage));
        #region pageload
        //Session.Abandon();
        //Session.Clear();
        // hddImportantDates.Value = "0";
        DataSet ds = null;
        DataSet dsPanelData = null;
        hddImportantDates.Value = "0";
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.GetMenuForPanel();
            if (!IsPostBack)
            {
                dsPanelData = obj.GetData();
                if (dsPanelData.Tables.Count > 0)
                {
                    if (dsPanelData.Tables[0].Rows.Count > 0)
                    {
                        HdnCookie.Value = dsPanelData.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Panel2List.Rows.Clear();
                    Panel3List.Rows.Clear();
                    Panel4List.Rows.Clear();
                    Panel5List.Rows.Clear();
                    tbllogin.Rows.Clear();
                    HtmlTableRow tr;
                    HtmlTableCell td;
                    HyperLink hp;
                    Literal lit;
                    Image SepImg;
                    HpLinkPanel2.NavigateUrl = "~/CMS/ListOfLinks.aspx?gid=2";
                    HpLinkPanel3.NavigateUrl = "~/CMS/ListOfLinks.aspx?gid=3";
                    HpLinkPanel4.NavigateUrl = "~/CMS/ListOfLinks.aspx?gid=4";
                    HpLinkPanel5.NavigateUrl = "~/CMS/ListOfLinks.aspx?gid=5";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Image img = new Image();
                        img.ImageUrl = "~/SynthesysModules_Files/Images/brownbullet12.gif";
                        switch (ds.Tables[0].Rows[i]["GroupID"].ToString())
                        {
                            case "1":
                                if (int.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                                {
                                    hp = new HyperLink();
                                    hp.Text = " " + ds.Tables[0].Rows[i]["MenuName"].ToString() + " ";
                                    hp.NavigateUrl = ds.Tables[0].Rows[i]["MenuUrl"].ToString();
                                    hp.CssClass = "text";
                                    panel1marquee.Controls.Add(hp);
                                    SepImg = new Image();
                                    SepImg.ImageUrl = "~/SynthesysModules_Files/Images/large-dia7.gif";
                                    panel1marquee.Controls.Add(SepImg);
                                }
                                else
                                {
                                    lit = new Literal();
                                    lit.Text = " " + ds.Tables[0].Rows[i]["MenuName"].ToString() + " ";
                                    panel1marquee.Controls.Add(lit);
                                    SepImg = new Image();
                                    SepImg.ImageUrl = "~/SynthesysModules_Files/Images/large-dia7.gif";
                                    panel1marquee.Controls.Add(SepImg);
                                }
                                break;
                            case "2":
                                if (Panel2List.Rows.Count < 3)
                                {
                                    tr = new HtmlTableRow();
                                    td = new HtmlTableCell();
                                    td.VAlign = "top";
                                    td.Controls.Add(img);
                                    tr.Cells.Add(td);
                                    td = new HtmlTableCell();
                                    if (int.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                                    {
                                        hp = new HyperLink();
                                        hp.Text = ds.Tables[0].Rows[i]["MenuName"].ToString();
                                        hp.NavigateUrl = ds.Tables[0].Rows[i]["MenuUrl"].ToString();
                                        td.Controls.Add(hp);
                                    }
                                    else
                                    {
                                        td.InnerHtml = ds.Tables[0].Rows[i]["MenuName"].ToString();
                                        // td.Attributes.Add("class", "middleboxtext");
                                    }
                                    td.VAlign = "top";
                                    tr.Cells.Add(td);
                                    Panel2List.Rows.Add(tr);
                                }
                                else if (Panel2List.Rows.Count == 3)
                                {
                                    HpLinkPanel2.Visible = true;
                                }
                                break;
                            case "3":
                                if (Panel3List.Rows.Count < 3)
                                {
                                    tr = new HtmlTableRow();
                                    td = new HtmlTableCell();
                                    td.VAlign = "top";
                                    td.Controls.Add(img);
                                    tr.Cells.Add(td);
                                    td = new HtmlTableCell();
                                    if (int.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                                    {
                                        hp = new HyperLink();
                                        hp.Text = ds.Tables[0].Rows[i]["MenuName"].ToString();
                                        hp.NavigateUrl = ds.Tables[0].Rows[i]["MenuUrl"].ToString();
                                        td.Controls.Add(hp);
                                    }
                                    else
                                    {
                                        td.InnerHtml = ds.Tables[0].Rows[i]["MenuName"].ToString();
                                        //td.Attributes.Add("class", "middleboxtext");
                                    }
                                    td.VAlign = "top";

                                    tr.Cells.Add(td);
                                    Panel3List.Rows.Add(tr);
                                }
                                else if (Panel3List.Rows.Count == 3)
                                {
                                    HpLinkPanel3.Visible = true;
                                }
                                break;
                            case "4":
                                if (Panel4List.Rows.Count < 3)
                                {
                                    tr = new HtmlTableRow();
                                    td = new HtmlTableCell();
                                    td.VAlign = "top";
                                    td.Controls.Add(img);
                                    tr.Cells.Add(td);
                                    td = new HtmlTableCell();
                                    if (int.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                                    {
                                        hp = new HyperLink();
                                        hp.Text = ds.Tables[0].Rows[i]["MenuName"].ToString();
                                        hp.NavigateUrl = ds.Tables[0].Rows[i]["MenuUrl"].ToString();
                                        td.Controls.Add(hp);
                                    }
                                    else
                                    {
                                        td.InnerHtml = ds.Tables[0].Rows[i]["MenuName"].ToString();
                                        //td.Attributes.Add("class", "middleboxtext");
                                    }
                                    td.VAlign = "top";
                                    tr.Cells.Add(td);
                                    Panel4List.Rows.Add(tr);
                                }
                                else if (Panel4List.Rows.Count == 3)
                                {
                                    HpLinkPanel4.Visible = true;
                                }
                                break;
                            case "5":
                                if (Panel5List.Rows.Count < 3)
                                {
                                    tr = new HtmlTableRow();
                                    td = new HtmlTableCell();
                                    td.VAlign = "top";
                                    td.Controls.Add(img);
                                    tr.Cells.Add(td);
                                    td = new HtmlTableCell();
                                    if (int.Parse(ds.Tables[0].Rows[i]["TypeOfMenu"].ToString()) != 3)
                                    {
                                        hp = new HyperLink();
                                        hp.Text = ds.Tables[0].Rows[i]["MenuName"].ToString();
                                        hp.NavigateUrl = ds.Tables[0].Rows[i]["MenuUrl"].ToString();
                                        td.Controls.Add(hp);
                                    }
                                    else
                                    {
                                        td.InnerHtml = ds.Tables[0].Rows[i]["MenuName"].ToString();
                                        //td.Attributes.Add("class", "middleboxtext");
                                    }
                                    td.VAlign = "top";
                                    tr.Cells.Add(td);
                                    Panel5List.Rows.Add(tr);
                                }
                                else if (Panel5List.Rows.Count == 3)
                                {
                                    HpLinkPanel5.Visible = true;
                                }
                                break;
                            case "6":
                                tr = new HtmlTableRow();
                                td = new HtmlTableCell();
                                td.Attributes.Add("class", "loginbtn");
                                hp = new HyperLink();
                                hp.Text = ds.Tables[0].Rows[i]["MenuName"].ToString();
                                hp.NavigateUrl = ds.Tables[0].Rows[i]["MenuUrl"].ToString();
                                td.Controls.Add(hp);
                                tr.Cells.Add(td);
                                tbllogin.Rows.Add(tr);
                                //li = new ListItem(ds.Tables[0].Rows[i]["MenuName"].ToString(), ds.Tables[0].Rows[i]["MenuUrl"].ToString());
                                //PanelLogin.Items.Add(li);
                                break;
                            case "10":
                                Panel6List.Visible = true;
                                // btnPanel6.Text = Regex.Replace(ds.Tables[0].Rows[i]["MenuName"].ToString(), "(.*?)<.*", "$1");

                                btnPanel6.Text = ds.Tables[0].Rows[i]["MenuName"].ToString();
                                btnPanel6.PostBackUrl = ds.Tables[0].Rows[i]["MenuUrl"].ToString();
                                break;
                                //case "11":
                                //    Panel7List.Visible = true;
                                //    hddImportantDates.Value = "1";
                                //    break;
                        }
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        switch (ds.Tables[1].Rows[i]["GroupId"].ToString())
                        {
                            case "1":
                                LblPanel1.Text = ds.Tables[1].Rows[i]["GroupDisplayText"].ToString();
                                break;
                            case "2":
                                LblPanel2.Text = ds.Tables[1].Rows[i]["GroupDisplayText"].ToString();
                                break;
                            case "3":
                                LblPanel3.Text = ds.Tables[1].Rows[i]["GroupDisplayText"].ToString();
                                break;
                            case "4":
                                LblPanel4.Text = ds.Tables[1].Rows[i]["GroupDisplayText"].ToString();
                                break;
                            case "5":
                                LblPanel5.Text = ds.Tables[1].Rows[i]["GroupDisplayText"].ToString();
                                break;
                            case "6":
                                CBLogIn.HeaderText = ds.Tables[1].Rows[i]["GroupDisplayText"].ToString();
                                break;

                        }
                    }
                }

            }

        }
        catch (DataException dex)
        {
        }
        finally
        {
            if (ds != null)
            {
                ds.Dispose();
                ds = null;

            }

        }
        #endregion 
    }

    protected void BtnSaveData_Click(object sender, EventArgs e)
    {
        DataSet ds = null;
        try
        {
            BusinessServiceImp obj = new BusinessServiceImp();
            ds = obj.SaveData(HdnCookie.Value);

        }
        catch (DataException dex)
        {

            //showMsg.SetMessage(dex);
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

    [AjaxMethod]
    public DataSet RenderEvents(string id)
    {
        BusinessServiceImp obj = new BusinessServiceImp();
        DataSet ds = obj.RenderEvents();
        return ds;
    }
}
