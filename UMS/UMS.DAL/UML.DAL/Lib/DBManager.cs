using System;
using System.IO;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

public class DBManager
{
    public static string connStr;
    public static string[] QueryCollection = new string[1];
    public DBManager()
    {
    }
    public static string connectionString
    {
        get
        {
            return connStr;
        }
        set
        {
            connStr = value;
        }
    }
    public static SqlConnection getConnection(string connString)
    {
        try
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            return conn;
        }
        catch (Exception ex)
        {
        }
        return null;
    }
    public DataTable GetDataTableUsingProc(string p_strProName, string p_actionName)
    {
        SqlConnection myconn = getConnection();
        DataTable table = new DataTable();
        using (myconn)
        using (var cmd = new SqlCommand(p_strProName, myconn))
        using (var da = new SqlDataAdapter(cmd))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", p_actionName);
            da.Fill(table);
        }
        closeConnection(myconn);
        return table;
    }


    public void AddQuery(string p_strProName, string p_actionName, string firstname, string lastname, string username, string password, Int32 age, string dateofbirth, Int16 preferredlanguage, Int16 passwordexpires)
    {

        SqlConnection myconn = getConnection();
        SqlCommand mycmd = new SqlCommand(p_strProName);
        mycmd.Connection = myconn;
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Parameters.AddWithValue("@Action", p_actionName);
        mycmd.Parameters.AddWithValue("@FirstName", firstname);
        mycmd.Parameters.AddWithValue("@LastName", lastname == null ? "" : lastname);
        mycmd.Parameters.AddWithValue("@UserName", username);
        mycmd.Parameters.AddWithValue("@Password", password);
        mycmd.Parameters.AddWithValue("@Age", age);
        mycmd.Parameters.AddWithValue("@Dateofbirth", dateofbirth);
        mycmd.Parameters.AddWithValue("@Preferredlanguage", preferredlanguage);
        mycmd.Parameters.AddWithValue("@Passwordexpires", passwordexpires);
        mycmd.ExecuteNonQuery();
        closeConnection(myconn);
    }

    public void UpdateQuery(string p_strProName, string p_actionName, int p_userid, string firstname, string lastname, string username, string password, Int32 age, string dateofbirth, Int16 preferredlanguage, Int16 passwordexpires)
    {

        SqlConnection myconn = getConnection();
        SqlCommand mycmd = new SqlCommand(p_strProName);
        mycmd.Connection = myconn;
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Parameters.AddWithValue("@Action", p_actionName);
        mycmd.Parameters.AddWithValue("@UserID", p_userid);
        mycmd.Parameters.AddWithValue("@FirstName", firstname);
        mycmd.Parameters.AddWithValue("@LastName", lastname == null ? "" : lastname);
        mycmd.Parameters.AddWithValue("@UserName", username);
        mycmd.Parameters.AddWithValue("@Password", password);
        mycmd.Parameters.AddWithValue("@Age", age);
        mycmd.Parameters.AddWithValue("@Dateofbirth", dateofbirth);
        mycmd.Parameters.AddWithValue("@Preferredlanguage", preferredlanguage);
        mycmd.Parameters.AddWithValue("@Passwordexpires", passwordexpires);
        mycmd.ExecuteNonQuery();
        closeConnection(myconn);
    }


    public DataTable GetTableUsingID(string p_strProName, string p_actionName, int userid)
    {
        SqlConnection myconn = getConnection();
        DataTable table = new DataTable();
        using (myconn)
        using (var cmd = new SqlCommand(p_strProName, myconn))
        using (var da = new SqlDataAdapter(cmd))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", p_actionName);
            cmd.Parameters.AddWithValue("@UserID", userid);
            da.Fill(table);
        }
        closeConnection(myconn);
        return table;

    }


    public void DeleteQuery(string p_strProName, string p_actionName, int userid)
    {
        SqlConnection myconn = getConnection();
        SqlCommand mycmd = new SqlCommand(p_strProName);
        mycmd.Connection = myconn;
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Parameters.AddWithValue("@Action", p_actionName);
        mycmd.Parameters.AddWithValue("@UserID", userid);
        mycmd.ExecuteNonQuery();
        closeConnection(myconn);
    }

    public static DataTable GetDataTableFromQuery(string strQuery)
    {
        SqlConnection myconn = getConnection();
        SqlCommand mycmd = new SqlCommand();
        mycmd.Connection = myconn;
        mycmd.CommandType = CommandType.Text;
        mycmd.CommandText = strQuery;
        SqlDataAdapter result = new SqlDataAdapter(mycmd);
        //query_found_rows = "select sql_calc_found_rows from
        DataSet mydataset = new DataSet();
        result.Fill(mydataset);
        closeConnection(myconn);
        return mydataset.Tables[0]; // make a table
    }
    public static DataSet GetDataSet(string strQuery)
    {
        SqlConnection myconn = getConnection();
        SqlCommand mycmd = new SqlCommand();
        mycmd.Connection = myconn;
        mycmd.CommandType = CommandType.Text;
        mycmd.CommandText = strQuery;
        SqlDataAdapter result = new SqlDataAdapter(mycmd);
        DataSet mydataset = new DataSet();
        result.Fill(mydataset, "DTCum");
        closeConnection(myconn);
        return mydataset;
    }
    public static SqlConnection getConnection()
    {
        try
        {
            string connstr = ConfigurationSettings.AppSettings.Get("UMConnectionString").ToString();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            return conn;
        }
        catch (Exception ex)
        {
        }
        return null;
    }
    public static void closeConnection(SqlConnection conn)
    {
        try
        {
            conn.Close();
        }
        catch (Exception ex)
        {
        }
    }
    public static long RunQuery(string query, bool getLastId)
    {
        SqlConnection MyConn = null;
        SqlTransaction tran = null;
        long lastid = 0;
        try
        {
            MyConn = DBManager.getConnection();
            tran = MyConn.BeginTransaction();
            SqlCommand MyCmd = new SqlCommand(query, MyConn, tran);
            MyCmd.ExecuteNonQuery();
            if (getLastId)
            {
                MyCmd.CommandText = "select LAST_INSERT_ID()";
                lastid = Convert.ToInt64(MyCmd.ExecuteScalar());
            }
            tran.Commit();
            return lastid;
        }
        catch (Exception ex)
        {
            if (tran != null)
                tran.Rollback();
            return -1;
        }
        finally
        {
            if (MyConn != null)
                DBManager.closeConnection(MyConn);
        }
    }
}
