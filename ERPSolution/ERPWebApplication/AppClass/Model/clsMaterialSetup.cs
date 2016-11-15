using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.Model
{
    public class clsMaterialSetup
    {

        public clsMaterialSetup()
        {
 
        }

        private int companyID;
        private int branchID;
        private int itemID;
        private int itemCatagoryID;
        private int itemTypeID;
        private string modelNo;
        private string itemCode;
        private string supplierID;
        private int unitID;
        private string dataUsed;
        private DateTime entryDate;
        private Guid entryUserID;
        private DateTime modifiedDate;
        private Guid modifiedUserID;

        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }

        public int BranchID
        {
            get { return branchID; }
            set { branchID = value; }
        }

        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }


        public int ItemCatagoryID
        {
            get { return itemCatagoryID; }
            set { itemCatagoryID = value; }
        }

        public int ItemTypeID
        {
            get { return itemTypeID; }
            set { itemTypeID = value; }
        }

        public string ModelNo
        {
            get { return modelNo; }
            set { modelNo = value; }
        }
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        public string SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }

        public int UnitID
        {
            get { return unitID; }
            set { unitID = value; }
        }

        public string DataUsed
        {
            get { return dataUsed; }
            set { dataUsed = value; }
        }

        public DateTime EntryDate
        {
            get { return entryDate; }
            set { entryDate = value; }
        }

        public Guid EntryUserID
        {
            get { return entryUserID; }
            set { entryUserID = value; }
        }

        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }

        public Guid ModifiedUserID
        {
            get { return modifiedUserID; }
            set { modifiedUserID = value; }
        }


    }
}