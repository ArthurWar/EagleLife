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
        string strconstring = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;

        string str = null;

        SqlCommand com;
        byte up;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
            lblChange.Visible = false;
            ChangePassword1.ChangingPassword += new LoginCancelEventHandler(this.ChangePassword1_ChangedPassword);

        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {
            if(!ChangePassword1.CurrentPassword.Equals(ChangePassword1.NewPassword, StringComparison.CurrentCultureIgnoreCase))
            {
                int rowsaffected = 0;

                string query = "Update [AdminLogin] Set [Password] = @NewPassword where [AdminUser] = @AdminUser AND [AdminPass] = @AdminPass";

                string constr = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;

                using(SqlConnection con = new SqlConnection(constr))
                {
                    using(SqlCommand cmd = new SqlCommand(query))
                    { 
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@AdminUser", this.Page.User.Identity.Name);
                            cmd.Parameters.AddWithValue("@AdminPass", ChangePassword1.CurrentPassword);
                            cmd.Parameters.AddWithValue("@NewPassword", ChangePassword1.NewPassword);
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