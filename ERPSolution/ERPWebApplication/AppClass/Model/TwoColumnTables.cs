using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class TwoColumnTables
    {
        private int _tableID;

        public int TableID
        {
            get { return _tableID; }
            set { _tableID = value; }
        }
        private string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" Please type table name");

                }
                _tableName = value;
            }
        }
        private string _entryMode;

        public string EntryMode
        {
            get { return _entryMode; }
            set { _entryMode = value; }
        }
        private string _relatedTo;

        public string RelatedTo
        {
            get { return _relatedTo; }
            set { _relatedTo = value; }
        }
        private int _relatedUserRoleID;

        public int RelatedUserRoleID
        {
            get { return _relatedUserRoleID; }
            set { _relatedUserRoleID = value; }
        }
        private string _entryUserName;

        public string EntryUserName
        {
            get { return _entryUserName; }
            set { _entryUserName = value; }
        }
        private string _entrySystem;

        public string EntrySystem
        {
            get { return _entrySystem; }
            set {
                if (value == null)
                {
                    throw new Exception(" Please select entry system");
                    
                }
                _entrySystem = value; }
        }
    }
}