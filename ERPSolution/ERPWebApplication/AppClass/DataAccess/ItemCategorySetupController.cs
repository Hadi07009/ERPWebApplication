using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.CommonClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ItemCategorySetupController
    {
        public void Save(string connectionString, ItemCategorySetup objItemCategorySetup)
        {
            try
            {
                var storedProcedureComandTest = "exec [spInitiatematCategoryList] " +
                                        objItemCategorySetup.CompanyID + "," +
                                        objItemCategorySetup.BranchID + "," +
                                        objItemCategorySetup.CategoryTypeID + "," +
                                        objItemCategorySetup.ItemCategoryID + ",'" +
                                        objItemCategorySetup.CategoryName + "'," +
                                        objItemCategorySetup.ParentCategoryID + "," +
                                        objItemCategorySetup.StartingItemCode + "," +
                                        objItemCategorySetup.EndingItemCode + "," +
                                        objItemCategorySetup.SeqNo + "," +
                                        objItemCategorySetup.TierNo + "," +
                                        objItemCategorySetup.CurrentBalance + ",'" +
                                        objItemCategorySetup.DataUsed + "','" +
                                        objItemCategorySetup.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);

            }
            catch (SqlException msgException)
            {
                throw msgException;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        internal void GetCategory(string connectionString, DropDownList ddlCategory)
        {
            try
            {
                string sql = "SELECT DISTINCT CategoryName,ItemCategoryID FROM [matCategoryList] WHERE DataUsed = 'A' ORDER BY ItemCategoryID";
                ClsDropDownListController.LoadDropDownList(connectionString, sql, ddlCategory, "CategoryName", "ItemCategoryID");
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable CheckItem(string connectionString, ItemCategorySetup objItemCategorySetup)
        {
            try
            {
                DataTable dtItem = null;
                string sqlString = "SELECT * FROM matMaterialSetup WHERE DataUsed = 'A' AND ItemCategoryID = " + objItemCategorySetup.ItemCategoryID + " OR ItemID = " + objItemCategorySetup.ItemCategoryID + "";
                dtItem = clsDataManipulation.GetData(connectionString, sqlString);
                return dtItem;

            }
            catch (SqlException msgException)
            {
                throw msgException;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}