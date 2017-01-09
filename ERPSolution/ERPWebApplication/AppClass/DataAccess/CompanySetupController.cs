using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}