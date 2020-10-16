using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;
using System.Data.Common;

namespace EagleLife
{

    public partial class DataList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }



        protected void btnSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                lblFolderStatus.Text = "";
                lblSaveStatus.Text = "";
                string strDelimiter = ",";
                string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                StringBuilder stringBuilder = new StringBuilder();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT [StID],[StName],[StPhone],[StLeader],[StSchool],[StGroupCode] FROM [Student];", connectionString);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dataSet.Tables[0].TableName = "Students";

                    stringBuilder.Append("ID" + strDelimiter);
                    stringBuilder.Append("Name" + strDelimiter);
                    stringBuilder.Append("Phone" + strDelimiter);
                    stringBuilder.Append("Leader" + strDelimiter);
                    stringBuilder.Append("School" + strDelimiter);
                    stringBuilder.Append("Group Code" + strDelimiter);
                    stringBuilder.Append("\r\n");

                    foreach (DataRow studentDR in dataSet.Tables["Students"].Rows)
                    {
                        int studentID = Convert.ToInt32(studentDR["StID"]);
                        stringBuilder.Append(studentID.ToString() + strDelimiter);
                        stringBuilder.Append(studentDR["StName"].ToString() + strDelimiter);
                        stringBuilder.Append(studentDR["StPhone"].ToString() + strDelimiter);
                        stringBuilder.Append(studentDR["StLeader"].ToString() + strDelimiter);
                        stringBuilder.Append(studentDR["StSchool"].ToString() + strDelimiter);
                        stringBuilder.Append(studentDR["StGroupCode"].ToString() + strDelimiter);
                        stringBuilder.Append("\r\n");
                    }
                }
                string strFileName = strDelimiter == "," ? "Students.csv" : "Students.txt";
                string subPath = HttpRuntime.AppDomainAppPath + "\\ExportedData\\";

                bool exists = System.IO.Directory.Exists(subPath);

                if (!exists)
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(subPath);
                        lblFolderStatus.Text = "Folder ExportedData created. ";
                        lblFolderStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    catch (IOException ex)
                    {
                        lblFolderStatus.Text = "Error: " + ex.Message;
                        lblFolderStatus.ForeColor = System.Drawing.Color.Red;
                        throw;
                    }
                }
                    

                StreamWriter file = new StreamWriter(subPath + strFileName);
                file.WriteLine(stringBuilder.ToString());
                file.Close();
                lblSaveStatus.Text = "Save to " + subPath + strFileName + " successful.";
                lblSaveStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (SqlException ex)
            {
                lblSaveStatus.Text = "Error: " + ex.Message;
                lblSaveStatus.ForeColor = System.Drawing.Color.Red;
                throw;
            }
        }

        protected void btnSaveLeaderFile_Click(object sender, EventArgs e)
        {
            try
            {
                lblFolderStatus.Text = "";
                lblSaveStatus.Text = "";
                string strDelimiter = ",";
                string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                StringBuilder stringBuilder = new StringBuilder();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT [LID],[LName],[LPhone],[LEmail],[ScID] FROM [Leader];", connectionString);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dataSet.Tables[0].TableName = "Leaders";

                    stringBuilder.Append("ID" + strDelimiter);
                    stringBuilder.Append("Name" + strDelimiter);
                    stringBuilder.Append("Phone" + strDelimiter);
                    stringBuilder.Append("Email" + strDelimiter);
                    stringBuilder.Append("School Code" + strDelimiter);
                    stringBuilder.Append("\r\n");

                    foreach (DataRow studentDR in dataSet.Tables["Leaders"].Rows)
                    {
                        int studentID = Convert.ToInt32(studentDR["LID"]);
                        stringBuilder.Append(studentID.ToString() + strDelimiter);
                        stringBuilder.Append(studentDR["LName"].ToString() + strDelimiter);
                        stringBuilder.Append(studentDR["LPhone"].ToString() + strDelimiter);
                        stringBuilder.Append(studentDR["LEmail"].ToString() + strDelimiter);
                        stringBuilder.Append(studentDR["ScID"].ToString() + strDelimiter);
                        stringBuilder.Append("\r\n");
                    }
                }
                string strFileName = strDelimiter == "," ? "Leaders.csv" : "Leaders.txt";
                string subPath = HttpRuntime.AppDomainAppPath + "\\ExportedData\\";

                bool exists = System.IO.Directory.Exists(subPath);

                if (!exists)
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(subPath);
                        lblFolderStatus.Text = "Folder ExportedData created. ";
                        lblFolderStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    catch (IOException ex)
                    {
                        lblFolderStatus.Text = "Error: " + ex.Message;
                        lblFolderStatus.ForeColor = System.Drawing.Color.Red;
                        throw;
                    }
                }


                StreamWriter file = new StreamWriter(subPath + strFileName);
                file.WriteLine(stringBuilder.ToString());
                file.Close();
                lblSaveStatus.Text = "Save to " + subPath + strFileName + " successful.";
                lblSaveStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (SqlException ex)
            {
                lblSaveStatus.Text = "Error: " + ex.Message;
                lblSaveStatus.ForeColor = System.Drawing.Color.Red;
                throw;
            }
        }
    }
}
