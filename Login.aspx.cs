using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.EnterpriseServices;

namespace EagleLife
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLoginError.Visible = false;
            lblDatafill.Visible = false;
            if(!IsPostBack)
            {
                if (Request.Cookies["adminUsername"] != null)
                    txtUsername.Text = Request.Cookies["adminUsername"].Value;
                
            }
        }
        protected void chkrmb_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string User = txtUsername.Text;
            string Pass = txtPassword.Text;


            if (txtPassword.Text != "" && txtPassword.Text != "" )
            {

                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString);
                connect.Open();
                string checkuserpass = "Select adminID, adminUsername, adminPassword " +
                                     "From AdminLogin where adminUsername = @adminUsername AND adminPassword = @adminPassword ";

                SqlCommand cmd = new SqlCommand(checkuserpass, connect);

                cmd.Parameters.AddWithValue("@adminUsername", User);
                cmd.Parameters.AddWithValue("@adminPassword", Pass);
                
                int count = Convert.ToInt32(cmd.ExecuteScalar());
               
                if (count == 1)               
                {
                    if(chkrmb.Checked == true)
                    {
                        Response.Cookies["adminUsername"].Value = txtUsername.Text;

                        Response.Cookies["adminUsername"].Expires = DateTime.Now.AddDays(7);
                    }
                    else
                    {
                        Response.Cookies["adminUsername"].Expires = DateTime.Now.AddDays(-1);
                    }
                    connect.Close();                
                    Session["adminUsername"] = txtUsername.Text.Trim();
                    Session["adminPassword"] = txtPassword.Text.Trim();
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

      
    }
    }
