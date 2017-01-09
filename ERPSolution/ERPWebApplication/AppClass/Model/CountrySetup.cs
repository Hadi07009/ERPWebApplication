using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class CountrySetup
    {
        private int _countryID;

        protected internal int CountryID
        {
            get { return _countryID; }
            set { _countryID = value; }
        }
        private string _entryUserName;

        protected internal string EntryUserName
        {
            get { return _entryUserName; }
            set { _entryUserName = value; }
        }

        
    }
}