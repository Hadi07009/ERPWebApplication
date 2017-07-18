using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class UserSecurityCode
    {
        private string _userKnownID;

        public string UserKnownID
        {
            get { return _userKnownID; }
            set {
                if (value == null)
                {
                    throw new Exception("Employee code/Known code is required ");
                    
                } _userKnownID = value;
            }
        }
        private int _securityCode;

        public int SecurityCode
        {
            get { return _securityCode; }
            set { _securityCode = value; }
        }
        private int _securityCodeStatus;

        public int SecurityCodeStatus
        {
            get { return _securityCodeStatus; }
            set { _securityCodeStatus = value; }
        }
        private int _sequenceNo;

        public int SequenceNo
        {
            get { return _sequenceNo; }
            set { _sequenceNo = value; }
        }
    }
}