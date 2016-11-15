using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class ItemCategorySetup
    {
        private int _companyID;

        public int CompanyID
        {
            get { return _companyID; }
            set
            {
                if (value == 0)
                {
                    throw new Exception(" Company id is required");

                } _companyID = value;
            }
        }
        private int _branchID;

        public int BranchID
        {
            get { return _branchID; }
            set
            {
                if (value == 0)
                {
                    throw new Exception(" Branch id is required");

                } _branchID = value;
            }
        }
        private int _categoryTypeID;

        public int CategoryTypeID
        {
            get { return _categoryTypeID; }
            set
            {
                if (value == -1)
                {
                    throw new Exception(" Please select product type");

                } _categoryTypeID = value;
            }
        }
        private int _itemCategoryID;

        public int ItemCategoryID
        {
            get { return _itemCategoryID; }
            set { _itemCategoryID = value; }
        }
        
        private string _categoryName;

        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" Please type category name");

                } _categoryName = value;
            }
        }
        private int _parentCategoryID;

        public int ParentCategoryID
        {
            get { return _parentCategoryID; }
            set { _parentCategoryID = value; }
        }
        private float _startingItemCode;

        public float StartingItemCode
        {
            get { return _startingItemCode; }
            set { _startingItemCode = value; }
        }
        private float _endingItemCode;

        public float EndingItemCode
        {
            get { return _endingItemCode; }
            set { _endingItemCode = value; }
        }
        private int _seqNo;

        public int SeqNo
        {
            get { return _seqNo; }
            set { _seqNo = value; }
        }
        private int _tierNo;

        public int TierNo
        {
            get { return _tierNo; }
            set { _tierNo = value; }
        }
        private int _currentBalance;

        public int CurrentBalance
        {
            get { return _currentBalance; }
            set { _currentBalance = value; }
        }
        private string _dataUsed;

        public string DataUsed
        {
            get { return _dataUsed; }
            set { _dataUsed = value; }
        }
        private int _serialNo;

        public int SerialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; }
        }
        private string _entryUserName;

        public string EntryUserName
        {
            get { return _entryUserName; }
            set {
                if (value == null)
                {
                    throw new Exception(" Entry user code id is required");
                    
                } _entryUserName = value;
            }
        }

    }
}