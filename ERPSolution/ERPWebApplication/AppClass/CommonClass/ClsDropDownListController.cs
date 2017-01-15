using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.CommonClass
{
    public class ClsDropDownListController
    {


        public ClsDropDownListController()
        { }

        public static void LoadDropDownList(string connectionString, string sqlQueryString, DropDownList dropDownListName, string displayMember, string valueMember)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQueryString, connection);
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                dropDownListName.Items.Clear();
                if (dt.Rows.Count > 0)
                {
                    dropDownListName.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListItem lst = new ListItem();
                        lst.Value = dr[valueMember].ToString();
                        lst.Text = dr[displayMember].ToString();
                        dropDownListName.Items.Add(lst);
                    }
                }
                else
                {
                    dropDownListName.Items.Insert(0, new ListItem("--- No Data Found ---", "-1"));
                }
            }
            catch (Exception msgException)
            {
                throw msgException;
            }
        }

        public static void LoadDropDownListWithConcatenation(string connectionString, string sqlQueryString, DropDownList dropDownListName, string displayMember, string valueMember)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQueryString, connection);
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                dropDownListName.Items.Clear();
                dropDownListName.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Value = dr[valueMember].ToString();
                    lst.Text = dr[valueMember].ToString() + ":" + dr[displayMember].ToString();
                    dropDownListName.Items.Add(lst);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error occurred during access the server !");
            }
        }
        public static void LoadCheckBoxList(string connectionString, string sqlQueryString, CheckBoxList checkBoxName, string displayMember, string valueMember)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQueryString, connection);
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                checkBoxName.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Value = dr[valueMember].ToString();
                    lst.Text = dr[valueMember].ToString() + ":" + dr[displayMember].ToString();
                    checkBoxName.Items.Add(lst);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error occurred during access the server !");
            }
        }
    }
}