using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.DataAccess;

namespace ERPWebApplication.ModuleName.HRMS.MasterPage
{
    public partial class OrganizationalChartForm : System.Web.UI.Page
    {
        private OrganizationalChartSetup _objOrganizationalChartSetup;
        private OrganizationalChartSetupController _objOrganizationalChartSetupController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadCompany(ddlCompany);
                    LoadStandardOrgElements(ListBoxStandardOrgElements);

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadStandardOrgElements(ListBox listBoxStandardOrgElements)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadStandardOrgElementsDDL(listBoxStandardOrgElements);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadCompany(DropDownList ddlCompany)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadCompanyDDL(ddlCompany);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}