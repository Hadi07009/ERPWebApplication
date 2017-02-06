using ERPWebApplication.CommonClass;
using ERPWebApplication.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class FileUploadDetailController:DataAccessBase 
    {

        public FileUploadDetailController()
        { 
        
        }

        public  bool SqlInsertFileDet(SqlCommand cmd, FileUploadDetail filedett, List<FileUploadDetail> lstfileDet)
        {
            string sql = "";
            bool retflag = true;

            foreach (FileUploadDetail file in lstfileDet)
            {
                sql = "INSERT INTO [FileUploadDetail] ([CompanyID],[BranchID],[FileID],[ReferenceNo],[FileType],[UserDefinedFileName],[OriginalFileName],[UploadedFilename],[FileLength],[UploadBy],[UploadDatetime],[RelativePath],[AbsolutePath],[DownloadLink]) VALUES (" + file.CompanyID + "," + file.BranchID + ",'" + file.FileID + "','" + file.ReferenceNo + "','" + file.FileType + "','" + file.UserDefinedFileName + "','" + file.OriginalFileName + "','" + file.UploadedFilename + "'," + file.FileLength + ",'" + file.UploadBy + "',convert(datetime,'" + file.UploadDateTime + "',103),'" + file.RelativePath + "','" + file.AbsolutePath + "','" + file.DownloadLink + "')";

                if (!DataProcess.ExecuteSqlCommand(cmd, sql))
                {
                    retflag = false;
                    goto errorhand;
                }
            }

        errorhand:
            return retflag;

        }

  

        internal DataTable GetDataFileDet(string requisitionNo, int companyID, int branchID)
        {
            try
            {
                DataTable dtFileDet = null;
                var storedProcedureComandText = "SELECT * FROM  FileUploadDetail where ReferenceNo='" + requisitionNo + "'";
                dtFileDet = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtFileDet;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        public static bool SqlFileAttachmentDet(SqlCommand cmd, RequisitionDetail det, List<RequisitionDetail> itemdet)
        {
            string sql = "";
            bool retflag = true;

            foreach (RequisitionDetail itm in itemdet)
            {
                sql = "INSERT INTO [ItemRequisitionDetail] ([ItemRequisitionNo],[InventoryItemID],[RequiredItemName],[RequestedQuantity],[FinalQuantity],[PossibleRate],[FinalRate],[CountryOfOrigin],[Specification],[Brand]) VALUES ('" + itm.ItemRequisitionNo + "'," + itm.InventoryItemID + ",'" + itm.RequiredItemName + "'," + itm.RequestedQuantity + "," + itm.FinalQuantity + "," + itm.PossibleRate + "," + itm.FinalRate + ",'" + itm.CountryOfOrigin + "','" + itm.Specification + "','" + itm.Brand + "')";

                if (!DataProcess.ExecuteSqlCommand(cmd, sql))
                {
                    retflag = false;
                    goto errorhand;
                }
            }

        errorhand:
            return retflag;

        }



        public bool DeleteFileUploadDetByRequisitionNo(SqlCommand cmd, FileUploadDetail det)
        {
            string sql = "";
            bool retflag = true;


            sql = "Delete from  [FileUploadDetail] where ReferenceNo= '" + det.ReferenceNo + "'";

            if (!DataProcess.ExecuteSqlCommand(cmd, sql))
            {
                retflag = false;
                goto errorhand;
            }


        errorhand:
            return retflag;

        }

       
    }
}