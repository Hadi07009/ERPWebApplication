using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWebApplication.ModuleName.Inventory.TransactionPage
{
    public partial class frm_item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               
                loadgrid();
                lblreqstatus.Visible = false;


                //button
                btnprintrequisition.Enabled = false;



                //table

                tbladvsearch.Visible = false;
                tbladvsearchresult.Visible = false;
                tblauthorization.Visible = false;
                tblitemdet.Visible = false;

                //hr 

                searchbottom.Visible = true;
                
                advsearchbottom.Visible = false;
                headertop.Visible = false;
             


                //Collapsible

                cpeheader.Collapsed =true;
                cpeheader.ClientState = "true";
               
           }
        }

        protected void btnadvsearch_Click(object sender, EventArgs e)
        {
            tbladvsearch.Visible = true ;
            searchbottom.Visible = true;
            advsearchbottom.Visible = true;

            searchbottom.Visible = true;

            

          
        }

        protected void imgbtnadsearch_Click(object sender, ImageClickEventArgs e)
        {
            tbladvsearch.Visible = false ;
            searchbottom.Visible = true ;

            advsearchbottom.Visible = false ;

       
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            tbladvsearchresult.Visible = true;
            loadgrid2();
            advsearchbottom.Visible = true;
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


        private void loadgrid()
        {

            //if (txtItem.Text == "")
            //{
            //    return;
            //}

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

            //int raw_no = Convert.ToInt32(txtItem.Text);
            int i;

          //  if (raw_no > 0)
          //  {
               // tbldet.Visible = true;
              //  btnsubmit.Visible = true;


          //  }
          //  else
           // {

               // tbldet.Visible = false;
             //   btnsubmit.Visible = false;

         //   }

            for (i = 1; i <= 3; i++)
            {

                dt.Rows.Add(i, "Computer", "10000", "03", "30000", "General Store", "Panasonic", "Japanese", "India", "PC");


            }
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }

        protected void btnnewReq_Click(object sender, EventArgs e)
        {
            cpeheader.Collapsed = false;
            cpeheader.ClientState = "false";
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            tblauthorization.Visible = true;
            tblitemdet.Visible = true;
        }

     

      

        


      
    }
}