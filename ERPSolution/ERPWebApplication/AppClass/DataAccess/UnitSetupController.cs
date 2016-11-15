using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class UnitSetupController
    {
        public string UnitSql(CompanySetup objCompanySetup, BranchSetup objBranchSetup)
        {
            string sqlString = null;
            sqlString = "SELECT UnitID,Unit FROM matUnitSetup WHERE CompanyID = '" + objCompanySetup.CompanyID + "' AND BranchID = '" + objBranchSetup.BranchID + "' ORDER BY Unit";
            return sqlString;
        }
    }
}