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
            lblSearch.Text = "";
            if (txtUserID.Text != "")
            {
                string connStr = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                string SQLStr = "Select StID, StName, StPhone, StEmail, StSchool, StHasGroup, StGroupCode From Student Where StID = @StID";
                SqlCommand comm = new SqlCommand(SQLStr, conn);
                comm.Parameters.AddWithValue("StID", txtUserID.Text);
                try
                {
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        txtUserName.Text = reader["StName"].ToString();
                        txtUserPhone.Text = reader["StPhone"].ToString();
                        txtUserEmail.Text = reader["StEmail"].ToString();
                        txtUserSchool.Text = reader["StSchool"].ToString();
                        userHasGroup.Checked = Convert.ToBoolean(reader["StHasGroup"]);
                        if (userHasGroup.Checked == true)
                        {
                            txtUserGroup.Text = reader["StGroupCode"].ToString();
                        }
                        else
                        {
                            txtUserGroup.Text = "User has no group.";
                        }
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