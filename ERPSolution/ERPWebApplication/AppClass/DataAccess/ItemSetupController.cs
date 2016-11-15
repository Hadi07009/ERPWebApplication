using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ItemSetupController
    {
        internal void Save(string connectionString, ItemSetup objItemSetup, ItemCategorySetup objItemCategorySetup)
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
                                        objItemSetup.EntryUserName + "',"+
                                        objItemCategorySetup.CompanyID + "," +
                                        objItemCategorySetup.BranchID + "," +
                                        objItemCategorySetup.CategoryTypeID + ",'" +                                        
                                        objItemCategorySetup.CategoryName + "'," +
                                        objItemCategorySetup.ParentCategoryID + "," +
                                        objItemCategorySetup.StartingItemCode + "," +
                                        objItemCategorySetup.EndingItemCode + "," +
                                        objItemCategorySetup.SeqNo + "," +
                                        objItemCategorySetup.TierNo + "," +
                                        objItemCategorySetup.CurrentBalance + ",'" +
                                        objItemCategorySetup.DataUsed + "'";
                StoredProcedureExecutor.StoredProcedureExecuteNonQuery(connectionString, storedProcedureComandTest);
                //ItemCategorySetupController objItemCategorySetupController = new ItemCategorySetupController();
                //objItemCategorySetupController.Save(connectionString, objItemCategorySetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}