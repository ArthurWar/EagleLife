using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EagleLife
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSwitchList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DataList.aspx");
        }

        protected void btnOpenEmail_Click(object sender, EventArgs e)
        {
            string email = txtUserEmail.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:" + email + "'", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text != "")
            {
                string connStr = ConfigurationManager.ConnectionStrings["YoungLifeDB.mdf"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                string SQLStr = "Select StEmail, StPhone, StGroupCode, StSchool From Student Where StName = @StName";
                SqlCommand comm = new SqlCommand(SQLStr, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        txtUserName.Text = reader["StName"].ToString();
                        txtUserPhone.Text = reader["StPhone"].ToString();
                        txtUserEmail.Text = reader["StEmail"].ToString();
                        txtUserArea.Text = reader["StSchool"].ToString();
                    }
                    else
                    {
                        lblSearch.Text = "User not found.";
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    lblSearch.Text = "Error: " + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                lblSearch.Text = "Must enter a valid user ID.";
            }
        }
    }
}