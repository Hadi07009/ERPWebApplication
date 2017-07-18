using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class SubledgerSetup : BranchSetup
    {
        private string _subledgerTypePrefix;

        public string SubledgerTypePrefix
        {
            get { return _subledgerTypePrefix; }
            set { _subledgerTypePrefix = value; }
        }
        private string _subledgerTypeID;

        public string SubledgerTypeID
        {
            get { return _subledgerTypeID; }
            set { _subledgerTypeID = value; }
        }
        private string _SubLedgerTypeName;

        public string SubLedgerTypeName
        {
            get { return _SubLedgerTypeName; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Subledger type is required");

                }
                _SubLedgerTypeName = value;
            }
        }
        private int _knownValueId;

        public int KnownValueId
        {
            get { return _knownValueId; }
            set { _knownValueId = value; }
        }
        private string _isConvertable;

        public string IsConvertable
        {
            get { return _isConvertable; }
            set { _isConvertable = value; }
        }

        private string _subledgerID;

        public string SubledgerID
        {
            get { return _subledgerID; }
            set { _subledgerID = value; }
        }

        private string _subledgerReferenceID;

        public string SubledgerReferenceID
        {
            get { return _subledgerReferenceID; }
            set { _subledgerReferenceID = value; }
        }

        private string _subledgerHeadName;

        public string SubledgerHeadName
        {
            get { return _subledgerHeadName; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Subledger name is required");

                }
                _subledgerHeadName = value;
            }
        }

        private string _subledgerDescription;

        public string SubledgerDescription
        {
            get { return _subledgerDescription; }
            set { _subledgerDescription = value; }
        }
    }
}