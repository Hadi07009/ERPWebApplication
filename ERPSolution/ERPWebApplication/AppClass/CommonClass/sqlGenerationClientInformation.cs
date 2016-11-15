using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ERPWebApplication.CommonClass
{
    public class sqlGenerationClientInformation
    {



        public sqlGenerationClientInformation()
        { 
        }



        public static string GetClientList(string contextKey)
        {

            if (contextKey == "")
            {

                contextKey="0";
            }
            
            
            return "SELECT  dbo.conContactDetailsName.CompanyID, dbo.conContactDetailsName.BranchID, dbo.conContactDetailsName.ContactID, dbo.conContactDetailsName.FullName"
                    +" FROM  dbo.conContactDetailsName INNER JOIN"
                    +" dbo.conContactDetailsType ON dbo.conContactDetailsName.ContactID = dbo.conContactDetailsType.ContactID"

                    + " WHERE  (dbo.conContactDetailsType.ContactTypeID = " + Convert.ToInt32(contextKey) + ")";
        }


        public static string GetClientListSearch(string contextKey,string keybal)
        {

            if (contextKey == "")
            {

                contextKey = "0";
            }
            
            
            return "SELECT  dbo.conContactDetailsName.CompanyID, dbo.conContactDetailsName.BranchID, dbo.conContactDetailsName.ContactID, dbo.conContactDetailsName.FullName"
                    +" FROM dbo.conContactDetailsName INNER JOIN"
                    +" dbo.conContactDetailsType ON dbo.conContactDetailsName.ContactID = dbo.conContactDetailsType.ContactID"
                    + " WHERE  (dbo.conContactDetailsType.ContactTypeID = " + Convert.ToInt32(contextKey) + ") and (dbo.conContactDetailsName.ContactID like '" + keybal + "' or dbo.conContactDetailsName.FullName like '" + keybal + "')";
        }





        public static string GetClientAddress(string keybal)
        {
            return "SELECT     dbo.conSetupContactAddressType.ContactAddressType, dbo.conContactAddressDetails.DisplayAddress, dbo.conContactDetailsName.ContactID FROM  dbo.conContactAddressDetails"
            +" INNER JOIN dbo.conContactDetailsName ON dbo.conContactAddressDetails.ContactAdreessID = dbo.conContactDetailsName.ContactAdreessID "
            +" INNER JOIN dbo.conSetupContactAddressType ON dbo.conContactAddressDetails.ContactAddressTypeID = dbo.conSetupContactAddressType.ContactAddressTypeID"
            +" WHERE (dbo.conContactDetailsName.ContactID = '" + keybal + "')";
        }




    }
}