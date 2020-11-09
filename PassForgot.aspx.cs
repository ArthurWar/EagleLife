using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace EagleLife
{
   public partial class PassWordForgot : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["LoginConnection"].ConnectionString;
        string str = null;
        SqlCommand com;
        string randomcode;
        public static string to;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSent.Visible = false;
            lblWrong.Visible = false;
            lblincode.Visible = false;
            lblcode.Visible = false;
            lblMissing.Visible = false;

        }

        protected void btnSend_Click1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            str = "Select * from AdminLogin";
            com = new SqlCommand(str, conn);
            SqlDataReader reader = com.ExecuteReader();
            Regex emailregex = new Regex(@"[a-z0-9!#$%&'*+/=?^_{|}~]+(?:\.[a-z0-9!!#$%&'*+/=?)^_{|}~-]+)");

            if(txtEmail.Text == "")
            {
                lblMissing.Visible = true;
            }
            else
            {
                if (emailregex.IsMatch(txtEmail.Text))
                {
                    if (reader.Read())
                    {
                        try
                        {
                            Session["AdminEmail"] = txtEmail.Text.Trim();
                            Random rand = new Random();
                            randomcode = (rand.Next(999999)).ToString();
                            SmtpClient client = new SmtpClient();
                            MailMessage mess = new MailMessage();
                            client.UseDefaultCredentials = false;
                            client.Credentials = new NetworkCredential("apmckee11@gmail.com", "YoungLife");
                            client.Port = 587;
                            client.EnableSsl = true;
                            client.Host = "smtp.gmail.com";
                            mess.To.Add(txtEmail.Text);
                            mess.From = new MailAddress("apmckee11@gmail.com");
                            mess.Body = randomcode;
                            mess.Subject = "Password reseting code!";
                            client.Send(mess);
                            conn.Close();
                            reader.Close();
                            lblSent.Visible = true;
                        }
                        catch
                        {
                            Exception ex;
                        }
                       
                    }
                    else
                    {
                        lblWrong.Visible = true;
                    }
                }
                else
                {
                    lblWrong.Visible = true;
                }
            }
        }
       protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if(randomcode == (txtCode.Text).ToString())
            {
                lblcode.Visible = true;
                to = txtEmail.Text;
                Response.Redirect("PassChange.aspx");
            }
            else
            {
                lblincode.Visible = true;
            }
        }
    }
}