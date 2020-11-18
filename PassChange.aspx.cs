using System;
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
        SqlConnection strcon = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnection"].ConnectionString);
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
            string pass = txtCurrent.Text;
            string user = txtUser.Text;

            SqlDataAdapter asdf = new SqlDataAdapter("Select COUNT(*) from AdminLogin where AdminUsername='" + user + "'AND  AdminPassword ='" + pass + "'", strcon);
            DataTable dt = new DataTable();
            asdf.Fill(dt);

            strcon.Open();
           string str = "Select AdminUserName, AdminpassWord from AdminLogin where AdminUserName = '"+user+"'AND AdminPassWord='"+pass+"'";
           SqlCommand com = new SqlCommand(str, strcon);
           SqlDataReader reader = com.ExecuteReader();
            if (dt.Rows.Count >= 1)
            {
                if (txtUser.Text == "" || txtCurrent.Text == "")
                {
                    lblError.Text = "Please make sure both the username and password are filled out.";
                }

                else if (txtCurrent.Text == txtNew.Text || txtCurrent.Text == txtConfirm.Text)
                {
                    lblError.Text = "New password cannot be same as current password.";
                }

                else
                {                  
                    if (txtNew.Text.Length >= 6 && txtConfirm.Text.Length >= 6)
                    {
                        if (txtNew.Text == txtConfirm.Text)
                        {
                            if (reader.Read())
                            {
                                strcon.Close();
                                strcon.Open();
                                str = "Update AdminLogin set AdminPassWord = @AdminPassWord where AdminUserName ='" + txtUser.Text + "'";
                                com = new SqlCommand(str, strcon);
                                com.Parameters.Add(new SqlParameter("@AdminPassWord", SqlDbType.VarChar, 50));
                                com.Parameters["@AdminPassWord"].Value = txtNew.Text;
                                com.ExecuteNonQuery();
                                strcon.Close();
                                lblChange.Visible = true;
                            }
                            
                            else 
                            {
                                lblError.Text = "Invalid username or Password.";
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
            }
            else
            {
                lblError.Text = "Please enter a valid username and password.";
            }
        }
    }
}