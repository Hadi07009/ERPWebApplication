using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.DataAccess;
using System.Data;

namespace ERPWebApplication.ModuleName.HRMS.MasterPage
{
    public partial class OrganizationalChartForm : System.Web.UI.Page
    {
        private OrganizationalChartSetup _objOrganizationalChartSetup;
        private OrganizationalChartSetupController _objOrganizationalChartSetupController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadCompany(ddlCompany);
                    LoadStandardOrgElements(ListBoxStandardOrgElements);
                    LoadCompany(ddlCompanyChart);
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadStandardOrgElements(ListBox listBoxStandardOrgElements)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadStandardOrgElementsDDL(listBoxStandardOrgElements);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadCompany(DropDownList ddlCompany)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadCompanyDDL(ddlCompany);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }


        protected void btnForword_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in ListBoxStandardOrgElements.Items)
                {
                    if (item.Selected)
                    {
                        if (ListBoxOrganizationElements.Items.Contains(item))
                        {
                            throw new Exception("this element already selected.");

                        }
                        
                        ListBoxOrganizationElements.Items.Add(new ListItem(item.Text, item.Value));
                        ListBoxOrganizationElements.AppendDataBoundItems = true;
                    }
                }
                
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnForwordAll_Click(object sender, EventArgs e)
        {
            try
            {
                ListBoxOrganizationElements.Items.Clear();
                foreach (ListItem item in ListBoxStandardOrgElements.Items)
                {
                    ListBoxOrganizationElements.Items.Add(item);
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListItem> deletedItems = new List<ListItem>();
                foreach (ListItem item in ListBoxOrganizationElements.Items)
                {
                    if (item.Selected)
                    {
                        deletedItems.Add(item);
                    }
                }

                foreach (ListItem item in deletedItems)
                {
                    ListBoxOrganizationElements.Items.Remove(item);
                }
                
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnBackAll_Click(object sender, EventArgs e)
        {
            try
            {
                ListBoxOrganizationElements.Items.Clear();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.AddOrgElements();
                this.ClearAllControl();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearAllControl()
        {
            try
            {
                ddlCompany.SelectedValue = "-1";
                ListBoxOrganizationElements.Items.Clear();
                btnSave.Text = "Save";

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddOrgElements()
        {
            try
            {
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                _objOrganizationalChartSetup.CompanyID = Convert.ToInt32( ddlCompany.SelectedValue);
                List<int> list = new List<int>();
                foreach (ListItem  item in ListBoxOrganizationElements.Items)
                {
                    list.Add(Convert.ToInt32( item.Value));
                }
                _objOrganizationalChartSetup.OrgElementIDList = list;

                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                if (btnSave.Text == "Save")
                {
                    _objOrganizationalChartSetupController.Save(_objOrganizationalChartSetup);
                }
                else
                {
                    _objOrganizationalChartSetupController.Update(_objOrganizationalChartSetup);
                }
                

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearAllControl();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var companyID = ddlCompany.SelectedValue;
                if (companyID == "-1")
                {
                    this.ClearAllControl();
                    
                }
                else
                {
                    GetOrganizationalElements(companyID,ListBoxOrganizationElements);
                    if (ListBoxOrganizationElements.Items.Count != 0)
                    {
                        btnSave.Text = "Update";
                        
                    }
                    else
                    {
                        btnSave.Text = "Save";
                    }
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void GetOrganizationalElements(string companyID, ListBox ListBoxOrganizationElements)
        {
            try
            {
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                _objOrganizationalChartSetup.CompanyID = Convert.ToInt32( companyID);
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadOrganizationalElements(_objOrganizationalChartSetup,ListBoxOrganizationElements);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void ddlCompanyChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                _objOrganizationalChartSetup.CompanyID = Convert.ToInt32( ddlCompanyChart.SelectedValue);
                if (_objOrganizationalChartSetup.CompanyID == -1)
                {
                    ddlElement.Items.Clear();
                    
                }
                else
                {
                    _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                    _objOrganizationalChartSetupController.LoadOrganizationalElements(_objOrganizationalChartSetup, ddlElement);
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }
    }
}