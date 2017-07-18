using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.DataAccess;

namespace ERPWebApplication.ModuleName.Accounts.MasterPage
{
    public partial class SubledgerSetupForm : System.Web.UI.Page
    {
        private SubledgerSetup _objSubledgerSetup;
        private SubledgerSetupController _objSubledgerSetupController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadSubLedgerTypeDDL();
                    LoadKnownValueDDL();

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadKnownValueDDL()
        {
            try
            {
                _objSubledgerSetup = new SubledgerSetup();
                _objSubledgerSetup.CompanyID = LoginUserInformation.CompanyID;
                _objSubledgerSetup.BranchID = 0; //LoginUserInformation.BranchID;
                _objSubledgerSetupController = new SubledgerSetupController();
                _objSubledgerSetupController.GetKnownValueSubledger(_objSubledgerSetup,ddlKnownValue);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadSubLedgerTypeDDL()
        {
            try
            {
                _objSubledgerSetup = new SubledgerSetup();
                _objSubledgerSetup.CompanyID = LoginUserInformation.CompanyID;
                _objSubledgerSetup.BranchID = 0;//LoginUserInformation.BranchID;
                _objSubledgerSetupController = new SubledgerSetupController();
                _objSubledgerSetupController.GetSubLedgerTypeConvertable(ddlSubLedgerTypeConvertible, _objSubledgerSetup);
                _objSubledgerSetupController.GetSubLedgerTypeNonConvertable(ddlSubLedgerTypeNonConvertable, _objSubledgerSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }



        protected void btnSubledgerTypeSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesSubledgerType();
                ClearControl();
                this.LoadSubLedgerTypeDDL();
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
                txtSubledgerType.Text = string.Empty;
                txtSubledgerPrefix.Text = string.Empty;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddValuesSubledgerType()
        {
            try
            {
                _objSubledgerSetup = new SubledgerSetup();
                _objSubledgerSetup.CompanyID = LoginUserInformation.CompanyID;
                _objSubledgerSetup.SubLedgerTypeName = txtSubledgerType.Text == string.Empty ? null : txtSubledgerType.Text;
                _objSubledgerSetup.SubledgerTypePrefix = txtSubledgerPrefix.Text == string.Empty ? null : txtSubledgerPrefix.Text;
                _objSubledgerSetup.KnownValueId = Convert.ToInt32(ddlKnownValue.SelectedValue);
                _objSubledgerSetup.IsConvertable = rdoConvert.SelectedValue;
                _objSubledgerSetup.EntryUserName = LoginUserInformation.UserID;
                _objSubledgerSetupController = new SubledgerSetupController();
                _objSubledgerSetupController.Save(_objSubledgerSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnSaveSubLedger_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesSubLedger();
                ClearControlSubLedger();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlSubLedger()
        {
            try
            {
                ddlSubLedgerTypeNonConvertable.SelectedValue = "-1";
                txtSubledgerName.Text = string.Empty;
                txtDescription.Text = string.Empty;
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesSubLedger()
        {
            try
            {
                _objSubledgerSetup = new SubledgerSetup();
                _objSubledgerSetup.CompanyID = LoginUserInformation.CompanyID;
                _objSubledgerSetup.BranchID = 0;// LoginUserInformation.BranchID;
                _objSubledgerSetup.EntryUserName = LoginUserInformation.UserID;
                _objSubledgerSetup.SubledgerTypeID = ddlSubLedgerTypeNonConvertable.SelectedValue;
                _objSubledgerSetup.SubledgerHeadName = txtSubledgerName.Text == string.Empty ? null : txtSubledgerName.Text;
                _objSubledgerSetup.SubledgerDescription = txtDescription.Text == string.Empty ? null : txtDescription.Text;
                _objSubledgerSetupController = new SubledgerSetupController();
                _objSubledgerSetupController.SaveSubLedger(_objSubledgerSetup);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnConvertSubledger_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesConvertSubledger();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AddValuesConvertSubledger()
        {
            try
            {
                _objSubledgerSetup = new SubledgerSetup();
                _objSubledgerSetup.SubledgerTypeID = ddlSubLedgerTypeConvertible.SelectedValue;
                _objSubledgerSetup.EntryUserName = LoginUserInformation.UserID;
                _objSubledgerSetupController = new SubledgerSetupController();
                _objSubledgerSetupController.SaveSubLedgerConvertible(_objSubledgerSetup);

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
    }
}