using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class TwoColumnsTableDataAuto
    {
        private int _tableID;

        public int TableID
        {
            get { return _tableID; }
            set { _tableID = value; }
        }
        private string _eieldOfID;

        public string EieldOfID
        {
            get { return _eieldOfID; }
            set { _eieldOfID = value; }
        }
        private string _fieldOfName;

        public string FieldOfName
        {
            get { return _fieldOfName; }
            set { _fieldOfName = value; }
        }
        private string _entryUserName;

        public string EntryUserName
        {
            get { return _entryUserName; }
            set { _entryUserName = value; }
        }
        private string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }
    }
}