using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class PersonTypeSetupController
    {

        public PersonTypeSetupController()
        { 
        
        }


        public static string GetDataPersonTypeSetup(int companyID ,int branchID)
        {
            string sqlForPersonType;
            sqlForPersonType = " SELECT  PersonTypeID, PersonType, DataUsed FROM   TypeOfPersonSetup  where CompanyID=" + companyID + " and BranchID=" + branchID + " order by PersonType ";
            return sqlForPersonType;
        }
    }
}