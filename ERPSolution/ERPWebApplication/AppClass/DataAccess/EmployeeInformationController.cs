using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class EmployeeInformationController
    {
        public EmployeeInformationController()
        { 
        
        }

        public static string GetEmployeeDetail(int companyID,int branchID)
        {
            return "SELECT EmployeeID, FullName, DisplayName, PrimaryContactNo FROM  hrEmployeeSetup where CompanyID=" + companyID + " and BranchID=" + branchID + " order by FullName";
        }

        public static string GetEmployeeDetailSearch(string keybal, int companyID, int branchID)
        {
            return "SELECT EmployeeID, FullName, DisplayName, PrimaryContactNo FROM  hrEmployeeSetup where (EmployeeID Like '" + keybal + "') OR (FullName Like '" + keybal + "') and CompanyID=" + companyID + " and BranchID=" + branchID + "";
        }
        public static string GetEmployeeDetailByEmpID(string empID, int companyID, int branchID)
        {
            return "SELECT EmployeeID, FullName, DisplayName, PrimaryContactNo FROM  hrEmployeeSetup where EmployeeID='" + empID + "' and  CompanyID=" + companyID + " and BranchID=" + branchID + " order by FullName";
        }



    }
}