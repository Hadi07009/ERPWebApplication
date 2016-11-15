using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using ERPWebApplication.Model;
using System.Data.SqlClient;
using ERPWebApplication.CommonClass;
using CrystalDecisions.Shared;
using System.Web.UI.WebControls;
using System.Collections.Generic;




namespace ERPWebApplication.ModuleName.Inventory.TransactionPage
{
    public partial class frmItemRequisition : System.Web.UI.Page
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        public static ArrayList Files = new ArrayList();
      
        protected void Page_Load(object sender, EventArgs e)
        {
           // ClsStatic.CheckUserAuthentication();

            Session[ClsStatic.link3sessionUserId] = "MOS";
            string userid = Session[ClsStatic.link3sessionUserId].ToString();
         

            if (!IsPostBack)
            {

                //table

                tblattach.Visible = true;

                tbladvsearch.Visible = false;

                tbladvsearchresult.Visible = false;

                tblitemdet.Visible = false;


                //hr 
                searchbottom.Visible = true;
                advsearchbottom.Visible = false;
                headertop.Visible = false;


                //button
                btnPrintRequisition.Enabled = true;


                //tr
                trtest.Visible = false;


                //panel

                pnl.Visible = false;
                pnlBillAttachment.Visible = true;



                //Collapsible

                cpeheader.Collapsed = true;
                cpeheader.ClientState = "true";

                //label

                lblstatus.Text = "";
                lblStatusforlabel.Visible = false;

                //ddl

                //ddlProject.Visible = false;

                //Gridview
                // gdvItemDetail.HeaderRow.Cells[0].Visible = true;
                foreach (GridViewRow gvrow in gdvItemDetail.Rows)
                {
                    gvrow.Cells[0].Enabled = true;

                }



                txtFrmDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtToDate.Text = System.DateTime.Now.AddDays(15).ToString("dd/MM/yyyy");



                txtrequestedDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtDateNeed.Text = System.DateTime.Now.AddDays(15).ToString("dd/MM/yyyy");

                Loaddata();
                GenerateRefNo(_connectionString, "1", "1", "ItemRequisitionHeader", "ItemRequisitionNo", Convert.ToDateTime(txtrequestedDate.Text), 1);
               
            }
        }

        private void GenerateRefNo(string connectionString, string companyID, string branchID, string tableName, string colName,DateTime requisitionDate, int refNoFor)
        {
            DateTime dt = Convert.ToDateTime(requisitionDate);
            string refno;
            refno = string.Format("{0:00}", dt.Month) + "" + string.Format("{0:00}", dt.Year.ToString().Substring(2, 2)) + "-";

            int maxnofromDate = DataProcess.GetMaximumValueFromtableColumn(_connectionString, "ItemRequisitionHeader", requisitionDate.ToString("dd/MM/yyyy"), "ItemRequisitionNo", companyID.ToString(), branchID.ToString());
            refno = refno + string.Format("{0:00}", maxnofromDate);


            DataTable dtrequisitionNo = new DataTable();
            dtrequisitionNo = DataProcess.GetData(_connectionString, SqlGenerateForItemRequisition.GetDataMaxRequisitionIDByDate(Convert.ToDateTime(txtrequestedDate.Text)));


            int maxPart3;

            if(dtrequisitionNo.Rows.Count==1)
            {

                if (dtrequisitionNo.Rows[0]["ItemRequisitionMaxNo"].ToString() == "0".ToString())
                {
                    maxPart3 = Convert.ToInt32(DataProcess.GetMaximumValueFromtableColumn2(_connectionString, "ItemRequisitionHeader", "ItemRequisitionNo", "1", "1"));
                    refno += string.Format("{0:0000}", maxPart3);
                    txtRefNo.Text = refno.ToString();
                }

                else
                {

                    int reqIDPart2, reqIDPart3;

                    string reqID = dtrequisitionNo.Rows[0]["ItemRequisitionMaxNo"].ToString();
                    string month = reqID.Substring(0, 2);
                    string year = reqID.Substring(2, 2);

                    if (dt.Month.ToString() == month && dt.Year.ToString().Substring(2, 2) == year)
                    {
                        reqIDPart2 = Convert.ToInt32(reqID.Substring(5, 2)) + 1;
                        reqIDPart3 = Convert.ToInt32(DataProcess.GetMaximumValueFromtableColumn2(_connectionString, "ItemRequisitionHeader", "ItemRequisitionNo", "1", "1")); ;
                        txtRefNo.Text = dt.Month + "" + string.Format("{0:00}", dt.Year.ToString().Substring(2, 2)) + "-" + string.Format("{0:00}", reqIDPart2) + string.Format("{0:0000}", reqIDPart3);

                    }
                }
                
            }
        }

        private void Loaddata()
        { 

            string sqlForPriority = "SELECT  p.CompanyID, p.BranchID, p.ActivityID, p.PriorityID, p.PriorityName, s.KnownByID, s.ActivityName, s.DataUsed AS Expr4 FROM  PrioritySetupActivityWise AS p INNER JOIN  sysActivitySetup AS s ON p.ActivityID = s.ActivityID WHERE (s.KnownByID = 10)";
            ClsDropDownListController.LoadDropDownList(_connectionString, sqlForPriority, ddlPriority, "PriorityName", "PriorityID");

            string sqlForPurpose = "SELECT ItemUsageID, ItemUsage FROM matMatUsagePurposeSetup";
            ClsDropDownListController.LoadDropDownList(_connectionString, sqlForPurpose, ddlPurpose, "ItemUsage", "ItemUsageID");

            string sqlForProjectID = "SELECT ProjectID , ProjectName , Descriptions , ProjectStatusID FROM pmProjectSetup where ProjectStatusID=1";
            ClsDropDownListController.LoadDropDownList(_connectionString, sqlForProjectID, ddlProject, "ProjectName", "ProjectID");


            string sqlForPersonType = "SELECT     PersonTypeID, PersonType, DataUsed FROM   TypeOfPersonSetup";
            ClsDropDownListController.LoadDropDownList(_connectionString, sqlForPersonType, ddlItemUserType, "PersonType", "PersonTypeID");


            string sqlForRefType = "select KnownByID,ActivityName from sysActivitySetup where KnownByID=10";
            ClsDropDownListController.LoadDropDownList(_connectionString, sqlForRefType, ddlRefType, "ActivityName", "KnownByID");


            //string sqlForUnit = "SELECT     CompanyID, BranchID, UnitTypeID, UnitID, Unit, DataUsed FROM  matUnitSetup";
            //ClsDropDownListController.LoadDropDownList(connectionStringreq, sqlForUnit, ddlUnit, "Unit", "UnitID");


            string sqlForDepartment = "SELECT  CompanyID, BranchID, DepartmentID, DepartmentName, DataUsed FROM oDepartmentSetup";
            ClsDropDownListController.LoadDropDownList(_connectionString, sqlForDepartment, ddlRequestedDept, "DepartmentName", "DepartmentID");



            // For searching ddl


            string sqlForPurposesearch = "SELECT ItemUsageID, ItemUsage FROM matMatUsagePurposeSetup";
            ClsDropDownListController.LoadDropDownList(_connectionString, sqlForPurposesearch, ddlPurposeSearch, "ItemUsage", "ItemUsageID");



            string sqlForPrioritySearch = "SELECT  p.CompanyID, p.BranchID, p.ActivityID, p.PriorityID, p.PriorityName, s.KnownByID, s.ActivityName, s.DataUsed AS Expr4 FROM  PrioritySetupActivityWise AS p INNER JOIN  sysActivitySetup AS s ON p.ActivityID = s.ActivityID WHERE (s.KnownByID = 10)";
            ClsDropDownListController.LoadDropDownList(_connectionString, sqlForPrioritySearch, ddlPrioritySearch, "PriorityName", "PriorityID");


            string sqlForDepartmentSearch = "SELECT  CompanyID, BranchID, DepartmentID, DepartmentName, DataUsed FROM oDepartmentSetup";
            ClsDropDownListController.LoadDropDownList(_connectionString, sqlForDepartmentSearch, ddldepartment, "DepartmentName", "DepartmentID");

        
        }



        protected void btnAdvSearch_Click(object sender, EventArgs e)
        {
            tbladvsearch.Visible = true ;
            searchbottom.Visible = true;
            advsearchbottom.Visible = true;
          

        CollapsiblePanelExtender5.Collapsed = true;
        CollapsiblePanelExtender5.ClientState = "true";

           
        }

        protected void imgbtnadsearch_Click(object sender, ImageClickEventArgs e)
        {
            tbladvsearch.Visible = false ;
            searchbottom.Visible = true  ;
            advsearchbottom.Visible = false ;

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            tbladvsearchresult.Visible = true;          
            advsearchbottom.Visible = true;
            headertop.Visible = true;


            //======================

            DataTable dtadsearch = new DataTable();
            clsRequisitionHeader hdr = new clsRequisitionHeader();

            //hdr.CompanyID = 1;
            //hdr.BranchID = 1;
          


            string  fromdate = Convert.ToDateTime(txtFrmDate.Text).ToString("dd/MMM/yyyy");
            string toDate = Convert.ToDateTime(txtToDate.Text).ToString("dd/MMM/yyyy");


            int item;

            if (txtItemSearch.Text == "")
            {

                item =0;
            }

            else
            {
                item = Convert.ToInt32(txtItemSearch.Text.Split(':')[0].ToString());


            }


            if (ddldepartment.SelectedItem.Value == "-1")
            {

                hdr.RequestedDepartment = "";
            }

            else
            {
                hdr.RequestedDepartment = ddldepartment.SelectedItem.Value;
            
            }

            if (ddlPrioritySearch.SelectedItem.Value == "-1")
            {
                hdr.PriorityID = 0;
            }

            else
            {
                hdr.PriorityID = Convert.ToInt32(ddlPrioritySearch.SelectedItem.Value);

            }

            if (ddlPurposeSearch.SelectedItem.Value == "-1")
            {

                hdr.PurposeID =0;
            }

            else
            {
                hdr.PurposeID = Convert.ToInt32(ddlPurposeSearch.SelectedItem.Value);
            }


            if (txtEmployeeSearch.Text =="")
            {

                hdr.RequisitionBy = "";
            }

            else
            {
                hdr.RequisitionBy = txtEmployeeSearch.Text.Split(':')[0].ToString();
            }

            dtadsearch = DataProcess.GetData(_connectionString, SqlGenerateForItemRequisition.GetDataRequisitionAdvancedSearch(hdr, Convert.ToDateTime(fromdate), Convert.ToDateTime(toDate), item));

            if (dtadsearch.Rows.Count == 0)

            {
                tbladvsearchresult.Visible = false ;
                advsearchbottom.Visible = false ;
                headertop.Visible = false ;
            }

            advsearchbottom.Visible = true;

            loadgrid2(dtadsearch);
        }

        private void loadgrid2(DataTable dtadsearch)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("SL", typeof(Int32));
            dt.Columns.Add("RefNo.", typeof(string));
            dt.Columns.Add("Requisition Date", typeof(string));
            dt.Columns.Add("Requisition By", typeof(string));
            dt.Columns.Add("Department", typeof(string));
            dt.Columns.Add("Priority", typeof(string));

            foreach (DataRow dr in dtadsearch.Rows)
            {


                dt.Rows.Add(dtadsearch.Rows.Count, dr["ItemRequisitionNo"].ToString(), Convert.ToDateTime(dr["RequisitionDate"]).ToShortDateString(), (dr["RequisitionID"] + ":" + dr["RequisitionBy"]).ToString(), dr["DepartmentName"], dr["PriorityName"]);
            }
            gdvSearchResult.DataSource = dt;
            gdvSearchResult.DataBind();
        }

        protected void btnNewReq_Click(object sender, EventArgs e)
        {



            Response.Redirect(Request.Url.AbsoluteUri);

           
           // //Table

           // tbladvsearch.Visible = false;
           // tbladvsearchresult.Visible = false;
         
           // tblitemdet.Visible = false;

           // //panel

           // pnl.Visible = false;

           // //hr 

           // searchbottom.Visible = true;

           // advsearchbottom.Visible = false;
           // headertop.Visible = false;

           // //Collapsible

           // cpeheader.Collapsed = false;
           // cpeheader.ClientState = "false";
           // pnl.Visible = false;


           // CollapsiblePanelExtender5.Collapsed = true;
           // CollapsiblePanelExtender5.ClientState = "true";


           // //griview


           // gdvItemDetail.DataSource = null;
           // gdvItemDetail.DataBind();

           // //Clear control

           // ClearAllItemHeader();
           // ClearAllItemDetail();

           // //Clear All Message Control

           // lblAttachMsg.Text = "";
           // lblMesg.Text = "";
           // lblMesgDet.Text = "";
           // lblMesSearch.Text = "";
            

           // //Header status

           // lblStatusforlabel.Text = "";
           // lblstatus.Text = "";

           // //Clear List Item

           //FileList.Items.Clear();

            
           // btnAttachFile.Visible = true ;
           // btnRemoveFile.Visible = true;
           // txtrequestedDate_TextChanged(null, null);

           // tblitemdetautho.Visible = false;
        }


        private string  CheckCompleteStatus()
        {

            if (txtRefNo.Text != "")
            {

                DataTable dtcount = new DataTable();
                dtcount = DataProcess.GetData(_connectionString, SqlGenerateForItemRequisition.GetDataRequisitionHdr(txtRefNo.Text));

                if (dtcount.Rows.Count > 0)
                {

                    if (Convert.ToInt32(dtcount.Rows[0]["CompletionStatus"]) != 0)
                    {
                        return "Data Already Submitted.";
                    }

                }
 
            }
            return "";
        
        }



        private string CheckEntryDetail()
        {

            if (CheckCompleteStatus() != "")
            {

                CheckCompleteStatus();
            
            }
           

            if (txtItem.Text == "") return "Please Search Item ";
            if (txtQuantity.Text == "") return "Please Enter Quantity ";
           
            //if (txtSpec.Text == "") return "Please Enter Specification ";
            //if (txtBrand.Text == "") return "Please Enter Brand ";
            //if (txtOrigin.Text == "") return "Please Enter Origin";
            if (txtRate.Text == "") return "Please Enter Rate";

            return "";
        
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
        
            tblitemdet.Visible = true;
           
            pnl.Visible = true ;

            if (CheckEntryDetail() != "")
            {

                lblMesgDet.Text = CheckEntryDetail();
                lblMesgDet.ForeColor = System.Drawing.Color.Red;             
                //tblitemdet.Visible = false ;
              
                lblMesgDet.Focus();

                return;

            }


            if (CheckDuplicate() == false)
            {
                lblMesgDet.Text = "Item Already Added";
                lblMesgDet.ForeColor = System.Drawing.Color.Red;
                lblMesgDet.Focus();
                return;                     
            }


            DataTable dt = new DataTable();

            if (ViewState[ClsStatic.link3sessionUserId] != null)
            {
                dt = (DataTable)ViewState[ClsStatic.link3sessionUserId];
            }
            else
            {
                dt.Rows.Clear();
                dt.Columns.Clear();

                dt.Columns.Add("SL", typeof(int));
                dt.Columns.Add("Icode", typeof(string));
                dt.Columns.Add("Item desc", typeof(string));
                dt.Columns.Add("UnitID", typeof(string));
                dt.Columns.Add("UOM", typeof(string ));             
                dt.Columns.Add("Quantity", typeof(decimal ));
                dt.Columns.Add("Rate", typeof(decimal));         
                dt.Columns.Add("Origin", typeof(string ));
                dt.Columns.Add("Specification", typeof(string ));
                dt.Columns.Add("Brand", typeof(string));
               

            }




            dt.Rows.Add(dt.Rows.Count + 1, txtItem.Text.Split(':')[0].Trim(), txtItem.Text.Split(':')[1].Trim(), txtunit.Text.Split(':')[0].ToString(), txtunit.Text.Split(':')[1].ToString(), Convert.ToDecimal(txtQuantity.Text.ToString()), Convert.ToDecimal(txtRate.Text.ToString()), txtOrigin.Text.Replace("&nbsp;", ""), txtSpec.Text.Replace("&nbsp;", ""), txtBrand.Text.Replace("&nbsp;", ""));


            ViewState[ClsStatic.link3sessionUserId] = new DataTable();
            ViewState[ClsStatic.link3sessionUserId] = dt;
            set_grid();
          //  GetTotal();


            if (dt.Rows.Count > 0)
            {
                trtest.Visible = true;
                tblitemdetautho.Visible = true ;
            
            }

            gdvItemDetail.HeaderRow.Cells[0].Visible = true;
            foreach (GridViewRow gvrow in gdvItemDetail.Rows)
            {
                gvrow.Cells[0].Enabled  =true ;

            }

            ClearAllItemDetail();

            if (CheckCompleteStatus() == "")
            {

                btnPost.Visible = false ;

            }

            else
            {

                btnPost.Visible = true;

            }
        }


        private void TotalAmount()
        { 
        double  qty;
            double rate;


            qty = txtQuantity.Text == "" ? 0 : Convert.ToDouble(txtQuantity.Text);
            rate = txtRate.Text == "" ? 0 : Convert.ToDouble(txtRate.Text);
            txtTotal.Text = (qty * rate).ToString();
        
        
        }


        private void GetTotal()
        {

            DataTable dt = new DataTable();
            dt =(DataTable) ViewState[ClsStatic.link3sessionUserId];
            int i = 0;
            double sum = 0;
            double total = 0;

            foreach (DataRow dr in dt.Rows)
            {
                i++;

                  double   quantity = (dr["Quantity"] == "") ? 0 : Convert.ToDouble(dr["Quantity"]);
                  double rate     = (dr["Rate"] == "") ? 0 : Convert.ToDouble(dr["Rate"]);

                  sum = quantity * rate;
                  total += sum;
        
            }
           // txtTotal.Text = total.ToString();
        }




        private void set_grid()
        {


            btnSubmit.Visible = false;
            gdvItemDetail.Visible = false;

            if (ViewState[ClsStatic.link3sessionUserId] != null)
            {
                DataTable dt = new DataTable();
                DataTable dtgrid = new DataTable();
                int cnt = 0;

                dt = (DataTable)ViewState[ClsStatic.link3sessionUserId];

                if (dt.Rows.Count > 0)
                {
                    btnSubmit.Visible = true;
                    gdvItemDetail.Visible = true;

                    dtgrid.Rows.Clear();
                    dtgrid.Columns.Clear();

                    dtgrid.Columns.Add("SL", typeof(int));
                    dtgrid.Columns.Add("Icode", typeof(string));
                    dtgrid.Columns.Add("Item desc", typeof(string));
                    dtgrid.Columns.Add("UnitID", typeof(string));
                    dtgrid.Columns.Add("uom", typeof(string));
                    dtgrid.Columns.Add("Quantity", typeof(decimal));
                    dtgrid.Columns.Add("Rate", typeof(decimal));
                    dtgrid.Columns.Add("Origin", typeof(string));
                    dtgrid.Columns.Add("Specification", typeof(string));
                    dtgrid.Columns.Add("Brand", typeof(string)); 

                    foreach (DataRow dr in dt.Rows)
                    {
                        cnt += 1;
                        dtgrid.Rows.Add(cnt, dr["Icode"].ToString(), dr["Item desc"].ToString(), dr["UnitID"].ToString(), dr["uom"].ToString(), dr["Quantity"].ToString(), dr["Rate"].ToString(), dr["Origin"].ToString(), dr["Specification"].ToString(), dr["Brand"].ToString());
                    }

                    gdvItemDetail.DataSource = dtgrid;
                    gdvItemDetail.DataBind();
                    ViewState[ClsStatic.link3sessionUserId] = dtgrid;

                }

            }
        }



        private void Load_grid_for_adv(string refno)
        {
            tblitemdet.Visible = true;
            DataTable det = new DataTable();
            DataTable dtgrid = new DataTable();

            det = DataProcess.GetData(_connectionString, SqlGenerateForItemRequisition.GetDataRequisitionDet(refno));
            int cnt = 0;
            if (det.Rows.Count > 0)
            {
                pnl.Visible = true;
                dtgrid.Rows.Clear();
                dtgrid.Columns.Clear();

                dtgrid.Columns.Add("SL", typeof(int));
                dtgrid.Columns.Add("Icode", typeof(string));
                dtgrid.Columns.Add("Item desc", typeof(string));
                dtgrid.Columns.Add("UnitID", typeof(string));
                dtgrid.Columns.Add("uom", typeof(string));
                dtgrid.Columns.Add("Quantity", typeof(decimal));
                dtgrid.Columns.Add("Rate", typeof(decimal));
                dtgrid.Columns.Add("Origin", typeof(string));
                dtgrid.Columns.Add("Specification", typeof(string));
                dtgrid.Columns.Add("Brand", typeof(string));

               

                foreach (DataRow row in det.Rows)
                {
                    cnt += 1;
                    dtgrid.Rows.Add(cnt, row["InventoryItemID"].ToString(), row["RequiredItemName"].ToString(), row["UnitID"].ToString(), row["Unit"].ToString(), Convert.ToDecimal(row["RequestedQuantity"]), Convert.ToDecimal(row["PossibleRate"]), row["CountryOfOrigin"].ToString(), row["Specification"].ToString(), row["Brand"].ToString());
                }

                gdvItemDetail.DataSource = dtgrid;
                gdvItemDetail.DataBind();

            }

        }

        private void Load_grid( string requisitionNo)
        {
            tblitemdet.Visible = true;
            DataTable det = new DataTable();
            DataTable dtgrid = new DataTable();

            det = DataProcess.GetData(_connectionString, SqlGenerateForItemRequisition.GetDataRequisitionDet(requisitionNo));
            int cnt = 0;
            if (det.Rows.Count > 0)
            {
                pnl.Visible = true;
                dtgrid.Rows.Clear();
                dtgrid.Columns.Clear();

                dtgrid.Columns.Add("SL", typeof(int));
                dtgrid.Columns.Add("Icode", typeof(string));
                dtgrid.Columns.Add("Item desc", typeof(string));

                dtgrid.Columns.Add("UnitID", typeof(string));
                dtgrid.Columns.Add("uom", typeof(string));
                dtgrid.Columns.Add("Quantity", typeof(decimal));
                dtgrid.Columns.Add("Rate", typeof(decimal));
                dtgrid.Columns.Add("Origin", typeof(string));
                dtgrid.Columns.Add("Specification", typeof(string));
                dtgrid.Columns.Add("Brand", typeof(string));

             

                foreach (DataRow row in det.Rows)
                {
                       cnt += 1;
                       dtgrid.Rows.Add(cnt, row["InventoryItemID"].ToString(), row["RequiredItemName"].ToString(), row["UnitID"].ToString(), row["Unit"].ToString(), Convert.ToDecimal(row["RequestedQuantity"]), Convert.ToDecimal(row["PossibleRate"]), row["CountryOfOrigin"].ToString().Trim(), row["Specification"].ToString().Trim(), row["Brand"].ToString().Trim());
                }

                gdvItemDetail.DataSource = dtgrid;
                gdvItemDetail.DataBind();

                ViewState[ClsStatic.link3sessionUserId] = dtgrid;


            }
        }

        private bool CheckDuplicate()
        {

            DataTable dt = new DataTable();
            dt = (DataTable)ViewState[ClsStatic.link3sessionUserId];

            int itemCode = Convert.ToInt32(txtItem.Text.Split(':')[0]);


            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {

                        if (dr["Icode"].ToString() == itemCode.ToString())
                        {
                            return false;
                        }
                    }
                 
                }
            }
            return true ;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMesgDet.Text = "";
            lblMesg.Text = "";
        
            cpeheader.Collapsed = true;
            cpeheader.ClientState = "true";

            if (txtSearch.Text == "")
            {
                lblMesSearch.Text = "Please enter Requisition No.";
                lblMesSearch.ForeColor = System.Drawing.Color.Red;
                lblMesSearch.Focus();
                return;          
            }

            GetRequisitionInfo(txtSearch.Text.Split(':')[0].Trim());
           // GetTotal();
           // tblauthorization.Visible = true;

            if (CheckCompleteStatus() == "")
            {
                btnPost.Visible = true;
            }

            else
            {
                btnPost.Visible = false;

            }

        }


        private void GetRequisitionInfo(string requisitionNo)
        {

            DataTable hdr = new DataTable();
            trtest.Visible = true;

            hdr = DataProcess.GetData(_connectionString, SqlGenerateForItemRequisition.GetDataRequisitionHdr(requisitionNo));
          
            if (hdr.Rows.Count > 0)
            {

                if (hdr.Rows[0]["CompletionStatus"].ToString() == "1")
                {
                    lblstatus.Text = "This Item Requisition has been Submitted";                  
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                    ClearAllItemHeader();
                    gdvItemDetail.DataSource = null;
                    gdvItemDetail.DataBind();
                    FileList.Items.Clear();
                    trtest.Visible = false;               
                    return;

                }
                else
                {
                    lblstatus.Text = "You Can Modify this Item Requisition";
                    lblstatus.ForeColor = System.Drawing.Color.Blue;
                  
                }

                if (hdr.Rows[0]["ProjectID"].ToString() != "")
                {

                    chkproject.Checked = true;
                    ddlProject.Visible = true;
                    lblStatusforlabel.Visible = true;

                }
                else
                {
                    chkproject.Checked = false;
                }

                if (chkproject.Checked == true)
                {

                    ddlProject.Visible = true;
                    lblStatusforlabel.Visible = true;
                    ddlProject.Text = hdr.Rows[0]["ProjectID"].ToString();
                }
                else
                {
                    ddlProject.Visible = true;
                    lblStatusforlabel.Visible = true;
                }

                txtRequestedBy.Text = hdr.Rows[0]["RequisitionBy"].ToString();
                ddlRequestedDept.Text = hdr.Rows[0]["RequestedDepartmentID"].ToString();
                ddlItemUserType.Text = hdr.Rows[0]["UserType"].ToString();
                txtUserName.Text = hdr.Rows[0]["UserID"].ToString();              
                txtLocAddress.Text = hdr.Rows[0]["LocationAddress"].ToString();
                txtrequestedDate.Text = Convert.ToDateTime(hdr.Rows[0]["RequisitionDate"]).ToShortDateString();
                txtDateNeed.Text = Convert.ToDateTime(hdr.Rows[0]["RequiredDate"]).ToShortDateString();
                ddlPriority.Text = hdr.Rows[0]["PriorityID"].ToString();
                ddlPurpose.Text = hdr.Rows[0]["PurposeID"].ToString();
                ddlRefType.Text = hdr.Rows[0]["ReferenceTypeID"].ToString();
                txtRefNo.Text = hdr.Rows[0]["ReferenceNumber"].ToString();
                txtComments.Text = hdr.Rows[0]["RequisitionComments"].ToString();
            }

            else
            {
                lblMesSearch.Text = "No data found ";
                lblMesSearch.ForeColor = System.Drawing.Color.Red;
                lblMesSearch.Focus();
                return;

            }

            DataTable filedet = new DataTable();
            filedet = DataProcess.GetData(_connectionString, SqlGenerateForItemRequisition.GetDataFileDet(requisitionNo));

            if (filedet.Rows.Count > 0)
            {
                btnAttachFile.Visible = false;
                btnRemoveFile.Visible = false;
                pnlBillAttachment.Visible = true;

                FileList.Items.Clear();

                foreach (DataRow dr in filedet.Rows)
                {
                    Files.Add(dr["OriginalFileName"]);
                    FileList.Items.Add(dr["OriginalFileName"].ToString());

                }

            }

            DataTable detis = new DataTable();
            detis = DataProcess.GetData(_connectionString, SqlGenerateForItemRequisition.GetDataRequisitionDet(requisitionNo));

            if (detis.Rows.Count > 0)
            {

                tblitemdet.Visible = true;
                Load_grid(requisitionNo);

                DataTable dtcount = new DataTable();
                dtcount = DataProcess.GetData(_connectionString, SqlGenerateForItemRequisition.GetDataRequisitionHdr(requisitionNo));
                gdvItemDetail.HeaderRow.Cells[0].Visible = true;

                if (dtcount.Rows.Count > 0)
                {

                  

                    if (Convert.ToInt32(dtcount.Rows[0]["CompletionStatus"]) == 1)
                    {
                      
                        foreach (GridViewRow gvrow in gdvItemDetail.Rows)
                        {
                            gvrow.Cells[0].Enabled = false;

                         

                        }
                    }

                    else

                    {
                        foreach (GridViewRow gvrow in gdvItemDetail.Rows)
                        {
                            gvrow.Cells[0].Enabled = true ;

                        }
                    
                    }

                }

            }
            else
            {
                lblMesSearch.Text = "No detail data found";
                tblitemdet.Visible = false;
                lblMesSearch.ForeColor = System.Drawing.Color.Red;
                lblMesSearch.Focus();
                return;
            }
        
        }

        protected void btnPrintRequisition_Click(object sender, EventArgs e)
        {

            lblMesSearch.Text = "";
            lblAttachMsg.Text = "";
            lblstatus.Text = "";
            lblMesgDet.Text = "";


            ShowReport(txtRefNo.Text);
        }


        private void ShowReport(string requisitionNo)
        {
            if (requisitionNo == "")
            {
                lblMesg.Text = "Please select Requisition";

                lblMesg.ForeColor = System.Drawing.Color.Red;
                lblMesg.Focus();
                return;          
               
            }


            ClsReport rpt = new ClsReport();
            ParameterFields myParams = new ParameterFields();

            rpt.SelectionFormulla = "";
            rpt.SelectionFormulla = "{viewItemRequisition.ItemRequisitionNo}='" + requisitionNo +"'";

            rpt.ParametersFields = myParams;
            rpt.FileName = "~/ModuleName/Inventory/Report/ReportFile/ReportItemRequisition.rpt";
            Session[ClsStatic.sessionReport] = rpt;

            rpt.Pagezoomfactor = 100;
            current.SessionReport = rpt;

          //  Response.Redirect("~/ModuleName/Inventory/Report/ReportForm/ReportViewer.aspx");

            RegisterStartupScript("click", "<script>window.open('../Report/ReportForm/ReportViewer.aspx');</script>");

        
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (checkEntry() != "")
            {
                lblMesg.Text = checkEntry();
                lblMesg.Visible = true;
                lblMesg.ForeColor = System.Drawing.Color.Red;
                lblMesg.Focus();
                return;           
            }


         bool flg=false ;


           DataTable dtcount = new DataTable ();
           dtcount= DataProcess.GetData(_connectionString,SqlGenerateForItemRequisition.GetDataRequisitionHdr(txtRefNo.Text));


           if (dtcount.Rows.Count > 0)
           {



               if (Convert.ToInt32(dtcount.Rows[0]["CompletionStatus"]) == 0)
               {

                   SaveitemDetail();
               }

               else
               {

                   lblMesg.Text = "Data Already Submitted";
               
               }
               return;

           }


            SqlConnection myConnection = new SqlConnection(_connectionString);
            myConnection.Open();
            SqlCommand cmd = myConnection.CreateCommand();
            SqlTransaction myTrans;
            myTrans = myConnection.BeginTransaction("BeginTransaction");

            cmd.Connection = myConnection;
            cmd.Transaction = myTrans;

            try
            {
                clsRequisitionHeader hdr = new clsRequisitionHeader();
                hdr.CompanyID = 1;
                hdr.BranchID = 1;
                hdr.ItemRequisitionNo = txtRefNo.Text;
                hdr.RequisitionBy = txtRequestedBy.Text.Split(':')[0].ToString();
                hdr.RequisitionDate = Convert.ToDateTime(txtrequestedDate.Text);
                hdr.RequiredDate = Convert.ToDateTime(txtDateNeed.Text);
                hdr.RequestedDepartment = ddlRequestedDept.SelectedItem.Value;
                hdr.UserType = Convert.ToInt32(ddlItemUserType.SelectedItem.Value);
                hdr.UserID = txtUserName.Text.Split(':')[0].ToString();
                hdr.LocationOfUse = 0;
                hdr.LocationAddress = txtLocAddress.Text;
                hdr.PriorityID = Convert.ToInt32(ddlPriority.SelectedItem.Value);
                hdr.PurposeID = Convert.ToInt32(ddlPurpose.SelectedItem.Value);
                hdr.ReferenceTypeID = Convert.ToInt32(ddlRefType.SelectedItem.Value);
                hdr.ReferenceNumber = txtRefNo.Text;
                hdr.RequisitionComments = txtComments.Text;
                hdr.CompletionStatus = 0;
                


                if (chkproject.Checked == true)
                {
                    hdr.ProjectID = ddlProject.SelectedItem.Value;               
                }

                else
                {
                    hdr.ProjectID = null;              
                }

                hdr.ProjectID = ddlProject.SelectedItem.Value;
                hdr.RequisitionCurrentStatus = 1;
                hdr.RequisitionComments = txtComments.Text.Trim();

                hdr.EntryDate = System.DateTime.Now;
                hdr.EntryUserID = Guid.NewGuid();
                hdr.ModifiedDate = System.DateTime.Now;
                hdr.ModifiedUserID = Guid.NewGuid();


                if (!DataProcess.ExecuteSqlCommand(cmd, SqlGenerateForItemRequisition.SqlInsert(hdr)))
                {
                    myTrans.Rollback();
                    return; 
                }

                ClsRequisitionDetail dett = new ClsRequisitionDetail();
                List<ClsRequisitionDetail> ItemList = new List<ClsRequisitionDetail>();

                foreach (GridViewRow dr in gdvItemDetail.Rows)
                {
                    ClsRequisitionDetail det = new ClsRequisitionDetail();

                    det.ItemRequisitionNo =txtRefNo.Text;
                    det.InventoryItemID  = Convert.ToInt32(dr.Cells[2].Text.Split(':')[0]);
                    det.RequiredItemName  = dr.Cells[3].Text.Split(':')[0].ToString();
                    det.UnitID = Convert.ToInt32(dr.Cells[4].Text);
                    det.RequestedQuantity = Convert.ToDecimal(dr.Cells[6].Text);                 
                    det.PossibleRate = Convert.ToDecimal(dr.Cells[7].Text);
                    det.FinalQuantity = 0;
                    det.CountryOfOrigin = dr.Cells[8].Text.Replace("&nbsp;", "");
                    det.Specification = dr.Cells[9].Text.Replace("&nbsp;", "");
                    det.Brand = dr.Cells[10].Text.Replace("&nbsp;", "");
         
                    ItemList.Add(det);
                }

                if (SqlGenerateForItemRequisition.SqlInsertDet(cmd, dett, ItemList))
                {
                    myTrans.Commit();

                    flg = true;

                    if (flg == true)
                    {

                        try
                        {

                            if (FileList.Items.Count > 0)
                            {

                                ClsFileUploadHeader fileHdr = new ClsFileUploadHeader();

                                fileHdr.CompanyID = 1;
                                fileHdr.BranchID = 1;
                                fileHdr.ReferenceNo = txtRefNo.Text;
                                fileHdr.FileCategoryID = 1;
                                fileHdr.UploadedScreenName = this.Form.Name;

                                if (!DataProcess.ExecuteSqlCommand(cmd, SqlGenerateForItemRequisition.SqlInsertFileHdr(fileHdr)))
                                {
                                    myTrans.Rollback();
                                    return;
                                }

                                ClsFileUploadDetail filedett = new ClsFileUploadDetail();
                                List<ClsFileUploadDetail> lstfileDet = new List<ClsFileUploadDetail>();


                                string fpath, floc;

                                for (int indexCounter = 0; indexCounter < FileList.Items.Count; indexCounter++)
                                {

                                    ClsFileUploadDetail filedet = new ClsFileUploadDetail();


                                    filedet.CompanyID = 1;
                                    filedet.BranchID = 1;
                                    filedet.ReferenceNo = txtRefNo.Text;
                                    filedet.OriginalFileName = FileList.Items[indexCounter].Text;
                                    filedet.FileID = Guid.NewGuid();
                                    filedet.FileType = null;
                                    filedet.UserDefinedFileName = FileList.Items[indexCounter].Text;
                                    filedet.UploadedFilename = FileList.Items[indexCounter].Text;
                                    filedet.FileLength = 100;
                                    filedet.UploadBy = "";


                                    filedet.UploadDateTime = System.DateTime.Now;


                                    fpath = Server.MapPath("~/Upload") + "\\";
                                    floc = fpath + filedet.FileID;

                                    filedet.RelativePath = floc;
                                    filedet.AbsolutePath = floc;
                                    filedet.DownloadLink = floc;

                                    lstfileDet.Add(filedet);
                                }


                                if (SqlGenerateForItemRequisition.SqlInsertFileDet(cmd, filedett, lstfileDet))
                                {

                                    ClearAllItemHeader();
                                    lblMesg.Text = "Data Saved Successfully";
                                    lblMesg.ForeColor = System.Drawing.Color.Purple;
                                    lblMesg.Focus();
                                }

                            }


                        }
                        catch(Exception ex)
                        {

                            lblMesg.Text = ex.Message;
                          

                        
                        }
                    }


                    ClearAllItemHeader();
                   
                }

                else
                {
                    myTrans.Rollback();
                }

            }

            catch (Exception ex)
            {
                myTrans.Rollback();
               
            }
            finally
            {
                myConnection.Close();
            }


            Response.Redirect(Request.Url.AbsoluteUri);

        }

        private void SaveitemDetail()
        {

            SqlConnection myConnection = new SqlConnection(_connectionString);
            myConnection.Open();
            SqlCommand cmd = myConnection.CreateCommand();
            SqlTransaction myTrans;
            myTrans = myConnection.BeginTransaction("BeginTransaction");

            cmd.Connection = myConnection;
            cmd.Transaction = myTrans;

            try
            {

                ClsRequisitionDetail detdelete = new ClsRequisitionDetail();

                detdelete.ItemRequisitionNo = txtRefNo.Text;

                if (!SqlGenerateForItemRequisition.DeleteRequisitionDetByRequisitionNo(cmd, detdelete))
                {
                    myTrans.Rollback();
                    return;
                }


                ClsRequisitionDetail dett = new ClsRequisitionDetail();
                List<ClsRequisitionDetail> ItemList = new List<ClsRequisitionDetail>();

                foreach (GridViewRow dr in gdvItemDetail.Rows)
                {
                    ClsRequisitionDetail det = new ClsRequisitionDetail();

                    det.ItemRequisitionNo = txtRefNo.Text;
                    det.InventoryItemID = Convert.ToInt32(dr.Cells[2].Text.Split(':')[0]);
                    det.RequiredItemName = dr.Cells[3].Text.Split(':')[0].ToString();
                    det.UnitID = Convert.ToInt32(dr.Cells[4].Text);
                    det.RequestedQuantity = Convert.ToDecimal(dr.Cells[6].Text);
                    det.PossibleRate = Convert.ToDecimal(dr.Cells[7].Text);
                    det.FinalQuantity = 0;         
                    det.CountryOfOrigin = dr.Cells[8].Text.Replace("&nbsp;", "");
                    det.Specification = dr.Cells[9].Text.Replace("&nbsp;", "");
                    det.Brand = dr.Cells[10].Text.Replace("&nbsp;", "");



                    ItemList.Add(det);


                }

                if (SqlGenerateForItemRequisition.SqlInsertDet(cmd, dett, ItemList))
                {
                    myTrans.Commit();
                    ClearAllItemHeader();
                    lblMesg.Text = "Data Saved Successfully";
                    lblMesg.ForeColor = System.Drawing.Color.Purple;
                    lblMesg.Focus();
                }

                else
                {

                    myTrans.Rollback();

                }

            }

            catch (Exception ex)
            {

                string exception = ex.Message;

            }



            finally

            {


                myConnection.Close();
            
            }

            Response.Redirect(Request.Url.AbsoluteUri);

         

        }



        private string save_file(string fpi_ref)
        {
            //tbl_file_detailTableAdapter fl = new tbl_file_detailTableAdapter();

            //string itm_det = Session[clsStatic.sessionItemSelForPO].ToString();
            //string[] tmp = itm_det.Split(':');

            string retstr = "";
            //if (tmp.Length < 2)
            //{
            //    return retstr;

            //}


            //string mpr_ref_no = tmp[0];
            //string itm_code = tmp[1];


          //  hdr.EntryUserID = Guid.NewGuid();


            string ref_no, fpath, floc, orgfilename;
            string uid = current.UserId.ToString();

            Guid  max_ref = Guid.NewGuid();
            int nFileLen;

            //foreach (HttpPostedFile myFile in FileUpload1.PostedFiles)
            //{

            //    if (FileUpload1.HasFile)
            //    {

                   
            //        if (myFile != null)
            //        {
            //            nFileLen = myFile.ContentLength;

            //            if ((nFileLen > 0) && (nFileLen < 5000001))
            //            {
            //                try
            //                {
            //                    ref_no = max_ref.ToString();



            //                    orgfilename = FileUpload1.FileName;
            //                    //fpath = Server.MapPath("~/UploadFile") + "\\";
            //                    //floc = fpath + ref_no;
            //                    //myFile.SaveAs(floc);



            //                   // string fileName = Path.GetFileName(postedFile.FileName);

            //                    myFile.SaveAs(Server.MapPath("~/UploadFile/") + orgfilename);


            //                    // fl.InsertFileDet(ref_no, fpi_ref, mpr_ref_no, itm_code, "", "PI", "Profoma Invoice", uid, DateTime.Now, "PDF", (decimal)nFileLen, orgfilename, ref_no + ".pdf", floc, floc, floc);

            //                    retstr = ref_no;
            //                }
            //                catch
            //                {
            //                    retstr = "";
            //                }
            //            }
            //        }
            //    }
            //}

            return retstr;
        }


        private string checkEntry()
        {
            if(txtRequestedBy.Text == "") return "Please Enter Requestor ";
            if (ddlRequestedDept.SelectedItem.Value == "-1") return "Please Select Requestor Department ";
            if (ddlItemUserType.Text == "-1") return "Please Select Item User Type ";
            if (txtUserName.Text == "") return "Please Enter Item User Name ";
            if (txtLocAddress.Text == "") return "Please Enter Location Address";
            if (ddlPriority.Text == "-1") return "Please Select Priority ";
            if (ddlPurpose.Text == "-1") return "Please Select Purpose ";
            if (ddlRefType.Text == "-1") return "Please Select Reference Type ";
            if (txtRefNo.Text == "") return "Please Enter Reference No.";

            if (chkproject.Checked == true)
            {
                if (ddlProject.Text == "-1") return "Please Select project";
                        
            }

            return "";
        
        }

        protected void chkproject_CheckedChanged(object sender, EventArgs e)
        {
            if (chkproject.Checked == true)
            {
                ddlProject.Visible = true;
                lblisproject.Visible = true;

            }
            else
            {
                ddlProject.Visible = false ;
                lblisproject.Visible = false;

            
            }
        }

        protected void gdvItemDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indx = gdvItemDetail.SelectedIndex;

            if (indx != -1)
            {
                DataTable dt = new DataTable();

                dt = (DataTable)ViewState[ClsStatic.link3sessionUserId];
                dt.Rows.RemoveAt(indx);
                ViewState[ClsStatic.link3sessionUserId] = dt;
                set_grid();
               // GetTotal();

                if (dt.Rows.Count == 0)
                {
                    trtest.Visible = false;
                    tblitemdetautho.Visible = false;
                }
            }
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

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        protected void gdvSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMesg.Text = "";
            lblMesSearch.Text = "";
            lblStatusforlabel.Visible = true;
            int indx = gdvSearchResult.SelectedIndex;

            if (indx != -1)
            {
                DataTable dt = new DataTable();
              string reqNo=  gdvSearchResult.Rows[indx].Cells[2].Text.ToString();
              GetRequisitionInfo(reqNo);

              if (CheckCompleteStatus() == "")
              {

                  btnPost.Visible = true;

              }

              else
              {

                  btnPost.Visible = false;

              }

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllItemDetail();
        }

        private void ClearAllItemHeader()
        {

            txtRequestedBy.Text = "";
            ddlRequestedDept.Text  = "-1";
            ddlItemUserType.Text = "-1";
            txtUserName.Text = "";         
            txtLocAddress.Text = "";
            txtComments.Text = "";
            ddlPriority.Text = "-1";
            ddlPurpose.Text = "-1";
            ddlRefType.Text = "-1";           
            ddlProject.Text = "-1";
            txtrequestedDate.Text = System.DateTime.Now.ToShortDateString();
            txtDateNeed.Text = System.DateTime.Now.ToShortDateString();

        }




        private void ClearAllItemDetail()
        {

            txtItem.Text = "";
            txtQuantity.Text = "";
            txtunit.Text = "";
            txtRate.Text = "";
            txtSpec.Text = "";
            txtBrand.Text = "";
            txtOrigin.Text = "";
            txtTotal.Text = "";
        
        }

      

        //Save

        protected void btnupload_Click(object sender, EventArgs e)
        {

            for (int indexCounter = 0; indexCounter < FileList.Items.Count; indexCounter++)
            {
                string firstval = FileList.Items[indexCounter].Text;              
            }        
        }



        protected void btnAttachFile_Click(object sender, EventArgs e)
        {
            string FileNameWithoutExten = string.Empty;
            string savename = string.Empty;
            string OrFileName = string.Empty;
            string strexten = string.Empty;
            string oldpath = string.Empty;
            string newpath = string.Empty;

            
            try
            {
                if (flAttachmentInBill.HasFile == true)
                {
                    if (flAttachmentInBill.PostedFile.ContentLength > 0)
                    {
                        FileNameWithoutExten = Path.GetFileNameWithoutExtension(flAttachmentInBill.PostedFile.FileName);
                        strexten = Path.GetExtension(flAttachmentInBill.PostedFile.FileName);
                        savename = FileNameWithoutExten.Replace(FileNameWithoutExten,FileNameWithoutExten) + strexten;
                        pnlBillAttachment.Visible = true;

                        if (FileList.Items.Contains(new ListItem(savename)))
                        {

                            lblAttachMsg.Visible = true;

                            lblAttachMsg.Text = "File already in the ListBox";
                            lblAttachMsg.ForeColor = System.Drawing.Color.Red;
                            lblAttachMsg.Focus();
                            return;
                        }
                        else
                        {
                            Files.Add(savename);
                            FileList.Items.Add(savename);


                            string completePath = Server.MapPath("~/UploadFile/") + savename;
                            if (System.IO.File.Exists(completePath))
                            {
                                System.IO.File.Delete(completePath);

                            }

                            flAttachmentInBill.SaveAs(Server.MapPath("~/UploadFile/") + savename);

                            lblAttachMsg.Visible = true;
                            lblAttachMsg.Text = "Add another file and click attach to attach in the list";
                            lblAttachMsg.ForeColor = System.Drawing.Color.YellowGreen;
                            lblAttachMsg.Focus();
                        }

                    }
                    else
                    {
                        lblAttachMsg.Visible = true;
                        lblAttachMsg.Text = "File size cannot be 0";
                        lblAttachMsg.ForeColor = System.Drawing.Color.Red;
                        lblAttachMsg.Focus();
                        return;
                    }
                }
                else
                {
                    lblAttachMsg.Visible = true;
                    lblAttachMsg.Text = "Please select a file to attach";
                    lblAttachMsg.ForeColor=System.Drawing.Color.Red;
                    lblAttachMsg.Focus();
                    return;
                }

            }
            catch (Exception)
            {
               // System.Windows.Forms.MessageBox.Show("An error occured. Please try again.");
                return;
            }
        }

        protected void btnRemoveFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileList.Items.Count > 0)
                {

                    if (FileList.SelectedIndex < 0)
                    {
                        lblAttachMsg.Visible = true;
                        lblAttachMsg.Text = "Please select a file to remove";
                        lblAttachMsg.ForeColor = System.Drawing.Color.Red;
                        return;

                    }

                    else
                    {
                        string completePath = Server.MapPath("~/UtilityBillPaperTempAttachment/") + FileList.SelectedItem.Text;

                        if (System.IO.File.Exists(completePath))
                        {
                            System.IO.File.Delete(completePath);
                        }

                        Files.RemoveAt(FileList.SelectedIndex);

                        FileList.Items.Remove(FileList.SelectedItem.Text);

                        lblAttachMsg.Visible = true;
                        lblAttachMsg.Text = "File removed";
                        lblAttachMsg.ForeColor = System.Drawing.Color.YellowGreen;

                        if (FileList.Items.Count == 0)
                        {
                            //pnlBillAttachment.Visible = false;
                        }
                    }
                }
            }
            catch
            {
                lblAttachMsg.Visible = true;
                lblAttachMsg.Text = "Please try again with valid information";
                lblAttachMsg.ForeColor = System.Drawing.Color.YellowGreen;
               
                
            }
        }


        protected void FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = FileList.SelectedIndex;
            lblDownloadSelectedFile.Text = FileList.Items[i].Text;
        }

        protected void chkproject_CheckedChanged1(object sender, EventArgs e)
        {


            if (chkproject.Checked == false)
            {

                Label35.Visible = false;
                ddlProject.Visible = false;

            }

            else

            {
                Label35.Visible = true ;
                ddlProject.Visible = true;
            
            }

        }

        protected void ddlRequestedDept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {


          //  dtaddreess = DataProcess.GetData(connectionStringreq, sqlGenerationClientInformation.GetClientAddress(txt));

            if (ddlItemUserType.Text == "-1")
            {

                lblMesg.Text = "Please select user type";
                lblMesg.ForeColor = System.Drawing.Color.Red;
                lblMesg.Focus();
                return;
            }
            
            
            GetClientAddress(txtUserName.Text.Split(':')[0].ToString());
        }

        private void GetClientAddress(string address)
        {


            txtLocAddress.Text = "";
            DataTable dtaddreess = new DataTable();
            dtaddreess = DataProcess.GetData(_connectionString, sqlGenerationClientInformation.GetClientAddress(address));

            if (dtaddreess.Rows.Count > 0)
            {

                foreach (DataRow dr in dtaddreess.Rows)
                {

                    txtLocAddress.Text += dr["ContactAddressType"].ToString() + "-" + dr["DisplayAddress"].ToString() + "." + "\r\n";

                }
            }
            else

            {

                txtLocAddress.Text = "";
            
            }
        
        }


        protected void ddlItemUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

            string userNmae="";

            txtUserName.Text = "";
            txtLocAddress.Text = "";

            lblMesg.Text = "";

            if (ddlItemUserType.Text == "-1")
            {
                txtUserName.Text = "";
                txtLocAddress.Text = "";

                userNmae = "";
            }
            else
            {

                userNmae = ddlItemUserType.SelectedItem.Value;
            
            }


            AutoUserName.ContextKey = userNmae.ToString();

           // txtUserName_TextChanged(null, null);
        }

        protected void gdvItemDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[3].Attributes["width"] = "200px";
        }

        protected void btnClearAdSearch_Click(object sender, EventArgs e)
        {
            ddlPrioritySearch.Text = "-1";
            ddldepartment.Text = "-1";
            ddlPurposeSearch.Text = "-1";
            txtItemSearch.Text = "";
            txtFrmDate.Text = System.DateTime.Now.ToShortDateString();
            txtToDate.Text = System.DateTime.Now.ToShortDateString();
            txtEmployeeSearch.Text = ""; 
        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            bool flg = false;
            if (txtRefNo.Text == "")
            {

                lblMesg.Text = "Enter Item Requisition No";
                return;
            }
            
            DataProcess.GetData(_connectionString, SqlGenerateForItemRequisition.SqlUpdateCompleteStatus (txtRefNo.Text));
            flg = true;
            if (flg)
            {

                Response.Redirect(Request.Url.AbsoluteUri);

                //lblMesg.Text = "Requisition Posted";
                //return;            
            }

        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {

            DataTable dtunit= new DataTable ();
            dtunit = DataProcess.GetData(_connectionString, SqlGenerationForItemDetail.GetItemUnit(txtItem.Text.Split(':')[0].ToString()));
            if (dtunit.Rows.Count > 0)
            {
                txtunit.Text = dtunit.Rows[0]["UnitID"].ToString() + ":" + dtunit.Rows[0]["Unit"].ToString();
            }

            else
            {
                txtunit.Text = "";
            
            }
        }

        protected void txtrequestedDate_TextChanged(object sender, EventArgs e)
        {
            GenerateRefNo(_connectionString, "1", "1", "ItemRequisitionHeader", "ItemRequisitionNo",Convert.ToDateTime(txtrequestedDate.Text),1);
        }


    }
}