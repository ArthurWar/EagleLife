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

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSwitchList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DataList.aspx");
        }

        protected void btnSwitchAM_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddModify.aspx");
        }

        protected void btnOpenEmail_Click(object sender, EventArgs e)
        {
            string email = txtUserEmail.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:" + email + "'", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblSearch.Text = "";
            if(rdoSearchToggle.SelectedIndex == 0)
            {
                if (txtUserID.Text != "")
                {
                    string connStr = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    string SQLStr = "Select LID, LName, LPhone, LEmail, ScID From Leader Where LID = @LID";
                    SqlCommand comm = new SqlCommand(SQLStr, conn);
                    comm.Parameters.AddWithValue("LID", txtUserID.Text);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        if (reader.Read())
                        {
                            txtUserName.Text = reader["LName"].ToString();
                            txtUserPhone.Text = reader["LPhone"].ToString();
                            txtUserEmail.Text = reader["LEmail"].ToString();
                            txtUserSchool.Text = "N/A";
                            txtUserGroup.Text = reader["ScID"].ToString();
                        }
                        else
                        {
                            lblSearch.Text = "User not found.";

                            txtUserName.Text = "";
                            txtUserPhone.Text = "";
                            txtUserEmail.Text = "";
                            txtUserSchool.Text = "";
                            txtUserGroup.Text = "";
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
            else if (rdoSearchToggle.SelectedIndex == 1)
            {
                if (txtUserID.Text != "")
                {
                    string connStr = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    string SQLStr = "Select StID, StName, StPhone, StEmail, StSchool, StGroupCode From Student Where StID = @StID";
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
                            txtUserGroup.Text = reader["StGroupCode"].ToString();
                        }
                        else
                        {
                            lblSearch.Text = "User not found.";

                            txtUserName.Text = "";
                            txtUserPhone.Text = "";
                            txtUserEmail.Text = "";
                            txtUserSchool.Text = "";
                            txtUserGroup.Text = "";
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
            
            else
            {
                if (txtUserID.Text != "")
                {
                    string connStr = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    string SQLStr = "Select TID, TName, TPhone, TDivisionCode From TeenMom Where TID = @TID";
                    SqlCommand comm = new SqlCommand(SQLStr, conn);
                    comm.Parameters.AddWithValue("TID", txtUserID.Text);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        if (reader.Read())
                        {
                            txtUserName.Text = reader["TName"].ToString();
                            txtUserPhone.Text = reader["TPhone"].ToString();
                            txtUserEmail.Text = "N/A";
                            txtUserSchool.Text = "N/A";
                            txtUserGroup.Text = reader["TDivisionCode"].ToString();
                        }
                        else
                        {
                            lblSearch.Text = "User not found.";

                            txtUserName.Text = "";
                            txtUserPhone.Text = "";
                            txtUserEmail.Text = "";
                            txtUserSchool.Text = "";
                            txtUserGroup.Text = "";
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

        protected void rdoSearchToggle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdoSearchToggle.SelectedIndex == 0)
            {
                lblRanges.Text = "ID Range: 1001-1999";
            }
            else if(rdoSearchToggle.SelectedIndex == 1)
            {
                lblRanges.Text = "ID Range: 2001-2999";
            }
            else
            {
                lblRanges.Text = "ID Range: 3001-3999";
            }
        }

        protected void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ChangeLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("PassChange.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}