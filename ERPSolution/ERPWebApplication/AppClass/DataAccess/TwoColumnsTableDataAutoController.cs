using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using System.Data;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.CommonClass;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class TwoColumnsTableDataAutoController : DataAccessBase
    {
        public void Save(string connectionString, TwoColumnsTableDataAuto objTwoColumnsTableDataAuto)
        {
            try
            {
                DataTable dtDefaultData = new DataTable();
                var storedProcedureComandTestTemp = "";
                storedProcedureComandTestTemp = SqlCreateTable();
                storedProcedureComandTestTemp += SqlDeleteGarbageData(objTwoColumnsTableDataAuto);
                TwoColumnTables objTwoColumnTables = new TwoColumnTables();
                objTwoColumnTables.TableID = objTwoColumnsTableDataAuto.TableID;
                AutoTableData objAutoTableData = new AutoTableData(objTwoColumnTables);
                dtDefaultData = objAutoTableData.ControlTableID();
                foreach (DataRow dtRow in dtDefaultData.Rows)
                {
                    objTwoColumnsTableDataAuto.EieldOfID = dtRow[0].ToString();
                    objTwoColumnsTableDataAuto.FieldOfName = dtRow[1].ToString();

                    var storedProcedureComandTest = "INSERT INTO [TwoColumnsTableAuto] ([TableID], [FieldOfID], [FieldOfName], [DataUsed], [EntryUserID], [EntryDate]) VALUES ( " +
                                                 objTwoColumnsTableDataAuto.TableID + ",'" +
                                                 objTwoColumnsTableDataAuto.EieldOfID + "', '" +
                                                 objTwoColumnsTableDataAuto.FieldOfName + "', '" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                    storedProcedureComandTestTemp += storedProcedureComandTest;
                }

                storedProcedureComandTestTemp += SqlCreateView(objTwoColumnsTableDataAuto);

                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTestTemp);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private string SqlCreateTable()
        {
            try
            {
                string sqlForTable = null;
                sqlForTable = @"if not exists (Select * from sysobjects where name = 'TwoColumnsTableAuto' and type = 'U' ) 
                        begin 
                        CREATE TABLE [dbo].[TwoColumnsTableAuto](
	                        [TableID] [int] NOT NULL,
	                        [FieldOfID] [varchar](35) NOT NULL,
	                        [FieldOfName] [varchar](50) NULL,
	                        [DataUsed] [varchar](1) NOT NULL,
	                        [EntryUserID] [uniqueidentifier] NOT NULL,
	                        [EntryDate] [datetime] NOT NULL,
	                        [LastUpdateDate] [datetime] NULL,
	                        [LastUpdateUserID] [uniqueidentifier] NULL,
                         CONSTRAINT [PK_TwoColumnsTableAuto] PRIMARY KEY CLUSTERED 
                        (
	                        [TableID] ASC,
	                        [FieldOfID] ASC
                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                        ) ON [PRIMARY]

                        end;  ";
                return sqlForTable;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private string SqlCreateView(TwoColumnsTableDataAuto objTwoColumnsTableDataAuto)
        {
            try
            {
                string sqlForView = null;
                sqlForView = @" if exists(Select * from sysobjects where name = '" + objTwoColumnsTableDataAuto.TableName.Replace(" ", String.Empty) + "' and type = 'V' ) begin drop view " + objTwoColumnsTableDataAuto.TableName.Replace(" ", String.Empty) + " end;";
                sqlForView += " exec('create view " + objTwoColumnsTableDataAuto.TableName.Replace(" ", string.Empty) +
                             @" as SELECT [FieldOfID]
                                  ,[FieldOfName]
                                  ,[DataUsed]
                                  ,[EntryUserID]
                                  ,[EntryDate]
                                  ,[LastUpdateDate]
                                  ,[LastUpdateUserID]
                              FROM [TwoColumnsTableAuto] WHERE [TableID] = " + objTwoColumnsTableDataAuto.TableID + "');";
                return sqlForView;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private string SqlDeleteGarbageData(TwoColumnsTableDataAuto objTwoColumnsTableDataAuto)
        {
            try
            {
                string sqlForDelete = null;
                sqlForDelete = @"  DELETE FROM [TwoColumnsTableAuto] WHERE [TableID] = " + objTwoColumnsTableDataAuto.TableID + "; ";
                return sqlForDelete;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetBusinessNature(DropDownList ddlBusinessType)
        {
            try
            {
                string sqlString = "BusinessNatureSetup";
                this.GetTwoColumnsTableDataAuto(ddlBusinessType, sqlString);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        internal void GetOwnershipType(DropDownList ddlOwnershipType)
        {
            try
            {
                string sqlString = "OwnershipSetup";
                this.GetTwoColumnsTableDataAuto(ddlOwnershipType, sqlString);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private void GetTwoColumnsTableDataAuto(DropDownList givenDDL, string sqlString)
        {
            try
            {
                string sqlStringFinal = "SELECT FieldOfID,FieldOfName FROM " + sqlString + " WHERE DataUsed = 'A' ORDER BY FieldOfName";
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlStringFinal, givenDDL, "FieldOfName", "FieldOfID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        internal void GetDistrict(DropDownList ddlDistrict)
        {
            try
            {
                string sqlString = "DistrictSetup";
                this.GetTwoColumnsTableDataAuto(ddlDistrict, sqlString);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetDivision(DropDownList ddlDivision)
        {
            try
            {
                string sqlString = "DivisionSetup";
                this.GetTwoColumnsTableDataAuto(ddlDivision, sqlString);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}