using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EagleLife
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSwitchList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DataList.aspx");
        }

        protected void btnOpenEmail_Click(object sender, EventArgs e)
        {
            string email = txtUserEmail.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:" + email + "'", true);
        }
    }
}