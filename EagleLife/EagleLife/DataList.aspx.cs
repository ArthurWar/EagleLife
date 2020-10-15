using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;

namespace EagleLife
{
    public class HomeController : System.Web.Mvc.Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EagleLifeDBEntities entities = new EagleLifeDBEntities();
            return DataView(from Student in entities.Students.Take(8)
                        select Student);
        }

        private ActionResult DataView(IQueryable<Student> queryables)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        //This code needs to be called by an HTML "Export" button on the Datalist web page 
        //This page has the code to do it - https://www.aspsnippets.com/Articles/Convert-List-of-Objects-to-CSV-file-using-C-in-ASPNet-MVC.aspx
        //
        public FileResult Export()
        {
            EagleLifeDBEntities entities = new EagleLifeDBEntities();
            List<object> Students = (from Student in entities.Students.ToList().Take(8)
                                     select new[] { Student.StID.ToString(),
                                                            Student.StName,
                                                            Student.StEmail,
                                                            Student.StPhone,
                                                            Student.StLeader,
                                                            Student.StSchool,
                                                            Student.StHasGroup.ToString(),
                                                            Student.StGroupCode.ToString()

                                      }).ToList<object>();

            //Insert the Column Names.
            Students.Insert(0, new string[8] { "StID", "StName", "StEmail", "StPhone", "StLeader", "StSchool", "StHasGroup", "StGroupCode" });

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Students.Count; i++)
            {
                string[] customer = (string[])Students[i];
                for (int j = 0; j < customer.Length; j++)
                {
                    //Append data with separator.
                    sb.Append(customer[j] + ',');
                }

                //Append new line character.
                sb.Append("\r\n");

            }

            return FileContentResult(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "EagleLife_Output.csv");
        }

        private FileResult FileContentResult(byte[] vs, string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
        public partial class DataList : System.Web.UI.Page
        {

            protected void Page_Load(object sender, EventArgs e)
            {

            }

            protected void Button1_Click(object sender, EventArgs e)
            {
                Response.Redirect("~/Default.aspx");
            }



            protected void btnSaveFile_Click(object sender, EventArgs e)
            {




            }


            protected void btnSaveFile_Click1(object sender, EventArgs e)
            {
            //StreamWriter swrOutput;
            String FileName = "EagleLife_Output.csv";
            //String FilePath = "C:/Users/Sarah/Downloads"; //Replace this
            //swrOutput = File.CreateText(dlgSave.FileName)

            //File.SetAttributes(FileName, FileAttributes.Normal);
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; EagleLife_Output=" + FileName + ";");
            //response.TransmitFile(FilePath);
            response.TransmitFile(Server.MapPath("/EagleLife_Output.csv"));
            response.Flush();
            response.End();

        }
      
                            

        protected void EagleLifeDB_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

    }
}
//}
