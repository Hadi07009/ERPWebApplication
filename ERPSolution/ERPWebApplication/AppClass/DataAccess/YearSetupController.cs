using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class YearSetupController : DataAccessBase
    {
        internal void Save(YearSetup objYearSetup)
        {
            try
            {
                objYearSetup.UseChartOfAccNo = this.GetChartOfAccNo();
                objYearSetup.YearOpen = 1;

                objYearSetup.YearOpeningID = Convert.ToInt32(objYearSetup.CompanyID.ToString() + objYearSetup.BranchID.ToString() + Convert.ToDateTime( objYearSetup.BeginningYear).ToString("yy") + objYearSetup.UseChartOfAccNo.ToString("00"));
                var storedProcedureComandText = "INSERT INTO [xSysYearSetup] ([YearOpeningID],[CompanyID],[BranchID],[BeginningYear],[EndingYear],[YearOpenBy],[YearOpen] " +
                                                " ,[UseChartOfAccNo],[EntryDate],[EntryUserID],[Dataused]) VALUES ( " +
                " " + objYearSetup.YearOpeningID + "," +
                " " + objYearSetup.CompanyID + "," +
                "" + objYearSetup.BranchID + "," +
                "CONVERT(DATETIME,'" + objYearSetup.BeginningYear + "',103)," +
                "CONVERT(DATETIME,'" + objYearSetup.EndingYear + "',103)," +
                "'" + objYearSetup.YearOpenBy + "'," +
                "" + objYearSetup.YearOpen + "," +
                "" + objYearSetup.UseChartOfAccNo + "," +
                "CAST(GETDATE() AS DateTime)," +
                "'" + objYearSetup.EntryUserName + "'," +
                "'A');";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetChartOfAccNo()
        {
            try
            {
                int chartOfAccNo = 0;
                var storedProcedureComandText = "SELECT ISNULL( MAX( UseChartOfAccNo),0) +1  FROM xSysYearSetup";
                chartOfAccNo = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return chartOfAccNo;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetLastOpenYearData()
        {
            try
            {
                var sqlString = @"  SELECT BeginningYear,EndingYear FROM xSysYearSetup  WHERE YearOpen = 1 AND Dataused = 'A' AND 
                    UseChartOfAccNo = (SELECT MAX(UseChartOfAccNo) FROM xSysYearSetup WHERE YearOpen = 1 AND Dataused = 'A')";
                var dtLastOpenYear = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtLastOpenYear;

            }
            catch (Exception msgException)
            {
                
                throw msgException; 
            }
        }
    }
}