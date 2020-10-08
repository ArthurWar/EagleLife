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

namespace EagleLife
{
    public partial class DataList : System.Web.UI.Page
    {

        private char csv;
        private object dataList;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void btnSaveFile_Click(object sender, EventArgs e)
        {
            var dataTable = GetData(dataList);
            StringBuilder builder = new StringBuilder();
            List<string> columnNames = new List<string>();
            List<string> rows = new List<string>();

            System.Collections.IList list = columnNames;
            for (int i = 0; i < list.Count; i++)
            {
                DataColumn column = (DataColumn)list[i];
                columnNames.Add(column.ColumnName);
            }

            builder.Append(string.Join(",", columnNames.ToArray())).Append("\n");

            System.Collections.IList list1 = rows;
            for (int i = 0; i < list1.Count; i++)
            {
                DataRow row = (DataRow)list1[i];
                List<string> currentRow = new List<string>();

                System.Collections.IList list2 = columnNames;
                for (int i1 = 0; i1 < list2.Count; i1++)
                {
                    DataColumn column = (DataColumn)list2[i1];
                    object item = row[column];

                    currentRow.Add(item.ToString());
                }

                rows.Add(string.Join(",", currentRow.ToArray()));
            }

            builder.Append(string.Join("\n", rows.ToArray()));

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "attachment;filename=myfilename.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Output.Write(builder.ToString());
            Response.Flush();
            Response.End();
            //-------------------------------------------------------------
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Student"))
            //    {
            //        using (SqlDataAdapter sda = new SqlDataAdapter())
            //        {
            //            cmd.Connection = con;
            //            sda.SelectCommand = cmd;
            //            using (DataTable dt = new DataTable())
            //            {
            //                sda.Fill(dt);

            //                //Build the CSV file data as a Comma separated string.
            //                string csv = string.Empty;

            //                foreach (DataColumn column in dt.Columns)
            //                {
            //                    //Add the Header row for CSV file.
            //                    csv += column.ColumnName + ',';
            //                }

            //                //Add new line.
            //                csv += "\r\n";

            //                foreach (DataRow row in dt.Rows)
            //                {
            //                    foreach (DataColumn column in dt.Columns)
            //                    {
            //                        //Add the Data rows.
            //                        csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
            //                    }

            //                    //Add new line.
            //                    csv += "\r\n";
            //                }

            //                //Download the CSV file.
            //                Response.Clear();
            //                Response.Buffer = true;
            //                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
            //                Response.Charset = "";
            //                Response.ContentType = "application/text";
            //                Response.Output.Write(csv);
            //                Response.Flush();
            //                Response.End();
            //            }
            //        }
            //    }
            //    }
            //}

            //protected void btnSaveFile_Click1(object sender, EventArgs e)
            //{

            //}

            //protected void EagleLifeDB_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
            //{

            //}
        }

        private object GetData(object dataList)
        {
            throw new NotImplementedException();
        }
    }
}
