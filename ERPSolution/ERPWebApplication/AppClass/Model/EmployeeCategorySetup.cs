using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class EmployeeCategorySetup
    {
        private int _employeeCategoryID;

        public int EmployeeCategoryID
        {
            get { return _employeeCategoryID; }
            set { _employeeCategoryID = value; }
        }
    }
}