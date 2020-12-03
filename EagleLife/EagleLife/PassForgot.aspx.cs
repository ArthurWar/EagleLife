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
       static string randomcode;
       
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

                        var from = new MailAddress("EagleLifeCap2020@gmail.com");
                        var to = new MailAddress(mail);
                        MailMessage mess = new MailMessage(from, to);
                        mess.Subject = "Password Resetting Code!";
                        mess.Body = ("Your Reset Code is: " + randomcode );

                        SmtpClient smtp = new SmtpClient();

                        NetworkCredential cred = new NetworkCredential();

                        cred.UserName = from.User;
                        cred.Password = "YoungLife";

                        smtp.Credentials = cred;
                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;


                        smtp.Send(mess);
                        lblSent.Visible = true;
               
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

        private static DateTime time = DateTime.MinValue;
        private static string current = "0";
        public string Currentnumber()
        {
            if(time < DateTime.Now)
            {
                time = DateTime.Now.AddMinutes(5);
            }
            return current;
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
           
            string text = txtEmail.Text;
            string code = txtCode.Text;
            DateTime dtnow = DateTime.Now;
            DateTime dtExp = dtnow.AddMinutes(30);
            
            SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From AdminLogin where AdminEmail='" + text + "'", strcon);
            DataTable dat = new DataTable();
            adapter.Fill(dat);

            strcon.Open();
            string checkemail = "Select AdminEmail from AdminLogin where AdminEmail= '" + text + "'";

            SqlCommand cmd = new SqlCommand(checkemail, strcon);

            SqlDataReader read = cmd.ExecuteReader();
            if (txtCode.Text != "")
            {
                if (txtCode.Text.Length == 6)
                {
                    if (dat.Rows.Count >= 1)
                    {

                        if (randomcode == code)
                        {

                            lblcode.Visible = true;
                            Response.Redirect("PassReset.aspx");
                        }
                        else
                        {
                            lblincode.Visible = true;

                        }
                    }
                    else
                    {
                        lblincode.Visible = true;
                    }
                }
                else
                {
                    lblincode.Visible = true;
                }
                
            }

            else
            {
                lblincode.Visible = true;
            }
            strcon.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}