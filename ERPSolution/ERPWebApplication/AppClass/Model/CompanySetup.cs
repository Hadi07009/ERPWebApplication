using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class CompanySetup : CountrySetup
    {
        private int _companyID;
        
        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

    }
}