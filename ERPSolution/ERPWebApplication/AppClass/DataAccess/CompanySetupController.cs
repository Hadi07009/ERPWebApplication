using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ERPWebApplication.CommonClass;
using ERPWebApplication.AppClass.CommonClass;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class CompanySetupController : DataAccessBase
    {
        private OrganizationalChartSetupController _objOrganizationalChartSetupController;
        private OrganizationalChartSetup _objOrganizationalChartSetup;
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
                var storedProcedureComandText = "INSERT INTO [comCompanySetup] ([CompanyID],[CountryID],[CompanyName],[CompanyMobile],[CompanyEmail] " +
                                                " ,[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                                                 objCompanyDetailsSetup.CompanyID + "," +
                                                 objCompanyDetailsSetup.CountryID + ", '" +
                                                 objCompanyDetailsSetup.CompanyName + "', '" +
                                                 objCompanyDetailsSetup.CompanyMobile + "', '" +
                                                 objCompanyDetailsSetup.CompanyEmail + "', '" +
                                                 "A" + "', '" +
                                                 "160ea939-7633-46a8-ae49-f661d12abfd5" + "'," +
                                                 "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
                if (objCompanyDetailsSetup.CompanyLogo != null)
                {
                    this.UpdateLogo(objCompanyDetailsSetup);

                }

                SaveCompanyChart(objCompanyDetailsSetup);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void SaveCompanyChart(CompanyDetailsSetup objCompanyDetailsSetup)
        {
            try
            {
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                objCompanyDetailsSetup.EntryUserName = "160ea939-7633-46a8-ae49-f661d12abfd5";
                _objOrganizationalChartSetup.CompanyID = objCompanyDetailsSetup.CompanyID;
                _objOrganizationalChartSetup.ParentEntityID = 111;
                _objOrganizationalChartSetup.EntityID = objCompanyDetailsSetup.CompanyID;
                _objOrganizationalChartSetup.AddressTag = "N";
                _objOrganizationalChartSetup.AddressID = objCompanyDetailsSetup.CompanyID;
                _objOrganizationalChartSetup.EntityName = objCompanyDetailsSetup.CompanyName;
                _objOrganizationalChartSetup.EntityTypeID = 1;
                _objOrganizationalChartSetup.EntryUserName = objCompanyDetailsSetup.EntryUserName;
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.SaveChart(_objOrganizationalChartSetup);

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

                DeleteCompanyChart(objCompanyDetailsSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private void DeleteCompanyChart(CompanyDetailsSetup objCompanyDetailsSetup)
        {
            try
            {
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                _objOrganizationalChartSetup.EntityID = objCompanyDetailsSetup.CompanyID;
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.DeleteChart(_objOrganizationalChartSetup);

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
                                           " SET [CountryID] = ISNULL(" + objCompanyDetailsSetup.CountryID + ",[CountryID]) " +
                                              " ,[CompanyName] = ISNULL('" + objCompanyDetailsSetup.CompanyName + "',[CompanyName]) " +
                                              " ,[CompanyMobile] = ISNULL('" + objCompanyDetailsSetup.CompanyMobile + "',[CompanyMobile]) " +
                                              " ,[CompanyEmail] = ISNULL('" + objCompanyDetailsSetup.CompanyEmail + "',[CompanyEmail]) " +
                                              " ,[LastUpdateDate] = CAST(GETDATE() AS DateTime) " +
                                              " ,[LastUpdateUserID] = '160ea939-7633-46a8-ae49-f661d12abfd5' " +
                                          " WHERE [CompanyID] = " + objCompanyDetailsSetup.CompanyID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
                if (objCompanyDetailsSetup.CompanyLogo != null)
                {
                    this.UpdateLogo(objCompanyDetailsSetup);

                }

                UpdateCompanyChart(objCompanyDetailsSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private void UpdateCompanyChart(CompanyDetailsSetup objCompanyDetailsSetup)
        {
            try
            {
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                objCompanyDetailsSetup.EntryUserName = "160ea939-7633-46a8-ae49-f661d12abfd5";
                _objOrganizationalChartSetup.EntityID = objCompanyDetailsSetup.CompanyID;
                _objOrganizationalChartSetup.EntityName = objCompanyDetailsSetup.CompanyName;
                _objOrganizationalChartSetup.EntryUserName = objCompanyDetailsSetup.EntryUserName;
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.UpdateChart(_objOrganizationalChartSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        internal void UpdateLogo(CompanyDetailsSetup objCompanyDetailsSetup)
        {
            try
            {
                SqlConnection con = null;
                con = new SqlConnection(this.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE [comCompanySetup] SET CompanyLogo = @CompanyLogo WHERE CompanyID = @CompanyID";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@CompanyLogo", objCompanyDetailsSetup.CompanyLogo);
                cmd.Parameters.AddWithValue("@CompanyID", objCompanyDetailsSetup.CompanyID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        internal DataTable GetLogo(CompanyDetailsSetup objCompanyDetailsSetup)
        {
            try
            {
                DataTable dtLogo = null;
                var storedProcedureComandText = @"select CompanyLogo from [comCompanySetup] WHERE CompanyID = '" + objCompanyDetailsSetup.CompanyID + "'";
                dtLogo = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtLogo;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        internal void UpdateByUser(CompanyDetailsSetup objCompanyDetailsSetup, BusinessType objBusinessType, OwnershipType objOwnershipType, DistrictSetup objDistrictSetup)
        {
            try
            {
                var storedProcedureComandText = "UPDATE [comCompanySetup] " +
                                           " SET [CompanyShortName] = ISNULL('" + objCompanyDetailsSetup.CompanyShortName + "',[CompanyShortName]) " +
                                              " ,[CompanySlogun] = ISNULL('" + objCompanyDetailsSetup.CompanySlogun + "',[CompanySlogun]) " +
                                              " ,[House] = ISNULL('" + objCompanyDetailsSetup.House + "',[House]) " +
                                              " ,[Road] = ISNULL('" + objCompanyDetailsSetup.Road + "',[Road]) " +
                                              " ,[Sector] = ISNULL('" + objCompanyDetailsSetup.Sector + "',[Sector]) " +
                                              " ,[Landmark] = ISNULL('" + objCompanyDetailsSetup.Landmark + "',[Landmark]) " +
                                              " ,[ContactPersonName] = ISNULL('" + objCompanyDetailsSetup.ContactPersonName + "',[ContactPersonName]) " +
                                              " ,[ContactPersonDesignation] = ISNULL('" + objCompanyDetailsSetup.ContactPersonDesignation + "',[ContactPersonDesignation]) " +
                                              " ,[ContactPersonContactNumber] = ISNULL('" + objCompanyDetailsSetup.ContactPersonContactNumber + "',[ContactPersonContactNumber]) " +
                                              " ,[AlternateContactPersonName] = ISNULL('" + objCompanyDetailsSetup.AlternateContactPersonName + "',[AlternateContactPersonName]) " +
                                              " ,[AlternateContactPersonDesignation] = ISNULL('" + objCompanyDetailsSetup.AlternateContactPersonDesignation + "',[AlternateContactPersonDesignation]) " +
                                              " ,[AlternateContactPersonContactNumber] = ISNULL('" + objCompanyDetailsSetup.AlternateContactPersonContactNumber + "',[AlternateContactPersonContactNumber]) " +
                                              " ,[CompanyPhones] = ISNULL('" + objCompanyDetailsSetup.CompanyPhones + "',[CompanyPhones]) " +
                                              " ,[CompanyFax] = ISNULL('" + objCompanyDetailsSetup.CompanyFax + "',[CompanyFax]) " +
                                              " ,[CompanyURL] = ISNULL('" + objCompanyDetailsSetup.CompanyURL + "',[CompanyURL]) " +
                                              " ,[LicenceID] = ISNULL(" + objCompanyDetailsSetup.LicenceID + ",[LicenceID]) " +
                                              " ,[FaceBookID] = ISNULL('" + objCompanyDetailsSetup.FaceBookID + "',[FaceBookID]) " +
                                              " ,[LinkedInID] = ISNULL('" + objCompanyDetailsSetup.LinkedInID + "',[LinkedInID]) " +
                                              " ,[TwitterID] = ISNULL('" + objCompanyDetailsSetup.TwitterID + "',[TwitterID]) " +
                                              " ,[YouTubeID] = ISNULL('" + objCompanyDetailsSetup.YouTubeID + "',[YouTubeID]) " +
                                              " ,[BusinessTypeID] = ISNULL(" + objBusinessType.BusinessTypeID + ",[BusinessTypeID]) " +
                                              " ,[OwnershipTypeID] = ISNULL(" + objOwnershipType.OwnershipTypeID + ",[OwnershipTypeID]) " +
                                              " ,[DistrictID] = ISNULL(" + objDistrictSetup.DistrictID + ",[DistrictID]) " +
                                              " ,[LastUpdateDate] = CAST(GETDATE() AS DateTime) " +
                                              " ,[LastUpdateUserID] = '160ea939-7633-46a8-ae49-f661d12abfd5' " +
                                          " WHERE [CompanyID] = " + objCompanyDetailsSetup.CompanyID + "";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

                this.UpdateCompanyChart(objCompanyDetailsSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetDataOfUser(CompanyDetailsSetup objCompanyDetailsSetup)
        {
            try
            {
                DataTable dtRecord = null;
                var storedProcedureComandText = @"SELECT
	                [CompanyShortName]
                      ,[BusinessTypeID]
                      ,[OwnershipTypeID]
                      ,[CompanySlogun]
                      ,[House]
                      ,[Road]
                      ,[Sector]
                      ,[Landmark]
                      ,[DistrictID]
                      ,[ContactPersonName]
                      ,[ContactPersonDesignation]
                      ,[ContactPersonContactNumber]
                      ,[AlternateContactPersonName]
                      ,[AlternateContactPersonDesignation]
                      ,[AlternateContactPersonContactNumber]
                      ,[CompanyPhones]
                      ,[CompanyFax]
                      ,[CompanyURL]
                      ,[LicenceID]
                      ,[FaceBookID]
                      ,[LinkedInID]
                      ,[TwitterID]
                      ,[YouTubeID]
                  FROM [comCompanySetup]
                  WHERE CompanyID = " + objCompanyDetailsSetup.CompanyID + "";
                dtRecord = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtRecord;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadCompany(DropDownList ddlCompany)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlGetCompany(), ddlCompany, "CompanyName", "CompanyID");
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        public string SqlGetCompany()
        {
            try
            {
                string sqlString = null;
                sqlString = @"SELECT [CompanyID]
                              ,[CompanyName]      
                          FROM [comCompanySetup] WHERE [DataUsed] = 'A' ORDER BY [CompanyName]";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}