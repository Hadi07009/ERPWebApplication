using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class ClientInformationController:DataAccessBase 
    {

        public ClientInformationController()
        {
        }

        public static string GetClientList(string contextKey, int companyID, int branchID)
        {

            if (contextKey == "")
            {

                contextKey = "0";
            }

            return "SELECT a.CompanyID, a.BranchID, a.ContactID, a.FullName"
                    + " FROM  dbo.conContactDetailsName a INNER JOIN"
                    + " dbo.conContactDetailsType b ON a.ContactID = b.ContactID"

                    + " WHERE  (b.ContactTypeID = " + Convert.ToInt32(contextKey) + " and a.CompanyID=" + companyID + " and a.BranchID=" + branchID + ")";
        }

        public static string GetClientListSearch(string personTypeID, string keybal, int companyID, int branchID)
        {

            if (personTypeID == "")
            {

                personTypeID = "0";
            }


            return "SELECT  a.CompanyID,a.BranchID, a.ContactID, a.FullName"
                    + " FROM dbo.conContactDetailsName a INNER JOIN"
                    + " dbo.conContactDetailsType b ON a.ContactID = b.ContactID"
                    + " WHERE  (b.ContactTypeID = " + Convert.ToInt32(personTypeID) + ") and (a.ContactID like '" + keybal + "' or a.FullName like '" + keybal + "') and a.CompanyID=" + companyID + " and a.BranchID=" + branchID + "";
        }


        //public static string GetClientAddress(string keybal, int companyID, int branchID)
        //{
        //    string sqlString = null;
        //    sqlString = "SELECT      ty.ContactAddressType, ad.DisplayAddress, na.ContactID FROM  dbo.conContactAddressDetails ad"
        //    + " INNER JOIN dbo.conContactDetailsName na ON ad.ContactAdreessID = na.ContactAdreessID "
        //    + " INNER JOIN dbo.conSetupContactAddressType ty ON ad.ContactAddressTypeID = ty.ContactAddressTypeID"
        //    + " WHERE (na.ContactID = '" + keybal + "' and na.CompanyID=" + companyID + " and na.BranchID=" + branchID + ")";
        //    return sqlString;
        //}



        public DataTable GetClientAddress(string keybal, int companyID, int branchID)
        {
            

             try
            {
                DataTable dtAddress = null;
                var storedProcedureComandText = "SELECT      ty.ContactAddressType, ad.DisplayAddress, na.ContactID FROM  dbo.conContactAddressDetails ad"
            + " INNER JOIN dbo.conContactDetailsName na ON ad.ContactAdreessID = na.ContactAdreessID "
            + " INNER JOIN dbo.conSetupContactAddressType ty ON ad.ContactAddressTypeID = ty.ContactAddressTypeID"
            + " WHERE (na.ContactID = '" + keybal + "' and na.CompanyID=" + companyID + " and na.BranchID=" + branchID + ")";
                dtAddress = clsDataManipulation.GetData(this.ConnectionString, storedProcedureComandText);
                return dtAddress;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

    }
}