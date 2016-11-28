using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ItemDetailController
    {
        public ItemDetailController()
        { 
        
        }

        public static string GetItemDetail(int companyID, int branchID)
        {
            return "SELECT * FROM  matMaterialSetup where  CompanyID=" + companyID + " and branchID="+branchID+"";
        }


        public static string GetItemDetailSearch(string keybal, int companyID, int branchID)
        {
            return "SELECT  ItemCode, ModelNo FROM matMaterialSetup where (ItemCode Like '" + keybal + "') OR (ModelNo Like '" + keybal + "') and CompanyID=" + companyID + " and BranchID="+branchID+" ";
        }



        public static string GetItemUnit(string itemId,int companyID,int branchID)
        {
            return "select a.ItemID,a.ItemCode,b.UnitID,b.Unit,b.DataUsed from matMaterialSetup a "

               + " inner join matUnitSetup b on a.UnitID=b.UnitID where (a.ItemCode= " + Convert.ToInt32(itemId) + " and b.CompanyID=" + companyID + " and b.branchID="+branchID+")";
        }

    }
}