using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ERPWebApplication.CommonClass;
using ERPWebApplication.Model;
using System.Data;
using System.Collections;

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
        private SqlGenerationForItemDetail _objSqlGenerationForItemDetail;
        string connectionStringreq = System.Configuration.ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string[] GetItemList(string prefixText, int count)
        {

           

            DataTable detitem = new DataTable();
            DataTable dt = new DataTable ();
            detitem = DataProcess.GetData(connectionStringreq, SqlGenerationForItemDetail.GetItemDetail());

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(connectionStringreq, SqlGenerationForItemDetail.GetItemDetailSearch(prefixText));
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
            _objSqlGenerationForItemDetail = new SqlGenerationForItemDetail();
            detitem = DataProcess.GetData(connectionStringreq, _objSqlGenerationForItemDetail.GetCategoryAndItem());

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(connectionStringreq, _objSqlGenerationForItemDetail.GetCategoryAndItem(prefixText));
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
        public string[] GetEmployeeList(string prefixText, int count)
        {

           

            DataTable detitem = new DataTable();
            DataTable dt = new DataTable();
            detitem = DataProcess.GetData(connectionStringreq, SqlGenerationForEmployee.GetEmployeeDetail());

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(connectionStringreq, SqlGenerationForEmployee.GetEmployeeDetailSearch(prefixText));
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
        public string[] GetRequisitionList(string prefixText, int count)
        {

            DataTable detitem = new DataTable();
            DataTable dt = new DataTable();
            detitem = DataProcess.GetData(connectionStringreq, SqlGenerateForItemRequisition.GetRequisitionList());

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(connectionStringreq, SqlGenerateForItemRequisition.GetRequisitionListSearch(prefixText));
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
                str[indx] = dr["ItemRequisitionNo"].ToString() + " : " + dr["RequisitionBy"].ToString();
                indx++;

                if (indx == maxsize) break;
            }

            return str;
        }



        [WebMethod]
        public string[] GetUserList(string prefixText, int count, string contextKey)
        {

            DataTable detitem = new DataTable();
            DataTable dt = new DataTable();
            detitem = DataProcess.GetData(connectionStringreq, sqlGenerationClientInformation.GetClientList(contextKey));

            int maxsize = 1000;

            if (prefixText == "*")
            {
                dt = detitem;
            }
            else
            {
                prefixText = "%" + prefixText + "%";
                dt = DataProcess.GetData(connectionStringreq, sqlGenerationClientInformation.GetClientListSearch(contextKey,prefixText));
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
