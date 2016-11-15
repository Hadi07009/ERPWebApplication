using ERPWebApplication.AppClass.DataAccess;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.CommonClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using ERPWebApplication.AppClass.CommonClass;

namespace ERPWebApplication.ModuleName.Inventory.MasterPage
{
    public partial class ItemCategorySetupForm : System.Web.UI.Page
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        private ItemCategorySetup _objItemCategorySetup;
        private ItemCategorySetupController _objItemCategorySetupController;
        private ItemSetup _objItemSetup;
        private ItemSetupController _objItemSetupController;
        private CompanySetup _objCompanySetup;
        private BranchSetup _objBranchSetup;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["company"] = 1;
                    Session["branch"] = 1;
                    Session["entryUserCode"] = "ADM";
                    PanelItemSetup.Visible = false;
                    PopulateRootLevel();
                    LoadCategory(ddlCategory);
                    LoadCategory(ddlParentCategory);
                    CheckBoxAddItem.Enabled = false;


                }

            }
            catch (Exception msgException)
            {

                TopMostMessageBox.Show(msgException.Message);
            }
        }



        private void LoadCategory(DropDownList ddlCategory)
        {
            try
            {
                _objItemCategorySetupController = new ItemCategorySetupController();
                _objItemCategorySetupController.GetCategory(_connectionString, ddlCategory);
                if (TreeViewCategory.Nodes.Count > 0)
                {
                    ddlCategory.Items.RemoveAt(0);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void PopulateRootLevel()
        {
            try
            {
                var myConnection = new SqlConnection(_connectionString);
                var command = new SqlCommand("SELECT ItemCategoryID,CategoryName," +
                "childnodecount = (SELECT Count(*) FROM matCategoryList WHERE ParentCategoryID = D.ItemCategoryID) " +
                "FROM matCategoryList D WHERE ParentCategoryID = 1", myConnection);
                var da = new SqlDataAdapter(command);
                var dt = new DataTable();
                da.Fill(dt);
                PopulateNodes(dt, TreeViewCategory.Nodes);
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var tn = new TreeNode(dr["CategoryName"].ToString(), dr["ItemCategoryID"].ToString());
                    nodes.Add(tn);
                    tn.PopulateOnDemand = (int.Parse(dr["childnodecount"].ToString()) > 0);
                }

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void PopulateSubLevel(int parentid, TreeNode parentNode)
        {
            try
            {
                var myConnection = new SqlConnection(_connectionString);
                var objCommand = new SqlCommand(@"select ItemCategoryID,CategoryName
                                                    ,
                                                    (select count(*) FROM matCategoryList
                                                    WHERE ParentCategoryID=e.ItemCategoryID)+
                                                    (select count(*) FROM matMaterialSetup
                                                    WHERE matMaterialSetup.ItemCategoryID=e.ItemCategoryID) AS childnodecount 
                                                    FROM matCategoryList e 
                                                    where ParentCategoryID=@ParentCategoryID
                                                    UNION
                                                    select ItemID AS ItemCategoryID ,ModelNo AS CategoryName,0 AS childnodecount FROM matMaterialSetup D where D.ItemCategoryID=@ParentCategoryID", myConnection);

                objCommand.Parameters.Add("@ParentCategoryID", SqlDbType.Int).Value = parentid;
                var da = new SqlDataAdapter(objCommand);
                var dt = new DataTable();
                da.Fill(dt);
                PopulateNodes(dt, parentNode.ChildNodes);
                TreeViewCategory.CollapseAll();

            }
            catch (Exception msgException)
            {
                throw msgException;
            }
        }

        public int CreateCategoryID()
        {
            string categoryID;
            int parentCategoryID = ddlParentCategory.SelectedValue == "-1" ? 1 : Convert.ToInt32(ddlParentCategory.SelectedValue);
            categoryID = Session["company"].ToString() + Session["branch"].ToString() + GetTierNo(parentCategoryID) + GetSeqNo(parentCategoryID);
            return Convert.ToInt32(categoryID);

        }
        private int GetTierNo(int parentAccNo)
        {
            try
            {
                var storedProcedureComandTest = "exec [spGetTierNumber] " + parentAccNo + "";
                var dtTierNo = StoredProcedureExecutor.StoredProcedureExecuteReader(_connectionString, storedProcedureComandTest);
                int tierNumber = Convert.ToInt32(dtTierNo.Rows[0][0].ToString());
                Session["tierNumber"] = tierNumber;
                return tierNumber;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private string GetSeqNo(int parentAccount)
        {
            try
            {
                var storedProcedureComandTest = "exec [spGetNodeSeqNo] " + parentAccount + " ";
                var dtSeqNo = StoredProcedureExecutor.StoredProcedureExecuteReader(_connectionString, storedProcedureComandTest);
                var sequenceNumberFixedDigit = dtSeqNo.Rows[0][0].ToString();
                int sequenceNumber = Convert.ToInt32(sequenceNumberFixedDigit);
                Session["sequenceNumber"] = sequenceNumber;
                return sequenceNumberFixedDigit;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
        protected void CheckBoxAddItem_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBoxAddItem.Checked == true)
            {
                try
                {
                    PanelBody.Visible = false;
                    PanelItemSetup.Visible = true;
                    PanelLeft.Visible = false;
                    PanelRight.Visible = false;
                    txtItemCode.Focus();
                    ItemTypeSetupController objItemTypeSetupController = new ItemTypeSetupController();
                    _objCompanySetup = new CompanySetup();
                    _objCompanySetup.CompanyID = Convert.ToInt32(Session["company"].ToString());
                    _objBranchSetup = new BranchSetup();
                    _objBranchSetup.BranchID = Convert.ToInt32(Session["branch"].ToString());
                    ClsDropDownListController.LoadDropDownList(_connectionString, objItemTypeSetupController.ItemTypeSql(_objCompanySetup, _objBranchSetup), ddlItemTypeID, "ItemType", "ItemTypeID");
                    UnitSetupController objUnitSetupController = new UnitSetupController();
                    ClsDropDownListController.LoadDropDownList(_connectionString, objUnitSetupController.UnitSql(_objCompanySetup, _objBranchSetup), ddlUnit, "Unit", "UnitID");
                    ItemUsageSetupController objItemUsageSetupController = new ItemUsageSetupController();
                    ClsDropDownListController.LoadDropDownList(_connectionString, objItemUsageSetupController.ItemUsageSql(_objCompanySetup, _objBranchSetup), ddlItemUsageID, "ItemUsage", "ItemUsageID");

                }
                catch (Exception msgException)
                {

                    TopMostMessageBox.Show(msgException.Message);
                }

            }
            else
            {
                PanelBody.Visible = true;
                PanelLeft.Visible = true;
                PanelRight.Visible = true;
                PanelItemSetup.Visible = false;

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TopMostMessageBox.MsgConfirmBox(btnSave, "Are you sure ?");
            try
            {
                if (CheckBoxAddItem.Checked == true)
                {
                    SaveItem();

                }
                else
                {
                    AddValuesToCategory();

                }

            }
            catch (Exception msgException)
            {
                TopMostMessageBox.Show1(@"fdddddfghffffffffffffffffffffffffffffffffffffffffffffgfhhh                                                ffffffffffffffffffffffffffffffffhghfhghg
                                                                    hjhhkjk", "Exception");
                
                
                
            }

        }

        private void SaveItem()
        {
            try
            {
                _objItemSetup = new ItemSetup();
                _objItemSetup.ItemCategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                _objItemSetup.Specification = txtDescription.Text == string.Empty ? null : txtDescription.Text;
                _objItemSetup.HsCode = txtHSCode.Text == string.Empty ? null : txtHSCode.Text;
                _objItemSetup.IsVATAbleItem = CheckBoxIsVATPayable.Checked == true ? true : false;
                _objItemSetup.SupplierID = ddlRelatedSupplier.SelectedValue == "-1" ? null : ddlRelatedSupplier.SelectedValue;
                _objItemSetup.OpenningBalance = txtOpeningBalance.Text == string.Empty ? 0 : Convert.ToInt32(txtOpeningBalance.Text);
                _objItemSetup.CoaSalesAccNo = 1;//Convert.ToInt32(ddlSalesAccountNo.SelectedValue);
                _objItemSetup.CoaStockAccNo = 1;//Convert.ToInt32(ddlStockAccountNo.SelectedValue);
                _objItemSetup.CoacgsAccNo = 1;//Convert.ToInt32(ddlCOGSAccountNo.SelectedValue);
                _objItemSetup.CoaSalesRetAccNo = 1;//Convert.ToInt32(ddlSalesReturnAccount.SelectedValue);
                _objItemSetup.EntryUserName = Session["entryUserCode"].ToString();
                _objItemSetup.ItemID = Convert.ToInt32(Session["company"].ToString() + Session["branch"].ToString());
                _objItemSetup.ModelNo = txtItemName.Text == string.Empty ? null : txtItemName.Text;
                _objItemSetup.UnitID = Convert.ToInt32(ddlUnit.SelectedValue);
                _objItemSetup.ItemCode = txtItemCode.Text == string.Empty ? null : txtItemCode.Text;
                _objItemSetup.ItemTypeID = Convert.ToInt32(ddlItemTypeID.SelectedValue);
                _objItemSetup.ItemPropertySetID = 1;
                _objItemSetup.ItemUsageID = Convert.ToInt32(ddlItemUsageID.SelectedValue);
                _objItemSetupController = new ItemSetupController();

                _objItemCategorySetup = new ItemCategorySetup();
                _objItemCategorySetup.CompanyID = Convert.ToInt32(Session["company"].ToString());
                _objItemCategorySetup.BranchID = Convert.ToInt32(Session["branch"].ToString());
                _objItemCategorySetup.CategoryTypeID = Convert.ToInt32(ddlProductType.SelectedValue);
                _objItemCategorySetup.ItemCategoryID = CreateCategoryID();
                _objItemCategorySetup.CategoryName = _objItemSetup.ItemCode = txtItemCode.Text;
                _objItemCategorySetup.ParentCategoryID = ddlParentCategory.SelectedValue == "-1" ? 1 : Convert.ToInt32(ddlParentCategory.SelectedValue);
                _objItemCategorySetup.StartingItemCode = 0;
                _objItemCategorySetup.EndingItemCode = 0;
                _objItemCategorySetup.SeqNo = Convert.ToInt32(Session["sequenceNumber"].ToString());
                _objItemCategorySetup.TierNo = Convert.ToInt32(Session["tierNumber"].ToString());
                _objItemCategorySetup.CurrentBalance = 0;
                _objItemCategorySetup.DataUsed = "A";
                _objItemCategorySetup.EntryUserName = Session["entryUserCode"].ToString();

                _objItemSetupController.Save(_connectionString, _objItemSetup, _objItemCategorySetup);
                ClearItemInformation();
                TreeViewCategory.Nodes.Clear();
                PopulateRootLevel();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ClearItemInformation()
        {
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            ddlItemTypeID.SelectedValue = "-1";
            ddlItemUsageID.SelectedValue = "-1";
            ddlUnit.SelectedValue = "-1";
            CheckBoxIsVATPayable.Checked = false;
            txtDescription.Text = string.Empty;
            txtHSCode.Text = string.Empty;
            txtOpeningBalance.Text = string.Empty;
            txtReOrderLevel.Text = string.Empty;
        }

        private void AddValuesToCategory()
        {
            try
            {
                _objItemCategorySetup = new ItemCategorySetup();
                _objItemCategorySetup.CompanyID = Convert.ToInt32(Session["company"].ToString());
                _objItemCategorySetup.BranchID = Convert.ToInt32(Session["branch"].ToString());
                _objItemCategorySetup.CategoryTypeID = Convert.ToInt32(ddlProductType.SelectedValue);
                _objItemCategorySetup.ItemCategoryID = CreateCategoryID();
                _objItemCategorySetup.CategoryName = txtCategoryName.Text == string.Empty ? null : txtCategoryName.Text;
                _objItemCategorySetup.ParentCategoryID = ddlParentCategory.SelectedValue == "-1" ? 1 : Convert.ToInt32(ddlParentCategory.SelectedValue);
                _objItemCategorySetup.StartingItemCode = 0;
                _objItemCategorySetup.EndingItemCode = 0;
                _objItemCategorySetup.SeqNo = Convert.ToInt32(Session["sequenceNumber"].ToString());
                _objItemCategorySetup.TierNo = Convert.ToInt32(Session["tierNumber"].ToString());
                _objItemCategorySetup.CurrentBalance = 0;
                _objItemCategorySetup.DataUsed = "A";
                _objItemCategorySetup.EntryUserName = Session["entryUserCode"].ToString();
                _objItemCategorySetupController = new ItemCategorySetupController();
                _objItemCategorySetupController.Save(_connectionString, _objItemCategorySetup);
                ClearCategory();
                TreeViewCategory.Nodes.Clear();
                PopulateRootLevel();
                LoadCategory(ddlCategory);
                LoadCategory(ddlParentCategory);

            }
            catch (SqlException msgException)
            {
                throw msgException;
            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ClearCategory()
        {
            txtCategoryName.Text = string.Empty;
        }

        protected void TreeViewCategory_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
            TreeViewCategory.ExpandAll();
        }

        protected void TreeViewCategory_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                _objItemCategorySetup = new ItemCategorySetup();
                _objItemCategorySetup.ItemCategoryID = Convert.ToInt32(TreeViewCategory.SelectedNode.Value);

                var parentID = TreeViewCategory.SelectedNode.Parent == null ? _objItemCategorySetup.ItemCategoryID : Convert.ToInt32(TreeViewCategory.SelectedNode.Parent.Value);
                var childID = 0;
                if (TreeViewCategory.SelectedNode.ChildNodes.Count > 0)
                {
                    childID = Convert.ToInt32( TreeViewCategory.SelectedNode.ChildNodes[0].Value.ToString());

                }




                int countIDDigit = Convert.ToInt32(_objItemCategorySetup.ItemCategoryID.ToString().Length.ToString());
                int countChildIDDigit = Convert.ToInt32(childID.ToString().Length.ToString());
                if (countIDDigit == 9)
                {
                    ddlParentCategory.SelectedValue = _objItemCategorySetup.ItemCategoryID.ToString();
                    ddlCategory.SelectedValue = _objItemCategorySetup.ItemCategoryID.ToString();
                    CheckBoxAddItem.Enabled = true;
                    txtCategoryName.Focus();
                    txtCategoryName.Enabled = true;
                    if (countChildIDDigit == 8)
                    {
                        txtCategoryName.Enabled = false;
                    }
                }
                else
                {
                    ddlParentCategory.SelectedValue = parentID.ToString();
                    ddlCategory.SelectedValue = parentID.ToString();
                    txtCategoryName.Enabled = false;
                    CheckBoxAddItem.Enabled = false;

                }

            }
            catch (Exception msgException)
            {

                TopMostMessageBox.Show(msgException.Message);
            }
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string valueForSearch = txtSearch.Text == string.Empty ? null : txtSearch.Text;
                TreeViewCategory.ExpandAll();
                if (valueForSearch != null)
                {
                    foreach (TreeNode t in TreeViewCategory.Nodes)
                    {
                        if (t.Text.ToUpper() == valueForSearch.ToUpper())
                        {
                            t.Text = "<div style='color:orange;hight:20px'>" + t.Text + "</div>";
                            

                        }
                        for (int iParent = 0; iParent < t.ChildNodes.Count; iParent++)
                        {
                            if (t.ChildNodes[iParent].Text.ToUpper() == valueForSearch.ToUpper())
                            {
                                t.ChildNodes[iParent].Text = "<div style='color:orange;hight:20px'>" + t.ChildNodes[iParent].Text + "</div>";


                            }
                            for (int iChild = 0; iChild < t.ChildNodes[iParent].ChildNodes.Count; iChild++)
                            {
                                if (t.ChildNodes[iParent].ChildNodes[iChild].Text.ToUpper() == valueForSearch.ToUpper())
                                {
                                    t.ChildNodes[iParent].ChildNodes[iChild].Text = "<div style='color:orange;hight:20px'>" + t.ChildNodes[iParent].ChildNodes[iChild].Text + "</div>";

                                }
                            }
                        }
                    }
                }

            }
            catch (Exception msgException)
            {

                TopMostMessageBox.Show(msgException.Message);
            }
        }
    }
}