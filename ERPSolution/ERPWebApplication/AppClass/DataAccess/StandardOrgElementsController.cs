using ERPWebApplication.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class StandardOrgElementsController : DataAccessBase
    {
        internal void LoadStandardOrgElements(ListBox listBoxStandardOrgElements)
        {
            try
            {
                //ClsL.LoadListBox(this.ConnectionString, this.SqlGetCompany(), ddlCompany, "CompanyName", "CompanyID");
                

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
        public string SqlGetStandardOrgElements()
        {
            try
            {
                string sqlString = null;
                sqlString = @"SELECT [OrgElementID]
                              ,[OrgElementName]
                          FROM [orgStandardOrgElements] 
                          WHERE [DataUsed] = 'A' ORDER BY [HierarchyID]";
                return sqlString;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}