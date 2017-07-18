using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;


namespace ERPWebApplication.ModuleName.HRMS.MasterPage
{
    public partial class EmployeeSetupForm : System.Web.UI.Page
    {
        private EmployeeDetailsSetup _objEmployeeDetailsSetup;
        private EmployeeSetupController _objEmployeeSetupController;
        private EmployeeTypeSetup _objEmployeeTypeSetup;
        private EmployeeCategorySetup _objEmployeeCategorySetup;
        private DesignationSetup _objDesignationSetup;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadorgDesignation();
                    LoadEmployeeType();
                    LoadEmployeeCategory();
                    LoadEmployeeTitle();
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadEmployeeTitle()
        {
            try
            {
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.GetEmployeeTitle(ddlTitle);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadEmployeeCategory()
        {
            try
            {
                _objEmployeeDetailsSetup = new EmployeeDetailsSetup();
                _objEmployeeDetailsSetup.CompanyID = LoginUserInformation.CompanyID;
                _objEmployeeSetupController.GetEmployeeCategory(ddlEmployeeCategory,_objEmployeeDetailsSetup);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadEmployeeType()
        {
            try
            {
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeDetailsSetup = new EmployeeDetailsSetup();
                _objEmployeeDetailsSetup.CompanyID = LoginUserInformation.CompanyID;
                _objEmployeeSetupController.GetEmployeeType(ddlEmployeeType, _objEmployeeDetailsSetup);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadorgDesignation()
        {
            try
            {
                TwoColumnsTableDataController objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                TwoColumnsTableData objTwoColumnsTableData = new TwoColumnsTableData();
                objTwoColumnsTableData.CompanyID = LoginUserInformation.CompanyID;
                objTwoColumnsTableDataController.LoadDesignationDDL(ddlDesignationEmployee, objTwoColumnsTableData);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddValues();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddValues()
        {
            try
            {
                _objEmployeeDetailsSetup = new EmployeeDetailsSetup();

                _objEmployeeDetailsSetup.CompanyID = this.OrganizationalChartControl1.empCompany;
                _objEmployeeDetailsSetup.dtEmployeeChart = this.OrganizationalChartControl1.empValueAsTable;
                _objEmployeeDetailsSetup.EmployeeID = txtEmployeeID.Text == string.Empty ? null : txtEmployeeID.Text;
                _objEmployeeTypeSetup = new EmployeeTypeSetup();
                _objEmployeeTypeSetup.EmployeeTypeID = Convert.ToInt32(ddlEmployeeType.SelectedValue);
                _objEmployeeCategorySetup = new EmployeeCategorySetup();
                _objEmployeeCategorySetup.EmployeeCategoryID = Convert.ToInt32(ddlEmployeeCategory.SelectedValue);
                _objEmployeeDetailsSetup.EmployeeTitle = Convert.ToInt32(ddlTitle.SelectedValue);
                _objDesignationSetup = new DesignationSetup();
                _objDesignationSetup.DesignationID = ddlDesignationEmployee.SelectedValue;
                _objEmployeeDetailsSetup.FirstName = txtFirstName.Text == string.Empty ? null : txtFirstName.Text;
                _objEmployeeDetailsSetup.MiddleName = txtMiddleName.Text == string.Empty ? null : txtMiddleName.Text;
                _objEmployeeDetailsSetup.LastName = txtLastName.Text == string.Empty ? null : txtLastName.Text;
                _objEmployeeDetailsSetup.Email = txtEmail.Text == string.Empty ? null : txtEmail.Text;
                _objEmployeeDetailsSetup.EntryUserName = LoginUserInformation.UserID;
                IsUser objIsUser = new IsUser();
                objIsUser.UserPermission = Convert.ToInt32( ddlUserPermission.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.Save(_objEmployeeDetailsSetup, _objEmployeeTypeSetup, _objEmployeeCategorySetup, _objDesignationSetup,objIsUser);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}