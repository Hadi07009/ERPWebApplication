using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class NodeList
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
        private int _activityID;

        public int ActivityID
        {
            get { return _activityID; }
            set {
                if (value == -1)
                {
                    throw new Exception(" type is required ");
                    
                } _activityID = value;
            }
        }
        private string _activityName;

        public string ActivityName
        {
            get { return _activityName; }
            set {
                if (value == null)
                {
                    throw new Exception(" title is required ");
                    
                } _activityName = value;
            }
        }
        private int _seqNo;

        public int SeqNo
        {
            get { return _seqNo; }
            set { _seqNo = value; }
        }
        private int _nodeTypeID;

        public int NodeTypeID
        {
            get { return _nodeTypeID; }
            set { _nodeTypeID = value; }
        }
        private int _parentNodeTypeID;

        public int ParentNodeTypeID
        {
            get { return _parentNodeTypeID; }
            set {
                if (value == 0)
                {
                    throw new Exception(" please select from tree view");
                    
                } _parentNodeTypeID = value;
            }
        }
        private string _formDescription;

        public string FormDescription
        {
            get { return _formDescription; }
            set { _formDescription = value; }
        }
        private string _formName;

        public string FormName
        {
            get { return _formName; }
            set {
                if (value == null && ActivityID == 4)
                {
                    throw new Exception(" form URL is required ");
                    
                } _formName = value;
            }
        }
        private string _entryUserName;

        public string EntryUserName
        {
            get { return _entryUserName; }
            set { _entryUserName = value; }
        }
    }
}