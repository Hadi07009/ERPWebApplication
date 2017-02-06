using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class Process
{
    public Process()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string SaveProcessDescription(List<ProcessHeader> lvphdrlst, SqlCommand myCommand)
    {
        string retValue = "";
        try
        {
            foreach (ProcessHeader ofproc in lvphdrlst)
            {
                myCommand.CommandText = "exec [spProcessInsertProcessDescription] '" + ofproc.ProcessId + "','" + ofproc.ProcessDescription + "','" + ofproc.Status + "','" + ofproc.Tag + "'";
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();
            }
            retValue = "Data Saved Successful";
            return retValue;
        }
        catch (Exception)
        {
            return retValue;
        }
    }
    public string SaveProcessFlowDefinition(List<ProcessHeader> lvphdrlst, SqlCommand myCommand)
    {
        string retValue = "";
        try
        {
            foreach (ProcessHeader ofproc in lvphdrlst)
            {
                myCommand.CommandText = "exec [spProcessInsertProcessFlowDefinition] '" + ofproc.ProcessId + "'," + ofproc.CategoryId + "," + ofproc.ProcessFlowId + ",'" + ofproc.FlowDescription + "'" + ",'" + ofproc.Tag + "'";
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();
            }
            retValue = "Data Saved Successful";
            return retValue;
        }
        catch (Exception)
        {
            return retValue;
        }
    }
    public string SaveProcessLevelDescription(List<ProcessHeader> lvphdrlst, SqlCommand myCommand)
    {
        string retValue = "";
        try
        {
            foreach (ProcessHeader ofproc in lvphdrlst)
            {
                myCommand.CommandText = "exec [spProcessInsertProcessLevelDescription] '" + ofproc.ProcessId + "','" + ofproc.LevelDescription + "'," + ofproc.ProcessLevelId + ",'" + ofproc.Tag + "'";
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();
            }
            retValue = "Data Saved Successful";
            return retValue;
        }
        catch (Exception)
        {
            return retValue;
        }
    }
    public string SaveProcessActionType(List<ProcessHeader> lvphdrlst, SqlCommand myCommand)
    {
        string retValue = "";
        try
        {
            foreach (ProcessHeader ofproc in lvphdrlst)
            {
                myCommand.CommandText = "exec [spProcessInsertProcessActionType] '" + ofproc.ProcessId + "','" + ofproc.Action + "'," + ofproc.ActionTypeId + ",'" + ofproc.Tag + "'";
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();
            }
            retValue = "Data Saved Successful";
            return retValue;
        }
        catch (Exception)
        {
            return retValue;
        }
    }
    public string SaveProcessHeaderConfigurationbyDepartment(List<ProcessHeader> lvphdrlst, SqlCommand myCommand,string flag)
    {
        string retValue = "";
        try
        {
            foreach (ProcessHeader ofproc in lvphdrlst)
            {
                myCommand.CommandText = "exec [spProcessInsertProcessHeaderConfigurationbyDepartment] '" + ofproc.ReferenceNo + "','" + ofproc.ProcessId + "'," + ofproc.ProcessFlowId + ",'" + ofproc.DepartmentId + "','" + flag + "','" + ofproc.ProcessName + "'";
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();

                //myCommand.CommandText = "spProcessInsertProcessHeaderConfigurationbyDepartment";
                //myCommand.CommandType = CommandType.StoredProcedure;
                //myCommand.Parameters.Add(new SqlParameter("@ReferenceNo", SqlDbType.VarChar, 25)).Value = ofproc.ReferenceNo;
                //myCommand.Parameters.Add(new SqlParameter("@ProcessId", SqlDbType.VarChar, 25)).Value = ofproc.ProcessId;
                //myCommand.Parameters.Add(new SqlParameter("@ProcessFlowId", SqlDbType.Int)).Value = ofproc.ProcessFlowId;
                //myCommand.Parameters.Add(new SqlParameter("@DepartmentId", SqlDbType.VarChar, 25)).Value = ofproc.DepartmentId;
                //myCommand.Parameters.Add(new SqlParameter("@flag", SqlDbType.VarChar, 1)).Value = flag;                
                //myCommand.CommandTimeout = 600;
                //myCommand.ExecuteNonQuery();
            }
            retValue = "Data Saved Successful";
            return retValue;
        }
        catch (Exception)
        {
            return retValue;
        }
    }
    public string SaveProcessDetailsConfigurationbyDepartment(List<ProcessHeader> lvphdrlst, SqlCommand myCommand)
    {
        string retValue = "";
        try
        {
            foreach (ProcessHeader ofproc in lvphdrlst)
            {
                myCommand.CommandText = "exec [spProcessInsertProcessDetailsConfigurationbyDepartment] '" + ofproc.ReferenceNo + "'," + ofproc.ProcessLevelId + ",'" + ofproc.AccessId + "','" + ofproc.SubAccessId + "','" + ofproc.AccessPermissionTypeID + "','" + ofproc.SubAccessPermissionTypeID + "','" + ofproc.SuperUserID + "','" + ofproc.MonitoringId + "'";
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();
            }
            retValue = "Data Saved Successful";
            return retValue;
        }
        catch (Exception)
        {
            return retValue;
        }
    }
    public string SaveProcessFlowConfigurationbyEmployee(List<ProcessHeader> lvphdrlst, SqlCommand myCommand)
    {
        string retValue = "";
        try
        {
            foreach (ProcessHeader ofproc in lvphdrlst)
            {
                myCommand.CommandText = "exec [spProcessInsertProcessFlowConfigurationbyEmployee] '" + ofproc.ReferenceNo + "','" + ofproc.ApplicantID  + "'," + ofproc.ProcessLevelId + ",'" + ofproc.AccessId + "','" + ofproc.SubAccessId + "','" + ofproc.AccessPermissionTypeID + "','" + ofproc.SubAccessPermissionTypeID + "','" + ofproc.SuperUserID + "','" + ofproc.MonitoringId + "'";
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();
            }
            retValue = "Data Saved Successful";
            return retValue;
        }
        catch (Exception)
        {
            return retValue;
        }
    }
    public DataTable GetDataFromProcessDetailsConfigurationbyDepartment(List<ProcessHeader> lvphdrlst, SqlCommand myCommand)
    {
        DataTable dt = new DataTable();
        try
        {
            foreach (ProcessHeader ofproc in lvphdrlst)
            {
                myCommand.CommandText = "exec [spProcessGetDataFromProcessDetailsConfigurationbyDepartment] '" + ofproc.ReferenceNo + "'";
                myCommand.CommandTimeout = 600;
                myCommand.ExecuteNonQuery();
            }
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            da.Fill(dt);
            return dt;
        }
        catch (Exception)
        {
            return dt;
        }
    }
    public string GetReferenceNoFromProcessHeaderConfigurationbyDepartment(SqlCommand myCommand)//(SqlCommand myCommand)
    {
        try
        {
            DataTable dt = new DataTable();
            string dtValue;
            myCommand.CommandText = "spProcessGetReferenceNoFromProcessHeaderConfigurationbyDepartment";
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add(new SqlParameter("@outputStr", SqlDbType.VarChar,25));
            myCommand.Parameters["@outputStr"].Direction = ParameterDirection.Output;
            myCommand.CommandTimeout = 600;
            myCommand.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            da.Fill(dt);
            dtValue = dt.Rows[0][0].ToString();
            return dtValue;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public string CheckSandwichLeave(string ConnectionStr, string Empid)
    {
        try
        {
            SqlConnection myConnection = new SqlConnection(ConnectionStr);
            myConnection.Open();
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.Connection = myConnection;

            DataTable dt = new DataTable();
            string dtValue;
            myCommand.CommandText = "spCheckSandwichLeave";
            myCommand.CommandType = CommandType.StoredProcedure;          
            myCommand.Parameters.Add(new SqlParameter("@empid", SqlDbType.VarChar, 50)).Value = Empid.ToString();
            myCommand.Parameters.Add(new SqlParameter("@outputStr", SqlDbType.VarChar, 25));
            myCommand.Parameters["@outputStr"].Direction = ParameterDirection.Output;
            myCommand.CommandTimeout = 600;
            myCommand.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            da.Fill(dt);
            dtValue = dt.Rows[0][0].ToString();
            return dtValue;

        }
        catch (Exception)
        {
            throw;
        }
    }


    public static DataTable Run(string SqlString)
    {
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        DataSet ds = new DataSet();
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter adapter = new SqlDataAdapter(SqlString, connection);
        adapter.Fill(ds);
        if (ds.Tables[0].Rows.Count != 0)
        {
            return ds.Tables[0];
        }
        else return ds.Tables[0]; 
    }
    public static int Run(string SqlString, string ConnectionString)
    {
        int ProposedValue = 0;
        SqlConnection con = null;
        try
        {
            con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(SqlString, con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ProposedValue = dr.GetInt32(0);
            }

            dr.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (con != null)
                con.Close();
            con = null;
        }

        return ProposedValue;
       
    }
    public static bool GetRateConfigurationStatus(string ConnectionStr, string processType, string employeeCode)
    {
        string storedProcedureCommandTest = "exec [spProcessGetConfigurationStatus] '" + processType + "','" + employeeCode + "'";
        DataTable dtConfiguration = StoredProcedureExecutor.StoredProcedureExecuteReader(ConnectionStr, storedProcedureCommandTest);
        if (dtConfiguration.Rows.Count > 0)
            return true;
        else
            return false;
    }

    public static bool CheckProcessConfigurationStatus(string ConnectionStr, string processType, string employeeCode)
    {
        string storedProcedureCommandTest = "exec [spProcessCheckConfigurationStatus] '" + processType + "','" + employeeCode + "'";
        DataTable dtProcessConfiguration = StoredProcedureExecutor.StoredProcedureExecuteReader(ConnectionStr, storedProcedureCommandTest);
        if (dtProcessConfiguration.Rows.Count > 0)
            return true;
        else
            return false;
    }
}
