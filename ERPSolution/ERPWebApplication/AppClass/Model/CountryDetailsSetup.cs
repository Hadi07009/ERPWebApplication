using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class CountryDetailsSetup : CountrySetup
    {
        private string _countryName;

        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }
        private string _countryCode;

        protected internal string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }
    }
}