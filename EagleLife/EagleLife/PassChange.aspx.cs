﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EagleLife
{

    public partial class PassWordChange : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["LoginConnection"].ConnectionString;
        string str = null;
        SqlCommand com;
        byte up;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblChange.Visible = false;
            lblError.Text = "";
        }

        protected void BtnCncl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
        protected void btnChange_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtCurrent.Text;

            SqlConnection connect = new SqlConnection(strcon);
            SqlDataAdapter data = new SqlDataAdapter("Select COUNT(*) FROM AdminLogin where AdminUserName='" + user + "' AND AdminPassWord= '" + pass + "'", connect);
            DataTable dt = new DataTable();
            data.Fill(dt);

            connect.Open();
            str = "Select AdminUserName, AdminPassword from AdminLogin where AdminUserName='"+ user +"' AND AdminpassWord='"+pass+"'";

            com = new SqlCommand(str, connect);
            SqlDataReader reader = com.ExecuteReader();

           

            if (txtUser.Text == "" || txtCurrent.Text == "")
            {
                lblError.Text = "Please enter a valid username and password.";
            }

            else if(txtCurrent.Text == txtNew.Text || txtCurrent.Text == txtConfirm.Text)
            {
                lblError.Text = "New password cannot be same as current password.";
            }

            else
            {
                
                if (dt.Rows.Count > 0)
                {
                    if (txtNew.Text.Length >= 6 && txtConfirm.Text.Length >= 6)
                    {
                        if (txtNew.Text == txtConfirm.Text)
                        {
                            if (reader.Read())
                            {
                                connect.Close();
                                connect.Open();
                                str = "Update AdminLogin set AdminPassWord = @AdminPassWord where AdminUserName ='" + txtUser.Text + "'";
                                com = new SqlCommand(str, connect);
                                com.Parameters.Add(new SqlParameter("@AdminPassWord", SqlDbType.VarChar, 50));
                                com.Parameters["@AdminPassWord"].Value = txtNew.Text;
                                com.ExecuteNonQuery();
                                connect.Close();
                                lblChange.Visible = true;
                            }
                            else
                            {
                                lblError.Text = "Please enter a valid UserName and Password.";
                            }
                        }
                        else
                        {
                            lblError.Text = "New and Confirm Password must match.";
                        }
                    }
                    else
                    {
                        lblError.Text = "New password must be at least 6 characters long.";
                    }
                }
                else
                {
                    lblError.Text = "Please enter a valid Username and Password";
                }
                
            }
            reader.Close();
        }
    }
}