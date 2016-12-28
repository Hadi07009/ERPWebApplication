using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class TwoColumnsTableData
    {
        private int _companyID;

        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }
        private int _branchID;

        public int BranchID
        {
            get { return _branchID; }
            set { _branchID = value; }
        }
        private int _tableID;

        public int TableID
        {
            get { return _tableID; }
            set { _tableID = value; }
        }
        private string _fieldOfID;

        public string FieldOfID
        {
            get { return _fieldOfID; }
            set { _fieldOfID = value; }
        }
        private string _fieldOfName;

        public string FieldOfName
        {
            get { return _fieldOfName; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" Please type field Of name");

                }
                _fieldOfName = value;
            }
        }
        private string _fieldDescription;

        public string FieldDescription
        {
            get { return _fieldDescription; }
            set { _fieldDescription = value; }
        }
        private string _entryUserName;

        public string EntryUserName
        {
            get { return _entryUserName; }
            set { _entryUserName = value; }
        }
    }
}