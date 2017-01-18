using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class EmployeeSetup : BranchSetup
    {
        private string _employeeID;

        public string EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }
    }
}