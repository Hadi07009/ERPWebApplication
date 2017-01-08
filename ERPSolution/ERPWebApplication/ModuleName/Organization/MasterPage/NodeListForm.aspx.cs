using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.DataAccess;
using System.Text.RegularExpressions;
using System.Data;

namespace ERPWebApplication.ModuleName.Organization.MasterPage
{
    public partial class NodeListForm : System.Web.UI.Page
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        private NodeList _objNodeList;
        private NodeListController _objNodeListController;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    PanelFormDetails.Visible = false;
                    Session["companyID"] = 1;
                    Session["branchID"] = 1;
                    lblParentText.Visible = false;
                    lblParentValue.Visible = false;
                    _objNodeListController = new NodeListController();
                    _objNodeListController.PopulateRootLevel(_connectionString, treeNodeList);
                    GetAllFormURL();
                    btnSave.Visible = false;
                    btnCancelAddNew.Visible = false;
                    btnUpdate.Visible = false;
                    btnCancelEdit.Visible = false;
                    PanelFormDetails.Height = 50;

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlType.SelectedValue == "4")
                {
                    PanelFormDetails.Visible = true;

                }
                else
                {
                    PanelFormDetails.Visible = false;
                }

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
                AddValuesOfNode();
                treeNodeList.Nodes.Clear();
                _objNodeListController = new NodeListController();
                _objNodeListController.PopulateRootLevel(_connectionString, treeNodeList);
                ClearControl();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
                treeNodeList.ExpandAll();

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
                txtTitle.Text = string.Empty;
                txtDescription.Text = string.Empty;
                ddlType.SelectedValue = "-1";
                ddlFormURL.SelectedValue = "-1";
                ddlShowPosition.SelectedValue = "-1";
                PanelFormDetails.Visible = false;
                lblParentText.Text = string.Empty;
                lblParentText.Visible = false;
                lblParentValue.Text = string.Empty;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void AddValuesOfNode()
        {
            try
            {
                _objNodeListController = new NodeListController();
                _objNodeList = new NodeList();
                _objNodeList.ActivityID = Convert.ToInt32(ddlType.SelectedValue);
                _objNodeList.ActivityName = txtTitle.Text == string.Empty ? null : txtTitle.Text;
                _objNodeList.BranchID = Convert.ToInt32(Session["branchID"].ToString());
                _objNodeList.CompanyID = Convert.ToInt32(Session["companyID"].ToString());
                _objNodeList.FormDescription = txtDescription.Text == string.Empty ? null : txtDescription.Text;
                _objNodeList.FormName = ddlFormURL.SelectedValue == "-1" ? null : ddlFormURL.SelectedValue;
                _objNodeList.ShowPosition = Convert.ToInt32( ddlShowPosition.SelectedValue);
                _objNodeList.ParentNodeTypeID = lblParentValue.Text == string.Empty ? 0 : Convert.ToInt32(lblParentValue.Text);
                _objNodeList.SeqNo = _objNodeListController.GetSeqNo(_connectionString);
                _objNodeListController.Save(_connectionString, _objNodeList);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        protected void treeNodeList_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            try
            {
                _objNodeListController = new NodeListController();
                _objNodeListController.PopulateSubLevel(_connectionString, Int32.Parse(e.Node.Value), e.Node);
                treeNodeList.ExpandAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void treeNodeList_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                lblParentText.Text = treeNodeList.SelectedNode.Text;
                lblParentText.Visible = true;
                var nodeValue = treeNodeList.SelectedNode.Value;
                lblParentValue.Text = nodeValue;
                txtTitle.Focus();
                if (Convert.ToInt32(nodeValue) == 111)
                {
                    btnEdit.Enabled = false;
                    btnUpdate.Visible = false;
                    btnCancelEdit.Visible = false;

                }
                else
                {
                    btnEdit.Enabled = true;
                    ViewNodeDetails(nodeValue);
                }


            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ViewNodeDetails(string nodeValue)
        {
            try
            {
                _objNodeList = new NodeList();
                _objNodeList.NodeTypeID = Convert.ToInt32(nodeValue);
                _objNodeListController = new NodeListController();

                DataTable dtNodeDetails = _objNodeListController.GetNodeDetails(_connectionString, _objNodeList);
                foreach (DataRow row in dtNodeDetails.Rows)
                {
                    txtTitle.Text = row["ActivityName"].ToString() == null ? string.Empty : row["ActivityName"].ToString();
                    txtDescription.Text = row["FormDescription"].ToString() == null ? string.Empty : row["FormDescription"].ToString();
                    ddlType.SelectedValue = row["ActivityID"].ToString() == null ? "-1" : row["ActivityID"].ToString();
                    string formURL = row["FormName"].ToString() == "" ? null : row["FormName"].ToString();
                    int formPosition = row["ShowPosition"].ToString() == "0" ? -1 : Convert.ToInt32( row["ShowPosition"].ToString());
                    if (formURL == null || formURL == string.Empty)
                    {
                        PanelFormDetails.Visible = false;
                    }
                    else
                    {
                        PanelFormDetails.Visible = true;
                        ddlFormURL.SelectedValue = formURL;
                        ddlShowPosition.SelectedValue = formPosition.ToString();
                    }


                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        public void GetAllFormURL()
        {
            try
            {
                string root = Server.MapPath("~");
                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(root);
                System.IO.FileInfo[] files = info.GetFiles("*.aspx", System.IO.SearchOption.AllDirectories);
                string pageName = "";
                ddlFormURL.Items.Clear();
                ddlFormURL.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                foreach (System.IO.FileInfo fi in files)
                {
                    pageName = fi.FullName.Replace(root, "~/").Replace("\\", "/");

                    ListItem lst = new ListItem();
                    lst.Value = pageName;
                    lst.Text = fi.Name.ToString();
                    ddlFormURL.Items.Add(lst);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = true;
                btnCancelAddNew.Visible = true;
                btnUpdate.Visible = false;
                btnCancelEdit.Visible = false;

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
                btnSave.Visible = false;
                btnCancelAddNew.Visible = false;
                btnUpdate.Visible = true;
                btnCancelEdit.Visible = true;

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnCancelAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = false;
                btnCancelAddNew.Visible = false;
                ClearControl();
                _objNodeListController = new NodeListController();
                _objNodeListController.PopulateRootLevel(_connectionString, treeNodeList);
                treeNodeList.ExpandAll();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Visible = false;
                btnCancelEdit.Visible = false;
                ClearControl();
                _objNodeListController = new NodeListController();
                _objNodeListController.PopulateRootLevel(_connectionString, treeNodeList);
                treeNodeList.ExpandAll();

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
                AddValuesForUpdate();
                treeNodeList.Nodes.Clear();
                _objNodeListController = new NodeListController();
                _objNodeListController.PopulateRootLevel(_connectionString, treeNodeList);
                ClearControl();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
                treeNodeList.ExpandAll();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void AddValuesForUpdate()
        {
            try
            {
                _objNodeListController = new NodeListController();
                _objNodeList = new NodeList();
                _objNodeList.ActivityID = Convert.ToInt32(ddlType.SelectedValue);
                _objNodeList.ActivityName = txtTitle.Text == string.Empty ? null : txtTitle.Text;
                _objNodeList.FormDescription = txtDescription.Text == string.Empty ? null : txtDescription.Text;
                _objNodeList.FormName = ddlFormURL.SelectedValue == "-1" ? null : ddlFormURL.SelectedValue;
                _objNodeList.ShowPosition = Convert.ToInt32( ddlShowPosition.SelectedValue);
                _objNodeList.NodeTypeID = lblParentValue.Text == string.Empty ? 0 : Convert.ToInt32(lblParentValue.Text);
                _objNodeListController.Update(_connectionString, _objNodeList);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}