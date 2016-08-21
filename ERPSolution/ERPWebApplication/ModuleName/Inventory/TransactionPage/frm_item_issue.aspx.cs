using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication.ModuleName.Inventory.TransactionPage
{
    public partial class frm_item_issue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                lbl1.Visible = false;
               
             
                Label1.Visible = false;               
                tbladvsearch.Visible = false;               
                hradvsearch.Visible = false;                          
                hr2.Visible = false;
                lblreqstatus.Visible = false;
                lblstatus1.Visible = false;

                hr2.Visible = false;
                hradvsearchresult.Visible = true;


                tblhdr.Visible = false;
                tbldet.Visible = false;


                lblreqstatus.Visible = false;
                lblstatus1.Visible = false;
              //  tblcomm.Visible = false;

                loadgrid();          
                loadgrid2();



                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    gvrow.Cells[7].Visible = false ;

                }
              


           }
        }

        private void loadgrid()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("SL", typeof(Int32));
            dt.Columns.Add("Requisition Ref", typeof(string));     
            dt.Columns.Add("Date", typeof(string));         
            dt.Columns.Add("Total Amt", typeof(string));
            dt.Columns.Add("Status", typeof(string));

            int raw_no = 5;
            int i;

          
            for (i = 1; i <= raw_no; i++)
            {

                dt.Rows.Add(i, "REQ-20160820", "20-08-2016", "30000","Approved");


            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        private void loadgrid2()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("SL", typeof(Int32));
           
            dt.Columns.Add("Item Name", typeof(string));
            dt.Columns.Add("Rate", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));       
            dt.Columns.Add("Store", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
            dt.Columns.Add("Issue", typeof(string));

           




            int raw_no = 5;
            int i;

            for (i = 1; i <= raw_no; i++)
            {

                dt.Rows.Add(i,  "Computer", "10000", "03", "General Store", "3000","3");


            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            GridView1.HeaderRow.Cells[7].Visible = false;

          
           
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
            }

            else
            {
                lbl1.Visible = false;
                Label1.Visible = false;
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            tbladvsearch.Visible = false;
            hradvsearch.Visible = false;               
            messagewhere(btnsearch.Text);
            hr2.Visible = false;

            tblhdr.Visible = false;
            tbldet.Visible = false;
        }

        protected void btnadvsearch_Click(object sender, EventArgs e)
        {
            tbladvsearch.Visible = true;
            hradvsearch.Visible = true;             
            messagewhere(btnadvsearch.Text);
            hr2.Visible = false ;
            lblreqstatus.Visible = false;
            lblstatus1.Visible = false;


            hr2.Visible = false;

            tblhdr.Visible = false;
            tbldet.Visible = false;

        }

        protected void lnkbtnhideadv_Click(object sender, EventArgs e)
        {
            tbladvsearch.Visible = false; 
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {           
            loadgrid2();
            messagewhere(btnshow.Text);
            hr2.Visible = false ;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            tbladvsearch.Visible = false;
            hradvsearch.Visible = false;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {          
            hradvsearch.Visible = false;
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
         
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
            lbl1.Visible =true;
            Label1.Visible = false;
            tbladvsearch.Visible = false;
            hradvsearch.Visible = false;
            lblstatus1.Text = "";
            hr2.Visible = false;

            CollapsiblePanelExtender5.Collapsed = true;
            CollapsiblePanelExtender5.ClientState ="true";

            lblreqstatus.Visible = false;
            lblstatus1.Visible = false;
           
        }

        protected void btnnewprint_Click(object sender, EventArgs e)
        {        
            messagewhere(btnprint.Text);   
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
           
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

          

            else if (btnname == btnprint.Text)
            {
                lblwhere.Text = "You have command for print requisition";
            }

            else

            {

            lblwhere.Text = "You cleared the requisition detail";
            }


        
        }

        protected void btnsubmit0_Click1(object sender, EventArgs e)
        {
           // ddlforwardto.Enabled = true;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            loadgrid();

            if (GridView1.Rows.Count > 0)
            {
               // hradditem.Visible = true;
             
            }
            else
            {
               // hradditem.Visible = false;

            }

       
            hr2.Visible = true;
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {

           
        }

        protected void lnkbtn_Click(object sender, EventArgs e)
        {
            tblhdr.Visible = true;
            tbldet.Visible = true;


            hr2.Visible = true;
            hradvsearchresult.Visible = true;

            lblreqstatus.Visible = true;
            lblstatus1.Visible = true;
            lbl1.Visible = true;
        }

        protected void btnedit_Click1(object sender, EventArgs e)
        {
            
        }

       

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indx = GridView1.SelectedIndex;
            if (indx == -1) return;


            string sec = GridView1.Rows[indx].Cells[1].Text;
            //string itm = GridView1.Rows[indx].Cells[2].Text;


            CollapsiblePanelExtender6.Collapsed = false;
            CollapsiblePanelExtender6.ClientState = "false";


        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 0)
            {
                //e.Row.Cells[0].Visible = false;
                ////e.Row.Cells[3].Visible = false;
                //e.Row.Cells[4].Visible = false;
                //e.Row.Cells[5].Visible = false;
                ////e.Row.Cells[6].Visible = false;
               // e.Row.Cells[7].Visible = false;
                //e.Row.Cells[8].Visible = false;
                //e.Row.Cells[12].Visible = false;
                //e.Row.Cells[13].Visible = false;
                // e.Row.Cells[9].Visible = false;
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {

            GridView1.HeaderRow.Cells[7].Visible = true ;

            foreach (GridViewRow gvrow in GridView1.Rows)
           {
                gvrow.Cells[7].Visible = true;
                gvrow.Cells[7].Text = txtissue.Text;
           
           }
        }

     
    }
}