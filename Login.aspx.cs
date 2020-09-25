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
        }

        

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" && txtPassword.Text != "")
            {
                string ConnectionString;
                ConnectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename= D:\\GitHub\\eaglelife\\EagleLifeDB.mdf; User Instance=true";

                string strSel = "SELECT COUNT(*) FROM Users WHERE UserName = @Username AND Password  = @Password";

                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSel;

                SqlParameter user = new SqlParameter("@Username", SqlDbType.VarChar, 50);
                user.Value = txtUsername.Text.Trim().ToString();
                cmd.Parameters.Add(user);

                SqlParameter pass = new SqlParameter("@Password", SqlDbType.VarChar, 50);
                pass.Value = txtPassword.Text.Trim().ToString();
                cmd.Parameters.Add(pass);

                con.Open();
                SqlDataAdapter du = new SqlDataAdapter("Select adminUsername from AdminLogin where adminUsername ='" + txtUsername.Text + "'", con);
                SqlDataAdapter dp = new SqlDataAdapter("Select adminPassword from AdminLogin where adminPassword ='" + txtPassword.Text + "'", con);
                if ( )
                {

                }

                else
                {
                    Response.Redirect("Initial.aspx");
                }
            }
            else
            {
                lblLoginError.Visible = true;
            }
        }
    }
    }
