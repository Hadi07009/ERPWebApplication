using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public class CheckDuplicateValue
{
    public CheckDuplicateValue()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static DataTable DuplicateCheckIntoDatabase(string coloumnName, string tableName,string textValue)
    {
        String connectionString = System.Configuration.ConfigurationManager.AppSettings["UbasysConnectionString"].ToString();
         DataSet ds = new DataSet();
         SqlConnection connection = new SqlConnection(connectionString);
        string queryString = queryString = "Select " + coloumnName + " from " + tableName + " " + "where" + " " + coloumnName + "=" + "'" + textValue + "'"; 
        SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
        adapter.Fill(ds);
        return ds.Tables[0];
    }
    public static DataTable DuplicateCheckForUpdate(string coloumnName,string coloumnName2, string tableName, string textValue)
    {
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        DataSet ds = new DataSet();
        SqlConnection connection = new SqlConnection(connectionString);
        string queryString = queryString = "Select " + coloumnName + "," + coloumnName2 + " from " + tableName + " " + "where" + " " + coloumnName + "=" + "'" + textValue + "'"; 
  

        SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
        adapter.Fill(ds);
        return ds.Tables[0];
    }
    public static DataTable DuplicateCheckForUpdateNew(string coloumnName,string coloumnName2,string coloumnName3, string tableName, string textValue,string processval)
    {
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        DataSet ds = new DataSet();
        SqlConnection connection = new SqlConnection(connectionString);
        string queryString ="select Action,ActionTypeId,ProcessId from ProcessActionType where ProcessId='" + processval + "' and Action='" + textValue + "'"; 
      
        SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
        adapter.Fill(ds);
        return ds.Tables[0];
    }
}
