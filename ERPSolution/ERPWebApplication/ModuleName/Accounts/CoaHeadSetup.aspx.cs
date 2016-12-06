using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPWebApplication.AppClass.CommonClass;
using System.Data;
using ERPWebApplication.CommonClass;
using System.Data.SqlClient;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.DataAccess;


namespace ERPWebApplication.ModuleName.Accounts
{
    public partial class CoaHeadSetup : System.Web.UI.Page
    {
        readonly String _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    PopulateRootLevel();
                    LoadParentAccountDdl();
                    Session["company"] = 1;
                    Session["branch"] = 1;
                    Session["entryUserCode"] = "ADM";
                    PanelAnalysisRequired.Visible = false;
                    txtSubledgerTypeID_AutoCompleteExtender.ContextKey = _connectionString;
                    txtSubledgerTypeID0_AutoCompleteExtender.ContextKey = _connectionString;
                    txtSubledgerTypeID1_AutoCompleteExtender.ContextKey = _connectionString;
                    txtSubledgerTypeID2_AutoCompleteExtender.ContextKey = _connectionString;
                    txtSubledgerTypeID3_AutoCompleteExtender.ContextKey = _connectionString;
                    clsTopMostMessageBox.MsgConfirmBox(btnSave, clsMessages.GConfirmMessage);
                    clsTopMostMessageBox.MsgConfirmBox(btnUpdate, clsMessages.GConfirmMessage);
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    btnCancelAdd.Visible = false;
                    btnCancelEdit.Visible = false;
                }

            }
            catch (Exception msgException)
            {

                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        private int GetSeqNo()
        {
            try
            {
                var storedProcedureComandTest = "exec [spGetSeqNo] ";
                var dtSeqNo = clsDataManipulation.GetData(_connectionString, storedProcedureComandTest);
                return Convert.ToInt32(dtSeqNo.Rows[0][0].ToString());

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetSeqNo(int parentAccount)
        {
            try
            {
                var storedProcedureComandTest = "exec [spGetNodeSeqNoCOA] " + parentAccount + " ";
                var dtSeqNo = clsDataManipulation.GetData(_connectionString, storedProcedureComandTest);
                int sequenceNumber = Convert.ToInt32(dtSeqNo.Rows[0][0].ToString());
                Session["sequenceNumber"] = sequenceNumber;
                return sequenceNumber;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private int GetTierNo(int parentAccNo)
        {
            try
            {
                var storedProcedureComandTest = "exec [spGetTierNumberCOA] " + parentAccNo + "";
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

        private int CreateAccountNumber()
        {
            try
            {
                string accountNumber;
                int parentAccountNumber = Convert.ToInt32(ddlParentAccountNo.SelectedValue == "-1" ? null : ddlParentAccountNo.SelectedValue);
                accountNumber = Session["company"].ToString() + Session["branch"].ToString() + rblAccountType.SelectedValue + GetSeqNo(parentAccountNumber) + GetTierNo(Convert.ToInt32(ddlParentAccountNo.SelectedValue)) + GetSeqNo() + GetSeqNo();
                return Convert.ToInt32(accountNumber);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void InitiateCoaHead()
        {
            try
            {
                int parentAccountNumber = Convert.ToInt32(ddlParentAccountNo.SelectedValue == "-1" ? null : ddlParentAccountNo.SelectedValue);
                var objCoaHead = new CoaHead
                {
                    ParentAccNo = parentAccountNumber,
                    AccountName = txtAccountHead.Text,
                    AccountTypeId = Convert.ToInt32(ddlAccountType.SelectedValue),
                    AccountDescription = txtAccountDescription.Text,
                    AccountNo = CreateAccountNumber(),
                    SeqNo = Convert.ToInt32(Session["sequenceNumber"].ToString()),
                    TierNo = Convert.ToInt32(Session["tierNumber"].ToString()),
                    SerialNo = GetSeqNo(),
                    EntryUserId = Session["entryUserCode"].ToString(),

                    CompanyID = Convert.ToInt32(Session["company"].ToString()),
                    BranchID = Convert.ToInt32(Session["branch"].ToString()),
                    IsBudgetRelated = CheckBoxIsBudgetRelated.Checked == true ? 1 : 0,
                    AnalysisRequired = CheckBoxAnalysisRequired.Checked == true ? "Y" : "N"
                };

                objCoaHead.DtSubledgerInformation = new DataTable();
                DataRow dr;
                objCoaHead.DtSubledgerInformation.Columns.Add(new DataColumn("SubledgerTypeID", typeof(String)));
                objCoaHead.DtSubledgerInformation.Columns.Add(new DataColumn("SubLedgerID", typeof(String)));

                var objCoaHeadController = new CoaHeadController();

                for (int subLedgerCount = 1; subLedgerCount < 6; subLedgerCount++)
                {
                    string subLedger = null;
                    if (subLedgerCount == 1)
                    {
                        subLedger = txtSubledgerTypeID.Text == string.Empty ? null : txtSubledgerTypeID.Text;
                    }
                    else if (subLedgerCount == 2)
                    {
                        subLedger = txtSubledgerTypeID0.Text == string.Empty ? null : txtSubledgerTypeID0.Text;
                    }
                    else if (subLedgerCount == 3)
                    {
                        subLedger = txtSubledgerTypeID1.Text == string.Empty ? null : txtSubledgerTypeID1.Text;

                    }
                    else if (subLedgerCount == 4)
                    {
                        subLedger = txtSubledgerTypeID2.Text == string.Empty ? null : txtSubledgerTypeID2.Text;

                    }
                    else
                    {
                        subLedger = txtSubledgerTypeID3.Text == string.Empty ? null : txtSubledgerTypeID3.Text;
                    }


                    if (subLedger != null)
                    {
                        var dtCheckSubLedgerInfo = objCoaHeadController.GetSubLedgerInformation(_connectionString, subLedger);
                        foreach (DataRow rowNo in dtCheckSubLedgerInfo.Rows)
                        {
                            dr = objCoaHead.DtSubledgerInformation.NewRow();
                            dr[0] = rowNo.ItemArray[0].ToString();
                            dr[1] = rowNo.ItemArray[1].ToString();
                            objCoaHead.DtSubledgerInformation.Rows.Add(dr);
                        }
                    }

                }

                objCoaHeadController.Save(_connectionString, objCoaHead);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void LoadParentAccountDdl()
        {
            try
            {
                const string sqlQuery = "SELECT [AccountNo],[AccountName]FROM [accCOAHeadSetup] ORDER BY [AccountNo]";
                ClsDropDownListController.LoadDropDownList(_connectionString, sqlQuery, ddlParentAccountNo, "AccountName", "AccountNo");
                if (treeCOAHead.Nodes.Count > 0)
                {
                    ddlParentAccountNo.Items.RemoveAt(0);
                }
                else
                {
                    ddlParentAccountNo.Items.RemoveAt(0);
                    ddlParentAccountNo.Items.Insert(0, new ListItem("--- No Data Found ---", "-1"));
                    ddlParentAccountNo.SelectedIndex = 0;
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
                var command = new SqlCommand("SELECT AccountNo,AccountName," +
                "childnodecount = (SELECT Count(*) FROM accCOAHeadSetup WHERE ParentAccNo = D.AccountNo) " +
                "FROM accCOAHeadSetup D WHERE ParentAccNo IS NULL", myConnection);
                var da = new SqlDataAdapter(command);
                var dt = new DataTable();
                da.Fill(dt);
                PopulateNodes(dt, treeCOAHead.Nodes);

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
                    var tn = new TreeNode(dr["AccountName"].ToString(), dr["AccountNo"].ToString());
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
                var objCommand = new SqlCommand(@"select AccountNo,AccountName,(select count(*) FROM accCOAHeadSetup WHERE ParentAccNo=e.AccountNo) childnodecount FROM accCOAHeadSetup e where ParentAccNo=@ParentAccNo", myConnection);
                objCommand.Parameters.Add("@ParentAccNo", SqlDbType.Int).Value = parentid;
                var da = new SqlDataAdapter(objCommand);
                var dt = new DataTable();
                da.Fill(dt);
                PopulateNodes(dt, parentNode.ChildNodes);
                treeCOAHead.CollapseAll();

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private void ClearAllControl()
        {
            txtAccountHead.Text = "";
            txtAccountDescription.Text = "";
            CheckBoxAnalysisRequired.Checked = false;
            CheckBoxIsBudgetRelated.Checked = false;
            txtSubledgerTypeID.Text = string.Empty;
            txtSubledgerTypeID0.Text = string.Empty;
            txtSubledgerTypeID1.Text = string.Empty;
            txtSubledgerTypeID2.Text = string.Empty;
            txtSubledgerTypeID3.Text = string.Empty;
            PanelAnalysisRequired.Visible = false;
        }

        private string CheckVaidation()
        {
            const string checkValidation = "";
            if (txtAccountHead.Text == "")
            {
                txtAccountHead.Focus();
                return "Must Enter Account Head !";
            }
            return checkValidation;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var validationMsg = CheckVaidation();
            switch (validationMsg)
            {
                case "":
                    try
                    {
                        InitiateCoaHead();
                        treeCOAHead.Nodes.Clear();
                        PopulateRootLevel();
                        LoadParentAccountDdl();
                        ClearAllControl();

                    }
                    catch (Exception msgException)
                    {

                        clsTopMostMessageBox.Show(msgException.Message);
                    }
                    break;
                default:
                    clsTopMostMessageBox.Show(validationMsg);
                    break;
            }
        }
        protected void treeCOAHead_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateSubLevel(Int32.Parse(e.Node.Value), e.Node);
        }
        protected void treeCOAHead_SelectedNodeChanged(object sender, EventArgs e)
        {
            int accountNo = Convert.ToInt32(treeCOAHead.SelectedNode.Value);
            string accountNoConcate = "WHERE AccountNo = " + treeCOAHead.SelectedNode.Value + "";
            string accountTypeId = clsDataManipulation.GetSingleValueFromtable(_connectionString, "accCOAHeadSetup", "AccountTypeID", accountNoConcate);
            rblAccountType.SelectedValue = accountTypeId;
            ddlAccountType.SelectedValue = accountTypeId;
            ddlParentAccountNo.SelectedValue = accountNo.ToString();
            txtAccountHead.Focus();
            ddlAccountType.Enabled = false;
            TreeNode treeSelectedNode = treeCOAHead.SelectedNode;
            treeCOAHead.SelectedNodeStyle.BackColor = System.Drawing.Color.Gray;
            treeSelectedNode.Expand();
            while (treeSelectedNode.Parent != null)
            {
                treeSelectedNode = treeSelectedNode.Parent;
                treeSelectedNode.Expand();
            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var accountNo = ddlParentAccountNo.SelectedValue;
            var queryString = "DELETE FROM accCOAHeadSetup WHERE AccountNo = '" + accountNo + "' OR ParentAccNo = '" + accountNo + "'";
            var msg = clsDataManipulation.DeleteQueryWithMessage(_connectionString, queryString);
            treeCOAHead.Nodes.Clear();
            PopulateRootLevel();
            LoadParentAccountDdl();
            ScriptManager.RegisterStartupScript(
                        this,
                        GetType(),
                        "MessageBox",
                        "alert(' " + msg + " ');",
                        true);
        }
        

        protected void rblAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeCOAHead.Nodes.Clear();
            PopulateRootLevel();
            LoadParentAccountDdl();
            ddlAccountType.SelectedValue = rblAccountType.SelectedValue;
        }
        protected void ddlParentAccountNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBoxAnalysisRequired_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckBoxAnalysisRequired.Checked == true)
            {
                PanelAnalysisRequired.Visible = true;
            }
            else
            {
                PanelAnalysisRequired.Visible = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var validationMsg = CheckVaidation();
            switch (validationMsg)
            {
                case "":
                    try
                    {
                        UpdateCoaHead();
                        treeCOAHead.Nodes.Clear();
                        PopulateRootLevel();
                        LoadParentAccountDdl();
                        ClearAllControl();

                    }
                    catch (Exception msgException)
                    {

                        clsTopMostMessageBox.Show(msgException.Message);
                    }
                    break;
                default:
                    clsTopMostMessageBox.Show(validationMsg);
                    break;
            }

        }

        private void UpdateCoaHead()
        {
            try
            {
                int parentAccountNumber = Convert.ToInt32(ddlParentAccountNo.SelectedValue == "-1" ? null : ddlParentAccountNo.SelectedValue);
                var objCoaHead = new CoaHead
                {
                    AccountName = txtAccountHead.Text,
                    AccountTypeId = Convert.ToInt32(ddlAccountType.SelectedValue),
                    AccountDescription = txtAccountDescription.Text,
                    AccountNo = parentAccountNumber,
                    EntryUserId = Session["entryUserCode"].ToString(),

                    CompanyID = Convert.ToInt32(Session["company"].ToString()),
                    BranchID = Convert.ToInt32(Session["branch"].ToString()),
                    IsBudgetRelated = CheckBoxIsBudgetRelated.Checked == true ? 1 : 0,
                    AnalysisRequired = CheckBoxAnalysisRequired.Checked == true ? "Y" : "N"
                };

                objCoaHead.DtSubledgerInformation = new DataTable();
                DataRow dr;
                objCoaHead.DtSubledgerInformation.Columns.Add(new DataColumn("SubledgerTypeID", typeof(String)));
                objCoaHead.DtSubledgerInformation.Columns.Add(new DataColumn("SubLedgerID", typeof(String)));

                var objCoaHeadController = new CoaHeadController();

                for (int subLedgerCount = 1; subLedgerCount < 6; subLedgerCount++)
                {
                    string subLedger = null;
                    if (subLedgerCount == 1)
                    {
                        subLedger = txtSubledgerTypeID.Text == string.Empty ? null : txtSubledgerTypeID.Text;
                    }
                    else if (subLedgerCount == 2)
                    {
                        subLedger = txtSubledgerTypeID0.Text == string.Empty ? null : txtSubledgerTypeID0.Text;
                    }
                    else if (subLedgerCount == 3)
                    {
                        subLedger = txtSubledgerTypeID1.Text == string.Empty ? null : txtSubledgerTypeID1.Text;

                    }
                    else if (subLedgerCount == 4)
                    {
                        subLedger = txtSubledgerTypeID2.Text == string.Empty ? null : txtSubledgerTypeID2.Text;

                    }
                    else
                    {
                        subLedger = txtSubledgerTypeID3.Text == string.Empty ? null : txtSubledgerTypeID3.Text;
                    }


                    if (subLedger != null)
                    {
                        var dtCheckSubLedgerInfo = objCoaHeadController.GetSubLedgerInformation(_connectionString, subLedger);
                        foreach (DataRow rowNo in dtCheckSubLedgerInfo.Rows)
                        {
                            dr = objCoaHead.DtSubledgerInformation.NewRow();
                            dr[0] = rowNo.ItemArray[0].ToString();
                            dr[1] = rowNo.ItemArray[1].ToString();
                            objCoaHead.DtSubledgerInformation.Rows.Add(dr);
                        }
                    }

                }

                objCoaHeadController.Update(_connectionString, objCoaHead);

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnCancelAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancelEdit.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnCancelAdd.Visible = false;
            btnUpdate.Visible = true;
            btnCancelEdit.Visible = true;
        }

        protected void btnCancelAdd_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnCancelAdd.Visible = false;
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnCancelEdit.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string valueForSearch = txtSearch.Text == string.Empty ? null : txtSearch.Text;
                treeCOAHead.ExpandAll();
                if (valueForSearch != null)
                {
                    foreach (TreeNode t in treeCOAHead.Nodes)
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


    }
}