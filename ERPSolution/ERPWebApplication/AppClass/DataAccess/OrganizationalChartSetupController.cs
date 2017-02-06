using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class OrganizationalChartSetupController : DataAccessBase
    {
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

        internal void LoadStandardOrgElementsDDL(ListBox listBoxStandardOrgElements)
        {
            try
            {
                StandardOrgElementsController objStandardOrgElementsController = new StandardOrgElementsController();
                objStandardOrgElementsController.LoadStandardOrgElements(listBoxStandardOrgElements);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}