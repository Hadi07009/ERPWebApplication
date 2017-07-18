using ERPWebApplication.AppClass.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class UserSecurityCodeController : DataAccessBase
    {
        internal void LoadUserForSecurityCode(CompanySetup objCompanySetup, GridView GridViewUsers)
        {
            try
            {
                DataTable dtUser = GetUserForSecurityCode(objCompanySetup);
                GridViewUsers.DataSource = null;
                GridViewUsers.DataBind();
                if (dtUser.Rows.Count > 0)
                {
                    GridViewUsers.DataSource = dtUser;
                    GridViewUsers.DataBind();

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private DataTable GetUserForSecurityCode(CompanySetup objCompanySetup)
        {
            try
            {
                DataTable dtUser = null;
                string sqlString = @"SELECT A.EmployeeID,A.FullName,A.EntryDate,NULL AS DateOfCode FROM [hrEmployeeSetup] A WHERE NOT EXISTS ( SELECT B.EmployeeID FROM UserSecurityCode B 
                WHERE A.CompanyID = B.CompanyID AND A.EmployeeID = B.EmployeeID ) AND A.UserPermission = 1 AND A.Email != '' AND A.CompanyID = " + objCompanySetup.CompanyID + "";
                sqlString += @" UNION
                SELECT A.EmployeeID,A.FullName,A.EntryDate AS EntryDate ,B.EntryDate AS DateOfCode FROM [hrEmployeeSetup] A 
                INNER JOIN UserSecurityCode B ON A.CompanyID = B.CompanyID AND A.EmployeeID = B.EmployeeID WHERE 
                B.SecurityCodeStatus = 0 AND B.DataUsed = 'A' AND A.CompanyID = " + objCompanySetup.CompanyID + "";
                sqlString += @" ORDER BY A.EntryDate";
                dtUser = clsDataManipulation.GetData(this.ConnectionString, sqlString);
                return dtUser;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        internal void SendSecurityCode(CompanySetup objCompanySetup, UserSecurityCode objUserSecurityCode)
        {
            try
            {
                Save(objCompanySetup, objUserSecurityCode);
                SendSecurityCodeByMail(objCompanySetup, objUserSecurityCode);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void SendSecurityCodeByMail(CompanySetup objCompanySetup, UserSecurityCode objUserSecurityCode)
        {
            try
            {
                objUserSecurityCode.SecurityCode = GetSecurityCode(objCompanySetup, objUserSecurityCode);
                if (objUserSecurityCode.SecurityCode != 0)
                {
                    MailServiceSetup objMailServiceSetup = new MailServiceSetup();
                    objMailServiceSetup.MailBody = "Your security code is: " + objUserSecurityCode.SecurityCode + "";
                    EmployeeInformationController objEmployeeInformationController = new EmployeeInformationController();
                    EmployeeSetup objEmployeeSetup = new EmployeeSetup();
                    objEmployeeSetup.EmployeeID = objUserSecurityCode.UserKnownID;
                    objEmployeeSetup.CompanyID = objCompanySetup.CompanyID;
                    objMailServiceSetup.EmailTo = objEmployeeInformationController.GetEmployeeEmail(objEmployeeSetup);
                    objMailServiceSetup.MailtypeID = "1";
                    ArrayList attachDocument = new ArrayList();
                    objMailServiceSetup.AttachItem = attachDocument;
                    MailServiceController objMailServiceController = new MailServiceController();
                    objMailServiceController.eMailSendService(objCompanySetup, objMailServiceSetup);

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetSecurityCode(CompanySetup objCompanySetup, UserSecurityCode objUserSecurityCode)
        {
            try
            {
                string sql = "SELECT [SecurityCode] FROM [UserSecurityCode] WHERE DataUsed = 'A' AND SecurityCodeStatus = 0 AND [CompanyID]= " + objCompanySetup.CompanyID + " AND [EmployeeID] = '" + objUserSecurityCode.UserKnownID + "'";
                clsDataManipulation objclsDataManipulation = new clsDataManipulation();
                objUserSecurityCode.SecurityCode = objclsDataManipulation.GetSingleValue(this.ConnectionString, sql);
                return objUserSecurityCode.SecurityCode;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void Save(CompanySetup objCompanySetup, UserSecurityCode objUserSecurityCode)
        {
            try
            {
                var storedProcedureComandText = "exec [spInitiateSecurityCode] " +
                                        objCompanySetup.CompanyID + ",'" +
                                        objUserSecurityCode.UserKnownID + "','" +
                                        objCompanySetup.EntryUserName + "'";
                clsDataManipulation.StoredProcedureExecuteNonQuery(this.ConnectionString, storedProcedureComandText);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}