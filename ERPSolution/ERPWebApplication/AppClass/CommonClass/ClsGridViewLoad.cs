using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace ERPWebApplication.AppClass.CommonClass
{
    public class ClsGridViewLoad 
    {

        public ClsGridViewLoad()
        { }
        public static void ShowDataInGridView(DataTable dt, GridView GridViewName)
        {
            if (dt.Rows.Count > 0)
            {
                GridViewName.DataSource = dt;
                GridViewName.DataBind();
            }
            else if (dt.Rows.Count == 0)
            {
                ShowNoResultFound(dt, GridViewName);
            }
        }
        public static void ShowNoResultFound(DataTable source, GridView gv)
        {
            source.Rows.Add(source.NewRow());
            gv.DataSource = source;
            gv.DataBind();
            int columnsCount = gv.Columns.Count;
            gv.Rows[0].Cells.Clear();
            gv.Rows[0].Cells.Add(new TableCell());
            gv.Rows[0].Cells[0].ColumnSpan = columnsCount;

            gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            gv.Rows[0].Cells[0].Font.Bold = true;

            gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
            gv.FooterRow.Visible = true;
        }
        public static void LoadGridView(string connectionString, string sqlQueryString, GridView givenGridViewID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQueryString, connection);
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                givenGridViewID.DataSource = null;
                givenGridViewID.DataBind();
                if (dt.Rows.Count > 0)
                {
                    givenGridViewID.DataSource = dt;
                    givenGridViewID.DataBind();
                }

            }
            catch (Exception msgException)
            {
                throw msgException;
            }
        }
    }
}