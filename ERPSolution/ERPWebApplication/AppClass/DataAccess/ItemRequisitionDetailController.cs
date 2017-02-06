using ERPWebApplication.CommonClass;
using ERPWebApplication.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ItemRequisitionDetailController:DataAccessBase 
    {

        public ItemRequisitionDetailController()
        { 
        
        }

        public  bool SqlInsertDet(SqlCommand cmd, RequisitionDetail det, List<RequisitionDetail> itemdet)
        {


            string sql = "";
            bool retflag = true;

            foreach (RequisitionDetail itm in itemdet)
            {
                sql = "INSERT INTO [ItemRequisitionDetail] ([ItemRequisitionNo],[InventoryItemID],[RequiredItemName],[RequestedQuantity],[FinalQuantity],[UnitID],[PossibleRate],[FinalRate],[CountryOfOrigin],[Specification],[Brand]) VALUES ('" + itm.ItemRequisitionNo + "'," + itm.InventoryItemID + ",'" + itm.RequiredItemName + "'," + itm.RequestedQuantity + "," + itm.FinalQuantity + "," + itm.UnitID + "," + itm.PossibleRate + "," + itm.FinalRate + ",'" + itm.CountryOfOrigin + "','" + itm.Specification + "','" + itm.Brand + "')";

                if (!clsDataManipulation.ExecuteSqlCommand(cmd, sql))
                {
                    retflag = false;
                    goto errorhand;
                }
            }

        errorhand:
            return retflag;

        }

     
       
        public  bool DeleteRequisitionDetByRequisitionNo(SqlCommand cmd, RequisitionDetail det)
        {
            string sql = "";
            bool retflag = true;


            sql = "Delete from  [ItemRequisitionDetail] where ItemRequisitionNo= '" + det.ItemRequisitionNo + "'";

            if (!DataProcess.ExecuteSqlCommand(cmd, sql))
            {
                retflag = false;
                goto errorhand;
            }


        errorhand:
            return retflag;

        }



        public static string SqlInsertDet(RequisitionDetail det)
        {
            string sql;
            return sql = "INSERT INTO [ItemRequisitionDetail] ([ItemRequisitionNo],[InventoryItemID],[RequiredItemName],[RequestedQuantity],[FinalQuantity],[UnitID],[PossibleRate],[FinalRate],[CountryOfOrigin],[Specification],[Brand]) VALUES ('" + det.ItemRequisitionNo + "'," + det.InventoryItemID + ",'" + det.RequiredItemName + "'," + det.RequestedQuantity + "," + det.FinalQuantity + "," + det.UnitID + "," + det.PossibleRate + "," + det.FinalRate + ",'" + det.CountryOfOrigin + "','" + det.Specification + "','" + det.Brand + "')";

        }



        internal DataTable GetDataRequisitionDet(string requisitionNo)
        {
            try
            {
                DataTable dtrequisitionDet = null;
                var storedProcedureComandText = "   SELECT  det.InventoryItemID, det.RequiredItemName, det.RequestedQuantity, det.FinalQuantity, det.UnitID,"
             + " det.PossibleRate, det.FinalRate, det.CountryOfOrigin, det.Specification, det.Brand,  un.Unit FROM  ItemRequisitionDetail det"
             + " INNER JOIN  matUnitSetup un ON det.UnitID = un.UnitID where ItemRequisitionNo='" + requisitionNo + "'";
                dtrequisitionDet = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtrequisitionDet;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        public string ShowRequisitionItems(int companyID, int branchID)
        {

            string sql = " SELECT * FROM ItemRequisitionDetail";

            return sql;

        }

        public DataTable  GetDataByItemDet(int itemId,int companyID,int branchID)
        {
          
            DataTable dtItemDet = null;
            try
            {
                var storedProcedureComandText = ShowRequisitionItems(companyID,branchID) + " where  InventoryItemID  =" + itemId + "";
                dtItemDet = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtItemDet;
            }

            catch (Exception msgException)
            {

                throw msgException;
            }
           
        }


        public  DataTable  GetDataByItemDet(string  itemId)
        {
            int itemcode;
            DataTable dtItemDet = null;
            try
            {
                itemcode = Convert.ToInt32(itemId);
            }

            catch
            {
                itemcode = 0;
            
            }
            var storedProcedureComandText = "  SELECT * FROM matMaterialSetup where  ItemID  =" + itemcode + "";
            dtItemDet = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
            return dtItemDet;
        }


       
  
    }
}