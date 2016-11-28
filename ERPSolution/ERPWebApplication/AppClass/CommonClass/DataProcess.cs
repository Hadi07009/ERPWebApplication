using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebApplication.CommonClass
{
    public class DataProcess
    {

        public DataProcess()
        { 
        
        
        }

        public static DataTable GetData(string ConnectionString, string QueryStr)
        {
            SqlConnection sqlConn = null;
            DataTable dataTableObj = null;
            try
            {
                string selectQuery = QueryStr;
                sqlConn = new SqlConnection(ConnectionString);
                sqlConn.Open();
                SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectQuery, sqlConn);
                dataTableObj = new DataTable();
                sqlDataAdapterObj.Fill(dataTableObj);

            }
            catch (SqlException sqlExceptionObject)
            {

            }
            catch (Exception exceptionObject)
            {

            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return dataTableObj;
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

            }
            catch (Exception exceptionObject)
            {

            }
            return dataTableObj;
        }



        public static bool InsertQuery(string ConnectionString, string QueryStr)
        {
            SqlConnection sqlConn = null;
            int noOfRowsAffected = 0;
            try
            {
                sqlConn = new SqlConnection(ConnectionString);
                sqlConn.Open();
                SqlCommand sqlCom = new SqlCommand(QueryStr, sqlConn);
                noOfRowsAffected = sqlCom.ExecuteNonQuery();
            }
            catch (Exception exceptionObj)
            {
                return false;
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

        public static bool ExecuteSqlCommand(SqlCommand myCommand, string QueryStr)
        {           
            int noOfRowsAffected = 0;
            try
            {
                myCommand.CommandText = QueryStr;
                noOfRowsAffected=myCommand.ExecuteNonQuery();                
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

        public static bool UpdateQuery(string ConnectionString, string QueryStr)
        {
            SqlConnection sqlConn = null;
            int noOfRowsAffected = 0;

            try
            {
                sqlConn = new SqlConnection(ConnectionString);
                sqlConn.Open();
                SqlCommand sqlCom = new SqlCommand(QueryStr, sqlConn);
                noOfRowsAffected = sqlCom.ExecuteNonQuery();
            }
            catch (SqlException sqlExceptionObject)
            {

            }
            catch (Exception exceptionObj)
            {

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

        public static bool DeleteQuery(string ConnectionString, string QueryStr)
        {
            SqlConnection sqlConn = null;
            int noOfRowsAffected = 0;

            try
            {
                sqlConn = new SqlConnection(ConnectionString);
                sqlConn.Open();
                SqlCommand sqlCom = new SqlCommand(QueryStr, sqlConn);
                noOfRowsAffected = sqlCom.ExecuteNonQuery();
            }
            catch (SqlException sqlExceptionObject)
            {

            }
            catch (Exception exceptionObj)
            {

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

       // RequisitionDate

        public static int GetMaximumValueFromtableColumn(string connectionString, string tableName, string whereClause, string colName, string companyID, string branchID)
        {
            SqlConnection sqlConn = null;
            DataTable dataTableObj = null;
            int retValue = 0;
            try
            {

                //SELECT RIGHT('HELLO WORLD', 3);


                string selectQuery = "select count(" + colName + ")+1  as " + colName + " from " + tableName + " " + "WHERE CompanyID = " + companyID + " AND BranchID = " + branchID + " and RequisitionDate=convert(datetime,'" + whereClause + "',103)";

                // string selectQuery = "select isnull( max(" + colName + "),0)+1  as " + colName + " from " + tableName + " " + "WHERE CompanyID = " + companyID + " AND BranchID = " + branchID + " ";

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

        public static int GetMaximumValueFromtableColumn2(string connectionString, string tableName, string colName, string companyID, string branchID)
        {
            SqlConnection sqlConn = null;
            DataTable dataTableObj = null;
            int retValue = 0;
            try
            {

                //SELECT RIGHT('HELLO WORLD', 3);

                string selectQuery = "select isnull( max(right(" + colName + ",4)),0)+1  as " + colName + " from " + tableName + " " + "WHERE  CompanyID = " + companyID + " AND BranchID = " + branchID + " ";

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
                //SELECT RIGHT('HELLO WORLD', 3);

                //string selectQuery = selectQuery;

                //string selectQuery = "select count(" + colName + ")+1  as " + colName + " from " + tableName + " " + "WHERE CompanyID = " + companyID + " AND BranchID = " + branchID + " and RequisitionDate=convert(datetime,'" + whereClause + "',103)";

                // string selectQuery = "select isnull( max(" + colName + "),0)+1  as " + colName + " from " + tableName + " " + "WHERE CompanyID = " + companyID + " AND BranchID = " + branchID + " ";

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
}