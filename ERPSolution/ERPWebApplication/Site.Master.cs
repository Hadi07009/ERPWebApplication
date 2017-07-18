using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using System.Data;
using System.IO;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        private UserPermissionController _objUserPermissionController;
        private ProjectSetup _objProjectSetup;
        private UserList _objUserList;
        private UserListController _objUserListController;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    GetMenuData();
                    if (Page.Title == "Home Page")
                    {
                        NavigationMenu.Visible = false;

                    }

                    ControlPageTitle();
                    ControllnkbtnChangeCompany();

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void ControlPageTitle()
        {
            try
            {
                _objProjectSetup = new ProjectSetup();
                _objProjectSetup.PageTitle = Page.Title == "" ? null : Page.Title;
                lblWelcomeMessage.Text = clsMessages.GWelcome;
                lblLoginEmployeeName.Text = LoginUserInformation.EmployeeFullName;
                if (_objProjectSetup.PageTitle != null )
                {
                    lblAt.Text = clsMessages.GYouAreAt;
                    lblPageTitle.Text = _objProjectSetup.PageTitle+clsMessages.GFullStop;

                }
                else
                {
                    lblAt.Text = string.Empty;
                    lblPageTitle.Text = string.Empty;
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void GetMenuData()
        {
            try
            {
                DataTable table = new DataTable();
                _objUserPermissionController = new UserPermissionController();
                if (LoginUserInformation.UserID == "160ea939-7633-46a8-ae49-f661d12abfd5")
                {
                    table = _objUserPermissionController.GetData();
                }
                else
                {
                    EmployeeSetup objEmployeeSetup = new EmployeeSetup();
                    objEmployeeSetup.CompanyID = LoginUserInformation.CompanyID;
                    objEmployeeSetup.EmployeeID = LoginUserInformation.EmployeeCode;
                    table = _objUserPermissionController.GetData(objEmployeeSetup);
                    
                }
                
                DataView view = new DataView(table);
                view.RowFilter = "PNodeTypeID = 111";
                foreach (DataRowView row in view)
                {
                    MenuItem menuItem = new MenuItem(row["ActivityName"].ToString(),
                    row["NodeTypeID"].ToString());
                    menuItem.NavigateUrl = row["FormName"].ToString();
                    NavigationMenu.Items.Add(menuItem);
                    AddChildItems(table, menuItem);
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddChildItems(DataTable table, MenuItem menuItem)
        {
            try
            {
                DataView viewItem = new DataView(table);
                viewItem.RowFilter = "PNodeTypeID=" + menuItem.Value;
                foreach (DataRowView childView in viewItem)
                {
                    MenuItem childItem = new MenuItem(childView["ActivityName"].ToString(),
                    childView["NodeTypeID"].ToString());
                    childItem.NavigateUrl = childView["FormName"].ToString();
                    menuItem.ChildItems.Add(childItem);
                    AddChildItems(table, childItem);
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void lnkbtnLoginoff_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/HomePageForm.aspx");

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void lnkbtnChangeCompany_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/ChangeCompanyForm.aspx");
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }
        private void ControllnkbtnChangeCompany()
        {
            try
            {
                _objUserList = new UserList();
                _objUserList.UserName = LoginUserInformation.UserName;
                _objUserListController = new UserListController();
                DataTable dtAssignCompany = _objUserListController.GetAssignCompany(_objUserList);
                if (dtAssignCompany.Rows.Count > 1)
                {
                    lnkbtnChangeCompany.Visible = true;
                }
                else
                {
                    lnkbtnChangeCompany.Visible = false;
                    
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}