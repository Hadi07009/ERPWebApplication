using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class DataManipulation
{
    public DataManipulation()
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
}

