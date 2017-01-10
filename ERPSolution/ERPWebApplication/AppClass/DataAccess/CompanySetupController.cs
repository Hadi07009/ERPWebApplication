using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class CompanySetupController : DataAccessBase
    {
        internal void LoadCountry(DropDownList ddlCountry)
        {
            try
            {
                CountrySetupController objCountrySetupController = new CountrySetupController();
                objCountrySetupController.LoadCountry(ddlCountry);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void Save(CompanyDetailsSetup objCompanyDetailsSetup)
        {
            try
            {
                if (objCompanyDetailsSetup.CountryID == -1)
                {
                    throw new Exception(" country name is required ");

                }


                objCompanyDetailsSetup.CompanyID = this.GetMaxCompanyID();
                var storedProcedureComandText = "INSERT INTO [comCompanySetup] ([CompanyID],[CountryID],[CompanyName],[CompanyMobile],[CompanyEmail],[CompanyLogo] " +
                                                " ,[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objCompanyDetailsSetup.CompanyID + "," +
                                                 objCompanyDetailsSetup.CountryID + ", '" +
                                                 objCompanyDetailsSetup.CompanyName + "', '" +
                                                 objCompanyDetailsSetup.CompanyMobile + "', '" +
                                                 objCompanyDetailsSetup.CompanyEmail + "', '" +
                                                 objCompanyDetailsSetup.CompanyLogo + "', '" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetMaxCompanyID()
        {
            try
            {
                int companyID = 0;
                var storedProcedureComandText = "SELECT ISNULL( MAX( [CompanyID]),0) +1  FROM [comCompanySetup]";
                companyID = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return companyID;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        internal DataTable GetCompanyDetails()
        {
            try
            {
                DataTable dtCompany = null;
                var storedProcedureComandText = @"SELECT A.[CompanyID]
                                              ,A.[CountryID]
                                              ,A.[CompanyName]
                                              ,A.[CompanyMobile]
                                              ,A.[CompanyEmail]
                                              ,B.CountryName
                                          FROM [comCompanySetup] A 
                                          INNER JOIN gCountryList B ON A.CountryID = B.CountryID
                                          WHERE A.DataUsed = 'A'
                                          ORDER BY A.[CompanyName]";
                dtCompany = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtCompany;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        internal void Delete(CompanyDetailsSetup objCompanyDetailsSetup)
        {
            try
            {
                var storedProcedureComandText = "UPDATE [comCompanySetup] SET DataUsed	= 'I' WHERE CompanyID = " + objCompanyDetailsSetup.CompanyID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        internal void Update(CompanyDetailsSetup objCompanyDetailsSetup)
        {
            try
            {
                if (objCompanyDetailsSetup.CountryID == -1)
                {
                    throw new Exception(" country name is required ");

                }


                var storedProcedureComandText = "UPDATE [comCompanySetup] " +
                                           " SET [CountryID] = ISNULL(" + objCompanyDetailsSetup.CompanyID + ",[CountryID]) " +
                                              " ,[CompanyName] = ISNULL('" + objCompanyDetailsSetup.CompanyName + "',[CompanyName]) " +
                                              " ,[CompanyMobile] = ISNULL('" + objCompanyDetailsSetup.CompanyMobile + "',[CompanyMobile]) " +
                                              " ,[CompanyEmail] = ISNULL('" + objCompanyDetailsSetup.CompanyEmail + "',[CompanyEmail]) " +
                                              " ,[CompanyLogo] = ISNULL('" + objCompanyDetailsSetup.CompanyLogo + "',[CompanyLogo]) " +
                                              " ,[LastUpdateDate] = CAST(GETDATE() AS DateTime) " +
                                              " ,[LastUpdateUserID] = '160ea939-7633-46a8-ae49-f661d12abfd5' " +
                                          " WHERE [CompanyID] = " + objCompanyDetailsSetup.CompanyID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
    }
}