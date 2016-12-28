using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using System.Data;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class TwoColumnsTableDataController
    {
        public void Save(string connectionString, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                var storedProcedureComandTest = "exec [ACT_TwoColumnsTable] " +
                                        objTwoColumnsTableData.CompanyID + "," +
                                        objTwoColumnsTableData.BranchID + "," +
                                        objTwoColumnsTableData.TableID + ",'" +
                                        0 + "','" +
                                        objTwoColumnsTableData.FieldOfName + "','" +
                                        objTwoColumnsTableData.FieldDescription + "','" +
                                        objTwoColumnsTableData.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        public DataTable GetRecord(string connectionString, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                DataTable dtRecord = null;
                string sqlString = @"SELECT [FieldOfID]
                 ,[FieldOfName]
                 ,[FieldDescription]      
                 FROM [TwoColumnsTable] 
                 WHERE DataUsed = 'A' AND [TableID] = " + objTwoColumnsTableData.TableID + " AND [CompanyID] = " + objTwoColumnsTableData.CompanyID + " AND [BranchID] = " + objTwoColumnsTableData.BranchID + " ORDER BY [FieldOfName]";
                dtRecord = clsDataManipulation.GetData(connectionString, sqlString);
                return dtRecord;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        public void Delete(string connectionString, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                string sqlString = "UPDATE TwoColumnsTable SET DataUsed	= 'I' WHERE FieldOfID = '" + objTwoColumnsTableData.FieldOfID + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, sqlString);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        public void Update(string connectionString, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                var storedProcedureComandTest = "exec [ACT_TwoColumnsTable] " +
                                        objTwoColumnsTableData.CompanyID + "," +
                                        objTwoColumnsTableData.BranchID + "," +
                                        objTwoColumnsTableData.TableID + ",'" +
                                        objTwoColumnsTableData.FieldOfID + "','" +
                                        objTwoColumnsTableData.FieldOfName + "','" +
                                        objTwoColumnsTableData.FieldDescription + "','" +
                                        objTwoColumnsTableData.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
 
        }
    }
}