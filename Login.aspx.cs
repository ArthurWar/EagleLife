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
            string strUser = txtUsername.Text;

            string strPass = txtPassword.Text;

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblLoginError.Visible = true;

            }
            else
            {
                SqlConnection dataconnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\GitHub\eaglelife\EagleLifeLogin.mdf; Integrated Security = True; Connect Timeout = 30.");





            }
        }
    }
}