using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class TwoColumnTablesController
    {
        public void Save(string connectionString, TwoColumnTables objTwoColumnTables)
        {
            try
            {
                var storedProcedureComandTest = "exec [ACT_sysTwoColumnTables] " +
                                        0 + ",'" +
                                        objTwoColumnTables.TableName + "','" +
                                        objTwoColumnTables.EntryMode + "','" +
                                        objTwoColumnTables.RelatedTo + "'," +
                                        objTwoColumnTables.RelatedUserRoleID + ",'" +
                                        objTwoColumnTables.EntrySystem + "','" +
                                        objTwoColumnTables.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        public DataTable GetRecord(string connectionString)
        {
            try
            {
                DataTable dtItem = null;
                string sqlString = @"SELECT [TableID]
                                  ,[TableName]
                                  ,[EntryMode]
                                  ,[RelatedTo]
                                  ,[RelatedUserRoleID]
                                  ,[EntrySystem]  
                              FROM [sysTwoColumnTables] WHERE DataUsed = 'A' ORDER BY [EntrySystem],[TableName],[RelatedUserRoleID]";
                dtItem = clsDataManipulation.GetData(connectionString, sqlString);
                return dtItem;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        public DataTable GetRecord(string connectionString, TwoColumnTables objTwoColumnTables)
        {
            try
            {
                DataTable dtItem = null;
                string sqlString = @"SELECT [TableID]
                                  ,[TableName]
                                    FROM [sysTwoColumnTables] WHERE DataUsed = 'A' AND EntrySystem = '" + objTwoColumnTables.EntrySystem + "' AND RelatedUserRoleID = " + objTwoColumnTables.RelatedUserRoleID + " ORDER BY [TableName],[RelatedUserRoleID]";
                dtItem = clsDataManipulation.GetData(connectionString, sqlString);
                return dtItem;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        public void Delete(string connectionString, TwoColumnTables objTwoColumnTables)
        {
            try
            {
                string sqlString = "UPDATE sysTwoColumnTables SET DataUsed	= 'I' WHERE TableID = " + objTwoColumnTables.TableID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, sqlString);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        public void Update(string connectionString, TwoColumnTables objTwoColumnTables)
        {
            try
            {
                var storedProcedureComandTest = "exec [ACT_sysTwoColumnTables] " +
                                        objTwoColumnTables.TableID + ",'" +
                                        objTwoColumnTables.TableName + "','" +
                                        objTwoColumnTables.EntryMode + "','" +
                                        objTwoColumnTables.RelatedTo + "'," +
                                        objTwoColumnTables.RelatedUserRoleID + ",'" +
                                        objTwoColumnTables.EntrySystem + "','" +
                                        objTwoColumnTables.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
    }
}