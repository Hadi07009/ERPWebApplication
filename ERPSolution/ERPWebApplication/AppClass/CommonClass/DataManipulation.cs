using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class DataManipulation
{
    public int DataManipulationValue { get; set; }
    public DataManipulation() { }

    //    public static DataTable GetData(string ConnectionString, string QueryStr)
    //    {
    //        SqlConnection sqlConn = null;
    //        DataTable dataTableObj = null;
    //        try
    //        {
    //            string selectQuery = QueryStr;
    //            sqlConn = new SqlConnection(ConnectionString);
    //            sqlConn.Open();
    //            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
    //            dataTableObj = new DataTable();
    //            sqlDataAdapterObj.Fill(dataTableObj);

    //        }
    //        catch (SqlException sqlExceptionObject)
    //        {
    //            TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObject.Message);
    //        }
    //        catch (Exception exceptionObject)
    //        {
    //            TopMostMessageBox.TopMostMessageBox.Show(exceptionObject.Message);
    //        }
    //        finally
    //        {
    //            if (sqlConn.State == System.Data.ConnectionState.Open)
    //            {
    //                sqlConn.Close();
    //            }
    //        }
    //        return dataTableObj;
    //    }

    //    public static DataTable GetData(SqlCommand myCommand,string QueryStr)
    //    {
    //        DataTable dataTableObj = new DataTable();
    //        try
    //        {
    //            myCommand.CommandText= QueryStr;
    //            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter();
    //            sqlDataAdapterObj.SelectCommand = myCommand;
    //            sqlDataAdapterObj.Fill(dataTableObj);
    //        }
    //        catch (SqlException sqlExceptionObject)
    //        {
    //            TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObject.Message);
    //        }
    //        catch (Exception exceptionObject)
    //        {
    //            TopMostMessageBox.TopMostMessageBox.Show(exceptionObject.Message);
    //        }
    //        return dataTableObj;
    //    }

    //    public static string GetSingleValueFromtable(string ConnectionString, string TableName,string ColName, string WhereClause)
    //    {
    //        SqlConnection sqlConn = null;
    //        DataTable dataTableObj = null;
    //        string retValue="";

    //            string selectQuery = "select top 1 "+ ColName +" from "+ TableName +" " + WhereClause;
    //            sqlConn = new SqlConnection(ConnectionString);
    //            sqlConn.Open();
    //            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
    //            dataTableObj = new DataTable();
    //            sqlDataAdapterObj.Fill(dataTableObj);

    //            if (dataTableObj.Rows.Count > 0)
    //                retValue = dataTableObj.Rows[0][ColName].ToString();


    //        return retValue;
    //    }

    //public static string GetSingleValueFromtable(SqlCommand myCommand, string TableName, string ColName, string WhereClause)
    //    {

    //        string retValue = "";
    //        DataTable dataTableObj = new DataTable();
    //        string selectQuery = "select top 1 " + ColName + " from " + TableName + " " + WhereClause;


    //        try
    //        {
    //            myCommand.CommandText = selectQuery;
    //            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter();
    //            sqlDataAdapterObj.SelectCommand = myCommand;
    //            sqlDataAdapterObj.Fill(dataTableObj);
    //            if (dataTableObj.Rows.Count > 0)
    //                retValue = dataTableObj.Rows[0][ColName].ToString();
    //        }
    //        catch (Exception Ex)
    //        {
    //            TopMostMessageBox.TopMostMessageBox.Show(Ex.Message); 
    //        }

    //        return retValue;
    //    }

    // Do it first
    //---------------------
    public static int GetMaximumValueFromtableColumn(string connectionString, string tableName, string colName, string companyID, string branchID)
    {
        SqlConnection sqlConn = null;
        DataTable dataTableObj = null;
        int retValue = 0;
        try
        {
            string selectQuery = "select isnull( max(" + colName + "),0)+1  as " + colName + " from " + tableName + " " + "WHERE CompanyID = " + companyID + " AND BranchID = " + branchID + " ";
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            dataTableObj = new DataTable();
            sqlDataAdapterObj.Fill(dataTableObj);

            if (dataTableObj.Rows.Count > 0)
                retValue = Convert.ToInt32(dataTableObj.Rows[0][colName].ToString());

        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }
        return retValue;
    }

    //public static string GetTotalValueFromtableColumn(string ConString, string TableName, string ColName, string newcolumn, string WhereClause)
    //{

    //    string ConnectionString = ConString;

    //    SqlConnection sqlConn = null;
    //    DataTable dataTableObj = null;
    //    string retValue = "";
    //    try
    //    {
    //        string selectQuery = "select Count(" + ColName + ") as " + newcolumn + " from " + TableName + " " + WhereClause;
    //        sqlConn = new SqlConnection(ConnectionString);
    //        sqlConn.Open();
    //        SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);

    //        dataTableObj = new DataTable();
    //        sqlDataAdapterObj.Fill(dataTableObj);

    //        if (dataTableObj.Rows.Count > 0)
    //            retValue = dataTableObj.Rows[0][newcolumn].ToString();

    //    }
    //    catch (SqlException sqlExceptionObject)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObject.ToString(), "SQL Exception");
    //    }
    //    catch (Exception exceptionObject)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(exceptionObject.ToString(), "SQL Exception");
    //    }
    //    finally
    //    {
    //        if (sqlConn.State == System.Data.ConnectionState.Open)
    //        {
    //            sqlConn.Close();
    //        }
    //    }
    //    return retValue;




    //}




    //public static string GetTotalValueFromtableColumn(SqlCommand myCommand, string TableName, string ColName, string newcolumn, string WhereClause)
    //{
    //    DataTable dataTableObj = new DataTable();
    //    string retValue = "";
    //    string QueryStr = string.Empty;

    //    try
    //    {
    //        QueryStr = "select Count(" + ColName + ") as " + newcolumn + " from " + TableName + " " + WhereClause;
    //        myCommand.CommandText = QueryStr;

    //        SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter();
    //        sqlDataAdapterObj.SelectCommand = myCommand;
    //        sqlDataAdapterObj.Fill(dataTableObj);

    //        if (dataTableObj.Rows.Count > 0)
    //            retValue = dataTableObj.Rows[0][newcolumn].ToString();

    //    }
    //    catch (SqlException sqlExceptionObj)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObj.Message);

    //    }
    //    catch (Exception exceptionObj)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(exceptionObj.Message);

    //    }

    //    return retValue;
    //}


    //public static bool InsertQuery(string ConnectionString, string QueryStr)
    //{
    //    SqlConnection sqlConn = null;
    //    int noOfRowsAffected = 0;
    //    try
    //    {   
    //        sqlConn = new SqlConnection(ConnectionString);
    //        sqlConn.Open();
    //        SqlCommand sqlCom = new SqlCommand(QueryStr, sqlConn);
    //        noOfRowsAffected = sqlCom.ExecuteNonQuery();
    //        TopMostMessageBox.TopMostMessageBox.Show("Data Saved Successfully");
    //    }
    //    catch (SqlException sqlExceptionObj)
    //    {
    //        if (sqlExceptionObj.Number == 2627)     //Violation of primary key Msg no =2627
    //        {
    //            TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObj.Message);
    //        }
    //        else
    //        {
    //            TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObj.Message);
    //        }
    //    }
    //    catch (Exception exceptionObj)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(exceptionObj.Message);
    //    }
    //    finally
    //    {
    //        if (sqlConn.State == System.Data.ConnectionState.Open)
    //        {
    //            sqlConn.Close();
    //        }
    //    }

    //    if (noOfRowsAffected > 0)
    //    {
    //        return true;

    //    }
    //    else
    //    {
    //        return false;
    //    }



    //}
    //public static bool InsertQuery(SqlCommand myCommand, string QueryStr)
    //{           
    //    int noOfRowsAffected = 0;
    //    try
    //    {              
    //        myCommand.CommandText = QueryStr;
    //        noOfRowsAffected = myCommand.ExecuteNonQuery();               
    //    }
    //    catch (SqlException sqlExceptionObj)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObj.Message);
    //        return false;
    //    }
    //    catch (Exception exceptionObj)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(exceptionObj.Message);
    //        return false;
    //    }            
    //    if (noOfRowsAffected > 0)
    //    {
    //        return true;

    //    }
    //    else
    //    {
    //        return false;
    //    }

    //}


    //public static bool ExecuteCommand(SqlCommand myCommand, string QueryStr)
    //{
    //    int noOfRowsAffected = 0;
    //    //try
    //    //{
    //        myCommand.CommandText = QueryStr;
    //        noOfRowsAffected = myCommand.ExecuteNonQuery();
    //    //}
    //    //catch (SqlException sqlExceptionObj)
    //    //{
    //    //    TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObj.Message);
    //    //    return false;
    //    //}
    //    //catch (Exception exceptionObj)
    //    //{
    //    //    TopMostMessageBox.TopMostMessageBox.Show(exceptionObj.Message);
    //    //    return false;
    //    //}
    //    if (noOfRowsAffected > 0)
    //    {
    //        return true;

    //    }
    //    else
    //    {
    //        return false;
    //    }

    //}

    //public static bool UpdateQuery(string ConnectionString, string QueryStr)
    //{
    //    SqlConnection sqlConn = null;
    //    int noOfRowsAffected = 0;

    //    try
    //    {
    //        sqlConn = new SqlConnection(ConnectionString);
    //        sqlConn.Open();
    //        SqlCommand sqlCom = new SqlCommand(QueryStr, sqlConn);
    //        noOfRowsAffected = sqlCom.ExecuteNonQuery();
    //        TopMostMessageBox.TopMostMessageBox.Show("Data Updated Successfully");

    //    }
    //    catch (SqlException sqlExceptionObject)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObject.Message);
    //    }
    //    catch (Exception exceptionObj)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(exceptionObj.Message);
    //    }
    //    finally
    //    {
    //        if (sqlConn.State == System.Data.ConnectionState.Open)
    //        {
    //            sqlConn.Close();
    //        }
    //    }

    //    if (noOfRowsAffected > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    //public static bool UpdateQuery(SqlCommand myCommand, string QueryStr)
    //{           
    //    int noOfRowsAffected = 0;
    //    try
    //    {                
    //        myCommand.CommandText = QueryStr;
    //        noOfRowsAffected = myCommand.ExecuteNonQuery();
    //        TopMostMessageBox.TopMostMessageBox.Show("Data Updated Successfully");

    //    }
    //    catch (SqlException sqlExceptionObject)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObject.Message);
    //        return false;
    //    }
    //    catch (Exception exceptionObj)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(exceptionObj.Message);
    //        return false;
    //    }          

    //    if (noOfRowsAffected > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}


    //public static bool DeleteQuery(string ConnectionString, string QueryStr)
    //{
    //    SqlConnection sqlConn = null;
    //    int noOfRowsAffected = 0;

    //    try
    //    {
    //        sqlConn = new SqlConnection(ConnectionString);
    //        sqlConn.Open();
    //        SqlCommand sqlCom = new SqlCommand(QueryStr, sqlConn);
    //        noOfRowsAffected = sqlCom.ExecuteNonQuery();
    //        //TopMostMessageBox.TopMostMessageBox.Show("Data deleted successfully");

    //    }
    //    catch (SqlException sqlExceptionObject)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(sqlExceptionObject.Message);
    //    }
    //    catch (Exception exceptionObj)
    //    {
    //        TopMostMessageBox.TopMostMessageBox.Show(exceptionObj.Message);
    //    }
    //    finally
    //    {
    //        if (sqlConn.State == System.Data.ConnectionState.Open)
    //        {
    //            sqlConn.Close();
    //        }
    //    }

    //    if (noOfRowsAffected > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //public static bool ExecuteQuery(string ConnectionString, string QueryStr)
    //{
    //    SqlConnection sqlConn = null;
    //    int noOfRowsAffected = 0;
    //    try
    //    {
    //        sqlConn = new SqlConnection(ConnectionString);
    //        sqlConn.Open();
    //        SqlCommand sqlCom = new SqlCommand(QueryStr, sqlConn);
    //        noOfRowsAffected = sqlCom.ExecuteNonQuery();
    //        return true;
    //    }
    //    catch (SqlException sqlExceptionObj)
    //    {
    //        if (sqlExceptionObj.Number == 2627)     //Violation of primary key Msg no =2627
    //        {
    //           // System.Windows.Forms.MessageBox.Show(sqlExceptionObj.Message, StringProcess.messageHead); 
    //            return false;
    //        }
    //        else
    //        {
    //           // System.Windows.Forms.MessageBox.Show(sqlExceptionObj.Message, StringProcess.messageHead); 
    //            return false;
    //        }
    //    }
    //    catch (Exception exceptionObj)
    //    {
    //        //System.Windows.Forms.MessageBox.Show(exceptionObj.Message, StringProcess.messageHead); 
    //        return false;
    //    }
    //    finally
    //    {
    //        if (sqlConn.State == System.Data.ConnectionState.Open)
    //        {
    //            sqlConn.Close();
    //        }
    //    }
    //}

    //public static bool ExecuteQuery(SqlCommand myCommand,string QueryStr)
    //{
    //    try
    //    {
    //        myCommand.CommandText = QueryStr;
    //        myCommand.ExecuteNonQuery();
    //        return true;
    //    }
    //    catch (SqlException sqlExceptionObj)
    //    {
    //        if (sqlExceptionObj.Number == 2627)     //Violation of primary key Msg no =2627
    //        {
    //            //System.Windows.Forms.MessageBox.Show(sqlExceptionObj.Message, StringProcess.messageHead); 
    //            return false;
    //        }
    //        else
    //        {
    //            //System.Windows.Forms.MessageBox.Show(sqlExceptionObj.Message, StringProcess.messageHead); 
    //            return false;
    //        }
    //    }
    //    catch (Exception exceptionObj)
    //    {
    //       // System.Windows.Forms.MessageBox.Show(exceptionObj.Message, StringProcess.messageHead); 
    //        return false;
    //    }
    //}


    //public static int GetupdateSequence(string ConnectionString, string TableName, string Seqcolname, string whereCluse, string wherecluse2)
    //{
    //    SqlConnection sqlConn = null;
    //    DataTable dataTableObj = null;
    //    int retValue = 0;
    //    int setseqno = 0;
    //    string selectQuery = "";
    //    try
    //    {

    //        if (wherecluse2 != "")
    //        {
    //            selectQuery = "select isnull(MAX(" + Seqcolname + "),0) as " + Seqcolname + " from " + TableName + "  " + whereCluse + "" + wherecluse2;
    //        }
    //        else
    //        {
    //            selectQuery = "select isnull(MAX(" + Seqcolname + "),0) as " + Seqcolname + " from " + TableName + " " + whereCluse; 
    //        }
    //        sqlConn = new SqlConnection(ConnectionString);
    //        sqlConn.Open();
    //        SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
    //        dataTableObj = new DataTable();
    //        sqlDataAdapterObj.Fill(dataTableObj);

    //        if (dataTableObj.Rows.Count > 0)
    //        {
    //            retValue = Convert.ToInt32(dataTableObj.Rows[0][Seqcolname].ToString());
    //        }

    //        if (retValue > 0)
    //        {
    //            retValue = retValue + 1;

    //            string QueryStr = "update " + TableName + " set " + Seqcolname + "=" + Seqcolname + "+1 where " + Seqcolname + ">=" + retValue;
    //            SqlCommand sqlCom = new SqlCommand(QueryStr, sqlConn);
    //            sqlCom.ExecuteNonQuery();
    //        }
    //        else
    //        {
    //            retValue = GetupdateSequence(ConnectionString, TableName, Seqcolname, whereCluse, "");                     
    //        }               

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;                
    //    }
    //    finally
    //    {
    //        if (sqlConn.State == System.Data.ConnectionState.Open)
    //        {
    //            sqlConn.Close();
    //        }
    //    }
    //    return retValue;
    //}



}

