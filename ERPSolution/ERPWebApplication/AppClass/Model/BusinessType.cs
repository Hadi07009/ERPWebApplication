using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class BusinessType
    {
        private int? _businessTypeID;

        public int? BusinessTypeID
        {
            get { return _businessTypeID; }
            set { _businessTypeID = value; }
        }
    }
}