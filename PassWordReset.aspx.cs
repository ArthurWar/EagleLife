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
    public partial class PassWordReset : System.Web.UI.Page
    {
        SqlConnection cont = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnection"].ConnectionString);
        string str = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblEmpty.Visible = false;
            lblIncorrect.Visible = false;
            lblLength.Visible = false;
            lblMatch.Visible = false;
            lblSuccess.Visible = false;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;

            SqlDataAdapter adapt = new SqlDataAdapter("Select COUNT(*) from AdminLogin where AdminUsername='" + user + "'", cont);
            DataTable table = new DataTable();
            adapt.Fill(table);

            cont.Open();
            string checkuse = "Select AdminUserName From AdminLogin where AdminUserName= '" + user + "'";

            SqlCommand cmd = new SqlCommand(checkuse, cont);

            SqlDataReader reader = cmd.ExecuteReader();
            if(table.Rows.Count >= 1)
            {
                if(txtUser.Text != "")
                {
                    if(txtNew.Text.Length >= 6 && txtConfirm.Text.Length >= 6)
                    {
                        if(txtNew.Text == txtConfirm.Text)
                        {
                            if (reader.Read())
                            {
                                cont.Close();
                                cont.Open();
                                str = "Update AdminLogin set AdminPassword =@AdminPassWord where AdminUserName='" + user + "'";
                                cmd = new SqlCommand(str, cont);
                                cmd.Parameters.Add(new SqlParameter("@AdminPassword", SqlDbType.VarChar, 50));
                                cmd.Parameters["@AdminPassWord"].Value = txtNew.Text;
                                cmd.ExecuteNonQuery();
                                cont.Close();
                                lblSuccess.Visible = true;

                            }
                            else
                            {
                                lblIncorrect.Visible = true;
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
                    lblEmpty.Visible = true;
                }
            }
            else
            {
                lblIncorrect.Visible = true;
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}