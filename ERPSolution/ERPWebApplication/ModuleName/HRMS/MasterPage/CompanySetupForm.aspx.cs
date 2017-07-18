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
        private BusinessType _objBusinessType;
        private OwnershipType _objOwnershipType;
        private DistrictSetup _objDistrictSetup;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["lastPositionNo"] = 1;
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
                    ShowDataOfUser();
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ShowDataOfUser()
        {
            try
            {
                _objCompanyDetailsSetup = new CompanyDetailsSetup();
                _objCompanyDetailsSetup.CompanyID = Convert.ToInt32(Session["selectedCompanyID"].ToString());
                _objCompanySetupController = new CompanySetupController();
                DataTable dtUserData = _objCompanySetupController.GetDataOfUser(_objCompanyDetailsSetup);
                this.ClearControlByUser();
                foreach (DataRow rowNo in dtUserData.Rows)
                {
                    txtShortName.Text = rowNo["CompanyShortName"].ToString() == null ? string.Empty : rowNo["CompanyShortName"].ToString();
                    txtSlogun.Text = rowNo["CompanySlogun"].ToString() == null ? string.Empty : rowNo["CompanySlogun"].ToString();
                    txtHouse.Text = rowNo["House"].ToString() == null ? string.Empty : rowNo["House"].ToString();
                    txtRoad.Text = rowNo["Road"].ToString() == null ? string.Empty : rowNo["Road"].ToString();
                    txtSector.Text = rowNo["Sector"].ToString() == null ? string.Empty : rowNo["Sector"].ToString();
                    txtLandmark.Text = rowNo["Landmark"].ToString() == null ? string.Empty : rowNo["Landmark"].ToString();
                    txtContactPersonName.Text = rowNo["ContactPersonName"].ToString() == null ? string.Empty : rowNo["ContactPersonName"].ToString();

                    var contactPersonDesignation = rowNo["ContactPersonDesignation"].ToString();
                    if (contactPersonDesignation == null || contactPersonDesignation == "0" || contactPersonDesignation == "")
                    {
                        ddlContactPersonDesignation.SelectedValue = "-1";
                    }
                    else
                    {
                        ddlContactPersonDesignation.SelectedValue = contactPersonDesignation;

                    }


                    txtContactNumber.Text = rowNo["ContactPersonContactNumber"].ToString() == null ? string.Empty : rowNo["ContactPersonContactNumber"].ToString();
                    txtAltContName.Text = rowNo["AlternateContactPersonName"].ToString() == null ? string.Empty : rowNo["AlternateContactPersonName"].ToString();

                    var AltContDesignation = rowNo["AlternateContactPersonDesignation"].ToString();
                    if (AltContDesignation == null || AltContDesignation == "0" || AltContDesignation == "")
                    {
                        ddlAltContDesignation.SelectedValue = "-1";
                    }
                    else
                    {
                        ddlAltContDesignation.SelectedValue = AltContDesignation;
                    }
                    
                    
                    txtAltContactNumber.Text = rowNo["AlternateContactPersonContactNumber"].ToString() == null ? string.Empty : rowNo["AlternateContactPersonContactNumber"].ToString();
                    txtPhone.Text = rowNo["CompanyPhones"].ToString() == null ? string.Empty : rowNo["CompanyPhones"].ToString();
                    txtFax.Text = rowNo["CompanyFax"].ToString() == null ? string.Empty : rowNo["CompanyFax"].ToString();
                    txtURL.Text = rowNo["CompanyURL"].ToString() == null ? string.Empty : rowNo["CompanyURL"].ToString();
                    var licenceNo = rowNo["LicenceID"].ToString();
                    if (licenceNo == null || licenceNo == "0" || licenceNo == "")
                    {
                        txtLicence.Text = string.Empty;
                    }
                    else
                    {
                        txtLicence.Text = licenceNo;
                    }
                    
                    
                    txtFaceBook.Text = rowNo["FaceBookID"].ToString() == null ? string.Empty : rowNo["FaceBookID"].ToString();
                    txtLinkedInID.Text = rowNo["LinkedInID"].ToString() == null ? string.Empty : rowNo["LinkedInID"].ToString();
                    txtTwitterID.Text = rowNo["TwitterID"].ToString() == null ? string.Empty : rowNo["TwitterID"].ToString();
                    txtYouTubeID.Text = rowNo["YouTubeID"].ToString() == null ? string.Empty : rowNo["YouTubeID"].ToString();
                    var businessType = rowNo["BusinessTypeID"].ToString();
                    if (businessType == null || businessType == "0" || businessType == "")
                    {
                        ddlBusinessType.SelectedValue = "-1";
                        
                    }
                    else
                    {
                        ddlBusinessType.SelectedValue = businessType;
                    }

                    var ownershipType = rowNo["OwnershipTypeID"].ToString();
                    if (ownershipType == null || ownershipType == "-1" || ownershipType == "")
                    {
                        ddlOwnershipType.SelectedValue = "-1";
                        
                    }
                    else
                    {
                        ddlOwnershipType.SelectedValue = ownershipType;
                    }

                    var districtID = rowNo["DistrictID"].ToString();
                    if (districtID == null || districtID == "-1" || districtID == "")
                    {
                        ddlDistrict.SelectedValue = "-1";
                        
                    }
                    else
                    {
                        ddlDistrict.SelectedValue = districtID;
                    }
                }


            }
            catch (Exception msgException)
            {

                throw msgException;
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
                _objTwoColumnsTableData.CompanyID = Convert.ToInt32(Session["lastPositionNo"].ToString());
                //objTwoColumnsTableData.BranchID = Convert.ToInt32(Session["branchID"].ToString());
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
                this.ClearControlByUser();
                this.LoadCompanyDetails();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlByUser()
        {
            try
            {
                txtShortName.Text = string.Empty;
                txtSlogun.Text = string.Empty;
                txtHouse.Text = string.Empty;
                txtRoad.Text = string.Empty;
                txtSector.Text = string.Empty;
                txtLandmark.Text = string.Empty;
                txtContactPersonName.Text = string.Empty;
                ddlContactPersonDesignation.SelectedValue = "-1";
                txtContactNumber.Text = string.Empty;
                txtAltContName.Text = string.Empty;
                ddlAltContDesignation.SelectedValue = "-1";
                txtAltContactNumber.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtFax.Text = string.Empty;
                txtURL.Text = string.Empty;
                txtLicence.Text = string.Empty;
                txtFaceBook.Text = string.Empty;
                txtLinkedInID.Text = string.Empty;
                txtTwitterID.Text = string.Empty;
                txtYouTubeID.Text = string.Empty;
                ddlBusinessType.SelectedValue = "-1";
                ddlOwnershipType.SelectedValue = "-1";
                ddlDistrict.SelectedValue = "-1";
            }
            catch (Exception msgException)
            {

                throw msgException;
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

                _objCompanyDetailsSetup.CompanyShortName = txtShortName.Text == string.Empty ? null : txtShortName.Text;
                _objCompanyDetailsSetup.CompanySlogun = txtSlogun.Text == string.Empty ? null : txtSlogun.Text;
                _objCompanyDetailsSetup.House = txtHouse.Text == string.Empty ? null : txtHouse.Text;
                _objCompanyDetailsSetup.Road = txtRoad.Text == string.Empty ? null : txtRoad.Text;
                _objCompanyDetailsSetup.Sector = txtSector.Text == string.Empty ? null : txtSector.Text;
                _objCompanyDetailsSetup.Landmark = txtLandmark.Text == string.Empty ? null : txtLandmark.Text;
                _objCompanyDetailsSetup.ContactPersonName = txtContactPersonName.Text == string.Empty ? null : txtContactPersonName.Text;
                _objCompanyDetailsSetup.ContactPersonDesignation = ddlContactPersonDesignation.SelectedValue == "-1" ? null : ddlContactPersonDesignation.SelectedValue;
                _objCompanyDetailsSetup.ContactPersonContactNumber = txtContactNumber.Text == string.Empty ? null : txtContactNumber.Text;
                _objCompanyDetailsSetup.AlternateContactPersonName = txtAltContName.Text == string.Empty ? null : txtAltContName.Text;
                _objCompanyDetailsSetup.AlternateContactPersonDesignation = ddlAltContDesignation.SelectedValue == "-1" ? null : ddlAltContDesignation.SelectedValue;
                _objCompanyDetailsSetup.AlternateContactPersonContactNumber = txtAltContactNumber.Text == string.Empty ? null : txtAltContactNumber.Text;
                _objCompanyDetailsSetup.CompanyPhones = txtPhone.Text == string.Empty ? null : txtPhone.Text;
                _objCompanyDetailsSetup.CompanyFax = txtFax.Text == string.Empty ? null : txtFax.Text;
                _objCompanyDetailsSetup.CompanyURL = txtURL.Text == string.Empty ? null : txtURL.Text;

                _objCompanyDetailsSetup.LicenceID = Convert.ToInt32(txtLicence.Text == string.Empty ? null : txtLicence.Text);
                _objCompanyDetailsSetup.FaceBookID = txtFaceBook.Text == string.Empty ? null : txtFaceBook.Text;
                _objCompanyDetailsSetup.LinkedInID = txtLinkedInID.Text == string.Empty ? null : txtLinkedInID.Text;
                _objCompanyDetailsSetup.TwitterID = txtTwitterID.Text == string.Empty ? null : txtTwitterID.Text;
                _objCompanyDetailsSetup.YouTubeID = txtYouTubeID.Text == string.Empty ? null : txtYouTubeID.Text;
                _objBusinessType = new BusinessType();
                _objBusinessType.BusinessTypeID = ddlBusinessType.SelectedValue == "-1" ? Convert.ToInt32(null) : Convert.ToInt32(ddlBusinessType.SelectedValue);
                _objOwnershipType = new OwnershipType();
                _objOwnershipType.OwnershipTypeID = ddlOwnershipType.SelectedValue == "-1" ? Convert.ToInt32(null) : Convert.ToInt32(ddlOwnershipType.SelectedValue);
                _objDistrictSetup = new DistrictSetup();
                _objDistrictSetup.DistrictID = ddlDistrict.SelectedValue == "-1" ? Convert.ToInt32(null) : Convert.ToInt32(ddlDistrict.SelectedValue);

                _objCompanySetupController = new CompanySetupController();
                if (btnSave.Text == "Update")
                {
                    _objCompanyDetailsSetup.CompanyID = Convert.ToInt32(Session["selectedCompanyID"].ToString());
                    _objCompanySetupController.Update(_objCompanyDetailsSetup);
                    _objCompanySetupController.UpdateByUser(_objCompanyDetailsSetup, _objBusinessType, _objOwnershipType, _objDistrictSetup);

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
                this.ClearControlByUser();

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
                            clsTopMostMessageBox.Show(clsMessages.GImageSize);
                            
                        }
                    }
                    else
                    {
                        clsTopMostMessageBox.Show(clsMessages.GImageSizeBytes);
                        
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