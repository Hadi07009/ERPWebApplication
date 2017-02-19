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
                    PopulateOrganizationalChart();
                    PanelAddress.Visible = false;
                    btnUpdate.Visible = false;
                    btnClearUpdate.Visible = false;
                    btnSaveChart.Visible = false;
                    btnClearChart.Visible = false;
                    lblParentElementText.Visible = false;
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void PopulateOrganizationalChart()
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.PopulateRootLevel(TreeViewCompanyChart);

            }
            catch (Exception msgException)
            {

                throw msgException;
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
                _objOrganizationalChartSetup.CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                List<int> list = new List<int>();
                foreach (ListItem item in ListBoxOrganizationElements.Items)
                {
                    list.Add(Convert.ToInt32(item.Value));
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
                    GetOrganizationalElements(companyID, ListBoxOrganizationElements);
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
                _objOrganizationalChartSetup.CompanyID = Convert.ToInt32(companyID);
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadOrganizationalElements(_objOrganizationalChartSetup, ListBoxOrganizationElements);

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
                _objOrganizationalChartSetup.CompanyID = Convert.ToInt32(ddlCompanyChart.SelectedValue);
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

        protected void TreeViewCompanyChart_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
                TreeViewCompanyChart.ExpandAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnSaveChart_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesOrganizationalChart(btnSaveChart);
                TreeViewCompanyChart.Nodes.Clear();
                this.PopulateOrganizationalChart();
                TreeViewCompanyChart.ExpandAll();
                ClearChartControl();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearChartControl()
        {
            try
            {
                ddlCompanyChart.SelectedValue = "-1";
                ddlElement.Items.Clear();
                txtTitle.Text = string.Empty;
                lblParentElementValue.Text = string.Empty;
                lblParentElementText.Text = string.Empty;
                txtShortName.Text = string.Empty;
                txtDisplayName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtHeadID.Text = string.Empty;
                ddlCategory.Items.Clear();
                txtOpeningDate.Text = string.Empty;
                CheckBoxAddress.Checked = false;
                ClearChartAddressControl();
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ClearChartAddressControl()
        {
            try
            {
                txtContactNumber.Text = string.Empty;
                txtDisplayAddress.Text = string.Empty;
                txtPostalCode.Text = string.Empty;
                txtPhoneNo.Text = string.Empty;
                txtFax.Text = string.Empty;
                if (ddlDivision.Items.Count > 0)
                {
                    ddlDivision.SelectedValue = "-1";
                }

                if (ddlDistrict.Items.Count > 0)
                {
                    ddlDistrict.SelectedValue = "-1";

                }

                PanelAddress.Visible = false;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddValuesOrganizationalChart(Button btnAction)
        {
            try
            {
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                _objOrganizationalChartSetup.CompanyID = Convert.ToInt32(ddlCompanyChart.SelectedValue);
                _objOrganizationalChartSetup.EntityTypeID = Convert.ToInt32(ddlElement.SelectedValue);
                _objOrganizationalChartSetup.TableName = ddlElement.SelectedValue == "-1" ? null : ddlElement.SelectedItem.Text;
                _objOrganizationalChartSetup.EntityName = txtTitle.Text == string.Empty ? null : txtTitle.Text;
                _objOrganizationalChartSetup.ParentEntityID = Convert.ToInt32(lblParentElementValue.Text);
                _objOrganizationalChartSetup.ShortName = txtShortName.Text == string.Empty ? null : txtShortName.Text;
                _objOrganizationalChartSetup.DisplayName = txtDisplayName.Text == string.Empty ? null : txtDisplayName.Text;
                _objOrganizationalChartSetup.GroupEmailAddress = txtEmail.Text == string.Empty ? null : txtEmail.Text;
                EmployeeSetup objEmployeeSetup = new EmployeeSetup();
                objEmployeeSetup.EmployeeID = txtHeadID.Text == string.Empty ? null : txtHeadID.Text;
                TwoColumnsTableData objTwoColumnsTableData = new TwoColumnsTableData();
                objTwoColumnsTableData.FieldOfID = ddlCategory.SelectedValue == "-1" ? null : ddlCategory.SelectedValue;
                
                if (txtOpeningDate.Text != string.Empty)
                {
                    _objOrganizationalChartSetup.EntityOpeningDate = Convert.ToDateTime(txtOpeningDate.Text);
                }

                _objOrganizationalChartSetup.AddressTag = CheckBoxAddress.Checked == true ? "Y" : "N";
                if (_objOrganizationalChartSetup.AddressTag == "Y")
                {
                    var contactNumberValue = txtContactNumber.Text == string.Empty ? null : txtContactNumber.Text;
                    if (contactNumberValue != null)
                    {
                        _objOrganizationalChartSetup.ContactAdreessNumber = Convert.ToInt32(contactNumberValue);
                    }

                    _objOrganizationalChartSetup.DisplayAddress = txtDisplayAddress.Text == string.Empty ? null : txtDisplayAddress.Text;
                    _objOrganizationalChartSetup.DivisionID = ddlDivision.SelectedValue == "-1" ? null : ddlDivision.SelectedValue;
                    _objOrganizationalChartSetup.DistrictID = ddlDistrict.SelectedValue == "-1" ? null : ddlDistrict.SelectedValue;
                    _objOrganizationalChartSetup.PostalCode = txtPostalCode.Text == string.Empty ? null : txtPostalCode.Text;
                    _objOrganizationalChartSetup.PhoneNo = txtPhoneNo.Text == string.Empty ? null : txtPhoneNo.Text;
                    _objOrganizationalChartSetup.Fax = txtFax.Text == string.Empty ? null : txtFax.Text;
                }

                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                if (btnAction == btnSaveChart)
                {
                    _objOrganizationalChartSetupController.SaveChart(_objOrganizationalChartSetup, objEmployeeSetup, objTwoColumnsTableData);
                }
                else
                {
                    _objOrganizationalChartSetupController.UpdateChart(_objOrganizationalChartSetup, objEmployeeSetup, objTwoColumnsTableData);
                }


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void ddlElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            _objOrganizationalChartSetup = new OrganizationalChartSetup();
            _objOrganizationalChartSetup.EntityTypeID = Convert.ToInt32(ddlElement.SelectedValue);
            if (_objOrganizationalChartSetup.EntityTypeID == -1)
            {
                ddlCategory.Items.Clear();

            }
            else
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetupController.LoadCategory(_objOrganizationalChartSetup, ddlCategory);
            }
        }

        protected void TreeViewCompanyChart_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                lblParentElementText.Text = TreeViewCompanyChart.SelectedNode.Text;
                lblParentElementText.Visible = true;
                _objOrganizationalChartSetup = new OrganizationalChartSetup();
                _objOrganizationalChartSetup.EntityID = Convert.ToInt32(TreeViewCompanyChart.SelectedNode.Value);
                lblParentElementValue.Text = _objOrganizationalChartSetup.EntityID.ToString();
                txtTitle.Focus();
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                _objOrganizationalChartSetup.EntityTypeID = _objOrganizationalChartSetupController.GetEntityTypeID(_objOrganizationalChartSetup);
                _objOrganizationalChartSetupController.LoadDivisionDDL(ddlDivision);
                _objOrganizationalChartSetupController.LoadDistrict(ddlDistrict);
                btnSaveChart.Visible = true;
                btnUpdate.Visible = true;
                if (Convert.ToInt32(_objOrganizationalChartSetup.EntityID) == 111)
                {
                    btnSaveChart.Visible = false;
                    btnUpdate.Visible = false;

                }
                else if (_objOrganizationalChartSetup.EntityTypeID == 1)
                {
                    btnUpdate.Visible = false;
                    ddlCompanyChart.SelectedValue = _objOrganizationalChartSetup.EntityID.ToString();
                    _objOrganizationalChartSetup.CompanyID = Convert.ToInt32(ddlCompanyChart.SelectedValue);
                    _objOrganizationalChartSetupController.LoadOrganizationalElements(_objOrganizationalChartSetup, ddlElement);

                }
                else
                {
                    ViewEntityDetails(_objOrganizationalChartSetup);
                    if (CheckBoxAddress.Checked == true)
                    {
                        _objOrganizationalChartSetup = new OrganizationalChartSetup();
                        _objOrganizationalChartSetup.EntityID = Convert.ToInt32(TreeViewCompanyChart.SelectedNode.Value);
                        ViewEntityAddress(_objOrganizationalChartSetup);
                        PanelAddress.Visible = true;

                    }
                    else
                    {
                        ClearChartAddressControl();

                    }

                }


            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ViewEntityAddress(OrganizationalChartSetup _objOrganizationalChartSetup)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                DataTable dtEntityAddress = _objOrganizationalChartSetupController.GetEntityAddress(_objOrganizationalChartSetup);
                foreach (DataRow rowNo in dtEntityAddress.Rows)
                {
                    txtContactNumber.Text = rowNo["ContactAdreessNumber"].ToString() == null ? string.Empty : rowNo["ContactAdreessNumber"].ToString();
                    txtDisplayAddress.Text = rowNo["DisplayAddress"].ToString() == null ? string.Empty : rowNo["DisplayAddress"].ToString();
                    
                    ddlDivision.SelectedValue = rowNo["DivisionID"].ToString() == null ? "-1" : rowNo["DivisionID"].ToString();
                    
                    ddlDistrict.SelectedValue = rowNo["DistrictID"].ToString() == null ? "-1" : rowNo["DistrictID"].ToString();
                    txtPostalCode.Text = rowNo["PostalCode"].ToString() == null ? string.Empty : rowNo["PostalCode"].ToString();
                    txtPhoneNo.Text = rowNo["ContactPhoneNo"].ToString() == null ? string.Empty : rowNo["ContactPhoneNo"].ToString();
                    txtFax.Text = rowNo["Fax"].ToString() == null ? string.Empty : rowNo["Fax"].ToString();

                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ViewEntityDetails(OrganizationalChartSetup objOrganizationalChartSetup)
        {
            try
            {
                _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                DataTable dtEntityDetails = _objOrganizationalChartSetupController.GetEntityDetails(objOrganizationalChartSetup);
                foreach (DataRow rowNo in dtEntityDetails.Rows)
                {
                    ddlCompanyChart.SelectedValue = rowNo["CompanyID"].ToString();
                    _objOrganizationalChartSetup = new OrganizationalChartSetup();
                    _objOrganizationalChartSetup.CompanyID = Convert.ToInt32(ddlCompanyChart.SelectedValue);
                    _objOrganizationalChartSetupController.LoadOrganizationalElements(_objOrganizationalChartSetup, ddlElement);
                    ddlElement.SelectedValue = rowNo["EntityTypeID"].ToString();
                    txtShortName.Text = rowNo["ShortName"].ToString() == null ? string.Empty : rowNo["ShortName"].ToString();
                    txtDisplayName.Text = rowNo["DisplayName"].ToString() == null ? string.Empty : rowNo["DisplayName"].ToString();
                    txtEmail.Text = rowNo["GroupEmailAddress"].ToString() == null ? string.Empty : rowNo["GroupEmailAddress"].ToString();
                    txtHeadID.Text = rowNo["HeadID"].ToString() == null ? string.Empty : rowNo["HeadID"].ToString();
                    _objOrganizationalChartSetup.EntityTypeID = Convert.ToInt32(ddlElement.SelectedValue);
                    _objOrganizationalChartSetupController.LoadCategory(_objOrganizationalChartSetup, this.ddlCategory);
                    ddlCategory.SelectedValue = rowNo["EntityCategoryID"].ToString() == "" ? "-1" : rowNo["EntityCategoryID"].ToString();
                    txtOpeningDate.Text = rowNo["EntityOpeningDate"].ToString() == null ? string.Empty : Convert.ToDateTime(rowNo["EntityOpeningDate"].ToString()).ToString("yyyy-MM-dd");
                    if (rowNo["AddressTag"].ToString() == "Y")
                    {
                        CheckBoxAddress.Checked = true;
                    }
                    else
                    {
                        CheckBoxAddress.Checked = false;
                    }
                }


            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnClearChart_Click(object sender, EventArgs e)
        {
            try
            {
                this.PopulateOrganizationalChart();
                this.ClearChartControl();
                TreeViewCompanyChart.ExpandAll();
                btnSaveChart.Visible = false;
                btnClearChart.Visible = false;

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void CheckBoxAddress_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBoxAddress.Checked == true)
                {
                    PanelAddress.Visible = true;
                    _objOrganizationalChartSetupController = new OrganizationalChartSetupController();
                    _objOrganizationalChartSetupController.LoadDivisionDDL(ddlDivision);
                    _objOrganizationalChartSetupController.LoadDistrict(ddlDistrict);

                }
                else
                {
                    PanelAddress.Visible = false;
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Visible = false;
                btnClearUpdate.Visible = false;
                btnSaveChart.Visible = true;
                btnClearChart.Visible = true;

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveChart.Visible = false;
                btnClearChart.Visible = false;
                btnUpdate.Visible = true;
                btnClearUpdate.Visible = true;

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnClearUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.PopulateOrganizationalChart();
                this.ClearChartControl();
                TreeViewCompanyChart.ExpandAll();
                btnUpdate.Visible = false;
                btnClearUpdate.Visible = false;

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesOrganizationalChart(btnUpdate);
                TreeViewCompanyChart.Nodes.Clear();
                this.PopulateOrganizationalChart();
                TreeViewCompanyChart.ExpandAll();
                ClearChartControl();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }
    }
}