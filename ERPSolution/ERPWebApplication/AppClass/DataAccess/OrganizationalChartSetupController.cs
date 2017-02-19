using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class OrganizationalChartSetupController : DataAccessBase
    {
        private TwoColumnsTableDataAutoController _objTwoColumnsTableDataAutoController;
        internal void LoadCompanyDDL(DropDownList ddlCompany)
        {
            try
            {
                CompanySetupController objCompanySetupController = new CompanySetupController();
                objCompanySetupController.LoadCompany(ddlCompany);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadStandardOrgElementsDDL(ListBox listBoxStandardOrgElements)
        {
            try
            {
                StandardOrgElementsController objStandardOrgElementsController = new StandardOrgElementsController();
                objStandardOrgElementsController.LoadStandardOrgElements(listBoxStandardOrgElements);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void Save(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                if (objOrganizationalChartSetup.CompanyID == -1)
                {
                    throw new Exception(" company name is required ");

                }

                if (objOrganizationalChartSetup.OrgElementIDList.Count == 0)
                {
                    throw new Exception("please select elements correctly");

                }

                foreach (var listItem in objOrganizationalChartSetup.OrgElementIDList)
                {
                    var storedProcedureComandText = "INSERT INTO [orgOrganizationElements] ([CompanyID],[OrgElementID],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objOrganizationalChartSetup.CompanyID + "," +
                                                 listItem.ToString() + ",'" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
                }


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadOrganizationalElements(OrganizationalChartSetup objOrganizationalChartSetup, ListBox listBoxOrganizationElements)
        {
            try
            {
                ClsListBoxController.LoadListBox(this.ConnectionString, SqlGetOrganizationalElements(objOrganizationalChartSetup),
                    listBoxOrganizationElements, "OrgElementName", "OrgElementID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlGetOrganizationalElements(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                string sqlQuery = null;
                sqlQuery = @"SELECT A.[OrgElementID],B.OrgElementName      
                          FROM [orgOrganizationElements] A 
                          INNER JOIN orgStandardOrgElements B ON A.OrgElementID = B.OrgElementID
                          WHERE A.[DataUsed] = 'A' AND A.[CompanyID]= " + objOrganizationalChartSetup.CompanyID + " ORDER BY B.HierarchyID";
                return sqlQuery;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        internal void LoadOrganizationalElements(OrganizationalChartSetup objOrganizationalChartSetup, DropDownList dropDownListOrganizationElements)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlGetOrganizationalElements(objOrganizationalChartSetup), dropDownListOrganizationElements,
                    "OrgElementName", "OrgElementID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void Update(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                var storedProcedureComandTextUpdate = @"UPDATE [orgOrganizationElements] SET [DataUsed] = 'I' WHERE [CompanyID] = " + objOrganizationalChartSetup.CompanyID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextUpdate);

                foreach (var listItem in objOrganizationalChartSetup.OrgElementIDList)
                {
                    var storedProcedureComandText = "INSERT INTO [orgOrganizationElements] ([CompanyID],[OrgElementID],[DataUsed],[EntryUserID],[LastUpdateUserID],[LastUpdateDate]) VALUES ( " +
                                                 objOrganizationalChartSetup.CompanyID + "," +
                                                 listItem.ToString() + ",'" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "','" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void PopulateRootLevel(TreeView TreeViewCompanyChart)
        {
            try
            {
                TreeViewCompanyChart.Nodes.Clear();
                TreeViewCompanyChart.ExpandAll();
                var myConnection = new SqlConnection(this.ConnectionString);
                var sqlString = @" SELECT 111 as EntityID,'Organizational Chart' as EntityName,childnodecount = 
                                    (SELECT Count(*) FROM orgOrganizationalChartSetup  
                                    WHERE ParentEntityID = 111)";
                var dt = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                PopulateNodes(dt, TreeViewCompanyChart.Nodes);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var tn = new TreeNode(dr["EntityName"].ToString(), dr["EntityID"].ToString());
                    nodes.Add(tn);
                    tn.PopulateOnDemand = (int.Parse(dr["childnodecount"].ToString()) > 0);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        public void PopulateSubLevel(int parentid, TreeNode parentNode)
        {
            try
            {
                var sqlString = @"select EntityID,EntityName,(select count(*) FROM orgOrganizationalChartSetup WHERE ParentEntityID=e.EntityID) childnodecount FROM orgOrganizationalChartSetup e where ParentEntityID= " + parentid + "";
                var dt = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                PopulateNodes(dt, parentNode.ChildNodes);
                parentNode.CollapseAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SaveChart(OrganizationalChartSetup objOrganizationalChartSetup, EmployeeSetup objEmployeeSetup, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                if (objOrganizationalChartSetup.CompanyID == -1)
                {
                    throw new Exception("company is required ");

                }


                objOrganizationalChartSetup.EntityID = Convert.ToInt32(objOrganizationalChartSetup.EntityTypeID.ToString() + this.GetEntityID(objOrganizationalChartSetup).ToString());
                var storedProcedureComandText = @"INSERT INTO [orgOrganizationalChartSetup] ([CompanyID],[ParentEntityID],[EntityID],[EntityTypeID]
                                               ,[AddressTag],[AddressID],[EntityName],[ShortName],[DisplayName],[GroupEmailAddress],[HeadID]
                                               ,[EntityCategoryID],[EntityOpeningDate],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objOrganizationalChartSetup.CompanyID + "," +
                                                 objOrganizationalChartSetup.ParentEntityID + "," +
                                                 objOrganizationalChartSetup.EntityID + "," +
                                                 objOrganizationalChartSetup.EntityTypeID + ",'" +
                                                 objOrganizationalChartSetup.AddressTag + "'," +
                                                 objOrganizationalChartSetup.EntityID + ",'" +
                                                 objOrganizationalChartSetup.EntityName + "','" +
                                                 objOrganizationalChartSetup.ShortName + "','" +
                                                 objOrganizationalChartSetup.DisplayName + "','" +
                                                 objOrganizationalChartSetup.GroupEmailAddress + "','" +
                                                 objEmployeeSetup.EmployeeID + "','" +
                                                 objTwoColumnsTableData.FieldOfID + "',CONVERT(DATETIME,'" +
                                                 objOrganizationalChartSetup.EntityOpeningDate + "', 103),'" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                if (objOrganizationalChartSetup.AddressTag == "Y")
                {
                    storedProcedureComandText += SqlSaveAddress(objOrganizationalChartSetup);

                }

                storedProcedureComandText += this.SqlCreateView(objOrganizationalChartSetup);
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlSaveAddress(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                objOrganizationalChartSetup.ContactAddressUsedID = GetContactAdreessNumber(objOrganizationalChartSetup);
                var storedProcedureComandText = @"INSERT INTO [orgOrganizationAddress] ([EntityAdreessID],[ContactAdreessNumber],[ContactAddressUsedID],[AddressAsOn]
                                    ,[DisplayAddress],[DivisionID],[DistrictID],[PostalCode],[ContactPhoneNo],[Fax],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objOrganizationalChartSetup.EntityID + "," +
                                                 objOrganizationalChartSetup.ContactAdreessNumber + "," +
                                                 objOrganizationalChartSetup.ContactAddressUsedID + "," +
                                                 "CAST(GETDATE() AS DateTime)" + ",'" +
                                                 objOrganizationalChartSetup.DisplayAddress + "'," +
                                                 objOrganizationalChartSetup.DivisionID + "," +
                                                 objOrganizationalChartSetup.DistrictID + ",'" +
                                                 objOrganizationalChartSetup.PostalCode + "','" +
                                                 objOrganizationalChartSetup.PhoneNo + "','" +
                                                 objOrganizationalChartSetup.Fax + "','" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                return storedProcedureComandText;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetContactAdreessNumber(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                int seqNo = 0;
                var storedProcedureComandText = @" SELECT ISNULL( MAX([ContactAddressUsedID]),0)+1 FROM [orgOrganizationAddress] WHERE [EntityAdreessID] = " + objOrganizationalChartSetup.EntityID + "";
                var dtSeq = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                foreach (DataRow item in dtSeq.Rows)
                {
                    seqNo = Convert.ToInt32(item.ItemArray[0].ToString());

                }
                return seqNo;


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        public string GetEntityID(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                string seqNo = null;
                var storedProcedureComandText = @" DECLARE @RefNumber VARCHAR(10),@countData INT
                SET @countData = ( SELECT ISNULL( COUNT( EntityID),0) +1  FROM orgOrganizationalChartSetup WHERE EntityTypeID = " + objOrganizationalChartSetup.EntityTypeID + ") " +
                " SET @RefNumber=STUFF('00',3-LEN(@countData),20,@countData) ; SELECT @RefNumber";
                var dtSeq = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                foreach (DataRow item in dtSeq.Rows)
                {
                    seqNo = item.ItemArray[0].ToString();

                }
                return seqNo;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        internal void LoadCategory(OrganizationalChartSetup objOrganizationalChartSetup, DropDownList ddlCategory)
        {
            try
            {
                TwoColumnsTableDataController objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                TwoColumnsTableData objTwoColumnsTableData = new TwoColumnsTableData();
                objTwoColumnsTableData.TableID = objOrganizationalChartSetup.EntityTypeID;
                objTwoColumnsTableDataController.LoadCategory(objTwoColumnsTableData, ddlCategory);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadDivisionDDL(DropDownList ddlDivision)
        {
            try
            {
                _objTwoColumnsTableDataAutoController = new TwoColumnsTableDataAutoController();
                _objTwoColumnsTableDataAutoController.GetDivision(ddlDivision);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadDistrict(DropDownList ddlDistrict)
        {
            try
            {
                _objTwoColumnsTableDataAutoController = new TwoColumnsTableDataAutoController();
                _objTwoColumnsTableDataAutoController.GetDistrict(ddlDistrict);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal int GetEntityTypeID(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                var sqlString = "SELECT [EntityTypeID] FROM [orgOrganizationalChartSetup] WHERE [EntityID] = " + objOrganizationalChartSetup.EntityID + "";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                var entityTypeID = objclsDataManipulation.GetSingleValue(this.ConnectionString, sqlString);
                return entityTypeID;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetEntityDetails(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                var sqlString = @"SELECT A.[CompanyID]
	                              ,[EntityTypeID]
                                  ,[AddressTag]
                                  ,[AddressID]
                                  ,[EntityName]
                                  ,[ShortName]
                                  ,[DisplayName]
                                  ,[GroupEmailAddress]
                                  ,[HeadID]
                                  ,[EntityCategoryID]
                                  ,[EntityOpeningDate] 
                              FROM [orgOrganizationalChartSetup] A  
                              WHERE A.DataUsed = 'A' AND A.EntityID = " + objOrganizationalChartSetup.EntityID + " ";
                var dtEntityDetails = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtEntityDetails;


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetEntityAddress(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                var sqlString = @"SELECT [ContactAdreessNumber]
	              ,[DisplayAddress]
                  ,[DivisionID]
                  ,[DistrictID]
                  ,[PostalCode]
                  ,[ContactPhoneNo]
                  ,[Fax]
              FROM [orgOrganizationAddress] WHERE [DataUsed] = 'A' AND [EntityAdreessID] = " + objOrganizationalChartSetup.EntityID + "";
                var dtEntityDetails = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtEntityDetails;


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void UpdateChart(OrganizationalChartSetup objOrganizationalChartSetup, EmployeeSetup objEmployeeSetup, TwoColumnsTableData objTwoColumnsTableData)
        {
            try
            {
                var storedProcedureComandText = @"UPDATE [orgOrganizationalChartSetup]
                                                   SET 
                                                   [AddressTag] = '" + objOrganizationalChartSetup.AddressTag + "'," +
                                                                    "[EntityName] = '" + objOrganizationalChartSetup.EntityName + "'," +
                                                                    "[ShortName] = '" + objOrganizationalChartSetup.ShortName + "'," +
                                                                    "[DisplayName] = '" + objOrganizationalChartSetup.DisplayName + "'," +
                                                      "[GroupEmailAddress] = '" + objOrganizationalChartSetup.GroupEmailAddress + "'," +
                                                      "[HeadID] = '" + objEmployeeSetup.EmployeeID + "'," +
                                                      "[EntityCategoryID] = '" + objTwoColumnsTableData.FieldOfID + "'," +
                                                      "[EntityOpeningDate] = CONVERT(DATETIME,'" + objOrganizationalChartSetup.EntityOpeningDate + "',103)" + "," +
                                                      "[LastUpdateDate] = CAST(GETDATE() AS DateTime) " +
                                                      ",[LastUpdateUserID] = '160ea939-7633-46a8-ae49-f661d12abfd5'" +
                                                 " WHERE [EntityID] = " + objOrganizationalChartSetup.ParentEntityID + ";";

                if (objOrganizationalChartSetup.AddressTag == "N")
                {
                    storedProcedureComandText += SqlInactiveAddressData(objOrganizationalChartSetup);

                }
                else if (objOrganizationalChartSetup.AddressTag == "Y")
                {
                    storedProcedureComandText += SqlUpdateAddress(objOrganizationalChartSetup);

                }

                storedProcedureComandText += this.SqlCreateView(objOrganizationalChartSetup);
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlUpdateAddress(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                var storedProcedureComandText = @"UPDATE [orgOrganizationAddress]
                                               SET [ContactAdreessNumber] = " + objOrganizationalChartSetup.ContactAdreessNumber + " " +
                                               " ,[DisplayAddress] = '" + objOrganizationalChartSetup.DisplayAddress + "'" +
                                               " ,[DivisionID] = " + objOrganizationalChartSetup.DivisionID + " " +
                                               " ,[DistrictID] = " + objOrganizationalChartSetup.DistrictID + " " +
                                               " ,[PostalCode] = '" + objOrganizationalChartSetup.PostalCode + "'" +
                                               " ,[ContactPhoneNo] = '" + objOrganizationalChartSetup.PhoneNo + "'" +
                                               " ,[Fax] = '" + objOrganizationalChartSetup.Fax + "'" +
                                               " ,[LastUpdateDate] = CAST(GETDATE() AS DateTime)" +
                                               " ,[LastUpdateUserID] = '160ea939-7633-46a8-ae49-f661d12abfd5'" +
                                             " WHERE [DataUsed] = 'A' AND [EntityAdreessID] = " + objOrganizationalChartSetup.ParentEntityID + ";";
                return storedProcedureComandText;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SqlInactiveAddressData(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                var storedProcedureComandText = @" UPDATE [orgOrganizationAddress]
                                               SET [DataUsed] = 'I'
                                               ,[LastUpdateDate] = CAST(GETDATE() AS DateTime)
                                               ,[LastUpdateUserID] = '160ea939-7633-46a8-ae49-f661d12abfd5'
                                             WHERE [DataUsed] = 'A' AND [EntityAdreessID] = " + objOrganizationalChartSetup.ParentEntityID + " ;";
                return storedProcedureComandText;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private string SqlCreateView(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                string sqlForView = null;
                sqlForView = @" if exists(Select * from sysobjects where name = 'org" + objOrganizationalChartSetup.TableName.Replace(" ", String.Empty) + "' and type = 'V' ) begin drop view  org" + objOrganizationalChartSetup.TableName.Replace(" ", String.Empty) + " end;";
                sqlForView += " exec('create view org" + objOrganizationalChartSetup.TableName.Replace(" ", string.Empty) +
                             @" as SELECT [CompanyID]
                          ,[ParentEntityID]
                          ,[EntityID]      
                          ,[AddressTag]
                          ,[AddressID]
                          ,[EntityName]
                          ,[ShortName]
                          ,[DisplayName]
                          ,[GroupEmailAddress]
                          ,[HeadID]
                          ,[EntityCategoryID]
                          ,[EntityOpeningDate]
                          ,[DataUsed]
                          ,[EntryUserID]
                          ,[EntryDate]
                          ,[LastUpdateDate]
                          ,[LastUpdateUserID]
                      FROM [orgOrganizationalChartSetup] WHERE [EntityTypeID] = " + objOrganizationalChartSetup.EntityTypeID + "');";
                return sqlForView;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
    }
}