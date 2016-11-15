using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.CommonClass
{
    public class SqlGenerationForEmployee
    {


        public SqlGenerationForEmployee()
        { 
        }
        public static string GetEmployeeDetail()
        {
            return "SELECT EmployeeID, FullName, DisplayName, PrimaryContactNo FROM  hrEmployeeSetup";
        }

        public static string GetEmployeeDetailSearch(string keybal)
        {
            return "SELECT EmployeeID, FullName, DisplayName, PrimaryContactNo FROM  hrEmployeeSetup where (EmployeeID Like '" + keybal + "') OR (FullName Like '" + keybal + "')";
        }

    }
}