using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ItemTypeSetupController
    {
        public string ItemTypeSql(CompanySetup objCompanySetup, BranchSetup objBranchSetup)
        {
            string sqlString = null;
            sqlString = "SELECT ItemTypeID,ItemType FROM matItemTypeSetup WHERE DataUsed = 'A' AND CompanyID = '" + objCompanySetup.CompanyID + "' AND BranchID = '" + objBranchSetup.BranchID + "' ORDER BY ItemType";
            return sqlString;
        }
    }
}