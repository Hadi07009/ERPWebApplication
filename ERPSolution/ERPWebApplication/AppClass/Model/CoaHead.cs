using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CoaHead
/// </summary>

namespace ERPWebApplication.AppClass.Model
{
    public class CoaHead
    {
        public CoaHead()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int AccountNo { get; set; }
        public int ParentAccNo { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountName { get; set; }
        public string AccountDescription { get; set; }
        public string EntryUserId { get; set; }
        public int SeqNo { get; set; }
        public int TierNo { get; set; }
        public int SerialNo { get; set; }
        private int _isBudgetRelated;

        public int IsBudgetRelated
        {
            get { return _isBudgetRelated; }
            set { _isBudgetRelated = value; }
        }
        private string _analysisRequired;

        public string AnalysisRequired
        {
            get { return _analysisRequired; }
            set { _analysisRequired = value; }
        }
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
        private string _subledgerTypeID;

        public string SubledgerTypeID
        {
            get { return _subledgerTypeID; }
            set { _subledgerTypeID = value; }
        }
        private string _subLedgerID;

        public string SubLedgerID
        {
            get { return _subLedgerID; }
            set { _subLedgerID = value; }
        }
        private int _subLineNo;

        public int SubLineNo
        {
            get { return _subLineNo; }
            set { _subLineNo = value; }
        }
        private DataTable _dtSubledgerInformation;

        public DataTable DtSubledgerInformation
        {
            get { return _dtSubledgerInformation; }
            set { _dtSubledgerInformation = value; }
        }

    }
}