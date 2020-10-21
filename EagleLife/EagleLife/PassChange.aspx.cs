using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EagleLife
{
    
    public partial class PassWordChange : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
        string str = null;
        SqlCommand com;
        byte up;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblIUser.Visible = false;
            lblIPass.Visible = false;
            lblChange.Visible = false;
            lblMatch.Visible = false;
            lblLength.Visible = false;
        }

        protected void BtnCncl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
        protected void btnChange_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(strcon);
            connect.Open();
            str = "select * from AdminLogin";
            com = new SqlCommand(str, connect);
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                if (txtCurrent.Text.Length > 6)
                {                  
                    if (txtNew.Text == txtConfirm.Text)
                    {
                        if (txtCurrent.Text == reader["AdminPassWord"].ToString())
                        {
                            up = 1;

                        }

                        else
                        {
                            lblIPass.Visible = true;
                            lblIUser.Visible = true;
                        }
                    }
                    else
                    {
                        lblMatch.Visible = true;
                    }
                }
                else
                {
                    lblLength.Visible = true;
                }
              
            }
            reader.Close();
            connect.Close();
            if (up == 1)
            {
                connect.Open();
                str = "update AdminLogin set AdminPassWord =@AdminPassWord where AdminUserName='" + Session["AdminUserName"].ToString() + "'";
                com = new SqlCommand(str, connect);
                com.Parameters.Add(new SqlParameter("@AdminPassWord", SqlDbType.VarChar, 50));
                com.Parameters["@AdminPassWord"].Value = txtNew.Text;
                com.ExecuteNonQuery();
                connect.Close();
                lblChange.Visible = true;
            }
        }

      
    }
}