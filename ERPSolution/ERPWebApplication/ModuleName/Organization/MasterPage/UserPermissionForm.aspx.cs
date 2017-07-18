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
    public partial class UserPermissionForm : System.Web.UI.Page
    {
        private UserPermissionController _objUserPermissionController;
        private UserPermission _objUserPermission;
        private CompanySetup _objCompanySetup;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _objUserPermissionController = new UserPermissionController();
                    _objUserPermissionController.PopulateRootLevel(TreeViewAllNode);
                    _objUserPermissionController.LoadRoleTypeData(ddlRoleType);
                    _objUserPermissionController.LoadRoleTypeData(ddlRoleTypeUser);
                    LoadRoleRecordGrid();
                    LoadRoleRecordList();
                    txtUserCode_AutoCompleteExtender.ContextKey = LoginUserInformation.CompanyID.ToString();
                    _objCompanySetup = new CompanySetup();
                    _objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                    _objUserPermissionController.LoadRelatedUserRoleLB(ListBoxRelatedUserRole,_objCompanySetup);

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        private void LoadRoleRecordList()
        {
            try
            {
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                _objUserPermission = new UserPermission();
                _objUserPermission.RoleType = ddlRoleTypeUser.SelectedValue;
                _objUserPermissionController = new UserPermissionController();
                _objUserPermissionController.GetRoleRecord(_objCompanySetup, _objUserPermission, ListBoxRoles);

            }
            catch (Exception msgException)
            {
                
                throw msgException; 
            }
        }
        private void LoadUserRoleRecord()
        {
            try
            {
                EmployeeSetup objEmployeeSetup = new EmployeeSetup();
                objEmployeeSetup.CompanyID = LoginUserInformation.CompanyID;
                objEmployeeSetup.EmployeeID = txtUserCode.Text == string.Empty ? null : txtUserCode.Text;
                _objUserPermission = new UserPermission();
                _objUserPermission.RoleType = ddlRoleTypeUser.SelectedValue;
                _objUserPermissionController = new UserPermissionController();
                _objUserPermissionController.GetUserRoleRecord(objEmployeeSetup, _objUserPermission, ListBoxSelectedRoles);
                _objUserPermissionController.GetRelatedUserRoleRecord(objEmployeeSetup,ListBoxSelectedRelatedUserRole);
                if (ListBoxSelectedRoles.Items.Count > 0)
                {
                    btnSave.Text = "Update";
                    
                }
                else
                {
                    btnSave.Text = "Save";
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void LoadRoleRecordGrid()
        {
            try
            {
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                _objUserPermission = new UserPermission();
                _objUserPermission.RoleType = ddlRoleType.SelectedValue;
                _objUserPermissionController = new UserPermissionController();
                _objUserPermissionController.GetRoleRecord(_objCompanySetup,_objUserPermission,GridViewRoles);
            }
            catch (Exception msgExceptin)
            {
                
                throw msgExceptin;
            }
        }
        protected void TreeViewAllNode_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            try
            {
                _objUserPermissionController = new UserPermissionController();
                _objUserPermissionController.PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
                TreeViewAllNode.ExpandAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnRoleSave_Click(object sender, EventArgs e)
        {
            try
            {
                AddValuesForRoleSetup();
                LoadRoleRecordGrid();
                LoadRoleRecordList();
                ClearControl();
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
                ddlRoleType.SelectedValue = "-1";
                txtRoleTitle.Text = string.Empty;
                btnRoleSave.Text = "Save";
                ddlRoleType.Enabled = true;
                while (TreeViewAllNode.CheckedNodes.Count > 0)
                {
                    TreeViewAllNode.CheckedNodes[0].Checked = false;
                }
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }
        List<int> listNode = new List<int>();
        private void AddValuesForRoleSetup()
        {
            try
            {
                _objUserPermission = new UserPermission();
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                _objCompanySetup.EntryUserName = LoginUserInformation.UserID;
                _objUserPermission.RoleName = txtRoleTitle.Text == string.Empty ? null : txtRoleTitle.Text;
                
                foreach (TreeNode nodeNumber in this.TreeViewAllNode.Nodes)
                {
                    saveNodePermission(nodeNumber);
                }
                
                _objUserPermission.nodeList = listNode;
                
                _objUserPermission.RoleType = ddlRoleType.SelectedValue == "-1" ? null : ddlRoleType.SelectedValue;
                _objUserPermissionController = new UserPermissionController();
                if (btnRoleSave.Text == "Save")
                {
                    _objUserPermissionController.SaveRoleData(_objCompanySetup, _objUserPermission);
                    
                }
                else
                {
                    _objUserPermission.RoleID = Convert.ToInt32(Session["selectedRoleID"].ToString());
                    _objUserPermissionController.UpdateRoleData(_objCompanySetup,_objUserPermission);
                }
                
            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void saveNodePermission(TreeNode targetNode)
        {
            try
            {
                if (targetNode.ChildNodes.Count > 0)
                {
                    if (targetNode.Checked)
                    {
                        listNode.Add(Convert.ToInt32(targetNode.Value.ToString()));
                    }
                    foreach (TreeNode targetChildNode in targetNode.ChildNodes)
                    {
                        saveNodePermission(targetChildNode);
                        
                    }
                }
                else
                {
                    if (targetNode.Checked)
                    {
                        listNode.Add(Convert.ToInt32(targetNode.Value.ToString()));
                    }
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        protected void ddlRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadRoleRecordGrid();
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void ddlRoleTypeUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadRoleRecordList();
                this.LoadUserRoleRecord();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnForword_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in ListBoxRoles.Items)
                {
                    if (item.Selected)
                    {
                        if (ListBoxSelectedRoles.Items.Contains(item))
                        {
                            throw new Exception("this element already selected.");

                        }

                        ListBoxSelectedRoles.Items.Add(new ListItem(item.Text, item.Value));
                        ListBoxSelectedRoles.AppendDataBoundItems = true;
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
                ListBoxSelectedRoles.Items.Clear();
                foreach (ListItem item in ListBoxRoles.Items)
                {
                    ListBoxSelectedRoles.Items.Add(item);
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
                foreach (ListItem item in ListBoxSelectedRoles.Items)
                {
                    if (item.Selected)
                    {
                        deletedItems.Add(item);
                    }
                }

                foreach (ListItem item in deletedItems)
                {
                    ListBoxSelectedRoles.Items.Remove(item);
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
                ListBoxSelectedRoles.Items.Clear();

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
                AddValuesForUserRole();
                ClearControlOfUserRole();
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ClearControlOfUserRole()
        {
            try
            {
                txtUserCode.Text = string.Empty;
                ddlRoleTypeUser.SelectedValue = "-1";
                ListBoxSelectedRoles.Items.Clear();
                btnSave.Text = "Save";
                ListBoxSelectedRelatedUserRole.Items.Clear();

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        private void AddValuesForUserRole()
        {
            try
            {
                _objUserPermission = new UserPermission();
                List<int> listRole = new List<int>();
                foreach (ListItem item in ListBoxSelectedRoles.Items)
                {
                    listRole.Add( Convert.ToInt32( item.Value.ToString()));
                }
                _objUserPermission.roleList = listRole;
                _objUserPermission.RoleType = ddlRoleTypeUser.SelectedValue == "-1" ? null : ddlRoleTypeUser.SelectedValue;
                EmployeeSetup objEmployeeSetup = new EmployeeSetup();
                objEmployeeSetup.EmployeeID = txtUserCode.Text == string.Empty ? null : txtUserCode.Text;
                objEmployeeSetup.CompanyID = LoginUserInformation.CompanyID;
                objEmployeeSetup.EntryUserName = LoginUserInformation.UserID;
                _objUserPermissionController = new UserPermissionController();

                List<int> listRelatedUserRole = new List<int>();
                foreach (ListItem item in ListBoxSelectedRelatedUserRole.Items)
                {
                    listRelatedUserRole.Add( Convert.ToInt32( item.Value.ToString()));
                }
                _objUserPermission.RelatedUserRoleList = listRelatedUserRole;

                if (btnSave.Text == "Save")
                {
                    _objUserPermissionController.SaveUserRole(objEmployeeSetup, _objUserPermission);
                }
                else
                {
                    _objUserPermissionController.UpdateUserRole(objEmployeeSetup,_objUserPermission);
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
                this.ClearControlOfUserRole();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void GridViewRoles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
        }

        protected void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadUserRoleRecord();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void GridViewRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string lblRoleID = ((Label)GridViewRoles.Rows[selectedIndex].FindControl("lblRoleID")).Text;
                if (e.CommandName.Equals("Select"))
                {
                    string lblRoleName = ((Label)GridViewRoles.Rows[selectedIndex].FindControl("lblRoleName")).Text;
                    string lblRoleTypeID = ((Label)GridViewRoles.Rows[selectedIndex].FindControl("lblRoleTypeID")).Text;
                    
                    ddlRoleType.SelectedValue = lblRoleTypeID;
                    txtRoleTitle.Text = lblRoleName;
                    btnRoleSave.Text = "Update";
                    Session["selectedRoleID"] = lblRoleID;
                    ShowNodesOfRole();
                    ddlRoleType.Enabled = false;
                    
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ShowNodesOfRole()
        {
            try
            {
                _objUserPermission = new UserPermission();
                _objUserPermission.RoleID = Convert.ToInt32( Session["selectedRoleID"].ToString());
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = LoginUserInformation.CompanyID;
                _objUserPermissionController = new UserPermissionController();
                DataTable dtNodes = _objUserPermissionController.GetNodesOfRole(_objCompanySetup,_objUserPermission);
                while (TreeViewAllNode.CheckedNodes.Count > 0)
                {
                    TreeViewAllNode.CheckedNodes[0].Checked = false;
                }

                foreach (DataRow rowNo in dtNodes.Rows)
                {
                    foreach (TreeNode nodeNumber in this.TreeViewAllNode.Nodes)
                    {
                        ShowNodeInRole(nodeNumber, rowNo["NodeID"].ToString());
                    }
                    
                }

            }
            catch (Exception msgException)
            {
                
                throw msgException;
            }
        }

        
        private void ShowNodeInRole(TreeNode targetNode,string nodeValue)
        {
            try
            {
                if (nodeValue == targetNode.Value)
                {
                    targetNode.Checked = true;

                }

                foreach (TreeNode targetChildNode in targetNode.ChildNodes)
                {
                    if (nodeValue == targetChildNode.Value)
                    {
                        targetChildNode.Checked = true;
                        
                    }
                    
                    ShowNodeInRole(targetChildNode,nodeValue);

                }
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnRoleClear_Click(object sender, EventArgs e)
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

        protected void btnForwordUserRole_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in ListBoxRelatedUserRole.Items)
                {
                    if (item.Selected)
                    {
                        if (ListBoxSelectedRelatedUserRole.Items.Contains(item))
                        {
                            throw new Exception("this element already selected.");

                        }

                        ListBoxSelectedRelatedUserRole.Items.Add(new ListItem(item.Text, item.Value));
                        ListBoxSelectedRelatedUserRole.AppendDataBoundItems = true;
                    }
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void btnForwordAllUserRole_Click(object sender, EventArgs e)
        {
            try
            {
                ListBoxSelectedRelatedUserRole.Items.Clear();
                foreach (ListItem item in ListBoxRelatedUserRole.Items)
                {
                    ListBoxSelectedRelatedUserRole.Items.Add(item);
                }
            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void btnBackUserRole_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListItem> deletedItems = new List<ListItem>();
                foreach (ListItem item in ListBoxSelectedRelatedUserRole.Items)
                {
                    if (item.Selected)
                    {
                        deletedItems.Add(item);
                    }
                }

                foreach (ListItem item in deletedItems)
                {
                    ListBoxSelectedRelatedUserRole.Items.Remove(item);
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }

        protected void btnBackAllUserRole_Click(object sender, EventArgs e)
        {
            try
            {
                ListBoxSelectedRelatedUserRole.Items.Clear();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }

        }
    }
}