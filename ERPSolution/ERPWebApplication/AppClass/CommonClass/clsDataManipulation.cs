using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

}

