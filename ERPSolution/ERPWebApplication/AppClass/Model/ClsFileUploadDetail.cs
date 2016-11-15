using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.Model
{
    public class ClsFileUploadDetail
    {

        public ClsFileUploadDetail()
        { 
        }

        #region Private Variable

        private int companyID;
        private int branchID;
        private Guid fileID;
        private string referenceNo;     
        private string fileType;
        private string userDefinedFileName;
        private string originalFileName;      
        private string uploadedFilename;
        private int fileLength;
        private string uploadBy;
        private DateTime uploadDateTime;
        private string relativePath;
        private string absolutePath;
        private string downloadLink;
     
    
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


        public Guid FileID
        {
            get { return fileID; }
            set { fileID = value; }
        }

        public string ReferenceNo
        {
            get { return referenceNo; }
            set { referenceNo = value; }
        }



        public string FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }
        public string UserDefinedFileName
        {
            get { return userDefinedFileName; }
            set { userDefinedFileName = value; }
        }


        public string OriginalFileName
        {
            get { return originalFileName; }
            set { originalFileName = value; }
        }

        public string UploadedFilename
        {
            get { return uploadedFilename; }
            set { uploadedFilename = value; }
        }

        public int FileLength
        {
            get { return fileLength; }
            set { fileLength = value; }
        }

        public string UploadBy
        {
            get { return uploadBy; }
            set { uploadBy = value; }
        }

        public DateTime UploadDateTime
        {
            get { return uploadDateTime; }
            set { uploadDateTime = value; }
        }


        public string RelativePath
        {
            get { return relativePath; }
            set { relativePath = value; }
        }
        public string AbsolutePath
        {
            get { return absolutePath; }
            set { absolutePath = value; }
        }

        public string DownloadLink
        {
            get { return downloadLink; }
            set { downloadLink = value; }
        }

        #endregion public Variable
    }
}