using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class YearSetup : BranchSetup
    {
        private int _yearOpeningID;

        public int YearOpeningID
        {
            get { return _yearOpeningID; }
            set { _yearOpeningID = value; }
        }
        private Nullable<DateTime> _beginningYear;

        public Nullable<DateTime> BeginningYear
        {
            get { return _beginningYear; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" start date is required ");

                } _beginningYear = value;
            }
        }

        private DateTime? _endingYear;

        public DateTime? EndingYear
        {
            get { return _endingYear; }
            set
            {
                if (value == null)
                {
                    throw new Exception(" end date is required ");

                } _endingYear = value;
            }
        }
        private string _yearOpenBy;

        public string YearOpenBy
        {
            get { return _yearOpenBy; }
            set { _yearOpenBy = value; }
        }
        private int _yearOpen;

        public int YearOpen
        {
            get { return _yearOpen; }
            set { _yearOpen = value; }
        }

       
        private int _useChartOfAccNo;

        public int UseChartOfAccNo
        {
            get { return _useChartOfAccNo; }
            set { _useChartOfAccNo = value; }
        }
        private string _remarks;

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
    }
}