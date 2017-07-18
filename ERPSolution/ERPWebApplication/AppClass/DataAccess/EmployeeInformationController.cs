using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class EmployeeInformationController : DataAccessBase
    {
        public EmployeeInformationController()
        {

        }

        public static string GetEmployeeDetail(int companyID, int branchID)
        {
            return "SELECT EmployeeID, FullName, DisplayName, PrimaryContactNo FROM  hrEmployeeSetup where CompanyID=" + companyID + " and BranchID=" + branchID + " order by FullName";
        }

        public static string GetEmployeeDetailSearch(string keybal, int companyID, int branchID)
        {
            return "SELECT EmployeeID, FullName, DisplayName, PrimaryContactNo FROM  hrEmployeeSetup where (EmployeeID Like '" + keybal + "') OR (FullName Like '" + keybal + "') and CompanyID=" + companyID + " and BranchID=" + branchID + "";
        }

        public DataTable GetEmployeeDetailByEmpID(string empID, int companyID, int branchID)
        {

            try
            {
                DataTable dtEmployee = null;
                var storedProcedureComandText = "SELECT EmployeeID, FullName, DisplayName, PrimaryContactNo FROM  hrEmployeeSetup where EmployeeID='" + empID + "' and  CompanyID=" + companyID + " and BranchID=" + branchID + " order by FullName";
                dtEmployee = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtEmployee;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }




        internal string GetEmployeeEmail(EmployeeSetup objEmployeeSetup)
        {
            try
            {
                string sql = " SELECT [Email]  FROM [hrEmployeeSetup] WHERE CompanyID = " + objEmployeeSetup.CompanyID + " AND DataUsed ='A' AND EmployeeID = '" + objEmployeeSetup.EmployeeID + "'";
                EmployeeDetailsSetup objEmployeeDetailsSetup = new EmployeeDetailsSetup();
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                return objEmployeeDetailsSetup.Email = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, sql);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}