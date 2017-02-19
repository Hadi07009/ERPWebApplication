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

        private int _parentEntityID;

        public int ParentEntityID
        {
            get { return _parentEntityID; }
            set { _parentEntityID = value; }
        }
        private int _entityID;

        public int EntityID
        {
            get { return _entityID; }
            set { _entityID = value; }
        }
        private int _entityTypeID;

        public int EntityTypeID
        {
            get { return _entityTypeID; }
            set
            {
                if (value == -1)
                {
                    throw new Exception("element is required ");

                } _entityTypeID = value;
            }
        }
        private int _addressID;

        public int AddressID
        {
            get { return _addressID; }
            set { _addressID = value; }
        }
        private string _entityName;

        public string EntityName
        {
            get { return _entityName; }
            set
            {
                if (value == null)
                {
                    throw new Exception("title is required ");

                } _entityName = value;
            }
        }
        private string _shortName;

        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }
        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
        private string _groupEmailAddress;

        public string GroupEmailAddress
        {
            get { return _groupEmailAddress; }
            set { _groupEmailAddress = value; }
        }
        private DateTime? _entityOpeningDate;

        public DateTime? EntityOpeningDate
        {
            get { return _entityOpeningDate; }
            set { _entityOpeningDate = value; }
        }
        private string _addressTag;

        public string AddressTag
        {
            get { return _addressTag; }
            set { _addressTag = value; }
        }

        public int ContactAdreessNumber { get; set; }

        public string DisplayAddress { get; set; }

        private string _divisionID;

        public string DivisionID
        {
            get { return _divisionID; }
            set {
                if (value == null)
                {
                    throw new Exception("division is required ");
                    
                } _divisionID = value;
            }
        }

        private string _districtID;

        public string DistrictID
        {
            get { return _districtID; }
            set {
                if (value == null)
                {
                    throw new Exception("district is required ");
                    
                } _districtID = value;
            }
        }

        public string PostalCode { get; set; }

        public string PhoneNo { get; set; }

        public string Fax { get; set; }

        public int ContactAddressUsedID { get; set; }
        private string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set {
                if (value == null)
                {
                    throw new Exception("element is required ");
                    
                } _tableName = value;
            }
        }
    }
}