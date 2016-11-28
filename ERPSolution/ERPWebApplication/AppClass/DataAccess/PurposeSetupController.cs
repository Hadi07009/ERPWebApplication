using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class PurposeSetupController
    {


        public PurposeSetupController()
        { 
        
        }
        public static string GetDataPurposeSetup(int companyID, int branchID)
        {

            try
            {

                string sqlForPurpose;
                sqlForPurpose = " select ItemUsageID,ItemUsage,DataUsed from matMatUsagePurposeSetup where CompanyID=" + companyID + " and BranchID=" + branchID + " order by ItemUsage";
                return sqlForPurpose;
            }

            catch(Exception ex)
            {
                return  ex.Message;
            
            }
        }


    }
}