using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ERPWebApplication.CommonClass;
using ERPWebApplication.AppClass.CommonClass;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class CountrySetupController : DataAccessBase
    {
        public string SqlGetCountry()
        {
            try
            {
                string sqlString = null;
                sqlString = @"SELECT [CountryID]
                              ,[CountryName]      
                          FROM [gCountryList] WHERE [DataUsed] = 'A'";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        public void LoadCountry(DropDownList ddlCountry)
        {
            try
            {
                ClsDropDownListController.LoadDropDownList(this.ConnectionString, this.SqlGetCountry(), ddlCountry, "CountryName", "CountryID");

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}