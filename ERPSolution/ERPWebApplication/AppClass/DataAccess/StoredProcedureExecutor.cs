using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StoredProcedureExecutor
/// </summary>
public class StoredProcedureExecutor
{
	public StoredProcedureExecutor()
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
            //myConnection.Close();
        }
        catch (Exception ex)
        {
            //throw ex;
        }
        finally
        {
            myConnection.Close(); 
        }
    }
    public static DataTable StoredProcedureExecuteReader(string connectionString, string storedProcedureCommandTest)
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
        catch(Exception e)
        {
        }
        finally
        {
            myConnection.Close(); 
        }

        return resultantDataTable;
    }
}

