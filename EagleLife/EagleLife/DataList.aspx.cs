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

        //internal object Column;
        //internal object Columns;
        //internal readonly IEnumerable<DataRow> Rows;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }



        protected void btnSaveFile_Click(object sender, EventArgs e)
        {
            ////DataList dl = OperationsUtlity.CreateDataList();
            //string filename = DataList.OpenSavefileDialog();
            //DataList.ToCSV(filename);

           

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", @"attachment; filename=""export.csv""");
            Response.TransmitFile(Server.MapPath("~/TestFile.aspx"));
            //Response.Write(sb.ToString());
            Response.End();


        }

        //private static void ToCSV(string filename)
        //{
        //    throw new NotImplementedException();
        //}

        //private static string OpenSavefileDialog()
        //{
        //    throw new NotImplementedException();
        //}

        protected void btnSaveFile_Click1(object sender, EventArgs e)
        {
            


        }
        protected void EagleLifeDB_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

    }
}
    //public static class OperationsUtlity
    //{
    //    public static DataTable CreateDataTable()
    //    {
    //        //get
    //        //{
    //            DataTable dt = new DataTable();
    //            dt.Columns.Add("Id", typeof(int));
    //            dt.Columns.Add("Name", typeof(string));
    //            dt.Columns.Add("Email", typeof(string));
    //            dt.Columns.Add("Phone", typeof(string));
    //            dt.Columns.Add("School", typeof(string));
    //            dt.Columns.Add("Leader", typeof(string));
    //            dt.Columns.Add("Has_Code", typeof(string));
    //            dt.Columns.Add("Group_Code",typeof(string));
    //        //Get Rows From Dataset
    //        SqlDataAdapter da = new SqlDataAdapter();
    //        DataSet ds = new DataSet();
    //        da.SelectCommand = new SqlCommand(@"SELECT * FROM Student", DbConnectionStringBuilder);
    //        da.Fill(ds, "Student");
    //        dt = ds.Tables["Student"];
    //        //dt.Rows.Add(2, "Mudassar Khan", "India");
    //        //dt.Rows.Add(3, "Suzanne Mathews", "France");
    //        //dt.Rows.Add(4, "Robert Schidner", "Russia");

    //        //DataList dl = new DataList();
    //        //dt.BorderStyle = BorderStyle.Groove;

    //        //dl.ItemTemplate = new DatalistLabelColumnBind();
    //        //dl.DataSource = dt;
    //        //dl.DataBind();

    //        //return table;
    //    }


    //    internal static DataList CreateDataList()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

//    public static class CSVUtlity
//    {

//        public static void ToCSV(this Page dtDataTable, string strFilePath)
//        {
//            StreamWriter sw = new StreamWriter(strFilePath, false);
//            //headers  
//            for (int i = 0; i < dtDataTable.Column.Count; i++)
//            {
//                sw.Write(dtDataTable.Columns[i]);
//                if (i < dtDataTable.Columns.Count - 1)
//                {
//                    sw.Write(",");
//                }
//            }
//            sw.Write(sw.NewLine);
//            foreach (DataRow dr in dtDataTable.Rows)
//            {
//                for (int i = 0; i < dtDataTable.Columns.Count; i++)
//                {
//                    if (!Convert.IsDBNull(dr[i]))
//                    {
//                        string value = dr[i].ToString();
//                        if (value.Contains(','))
//                        {
//                            value = String.Format("\"{0}\"", value);
//                            sw.Write(value);
//                        }
//                        else
//                        {
//                            sw.Write(dr[i].ToString());
//                        }
//                    }
//                    if (i < dtDataTable.Columns.Count - 1)
//                    {
//                        sw.Write(",");
//                    }
//                }
//                sw.Write(sw.NewLine);
//            }
//            sw.Close();
//        }
//    }
//}
