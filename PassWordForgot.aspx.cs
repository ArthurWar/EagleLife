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

namespace EagleLife
{

    public partial class PassWordForgot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSent.Visible = false;
            lblWrong.Visible = false;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(conn);
            string sqlquery = "select AdminUserName, AdminPassWord from AdminLogin where AdminEmail=@AdminEmail";
            SqlCommand comm = new SqlCommand(sqlquery, connect);
            comm.Parameters.AddWithValue("@AdminEmail", txtEmail.Text);
            connect.Open();
            SqlDataReader sdr = comm.ExecuteReader();
            if (sdr.Read())
            {
                string user = sdr["AdminUserName"].ToString();
                string pass = sdr["AdminPassWord"].ToString();
                

                MailMessage mess = new MailMessage("apmckee11@gmail.com", txtEmail.Text);
                mess.Subject = "Password Recovery!";
                mess.Body = string.Format("Hello; <h1>{0}</h1> is your UserName ,br/> your password is <h1>{1}</h1>", user, pass);
                mess.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential();
                nc.UserName = "apmckee11@gmail.com";
                nc.Password = "YoungLife";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Port = 587;
                smtp.Send(mess);
                lblSent.Visible = true;
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
    }
}
    
