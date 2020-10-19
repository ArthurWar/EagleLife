using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EagleLife
{
    public partial class PassWordChange : System.Web.UI.Page
    {
        string strconstr = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;

        string str = null;
        SqlCommand cmd;
        byte up;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
            lblChange.Visible = false;
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ChangePassword1.ChangingPassword += new LoginCancelEventHandler(this.ChangePassword1_ChangedPassword);
        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {
            if(!ChangePassword1.CurrentPassword.Equals(ChangePassword1.NewPassword, StringComparison.CurrentCultureIgnoreCase))
            {
                int rowsaffected = 0;

                string query = "Update AdminLogin Set PassWord = @NewPassWord where AdminUserName = @AdminUserName AND AdminPassWord = @AdminPassWord";

                string constr = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;

                using(SqlConnection con = new SqlConnection(constr))
                {
                    using(SqlCommand cmd = new SqlCommand(query))
                    {
                        using(SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@AdminUserName", this.Page.User.Identity.Name);
                            cmd.Parameters.AddWithValue("AdminPassWord", ChangePassword1.CurrentPassword);
                            cmd.Parameters.AddWithValue("@NewPassWord", ChangePassword1.NewPassword);
                            cmd.Connection = con;
                            con.Open();
                            rowsaffected = cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    if(rowsaffected > 0)
                    {
                        lblSuccess.Visible = true; 
                    }
                    else
                    {
                        lblChange.Visible = true;
                    }
                }
            }
        }
    }
}