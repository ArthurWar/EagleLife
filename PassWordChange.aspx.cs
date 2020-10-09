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
            lblChange.Visible = false;
            ChangePassword1.ChangingPassword += new LoginCancelEventHandler(this.ChangePassword1_ChangedPassword);

        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {
            
        }
    }
}