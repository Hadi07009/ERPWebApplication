using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class DistrictSetup
    {
        private int? _districtID;

        public int? DistrictID
        {
            get { return _districtID; }
            set { _districtID = value; }
        }
    }
}