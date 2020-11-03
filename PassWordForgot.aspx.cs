using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Text;
using EllipticCurve;
using Microsoft.Web.Services3.Addressing;

namespace EagleLife
{

    public partial class PassWordForgot : System.Web.UI.Page
    {
        string str;
        string randomcode;
        public static string to;
     
    protected void Page_Load(object sender, EventArgs e)
        {
            lblSent.Visible = false;
            lblWrong.Visible = false;
            lblcode.Visible = false;
            lblincode.Visible = false;
        }

        protected void btnSend_Click(object sender,EventArgs e)
        {

            if (txtEmail.Text != "")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString);
                con.Open();
                str = "select AdminEmail from AdminLogin";
                SqlCommand Com = new SqlCommand(str, con);
                SqlDataReader read = Com.ExecuteReader();

                    if (read.Read())
                    {
                    Session["AdminEmail"] = txtEmail.Text.Trim();

                        string from, pass, messagebody;
                        Random rand = new Random();
                        randomcode = (rand.Next(999999)).ToString();
                        MailMessage mess = new MailMessage();
                        to = (txtEmail.Text).ToString();
                        from = "apmckee11@gmail.com";
                        pass = "YoungLife";
                        messagebody = "Your Reset Code is " + randomcode;
                        mess.To.Add(to);
                        mess.From = new MailAddress(from);
                        mess.Body = messagebody;
                        mess.Subject = "Password reseting code!";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, pass);

                        try
                        {
                            smtp.Send(mess);
                            lblSent.Visible = true;
                        }
                        catch (Exception ex)
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
                lblWrong.Visible = true;
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
                Response.Redirect("PasswordChange.aspx");
            }
            else
            {
                lblincode.Visible = true;
            }
        }
    }
}
    
