using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using System.Data;

namespace ERPWebApplication.WebUserControls
{
    public partial class OrganizationalChartControl : System.Web.UI.UserControl
    {
        private OrganizationalChartSetup _objOrganizationalChartSetup;
        private UCOrganizationalChartController _objUCOrganizationalChartController;
        private EmployeeSetupController _objEmployeeSetupController;
        private CompanySetup _objCompanySetup;
        private BranchSetup _objBranchSetup;
        private DepartmentSetup _objDepartmentSetup;
        private SectionSetup _objSectionSetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    UCGetOrganizationElements();
                }
                DropDownList ddlElementDataCompany = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                ddlElementDataCompany.Enabled = false;
                if (ddlElementDataCompany.Items.Count >2)
                {
                    ddlElementDataCompany.Enabled = true;
                    
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void UCGetOrganizationElements()
        {
            try
            {
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                _objOrganizationalChartSetup.CompanyID = LoginUserInformation.CompanyID;
                _objUCOrganizationalChartController = new UCOrganizationalChartController();
                _objUCOrganizationalChartController.GetOrganizationElementsGV(GridViewOrganizationalChart, _objOrganizationalChartSetup);


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private int gridRowIndex = 0;
        protected void GridViewOrganizationalChart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                DropDownList ddlElementData = (DropDownList)e.Row.FindControl("ddlElementData");

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    switch (gridRowIndex)
                    {
                        case 0:
                            {
                                UCLoadCompany(ddlElementData);
                                gridRowIndex++;
                                break;
                            }
                        case 1:
                            {
                                UCLoadBranch(ddlElementData);
                                gridRowIndex++; break;
                            }
                        case 2:
                            {
                                UCLoadDepartment(ddlElementData);
                                gridRowIndex++; break;
                            }
                        case 3:
                            {
                                UCLoadSection(ddlElementData);
                                gridRowIndex++; break;
                            }
                        case 4:
                            {
                                UCLoadTeam(ddlElementData);
                                gridRowIndex++; break;
                            }
                        default:
                            break;
                    }
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void UCLoadTeam(DropDownList ddlElementData)
        {
            try
            {
                _objSectionSetup = new SectionSetup();
                DropDownList ddlElementDataCompany = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                DropDownList ddlElementDataBranch = (DropDownList)GridViewOrganizationalChart.Rows[1].FindControl("ddlElementData");
                DropDownList ddlElementDataDepartment = (DropDownList)GridViewOrganizationalChart.Rows[2].FindControl("ddlElementData");
                DropDownList ddlElementDataSection = (DropDownList)GridViewOrganizationalChart.Rows[3].FindControl("ddlElementData");
                _objSectionSetup.CompanyID = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                _objSectionSetup.BranchID = Convert.ToInt32(ddlElementDataBranch.SelectedValue);
                _objSectionSetup.DepartmentID = Convert.ToInt32(ddlElementDataDepartment.SelectedValue);
                _objSectionSetup.SectionID = Convert.ToInt32(ddlElementDataSection.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadTeamDDL(ddlElementData, _objSectionSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void UCLoadSection(DropDownList ddlElementData)
        {
            try
            {
                _objDepartmentSetup = new DepartmentSetup();
                DropDownList ddlElementDataCompany = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                DropDownList ddlElementDataBranch = (DropDownList)GridViewOrganizationalChart.Rows[1].FindControl("ddlElementData");
                DropDownList ddlElementDataDepartment = (DropDownList)GridViewOrganizationalChart.Rows[2].FindControl("ddlElementData");
                _objDepartmentSetup.CompanyID = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                _objDepartmentSetup.BranchID = Convert.ToInt32(ddlElementDataBranch.SelectedValue);
                _objDepartmentSetup.DepartmentID = Convert.ToInt32(ddlElementDataDepartment.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadSectionDDL(ddlElementData, _objDepartmentSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void UCLoadCompany(DropDownList ddlElementData)
        {
            try
            {
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadCompanyDDL(ddlElementData);
                foreach (ListItem itemNo in ddlElementData.Items)
                {
                    if (Convert.ToInt32(itemNo.Value) == LoginUserInformation.CompanyID)
                    {
                        ddlElementData.SelectedValue = LoginUserInformation.CompanyID.ToString();

                    }

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void UCLoadBranch(DropDownList ddlElementData)
        {
            try
            {
                _objCompanySetup = new CompanySetup();
                DropDownList ddlElementDataCompany = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                _objCompanySetup.CompanyID = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadBranchDDL(ddlElementData, _objCompanySetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void UCLoadDepartment(DropDownList ddlElementData)
        {
            try
            {
                _objBranchSetup = new BranchSetup();
                DropDownList ddlElementDataCompany = (DropDownList)GridViewOrganizationalChart.Rows[0].FindControl("ddlElementData");
                DropDownList ddlElementDataBranch = (DropDownList)GridViewOrganizationalChart.Rows[1].FindControl("ddlElementData");
                _objBranchSetup.CompanyID = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                _objBranchSetup.BranchID = Convert.ToInt32(ddlElementDataBranch.SelectedValue);
                _objEmployeeSetupController = new EmployeeSetupController();
                _objEmployeeSetupController.LoadDepartmentDDL(ddlElementData, _objBranchSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void ddlElementData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlSelected = (DropDownList)sender;
                GridViewRow rowSelected = (GridViewRow)ddlSelected.NamingContainer;
                int selectedIndex = rowSelected.RowIndex;
                switch (selectedIndex)
                {
                    case 0:
                        {
                            DropDownList ddlElementDataBranch = (DropDownList)GridViewOrganizationalChart.Rows[1].FindControl("ddlElementData");
                            this.UCLoadBranch(ddlElementDataBranch);
                            break;
                        }
                    case 1:
                        {
                            DropDownList ddlElementDataDepartment = (DropDownList)GridViewOrganizationalChart.Rows[2].FindControl("ddlElementData");
                            this.UCLoadDepartment(ddlElementDataDepartment);
                            break;
                        }
                    case 2:
                        {
                            DropDownList ddlElementDataSection = (DropDownList)GridViewOrganizationalChart.Rows[3].FindControl("ddlElementData");
                            this.UCLoadSection(ddlElementDataSection);
                            break;
                        }
                    case 3:
                        {
                            DropDownList ddlElementDataTeam = (DropDownList)GridViewOrganizationalChart.Rows[4].FindControl("ddlElementData");
                            this.UCLoadTeam(ddlElementDataTeam);
                            break;
                        }
                    default:
                        break;
                }


            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private int _empCompany;
        private int _empBranch;
        private int _empDepartment;
        private int _empSection;
        private int _empTeam;
        public int empCompany
        {
            get
            {
                this.organigationalValue();
                return _empCompany;
            }
        }
        public int empBranch
        {
            get
            {
                this.organigationalValue();
                return _empBranch;
            }
        }
        public int empDepartment
        {
            get
            {
                this.organigationalValue();
                return _empDepartment;
            }
        }
        public int empSection
        {
            get
            {
                this.organigationalValue();
                return _empSection;
            }
        }
        public int empTeam
        {
            get
            {
                this.organigationalValue();
                return _empTeam;
            }
        }
        public DataTable empValueAsTable
        {
            get
            {
                return this.organigationalValueAsTable();
            }
        }
        private void organigationalValue()
        {
            try
            {
                foreach (GridViewRow rowNoInGrid in GridViewOrganizationalChart.Rows)
                {
                    DropDownList ddlElementDataCompany = (DropDownList)rowNoInGrid.FindControl("ddlElementData");
                    switch (rowNoInGrid.RowIndex)
                    {
                        case 0:
                            {
                                _empCompany = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                                break;
                            }
                        case 1:
                            {
                                _empBranch = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                                break;
                            }
                        case 2:
                            {
                                _empDepartment = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                                break;
                            }
                        case 3:
                            {
                                _empSection = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                                break;
                            }
                        case 4:
                            {
                                _empTeam = Convert.ToInt32(ddlElementDataCompany.SelectedValue);
                                break;
                            }
                        default:
                            break;
                    }

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        private DataTable organigationalValueAsTable()
        {
            try
            {
                var dtEmployeeInfo = new DataTable();
                DataRow drOrganigationElement;
                dtEmployeeInfo.Columns.Add(new DataColumn("EntityTypeID", typeof(int)));
                dtEmployeeInfo.Columns.Add(new DataColumn("EntityID", typeof(int)));
                foreach (GridViewRow rowNoInGrid in GridViewOrganizationalChart.Rows)
                {
                    DropDownList ddlElementDataCompany = (DropDownList)rowNoInGrid.FindControl("ddlElementData");
                    OrganizationalChartSetup objOrganizationalChartSetup = new OrganizationalChartSetup();
                    objOrganizationalChartSetup.EntityID = Convert.ToInt32( ddlElementDataCompany.SelectedValue);
                    if (objOrganizationalChartSetup.EntityID == -1)
                    {
                        break;
                        
                    }

                    switch (rowNoInGrid.RowIndex)
                    {
                        case 1:
                            {
                                drOrganigationElement = dtEmployeeInfo.NewRow();
                                drOrganigationElement[0] = 2; drOrganigationElement[1] = objOrganizationalChartSetup.EntityID;
                                dtEmployeeInfo.Rows.Add(drOrganigationElement);
                                break;
                            }
                        case 2:
                            {
                                drOrganigationElement = dtEmployeeInfo.NewRow();
                                drOrganigationElement[0] = 3;drOrganigationElement[1] = objOrganizationalChartSetup.EntityID;
                                dtEmployeeInfo.Rows.Add(drOrganigationElement);
                                break;
                            }
                        case 3:
                            {
                                drOrganigationElement = dtEmployeeInfo.NewRow();
                                drOrganigationElement[0] = 4;drOrganigationElement[1] = objOrganizationalChartSetup.EntityID;
                                dtEmployeeInfo.Rows.Add(drOrganigationElement);
                                break;
                            }
                        case 4:
                            {
                                drOrganigationElement = dtEmployeeInfo.NewRow();
                                drOrganigationElement[0] = 5;drOrganigationElement[1] = objOrganizationalChartSetup.EntityID;
                                dtEmployeeInfo.Rows.Add(drOrganigationElement);
                                break;
                            }
                        default:
                            break;
                    }


                }
                return dtEmployeeInfo;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}