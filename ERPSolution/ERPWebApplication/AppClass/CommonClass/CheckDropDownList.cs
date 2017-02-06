using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI;
////using iTextSharp.text;


public class CheckDropDownList
{
    public CheckDropDownList()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static bool DDLNameEmptyCheck(DropDownList DDLName)
    {
        if (DDLName.Text.Equals("") || DDLName.Text.Equals("--please select--"))
        {
            //DDLName.ForeColor;
            //DDLName.BackColor = Color.Red;
            //ScriptManager.RegisterStartupScript(this, typeof(DropDownList), "focusOnDDL", "document.getElementById('DDLName').focus();", true);

            DDLName.Focus();
            return true;
        }
        else
        {
            //DDLName.BackColor = Color.Silver;
            return false;
        }
    }
    public static bool DDLNameEmptyCheck2(DropDownList DDLName, DropDownList DDLName2)
    {
        if (DDLName.Text.Equals("") || DDLName.Text.Equals("--please select--") || DDLName2.Text.Equals("") || DDLName2.Text.Equals("--please select--"))
        {
            if (DDLName.Text.Equals("") || DDLName.Text.Equals("--please select--"))
            {
                //DDLName.BackColor = Color.Red;
                //DDLName.ForeColor = Color.White;
                DDLName.Focus();
            }
            else
            {
                //DDLName2.BackColor = Color.Red;
                //DDLName.ForeColor = Color.White;
                DDLName2.Focus();
            }
            //MessageBox.Show("Please Enter Data Correctly", "Validation Error");
            //DDLName.BackColor = Color.White;
            //DDLName2.BackColor = Color.White;

            return true;
        }
        else 
            return false;
    }
    public static bool DDLNameEmptyCheck3(DropDownList DDLName, DropDownList DDLName1, DropDownList DDLName2)
    {
        if (DDLName.Text.Equals("") || DDLName.Text.Equals("--please select--") || DDLName1.Text.Equals("") || DDLName1.Text.Equals("--please select--") || DDLName2.Text.Equals("") || DDLName2.Text.Equals("--please select--"))
        {
            if (DDLName.Text.Equals("") || DDLName.Text.Equals("--please select--"))
            {
                //DDLName.BackColor = Color.Red;
                DDLName.Focus();
            }
            else if (DDLName1.Text.Equals("") || DDLName1.Text.Equals("--please select--"))
            {
                //DDLName1.BackColor = Color.Red;
                DDLName1.Focus();
            }
            
            else
            {
                //DDLName2.BackColor = Color.Red;
                DDLName2.Focus();
            }

            //MessageBox.Show("Please Enter Data Correctly", "Validation Error");
            //DDLName.BackColor = Color.White;
            //DDLName1.BackColor = Color.White;
            //DDLName2.BackColor = Color.White;
            return true;
        }
        else 
            return false;
    }
    public static bool DDLNameEmptyCheck4(DropDownList DDLName, DropDownList DDLName1, DropDownList DDLName2, DropDownList DDLName3)
    {
        if (DDLName.Text.Equals("") || DDLName.Text.Equals("--please select--") || DDLName1.Text.Equals("") || DDLName1.Text.Equals("--please select--") || DDLName2.Text.Equals("") || DDLName2.Text.Equals("--please select--") || DDLName3.Text.Equals("") || DDLName3.Text.Equals("--please select--"))
        {
            if (DDLName.Text.Equals("") || DDLName.Text.Equals("--please select--"))
            {
                //DDLName.BackColor = Color.Red;
                DDLName.Focus();
            }
            else if (DDLName1.Text.Equals("") || DDLName1.Text.Equals("--please select--"))
            {
                //DDLName1.BackColor = Color.Red;
                DDLName1.Focus();
            }
            else if (DDLName2.Text.Equals("") || DDLName2.Text.Equals("--please select--"))
            {
                //DDLName2.BackColor = Color.Red;
                DDLName2.Focus();
            }
            else
            {
                //DDLName3.BackColor = Color.Red;
                DDLName3.Focus();
            }
            
            //MessageBox.Show("Please Enter Data Correctly", "Validation Error");
            //DDLName.BackColor = Color.White;
            //DDLName1.BackColor = Color.White;
            //DDLName2.BackColor = Color.White;
            //DDLName3.BackColor = Color.White;
            return true;
        }
        else 
            return false;
    }
}
