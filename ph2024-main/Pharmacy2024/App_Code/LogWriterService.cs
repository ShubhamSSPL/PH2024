using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


public class LogWriterService
{
    private static string m_baseDir = AppDomain.CurrentDomain.BaseDirectory + ConfigurationSettings.AppSettings["LogDirectory"];

    public static string GetFilenameYYYMMDD(string suffix, string extension)
    {
        return DateTime.Now.ToString("yyyy_MM_dd") + suffix + extension;
    }

    public static string GetBackUpFilenameYYYMMDDHHMM(string suffix, string extension)
    {
        return DateTime.Now.ToString("yyyy_MM_dd_hh_mm") + suffix + extension;
    }

    public static void WriteNormalLog(string message)
    {
        try
        {
            if (!Directory.Exists(LogWriterService.m_baseDir))
                Directory.CreateDirectory(LogWriterService.m_baseDir);
            string str = LogWriterService.m_baseDir + "\\" + LogWriterService.GetFilenameYYYMMDD("_LOG_Normal", ".log");
            FileInfo fileInfo = new FileInfo(str);
            long num = 0;
            try
            {
                num = fileInfo.Length;
            }
            catch (Exception ex)
            {
            }
            if (num > 1024000L)
            {
                string destFileName = LogWriterService.m_baseDir + "\\" + LogWriterService.GetBackUpFilenameYYYMMDDHHMM("_LOG_Normal", ".log");
                File.Move(str, destFileName);
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Date:" + DateTime.Now.ToString() + " " + message);
            StreamWriter streamWriter = new StreamWriter(str, true);
            streamWriter.WriteLine(stringBuilder.ToString());
            streamWriter.Close();
        }
        catch (Exception ex)
        {
        }
    }

    public static void WriteErrorLog(string message, string errorPlace)
    {
        try
        {
            if (!Directory.Exists(LogWriterService.m_baseDir))
                Directory.CreateDirectory(LogWriterService.m_baseDir);
            string str = LogWriterService.m_baseDir + "\\" + LogWriterService.GetFilenameYYYMMDD("_LOG_Error", ".log");
            FileInfo fileInfo = new FileInfo(str);
            long num = 0;
            try
            {
                num = fileInfo.Length;
            }
            catch (Exception ex)
            {
            }
            if (num > 1024000L)
            {
                string destFileName = LogWriterService.m_baseDir + "\\" + LogWriterService.GetBackUpFilenameYYYMMDDHHMM("_LOG_Error", ".log");
                File.Move(str, destFileName);
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Date:" + DateTime.Now.ToString() + " " + message + "  ErrorPlace: " + errorPlace);
            StreamWriter streamWriter = new StreamWriter(str, true);
            streamWriter.WriteLine(stringBuilder.ToString());
            streamWriter.Close();
        }
        catch (Exception ex)
        {
        }
    }
}
