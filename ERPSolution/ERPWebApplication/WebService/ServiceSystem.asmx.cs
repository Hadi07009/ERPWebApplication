using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ERPWebApplication.CommonClass;
using ERPWebApplication.Model;
using System.Data;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.WebService
{
    /// <summary>
    /// Summary description for ServiceSystem
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceSystem : System.Web.Services.WebService
    {
        private CompanySetup _objCompanySetup;
        #region ItemRequisition
        private ItemSetupController _objItemSetupController;
        string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string[] GetItemList(string prefixText, int count, string contextKey)
        {

            int companyID = Convert.ToInt32(contextKey.Split(':')[0]);
            int branchID = Convert.ToInt32(contextKey.Split(':')[1]);


            DataTable detitem = new DataTable();
            DataTable dt = new DataTable();
            detitem = DataProcess.GetData(_connectionString, ItemSetupController.GetItemDetail(companyID, branchID));

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(_connectionString, ItemSetupController.GetItemDetailSearch(prefixText, companyID, branchID));
            }


            string[] str;

            if (dt.Rows.Count > maxsize)
                str = new string[maxsize];
            else
                str = new string[dt.Rows.Count];

            int indx = 0;


            foreach (DataRow dr in dt.Rows)
            {
                str[indx] = dr["ItemCode"].ToString() + " : " + dr["ModelNo"].ToString();
                indx++;

                if (indx == maxsize) break;
            }

            return str;
        }





        [WebMethod]
        public string[] GetEmployeeList(string prefixText, int count, string contextKey)
        {

            int companyID = Convert.ToInt32(contextKey.Split(':')[0]);
            int branchID = Convert.ToInt32(contextKey.Split(':')[1]);


            DataTable detitem = new DataTable();
            DataTable dt = new DataTable();
            detitem = DataProcess.GetData(_connectionString, EmployeeInformationController.GetEmployeeDetail(companyID, branchID));

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(_connectionString, EmployeeInformationController.GetEmployeeDetailSearch(prefixText, companyID, branchID));
            }


            string[] str;

            if (dt.Rows.Count > maxsize)
                str = new string[maxsize];
            else
                str = new string[dt.Rows.Count];

            int indx = 0;


            foreach (DataRow dr in dt.Rows)
            {
                str[indx] = dr["EmployeeID"].ToString() + " : " + dr["FullName"].ToString();
                indx++;

                if (indx == maxsize) break;
            }

            return str;
        }


        [WebMethod]
        public string[] GetRequisitionList(string prefixText, int count, string contextKey)
        {

            int companyID = Convert.ToInt32(contextKey.Split(':')[0]);
            int branchID = Convert.ToInt32(contextKey.Split(':')[1]);

            DataTable detitem = new DataTable();
            DataTable dt = new DataTable();
            detitem = DataProcess.GetData(_connectionString, ItemRequisitionController.GetRequisitionList(companyID, branchID));

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(_connectionString, ItemRequisitionController.GetRequisitionListSearch(prefixText, companyID, branchID));
            }


            string[] str;

            if (dt.Rows.Count > maxsize)
                str = new string[maxsize];
            else
                str = new string[dt.Rows.Count];

            int indx = 0;


            foreach (DataRow dr in dt.Rows)
            {
                //sqlString[indx] = drOrganigationElement["ItemRequisitionNo"].ToString() + ":" + drOrganigationElement["RequisitionBy"].ToString() + ":" + drOrganigationElement["RequisitionDate"].ToString();
                str[indx] = dr["ItemRequisitionNo"].ToString() + " : " + dr["RequisitionBy"].ToString() + ":" + Convert.ToDateTime(dr["RequisitionDate"]).ToShortDateString();
                indx++;

                if (indx == maxsize) break;
            }

            return str;
        }



        [WebMethod]
        public string[] GetUserList(string prefixText, int count, string contextKey)
        {






            int personTypeID = Convert.ToInt32(contextKey.Split(':')[0]);
            int companyID = Convert.ToInt32(contextKey.Split(':')[1]);
            int branchID = Convert.ToInt32(contextKey.Split(':')[2]);


            DataTable detitem = new DataTable();
            DataTable dt = new DataTable();
            detitem = DataProcess.GetData(_connectionString, ClientInformationController.GetClientList(personTypeID.ToString(), companyID, branchID));

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(_connectionString, ClientInformationController.GetClientListSearch(personTypeID.ToString(), prefixText, companyID, branchID));
            }


            string[] str;

            if (dt.Rows.Count > maxsize)
                str = new string[maxsize];
            else
                str = new string[dt.Rows.Count];

            int indx = 0;


            foreach (DataRow dr in dt.Rows)
            {

                str[indx] = dr["ContactID"].ToString() + " : " + dr["FullName"].ToString();
                indx++;

                if (indx == maxsize) break;
            }

            return str;
        }

        [WebMethod]
        public List<string> GetSubledgerHeadName(string prefixText, int count, String contextKey)
        {
            List<string> SubledgerHeadList = new List<string>();
            DataTable dt = new DataTable();
            string str = "";
            string constr = contextKey;
            if (prefixText == "*")
            {
                str = "SELECT DISTINCT [SubledgerHeadName]  FROM [AccCOASubHeadSetup] ORDER BY [SubledgerHeadName]";
            }
            else
            {
                str = "SELECT DISTINCT [SubledgerHeadName] FROM [AccCOASubHeadSetup] WHERE ([SubledgerHeadName] like '%" + prefixText + "%' ) ORDER BY [SubledgerHeadName]";
            }
            dt = DataProcess.GetData(constr, str);
            foreach (DataRow dr in dt.Rows)
            {
                SubledgerHeadList.Add(dr["SubledgerHeadName"].ToString());
            }
            return SubledgerHeadList;
        }
        [WebMethod]
        public List<string> GetSubledgerType(string prefixText, int count, String contextKey)
        {
            List<string> SubledgerHeadList = new List<string>();
            DataTable dt = new DataTable();
            string str = "";
            string constr = contextKey;
            if (prefixText == "*")
            {
                str = "SELECT DISTINCT [SubLedgerTypeName]  FROM [AccCOASubLedgerTypeSetup] WHERE [DataUsed] = 'A' ORDER BY [SubLedgerTypeName]";
            }
            else
            {
                str = "SELECT DISTINCT [SubLedgerTypeName] FROM [AccCOASubLedgerTypeSetup] WHERE [DataUsed] = 'A' AND ([SubLedgerTypeName] like '%" + prefixText + "%' ) ORDER BY [SubLedgerTypeName]";
            }
            dt = DataProcess.GetData(constr, str);
            foreach (DataRow dr in dt.Rows)
            {
                SubledgerHeadList.Add(dr["SubLedgerTypeName"].ToString());
            }
            return SubledgerHeadList;
        }
        #endregion ItemRequisition


        [WebMethod]
        public string[] GetItemName(string prefixText, int count)
        {
            DataTable detitem = new DataTable();
            DataTable dt = new DataTable();
            _objItemSetupController = new ItemSetupController();
            detitem = DataProcess.GetData(_connectionString, _objItemSetupController.GetCategoryAndItem());

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(_connectionString, _objItemSetupController.GetCategoryAndItem(prefixText));
            }


            string[] str;

            if (dt.Rows.Count > maxsize)
                str = new string[maxsize];
            else
                str = new string[dt.Rows.Count];

            int indx = 0;


            foreach (DataRow dr in dt.Rows)
            {
                str[indx] = dr["ModelNo"].ToString();
                indx++;

                if (indx == maxsize) break;
            }

            return str;
        }
        [WebMethod]
        public List<string> GetEmpId(string prefixText, int count, string contextKey)
        {
            try
            {
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = Convert.ToInt32(contextKey);
                List<string> ItemList = new List<string>();
                DataTable dtEmployee = new DataTable();
                string sqlString = "";
                if (prefixText == "*")
                {
                    sqlString = "SELECT EmployeeID FROM [hrEmployeeSetup] WHERE DataUsed = 'A' AND CompanyID = " + _objCompanySetup.CompanyID + " ORDER BY EmployeeID";

                }
                else
                {
                    sqlString = "SELECT EmployeeID FROM [hrEmployeeSetup] WHERE (EmployeeID like '%" + prefixText + "%'  or (FullName like '%" + prefixText + "%')) AND DataUsed = 'A' AND CompanyID = " + _objCompanySetup.CompanyID + " ORDER BY EmployeeID";

                }

                dtEmployee = clsDataManipulation.GetData(_connectionString, sqlString);
                foreach (DataRow dr in dtEmployee.Rows)
                {
                    ItemList.Add(dr["EmployeeID"].ToString());
                }
                return ItemList;

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
        [WebMethod]
        public List<string> GetAllActiveEmpId(string prefixText, int count, string contextKey)
        {
            try
            {
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = Convert.ToInt32(contextKey);
                List<string> ItemList = new List<string>();
                DataTable dtEmployee = new DataTable();
                string sqlString = "";
                if (prefixText == "*")
                {
                    sqlString = "SELECT EmployeeID FROM [hrEmployeeSetup] WHERE DataUsed = 'A' ORDER BY EmployeeID";

                }
                else
                {
                    sqlString = "SELECT EmployeeID FROM [hrEmployeeSetup] WHERE (EmployeeID like '%" + prefixText + "%'  or (FullName like '%" + prefixText + "%')) AND DataUsed = 'A' ORDER BY EmployeeID";

                }

                dtEmployee = clsDataManipulation.GetData(_connectionString, sqlString);
                foreach (DataRow dr in dtEmployee.Rows)
                {
                    ItemList.Add(dr["EmployeeID"].ToString());
                }
                return ItemList;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

    }
}
