using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using System.Data;
using ERPWebApplication.CommonClass;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class TwoColumnsTableDataController : DataAccessBase
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
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, this.SqlCreateView(objTwoColumnsTableData));

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private string SqlCreateView(TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                string sqlForView = null;
                sqlForView = @" if exists(Select * from sysobjects where name = '" + objTwoColumnsTableData.TableName.Replace(" ", String.Empty) + "' and type = 'V' ) begin drop view " + objTwoColumnsTableData.TableName.Replace(" ", String.Empty) + " end;";
                sqlForView += " exec('create view " + objTwoColumnsTableData.TableName.Replace(" ", string.Empty) +
                             @" as   SELECT  CompanyID
			                ,[FieldOfID]
			                ,[FieldOfName]
			                ,FieldDescription
                            ,[DataUsed]
                            ,[EntryUserID]
                            ,[EntryDate]
                            ,[LastUpdateDate]
                            ,[LastUpdateUserID]
                            FROM [TwoColumnsTable] WHERE CompanyID = " + objTwoColumnsTableData.CompanyID + " AND [TableID] = " + objTwoColumnsTableData.TableID + "');";
                return sqlForView;

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
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, this.SqlCreateView(objTwoColumnsTableData));

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
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, this.SqlCreateView(objTwoColumnsTableData));

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private void LoadRecordDDL(DropDownList givenDDLID, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                string sqlString = @"SELECT [FieldOfID]
                 ,[FieldOfName]
                 FROM [TwoColumnsTable] 
                 WHERE DataUsed = 'A' AND [TableID] = " + objTwoColumnsTableData.TableID + " AND [CompanyID] = " + objTwoColumnsTableData.CompanyID + " AND [BranchID] = " + objTwoColumnsTableData.BranchID + " ORDER BY [FieldOfName]";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlString, givenDDLID, "FieldOfName", "FieldOfID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private void LoadRecordDynamicDDL(DropDownList givenDDLID, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                string sqlString = @"SELECT [FieldOfID]
                 ,[FieldOfName]
                 FROM [TwoColumnsTable] 
                 WHERE DataUsed = 'A' AND [TableID] = " + objTwoColumnsTableData.TableID + "";

                if (objTwoColumnsTableData.CompanyID != 0)
                {
                    sqlString += " AND [CompanyID] = " + objTwoColumnsTableData.CompanyID + "";

                }

                if (objTwoColumnsTableData.BranchID != 0)
                {
                    sqlString += " AND[BranchID] = " + objTwoColumnsTableData.BranchID + "";
                }

                sqlString += " ORDER BY [FieldOfName]";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlString, givenDDLID, "FieldOfName", "FieldOfID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        internal void LoadDesignationDDL(DropDownList givenDDL, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, SqlGetDesignation(objTwoColumnsTableData), givenDDL, "FieldOfName", "FieldOfID");
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private static string SqlGetDesignation(TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                string sqlString = @"SELECT [FieldOfID]
                 ,[FieldOfName]
                 FROM [orgDesignation] 
                 WHERE DataUsed = 'A' AND [CompanyID] = " + objTwoColumnsTableData.CompanyID + "";
                if (objTwoColumnsTableData.BranchID != 0)
                {
                    sqlString += " AND [BranchID] = " + objTwoColumnsTableData.BranchID + "";
                }

                sqlString += " ORDER BY [FieldOfName]";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadCategory(TwoColumnsTableData objTwoColumnsTableData, DropDownList ddlCategory)
        {
            try
            {
                this.LoadRecordDynamicDDL(ddlCategory, objTwoColumnsTableData);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadRoleType(DropDownList ddlRoleType)
        {
            try
            {
                TwoColumnsTableData objTwoColumnsTableData = new TwoColumnsTableData();
                objTwoColumnsTableData.TableID = 25;
                this.LoadRecordDynamicDDL(ddlRoleType, objTwoColumnsTableData);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        internal void LoadEmployeeTypeDDL(DropDownList ddlEmployeeType, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, SqlForEmployeeType(objTwoColumnsTableData), ddlEmployeeType, "FieldOfName", "FieldOfID");
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlForEmployeeType(TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                string sqlString = null;
                sqlString = "SELECT [FieldOfID],[FieldOfName] FROM [EmployeeType] WHERE [DataUsed] = 'A' AND [CompanyID] = " + objTwoColumnsTableData.CompanyID + " ORDER BY [FieldOfName]";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadEmployeeCategoryDDL(DropDownList ddlEmployeeCategory, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, SqlGetEmployeeCategory(objTwoColumnsTableData), ddlEmployeeCategory, "FieldOfName", "FieldOfID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetEmployeeCategory(TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                string sqlString = null;
                sqlString = "SELECT [FieldOfID],[FieldOfName] FROM [EmployeeCategory] WHERE [DataUsed] = 'A' AND [CompanyID] = " + objTwoColumnsTableData.CompanyID + " ORDER BY [FieldOfName]";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadEmployeeTitle(DropDownList ddlTitle)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, SqlGetEmployeeTitle(), ddlTitle, "FieldOfName", "FieldOfID");

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private string SqlGetEmployeeTitle()
        {
            try
            {
                string sqlString = null;
                sqlString = "SELECT [FieldOfID],[FieldOfName] FROM [EmployeeTitle] WHERE [DataUsed] = 'A' ORDER BY [FieldOfName]";
                return sqlString;

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}