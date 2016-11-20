using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class SuppliersController
    {
        public string SQLGetAllSuppliers(CompanySetup objCompanySetup, BranchSetup objBranchSetup)
        {
            string sqlString = null;
            sqlString = "SELECT ContactID,FullName FROM [AllSuppliers] WHERE CompanyID = " + objCompanySetup.CompanyID + " AND BranchID = " + objBranchSetup.BranchID + " ORDER BY FullName";
            return sqlString;
        }
    }
}