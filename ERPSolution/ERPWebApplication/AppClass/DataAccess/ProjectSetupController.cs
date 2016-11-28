using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ProjectSetupController
    {
        public ProjectSetupController()
        { 
        }

        public static string GetDataProjectSetup(int companyID,int branchID)
        {
            string sqlForProjectID;
            sqlForProjectID = " SELECT ProjectID , ProjectName , Descriptions , ProjectStatusID FROM pmProjectSetup  where CompanyID="+companyID+" and BranchID="+branchID+" and  ProjectStatusID=1 order by ProjectName";
            return sqlForProjectID;
        }

    }
}