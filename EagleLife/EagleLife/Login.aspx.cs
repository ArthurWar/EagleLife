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
            lblLoginError.Visible = false;
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\GitHub\eaglelife\EagleLifeLogin.mdf; Integrated Security = True; Connect Timeout = 30");
                string selectStatement = "Select adminID, adminUsername, adminPassword " +
                                            "From AdminLogin where adminID = @adminID AND adminPassword = @adminPassword";
                SqlCommand commandString = new SqlCommand(selectStatement, connection);
                commandString.Parameters.AddWithValue("@adminID", txtUsername.Text);
                commandString.Parameters.AddWithValue("@adminPassword", txtPassword.Text);
                connection.Open();
                int count = Convert.ToInt32(commandString.ExecuteScalar());
                if (count == 1)
                {
                    connection.Close();
                    Session["adminUsername"] = txtUsername.Text.Trim();
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    lblLoginError.Visible = true;
                    connection.Close();
                }
            }
        }
    }
}