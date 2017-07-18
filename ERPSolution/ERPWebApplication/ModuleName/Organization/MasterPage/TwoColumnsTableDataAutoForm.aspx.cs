using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class TwoColumnsTableDataAutoForm : System.Web.UI.Page
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        private TwoColumnTables _objTwoColumnTables;
        private TwoColumnTablesController _objTwoColumnTablesController;
        private TwoColumnsTableDataAutoController _objTwoColumnsTableDataAutoController;
        private TwoColumnsTableDataAuto _objTwoColumnsTableDataAuto;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["relatedUserRoleID"] = 1;
                    ShowsysTwoColumnTables();

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void ShowsysTwoColumnTables()
        {
            try
            {
                _objTwoColumnTables = new TwoColumnTables();
                _objTwoColumnTables.RelatedUserRoleID = Convert.ToInt32(Session["relatedUserRoleID"].ToString());
                _objTwoColumnTables.EntrySystem = "A";
                EmployeeSetup objEmployeeSetup = new EmployeeSetup();
                objEmployeeSetup.CompanyID = LoginUserInformation.CompanyID;
                objEmployeeSetup.EmployeeID = LoginUserInformation.EmployeeCode;
                _objTwoColumnTablesController = new TwoColumnTablesController();
                DataTable dtTablesName = _objTwoColumnTablesController.GetRecord(_connectionString, _objTwoColumnTables,objEmployeeSetup);
                grdTableName.DataSource = null;
                grdTableName.DataBind();
                if (dtTablesName.Rows.Count > 0)
                {
                    grdTableName.DataSource = dtTablesName;
                    grdTableName.DataBind();

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        protected void grdTableName_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }

        protected void grdTableName_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string lblTableID = ((Label)grdTableName.Rows[selectedIndex].FindControl("lblTableID")).Text;
            int countCommandNameLength = e.CommandName.Length;
            if (e.CommandName.Equals("Select"))
            {
                try
                {
                    string lblTableName = ((Label)grdTableName.Rows[selectedIndex].FindControl("lblTableName")).Text;
                    ApplyDefaultData(lblTableID,lblTableName);
                    clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

                }
                catch (Exception msgException)
                {

                    clsTopMostMessageBox.Show(msgException.Message);
                }
            }
        }

        private void ApplyDefaultData(string lblTableID, string lblTableName)
        {
            try
            {
                _objTwoColumnsTableDataAuto = new TwoColumnsTableDataAuto();
                _objTwoColumnsTableDataAuto.TableID = Convert.ToInt32(lblTableID);
                _objTwoColumnsTableDataAuto.TableName = lblTableName;
                _objTwoColumnsTableDataAutoController = new TwoColumnsTableDataAutoController();
                _objTwoColumnsTableDataAutoController.Save(_connectionString, _objTwoColumnsTableDataAuto);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }


    }
}