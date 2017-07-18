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

namespace ERPWebApplication.ModuleName.Accounts.MasterPage
{
    public partial class YearSetupForm : System.Web.UI.Page
    {
        private YearSetup _objYearSetup;
        private YearSetupController _YearSetupController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.ShowLastOpenYear();

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void ShowLastOpenYear()
        {
            try
            {
                _YearSetupController = new YearSetupController();
                DataTable dtLastOpenYear =  _YearSetupController.GetLastOpenYearData();
                if (dtLastOpenYear.Rows.Count > 0)
                {
                    PanelLastOpenYear.Visible = true;
                    lblLastOpenYear.Visible = false;
                    txtLastYearStartDate.Text = dtLastOpenYear.Rows[0]["BeginningYear"].ToString() == null ?string.Empty : Convert.ToDateTime(dtLastOpenYear.Rows[0]["BeginningYear"].ToString()).ToString("yyyy-MM-dd");
                    txtLastYearEndDate.Text = dtLastOpenYear.Rows[0]["EndingYear"].ToString() == null ? string.Empty : Convert.ToDateTime(dtLastOpenYear.Rows[0]["EndingYear"].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    PanelLastOpenYear.Visible = false;
                    lblLastOpenYear.Visible = true;
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void btnYearOpen_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesOfYear();
                ClearControl();
                this.ShowLastOpenYear();
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
                txtNewYearStartDate.Text = string.Empty;
                txtNewYearEndDate.Text = string.Empty;
                txtOpenBy.Text = string.Empty;
                txtRemarks.Text = string.Empty;

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesOfYear()
        {
            try
            {
                _objYearSetup = new YearSetup();
                _objYearSetup.CompanyID = LoginUserInformation.CompanyID;
                //_objYearSetup.BranchID = LoginUserInformation.BranchID;
                if (txtNewYearStartDate.Text == string.Empty)
                {
                    _objYearSetup.BeginningYear =  null;
                }
                else
                {
                    _objYearSetup.BeginningYear =  Convert.ToDateTime(txtNewYearStartDate.Text);
                }

                if (txtNewYearEndDate.Text == string.Empty)
                {
                    _objYearSetup.EndingYear = null;
                }
                else
                {
                    _objYearSetup.EndingYear = Convert.ToDateTime(txtNewYearEndDate.Text);

                }

                
                _objYearSetup.EntryUserName = LoginUserInformation.UserID;
                _objYearSetup.YearOpenBy = txtOpenBy.Text == string.Empty ? null : txtOpenBy.Text;
                _objYearSetup.Remarks = txtRemarks.Text == string.Empty ? null : txtRemarks.Text;
                _YearSetupController = new YearSetupController();
                _YearSetupController.Save(_objYearSetup);

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
    }
}