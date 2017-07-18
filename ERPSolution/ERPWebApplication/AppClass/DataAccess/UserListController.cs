using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class UserListController : DataAccessBase
    {
        internal void Save(UserList objUserList)
        {
            try
            {
                if (objUserList.UserPassword.ToString().Length < 6)
                {
                    throw new Exception("Passwords are required to be a minimum of 6 characters in length.");

                }

                if (objUserList.UserPassword != objUserList.ConfirmPassword)
                {
                    throw new Exception("The password and confirmation password do not match.");

                }

                if (objUserList.SecurityCode != CheckSecurityCode(objUserList))
                {
                    throw new Exception("The security code and email do not match.");

                }

                if (CheckUserNameWithCompany(objUserList) > 0)
                {
                    throw new Exception("User name already exist ");

                }

                var storedProcedureComandText = "exec [uUserRegistration] '" +
                                        objUserList.UserPassword + "','" +
                                        objUserList.SecurityCode + "','" +
                                        objUserList.UserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int CheckUserName(UserList objUserList)
        {
            try
            {
                int countUserProfileId = 0;
                string sqlString = "SELECT ISNULL( COUNT( UserProfileID),0) FROM uUserList WHERE UserName = '" + objUserList.UserName + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                countUserProfileId = objclsDataManipulation.GetSingleValue(this.ConnectionString, sqlString);
                return countUserProfileId;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private int CheckUserNameWithCompany(UserList objUserList)
        {
            try
            {
                int countUserProfileId = 0;
                string sqlString = "  SELECT ISNULL( COUNT( A.UserProfileID),0) FROM uUserList A INNER JOIN uUserProfile B ON A.UserProfileID = B.UserProfileID " +
                   " INNER JOIN UserSecurityCode C ON B.SecurityCode = C.SecurityCode WHERE B.DataUsed = 'A' AND C.DataUsed = 'A' AND " +
                   " C.CompanyID =(SELECT CompanyID FROM UserSecurityCode WHERE SecurityCode = " + objUserList.SecurityCode + ") AND A.UserName = '" + objUserList.UserName + "' ";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                countUserProfileId = objclsDataManipulation.GetSingleValue(this.ConnectionString, sqlString);
                return countUserProfileId;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private string CheckSecurityCode(UserList objUserList)
        {
            try
            {
                string targetSecurityCode = null;
                string sql = @" SELECT B.SecurityCode FROM [hrEmployeeSetup] A 
                INNER JOIN UserSecurityCode B ON A.CompanyID = B.CompanyID AND A.EmployeeID = B.EmployeeID WHERE 
                B.SecurityCodeStatus = 0 AND B.DataUsed = 'A' AND A.Email = '" + objUserList.UserEmail + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                targetSecurityCode = objclsDataManipulation.GetSingleValueAsString(this.ConnectionString, sql);
                return targetSecurityCode;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }



        internal DataTable GetLoginUserInformation(UserList objUserList)
        {
            try
            {
                DataTable dtInformation = new DataTable();
                string sqlString = @"SELECT A.UserProfileID,C.CompanyID,C.EmployeeID,D.FullName FROM uUserList A 
                INNER JOIN uUserProfile B 
                ON A.UserProfileID = B.UserProfileID
                INNER JOIN UserSecurityCode C ON B.SecurityCode = C.SecurityCode
                INNER JOIN hrEmployeeSetup D ON C.CompanyID = D.CompanyID AND C.EmployeeID = D.EmployeeID 
                WHERE C.DataUsed = 'A' AND A.UserName = '" + objUserList.UserName + "' AND B.[Password] = '" + objUserList.UserPassword + "'";
                dtInformation = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtInformation;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        internal DataTable GetLoginUserInformation(UserList objUserList, CompanySetup objCompanySetup)
        {
            try
            {
                DataTable dtInformation = new DataTable();
                string sqlString = @"SELECT A.UserProfileID,C.CompanyID,C.EmployeeID,D.FullName FROM uUserList A 
                INNER JOIN uUserProfile B 
                ON A.UserProfileID = B.UserProfileID
                INNER JOIN UserSecurityCode C ON B.SecurityCode = C.SecurityCode
                INNER JOIN hrEmployeeSetup D ON C.CompanyID = D.CompanyID AND C.EmployeeID = D.EmployeeID 
                WHERE C.DataUsed = 'A' AND A.UserName = '" + objUserList.UserName + "' AND B.[Password] = '" + objUserList.UserPassword + "' AND C.CompanyID = " + objCompanySetup.CompanyID + "";
                dtInformation = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtInformation;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal DataTable GetAssignCompany(UserList objUserList)
        {
            try
            {
                DataTable dtUserCompanyList = new DataTable();
                string sqlString = @"SELECT DISTINCT E.CompanyID,E.CompanyName FROM uUserList A 
                                INNER JOIN uUserProfile B ON A.UserProfileID = B.UserProfileID
                                INNER JOIN UserSecurityCode C ON B.SecurityCode = C.SecurityCode
                                INNER JOIN uUsersInRoles D ON C.EmployeeID = D.UserId
                                INNER JOIN [comCompanySetup] E ON D.CompanyID = E.CompanyID
                WHERE B.DataUsed = 'A' AND C.DataUsed = 'A' AND D.DataUsed = 'A' AND E.DataUsed = 'A' AND A.UserName = '" + objUserList.UserName + "'";
                dtUserCompanyList = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtUserCompanyList;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void LoadCompanyDDL(DataTable dtAssignCompany, DropDownList ddlCompany)
        {
            try
            {
                ClsDropDownListController.LoadDropDownListFromDataTable(dtAssignCompany, ddlCompany, "CompanyName", "CompanyID");
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}