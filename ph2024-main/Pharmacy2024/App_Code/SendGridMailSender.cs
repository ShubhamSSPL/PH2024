using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using RestSharp;
using System.Configuration;
using System.Collections.Specialized;
using System.Globalization;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Communication
/// </summary>

public class UploadFile
{
    public UploadFile()
    {
        ContentType = "application/octet-stream";
    }
    public string Name { get; set; }
    public string Filename { get; set; }
    public string ContentType { get; set; }
    public Stream Stream { get; set; }
}
public class SendGridMailSender
{


    public static string SendgridUsername()
    {
        string str = string.Empty;
        str = ConfigurationSettings.AppSettings["SendGridUsername"].ToString();
        if ((str == null) || (str.Length == 0))
        {
            str = "CONFIG1";
        }
        return str;
    }
    //public static string ReplyEmail()
    //{
    //    string str = string.Empty;
    //    str = ConfigurationSettings.AppSettings["AdminId"].ToString();
    //    if ((str == null) || (str.Length == 0))
    //    {
    //        str = "CONFIG1";
    //    }
    //    return str;
    //}
    public static string SendgridPassword()
    {
        string str = string.Empty;
        str = ConfigurationSettings.AppSettings["SendGridPassword"].ToString();
        if ((str == null) || (str.Length == 0))
        {
            str = "CONFIG1";
        }
        return str;
    }
  
    public static string sendgrid_apikey()
    {
        string str = string.Empty;
        str = ConfigurationSettings.AppSettings["sendgrid_apikey"].ToString();
        if ((str == null) || (str.Length == 0))
        {
            str = "";
        }
        return str;
    }


    public static Boolean SendEMail(string from_email, string fromname, string to_email, string to_name, string subject, string mailBody)
    {
	/* File Name Displayed*/
        List<string> attachname = new List<string>();
	/* File Path to Be Send*/
        List<string> attachpath = new List<string>();
        string result = SendEmailWithAttachmentAsync(from_email, fromname, to_email, to_name, subject, mailBody, "", attachname, attachpath);

        Boolean response = false;
        if(result.ToUpper() == "SEND")
            response = true;
        else
            response = false;

        return response;
    }
    public static string SendEmailWithAttachmentAsync(string fromAddress, string fromname, string toAddress, string toName, string subject, string messagehtml, string messagetext, List<string> Attachmentname, List<string> AttachFilePath)
    {
        try
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
        }
        catch (Exception)
        {


        }

        string result = string.Empty;
        string data = string.Empty;


        //try 
        //{	        

        System.Text.UTF8Encoding UTF8 = new UTF8Encoding();

        List<UploadFile> files = new List<UploadFile>();

        for (int i = 0; i < Attachmentname.Count; i++)
        {
            var stream = File.Open(AttachFilePath[i], FileMode.Open);
            UploadFile s1 = new UploadFile
            {
                Name = "files[" + Attachmentname[i] + "]",
                Filename = Attachmentname[i],
                ContentType = "application/octet-stream",
                Stream = stream
            };
            files.Add(s1);

        }

        messagehtml = messagehtml.Replace("##TOEMAIL##", toAddress);
        string email_body = "<table width='100%'  cellpadding='5'  border='0' style='text-align:justify'>";

        email_body += "<tr>";
        email_body += "<td>";
        email_body += StripSlashes(messagehtml);
        email_body += "</td>";
        email_body += "</tr>";
        email_body += "<tr>";
        email_body += "<td>";
        email_body += "<br/><br/>This is a system generated mail so please do not reply to this mail.";
        email_body += "</td>";
        email_body += "</tr>";
        email_body += "<tr>";
        email_body += "<td>";
        email_body += "<br/>Regards,<br/>CET CELL, Mumbai<br/>";
        email_body += "</td>";
        email_body += "</tr>";
        email_body += "<tr>";
        email_body += "<td  style='border-bottom:1px solid #000000'></td>";
        email_body += "</tr>";
        email_body += "</table>";

        string messageMAIL = "<html>";
        messageMAIL += "<head>";
        messageMAIL += "<title></title>";
        messageMAIL += "</head>";
        messageMAIL += "<body ><center>" + email_body + "</center>";
       
        messageMAIL += "</body>";
        messageMAIL += "</html>";
        /*
        NameValueCollection values = new NameValueCollection();
        values.Add("api_user", SendgridUsername());

        values.Add("api_key", SendgridPassword());
        values.Add("to", toAddress);
        if (toName.Length > 0)
        {
            values.Add("toname", toName);
        }
        values.Add("from", fromAddress);
        values.Add("fromname", fromname);
        values.Add("replyto", fromAddress);

        values.Add("subject", subject);
        values.Add("html", messageMAIL);
        values.Add("text", messageMAIL);


      result = MyUploadFiles("https://sendgrid.com/api/mail.send.json", files, values);
        foreach (UploadFile file in files)
        {
            file.Stream.Close();
        }*/
        string sendgrid_apikey = SendGridMailSender.sendgrid_apikey();
        var client = new SendGridClient(sendgrid_apikey);
        var from = new EmailAddress(fromAddress, fromname);
        var subjectmail = subject;
        var to = new EmailAddress(toAddress, toName);
        var plainTextContent = messageMAIL;
        var htmlContent = messageMAIL;
        var msg = MailHelper.CreateSingleEmail(from, to, subjectmail, plainTextContent, htmlContent);
        var task = Task.Run(() => client.SendEmailAsync(msg));
        var result1 = task.Result;
        
        result = "Send";
        //}
        //catch 
        //{
        //result = "Failed";
        //}
        return result;
    }
    public static DateTime GetDateTime()
    {
        TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        return indianTime;
    }
    private static string MyUploadFiles(string address, List<UploadFile> files, NameValueCollection values)
    {
        var request = WebRequest.Create(address);
        request.Timeout = System.Threading.Timeout.Infinite; ;
        request.Method = "POST";
        var boundary = "---------------------------" + GetDateTime().Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
        string sendgrid_apikey = SendGridMailSender.sendgrid_apikey();


        request.Headers.Add("Authorization", "Bearer " + sendgrid_apikey);

        request.ContentType = "multipart/form-data; boundary=" + boundary;
        boundary = "--" + boundary;

        using (Stream requestStream = request.GetRequestStream())
        {
            // Write the values
            foreach (string name in values.Keys)
            {
                var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                requestStream.Write(buffer, 0, buffer.Length);
                buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
                requestStream.Write(buffer, 0, buffer.Length);
                buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
                requestStream.Write(buffer, 0, buffer.Length);
            }

            // Write the files
            foreach (UploadFile file in files)
            {
                var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                requestStream.Write(buffer, 0, buffer.Length);
                buffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", file.Name, file.Filename, Environment.NewLine));
                requestStream.Write(buffer, 0, buffer.Length);
                buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
                requestStream.Write(buffer, 0, buffer.Length);



                // Write out the file contents
                byte[] bufferx = new Byte[checked((uint)Math.Min(4096,
                                         (int)file.Stream.Length))];
                int bytesRead = 0;
                while ((bytesRead = file.Stream.Read(bufferx, 0, bufferx.Length)) != 0)
                    requestStream.Write(bufferx, 0, bytesRead);
                buffer = Encoding.ASCII.GetBytes(Environment.NewLine);
                requestStream.Write(buffer, 0, buffer.Length);
            }

            var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
            requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
        }


        WebResponse responce = request.GetResponse();
        Stream s = responce.GetResponseStream();
        StreamReader sr = new StreamReader(s);

        return "Send";


    }
    private static string StripSlashes(string InputTxt)
    {
        string Result = InputTxt;
        try
        {
            Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"(\\)([\000\010\011\012\015\032\042\047\134\140])", "$2");
        }
        catch
        {
            Result = InputTxt;
        }
        return Result;
    }
    
   
}