using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.Model
{
    public class ClsFileUploadHeader
    {

        public ClsFileUploadHeader()
        {

        }

        #region Private Variable

        private int companyID;
        private int branchID;
   
        private string referenceNo;
        private int fileCategoryID;
        private string uploadedScreenName;
    
        # endregion

        #region public Variable

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

   

        public string ReferenceNo
        {
            get { return referenceNo; }
            set { referenceNo = value; }
        }

        public int FileCategoryID
        {
            get { return fileCategoryID; }
            set { fileCategoryID = value; }
        }

        public string UploadedScreenName
        {
            get { return uploadedScreenName; }
            set { uploadedScreenName = value; }
        }



        #endregion public Variable





    }
}