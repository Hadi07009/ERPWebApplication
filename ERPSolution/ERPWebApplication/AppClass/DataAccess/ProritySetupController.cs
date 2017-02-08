using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ProritySetupController:DataAccessBase
    {
        public ProritySetupController()
        { 
        
        }


        public string SqlGetPriority()
        {
            try
            {
                string sqlString = null;
//                sqlString = @"SELECT [CountryID]
//                              ,[CountryName]      
//                          FROM [gCountryList] WHERE [DataUsed] = 'A'";

                sqlString = @"SELECT  p.CompanyID, p.BranchID, p.ActivityID, p.PriorityID, p.PriorityName, s.KnownByID, s.ActivityName, s.DataUsed AS dataused FROM  PrioritySetupActivityWise AS p INNER JOIN  sysActivitySetup AS s ON p.ActivityID = s.ActivityID WHERE (s.KnownByID ='10')";


                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }



        public void LoadPriority(DropDownList ddlPrioritySearch)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlGetPriority(), ddlPrioritySearch, "PriorityName", "PriorityID");

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }



        public static string GetDataPriority(int companyID,int branchID)
        {
            string sqlForPriority;
            sqlForPriority = "SELECT  p.CompanyID, p.BranchID, p.ActivityID, p.PriorityID, p.PriorityName, s.KnownByID, s.ActivityName, s.DataUsed AS dataused FROM  PrioritySetupActivityWise AS p INNER JOIN  sysActivitySetup AS s ON p.ActivityID = s.ActivityID WHERE (s.KnownByID = 10 and s.CompanyID=" + companyID + " and s.BranchID=" + branchID + ")";
            return sqlForPriority;
        }

    }
}