using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class DataAccessBase
    {
        protected string ConnectionString
        {
            get { return GetSQLString(); }
        }
        private string GetSQLString()
        {
            string startupPath = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
            return startupPath;
        }
    }
}