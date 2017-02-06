using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPWebApplication.AppClass.CommonClass
{
    public class ClsListBoxController
    {
        public static void LoadListBox(string connectionString, string sqlQueryString, ListBox ListBoxName, string displayMember, string valueMember)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQueryString, connection);
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                ListBoxName.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Value = dr[valueMember].ToString();
                    lst.Text = dr[displayMember].ToString();
                    ListBoxName.Items.Add(lst);
                }
                
            }
            catch (Exception msgException)
            {
                throw msgException;
            }
        }
    }
}