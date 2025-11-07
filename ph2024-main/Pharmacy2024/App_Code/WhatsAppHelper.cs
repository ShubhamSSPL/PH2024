using Newtonsoft.Json;
using RestSharp;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;

public class WhatsAppHelper
{
    public void SendWhatsAppMessage(string MobileNo, string TemplateName, string MessageType, List<WhatsAppMessageParameter> Parameters, string ToUserID, string strWhatupTemplate)
    {
        if (MobileNo.Length == 10)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["WhatsAppBaseURL"]);
            var request = new RestRequest(Method.POST);

            request.AddHeader("authorization", ConfigurationManager.AppSettings["WhatsAppAuthorizationKey"]);
            request.AddHeader("Content-Type", "application/json");

            WhatsAppMessageEntity entity = new WhatsAppMessageEntity();

            entity.to = "91" + MobileNo;
            entity.type = "template";
            entity.template.name = TemplateName.ToLower();
            entity.template.language.code = "en";
            if (MessageType == "C")
            {
                WhatsAppMessageComponent whatsAppMessageComponent = new WhatsAppMessageComponent();

                whatsAppMessageComponent.type = "body";
                whatsAppMessageComponent.parameters = Parameters;

                entity.template.components.Add(whatsAppMessageComponent);
            }

            IRestResponse response = null;
            var body = JsonConvert.SerializeObject(entity);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            response = client.Execute(request);

            new DBUtilityWhatsApp().SaveSentWhatsAppDetails(MobileNo, body, response.StatusCode.ToString() == "OK" ? response.Content : response.ErrorMessage, TemplateName, HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), ToUserID, strWhatupTemplate);
        }
    }
    public void SendWhatsAppMessageMSG91(string MobileNo, string TemplateName, string MessageType, List<WhatsAppMessageParameter> Parameters, string ToUserID, string strWhatupTemplate)
    {
        if (MobileNo.Length == 10)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["WhatsAppMS91BaseURL"]);
            var request = new RestRequest(Method.POST);

            request.AddHeader("authkey", ConfigurationManager.AppSettings["WhatsAppMSG91AuthorizationKey"]);
            request.AddHeader("Content-Type", "application/json");

            WhatsAppMessageEntityMSG91 entity = new WhatsAppMessageEntityMSG91();
            entity.integrated_number = ConfigurationManager.AppSettings["WhatsAppMSG91IntegratedNumber"].ToString();
            entity.to = "91" + MobileNo;
            entity.type = "template";

            entity.template.name = TemplateName.ToLower();
            entity.template.language.code = "en";
            if (MessageType == "C")
            {
                WhatsAppMessageComponent whatsAppMessageComponent = new WhatsAppMessageComponent();

                whatsAppMessageComponent.type = "body";
                whatsAppMessageComponent.parameters = Parameters;

                entity.template.components.Add(whatsAppMessageComponent);
            }
            var jsonData = new
            {
                integrated_number = entity.integrated_number,
                content_type = "template",
                payload = new
                {
                    to = entity.to,
                    type = entity.type,
                    template = new
                    {
                        name = entity.template.name,
                        language = new
                        {
                            code = entity.template.language.code,
                            policy = "deterministic"
                        },
                        components =
                     entity.template.components

                    },
                    messaging_product = "whatsapp"
                }
            };
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);

            new DBUtilityWhatsApp().SaveSentWhatsAppDetails(MobileNo, body, response.StatusCode.ToString() == "OK" ? response.Content : response.ErrorMessage, TemplateName, HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), ToUserID, strWhatupTemplate);
        }
    }
}
public class WhatsAppMessageLanguage
{
    public string code { get; set; }
}
public class WhatsAppMessageParameter
{
    public string type { get; set; }
    public string text { get; set; }
}
public class WhatsAppMessageComponent
{
    public string type { get; set; }
    public List<WhatsAppMessageParameter> parameters { get; set; }

    public WhatsAppMessageComponent()
    {
        parameters = new List<WhatsAppMessageParameter>();
    }
}
public class WhatsAppMessageTemplate
{
    public string name { get; set; }
    public WhatsAppMessageLanguage language { get; set; }
    public List<WhatsAppMessageComponent> components { get; set; }

    public WhatsAppMessageTemplate()
    {
        language = new WhatsAppMessageLanguage();
        components = new List<WhatsAppMessageComponent>();
    }
}
public class WhatsAppMessageEntity
{
    public string to { get; set; }
    public string type { get; set; }
    public WhatsAppMessageTemplate template { get; set; }

    public WhatsAppMessageEntity()
    {
        template = new WhatsAppMessageTemplate();
    }
}
public class WhatsAppMessageEntityMSG91
{
    public string integrated_number { get; set; }
    public string to { get; set; }
    public string type { get; set; }
    public WhatsAppMessageTemplate template { get; set; }

    public WhatsAppMessageEntityMSG91()
    {
        template = new WhatsAppMessageTemplate();
    }
}
public class DBUtilityWhatsApp
{
    public void SaveSentWhatsAppDetails(string MobileNo, string Message, string Response, string Template, string SentBy, string SentByIPAddress, string ToUserID, string WhatsUpMessage)
    {
        DBConnection db = new DBConnection();
        try
        {
            db.ExecuteScaler("MHDTE_spSaveSentSMSDetails", new SqlParameter[]
            {
                new SqlParameter("@MobileNo", MobileNo),
                new SqlParameter("@Message", Message),
                new SqlParameter("@Response", Response),
                new SqlParameter("@Template", Template),
                new SqlParameter("@SMSType", "W"),
                new SqlParameter("@SentBy", SentBy),
                new SqlParameter("@SentByIPAddress", SentByIPAddress),
                new SqlParameter("@ToUserID", ToUserID),
                new SqlParameter("@WhatsUpMessage", WhatsUpMessage)
            });
        }
        finally
        {
            db.Dispose();
        }
    }
}