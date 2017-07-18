using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class SubledgerSetupController : DataAccessBase
    {
        internal void Save(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                objSubledgerSetup.SubledgerTypeID = objSubledgerSetup.SubledgerTypePrefix + this.GetSubledgerTypeID().ToString("000");
                var storedProcedureComandText = "INSERT INTO [AccCOASubLedgerTypeSetup] ([SubledgerTypePrefix],[SubledgerTypeID],[SubLedgerTypeName] ,[KnownValueId] " +
                ",[IsConvertable],[CompanyID],[BranchID],[EntryDate],[EntryUserID],[DataUsed]) VALUES ( " +
                "'" + objSubledgerSetup.SubledgerTypePrefix + "'," +
                "'" + objSubledgerSetup.SubledgerTypeID + "'," +
                "'" + objSubledgerSetup.SubLedgerTypeName + "'," +
                "" + objSubledgerSetup.KnownValueId + "," +
                "'" + objSubledgerSetup.IsConvertable + "'," +
                "" + objSubledgerSetup.CompanyID + "," +
                "" + objSubledgerSetup.BranchID + "," +
                "CAST(GETDATE() AS DateTime)," +
                "'" + objSubledgerSetup.EntryUserName + "'," +
                "'A');";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private int GetSubledgerTypeID()
        {
            try
            {
                int subledgerTypeID = 0;
                var storedProcedureComandText = "SELECT ISNULL( MAX( RIGHT( SubledgerTypeID,3)),0) +1  FROM AccCOASubLedgerTypeSetup";
                subledgerTypeID = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return subledgerTypeID;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetSubLedgerTypeConvertable(DropDownList ddlSubLedgerTypeConvertable, SubledgerSetup objSubledgerSetup)
        {
            try
            {
                objSubledgerSetup.IsConvertable = "Y";
                string sqlString = SqlGetSubLedgerType(objSubledgerSetup);
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlString, ddlSubLedgerTypeConvertable, "SubLedgerTypeName", "SubledgerTypeID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private static string SqlGetSubLedgerType(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                string sqlString = @"SELECT [SubledgerTypeID]
                  ,[SubLedgerTypeName]
              FROM [AccCOASubLedgerTypeSetup] WHERE [DataUsed] = 'A' AND [IsConvertable] = '" + objSubledgerSetup.IsConvertable + "'";

                if (objSubledgerSetup.CompanyID != 0)
                {
                    sqlString += " AND [CompanyID] = " + objSubledgerSetup.CompanyID + "";

                }

                if (objSubledgerSetup.BranchID != 0)
                {
                    sqlString += " AND[BranchID] = " + objSubledgerSetup.BranchID + "";
                }

                sqlString += " ORDER BY [SubLedgerTypeName]";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetSubLedgerTypeNonConvertable(DropDownList ddlSubLedgerTypeNonConvertable, SubledgerSetup objSubledgerSetup)
        {
            try
            {
                objSubledgerSetup.IsConvertable = "N";
                string sqlString = SqlGetSubLedgerType(objSubledgerSetup);
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlString, ddlSubLedgerTypeNonConvertable, "SubLedgerTypeName", "SubledgerTypeID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SaveSubLedger(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                if (objSubledgerSetup.SubledgerTypeID == "-1")
                {
                    throw new Exception("Subledger type is required");

                }

                objSubledgerSetup.SubledgerID = objSubledgerSetup.CompanyID + GetSubledgerID().ToString("000");
                objSubledgerSetup.SubledgerReferenceID = objSubledgerSetup.SubledgerID;
                var storedProcedureComandText = "INSERT INTO [AccCOASubHeadSetup] ([CompanyID],[BranchID],[SubLedgerTypeID],[SubLedgerID],[ReferenceID],[SubledgerHeadName] " +
               ",[SubledgerDescription],[EntryDate],[EntryUserID],[DataUsed]) VALUES( " +
                "" + objSubledgerSetup.CompanyID + "," +
                "" + objSubledgerSetup.BranchID + "," +
                "'" + objSubledgerSetup.SubledgerTypeID + "'," +
                "'" + objSubledgerSetup.SubledgerID + "'," +
                "'" + objSubledgerSetup.SubledgerReferenceID + "'," +
                "'" + objSubledgerSetup.SubledgerHeadName + "'," +
                "'" + objSubledgerSetup.SubledgerDescription + "'," +
                "CAST(GETDATE() AS DateTime)," +
                "'" + objSubledgerSetup.EntryUserName + "'," +
                "'A');";

                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetSubledgerID()
        {
            try
            {
                int subledgerTypeID = 0;
                var storedProcedureComandText = "SELECT ISNULL( MAX( RIGHT( SubLedgerID,3)),0) +1  FROM AccCOASubHeadSetup";
                subledgerTypeID = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return subledgerTypeID;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetKnownValueSubledger(SubledgerSetup objSubledgerSetup, DropDownList ddlKnownValue)
        {
            try
            {
                string sqlString = @"SELECT [KnownValueID],[KnownValueName] FROM [AccCoaSubLedgerKnownValue] WHERE [DataUsed] = 'A'";

                if (objSubledgerSetup.CompanyID != 0)
                {
                    sqlString += " AND [CompanyID] = " + objSubledgerSetup.CompanyID + "";

                }

                if (objSubledgerSetup.BranchID != 0)
                {
                    sqlString += " AND[BranchID] = " + objSubledgerSetup.BranchID + "";
                }

                sqlString += " ORDER BY [KnownValueName]";

                ClsDropDownListController.LoadDropDownList(this.ConnectionString, sqlString, ddlKnownValue, "KnownValueName", "KnownValueID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SaveSubLedgerConvertible(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                DataTable dtValuesOfSubledgerType = GetValuesOfSubledgerType(objSubledgerSetup);
                foreach (DataRow dtSubledgerTypeRow in dtValuesOfSubledgerType.Rows)
                {
                    objSubledgerSetup.CompanyID = Convert.ToInt32(dtSubledgerTypeRow["CompanyID"].ToString());
                    objSubledgerSetup.BranchID = Convert.ToInt32(dtSubledgerTypeRow["BranchID"].ToString());
                    objSubledgerSetup.KnownValueId = Convert.ToInt32(dtSubledgerTypeRow["KnownValueId"].ToString());
                }

                DataTable dtConvertibleData = GetConvertibleData(objSubledgerSetup);
                int tempSubledgerID = GetSubledgerID();
                objSubledgerSetup.SubledgerID = objSubledgerSetup.CompanyID + tempSubledgerID.ToString("000");
                if (dtConvertibleData != null)
                {
                    string storedProcedureComandText = null;
                    foreach (DataRow rowNo in dtConvertibleData.Rows)
                    {
                        objSubledgerSetup.SubledgerReferenceID = rowNo["ReferenceID"].ToString();
                        objSubledgerSetup.SubledgerHeadName = rowNo["SubledgerHeadName"].ToString();
                        objSubledgerSetup.SubledgerDescription = rowNo["ReferenceID"].ToString() + "-" + rowNo["SubledgerHeadName"].ToString();
                        bool subledgerID = CheckSubledgerID(objSubledgerSetup);
                        if (subledgerID == false)
                        {
                            storedProcedureComandText += "INSERT INTO [AccCOASubHeadSetup] ([CompanyID],[BranchID],[SubLedgerTypeID],[SubLedgerID],[ReferenceID],[SubledgerHeadName] " +
                           ",[SubledgerDescription],[EntryDate],[EntryUserID],[DataUsed]) VALUES( " +
                            "" + objSubledgerSetup.CompanyID + "," +
                            "" + objSubledgerSetup.BranchID + "," +
                            "'" + objSubledgerSetup.SubledgerTypeID + "'," +
                            "'" + objSubledgerSetup.SubledgerID + "'," +
                            "'" + objSubledgerSetup.SubledgerReferenceID + "'," +
                            "'" + objSubledgerSetup.SubledgerHeadName + "'," +
                            "'" + objSubledgerSetup.SubledgerDescription + "'," +
                            "CAST(GETDATE() AS DateTime)," +
                            "'" + objSubledgerSetup.EntryUserName + "'," +
                            "'A');";
                            tempSubledgerID++;
                            objSubledgerSetup.SubledgerID = objSubledgerSetup.CompanyID + tempSubledgerID.ToString("000");
                        }
                    }

                    if (storedProcedureComandText == null)
                    {
                        throw new Exception(clsMessages.GNoNewDataFound);

                    }
                    else
                    {
                        clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

                    }


                }
                else
                {
                    throw new Exception(clsMessages.GNoDataFound);
                }


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private bool CheckSubledgerID(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                bool subledgerID = false;
                DataTable dtSubledgerID = null;
                string storedProcedureCommandText = @"SELECT [SubLedgerID] FROM [AccCOASubHeadSetup] WHERE [DataUsed] = 'A' AND [ReferenceID] ='" + objSubledgerSetup.SubledgerReferenceID + "'";
                dtSubledgerID = clsDataManipulation.GetData(this.ConnectionString, storedProcedureCommandText);
                if (dtSubledgerID.Rows.Count > 0)
                {
                    subledgerID = true;

                }

                return subledgerID;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private DataTable GetValuesOfSubledgerType(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                DataTable dtValuesOfSubledgerType = null;
                string storedProcedureCommandText = @"SELECT [KnownValueId],[CompanyID],[BranchID]
                FROM [AccCOASubLedgerTypeSetup] WHERE DataUsed = 'A' AND [SubledgerTypeID] = '" + objSubledgerSetup.SubledgerTypeID + "'";
                return dtValuesOfSubledgerType = clsDataManipulation.GetData(this.ConnectionString, storedProcedureCommandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private DataTable GetConvertibleData(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                DataTable dtSpecifiedConvertibleData = null;
                switch (objSubledgerSetup.KnownValueId)
                {
                    case 9:
                        {
                            string storedProcedureCommandText = @"SELECT [ReferenceID] AS ReferenceID,[EmployeeID] AS SubledgerHeadName
                            FROM [hrEmployeeSetup] WHERE [DataUsed] = 'A' ";
                            if (objSubledgerSetup.CompanyID != 0)
                            {
                                storedProcedureCommandText += " AND [CompanyID] = " + objSubledgerSetup.CompanyID + "";

                            }

                            storedProcedureCommandText += " ORDER BY [ReferenceID]";
                            dtSpecifiedConvertibleData = clsDataManipulation.GetData(this.ConnectionString, storedProcedureCommandText);
                            break;
                        }
                    case 1:
                        {
                            dtSpecifiedConvertibleData = clsDataManipulation.GetData(this.ConnectionString, SqlGetOrgBranch(objSubledgerSetup));
                            break;
                        }
                    case 4:
                        {
                            dtSpecifiedConvertibleData = clsDataManipulation.GetData(this.ConnectionString, SqlGetOrgDepartment(objSubledgerSetup));
                            break;
                        }
                    case 5:
                        {
                            dtSpecifiedConvertibleData = clsDataManipulation.GetData(this.ConnectionString, SqlGetOrgSection(objSubledgerSetup));
                            break;
                        }
                    case 6:
                        {
                            dtSpecifiedConvertibleData = clsDataManipulation.GetData(this.ConnectionString, SqlGetOrgTeam(objSubledgerSetup));
                            break;
                        }
                    case 3:
                        {
                            dtSpecifiedConvertibleData = clsDataManipulation.GetData(this.ConnectionString, SqlGetDivision(objSubledgerSetup));
                            break;
                        }
                    case 11:
                        {
                            dtSpecifiedConvertibleData = clsDataManipulation.GetData(this.ConnectionString, SqlGetProject(objSubledgerSetup));
                            break;
                        }
                    case 7:
                        {
                            dtSpecifiedConvertibleData = clsDataManipulation.GetData(this.ConnectionString, SqlGetClient(objSubledgerSetup));
                            break;
                        }
                    case 8:
                        {
                            dtSpecifiedConvertibleData = clsDataManipulation.GetData(this.ConnectionString, SqlGetSupplier(objSubledgerSetup));
                            break;
                        }
                    default:
                        dtSpecifiedConvertibleData = null;
                        break;
                }
                return dtSpecifiedConvertibleData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetSupplier(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                string storedProcedureCommandText = @"SELECT [ContactID] AS ReferenceID,[FullName] AS SubledgerHeadName
                            FROM [AllSuppliers] ";
                if (objSubledgerSetup.CompanyID != 0)
                {
                    storedProcedureCommandText += " WHERE [CompanyID] = " + objSubledgerSetup.CompanyID + "";

                }

                if (objSubledgerSetup.BranchID != 0)
                {
                    storedProcedureCommandText += " AND [BranchID] = " + objSubledgerSetup.BranchID + "";

                }

                return storedProcedureCommandText += " ORDER BY [ContactID]";

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetClient(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                string storedProcedureCommandText = @"SELECT [ContactID] AS ReferenceID,[FullName] AS SubledgerHeadName
                            FROM [Show All Clients] ";
                if (objSubledgerSetup.CompanyID != 0)
                {
                    storedProcedureCommandText += " WHERE [CompanyID] = " + objSubledgerSetup.CompanyID + "";

                }

                if (objSubledgerSetup.BranchID != 0)
                {
                    storedProcedureCommandText += " AND [BranchID] = " + objSubledgerSetup.BranchID + "";

                }

                return storedProcedureCommandText += " ORDER BY [ContactID]";

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetProject(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                string storedProcedureCommandText = @"SELECT [ProjectID] AS ReferenceID,[ProjectName] AS SubledgerHeadName
                            FROM [pmProjectSetup] WHERE [DataUsed] = 'A' ";
                if (objSubledgerSetup.CompanyID != 0)
                {
                    storedProcedureCommandText += " AND [CompanyID] = " + objSubledgerSetup.CompanyID + "";

                }

                if (objSubledgerSetup.BranchID != 0)
                {
                    storedProcedureCommandText += " AND [BranchID] = " + objSubledgerSetup.BranchID + "";

                }

                return storedProcedureCommandText += " ORDER BY [ProjectID]";

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private string SqlGetDivision(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                string storedProcedureCommandText = @"SELECT [FieldOfID] AS ReferenceID,[FieldOfName] AS SubledgerHeadName
                            FROM [DivisionSetup] WHERE [DataUsed] = 'A' ORDER BY FieldOfID ";
                return storedProcedureCommandText;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetOrgTeam(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                string storedProcedureCommandText = @"SELECT [EntityID] AS ReferenceID,[EntityName] AS SubledgerHeadName
                            FROM [orgTeam] WHERE [DataUsed] = 'A' ";
                if (objSubledgerSetup.CompanyID != 0)
                {
                    storedProcedureCommandText += " AND [CompanyID] = " + objSubledgerSetup.CompanyID + "";

                }

                if (objSubledgerSetup.BranchID != 0)
                {
                    storedProcedureCommandText += " AND [ParentEntityID] = " + objSubledgerSetup.BranchID + "";

                }

                return storedProcedureCommandText += " ORDER BY [EntityID]";

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetOrgSection(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                string storedProcedureCommandText = @"SELECT [EntityID] AS ReferenceID,[EntityName] AS SubledgerHeadName
                            FROM [orgSection] WHERE [DataUsed] = 'A' ";
                if (objSubledgerSetup.CompanyID != 0)
                {
                    storedProcedureCommandText += " AND [CompanyID] = " + objSubledgerSetup.CompanyID + "";

                }

                if (objSubledgerSetup.BranchID != 0)
                {
                    storedProcedureCommandText += " AND [ParentEntityID] = " + objSubledgerSetup.BranchID + "";

                }

                return storedProcedureCommandText += " ORDER BY [EntityID]";

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetOrgDepartment(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                string storedProcedureCommandText = @"SELECT [EntityID] AS ReferenceID,[EntityName] AS SubledgerHeadName
                            FROM [orgDepartment] WHERE [DataUsed] = 'A' ";
                if (objSubledgerSetup.CompanyID != 0)
                {
                    storedProcedureCommandText += " AND [CompanyID] = " + objSubledgerSetup.CompanyID + "";

                }

                if (objSubledgerSetup.BranchID != 0)
                {
                    storedProcedureCommandText += " AND [ParentEntityID] = " + objSubledgerSetup.BranchID + "";

                }

                return storedProcedureCommandText += " ORDER BY [EntityID]";

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetOrgBranch(SubledgerSetup objSubledgerSetup)
        {
            try
            {
                string storedProcedureCommandText = @"SELECT [EntityID] AS ReferenceID,[EntityName] AS SubledgerHeadName
                            FROM [orgBranch] WHERE [DataUsed] = 'A' ";
                if (objSubledgerSetup.CompanyID != 0)
                {
                    storedProcedureCommandText += " AND [CompanyID] = " + objSubledgerSetup.CompanyID + "";

                }

                return storedProcedureCommandText += " ORDER BY [EntityID]";

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}