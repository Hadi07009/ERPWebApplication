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

namespace ERPWebApplication.ModuleName.HRMS.MasterPage
{
    public partial class CompanySetupForm : System.Web.UI.Page
    {
        private CompanyDetailsSetup _objCompanyDetailsSetup;
        private CompanySetupController _objCompanySetupController;
        private TwoColumnsTableDataAutoController _objTwoColumnsTableDataAutoController;
        private TwoColumnsTableDataController _objTwoColumnsTableDataController;
        private TwoColumnsTableData _objTwoColumnsTableData;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["companyID"] = 1;
                    Session["branchID"] = 1;

                    PanelDetails.Visible = false;
                    LoadCountryDropDown(ddlCountry);
                    LoadCompanyDetails();
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadBusinessNature(DropDownList ddlBusinessType)
        {
            try
            {
                _objTwoColumnsTableDataAutoController = new TwoColumnsTableDataAutoController();
                _objTwoColumnsTableDataAutoController.GetBusinessNature(ddlBusinessType);

            }
            catch (Exception msgException)
            {

                throw msgException;
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
                    ShowLogo();
                    PanelDetails.Visible = true;
                    LoadBusinessNature(ddlBusinessType);
                    LoadOwnershipType(ddlOwnershipType);
                    LoadDesignation(ddlContactPersonDesignation);
                    LoadDesignation(ddlAltContDesignation);
                    LoadDistrict(ddlDistrict);
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void LoadDistrict(DropDownList ddlDistrict)
        {
            try
            {
                _objTwoColumnsTableDataAutoController = new TwoColumnsTableDataAutoController();
                _objTwoColumnsTableDataAutoController.GetDistrict(ddlDistrict);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadDesignation(DropDownList givenDDL)
        {
            try
            {
                _objTwoColumnsTableDataController = new TwoColumnsTableDataController();
                _objTwoColumnsTableData = new TwoColumnsTableData();
                _objTwoColumnsTableData.CompanyID = Convert.ToInt32( Session["companyID"].ToString());
                _objTwoColumnsTableData.BranchID = Convert.ToInt32( Session["branchID"].ToString());
                _objTwoColumnsTableDataController.LoadDesignationDDL(givenDDL, _objTwoColumnsTableData);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadOwnershipType(DropDownList ddlOwnershipType)
        {
            try
            {
                _objTwoColumnsTableDataAutoController = new TwoColumnsTableDataAutoController();
                _objTwoColumnsTableDataAutoController.GetOwnershipType(ddlOwnershipType);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        protected void grdCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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
                lblImage.Text = "<br />  Logo <br />  Not <br />  Available ";
                ViewState["profileImage"] = null;
                PanelDetails.Visible = false;

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
                _objCompanyDetailsSetup.CompanyLogo = (byte[])ViewState["profileImage"];
                _objCompanySetupController = new CompanySetupController();
                if (btnSave.Text == "Update")
                {
                    _objCompanyDetailsSetup.CompanyID = Convert.ToInt32(Session["selectedCompanyID"].ToString());
                    _objCompanySetupController.Update(_objCompanyDetailsSetup);

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
        protected void btnCompanyLogo_Click(object sender, ImageClickEventArgs e)
        {
            if (ProfileImageUpload.HasFile)
            {
                if (ProfileImageUpload.PostedFile.ContentType == "image/jpg" ||
                    ProfileImageUpload.PostedFile.ContentType == "image/jpeg" ||
                    ProfileImageUpload.PostedFile.ContentType == "image/gif" ||
                    ProfileImageUpload.PostedFile.ContentType == "image/pjpeg" ||
                    ProfileImageUpload.PostedFile.ContentType == "image/bmp" ||
                    ProfileImageUpload.PostedFile.ContentType == "image/png")
                {
                    int filelenght = ProfileImageUpload.PostedFile.ContentLength;
                    if (filelenght <= 524288)
                    {
                        byte[] imagebytes = new byte[filelenght];
                        ProfileImageUpload.PostedFile.InputStream.Read(imagebytes, 0, filelenght);
                        byte[] img = imagebytes;
                        string base64string = Convert.ToBase64String(img, 0, img.Length);
                        System.Drawing.Image im = System.Drawing.Image.FromStream(ProfileImageUpload.PostedFile.InputStream);
                        double imageHight = im.PhysicalDimension.Height;
                        double imageWidth = im.PhysicalDimension.Width;
                        if (imageHight <= 150 && imageWidth <= 150)
                        {
                            lblImage.Text = "<img src='data:image/png;base64," + base64string +
                                "' alt='<br />  Logo <br />  Not <br />  Available ' width='" + imageWidth + "' hight='" + imageHight + "' vspace='5px' hspace='5px' />";
                            ViewState["profileImage"] = imagebytes;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(
                            this,
                            GetType(),
                            "MessageBox",
                            "alert(' Image size should not be greater than 150X150 !');",
                            true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(
                            this,
                            GetType(),
                            "MessageBox",
                            "alert(' Image size not more than 500 kb!');",
                            true);
                    }

                }
            }
        }
        private void ShowLogo()
        {
            try
            {
                ViewState["profileImage"] = null;
                lblImage.Text = "<br />  Logo <br />  Not <br />  Available ";
                _objCompanyDetailsSetup = new CompanyDetailsSetup();
                _objCompanyDetailsSetup.CompanyID = Convert.ToInt32(Session["selectedCompanyID"].ToString());
                _objCompanySetupController = new CompanySetupController();
                DataTable dtLogo = _objCompanySetupController.GetLogo(_objCompanyDetailsSetup);
                if (dtLogo.Rows.Count > 0)
                {
                    var img = (byte[])dtLogo.Rows[0].ItemArray[0];
                    string base64string = Convert.ToBase64String(img, 0, img.Length);
                    lblImage.Text = "<img src='data:image/png;base64," + base64string + "' alt='<br />  Logo <br />  Not <br />  Available ' width='150px' hight='150px' vspace='5px' hspace='5px' />";
                    ViewState["profileImage"] = img;
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}