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
using ERPWebApplication.AppClass.DataAccess;
using CrystalDecisions.Shared;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using ERPWebApplication.AppClass.CommonClass;
using ERPWebApplication.AppClass.Model;
using System.Drawing;




namespace ERPWebApplication.ModuleName.Inventory.TransactionPage
{
    public partial class frmItemRequisition : System.Web.UI.Page
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
        public static ArrayList Files = new ArrayList();

       private ProritySetupController _objPrioritySetupController;


      
       string requisitionrefno="";

       RequisitionHeader _objRequisitionHeader;
       RequisitionDetail _objRequisitionDetail;
       FileUploadHeader _objFileUploadHeader;
       FileUploadDetail _objFileUploadDetail;

       ItemRequisitionHeaderController _objItemRequisitionHeaderController;
       ItemRequisitionDetailController _objItemRequisitionDetailController;

       FileUploadHeaderController _objFileUploadHeaderController;
       FileUploadDetailController _objFileUploadDetailController;
       UnitSetupController _objUnitSetupController;

       EmployeeInformationController _objEmployeeInformationController;
       ClientInformationController _objClientInformationController;

       ItemSetupController _objItemSetupController;

       CompanySetup _objCompanySetup;
       BranchSetup _objBranchSetup;

        protected void Page_Load(object sender, EventArgs e)
        {
           // ClsStatic.CheckUserAuthentication();
          
            Session[ClsStatic.link3sessionUserId] = "MOS";
            string userid = Session[ClsStatic.link3sessionUserId].ToString();


            Session[ClsStatic.sessionCompanyID]="1";
            Session[ClsStatic.sessionBranchID]="0";

            ClsStatic.MsgConfirmBox(btnSubmit,"Are you sure to confirm submit?");
            ClsStatic.MsgConfirmBox(btnPost, "Are you sure to confirm post?");
            ClsStatic.MsgConfirmBox(btnReject , "Are you sure to confirm reject?");
           // tblsearch.BgColor = "#F0F8FF";

            

            if (!IsPostBack)
            {

                AutoCompleteForReq.ContextKey = Session[ClsStatic.sessionCompanyID].ToString() + ":" + Session[ClsStatic.sessionBranchID].ToString();
                AutoCompleteforEmployee.ContextKey = Session[ClsStatic.sessionCompanyID].ToString() + ":" + Session[ClsStatic.sessionBranchID].ToString();
                autoCompleteforItemDeat.ContextKey = Session[ClsStatic.sessionCompanyID].ToString() + ":" + Session[ClsStatic.sessionBranchID].ToString();



                trSearchResult.Visible = false;
                trItemDetail.Visible = false;
           



                // adv search

                AutoCompleteadempserch.ContextKey = Session[ClsStatic.sessionCompanyID].ToString() + ":" + Session[ClsStatic.sessionBranchID].ToString();

                AutoCompleteItemSearch.ContextKey = Session[ClsStatic.sessionCompanyID].ToString() + ":" + Session[ClsStatic.sessionBranchID].ToString();

               
                //table

                tblattach.Visible = true;
                tbladvsearch.Visible = false;
              
             

                //hr 
              //  searchbottom.Visible = true;
                advsearchbottom.Visible = false;
                headertop.Visible = false;


                //button
                btnPrintRequisition.Enabled = true;

                //tr
              

              //  mesg.Visible = false;


                //panel
             
                //pnlBillAttachment.Visible = true;

                //Collapsible
                cpeheader.Collapsed = true;
                cpeheader.ClientState = "true";

                //label

             
                lblStatusforlabel.Visible = false;

                foreach (GridViewRow gvrow in gdvItemDetail.Rows)
                {
                    gvrow.Cells[0].Enabled = true;

                }

                txtFrmDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtToDate.Text = System.DateTime.Now.AddDays(15).ToString("dd/MM/yyyy");
                txtrequestedDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtDateNeed.Text = System.DateTime.Now.AddDays(15).ToString("dd/MM/yyyy");

                LoadDataInDropdown();

            }
        }

        private void MessageBox(string mesg)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('"+mesg +"');", true);
        }

        private void MessageBoxShow(Page page, string message)
        {
            Literal ltr = new Literal();
            ltr.Text = @"<script type='text/javascript'> alert('" + message + "') </script>";
            page.Controls.Add(ltr);
        }

        private void LoadDataInDropdown()
        {

           //ClsDropDownListController.LoadListBox(_connectionString, ProritySetupController.GetDataPriority(Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID])), ddlPriority, "PriorityName", "PriorityID");
            LoadPriorityDropDown(ddlPrioritySearch);


            ClsDropDownListController.LoadDropDownList(_connectionString, PurposeSetupController.GetDataPurposeSetup(Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID])), ddlPurpose, "ItemUsage", "ItemUsageID");
            ClsDropDownListController.LoadDropDownList(_connectionString, ProjectSetupController.GetDataProjectSetup(Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID])), ddlProject, "ProjectName", "ProjectID");
            ClsDropDownListController.LoadDropDownList(_connectionString, PersonTypeSetupController.GetDataPersonTypeSetup(Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID])), ddlItemUserType, "PersonType", "PersonTypeID");
            ClsDropDownListController.LoadDropDownList(_connectionString, ActivitySetupController.GetDataActivitySetup(Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID])), ddlRefType, "ActivityName", "KnownByID");
            ClsDropDownListController.LoadDropDownList(_connectionString, DepartmentSetupController.GetDataDepartmentSetup(Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID])), ddlRequestedDept, "DepartmentName", "DepartmentID");

            // For searching ddl

            ClsDropDownListController.LoadDropDownList(_connectionString, PurposeSetupController.GetDataPurposeSetup(Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID])), ddlPurposeSearch, "ItemUsage", "ItemUsageID");
            ClsDropDownListController.LoadDropDownList(_connectionString, ProritySetupController.GetDataPriority(Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID])), ddlPriority, "PriorityName", "PriorityID");
            ClsDropDownListController.LoadDropDownList(_connectionString, DepartmentSetupController.GetDataDepartmentSetup(Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID])), ddldepartment, "DepartmentName", "DepartmentID");

            _objUnitSetupController = new UnitSetupController ();
            _objCompanySetup = new CompanySetup();
            _objBranchSetup = new BranchSetup();
            _objCompanySetup.CompanyID = Convert.ToInt32(Session[ClsStatic.sessionCompanyID]);
            _objBranchSetup.BranchID = Convert.ToInt32(Session[ClsStatic.sessionBranchID]);
            ClsDropDownListController.LoadDropDownList(_connectionString, _objUnitSetupController.UnitSql(_objCompanySetup, _objBranchSetup), ddlunit, "Unit", "UnitID");

        }

        private void LoadPriorityDropDown(DropDownList ddlCountry)
        {
            try
            {
                _objPrioritySetupController = new ProritySetupController();
                _objPrioritySetupController.LoadPriority(ddlCountry);

            }
            catch (Exception msgException)
            {
                clsTopMostMessageBox.Show(msgException.Message);
            }
        }

        protected void btnAdvSearch_Click(object sender, EventArgs e)
        {
            tbladvsearch.Visible = true;
            advsearchbottom.Visible = true;
            CollapsiblePanelExtender5.Collapsed = true;
            CollapsiblePanelExtender5.ClientState = "true";   
        }

        protected void imgbtnadsearch_Click(object sender, ImageClickEventArgs e)
        {
            tbladvsearch.Visible = false ;
            advsearchbottom.Visible = false ;

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //tbladvsearchresult.Visible = true;          
            advsearchbottom.Visible = true;
            headertop.Visible = true;

            DataTable dtadsearch = new DataTable();
            RequisitionHeader hdr = new RequisitionHeader();

            _objItemRequisitionHeaderController = new ItemRequisitionHeaderController();

            hdr.CompanyID = Convert.ToInt32(Session[ClsStatic.sessionCompanyID]);
            hdr.BranchID = Convert.ToInt32(Session[ClsStatic.sessionBranchID]);       


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

            _objItemRequisitionHeaderController = new ItemRequisitionHeaderController ();
            dtadsearch = _objItemRequisitionHeaderController.GetDataRequisitionAdvancedSearch(hdr, Convert.ToDateTime(fromdate), Convert.ToDateTime(toDate), item);

            if (dtadsearch.Rows.Count == 0)

            {
               // tbladvsearchresult.Visible = false ;
                advsearchbottom.Visible = false ;
                headertop.Visible = false ;
                clsTopMostMessageBox.Show("No data found");

            }

            advsearchbottom.Visible = true;
            LoadAdvancedSearch(dtadsearch);
        }

        private void LoadAdvancedSearch(DataTable dtadsearch)
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
                dt.Rows.Add(dtadsearch.Rows.Count+1, dr["ItemRequisitionNo"].ToString(), Convert.ToDateTime(dr["RequisitionDate"]).ToShortDateString(), (dr["RequisitionID"] + ":" + dr["RequisitionBy"]).ToString(), dr["DepartmentName"], dr["PriorityName"]);
            }
            gdvSearchResult.DataSource = dt;
            gdvSearchResult.DataBind();

            if (gdvSearchResult.Rows.Count > 0)
            {

                trSearchResult.Visible = true;
            
            }


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


        private string CheckCompleteStatus(string ReqRefno,int companyID,int branchID)
        {

            if (ReqRefno != "")
            {

                DataTable dtcount = new DataTable();

                _objItemRequisitionHeaderController = new ItemRequisitionHeaderController();

                dtcount = _objItemRequisitionHeaderController.GetDataRequisitionHdr(ReqRefno, companyID, branchID);

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

            //if (CheckCompleteStatus() != "")
            //{

            //    CheckCompleteStatus();
            
            //}

            if (ddlunit.SelectedItem.Value == "-1") return "Please Select Unit ";
            if (txtItem.Text == "") return "Please Search Item ";
            if (txtQuantity.Text == "") return "Please Enter Quantity ";
            if (txtRate.Text == "") return "Please Enter Quantity ";
            return "";
        
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
        

            if (CheckEntryDetail() != "")
            {
                string mesg = CheckEntryDetail();                
            
                MessageBox(mesg);
                return;

            }
            if (CheckDuplicate() == false)
            {
                MessageBox("Item Already Added");
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
                dt.Columns.Add("Quantity", typeof(double ));
                dt.Columns.Add("Rate", typeof(double));
                dt.Columns.Add("Amount", typeof(double));
            
                dt.Columns.Add("Origin", typeof(string ));
                dt.Columns.Add("Specification", typeof(string ));
                dt.Columns.Add("Brand", typeof(string));

            }

            ItemRequisitionDetailController dtcontroller = new ItemRequisitionDetailController();
            string icode = "";
            DataTable dtnewitem = new DataTable();

            ItemRequisitionDetailController _objItemRequisitionDetail = new ItemRequisitionDetailController();


            try
            {
                dtnewitem = _objItemRequisitionDetail.GetDataByItemDet(Convert.ToInt32(txtItem.Text.Split(':')[0]), Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID]));
                dt.Rows.Add(dt.Rows.Count + 1, txtItem.Text.Split(':')[0].Trim(), txtItem.Text.Split(':')[1].Trim(), ddlunit.SelectedItem.Value, ddlunit.SelectedItem.Text, Convert.ToDecimal(txtQuantity.Text.ToString()), Convert.ToDecimal(txtRate.Text.ToString()), Convert.ToDecimal(txtQuantity.Text.ToString()) * Convert.ToDecimal(txtRate.Text.ToString()), txtOrigin.Text.Replace("&nbsp;", ""), txtSpec.Text.Replace("&nbsp;", ""), txtBrand.Text.Replace("&nbsp;", ""));
            
            }

            catch

            {

                ItemSetupController _ObjItemSetupControoler = new ItemSetupController();
                int sl = SlItemRefno();
                icode = _ObjItemSetupControoler.GenerateTemporaryItemRefNo(_connectionString, Session[ClsStatic.sessionCompanyID].ToString(), Session[ClsStatic.sessionBranchID].ToString(), Convert.ToDateTime(txtrequestedDate.Text), 1, sl);
                dt.Rows.Add(dt.Rows.Count + 1, icode, txtItem.Text.Trim(), ddlunit.SelectedItem.Value, ddlunit.SelectedItem.Text, Convert.ToDouble(txtQuantity.Text.ToString()), Convert.ToDouble(txtRate.Text.ToString()), Convert.ToDouble(txtQuantity.Text.ToString()) * Convert.ToDouble(txtRate.Text.ToString()), txtOrigin.Text.Replace("&nbsp;", ""), txtSpec.Text.Replace("&nbsp;", ""), txtBrand.Text.Replace("&nbsp;", ""));
            }


           
            ViewState[ClsStatic.link3sessionUserId] = new DataTable();
            ViewState[ClsStatic.link3sessionUserId] = dt;
            set_grid();
          //  GetTotal();
            if (dt.Rows.Count > 0)
            {              
                trItemDetail.Visible = true;

            }

            gdvItemDetail.HeaderRow.Cells[0].Visible = true;
            foreach (GridViewRow gvrow in gdvItemDetail.Rows)
            {
                gvrow.Cells[0].Enabled  =true ;

            }

            ClearAllItemDetail();

            if (CheckCompleteStatus(lblref.Text, Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID])) == "")
            {

                btnPost.Visible = false ;
                btnReject.Visible = false;

            }

            else
            {

                btnPost.Visible = true;
                btnReject.Visible = true;

            }
        }

        private int SlItemRefno()
        {

         int sl = 1;
         int lasttwonumber;
         DataTable dt = new DataTable();
         dt = (DataTable)ViewState[ClsStatic.link3sessionUserId];

         if (dt != null)
         {
             foreach (DataRow dr in dt.Rows)
             {
                 string abc = dr["Icode"].ToString();
                 if (abc.Length == 9)
                 {
                     if (abc.Substring(2, 1) == "9")
                     {
                         
                        lasttwonumber=Convert.ToInt32 (abc.Substring(7, 2));
                        lasttwonumber += 1;
                        sl = lasttwonumber;
                     }

                 }

             }
         }

         return sl;
        }

        //private void TotalAmount()
        //{ 
        //    double  qty;
        //    double rate;

        //    qty = txtQuantity.Text == "" ? 0 : Convert.ToDouble(txtQuantity.Text);
        //    rate = txtRate.Text == "" ? 0 : Convert.ToDouble(txtRate.Text);
        //    txtTotal.Text = (qty * rate).ToString();
 
        //}


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
                    dtgrid.Columns.Add("Quantity", typeof(double));

                    dtgrid.Columns.Add("Rate", typeof(double));
                    dtgrid.Columns.Add("Amount", typeof(double));
                   

                    dtgrid.Columns.Add("Origin", typeof(string));
                    dtgrid.Columns.Add("Specification", typeof(string));
                    dtgrid.Columns.Add("Brand", typeof(string)); 

                    foreach (DataRow dr in dt.Rows)
                    {
                        cnt += 1;
                        dtgrid.Rows.Add(cnt, dr["Icode"].ToString(), dr["Item desc"].ToString(), dr["UnitID"].ToString(), dr["uom"].ToString(), Convert.ToDouble(dr["Quantity"]), Convert.ToDouble(dr["Rate"]), Convert.ToDouble(Convert.ToDouble(dr["Quantity"]) * Convert.ToDouble(dr["Rate"])), dr["Origin"].ToString(), dr["Specification"].ToString(), dr["Brand"].ToString());
                    }

                    gdvItemDetail.DataSource = dtgrid;
                    gdvItemDetail.DataBind();
                    ViewState[ClsStatic.link3sessionUserId] = dtgrid;

                    if (dtgrid.Rows.Count > 0)
                    {


                        double  total = dt.AsEnumerable().Sum(row => row.Field<Double>("Amount"));
                        gdvItemDetail.FooterRow.Cells[7].Text = "Total";
                        gdvItemDetail.FooterRow.Cells[7].Font.Bold = true;
                        gdvItemDetail.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                        gdvItemDetail.FooterRow.Cells[8].Text = total.ToString();
                        gdvItemDetail.FooterRow.Cells[8].Font.Bold = true;
                        gdvItemDetail.FooterRow.Cells[7].Font.Bold = true;
                    }
                }

            }
        }

        private void Load_grid_for_adv(string refno)
        {
            //tblitemdet.Visible = true;
            DataTable det = new DataTable();
            DataTable dtgrid = new DataTable();

            _objItemRequisitionDetailController = new ItemRequisitionDetailController();
            det = _objItemRequisitionDetailController.GetDataRequisitionDet(refno);

            int cnt = 0;
            if (det.Rows.Count > 0)
            {
                //pnl.Visible = true;
                dtgrid.Rows.Clear();
                dtgrid.Columns.Clear();
                dtgrid.Columns.Add("SL", typeof(int));
                dtgrid.Columns.Add("Icode", typeof(string));
                dtgrid.Columns.Add("Item desc", typeof(string));
                dtgrid.Columns.Add("UnitID", typeof(string));
                dtgrid.Columns.Add("uom", typeof(string));
                dtgrid.Columns.Add("Quantity", typeof(decimal));
                dtgrid.Columns.Add("Rate", typeof(decimal));
                dtgrid.Columns.Add("Amount", typeof(decimal));
                dtgrid.Columns.Add("Origin", typeof(string));
                dtgrid.Columns.Add("Specification", typeof(string));
                dtgrid.Columns.Add("Brand", typeof(string));

                foreach (DataRow row in det.Rows)
                {
                    cnt += 1;
                    dtgrid.Rows.Add(cnt, row["InventoryItemID"].ToString(), row["RequiredItemName"].ToString(), row["UnitID"].ToString(), row["Unit"].ToString(), Convert.ToDecimal(row["RequestedQuantity"]), Convert.ToDecimal(row["PossibleRate"]), Convert.ToDecimal(row["RequestedQuantity"])* Convert.ToDecimal(row["PossibleRate"]), row["CountryOfOrigin"].ToString(), row["Specification"].ToString(), row["Brand"].ToString());
                }

                gdvItemDetail.DataSource = dtgrid;
                gdvItemDetail.DataBind();


                if (dtgrid.Rows.Count > 0)
                {


                    double  total = dtgrid.AsEnumerable().Sum(row => row.Field<double>("Amount"));
                    gdvItemDetail.FooterRow.Cells[7].Text = "Total";
                    gdvItemDetail.FooterRow.Cells[7].Font.Bold = true;
                    gdvItemDetail.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                    gdvItemDetail.FooterRow.Cells[8].Text = total.ToString();
                    gdvItemDetail.FooterRow.Cells[8].Font.Bold = true;
                    gdvItemDetail.FooterRow.Cells[7].Font.Bold = true;
                }

            }

        }

        private void Load_grid( string requisitionNo)
        {
            //tblitemdet.Visible = true;
            DataTable det = new DataTable();
            DataTable dtgrid = new DataTable();

            _objItemRequisitionDetailController = new ItemRequisitionDetailController();
            det = _objItemRequisitionDetailController.GetDataRequisitionDet(requisitionNo);
            int cnt = 0;
            if (det.Rows.Count > 0)
            {
                trItemDetail.Visible = true;
                dtgrid.Rows.Clear();
                dtgrid.Columns.Clear();

                dtgrid.Columns.Add("SL", typeof(int));
                dtgrid.Columns.Add("Icode", typeof(string));
                dtgrid.Columns.Add("Item desc", typeof(string));
                dtgrid.Columns.Add("UnitID", typeof(string));
                dtgrid.Columns.Add("uom", typeof(string));
                dtgrid.Columns.Add("Quantity", typeof(double));
                dtgrid.Columns.Add("Rate", typeof(double));
                dtgrid.Columns.Add("Amount", typeof(double));

                dtgrid.Columns.Add("Origin", typeof(string));
                dtgrid.Columns.Add("Specification", typeof(string));
                dtgrid.Columns.Add("Brand", typeof(string));

                foreach (DataRow row in det.Rows)
                {
                       cnt += 1;
                       dtgrid.Rows.Add(cnt, row["InventoryItemID"].ToString(), row["RequiredItemName"].ToString(), row["UnitID"].ToString(), row["Unit"].ToString(), Convert.ToDouble(row["RequestedQuantity"]), Convert.ToDouble(row["PossibleRate"]), Convert.ToDouble(row["RequestedQuantity"]) * Convert.ToDouble(row["PossibleRate"]), row["CountryOfOrigin"].ToString().Trim(), row["Specification"].ToString().Trim(), row["Brand"].ToString().Trim());
                }

                gdvItemDetail.DataSource = dtgrid;
                gdvItemDetail.DataBind();

                ViewState[ClsStatic.link3sessionUserId] = dtgrid;


                if (dtgrid.Rows.Count > 0)
                {


                    double total = dtgrid.AsEnumerable().Sum(row => row.Field<double>("Amount"));
                    gdvItemDetail.FooterRow.Cells[7].Text = "Total";
                    gdvItemDetail.FooterRow.Cells[7].Font.Bold = true;
                    gdvItemDetail.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                    gdvItemDetail.FooterRow.Cells[8].Text = total.ToString();
                    gdvItemDetail.FooterRow.Cells[8].Font.Bold = true;
                    gdvItemDetail.FooterRow.Cells[7].Font.Bold = true;
                }

            }
        }

        private bool CheckDuplicate()
        {

            DataTable dt = new DataTable();
            dt = (DataTable)ViewState[ClsStatic.link3sessionUserId];
             string  itemCode = txtItem.Text.Split(':')[0].ToString();

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
          
           
            cpeheader.Collapsed = true;
            cpeheader.ClientState = "true";

            if (txtSearch.Text == "")
            {
                clsTopMostMessageBox.Show("Please enter Requisition No.");
                return;          
            }

            int branchID=Convert.ToInt32(Session[ClsStatic.sessionBranchID]); 
            int companyID=Convert.ToInt32(Session[ClsStatic.sessionCompanyID]); 
            GetRequisitionInfo(txtSearch.Text.Split(':')[0].Trim(),branchID,companyID);

           // GetTotal();
           // tblauthorization.Visible = true;

            if (CheckCompleteStatus(lblref.Text, companyID, branchID) == "")
            {
                btnPost.Visible = true;
                btnReject.Visible = true;
            }
            else
            {
                btnPost.Visible = false;
                btnReject.Visible = false ;
            }
        }


        private void GetRequisitionInfo(string requisitionNo,int branchID,int CompID )
        {
            DataTable hdr = new DataTable();
           

            _objItemRequisitionHeaderController = new ItemRequisitionHeaderController();
            _objItemRequisitionDetailController = new ItemRequisitionDetailController();

            hdr = _objItemRequisitionHeaderController.GetDataRequisitionHdr(requisitionNo, branchID, CompID);

            if (hdr.Rows.Count > 0)
            {

                if (hdr.Rows[0]["CompletionStatus"].ToString() == "1")
                {
                    clsTopMostMessageBox.Show("This Item Requisition has been Submitted");
                    ClearAllItemHeader();
                    gdvItemDetail.DataSource = null;
                    gdvItemDetail.DataBind();
                    FileList.Items.Clear();
                  
                    return;

                }
                else
                {
                    lblstatus.Text = "You Can Modify this Item Requisition";
                    lblstatus.ForeColor = System.Drawing.Color.Blue;
                    btnDownLoad.Visible = true;
                    btnAttachFile.Visible = true;
                    btnRemoveFile.Visible = true;

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
                ddlItemUserType.Text = hdr.Rows[0]["UserTypeID"].ToString();
                txtUserName.Text = hdr.Rows[0]["UserID"].ToString();
                txtLocAddress.Text = hdr.Rows[0]["LocationAddress"].ToString();
                txtrequestedDate.Text = Convert.ToDateTime(hdr.Rows[0]["RequisitionDate"]).ToShortDateString();
                txtDateNeed.Text = Convert.ToDateTime(hdr.Rows[0]["RequiredDate"]).ToShortDateString();
                ddlPriority.Text = hdr.Rows[0]["PriorityID"].ToString();
                ddlPurpose.Text = hdr.Rows[0]["PurposeID"].ToString();
                ddlRefType.Text = hdr.Rows[0]["ReferenceTypeID"].ToString();
               
                txtComments.Text = hdr.Rows[0]["RequisitionComments"].ToString();
                lblref.Text = hdr.Rows[0]["ItemRequisitionNo"].ToString();

                DataTable filedet = new DataTable();

                _objFileUploadDetailController = new FileUploadDetailController();
                filedet = _objFileUploadDetailController.GetDataFileDet(requisitionNo, CompID, branchID);

                if (filedet.Rows.Count > 0)
                {
                    btnAttachFile.Visible = true;
                    btnRemoveFile.Visible = true;
                    btnDownLoad.Visible = true;
                   // pnlBillAttachment.Visible = true;

                    FileList.Items.Clear();

                    foreach (DataRow dr in filedet.Rows)
                    {
                        Files.Add(dr["OriginalFileName"]);
                        FileList.Items.Add(dr["OriginalFileName"].ToString());
                    }
                }

                DataTable dtItemRequisition = new DataTable();

                _objItemRequisitionDetailController = new ItemRequisitionDetailController();
                dtItemRequisition = _objItemRequisitionDetailController.GetDataRequisitionDet(requisitionNo);

                if (dtItemRequisition.Rows.Count > 0)
                {
                   
                    Load_grid(requisitionNo);
                    DataTable dtcount = new DataTable();
                    _objItemRequisitionHeaderController = new ItemRequisitionHeaderController();
                    dtcount = _objItemRequisitionHeaderController.GetDataRequisitionHdr(requisitionNo, branchID, CompID);
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
                                gvrow.Cells[0].Enabled = true;

                            }
                        }

                    }
                }
            }

            else
            {               
                clsTopMostMessageBox.Show("No data found");
                return;

            }
        }


        protected void btnPrintRequisition_Click(object sender, EventArgs e)
        {
         
            lblstatus.Text = "";
            ShowReport(lblref.Text);

        }

        private void ShowReport(string requisitionNo)
        {
            if (requisitionNo == "")
            {
                clsTopMostMessageBox.Show("Please select Requisition");
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

            RegisterStartupScript("click", "<script>window.open('../Report/ReportForm/ReportViewer.aspx');</script>");

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            _objItemRequisitionHeaderController = new ItemRequisitionHeaderController();
            if (checkEntry() != "")
            {
                MessageBox(checkEntry());
                return;           
            }

            bool flg=false ;
            string showpop;

            int branchID=Convert.ToInt32(Session[ClsStatic.sessionBranchID]);
            int companyID=Convert.ToInt32(Session[ClsStatic.sessionCompanyID]);

            requisitionrefno = _objItemRequisitionHeaderController.GenerateRefNo(_connectionString, Session[ClsStatic.sessionCompanyID].ToString(), Session[ClsStatic.sessionBranchID].ToString(), Convert.ToDateTime(txtrequestedDate.Text), 1);

           DataTable dtcount = new DataTable ();

           if (lblref.Text != "")
           {
               requisitionrefno = lblref.Text.Trim();

               _objItemRequisitionHeaderController = new ItemRequisitionHeaderController ();
               dtcount = _objItemRequisitionHeaderController.GetDataRequisitionHdr(requisitionrefno, branchID, companyID);

               if (dtcount.Rows.Count > 0)
               {

                   if (Convert.ToInt32(dtcount.Rows[0]["CompletionStatus"]) == 0)
                   {
                       SaveitemDetail(requisitionrefno);
                       goto showpop;
                   }

                   else
                   {
                       clsTopMostMessageBox.Show("Data Already Submitted");
                       return;
                   }

               }
           }
           
            SqlConnection myConnection = new SqlConnection(_connectionString);
            myConnection.Open();
            SqlCommand cmd = myConnection.CreateCommand();
            SqlTransaction myTrans;
            myTrans = myConnection.BeginTransaction("BeginTransaction");

            cmd.Connection = myConnection;
            cmd.Transaction = myTrans;

             RequisitionHeader _objRequisitionHeader = new RequisitionHeader();
            try
            {

                _objRequisitionHeader.CompanyID = Convert.ToInt32(Session[ClsStatic.sessionCompanyID]);
                _objRequisitionHeader.BranchID = Convert.ToInt32(Session[ClsStatic.sessionBranchID]);
                _objRequisitionHeader.ItemRequisitionNo = requisitionrefno;
                _objRequisitionHeader.RequisitionBy = txtRequestedBy.Text.Split(':')[0].ToString();
                _objRequisitionHeader.RequisitionDate = Convert.ToDateTime(txtrequestedDate.Text);
                _objRequisitionHeader.RequiredDate = Convert.ToDateTime(txtDateNeed.Text);
                _objRequisitionHeader.RequestedDepartment = ddlRequestedDept.SelectedItem.Value;
                _objRequisitionHeader.UserType = Convert.ToInt32(ddlItemUserType.SelectedItem.Value);
                _objRequisitionHeader.UserID = txtUserName.Text.Split(':')[0].ToString();
                _objRequisitionHeader.LocationOfUse = 0;
                _objRequisitionHeader.LocationAddress = txtLocAddress.Text;
                _objRequisitionHeader.PriorityID = Convert.ToInt32(ddlPriority.SelectedItem.Value);
                _objRequisitionHeader.PurposeID = Convert.ToInt32(ddlPurpose.SelectedItem.Value);
                _objRequisitionHeader.ReferenceTypeID = Convert.ToInt32(ddlRefType.SelectedItem.Value);
                _objRequisitionHeader.ReferenceNumber = requisitionrefno;
                _objRequisitionHeader.RequisitionComments = txtComments.Text;
                _objRequisitionHeader.CompletionStatus = 0;

                if (chkproject.Checked == true)
                {
                    _objRequisitionHeader.ProjectID = ddlProject.SelectedItem.Value;               
                }

                else
                {
                    _objRequisitionHeader.ProjectID = null;              
                }

                _objRequisitionHeader.ProjectID = ddlProject.SelectedItem.Value;
                _objRequisitionHeader.RequisitionCurrentStatus = 1;
                _objRequisitionHeader.RequisitionComments = txtComments.Text.Trim();

                _objRequisitionHeader.EntryDate = System.DateTime.Now;
                _objRequisitionHeader.EntryUserID = Guid.NewGuid();
                _objRequisitionHeader.ModifiedDate = System.DateTime.Now;
                _objRequisitionHeader.ModifiedUserID = Guid.NewGuid();


                //if (!DataProcess.ExecuteSqlCommand(cmd, ItemRequisitionHeaderController.SqlInsert(hdr)))
                //{
                //    myTrans.Rollback();
                //    return;
                //}


                _objItemRequisitionHeaderController = new ItemRequisitionHeaderController ();

                if (_objItemRequisitionHeaderController.SqlInsert(cmd, _objRequisitionHeader) == false)
                {
                    myTrans.Rollback();
                    return;               
                }

                RequisitionDetail dett = new RequisitionDetail();
                List<RequisitionDetail> ItemList = new List<RequisitionDetail>();

                foreach (GridViewRow dr in gdvItemDetail.Rows)
                {
                    RequisitionDetail det = new RequisitionDetail();

                    det.ItemRequisitionNo = requisitionrefno;
                    det.InventoryItemID  = Convert.ToInt32(dr.Cells[2].Text.Split(':')[0]);
                    det.RequiredItemName  = dr.Cells[3].Text.Split(':')[0].ToString();
                    det.UnitID = Convert.ToInt32(dr.Cells[4].Text);
                    det.RequestedQuantity = Convert.ToDecimal(dr.Cells[6].Text);
                    det.PossibleRate = Convert.ToDecimal(dr.Cells[7].Text);   
                    det.FinalQuantity = 0;
                    det.CountryOfOrigin = dr.Cells[9].Text.Replace("&nbsp;", "");
                    det.Specification = dr.Cells[10].Text.Replace("&nbsp;", "");
                    det.Brand = dr.Cells[11].Text.Replace("&nbsp;", "");
         
                    ItemList.Add(det);
                }


                _objItemRequisitionDetailController=new ItemRequisitionDetailController ();

                if (_objItemRequisitionDetailController.SqlInsertDet(cmd, dett, ItemList))
                {
                   // myTrans.Commit();

                    flg = true;

                    if (flg == true)
                    {

                        try
                        {

                            if (FileList.Items.Count > 0)
                            {

                                FileUploadHeader fileHdr = new FileUploadHeader();

                                fileHdr.CompanyID = Convert.ToInt32(Session[ClsStatic.sessionCompanyID]);
                                fileHdr.BranchID = Convert.ToInt32(Session[ClsStatic.sessionBranchID]);
                                fileHdr.ReferenceNo = requisitionrefno;
                                fileHdr.FileCategoryID = 1;
                                fileHdr.UploadedScreenName = Path.GetFileName(Request.PhysicalPath);

                                _objFileUploadHeaderController= new FileUploadHeaderController ();


                                if (_objFileUploadHeaderController.SqlInsertFileHdr(cmd, fileHdr) == false)
                                {
                                    myTrans.Rollback();
                                    return;
                                }

                                FileUploadDetail filedett = new FileUploadDetail();
                                List<FileUploadDetail> lstfileDet = new List<FileUploadDetail>();


                                string fpath, floc;

                                for (int indexCounter = 0; indexCounter < FileList.Items.Count; indexCounter++)
                                {

                                    FileUploadDetail filedet = new FileUploadDetail();


                                    filedet.CompanyID = Convert.ToInt32(Session[ClsStatic.sessionCompanyID]);
                                    filedet.BranchID = Convert.ToInt32(Session[ClsStatic.sessionBranchID]);
                                    filedet.ReferenceNo = requisitionrefno;
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

                                _objFileUploadDetailController= new FileUploadDetailController ();

                                if (_objFileUploadDetailController.SqlInsertFileDet(cmd, filedett, lstfileDet))
                                {

                                    ClearAllItemHeader();

                                }

                                else
                                {

                                    myTrans.Rollback();
                                    return;
                                }

                            }

                            else
                            {


                            }


                        }
                        catch (Exception ex)
                        {

                            clsTopMostMessageBox.Show(ex.Message);

                        }

                        myTrans.Commit();
                        ClearAllItemHeader();
                    }

                    else
                    {
                        myTrans.Rollback();
                        return;
                      
                    }
                   
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

            lblporef.Text = _objRequisitionHeader.ItemRequisitionNo;
            showpop:
            if (lblref.Text != "")
            {
                lblporef.Text = lblref.Text;
            }

            ModalPopupExtender5.Show();   

        }

        private void SaveitemDetail( string refno)
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

                RequisitionDetail _objRequisitionDetail = new RequisitionDetail();

                _objRequisitionDetail.ItemRequisitionNo = refno;
                _objItemRequisitionDetailController = new ItemRequisitionDetailController();

                if (!_objItemRequisitionDetailController.DeleteRequisitionDetByRequisitionNo(cmd, _objRequisitionDetail))
                {
                    myTrans.Rollback();
                    return;
                }

                RequisitionDetail dett = new RequisitionDetail();
                List<RequisitionDetail> ItemList = new List<RequisitionDetail>();

                foreach (GridViewRow dr in gdvItemDetail.Rows)
                {
                    RequisitionDetail det = new RequisitionDetail();

                    det.ItemRequisitionNo = requisitionrefno;
                    det.InventoryItemID = Convert.ToInt32(dr.Cells[2].Text.Split(':')[0]);
                    det.RequiredItemName = dr.Cells[3].Text.Split(':')[0].ToString();
                    det.UnitID = Convert.ToInt32(dr.Cells[4].Text);
                    det.RequestedQuantity = Convert.ToDecimal(dr.Cells[6].Text);
                    det.PossibleRate = Convert.ToDecimal(dr.Cells[7].Text);
                    det.FinalQuantity = 0;         
                    det.CountryOfOrigin = dr.Cells[9].Text.Replace("&nbsp;", "");
                    det.Specification = dr.Cells[10].Text.Replace("&nbsp;", "");
                    det.Brand = dr.Cells[11].Text.Replace("&nbsp;", "");

                    ItemList.Add(det);

                }

                _objFileUploadDetailController = new FileUploadDetailController();

                _objFileUploadDetail = new FileUploadDetail();

                _objFileUploadDetail.ReferenceNo = refno;

                if (!_objFileUploadDetailController.DeleteFileUploadDetByRequisitionNo(cmd, _objFileUploadDetail))
                {
                    myTrans.Rollback();
                    return;
                }


                if (_objItemRequisitionDetailController.SqlInsertDet(cmd, dett, ItemList))
                {

                    FileUploadDetail filedett = new FileUploadDetail();
                    List<FileUploadDetail> lstfileDet = new List<FileUploadDetail>();


                    string fpath, floc;

                    for (int indexCounter = 0; indexCounter < FileList.Items.Count; indexCounter++)
                    {

                        FileUploadDetail filedet = new FileUploadDetail();


                        filedet.CompanyID = Convert.ToInt32(Session[ClsStatic.sessionCompanyID]);
                        filedet.BranchID = Convert.ToInt32(Session[ClsStatic.sessionBranchID]);
                        filedet.ReferenceNo = requisitionrefno;
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

                    _objFileUploadDetailController = new FileUploadDetailController();

                    if (_objFileUploadDetailController.SqlInsertFileDet(cmd, filedett, lstfileDet))
                    {

                        myTrans.Commit();
                        ClearAllItemHeader();

                    }

                    else
                    {

                        myTrans.Rollback();
                        return;
                    }

                  
                  
                }

                else
                {

                    myTrans.Rollback();
                    return;

                }

            }

            catch (Exception ex)
            {

                clsTopMostMessageBox.Show(ex.Message);
                return;

                

            }

            finally

            {
                myConnection.Close();
            
            }
           
           // Response.Redirect(Request.Url.AbsoluteUri);

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
           

            if (chkproject.Checked == true)
            {
                if (ddlProject.Text == "-1") return "Please Select project";
                        
            }

            DataTable dtemployee = new DataTable ();

            _objEmployeeInformationController = new EmployeeInformationController();

            dtemployee = _objEmployeeInformationController.GetEmployeeDetailByEmpID(txtRequestedBy.Text.Split(':')[0].ToString(), Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID]));

            if (dtemployee.Rows.Count == 0)
           {
               return "Please enter valid employee ID";
           
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
                    //trtest.Visible = false;
                    //tblitemdetautho.Visible = false;
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

       
        protected void gdvSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStatusforlabel.Visible = true;
            int indx = gdvSearchResult.SelectedIndex;

            if (indx != -1)
            {
                DataTable dt = new DataTable();
              string reqNo=  gdvSearchResult.Rows[indx].Cells[2].Text.ToString();
              int branchID = Convert.ToInt32(Session[ClsStatic.sessionBranchID]);
              int companyID = Convert.ToInt32(Session[ClsStatic.sessionCompanyID]);
              GetRequisitionInfo(reqNo, branchID, companyID);

              if (CheckCompleteStatus(reqNo, companyID, branchID) == "")
              {

                  btnPost.Visible = true;
                  btnReject.Visible = true;

              }

              else
              {
                  btnPost.Visible = false;
                  btnReject.Visible = false;

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
            //ddlunit.SelectedItem.Value  = "-1";      
            txtSpec.Text = "";
            txtBrand.Text = "";
            txtOrigin.Text = "";
           
        
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
                      //  pnlBillAttachment.Visible = true;

                        if (FileList.Items.Contains(new ListItem(savename)))
                        {
                            clsTopMostMessageBox.Show("File already in the ListBox");
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
                           // MessageBoxShow(this, "Add another file and click attach to attach in the list");
                        }

                    }
                    else
                    {
            
                        clsTopMostMessageBox.Show("File size cannot be 0");

                        return;
                    }
                }
                else
                {
                    clsTopMostMessageBox.Show("Please select a file to attach");
                    return;
                }

            }
            catch (Exception)
            {
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
                        clsTopMostMessageBox.Show("Please select a file to attach");
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
                        clsTopMostMessageBox.Show("File removed");



                        if (FileList.Items.Count == 0)
                        {
                            //pnlBillAttachment.Visible = false;
                        }
                    }
                }
            }
            catch
            {
                clsTopMostMessageBox.Show("Please try again with valid information");
                              
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
               
                ddlProject.Visible = false;
            }

            else
            {
               
                ddlProject.Visible = true;
            
            }

        }

        protected void ddlRequestedDept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
        
            if (ddlItemUserType.Text == "-1")
            {              
              clsTopMostMessageBox.Show("Please select user type");
               return;
            }

            try
            {

                GetClientAddress(txtUserName.Text.Split(':')[0].ToString());
            }

            catch( Exception ex)
            {

                clsTopMostMessageBox.Show(ex.Message);
           
            }
        }

        private void GetClientAddress(string address)
        {

            txtLocAddress.Text = "";

            DataTable dtaddreess = new DataTable();

            ClientInformationController _objClientInformationController = new ClientInformationController ();
            dtaddreess =  _objClientInformationController.GetClientAddress(address, Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID]));

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

            AutoUserName.ContextKey = userNmae.ToString() + ":" + Session[ClsStatic.sessionCompanyID].ToString() + ":" + Session[ClsStatic.sessionBranchID].ToString();

        }

        protected void gdvItemDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {

                e.Row.Cells[4].Visible = false;
                e.Row.Cells[3].Attributes["width"] = "200px";

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string refno = e.Row.Cells[2].Text;

                    foreach (TableCell cell in e.Row.Cells)
                    {

                       if (refno.Substring(2, 1) == "9")
                        {
                            cell.BackColor = Color.Bisque;
                        }

                    }
                }



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

       

        protected void btnPost_Click(object sender, EventArgs e)
        {        
            if (lblref.Text != "")
            {

                try
                {
                        string refno = lblref.Text;
                        DataTable dtItemRequisitionHdr = new DataTable();

                      _objItemRequisitionHeaderController = new ItemRequisitionHeaderController ();
                      dtItemRequisitionHdr = _objItemRequisitionHeaderController.GetDataRequisitionHdr(refno, Convert.ToInt32(Session[ClsStatic.sessionBranchID]), Convert.ToInt32(Session[ClsStatic.sessionCompanyID]));

                        if (dtItemRequisitionHdr.Rows.Count > 0)
                        {

                            try
                            {

                                _objItemRequisitionHeaderController.SqlUpdateCompleteStatus(refno, Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID]));
                                Response.Redirect(Request.Url.AbsoluteUri);

                              

                            }

                            catch(Exception ex)

                            {

                                clsTopMostMessageBox.Show(ex.Message);
                                return;
                            
                            }

                            
                        }
                  }

                catch (Exception ex)
                {
                    clsTopMostMessageBox.Show(ex.Message);
                
                }
            }   

        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            ItemSetup _objItemSetup = new ItemSetup();

            GetUnit(txtItem.Text.Split(':')[0].ToString(), Convert.ToInt32(Session[ClsStatic.sessionCompanyID]), Convert.ToInt32(Session[ClsStatic.sessionBranchID]));
            _objItemSetup.ItemCode = txtItem.Text.Split(':')[0].ToString();

            GetLastPurchaseCost(_objItemSetup);
        }

        private void GetUnit(string ItemCode ,int companyID, int branchID)
        {
            DataTable dtNewItem = new DataTable();
            ItemSetupController _objItemSetup = new ItemSetupController ();
            try
            {
                int icode = Convert.ToInt32(ItemCode);

                DataTable dtunit = new DataTable();
                dtunit = _objItemSetup.GetItemUnit(icode, companyID, branchID);

                if (dtunit.Rows.Count > 0)
                {
                    ddlunit.Text = dtunit.Rows[0]["UnitID"].ToString();
                    ddlunit.Enabled = false;
                }
            }

            catch

            {

                ddlunit.Text = "-1";
                ddlunit.Enabled = true;

            }
            

        }


        private void GetLastPurchaseCost(ItemSetup _objItemSetup)
        {
            DataTable dtItem = new DataTable();

            _objItemSetupController = new ItemSetupController();
            dtItem = _objItemSetupController.GetItemDetails2(_connectionString, _objItemSetup);

            if (dtItem != null)
            {

                if (dtItem.Rows.Count > 0)
                {
                    txtRate.Text = dtItem.Rows[0]["LastPurchaseCost"].ToString();
                    txtRate.Enabled = false;
                }
            }

            else
            {
                txtRate.Text = "";
                txtRate.Enabled = true;

            }
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnDownLoad_Click(object sender, EventArgs e)
        {
            string gg = lblDownloadSelectedFile.Text.Replace("amp;", "");
            String F1Path, F1Name;
            string abc = Server.MapPath("~/UploadFile/") + gg.ToString();
            F1Path = abc.ToString();

          

            F1Name = Path.GetFileName(F1Path);
            GetFile(F1Path, F1Name);       

        }
        private void GetFile(String strPath, String strSuggestedName)
        {
            if (strSuggestedName == "")
            {

                clsTopMostMessageBox.Show("Please select download file");
                return;
            }

            String strServerPath;
            System.IO.FileInfo objSourceFileInfo;
            strServerPath = this.Server.MapPath(strSuggestedName);
            objSourceFileInfo = new System.IO.FileInfo(strPath);
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + strSuggestedName);
            Response.AddHeader("Content-Length", objSourceFileInfo.Length.ToString());
            Response.WriteFile(objSourceFileInfo.FullName);
            Response.Flush();
            Response.End();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

  

       
        

    }
}