using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class CompanyDetailsSetup : CompanySetup
    {
        public CompanyDetailsSetup()
        {
            if (this.CountryID == -1)
            {
                throw new Exception(" country name is required ");
                
            }
        }

        private string _companyName;

        public string CompanyName
        {
            get { return _companyName; }
            set {
                if (value == null)
                {
                    throw new Exception(" Company name is required ");
                    
                } _companyName = value;
            }
        }
        private string _companyEmail;

        public string CompanyEmail
        {
            get { return _companyEmail; }
            set { _companyEmail = value; }
        }
        private string _companyMobile;

        public string CompanyMobile
        {
            get { return _companyMobile; }
            set { _companyMobile = value; }
        }



    }
}