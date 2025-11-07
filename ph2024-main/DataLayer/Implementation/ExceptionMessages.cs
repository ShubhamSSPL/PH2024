using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using forProjectCustomExceptions;
using System.Data;
using System.Collections;

namespace DataAccess.Implementation
{
    public class ExceptionMessages : EntityManager
    {

        //private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CRConnectionString"].ToString();
        /// <summary>
        /// Update MessageId in system table.
        /// </summary>
        /// <param name="msgId">type represent MessageId to update</param>
        public static void UpdateMessageId(long msgId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand dCmd = new SqlCommand("UPDATE System SET MESSAGEID = " + msgId, connection);
                    dCmd.CommandType = CommandType.Text;

                    SqlHelper.ExecuteNonQuery(connection, CommandType.Text, dCmd.CommandText);
                }

            }
            catch (CustomException)
            {
            }
            catch (Exception ex)
            {
                long messageID = GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, GetHashTable(messageID, 2), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "updateMessageId()", "msgId : " + msgId);
            }
        }

        public static Hashtable GetHashTable()
        {
            return null;
        }

        public static Hashtable GetHashTable(long messgID, int isSP)
        {

            Hashtable htMessage = new Hashtable();
            object htLogTypeValue;
            htMessage.Add("Database", connectionString);
            if (htMessage.ContainsKey("Database"))
            {
                htLogTypeValue = htMessage["Database"].ToString() + "|" + messgID.ToString() + "|" + isSP.ToString();
                htMessage["Database"] = htLogTypeValue;
            }
            return htMessage;
        }

        public static long GetMessageId(string Msg_ID)
        {
            DataSet messageData = new DataSet();
            long messageId = 0;
            try
            {
                long randomMessageID = 0;
                randomMessageID = 1;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = "SELECT MESSAGEID FROM System";

                    SqlCommand odbcCommand = new SqlCommand(query, connection);
                    odbcCommand.CommandText = query;
                    messageData = SqlHelper.ExecuteDataset(connection, CommandType.Text, odbcCommand.CommandText);

                    if (messageData.Tables[0].Rows.Count > 0)
                    {
                        messageId = long.Parse(messageData.Tables[0].Rows[0]["MESSAGEID"].ToString());
                        return randomMessageID + messageId;
                    }
                    else
                    {
                        return randomMessageID;
                    }
                    // connection.Close();
                }
            }
            catch (CustomException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                long messageID = GetMessageDetails();
                throw new CustomException(SeverityLevel.Critical, GetHashTable(messageID, 2), ex, "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString(), "getMessageId()", "Msg_ID : " + Msg_ID);
            }

        }

        public static long GetMessageDetails()
        {

            Hashtable htMessage = new Hashtable();
            object htLogTypeKey;
            object htLogTypeValue;

            htMessage.Add("Database", connectionString);
            long messageID = GetMessageId(null);
            if (htMessage.ContainsKey("Database"))
            {
                htLogTypeKey = htMessage["Database"];
                htLogTypeValue = htLogTypeKey + "|" + messageID.ToString();
                htMessage["Database"] = htLogTypeValue;
            }
            UpdateMessageId(messageID);
            return messageID;


        }

        public static string GetExceptionMessage(SqlException exception, long messageID)
        {
            string exceptionMessage = "";
            if (((SqlException)exception).Number >= 50000)
            {
                exceptionMessage = exception.Message;
            }
            else
            {
                exceptionMessage = "Unknwon error occured,Please contact to Administrator; Message ID:" + messageID.ToString();
            }
            return exceptionMessage;
        }


    }
}
