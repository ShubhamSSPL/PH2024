using DataAccess.Implementation;
using EntityModel;
using forProjectCustomExceptions;
using Newtonsoft.Json;
using RestSharp;
using SynthesysDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;


public class SMS
{
    //string userName = "dtemumbai-mtcet";
    //string password = "Mtcet#123";
    string senderID = ConfigurationManager.AppSettings["SMSSenderID"];
    string secureKeyOTP = ConfigurationManager.AppSettings["SMSSecureKey"];
    string url = ConfigurationManager.AppSettings["SMSOTPUrl"]; //"http://control.msg91.com/api/sendotp.php?";
    string normalUrl = ConfigurationManager.AppSettings["SMSNormalUrl"]; //"http://api.msg91.com/api/sendhttp.php?";
    string voiccallURL = ConfigurationManager.AppSettings["SMSOTPVoiceUrl"];//"http://control.msg91.com/api/retryotp.php?";
    string bulkSMSAPIURL = ConfigurationManager.AppSettings["BulkSMSAPIURL"];
    public String sendSingleSMS(string mobileNo, string message)
    {

        String query = normalUrl + "sender=" + senderID + "&route=4&mobiles=91" + mobileNo + "&authkey=" + secureKeyOTP + "&country=0&message=" + message;
        HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(query);
        HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
        System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
        string responseString = respStreamReader.ReadToEnd();
        respStreamReader.Close();
        myResp.Close();

        //Stream dataStream;
        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //request.ProtocolVersion = HttpVersion.Version10;
        //request.KeepAlive = false;
        //request.ServicePoint.ConnectionLimit = 1;
        //((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        //request.Method = "POST";

        //String encryptedPassword = encryptPasswod(password);
        //String newSecureKey = hashGenerator(userName, senderID, message, secureKey);
        //String smsServiceType = "singlemsg";
        //String query = "username=" + HttpUtility.UrlEncode(userName) + "&password=" + HttpUtility.UrlEncode(encryptedPassword) + "&smsservicetype=" + HttpUtility.UrlEncode(smsServiceType) + "&content=" + HttpUtility.UrlEncode(message) + "&mobileno=" + HttpUtility.UrlEncode(mobileNo) + "&senderid=" + HttpUtility.UrlEncode(senderID) + "&key=" + HttpUtility.UrlEncode(newSecureKey);
        //byte[] byteArray = Encoding.ASCII.GetBytes(query);

        //request.ContentType = "application/x-www-form-urlencoded";
        //request.ContentLength = byteArray.Length;
        //dataStream = request.GetRequestStream();
        //dataStream.Write(byteArray, 0, byteArray.Length);
        //dataStream.Close();

        //WebResponse response = request.GetResponse();
        //String Status = ((HttpWebResponse)response).StatusDescription;
        //dataStream = response.GetResponseStream();
        //StreamReader reader = new StreamReader(dataStream);
        //String responseFromServer = reader.ReadToEnd();

        //reader.Close();
        //dataStream.Close();
        //response.Close();

        DBUtilitySMS reg = new DBUtilitySMS();
        reg.savedSentSMSDetails(mobileNo, message, responseString, HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), "N","","");

        return responseString;
    }
    public String sendOTPSMS(string mobileNo, string message, string OTP)
    {
        String query = url + "&authkey=" + secureKeyOTP + "&message=" + message + "&sender=" + senderID + "&mobile=91" + mobileNo + "&otp=" + OTP;

        HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(query);
        HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
        System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
        string responseString = respStreamReader.ReadToEnd();
        respStreamReader.Close();
        myResp.Close();
        DBUtilitySMS reg = new DBUtilitySMS();
        reg.savedSentSMSDetails(mobileNo, message, responseString, HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), "O","","");

        //Stream dataStream;
        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //request.ProtocolVersion = HttpVersion.Version10;
        //request.KeepAlive = false;
        //request.ServicePoint.ConnectionLimit = 1;
        //((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        //request.Method = "POST";

        //String encryptedPassword = encryptPasswod(password);
        //String newSecureKey = hashGenerator(userName, senderID, message, secureKey);
        //String smsServiceType = "otpmsg";
        //String query = "username=" + HttpUtility.UrlEncode(userName) + "&password=" + HttpUtility.UrlEncode(encryptedPassword) + "&smsservicetype=" + HttpUtility.UrlEncode(smsServiceType) + "&content=" + HttpUtility.UrlEncode(message) + "&mobileno=" + HttpUtility.UrlEncode(mobileNo) + "&senderid=" + HttpUtility.UrlEncode(senderID) + "&key=" + HttpUtility.UrlEncode(newSecureKey);
        //byte[] byteArray = Encoding.ASCII.GetBytes(query);

        //request.ContentType = "application/x-www-form-urlencoded";
        //request.ContentLength = byteArray.Length;
        //dataStream = request.GetRequestStream();
        //dataStream.Write(byteArray, 0, byteArray.Length);
        //dataStream.Close();

        //WebResponse response = request.GetResponse();
        //String Status = ((HttpWebResponse)response).StatusDescription;
        //dataStream = response.GetResponseStream();
        //StreamReader reader = new StreamReader(dataStream);
        //String responseFromServer = reader.ReadToEnd();

        //reader.Close();
        //dataStream.Close();
        //response.Close();

        //DBUtilitySMS reg = new DBUtilitySMS();
        //reg.savedSentSMSDetails(mobileNo, message, responseFromServer, HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());

        return responseString;
    }
    public string sendOTPSMS(string mobileNo, string message, string OTP, string TemplateName, string ToUserID, string strTemplateID)
    {
        try
        {
            String query = url + "&authkey=" + secureKeyOTP + "&message=" + message + "&sender=" + senderID + "&mobile=91" + mobileNo + "&otp=" + OTP + "&DLT_TE_ID=" + strTemplateID;

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(query);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
            DBUtilitySMS reg = new DBUtilitySMS();
            reg.savedSentSMSDetails(mobileNo, message, responseString, HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), "O", TemplateName, ToUserID);
            return responseString;
        }
        catch (Exception ex)
        {
            long messageID = ExceptionMessages.GetMessageDetails();
            throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "sendOTPSMS()", "  ");
        }

    }
    public string sendSingleSMS(string mobileNo, string message, string TemplateName, string ToUserID, string strTemplateID)
    {
        try
        {
            String query = normalUrl + "sender=" + senderID + "&route=4&mobiles=91" + mobileNo + "&authkey=" + secureKeyOTP + "&country=0&message=" + message + "&DLT_TE_ID=" + strTemplateID;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(query);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();

            DBUtilitySMS reg = new DBUtilitySMS();
            reg.savedSentSMSDetails(mobileNo, message, responseString, HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), "N", TemplateName, ToUserID);

            return responseString;
        }
        catch (Exception ex)
        {
            long messageID = ExceptionMessages.GetMessageDetails();
            throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "sendSingleSMS()", "  ");
        }
    }
    //public String sendBulkSMS(string mobileNos, string message)
    //{
    //    //Stream dataStream;
    //    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    //    //request.ProtocolVersion = HttpVersion.Version10;
    //    //request.KeepAlive = false;
    //    //request.ServicePoint.ConnectionLimit = 1;
    //    //((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
    //    //request.Method = "POST";

    //    //String encryptedPassword = encryptPasswod(password);
    //    //String newSecureKey = hashGenerator(userName, senderID, message, secureKey);
    //    //String smsServiceType = "bulkmsg";
    //    //String query = "username=" + HttpUtility.UrlEncode(userName) + "&password=" + HttpUtility.UrlEncode(encryptedPassword) + "&smsservicetype=" + HttpUtility.UrlEncode(smsServiceType) + "&content=" + HttpUtility.UrlEncode(message) + "&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) + "&senderid=" + HttpUtility.UrlEncode(senderID) + "&key=" + HttpUtility.UrlEncode(newSecureKey);
    //    //Console.Write(query);
    //    //byte[] byteArray = Encoding.ASCII.GetBytes(query);

    //    //request.ContentType = "application/x-www-form-urlencoded";
    //    //request.ContentLength = byteArray.Length;
    //    //dataStream = request.GetRequestStream();
    //    //dataStream.Write(byteArray, 0, byteArray.Length);
    //    //dataStream.Close();

    //    //WebResponse response = request.GetResponse();
    //    //String Status = ((HttpWebResponse)response).StatusDescription;
    //    //dataStream = response.GetResponseStream();
    //    //StreamReader reader = new StreamReader(dataStream);
    //    String responseFromServer = "";

    //    //reader.Close();
    //    //dataStream.Close();
    //    //response.Close();

    //    return responseFromServer;
    //}
    public async Task<string> SendBulkSMS(Msg91 msg91, string TemplateName)
    {
        string res = "";
        try
        {
            string Userid = HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString();
            string IPAddress = UserInfo.GetIPAddress();
            await Task.Run(() =>
            {
                var client = new RestClient(bulkSMSAPIURL);
                var request = new RestRequest(Method.POST);
                msg91.Country = "91";
                msg91.Route = "4";
                msg91.Sender = ConfigurationManager.AppSettings["SMSSenderID"];
                string reqparam = JsonConvert.SerializeObject(msg91);
                request.AddHeader("content-type", "application/json");
                request.Timeout = 1800000;
                request.AddHeader("authkey", ConfigurationManager.AppSettings["SMSSecureKey"]);
                request.AddParameter("application/json", reqparam, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);


                Parallel.ForEach(msg91.Sms, item => new DBUtilitySMS().savedSentSMSDetails(item.To.FirstOrDefault(), item.Message, response.Content, Userid, IPAddress, "B", TemplateName, item.PersonalID));
                //foreach (var item in msg91.Sms)
                //{
                //    reg.savedSentSMSDetails(item.To.FirstOrDefault(), item.Message, response.Content, HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress(), "B", TemplateName, item.PersonalID);

                res = "Done";
            });
            return res;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public String sendUnicodeSMS(string mobileNos, string unicodeMessage)
    {
        //Stream dataStream;
        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //request.ProtocolVersion = HttpVersion.Version10;
        //request.KeepAlive = false;
        //request.ServicePoint.ConnectionLimit = 1;
        //((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        //request.Method = "POST";

        //String convertedMessage = "";
        //foreach (char c in unicodeMessage)
        //{
        //    Int32 j = (Int32)c;
        //    String sss = "&#" + j + ";";
        //    convertedMessage = convertedMessage + sss;
        //}

        //String encryptedPassword = encryptPasswod(password);
        //String newSecureKey = hashGenerator(userName, senderID, convertedMessage, secureKey);
        //String smsServiceType = "unicodemsg"; 
        //String query = "username=" + HttpUtility.UrlEncode(userName) + "&password=" + HttpUtility.UrlEncode(encryptedPassword) + "&smsservicetype=" + HttpUtility.UrlEncode(smsServiceType) + "&content=" + HttpUtility.UrlEncode(convertedMessage) + "&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) + "&senderid=" + HttpUtility.UrlEncode(senderID) + "&key=" + HttpUtility.UrlEncode(newSecureKey);
        //byte[] byteArray = Encoding.ASCII.GetBytes(query);

        //request.ContentType = "application/x-www-form-urlencoded";
        //request.ContentLength = byteArray.Length;
        //dataStream = request.GetRequestStream();
        //dataStream.Write(byteArray, 0, byteArray.Length);
        //dataStream.Close();

        //WebResponse response = request.GetResponse();
        //String Status = ((HttpWebResponse)response).StatusDescription;
        //dataStream = response.GetResponseStream();
        //StreamReader reader = new StreamReader(dataStream);
        //String responseFromServer = reader.ReadToEnd();

        //reader.Close();
        //dataStream.Close();
        //response.Close();
        string responseFromServer = string.Empty;
        return responseFromServer;
    }
    protected String encryptPasswod(string password)
    {
        byte[] encPwd = Encoding.UTF8.GetBytes(password);
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
        byte[] pp = sha1.ComputeHash(encPwd);
        StringBuilder sb = new StringBuilder();

        foreach (byte b in pp)
        {
            sb.Append(b.ToString("x2"));
        }

        return sb.ToString();
    }
    //protected String hashGenerator(string UserName, string senderID, string message, string secureKey)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    sb.Append(userName).Append(senderID).Append(message).Append(secureKey);
    //    byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
    //    HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
    //    byte[] sec_key = sha1.ComputeHash(genkey);
    //    StringBuilder sb1 = new StringBuilder();

    //    for (Int32 i = 0; i < sec_key.Length; i++)
    //    {
    //        sb1.Append(sec_key[i].ToString("x2"));
    //    }

    //    return sb1.ToString();
    //}
    public string voiceCallOTP(string mobileNo)
    {
        try
        {
            String query = voiccallURL + "authkey=" + secureKeyOTP + "&mobile=91" + mobileNo + "&retrytype=voice";
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(query);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
            return responseString;
        }
        catch (Exception ex)
        {
            long messageID = ExceptionMessages.GetMessageDetails();
            throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "voiceCallOTP()", "mobileNo " + mobileNo);
        }

    }
    //public void SendEmail(string email, string body, string subject, bool IsBodyHTMl)
    //{
    //    try
    //    {
    //        using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["SenderEmail"], email))
    //        {
    //            mm.Subject = subject;
    //            mm.Body = body;
    //            mm.IsBodyHtml = IsBodyHTMl;
    //            SmtpClient smtp = new SmtpClient();
    //            smtp.Host = "smtp.gmail.com";
    //            smtp.EnableSsl = true;
    //            NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["SenderEmail"], ConfigurationManager.AppSettings["SenderPassword"]);
    //            smtp.UseDefaultCredentials = true;
    //            smtp.Credentials = NetworkCred;
    //            smtp.Port = 587;
    //            smtp.Send(mm);
    //            DBUtilitySMS reg = new DBUtilitySMS();
    //            reg.savedSentEmailDetails(email, subject, body, "", HttpContext.Current.Session["UserLoginID"] == null ? "Guest" : HttpContext.Current.Session["UserLoginID"].ToString(), UserInfo.GetIPAddress());
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        long messageID = ExceptionMessages.GetMessageDetails();
    //        throw new CustomException(SeverityLevel.Critical, ExceptionMessages.GetHashTable(messageID, 1), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "SendEmail()", "  ");
    //    }
    //}


}
public class DBUtilitySMS
{
    //public void savedSentSMSDetails(string mobileNo, string message, string response, string sentBy, string sentByIPAddress, string SMSType)
    //{
    //    DBConnection db = new DBConnection();
    //    try
    //    {
    //        db.ExecuteScaler("MHDTE_spSaveSentSMSDetails", new SqlParameter[]
    //        {
    //              new SqlParameter("@MobileNo", DataEncryption.EncryptDataByEncryptionKey(mobileNo)),
    //        new SqlParameter("@message", message),
    //        new SqlParameter("@Response", response),
    //        new SqlParameter("@SentBy", sentBy),
    //        new SqlParameter("@SentByIPAddress", sentByIPAddress),
    //        new SqlParameter("@SMSType", SMSType),
    //        });
    //    }
    //    finally
    //    {
    //        db.Dispose();
    //    }

    //}
    public void savedSentSMSDetails(string mobileNo, string message, string response, string sentBy, string sentByIPAddress, string SMSType, string TemplateName, string ToUserID)
    {
        DBConnection db = new DBConnection();
        try
        {
            db.ExecuteScaler("MHDTE_spSaveSentSMSDetails", new SqlParameter[]
            {
                  new SqlParameter("@MobileNo", DataEncryption.EncryptDataByEncryptionKey(mobileNo)),
            new SqlParameter("@message", message),
            new SqlParameter("@Response", response),
            new SqlParameter("@SentBy", sentBy),
            new SqlParameter("@SentByIPAddress", sentByIPAddress),
            new SqlParameter("@SMSType", SMSType),
               new SqlParameter("@Template", TemplateName),
               new SqlParameter("@ToUserID", ToUserID)

            });
        }
        finally
        {
            db.Dispose();
        }

    }
    public void savedSentEmailDetails(string mailID, string subject, string body, string response, string sentBy, string sentByIPAddress, string SMSType, string TemplateName, string ToUserID)
    {
        DBConnection db = new DBConnection();
        try
        {
            db.ExecuteScaler("MHDTE_spSaveSentEmailDetails", new SqlParameter[]
            {
                  new SqlParameter("@EmailID",  mailID),
            new SqlParameter("@Subject", subject ),
            new SqlParameter("@Body",  body),
            new SqlParameter("@Response",  response),
            new SqlParameter("@SentBy", sentBy ),
            new SqlParameter("@SentByIPAddress",  sentByIPAddress),
            new SqlParameter("@SMSType", SMSType),
               new SqlParameter("@Template", TemplateName),
               new SqlParameter("@ToUserID", ToUserID)
            });
        }
        finally
        {
            db.Dispose();
        }
    }
}
