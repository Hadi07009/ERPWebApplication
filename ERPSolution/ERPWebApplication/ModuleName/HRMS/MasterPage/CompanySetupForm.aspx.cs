using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using System.Data;
using System.Configuration;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing;

namespace ERPWebApplication.ModuleName.HRMS.MasterPage
{
    public partial class CompanySetupForm : System.Web.UI.Page
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataReader dr;

        ClsCompanySetup objCompanySetup = new ClsCompanySetup();
        
        clsImageHandler objImageHandler = new clsImageHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["company"] = 1;
                Session["branch"] = 1;
                Session["username"] = "ADM";
                //loadCompanySetup();
                //loadOwnershipType();
                //loadBusinessType();
                //loadCountry();
                //loadDistrict();
               
            }

        }


        private void CheckSessionData()
        {
            // need hints
        }

        public void loadCompanySetup()
        {
            string SessionCompanyID = Session["company"].ToString();
            string colname = "pCompanySetup.CompanyID,pCompanySetup.CompanyName,pCompanySetup.House+'; '+pCompanySetup.Road+'; ' as CompanyAddress,pCompanySetup.CompanyPhones";
            string tablename = "uCompanyWiseUserList inner join pCompanySetup on uCompanyWiseUserList.CompanyID=pCompanySetup.CompanyID ";
            string headername = "CompanyID,CompanyName,CompanyAddress,CompanyPhones";
            string whereCaluse = " pCompanySetup.CompanyID='" + Session["company"].ToString() + "' and uCompanyWiseUserList.BranchID='" + Session["branch"].ToString() + "' and uCompanyWiseUserList.UserID='" + UserID() + "' and pCompanySetup.DataUsed='A' order by pCompanySetup.CompanyName asc";

            SqlConnection sqlConn = new SqlConnection(_connectionString); 
            sqlConn.Open();
            SqlCommand myCommand = sqlConn.CreateCommand();
            myCommand.Connection = sqlConn;
            try
            {
                objCompanySetup.loadCompanySetup(colname, tablename, whereCaluse, headername, GridCompanySetup, myCommand);
                if (GridCompanySetup.Rows.Count > 0)
                {
                    pnlCompanySetupGrid.Visible = true;
                    //lblCompanyMessage.Text="Company Information";

                }
                else
                {
                    pnlCompanySetupGrid.Visible = false;
                    lblCompanyMessage.Text = "No record found";
                }
            }
            catch
            {
                clsTopMostMessageBox.Show1("Please try again", "Error");
            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        private void loadCompanySetupFromGrid(string CompanyID)
        {
            DataTable dt = new DataTable();
            string WhereClause = "CompanyID='" + CompanyID + "'";
            string TableName = "pCompanySetup";
            string ColumnName = "CompanyID,CompanyName,CompanyShortName,CompanySlogun,House,Road,Sector,Landmark,DistrictID,AreaGroupID,AreaID,CountryID,BusinessTypeID,OwnershipTypeID,CompanyPhones,CompanyMobile,CompanyFax,CompanyEmail,CompanyURL,FaceBookID,LinkedInID,TwitterID,YouTubeID,ContactPersonName,ContactPersonDesignation,ContactPersonContactNumber,AlternateContactPersonName,AlternateContactPersonDesignation,AlternateContactPersonContactNumber,CompanyLogo";
            SqlConnection sqlConn = new SqlConnection(_connectionString);
            sqlConn.Open();
            SqlCommand myCommand = sqlConn.CreateCommand();
            myCommand.Connection = sqlConn;
            try
            {
                dt = objCompanySetup.loadCompanySetupFromGridDet(ColumnName, TableName, WhereClause, myCommand);
                if (dt.Rows.Count > 0)
                {
                    pnlUpdateCompanySetup.Visible = true;
                    txtCompanySetup.Text = dt.Rows[0][1].ToString();
                    txtCompanyShortName.Text = dt.Rows[0][2].ToString();
                    txtCompanySlogun.Text = dt.Rows[0][3].ToString();
                    txtHouse.Text = dt.Rows[0][4].ToString();
                    txtRoad.Text = dt.Rows[0][5].ToString();
                    txtSector.Text = dt.Rows[0][6].ToString();
                    txtLandMark.Text = dt.Rows[0][7].ToString();
                    ddlDistrict.SelectedValue = dt.Rows[0][8].ToString();
                    SqlConnection sqlConDistrict = new SqlConnection(_connectionString);
                    sqlConDistrict.Open();
                    SqlCommand myCommandDistrict = sqlConDistrict.CreateCommand();
                    myCommandDistrict.Connection = sqlConDistrict;
                    string Wherecluse = "where [DistrictID]='" + ddlDistrict.SelectedValue + "' and [DataUsed]='A'";
                    lblDistrictCode.Text = clsDataManipulation.GetSingleValueFromtable(myCommandDistrict, "paDistrictsOfBDSetup", "DistrictCode", Wherecluse);
                    if (sqlConDistrict.State == System.Data.ConnectionState.Open)
                    {
                        sqlConDistrict.Close();
                    }

                    loadAreaGroup(dt.Rows[0][9].ToString());
                    ddlAreaGroup.SelectedValue = dt.Rows[0][9].ToString();
                    loadArea(dt.Rows[0][10].ToString());
                    ddlArea.SelectedValue = dt.Rows[0][10].ToString();
                    ddlCountry.SelectedValue = dt.Rows[0][11].ToString();
                    SqlConnection sqlConCountry = new SqlConnection(_connectionString);
                    sqlConCountry.Open();
                    SqlCommand myCommandCountry = sqlConCountry.CreateCommand();
                    myCommandCountry.Connection = sqlConCountry;
                    string Wherecluse1 = "where [CountryID]='" + Convert.ToInt32(ddlCountry.SelectedValue) + "' and [DataUsed]='A'";
                    lblDialingCode.Text = clsDataManipulation.GetSingleValueFromtable(myCommandCountry, "gCountryList", "DialingCode", Wherecluse1);
                    if (sqlConCountry.State == System.Data.ConnectionState.Open)
                    {
                        sqlConCountry.Close();
                    }
                    ddlBusiness.SelectedValue = dt.Rows[0][12].ToString();
                    ddlOwnership.SelectedValue = dt.Rows[0][13].ToString();
                    txtCompanyPhone.Text = dt.Rows[0][14].ToString();
                    txtCompanyMobile.Text = dt.Rows[0][15].ToString();
                    txtCompanyFax.Text = dt.Rows[0][16].ToString();
                    txtCompanyEmail.Text = dt.Rows[0][17].ToString();
                    txtCompanyURL.Text = dt.Rows[0][18].ToString();
                    txtFaceBookID.Text = dt.Rows[0][19].ToString();
                    txtLinkedInID.Text = dt.Rows[0][20].ToString();
                    txtTwitterID.Text = dt.Rows[0][21].ToString();
                    txtYouTubeID.Text = dt.Rows[0][22].ToString();
                    //txtAlphaSoftProduct.Text = dtAutoData.Rows[0][18].ToString();                
                    txtContactPersonName.Text = dt.Rows[0][23].ToString();
                    txtContactPersonDesignation.Text = dt.Rows[0][24].ToString();
                    txtContactPersonContactNum.Text = dt.Rows[0][25].ToString();
                    txtAltContactPersonName.Text = dt.Rows[0][26].ToString();
                    txtAltContactPersonDesignation.Text = dt.Rows[0][27].ToString();
                    txtAltContactPersonContactNum.Text = dt.Rows[0][28].ToString();

                    if ((dt.Rows[0][29].ToString() != string.Empty) || (CheckForCompanyLogo() != string.Empty))
                    {
                        if (dt.Rows[0][29].ToString() == CheckForCompanyLogo())
                        {
                            ImgCompanyLogo.ImageUrl = dt.Rows[0][29].ToString();
                        }
                        else
                        {
                            ImgCompanyLogo.ImageUrl = "~/App_Themes/CSSstyleTheme/Images/Link3Solutions1.jpg";
                        }
                    }
                    else
                    {
                        ImgCompanyLogo.ImageUrl = "~/App_Themes/CSSstyleTheme/Images/Link3Solutions1.jpg";
                    }
                    
                    
                }
                else
                {
                    pnlUpdateCompanySetup.Visible = false;
                    
                }
            }
            catch (Exception ex)
            {
                clsTopMostMessageBox.Show1(ex.Message, "Error");
            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }


        private string ValidationForCompanySetup(string CompanyName, string CompanySlogun, DropDownList ddlCountry, DropDownList ddlBusiness, DropDownList ddlOwnership, string House, string Road, string Sector, string LandMark, DropDownList ddlDistrict, DropDownList ddlAreaGroup, DropDownList ddlArea, string ContactPersonName, string ContactPersonDesignation, string ContactPersonContactNum, string AltContactPersonName, string AltContactPersonDesignation, string AltContactPersonContactNum, string CompanyMobile, string CompanyPhone, string CompanyFax, string CompanyEmail, string CompanyURL, string FaceBookid, string LinkedInid, string Twitterid, string YouTubeid, string CompanyLogo)
        {
            string checkValidity = string.Empty;
            if (CompanyName == string.Empty)
            {
                checkValidity = checkValidity + "\r\n" + "Company name;";
            }
            if (CompanyName.Length > 100)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Company Name' must not exceed 100 characters!";
            }
            if (CompanySlogun.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Company Slogun' must not exceed 50 characters!";
            }
            if (House == string.Empty)
            {
                checkValidity = checkValidity + "\r\n" + "House Number";
            }

            if (Road == string.Empty)
            {
                checkValidity = checkValidity + "\r\n" + "Road Number";
            }

            if (House.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'House' must not exceed 50 characters!";
            }

            if (Road.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Road' must not exceed 50 characters!";
            }

            if (Sector.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Sector' must not exceed 50 characters!";
            }

            if (LandMark.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'LandMark' must not exceed 50 characters!";
            }

            if ((ddlCountry.SelectedIndex == -1) || (ddlCountry.SelectedItem.Text == "-- Select --"))
            {
                checkValidity = checkValidity + "\r\n" + "Country name;";
            }
            if ((ddlBusiness.SelectedIndex == -1) || (ddlBusiness.SelectedItem.Text == "-- Select --"))
            {
                checkValidity = checkValidity + "\r\n" + "Business type;";
            }
            if ((ddlOwnership.SelectedIndex == -1) || (ddlOwnership.SelectedItem.Text == "-- Select --"))
            {
                checkValidity = checkValidity + "\r\n" + "Ownership;";
            }
            if ((ddlDistrict.SelectedIndex == -1) || (ddlDistrict.SelectedItem.Text == "-- Select --"))
            {
                checkValidity = checkValidity + "\r\n" + "District;";
            }
            if ((ddlAreaGroup.SelectedIndex == -1) || (ddlAreaGroup.SelectedItem.Text == "-- Select --"))
            {
                checkValidity = checkValidity + "\r\n" + "Area group;";
            }
            if ((ddlArea.SelectedIndex == -1) || (ddlArea.SelectedItem.Text == "-- Select --"))
            {
                checkValidity = checkValidity + "\r\n" + "Area;";
            }
            if (ContactPersonName == string.Empty)
            {
                checkValidity = checkValidity + "\r\n" + "Contact person name;";
            }
            if (AltContactPersonName != string.Empty)
            {
                if (AltContactPersonDesignation == string.Empty)
                {
                    checkValidity = checkValidity + "\r\n" + "Alternate contact person designation;";
                }
                if (AltContactPersonDesignation.Length > 50)
                {
                    checkValidity = checkValidity + "\r\n" + "Maximum length of 'Alternate contact person designation' must not exceed 50 characters!";
                }
                if (AltContactPersonContactNum == string.Empty)
                {
                    checkValidity = checkValidity + "\r\n" + "Alternate contact person name;";
                }
                if (AltContactPersonContactNum.Length > 50)
                {
                    checkValidity = checkValidity + "\r\n" + "Maximum length of 'Alternate Contact Person's Contact Number' must not exceed 50 characters!";
                }
            }
            if (ContactPersonName.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Contact Person Name' must not exceed 50 characters!";
            }
            if (ContactPersonDesignation == string.Empty)
            {
                checkValidity = checkValidity + "\r\n" + "Contact person designation;";
            }
            if (ContactPersonDesignation.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Contact Person Designation' must not exceed 50 characters!";
            }
            if (ContactPersonContactNum == string.Empty)
            {
                checkValidity = checkValidity + "\r\n" + "Contact person name;";
            }
            if (ContactPersonContactNum.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Contact Person's Contact Number' must not exceed 50 characters!";
            }
            if ((CompanyMobile == string.Empty) && (CompanyPhone == string.Empty))
            {
                checkValidity = checkValidity + "\r\n" + "Company phone/mobile number;";
            }
            if (CompanyMobile.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Company Mobile' must not exceed 50 characters!";
            }
            if (CompanyPhone.Length > 150)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Comapny Phone' must not exceed 50 characters!";
            }
            if (CompanyFax.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Company Fax' number must not exceed 50 characters!";
            }
            if (CompanyEmail.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Company Email' must not exceed 50 characters!";
            }
            if (CompanyURL.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Company URL' must not exceed 50 characters!";
            }
            if (CompanyURL.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Company URL' must not exceed 50 characters!";
            }
            if (FaceBookid.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'FaceBook ID' must not exceed 50 characters!";
            }
            if (LinkedInid.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'LinkedIn ID' must not exceed 50 characters!";
            }
            if (Twitterid.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Twitter ID' must not exceed 50 characters!";
            }
            if (YouTubeid.Length > 50)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'YouTube ID' must not exceed 50 characters!";
            }
            if (CompanyLogo.Length > 200)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Attached Company Logo' name must not exceed 200 characters!";
            }
            return checkValidity;
        }

        private void loadCountry()
        {
            SqlConnection sqlConn = new SqlConnection(_connectionString);
            sqlConn.Open();
            SqlCommand myCommand = sqlConn.CreateCommand();
            myCommand.Connection = sqlConn;
            try
            {
                objCompanySetup.dropdownElements(ddlCountry, "CountryID,CountryName ", "gCountryList", "DataUsed='A'", myCommand);
            }
            catch
            {
                clsTopMostMessageBox.Show1("Please try again", "Error");
            }

            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        private void loadBusinessType()
        {
            SqlConnection sqlConn = new SqlConnection(_connectionString);
            sqlConn.Open();
            SqlCommand myCommand = sqlConn.CreateCommand();
            myCommand.Connection = sqlConn;
            try
            {
                objCompanySetup.dropdownElements(ddlBusiness, "BusinessTypeID,BusinessType ", "BusinessTypeSetup", "DataUsed='A'", myCommand);
            }
            catch
            {
                clsTopMostMessageBox.Show1("Please try again", "Error");
            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        private void loadOwnershipType()
        {
            SqlConnection sqlConn = new SqlConnection(_connectionString);
            sqlConn.Open();
            SqlCommand myCommand = sqlConn.CreateCommand();
            myCommand.Connection = sqlConn;
            try
            {
                objCompanySetup.dropdownElements(ddlOwnership, "OwnershipTypeID,OwnershipType ", "OwnershipTypeSetup", "DataUsed='A'", myCommand);
            }
            catch
            {
                clsTopMostMessageBox.Show1("Please try again", "Error");
            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        private void loadDistrict()
        {
            SqlConnection sqlConn = new SqlConnection(_connectionString);
            sqlConn.Open();
            SqlCommand myCommand = sqlConn.CreateCommand();
            myCommand.Connection = sqlConn;
            try
            {
                objCompanySetup.dropdownElements(ddlDistrict, "DistrictID,DistrictName ", "paDistrictsOfBDSetup", "DataUsed='A'", myCommand);

            }
            catch
            {
                clsTopMostMessageBox.Show1("Please try again", "Error");
            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        private void loadAreaGroup(string districtval)
        {
            SqlConnection sqlConn = new SqlConnection(_connectionString);
            sqlConn.Open();
            SqlCommand myCommand = sqlConn.CreateCommand();
            myCommand.Connection = sqlConn;
            try
            {
                if (districtval == "-- Select --")
                {
                    ddlAreaGroup.Items.Clear();
                }
                else
                {
                    objCompanySetup.dropdownElements(ddlAreaGroup, "AreaGroupID,AreaGroupName ", "paAreaGroupSetup", "DistrictID='" + Convert.ToInt32(ddlDistrict.SelectedValue) + "' and DataUsed='A'", myCommand);
                }
            }
            catch
            {
                clsTopMostMessageBox.Show1("Please try again", "Error");
            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        private void loadArea(string AreaGroup)
        {
            if ((ddlAreaGroup.SelectedIndex == -1) || (ddlAreaGroup.SelectedItem.Text == "-- Select --") || (ddlAreaGroup.SelectedItem.Text == string.Empty))
            {
                ddlArea.Items.Clear();
            }
            else
            {
                SqlConnection sqlConn = new SqlConnection(_connectionString);
                sqlConn.Open();
                SqlCommand myCommand = sqlConn.CreateCommand();
                myCommand.Connection = sqlConn;
                try
                {
                    if (AreaGroup == "-- Select --")
                    {
                        ddlArea.Items.Clear();
                    }
                    else
                    {
                        objCompanySetup.dropdownElements(ddlArea, "AreaID,AreaName+'-'+AreaCode ", "paAreaSetup", "AreaGroupID='" + Convert.ToInt32(ddlAreaGroup.SelectedValue) + "'  and DataUsed='A'", myCommand);
                    }
                }
                catch
                {
                    clsTopMostMessageBox.Show1("Please try again", "Error");
                }
                finally
                {
                    if (sqlConn.State == System.Data.ConnectionState.Open)
                    {
                        sqlConn.Close();
                    }
                }
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAreaGroup(ddlDistrict.SelectedValue);
            loadArea("-- Select --");

            if ((ddlDistrict.SelectedItem.Text != "-- Select --") || (ddlDistrict.SelectedIndex != -1))
            {
                objCompanySetup.pDistrictID = ddlDistrict.SelectedValue;

                SqlConnection sqlConn = new SqlConnection(_connectionString);
                sqlConn.Open();
                SqlCommand myCommand = sqlConn.CreateCommand();
                myCommand.Connection = sqlConn;
                string Wherecluse = "where [DistrictID]='" + objCompanySetup.pDistrictID + "' and [DataUsed]='A'";
                lblDistrictCode.Text = clsDataManipulation.GetSingleValueFromtable(myCommand, "paDistrictsOfBDSetup", "DistrictCode", Wherecluse);
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        protected void ddlAreaGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadArea(ddlAreaGroup.SelectedValue);
        }

        private bool saveCompanySetup()
        {
            //    string HeaderValidity = "Following information should be filled with correct and valid data for company setup : ";
            //    string values = string.Empty;
            //    string duplicatecheck = string.Empty;
            //    if (ValidationForCompanySetup(txtCompanySetup.Text, txtCompanySlogun.Text, ddlCountry, ddlBusiness, ddlOwnership,txtHouse.Text, txtRoad.Text,txtSector.Text,txtLandMark.Text,ddlDistrict, ddlAreaGroup, ddlArea, txtContactPersonName.Text, txtContactPersonDesignation.Text, txtContactPersonContactNum.Text,txtAltContactPersonName.Text,txtAltContactPersonDesignation.Text,txtAltContactPersonContactNum.Text,txtCompanyMobile.Text, txtCompanyPhone.Text, txtCompanyFax.Text, txtCompanyEmail.Text, txtCompanyURL.Text, txtFaceBookID.Text, txtLinkedInID.Text, txtTwitterID.Text, txtYouTubeID.Text) != string.Empty)
            //    {
            //        clsTopMostMessageBox.Show(HeaderValidity + ValidationForCompanySetup(txtCompanySetup.Text, txtCompanySlogun.Text, ddlCountry, ddlBusiness, ddlOwnership, txtHouse.Text, txtRoad.Text, txtSector.Text, txtLandMark.Text, ddlDistrict, ddlAreaGroup, ddlArea, txtContactPersonName.Text, txtContactPersonDesignation.Text, txtContactPersonContactNum.Text, txtAltContactPersonName.Text, txtAltContactPersonDesignation.Text, txtAltContactPersonContactNum.Text, txtCompanyMobile.Text, txtCompanyPhone.Text, txtCompanyFax.Text, txtCompanyEmail.Text, txtCompanyURL.Text, txtFaceBookID.Text, txtLinkedInID.Text, txtTwitterID.Text, txtYouTubeID.Text));
            //        pnlUpdateCompanySetup.Visible = true;
            //        return false;
            //    }
            //    else
            //    {
            //        SqlConnection sqlConn = ConnectionManager.GetConnection();
            //        sqlConn.Open();
            //        SqlCommand myCommand = sqlConn.CreateCommand();
            //        myCommand.Connection = sqlConn;
            //        SqlTransaction myTrans = sqlConn.BeginTransaction("ST");
            //        myCommand.Transaction = myTrans;
            //        try
            //        {
            //            objCompanySetup.pUserid = Session["username"].ToString();
            //            objCompanySetup.pCompanyName = clsDataManipulation.ConvertProperCase(clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtCompanySetup.Text)));
            //            objCompanySetup.pCompanyShortName = clsDataManipulation.ConvertProperCase(clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtCompanyShortName.Text)));
            //            objCompanySetup.pBusinessTypeID = ddlBusiness.SelectedValue;
            //            objCompanySetup.pOwnershipTypeID = ddlOwnership.SelectedValue;
            //            objCompanySetup.pCountryID = ddlCountry.SelectedValue;
            //            objCompanySetup.pCompanySlogun = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtCompanySlogun.Text));
            //            objCompanySetup.pHouse = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtHouse.Text));
            //            objCompanySetup.pRoad = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtRoad.Text));
            //            objCompanySetup.pSector = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtSector.Text));
            //            objCompanySetup.pLandMark = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtLandMark.Text));
            //            objCompanySetup.pDistrictID = ddlDistrict.SelectedValue;
            //            objCompanySetup.pAreaGroup = ddlAreaGroup.SelectedValue;
            //            objCompanySetup.pAreaID = ddlArea.SelectedValue;
            //            objCompanySetup.pContactPersonName = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtContactPersonName.Text));
            //            objCompanySetup.pContactPersonDesignation = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtContactPersonDesignation.Text));
            //            objCompanySetup.pContactPersonContactNumber = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtContactPersonContactNum.Text));

            //            objCompanySetup.pAlternateContactPersonName = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtAltContactPersonName.Text));
            //            objCompanySetup.pAlternateContactPersonDesignation = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtAltContactPersonDesignation.Text));
            //            objCompanySetup.pAlternateContactPersonContactNumber = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtAltContactPersonContactNum.Text));

            //            objCompanySetup.pCompanyPhones = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtCompanyPhone.Text));
            //            objCompanySetup.pCompanyMobile = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtCompanyMobile.Text));
            //            objCompanySetup.pCompanyFax = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtCompanyFax.Text));
            //            objCompanySetup.pCompanyEmail = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtCompanyEmail.Text));
            //            objCompanySetup.pCompanyURL = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtCompanyURL.Text));
            //           // objCompanySetup.pALPHABETSoftwareProduct = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtAlphaSoftProduct.Text));

            //            objCompanySetup.pFaceBookURL = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtFaceBookID.Text));
            //            objCompanySetup.pLinkedInURL = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtLinkedInID.Text));
            //            objCompanySetup.pTwitterURL = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtTwitterID.Text));
            //            objCompanySetup.pYouTubeURL = clsDataManipulation.InvalidCharecterHandler(clsDataManipulation.RemoveSpace(txtYouTubeID.Text));
            //            objCompanyLicence.pBranchID=Session["branch"].ToString();

            //            duplicatecheck = clsDataManipulation.GetSingleValueFromtable(myCommand, "pCompanySetup inner join uCompanyWiseUserList", "pCompanySetup.DataUsed", objCompanySetup.CompanySetupWhereClause(objCompanySetup.pCompanyName,objCompanyLicence.pBranchID,objCompanySetup.pCountryID));
            //            if (duplicatecheck == "A")
            //            {
            //                myTrans.Rollback("ST");
            //                clsTopMostMessageBox.Show("Data Already Exists.");
            //                return false;
            //            }
            //            else if (duplicatecheck == "I")
            //            {
            //                if (clsTopMostMessageBox.Show1("Data already exists as inactive. Are you sure to update data to activate?", "Update") == true)
            //                {
            //                    string Wherecluse1 = "where [uCompanyWiseUserList.CompanyName]='" + objCompanySetup.pCompanyName + "' and [pCompanySetup.DataUsed]='I' and [pCompanySetup.CountryID]='" + Convert.ToInt32(objCompanySetup.pCountryID) + "' and [uCompanyWiseUserList.BranchID]='" + Convert.ToInt32(objCompanySetup.pBranchID)+ "'";
            //                    objCompanySetup.pCompanyID = clsDataManipulation.GetSingleValueFromtable(myCommand, "pCompanySetup", "CompanyID", Wherecluse1);
            //                    objCompanySetup.CommandGenerator("[dbo].[Company_SaveCompanySetup]", "'" + Convert.ToInt32(objCompanySetup.pCompanyID) + "','" + Convert.ToInt32(objCompanySetup.pCountryID) + "','" + objCompanySetup.pCompanyName + "','" + objCompanySetup.pCompanyShortName + "','" + Convert.ToInt32(objCompanySetup.pBusinessTypeID) + "','" + Convert.ToInt32(objCompanySetup.pOwnershipTypeID) + "','" + objCompanySetup.pCompanySlogun + "','" + objCompanySetup.pHouse + "','" + objCompanySetup.pRoad + "','" + objCompanySetup.pSector + "','" + objCompanySetup.pLandMark+ "','" + Convert.ToInt32(objCompanySetup.pDistrictID) + "','" + Convert.ToInt32(objCompanySetup.pAreaGroup) + "','" + Convert.ToInt32(objCompanySetup.pAreaID) + "','" + objCompanySetup.pContactPersonName + "','" + objCompanySetup.pContactPersonDesignation + "','" + objCompanySetup.pContactPersonContactNumber + "','" + objCompanySetup.pAlternateContactPersonName + "','" + objCompanySetup.pAlternateContactPersonDesignation + "','" + objCompanySetup.pAlternateContactPersonContactNumber + "','" + objCompanySetup.pCompanyPhones + "','" + objCompanySetup.pCompanyMobile + "','" + objCompanySetup.pCompanyFax + "','" + objCompanySetup.pCompanyEmail + "','" + objCompanySetup.pCompanyURL + "','" + objCompanySetup.pFaceBookURL + "','" + objCompanySetup.pLinkedInURL + "','" + objCompanySetup.pTwitterURL + "','" + objCompanySetup.pYouTubeURL + "','" + objCompanySetup.pUserid + "','2'", myCommand);
            //                }
            //                else
            //                {
            //                    myTrans.Rollback("ST");
            //                    clsTopMostMessageBox.Show("Insert operation cancelled.");
            //                    return false;
            //                }
            //            }
            //            else
            //            {
            //                if (clsTopMostMessageBox.Show1("Are you sure to save data?", "Insert") == true)
            //                {
            //                    values = "'" + string.Empty + "','" + Convert.ToInt32(objCompanySetup.pCountryID) + "','" + objCompanySetup.pCompanyName + "','" + objCompanySetup.pCompanyShortName + "','" + Convert.ToInt32(objCompanySetup.pBusinessTypeID) + "','" + Convert.ToInt32(objCompanySetup.pOwnershipTypeID) + "','" + objCompanySetup.pCompanySlogun + "','" + objCompanySetup.pHouse + "','" + objCompanySetup.pRoad + "','" + objCompanySetup.pSector + "','" + objCompanySetup.pLandMark + "','" + Convert.ToInt32(objCompanySetup.pDistrictID) + "','" + Convert.ToInt32(objCompanySetup.pAreaGroup) + "','" + Convert.ToInt32(objCompanySetup.pAreaID) + "','" + objCompanySetup.pContactPersonName + "','" + objCompanySetup.pContactPersonDesignation + "','" + objCompanySetup.pContactPersonContactNumber + "','" + objCompanySetup.pAlternateContactPersonName + "','" + objCompanySetup.pAlternateContactPersonDesignation + "','" + objCompanySetup.pAlternateContactPersonContactNumber + "','" + objCompanySetup.pCompanyPhones + "','" + objCompanySetup.pCompanyMobile + "','" + objCompanySetup.pCompanyFax + "','" + objCompanySetup.pCompanyEmail + "','" + objCompanySetup.pCompanyURL + "','" + objCompanySetup.pFaceBookURL + "','" + objCompanySetup.pLinkedInURL + "','" + objCompanySetup.pTwitterURL + "','" + objCompanySetup.pYouTubeURL + "','" + objCompanySetup.pUserid + "','1'";
            //                    objCompanySetup.CommandGenerator("[dbo].[Company_SaveCompanySetup]", values, myCommand);

            //                }
            //                else
            //                {
            //                    myTrans.Rollback("ST");
            //                    clsTopMostMessageBox.Show("Insert operation cancelled.");
            //                    return false;
            //                }
            //            }
            //            clsTopMostMessageBox.Show("Data Saved Successfully");
            //            myTrans.Commit();
            return true;
            //        }
            //        catch (Exception ex)
            //        {
            //            myTrans.Rollback("ST");
            //            clsTopMostMessageBox.Show("Error type:" + ex + ".\n An error occured. Try again.");
            //            return false;
            //        }
            //        finally
            //        {
            //            if (sqlConn.State == System.Data.ConnectionState.Open)
            //            {
            //                sqlConn.Close();
            //            }
            //        }
            //    }
        }

        private bool UpdateCompanySetup(string CompanyID, string CompanyName, string CompanyShortName, DropDownList BusinessTypeID, DropDownList OwnershipTypeID, DropDownList CountryID, string CompanySlogun, string House, string Road, string Sector, string LandMark, DropDownList DistrictID, DropDownList AreaGroup, DropDownList AreaID, string ContactPersonName, string ContactPersonDesignation, string ContactPersonContactNumber, string AltContactPersonName, string AltContactPersonDesignation, string AltContactPersonContactNumber, string CompanyPhones, string CompanyMobile, string CompanyFax, string CompanyEmail, string CompanyURL, string FaceBook, string LinkedIn, string Twitter, string YouTube)
        {
            string fCompanyLogo = string.Empty;
            string HeaderValidity = "Following information should be filled with correct and valid data for company setup : ";
            string duplicatecheck = string.Empty;
            SqlConnection sqlConn = new SqlConnection(_connectionString);
            sqlConn.Open();
            SqlCommand myCommand = sqlConn.CreateCommand();
            myCommand.Connection = sqlConn;
            SqlTransaction myTrans = sqlConn.BeginTransaction("ST");
            myCommand.Transaction = myTrans;
            objCompanySetup.pUserid = Session["username"].ToString();
            objCompanySetup.pCompanyID = CompanyID;
            objCompanySetup.pCompanyName = clsStringManipulation.ConvertProperCase(clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(CompanyName)));
            objCompanySetup.pCompanyShortName = clsStringManipulation.ConvertProperCase(clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(CompanyShortName)));
            objCompanySetup.pBusinessTypeID = BusinessTypeID.SelectedValue;
            objCompanySetup.pOwnershipTypeID = OwnershipTypeID.SelectedValue;
            objCompanySetup.pCountryID = CountryID.SelectedValue;
            objCompanySetup.pHouse = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(House));
            objCompanySetup.pRoad = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(Road));
            objCompanySetup.pSector = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(Sector));
            objCompanySetup.pLandMark = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(LandMark));
            objCompanySetup.pCompanySlogun = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(CompanySlogun));
            objCompanySetup.pDistrictID = DistrictID.SelectedValue;
            objCompanySetup.pAreaGroup = AreaGroup.SelectedValue;
            objCompanySetup.pAreaID = AreaID.SelectedValue;
            objCompanySetup.pContactPersonName = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(ContactPersonName));
            objCompanySetup.pContactPersonDesignation = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(ContactPersonDesignation));
            objCompanySetup.pContactPersonContactNumber = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(ContactPersonContactNumber));
            objCompanySetup.pAlternateContactPersonName = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(AltContactPersonName));
            objCompanySetup.pAlternateContactPersonDesignation = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(AltContactPersonDesignation));
            objCompanySetup.pAlternateContactPersonContactNumber = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(AltContactPersonContactNumber));
            objCompanySetup.pCompanyPhones = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(CompanyPhones));
            objCompanySetup.pCompanyMobile = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(CompanyMobile));
            objCompanySetup.pCompanyFax = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(CompanyFax));
            objCompanySetup.pCompanyEmail = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(CompanyEmail));
            objCompanySetup.pCompanyURL = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(CompanyURL));
            objCompanySetup.pFaceBookURL = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(FaceBook));
            objCompanySetup.pLinkedInURL = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(LinkedIn));
            objCompanySetup.pTwitterURL = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(Twitter));
            objCompanySetup.pYouTubeURL = clsStringManipulation.InvalidCharecterHandler(clsStringManipulation.RemoveSpace(YouTube));

            if (ImgCompanyLogo.ImageUrl != string.Empty)
            {
                DeleteExistingCompanyLogo();
                fCompanyLogo = ImgCompanyLogo.ImageUrl.Replace("temp_", string.Empty);
            }
            else
            {
                fCompanyLogo = string.Empty;
            }

            objImageHandler.pCompanyLogo = fCompanyLogo;
            if (ValidationForCompanySetup(CompanyName, CompanySlogun, CountryID, BusinessTypeID, OwnershipTypeID, House, Road, Sector, LandMark, DistrictID, AreaGroup, AreaID, ContactPersonName, ContactPersonDesignation, ContactPersonContactNumber, AltContactPersonName, AltContactPersonDesignation, AltContactPersonContactNumber, CompanyMobile, CompanyPhones, CompanyFax, CompanyEmail, CompanyURL, FaceBook, LinkedIn, Twitter, YouTube, fCompanyLogo) != string.Empty)
            {
                clsTopMostMessageBox.Show(HeaderValidity + ValidationForCompanySetup(CompanyName, CompanySlogun, CountryID, BusinessTypeID, OwnershipTypeID, House, Road, Sector, LandMark, DistrictID, AreaGroup, AreaID, ContactPersonName, ContactPersonDesignation, ContactPersonContactNumber, AltContactPersonName, AltContactPersonDesignation, AltContactPersonContactNumber, CompanyMobile, CompanyPhones, CompanyFax, CompanyEmail, CompanyURL, FaceBook, LinkedIn, Twitter, YouTube, fCompanyLogo));
                
                return false;
            }

            try
            {
                string Wherecluse = "where [CompanyName]='" + objCompanySetup.pCompanyName + "' and [CompanyID]!='" + objCompanySetup.pCompanyID + "' and [CountryID]='" + objCompanySetup.pCountryID + "'";
                duplicatecheck = clsDataManipulation.GetSingleValueFromtable(myCommand, "pCompanySetup", "DataUsed", Wherecluse);
                if (duplicatecheck == "A")
                {
                    clsTopMostMessageBox.Show("Data Already Exists.");
                    return false;
                }
                else if (duplicatecheck == "I")
                {
                    if (clsTopMostMessageBox.Show1("Data already exists as inactive. Are you sure to update data to activate?", "Update") == true)
                    {
                        string Wherecluse1 = "where [CompanyName]='" + objCompanySetup.pCompanyName + "' and [CompanyID]!='" + objCompanySetup.pCompanyID + "' and [CountryID]='" + objCompanySetup.pCountryID + "' and [DataUsed]='I'";
                        string CompanyNameID = clsDataManipulation.GetSingleValueFromtable(myCommand, "pCompanySetup", "CompanyID", Wherecluse1);
                        objCompanySetup.CommandGenerator("[dbo].[Company_DeleteCompanySetup]", "'" + objCompanySetup.pCompanyID + "','" + objCompanySetup.pCountryID + "','" + objCompanySetup.pUserid + "'", myCommand);
                        objCompanySetup.CommandGenerator("[dbo].[Company_SaveCompanySetup]", "'" + CompanyNameID + "','" + Convert.ToInt32(objCompanySetup.pCountryID) + "','" + objCompanySetup.pCompanyName + "','" + objCompanySetup.pCompanyShortName + "','" + Convert.ToInt32(objCompanySetup.pBusinessTypeID) + "','" + Convert.ToInt32(objCompanySetup.pOwnershipTypeID) + "','" + objCompanySetup.pCompanySlogun + "','" + objCompanySetup.pHouse + "','" + objCompanySetup.pRoad + "','" + objCompanySetup.pSector + "','" + objCompanySetup.pLandMark + "','" + Convert.ToInt32(objCompanySetup.pDistrictID) + "','" + Convert.ToInt32(objCompanySetup.pAreaGroup) + "','" + Convert.ToInt32(objCompanySetup.pAreaID) + "','" + objCompanySetup.pContactPersonName + "','" + objCompanySetup.pContactPersonDesignation + "','" + objCompanySetup.pContactPersonContactNumber + "','" + objCompanySetup.pAlternateContactPersonName + "','" + objCompanySetup.pAlternateContactPersonDesignation + "','" + objCompanySetup.pAlternateContactPersonContactNumber + "','" + objCompanySetup.pCompanyPhones + "','" + objCompanySetup.pCompanyMobile + "','" + objCompanySetup.pCompanyFax + "','" + objCompanySetup.pCompanyEmail + "','" + objCompanySetup.pCompanyURL + "','" + objCompanySetup.pFaceBookURL + "','" + objCompanySetup.pLinkedInURL + "','" + objCompanySetup.pTwitterURL + "','" + objCompanySetup.pYouTubeURL + "','" + objImageHandler.pCompanyLogo + "','" + objCompanySetup.pUserid + "','2'", myCommand);
                        
                        clsTopMostMessageBox.Show("Data Updated Successfully");
                    }
                    else
                    {
                        clsTopMostMessageBox.Show("Update operation cancelled.");
                        return false;
                    }
                }
                else
                {
                    if (clsTopMostMessageBox.Show1("Are you sure to update data?", "Update") == true)
                    {
                        objCompanySetup.CommandGenerator("[dbo].[Company_SaveCompanySetup]", "'" + objCompanySetup.pCompanyID + "','" + Convert.ToInt32(objCompanySetup.pCountryID) + "','" + objCompanySetup.pCompanyName + "','" + objCompanySetup.pCompanyShortName + "','" + Convert.ToInt32(objCompanySetup.pBusinessTypeID) + "','" + Convert.ToInt32(objCompanySetup.pOwnershipTypeID) + "','" + objCompanySetup.pCompanySlogun + "','" + objCompanySetup.pHouse + "','" + objCompanySetup.pRoad + "','" + objCompanySetup.pSector + "','" + objCompanySetup.pLandMark + "','" + Convert.ToInt32(objCompanySetup.pDistrictID) + "','" + Convert.ToInt32(objCompanySetup.pAreaGroup) + "','" + Convert.ToInt32(objCompanySetup.pAreaID) + "','" + objCompanySetup.pContactPersonName + "','" + objCompanySetup.pContactPersonDesignation + "','" + objCompanySetup.pContactPersonContactNumber + "','" + objCompanySetup.pAlternateContactPersonName + "','" + objCompanySetup.pAlternateContactPersonDesignation + "','" + objCompanySetup.pAlternateContactPersonContactNumber + "','" + objCompanySetup.pCompanyPhones + "','" + objCompanySetup.pCompanyMobile + "','" + objCompanySetup.pCompanyFax + "','" + objCompanySetup.pCompanyEmail + "','" + objCompanySetup.pCompanyURL + "','" + objCompanySetup.pFaceBookURL + "','" + objCompanySetup.pLinkedInURL + "','" + objCompanySetup.pTwitterURL + "','" + objCompanySetup.pYouTubeURL + "','" + objImageHandler.pCompanyLogo + "','" + objCompanySetup.pUserid + "','2'", myCommand);
                        
                        clsTopMostMessageBox.Show("Data Updated Successfully");
                    }
                    else
                    {
                        clsTopMostMessageBox.Show("Update operation cancelled.");
                        return false;
                    }
                }
                myTrans.Commit();

                clrCompanySetup();
                return true;
            }
            catch (Exception ex)
            {
                myTrans.Rollback("ST");
                clsTopMostMessageBox.Show("Error type:" + ex + ".\n An error occured. Try again.");
                return false;
            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        private bool DeleteCompanySetup(string Userid, string CompanyID)
        {
            objCompanySetup.pUserid = Userid;
            objCompanySetup.pCompanyID = CompanyID;
            SqlConnection sqlConn = new SqlConnection(_connectionString);
            sqlConn.Open();
            SqlCommand myCommand = sqlConn.CreateCommand();
            myCommand.Connection = sqlConn;
            SqlTransaction myTrans = sqlConn.BeginTransaction("ST");
            myCommand.Transaction = myTrans;
            try
            {
                if (clsTopMostMessageBox.Show1("Are you sure to delete data?", "Delete") == true)
                {
                    objCompanySetup.CommandGenerator("[dbo].[Company_DeleteCompanySetup]", "'" + objCompanySetup.pCompanyID + "','" + objCompanySetup.pUserid + "'", myCommand);
                    clsTopMostMessageBox.Show("Data Deleted");
                }
                else
                {
                    myTrans.Rollback("ST");
                    clsTopMostMessageBox.Show("Delete operation cancelled.");
                    return false;
                }
                if (GridCompanySetup.Rows.Count > 1)
                {
                    pnlCompanySetupGrid.Visible = true;
                }
                else
                {
                    pnlCompanySetupGrid.Visible = false;
                }
                myTrans.Commit();

                return true;
            }
            catch (Exception ex)
            {
                myTrans.Rollback("ST");
                clsTopMostMessageBox.Show("Error type:" + ex + ".\n An error occured. Try again.");
                return false;
            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        public void clrCompanySetup()
        {
            txtCompanySetup.Text = string.Empty;
            ddlCountry.SelectedIndex = -1;
            txtCompanyShortName.Text = string.Empty;
            ddlBusiness.SelectedIndex = -1;
            ddlOwnership.SelectedIndex = -1;
            txtCompanySlogun.Text = string.Empty;
            txtHouse.Text = string.Empty;
            txtRoad.Text = string.Empty;
            txtSector.Text = string.Empty;
            txtLandMark.Text = string.Empty;
            ddlDistrict.SelectedIndex = -1;
            ddlAreaGroup.SelectedIndex = -1;
            ddlArea.SelectedIndex = -1;
            txtContactPersonName.Text = string.Empty;
            txtContactPersonContactNum.Text = string.Empty;
            txtContactPersonDesignation.Text = string.Empty;
            txtAltContactPersonName.Text = string.Empty;
            txtAltContactPersonContactNum.Text = string.Empty;
            txtAltContactPersonDesignation.Text = string.Empty;
            txtCompanyEmail.Text = string.Empty;
            txtCompanyPhone.Text = string.Empty;
            txtCompanyMobile.Text = string.Empty;
            txtCompanyFax.Text = string.Empty;
            txtCompanyURL.Text = string.Empty;
            txtFaceBookID.Text = string.Empty;
            txtLinkedInID.Text = string.Empty;
            txtTwitterID.Text = string.Empty;
            txtYouTubeID.Text = string.Empty;
            DeleteTempCompanyLogo();
            
        }

        protected void btnCompanySetupSaveMore_Click(object sender, EventArgs e)
        {
            GridCompanySetup.EditIndex = -1;
            saveCompanySetup();
            loadCompanySetup();
            clrCompanySetup();
        }

        protected void btnCompanySetupSave_Click(object sender, EventArgs e)
        {
            string CompanyID = GridCompanySetup.Rows[GridCompanySetup.SelectedIndex].Cells[0].Text;
            if (UpdateCompanySetup(CompanyID, txtCompanySetup.Text, txtCompanyShortName.Text, ddlBusiness, ddlOwnership, ddlCountry, txtCompanySlogun.Text, txtHouse.Text, txtRoad.Text, txtSector.Text, txtLandMark.Text, ddlDistrict, ddlAreaGroup, ddlArea, txtContactPersonName.Text, txtContactPersonDesignation.Text, txtContactPersonContactNum.Text, txtAltContactPersonName.Text, txtAltContactPersonDesignation.Text, txtAltContactPersonContactNum.Text, txtCompanyPhone.Text, txtCompanyMobile.Text, txtCompanyFax.Text, txtCompanyEmail.Text, txtCompanyURL.Text, txtFaceBookID.Text, txtLinkedInID.Text, txtTwitterID.Text, txtYouTubeID.Text) == false)
            {
                
                GridCompanySetup.EditIndex = -1;
                loadCompanySetup();
            }
            else
            {
                pnlUpdateCompanySetup.Visible = false;
                pnlCompanySetupGrid.Visible = true;
                GridCompanySetup.EditIndex = -1;
                loadCompanySetup();

            }
        }

        protected void GridCompanySetup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                string s1 = e.Row.Cells[2].Text;
                if (e.Row.Cells[2].Text.Length > 40)
                {
                    e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 40) + "...";
                    e.Row.Cells[2].Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';this.style.color='blue';";
                    e.Row.Cells[2].Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='#696969';";
                    e.Row.Cells[2].Attributes.Add("onClick", "doAlert('Description','" + s1.Replace("\r\n", "<br/>\\n") + "');");
                }

                string s2 = e.Row.Cells[3].Text;
                if (e.Row.Cells[3].Text.Length > 40)
                {
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text.Substring(0, 40) + "...";
                    e.Row.Cells[3].Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';this.style.color='blue';";
                    e.Row.Cells[3].Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='#696969';";
                    e.Row.Cells[3].Attributes.Add("onClick", "doAlert('Description','" + s2.Replace("\r\n", "<br/>\\n") + "');");
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Visible = false;
            }
        }

        protected void GridCompanySetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCompanySetup.PageIndex = e.NewPageIndex;
            GridCompanySetup.EditIndex = -1;
            loadCompanySetup();
        }

        protected void GridCompanySetup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridCompanySetup.EditIndex = -1;
            loadCompanySetup();
        }

        public string ShowRecordNumbers(int pRecordCount, string pShowInLabel)
        {
            if (pRecordCount < 1)
            {
                pShowInLabel = "No Record Found ";
            }
            else if (pRecordCount == 1)
            {
                pShowInLabel = pRecordCount + " Record Found ";
            }
            else if (pRecordCount > 1)
            {
                pShowInLabel = pRecordCount + " Records Found ";
            }
            return pShowInLabel;
        }

        private void parameterpass(ParameterFields myParams, string pname, string value)
        {
            ParameterField param = new ParameterField();
            ParameterDiscreteValue dis1 = new ParameterDiscreteValue();
            param.ParameterFieldName = pname;
            dis1.Value = value;
            param.CurrentValues.Add(dis1);
            myParams.Add(param);
        }

        protected void btnAddCompanySetup_Click(object sender, EventArgs e)
        {
            loadCountry();
            loadBusinessType();
            loadOwnershipType();
            GridCompanySetup.EditIndex = -1;
            pnlUpdateCompanySetup.Visible = true;
            clrCompanySetup();
        }

        protected void btnCompanySetupCancel_Click(object sender, EventArgs e)
        {
            clrCompanySetup();
            loadCompanySetup();
            pnlUpdateCompanySetup.Visible = false;
        }

        protected void GridCompanySetup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = GridCompanySetup.SelectedIndex;
            loadCompanySetup();
            pnlCompanySetupGrid.Visible = false;

            string CompanyID = GridCompanySetup.Rows[i].Cells[0].Text;

            GridCompanySetup.Rows[i].Cells[2].Attributes.Remove("onClick");
            GridCompanySetup.Rows[i].Cells[3].Attributes.Remove("onClick");

            if (CompanyID != string.Empty)
            {
                loadCompanySetupFromGrid(CompanyID);
                LoadCompanyLicence(CompanyID, Session["branch"].ToString());
            }
            else
            {
                clrCompanySetup();
            }

        }

        private string AttachFileName()
        {
            string AttachedFileName = string.Empty;
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/UtilityBillPaperTempAttachment/"));
            string FileNameWithoutExten = string.Empty;
            string savename = string.Empty;
            string OrFileName = string.Empty;
            string strexten = string.Empty;
            string oldpath = string.Empty;
            string newpath = string.Empty;

            foreach (string fname in filePaths)
            {
                string completePath = Server.MapPath("~/UtilityBillPaperTempAttachment/");
                string completePathnew = Server.MapPath("~/UtilityBillPaperAttachment/");

                OrFileName = Path.GetFileName(fname);
                FileNameWithoutExten = Path.GetFileNameWithoutExtension(fname);

                strexten = Path.GetExtension(fname);
                savename = FileNameWithoutExten + strexten;

                string oldpho = OrFileName;
                string newpho = savename;

                oldpath = System.IO.Path.Combine(completePath, oldpho);
                newpath = System.IO.Path.Combine(completePathnew, newpho);

                if (System.IO.File.Exists(oldpath))
                {
                    System.IO.FileInfo fle = new System.IO.FileInfo(oldpath);
                    System.IO.FileInfo f = fle.CopyTo(newpath, true);
                    fle.Delete();
                }
                AttachedFileName += savename + ";";
            }
            return AttachedFileName;

        }

        #region Company Licence

        private void LoadCompanyLicence(string CompanyID, string BranchID)
        {
            string colname = "pCompanyLicence.CompanyID,pCompanyLicence.BranchID,pLicenceSetup.LicenceID,pCompanyLicence.LicenceValue,pCompanyLicence.ID";
            string tablename = "pLicenceSetup inner join pCompanyLicence on pLicenceSetup.LicenceID=pCompanyLicence.LicenceID inner join uCompanyWiseUserList on pCompanyLicence.BranchID=uCompanyWiseUserList.BranchID";
            string headername = "CompanyID,BranchID,LicenceID,LicenceValue,ID";
            string whereCaluse = " uCompanyWiseUserList.CompanyID='" + CompanyID + "' and uCompanyWiseUserList.BranchID='" + BranchID + "' and uCompanyWiseUserList.UserID='" + UserID() + "' and pCompanyLicence.DataUsed='A' order by pLicenceSetup.LicenceName asc";
            SqlConnection sqlConn = new SqlConnection(_connectionString);
            sqlConn.Open();
            SqlCommand myCommand = sqlConn.CreateCommand();
            myCommand.Connection = sqlConn;
            try
            {
                objCompanySetup.loadCompanySetup(colname, tablename, whereCaluse, headername, grdCompanyLicence, myCommand);
                if (grdCompanyLicence.Rows.Count > 0)
                {
                    lblMessageCompanyLicence.Text = string.Empty;

                }
                else
                {
                    pnlShowGridCompanyLicence.Visible = false;
                    lblMessageCompanyLicence.Text = "No record found for company matters";
                }
            }
            catch
            {
                clsTopMostMessageBox.Show1("Please try again", "Error");
            }
            finally
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }


        protected void grdCompanyLicence_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[5].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[5].Visible = false;

                SqlConnection sqlConn = new SqlConnection(_connectionString);
                sqlConn.Open();
                SqlCommand myCommand = sqlConn.CreateCommand();
                myCommand.Connection = sqlConn;
                try
                {
                    DropDownList ddlLicenceName = (DropDownList)e.Row.FindControl("ddlLicenceName");
                    foreach (ListItem li in ddlLicenceName.Items)
                    {
                        if (li.Value == e.Row.Cells[2].Text)
                            ddlLicenceName.SelectedValue = li.Value;
                    }
                    ddlLicenceName.Enabled = false;

                }
                finally
                {
                    if (sqlConn.State == System.Data.ConnectionState.Open)
                    {
                        sqlConn.Close();
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[5].Visible = false;
            }
        }

        protected void grdCompanyLicence_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string CompanyID = string.Empty;
            int i = GridCompanySetup.SelectedIndex;
            if (i.ToString() != string.Empty)
            {
                CompanyID = GridCompanySetup.Rows[i].Cells[0].Text;
                grdCompanyLicence.PageIndex = e.NewPageIndex;
                grdCompanyLicence.EditIndex = -1;
                LoadCompanyLicence(CompanyID, Session["branch"].ToString());
            }
            else
            {
                grdCompanyLicence.Visible = false;
            }

        }

        #endregion Company Licence

       

        private void ClearCompanyLicence()
        {
            ddlLicenceNameEnter.SelectedIndex = -1;
            txtLicenceValueEnter.Text = string.Empty;
        }

        private string ValidationForCompanyLicence(DropDownList ddlNameOfLicence, string ValueOFLicence)
        {
            string checkValidity = string.Empty;
            if (ValueOFLicence == string.Empty)
            {
                checkValidity = checkValidity + "\r\n" + "Licence Value;";
            }
            if (ValueOFLicence.Length > 100)
            {
                checkValidity = checkValidity + "\r\n" + "Maximum length of 'Licence Value' must not exceed 100!";
            }

            if ((ddlNameOfLicence.SelectedIndex == -1) || (ddlNameOfLicence.SelectedItem.Text == "-- Select --"))
            {
                checkValidity = checkValidity + "\r\n" + "Licence Name;";
            }

            return checkValidity;
        }

       

       

        
        protected void lnkExpand_Click(object sender, EventArgs e)
        {
            pnlShowGridCompanyLicence.Visible = false;
        }

        

        protected void grdCompanyLicence_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdCompanyLicence.Rows[e.RowIndex];
            TextBox Id = (TextBox)grdCompanyLicence.Rows[e.RowIndex].Cells[5].Controls[0];
            TextBox matterBranch = (TextBox)grdCompanyLicence.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox matterValue = (TextBox)grdCompanyLicence.Rows[e.RowIndex].Cells[4].Controls[0];
            DropDownList matterName = (DropDownList)row.FindControl("ddlLicenceName");

            
        }

        protected void grdCompanyLicence_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCompanyLicence.EditIndex = e.NewEditIndex;
            LoadCompanyLicence(Session["company"].ToString(), Session["branch"].ToString());
            DropDownList ddlLicenceNameInGrid = (DropDownList)grdCompanyLicence.Rows[grdCompanyLicence.EditIndex].FindControl("ddlLicenceName");
            ddlLicenceNameInGrid.Enabled = true;
            TextBox LicenceNameInGrid = (TextBox)grdCompanyLicence.Rows[grdCompanyLicence.EditIndex].Cells[2].Controls[0];
            ddlLicenceNameInGrid.SelectedValue = LicenceNameInGrid.Text;
        }

        protected void grdCompanyLicence_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            grdCompanyLicence.EditIndex = -1;
            string Userid = Session["username"].ToString();
            int i = Convert.ToInt32(e.RowIndex);
            string LicenceId = grdCompanyLicence.Rows[i].Cells[5].Text;
            
        }

        protected void grdCompanyLicence_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCompanyLicence.EditIndex = -1;
            LoadCompanyLicence(Session["company"].ToString(), Session["branch"].ToString());
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlCountry.SelectedItem.Text != "-- Select --") && (ddlCountry.SelectedIndex != -1))
            {
                objCompanySetup.pCountryID = ddlCountry.SelectedValue;

                SqlConnection sqlConn = new SqlConnection(_connectionString);
                sqlConn.Open();
                SqlCommand myCommand = sqlConn.CreateCommand();
                myCommand.Connection = sqlConn;
                string Wherecluse = "where [CountryID]='" + Convert.ToInt32(objCompanySetup.pCountryID) + "' and [DataUsed]='A'";
                lblDialingCode.Text = clsDataManipulation.GetSingleValueFromtable(myCommand, "gCountryList", "DialingCode", Wherecluse);
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        protected void btnUploadCompanyImage_Click(object sender, EventArgs e)
        {
            DeleteTempCompanyLogo();
            string FileNameWithoutExten = string.Empty;
            if (FluPhotoUpload.FileBytes.Length == 0)
                return;
            string ext = System.IO.Path.GetExtension(FluPhotoUpload.FileName).TrimStart(".".ToCharArray()).ToLower();
            if ((ext != "jpeg") && (ext != "jpg") && (ext != "png") && (ext != "gif") && (ext != "bmp"))
            {
                return;
            }

            if (System.IO.Path.GetFileNameWithoutExtension(FluPhotoUpload.FileName).Contains("_temp_"))
            {
                return;
            }

            Bitmap uploadedImage = new Bitmap(FluPhotoUpload.FileContent);

            int maxWidth = 100;
            int maxHeight = 100;


            Bitmap resizedImage = objImageHandler.GetScaledPicture(uploadedImage, maxWidth, maxHeight);

            String virtualPath = "~/App_Themes/CSSstyleTheme/CompanyLogo/" + Session["company"].ToString() + "_temp_" + Path.GetFileNameWithoutExtension(FluPhotoUpload.PostedFile.FileName) + "." + ext;
            String tempFileName = Server.MapPath(virtualPath);
            resizedImage.Save(tempFileName, uploadedImage.RawFormat);

            ImgCompanyLogo.ImageUrl = virtualPath;
            imageContainer.Visible = true;
        }

        private void DeleteExistingCompanyLogo()
        {
            string FileName = string.Empty;
            string FileNameWithExten = string.Empty;
            string FileNameWithoutExten = string.Empty;
            string FileNameWithExten1 = string.Empty;
            string FileNameWithoutExten1 = string.Empty;
            string delFilename = string.Empty;
            string renFilename = string.Empty;
            string newFilename = string.Empty;
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Themes/CSSstyleTheme/CompanyLogo/"));

            foreach (string fname in filePaths)
            {

                FileNameWithExten = Path.GetFileNameWithoutExtension(fname);
                FileNameWithoutExten = Path.GetExtension(fname);
                if (((FileNameWithExten.Split('_'))[0] == Session["company"].ToString()) && ((FileNameWithExten.Split('_'))[1] == "temp"))
                {
                    string completePath2 = Server.MapPath("~/App_Themes/CSSstyleTheme/CompanyLogo/");
                    renFilename = System.IO.Path.Combine(completePath2, FileNameWithExten + FileNameWithoutExten);
                    newFilename = System.IO.Path.Combine(completePath2, FileNameWithExten.Replace("temp_", string.Empty) + FileNameWithoutExten);

                    if (System.IO.File.Exists(renFilename))
                    {
                        foreach (string fname1 in filePaths)
                        {
                            FileNameWithExten1 = Path.GetFileNameWithoutExtension(fname1);
                            FileNameWithoutExten1 = Path.GetExtension(fname1);
                            if (((FileNameWithExten1.Split('_'))[0] == Session["company"].ToString()) && ((FileNameWithExten1.Split('_'))[1] != "temp"))
                            {
                                string completePath1 = Server.MapPath("~/App_Themes/CSSstyleTheme/CompanyLogo/");
                                delFilename = System.IO.Path.Combine(completePath1, FileNameWithExten1 + FileNameWithoutExten1);
                                if (System.IO.File.Exists(delFilename))
                                {
                                    System.IO.FileInfo fle = new System.IO.FileInfo(delFilename);
                                    fle.Delete();
                                }

                            }
                        }

                        System.IO.FileInfo fl = new System.IO.FileInfo(renFilename);
                        System.IO.FileInfo f = fl.CopyTo(newFilename, true);
                        fl.Delete();
                    }
                }
            }
        }

        private void DeleteTempCompanyLogo()
        {
            string FileName = string.Empty;
            string FileNameWithExten = string.Empty;
            string FileNameWithoutExten = string.Empty;
            string delFilename = string.Empty;
            string renFilename = string.Empty;
            string newFilename = string.Empty;
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Themes/CSSstyleTheme/CompanyLogo/"));
            foreach (string fname in filePaths)
            {

                FileNameWithExten = Path.GetFileNameWithoutExtension(fname);
                FileNameWithoutExten = Path.GetExtension(fname);
                if (((FileNameWithExten.Split('_'))[0] == Session["company"].ToString()) && ((FileNameWithExten.Split('_'))[1] == "temp"))
                {
                    string completePath2 = Server.MapPath("~/App_Themes/CSSstyleTheme/CompanyLogo/");
                    renFilename = System.IO.Path.Combine(completePath2, FileNameWithExten + FileNameWithoutExten);

                    if (System.IO.File.Exists(renFilename))
                    {
                        System.IO.FileInfo fle = new System.IO.FileInfo(renFilename);
                        fle.Delete();
                    }
                }
            }
        }

        private string CheckForCompanyLogo()
        {
            string FileName = string.Empty;
            string FileNameWithExten = string.Empty;
            string FileNameWithoutExten = string.Empty;
            string delFilename = string.Empty;
            string renFilename = string.Empty;
            string newFilename = string.Empty;
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Themes/CSSstyleTheme/CompanyLogo/"));
            foreach (string fname in filePaths)
            {

                FileNameWithExten = Path.GetFileNameWithoutExtension(fname);
                FileNameWithoutExten = Path.GetExtension(fname);
                if (((FileNameWithExten.Split('_'))[0] == Session["company"].ToString()) && ((FileNameWithExten.Split('_'))[1] != "temp"))
                {
                    string completePath2 = Server.MapPath("~/App_Themes/CSSstyleTheme/CompanyLogo/");
                    renFilename = System.IO.Path.Combine(completePath2, FileNameWithExten + FileNameWithoutExten);

                    if (System.IO.File.Exists(renFilename))
                    {
                        FileName = "~/App_Themes/CSSstyleTheme/CompanyLogo/" + FileNameWithExten + FileNameWithoutExten;

                    }
                    else
                    {
                        FileName = string.Empty;
                    }
                }
            }
            return FileName;
        }

        private string UserID()
        {
            DataTable dt = new DataTable();
            string uName = string.Empty;

            string sql = "select a.UserName as UserName,a.UserID as UserID  from uUserList a "
                       + " inner join [uUserProfile] b on a.UserID=b.UserProfileID "
                       + " inner join [uCompanyWiseUserList] c on c.UserID=a.UserID "
                       + " where a.UserName='" + Session["username"] + "' and c.CompanyID='" + Session["company"] + "' and c.BranchID='" + Session["branch"] + "'";


            dt = clsDataManipulation.GetData(_connectionString, sql);

            if (dt.Rows.Count == 0)
            {
                uName = Session["username"].ToString();
                return uName;
            }
            else
            {
                uName = dt.Rows[0]["UserID"].ToString();
                return uName;
            }
        }

        protected void btnCloseCompanyLicence_Click(object sender, EventArgs e)
        {
            pnlShowGridCompanyLicence.Visible = true;

        }
    }
}