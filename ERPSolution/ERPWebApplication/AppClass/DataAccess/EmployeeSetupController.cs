using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using System.Web.UI.WebControls;
using System.Data;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class EmployeeSetupController : DataAccessBase
    {
        public void Save(EmployeeDetailsSetup objEmployeeDetailsSetup, EmployeeTypeSetup objEmployeeTypeSetup,
            EmployeeCategorySetup objEmployeeCategorySetup, DesignationSetup objDesignationSetup, IsUser objIsUser)
        {
            try
            {
                objEmployeeDetailsSetup.EmployeeSerialNo = this.GetEmployeeSerialNo();
                var storedProcedureComandText = "INSERT INTO [hrEmployeeSetup] ([ReferenceID],[CompanyID],[EmployeeID],[EmployeeTypeID], " +
                    " [EmployeeCategoryID] ,[Title],[FirstName],[MiddleName],[LastName],[Email],[UserPermission] ,[DataUsed],[EntryUserID],[EntryDate]) VALUES ( " +
                    objEmployeeDetailsSetup.EmployeeSerialNo + "," +
                    objEmployeeDetailsSetup.CompanyID + ",'" +
                    objEmployeeDetailsSetup.EmployeeID + "', " +
                    objEmployeeTypeSetup.EmployeeTypeID + ", " +
                    objEmployeeCategorySetup.EmployeeCategoryID + ", '" +
                    objEmployeeDetailsSetup.EmployeeTitle + "', '" +
                    objEmployeeDetailsSetup.FirstName + "', '" +
                    objEmployeeDetailsSetup.MiddleName + "', '" +
                    objEmployeeDetailsSetup.LastName + "', '" +
                    objEmployeeDetailsSetup.Email + "'," +
                    objIsUser.UserPermission + ",'" +
                    "A" + "', '" +
                    objEmployeeDetailsSetup.EntryUserName + "'," +
                    "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

                objDesignationSetup.LastPositionNo = this.GetLastPosition(objEmployeeDetailsSetup);
                var storedProcedureComandTextDesignation = "INSERT INTO [empDesignation]([ReferenceID],[DesignationID],[LastPosition],[DataUsed],[EntryUserID],[EntryDate]) VALUES( " +
                objEmployeeDetailsSetup.EmployeeSerialNo + ",'" +
                objDesignationSetup.DesignationID + "'," +
                objDesignationSetup.LastPositionNo + ",'" +
                "A" + "','" +
                objEmployeeDetailsSetup.EntryUserName + "'," +
                "CAST(GETDATE() AS DateTime));";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextDesignation);
                string storedProcedureComandTextChart = null;
                foreach (DataRow rowNo in objEmployeeDetailsSetup.dtEmployeeChart.Rows)
                {
                    OrganizationalChartSetup objOrganizationalChartSetup = new OrganizationalChartSetup();
                    objOrganizationalChartSetup.EntityTypeID = Convert.ToInt32( rowNo["EntityTypeID"].ToString());
                    objOrganizationalChartSetup.EntityID = Convert.ToInt32( rowNo["EntityID"].ToString());
                    storedProcedureComandTextChart += "INSERT INTO [orgEmployeeChart] ([ReferenceID],[EntityTypeID],[EntityID],[LastPosition],[DataUsed],[EntryUserID],[EntryDate] " +
                    ") VALUES( " + objEmployeeDetailsSetup.EmployeeSerialNo + "," +
                    objOrganizationalChartSetup.EntityTypeID + "," +
                    objOrganizationalChartSetup.EntityID + "," +
                    objDesignationSetup.LastPositionNo + ",'" +
                    "A" + "','" +
                    objEmployeeDetailsSetup.EntryUserName + "'," +
                    "CAST(GETDATE() AS DateTime));";
                }
                if (storedProcedureComandTextChart != null)
                {
                    clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandTextChart);
                    
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        private int GetEmployeeSerialNo()
        {
            try
            {
                int empSerialNo = 0;
                var storedProcedureComandText = "SELECT ISNULL( MAX( [ReferenceID]),0) +1  FROM [hrEmployeeSetup]";
                empSerialNo = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return empSerialNo;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private int GetLastPosition(EmployeeDetailsSetup objEmployeeDetailsSetup)
        {
            try
            {
                int lastPositionNo = 0;
                var storedProcedureComandText = "SELECT ISNULL( MAX(  [LastPosition]),0) +1 FROM [empDesignation] WHERE [ReferenceID]= " + objEmployeeDetailsSetup.EmployeeSerialNo + " ";
                lastPositionNo = clsDataManipulation.GetMaximumValueUsingSQL(this.ConnectionString, storedProcedureComandText);
                return lastPositionNo;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        internal void LoadCompanyDDL(DropDownList ddlCompany)
        {
            try
            {
                CompanySetupController objCompanySetupController = new CompanySetupController();
                objCompanySetupController.LoadCompany(ddlCompany);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        private OrganizationalChartSetupController _objOrganizationalChartSetupController;
        internal void LoadBranchDDL(DropDownList ddlBranch, CompanySetup objCompanySetup)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadBranchDDL(ddlBranch, objCompanySetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadDepartmentDDL(DropDownList ddlDepartment, BranchSetup objBranchSetup)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadDepartmentDDL(ddlDepartment, objBranchSetup);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadSectionDDL(DropDownList ddlSection, DepartmentSetup objDepartmentSetup)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadSectionDDL(ddlSection, objDepartmentSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadTeamDDL(DropDownList ddlTeam, SectionSetup objSectionSetup)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadTeamDDL(ddlTeam, objSectionSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private TwoColumnsTableDataController _objTwoColumnsTableDataController;
        private TwoColumnsTableData _objTwoColumnsTableData;
        internal void GetEmployeeType(DropDownList ddlEmployeeType, EmployeeDetailsSetup objEmployeeDetailsSetup)
        {
            try
            {
                _objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                _objTwoColumnsTableData = new TwoColumnsTableData();
                _objTwoColumnsTableData.CompanyID = objEmployeeDetailsSetup.CompanyID;
                _objTwoColumnsTableDataController.LoadEmployeeTypeDDL(ddlEmployeeType, _objTwoColumnsTableData);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetEmployeeCategory(DropDownList ddlEmployeeCategory, EmployeeDetailsSetup objEmployeeDetailsSetup)
        {
            try
            {
                _objTwoColumnsTableData = new TwoColumnsTableData();
                _objTwoColumnsTableData.CompanyID = objEmployeeDetailsSetup.CompanyID;
                _objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                _objTwoColumnsTableDataController.LoadEmployeeCategoryDDL(ddlEmployeeCategory, _objTwoColumnsTableData);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void GetEmployeeTitle(DropDownList ddlTitle)
        {
            try
            {
                _objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                _objTwoColumnsTableDataController.LoadEmployeeTitle(ddlTitle);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
    }
}