using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.Model
{
    public class RequisitionHeader
    {

        public RequisitionHeader()
        { 
        }


        private int companyID;
        private int branchID;
        private string itemRequisitionNo;
        private string requisitionBy;
        private DateTime requisitionDate;
        private DateTime requiredDate;
        private string requestedDepartment;
        private int userType;
        private string userID;

      
        private int locationOfUse;
        private string locationAddress;
        private int priorityID;
        private int purposeID;
        private int referenceTypeID;
        private string referenceNumber;
        private string projectID;
        private int requisitionCurrentStatus;
        private string requisitionComments;
        private int completionStatus;

      



     

        private DateTime entryDate;
        private Guid entryUserID;
        private DateTime modifiedDate;
        private Guid modifiedUserID;

        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }       

        public int BranchID
        {
            get { return branchID; }
            set { branchID = value; }
        }

        public string ItemRequisitionNo
        {
            get { return itemRequisitionNo; }
            set { itemRequisitionNo = value; }
        }       

        public string RequisitionBy
        {
            get { return requisitionBy; }
            set { requisitionBy = value; }
        }       

        public DateTime RequisitionDate
        {
            get { return requisitionDate; }
            set { requisitionDate = value; }
        }        

        public DateTime RequiredDate
        {
            get { return requiredDate; }
            set { requiredDate = value; }
        }       

        public string RequestedDepartment
        {
            get { return requestedDepartment; }
            set { requestedDepartment = value; }
        }       

        public int UserType
        {
            get { return userType; }
            set { userType = value; }
        }



        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public int LocationOfUse
        {
            get { return locationOfUse; }
            set { locationOfUse = value; }
        }

       

        public string LocationAddress
        {
            get { return locationAddress; }
            set { locationAddress = value; }
        }

        

        public int PriorityID
        {
            get { return priorityID; }
            set { priorityID = value; }
        }

       

        public int PurposeID
        {
            get { return purposeID; }
            set { purposeID = value; }
        }
       

        public int ReferenceTypeID
        {
            get { return referenceTypeID; }
            set { referenceTypeID = value; }
        }
        

        public string ReferenceNumber
        {
            get { return referenceNumber; }
            set { referenceNumber = value; }
        }
        

        public string ProjectID
        {
            get { return projectID; }
            set { projectID = value; }
        }
       

        public int RequisitionCurrentStatus
        {
            get { return requisitionCurrentStatus; }
            set { requisitionCurrentStatus = value; }
        }



        public string RequisitionComments
        {
            get { return requisitionComments; }
            set { requisitionComments = value; }
        }


        public int CompletionStatus
        {
            get { return completionStatus; }
            set { completionStatus = value; }
        }
       

        public DateTime EntryDate
        {
            get { return entryDate; }
            set { entryDate = value; }
        }
        

        public Guid EntryUserID
        {
            get { return entryUserID; }
            set { entryUserID = value; }
        }
       

        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }
       

        public Guid ModifiedUserID
        {
            get { return modifiedUserID; }
            set { modifiedUserID = value; }
        }


    }
}