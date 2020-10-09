using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace EagleLife
{
    public partial class DataList : System.Web.UI.Page
    {
        private object dataList;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
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
            Response.ContentType = "text/csv";
            Response.AddHeader("Content-Disposition", "attachment;filename=myfilename.csv");
            Response.Write(builder.ToString());
            Response.End();
        }

        private object GetData(object dataList)
        {
            throw new NotImplementedException();
        }
    }
}