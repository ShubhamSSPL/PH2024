using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

namespace Pharmacy2024.StaticPages
{
    public partial class ImportCandidateSentSMS : System.Web.UI.Page
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
             
        }
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void LoadDataToDatabase(string tableName, string fileFullPath, string delimeter)
        {
            try
            {


                string sqlQuery = string.Empty;
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(string.Format("BULK INSERT {0} ", tableName));
                sb.AppendFormat(string.Format(" FROM '{0}'", fileFullPath));
                sb.AppendFormat(string.Format(" WITH ( FIELDTERMINATOR = '{0}' , ROWTERMINATOR = '\n' )", delimeter));
                sqlQuery = sb.ToString();

                using (SqlConnection sqlConn = new SqlConnection(GetConnectionString()))
                {
                    sqlConn.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn))
                    {
                        sqlCmd.ExecuteNonQuery();
                        sqlConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LoadDataToDatabase1(string tableName, DataTable dtCSV)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    con.Open();

                    // Get a reference to a single row in the table. 
                    DataRow[] rowArray = dtCSV.Select();

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                    {
                        bulkCopy.DestinationTableName = "dbo.AppForm_SentReminderSMSDetails";

                        try
                        {
                            // Write the array of rows to the destination.
                            bulkCopy.WriteToServer(rowArray);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UploadAndProcessFile()
        {
            if (FileUpload1.HasFile)
            {
                FileInfo fileInfo = new FileInfo(FileUpload1.PostedFile.FileName);
                if (fileInfo.Name.Contains(".csv"))
                {
                    string fileName = fileInfo.Name.Replace(".csv", "").ToString();
                    string csvFilePath = Server.MapPath("../UploadedCSVFiles") + "\\" + fileInfo.Name;

                    //Save the CSV file in the Server inside 'UploadedCSVFiles'   
                    FileUpload1.SaveAs(csvFilePath);

                    //Fetch the location of CSV file   
                    string filePath = Server.MapPath("../UploadedCSVFiles") + "\\";

                    string strSql = string.Format("SELECT * FROM [{0}]", fileInfo.Name);
                    string strCSVConnString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='text;HDR=YES;'", filePath);

                    // load the data from CSV to DataTable   
                    DataTable dtCSV = new DataTable();
                    DataTable dtSchema = new DataTable();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(strSql, strCSVConnString))
                    {
                        adapter.FillSchema(dtCSV, SchemaType.Mapped);
                        adapter.Fill(dtCSV);
                    }

                    if (dtCSV.Rows.Count > 0)
                    {
                        //CreateDatabaseTable(dtCSV, fileName);
                        //Label2.Text = string.Format("The table ({0}) has been successfully created to the database.", fileName);
                        string fileFullPath = filePath + fileInfo.Name;
                        LoadDataToDatabase1("AppForm_SentReminderSMSDetails", dtCSV);
                        Label1.Text = string.Format("({0}) records has been loaded to the table {1}.", dtCSV.Rows.Count, fileName);
                    }
                    else
                    {
                        lblError.Text = "File is empty.";
                    }
                }
                else
                {
                    lblError.Text = "Unable to recognize file.";
                }
            }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            UploadAndProcessFile();
        }

    }
}