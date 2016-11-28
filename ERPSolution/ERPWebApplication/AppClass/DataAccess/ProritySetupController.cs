using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ProritySetupController
    {
        public ProritySetupController()
        { 
        
        }

        public static string GetDataPriority(int companyID,int branchID)
        {
            string sqlForPriority;
            sqlForPriority = "SELECT  p.CompanyID, p.BranchID, p.ActivityID, p.PriorityID, p.PriorityName, s.KnownByID, s.ActivityName, s.DataUsed AS dataused FROM  PrioritySetupActivityWise AS p INNER JOIN  sysActivitySetup AS s ON p.ActivityID = s.ActivityID WHERE (s.KnownByID = 10 and s.CompanyID=" + companyID + " and s.BranchID=" + branchID + ")";
            return sqlForPriority;
        }

    }
}