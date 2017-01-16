using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class OwnershipType
    {
        private int? _ownershipTypeID;

        public int? OwnershipTypeID
        {
            get { return _ownershipTypeID; }
            set { _ownershipTypeID = value; }
        }
    }
}