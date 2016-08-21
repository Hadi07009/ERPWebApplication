using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication.ModuleName.Inventory.TransactionPage
{
    public partial class frm_item_requisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                lbl1.Visible = false;
                DropDownList7.Visible = false;
                tbldet.Visible = false;
                Label1.Visible = false;
               
                tbladvsearch.Visible = false;
                tbladvsearchresult.Visible = false;

                hradvsearch.Visible = false;
                hradvsearchresult.Visible = false;
               // hradditem.Visible = false;
                ddlforwardto.Enabled = false;
                hr2.Visible = false;
                lblreqstatus.Visible = false;
                lblstatus1.Visible = false;
                tblauthorization.Visible = false;
               
             
            }
        }



        private void loadgrid()
        {

            if (txtItem.Text == "")
            {
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("SL", typeof(Int32));
            dt.Columns.Add("Item Name", typeof(string));
            dt.Columns.Add("Rate", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
            dt.Columns.Add("Store", typeof(string));
            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("Specification", typeof(string));
            dt.Columns.Add("Origin", typeof(string));
            dt.Columns.Add("UOM", typeof(string));

            int raw_no = Convert.ToInt32(txtItem.Text);
            int i;

            if (raw_no > 0)
            {
                tbldet.Visible = true;
                btnsubmit.Visible = true;


            }
            else
            {

                tbldet.Visible = false;
                btnsubmit.Visible = false;

            }

            for (i = 1; i <= raw_no; i++)
            {

                dt.Rows.Add(i, "Computer", "10000", "03", "30000", "General Store", "Panasonic", "Japanese", "India", "PC");


            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        private void loadgrid2()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("SL", typeof(Int32));
            dt.Columns.Add("RefNo.", typeof(string));
            dt.Columns.Add("Item Name", typeof(string));
            dt.Columns.Add("Rate", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
            dt.Columns.Add("Store", typeof(string));


            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("Specification", typeof(string));
            dt.Columns.Add("Origin", typeof(string));


            int raw_no = 3;
            int i;

            for (i = 1; i <= raw_no; i++)
            {

                dt.Rows.Add(i, "20160803", "Computer", "10000", "03", "30000", "General Store", "Panasonic", "Japanese", "India");


            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }


        private void loadgrid3()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("SL", typeof(Int32));
            dt.Columns.Add("RefNo.", typeof(string));
            dt.Columns.Add("Item Name", typeof(string));
            dt.Columns.Add("Rate", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
            dt.Columns.Add("Store", typeof(string));


            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("Specification", typeof(string));
            dt.Columns.Add("Origin", typeof(string));


            int raw_no = 2;
            int i;

            for (i = 1; i <= raw_no; i++)
            {

                dt.Rows.Add(i, "20160803", "Computer", "10000", "03", "30000", "General Store", "Panasonic", "Japanese", "India");


            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked == true)
            {
                lbl1.Visible = true;
                Label1.Visible = true;

                DropDownList7.Visible = true;
            }

            else
            {
                lbl1.Visible = false;
                Label1.Visible = false;

                DropDownList7.Visible = false;

            }
        }

       

        protected void btnsearch_Click(object sender, EventArgs e)
        {
          
          
            tbladvsearch.Visible = false;
            hradvsearch.Visible = false;
            tbldet.Visible = false;
            Label2.Visible = false;
            tbladvsearchresult.Visible = false;
            hradvsearchresult.Visible = false;
          //  hradditem.Visible =false ;

            loadgrid3();
            tbldet.Visible = true;
            btnsubmit.Visible = false;
            btnnewReq.Visible = true;
         
            lblstatus1.Text = "Approved/Running";


            cpeheader.Collapsed = true ;
            cpeheader.ClientState = "true";

            messagewhere(btnsearch.Text);
            hr2.Visible = true; ;
            lblreqstatus.Visible = true;
            lblstatus1.Visible = true;

            ddlforwardto.Enabled = false;
            tblauthorization.Visible = false;
        }

        protected void btnadvsearch_Click(object sender, EventArgs e)
        {
            tbladvsearch.Visible = true;
            hradvsearch.Visible = true;
            tbldet.Visible = false;
         //   hradditem.Visible = false;
            tbldet.Visible = false ;
            btnnewReq.Visible = true;
            //GridView1.DataSource = null;
            //GridView1.DataBind();

            cpeheader.Collapsed = true;
            cpeheader.ClientState = "true";
            messagewhere(btnadvsearch.Text);
            hr2.Visible = false ;


            lblreqstatus.Visible = false;
            lblstatus1.Visible = false;

        }

        protected void lnkbtnhideadv_Click(object sender, EventArgs e)
        {
            tbladvsearch.Visible = false;
          
            tbladvsearchresult.Visible = false;
        }

       

        protected void btnshow_Click(object sender, EventArgs e)
        {
            tbladvsearchresult.Visible = true;
            loadgrid2();


            if (GridView2.Rows.Count == 0)
            {
                tbladvsearchresult.Visible = false;
                hradvsearchresult.Visible = false;
            }
            else
            {

                Label2.Text = GridView2.Rows.Count + " records found";
                hradvsearchresult.Visible = true;
                Label2.Visible = true;
            }

            messagewhere(btnshow.Text);
            hr2.Visible = false ;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            tbladvsearch.Visible = false;
        
      
            hradvsearch.Visible = false;
          
          //  hradditem.Visible = false;
            tbldet.Visible = false;

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
           
            hradvsearch.Visible = false;
            hradvsearchresult.Visible = false;
           // hradditem.Visible = false;
            tbldet.Visible = false;

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
            messagewhere(btnclearw.Text);
        }


        private void Clear()
        {
      
            txtItem.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtLoc.Text = string.Empty;
            txtOrigin.Text = string.Empty;
            txtSpec.Text = string.Empty;
            txtQunt.Text = string.Empty;
        
        }

        protected void btnclear_Click1(object sender, EventArgs e)
        {
            txtrequisitionid.Text = string.Empty;
            txtitmcode.Text = string.Empty;
            txtfrmdate.Text = string.Empty;
            txttodate.Text = string.Empty;
            messagewhere(btnclear.Text);
        }

        protected void btnnewReq_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            DropDownList7.Visible = false;
            tbldet.Visible = false;
            Label1.Visible = false;

            tbladvsearch.Visible = false;
            tbladvsearchresult.Visible = false;


            hradvsearch.Visible = false;
            hradvsearchresult.Visible = false;
          //  hradditem.Visible = false;
            lblstatus1.Text = "";


            cpeheader.Collapsed = false;
            cpeheader.ClientState = "false";
            messagewhere(btnnewReq.Text);
            hr2.Visible = false;

            CollapsiblePanelExtender5.Collapsed = true;
            CollapsiblePanelExtender5.ClientState ="true";

            lblreqstatus.Visible = false;
            lblstatus1.Visible = false;
           
        }

        protected void btnnewprint_Click(object sender, EventArgs e)
        {        
            messagewhere(btnnewprint.Text);   
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            messagewhere(btnsubmit.Text);
        }

        private void  messagewhere(string btnname)
        {

       

            if (btnname == btnsearch.Text)
             {

            lblwhere.Text = "You are searching for " + btnname+" requisition";

             }

            else if (btnname == btnadvsearch.Text)
             {

            lblwhere.Text = "You are searching for " + btnname + " requisition";

             }

            else if (btnname == btnshow.Text)
            {
                lblwhere.Text = "You are searching for " + btnname + " advanced search requisition";
            }

            else if (btnname == btnclear.Text)
            {
                lblwhere.Text = "You are searching for " + btnname + " requisition";
            }

            else if (btnname == btnnewReq.Text)
            {
                lblwhere.Text = "You are entering new requisition";
            }

            else if (btnname == btnnewprint.Text)
            {
                lblwhere.Text = "You have command for print requisition";
            }

            else if (btnname == btnsubmit.Text)
            {
                lblwhere.Text = "You have submit requisition for save";
            }

            else if (btnname == btnadd.Text)
            {
                lblwhere.Text = "You adding item in requisition list ";
            }

            else

            {

            lblwhere.Text = "You cleared the requisition detail";
            }


        
        }

        protected void btnsubmit0_Click1(object sender, EventArgs e)
        {
            ddlforwardto.Enabled = true;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            loadgrid();

            if (GridView1.Rows.Count > 0)
            {
               // hradditem.Visible = true;
                btnsubmit.Visible = true;
                tblauthorization.Visible = true;
            }
            else
            {
               // hradditem.Visible = false;

            }

            messagewhere(btnadd.Text);
            hr2.Visible = true;
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {

            if (btnedit.Text == "Enable")
            {

                ddlforwardto.Enabled = true;
                btnedit.Text = "Disable";
            }

            else
            {
                ddlforwardto.Enabled = false ;
                btnedit.Text = "Enable";
            
            }
        }

        
    }
}