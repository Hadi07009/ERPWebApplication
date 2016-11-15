using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ClsDropDownListController
/// </summary>
public class ClsDropDownListController
{
	public ClsDropDownListController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void LoadDropDownList(string connectionString, string sqlQueryString, DropDownList dropDownListName, string displayMember, string valueMember)
    {
        var ds = new DataSet();
        var connection = new SqlConnection(connectionString);
        try
        {
            var adapter = new SqlDataAdapter(sqlQueryString, connection);
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            dropDownListName.Items.Clear();
            dropDownListName.Items.Insert(0, new ListItem("--- Please Select ---", "-1"));
            foreach (var lst in from DataRow dr in dt.Rows select new ListItem { Value = dr[valueMember].ToString(), Text = dr[displayMember].ToString() })
            {
                dropDownListName.Items.Add(lst);
            }
        }
        catch (SqlException msgException)
        {
            throw msgException;
        }
    }
}