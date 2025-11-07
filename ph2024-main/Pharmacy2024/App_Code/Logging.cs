
using System;
using System.Web;
using System.Text;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using SynthesysDAL;


public class Logging
{
    protected static string GetFileName(bool info)
    {
        string folder = info ? GetInfoFolder() : GetErrorFolder();

        if (folder == null)
        {
            return null;
        }
        else
        {
            StringBuilder stb = new StringBuilder();
            stb.AppendFormat("{0}\\{1}_{2}-{3}-{4}.txt", folder, DateTime.Now.ToString("HH"), DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"));

            return stb.ToString();
        }
    }
    protected static bool GetEnableLogging()
    {
        IDictionary dic = System.Configuration.ConfigurationManager.GetSection("ErrorHandling") as IDictionary;
        bool enableLogging = false;

        if (dic != null || dic["EnableLogging"] != null)
        {
            Boolean.TryParse(dic["EnableLogging"].ToString().Trim(), out enableLogging);
        }

        return enableLogging;
    }
    protected static string GetErrorFolder()
    {
        IDictionary dic = System.Configuration.ConfigurationManager.GetSection("ErrorHandling") as IDictionary;
        string folder = dic == null || dic["ErrorLogFilesDir"] == null ? "" : dic["ErrorLogFilesDir"].ToString().Trim();
        folder = HttpContext.Current.Server.MapPath("~/" + folder);

        if (!Directory.Exists(folder))
        {
            return null;
        }
        else
        {
            return folder;
        }
    }
    protected static string GetInfoFolder()
    {
        IDictionary dic = System.Configuration.ConfigurationManager.GetSection("ErrorHandling") as IDictionary;
        string folder = dic == null || dic["AppLogFilesDir"] == null ? "" : dic["AppLogFilesDir"].ToString().Trim();
        folder = HttpContext.Current.Server.MapPath("~/" + folder);
        if (!Directory.Exists(folder))
        {
            return null;
        }
        else
        {
            return folder;
        }
    }
    protected static void WriteToFile(StringBuilder stb, bool info)
    {
        if (GetEnableLogging())
        {
            string path = GetFileName(info);

            if (path != null)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(stb.ToString());
                    sw.Close();
                }
            }
        }
    }
    public static void LogInfo(string info)
    {
        LogInfo(info, false);
    }
    public static void LogInfo(string info, bool includeAdditionalInfo)
    {
        if (HttpContext.Current != null && HttpContext.Current.Request != null)
        {
            ErrorLog obj = new ErrorLog();

            obj.ErrorType = "Activity";
            obj.URL = HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.Url.PathAndQuery;
            obj.HostIP = UserInfo.GetIPAddress();
            obj.BrowserName = HttpContext.Current.Request.Browser.Browser;
            obj.BrowserVersion = HttpContext.Current.Request.Browser.Version;
            if (HttpContext.Current.Session != null)
            {
                obj.UserLoginID = HttpContext.Current.Session["UserLoginID"].ToString();
            }
            else
            {
                obj.UserLoginID = "Guest";
            }
            obj.CustomMessage = info;
            obj.ErrorMessage = "";
            obj.InnerException = "";
            obj.DateTime = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);

            new ErrorLogDBUtility().SaveErrorLog(obj);

            //StringBuilder stb = new StringBuilder();

            //stb.Append("<Activity>");
            //stb.AppendLine();
            //stb.AppendFormat("<DateTime>{0}</DateTime>", DateTime.Now.ToString("dd/MM/yyyy") + "  " + String.Format("{0:T}", DateTime.Now));
            //stb.AppendLine();
            //stb.AppendFormat("<Message>{0}</Message>", info);
            //stb.AppendLine();
            //if (includeAdditionalInfo)
            //{
            //    stb.Append("<Info>");
            //    stb.AppendLine();
            //    stb.AppendFormat("<Verb>{0}</Verb>", HttpContext.Current.Request.RequestType);
            //    stb.AppendLine();
            //    stb.AppendFormat("<URL>{0}</URL>", HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.Url.PathAndQuery);
            //    stb.AppendLine();
            //    stb.AppendFormat("<HostIP>{0}</HostIP>", HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.UserHostName);
            //    stb.AppendLine();
            //    stb.Append("</Info>");
            //    stb.AppendLine();
            //    if (HttpContext.Current.Request.Browser != null)
            //    {
            //        stb.Append("<Browser>");
            //        stb.AppendLine();
            //        stb.AppendFormat("<Name>{0}</Name>", HttpContext.Current.Request.Browser.Browser);
            //        stb.AppendLine();
            //        stb.AppendFormat("<Version>{0}</Version>", HttpContext.Current.Request.Browser.Version);
            //        stb.AppendLine();
            //        stb.Append("</Browser>");
            //        stb.AppendLine();
            //    }
            //    if (HttpContext.Current.Session != null)
            //    {
            //        stb.AppendFormat("<User>{0}</User>", HttpContext.Current.Session["UserLoginID"].ToString());
            //    }
            //    else
            //    {
            //        stb.AppendFormat("<User>{0}</User>", "Guest");
            //    }
            //    stb.AppendLine();
            //}
            //stb.Append("</Activity>");
            //stb.AppendLine();
            //stb.Append("------------------------------------------------------------------------------------------------------");
            //stb.AppendLine();
            //stb.AppendLine();
            //stb.AppendLine();

            //lock (typeof(Logging))
            //{
            //    WriteToFile(stb, true);
            //}
        }
    }
    public static void LogException(Exception er)
    {
        LogException(er, string.Empty, ErrorLevel.ERROR);
    }
    public static void LogException(Exception er, string strMessage)
    {
        LogException(er, strMessage, ErrorLevel.ERROR);
    }
    public static void LogException(Exception er, string strMessage, ErrorLevel errLevel)
    {
        if (HttpContext.Current != null && HttpContext.Current.Request != null && er != null && !(er is System.Threading.ThreadAbortException))
        {
            try
            {
                ErrorLog obj = new ErrorLog();

                obj.ErrorType = "Exception";
                obj.URL = HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.Url.PathAndQuery;
                obj.HostIP = UserInfo.GetIPAddress();
                obj.BrowserName = HttpContext.Current.Request.Browser.Browser;
                obj.BrowserVersion = HttpContext.Current.Request.Browser.Version;
                if (HttpContext.Current.Session != null)
                {
                    obj.UserLoginID = HttpContext.Current.Session["UserLoginID"].ToString();
                }
                else
                {
                    obj.UserLoginID = "Guest";
                }
                obj.CustomMessage = strMessage;
                obj.ErrorMessage = er.Message;
                if (er.InnerException != null)
                {
                    obj.InnerException = er.InnerException.ToString();
                }
                else
                {
                    obj.InnerException = "";
                }
                obj.DateTime = DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now);

                new ErrorLogDBUtility().SaveErrorLog(obj);

                //StringBuilder stb = new StringBuilder();

                //stb.Append("<Exception>");
                //stb.AppendLine();
                //stb.AppendFormat("<DateTime>{0}</DateTime>", DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:T}", DateTime.Now));
                //stb.AppendLine();
                //if (strMessage != string.Empty)
                //{
                //    stb.AppendFormat("<CustomMessage>{0}</CustomMessage>", strMessage);
                //    stb.AppendLine();
                //}
                //stb.Append("<Info>");
                //stb.AppendLine();
                //stb.AppendFormat("<Verb>{0}</Verb>", HttpContext.Current.Request.RequestType);
                //stb.AppendLine();
                //stb.AppendFormat("<URL>{0}</URL>", HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.Url.PathAndQuery);
                //stb.AppendLine();
                //stb.AppendFormat("<HostIP>{0}</HostIP>", HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.UserHostName);
                //stb.AppendLine();
                //stb.Append("</Info>");
                //stb.AppendLine();
                //if (HttpContext.Current.Request.Browser != null)
                //{
                //    stb.Append("<Browser>");
                //    stb.AppendLine();
                //    stb.AppendFormat("<Name>{0}</Name>", HttpContext.Current.Request.Browser.Browser);
                //    stb.AppendLine();
                //    stb.AppendFormat("<Version>{0}</Version>", HttpContext.Current.Request.Browser.Version);
                //    stb.AppendLine();
                //    stb.Append("</Browser>");
                //    stb.AppendLine();
                //}
                //if (HttpContext.Current.Session != null)
                //{
                //    stb.AppendFormat("<User>{0}</User>", HttpContext.Current.Session["UserLoginID"].ToString());
                //}
                //else
                //{
                //    stb.AppendFormat("<User>{0}</User>", "Guest");
                //}
                //stb.AppendLine();
                //stb.AppendFormat("<ErrorMessage>{0}</ErrorMessage>", er.Message);
                //stb.AppendLine();
                //if (er.InnerException != null)
                //{
                //    stb.AppendFormat("<InnerException>{0}</InnerException>", er.InnerException.ToString());
                //    stb.AppendLine();
                //}
                //stb.Append("</Exception>");
                //stb.AppendLine();
                //stb.Append("------------------------------------------------------------------------------------------------------");
                //stb.AppendLine();
                //stb.AppendLine();
                //stb.AppendLine();

                //lock (typeof(Logging))
                //{
                //    WriteToFile(stb, false);
                //    SendMessage.SMS("9820363709", ConfigurationManager.AppSettings["Project_Name"] + " " + strMessage + " : " + er.Message);
                //}
            }
            catch (Exception)
            {
            }
        }
    }
}
public class ErrorLogDBUtility
{
    public void SaveErrorLog(ErrorLog obj)
    {
        DBConnection db = new DBConnection();
        try
        {
            db.ExecuteScaler("MHDTE_spSaveErrorLog", new SqlParameter[]
            {
                    new SqlParameter("@ErrorType", obj.ErrorType),
                new SqlParameter("@URL",  obj.URL),
                new SqlParameter("@HostIP", obj.HostIP),
                new SqlParameter("@BrowserName", obj.BrowserName),
                new SqlParameter("@BrowserVersion", obj.BrowserVersion),
                new SqlParameter("@UserLoginID", obj.UserLoginID),
                new SqlParameter("@CustomMessage", obj.CustomMessage),
                new SqlParameter("@ErrorMessage", obj.ErrorMessage),
                new SqlParameter("@InnerException", obj.InnerException),
                new SqlParameter("@DateTime", obj.DateTime)
            });
        }
        finally
        {
            db.Dispose();
        }
    }
}
public class ErrorLog
{
    public string ErrorType { get; set; }
    public string URL { get; set; }
    public string HostIP { get; set; }
    public string BrowserName { get; set; }
    public string BrowserVersion { get; set; }
    public string UserLoginID { get; set; }
    public string CustomMessage { get; set; }
    public string ErrorMessage { get; set; }
    public string InnerException { get; set; }
    public string DateTime { get; set; }
}
public enum ErrorLevel : int
{
    FATAL_ERROR = 3,
    ERROR = 2,
    WARNING = 1
}

