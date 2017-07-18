using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.CommonClass
{
    public static class LoginUserInformation
    {
        public static string UserID
        {
            get { return HttpContext.Current.Session["@#$$%@)userID(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)userID(@^&^&%"] = value; }
        }
        public static string UserName
        {
            get { return HttpContext.Current.Session["@#$$%@)userName(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)userName(@^&^&%"] = value; }
        }
        public static int CompanyID
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["@#$$%@)lastPositionNo(@^&^&%"].ToString()); }
            set { HttpContext.Current.Session["@#$$%@)lastPositionNo(@^&^&%"] = value; }
        }
        public static string EmployeeCode
        {
            get { return HttpContext.Current.Session["@#$$%@)employeeCode(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)employeeCode(@^&^&%"] = value; }

        }
        public static string EmployeeFullName
        {
            get { return HttpContext.Current.Session["@#$$%@)employeeFullName(@^&^&%"].ToString(); }
            set { HttpContext.Current.Session["@#$$%@)employeeFullName(@^&^&%"] = value; }

        }
        public static int BranchID
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["@#$$%@)branchID(@^&^&%"].ToString()); }
            set { HttpContext.Current.Session["@#$$%@)branchID(@^&^&%"] = value; }
        }


    }
}