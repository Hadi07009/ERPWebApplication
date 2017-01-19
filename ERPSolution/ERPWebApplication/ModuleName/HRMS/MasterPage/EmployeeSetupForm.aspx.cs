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
                    LoadAllDDL();

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadAllDDL()
        {
            try
            {
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadCompanyDDL(ddlCompany);
                //_objEmployeeSetupController.LoadBranchDDL(ddlBranch);
                //_objEmployeeSetupController.LoadEmployeeType(ddlEmployeeType);
                //_objEmployeeSetupController.LoadEmployeeCategoryDDL(ddlEmployeeCategory);
                //_objEmployeeSetupController.LoadDesignationDDL(ddlDesignation);
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
                _objEmployeeDetailsSetup.CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                _objEmployeeDetailsSetup.BranchID = 1;//Convert.ToInt32(ddlBranch.SelectedValue);
                _objEmployeeDetailsSetup.EmployeeID = txtEmployeeID.Text == string.Empty ? null : txtEmployeeID.Text;
                _objEmployeeTypeSetup = new EmployeeTypeSetup();
                _objEmployeeTypeSetup.EmployeeTypeID = 1;//Convert.ToInt32(ddlEmployeeType.SelectedValue);
                _objEmployeeCategorySetup = new EmployeeCategorySetup();
                _objEmployeeCategorySetup.EmployeeCategoryID = 1; //Convert.ToInt32(ddlEmployeeCategory.SelectedValue);
                _objDesignationSetup = new DesignationSetup();
                _objDesignationSetup.DesignationID = "1";//ddlDesignation.SelectedValue;
                _objEmployeeDetailsSetup.FirstName = txtFirstName.Text == string.Empty ? null : txtFirstName.Text;
                _objEmployeeDetailsSetup.MiddleName = txtMiddleName.Text == string.Empty ? null : txtMiddleName.Text;
                _objEmployeeDetailsSetup.LastName = txtLastName.Text == string.Empty ? null : txtLastName.Text;
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.Save(_objEmployeeDetailsSetup, _objEmployeeTypeSetup, _objEmployeeCategorySetup, _objDesignationSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}