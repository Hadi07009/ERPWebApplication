using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class NewCompany : System.Web.UI.Page
    {
        private CompanyDetailsSetup _objCompanyDetailsSetup;
        private CompanySetupController _objCompanySetupController;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadCountryDropDown(ddlCountry);
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadCountryDropDown(DropDownList ddlCountry)
        {
            try
            {
                _objCompanySetupController = new CompanySetupController();
                _objCompanySetupController.LoadCountry(ddlCountry);

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
                AddCompanyValues();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddCompanyValues()
        {
            try
            {
                _objCompanyDetailsSetup.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                _objCompanyDetailsSetup.CompanyName = txtCompanyName.Text == string.Empty ? null : txtCompanyName.Text;
                _objCompanyDetailsSetup.CompanyEmail = txtEmail.Text == string.Empty ? null : txtEmail.Text;
                _objCompanyDetailsSetup.CompanyMobile = txtMobile.Text == string.Empty ? null : txtMobile.Text;
                _objCompanySetupController = new CompanySetupController();
                _objCompanySetupController.Save(_objCompanyDetailsSetup);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}