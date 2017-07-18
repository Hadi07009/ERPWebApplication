using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class SectionSetup : DepartmentSetup
    {
        private int _sectionID;

        public int SectionID
        {
            get { return _sectionID; }
            set { _sectionID = value; }
        }
    }
}