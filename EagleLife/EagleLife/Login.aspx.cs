using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace EagleLife
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLoginError.Visible = false;
        }

        

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" && txtPassword.Text != "")
            {


                SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =D:\GitHub\eaglelife\EagleLifeLogin.mdf; Integrated Security = True; Connect Timeout = 30");
                string selectState = "Select adminID, adminUsername, adminPassword " +
                                     "From AdminLogin where adminID = @adminID AND adminPassword = @adminPassword";

                SqlCommand cmd = new SqlCommand(selectState, connect);

                cmd.Parameters.AddWithValue("@adminID", txtUsername.Text);
                cmd.Parameters.AddWithValue("@adminPassword", txtPassword.Text);
                connect.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    connect.Close();
                    Session["adminUsername"] = txtUsername.Text.Trim();
                    Response.Redirect("Initial.aspx");
                }

                else
                {
                    lblLoginError.Visible = true;
                }
            }
            else
            {
                lblLoginError.Visible = true;

            }

        }
    }
}