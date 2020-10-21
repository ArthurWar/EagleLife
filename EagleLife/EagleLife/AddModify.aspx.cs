using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EagleLife
{

    public partial class AddModify : System.Web.UI.Page
    {
        bool isAdding = true;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSwitchList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void rdoSearchToggle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdoSearchToggle.SelectedIndex == 0)
            {
                lblRanges.Text = "ID Range: 1001-1999";
                txtUserEmail.Enabled = true;
                txtUserSchool.Enabled = false;
                txtUserGroup.Enabled = false;
                ClearTextboxes();
            }
            else if(rdoSearchToggle.SelectedIndex == 1)
            {
                lblRanges.Text = "ID Range: 2001-2999";
                txtUserEmail.Enabled = true;
                txtUserSchool.Enabled = true;
                txtUserGroup.Enabled = true;
                ClearTextboxes();
            }
            else
            {
                lblRanges.Text = "ID Range: 3001-3999";
                txtUserEmail.Enabled = false;
                txtUserSchool.Enabled = true;
                txtUserGroup.Enabled = false;
                ClearTextboxes();
            }
        }

        protected void txtUserID_TextChanged(object sender, EventArgs e)
        {
            ClearTextboxes();
        }

        private void ClearTextboxes()
        {
            txtUserName.Text = "";
            txtUserEmail.Text = "";
            txtUserPhone.Text = "";
            txtUserSchool.Text = "";
            txtUserGroup.Text = "";
            txtDivision.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text != "")
            {
                if (rdoSearchToggle.SelectedIndex == 0)
                {
                    string connStr = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    string SQLStr = "Select LID, LName, LPhone, LEmail, ScID From Leader Where LID = @LID";
                    SqlCommand comm = new SqlCommand(SQLStr, conn);
                    comm.Parameters.AddWithValue("LID", txtUserID.Text);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        if (reader.Read())
                        {
                            txtUserName.Text = reader["LName"].ToString();
                            txtUserEmail.Text = reader["LEmail"].ToString();
                            txtUserPhone.Text = reader["LPhone"].ToString();
                            txtDivision.Text = reader["ScID"].ToString();
                            lblSystemMessage.Text = "";
                        }
                        else
                        {
                            lblSystemMessage.Text = "User not found.";
                            ClearTextboxes();
                        }
                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        lblSystemMessage.Text = "Error: " + ex.Message;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else if (rdoSearchToggle.SelectedIndex == 1)
                {
                    string connStr = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    string SQLStr = "Select StID, StName, StEmail, StSchool, StGroupCode, StPhone, StLeader From Student Where StID = @StID";
                    SqlCommand comm = new SqlCommand(SQLStr, conn);
                    comm.Parameters.AddWithValue("StID", txtUserID.Text);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        if (reader.Read())
                        {
                            txtUserName.Text = reader["StName"].ToString();
                            txtUserEmail.Text = reader["StEmail"].ToString();
                            txtUserSchool.Text = reader["StSchool"].ToString();
                            txtUserGroup.Text = reader["StGroupCode"].ToString();
                            txtUserPhone.Text = reader["StPhone"].ToString();
                            txtDivision.Text = reader["StLeader"].ToString();
                            lblSystemMessage.Text = "";
                        }
                        else
                        {
                            lblSystemMessage.Text = "User not found.";
                            ClearTextboxes();
                        }
                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        lblSystemMessage.Text = "Error: " + ex.Message;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    string connStr = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    string SQLStr = "Select TID, TName, TSchool, TPhone, TDivisionCode From TeenMom Where TID = @TID";
                    SqlCommand comm = new SqlCommand(SQLStr, conn);
                    comm.Parameters.AddWithValue("TID", txtUserID.Text);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        if (reader.Read())
                        {
                            txtUserName.Text = reader["TName"].ToString();
                            txtUserSchool.Text = reader["TSchool"].ToString();
                            txtUserPhone.Text = reader["TPhone"].ToString();
                            txtDivision.Text = reader["TDivisionCode"].ToString();
                            lblSystemMessage.Text = "";
                        }
                        else
                        {
                            lblSystemMessage.Text = "User not found.";
                            ClearTextboxes();
                        }
                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        lblSystemMessage.Text = "Error: " + ex.Message;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                lblSystemMessage.Text = "Must enter a valid user ID.";
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if(isAdding == true)
            {
                if (txtUserID.Text != "")
                {
                    if (rdoSearchToggle.SelectedIndex == 0)
                    {
                        lblSystemMessage.Text = "";
                        string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                        SqlConnection connection = new SqlConnection(connectionString);
                        string insertStatement = "Insert Into Leader " +
                                "(LID, LName, LEmail, LPhone, ScID) " +
                                "Values (@LID, @LName, @LEmail, @LPhone, @ScID)";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                        int.TryParse(txtUserID.Text, out int intUserID);
                        insertCommand.Parameters.AddWithValue("@LID", intUserID);
                        insertCommand.Parameters.AddWithValue("@LName", txtUserName.Text);
                        insertCommand.Parameters.AddWithValue("@LEmail", txtUserEmail.Text);
                        insertCommand.Parameters.AddWithValue("@LPhone", txtUserSchool.Text);
                        int.TryParse(txtDivision.Text, out int intScID);
                        insertCommand.Parameters.AddWithValue("@ScID", intScID);

                        try
                        {
                            connection.Open();
                            int userCount = 0;
                            userCount = insertCommand.ExecuteNonQuery();

                            if (userCount == 1)
                            {
                                lblSystemMessage.ForeColor = System.Drawing.Color.Green;
                                lblSystemMessage.Text = "Leader has been added.";
                            }

                        }
                        catch (SqlException ex)
                        {
                            lblSystemMessage.ForeColor = System.Drawing.Color.Red;
                            lblSystemMessage.Text = "Error: " + ex.Message;
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                    else if (rdoSearchToggle.SelectedIndex == 1)
                    {
                        lblSystemMessage.Text = "";
                        string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                        SqlConnection connection = new SqlConnection(connectionString);
                        string insertStatement = "Insert Into Student " +
                                "(StID, StName, StEmail, StSchool, StGroupCode, StPhone, StLeader) " +
                                "Values (@StID, @StName, @StEmail, @StSchool, @StGroupCode, @StPhone, @StLeader)";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                        int.TryParse(txtUserID.Text, out int intUserID);
                        insertCommand.Parameters.AddWithValue("@StID", intUserID);
                        insertCommand.Parameters.AddWithValue("@StName", txtUserName.Text);
                        insertCommand.Parameters.AddWithValue("@StEmail", txtUserEmail.Text);
                        insertCommand.Parameters.AddWithValue("@StSchool", txtUserSchool.Text);
                        int.TryParse(txtUserGroup.Text, out int intGroupCode);
                        insertCommand.Parameters.AddWithValue("@StGroupCode", intGroupCode);
                        insertCommand.Parameters.AddWithValue("@StPhone", txtUserPhone.Text);
                        insertCommand.Parameters.AddWithValue("@StLeader", txtDivision.Text);

                        try
                        {
                            connection.Open();
                            int userCount = 0;
                            userCount = insertCommand.ExecuteNonQuery();

                            if (userCount == 1)
                            {
                                lblSystemMessage.ForeColor = System.Drawing.Color.Green;
                                lblSystemMessage.Text = "Student has been added.";
                            }

                        }
                        catch (SqlException ex)
                        {
                            lblSystemMessage.ForeColor = System.Drawing.Color.Red;
                            lblSystemMessage.Text = "Error: " + ex.Message;
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                    else
                    {
                        lblSystemMessage.Text = "";
                        string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                        SqlConnection connection = new SqlConnection(connectionString);
                        string insertStatement = "Insert Into TeenMom " +
                                "(TID, TName, TSchool, TPhone, TDivisionCode) " +
                                "Values (@TID, @TName, @TSchool, @TPhone, @TDivisionCode)";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                        int.TryParse(txtUserID.Text, out int intUserID);
                        insertCommand.Parameters.AddWithValue("@TID", intUserID);
                        insertCommand.Parameters.AddWithValue("@TName", txtUserName.Text);
                        insertCommand.Parameters.AddWithValue("@TSchool", txtUserSchool.Text);
                        insertCommand.Parameters.AddWithValue("@TPhone", txtUserPhone.Text);
                        int.TryParse(txtDivision.Text, out int intDivisionCode);
                        insertCommand.Parameters.AddWithValue("@TDivisonCode", intDivisionCode);

                        try
                        {
                            connection.Open();
                            int userCount = 0;
                            userCount = insertCommand.ExecuteNonQuery();

                            if (userCount == 1)
                            {
                                lblSystemMessage.ForeColor = System.Drawing.Color.Green;
                                lblSystemMessage.Text = "Teen Mom has been added.";
                            }

                        }
                        catch (SqlException ex)
                        {
                            lblSystemMessage.ForeColor = System.Drawing.Color.Red;
                            lblSystemMessage.Text = "Error: " + ex.Message;
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                else
                {
                    lblSystemMessage.ForeColor = System.Drawing.Color.Red;
                    lblSystemMessage.Text = "Please enter a valid ID.";
                }
            }
            else
            {
                if (txtUserID.Text != "")
                {
                    if(rdoSearchToggle.SelectedIndex == 0)
                    {
                        lblSystemMessage.Text = "";
                        string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                        SqlConnection connection = new SqlConnection(connectionString);
                        string updateStatement = "Update Leader " +
                                "Set LName = @LName, LEmail = @LEmail, LPhone = @LPhone, ScID = @ScID  " +
                                "Where LID = @LID";

                        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

                        int.TryParse(txtUserID.Text, out int intUserID);
                        updateCommand.Parameters.AddWithValue("@LID", intUserID);
                        updateCommand.Parameters.AddWithValue("@LName", txtUserName.Text);
                        updateCommand.Parameters.AddWithValue("@LEmail", txtUserEmail.Text);
                        updateCommand.Parameters.AddWithValue("@LPhone", txtUserPhone.Text);
                        int.TryParse(txtDivision.Text, out int intScID);
                        updateCommand.Parameters.AddWithValue("@ScID", intScID);

                        try
                        {
                            connection.Open();
                            int userCount = 0;
                            userCount = updateCommand.ExecuteNonQuery();
                            if (userCount == 1)
                            {
                                lblSystemMessage.Text = "Leader updated.";
                            }
                            else
                            {
                                lblSystemMessage.Text = "Leader does not exist.";
                            }
                        }
                        catch (SqlException ex)
                        {
                            lblSystemMessage.Text = "Error in updating leader.";
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                    else if (rdoSearchToggle.SelectedIndex == 1)
                    {
                        lblSystemMessage.Text = "";
                        string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                        SqlConnection connection = new SqlConnection(connectionString);
                        string updateStatement = "Update Student " +
                                "Set StID = @StID, StName = @StName, StEmail = @StEmail, StSchool = @StSchool, StGroupCode = @StGroupCode, StPhone = @StPhone, StLeader = @StLeader  " +
                                "Where StID = @StID";

                        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

                        int.TryParse(txtUserID.Text, out int intUserID);
                        updateCommand.Parameters.AddWithValue("@StID", intUserID);
                        updateCommand.Parameters.AddWithValue("@StName", txtUserName.Text);
                        updateCommand.Parameters.AddWithValue("@StEmail", txtUserEmail.Text);
                        updateCommand.Parameters.AddWithValue("@StSchool", txtUserEmail.Text);
                        int.TryParse(txtUserGroup.Text, out int intGroupCode);
                        updateCommand.Parameters.AddWithValue("@StGroupCode", txtUserEmail.Text);
                        updateCommand.Parameters.AddWithValue("@StPhone", txtUserPhone.Text);
                        updateCommand.Parameters.AddWithValue("@StLeader", txtDivision.Text);

                        try
                        {
                            connection.Open();
                            int userCount = 0;
                            userCount = updateCommand.ExecuteNonQuery();
                            if (userCount == 1)
                            {
                                lblSystemMessage.Text = "Student updated.";
                            }
                            else
                            {
                                lblSystemMessage.Text = "Student does not exist.";
                            }
                        }
                        catch (SqlException ex)
                        {
                            lblSystemMessage.Text = "Error in updating student.";
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                    else
                    {
                        lblSystemMessage.Text = "";
                        string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                        SqlConnection connection = new SqlConnection(connectionString);
                        string updateStatement = "Update TeenMom " +
                                "Set TID = @TID, TName = @TName, TSchool = @TSchool, TPhone = @TPhone, TDivisionCode = @TDivisionCode  " +
                                "Where TID = @TID";

                        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

                        int.TryParse(txtUserID.Text, out int intUserID);
                        updateCommand.Parameters.AddWithValue("@StID", intUserID);
                        updateCommand.Parameters.AddWithValue("@StName", txtUserName.Text);
                        updateCommand.Parameters.AddWithValue("@StSchool", txtUserEmail.Text);
                        updateCommand.Parameters.AddWithValue("@StPhone", txtUserPhone.Text);
                        int.TryParse(txtDivision.Text, out int intDivisionCode);
                        updateCommand.Parameters.AddWithValue("@TDivisionCode", intDivisionCode);

                        try
                        {
                            connection.Open();
                            int userCount = 0;
                            userCount = updateCommand.ExecuteNonQuery();
                            if (userCount == 1)
                            {
                                lblSystemMessage.Text = "Teen mom updated.";
                            }
                            else
                            {
                                lblSystemMessage.Text = "Teen mom does not exist.";
                            }
                        }
                        catch (SqlException ex)
                        {
                            lblSystemMessage.Text = "Error in updating teen mom.";
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                }
                else
                {
                    lblSystemMessage.Text = "Please enter a valid ID.";
                }
            }
        }

        protected void rdoAddModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoAddModify.SelectedIndex == 0)
                isAdding = true;
            else
                isAdding = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(rdoSearchToggle.SelectedIndex == 0)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);

                string deleteStatement = "Delete From Leader " +
                    "Where LID = @LID";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);

                int.TryParse(txtUserID.Text, out int intUserID);
                deleteCommand.Parameters.AddWithValue("@LID", intUserID);

                try
                {
                    connection.Open();
                    int userCount = 0;
                    userCount = deleteCommand.ExecuteNonQuery();

                    if (userCount == 1)
                    {
                        lblSystemMessage.Text = "Leader has been deleted";
                    }
                }
                catch (SqlException ex)
                {
                    lblSystemMessage.Text = "Error in deleting leader.";
                }
                finally
                {
                    connection.Close();
                }
            }
            else if(rdoSearchToggle.SelectedIndex == 1)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);

                string deleteStatement = "Delete From Student " +
                    "Where StID = @StID";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);

                int.TryParse(txtUserID.Text, out int intUserID);
                deleteCommand.Parameters.AddWithValue("@StID", intUserID);

                try
                {
                    connection.Open();
                    int userCount = 0;
                    userCount = deleteCommand.ExecuteNonQuery();

                    if (userCount == 1)
                    {
                        lblSystemMessage.Text = "Student has been deleted";
                    }
                }
                catch (SqlException ex)
                {
                    lblSystemMessage.Text = "Error in deleting leader.";
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EagleLifeDBConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);

                string deleteStatement = "Delete From TeenMom " +
                    "Where TID = @TID";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);

                int.TryParse(txtUserID.Text, out int intUserID);
                deleteCommand.Parameters.AddWithValue("@TID", intUserID);

                try
                {
                    connection.Open();
                    int userCount = 0;
                    userCount = deleteCommand.ExecuteNonQuery();

                    if (userCount == 1)
                    {
                        lblSystemMessage.Text = "Teen mom has been deleted";
                    }
                }
                catch (SqlException ex)
                {
                    lblSystemMessage.Text = "Error in deleting teen mom.";
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}