using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Caching;

namespace EagleLife
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLoginError.Visible = false;
            lblDatafill.Visible = false;
            if (!IsPostBack)
            {
                if (Request.Cookies["AdminUser"] != null)
                    txtUsername.Text = Request.Cookies["AdminUser"].Value;
            }
        }

        protected void chkRmb_CheckedChanged(object sender, EventArgs e)
        {

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;

            string pass = txtPassword.Text;


            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString);

                con.Open();

                string checkuserpass =  "Select AdminId, AdminUser, AdminPass " +
                    "From AdminLogin where AdminUser = @AdminUser AND AdminPass = @AdminPass ";

                SqlCommand cmd = new SqlCommand(checkuserpass, con);

                cmd.Parameters.AddWithValue("@AdminUser", user);
                cmd.Parameters.AddWithValue("@AdminPass", pass);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if(count == 1)
                {
                    if(chkRmb.Checked == true)
                    {
                        Response.Cookies["AdminUser"].Value = txtUsername.Text;
                        Response.Cookies["AdminUser"].Expires = DateTime.Now.AddDays(7);
                    }
                    else
                    {
                        Response.Cookies["AdminUser"].Expires = DateTime.Now.AddDays(-1);
                    }
                    con.Close();
                    Session["AdminUser"] = txtUsername.Text.Trim();
                    Session["AdminPass"] = txtPassword.Text.Trim();
                    Response.Redirect("Initial.aspx");
                }
                else
                {
                    lblLoginError.Visible = true;
                }
            }
            else
            {
                lblDatafill.Visible = true;

            }

        }

        protected void ForgotLnk_Click(object sender, EventArgs e)
        {
            Response.Redirect("PasswordForgot.aspx");
        }

        protected void ChangeLnk_Click(object sender, EventArgs e)
        {
            Response.Redirect("PassWordChange.aspx");
        }
    }
}