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

namespace EagleLife
{
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
            String FileName = "EagleLife_Output.txt";
            //String FilePath = "C:/Users/Sarah/Downloads"; //Replace this
            //swrOutput = File.CreateText(dlgSave.FileName)

            //File.SetAttributes(FileName, FileAttributes.Normal);
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; EagleLife_Output=" + FileName + ";");
            //response.TransmitFile(FilePath);
            response.TransmitFile(Server.MapPath("/EagleLife_Output.txt"));
            response.Flush();
            response.End();


        }
        protected void EagleLifeDB_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

    }
}
//}
