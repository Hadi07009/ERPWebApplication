using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;


namespace ERPWebApplication.AppClass.DataAccess
{
    public class UserPermissionController : DataAccessBase
    {
        internal DataTable GetData()
        {
            try
            {
                string sqlString = "SELECT [NodeTypeID], [ActivityName], [FormDescription], [FormName],[PNodeTypeID] FROM [uDefaultNodeList] ";
                var dtEntityDetails = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtEntityDetails;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        internal void PopulateRootLevel(TreeView TreeViewAllNode)
        {
            try
            {
                TreeViewAllNode.Nodes.Clear();
                TreeViewAllNode.ExpandAll();
                var sqlString = @"SELECT 111 as NodeTypeID,'Node List' as ActivityName,childnodecount = 
                                    (SELECT Count(*) FROM UDefaultNodeList  
                                    WHERE PNodeTypeID = 111)";
                var dt = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                PopulateNodes(dt, TreeViewAllNode.Nodes);

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
                    var tn = new TreeNode(dr["ActivityName"].ToString(), dr["NodeTypeID"].ToString());
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
                var sqlString = @"select NodeTypeID,ActivityName,(select count(*) FROM UDefaultNodeList WHERE PNodeTypeID=e.NodeTypeID) childnodecount FROM UDefaultNodeList e where PNodeTypeID= " + parentid + "";
                var dt = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                PopulateNodes(dt, parentNode.ChildNodes);
                parentNode.CollapseAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadRoleTypeData(DropDownList ddlRoleType)
        {
            try
            {
                TwoColumnsTableDataController objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                objTwoColumnsTableDataController.LoadRoleType(ddlRoleType);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SaveRoleData(CompanySetup objCompanySetup, UserPermission objUserPermission)
        {
            try
            {
                objUserPermission.RoleID = GetRoleID();
                var storedProcedureComandText = "INSERT INTO [uRoleSetup] ([CompanyID],[RoleID],[RoleTypeID],[RoleName],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objCompanySetup.CompanyID + "," +
                                                 objUserPermission.RoleID + ",'" +
                                                 objUserPermission.RoleType + "','" +
                                                 objUserPermission.RoleName + "','" +
                                                 "A" + "', '" +
                                                 objCompanySetup.EntryUserName + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

                foreach (var itemNo in objUserPermission.nodeList)
                {
                    objUserPermission.NodeID = Convert.ToInt32(itemNo.ToString());
                    var storedProcedureComandTextNode = "INSERT INTO [uRoleSetupDetails] ([RoleID],[NodeID],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objUserPermission.RoleID + "," +
                                                 objUserPermission.NodeID + ",'" +
                                                 "A" + "', '" +
                                                 objCompanySetup.EntryUserName + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextNode);

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetRoleID()
        {
            try
            {
                UserPermission objUserPermission = new UserPermission();
                var storedProcedureComandText = "SELECT ISNULL( MAX( RoleID ),0) +1 FROM [uRoleSetup]";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                return objUserPermission.RoleID = objclsDataManipulation.GetSingleValue(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetRoleRecord(CompanySetup objCompanySetup, UserPermission objUserPermission, GridView targetGridView)
        {
            try
            {
                DataTable dtRoleRecord = null;
                dtRoleRecord = clsDataManipulation.GetData(this.ConnectionString, this.SQLGetRoleRecord(objCompanySetup, objUserPermission));
                targetGridView.DataSource = null;
                targetGridView.DataBind();
                if (dtRoleRecord.Rows.Count > 0)
                {
                    targetGridView.DataSource = dtRoleRecord;
                    targetGridView.DataBind();
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        internal void GetRoleRecord(CompanySetup objCompanySetup, UserPermission objUserPermission, ListBox targetListBox)
        {
            try
            {
                ClsListBoxController.LoadListBox(this.ConnectionString, this.SQLGetRoleRecord(objCompanySetup, objUserPermission), targetListBox, "RoleName", "RoleID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private string SQLGetRoleRecord(CompanySetup objCompanySetup, UserPermission objUserPermission)
        {
            string sqlString = @"  SELECT 
              [RoleID]      
              ,[RoleName]
              ,[RoleTypeID]
          FROM [uRoleSetup] WHERE [DataUsed] = 'A' AND [CompanyID] = " + objCompanySetup.CompanyID + "";
            if (objUserPermission.RoleType != "-1")
            {
                sqlString += " AND [RoleTypeID] = '" + objUserPermission.RoleType + "'";

            }

            sqlString += "  ORDER BY RoleName";
            return sqlString;
        }

        internal void SaveUserRole(EmployeeSetup objEmployeeSetup, UserPermission objUserPermission)
        {
            try
            {
                if (objEmployeeSetup.EmployeeID == null)
                {
                    throw new Exception("User code is required ");

                }

                if (objUserPermission.RoleType == null)
                {
                    throw new Exception("Role type is required ");
                }

                string storedProcedureComandTextNode = null;
                foreach (var itemNo in objUserPermission.roleList)
                {
                    objUserPermission.RoleID = itemNo;
                    storedProcedureComandTextNode += @" INSERT INTO [uUsersInRoles] ([CompanyID],[UserId],[RoleTypeID],[RoleID],[DataUsed],[EntryUserID],[EntryDate]) VALUES(" +
                                                    objEmployeeSetup.CompanyID + ",'" +
                                                    objEmployeeSetup.EmployeeID + "','" +
                                                    objUserPermission.RoleType + "'," +
                                                    objUserPermission.RoleID + ",'" +
                                                    "A" + "','" +
                                                    objEmployeeSetup.EntryUserName + "'," +
                                                    "CAST(GETDATE() AS DateTime)" + ");";
                }

                if (storedProcedureComandTextNode != null)
                {
                    foreach (var itemNo in objUserPermission.RelatedUserRoleList)
                    {
                        TwoColumnTables objTwoColumnTables = new TwoColumnTables();
                        objTwoColumnTables.RelatedUserRoleID = itemNo;
                        storedProcedureComandTextNode += @"INSERT INTO [uUsersInRelatedRoles] ([CompanyID],[UserId],[RoleID],[DataUsed],[EntryUserID],[EntryDate]) VALUES(" +
                        objEmployeeSetup.CompanyID + ",'" +
                        objEmployeeSetup.EmployeeID + "'," +
                        objTwoColumnTables.RelatedUserRoleID + ",'" +
                        "A" + "','" +
                        objEmployeeSetup.EntryUserName + "'," +
                        "CAST(GETDATE() AS DateTime)" + ");";
                    }

                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextNode);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetData(EmployeeSetup objEmployeeSetup)
        {
            try
            {
                string sqlString = @"SELECT DISTINCT D.[NodeTypeID], D.[ActivityName], D.[FormDescription], D.[FormName],D.[PNodeTypeID] FROM uUsersInRoles A
                INNER JOIN uRoleSetup B ON A.RoleID = B.RoleID AND A.RoleTypeID = B.RoleTypeID
                INNER JOIN uRoleSetupDetails C ON B.RoleID = C.RoleID
                INNER JOIN [uDefaultNodeList] D ON C.NodeID = D.NodeTypeID
                WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' AND C.DataUsed = 'A' AND D.DataUsed = 'A' AND A.CompanyID = " + objEmployeeSetup.CompanyID + " AND A.UserId = '" + objEmployeeSetup.EmployeeID + "'";
                var dtEntityDetails = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtEntityDetails;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetUserRoleRecord(EmployeeSetup objEmployeeSetup, UserPermission objUserPermission, ListBox targetListBox)
        {
            try
            {
                ClsListBoxController.LoadListBox(this.ConnectionString, this.SQLGetUserRoleRecord(objEmployeeSetup, objUserPermission), targetListBox, "RoleName", "RoleID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SQLGetUserRoleRecord(EmployeeSetup objEmployeeSetup, UserPermission objUserPermission)
        {
            try
            {
                string sqlString = @"  SELECT A.RoleID,B.RoleName FROM uUsersInRoles A INNER JOIN uRoleSetup B ON A.RoleID = B.RoleID 
                WHERE A.[DataUsed] = 'A' AND A.CompanyID = " + objEmployeeSetup.CompanyID + " AND A.UserId = '" + objEmployeeSetup.EmployeeID + "'";
                if (objUserPermission.RoleType != "-1")
                {
                    sqlString += " AND A.[RoleTypeID] = '" + objUserPermission.RoleType + "'";

                }

                sqlString += "  ORDER BY B.RoleName";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void UpdateUserRole(EmployeeSetup objEmployeeSetup, UserPermission objUserPermission)
        {
            try
            {
                if (objEmployeeSetup.EmployeeID == null)
                {
                    throw new Exception("User code is required ");

                }

                if (objUserPermission.RoleType == null)
                {
                    throw new Exception("Role type is required ");
                }

                string storedProcedureComandTextNode = @" UPDATE [uUsersInRoles] SET [DataUsed] = 'I' ,[LastUpdateDate] = CAST(GETDATE() AS DateTime)
                  ,[LastUpdateUserID] = '" + objEmployeeSetup.EntryUserName + "'" +
                                           " WHERE [CompanyID] = " + objEmployeeSetup.CompanyID + " AND [UserId] = '" + objEmployeeSetup.EmployeeID + "'" +
                                           " AND [RoleTypeID] = '" + objUserPermission.RoleType + "'";
                storedProcedureComandTextNode += @"; UPDATE [uUsersInRelatedRoles] SET [DataUsed] = 'I' ,[LastUpdateDate] = CAST(GETDATE() AS DateTime)
                  ,[LastUpdateUserID] = '" + objEmployeeSetup.EntryUserName + "'" +
                                           " WHERE [CompanyID] = " + objEmployeeSetup.CompanyID + " AND [UserId] = '" + objEmployeeSetup.EmployeeID + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextNode);
                this.SaveUserRole(objEmployeeSetup, objUserPermission);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetNodesOfRole(CompanySetup objCompanySetup, UserPermission objUserPermission)
        {
            try
            {
                DataTable dtNodes = new DataTable();
                string sqlString = @"SELECT DISTINCT A.NodeID FROM uRoleSetupDetails A INNER JOIN uRoleSetup B ON A.RoleID = B.RoleID
                                    WHERE A.DataUsed = 'A' AND B.DataUsed = 'A' AND A.RoleID = " + objUserPermission.RoleID + " AND B.CompanyID = " + objCompanySetup.CompanyID + " ORDER BY A.NodeID";
                dtNodes = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtNodes;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void UpdateRoleData(CompanySetup objCompanySetup, UserPermission objUserPermission)
        {
            try
            {
                string sqlForUpdate = @"UPDATE [uRoleSetup] SET [RoleName] = '" + objUserPermission.RoleName + "',[LastUpdateDate] = CAST(GETDATE() AS DateTime)," +
                                "[LastUpdateUserID] = '" + objCompanySetup.EntryUserName + "' WHERE [CompanyID] = " + objCompanySetup.CompanyID + " AND " +
                                " [RoleID] = 1 AND [RoleTypeID] = '" + objUserPermission.RoleType + "'; " +
                                 " DELETE FROM uRoleSetupDetails WHERE RoleID = " + objUserPermission.RoleID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, sqlForUpdate);

                foreach (var itemNo in objUserPermission.nodeList)
                {
                    objUserPermission.NodeID = Convert.ToInt32(itemNo.ToString());
                    var storedProcedureComandTextNode = "INSERT INTO [uRoleSetupDetails] ([RoleID],[NodeID],[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objUserPermission.RoleID + "," +
                                                 objUserPermission.NodeID + ",'" +
                                                 "A" + "', '" +
                                                 objCompanySetup.EntryUserName + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextNode);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadRelatedUserRoleLB(ListBox ListBoxRelatedUserRole, CompanySetup _objCompanySetup)
        {
            try
            {
                TwoColumnTablesController objTwoColumnTablesController = new TwoColumnTablesController();
                objTwoColumnTablesController.LoadRelatedUserRoleLB(ListBoxRelatedUserRole, _objCompanySetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetRelatedUserRoleRecord(EmployeeSetup objEmployeeSetup, ListBox targetListBox)
        {
            try
            {
                ClsListBoxController.LoadListBox(this.ConnectionString, this.SQLGetRelatedUserRoleRecord(objEmployeeSetup), targetListBox, "RelatedToText", "RoleID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string SQLGetRelatedUserRoleRecord(EmployeeSetup objEmployeeSetup)
        {
            try
            {
                string sqlString = null;
                sqlString = @"SELECT DISTINCT A.[RoleID],B.RelatedToText FROM [uUsersInRelatedRoles] A INNER JOIN sysRelatedUserRole B ON A.CompanyID = B.CompanyID
                            AND A.RoleID = B.RelatedToID WHERE A.DataUsed = 'A' AND A.[CompanyID] = " + objEmployeeSetup.CompanyID + " AND A.UserId = '" + objEmployeeSetup.EmployeeID + "'" +
                            " ORDER BY B.RelatedToText";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}