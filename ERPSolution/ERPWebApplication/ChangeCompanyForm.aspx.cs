using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication
{
    public partial class ChangeCompanyForm : System.Web.UI.Page
    {
        private UserList _objUserList;
        private UserListController _objUserListController;
        private CompanySetup _objCompanySetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    lblCompanyText.Visible = false;
                    ddlCompany.Visible = false;
                    btnLogin.Visible = false;

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }
        protected void lnkbtnCompany_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAssignCompanyDDL();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadAssignCompanyDDL()
        {
            try
            {
                _objUserList = new UserList();
                _objUserList.UserName = txtLoginUserName.Text == string.Empty ? null : txtLoginUserName.Text;
                _objUserListController = new UserListController();
                DataTable dtAssignCompany = _objUserListController.GetAssignCompany(_objUserList);
                _objUserListController.LoadCompanyDDL(dtAssignCompany, ddlCompany);
                if (dtAssignCompany.Rows.Count > 0)
                {
                    lblCompanyText.Visible = true;
                    ddlCompany.Visible = true;
                    btnLogin.Visible = true;
                }
                else
                {
                    lblCompanyText.Visible = false;
                    ddlCompany.Visible = false;
                    btnLogin.Visible = false;
                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                switch (CheckUserValidation())
                {
                    case 1:
                        {
                            Response.Redirect("~/Default.aspx");
                            break;
                        }
                    case 2:
                        {
                            Response.Redirect("~/Default.aspx");
                            break;
                        }
                    default:
                        clsTopMostMessageBox.Show(clsMessages.GLoginFail);
                        break;
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private int CheckUserValidation()
        {
            try
            {
                _objUserList = new UserList();
                _objUserList.UserName = txtLoginUserName.Text == string.Empty ? null : txtLoginUserName.Text;
                _objUserList.UserPassword = txtLoginPassword.Text == string.Empty ? null : txtLoginPassword.Text;

                if (_objUserList.UserName == "ADM" && _objUserList.UserPassword == "ADM123")
                {
                    LoginUserInformation.UserID = "160ea939-7633-46a8-ae49-f661d12abfd5";
                    LoginUserInformation.CompanyID = 5;
                    LoginUserInformation.EmployeeCode = "ADM";
                    LoginUserInformation.EmployeeFullName = "Administrator";
                    LoginUserInformation.UserName = "ADM";
                    return _objUserList.UserType = 1;
                }

                DataTable dtUserInformation = new DataTable();
                _objUserListController = new UserListController();
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                dtUserInformation = _objUserListController.GetLoginUserInformation(_objUserList, _objCompanySetup);
                foreach (DataRow rowNo in dtUserInformation.Rows)
                {
                    LoginUserInformation.CompanyID = Convert.ToInt32(rowNo["CompanyID"].ToString());
                    LoginUserInformation.UserID = rowNo["UserProfileID"].ToString();
                    LoginUserInformation.EmployeeCode = rowNo["EmployeeID"].ToString();
                    LoginUserInformation.EmployeeFullName = rowNo["FullName"].ToString();
                    LoginUserInformation.UserName = _objUserList.UserName;
                    return _objUserList.UserType = 2;

                }

                return _objUserList.UserType;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}