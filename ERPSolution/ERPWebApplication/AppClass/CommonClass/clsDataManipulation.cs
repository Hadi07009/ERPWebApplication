using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;


public class clsDataManipulation
{
    public clsDataManipulation()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void StoredProcedureExecuteNonQuery(string connectionString, string storedProcedureCommandTest)
    {
        var myConnection = new SqlConnection(connectionString);
        try
        {
            myConnection.Open();
            new SqlCommand(storedProcedureCommandTest, myConnection).ExecuteNonQuery();

        }
        //catch (SqlException msgException)
        //{
        //    throw msgException;
        //}
        catch (Exception msgException)
        {
            throw msgException;
        }
        finally
        {
            myConnection.Close();
        }
    }
    public static DataTable GetData(string connectionString, string storedProcedureCommandTest)
    {
        var resultantDataTable = new DataTable();
        var myConnection = new SqlConnection(connectionString);
        myConnection.Open();

        try
        {
            var myCommand = myConnection.CreateCommand();
            myCommand.CommandText = storedProcedureCommandTest;
            myCommand.ExecuteNonQuery();
            var resultantDataAdapter = new SqlDataAdapter(myCommand);
            resultantDataAdapter.Fill(resultantDataTable);
            return resultantDataTable;
        }
        catch (SqlException msgException)
        {
            throw msgException;
        }
        catch (Exception msgException)
        {
            throw msgException;
        }
        finally
        {
            myConnection.Close();

        }

    }
    public int GetSingleValue(string connectionString, string sqlString)
    {
        try
        {
            int seqNo = 0;
            var storedProcedureComandText = @"" + sqlString + " ";
            var dtSeq = clsDataManipulation.GetData(connectionString, storedProcedureComandText);
            foreach (DataRow item in dtSeq.Rows)
            {
                seqNo = Convert.ToInt32(item.ItemArray[0].ToString());

            }
            return seqNo;


        }
        catch (Exception msgException)
        {

            throw msgException;
        }
    }

    public static bool DuplicateDataCheckfunction(string ConnectionString, string SQLStatementpar)
    {
        SqlConnection sqlConn = null;
        try
        {
            sqlConn = new SqlConnection(ConnectionString);
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(SQLStatementpar, sqlConn);
            DataTable dataTableObj = new DataTable();
            sqlDataAdapterObj.Fill(dataTableObj);

            if (dataTableObj.Rows.Count > 0)
                return true;
            else
                return false;
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

    }

    public static bool InsertQuery(string connectionString, string queryString)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(queryString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
        }
        catch (Exception msgException)
        {
            throw msgException;
        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }

        if (noOfRowsAffected > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool UpdateQuery(string connectionString, string queryString)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(queryString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
        }
        catch (SqlException msgException)
        {

            throw msgException;
        }
        catch (Exception msgException)
        {
            throw msgException;

        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }

        if (noOfRowsAffected > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool DeleteQuery(string connectionString, string queryString)
    {
        SqlConnection sqlConn = null;
        int noOfRowsAffected = 0;
        try
        {
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            SqlCommand sqlCom = new SqlCommand(queryString, sqlConn);
            noOfRowsAffected = sqlCom.ExecuteNonQuery();
        }
        catch (SqlException msgException)
        {
            throw msgException;

        }
        catch (Exception msgException)
        {
            throw msgException;

        }
        finally
        {
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }

        if (noOfRowsAffected > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int GetMaximumValueFromtableColumnAll(string connectionString, string tableName, string colName, string companyID, string branchID)
    {
        SqlConnection sqlConn = null;
        DataTable dataTableObj = null;
        int retValue = 0;
        try
        {
            string selectQuery = "select count(" + colName + ")+1  as " + colName + " from " + tableName + " " + "WHERE CompanyID = " + companyID + " AND BranchID = " + branchID + "";

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

    public static int GetMaximumValueFromtableColumn(string connectionString, string tableName, string colName, string companyID, string branchID, string dataUsed)
    {
        SqlConnection sqlConn = null;
        DataTable dataTableObj = null;
        int retValue = 0;
        try
        {
            string selectQuery = "select count(" + colName + ")+1  as " + colName + " from " + tableName + " " + "WHERE DataUsed = '" + dataUsed + "' AND CompanyID = " + companyID + " AND BranchID = " + branchID + "";

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

    public static int GetMaximumValueUsingSQL(string connectionString, string selectQuery)
    {
        SqlConnection sqlConn = null;
        DataTable dataTableObj = null;
        int retValue = 0;
        try
        {
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            dataTableObj = new DataTable();
            sqlDataAdapterObj.Fill(dataTableObj);

            if (dataTableObj.Rows.Count > 0)
                retValue = Convert.ToInt32(dataTableObj.Rows[0][0].ToString());

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

    public static string GetSingleValueFromtable(string ConnectionString, string TableName, string ColName, string WhereClause)
    {
        SqlConnection sqlConn = null;
        DataTable dataTableObj = null;
        string retValue = "";
        try
        {
            string selectQuery = "select top 1 " + ColName + " from " + TableName + " " + WhereClause;
            sqlConn = new SqlConnection(ConnectionString);
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
            dataTableObj = new DataTable();
            sqlDataAdapterObj.Fill(dataTableObj);

            if (dataTableObj.Rows.Count > 0)
                retValue = dataTableObj.Rows[0][ColName].ToString();

        }
        catch (SqlException msgException)
        {
            throw msgException;
        }
        catch (Exception msgException)
        {
            throw msgException;
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

    public static string GetSingleValueFromtable(SqlCommand myCommand, string TableName, string ColName, string WhereClause)
    {
        string retValue = "";
        DataTable dataTableObj = new DataTable();
        string selectQuery = "select top 1 " + ColName + " from " + TableName + " " + WhereClause;
        try
        {
            myCommand.CommandText = selectQuery;
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter();
            sqlDataAdapterObj.SelectCommand = myCommand;
            sqlDataAdapterObj.Fill(dataTableObj);
            if (dataTableObj.Rows.Count > 0)
                retValue = dataTableObj.Rows[0][ColName].ToString();
        }
        catch (Exception msgException)
        {
            throw msgException;

        }

        return retValue;
    }

    public static DataTable GetData(SqlCommand myCommand, string QueryStr)
    {
        DataTable dataTableObj = new DataTable();
        try
        {
            myCommand.CommandText = QueryStr;
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter();
            sqlDataAdapterObj.SelectCommand = myCommand;
            sqlDataAdapterObj.Fill(dataTableObj);
        }
        catch (SqlException sqlExceptionObject)
        {
            throw sqlExceptionObject;
        }
        catch (Exception exceptionObject)
        {
            throw exceptionObject;
        }
        return dataTableObj;
    }

    public static bool ExecuteCommand(SqlCommand myCommand, string QueryStr)
    {
        int noOfRowsAffected = 0;
        try
        {
            myCommand.CommandText = QueryStr;
            noOfRowsAffected = myCommand.ExecuteNonQuery();
        }
        catch (SqlException sqlExceptionObj)
        {
            throw sqlExceptionObj;
        }
        catch (Exception exceptionObj)
        {
            throw exceptionObj;
        }
        if (noOfRowsAffected > 0)
        {
            return true;

        }
        else
        {
            return false;
        }

    }

    public static string DeleteQueryWithMessage(string connectionString, string queryStr)
    {
        try
        {
            var sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            var sqlCom = new SqlCommand(queryStr, sqlConn);
            var noOfRowsAffected = sqlCom.ExecuteNonQuery();
            sqlConn.Close();
            return noOfRowsAffected.ToString(CultureInfo.InvariantCulture) + "  row(s) affected";
        }
        catch (SqlException msgException)
        {
            throw msgException;
        }
        catch (Exception msgException)
        {
            throw msgException;
        }
    }
    public static bool ExecuteSqlCommand(SqlCommand myCommand, string QueryStr)
    {
        int noOfRowsAffected = 0;
        try
        {
            myCommand.CommandText = QueryStr;
            noOfRowsAffected = myCommand.ExecuteNonQuery();
        }
        catch (Exception exceptionObj)
        {
            return false;
        }
        if (noOfRowsAffected > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

