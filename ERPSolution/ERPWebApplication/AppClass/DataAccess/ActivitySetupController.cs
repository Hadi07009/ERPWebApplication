using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ActivitySetupController
    {

        public ActivitySetupController()
        {
        }


        public static string GetDataActivitySetup(int companyID, int branchID)
        {
            string sqlForRefType;
            sqlForRefType = "select KnownByID,ActivityName from sysActivitySetup where KnownByID=10 and CompanyID=" + companyID + " and BranchID=" + branchID + "";
            return sqlForRefType;
        }




    }
}