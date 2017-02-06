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
    public class FileUploadHeaderController
    {

        public FileUploadHeaderController()
        { 
        
        }



        public static string SqlInsertFileHdr(FileUploadHeader filehdr)
        {
            string sql = "INSERT INTO [FileUploadHeader] ([CompanyID], [BranchID], [ReferenceNo],[FileCategoryID],[UploadedScreenName]) VALUES (" + filehdr.CompanyID + ", " + filehdr.BranchID + ", '" + filehdr.ReferenceNo + "'," + filehdr.FileCategoryID + ",'" + filehdr.UploadedScreenName + "')";
            return sql;
        }





        internal bool SqlInsertFileHdr(SqlCommand cmd, FileUploadHeader filehdr)
        {
            bool flg = false;

            try
            {
                //if (hdr.ItemRequisitionNo == "-1")
                //{
                //    throw new Exception(" country name is required ");

                //}


                string storedProcedureComandText = "INSERT INTO [FileUploadHeader] ([CompanyID], [BranchID], [ReferenceNo],[FileCategoryID],[UploadedScreenName]) VALUES (" + filehdr.CompanyID + ", " + filehdr.BranchID + ", '" + filehdr.ReferenceNo + "'," + filehdr.FileCategoryID + ",'" + filehdr.UploadedScreenName + "')";
                if (clsDataManipulation.ExecuteSqlCommand(cmd, storedProcedureComandText) == false)
                {
                    return flg = false;

                }

                else
                {
                    return flg = true;
                }


            }
            catch (Exception msgException)
            {

                return flg;
                throw msgException;

            }


        }

    }
}