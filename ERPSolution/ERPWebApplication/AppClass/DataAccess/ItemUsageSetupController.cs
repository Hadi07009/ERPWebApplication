using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ItemUsageSetupController
    {
        public string ItemUsageSql(CompanySetup objCompanySetup, BranchSetup objBranchSetup)
        {
            string sqlString = null;
            sqlString = "SELECT ItemUsageID,ItemUsage FROM matMatUsagePurposeSetup WHERE CompanyID = '" + objCompanySetup.CompanyID + "' AND BranchID = '" + objBranchSetup.BranchID + "' ORDER BY ItemUsage";
            return sqlString;
        }
    }
}