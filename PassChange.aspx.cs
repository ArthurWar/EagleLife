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
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnection"].ConnectionString);
        string str = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMiss.Visible = false;
            lblUserPass.Visible = false;
            lblChange.Visible = false;
            lblMatch.Visible = false;
            lblLength.Visible = false;
        }

        protected void BtnCncl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
        protected void btnChange_Click(object sender, EventArgs e)
        {
            string use = txtUser.Text;
            string pass = txtpass.Text;

            SqlDataAdapter asdf = new SqlDataAdapter("Select COUNT(*) FROM AdminLogin where AdminUserName='" + use +"' AND AdminPassWord= '" + pass +"'", con);
            DataTable dt = new DataTable();
            asdf.Fill(dt);

            con.Open();
            string checkup = "Select AdminUserName, AdminPassWord  From AdminLogin where AdminUserName = '" + use + "' AND AdminPassWord ='" + pass + "' ";

            SqlCommand command = new SqlCommand(checkup, con);

            SqlDataReader read = command.ExecuteReader();

            if (dt.Rows.Count >= 1)
            {            
                    if (txtUser.Text != "" && txtpass.Text != "")
                    {
                        if (txtNew.Text.Length >= 6 && txtConfirm.Text.Length >= 6)
                        {
                            if (txtNew.Text == txtConfirm.Text)
                            {
                                if (read.Read())
                                {
                                    con.Close();
                                    con.Open();
                                    str = "update AdminLogin set AdminPassWord =@AdminPassWord where AdminUserName='" + txtUser.Text + "'";
                                    command = new SqlCommand(str, con);
                                    command.Parameters.Add(new SqlParameter("@AdminPassWord", SqlDbType.VarChar, 50));
                                    command.Parameters["@AdminPassWord"].Value = txtNew.Text;
                                    command.ExecuteNonQuery();
                                    con.Close();
                                    lblChange.Visible = true;
                                }
                                else
                                {
                                    lblUserPass.Visible = true;
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
                    else
                    {
                        lblMiss.Visible = true;
                    }

            }
            else
            {
                lblUserPass.Visible = true;
            }
        }
    }

}

      
    
