using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.CommonClass
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

        public static DataSet ShowDataInGridView(String queryString, GridView GridViewName)
        {
            String connectionString = System.Configuration.ConfigurationManager.AppSettings["UbasysConnectionString"].ToString();
            DataSet ds = new DataSet();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridViewName.DataSource = ds;
                    GridViewName.DataBind();
                }
                else if (ds.Tables[0].Rows.Count == 0)
                {
                    DataTable dt = ds.Tables[0];
                    ShowNoResultFound(dt, GridViewName);
                }
            }
            catch (Exception ex)
            {

            }
            return ds;
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
        public static DataSet GetData(String queryString, GridView GridViewName)
        {
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbERPSolutionConnection"].ToString();
            DataSet ds = new DataSet();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridViewName.DataSource = ds;
                    GridViewName.DataBind();
                }
                else if (ds.Tables[0].Rows.Count == 0)
                {
                    DataTable dt = ds.Tables[0];
                    ShowNoResultFound(dt, GridViewName);
                }
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

    }
}