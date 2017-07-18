using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class UCOrganizationalChartController : DataAccessBase
    {
        internal void GetOrganizationElementsGV(GridView gridViewOrganizationalChart, OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                OrganizationalChartSetupController objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                objOrganizationalChartSetupController.LoadOrganizationalElementsWithCompany(objOrganizationalChartSetup, gridViewOrganizationalChart);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}