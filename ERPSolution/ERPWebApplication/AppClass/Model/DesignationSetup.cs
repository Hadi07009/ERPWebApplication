using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class DesignationSetup
    {
        private string _designationID;

        public string DesignationID
        {
            get { return _designationID; }
            set { _designationID = value; }
        }
    }
}