using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class OrganizationalChartSetup : CompanySetup
    {
        private List<int> _orgElementIDList;

        public List<int> OrgElementIDList
        {
            get { return _orgElementIDList; }
            set { _orgElementIDList = value; }
        }
    }
}