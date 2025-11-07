using BusinessLayer;
using Synthesys.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pharmacy2024.AFCModule
{
    public partial class frmUploadData : System.Web.UI.Page
    {
        private readonly IBusinessService reg = new BusinessServiceImp();
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
        protected void Page_Init(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                string SourceFileType = Request.Form[ddlSourceFileType.UniqueID];
                string SourceFileName = Request.Form[ddlSourceFileName.UniqueID];
                string SourceTableName = Request.Form[ddlSourceTableName.UniqueID];
                string DestinationTableName = Request.Form[ddlDestinationTableName.UniqueID];
                string ConnectionString = "";
                if (SourceFileType == ".mdb")
                {
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/FileUpload/") + SourceFileName;
                }
                else if (SourceFileType == ".accdb")
                {
                    ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/FileUpload/") + SourceFileName;
                }
                else if (SourceFileType == ".xls")
                {
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/FileUpload/") + SourceFileName + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
                }
                else if (SourceFileType == ".xlsx")
                {
                    ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/FileUpload/") + SourceFileName + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"";
                }
                else if (SourceFileType == ".csv")
                {
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + new FileInfo(Server.MapPath("~/FileUpload/") + ddlSourceFileName.SelectedValue).Directory + ";Extended Properties=\"text;HDR=YES;FMT=Delimited\";";
                }

                for (Int32 i = tblColumnsList.Rows.Count - 1; i > 0; i--)
                {
                    tblColumnsList.Rows.RemoveAt(i);
                }

                if (SourceTableName != "0" && DestinationTableName != "0" && SourceTableName != null && DestinationTableName != null)
                {
                    DataTable dtSourceColumns;
                    DataTable dtDestinationColumns;

                    OleDbConnection OleDbConnectionString = new OleDbConnection(ConnectionString);
                    OleDbConnectionString.Open();
                    dtSourceColumns = OleDbConnectionString.GetSchema("Columns").AsEnumerable().Where(a => a.Field<string>("TABLE_NAME") == SourceTableName).OrderBy(a => a.Field<string>("COLUMN_NAME")).CopyToDataTable();
                    OleDbConnectionString.Close();

                    if (DestinationTableName == "[New Table]")
                    {
                        dtDestinationColumns = dtSourceColumns;
                    }
                    else
                    {
                        SqlConnection SqlConnectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["CGA"].ConnectionString);
                        SqlConnectionString.Open();
                        dtDestinationColumns = SqlConnectionString.GetSchema("Columns").AsEnumerable().Where(a => a.Field<string>("TABLE_NAME") == DestinationTableName).CopyToDataTable();
                        SqlConnectionString.Close();
                    }

                    for (Int32 i = 0; i < dtSourceColumns.Rows.Count; i++)
                    {
                        Label lblSourceColumn = new Label();
                        lblSourceColumn.ID = "lblSourceColumn" + Convert.ToString(i + 1);
                        lblSourceColumn.Text = dtSourceColumns.Rows[i]["COLUMN_NAME"].ToString();

                        DropDownList ddlDestinationColumn = new DropDownList();
                        ddlDestinationColumn.ID = "ddlDestinationColumn" + Convert.ToString(i + 1);
                        ddlDestinationColumn.DataSource = dtDestinationColumns;
                        ddlDestinationColumn.DataTextField = "COLUMN_NAME";
                        ddlDestinationColumn.DataValueField = "COLUMN_NAME";
                        ddlDestinationColumn.DataBind();
                        ddlDestinationColumn.Items.Insert(0, new ListItem("-- Select --", "0"));

                        HtmlTableCell cellSource = new HtmlTableCell();
                        cellSource.Controls.Add(lblSourceColumn);
                        cellSource.Align = "Center";

                        HtmlTableCell cellDestination = new HtmlTableCell();
                        cellDestination.Controls.Add(ddlDestinationColumn);
                        cellDestination.Align = "Center";

                        HtmlTableRow row = new HtmlTableRow();
                        row.Cells.Add(cellSource);
                        row.Cells.Add(cellDestination);

                        tblColumnsList.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLoginId"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["WebSite_HomePage"], true);
            }
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (!IsPostBack)
                {
                    Page.Form.Attributes.Add("enctype", "multipart/form-data");

                    ddlSourceFileName.Items.Insert(0, new ListItem("-- Select --", "0"));
                    ddlSourceTableName.Items.Insert(0, new ListItem("-- Select --", "0"));

                    ddlDestinationTableName.DataSource = getDestinationTables();
                    ddlDestinationTableName.DataTextField = "TABLE_NAME";
                    ddlDestinationTableName.DataValueField = "TABLE_NAME";
                    ddlDestinationTableName.DataBind();
                    ddlDestinationTableName.Items.Insert(0, new ListItem("-- Select --", "0"));
                    ddlDestinationTableName.Items.Insert(ddlDestinationTableName.Items.Count, new ListItem("[New Table]", "[New Table]"));

                    if (!Directory.Exists(Server.MapPath("~/FileUpload/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/FileUpload/"));
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (fileUpload.HasFile)
                {
                    if (fileUpload.PostedFile.FileName.Length > 0)
                    {
                        DateTime start = DateTime.Now;
                        bool isValidFile = false;
                        string[] validFileTypes = { ".mdb", ".accdb", ".xls", ".xlsx", ".csv" };
                        string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                        string fileExtension = System.IO.Path.GetExtension(fileUpload.PostedFile.FileName);
                        double fileSize = Math.Round((fileUpload.PostedFile.ContentLength) / (1024f * 1024f), 2);

                        for (Int32 i = 0; i < validFileTypes.Length; i++)
                        {
                            if (fileExtension == validFileTypes[i])
                            {
                                isValidFile = true;
                                break;
                            }
                        }

                        if (isValidFile)
                        {
                            fileUpload.PostedFile.SaveAs(Server.MapPath("~/FileUpload/") + fileName);

                            shInfo.SetMessage(fileSize.ToString() + " MB File Uploaded Successfully in " + DateTime.Now.Subtract(start).Seconds + " Seconds.", ShowMessageType.Information);
                        }
                        else
                        {
                            shInfo.SetMessage("Invalid File. Please upload a File with Extension " + string.Join(", ", validFileTypes), ShowMessageType.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlSourceFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                FileInfo[] files = new DirectoryInfo(Server.MapPath("~/FileUpload/")).GetFiles("*" + ddlSourceFileType.SelectedValue);
                List<string> list = new List<string>();

                foreach (FileInfo file in files)
                {
                    list.Add(file.Name);
                }

                ddlSourceFileName.DataSource = list;
                ddlSourceFileName.DataBind();
                ddlSourceFileName.Items.Insert(0, new ListItem("-- Select --", "0"));

                ddlSourceTableName.Items.Clear();
                ddlSourceTableName.Items.Insert(0, new ListItem("-- Select --", "0"));

                ddlDestinationTableName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlSourceFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                if (ddlSourceFileName.SelectedIndex > 0)
                {
                    OleDbConnection OleDbConnectionString = new OleDbConnection(getConnectionString(ddlSourceFileType.SelectedValue, "OleDbConnection"));
                    OleDbConnectionString.Open();
                    DataTable dt = OleDbConnectionString.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).AsEnumerable().Where(a => a.Field<string>("TABLE_TYPE") == "TABLE").CopyToDataTable();
                    OleDbConnectionString.Close();

                    ddlSourceTableName.DataSource = dt;
                    ddlSourceTableName.DataTextField = "TABLE_NAME";
                    ddlSourceTableName.DataValueField = "TABLE_NAME";
                    ddlSourceTableName.DataBind();
                    ddlSourceTableName.Items.Insert(0, new ListItem("-- Select --", "0"));

                    ddlDestinationTableName.SelectedIndex = 0;
                }
                else
                {
                    ddlSourceTableName.Items.Clear();
                    ddlSourceTableName.Items.Insert(0, new ListItem("-- Select --", "0"));

                    ddlDestinationTableName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlSourceTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                for (Int32 i = 1; i < tblColumnsList.Rows.Count; i++)
                {
                    Label lblSourceColumn = (Label)tblColumnsList.Rows[i].Cells[1].FindControl("lblSourceColumn" + i.ToString());
                    DropDownList ddlDestinationColumn = (DropDownList)tblColumnsList.Rows[i].Cells[1].FindControl("ddlDestinationColumn" + i.ToString());
                    if (ddlDestinationColumn.SelectedIndex == 0)
                    {
                        ddlDestinationColumn.SelectedValue = lblSourceColumn.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void ddlDestinationTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                for (Int32 i = 1; i < tblColumnsList.Rows.Count; i++)
                {
                    Label lblSourceColumn = (Label)tblColumnsList.Rows[i].Cells[1].FindControl("lblSourceColumn" + i.ToString());
                    DropDownList ddlDestinationColumn = (DropDownList)tblColumnsList.Rows[i].Cells[1].FindControl("ddlDestinationColumn" + i.ToString());
                    if (ddlDestinationColumn.SelectedIndex == 0)
                    {
                        ddlDestinationColumn.SelectedValue = lblSourceColumn.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected void btnUploadData_Click(object sender, EventArgs e)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            try
            {
                DateTime start = DateTime.Now;
                Int32 rowsCopied = 0;
                List<string> SourceColumnList = new List<string>();
                List<string> DestinationColumnList = new List<string>();

                for (Int32 i = 1; i < tblColumnsList.Rows.Count; i++)
                {
                    Label lblSourceColumn = (Label)tblColumnsList.Rows[i].Cells[1].FindControl("lblSourceColumn" + i.ToString());
                    DropDownList ddlDestinationColumn = (DropDownList)tblColumnsList.Rows[i].Cells[1].FindControl("ddlDestinationColumn" + i.ToString());
                    if (ddlDestinationColumn.SelectedIndex > 0)
                    {
                        SourceColumnList.Add("[" + lblSourceColumn.Text + "]");
                        DestinationColumnList.Add("[" + ddlDestinationColumn.SelectedValue + "]");
                    }
                }

                DataSet SourceDataSet = new DataSet();
                OleDbConnection OleDbConnectionString = new OleDbConnection(getConnectionString(ddlSourceFileType.SelectedValue, "OleDbConnection"));
                OleDbCommand OleDbCommandString = new OleDbCommand("SELECT " + string.Join(", ", SourceColumnList) + " FROM [" + ddlSourceTableName.SelectedValue + "]", OleDbConnectionString);
                OleDbDataAdapter OleDbDataAdapterString = new OleDbDataAdapter();
                OleDbDataAdapterString.SelectCommand = OleDbCommandString;
                OleDbConnectionString.Open();
                OleDbDataAdapterString.Fill(SourceDataSet);
                OleDbConnectionString.Close();

                SqlConnection SqlConnectionString = new SqlConnection(getConnectionString("sql", "SqlConnection"));
                SqlConnectionString.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(SqlConnectionString))
                {
                    bulkCopy.BatchSize = 5000;
                    if (ddlDestinationTableName.SelectedValue == "[New Table]")
                    {
                        createSQLTable(SourceDataSet.Tables[0], ddlSourceTableName.SelectedValue);
                        bulkCopy.DestinationTableName = "[" + ddlSourceTableName.SelectedValue + "]";
                    }
                    else
                    {
                        bulkCopy.DestinationTableName = "[" + ddlDestinationTableName.SelectedValue + "]";
                    }
                    for (Int32 i = 0; i < DestinationColumnList.Count; i++)
                    {
                        bulkCopy.ColumnMappings.Add(SourceColumnList[i], DestinationColumnList[i]);
                    }
                    bulkCopy.WriteToServer(SourceDataSet.Tables[0]);
                    rowsCopied = SqlBulkCopyHelper.GetRowsCopied(bulkCopy);
                }

                SqlConnectionString.Close();

                shInfo.SetMessage(rowsCopied.ToString() + " Records Copied in " + DateTime.Now.Subtract(start).Milliseconds + " Milliseconds.", ShowMessageType.Information);
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);
            }
        }
        protected DataTable getDestinationTables()
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            DataTable dt = null;
            try
            {
                SqlConnection SqlConnectionString = new SqlConnection(getConnectionString("sql", "SqlConnection"));
                SqlConnectionString.Open();
                dt = SqlConnectionString.GetSchema("Tables").AsEnumerable().Where(a => a.Field<string>("TABLE_TYPE") == "BASE TABLE" && a.Field<string>("TABLE_NAME") != "sysdiagrams").OrderBy(a => a.Field<string>("TABLE_NAME")).CopyToDataTable();
                SqlConnectionString.Close();

                return dt;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);

                return dt;
            }
        }
        protected string getConnectionString(string FileType, string ConnectionType)
        {
            ShowMessage shInfo = (ShowMessage)Master.FindControl("ShowMsg");
            string ConnectionString = "";
            try
            {
                if (ConnectionType == "SqlConnection")
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["CGA"].ConnectionString;
                }
                else
                {
                    if (ddlSourceFileType.SelectedValue == ".mdb")
                    {
                        ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/FileUpload/") + ddlSourceFileName.SelectedValue;
                    }
                    else if (ddlSourceFileType.SelectedValue == ".accdb")
                    {
                        ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/FileUpload/") + ddlSourceFileName.SelectedValue;
                    }
                    else if (ddlSourceFileType.SelectedValue == ".xls")
                    {
                        ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/FileUpload/") + ddlSourceFileName.SelectedValue + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
                    }
                    else if (ddlSourceFileType.SelectedValue == ".xlsx")
                    {
                        ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/FileUpload/") + ddlSourceFileName.SelectedValue + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"";
                    }
                    else if (ddlSourceFileType.SelectedValue == ".csv")
                    {
                        ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + new FileInfo(Server.MapPath("~/FileUpload/") + ddlSourceFileName.SelectedValue).Directory + ";Extended Properties=\"text;HDR=YES;FMT=Delimited\";";
                    }
                }

                return ConnectionString;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex, "[Page Level Error]");
                shInfo.SetMessage(ex.Message, ShowMessageType.TechnicalError, ex.StackTrace);

                return ConnectionString;
            }
        }
        static class SqlBulkCopyHelper
        {
            static FieldInfo rowsCopiedField = null;
            public static Int32 GetRowsCopied(SqlBulkCopy bulkCopy)
            {
                if (rowsCopiedField == null)
                {
                    rowsCopiedField = typeof(SqlBulkCopy).GetField("_rowsCopied", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                }

                return (Int32)rowsCopiedField.GetValue(bulkCopy);
            }
        }
        public void createSQLTable(DataTable dt, string TableName)
        {
            string strCreateTable = "";
            strCreateTable += "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U'))";
            strCreateTable += "BEGIN ";
            strCreateTable += "CREATE TABLE " + TableName + "";
            strCreateTable += "(";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string SqlDbType = (getSqlDbType(dt.Columns[i].DataType).ToString() == "VarChar") ? "VARCHAR(MAX)" : getSqlDbType(dt.Columns[i].DataType).ToString();

                if (i != dt.Columns.Count - 1)
                    strCreateTable += dt.Columns[i].ColumnName + " " + SqlDbType + ",";
                else
                    strCreateTable += dt.Columns[i].ColumnName + " " + SqlDbType;
            }
            strCreateTable += ") ";
            strCreateTable += "END";

            SqlConnection SqlConnectionString = new SqlConnection(getConnectionString("sql", "SqlConnection"));
            SqlCommand SqlCommandString = new SqlCommand(strCreateTable, SqlConnectionString);
            SqlConnectionString.Open();
            SqlCommandString.ExecuteNonQuery();
            SqlConnectionString.Close();
        }
        protected SqlDbType getSqlDbType(Type DataType)
        {
            switch (DataType.ToString())
            {
                case "System.Boolean":
                    return SqlDbType.Bit;
                case "System.Byte":
                    return SqlDbType.TinyInt;
                case "System.Byte[]":
                    return SqlDbType.VarBinary;
                case "System.Char[]":
                    return SqlDbType.VarBinary;
                case "System.DateTime":
                    return SqlDbType.DateTime;
                case "System.DateTimeOffset":
                    return SqlDbType.DateTimeOffset;
                case "System.Decimal":
                    return SqlDbType.Decimal;
                case "System.Double":
                    return SqlDbType.Float;
                case "System.Guid":
                    return SqlDbType.UniqueIdentifier;
                case "System.Int16":
                    return SqlDbType.SmallInt;
                case "System.Int32":
                    return SqlDbType.Int;
                case "System.Int64":
                    return SqlDbType.BigInt;
                case "System.Single":
                    return SqlDbType.Real;
                case "System.String":
                    return SqlDbType.VarChar;
                case "System.TimeSpan":
                    return SqlDbType.Time;
                case "System.Xml":
                    return SqlDbType.Xml;
                default:
                    return SqlDbType.VarChar;
            }
        }
    }
}