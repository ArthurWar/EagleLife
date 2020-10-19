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
            lblDataFill.Visible = false;
            if (!IsPostBack)
            {
                if (Request.Cookies["AdminUserName"] != null)
                    txtUsername.Text = Request.Cookies["AdminUserName"].Value;
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

                string checkuserpass = "Select AdminID, AdminUserName, AdminPassWord  From AdminLogin where AdminUserName = @AdminUserName AND AdminPassWord = @AdminPassWord ";

                SqlCommand cmd = new SqlCommand(checkuserpass, con);

                cmd.Parameters.AddWithValue("@AdminUserName", user);
                cmd.Parameters.AddWithValue("@AdminPassWord", pass);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if(count == 1)
                {
                    if(chkRmb.Checked == true)
                    {
                        Response.Cookies["AdminUserName"].Value = txtUsername.Text;
                        Response.Cookies["AdminUserName"].Expires = DateTime.Now.AddDays(7);
                    }
                    else
                    {
                        Response.Cookies["AdminUserName"].Expires = DateTime.Now.AddDays(-1);
                    }
                    con.Close();
                    Session["AdminUserName"] = txtUsername.Text.Trim();
                    Session["AdminPassWord"] = txtPassword.Text.Trim();
                    Response.Redirect("Initial.aspx");
                }
                else
                {
                    lblLoginError.Visible = true;
                }
            }
            else
            {
                lblDataFill.Visible = true;

            }

        }

        protected void ChangeLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("PassChange.aspx");
        }

        protected void ForgotLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("PassWordForgot.aspx");
        }
    }
}