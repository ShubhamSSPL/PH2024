using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using SynthesysDAL;
public class UserInfo
{
    public static string GetIPAddress()
    {
        if (!string.IsNullOrEmpty(HttpContext.Current.Request.Headers["X-Forwarded-For"]))
        {
            return HttpContext.Current.Request.Headers["X-Forwarded-For"];
        }
        else if (!string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"]))
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
        }
        else
        {
            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
    public static string GetServerIPAddress()
    {
        string[] IPAddress = System.Net.Dns.Resolve(System.Net.Dns.GetHostName()).AddressList[0].ToString().Split(new string[] { "." }, StringSplitOptions.None);
        return IPAddress[IPAddress.Length - 1];
    }
    public static string GetImageURL(Int64 PID, string ImageType)
    {
        dbUtilityUserInfo reg = new dbUtilityUserInfo();

        string ImageURL = reg.GetImageURL(PID, ImageType);
        if (ImageURL == "")
        {
            return ImageURL;
        }
        return ConfigurationManager.AppSettings["StorageBaseURL"].ToString() + ImageURL; //+ "?dt=" + DateTime.Now.ToString();
    }
    public static string GenerateOTP()
    {
        string _allowedChars = "0123456789";
        Random randNum = new Random((int)DateTime.Now.Ticks);
        char[] chars = new char[6];

        for (int i = 0; i < 6; i++)
        {
            chars[i] = _allowedChars[randNum.Next(_allowedChars.Length)];
        }

        return new string(chars);
    }
    public static string ConvertNumbertoWords(Int64 number)
    {
        if (number == 0)
            return "Zero";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";

        if ((number / 1000000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000000) + " Billion ";
            number %= 1000000000;
        }

        if ((number / 10000000) > 0)
        {
            words += ConvertNumbertoWords(number / 10000000) + " Crore ";
            number %= 10000000;
        }

        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " Lac ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " Thousand ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " Hundred ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "and ";
            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }
    public static string GetBrowserDetails()
    {
        string browserDetails = string.Empty;
        System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
        browserDetails =
        "Name = " + browser.Browser + "," +
        "Type = " + browser.Type + ","
        + "Version = " + browser.Version + ","
        + "Major Version = " + browser.MajorVersion + ","
        + "Minor Version = " + browser.MinorVersion + ","
        + "Platform = " + browser.Platform + ","
        + "Is Beta = " + browser.Beta + ","
        + "Is Crawler = " + browser.Crawler + ","
        + "Is AOL = " + browser.AOL + ","
        + "Is Win16 = " + browser.Win16 + ","
        + "Is Win32 = " + browser.Win32 + ","
        + "Supports Frames = " + browser.Frames + ","
        + "Supports Tables = " + browser.Tables + ","
        + "Supports Cookies = " + browser.Cookies + ","
        + "Supports VBScript = " + browser.VBScript + ","
        + "Supports JavaScript = " + "," +
        browser.EcmaScriptVersion.ToString() + ","
        + "Supports Java Applets = " + browser.JavaApplets + ","
        + "Supports ActiveX Controls = " + browser.ActiveXControls
        + ","
        + "Supports JavaScript Version = " +
        browser["JavaScriptVersion"];
        return browserDetails;
    }
}
public class dbUtilityUserInfo
{
    public string GetImageURL(Int64 PID, string ImageType)
    {
        DBConnection db = new DBConnection();
        try
        {
            return Convert.ToString(db.ExecuteScaler("MHDTE_spGetImageURL", new SqlParameter[]
              {
                   new SqlParameter("@PID", PID),
                new SqlParameter("@ImageType", ImageType)
              }));
        }
        finally
        {
            db.Dispose();
        }
    }
}