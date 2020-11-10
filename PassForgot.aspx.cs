using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        SqlConnection strcon = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnection"].ConnectionString);
        string server = null;
        SqlCommand com;
        string randomcode;
        public static string to;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFail.Visible = false;
            lblSent.Visible = false;
            lblWrong.Visible = false;
            lblincode.Visible = false;
            lblcode.Visible = false;
            lblMissing.Visible = false;

        }

        protected void btnSend_Click1(object sender, EventArgs e)
        {
            string mail = txtEmail.Text;
            
            SqlDataAdapter adapt = new SqlDataAdapter("Select COUNT(*) FROM AdminLogin where AdminEmail='" + mail + "'", strcon);
            DataTable tab = new DataTable();
            adapt.Fill(tab);

            strcon.Open();

            string email = "Select AdminEmail FROM AdminLogin where AdminEmail='" + mail + "'";
            SqlCommand comm = new SqlCommand(email, strcon);

            SqlDataReader reader = comm.ExecuteReader();
            Regex emailregex = new Regex(@"[a-z0-9!#$%&'*+/=?^_{|}~]+(?:\.[a-z0-9!!#$%&'*+/=?)^_{|}~-]+)");
            Random rand = new Random();
            randomcode = (rand.Next(999999)).ToString();

            if (txtEmail.Text != "")
            {
                if (emailregex.IsMatch(mail))
                {
                    if (reader.Read())
                    {
                        using (SmtpClient smtp = new SmtpClient(server, 25))
                        {
                            string from, to, messagebody;
                            from = "apmckee11@gmail.com";
                            to = (txtEmail.Text).ToString();
                            MailMessage mess = new MailMessage(from, to);
                            messagebody = "Your Reset Code is " + randomcode;
                            mess.To.Add(to);
                            mess.From = new MailAddress(from);
                            mess.Body = messagebody;
                            mess.Subject = "Password reseting code!";
                            mess.IsBodyHtml = true;
                            smtp.Host = "smtp.gmail.com";
                            smtp.UseDefaultCredentials = true;
                            smtp.EnableSsl = true;
                            smtp.Port = 465;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Credentials = new NetworkCredential("AMcKee", "YoungLife");
                            smtp.Send(mess);
                            lblSent.Visible = true;
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
            else
            {
                lblMissing.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if (randomcode == (txtCode.Text).ToString())
            {
                lblcode.Visible = true;
                to = txtEmail.Text;
                Response.Redirect("PassWordReset.aspx");
            }
            else
            {
                lblincode.Visible = true;
            }
        }
    }
}