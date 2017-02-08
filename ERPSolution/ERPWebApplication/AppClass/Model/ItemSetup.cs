using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class ItemSetup
    {
        private int _itemID;

        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        private int _itemCategoryID;

        public int ItemCategoryID
        {
            get { return _itemCategoryID; }
            set { _itemCategoryID = value; }
        }
        private int _unitID;

        public int UnitID
        {
            get { return _unitID; }
            set
            {
                if (value == -1)
                {
                    throw new Exception("please select unit");

                }
                _unitID = value;
            }
        }
        private string _hsCode;

        public string HsCode
        {
            get { return _hsCode; }
            set { _hsCode = value; }
        }
        private string _specification;

        public string Specification
        {
            get { return _specification; }
            set { _specification = value; }
        }
        private int _openningBalance;

        public int OpenningBalance
        {
            get { return _openningBalance; }
            set { _openningBalance = value; }
        }
        private string _supplierID;

        public string SupplierID
        {
            get { return _supplierID; }
            set { _supplierID = value; }
        }
        private bool _isVATAbleItem;

        public bool IsVATAbleItem
        {
            get { return _isVATAbleItem; }
            set { _isVATAbleItem = value; }
        }
        private int _coaSalesAccNo;

        public int CoaSalesAccNo
        {
            get { return _coaSalesAccNo; }
            set
            {
                if (value == -1)
                {
                    throw new Exception("please select sales account no");

                }
                _coaSalesAccNo = value;
            }
        }
        private int _coaStockAccNo;

        public int CoaStockAccNo
        {
            get { return _coaStockAccNo; }
            set
            {
                if (value == -1)
                {
                    throw new Exception("please select stock account no");

                }
                _coaStockAccNo = value;
            }
        }
        private int _coacgsAccNo;

        public int CoacgsAccNo
        {
            get { return _coacgsAccNo; }
            set
            {
                if (value == -1)
                {
                    throw new Exception("please select COGS account no");

                }
                _coacgsAccNo = value;
            }
        }
        private int _coaSalesRetAccNo;

        public int CoaSalesRetAccNo
        {
            get { return _coaSalesRetAccNo; }
            set
            {
                if (value == -1)
                {
                    throw new Exception("please select sales return account");

                }
                _coaSalesRetAccNo = value;
            }
        }
        private string _entryUserName;

        public string EntryUserName
        {
            get { return _entryUserName; }
            set { _entryUserName = value; }
        }
        private int _itemTypeID;

        public int ItemTypeID
        {
            get { return _itemTypeID; }
            set {
                if (value == -1)
                {
                    throw new Exception("please select listItem type ID");
                    
                }
                _itemTypeID = value; }
        }
        private int _itemPropertySetID;

        public int ItemPropertySetID
        {
            get { return _itemPropertySetID; }
            set { _itemPropertySetID = value; }
        }
        private int _itemUsageID;

        public int ItemUsageID
        {
            get { return _itemUsageID; }
            set {
                if (value == -1)
                {
                    throw new Exception("please select listItem usage ID");
                    
                }
                _itemUsageID = value; }
        }
        private string _modelNo;

        public string ModelNo
        {
            get { return _modelNo; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" Please type listItem name");

                } _modelNo = value;
            }
        }
        private string _itemCode;

        public string ItemCode
        {
            get { return _itemCode; }
            set { _itemCode = value; }
        }
        private string _reOrderLevel;

        public string ReOrderLevel
        {
            get { return _reOrderLevel; }
            set { _reOrderLevel = value; }
        }
        private int _breakUpQuantity;

        public int BreakUpQuantity
        {
            get { return _breakUpQuantity; }
            set { _breakUpQuantity = value; }
        }
        private int _breakUpUnitD;

        public int BreakUpUnitD
        {
            get { return _breakUpUnitD; }
            set { _breakUpUnitD = value; }
        }
        private int _minimumQuantity;

        public int MinimumQuantity
        {
            get { return _minimumQuantity; }
            set { _minimumQuantity = value; }
        }
    }
}