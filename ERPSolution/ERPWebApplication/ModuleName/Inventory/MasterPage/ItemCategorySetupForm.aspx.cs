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
using ERPWebApplication.AppClass;

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
                    clsTopMostMessageBox.MsgConfirmBox(btnSave, clsMessages.GConfirmMessage);
                    txtSearch_AutoCompleteExtender.ContextKey = _connectionString;
                    PanelItemDetails.Visible = false;
                    btnUpdate.Visible = false;
                    clsTopMostMessageBox.MsgConfirmBox(btnUpdate, clsMessages.GConfirmMessage);
                }


            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
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
                "FROM matCategoryList D WHERE ParentCategoryID = 111", myConnection);
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
                var dtTierNo = clsDataManipulation.GetData(_connectionString, storedProcedureComandTest);
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
                var dtSeqNo = clsDataManipulation.GetData(_connectionString, storedProcedureComandTest);
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
                    LoadDropDownListData(ddlItemTypeID, ddlUnit, ddlBreakupUnit, ddlItemUsageID, ddlRelatedSupplier, ddlSalesAccountNo, ddlStockAccountNo, ddlCOGSAccountNo, ddlSalesReturnAccount);

                }
                catch (Exception msgException)
                {

                    clsTopMostMessageBox.Show(msgException.Message);
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

        private void LoadDropDownListData(DropDownList targetDDLItemTypeID, DropDownList targetDDLUnit, DropDownList targetDDBreakupUnit, DropDownList targetDDItemUsageID,
            DropDownList targetDDRelatedSupplier, DropDownList targetDDSalesAccountNo, DropDownList targetDDStockAccountNo, DropDownList targetDDCOGSAccountNo,
            DropDownList targetDDSalesReturnAccount)
        {
            try
            {
                ItemTypeSetupController objItemTypeSetupController = new ItemTypeSetupController();
                _objCompanySetup = new CompanySetup();
                _objCompanySetup.CompanyID = Convert.ToInt32(Session["company"].ToString());
                _objBranchSetup = new BranchSetup();
                _objBranchSetup.BranchID = Convert.ToInt32(Session["branch"].ToString());
                ClsDropDownListController.LoadDropDownList(_connectionString, objItemTypeSetupController.ItemTypeSql(_objCompanySetup, _objBranchSetup), targetDDLItemTypeID, "ItemType", "ItemTypeID");
                UnitSetupController objUnitSetupController = new UnitSetupController();
                ClsDropDownListController.LoadDropDownList(_connectionString, objUnitSetupController.UnitSql(_objCompanySetup, _objBranchSetup), targetDDLUnit, "Unit", "UnitID");
                ClsDropDownListController.LoadDropDownList(_connectionString, objUnitSetupController.UnitSql(_objCompanySetup, _objBranchSetup), targetDDBreakupUnit, "Unit", "UnitID");
                ItemUsageSetupController objItemUsageSetupController = new ItemUsageSetupController();
                ClsDropDownListController.LoadDropDownList(_connectionString, objItemUsageSetupController.ItemUsageSql(_objCompanySetup, _objBranchSetup), targetDDItemUsageID, "ItemUsage", "ItemUsageID");
                SuppliersController objSuppliersController = new SuppliersController();
                ClsDropDownListController.LoadDropDownList(_connectionString, objSuppliersController.SQLGetAllSuppliers(_objCompanySetup, _objBranchSetup), targetDDRelatedSupplier, "FullName", "ContactID");
                _objItemSetupController = new ItemSetupController();
                _objItemCategorySetup = new ItemCategorySetup();
                _objItemCategorySetup.CompanyID = _objCompanySetup.CompanyID;
                _objItemCategorySetup.BranchID = _objBranchSetup.BranchID;

                _objItemCategorySetup.KnownValueID = Convert.ToInt32(EnumCollections.eTransactionType.eSalesTrans);
                ClsDropDownListController.LoadDropDownList(_connectionString, _objItemSetupController.SQLForAccountType(_objItemCategorySetup), targetDDSalesAccountNo, "AccountName", "AccountNo");
                _objItemCategorySetup.KnownValueID = Convert.ToInt32(EnumCollections.eTransactionType.eStock);
                ClsDropDownListController.LoadDropDownList(_connectionString, _objItemSetupController.SQLForAccountType(_objItemCategorySetup), targetDDStockAccountNo, "AccountName", "AccountNo");
                _objItemCategorySetup.KnownValueID = Convert.ToInt32(EnumCollections.eTransactionType.eCOGS);
                ClsDropDownListController.LoadDropDownList(_connectionString, _objItemSetupController.SQLForAccountType(_objItemCategorySetup), targetDDCOGSAccountNo, "AccountName", "AccountNo");
                _objItemCategorySetup.KnownValueID = Convert.ToInt32(EnumCollections.eTransactionType.eSalesReturn);
                ClsDropDownListController.LoadDropDownList(_connectionString, _objItemSetupController.SQLForAccountType(_objItemCategorySetup), targetDDSalesReturnAccount, "AccountName", "AccountNo");

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
                if (CheckBoxAddItem.Checked == true)
                {
                    SaveItem();
                    clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

                }
                else
                {
                    AddValuesToCategory();
                    clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);

                }

            }
            catch (Exception msgException)
            {
                clsTopMostMessageBox.Show(msgException.Message);



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
                _objItemSetup.CoaSalesAccNo = Convert.ToInt32(ddlSalesAccountNo.SelectedValue);
                _objItemSetup.CoaStockAccNo = Convert.ToInt32(ddlStockAccountNo.SelectedValue);
                _objItemSetup.CoacgsAccNo = Convert.ToInt32(ddlCOGSAccountNo.SelectedValue);
                _objItemSetup.CoaSalesRetAccNo = Convert.ToInt32(ddlSalesReturnAccount.SelectedValue);
                _objItemSetup.EntryUserName = Session["entryUserCode"].ToString();
                _objItemSetup.ItemID = Convert.ToInt32(Session["company"].ToString() + Session["branch"].ToString());
                _objItemSetup.ModelNo = txtItemName.Text == string.Empty ? null : txtItemName.Text;
                _objItemSetup.UnitID = Convert.ToInt32(ddlUnit.SelectedValue);
                _objItemSetup.ItemCode = txtItemCode.Text == string.Empty ? null : txtItemCode.Text;
                _objItemSetup.ItemTypeID = Convert.ToInt32(ddlItemTypeID.SelectedValue);
                _objItemSetup.ItemPropertySetID = 1;
                _objItemSetup.ItemUsageID = Convert.ToInt32(ddlItemUsageID.SelectedValue);
                _objItemSetup.BreakUpQuantity = txtBreakUpQuantity.Text == string.Empty ? 0 : Convert.ToInt32(txtBreakUpQuantity.Text);
                _objItemSetup.ReOrderLevel = txtReOrderLevel.Text == string.Empty ? null : txtReOrderLevel.Text;
                _objItemSetup.BreakUpUnitD = Convert.ToInt32(ddlBreakupUnit.SelectedValue) == -1 ? 0 : Convert.ToInt32(ddlBreakupUnit.SelectedValue);
                _objItemSetup.MinimumQuantity = txtMinimumQuantity.Text == string.Empty ? 0 : Convert.ToInt32(txtMinimumQuantity.Text);
                _objItemSetupController = new ItemSetupController();
                _objItemSetupController.Save(_connectionString, _objItemSetup);
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
            txtBreakUpQuantity.Text = string.Empty;
            ddlBreakupUnit.SelectedValue = "-1";
            txtMinimumQuantity.Text = string.Empty;

            if (CheckBoxSameSupplier.Checked == false)
            {
                ddlRelatedSupplier.SelectedValue = "-1";

            }


            if (CheckBoxSameAccount.Checked == false)
            {
                ddlSalesAccountNo.SelectedValue = "-1";
                ddlStockAccountNo.SelectedValue = "-1";
                ddlCOGSAccountNo.SelectedValue = "-1";
                ddlSalesReturnAccount.SelectedValue = "-1";

            }
        }

        private void ClearAfterUpdate()
        {
            txtItemCodeUpdate.Text = string.Empty;
            txtItemNameUpdate.Text = string.Empty;
            ddlItemTypeIDUpdate.SelectedValue = "-1";
            ddlItemUsageIDUpdate.SelectedValue = "-1";
            ddlUnitUpdate.SelectedValue = "-1";
            CheckBoxIsVATUpdate.Checked = false;
            txtDescriptionUpdate.Text = string.Empty;
            txtHSCodeUpdate.Text = string.Empty;
            txtOpeningBalanceUpdate.Text = string.Empty;
            txtReOrderLevelUpdate.Text = string.Empty;
            txtBreakUpQuantityUpdate.Text = string.Empty;
            ddlBreakupUnitUpdate.SelectedValue = "-1";
            txtMinimumQuantityUpdate.Text = string.Empty;
            ddlRelatedSupplierUpdate.SelectedValue = "-1";
            ddlSalesAccountNoUpdate.SelectedValue = "-1";
            ddlStockAccountNoUpdate.SelectedValue = "-1";
            ddlCOGSAccountNoUpdate.SelectedValue = "-1";
            ddlSalesReturnAccountUpdate.SelectedValue = "-1";
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

                _objItemCategorySetup.ParentCategoryID = ddlParentCategory.SelectedValue == "-1" ? Convert.ToInt32("1" + _objItemCategorySetup.CompanyID.ToString() + _objItemCategorySetup.BranchID.ToString()) :
                    Convert.ToInt32(ddlParentCategory.SelectedValue);
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
                    childID = Convert.ToInt32(TreeViewCategory.SelectedNode.ChildNodes[0].Value.ToString());

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
                    PanelItemDetails.Visible = false;
                    btnUpdate.Visible = false;
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
                    PanelItemDetails.Visible = true;
                    LoadDropDownListData(ddlItemTypeIDUpdate, ddlUnitUpdate, ddlBreakupUnitUpdate, ddlItemUsageIDUpdate, ddlRelatedSupplierUpdate, ddlSalesAccountNoUpdate,
                        ddlStockAccountNoUpdate, ddlCOGSAccountNoUpdate, ddlSalesReturnAccountUpdate);
                    _objItemSetup = new ItemSetup();
                    _objItemSetup.ItemID = Convert.ToInt32(TreeViewCategory.SelectedNode.Value);
                    Session["itemID"] = _objItemSetup.ItemID;
                    ShowItemDetails(_objItemSetup);
                    btnUpdate.Visible = true;

                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void ShowItemDetails(ItemSetup objItemSetup)
        {
            try
            {
                DataTable dtItemDetails = null;
                _objItemSetupController = new ItemSetupController();
                dtItemDetails = _objItemSetupController.GetItemDetails(_connectionString, objItemSetup);
                foreach (DataRow rowNo in dtItemDetails.Rows)
                {
                    txtItemCodeUpdate.Text = rowNo["ItemCode"].ToString();
                    txtItemNameUpdate.Text = rowNo["ModelNo"].ToString();
                    ddlItemTypeIDUpdate.SelectedValue = rowNo["ItemTypeID"].ToString() == null ? "-1" : rowNo["ItemTypeID"].ToString();
                    ddlItemUsageIDUpdate.SelectedValue = rowNo["ItemUsageID"].ToString() == null ? "-1" : rowNo["ItemUsageID"].ToString();
                    ddlRelatedSupplierUpdate.SelectedValue = rowNo["SupplierID"].ToString() == "" ? "-1" : rowNo["SupplierID"].ToString();
                    txtDescriptionUpdate.Text = rowNo["Specification"].ToString();
                    txtHSCodeUpdate.Text = rowNo["HSCode"].ToString();
                    txtOpeningBalanceUpdate.Text = rowNo["OpenningBalance"].ToString();
                    ddlUnitUpdate.SelectedValue = rowNo["UnitID"].ToString() == null ? "-1" : rowNo["UnitID"].ToString();
                    txtBreakUpQuantityUpdate.Text = rowNo["BreakUpQuantity"].ToString();
                    ddlBreakupUnitUpdate.SelectedValue = rowNo["BreakUpUnitID"].ToString() == null ? "-1" : rowNo["BreakUpUnitID"].ToString();
                    txtReOrderLevelUpdate.Text = rowNo["ReOrderLevel"].ToString();
                    txtMinimumQuantityUpdate.Text = rowNo["MinimumBal"].ToString();
                    ddlSalesAccountNoUpdate.SelectedValue = rowNo["COASalesAccNo"].ToString() == null ? "-1" : rowNo["COASalesAccNo"].ToString();
                    ddlStockAccountNoUpdate.SelectedValue = rowNo["COAStockAccNo"].ToString() == null ? "-1" : rowNo["COAStockAccNo"].ToString();
                    ddlCOGSAccountNoUpdate.SelectedValue = rowNo["COACGSAccNo"].ToString() == null ? "-1" : rowNo["COACGSAccNo"].ToString();
                    ddlSalesReturnAccountUpdate.SelectedValue = rowNo["COASalesRetAccNo"].ToString() == null ? "-1" : rowNo["COASalesRetAccNo"].ToString();
                    var vatValue = rowNo["IsVATableItem"].ToString();
                    if (Convert.ToBoolean(vatValue) == true)
                    {
                        CheckBoxIsVATUpdate.Checked = true;

                    }
                    else
                    {
                        CheckBoxIsVATUpdate.Checked = false;
                    }


                }

            }
            catch (Exception msgException)
            {

                throw msgException;
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
                            t.Text = "<div style='color:orange;hight:15px'>" + t.Text + "</div>";

                            t.Selected = true;


                        }
                        for (int iParent = 0; iParent < t.ChildNodes.Count; iParent++)
                        {
                            if (t.ChildNodes[iParent].Text.ToUpper() == valueForSearch.ToUpper())
                            {
                                t.ChildNodes[iParent].Text = "<div style='color:orange;hight:15px'>" + t.ChildNodes[iParent].Text + "</div>";

                                t.ChildNodes[iParent].Selected = true;


                            }
                            for (int iChild = 0; iChild < t.ChildNodes[iParent].ChildNodes.Count; iChild++)
                            {
                                if (t.ChildNodes[iParent].ChildNodes[iChild].Text.ToUpper() == valueForSearch.ToUpper())
                                {
                                    t.ChildNodes[iParent].ChildNodes[iChild].Text = "<div style='color:orange;hight:15px'>" + t.ChildNodes[iParent].ChildNodes[iChild].Text + "</div>";

                                    t.ChildNodes[iParent].ChildNodes[iChild].Selected = true;
                                }
                            }
                        }
                    }
                }

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
                AssignItemValuesForUpdate();
                PanelItemDetails.Visible = false;
                clsTopMostMessageBox.Show(clsMessages.GProcessSuccess);
                btnUpdate.Visible = false;
                TreeViewCategory.ExpandAll();

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private void AssignItemValuesForUpdate()
        {
            try
            {
                _objItemSetup = new ItemSetup();
                _objItemSetup.ItemCategoryID = Convert.ToInt32(ddlParentCategory.SelectedValue);
                _objItemSetup.Specification = txtDescriptionUpdate.Text == string.Empty ? null : txtDescriptionUpdate.Text;
                _objItemSetup.HsCode = txtHSCodeUpdate.Text == string.Empty ? null : txtHSCodeUpdate.Text;
                _objItemSetup.IsVATAbleItem = CheckBoxIsVATUpdate.Checked == true ? true : false;
                _objItemSetup.SupplierID = ddlRelatedSupplierUpdate.SelectedValue == "-1" ? null : ddlRelatedSupplierUpdate.SelectedValue;
                _objItemSetup.OpenningBalance = txtOpeningBalanceUpdate.Text == string.Empty ? 0 : Convert.ToInt32(txtOpeningBalanceUpdate.Text);
                _objItemSetup.CoaSalesAccNo = Convert.ToInt32(ddlSalesAccountNoUpdate.SelectedValue);
                _objItemSetup.CoaStockAccNo = Convert.ToInt32(ddlStockAccountNoUpdate.SelectedValue);
                _objItemSetup.CoacgsAccNo = Convert.ToInt32(ddlCOGSAccountNoUpdate.SelectedValue);
                _objItemSetup.CoaSalesRetAccNo = Convert.ToInt32(ddlSalesReturnAccountUpdate.SelectedValue);
                _objItemSetup.EntryUserName = Session["entryUserCode"].ToString();
                _objItemSetup.ItemID = Convert.ToInt32(Session["itemID"].ToString());//
                _objItemSetup.ModelNo = txtItemNameUpdate.Text == string.Empty ? null : txtItemNameUpdate.Text;
                _objItemSetup.UnitID = Convert.ToInt32(ddlUnitUpdate.SelectedValue);
                _objItemSetup.ItemCode = txtItemCodeUpdate.Text == string.Empty ? null : txtItemCodeUpdate.Text;
                _objItemSetup.ItemTypeID = Convert.ToInt32(ddlItemTypeIDUpdate.SelectedValue);
                _objItemSetup.ItemPropertySetID = 1;
                _objItemSetup.ItemUsageID = Convert.ToInt32(ddlItemUsageIDUpdate.SelectedValue);
                _objItemSetup.BreakUpQuantity = txtBreakUpQuantityUpdate.Text == string.Empty ? 0 : Convert.ToInt32(txtBreakUpQuantityUpdate.Text);
                _objItemSetup.ReOrderLevel = txtReOrderLevelUpdate.Text == string.Empty ? null : txtReOrderLevelUpdate.Text;
                _objItemSetup.BreakUpUnitD = Convert.ToInt32(ddlBreakupUnitUpdate.SelectedValue) == -1 ? 0 : Convert.ToInt32(ddlBreakupUnitUpdate.SelectedValue);
                _objItemSetup.MinimumQuantity = txtMinimumQuantityUpdate.Text == string.Empty ? 0 : Convert.ToInt32(txtMinimumQuantityUpdate.Text);
                _objItemSetupController = new ItemSetupController();
                _objItemSetupController.Update(_connectionString, _objItemSetup);
                ClearAfterUpdate();
                TreeViewCategory.Nodes.Clear();
                PopulateRootLevel();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }
    }
}