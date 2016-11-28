using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class DepartmentSetupController
    {
        public DepartmentSetupController()
        { 
        
        }

        public static string GetDataDepartmentSetup(int companyID, int branchID)
        {
            string sqlForDepartment;
            sqlForDepartment = "SELECT  CompanyID, BranchID, DepartmentID, DepartmentName, DataUsed FROM oDepartmentSetup where companyID=" + companyID + " and BranchID="+branchID+" order by DepartmentName ";
            return sqlForDepartment;
        }
    }
}