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

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class NewCompany : System.Web.UI.Page
    {
        private CompanyDetailsSetup _objCompanyDetailsSetup;
        private CompanySetupController _objCompanySetupController;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadCountryDropDown(ddlCountry);
                    LoadCompanyDetails();
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadCompanyDetails()
        {
            try
            {
                DataTable dtCompanyDetails = null;
                _objCompanySetupController = new CompanySetupController();
                dtCompanyDetails = _objCompanySetupController.GetCompanyDetails();
                grdCompany.DataSource = null;
                grdCompany.DataBind();
                if (dtCompanyDetails.Rows.Count > 0)
                {
                    grdCompany.DataSource = dtCompanyDetails;
                    grdCompany.DataBind();
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadCountryDropDown(DropDownList ddlCountry)
        {
            try
            {
                _objCompanySetupController = new CompanySetupController();
                _objCompanySetupController.LoadCountry(ddlCountry);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddCompanyValues();
                ClearControl();
                this.LoadCompanyDetails();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControl()
        {
            try
            {
                ddlCountry.SelectedValue = "-1";
                txtCompanyName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtMobile.Text = string.Empty;
                btnSave.Text = "Save";

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddCompanyValues()
        {
            try
            {
                _objCompanyDetailsSetup = new CompanyDetailsSetup();
                _objCompanyDetailsSetup.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                _objCompanyDetailsSetup.CompanyName = txtCompanyName.Text == string.Empty ? null : txtCompanyName.Text;
                _objCompanyDetailsSetup.CompanyEmail = txtEmail.Text == string.Empty ? null : txtEmail.Text;
                _objCompanyDetailsSetup.CompanyMobile = txtMobile.Text == string.Empty ? null : txtMobile.Text;
                _objCompanySetupController = new CompanySetupController();
                if (btnSave.Text == "Update")
                {
                    _objCompanyDetailsSetup.CompanyID = Convert.ToInt32(Session["selectedCompanyID"].ToString());
                    _objCompanySetupController.Update(_objCompanyDetailsSetup);

                }
                else
                {
                    _objCompanySetupController.Save(_objCompanyDetailsSetup);
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
                this.ClearControl();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
        }

        protected void grdCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string lblCompanyID = ((Label)grdCompany.Rows[selectedIndex].FindControl("lblCompanyID")).Text;
                if (e.CommandName.Equals("Select"))
                {
                    string lblCountryID = ((Label)grdCompany.Rows[selectedIndex].FindControl("lblCountryID")).Text;
                    string lblCompanyName = ((Label)grdCompany.Rows[selectedIndex].FindControl("lblCompanyName")).Text;
                    string lblCompanyEmail = ((Label)grdCompany.Rows[selectedIndex].FindControl("lblCompanyEmail")).Text;
                    string lblCompanyMobile = ((Label)grdCompany.Rows[selectedIndex].FindControl("lblCompanyMobile")).Text;

                    ddlCountry.SelectedValue = lblCountryID;
                    txtCompanyName.Text = lblCompanyName;
                    txtEmail.Text = lblCompanyEmail;
                    txtMobile.Text = lblCompanyMobile;
                    Session["selectedCompanyID"] = lblCompanyID;
                    btnSave.Text = "Update";
                }
                else if (e.CommandName.Equals("Delete"))
                {
                    _objCompanyDetailsSetup = new CompanyDetailsSetup();
                    _objCompanyDetailsSetup.CompanyID = Convert.ToInt32(lblCompanyID);
                    _objCompanySetupController = new CompanySetupController();
                    _objCompanySetupController.Delete(_objCompanyDetailsSetup);
                    this.LoadCompanyDetails();

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void grdCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}