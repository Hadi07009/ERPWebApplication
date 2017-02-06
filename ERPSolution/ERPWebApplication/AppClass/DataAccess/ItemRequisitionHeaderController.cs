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
    public class ItemRequisitionHeaderController:DataAccessBase
    {

        public ItemRequisitionHeaderController()
        { 
        
        }


        internal bool  SqlInsert(SqlCommand cmd,RequisitionHeader hdr)
        {
           bool flg=false ;
          
            try
            {
                
                var storedProcedureComandText = "INSERT INTO [ItemRequisitionHeader] ([CompanyID], [BranchID], [ItemRequisitionNo],[RequisitionBy],[RequisitionDate],[RequiredDate],[RequestedDepartmentID],[UserTypeID],[UserID],[LocationOfUse],[LocationAddress],[PriorityID],[PurposeID],[ReferenceTypeID],[ReferenceNumber],[ProjectID],[RequisitionCurrentStatus],[RequisitionComments],[CompletionStatus],[EntryDate],[EntryUserID],[ModifiedDate],[ModifiedUserID]) VALUES (" + hdr.CompanyID + ", " + hdr.BranchID + ", '" + hdr.ItemRequisitionNo + "','" + hdr.RequisitionBy + "',convert(datetime,'" + hdr.RequisitionDate + "',103),convert(datetime,'" + hdr.RequiredDate + "',103),'" + hdr.RequestedDepartment + "'," + hdr.UserType + ",'" + hdr.UserID + "'," + hdr.LocationOfUse + ",'" + hdr.LocationAddress + "'," + hdr.PriorityID + "," + hdr.PurposeID + "," + hdr.ReferenceTypeID + ",'" + hdr.ReferenceNumber + "','" + hdr.ProjectID + "'," + hdr.RequisitionCurrentStatus + ",'" + hdr.RequisitionComments + "'," + hdr.CompletionStatus + ",convert(datetime,'" + hdr.EntryDate + "',103),'" + hdr.EntryUserID + "',convert(datetime,'" + Convert.ToDateTime(hdr.ModifiedDate) + "',103),'" + hdr.ModifiedUserID + "')";
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


    

        public static string GetDataRequisitionHdr(string refNo)
        {
            return "SELECT * FROM  ItemRequisitionHeader where ItemRequisitionNo='" + refNo + "'";
        }


        internal DataTable GetDataRequisitionHdr(string refNo, int branchId, int companyID)
        {
            try
            {
                DataTable dtReqHdr = null;
                var storedProcedureComandText = "SELECT * FROM  ItemRequisitionHeader where ItemRequisitionNo='" + refNo + "' and CompanyID=" + companyID + " and BranchID=" + branchId + "";
                dtReqHdr = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtReqHdr;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }


        public string ShowRequisitionHeader(int companyID,int branchID)
        {

                string sql = " SELECT ItemRequisitionHeader.ItemRequisitionNo,ItemRequisitionHeader.PriorityID,ItemRequisitionHeader.PurposeID,"
                                + " ItemRequisitionHeader.RequestedDepartmentID, ItemRequisitionHeader.CompanyID, ItemRequisitionHeader.BranchID,"
                                + " ItemRequisitionHeader.RequisitionBy as RequisitionID, ItemRequisitionHeader.RequisitionDate, ItemRequisitionHeader.RequiredDate,"
                                + " hrEmployeeSetup.FullName as RequisitionBy,oDepartmentSetup.DepartmentName,PrioritySetupActivityWise.PriorityName   FROM  ItemRequisitionHeader "

                                + " inner join hrEmployeeSetup on ItemRequisitionHeader.RequisitionBy =hrEmployeeSetup.EmployeeID "
                                + " inner join oDepartmentSetup on oDepartmentSetup.DepartmentID=ItemRequisitionHeader.RequestedDepartmentID "
                                + " inner join PrioritySetupActivityWise on PrioritySetupActivityWise.PriorityID=ItemRequisitionHeader.PriorityID where ItemRequisitionHeader.CompanyID=" + companyID + " and ItemRequisitionHeader.BranchID=" + branchID + "";

                return sql;
          
        }





        public DataTable  GetDataRequisitionAdvancedSearch(RequisitionHeader hdr, DateTime frmdate, DateTime todate, int item)
        {

            try
            {

                DataTable dtAdSearch = null;
                var storedProcedureComandText = "";

                storedProcedureComandText = ShowRequisitionHeader(hdr.CompanyID,hdr.BranchID);


                if (hdr.PriorityID != 0)
                {
                    storedProcedureComandText += " and ItemRequisitionHeader.PriorityID=" + hdr.PriorityID;

                }

                if (hdr.RequestedDepartment != "")
                {
                    storedProcedureComandText += " and ItemRequisitionHeader.RequestedDepartmentID='" + hdr.RequestedDepartment + "'";

                }


                if (hdr.PurposeID != 0)
                {

                    storedProcedureComandText += " and ItemRequisitionHeader.PurposeID=" + hdr.PurposeID;

                }

                if (hdr.RequisitionBy != "")
                {

                    storedProcedureComandText += " and ItemRequisitionHeader.RequisitionBy='" + hdr.RequisitionBy + "'";

                }

                if (item != 0)
                {

                    
                    DataTable dt = new DataTable();

                    ItemRequisitionDetailController _objItemRequisitionDetail = new ItemRequisitionDetailController();
                    dt = _objItemRequisitionDetail.GetDataByItemDet(item,hdr.CompanyID, hdr.BranchID);

                    string aaaa = "";

                    foreach (DataRow dr in dt.Rows)
                    {

                        if (aaaa == "")
                        {

                            aaaa = "'" + dr["ItemRequisitionNo"].ToString() + "'";

                        }

                        else
                        {
                            aaaa += ",'" + dr["ItemRequisitionNo"].ToString() + "'";

                        }

                    }

                    storedProcedureComandText += " and ItemRequisitionNo in (" + aaaa + ")";

                }


                if (frmdate != null)
                {

                    storedProcedureComandText += " and RequisitionDate between convert(datetime,'" + frmdate + "',103)";

                }

                if (todate != null)
                {

                    storedProcedureComandText += " and convert(datetime,'" + todate + "',103)";

                }

                dtAdSearch = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtAdSearch;

            }

            catch( Exception ex)
            {

                throw ex;
            
            }
        }


        public static string GetRequisitionList(int companyID, int branchID)
        {
            return "SELECT ItemRequisitionNo, RequisitionDate, RequisitionBy FROM  ItemRequisitionHeader where (CompanyID=" + companyID + ") and (BranchID=" + branchID + ") ";
        }

        public static string GetRequisitionListSearch(string keybal, int companyID,int branchID)
        {
            return "SELECT ItemRequisitionNo, RequisitionDate, RequisitionBy FROM  ItemRequisitionHeader where (ItemRequisitionNo Like '" + keybal + "') or (RequisitionBy Like '" + keybal + "' and CompanyID=" + companyID + " and BranchID="+branchID+" ) ";
        }

        public static string GetDataMaxRequisitionIDByDate(DateTime requisitionDate)
        {
            return "select isnull( max(ItemRequisitionNo),0)  as ItemRequisitionMaxNo from ItemRequisitionHeader WHERE  RequisitionDate =convert(datetime,'" + requisitionDate + "',103) and CompanyID = 1 AND BranchID = 1";
        }

        public string GenerateRefNo(string connectionString, string companyID, string branchID, DateTime requisitionDate, int refNoFor)
        {
            DateTime dt = Convert.ToDateTime(requisitionDate);
            int maxnofromDate;
            string refno;
            string SQLStatement;

            maxnofromDate = 0;
            refno = clsDateProcess.DateToNumber(requisitionDate);

            // By Date
            SQLStatement = "select count(ItemRequisitionNo)+1  as ItemRequisitionMaxNo from ItemRequisitionHeader WHERE  RequisitionDate =convert(datetime,'" + requisitionDate + "',103) and CompanyID = " + companyID + " AND BranchID = " + branchID + "";


            maxnofromDate = DataProcess.GetMaximumValueUsingSQL(connectionString, SQLStatement);
            refno = refno + string.Format("{0:00}", maxnofromDate);

            // By Month

            SQLStatement = "select count(ItemRequisitionNo)+1  as ItemRequisitionMaxNo from ItemRequisitionHeader WHERE  month(RequisitionDate) =" + requisitionDate.Month + " and year(RequisitionDate) =" + requisitionDate.Year + " and CompanyID = " + companyID + " AND BranchID = " + branchID + "";


            maxnofromDate = DataProcess.GetMaximumValueUsingSQL(connectionString, SQLStatement);
            refno = refno + string.Format("{0:0000}", maxnofromDate);

            return refno;

        }


        public static string SqlFileAttachmentHdr(RequisitionHeader hdr)
        {
            string sql = "INSERT INTO [ItemRequisitionHeader] ([CompanyID], [BranchID], [ItemRequisitionNo],[RequisitionBy],[RequisitionDate],[RequiredDate],[RequestedDepartment],[UserType],[UserID],[LocationOfUse],[LocationAddress],[PriorityID],[PurposeID],[ReferenceTypeID],[ReferenceNumber],[ProjectID],[RequisitionCurrentStatus],[EntryDate],[EntryUserID],[ModifiedDate],[ModifiedUserID]) VALUES (" + hdr.CompanyID + ", " + hdr.BranchID + ", '" + hdr.ItemRequisitionNo + "','" + hdr.RequisitionBy + "',convert(datetime,'" + hdr.RequisitionDate + "',103),convert(datetime,'" + hdr.RequiredDate + "',103),'" + hdr.RequestedDepartment + "'," + hdr.UserType + ",'" + hdr.UserID + "'," + hdr.LocationOfUse + ",'" + hdr.LocationAddress + "'," + hdr.PriorityID + "," + hdr.PurposeID + "," + hdr.ReferenceTypeID + ",'" + hdr.ReferenceNumber + "','" + hdr.ProjectID + "'," + hdr.RequisitionCurrentStatus + ",convert(datetime,'" + hdr.EntryDate + "',103),'" + hdr.EntryUserID + "',convert(datetime,'" + Convert.ToDateTime(hdr.ModifiedDate) + "',103),'" + hdr.ModifiedUserID + "')";
            return sql;
        }

      

        public  void SqlUpdateCompleteStatus(string requisitionID,int companyID,int branchID)
        {
         
            try
            {

                var storedProcedureComandText = "UPDATE  ItemRequisitionHeader"
                    + " SET CompletionStatus =1, ModifiedDate = convert(datetime,'" + System.DateTime.Now.ToShortDateString() + "',103), ModifiedUserID ='a514f06e-0827-4a82-a39c-2b5336f293b8'"
                    + " WHERE (CompanyID ="+companyID+") AND (BranchID ="+branchID+") AND (ItemRequisitionNo ='" + requisitionID + "')";
                 clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
            

            }
            catch (Exception msgException)
            {

                throw msgException;
            }




        }      
    }
}