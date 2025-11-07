using Newtonsoft.Json;
using RestSharp;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Msg91EMailHelper
{
    public void SendMsg91EMail(List<Msg91EMailTo> ToEMailID, string TemplateName, Msg91EMailVariables Variables, string ToUserID, string strMsg91TempEmail)
    {
        if (ToEMailID.Count > 0)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["Msg91BaseURL"]);
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/JSON");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("authkey", ConfigurationManager.AppSettings["Msg91AuthorizationKey"]);

            Msg91EMailTemplate msg = new Msg91EMailTemplate();

            msg.to = ToEMailID;
            msg.from.name = ConfigurationManager.AppSettings["Msg91FromName"];
            msg.from.email = ConfigurationManager.AppSettings["Msg91FromEMailID"];
            msg.template_id = TemplateName;
            msg.variables = Variables;

            IRestResponse response = null;
            var body = JsonConvert.SerializeObject(msg);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            response = client.Execute(request);

            new DBUtilityMsg91EMail().SaveSentEMailDetails(ToEMailID[0].email, "", body, response.Content, TemplateName, HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), ToUserID, strMsg91TempEmail);
        }
    }
}
public class Msg91EMailTo
{
    public string name { get; set; }
    public string email { get; set; }
}
public class Msg91EMailFrom
{
    public string name { get; set; }
    public string email { get; set; }
}
public class Msg91EMailVariables
{
    public string VAR1 { get; set; }
    public string VAR2 { get; set; }
    public string VAR3 { get; set; }
    public string VAR4 { get; set; }
    public string VAR5 { get; set; }
    public string VAR6 { get; set; }
    public string VAR7 { get; set; }
    public string VAR8 { get; set; }
    public string VAR9 { get; set; }
    public string VAR10 { get; set; }

    public Msg91EMailVariables()
    {
        VAR1 = "";
        VAR2 = "";
        VAR3 = "";
        VAR4 = "";
        VAR5 = "";
        VAR6 = "";
        VAR7 = "";
        VAR8 = "";
        VAR9 = "";
        VAR10 = "";
    }
}
public class Msg91EMailTemplate
{
    public List<Msg91EMailTo> to { get; set; }
    public Msg91EMailFrom from { get; set; }
    public string template_id { get; set; }
    public Msg91EMailVariables variables { get; set; }

    public Msg91EMailTemplate()
    {
        to = new List<Msg91EMailTo>();
        from = new Msg91EMailFrom();
        variables = new Msg91EMailVariables();
    }
}
public class DBUtilityMsg91EMail
{
    public void SaveSentEMailDetails(string EMailID, string Subject, string Body, string Response, string Template, string SentBy, string SentByIPAddress, string ToUserID, string strMsg91TempEmail)
    {
        DBConnection db = new DBConnection();
        try
        {
            db.ExecuteScaler("MHDTE_spSaveSentEmailDetails", new SqlParameter[]
            {
                new SqlParameter("@EMailID", EMailID),
                new SqlParameter("@Subject", Subject),
                new SqlParameter("@Body", Body),
                new SqlParameter("@Response", Response),
                new SqlParameter("@Template", Template),
                new SqlParameter("@SMSType", "E"),
                new SqlParameter("@SentBy", SentBy),
                new SqlParameter("@SentByIPAddress", SentByIPAddress),
                new SqlParameter("@ToUserID", ToUserID),
                new SqlParameter("@SendEmailMaessage", strMsg91TempEmail)
            });
        }
        finally
        {
            db.Dispose();
        }
    }
}