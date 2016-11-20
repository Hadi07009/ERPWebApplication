using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ItemSetupController
    {
        internal void Save(string connectionString, ItemSetup objItemSetup)
        {
            try
            {
                var storedProcedureComandTest = "exec [spInitiatematMaterialSetup] " +
                                        objItemSetup.ItemID + "," +
                                        objItemSetup.ItemCategoryID + "," +
                                        objItemSetup.ItemTypeID + "," +
                                        objItemSetup.ItemPropertySetID + "," +
                                        objItemSetup.ItemUsageID + ",'" +
                                        objItemSetup.ModelNo + "'," +
                                        objItemSetup.UnitID + ",'" +
                                        objItemSetup.HsCode + "','" +
                                        objItemSetup.ItemCode + "','" +
                                        objItemSetup.Specification + "'," +
                                        objItemSetup.OpenningBalance + ",'" +
                                        objItemSetup.SupplierID + "'," +
                                        objItemSetup.IsVATAbleItem + "," +
                                        objItemSetup.CoaSalesAccNo + "," +
                                        objItemSetup.CoaStockAccNo + "," +
                                        objItemSetup.CoacgsAccNo + "," +
                                        objItemSetup.CoaSalesRetAccNo + ",'" +
                                        objItemSetup.EntryUserName + "'," +
                                        objItemSetup.BreakUpQuantity + ",'" +
                                        objItemSetup.ReOrderLevel + "',"+
                                        objItemSetup.BreakUpUnitD+","+
                                        objItemSetup.MinimumQuantity;
                StoredProcedureExecutor.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        public string SQLForAccountType(ItemCategorySetup objItemCategorySetup)
        {
            string sqlString = null;
            sqlString = @"SELECT B.AccountNo,B.AccountName FROM accCOAAccountTypeSetup A INNER JOIN accCOAHeadSetup B ON A.AccountTypeID = B.AccountTypeID
                                WHERE  A.KnownValueID = " + objItemCategorySetup.KnownValueID + " AND A.CompanyID = " + objItemCategorySetup.CompanyID + " AND A.BranchID = " + objItemCategorySetup.BranchID + "";
            return sqlString;
        }

    }
}