using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EagleLife
{

    public partial class AddModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSwitchList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnOpenEmail_Click(object sender, EventArgs e)
        {
            string email = txtUserEmail.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:" + email + "'", true);
        }

        protected void rdoSearchToggle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdoSearchToggle.SelectedIndex == 0)
            {
                lblRanges.Text = "ID Range: 1001-1999";
            }
            else if(rdoSearchToggle.SelectedIndex == 1)
            {
                lblRanges.Text = "ID Range: 2001-2999";
            }
            else
            {
                lblRanges.Text = "ID Range: 3001-3999";
            }
        }

        protected void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}