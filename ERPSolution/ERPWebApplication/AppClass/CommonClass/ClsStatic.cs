using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.CommonClass
{
    public class ClsStatic
    {
        public ClsStatic()
        { 
        
        }

        public static string link3sessionUserId = "*_%^&**link3sessionUserId*_%^&**";
        public static String sessionTempDatatable = "*_%^&**link3TempDatatable*_%^&**";
        public static String sessionReport = "*_%^&**scblsessionsessionReport*_%^&**";




        public static string  sessionCompanyID = "*_%^&**scblsessionCompanyID*_%^&**";

        public static string sessionBranchID = "*_%^&**scblsessionbranchID*_%^&**";


        public static void CheckUserAuthentication()
        {
            current.PermissionPrm = "";
            current.FormParameter = "";
            if (HttpContext.Current.Session.Count == 0)
                HttpContext.Current.Response.Redirect("~/frmLogin.aspx");


            if (current.UserId == "")
                HttpContext.Current.Response.Redirect("~/frmLogin.aspx");

        }


        public static void MsgConfirmBox(Button btn, string strMessage)
        {
            btn.Attributes.Add("onclick", "return confirm('" + strMessage + "');");

        }
        public static void MsgConfirmBox(LinkButton btn, string strMessage)
        {
            btn.Attributes.Add("onclick", "return confirm('" + strMessage + "');");

        }
    }


    public static class current
    {

        public static String CompanyCode
        {
            get { return ConfigurationManager.AppSettings["companycode"].ToString(); }

        }
        public static String CompanyName
        {
            get { return ConfigurationManager.AppSettings["pagetitle"].ToString(); }

        }

        public static String CompanyAddress
        {
            get { return ConfigurationManager.AppSettings["companyaddress"].ToString(); }

        }

        public static String UserId
        {


            get
            {
                if (HttpContext.Current.Session["@#$$%@)UserId(@^&^&%"] == null) { return ""; }

                return HttpContext.Current.Session["@#$$%@)UserId(@^&^&%"].ToString();
            }
            set { HttpContext.Current.Session["@#$$%@)UserId(@^&^&%"] = value; }


        }

        public static String UserName
        {
            get { return HttpContext.Current.Session["@#$$%@)UserName(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)UserName(@^&^&%"] = value; }
        }

        public static String UserDesignation
        {
            get { return HttpContext.Current.Session["@#$$%@)UserDesignation(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)UserDesignation(@^&^&%"] = value; }
        }

        public static String UserDepartment
        {
            get { return HttpContext.Current.Session["@#$$%@)UserDepartment(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)UserDepartment(@^&^&%"] = value; }
        }

        public static String UserEmail
        {
            get { return HttpContext.Current.Session["@#$$%@)Email(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)Email(@^&^&%"] = value; }
        }

        
        public static String PermissionPrm
        {
            get { return HttpContext.Current.Session["@#$$%@)PermissionPrm(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)PermissionPrm(@^&^&%"] = value; }
        }
        public static String FormParameter
        {
            get { return HttpContext.Current.Session["@#$$%@)FormParameter(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)FormParameter(@^&^&%"] = value; }
        }

        public static ClsReport SessionReport
        {
            get { return (ClsReport)HttpContext.Current.Session["@#$$%@)SessionReport(@^&^&%"]; }
            set { HttpContext.Current.Session["@#$$%@)SessionReport(@^&^&%"] = value; }
        }

        public static ReportDocument ReportDocument
        {
            get { return (ReportDocument)HttpContext.Current.Session["@#$$%@)ReportDocument(@^&^&%"]; }
            set { HttpContext.Current.Session["@#$$%@)FormParameter(@^&^&%"] = value; }
        }
    }
}