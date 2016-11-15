using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.CommonClass
{
    public class SqlGenerationForItemDetail
    {

        public SqlGenerationForItemDetail()
        { 
        }

        public static string GetItemDetail()
        {
            return "SELECT * FROM  matMaterialSetup";
        }


         public static string GetItemDetailSearch(string  keybal)
        {
            return "SELECT  ItemCode, ModelNo FROM matMaterialSetup where (ItemCode Like '" + keybal + "') OR (ModelNo Like '" + keybal + "')";
        }



         public static string GetItemUnit(string itemId)
         {
             return "select matMaterialSetup.ItemID,matMaterialSetup.ItemCode,matUnitSetup.UnitID,matUnitSetup.Unit,matUnitSetup.DataUsed from matMaterialSetup "

                + " inner join matUnitSetup on matMaterialSetup.UnitID=matUnitSetup.UnitID where (ItemCode= " + Convert.ToInt32(itemId)+ ")";
         }







       

    }
}