using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ERPWebApplication.CommonClass;
using ERPWebApplication.Model;
using System.Data;
using ERPWebApplication.AppClass.DataAccess;

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
        private ItemSetupController _objItemSetupController;
        string connectionStringreq = System.Configuration.ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();

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
            DataTable dt = new DataTable ();
            detitem = DataProcess.GetData(connectionStringreq, ItemSetupController.GetItemDetail(companyID,branchID));

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(connectionStringreq, ItemSetupController.GetItemDetailSearch(prefixText, companyID, branchID));
            }


            string[] str;

            if (dt.Rows.Count > maxsize)
                str = new string[maxsize];
            else
                str = new string[dt.Rows.Count];

            int indx = 0;


            foreach (DataRow  dr in dt.Rows)
            {
                str[indx] = dr["ItemCode"].ToString() + " : " + dr["ModelNo"].ToString();
                indx++;

                if (indx == maxsize) break;
            }

            return str;
        }


        [WebMethod]
        public string[] GetItemName(string prefixText, int count)
        {
            DataTable detitem = new DataTable();
            DataTable dt = new DataTable();
            _objItemSetupController = new ItemSetupController();
            detitem = DataProcess.GetData(connectionStringreq, _objItemSetupController.GetCategoryAndItem());

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(connectionStringreq, _objItemSetupController.GetCategoryAndItem(prefixText));
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
        public string[] GetEmployeeList(string prefixText, int count, string contextKey)
        {

            int companyID = Convert.ToInt32(contextKey.Split(':')[0]);
            int branchID = Convert.ToInt32(contextKey.Split(':')[1]);
           

            DataTable detitem = new DataTable();
            DataTable dt = new DataTable();
            detitem = DataProcess.GetData(connectionStringreq, EmployeeInformationController.GetEmployeeDetail(companyID,branchID));

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(connectionStringreq, EmployeeInformationController.GetEmployeeDetailSearch(prefixText,companyID,branchID));
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
            detitem = DataProcess.GetData(connectionStringreq, ItemRequisitionController.GetRequisitionList(companyID, branchID));

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(connectionStringreq, ItemRequisitionController.GetRequisitionListSearch(prefixText, companyID, branchID));
            }


            string[] str;

            if (dt.Rows.Count > maxsize)
                str = new string[maxsize];
            else
                str = new string[dt.Rows.Count];

            int indx = 0;


            foreach (DataRow dr in dt.Rows)
            {
                //str[indx] = dr["ItemRequisitionNo"].ToString() + ":" + dr["RequisitionBy"].ToString() + ":" + dr["RequisitionDate"].ToString();
                str[indx] = dr["ItemRequisitionNo"].ToString() + " : " + dr["RequisitionBy"].ToString() +":" + Convert.ToDateTime(dr["RequisitionDate"]).ToShortDateString();
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
            detitem = DataProcess.GetData(connectionStringreq, ClientInformationController.GetClientList(personTypeID.ToString(), companyID, branchID));

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(connectionStringreq, ClientInformationController.GetClientListSearch(personTypeID.ToString(), prefixText, companyID, branchID));
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

    }
}
